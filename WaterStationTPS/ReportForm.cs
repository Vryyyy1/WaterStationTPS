using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WaterStationTPS
{
    public partial class ReportForm : Form
    {
        private string connString = @"Server=(localdb)\MSSQLLocalDB;Database=WaterStationDB;Integrated Security=True;TrustServerCertificate=True;";

        public ReportForm()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            panelHeader.Paint += PanelHeader_Paint;
            panelCardBalance.Paint += (s, e) => DrawCardPanel(panelCardBalance, e);
            panelCardJugs.Paint += (s, e) => DrawCardPanel(panelCardJugs, e);
            panelCardChange.Paint += (s, e) => DrawCardPanel(panelCardChange, e);
            panelGridCard.Paint += (s, e) => DrawCardPanel(panelGridCard, e);
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            StyleDataGridView();
            LoadReportData();
        }

        private void StyleDataGridView()
        {
            dgvReport.EnableHeadersVisualStyles = false;
            dgvReport.BorderStyle = BorderStyle.None;
            dgvReport.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvReport.GridColor = Color.FromArgb(226, 232, 240);
            dgvReport.BackgroundColor = Color.White;
            dgvReport.RowTemplate.Height = 36;

            dgvReport.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 114, 255);
            dgvReport.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvReport.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            dgvReport.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvReport.ColumnHeadersHeight = 40;

            dgvReport.DefaultCellStyle.BackColor = Color.White;
            dgvReport.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgvReport.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvReport.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvReport.DefaultCellStyle.SelectionForeColor = Color.FromArgb(2, 132, 199);

            dgvReport.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvReport.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvReport.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(2, 132, 199);
        }

        private void PanelHeader_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            using (LinearGradientBrush brush = new LinearGradientBrush(
                panelHeader.ClientRectangle,
                Color.FromArgb(0, 114, 255),
                Color.FromArgb(0, 210, 255),
                0f))
            {
                e.Graphics.FillRectangle(brush, panelHeader.ClientRectangle);
            }

            // Title Text with soft subtle drop shadow
            string title = "Summary & Reporting Module";
            using (Font titleFont = new Font("Segoe UI", 15f, FontStyle.Bold))
            {
                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(80, 0, 40, 100)))
                {
                    e.Graphics.DrawString(title, titleFont, shadowBrush, 25, 13);
                }
                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    e.Graphics.DrawString(title, titleFont, textBrush, 24, 12);
                }
            }

            // Subtitle Text
            string subtitle = "Outstanding Balances & Jug Inventory Overview";
            using (Font subFont = new Font("Segoe UI", 9.5f, FontStyle.Regular))
            {
                using (SolidBrush subBrush = new SolidBrush(Color.FromArgb(224, 242, 254)))
                {
                    e.Graphics.DrawString(subtitle, subFont, subBrush, 25, 42);
                }
            }
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

            // Top Left
            path.AddArc(arc, 180, 90);

            // Top Right
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom Right
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom Left
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadReportData();
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

        private void FormatReportGridColumns(DataGridView? dgv)
        {
            if (dgv == null || dgv.Columns.Count == 0) return;

            try
            {
                dgv.AutoGenerateColumns = false;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.RowHeadersVisible = false;
                dgv.ScrollBars = ScrollBars.Both;

                if (dgv.Columns.Contains("CustomerID") && dgv.Columns["CustomerID"] is DataGridViewColumn colId)
                {
                    colId.HeaderText = "ID";
                    colId.MinimumWidth = 50;
                    colId.FillWeight = 40;
                    SetColumnStyle(colId, DataGridViewContentAlignment.MiddleCenter);
                }
                if (dgv.Columns.Contains("FullName") && dgv.Columns["FullName"] is DataGridViewColumn colName)
                {
                    colName.HeaderText = "Customer Name";
                    colName.MinimumWidth = 140;
                    colName.FillWeight = 120;
                }
                if (dgv.Columns.Contains("Phone") && dgv.Columns["Phone"] is DataGridViewColumn colPhone)
                {
                    colPhone.HeaderText = "Contact No.";
                    colPhone.MinimumWidth = 110;
                    colPhone.FillWeight = 85;
                }
                if (dgv.Columns.Contains("BorrowedJugs") && dgv.Columns["BorrowedJugs"] is DataGridViewColumn colJugs)
                {
                    colJugs.HeaderText = "Borrowed Jugs";
                    colJugs.MinimumWidth = 90;
                    colJugs.FillWeight = 75;
                    SetColumnStyle(colJugs, DataGridViewContentAlignment.MiddleCenter);
                }
                if (dgv.Columns.Contains("UnpaidBalance") && dgv.Columns["UnpaidBalance"] is DataGridViewColumn colBal)
                {
                    colBal.HeaderText = "Unpaid Balance";
                    colBal.MinimumWidth = 100;
                    colBal.FillWeight = 85;
                    SetColumnStyle(colBal, DataGridViewContentAlignment.MiddleRight, "₱#,##0.00");
                }
                if (dgv.Columns.Contains("RemainingChange") && dgv.Columns["RemainingChange"] is DataGridViewColumn colChange)
                {
                    colChange.HeaderText = "Remaining Change";
                    colChange.MinimumWidth = 110;
                    colChange.FillWeight = 90;
                    SetColumnStyle(colChange, DataGridViewContentAlignment.MiddleRight, "₱#,##0.00");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("FormatReportGridColumns warning: " + ex.Message);
            }
        }

        private void LoadReportData()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    AuditLogger.EnsureTransactionsTableStructure(conn);

                    // 1. Calculate Summary Metrics (Unpaid Balance, Borrowed Jugs, and Total Change Processed)
                    string summaryQuery = @"SELECT ISNULL(SUM(c.UnpaidBalance), 0) AS TotalBalance, 
                                                   ISNULL(SUM(c.BorrowedJugs), 0) AS TotalJugs,
                                                   ISNULL(SUM(c.RemainingChange), 0) AS TotalChange 
                                            FROM Customers c";
                    using (SqlCommand cmd = new SqlCommand(summaryQuery, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal totalBalance = reader["TotalBalance"] != DBNull.Value ? Convert.ToDecimal(reader["TotalBalance"]) : 0;
                                int totalJugs = reader["TotalJugs"] != DBNull.Value ? Convert.ToInt32(reader["TotalJugs"]) : 0;
                                decimal totalChange = reader["TotalChange"] != DBNull.Value ? Convert.ToDecimal(reader["TotalChange"]) : 0;

                                lblTotalBalance.Text = $"₱{totalBalance:N2}";
                                lblTotalJugs.Text = $"{totalJugs:N0}";
                                lblTotalChange.Text = $"₱{totalChange:N2}";
                            }
                        }
                    }

                    // 2. Fetch Customers who have outstanding balances, borrowed jugs, or change history
                    string gridQuery = @"SELECT c.CustomerID, c.FullName, c.Phone, c.BorrowedJugs, c.UnpaidBalance, 
                                                ISNULL(c.RemainingChange, 0.00) AS RemainingChange
                                         FROM Customers c
                                         WHERE c.BorrowedJugs > 0 OR c.UnpaidBalance > 0 OR c.RemainingChange > 0
                                         ORDER BY c.UnpaidBalance DESC, c.BorrowedJugs DESC, c.RemainingChange DESC";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(gridQuery, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvReport.DataSource = dt;
                        FormatReportGridColumns(dgvReport);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to generate report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- Empty Event Handlers to Resolve Designer Errors ---
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void lblTotalJugs_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
