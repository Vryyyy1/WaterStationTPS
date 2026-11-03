using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WaterStationTPS
{
    public partial class AuditLogForm : Form
    {
        private string connString = @"Server=(localdb)\MSSQLLocalDB;Database=WaterStationDB;Integrated Security=True;TrustServerCertificate=True;";

        public AuditLogForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            panelGridCard.Paint += (s, e) => DrawCardPanel(panelGridCard, e);
        }

        private void AuditLogForm_Load(object sender, EventArgs e)
        {
            StyleDataGridView();
            LoadAuditLogsData();
        }

        private void StyleDataGridView()
        {
            dgvAudit.EnableHeadersVisualStyles = false;
            dgvAudit.BorderStyle = BorderStyle.None;
            dgvAudit.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAudit.GridColor = Color.FromArgb(226, 232, 240);
            dgvAudit.BackgroundColor = Color.White;
            dgvAudit.RowTemplate.Height = 36;
            dgvAudit.RowHeadersVisible = false;
            dgvAudit.AllowUserToResizeRows = false;
            dgvAudit.AllowUserToResizeColumns = true;
            dgvAudit.ScrollBars = ScrollBars.Both;

            dgvAudit.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvAudit.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAudit.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvAudit.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvAudit.ColumnHeadersHeight = 40;

            dgvAudit.DefaultCellStyle.BackColor = Color.White;
            dgvAudit.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvAudit.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvAudit.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvAudit.DefaultCellStyle.SelectionForeColor = Color.FromArgb(2, 132, 199);
            dgvAudit.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);

            dgvAudit.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvAudit.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvAudit.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(2, 132, 199);
        }

        private void DrawCardPanel(Panel panel, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = panel.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            int radius = 16;
            using (GraphicsPath path = GetRoundedRectanglePath(rect, radius))
            {
                using (SolidBrush bgBrush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillPath(bgBrush, path);
                }
                using (Pen borderPen = new Pen(Color.FromArgb(226, 232, 240), 1f))
                {
                    e.Graphics.DrawPath(borderPen, path);
                }
            }

            using (GraphicsPath clipPath = GetRoundedRectanglePath(panel.ClientRectangle, radius))
            {
                panel.Region = new Region(clipPath);
            }
        }

        private GraphicsPath GetRoundedRectanglePath(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAuditLogsData();
        }

        private void LoadAuditLogsData()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    AuditLogger.EnsureAuditLogsTableExists(conn);

                    string query = "SELECT LogID, Timestamp, Username, ActionType, TableAffected, RecordReference, Details FROM AuditLogs ORDER BY LogID DESC";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvAudit.DataSource = dt;
                        FormatAuditGridColumns(dgvAudit);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to load audit logs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetColumnStyle(DataGridViewColumn col, DataGridViewContentAlignment align, string? format = null)
        {
            if (col == null) return;
            if (col.DefaultCellStyle == null) col.DefaultCellStyle = new DataGridViewCellStyle();
            col.DefaultCellStyle.Alignment = align;
            if (format != null) col.DefaultCellStyle.Format = format;

            if (col.HeaderCell != null)
            {
                if (col.HeaderCell.Style == null) col.HeaderCell.Style = new DataGridViewCellStyle();
                col.HeaderCell.Style.Alignment = align;
            }
        }

        private void FormatAuditGridColumns(DataGridView? dgv)
        {
            if (dgv == null || dgv.Columns.Count == 0) return;

            dgv.AutoGenerateColumns = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.RowHeadersVisible = false;
            dgv.ScrollBars = ScrollBars.Both;

            if (dgv.Columns.Contains("LogID") && dgv.Columns["LogID"] is DataGridViewColumn colLogId)
            {
                colLogId.HeaderText = "Log #";
                colLogId.Width = 75;
                colLogId.MinimumWidth = 65;
                SetColumnStyle(colLogId, DataGridViewContentAlignment.MiddleCenter);
            }
            if (dgv.Columns.Contains("Timestamp") && dgv.Columns["Timestamp"] is DataGridViewColumn colTime)
            {
                colTime.HeaderText = "Date & Time";
                colTime.Width = 175;
                colTime.MinimumWidth = 150;
                SetColumnStyle(colTime, DataGridViewContentAlignment.MiddleLeft, "MM/dd/yyyy hh:mm:ss tt");
            }
            if (dgv.Columns.Contains("Username") && dgv.Columns["Username"] is DataGridViewColumn colUser)
            {
                colUser.HeaderText = "User Captured";
                colUser.Width = 130;
                colUser.MinimumWidth = 110;
                SetColumnStyle(colUser, DataGridViewContentAlignment.MiddleLeft);
            }
            if (dgv.Columns.Contains("ActionType") && dgv.Columns["ActionType"] is DataGridViewColumn colAction)
            {
                colAction.HeaderText = "Action Type";
                colAction.Width = 110;
                colAction.MinimumWidth = 95;
                SetColumnStyle(colAction, DataGridViewContentAlignment.MiddleCenter);
            }
            if (dgv.Columns.Contains("TableAffected") && dgv.Columns["TableAffected"] is DataGridViewColumn colTable)
            {
                colTable.HeaderText = "Module / Table";
                colTable.Width = 130;
                colTable.MinimumWidth = 110;
                SetColumnStyle(colTable, DataGridViewContentAlignment.MiddleLeft);
            }
            if (dgv.Columns.Contains("RecordReference") && dgv.Columns["RecordReference"] is DataGridViewColumn colRef)
            {
                colRef.HeaderText = "Record Reference";
                colRef.Width = 220;
                colRef.MinimumWidth = 160;
                SetColumnStyle(colRef, DataGridViewContentAlignment.MiddleLeft);
            }
            if (dgv.Columns.Contains("Details") && dgv.Columns["Details"] is DataGridViewColumn colDetails)
            {
                colDetails.HeaderText = "Audit Details";
                colDetails.MinimumWidth = 260;
                colDetails.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                SetColumnStyle(colDetails, DataGridViewContentAlignment.MiddleLeft);
            }
        }
    }
}
