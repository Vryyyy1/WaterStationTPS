using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WaterStationTPS
{
    public partial class LoginForm : Form
    {
        private string connString = @"Server=(localdb)\MSSQLLocalDB;Database=WaterStationDB;Integrated Security=True;TrustServerCertificate=True;";

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private const int EM_SETCUEBANNER = 0x1501;

        private bool isLoginHovered = false;

        public LoginForm()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            this.Load += LoginForm_Load;
            this.Resize += LoginForm_Resize;

            panelCard.Paint += PanelCard_Paint;
            panelUsername.Paint += (s, e) => DrawRoundedInputPanel(panelUsername, txtUsername, e);
            panelPassword.Paint += (s, e) => DrawRoundedInputPanel(panelPassword, txtPassword, e);

            txtUsername.Enter += (s, e) => panelUsername.Invalidate();
            txtUsername.Leave += (s, e) => panelUsername.Invalidate();
            txtPassword.Enter += (s, e) => panelPassword.Invalidate();
            txtPassword.Leave += (s, e) => panelPassword.Invalidate();

            btnLogin.Paint += BtnLogin_Paint;
            btnLogin.MouseEnter += (s, e) => { isLoginHovered = true; btnLogin.Invalidate(); };
            btnLogin.MouseLeave += (s, e) => { isLoginHovered = false; btnLogin.Invalidate(); };
        }

        private void LoginForm_Load(object? sender, EventArgs e)
        {
            CenterCard();
            SetPlaceholder(txtUsername, "Enter username");
            SetPlaceholder(txtPassword, "Enter password");
        }

        private void LoginForm_Resize(object? sender, EventArgs e)
        {
            CenterCard();
            this.Invalidate();
        }

        private void CenterCard()
        {
            if (panelCard != null)
            {
                panelCard.Location = new Point(
                    Math.Max(0, (this.ClientSize.Width - panelCard.Width) / 2),
                    Math.Max(0, (this.ClientSize.Height - panelCard.Height) / 2)
                );
            }
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox.IsHandleCreated)
            {
                SendMessage(textBox.Handle, EM_SETCUEBANNER, 1, placeholder);
            }
            else
            {
                textBox.HandleCreated += (s, e) => SendMessage(textBox.Handle, EM_SETCUEBANNER, 1, placeholder);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(0, 114, 255),
                Color.FromArgb(0, 210, 255),
                45f))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void PanelCard_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = panelCard.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            int cornerRadius = 24;
            using (GraphicsPath path = GetRoundedRectanglePath(rect, cornerRadius))
            {
                using (SolidBrush bgBrush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillPath(bgBrush, path);
                }
                using (Pen borderPen = new Pen(Color.FromArgb(241, 245, 249), 1f))
                {
                    e.Graphics.DrawPath(borderPen, path);
                }
            }

            using (GraphicsPath clipPath = GetRoundedRectanglePath(panelCard.ClientRectangle, cornerRadius))
            {
                panelCard.Region = new Region(clipPath);
            }
        }

        private void DrawRoundedInputPanel(Panel container, TextBox childBox, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = container.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            int cornerRadius = 20;
            bool isFocused = childBox.Focused;

            Color bgColor = Color.FromArgb(241, 245, 249);
            Color borderColor = isFocused ? Color.FromArgb(0, 114, 255) : Color.FromArgb(226, 232, 240);

            using (GraphicsPath path = GetRoundedRectanglePath(rect, cornerRadius))
            {
                using (SolidBrush bgBrush = new SolidBrush(bgColor))
                {
                    e.Graphics.FillPath(bgBrush, path);
                }

                using (Pen pen = new Pen(borderColor, isFocused ? 2f : 1f))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }

            using (GraphicsPath clipPath = GetRoundedRectanglePath(container.ClientRectangle, cornerRadius))
            {
                container.Region = new Region(clipPath);
            }
        }

        private void BtnLogin_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = btnLogin.ClientRectangle;
            rect.Width -= 1;
            rect.Height -= 1;

            int cornerRadius = 22;
            using (GraphicsPath path = GetRoundedRectanglePath(rect, cornerRadius))
            {
                Color startColor = isLoginHovered ? Color.FromArgb(0, 100, 235) : Color.FromArgb(0, 114, 255);
                Color endColor = isLoginHovered ? Color.FromArgb(0, 190, 245) : Color.FromArgb(0, 210, 255);

                using (LinearGradientBrush brush = new LinearGradientBrush(rect, startColor, endColor, 0f))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }

            using (GraphicsPath clipPath = GetRoundedRectanglePath(btnLogin.ClientRectangle, cornerRadius))
            {
                btnLogin.Region = new Region(clipPath);
            }

            TextRenderer.DrawText(
                e.Graphics,
                btnLogin.Text,
                btnLogin.Font,
                btnLogin.ClientRectangle,
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT UserID, Role FROM Users WHERE Username = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            UserSession.CurrentUsername = txtUsername.Text.Trim();
                            UserSession.CurrentUserId = reader["UserID"] != DBNull.Value ? Convert.ToInt32(reader["UserID"]) : 1;
                            
                            AuditLogger.LogAction("Login", "Users", $"User #{UserSession.CurrentUserId} ({UserSession.CurrentUsername})", "Logged into system", conn);

                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                            Form1 mainForm = new Form1();
                            mainForm.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}

