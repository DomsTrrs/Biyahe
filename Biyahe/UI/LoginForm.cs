using Biyahe.Models;
using Biyahe.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Biyahe.UI
{
    public partial class LoginForm : Form
    {
        private bool isPasswordVisible = false;

        public LoginForm()
        {
            InitializeComponent();

        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;
            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(255, 89, 120, 255),
                Color.FromArgb(255, 21, 46, 171),
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '•';

            eyePicBox.Image = Properties.Resources.eye_closed;
            eyePicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            eyePicBox.Cursor = Cursors.Hand;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            AuthService service = new AuthService();
            User user = service.userLogin(username, password);
            Driver driver = service.driverLogin(username, password);


            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrEmpty(password))
            {
                //for checking db
                if (user != null)
                {
                    UserForm uForm = new UserForm(user);
                    uForm.Dock = DockStyle.Fill;
                    uForm.TopLevel = false;
                    MainForm.MainPanel.Controls.Clear();
                    MainForm.MainPanel.Controls.Add(uForm);
                    uForm.Show();
                }
                else if (driver != null)
                {
                    DriverForm dForm = new DriverForm(driver);
                    dForm.Dock = DockStyle.Fill;
                    dForm.TopLevel = false;
                    MainForm.MainPanel.Controls.Clear();
                    MainForm.MainPanel.Controls.Add(dForm);
                    dForm.Show();
                }
                else
                {
                    lblLogin.Text = "Invalid Username or Password";
                }
            } else
            {
                lblLogin.Text = "No input detected.";
            }
        }

        private void signUpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.LoadForm(new RegisterForm());
        }

    }
}