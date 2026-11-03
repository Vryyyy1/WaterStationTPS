using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WaterStationTPS
{
    public partial class Form1 : Form
    {
        // Connection string matching SQL Server LocalDB database
        private string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=WaterStationDB;Integrated Security=True;TrustServerCertificate=True;";

        private bool isLogoutHovered = false;
        private bool isDashRefreshHovered = false;
        private bool isAuditRefreshHovered = false;
        private ModernToolStripRenderer modernRenderer;

        private decimal currentCustUnpaid = 0.00m;
        private int currentCustBorrowed = 0;
        private decimal currentCustRemainingChange = 0.00m;

        public Form1()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            // Form Header & Logout Styling
            panelHeader.Paint += PanelHeader_Paint;
            panelHeader.Resize += (s, e) => panelHeader.Invalidate();
            btnLogout.Paint += BtnLogout_Paint;
            btnLogout.MouseEnter += (s, e) => { isLogoutHovered = true; btnLogout.Invalidate(); };
            btnLogout.MouseLeave += (s, e) => { isLogoutHovered = false; btnLogout.Invalidate(); };

            // Dashboard Cards & Components
            panel1.Paint += (s, e) => DrawStatCard(panel1, Color.FromArgb(0, 114, 255), e);
            panel2.Paint += (s, e) => DrawStatCard(panel2, Color.FromArgb(245, 158, 11), e);
            panel3.Paint += (s, e) => DrawStatCard(panel3, Color.FromArgb(225, 29, 72), e);
            panelRecentCard.Paint += (s, e) => DrawCardPanel(panelRecentCard, e);

            btnDashRefresh.Paint += (s, e) => DrawPillButton(btnDashRefresh, isDashRefreshHovered, e);
            btnDashRefresh.MouseEnter += (s, e) => { isDashRefreshHovered = true; btnDashRefresh.Invalidate(); };
            btnDashRefresh.MouseLeave += (s, e) => { isDashRefreshHovered = false; btnDashRefresh.Invalidate(); };
            btnDashRefresh.Click += (s, e) => LoadDashboardData();

            panelDashboard.Resize += PanelDashboard_Resize;

            // Customers Module Cards & Buttons
            panelLeft.Paint += (s, e) => DrawCardPanel(panelLeft, e);
            panelRight.Paint += (s, e) => DrawCardPanel(panelRight, e);
            btnRefreshCust.Click += (s, e) => LoadCustomersData();

            // Transactions Module Cards & Components
            panelTransForm.Paint += (s, e) => DrawCardPanel(panelTransForm, e);
            panelTransGrid.Paint += (s, e) => DrawCardPanel(panelTransGrid, e);
            pnlTransSummary.Paint += (s, e) => DrawSubCard(pnlTransSummary, e);
            pnlTransCustInfo.Paint += (s, e) => DrawSubCard(pnlTransCustInfo, e);
            pnlUpdateSummary.Paint += (s, e) => DrawSubCard(pnlUpdateSummary, e);
            btnRefreshTrans.Click += (s, e) => LoadTransactionsData();
            btnModeNewOrder.Click += btnModeNewOrder_Click;
            btnModeUpdateCust.Click += btnModeUpdateCust_Click;
            btnSaveTransCust.Click += btnSaveTransCust_Click;
            numUpdatePay.ValueChanged += (s, e) => UpdateCustomerUpdatePreview();
            numUpdatePay.KeyUp += (s, e) => UpdateCustomerUpdatePreview();
            numUpdateReturned.ValueChanged += (s, e) => UpdateCustomerUpdatePreview();
            numUpdateReturned.KeyUp += (s, e) => UpdateCustomerUpdatePreview();
            dgvTransactions.CellClick += dgvTransactions_CellClick;

            numTransQty.ValueChanged += (s, e) => UpdateOrderTotal();
            numTransQty.KeyUp += (s, e) => UpdateOrderTotal();
            numTransQty.TextChanged += (s, e) => UpdateOrderTotal();
            numTransCashPaid.ValueChanged += (s, e) => UpdateOrderTotal();
            numTransCashPaid.KeyUp += (s, e) => UpdateOrderTotal();
            txtUnitPrice.TextChanged += (s, e) => UpdateOrderTotal();
            txtUnitPrice.SelectedIndexChanged += (s, e) => UpdateOrderTotal();
            cmbPaymentStatus.SelectedIndexChanged += (s, e) => UpdateOrderTotal();
            cmbTransCustomer.SelectedIndexChanged += (s, e) => UpdateCustomerJugsState();
            cmbTransCustomer.TextChanged += (s, e) => UpdateCustomerJugsState();

            // Inventory Module Cards & Components
            pnlTotalStock.Paint += (s, e) => DrawStatCard(pnlTotalStock, Color.FromArgb(0, 114, 255), e);
            pnlJugsOut.Paint += (s, e) => DrawStatCard(pnlJugsOut, Color.FromArgb(245, 158, 11), e);
            pnlOverdue.Paint += (s, e) => DrawStatCard(pnlOverdue, Color.FromArgb(225, 29, 72), e);
            panelReturnCard.Paint += (s, e) => DrawCardPanel(panelReturnCard, e);
            pnlReturnCustInfo.Paint += (s, e) => DrawSubCard(pnlReturnCustInfo, e);
            panelInvGridCard.Paint += (s, e) => DrawCardPanel(panelInvGridCard, e);
            btnRefreshInv.Click += (s, e) => LoadInventoryData();
            btnProcessReturn.Click += btnProcessReturn_Click;
            cmbReturnCustomer.SelectedIndexChanged += (s, e) => UpdateReturnCustomerJugsState();
            cmbReturnCustomer.TextChanged += (s, e) => UpdateReturnCustomerJugsState();
            dgvInventory.CellClick += dgvInventory_CellClick;

            panelInventory.Resize += PanelInventory_Resize;

            // Audit Logs Module Cards & Components
            panelAuditGridCard.Paint += (s, e) => DrawCardPanel(panelAuditGridCard, e);
            btnRefreshAudit.Paint += (s, e) => DrawPillButton(btnRefreshAudit, isAuditRefreshHovered, e);
            btnRefreshAudit.MouseEnter += (s, e) => { isAuditRefreshHovered = true; btnRefreshAudit.Invalidate(); };
            btnRefreshAudit.MouseLeave += (s, e) => { isAuditRefreshHovered = false; btnRefreshAudit.Invalidate(); };
            btnRefreshAudit.Click += (s, e) => LoadAuditLogsData();

            // Sleek Button Styling & Rounded Clip
            StyleActionButtons();

            // Modern Dynamic ToolStrip Renderer with Active Pill Highlights
            modernRenderer = new ModernToolStripRenderer();
            toolStrip1.Renderer = modernRenderer;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ensure AuditLogs table structure is verified
            AuditLogger.EnsureAuditLogsTableExists();

            // Apply signature modern theme across all grids
            StyleDataGrid(dgvDashRecent);
            StyleDataGrid(dgvCustomers);
            StyleDataGrid(dgvTransactions);
            StyleDataGrid(dgvInventory);
            StyleDataGrid(dgvAuditLogs);

            PanelDashboard_Resize(this, EventArgs.Empty);
            PanelInventory_Resize(this, EventArgs.Empty);

            OpenDashboard();
        }

        private void StyleActionButtons()
        {
            ApplyButtonCorners(btnAdd, 8);
            ApplyButtonCorners(btnUpdate, 8);
            ApplyButtonCorners(btnDelete, 8);
            ApplyButtonCorners(btnClear, 8);
            ApplyButtonCorners(btnRefreshCust, 8);
            ApplyButtonCorners(btnRefreshTrans, 8);
            ApplyButtonCorners(btnRefreshInv, 8);
            ApplyButtonCorners(btnRefreshAudit, 8);
            ApplyButtonCorners(btnProcessTransaction, 10);
            ApplyButtonCorners(btnProcessReturn, 10);
            ApplyButtonCorners(btnModeNewOrder, 8);
            ApplyButtonCorners(btnModeUpdateCust, 8);
            ApplyButtonCorners(btnSaveTransCust, 10);
        }

        private void ApplyButtonCorners(Button btn, int radius)
        {
            if (btn == null) return;
            btn.SizeChanged += (s, e) =>
            {
                using (GraphicsPath path = GetRoundedRectanglePath(btn.ClientRectangle, radius))
                {
                    btn.Region = new Region(path);
                }
            };
        }

        #region Responsive Layout Engines

        private void PanelDashboard_Resize(object? sender, EventArgs e)
        {
            if (panelDashboard == null || panel1 == null || panel2 == null || panel3 == null) return;

            int totalMargin = 24 * 2;
            int gap = 16;
            int availableWidth = panelDashboard.ClientSize.Width - totalMargin - (gap * 2);
            int cardWidth = Math.Max(220, availableWidth / 3);

            panel1.Location = new Point(24, 20);
            panel1.Size = new Size(cardWidth, 110);

            panel2.Location = new Point(24 + cardWidth + gap, 20);
            panel2.Size = new Size(cardWidth, 110);

            panel3.Location = new Point(24 + (cardWidth + gap) * 2, 20);
            panel3.Size = new Size(cardWidth, 110);
        }

        private void PanelInventory_Resize(object? sender, EventArgs e)
        {
            if (panelInventory == null || pnlTotalStock == null || pnlJugsOut == null || pnlOverdue == null) return;

            int totalMargin = 24 * 2;
            int gap = 16;
            int availableWidth = panelInventory.ClientSize.Width - totalMargin - (gap * 2);
            int cardWidth = Math.Max(220, availableWidth / 3);

            pnlTotalStock.Location = new Point(24, 15);
            pnlTotalStock.Size = new Size(cardWidth, 110);

            pnlJugsOut.Location = new Point(24 + cardWidth + gap, 15);
            pnlJugsOut.Size = new Size(cardWidth, 110);

            pnlOverdue.Location = new Point(24 + (cardWidth + gap) * 2, 15);
            pnlOverdue.Size = new Size(cardWidth, 110);
        }

        #endregion

        #region Navigation & Tab Switching Logic

        private void SetActiveTab(string tabName)
        {
            if (modernRenderer != null)
            {
                modernRenderer.ActiveTabName = tabName;
                toolStrip1.Invalidate();
            }
        }

        // 1. Dashboard Navigation
        private void btnNavDashboard_Click(object sender, EventArgs e) => OpenDashboard();
        private void btnDashboard_Click(object sender, EventArgs e) => OpenDashboard();

        private void OpenDashboard()
        {
            SetActiveTab("Dashboard");
            HideAllPanels();
            if (panelDashboard != null)
            {
                panelDashboard.Visible = true;
                panelDashboard.BringToFront();
            }
            LoadDashboardData();
        }

        // 2. Customers Navigation
        private void btnNavCustomers_Click(object sender, EventArgs e) => OpenCustomers();
        private void btnCustomers_Click(object sender, EventArgs e) => OpenCustomers();

        private void OpenCustomers()
        {
            SetActiveTab("Customers");
            HideAllPanels();
            ShowPanelByName("panelLeft");
            ShowPanelByName("panelRight");
            LoadCustomersData();
        }

        // 3. Transactions Navigation
        private void btnNavTransactions_Click(object sender, EventArgs e) => OpenTransactions();
        private void btnTransactions_Click(object sender, EventArgs e) => OpenTransactions();

        private void OpenTransactions()
        {
            SetActiveTab("Transactions");
            HideAllPanels();
            ShowPanelByName("panelTransactions");
            SetTransactionFormMode(true);
            PopulateCustomerDropdown(cmbTransCustomer);
            if (cmbBorrowedJugs.SelectedIndex < 0) cmbBorrowedJugs.SelectedIndex = 0;
            if (cmbPaymentStatus.SelectedIndex < 0) cmbPaymentStatus.SelectedIndex = 0;
            UpdateCustomerJugsState();
            UpdateOrderTotal();
            LoadTransactionsData();
        }

        // 4. Inventory Navigation
        private void btnNavInventory_Click(object sender, EventArgs e) => OpenInventory();
        private void btnInventory_Click(object sender, EventArgs e) => OpenInventory();

        private void OpenInventory()
        {
            SetActiveTab("Inventory");
            HideAllPanels();
            ShowPanelByName("panelInventory");
            PanelInventory_Resize(this, EventArgs.Empty);
            PopulateCustomerDropdown(cmbReturnCustomer);
            LoadInventoryData();
        }

        // 5. Reports Navigation (Opens ReportForm without hiding Dashboard)
        private void btnNavReports_Click(object sender, EventArgs e) => OpenReports();
        private void btnReports_Click(object sender, EventArgs e) => OpenReports();

        private void OpenReports()
        {
            if (panelDashboard != null)
            {
                panelDashboard.Visible = true;
                panelDashboard.BringToFront();
            }

            using (ReportForm reportForm = new ReportForm())
            {
                reportForm.ShowDialog();
            }
        }

        // 6. Standalone Audit Logs Navigation
        private void btnNavAuditLogs_Click(object sender, EventArgs e) => OpenAuditLogs();
        private void btnAuditLogs_Click(object sender, EventArgs e) => OpenAuditLogs();

        private void OpenAuditLogs()
        {
            SetActiveTab("Audit Logs");
            HideAllPanels();
            ShowPanelByName("panelAuditLogs");
            LoadAuditLogsData();
        }

        private void HideAllPanels()
        {
            if (panelDashboard != null) panelDashboard.Visible = false;

            string[] panelNames = { "panelCustomers", "panelTransactions", "panelInventory", "panelAuditLogs", "panelLeft", "panelRight" };
            foreach (string pName in panelNames)
            {
                Control[] controls = this.Controls.Find(pName, true);
                if (controls.Length > 0 && controls[0] is Control ctrl)
                {
                    ctrl.Visible = false;
                }
            }
        }

        private void ShowPanelByName(string panelName)
        {
            Control[] found = this.Controls.Find(panelName, true);
            if (found.Length > 0)
            {
                found[0].Visible = true;
                found[0].BringToFront();
            }
        }

        #endregion

        #region DataGrid Enterprise Styling Engine

        private void StyleDataGrid(DataGridView? dgv)
        {
            if (dgv == null) return;

            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(226, 232, 240);
            dgv.BackgroundColor = Color.White;
            dgv.RowTemplate.Height = 36;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ScrollBars = ScrollBars.Both;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 114, 255);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgv.ColumnHeadersHeight = 38;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(2, 132, 199);
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(2, 132, 199);
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

        private void FormatCustomerGridColumns(DataGridView? dgv)
        {
            if (dgv == null || dgv.Columns.Count == 0) return;

            try
            {
                dgv.AutoGenerateColumns = false;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                if (dgv.Columns.Contains("Address") && dgv.Columns["Address"] is DataGridViewColumn colAddr)
                {
                    colAddr.HeaderText = "Delivery Address";
                    colAddr.MinimumWidth = 150;
                    colAddr.FillWeight = 140;
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
                System.Diagnostics.Debug.WriteLine("FormatCustomerGridColumns warning: " + ex.Message);
            }
        }

        private void FormatTransactionGridColumns(DataGridView? dgv)
        {
            if (dgv == null || dgv.Columns.Count == 0) return;

            dgv.AutoGenerateColumns = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ScrollBars = ScrollBars.Both;

            if (dgv.Columns.Contains("TransactionID") && dgv.Columns["TransactionID"] is DataGridViewColumn colId)
            {
                colId.HeaderText = "Order #";
                colId.MinimumWidth = 60;
                colId.FillWeight = 50;
                SetColumnStyle(colId, DataGridViewContentAlignment.MiddleCenter);
            }
            if (dgv.Columns.Contains("TransactionDate") && dgv.Columns["TransactionDate"] is DataGridViewColumn colDate)
            {
                colDate.HeaderText = "Date & Time";
                colDate.MinimumWidth = 140;
                colDate.FillWeight = 115;
                SetColumnStyle(colDate, DataGridViewContentAlignment.MiddleCenter, "yyyy-MM-dd hh:mm tt");
            }
            if (dgv.Columns.Contains("CustomerName") && dgv.Columns["CustomerName"] is DataGridViewColumn colCust)
            {
                colCust.HeaderText = "Customer Name";
                colCust.MinimumWidth = 120;
                colCust.FillWeight = 120;
                SetColumnStyle(colCust, DataGridViewContentAlignment.MiddleLeft);
            }
            if (dgv.Columns.Contains("Quantity") && dgv.Columns["Quantity"] is DataGridViewColumn colQty)
            {
                colQty.HeaderText = "Qty";
                colQty.MinimumWidth = 45;
                colQty.FillWeight = 40;
                SetColumnStyle(colQty, DataGridViewContentAlignment.MiddleCenter);
            }
            if (dgv.Columns.Contains("BorrowedJugs") && dgv.Columns["BorrowedJugs"] is DataGridViewColumn colBorrow)
            {
                colBorrow.HeaderText = "Borrowed Jugs";
                colBorrow.MinimumWidth = 90;
                colBorrow.FillWeight = 75;
                SetColumnStyle(colBorrow, DataGridViewContentAlignment.MiddleCenter);
            }
            if (dgv.Columns.Contains("ReturnedJugs") && dgv.Columns["ReturnedJugs"] is DataGridViewColumn colReturn)
            {
                colReturn.HeaderText = "Returned Jugs";
                colReturn.MinimumWidth = 90;
                colReturn.FillWeight = 75;
                SetColumnStyle(colReturn, DataGridViewContentAlignment.MiddleCenter);
            }
            if (dgv.Columns.Contains("UnitPrice") && dgv.Columns["UnitPrice"] is DataGridViewColumn colPrice)
            {
                colPrice.HeaderText = "Unit Price";
                colPrice.MinimumWidth = 75;
                colPrice.FillWeight = 65;
                SetColumnStyle(colPrice, DataGridViewContentAlignment.MiddleRight, "₱#,##0.00");
            }
            if (dgv.Columns.Contains("TotalPrice") && dgv.Columns["TotalPrice"] is DataGridViewColumn colTotal)
            {
                colTotal.HeaderText = "Total Due";
                colTotal.MinimumWidth = 80;
                colTotal.FillWeight = 70;
                SetColumnStyle(colTotal, DataGridViewContentAlignment.MiddleRight, "₱#,##0.00");
            }
            if (dgv.Columns.Contains("ChangeAmount") && dgv.Columns["ChangeAmount"] is DataGridViewColumn colChange)
            {
                colChange.HeaderText = "Change";
                colChange.MinimumWidth = 75;
                colChange.FillWeight = 65;
                SetColumnStyle(colChange, DataGridViewContentAlignment.MiddleRight, "₱#,##0.00");
            }
            if (dgv.Columns.Contains("PaymentStatus") && dgv.Columns["PaymentStatus"] is DataGridViewColumn colStatus)
            {
                colStatus.HeaderText = "Status";
                colStatus.MinimumWidth = 70;
                colStatus.FillWeight = 55;
                SetColumnStyle(colStatus, DataGridViewContentAlignment.MiddleCenter);
            }
            if (dgv.Columns.Contains("RefillType") && dgv.Columns["RefillType"] is DataGridViewColumn colType)
            {
                colType.HeaderText = "Type";
                colType.MinimumWidth = 100;
                colType.FillWeight = 85;
                SetColumnStyle(colType, DataGridViewContentAlignment.MiddleCenter);
            }
            if (dgv.Columns.Contains("CustomerID") && dgv.Columns["CustomerID"] is DataGridViewColumn colCustId)
            {
                colCustId.Visible = false;
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

        #endregion

        #region Database Data Operations

        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Total Active Customers
                    string queryCustomers = "SELECT COUNT(*) FROM Customers";
                    using (SqlCommand cmd = new SqlCommand(queryCustomers, conn))
                    {
                        int totalCustomers = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                        if (lblDashTotalCustomers != null)
                            lblDashTotalCustomers.Text = totalCustomers.ToString("N0");
                    }

                    // 2. Containers Borrowed
                    string queryBorrowed = "SELECT ISNULL(SUM(BorrowedJugs), 0) FROM Customers";
                    using (SqlCommand cmd = new SqlCommand(queryBorrowed, conn))
                    {
                        int totalBorrowed = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                        if (lblDashBorrowedJugs != null)
                            lblDashBorrowedJugs.Text = totalBorrowed.ToString("N0");
                    }

                    // 3. Total Unpaid Balance
                    string queryBalance = "SELECT ISNULL(SUM(UnpaidBalance), 0) FROM Customers";
                    using (SqlCommand cmd = new SqlCommand(queryBalance, conn))
                    {
                        decimal totalBalance = Convert.ToDecimal(cmd.ExecuteScalar() ?? 0);
                        if (lblDashUnpaidBalance != null)
                            lblDashUnpaidBalance.Text = string.Format("₱{0:N2}", totalBalance);
                    }

                    // 4. Recent Customer Accounts DataGrid
                    string queryRecent = "SELECT CustomerID, FullName, Phone, Address, BorrowedJugs, UnpaidBalance, RemainingChange FROM Customers ORDER BY CustomerID DESC";
                    using (SqlDataAdapter da = new SqlDataAdapter(queryRecent, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dgvDashRecent != null)
                        {
                            dgvDashRecent.DataSource = dt;
                            FormatCustomerGridColumns(dgvDashRecent);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomersData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT CustomerID, FullName, Phone, Address, BorrowedJugs, UnpaidBalance, RemainingChange FROM Customers ORDER BY CustomerID DESC";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dgvCustomers != null)
                        {
                            dgvCustomers.DataSource = dt;
                            FormatCustomerGridColumns(dgvCustomers);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer records: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransactionsData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT TransactionID, TransactionDate, CustomerName, Quantity, BorrowedJugs, ReturnedJugs, UnitPrice, TotalPrice, ISNULL(ChangeAmount, 0.00) AS ChangeAmount, PaymentStatus, RefillType, CustomerID FROM Transactions ORDER BY TransactionDate DESC, TransactionID DESC";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dgvTransactions != null)
                        {
                            dgvTransactions.DataSource = dt;
                            FormatTransactionGridColumns(dgvTransactions);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading transactions log: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInventoryData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Total Borrowed Jugs
                    string queryBorrowed = "SELECT ISNULL(SUM(BorrowedJugs), 0) FROM Customers";
                    int totalBorrowed = 0;
                    using (SqlCommand cmd = new SqlCommand(queryBorrowed, conn))
                    {
                        totalBorrowed = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                        if (lblJugsOut != null)
                            lblJugsOut.Text = totalBorrowed.ToString("N0");
                    }

                    // Stock On-Hand (Base 150 standard capacity minus jugs out)
                    int stockOnHand = Math.Max(0, 150 - totalBorrowed);
                    if (lblTotalStock != null)
                        lblTotalStock.Text = stockOnHand.ToString("N0");

                    // Overdue count (borrowed jugs accounts)
                    string queryOverdue = "SELECT COUNT(*) FROM Customers WHERE BorrowedJugs > 0";
                    using (SqlCommand cmd = new SqlCommand(queryOverdue, conn))
                    {
                        int overdue = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                        if (lblOverdue != null)
                            lblOverdue.Text = overdue.ToString("N0");
                    }

                    // Inventory Tracking DataGrid (Customers holding containers)
                    string queryInv = "SELECT CustomerID, FullName, Phone, BorrowedJugs, UnpaidBalance FROM Customers WHERE BorrowedJugs > 0 ORDER BY BorrowedJugs DESC";
                    using (SqlDataAdapter da = new SqlDataAdapter(queryInv, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dgvInventory != null)
                        {
                            dgvInventory.DataSource = dt;
                            FormatCustomerGridColumns(dgvInventory);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory stats: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateCustomerDropdown(ComboBox cmb)
        {
            if (cmb == null) return;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT CustomerID, FullName FROM Customers ORDER BY FullName ASC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            cmb.DataSource = dt;
                            cmb.DisplayMember = "FullName";
                            cmb.ValueMember = "CustomerID";

                            AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();
                            foreach (DataRow row in dt.Rows)
                            {
                                if (row["FullName"] != DBNull.Value)
                                    autoSource.Add(row["FullName"].ToString() ?? string.Empty);
                            }
                            cmb.AutoCompleteCustomSource = autoSource;
                            cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            cmb.DropDownStyle = ComboBoxStyle.DropDown;
                        }
                    }
                }
            }
            catch { }
        }

        private int GetSelectedCustomerId(ComboBox? cmb)
        {
            if (cmb == null) return 0;
            if (cmb.SelectedValue != null && int.TryParse(cmb.SelectedValue.ToString(), out int id) && id > 0)
                return id;

            if (!string.IsNullOrWhiteSpace(cmb.Text) && cmb.DataSource is DataTable dt)
            {
                string search = cmb.Text.Trim();
                if (int.TryParse(search.TrimStart('#'), out int searchedId))
                {
                    var rowById = dt.AsEnumerable().FirstOrDefault(r => r.Field<int>("CustomerID") == searchedId);
                    if (rowById != null)
                        return rowById.Field<int>("CustomerID");
                }

                var row = dt.AsEnumerable().FirstOrDefault(r => string.Equals((r.Field<string>("FullName") ?? "").Trim(), search, StringComparison.OrdinalIgnoreCase));
                if (row != null)
                    return row.Field<int>("CustomerID");

                row = dt.AsEnumerable().FirstOrDefault(r => (r.Field<string>("FullName") ?? "").Trim().StartsWith(search, StringComparison.OrdinalIgnoreCase));
                if (row != null)
                    return row.Field<int>("CustomerID");
            }

            return 0;
        }

        private void UpdateCustomerJugsState()
        {
            if (cmbTransCustomer == null) return;

            int customerId = GetSelectedCustomerId(cmbTransCustomer);
            if (customerId <= 0)
            {
                currentCustUnpaid = 0.00m;
                currentCustBorrowed = 0;
                currentCustRemainingChange = 0.00m;
                if (lblTransCustChange != null)
                {
                    lblTransCustChange.Text = "Change to Give: ₱0.00";
                    lblTransCustChange.ForeColor = Color.FromArgb(100, 116, 139);
                }
                if (btnReleaseChange != null) btnReleaseChange.Visible = false;

                if (lblTransCustBal != null)
                {
                    lblTransCustBal.Text = "Unpaid Due: ₱0.00";
                    lblTransCustBal.ForeColor = Color.FromArgb(100, 116, 139);
                }
                if (lblTransCustJugs != null)
                {
                    lblTransCustJugs.Text = "Borrowed Jugs: 0";
                    lblTransCustJugs.ForeColor = Color.FromArgb(100, 116, 139);
                }

                if (numUpdatePay != null)
                {
                    numUpdatePay.Maximum = 0;
                    numUpdatePay.Value = 0;
                }
                if (numUpdateReturned != null)
                {
                    numUpdateReturned.Maximum = 0;
                    numUpdateReturned.Value = 0;
                }

                UpdateCustomerUpdatePreview();
                return;
            }

            try
            {
                int borrowedJugs = 0;
                decimal unpaidBalance = 0.00m;
                decimal remainingChange = 0.00m;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ISNULL(BorrowedJugs, 0), ISNULL(UnpaidBalance, 0), ISNULL(RemainingChange, 0) FROM Customers WHERE CustomerID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", customerId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                borrowedJugs = reader.GetInt32(0);
                                unpaidBalance = reader.GetDecimal(1);
                                remainingChange = reader.GetDecimal(2);
                            }
                        }
                    }
                }

                currentCustUnpaid = unpaidBalance;
                currentCustBorrowed = borrowedJugs;
                currentCustRemainingChange = remainingChange;

                if (lblTransCustBal != null)
                {
                    lblTransCustBal.Text = $"Unpaid Due: ₱{unpaidBalance:N2}";
                    lblTransCustBal.ForeColor = unpaidBalance > 0 ? Color.FromArgb(225, 29, 72) : Color.FromArgb(100, 116, 139);
                }
                if (lblTransCustJugs != null)
                {
                    lblTransCustJugs.Text = $"Borrowed Jugs: {borrowedJugs}";
                    lblTransCustJugs.ForeColor = borrowedJugs > 0 ? Color.FromArgb(217, 119, 6) : Color.FromArgb(100, 116, 139);
                }
                if (lblTransCustChange != null)
                {
                    lblTransCustChange.Text = remainingChange > 0 ? $"Change to Give: ₱{remainingChange:N2}" : "Change to Give: ₱0.00";
                    lblTransCustChange.ForeColor = remainingChange > 0 ? Color.FromArgb(5, 150, 105) : Color.FromArgb(100, 116, 139);
                }
                if (btnReleaseChange != null)
                {
                    btnReleaseChange.Visible = remainingChange > 0;
                    btnReleaseChange.Text = $"Release ₱{remainingChange:N2} Change";
                }

                if (numUpdatePay != null)
                {
                    numUpdatePay.Maximum = Math.Max(999999, unpaidBalance);
                    numUpdatePay.Value = 0;
                }
                if (numUpdateReturned != null)
                {
                    numUpdateReturned.Maximum = Math.Max(1000, borrowedJugs);
                    numUpdateReturned.Value = 0;
                }

                UpdateCustomerUpdatePreview();
            }
            catch
            {
                currentCustUnpaid = 0.00m;
                currentCustBorrowed = 0;
                currentCustRemainingChange = 0.00m;
                if (lblTransCustChange != null)
                {
                    lblTransCustChange.Text = "Change to Give: ₱0.00";
                    lblTransCustChange.ForeColor = Color.FromArgb(100, 116, 139);
                }
                if (btnReleaseChange != null) btnReleaseChange.Visible = false;

                if (lblTransCustBal != null)
                {
                    lblTransCustBal.Text = "Unpaid Due: ₱0.00";
                    lblTransCustBal.ForeColor = Color.FromArgb(100, 116, 139);
                }
                if (lblTransCustJugs != null)
                {
                    lblTransCustJugs.Text = "Borrowed Jugs: 0";
                    lblTransCustJugs.ForeColor = Color.FromArgb(100, 116, 139);
                }

                if (numUpdatePay != null)
                {
                    numUpdatePay.Maximum = 0;
                    numUpdatePay.Value = 0;
                }
                if (numUpdateReturned != null)
                {
                    numUpdateReturned.Maximum = 0;
                    numUpdateReturned.Value = 0;
                }

                UpdateCustomerUpdatePreview();
            }
        }

        private void UpdateReturnCustomerJugsState()
        {
            if (cmbReturnCustomer == null || lblReturnCustJugs == null) return;

            int customerId = GetSelectedCustomerId(cmbReturnCustomer);
            if (customerId <= 0)
            {
                lblReturnCustJugs.Text = "Borrowed Jugs: 0 jugs";
                lblReturnCustJugs.ForeColor = Color.FromArgb(100, 116, 139);
                btnProcessReturn.Enabled = false;
                numReturnQty.Maximum = 0;
                numReturnQty.Value = 0;
                return;
            }

            try
            {
                int borrowedJugs = 0;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ISNULL(BorrowedJugs, 0) FROM Customers WHERE CustomerID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", customerId);
                        borrowedJugs = Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
                    }
                }

                if (borrowedJugs > 0)
                {
                    lblReturnCustJugs.Text = $"Currently Holding: {borrowedJugs} borrowed jug{(borrowedJugs == 1 ? "" : "s")}";
                    lblReturnCustJugs.ForeColor = Color.FromArgb(217, 119, 6);
                    btnProcessReturn.Enabled = true;
                    numReturnQty.Maximum = borrowedJugs;
                    if (numReturnQty.Value < 1 || numReturnQty.Value > borrowedJugs)
                    {
                        numReturnQty.Value = 1;
                    }
                }
                else
                {
                    lblReturnCustJugs.Text = "No borrowed jugs currently held";
                    lblReturnCustJugs.ForeColor = Color.FromArgb(100, 116, 139);
                    btnProcessReturn.Enabled = false;
                    numReturnQty.Maximum = 0;
                    numReturnQty.Value = 0;
                }
            }
            catch
            {
                lblReturnCustJugs.Text = "Borrowed Jugs: 0";
                lblReturnCustJugs.ForeColor = Color.FromArgb(100, 116, 139);
                btnProcessReturn.Enabled = false;
                numReturnQty.Maximum = 0;
                numReturnQty.Value = 0;
            }
        }

        private void UpdateCustomerUpdatePreview()
        {
            if (lblUpdateBalPreview == null || lblUpdateJugsPreview == null) return;

            decimal payAmt = numUpdatePay != null ? numUpdatePay.Value : 0;
            int retJugs = numUpdateReturned != null ? (int)numUpdateReturned.Value : 0;

            decimal remainingBal = Math.Max(0, currentCustUnpaid - payAmt);
            decimal changeFromPay = Math.Max(0, payAmt - currentCustUnpaid);
            decimal totalChangeToGive = currentCustRemainingChange + changeFromPay;
            int remainingJugs = Math.Max(0, currentCustBorrowed - retJugs);

            lblUpdateBalPreview.Text = $"Remaining Due: ₱{remainingBal:N2} (Paying: ₱{payAmt:N2})";
            lblUpdateBalPreview.ForeColor = remainingBal > 0 ? Color.FromArgb(225, 29, 72) : Color.FromArgb(5, 150, 105);

            if (lblUpdateChangePreview != null)
            {
                lblUpdateChangePreview.Text = totalChangeToGive > 0 ? $"Change to Give: ₱{totalChangeToGive:N2}" : "Change Due: ₱0.00";
                lblUpdateChangePreview.ForeColor = totalChangeToGive > 0 ? Color.FromArgb(5, 150, 105) : Color.FromArgb(100, 116, 139);
            }

            lblUpdateJugsPreview.Text = $"Remaining Jugs: {remainingJugs} jugs (Returning: {retJugs})";
            lblUpdateJugsPreview.ForeColor = remainingJugs > 0 ? Color.FromArgb(217, 119, 6) : Color.FromArgb(5, 150, 105);
        }

        private void UpdateOrderTotal()
        {
            decimal qty = numTransQty.Value;
            decimal price = 30.00m;
            decimal.TryParse(txtUnitPrice.Text, out price);
            decimal total = qty * price;
            lblTransTotalAmount.Text = $"₱{total:N2}";

            if (numTransCashPaid != null && lblTransChangeAmount != null)
            {
                string status = cmbPaymentStatus.SelectedItem?.ToString() ?? "Paid";
                if (status.Equals("Unpaid", StringComparison.OrdinalIgnoreCase))
                {
                    lblTransChangeAmount.Text = "₱0.00";
                    lblTransChangeAmount.ForeColor = Color.FromArgb(100, 116, 139);
                }
                else
                {
                    decimal cashPaid = numTransCashPaid.Value;
                    decimal change = Math.Max(0, cashPaid - total);
                    lblTransChangeAmount.Text = $"₱{change:N2}";
                    if (cashPaid >= total && total > 0)
                    {
                        lblTransChangeAmount.ForeColor = Color.FromArgb(5, 150, 105);
                    }
                    else if (cashPaid > 0)
                    {
                        lblTransChangeAmount.ForeColor = Color.FromArgb(225, 29, 72);
                    }
                    else
                    {
                        lblTransChangeAmount.ForeColor = Color.FromArgb(100, 116, 139);
                    }
                }
            }
        }

        private void dgvTransactions_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvTransactions.Rows.Count) return;

            DataGridViewRow row = dgvTransactions.Rows[e.RowIndex];
            if (row.Cells["CustomerID"] != null && row.Cells["CustomerID"].Value != DBNull.Value && row.Cells["CustomerID"].Value != null)
            {
                int customerId = Convert.ToInt32(row.Cells["CustomerID"].Value);
                cmbTransCustomer.SelectedValue = customerId;
                UpdateCustomerJugsState();
            }
        }

        private void btnModeNewOrder_Click(object? sender, EventArgs e)
        {
            SetTransactionFormMode(true);
        }

        private void btnModeUpdateCust_Click(object? sender, EventArgs e)
        {
            SetTransactionFormMode(false);
        }

        private void SetTransactionFormMode(bool isNewOrder)
        {
            pnlTransNewOrder.Visible = isNewOrder;
            pnlTransUpdateCust.Visible = !isNewOrder;

            if (isNewOrder)
            {
                btnModeNewOrder.BackColor = Color.FromArgb(0, 114, 255);
                btnModeNewOrder.ForeColor = Color.White;
                btnModeUpdateCust.BackColor = Color.FromArgb(241, 245, 249);
                btnModeUpdateCust.ForeColor = Color.FromArgb(71, 85, 105);
                lblTransSection.Text = "Process New Order";
                lblTransSub.Text = "Record water refill sales, pricing, and payments";
            }
            else
            {
                btnModeNewOrder.BackColor = Color.FromArgb(241, 245, 249);
                btnModeNewOrder.ForeColor = Color.FromArgb(71, 85, 105);
                btnModeUpdateCust.BackColor = Color.FromArgb(0, 114, 255);
                btnModeUpdateCust.ForeColor = Color.White;
                lblTransSection.Text = "Update Unpaid Balance & Jugs";
                lblTransSub.Text = "Settle unpaid customer balance and record returned empty jugs";

                if (cmbTransCustomer.SelectedValue != null && int.TryParse(cmbTransCustomer.SelectedValue.ToString(), out _))
                {
                    UpdateCustomerJugsState();
                }
            }
        }

        private void btnReleaseChange_Click(object? sender, EventArgs e)
        {
            int customerId = GetSelectedCustomerId(cmbTransCustomer);
            if (customerId <= 0) return;
            if (currentCustRemainingChange <= 0) return;

            string customerName = cmbTransCustomer.Text;
            decimal releaseAmt = currentCustRemainingChange;

            DialogResult dr = MessageBox.Show($"Confirm handing over change of ₱{releaseAmt:N2} to customer {customerName}?", "Release Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction sqlTrans = conn.BeginTransaction())
                    {
                        try
                        {
                            string updSql = "UPDATE Customers SET RemainingChange = 0 WHERE CustomerID = @id";
                            using (SqlCommand cmd = new SqlCommand(updSql, conn, sqlTrans))
                            {
                                cmd.Parameters.AddWithValue("@id", customerId);
                                cmd.ExecuteNonQuery();
                            }

                            string insTrans = @"INSERT INTO Transactions (CustomerID, CustomerName, RefillType, Quantity, BorrowedJugs, ReturnedJugs, UnitPrice, TotalPrice, ChangeAmount, PaymentStatus, TransactionDate)
                                                VALUES (@cid, @cname, 'Change Released', 0, 0, 0, 0.00, 0.00, @change, 'Paid', @tdate)";
                            using (SqlCommand cmd = new SqlCommand(insTrans, conn, sqlTrans))
                            {
                                cmd.Parameters.AddWithValue("@cid", customerId);
                                cmd.Parameters.AddWithValue("@cname", customerName);
                                cmd.Parameters.AddWithValue("@change", releaseAmt);
                                cmd.Parameters.AddWithValue("@tdate", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }

                            AuditLogger.LogAction("Update", "Customers", $"Customer #{customerId} ({customerName})", $"Handed over / released remaining change: ₱{releaseAmt:N2}", conn, sqlTrans);
                            sqlTrans.Commit();
                        }
                        catch
                        {
                            sqlTrans.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show($"Change of ₱{releaseAmt:N2} was handed over to {customerName} successfully!", "Change Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTransactionsData();
                LoadCustomersData();
                LoadDashboardData();
                UpdateCustomerJugsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error releasing change: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveTransCust_Click(object? sender, EventArgs e)
        {
            int customerId = GetSelectedCustomerId(cmbTransCustomer);
            if (customerId <= 0)
            {
                MessageBox.Show("Please select a customer first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string customerName = cmbTransCustomer.Text;
            decimal payAmt = numUpdatePay != null ? numUpdatePay.Value : 0;
            int retJugs = numUpdateReturned != null ? (int)numUpdateReturned.Value : 0;

            if (payAmt <= 0 && retJugs <= 0)
            {
                MessageBox.Show("Please enter an amount to pay or the number of jugs returned.", "No Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (retJugs > currentCustBorrowed)
            {
                MessageBox.Show($"Returned jugs ({retJugs}) cannot exceed the customer's borrowed jugs count ({currentCustBorrowed}).", "Invalid Return Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal actualPaidToBalance = Math.Min(payAmt, currentCustUnpaid);
            decimal changeAmount = Math.Max(0, payAmt - currentCustUnpaid);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction sqlTrans = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Process Payment / Settle Due
                            if (payAmt > 0)
                            {
                                string updateBalSql = @"UPDATE Customers 
                                                       SET UnpaidBalance = CASE WHEN UnpaidBalance - @paid < 0 THEN 0 ELSE UnpaidBalance - @paid END 
                                                       WHERE CustomerID = @id";
                                using (SqlCommand cmd = new SqlCommand(updateBalSql, conn, sqlTrans))
                                {
                                    cmd.Parameters.AddWithValue("@paid", payAmt);
                                    cmd.Parameters.AddWithValue("@id", customerId);
                                    cmd.ExecuteNonQuery();
                                }

                                string insertPayTransSql = @"INSERT INTO Transactions (CustomerID, CustomerName, RefillType, Quantity, BorrowedJugs, ReturnedJugs, UnitPrice, TotalPrice, ChangeAmount, PaymentStatus, TransactionDate)
                                                             VALUES (@cid, @cname, 'Payment / Due Settle', 0, 0, 0, 0.00, @paid, @change, 'Paid', @tdate)";
                                using (SqlCommand cmd = new SqlCommand(insertPayTransSql, conn, sqlTrans))
                                {
                                    cmd.Parameters.AddWithValue("@cid", customerId);
                                    cmd.Parameters.AddWithValue("@cname", customerName);
                                    cmd.Parameters.AddWithValue("@paid", actualPaidToBalance > 0 ? actualPaidToBalance : payAmt);
                                    cmd.Parameters.AddWithValue("@change", changeAmount);
                                    cmd.Parameters.AddWithValue("@tdate", DateTime.Now);
                                    cmd.ExecuteNonQuery();
                                }

                                if (changeAmount > 0)
                                {
                                    string addChangeSql = @"UPDATE Customers SET RemainingChange = RemainingChange + @change WHERE CustomerID = @id";
                                    using (SqlCommand cmdChange = new SqlCommand(addChangeSql, conn, sqlTrans))
                                    {
                                        cmdChange.Parameters.AddWithValue("@change", changeAmount);
                                        cmdChange.Parameters.AddWithValue("@id", customerId);
                                        cmdChange.ExecuteNonQuery();
                                    }
                                }
                            }

                            // 2. Process Returned Empty Jugs
                            if (retJugs > 0)
                            {
                                string updateJugsSql = @"UPDATE Customers 
                                                        SET BorrowedJugs = CASE WHEN BorrowedJugs - @ret < 0 THEN 0 ELSE BorrowedJugs - @ret END 
                                                        WHERE CustomerID = @id";
                                using (SqlCommand cmd = new SqlCommand(updateJugsSql, conn, sqlTrans))
                                {
                                    cmd.Parameters.AddWithValue("@ret", retJugs);
                                    cmd.Parameters.AddWithValue("@id", customerId);
                                    cmd.ExecuteNonQuery();
                                }

                                string insertJugTransSql = @"INSERT INTO Transactions (CustomerID, CustomerName, RefillType, Quantity, BorrowedJugs, ReturnedJugs, UnitPrice, TotalPrice, ChangeAmount, PaymentStatus, TransactionDate)
                                                             VALUES (@cid, @cname, 'Return Empty Jugs', 0, 0, @ret, 0.00, 0.00, 0.00, 'Paid', @tdate)";
                                using (SqlCommand cmd = new SqlCommand(insertJugTransSql, conn, sqlTrans))
                                {
                                    cmd.Parameters.AddWithValue("@cid", customerId);
                                    cmd.Parameters.AddWithValue("@cname", customerName);
                                    cmd.Parameters.AddWithValue("@ret", retJugs);
                                    cmd.Parameters.AddWithValue("@tdate", DateTime.Now);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // 3. Log Audit Entry for Settle Due / Jug Return
                            AuditLogger.LogAction("Update", "Customers", $"Customer #{customerId} ({customerName})", $"Settle/Update (Paid: ₱{payAmt:N2}, Applied to Balance: ₱{(actualPaidToBalance > 0 ? actualPaidToBalance : payAmt):N2}, Change: ₱{changeAmount:N2}, Returned Jugs: {retJugs})", conn, sqlTrans);

                            sqlTrans.Commit();
                        }
                        catch
                        {
                            sqlTrans.Rollback();
                            throw;
                        }
                    }
                }

                string msg = $"Customer account for {customerName} updated successfully!";
                if (payAmt > 0)
                {
                    decimal remainingDue = Math.Max(0, currentCustUnpaid - payAmt);
                    msg += $"\n- Payment Tendered: ₱{payAmt:N2}";
                    msg += $"\n- Applied to Balance: ₱{(actualPaidToBalance > 0 ? actualPaidToBalance : payAmt):N2}";
                    if (changeAmount > 0)
                    {
                        msg += $"\n- Change: ₱{changeAmount:N2}";
                    }
                    msg += $"\n- Remaining Due: ₱{remainingDue:N2}";
                }
                if (retJugs > 0) msg += $"\n- Jugs Returned: {retJugs} (Remaining Jugs: {Math.Max(0, currentCustBorrowed - retJugs)})";

                MessageBox.Show(msg, "Account Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int savedCustId = customerId;
                if (numUpdatePay != null) numUpdatePay.Value = 0;
                if (numUpdateReturned != null) numUpdateReturned.Value = 0;

                LoadTransactionsData();
                LoadCustomersData();
                LoadInventoryData();
                LoadDashboardData();

                cmbTransCustomer.SelectedValue = savedCustId;
                UpdateCustomerJugsState();

                if (changeAmount > 0 && lblUpdateChangePreview != null)
                {
                    lblUpdateChangePreview.Text = $"Change Due: ₱{changeAmount:N2}";
                    lblUpdateChangePreview.ForeColor = Color.FromArgb(5, 150, 105);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer account: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Customer Form CRUD & Interaction Logic

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCustomers.Rows.Count) return;

            DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
            if (row.Cells["FullName"].Value != null)
                txtFullName.Text = row.Cells["FullName"].Value?.ToString() ?? string.Empty;
            if (row.Cells["Phone"].Value != null)
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? string.Empty;
            if (row.Cells["Address"].Value != null)
                txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? string.Empty;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter the customer's full name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Check duplicate customer name
                    string checkNameQuery = "SELECT COUNT(*) FROM Customers WHERE LOWER(FullName) = LOWER(@name)";
                    using (SqlCommand cmd = new SqlCommand(checkNameQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show($"A customer account with the name '{name}' already exists. Duplicate customer names are not allowed.", "Duplicate Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 2. Check duplicate contact number if provided
                    if (!string.IsNullOrWhiteSpace(phone))
                    {
                        string checkPhoneQuery = "SELECT COUNT(*) FROM Customers WHERE LOWER(Phone) = LOWER(@phone)";
                        using (SqlCommand cmd = new SqlCommand(checkPhoneQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@phone", phone);
                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (count > 0)
                            {
                                MessageBox.Show($"A customer account with the phone number '{phone}' already exists. Duplicate contact numbers are not allowed.", "Duplicate Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    // 3. Insert new customer record
                    string query = "INSERT INTO Customers (FullName, Phone, Address, BorrowedJugs, UnpaidBalance) VALUES (@name, @phone, @addr, 0, 0.00); SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@addr", txtAddress.Text.Trim());
                        object newObj = cmd.ExecuteScalar();
                        int newId = newObj != null && newObj != DBNull.Value ? Convert.ToInt32(newObj) : 0;
                        AuditLogger.LogAction("Insert", "Customers", $"Customer #{newId} ({name})", $"Registered new customer profile (Phone: {phone}, Address: {txtAddress.Text.Trim()})", conn);
                    }
                }

                MessageBox.Show("Customer account registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearCustomerFields();
                LoadCustomersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving customer: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer from the table to update.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string name = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter the customer's full name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Check duplicate customer name for other records
                    string checkNameQuery = "SELECT COUNT(*) FROM Customers WHERE LOWER(FullName) = LOWER(@name) AND CustomerID <> @id";
                    using (SqlCommand cmd = new SqlCommand(checkNameQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@id", customerId);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show($"Another customer account with the name '{name}' already exists. Duplicate customer names are not allowed.", "Duplicate Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 2. Check duplicate contact number for other records if provided
                    if (!string.IsNullOrWhiteSpace(phone))
                    {
                        string checkPhoneQuery = "SELECT COUNT(*) FROM Customers WHERE LOWER(Phone) = LOWER(@phone) AND CustomerID <> @id";
                        using (SqlCommand cmd = new SqlCommand(checkPhoneQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@phone", phone);
                            cmd.Parameters.AddWithValue("@id", customerId);
                            int count = Convert.ToInt32(cmd.ExecuteScalar());
                            if (count > 0)
                            {
                                MessageBox.Show($"Another customer account with the phone number '{phone}' already exists. Duplicate contact numbers are not allowed.", "Duplicate Contact Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    // 3. Update customer details
                    string query = "UPDATE Customers SET FullName = @name, Phone = @phone, Address = @addr WHERE CustomerID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@addr", txtAddress.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", customerId);
                        cmd.ExecuteNonQuery();
                        AuditLogger.LogAction("Update", "Customers", $"Customer #{customerId} ({name})", $"Updated details to Phone: {phone}, Address: {txtAddress.Text.Trim()}", conn);
                    }
                }

                MessageBox.Show("Customer details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCustomersData();
                LoadTransactionsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a customer to delete.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to delete this customer account and all associated transaction records?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                int customerId = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlTransaction sqlTrans = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Delete associated transactions for this customer to satisfy foreign key constraint
                            string delTransQuery = "DELETE FROM Transactions WHERE CustomerID = @id";
                            using (SqlCommand cmd = new SqlCommand(delTransQuery, conn, sqlTrans))
                            {
                                cmd.Parameters.AddWithValue("@id", customerId);
                                cmd.ExecuteNonQuery();
                            }

                            // 2. Delete customer account
                            string delCustQuery = "DELETE FROM Customers WHERE CustomerID = @id";
                            using (SqlCommand cmd = new SqlCommand(delCustQuery, conn, sqlTrans))
                            {
                                cmd.Parameters.AddWithValue("@id", customerId);
                                cmd.ExecuteNonQuery();
                            }

                            // 3. Audit log customer deletion
                            AuditLogger.LogAction("Delete", "Customers", $"Customer #{customerId}", $"Deleted customer account and all associated transaction records", conn, sqlTrans);

                            sqlTrans.Commit();
                        }
                        catch
                        {
                            sqlTrans.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Customer account and associated records deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearCustomerFields();
                LoadCustomersData();
                LoadTransactionsData();
                LoadInventoryData();
                LoadDashboardData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting customer: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearCustomerFields();
        }

        private void ClearCustomerFields()
        {
            txtFullName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
        }

        #endregion

        #region Transaction Processing Logic

        private void btnProcessTransaction_Click(object sender, EventArgs e)
        {
            int customerId = GetSelectedCustomerId(cmbTransCustomer);
            if (customerId <= 0)
            {
                MessageBox.Show("Please select a registered customer.", "Validation Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string customerName = cmbTransCustomer.Text;
            int qty = (int)numTransQty.Value;
            int borrowedJugs = 0;
            if (cmbBorrowedJugs.SelectedItem != null)
            {
                int.TryParse(cmbBorrowedJugs.SelectedItem.ToString(), out borrowedJugs);
            }
            else
            {
                int.TryParse(cmbBorrowedJugs.Text, out borrowedJugs);
            }

            int returnedJugs = 0;
            decimal price = 30.00m;
            decimal.TryParse(txtUnitPrice.Text, out price);
            decimal orderTotal = qty * price;
            string refillType = "Purified";
            string status = cmbPaymentStatus.SelectedItem?.ToString() ?? "Paid";
            decimal cashPaid = numTransCashPaid != null ? numTransCashPaid.Value : 0;

            if (status.Equals("Paid", StringComparison.OrdinalIgnoreCase) && cashPaid > 0 && cashPaid < orderTotal)
            {
                MessageBox.Show($"Amount paid (₱{cashPaid:N2}) is less than the total due (₱{orderTotal:N2}). Please enter an amount equal to or greater than the total due, or select Unpaid payment status.", "Insufficient Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal change = Math.Max(0, cashPaid - orderTotal);
            DateTime transDate = DateTime.Now;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // 1. Insert permanent record into Transactions table
                    string insertQuery = @"INSERT INTO Transactions (CustomerID, CustomerName, RefillType, Quantity, BorrowedJugs, ReturnedJugs, UnitPrice, TotalPrice, ChangeAmount, PaymentStatus, TransactionDate) 
                                           VALUES (@customerId, @customerName, @refillType, @qty, @borrowedJugs, @returnedJugs, @unitPrice, @totalPrice, @changeAmount, @paymentStatus, @transDate)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.Parameters.AddWithValue("@customerName", customerName);
                        cmd.Parameters.AddWithValue("@refillType", refillType);
                        cmd.Parameters.AddWithValue("@qty", qty);
                        cmd.Parameters.AddWithValue("@borrowedJugs", borrowedJugs);
                        cmd.Parameters.AddWithValue("@returnedJugs", returnedJugs);
                        cmd.Parameters.AddWithValue("@unitPrice", price);
                        cmd.Parameters.AddWithValue("@totalPrice", orderTotal);
                        cmd.Parameters.AddWithValue("@changeAmount", change);
                        cmd.Parameters.AddWithValue("@paymentStatus", status);
                        cmd.Parameters.AddWithValue("@transDate", transDate);
                        cmd.ExecuteNonQuery();

                        if (change > 0)
                        {
                            string addChangeSql = @"UPDATE Customers SET RemainingChange = RemainingChange + @change WHERE CustomerID = @id";
                            using (SqlCommand cmdChange = new SqlCommand(addChangeSql, conn))
                            {
                                cmdChange.Parameters.AddWithValue("@change", change);
                                cmdChange.Parameters.AddWithValue("@id", customerId);
                                cmdChange.ExecuteNonQuery();
                            }
                        }
                        AuditLogger.LogAction("Insert", "Transactions", $"Transaction (Customer #{customerId}: {customerName})", $"Processed order (Qty: {qty}, Total: ₱{orderTotal:N2}, Status: {status}, Borrowed Jugs: {borrowedJugs})", conn);
                    }

                    // 2. Update Customer's Borrowed Jugs (add newly borrowed) and Unpaid Balance if applicable
                    if (status.Equals("Unpaid", StringComparison.OrdinalIgnoreCase))
                    {
                        string updateQuery = @"UPDATE Customers 
                                               SET UnpaidBalance = UnpaidBalance + @due, 
                                                   BorrowedJugs = BorrowedJugs + @borrowedJugs 
                                               WHERE CustomerID = @id";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@due", orderTotal);
                            cmd.Parameters.AddWithValue("@borrowedJugs", borrowedJugs);
                            cmd.Parameters.AddWithValue("@id", customerId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        if (borrowedJugs > 0)
                        {
                            string updateQuery = @"UPDATE Customers 
                                                   SET BorrowedJugs = BorrowedJugs + @borrowedJugs 
                                                   WHERE CustomerID = @id";
                            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@borrowedJugs", borrowedJugs);
                                cmd.Parameters.AddWithValue("@id", customerId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                string summaryMsg = $"Order for {customerName} processed successfully!\n" +
                                   $"Type: {refillType}\n" +
                                   $"Quantity: {qty}\n" +
                                   $"Total Due: ₱{orderTotal:N2}\n";
                if (status.Equals("Paid", StringComparison.OrdinalIgnoreCase) && cashPaid > 0)
                {
                    summaryMsg += $"Amount Paid: ₱{cashPaid:N2}\n" +
                                  $"Change: ₱{change:N2}\n";
                }
                summaryMsg += $"Payment Status: {status}\n" +
                              $"Borrowed Jugs: {borrowedJugs}";

                MessageBox.Show(summaryMsg, "Order Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (numTransCashPaid != null) numTransCashPaid.Value = 0;
                LoadTransactionsData();
                LoadCustomersData();
                LoadInventoryData();
                LoadDashboardData();
                UpdateCustomerJugsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcessReturn_Click(object? sender, EventArgs e)
        {
            int customerId = GetSelectedCustomerId(cmbReturnCustomer);
            if (customerId <= 0)
            {
                MessageBox.Show("Please select or search for a customer returning jugs.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int returnedQty = (int)numReturnQty.Value;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Customers SET BorrowedJugs = CASE WHEN BorrowedJugs >= @qty THEN BorrowedJugs - @qty ELSE 0 END WHERE CustomerID = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@qty", returnedQty);
                        cmd.Parameters.AddWithValue("@id", customerId);
                        cmd.ExecuteNonQuery();
                        AuditLogger.LogAction("Update", "Customers", $"Customer #{customerId}", $"Restocked / returned {returnedQty} container(s)", conn);
                    }
                }

                MessageBox.Show($"Successfully restocked {returnedQty} returned container(s)!", "Return Recorded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInventoryData();
                UpdateReturnCustomerJugsState();
                UpdateCustomerJugsState();
                LoadCustomersData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error logging returned container: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvInventory_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvInventory.Rows.Count) return;

            DataGridViewRow row = dgvInventory.Rows[e.RowIndex];
            if (row.Cells["CustomerID"] != null && row.Cells["CustomerID"].Value != DBNull.Value && row.Cells["CustomerID"].Value != null)
            {
                int customerId = Convert.ToInt32(row.Cells["CustomerID"].Value);
                cmbReturnCustomer.SelectedValue = customerId;
                UpdateReturnCustomerJugsState();
            }
        }

        private void LoadAuditLogsData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    AuditLogger.EnsureAuditLogsTableExists(conn);

                    string query = "SELECT LogID, Timestamp, Username, ActionType, TableAffected, RecordReference, Details FROM AuditLogs ORDER BY LogID DESC";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvAuditLogs.DataSource = dt;
                        FormatAuditGridColumns(dgvAuditLogs);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load audit logs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Custom UI Painting Engine

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

            // Draw Header Title directly onto gradient (Eliminates background box / highlight artifact)
            using (Font titleFont = new Font("Segoe UI", 15f, FontStyle.Bold))
            {
                TextRenderer.DrawText(
                    e.Graphics,
                    "Water Refilling Station Tracking System",
                    titleFont,
                    new Point(22, 14),
                    Color.White,
                    TextFormatFlags.NoPadding
                );
            }

            // Draw Header Subtitle directly onto gradient
            using (Font subFont = new Font("Segoe UI", 9.5f, FontStyle.Regular))
            {
                TextRenderer.DrawText(
                    e.Graphics,
                    "Customer Profiles & Jug Balance Management",
                    subFont,
                    new Point(24, 44),
                    Color.FromArgb(224, 242, 254),
                    TextFormatFlags.NoPadding
                );
            }

            // Draw Logged-in User Status directly onto gradient
            string userText = (lblLoggedInUser != null && !string.IsNullOrEmpty(lblLoggedInUser.Text))
                ? lblLoggedInUser.Text
                : "Logged in as: Admin";

            using (Font userFont = new Font("Segoe UI", 9f, FontStyle.Bold))
            {
                Size userTextSize = TextRenderer.MeasureText(userText, userFont);
                int userX = btnLogout.Left - userTextSize.Width - 18;
                int userY = btnLogout.Top + (btnLogout.Height - userTextSize.Height) / 2;

                TextRenderer.DrawText(
                    e.Graphics,
                    userText,
                    userFont,
                    new Point(userX, userY),
                    Color.White,
                    TextFormatFlags.NoPadding
                );
            }
        }

        private void DrawStatCard(Panel panel, Color accentColor, PaintEventArgs e)
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

            // Top accent pill indicator
            using (GraphicsPath pillPath = GetRoundedRectanglePath(new Rectangle(22, 10, 36, 4), 2))
            {
                using (SolidBrush accentBrush = new SolidBrush(accentColor))
                {
                    e.Graphics.FillPath(accentBrush, pillPath);
                }
            }

            using (GraphicsPath clipPath = GetRoundedRectanglePath(panel.ClientRectangle, radius))
            {
                panel.Region = new Region(clipPath);
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

        private void DrawSubCard(Panel panel, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = panel.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            int radius = 10;
            using (GraphicsPath path = GetRoundedRectanglePath(rect, radius))
            {
                using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(248, 250, 252)))
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

        private void BtnLogout_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = btnLogout.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            int radius = 16;
            using (GraphicsPath path = GetRoundedRectanglePath(rect, radius))
            {
                Color bgColor = isLogoutHovered ? Color.FromArgb(241, 245, 249) : Color.White;
                using (SolidBrush brush = new SolidBrush(bgColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }

            using (GraphicsPath clipPath = GetRoundedRectanglePath(btnLogout.ClientRectangle, radius))
            {
                btnLogout.Region = new Region(clipPath);
            }

            TextRenderer.DrawText(
                e.Graphics,
                btnLogout.Text,
                btnLogout.Font,
                btnLogout.ClientRectangle,
                Color.FromArgb(0, 114, 255),
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
        }

        private void DrawPillButton(Button btn, bool isHovered, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = btn.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            int radius = 16;
            using (GraphicsPath path = GetRoundedRectanglePath(rect, radius))
            {
                Color startColor = isHovered ? Color.FromArgb(0, 100, 235) : Color.FromArgb(0, 114, 255);
                Color endColor = isHovered ? Color.FromArgb(0, 190, 245) : Color.FromArgb(0, 210, 255);

                using (LinearGradientBrush brush = new LinearGradientBrush(rect, startColor, endColor, 0f))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }

            using (GraphicsPath clipPath = GetRoundedRectanglePath(btn.ClientRectangle, radius))
            {
                btn.Region = new Region(clipPath);
            }

            TextRenderer.DrawText(
                e.Graphics,
                btn.Text,
                btn.Font,
                btn.ClientRectangle,
                Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );
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

        #endregion

        #region Logout Logic

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                LoginForm login = new LoginForm();
                login.Show();
                this.Hide();
            }
        }

        #endregion

        #region Preserved Designer Event Handlers

        private void dgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
        private void lblDashUnpaidBalance_Click(object sender, EventArgs e) { }
        private void lblJugsOut_Click(object sender, EventArgs e) { }
        private void lblLoggedInUser_Click(object sender, EventArgs e) { }
        private void lblTotalStock_Click(object sender, EventArgs e) { }
        private void panelInventory_Paint(object sender, PaintEventArgs e) { }
        private void panelLeft_Paint(object sender, PaintEventArgs e) { }
        private void panelRight_Paint(object sender, PaintEventArgs e) { }

        #endregion
    }

    #region Modern Navigation ToolStrip Renderer

    public class ModernToolStripRenderer : ToolStripProfessionalRenderer
    {
        public string ActiveTabName { get; set; } = "Dashboard";

        public ModernToolStripRenderer() : base(new ModernColorTable())
        {
            this.RoundedEdges = true;
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            // Transparent background so header gradient shines through
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // No default border line
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
            bounds.Inflate(-2, -2);

            if (e.Item.Selected || e.Item.Pressed)
            {
                using (GraphicsPath path = GetPillPath(bounds, 10))
                {
                    Color fillColor = e.Item.Pressed
                        ? Color.FromArgb(90, 255, 255, 255)
                        : Color.FromArgb(50, 255, 255, 255);
                    using (SolidBrush brush = new SolidBrush(fillColor))
                    {
                        g.FillPath(brush, path);
                    }
                }
            }
            else if (e.Item.Text != null && e.Item.Text.Equals(ActiveTabName, StringComparison.OrdinalIgnoreCase))
            {
                using (GraphicsPath path = GetPillPath(bounds, 10))
                {
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(45, 255, 255, 255)))
                    {
                        g.FillPath(brush, path);
                    }
                    using (Pen pen = new Pen(Color.FromArgb(130, 255, 255, 255), 1.2f))
                    {
                        g.DrawPath(pen, path);
                    }
                }
            }
        }

        private GraphicsPath GetPillPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            Rectangle arc = new Rectangle(rect.Location, new Size(d, d));

            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - d;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - d;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }
    }

    public class ModernColorTable : ProfessionalColorTable
    {
        public override Color ToolStripGradientBegin => Color.Transparent;
        public override Color ToolStripGradientMiddle => Color.Transparent;
        public override Color ToolStripGradientEnd => Color.Transparent;
    }

    #endregion
}