namespace WaterStationTPS
{
    partial class AuditLogForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            btnRefresh = new Button();
            lblTitle = new Label();
            lblSubtitle = new Label();
            panelGridCard = new Panel();
            lblGridTitle = new Label();
            dgvAudit = new DataGridView();
            panelHeader.SuspendLayout();
            panelGridCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAudit).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(15, 23, 42);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(btnRefresh);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(960, 75);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(24, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(263, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "System Audit Logging Trail";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(148, 163, 184);
            lblSubtitle.Location = new Point(25, 44);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(395, 17);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Real-time records of user logins, creates, updates, and deletes";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(2, 132, 199);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(816, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 36);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh Data";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // panelGridCard
            // 
            panelGridCard.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelGridCard.BackColor = Color.White;
            panelGridCard.Controls.Add(lblGridTitle);
            panelGridCard.Controls.Add(dgvAudit);
            panelGridCard.Location = new Point(24, 95);
            panelGridCard.Name = "panelGridCard";
            panelGridCard.Size = new Size(912, 485);
            panelGridCard.TabIndex = 1;
            // 
            // lblGridTitle
            // 
            lblGridTitle.AutoSize = true;
            lblGridTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblGridTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblGridTitle.Location = new Point(20, 16);
            lblGridTitle.Name = "lblGridTitle";
            lblGridTitle.Size = new Size(251, 20);
            lblGridTitle.TabIndex = 0;
            lblGridTitle.Text = "System Activity Log Records Trail";
            // 
            // dgvAudit
            // 
            dgvAudit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAudit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAudit.BackgroundColor = Color.White;
            dgvAudit.BorderStyle = BorderStyle.None;
            dgvAudit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAudit.Location = new Point(20, 48);
            dgvAudit.MultiSelect = false;
            dgvAudit.Name = "dgvAudit";
            dgvAudit.ReadOnly = true;
            dgvAudit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAudit.Size = new Size(872, 417);
            dgvAudit.TabIndex = 1;
            // 
            // AuditLogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(960, 600);
            Controls.Add(panelGridCard);
            Controls.Add(panelHeader);
            DoubleBuffered = true;
            MinimumSize = new Size(800, 500);
            Name = "AuditLogForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "System Audit Logging Trail";
            Load += AuditLogForm_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelGridCard.ResumeLayout(false);
            panelGridCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAudit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private Label lblSubtitle;
        private Button btnRefresh;
        private Panel panelGridCard;
        private Label lblGridTitle;
        private DataGridView dgvAudit;
    }
}
