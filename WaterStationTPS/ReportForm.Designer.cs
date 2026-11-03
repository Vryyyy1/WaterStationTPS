namespace WaterStationTPS
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            btnRefresh = new Button();
            panelCardBalance = new Panel();
            lblBalanceHeader = new Label();
            lblTotalBalance = new Label();
            panelCardJugs = new Panel();
            lblJugsHeader = new Label();
            lblTotalJugs = new Label();
            panelCardChange = new Panel();
            lblChangeHeader = new Label();
            lblTotalChange = new Label();
            panelGridCard = new Panel();
            lblGridTitle = new Label();
            dgvReport = new DataGridView();
            panelHeader.SuspendLayout();
            panelCardBalance.SuspendLayout();
            panelCardJugs.SuspendLayout();
            panelCardChange.SuspendLayout();
            panelGridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(0, 114, 255);
            panelHeader.Controls.Add(btnRefresh);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(880, 72);
            panelHeader.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(2, 132, 199);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(735, 18);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 36);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Refresh Data";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // panelCardBalance
            // 
            panelCardBalance.BackColor = Color.White;
            panelCardBalance.Controls.Add(lblBalanceHeader);
            panelCardBalance.Controls.Add(lblTotalBalance);
            panelCardBalance.Location = new Point(24, 88);
            panelCardBalance.Name = "panelCardBalance";
            panelCardBalance.Size = new Size(266, 90);
            panelCardBalance.TabIndex = 1;
            // 
            // lblBalanceHeader
            // 
            lblBalanceHeader.AutoSize = true;
            lblBalanceHeader.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblBalanceHeader.ForeColor = Color.FromArgb(100, 116, 139);
            lblBalanceHeader.Location = new Point(18, 16);
            lblBalanceHeader.Name = "lblBalanceHeader";
            lblBalanceHeader.Size = new Size(136, 15);
            lblBalanceHeader.TabIndex = 0;
            lblBalanceHeader.Text = "TOTAL UNPAID BALANCE";
            // 
            // lblTotalBalance
            // 
            lblTotalBalance.AutoSize = true;
            lblTotalBalance.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalBalance.ForeColor = Color.FromArgb(220, 38, 38);
            lblTotalBalance.Location = new Point(18, 38);
            lblTotalBalance.Name = "lblTotalBalance";
            lblTotalBalance.Size = new Size(77, 32);
            lblTotalBalance.TabIndex = 1;
            lblTotalBalance.Text = "₱0.00";
            lblTotalBalance.Click += label2_Click;
            // 
            // panelCardJugs
            // 
            panelCardJugs.BackColor = Color.White;
            panelCardJugs.Controls.Add(lblJugsHeader);
            panelCardJugs.Controls.Add(lblTotalJugs);
            panelCardJugs.Location = new Point(306, 88);
            panelCardJugs.Name = "panelCardJugs";
            panelCardJugs.Size = new Size(266, 90);
            panelCardJugs.TabIndex = 2;
            // 
            // lblJugsHeader
            // 
            lblJugsHeader.AutoSize = true;
            lblJugsHeader.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblJugsHeader.ForeColor = Color.FromArgb(100, 116, 139);
            lblJugsHeader.Location = new Point(18, 16);
            lblJugsHeader.Name = "lblJugsHeader";
            lblJugsHeader.Size = new Size(141, 15);
            lblJugsHeader.TabIndex = 0;
            lblJugsHeader.Text = "TOTAL BORROWED JUGS";
            // 
            // lblTotalJugs
            // 
            lblTotalJugs.AutoSize = true;
            lblTotalJugs.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalJugs.ForeColor = Color.FromArgb(15, 23, 42);
            lblTotalJugs.Location = new Point(18, 38);
            lblTotalJugs.Name = "lblTotalJugs";
            lblTotalJugs.Size = new Size(28, 32);
            lblTotalJugs.TabIndex = 1;
            lblTotalJugs.Text = "0";
            lblTotalJugs.Click += lblTotalJugs_Click;
            // 
            // panelCardChange
            // 
            panelCardChange.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelCardChange.BackColor = Color.White;
            panelCardChange.Controls.Add(lblChangeHeader);
            panelCardChange.Controls.Add(lblTotalChange);
            panelCardChange.Location = new Point(588, 88);
            panelCardChange.Name = "panelCardChange";
            panelCardChange.Size = new Size(268, 90);
            panelCardChange.TabIndex = 4;
            // 
            // lblChangeHeader
            // 
            lblChangeHeader.AutoSize = true;
            lblChangeHeader.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point);
            lblChangeHeader.ForeColor = Color.FromArgb(100, 116, 139);
            lblChangeHeader.Location = new Point(18, 16);
            lblChangeHeader.Name = "lblChangeHeader";
            lblChangeHeader.Size = new Size(155, 15);
            lblChangeHeader.TabIndex = 0;
            lblChangeHeader.Text = "TOTAL CHANGE PROCESSED";
            // 
            // lblTotalChange
            // 
            lblTotalChange.AutoSize = true;
            lblTotalChange.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalChange.ForeColor = Color.FromArgb(5, 150, 105);
            lblTotalChange.Location = new Point(18, 38);
            lblTotalChange.Name = "lblTotalChange";
            lblTotalChange.Size = new Size(77, 32);
            lblTotalChange.TabIndex = 1;
            lblTotalChange.Text = "₱0.00";
            // 
            // panelGridCard
            // 
            panelGridCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelGridCard.BackColor = Color.White;
            panelGridCard.Controls.Add(lblGridTitle);
            panelGridCard.Controls.Add(dgvReport);
            panelGridCard.Location = new Point(24, 194);
            panelGridCard.Name = "panelGridCard";
            panelGridCard.Size = new Size(832, 360);
            panelGridCard.TabIndex = 3;
            // 
            // lblGridTitle
            // 
            lblGridTitle.AutoSize = true;
            lblGridTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblGridTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblGridTitle.Location = new Point(20, 16);
            lblGridTitle.Name = "lblGridTitle";
            lblGridTitle.Size = new Size(257, 20);
            lblGridTitle.TabIndex = 0;
            lblGridTitle.Text = "Outstanding Accounts & Jug Loans";
            // 
            // dgvReport
            // 
            dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.BackgroundColor = Color.White;
            dgvReport.BorderStyle = BorderStyle.None;
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new Point(20, 48);
            dgvReport.MultiSelect = false;
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(792, 292);
            dgvReport.TabIndex = 1;
            dgvReport.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(880, 580);
            Controls.Add(panelGridCard);
            Controls.Add(panelCardChange);
            Controls.Add(panelCardJugs);
            Controls.Add(panelCardBalance);
            Controls.Add(panelHeader);
            DoubleBuffered = true;
            MinimumSize = new Size(750, 500);
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Summary & Reporting Module";
            Load += ReportForm_Load;
            panelHeader.ResumeLayout(false);
            panelCardBalance.ResumeLayout(false);
            panelCardBalance.PerformLayout();
            panelCardJugs.ResumeLayout(false);
            panelCardJugs.PerformLayout();
            panelCardChange.ResumeLayout(false);
            panelCardChange.PerformLayout();
            panelGridCard.ResumeLayout(false);
            panelGridCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Button btnRefresh;
        private Panel panelCardBalance;
        private Label lblBalanceHeader;
        private Label lblTotalBalance;
        private Panel panelCardJugs;
        private Label lblJugsHeader;
        private Label lblTotalJugs;
        private Panel panelCardChange;
        private Label lblChangeHeader;
        private Label lblTotalChange;
        private Panel panelGridCard;
        private Label lblGridTitle;
        private DataGridView dgvReport;
    }
}
