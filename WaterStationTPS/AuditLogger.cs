using System;
using System.Data;
using System.Data.SqlClient;

namespace WaterStationTPS
{
    public static class UserSession
    {
        public static string CurrentUsername { get; set; } = "Admin";
        public static int CurrentUserId { get; set; } = 1;
    }

    public static class AuditLogger
    {
        private static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=WaterStationDB;Integrated Security=True;TrustServerCertificate=True;";

        public static void EnsureAuditLogsTableExists(SqlConnection? conn = null, SqlTransaction? trans = null)
        {
            EnsureTransactionsTableStructure(conn, trans);
            string sql = @"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'AuditLogs')
                BEGIN
                    CREATE TABLE AuditLogs (
                        LogID INT IDENTITY(1,1) PRIMARY KEY,
                        Username NVARCHAR(100) NULL,
                        ActionType NVARCHAR(50) NULL,
                        TableAffected NVARCHAR(100) NULL,
                        RecordID INT NULL,
                        RecordReference NVARCHAR(200) NULL,
                        Details NVARCHAR(MAX) NULL,
                        Timestamp DATETIME NOT NULL DEFAULT GETDATE()
                    );
                END
                ELSE
                BEGIN
                    IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('AuditLogs') AND name = 'RecordID' AND is_nullable = 0)
                    BEGIN
                        ALTER TABLE AuditLogs ALTER COLUMN RecordID INT NULL;
                    END

                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('AuditLogs') AND name = 'RecordID')
                    BEGIN
                        ALTER TABLE AuditLogs ADD RecordID INT NULL;
                    END

                    IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('AuditLogs') AND name = 'RecordReference' AND is_nullable = 0)
                    BEGIN
                        ALTER TABLE AuditLogs ALTER COLUMN RecordReference NVARCHAR(200) NULL;
                    END

                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('AuditLogs') AND name = 'RecordReference')
                    BEGIN
                        ALTER TABLE AuditLogs ADD RecordReference NVARCHAR(200) NULL;
                    END

                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('AuditLogs') AND name = 'Details')
                    BEGIN
                        ALTER TABLE AuditLogs ADD Details NVARCHAR(MAX) NULL;
                    END

                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('AuditLogs') AND name = 'TableAffected')
                    BEGIN
                        ALTER TABLE AuditLogs ADD TableAffected NVARCHAR(100) NULL;
                    END

                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('AuditLogs') AND name = 'Username')
                    BEGIN
                        ALTER TABLE AuditLogs ADD Username NVARCHAR(100) NULL;
                    END

                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('AuditLogs') AND name = 'ActionType')
                    BEGIN
                        ALTER TABLE AuditLogs ADD ActionType NVARCHAR(50) NULL;
                    END
                END";

            try
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (SqlConnection freshConn = new SqlConnection(connectionString))
                    {
                        freshConn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, freshConn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("EnsureAuditLogsTableExists warning: " + ex.Message);
            }
        }

        public static void EnsureTransactionsTableStructure(SqlConnection? conn = null, SqlTransaction? trans = null)
        {
            string sql = @"
                IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Transactions')
                BEGIN
                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Transactions') AND name = 'ChangeAmount')
                    BEGIN
                        ALTER TABLE Transactions ADD ChangeAmount DECIMAL(18, 2) NOT NULL DEFAULT 0.00;
                    END
                END
                IF EXISTS (SELECT * FROM sys.tables WHERE name = 'Customers')
                BEGIN
                    IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('Customers') AND name = 'RemainingChange')
                    BEGIN
                        ALTER TABLE Customers ADD RemainingChange DECIMAL(18, 2) NOT NULL DEFAULT 0.00;
                    END
                END";

            try
            {
                if (conn != null)
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (SqlConnection freshConn = new SqlConnection(connectionString))
                    {
                        freshConn.Open();
                        using (SqlCommand cmd = new SqlCommand(sql, freshConn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("EnsureTransactionsTableStructure warning: " + ex.Message);
            }
        }

        public static void LogAction(string actionType, string tableAffected, string recordReference, string details, SqlConnection? existingConn = null, SqlTransaction? existingTrans = null)
        {
            string username = string.IsNullOrWhiteSpace(UserSession.CurrentUsername) ? "Admin" : UserSession.CurrentUsername;
            DateTime timestamp = DateTime.Now;

            // Extract numeric ID from record reference if available (e.g. "Customer #10" -> 10)
            int recordId = 0;
            if (!string.IsNullOrWhiteSpace(recordReference))
            {
                int hashIdx = recordReference.IndexOf('#');
                if (hashIdx >= 0)
                {
                    string idPart = "";
                    for (int i = hashIdx + 1; i < recordReference.Length && char.IsDigit(recordReference[i]); i++)
                    {
                        idPart += recordReference[i];
                    }
                    if (int.TryParse(idPart, out int parsedId))
                    {
                        recordId = parsedId;
                    }
                }
            }

            string insertSql = @"
                INSERT INTO AuditLogs (Username, ActionType, TableAffected, RecordID, RecordReference, Details, Timestamp)
                VALUES (@username, @actionType, @tableAffected, @recordId, @recordReference, @details, @timestamp)";

            // 1. If we have an active transaction, try executing within the transaction
            if (existingConn != null && existingTrans != null && existingConn.State == ConnectionState.Open)
            {
                try
                {
                    EnsureAuditLogsTableExists(existingConn, existingTrans);
                    using (SqlCommand cmd = new SqlCommand(insertSql, existingConn, existingTrans))
                    {
                        cmd.Parameters.AddWithValue("@username", username ?? "Admin");
                        cmd.Parameters.AddWithValue("@actionType", actionType ?? "System");
                        cmd.Parameters.AddWithValue("@tableAffected", tableAffected ?? string.Empty);
                        cmd.Parameters.AddWithValue("@recordId", recordId);
                        cmd.Parameters.AddWithValue("@recordReference", recordReference ?? string.Empty);
                        cmd.Parameters.AddWithValue("@details", details ?? string.Empty);
                        cmd.Parameters.AddWithValue("@timestamp", timestamp);
                        cmd.ExecuteNonQuery();
                    }
                    return;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Transactional Audit Log failed: " + ex.Message);
                }
            }

            // 2. Always use an independent connection to guarantee audit log insertion
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    EnsureAuditLogsTableExists(conn);
                    using (SqlCommand cmd = new SqlCommand(insertSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username ?? "Admin");
                        cmd.Parameters.AddWithValue("@actionType", actionType ?? "System");
                        cmd.Parameters.AddWithValue("@tableAffected", tableAffected ?? string.Empty);
                        cmd.Parameters.AddWithValue("@recordId", recordId);
                        cmd.Parameters.AddWithValue("@recordReference", recordReference ?? string.Empty);
                        cmd.Parameters.AddWithValue("@details", details ?? string.Empty);
                        cmd.Parameters.AddWithValue("@timestamp", timestamp);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Independent Audit Log error: " + ex.Message);
            }
        }
    }
}
