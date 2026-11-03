namespace WaterStationTPS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelHeader = new Panel();
            lblLoggedInUser = new Label();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            toolStripButton5 = new ToolStripButton();
            toolStripButton6 = new ToolStripButton();
            lblHeaderTitle = new Label();
            lblHeaderSubtitle = new Label();
            btnLogout = new Button();
            panelTransactions = new Panel();
            panelTransForm = new Panel();
            lblTransSection = new Label();
            lblTransSub = new Label();
            cmbTransCustomer = new ComboBox();
            pnlTransCustInfo = new Panel();
            lblTransCustBal = new Label();
            lblTransCustJugs = new Label();
            lblTransCustChange = new Label();
            btnReleaseChange = new Button();
            btnModeNewOrder = new Button();
            btnModeUpdateCust = new Button();
            pnlTransNewOrder = new Panel();
            pnlTransUpdateCust = new Panel();
            lblUpdatePay = new Label();
            numUpdatePay = new NumericUpDown();
            lblUpdateReturned = new Label();
            numUpdateReturned = new NumericUpDown();
            pnlUpdateSummary = new Panel();
            lblUpdateSummaryTitle = new Label();
            lblUpdateBalPreview = new Label();
            lblUpdateChangePreview = new Label();
            lblUpdateJugsPreview = new Label();
            btnSaveTransCust = new Button();
            label3 = new Label();
            numTransQty = new NumericUpDown();
            label5 = new Label();
            lblBorrowedJugs = new Label();
            cmbBorrowedJugs = new ComboBox();
            txtUnitPrice = new ComboBox();
            label6 = new Label();
            cmbPaymentStatus = new ComboBox();
            label7 = new Label();
            pnlTransSummary = new Panel();
            lblTransTotalLabel = new Label();
            lblTransTotalAmount = new Label();
            lblTransCash = new Label();
            numTransCashPaid = new NumericUpDown();
            lblTransChangeLabel = new Label();
            lblTransChangeAmount = new Label();
            btnProcessTransaction = new Button();
            panelTransGrid = new Panel();
            lblTransGridTitle = new Label();
            lblTransGridSub = new Label();
            btnRefreshTrans = new Button();
            dgvTransactions = new DataGridView();
            panelLeft = new Panel();
            lblCustomerSection = new Label();
            lblCustSub = new Label();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            panelRight = new Panel();
            lblGridTitle = new Label();
            lblCustGridSub = new Label();
            btnRefreshCust = new Button();
            dgvCustomers = new DataGridView();
            panelInventory = new Panel();
            pnlTotalStock = new Panel();
            lblTotalStock = new Label();
            label8 = new Label();
            lblSubTotalStock = new Label();
            pnlJugsOut = new Panel();
            lblJugsOut = new Label();
            label9 = new Label();
            lblSubJugsOut = new Label();
            pnlOverdue = new Panel();
            lblOverdue = new Label();
            label10 = new Label();
            lblSubOverdue = new Label();
            panelReturnCard = new Panel();
            lblReturnHeader = new Label();
            lblReturnSub = new Label();
            grpReturn = new GroupBox();
            pnlReturnCustInfo = new Panel();
            lblReturnCustJugs = new Label();
            btnProcessReturn = new Button();
            numReturnQty = new NumericUpDown();
            label12 = new Label();
            cmbReturnCustomer = new ComboBox();
            label11 = new Label();
            panelInvGridCard = new Panel();
            lblInvGridTitle = new Label();
            lblInvGridSub = new Label();
            btnRefreshInv = new Button();
            dgvInventory = new DataGridView();
            panelDashboard = new Panel();
            label16 = new Label();
            lblDashRecentSub = new Label();
            btnDashRefresh = new Button();
            dgvDashRecent = new DataGridView();
            panelRecentCard = new Panel();
            panel3 = new Panel();
            lblDashUnpaidBalance = new Label();
            label15 = new Label();
            lblSubBalance = new Label();
            panel2 = new Panel();
            lblDashBorrowedJugs = new Label();
            label14 = new Label();
            lblSubBorrowed = new Label();
            panel1 = new Panel();
            lblDashTotalCustomers = new Label();
            label13 = new Label();
            lblSubCustomers = new Label();
            panelAuditLogs = new Panel();
            panelAuditGridCard = new Panel();
            lblAuditGridTitle = new Label();
            lblAuditGridSub = new Label();
            btnRefreshAudit = new Button();
            dgvAuditLogs = new DataGridView();
            panelHeader.SuspendLayout();
            toolStrip1.SuspendLayout();
            panelTransactions.SuspendLayout();
            panelTransForm.SuspendLayout();
            pnlTransCustInfo.SuspendLayout();
            pnlTransNewOrder.SuspendLayout();
            pnlTransSummary.SuspendLayout();
            pnlTransUpdateCust.SuspendLayout();
            pnlUpdateSummary.SuspendLayout();
            panelTransGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTransQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTransCashPaid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numUpdatePay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numUpdateReturned).BeginInit();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            panelInventory.SuspendLayout();
            pnlTotalStock.SuspendLayout();
            pnlJugsOut.SuspendLayout();
            pnlOverdue.SuspendLayout();
            panelReturnCard.SuspendLayout();
            grpReturn.SuspendLayout();
            pnlReturnCustInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numReturnQty).BeginInit();
            panelInvGridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            panelDashboard.SuspendLayout();
            panelRecentCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashRecent).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panelAuditLogs.SuspendLayout();
            panelAuditGridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLogs).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(0, 114, 255);
            panelHeader.Controls.Add(lblLoggedInUser);
            panelHeader.Controls.Add(toolStrip1);
            panelHeader.Controls.Add(lblHeaderTitle);
            panelHeader.Controls.Add(lblHeaderSubtitle);
            panelHeader.Controls.Add(btnLogout);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1200, 110);
            panelHeader.TabIndex = 0;
            // 
            // lblLoggedInUser
            // 
            lblLoggedInUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLoggedInUser.AutoSize = true;
            lblLoggedInUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLoggedInUser.ForeColor = Color.White;
            lblLoggedInUser.Location = new Point(940, 27);
            lblLoggedInUser.Name = "lblLoggedInUser";
            lblLoggedInUser.Size = new Size(121, 15);
            lblLoggedInUser.TabIndex = 5;
            lblLoggedInUser.Text = "Logged in as: Admin";
            lblLoggedInUser.Visible = false;
            lblLoggedInUser.Click += lblLoggedInUser_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = Color.Transparent;
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5, toolStripButton6 });
            toolStrip1.Location = new Point(20, 72);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(480, 28);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            toolStripButton1.ForeColor = Color.White;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Padding = new Padding(6, 2, 6, 2);
            toolStripButton1.Size = new Size(81, 25);
            toolStripButton1.Text = "Dashboard";
            toolStripButton1.Click += btnNavDashboard_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            toolStripButton2.ForeColor = Color.White;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Padding = new Padding(6, 2, 6, 2);
            toolStripButton2.Size = new Size(80, 25);
            toolStripButton2.Text = "Customers";
            toolStripButton2.Click += btnNavCustomers_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            toolStripButton3.ForeColor = Color.White;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Padding = new Padding(6, 2, 6, 2);
            toolStripButton3.Size = new Size(91, 25);
            toolStripButton3.Text = "Transactions";
            toolStripButton3.Click += btnNavTransactions_Click;
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton4.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            toolStripButton4.ForeColor = Color.White;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Padding = new Padding(6, 2, 6, 2);
            toolStripButton4.Size = new Size(74, 25);
            toolStripButton4.Text = "Inventory";
            toolStripButton4.Click += btnNavInventory_Click;
            // 
            // toolStripButton5
            // 
            toolStripButton5.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton5.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            toolStripButton5.ForeColor = Color.White;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Padding = new Padding(6, 2, 6, 2);
            toolStripButton5.Size = new Size(64, 25);
            toolStripButton5.Text = "Reports";
            toolStripButton5.Click += btnNavReports_Click;
            // 
            // toolStripButton6
            // 
            toolStripButton6.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton6.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            toolStripButton6.ForeColor = Color.White;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Padding = new Padding(6, 2, 6, 2);
            toolStripButton6.Size = new Size(82, 25);
            toolStripButton6.Text = "Audit Logs";
            toolStripButton6.Click += btnNavAuditLogs_Click;
            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(22, 14);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new Size(385, 28);
            lblHeaderTitle.TabIndex = 0;
            lblHeaderTitle.Text = "Water Refilling Station Tracking System";
            lblHeaderTitle.Visible = false;
            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(224, 242, 254);
            lblHeaderSubtitle.Location = new Point(24, 44);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new Size(260, 17);
            lblHeaderSubtitle.TabIndex = 1;
            lblHeaderSubtitle.Text = "Customer Profiles & Jug Balance Management";
            lblHeaderSubtitle.Visible = false;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.White;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLogout.ForeColor = Color.FromArgb(0, 114, 255);
            btnLogout.Location = new Point(1085, 18);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(90, 32);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panelTransactions
            // 
            panelTransactions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelTransactions.BackColor = Color.FromArgb(241, 245, 249);
            panelTransactions.Controls.Add(panelTransGrid);
            panelTransactions.Controls.Add(panelTransForm);
            panelTransactions.Location = new Point(0, 110);
            panelTransactions.Name = "panelTransactions";
            panelTransactions.Size = new Size(1200, 550);
            panelTransactions.TabIndex = 6;
            panelTransactions.Visible = false;
            // 
            // panelTransForm
            // 
            panelTransForm.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelTransForm.BackColor = Color.White;
            panelTransForm.Controls.Add(pnlTransUpdateCust);
            panelTransForm.Controls.Add(pnlTransNewOrder);
            panelTransForm.Controls.Add(btnModeUpdateCust);
            panelTransForm.Controls.Add(btnModeNewOrder);
            panelTransForm.Controls.Add(pnlTransCustInfo);
            panelTransForm.Controls.Add(cmbTransCustomer);
            panelTransForm.Controls.Add(label3);
            panelTransForm.Controls.Add(lblTransSub);
            panelTransForm.Controls.Add(lblTransSection);
            panelTransForm.Location = new Point(24, 15);
            panelTransForm.Name = "panelTransForm";
            panelTransForm.Size = new Size(380, 515);
            panelTransForm.TabIndex = 0;
            // 
            // lblTransSection
            // 
            lblTransSection.AutoSize = true;
            lblTransSection.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTransSection.ForeColor = Color.FromArgb(15, 23, 42);
            lblTransSection.Location = new Point(18, 10);
            lblTransSection.Name = "lblTransSection";
            lblTransSection.Size = new Size(160, 21);
            lblTransSection.TabIndex = 0;
            lblTransSection.Text = "Process New Order";
            // 
            // lblTransSub
            // 
            lblTransSub.AutoSize = true;
            lblTransSub.Font = new Font("Segoe UI", 8.5F);
            lblTransSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblTransSub.Location = new Point(19, 32);
            lblTransSub.Name = "lblTransSub";
            lblTransSub.Size = new Size(255, 15);
            lblTransSub.TabIndex = 1;
            lblTransSub.Text = "Record water refill sales, pricing, and payments";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(71, 85, 105);
            label3.Location = new Point(18, 52);
            label3.Name = "label3";
            label3.Size = new Size(96, 15);
            label3.TabIndex = 2;
            label3.Text = "Select Customer:";
            // 
            // cmbTransCustomer
            // 
            cmbTransCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbTransCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbTransCustomer.DropDownStyle = ComboBoxStyle.DropDown;
            cmbTransCustomer.Font = new Font("Segoe UI", 9.5F);
            cmbTransCustomer.FormattingEnabled = true;
            cmbTransCustomer.Location = new Point(18, 70);
            cmbTransCustomer.Name = "cmbTransCustomer";
            cmbTransCustomer.Size = new Size(344, 25);
            cmbTransCustomer.TabIndex = 3;
            // 
            // pnlTransCustInfo
            // 
            pnlTransCustInfo.BackColor = Color.FromArgb(248, 250, 252);
            pnlTransCustInfo.Controls.Add(btnReleaseChange);
            pnlTransCustInfo.Controls.Add(lblTransCustChange);
            pnlTransCustInfo.Controls.Add(lblTransCustJugs);
            pnlTransCustInfo.Controls.Add(lblTransCustBal);
            pnlTransCustInfo.Location = new Point(18, 100);
            pnlTransCustInfo.Name = "pnlTransCustInfo";
            pnlTransCustInfo.Size = new Size(344, 46);
            pnlTransCustInfo.TabIndex = 4;
            // 
            // lblTransCustBal
            // 
            lblTransCustBal.AutoSize = true;
            lblTransCustBal.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTransCustBal.ForeColor = Color.FromArgb(225, 29, 72);
            lblTransCustBal.Location = new Point(12, 6);
            lblTransCustBal.Name = "lblTransCustBal";
            lblTransCustBal.Size = new Size(115, 15);
            lblTransCustBal.TabIndex = 0;
            lblTransCustBal.Text = "Unpaid Due: ₱0.00";
            // 
            // lblTransCustJugs
            // 
            lblTransCustJugs.AutoSize = true;
            lblTransCustJugs.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTransCustJugs.ForeColor = Color.FromArgb(217, 119, 6);
            lblTransCustJugs.Location = new Point(12, 24);
            lblTransCustJugs.Name = "lblTransCustJugs";
            lblTransCustJugs.Size = new Size(108, 15);
            lblTransCustJugs.TabIndex = 1;
            lblTransCustJugs.Text = "Borrowed Jugs: 0";
            // 
            // lblTransCustChange
            // 
            lblTransCustChange.AutoSize = true;
            lblTransCustChange.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTransCustChange.ForeColor = Color.FromArgb(5, 150, 105);
            lblTransCustChange.Location = new Point(165, 6);
            lblTransCustChange.Name = "lblTransCustChange";
            lblTransCustChange.Size = new Size(130, 15);
            lblTransCustChange.TabIndex = 2;
            lblTransCustChange.Text = "Change to Give: ₱0.00";
            // 
            // btnReleaseChange
            // 
            btnReleaseChange.BackColor = Color.FromArgb(5, 150, 105);
            btnReleaseChange.Cursor = Cursors.Hand;
            btnReleaseChange.FlatAppearance.BorderSize = 0;
            btnReleaseChange.FlatStyle = FlatStyle.Flat;
            btnReleaseChange.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            btnReleaseChange.ForeColor = Color.White;
            btnReleaseChange.Location = new Point(165, 23);
            btnReleaseChange.Name = "btnReleaseChange";
            btnReleaseChange.Size = new Size(165, 20);
            btnReleaseChange.TabIndex = 3;
            btnReleaseChange.Text = "Release Change (Give)";
            btnReleaseChange.UseVisualStyleBackColor = false;
            btnReleaseChange.Visible = false;
            btnReleaseChange.Click += btnReleaseChange_Click;
            // 
            // btnModeNewOrder
            // 
            btnModeNewOrder.BackColor = Color.FromArgb(0, 114, 255);
            btnModeNewOrder.Cursor = Cursors.Hand;
            btnModeNewOrder.FlatAppearance.BorderSize = 0;
            btnModeNewOrder.FlatStyle = FlatStyle.Flat;
            btnModeNewOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnModeNewOrder.ForeColor = Color.White;
            btnModeNewOrder.Location = new Point(18, 152);
            btnModeNewOrder.Name = "btnModeNewOrder";
            btnModeNewOrder.Size = new Size(168, 34);
            btnModeNewOrder.TabIndex = 5;
            btnModeNewOrder.Text = "Process New Order";
            btnModeNewOrder.UseVisualStyleBackColor = false;
            btnModeNewOrder.Click += btnModeNewOrder_Click;
            // 
            // btnModeUpdateCust
            // 
            btnModeUpdateCust.BackColor = Color.FromArgb(241, 245, 249);
            btnModeUpdateCust.Cursor = Cursors.Hand;
            btnModeUpdateCust.FlatAppearance.BorderSize = 0;
            btnModeUpdateCust.FlatStyle = FlatStyle.Flat;
            btnModeUpdateCust.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnModeUpdateCust.ForeColor = Color.FromArgb(71, 85, 105);
            btnModeUpdateCust.Location = new Point(194, 152);
            btnModeUpdateCust.Name = "btnModeUpdateCust";
            btnModeUpdateCust.Size = new Size(168, 34);
            btnModeUpdateCust.TabIndex = 6;
            btnModeUpdateCust.Text = "Update";
            btnModeUpdateCust.UseVisualStyleBackColor = false;
            btnModeUpdateCust.Click += btnModeUpdateCust_Click;
            // 
            // pnlTransNewOrder
            // 
            pnlTransNewOrder.Controls.Add(btnProcessTransaction);
            pnlTransNewOrder.Controls.Add(pnlTransSummary);
            pnlTransNewOrder.Controls.Add(numTransCashPaid);
            pnlTransNewOrder.Controls.Add(lblTransCash);
            pnlTransNewOrder.Controls.Add(cmbPaymentStatus);
            pnlTransNewOrder.Controls.Add(label7);
            pnlTransNewOrder.Controls.Add(cmbBorrowedJugs);
            pnlTransNewOrder.Controls.Add(lblBorrowedJugs);
            pnlTransNewOrder.Controls.Add(txtUnitPrice);
            pnlTransNewOrder.Controls.Add(label6);
            pnlTransNewOrder.Controls.Add(numTransQty);
            pnlTransNewOrder.Controls.Add(label5);
            pnlTransNewOrder.Location = new Point(18, 192);
            pnlTransNewOrder.Name = "pnlTransNewOrder";
            pnlTransNewOrder.Size = new Size(344, 315);
            pnlTransNewOrder.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(71, 85, 105);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(130, 15);
            label5.TabIndex = 0;
            label5.Text = "Quantity (Containers):";
            // 
            // numTransQty
            // 
            numTransQty.Font = new Font("Segoe UI", 9.5F);
            numTransQty.Location = new Point(0, 18);
            numTransQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTransQty.Name = "numTransQty";
            numTransQty.Size = new Size(165, 24);
            numTransQty.TabIndex = 1;
            numTransQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(71, 85, 105);
            label6.Location = new Point(179, 0);
            label6.Name = "label6";
            label6.Size = new Size(81, 15);
            label6.TabIndex = 2;
            label6.Text = "Unit Price (₱):";
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Font = new Font("Segoe UI", 9.5F);
            txtUnitPrice.FormattingEnabled = true;
            txtUnitPrice.Items.AddRange(new object[] { "25.00", "30.00", "35.00", "40.00", "50.00" });
            txtUnitPrice.Location = new Point(179, 18);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(165, 25);
            txtUnitPrice.TabIndex = 3;
            txtUnitPrice.Text = "30.00";
            // 
            // lblBorrowedJugs
            // 
            lblBorrowedJugs.AutoSize = true;
            lblBorrowedJugs.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblBorrowedJugs.ForeColor = Color.FromArgb(71, 85, 105);
            lblBorrowedJugs.Location = new Point(0, 48);
            lblBorrowedJugs.Name = "lblBorrowedJugs";
            lblBorrowedJugs.Size = new Size(89, 15);
            lblBorrowedJugs.TabIndex = 4;
            lblBorrowedJugs.Text = "Borrowed Jugs:";
            // 
            // cmbBorrowedJugs
            // 
            cmbBorrowedJugs.Font = new Font("Segoe UI", 9.5F);
            cmbBorrowedJugs.FormattingEnabled = true;
            cmbBorrowedJugs.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "15", "20" });
            cmbBorrowedJugs.Location = new Point(0, 66);
            cmbBorrowedJugs.Name = "cmbBorrowedJugs";
            cmbBorrowedJugs.Size = new Size(165, 25);
            cmbBorrowedJugs.TabIndex = 5;
            cmbBorrowedJugs.Text = "0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(71, 85, 105);
            label7.Location = new Point(179, 48);
            label7.Name = "label7";
            label7.Size = new Size(95, 15);
            label7.TabIndex = 6;
            label7.Text = "Payment Status:";
            // 
            // cmbPaymentStatus
            // 
            cmbPaymentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentStatus.Font = new Font("Segoe UI", 9.5F);
            cmbPaymentStatus.FormattingEnabled = true;
            cmbPaymentStatus.Items.AddRange(new object[] { "Paid", "Unpaid" });
            cmbPaymentStatus.Location = new Point(179, 66);
            cmbPaymentStatus.Name = "cmbPaymentStatus";
            cmbPaymentStatus.Size = new Size(165, 25);
            cmbPaymentStatus.TabIndex = 7;
            // 
            // lblTransCash
            // 
            lblTransCash.AutoSize = true;
            lblTransCash.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTransCash.ForeColor = Color.FromArgb(71, 85, 105);
            lblTransCash.Location = new Point(0, 96);
            lblTransCash.Name = "lblTransCash";
            lblTransCash.Size = new Size(137, 15);
            lblTransCash.TabIndex = 8;
            lblTransCash.Text = "Amount Paid / Cash (₱):";
            // 
            // numTransCashPaid
            // 
            numTransCashPaid.DecimalPlaces = 2;
            numTransCashPaid.Font = new Font("Segoe UI", 9.5F);
            numTransCashPaid.Location = new Point(0, 114);
            numTransCashPaid.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numTransCashPaid.Name = "numTransCashPaid";
            numTransCashPaid.Size = new Size(344, 24);
            numTransCashPaid.TabIndex = 9;
            // 
            // pnlTransSummary
            // 
            pnlTransSummary.BackColor = Color.FromArgb(248, 250, 252);
            pnlTransSummary.Controls.Add(lblTransChangeAmount);
            pnlTransSummary.Controls.Add(lblTransChangeLabel);
            pnlTransSummary.Controls.Add(lblTransTotalAmount);
            pnlTransSummary.Controls.Add(lblTransTotalLabel);
            pnlTransSummary.Location = new Point(0, 146);
            pnlTransSummary.Name = "pnlTransSummary";
            pnlTransSummary.Size = new Size(344, 58);
            pnlTransSummary.TabIndex = 10;
            // 
            // lblTransTotalLabel
            // 
            lblTransTotalLabel.AutoSize = true;
            lblTransTotalLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblTransTotalLabel.ForeColor = Color.FromArgb(100, 116, 139);
            lblTransTotalLabel.Location = new Point(12, 6);
            lblTransTotalLabel.Name = "lblTransTotalLabel";
            lblTransTotalLabel.Size = new Size(62, 13);
            lblTransTotalLabel.TabIndex = 0;
            lblTransTotalLabel.Text = "TOTAL DUE";
            // 
            // lblTransTotalAmount
            // 
            lblTransTotalAmount.AutoSize = true;
            lblTransTotalAmount.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTransTotalAmount.ForeColor = Color.FromArgb(0, 114, 255);
            lblTransTotalAmount.Location = new Point(10, 22);
            lblTransTotalAmount.Name = "lblTransTotalAmount";
            lblTransTotalAmount.Size = new Size(82, 30);
            lblTransTotalAmount.TabIndex = 1;
            lblTransTotalAmount.Text = "₱30.00";
            // 
            // lblTransChangeLabel
            // 
            lblTransChangeLabel.AutoSize = true;
            lblTransChangeLabel.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblTransChangeLabel.ForeColor = Color.FromArgb(100, 116, 139);
            lblTransChangeLabel.Location = new Point(180, 6);
            lblTransChangeLabel.Name = "lblTransChangeLabel";
            lblTransChangeLabel.Size = new Size(78, 13);
            lblTransChangeLabel.TabIndex = 2;
            lblTransChangeLabel.Text = "CHANGE DUE";
            // 
            // lblTransChangeAmount
            // 
            lblTransChangeAmount.AutoSize = true;
            lblTransChangeAmount.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTransChangeAmount.ForeColor = Color.FromArgb(5, 150, 105);
            lblTransChangeAmount.Location = new Point(178, 22);
            lblTransChangeAmount.Name = "lblTransChangeAmount";
            lblTransChangeAmount.Size = new Size(70, 30);
            lblTransChangeAmount.TabIndex = 3;
            lblTransChangeAmount.Text = "₱0.00";
            // 
            // btnProcessTransaction
            // 
            btnProcessTransaction.BackColor = Color.FromArgb(0, 114, 255);
            btnProcessTransaction.Cursor = Cursors.Hand;
            btnProcessTransaction.FlatAppearance.BorderSize = 0;
            btnProcessTransaction.FlatStyle = FlatStyle.Flat;
            btnProcessTransaction.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnProcessTransaction.ForeColor = Color.White;
            btnProcessTransaction.Location = new Point(0, 212);
            btnProcessTransaction.Name = "btnProcessTransaction";
            btnProcessTransaction.Size = new Size(344, 44);
            btnProcessTransaction.TabIndex = 11;
            btnProcessTransaction.Text = "Process Order";
            btnProcessTransaction.UseVisualStyleBackColor = false;
            btnProcessTransaction.Click += btnProcessTransaction_Click;
            // 
            // pnlTransUpdateCust
            // 
            pnlTransUpdateCust.Controls.Add(btnSaveTransCust);
            pnlTransUpdateCust.Controls.Add(pnlUpdateSummary);
            pnlTransUpdateCust.Controls.Add(numUpdateReturned);
            pnlTransUpdateCust.Controls.Add(lblUpdateReturned);
            pnlTransUpdateCust.Controls.Add(numUpdatePay);
            pnlTransUpdateCust.Controls.Add(lblUpdatePay);
            pnlTransUpdateCust.Location = new Point(18, 192);
            pnlTransUpdateCust.Name = "pnlTransUpdateCust";
            pnlTransUpdateCust.Size = new Size(344, 315);
            pnlTransUpdateCust.TabIndex = 8;
            pnlTransUpdateCust.Visible = false;
            // 
            // lblUpdatePay
            // 
            lblUpdatePay.AutoSize = true;
            lblUpdatePay.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblUpdatePay.ForeColor = Color.FromArgb(71, 85, 105);
            lblUpdatePay.Location = new Point(0, 0);
            lblUpdatePay.Name = "lblUpdatePay";
            lblUpdatePay.Size = new Size(174, 15);
            lblUpdatePay.TabIndex = 0;
            lblUpdatePay.Text = "Amount to Pay / Settle Due (₱):";
            // 
            // numUpdatePay
            // 
            numUpdatePay.DecimalPlaces = 2;
            numUpdatePay.Font = new Font("Segoe UI", 9.5F);
            numUpdatePay.Location = new Point(0, 18);
            numUpdatePay.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numUpdatePay.Name = "numUpdatePay";
            numUpdatePay.Size = new Size(344, 24);
            numUpdatePay.TabIndex = 1;
            // 
            // lblUpdateReturned
            // 
            lblUpdateReturned.AutoSize = true;
            lblUpdateReturned.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblUpdateReturned.ForeColor = Color.FromArgb(71, 85, 105);
            lblUpdateReturned.Location = new Point(0, 48);
            lblUpdateReturned.Name = "lblUpdateReturned";
            lblUpdateReturned.Size = new Size(160, 15);
            lblUpdateReturned.TabIndex = 2;
            lblUpdateReturned.Text = "Return Borrowed Jugs (Qty):";
            // 
            // numUpdateReturned
            // 
            numUpdateReturned.Font = new Font("Segoe UI", 9.5F);
            numUpdateReturned.Location = new Point(0, 66);
            numUpdateReturned.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numUpdateReturned.Name = "numUpdateReturned";
            numUpdateReturned.Size = new Size(344, 24);
            numUpdateReturned.TabIndex = 3;
            // 
            // pnlUpdateSummary
            // 
            pnlUpdateSummary.BackColor = Color.FromArgb(248, 250, 252);
            pnlUpdateSummary.Controls.Add(lblUpdateJugsPreview);
            pnlUpdateSummary.Controls.Add(lblUpdateChangePreview);
            pnlUpdateSummary.Controls.Add(lblUpdateBalPreview);
            pnlUpdateSummary.Controls.Add(lblUpdateSummaryTitle);
            pnlUpdateSummary.Location = new Point(0, 104);
            pnlUpdateSummary.Name = "pnlUpdateSummary";
            pnlUpdateSummary.Size = new Size(344, 98);
            pnlUpdateSummary.TabIndex = 4;
            // 
            // lblUpdateSummaryTitle
            // 
            lblUpdateSummaryTitle.AutoSize = true;
            lblUpdateSummaryTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblUpdateSummaryTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblUpdateSummaryTitle.Location = new Point(12, 6);
            lblUpdateSummaryTitle.Name = "lblUpdateSummaryTitle";
            lblUpdateSummaryTitle.Size = new Size(187, 13);
            lblUpdateSummaryTitle.TabIndex = 0;
            lblUpdateSummaryTitle.Text = "UPDATED BALANCE & JUG SUMMARY";
            // 
            // lblUpdateBalPreview
            // 
            lblUpdateBalPreview.AutoSize = true;
            lblUpdateBalPreview.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUpdateBalPreview.ForeColor = Color.FromArgb(225, 29, 72);
            lblUpdateBalPreview.Location = new Point(12, 26);
            lblUpdateBalPreview.Name = "lblUpdateBalPreview";
            lblUpdateBalPreview.Size = new Size(149, 17);
            lblUpdateBalPreview.TabIndex = 1;
            lblUpdateBalPreview.Text = "Remaining Due: ₱0.00";
            // 
            // lblUpdateChangePreview
            // 
            lblUpdateChangePreview.AutoSize = true;
            lblUpdateChangePreview.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUpdateChangePreview.ForeColor = Color.FromArgb(5, 150, 105);
            lblUpdateChangePreview.Location = new Point(12, 48);
            lblUpdateChangePreview.Name = "lblUpdateChangePreview";
            lblUpdateChangePreview.Size = new Size(130, 17);
            lblUpdateChangePreview.TabIndex = 2;
            lblUpdateChangePreview.Text = "Change Due: ₱0.00";
            // 
            // lblUpdateJugsPreview
            // 
            lblUpdateJugsPreview.AutoSize = true;
            lblUpdateJugsPreview.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUpdateJugsPreview.ForeColor = Color.FromArgb(217, 119, 6);
            lblUpdateJugsPreview.Location = new Point(12, 70);
            lblUpdateJugsPreview.Name = "lblUpdateJugsPreview";
            lblUpdateJugsPreview.Size = new Size(157, 17);
            lblUpdateJugsPreview.TabIndex = 3;
            lblUpdateJugsPreview.Text = "Remaining Jugs: 0 jugs";
            // 
            // btnSaveTransCust
            // 
            btnSaveTransCust.BackColor = Color.FromArgb(5, 150, 105);
            btnSaveTransCust.Cursor = Cursors.Hand;
            btnSaveTransCust.FlatAppearance.BorderSize = 0;
            btnSaveTransCust.FlatStyle = FlatStyle.Flat;
            btnSaveTransCust.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveTransCust.ForeColor = Color.White;
            btnSaveTransCust.Location = new Point(0, 212);
            btnSaveTransCust.Name = "btnSaveTransCust";
            btnSaveTransCust.Size = new Size(344, 44);
            btnSaveTransCust.TabIndex = 5;
            btnSaveTransCust.Text = "Save / Update Customer Status";
            btnSaveTransCust.UseVisualStyleBackColor = false;
            btnSaveTransCust.Click += btnSaveTransCust_Click;
            // 
            // panelTransGrid
            // 
            panelTransGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelTransGrid.BackColor = Color.White;
            panelTransGrid.Controls.Add(btnRefreshTrans);
            panelTransGrid.Controls.Add(lblTransGridSub);
            panelTransGrid.Controls.Add(lblTransGridTitle);
            panelTransGrid.Controls.Add(dgvTransactions);
            panelTransGrid.Location = new Point(420, 15);
            panelTransGrid.Name = "panelTransGrid";
            panelTransGrid.Size = new Size(756, 515);
            panelTransGrid.TabIndex = 1;
            // 
            // lblTransGridTitle
            // 
            lblTransGridTitle.AutoSize = true;
            lblTransGridTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTransGridTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTransGridTitle.Location = new Point(20, 14);
            lblTransGridTitle.Name = "lblTransGridTitle";
            lblTransGridTitle.Size = new Size(227, 21);
            lblTransGridTitle.TabIndex = 0;
            lblTransGridTitle.Text = "Transaction & Order History";
            // 
            // lblTransGridSub
            // 
            lblTransGridSub.AutoSize = true;
            lblTransGridSub.Font = new Font("Segoe UI", 8.5F);
            lblTransGridSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblTransGridSub.Location = new Point(21, 38);
            lblTransGridSub.Name = "lblTransGridSub";
            lblTransGridSub.Size = new Size(253, 15);
            lblTransGridSub.TabIndex = 1;
            lblTransGridSub.Text = "Audit trail of water refills and billing records";
            // 
            // btnRefreshTrans
            // 
            btnRefreshTrans.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefreshTrans.BackColor = Color.FromArgb(0, 114, 255);
            btnRefreshTrans.Cursor = Cursors.Hand;
            btnRefreshTrans.FlatAppearance.BorderSize = 0;
            btnRefreshTrans.FlatStyle = FlatStyle.Flat;
            btnRefreshTrans.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefreshTrans.ForeColor = Color.White;
            btnRefreshTrans.Location = new Point(616, 14);
            btnRefreshTrans.Name = "btnRefreshTrans";
            btnRefreshTrans.Size = new Size(120, 34);
            btnRefreshTrans.TabIndex = 2;
            btnRefreshTrans.Text = "Refresh Orders";
            btnRefreshTrans.UseVisualStyleBackColor = false;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.BackgroundColor = Color.White;
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new Point(20, 68);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.Size = new Size(716, 427);
            dgvTransactions.TabIndex = 3;
            // 
            // panelLeft
            // 
            panelLeft.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelLeft.BackColor = Color.White;
            panelLeft.Controls.Add(btnClear);
            panelLeft.Controls.Add(btnDelete);
            panelLeft.Controls.Add(btnUpdate);
            panelLeft.Controls.Add(btnAdd);
            panelLeft.Controls.Add(txtAddress);
            panelLeft.Controls.Add(lblAddress);
            panelLeft.Controls.Add(txtPhone);
            panelLeft.Controls.Add(lblPhone);
            panelLeft.Controls.Add(txtFullName);
            panelLeft.Controls.Add(lblFullName);
            panelLeft.Controls.Add(lblCustSub);
            panelLeft.Controls.Add(lblCustomerSection);
            panelLeft.Location = new Point(24, 125);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(380, 515);
            panelLeft.TabIndex = 1;
            panelLeft.Paint += panelLeft_Paint;
            // 
            // lblCustomerSection
            // 
            lblCustomerSection.AutoSize = true;
            lblCustomerSection.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCustomerSection.ForeColor = Color.FromArgb(15, 23, 42);
            lblCustomerSection.Location = new Point(20, 14);
            lblCustomerSection.Name = "lblCustomerSection";
            lblCustomerSection.Size = new Size(185, 21);
            lblCustomerSection.TabIndex = 0;
            lblCustomerSection.Text = "Customer Registration";
            // 
            // lblCustSub
            // 
            lblCustSub.AutoSize = true;
            lblCustSub.Font = new Font("Segoe UI", 8.5F);
            lblCustSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblCustSub.Location = new Point(21, 38);
            lblCustSub.Name = "lblCustSub";
            lblCustSub.Size = new Size(244, 15);
            lblCustSub.TabIndex = 1;
            lblCustSub.Text = "Register and manage customer profiles";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(71, 85, 105);
            lblFullName.Location = new Point(20, 65);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(65, 15);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Full Name:";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 9.5F);
            txtFullName.Location = new Point(20, 85);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(340, 24);
            txtFullName.TabIndex = 3;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblPhone.ForeColor = Color.FromArgb(71, 85, 105);
            lblPhone.Location = new Point(20, 120);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(93, 15);
            lblPhone.TabIndex = 4;
            lblPhone.Text = "Phone Number:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 9.5F);
            txtPhone.Location = new Point(20, 140);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(340, 24);
            txtPhone.TabIndex = 5;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(71, 85, 105);
            lblAddress.Location = new Point(20, 175);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(137, 15);
            lblAddress.TabIndex = 6;
            lblAddress.Text = "Address / Delivery Area:";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 9.5F);
            txtAddress.Location = new Point(20, 195);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(340, 24);
            txtAddress.TabIndex = 7;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(0, 114, 255);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(20, 245);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(165, 38);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Save Customer";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(2, 132, 199);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(195, 245);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(165, 38);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update Customer";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(239, 68, 68);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(20, 295);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(165, 36);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete Customer";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(241, 245, 249);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.FromArgb(51, 65, 85);
            btnClear.Location = new Point(195, 295);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(165, 36);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear Fields";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // panelRight
            // 
            panelRight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRight.BackColor = Color.White;
            panelRight.Controls.Add(btnRefreshCust);
            panelRight.Controls.Add(lblCustGridSub);
            panelRight.Controls.Add(lblGridTitle);
            panelRight.Controls.Add(dgvCustomers);
            panelRight.Location = new Point(420, 125);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(756, 515);
            panelRight.TabIndex = 2;
            panelRight.Paint += panelRight_Paint;
            // 
            // lblGridTitle
            // 
            lblGridTitle.AutoSize = true;
            lblGridTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblGridTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblGridTitle.Location = new Point(20, 14);
            lblGridTitle.Name = "lblGridTitle";
            lblGridTitle.Size = new Size(224, 21);
            lblGridTitle.TabIndex = 0;
            lblGridTitle.Text = "Customer Records Database";
            // 
            // lblCustGridSub
            // 
            lblCustGridSub.AutoSize = true;
            lblCustGridSub.Font = new Font("Segoe UI", 8.5F);
            lblCustGridSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblCustGridSub.Location = new Point(21, 38);
            lblCustGridSub.Name = "lblCustGridSub";
            lblCustGridSub.Size = new Size(328, 15);
            lblCustGridSub.TabIndex = 1;
            lblCustGridSub.Text = "Directory of registered accounts, active containers, and dues";
            // 
            // btnRefreshCust
            // 
            btnRefreshCust.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefreshCust.BackColor = Color.FromArgb(0, 114, 255);
            btnRefreshCust.Cursor = Cursors.Hand;
            btnRefreshCust.FlatAppearance.BorderSize = 0;
            btnRefreshCust.FlatStyle = FlatStyle.Flat;
            btnRefreshCust.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefreshCust.ForeColor = Color.White;
            btnRefreshCust.Location = new Point(616, 14);
            btnRefreshCust.Name = "btnRefreshCust";
            btnRefreshCust.Size = new Size(120, 34);
            btnRefreshCust.TabIndex = 2;
            btnRefreshCust.Text = "Refresh List";
            btnRefreshCust.UseVisualStyleBackColor = false;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.BorderStyle = BorderStyle.None;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(20, 68);
            dgvCustomers.MultiSelect = false;
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.Size = new Size(716, 427);
            dgvCustomers.TabIndex = 3;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
            // 
            // panelInventory
            // 
            panelInventory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelInventory.BackColor = Color.FromArgb(241, 245, 249);
            panelInventory.Controls.Add(panelInvGridCard);
            panelInventory.Controls.Add(panelReturnCard);
            panelInventory.Controls.Add(pnlOverdue);
            panelInventory.Controls.Add(pnlJugsOut);
            panelInventory.Controls.Add(pnlTotalStock);
            panelInventory.Location = new Point(0, 110);
            panelInventory.Name = "panelInventory";
            panelInventory.Size = new Size(1200, 550);
            panelInventory.TabIndex = 7;
            panelInventory.Visible = false;
            panelInventory.Paint += panelInventory_Paint;
            // 
            // pnlTotalStock
            // 
            pnlTotalStock.BackColor = Color.White;
            pnlTotalStock.Controls.Add(lblSubTotalStock);
            pnlTotalStock.Controls.Add(lblTotalStock);
            pnlTotalStock.Controls.Add(label8);
            pnlTotalStock.Location = new Point(24, 15);
            pnlTotalStock.Name = "pnlTotalStock";
            pnlTotalStock.Size = new Size(360, 110);
            pnlTotalStock.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(100, 116, 139);
            label8.Location = new Point(22, 18);
            label8.Name = "label8";
            label8.Size = new Size(137, 15);
            label8.TabIndex = 0;
            label8.Text = "TOTAL STOCK ON-HAND";
            // 
            // lblTotalStock
            // 
            lblTotalStock.AutoSize = true;
            lblTotalStock.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotalStock.ForeColor = Color.FromArgb(15, 23, 42);
            lblTotalStock.Location = new Point(20, 36);
            lblTotalStock.Name = "lblTotalStock";
            lblTotalStock.Size = new Size(72, 45);
            lblTotalStock.TabIndex = 1;
            lblTotalStock.Text = "150";
            lblTotalStock.Click += lblTotalStock_Click;
            // 
            // lblSubTotalStock
            // 
            lblSubTotalStock.AutoSize = true;
            lblSubTotalStock.Font = new Font("Segoe UI", 8.5F);
            lblSubTotalStock.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubTotalStock.Location = new Point(23, 82);
            lblSubTotalStock.Name = "lblSubTotalStock";
            lblSubTotalStock.Size = new Size(189, 15);
            lblSubTotalStock.TabIndex = 2;
            lblSubTotalStock.Text = "Clean containers available in store";
            // 
            // pnlJugsOut
            // 
            pnlJugsOut.BackColor = Color.White;
            pnlJugsOut.Controls.Add(lblSubJugsOut);
            pnlJugsOut.Controls.Add(lblJugsOut);
            pnlJugsOut.Controls.Add(label9);
            pnlJugsOut.Location = new Point(410, 15);
            pnlJugsOut.Name = "pnlJugsOut";
            pnlJugsOut.Size = new Size(360, 110);
            pnlJugsOut.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(100, 116, 139);
            label9.Location = new Point(22, 18);
            label9.Name = "label9";
            label9.Size = new Size(187, 15);
            label9.TabIndex = 0;
            label9.Text = "CONTAINERS OUT (BORROWED)";
            // 
            // lblJugsOut
            // 
            lblJugsOut.AutoSize = true;
            lblJugsOut.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblJugsOut.ForeColor = Color.FromArgb(217, 119, 6);
            lblJugsOut.Location = new Point(20, 36);
            lblJugsOut.Name = "lblJugsOut";
            lblJugsOut.Size = new Size(38, 45);
            lblJugsOut.TabIndex = 1;
            lblJugsOut.Text = "0";
            lblJugsOut.Click += lblJugsOut_Click;
            // 
            // lblSubJugsOut
            // 
            lblSubJugsOut.AutoSize = true;
            lblSubJugsOut.Font = new Font("Segoe UI", 8.5F);
            lblSubJugsOut.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubJugsOut.Location = new Point(23, 82);
            lblSubJugsOut.Name = "lblSubJugsOut";
            lblSubJugsOut.Size = new Size(182, 15);
            lblSubJugsOut.TabIndex = 2;
            lblSubJugsOut.Text = "Jugs with customers in circulation";
            // 
            // pnlOverdue
            // 
            pnlOverdue.BackColor = Color.White;
            pnlOverdue.Controls.Add(lblSubOverdue);
            pnlOverdue.Controls.Add(lblOverdue);
            pnlOverdue.Controls.Add(label10);
            pnlOverdue.Location = new Point(796, 15);
            pnlOverdue.Name = "pnlOverdue";
            pnlOverdue.Size = new Size(360, 110);
            pnlOverdue.TabIndex = 2;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(100, 116, 139);
            label10.Location = new Point(22, 18);
            label10.Name = "label10";
            label10.Size = new Size(114, 15);
            label10.TabIndex = 0;
            label10.Text = "OVERDUE RETURNS";
            label10.Click += label10_Click;
            // 
            // lblOverdue
            // 
            lblOverdue.AutoSize = true;
            lblOverdue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblOverdue.ForeColor = Color.FromArgb(225, 29, 72);
            lblOverdue.Location = new Point(20, 36);
            lblOverdue.Name = "lblOverdue";
            lblOverdue.Size = new Size(38, 45);
            lblOverdue.TabIndex = 1;
            lblOverdue.Text = "0";
            // 
            // lblSubOverdue
            // 
            lblSubOverdue.AutoSize = true;
            lblSubOverdue.Font = new Font("Segoe UI", 8.5F);
            lblSubOverdue.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubOverdue.Location = new Point(23, 82);
            lblSubOverdue.Name = "lblSubOverdue";
            lblSubOverdue.Size = new Size(196, 15);
            lblSubOverdue.TabIndex = 2;
            lblSubOverdue.Text = "Containers not returned on schedule";
            // 
            // panelReturnCard
            // 
            panelReturnCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelReturnCard.BackColor = Color.White;
            panelReturnCard.Controls.Add(grpReturn);
            panelReturnCard.Controls.Add(lblReturnSub);
            panelReturnCard.Controls.Add(lblReturnHeader);
            panelReturnCard.Location = new Point(24, 140);
            panelReturnCard.Name = "panelReturnCard";
            panelReturnCard.Size = new Size(380, 390);
            panelReturnCard.TabIndex = 3;
            // 
            // lblReturnHeader
            // 
            lblReturnHeader.AutoSize = true;
            lblReturnHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblReturnHeader.ForeColor = Color.FromArgb(15, 23, 42);
            lblReturnHeader.Location = new Point(20, 14);
            lblReturnHeader.Name = "lblReturnHeader";
            lblReturnHeader.Size = new Size(183, 21);
            lblReturnHeader.TabIndex = 0;
            lblReturnHeader.Text = "Log Container Returns";
            // 
            // lblReturnSub
            // 
            lblReturnSub.AutoSize = true;
            lblReturnSub.Font = new Font("Segoe UI", 8.5F);
            lblReturnSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblReturnSub.Location = new Point(21, 38);
            lblReturnSub.Name = "lblReturnSub";
            lblReturnSub.Size = new Size(278, 15);
            lblReturnSub.TabIndex = 1;
            lblReturnSub.Text = "Restock customer-returned jugs into station inventory";
            // 
            // grpReturn
            // 
            grpReturn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpReturn.Controls.Add(btnProcessReturn);
            grpReturn.Controls.Add(numReturnQty);
            grpReturn.Controls.Add(label12);
            grpReturn.Controls.Add(pnlReturnCustInfo);
            grpReturn.Controls.Add(cmbReturnCustomer);
            grpReturn.Controls.Add(label11);
            grpReturn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpReturn.ForeColor = Color.FromArgb(15, 23, 42);
            grpReturn.Location = new Point(20, 68);
            grpReturn.Name = "grpReturn";
            grpReturn.Size = new Size(340, 302);
            grpReturn.TabIndex = 2;
            grpReturn.TabStop = false;
            grpReturn.Text = "Return Details";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(71, 85, 105);
            label11.Location = new Point(16, 24);
            label11.Name = "label11";
            label11.Size = new Size(96, 15);
            label11.TabIndex = 0;
            label11.Text = "Search Customer:";
            // 
            // cmbReturnCustomer
            // 
            cmbReturnCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbReturnCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbReturnCustomer.DropDownStyle = ComboBoxStyle.DropDown;
            cmbReturnCustomer.Font = new Font("Segoe UI", 9.5F);
            cmbReturnCustomer.FormattingEnabled = true;
            cmbReturnCustomer.Location = new Point(16, 44);
            cmbReturnCustomer.Name = "cmbReturnCustomer";
            cmbReturnCustomer.Size = new Size(308, 25);
            cmbReturnCustomer.TabIndex = 1;
            // 
            // pnlReturnCustInfo
            // 
            pnlReturnCustInfo.BackColor = Color.FromArgb(248, 250, 252);
            pnlReturnCustInfo.Controls.Add(lblReturnCustJugs);
            pnlReturnCustInfo.Location = new Point(16, 74);
            pnlReturnCustInfo.Name = "pnlReturnCustInfo";
            pnlReturnCustInfo.Size = new Size(308, 32);
            pnlReturnCustInfo.TabIndex = 2;
            // 
            // lblReturnCustJugs
            // 
            lblReturnCustJugs.AutoSize = true;
            lblReturnCustJugs.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblReturnCustJugs.ForeColor = Color.FromArgb(217, 119, 6);
            lblReturnCustJugs.Location = new Point(8, 8);
            lblReturnCustJugs.Name = "lblReturnCustJugs";
            lblReturnCustJugs.Size = new Size(130, 15);
            lblReturnCustJugs.TabIndex = 0;
            lblReturnCustJugs.Text = "Borrowed Jugs: 0 jugs";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(71, 85, 105);
            label12.Location = new Point(16, 114);
            label12.Name = "label12";
            label12.Size = new Size(150, 15);
            label12.TabIndex = 3;
            label12.Text = "Number of Jugs Returned:";
            // 
            // numReturnQty
            // 
            numReturnQty.Font = new Font("Segoe UI", 9.5F);
            numReturnQty.Location = new Point(16, 134);
            numReturnQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numReturnQty.Name = "numReturnQty";
            numReturnQty.Size = new Size(308, 24);
            numReturnQty.TabIndex = 4;
            numReturnQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnProcessReturn
            // 
            btnProcessReturn.BackColor = Color.FromArgb(5, 150, 105);
            btnProcessReturn.Cursor = Cursors.Hand;
            btnProcessReturn.FlatAppearance.BorderSize = 0;
            btnProcessReturn.FlatStyle = FlatStyle.Flat;
            btnProcessReturn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnProcessReturn.ForeColor = Color.White;
            btnProcessReturn.Location = new Point(16, 180);
            btnProcessReturn.Name = "btnProcessReturn";
            btnProcessReturn.Size = new Size(308, 44);
            btnProcessReturn.TabIndex = 5;
            btnProcessReturn.Text = "Log Jug Return";
            btnProcessReturn.UseVisualStyleBackColor = false;
            // 
            // panelInvGridCard
            // 
            panelInvGridCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelInvGridCard.BackColor = Color.White;
            panelInvGridCard.Controls.Add(btnRefreshInv);
            panelInvGridCard.Controls.Add(lblInvGridSub);
            panelInvGridCard.Controls.Add(lblInvGridTitle);
            panelInvGridCard.Controls.Add(dgvInventory);
            panelInvGridCard.Location = new Point(420, 140);
            panelInvGridCard.Name = "panelInvGridCard";
            panelInvGridCard.Size = new Size(756, 390);
            panelInvGridCard.TabIndex = 4;
            // 
            // lblInvGridTitle
            // 
            lblInvGridTitle.AutoSize = true;
            lblInvGridTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblInvGridTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblInvGridTitle.Location = new Point(20, 14);
            lblInvGridTitle.Name = "lblInvGridTitle";
            lblInvGridTitle.Size = new Size(224, 21);
            lblInvGridTitle.TabIndex = 0;
            lblInvGridTitle.Text = "Container Tracking Records";
            // 
            // lblInvGridSub
            // 
            lblInvGridSub.AutoSize = true;
            lblInvGridSub.Font = new Font("Segoe UI", 8.5F);
            lblInvGridSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblInvGridSub.Location = new Point(21, 38);
            lblInvGridSub.Name = "lblInvGridSub";
            lblInvGridSub.Size = new Size(313, 15);
            lblInvGridSub.TabIndex = 1;
            lblInvGridSub.Text = "Live log of customer jug custody and return statuses";
            // 
            // btnRefreshInv
            // 
            btnRefreshInv.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefreshInv.BackColor = Color.FromArgb(0, 114, 255);
            btnRefreshInv.Cursor = Cursors.Hand;
            btnRefreshInv.FlatAppearance.BorderSize = 0;
            btnRefreshInv.FlatStyle = FlatStyle.Flat;
            btnRefreshInv.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefreshInv.ForeColor = Color.White;
            btnRefreshInv.Location = new Point(616, 14);
            btnRefreshInv.Name = "btnRefreshInv";
            btnRefreshInv.Size = new Size(120, 34);
            btnRefreshInv.TabIndex = 2;
            btnRefreshInv.Text = "Refresh Stock";
            btnRefreshInv.UseVisualStyleBackColor = false;
            // 
            // dgvInventory
            // 
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.BackgroundColor = Color.White;
            dgvInventory.BorderStyle = BorderStyle.None;
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Location = new Point(20, 68);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.ReadOnly = true;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.Size = new Size(716, 302);
            dgvInventory.TabIndex = 3;
            dgvInventory.CellContentClick += dgvInventory_CellContentClick;
            // 
            // panelDashboard
            // 
            panelDashboard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelDashboard.BackColor = Color.FromArgb(241, 245, 249);
            panelDashboard.Controls.Add(panelRecentCard);
            panelDashboard.Controls.Add(panel3);
            panelDashboard.Controls.Add(panel2);
            panelDashboard.Controls.Add(panel1);
            panelDashboard.Location = new Point(0, 110);
            panelDashboard.Name = "panelDashboard";
            panelDashboard.Size = new Size(1200, 550);
            panelDashboard.TabIndex = 6;
            panelDashboard.Visible = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblSubCustomers);
            panel1.Controls.Add(lblDashTotalCustomers);
            panel1.Controls.Add(label13);
            panel1.Location = new Point(24, 20);
            panel1.Name = "panel1";
            panel1.Size = new Size(360, 110);
            panel1.TabIndex = 0;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label13.ForeColor = Color.FromArgb(100, 116, 139);
            label13.Location = new Point(22, 18);
            label13.Name = "label13";
            label13.Size = new Size(147, 15);
            label13.TabIndex = 0;
            label13.Text = "TOTAL ACTIVE CUSTOMERS";
            label13.Click += label13_Click;
            // 
            // lblDashTotalCustomers
            // 
            lblDashTotalCustomers.AutoSize = true;
            lblDashTotalCustomers.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblDashTotalCustomers.ForeColor = Color.FromArgb(15, 23, 42);
            lblDashTotalCustomers.Location = new Point(20, 36);
            lblDashTotalCustomers.Name = "lblDashTotalCustomers";
            lblDashTotalCustomers.Size = new Size(38, 45);
            lblDashTotalCustomers.TabIndex = 1;
            lblDashTotalCustomers.Text = "0";
            // 
            // lblSubCustomers
            // 
            lblSubCustomers.AutoSize = true;
            lblSubCustomers.Font = new Font("Segoe UI", 8.5F);
            lblSubCustomers.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubCustomers.Location = new Point(23, 82);
            lblSubCustomers.Name = "lblSubCustomers";
            lblSubCustomers.Size = new Size(150, 15);
            lblSubCustomers.TabIndex = 2;
            lblSubCustomers.Text = "Registered customer records";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblSubBorrowed);
            panel2.Controls.Add(lblDashBorrowedJugs);
            panel2.Controls.Add(label14);
            panel2.Location = new Point(410, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(360, 110);
            panel2.TabIndex = 1;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label14.ForeColor = Color.FromArgb(100, 116, 139);
            label14.Location = new Point(22, 18);
            label14.Name = "label14";
            label14.Size = new Size(169, 15);
            label14.TabIndex = 0;
            label14.Text = "CONTAINERS OUT (BORROWED)";
            // 
            // lblDashBorrowedJugs
            // 
            lblDashBorrowedJugs.AutoSize = true;
            lblDashBorrowedJugs.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblDashBorrowedJugs.ForeColor = Color.FromArgb(217, 119, 6);
            lblDashBorrowedJugs.Location = new Point(20, 36);
            lblDashBorrowedJugs.Name = "lblDashBorrowedJugs";
            lblDashBorrowedJugs.Size = new Size(38, 45);
            lblDashBorrowedJugs.TabIndex = 1;
            lblDashBorrowedJugs.Text = "0";
            // 
            // lblSubBorrowed
            // 
            lblSubBorrowed.AutoSize = true;
            lblSubBorrowed.Font = new Font("Segoe UI", 8.5F);
            lblSubBorrowed.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubBorrowed.Location = new Point(23, 82);
            lblSubBorrowed.Name = "lblSubBorrowed";
            lblSubBorrowed.Size = new Size(158, 15);
            lblSubBorrowed.TabIndex = 2;
            lblSubBorrowed.Text = "Jugs currently in circulation";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(lblSubBalance);
            panel3.Controls.Add(lblDashUnpaidBalance);
            panel3.Controls.Add(label15);
            panel3.Location = new Point(796, 20);
            panel3.Name = "panel3";
            panel3.Size = new Size(360, 110);
            panel3.TabIndex = 2;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            label15.ForeColor = Color.FromArgb(100, 116, 139);
            label15.Location = new Point(22, 18);
            label15.Name = "label15";
            label15.Size = new Size(140, 15);
            label15.TabIndex = 0;
            label15.Text = "TOTAL UNPAID BALANCE";
            // 
            // lblDashUnpaidBalance
            // 
            lblDashUnpaidBalance.AutoSize = true;
            lblDashUnpaidBalance.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblDashUnpaidBalance.ForeColor = Color.FromArgb(225, 29, 72);
            lblDashUnpaidBalance.Location = new Point(20, 36);
            lblDashUnpaidBalance.Name = "lblDashUnpaidBalance";
            lblDashUnpaidBalance.Size = new Size(106, 45);
            lblDashUnpaidBalance.TabIndex = 1;
            lblDashUnpaidBalance.Text = "₱0.00";
            lblDashUnpaidBalance.Click += lblDashUnpaidBalance_Click;
            // 
            // lblSubBalance
            // 
            lblSubBalance.AutoSize = true;
            lblSubBalance.Font = new Font("Segoe UI", 8.5F);
            lblSubBalance.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubBalance.Location = new Point(23, 82);
            lblSubBalance.Name = "lblSubBalance";
            lblSubBalance.Size = new Size(178, 15);
            lblSubBalance.TabIndex = 2;
            lblSubBalance.Text = "Outstanding customer accounts";
            // 
            // panelRecentCard
            // 
            panelRecentCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelRecentCard.BackColor = Color.White;
            panelRecentCard.Controls.Add(btnDashRefresh);
            panelRecentCard.Controls.Add(lblDashRecentSub);
            panelRecentCard.Controls.Add(label16);
            panelRecentCard.Controls.Add(dgvDashRecent);
            panelRecentCard.Location = new Point(24, 150);
            panelRecentCard.Name = "panelRecentCard";
            panelRecentCard.Size = new Size(1150, 380);
            panelRecentCard.TabIndex = 3;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label16.ForeColor = Color.FromArgb(15, 23, 42);
            label16.Location = new Point(20, 16);
            label16.Name = "label16";
            label16.Size = new Size(203, 21);
            label16.TabIndex = 0;
            label16.Text = "Recent Customer Activity";
            // 
            // lblDashRecentSub
            // 
            lblDashRecentSub.AutoSize = true;
            lblDashRecentSub.Font = new Font("Segoe UI", 8.5F);
            lblDashRecentSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblDashRecentSub.Location = new Point(21, 40);
            lblDashRecentSub.Name = "lblDashRecentSub";
            lblDashRecentSub.Size = new Size(335, 15);
            lblDashRecentSub.TabIndex = 1;
            lblDashRecentSub.Text = "Summary of customer profiles, container counts, and balances";
            // 
            // btnDashRefresh
            // 
            btnDashRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDashRefresh.BackColor = Color.FromArgb(0, 114, 255);
            btnDashRefresh.Cursor = Cursors.Hand;
            btnDashRefresh.FlatAppearance.BorderSize = 0;
            btnDashRefresh.FlatStyle = FlatStyle.Flat;
            btnDashRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDashRefresh.ForeColor = Color.White;
            btnDashRefresh.Location = new Point(1012, 16);
            btnDashRefresh.Name = "btnDashRefresh";
            btnDashRefresh.Size = new Size(118, 34);
            btnDashRefresh.TabIndex = 2;
            btnDashRefresh.Text = "Refresh Data";
            btnDashRefresh.UseVisualStyleBackColor = false;
            // 
            // dgvDashRecent
            // 
            dgvDashRecent.AllowUserToAddRows = false;
            dgvDashRecent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDashRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDashRecent.BackgroundColor = Color.White;
            dgvDashRecent.BorderStyle = BorderStyle.None;
            dgvDashRecent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDashRecent.Location = new Point(20, 68);
            dgvDashRecent.Name = "dgvDashRecent";
            dgvDashRecent.ReadOnly = true;
            dgvDashRecent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDashRecent.Size = new Size(1110, 292);
            dgvDashRecent.TabIndex = 3;
            // 
            // panelAuditLogs
            // 
            panelAuditLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelAuditLogs.BackColor = Color.FromArgb(241, 245, 249);
            panelAuditLogs.Controls.Add(panelAuditGridCard);
            panelAuditLogs.Location = new Point(0, 110);
            panelAuditLogs.Name = "panelAuditLogs";
            panelAuditLogs.Size = new Size(1200, 550);
            panelAuditLogs.TabIndex = 8;
            panelAuditLogs.Visible = false;
            // 
            // panelAuditGridCard
            // 
            panelAuditGridCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelAuditGridCard.BackColor = Color.White;
            panelAuditGridCard.Controls.Add(btnRefreshAudit);
            panelAuditGridCard.Controls.Add(lblAuditGridSub);
            panelAuditGridCard.Controls.Add(lblAuditGridTitle);
            panelAuditGridCard.Controls.Add(dgvAuditLogs);
            panelAuditGridCard.Location = new Point(24, 20);
            panelAuditGridCard.Name = "panelAuditGridCard";
            panelAuditGridCard.Size = new Size(1150, 510);
            panelAuditGridCard.TabIndex = 0;
            // 
            // lblAuditGridTitle
            // 
            lblAuditGridTitle.AutoSize = true;
            lblAuditGridTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAuditGridTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblAuditGridTitle.Location = new Point(20, 16);
            lblAuditGridTitle.Name = "lblAuditGridTitle";
            lblAuditGridTitle.Size = new Size(245, 21);
            lblAuditGridTitle.TabIndex = 0;
            lblAuditGridTitle.Text = "System Audit & Activity Trail";
            // 
            // lblAuditGridSub
            // 
            lblAuditGridSub.AutoSize = true;
            lblAuditGridSub.Font = new Font("Segoe UI", 8.5F);
            lblAuditGridSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblAuditGridSub.Location = new Point(21, 40);
            lblAuditGridSub.Name = "lblAuditGridSub";
            lblAuditGridSub.Size = new Size(420, 15);
            lblAuditGridSub.TabIndex = 1;
            lblAuditGridSub.Text = "Real-time records of user logins, customer updates, transactions, and deletions";
            // 
            // btnRefreshAudit
            // 
            btnRefreshAudit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefreshAudit.BackColor = Color.FromArgb(0, 114, 255);
            btnRefreshAudit.Cursor = Cursors.Hand;
            btnRefreshAudit.FlatAppearance.BorderSize = 0;
            btnRefreshAudit.FlatStyle = FlatStyle.Flat;
            btnRefreshAudit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefreshAudit.ForeColor = Color.White;
            btnRefreshAudit.Location = new Point(1012, 16);
            btnRefreshAudit.Name = "btnRefreshAudit";
            btnRefreshAudit.Size = new Size(118, 34);
            btnRefreshAudit.TabIndex = 2;
            btnRefreshAudit.Text = "Refresh Logs";
            btnRefreshAudit.UseVisualStyleBackColor = false;
            // 
            // dgvAuditLogs
            // 
            dgvAuditLogs.AllowUserToAddRows = false;
            dgvAuditLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAuditLogs.BackgroundColor = Color.White;
            dgvAuditLogs.BorderStyle = BorderStyle.None;
            dgvAuditLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditLogs.Location = new Point(20, 68);
            dgvAuditLogs.Name = "dgvAuditLogs";
            dgvAuditLogs.ReadOnly = true;
            dgvAuditLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditLogs.Size = new Size(1110, 422);
            dgvAuditLogs.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1200, 660);
            Controls.Add(panelAuditLogs);
            Controls.Add(panelDashboard);
            Controls.Add(panelHeader);
            Controls.Add(panelInventory);
            Controls.Add(panelTransactions);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            MinimumSize = new Size(1000, 650);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Water Refilling Station Management System";
            Load += Form1_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            pnlTransCustInfo.ResumeLayout(false);
            pnlTransCustInfo.PerformLayout();
            pnlTransSummary.ResumeLayout(false);
            pnlTransSummary.PerformLayout();
            pnlTransNewOrder.ResumeLayout(false);
            pnlTransNewOrder.PerformLayout();
            pnlTransUpdateCust.ResumeLayout(false);
            pnlTransUpdateCust.PerformLayout();
            pnlUpdateSummary.ResumeLayout(false);
            pnlUpdateSummary.PerformLayout();
            panelTransForm.ResumeLayout(false);
            panelTransForm.PerformLayout();
            panelTransGrid.ResumeLayout(false);
            panelTransGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTransQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTransCashPaid).EndInit();
            ((System.ComponentModel.ISupportInitialize)numUpdatePay).EndInit();
            ((System.ComponentModel.ISupportInitialize)numUpdateReturned).EndInit();
            panelTransactions.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            pnlTotalStock.ResumeLayout(false);
            pnlTotalStock.PerformLayout();
            pnlJugsOut.ResumeLayout(false);
            pnlJugsOut.PerformLayout();
            pnlOverdue.ResumeLayout(false);
            pnlOverdue.PerformLayout();
            pnlReturnCustInfo.ResumeLayout(false);
            pnlReturnCustInfo.PerformLayout();
            grpReturn.ResumeLayout(false);
            grpReturn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numReturnQty).EndInit();
            panelReturnCard.ResumeLayout(false);
            panelReturnCard.PerformLayout();
            panelInvGridCard.ResumeLayout(false);
            panelInvGridCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            panelInventory.ResumeLayout(false);
            panelRecentCard.ResumeLayout(false);
            panelRecentCard.PerformLayout();
            panelDashboard.ResumeLayout(false);
            panelDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashRecent).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelAuditGridCard.ResumeLayout(false);
            panelAuditGridCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditLogs).EndInit();
            panelAuditLogs.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Button btnLogout;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private Label lblLoggedInUser;
        private Panel panelTransactions;
        private Panel panelTransForm;
        private Label lblTransSection;
        private Label lblTransSub;
        private Label label3;
        private ComboBox cmbTransCustomer;
        private Panel pnlTransCustInfo;
        private Label lblTransCustBal;
        private Label lblTransCustJugs;
        private Label lblTransCustChange;
        private Button btnReleaseChange;
        private Button btnModeNewOrder;
        private Button btnModeUpdateCust;
        private Panel pnlTransNewOrder;
        private Panel pnlTransUpdateCust;
        private Label lblUpdatePay;
        private NumericUpDown numUpdatePay;
        private Label lblUpdateReturned;
        private NumericUpDown numUpdateReturned;
        private Panel pnlUpdateSummary;
        private Label lblUpdateSummaryTitle;
        private Label lblUpdateBalPreview;
        private Label lblUpdateChangePreview;
        private Label lblUpdateJugsPreview;
        private Button btnSaveTransCust;
        private Label label5;
        private NumericUpDown numTransQty;
        private Label lblBorrowedJugs;
        private ComboBox cmbBorrowedJugs;
        private Label label6;
        private ComboBox txtUnitPrice;
        private Label label7;
        private ComboBox cmbPaymentStatus;
        private Panel pnlTransSummary;
        private Label lblTransTotalLabel;
        private Label lblTransTotalAmount;
        private Label lblTransCash;
        private NumericUpDown numTransCashPaid;
        private Label lblTransChangeLabel;
        private Label lblTransChangeAmount;
        private Button btnProcessTransaction;
        private Panel panelTransGrid;
        private Label lblTransGridTitle;
        private Label lblTransGridSub;
        private Button btnRefreshTrans;
        private DataGridView dgvTransactions;
        private Panel panelLeft;
        private Label lblCustomerSection;
        private Label lblCustSub;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private Panel panelRight;
        private Label lblGridTitle;
        private Label lblCustGridSub;
        private Button btnRefreshCust;
        private DataGridView dgvCustomers;
        private Panel panelInventory;
        private Panel pnlTotalStock;
        private Label label8;
        private Label lblTotalStock;
        private Label lblSubTotalStock;
        private Panel pnlJugsOut;
        private Label label9;
        private Label lblJugsOut;
        private Label lblSubJugsOut;
        private Panel pnlOverdue;
        private Label label10;
        private Label lblOverdue;
        private Label lblSubOverdue;
        private Panel panelReturnCard;
        private Label lblReturnHeader;
        private Label lblReturnSub;
        private GroupBox grpReturn;
        private Panel pnlReturnCustInfo;
        private Label lblReturnCustJugs;
        private Label label11;
        private ComboBox cmbReturnCustomer;
        private Label label12;
        private NumericUpDown numReturnQty;
        private Button btnProcessReturn;
        private Panel panelInvGridCard;
        private Label lblInvGridTitle;
        private Label lblInvGridSub;
        private Button btnRefreshInv;
        private DataGridView dgvInventory;
        private Panel panelDashboard;
        private Panel panel1;
        private Label label13;
        private Label lblDashTotalCustomers;
        private Label lblSubCustomers;
        private Panel panel2;
        private Label label14;
        private Label lblDashBorrowedJugs;
        private Label lblSubBorrowed;
        private Panel panel3;
        private Label label15;
        private Label lblDashUnpaidBalance;
        private Label lblSubBalance;
        private Panel panelRecentCard;
        private Label label16;
        private Label lblDashRecentSub;
        private Button btnDashRefresh;
        private DataGridView dgvDashRecent;
        private ToolStripButton toolStripButton6;
        private Panel panelAuditLogs;
        private Panel panelAuditGridCard;
        private Label lblAuditGridTitle;
        private Label lblAuditGridSub;
        private Button btnRefreshAudit;
        private DataGridView dgvAuditLogs;
    }
}
