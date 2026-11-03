namespace WaterStationTPS
{
    partial class LoginForm
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
            panelCard = new Panel();
            lblTitle = new Label();
            lblUsername = new Label();
            panelUsername = new Panel();
            txtUsername = new TextBox();
            lblPassword = new Label();
            panelPassword = new Panel();
            txtPassword = new TextBox();
            btnLogin = new Button();
            panelCard.SuspendLayout();
            panelUsername.SuspendLayout();
            panelPassword.SuspendLayout();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.White;
            panelCard.Controls.Add(lblTitle);
            panelCard.Controls.Add(lblUsername);
            panelCard.Controls.Add(panelUsername);
            panelCard.Controls.Add(lblPassword);
            panelCard.Controls.Add(panelPassword);
            panelCard.Controls.Add(btnLogin);
            panelCard.Location = new Point(235, 60);
            panelCard.Name = "panelCard";
            panelCard.Size = new Size(380, 370);
            panelCard.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(35, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(249, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Welcome Admin";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(51, 65, 85);
            lblUsername.Location = new Point(35, 90);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(80, 19);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username:";
            // 
            // panelUsername
            // 
            panelUsername.BackColor = Color.FromArgb(241, 245, 249);
            panelUsername.Controls.Add(txtUsername);
            panelUsername.Location = new Point(35, 115);
            panelUsername.Name = "panelUsername";
            panelUsername.Size = new Size(310, 44);
            panelUsername.TabIndex = 2;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(241, 245, 249);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.ForeColor = Color.FromArgb(15, 23, 42);
            txtUsername.Location = new Point(14, 12);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(282, 20);
            txtUsername.TabIndex = 0;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(51, 65, 85);
            lblPassword.Location = new Point(35, 175);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(77, 19);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password:";
            // 
            // panelPassword
            // 
            panelPassword.BackColor = Color.FromArgb(241, 245, 249);
            panelPassword.Controls.Add(txtPassword);
            panelPassword.Location = new Point(35, 200);
            panelPassword.Name = "panelPassword";
            panelPassword.Size = new Size(310, 44);
            panelPassword.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(241, 245, 249);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtPassword.Location = new Point(14, 12);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(282, 20);
            txtPassword.TabIndex = 0;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(35, 275);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(310, 46);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 114, 255);
            ClientSize = new Size(850, 520);
            Controls.Add(panelCard);
            DoubleBuffered = true;
            MinimumSize = new Size(500, 520);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Log In";
            Load += LoginForm_Load_1;
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            panelUsername.ResumeLayout(false);
            panelUsername.PerformLayout();
            panelPassword.ResumeLayout(false);
            panelPassword.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCard;
        private Label lblTitle;
        private Label lblUsername;
        private Panel panelUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private Panel panelPassword;
        private TextBox txtPassword;
        private Button btnLogin;
    }
}

