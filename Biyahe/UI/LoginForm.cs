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

            if (user != null)
            {
                MainForm.MainPanel.SuspendLayout();
                UserForm uForm = new UserForm(user);
                uForm.Dock = DockStyle.Fill;
                uForm.TopLevel = false;
                MainForm.MainPanel.Controls.Clear();
                MainForm.MainPanel.Controls.Add(uForm);
                uForm.Show();
                MainForm.MainPanel.ResumeLayout(true);
            }
            else if (driver != null)
            {
                MainForm.MainPanel.SuspendLayout();
                DriverForm dForm = new DriverForm(driver);
                dForm.Dock = DockStyle.Fill;
                dForm.TopLevel = false;
                MainForm.MainPanel.Controls.Clear();
                MainForm.MainPanel.Controls.Add(dForm);
                dForm.Show();
                MainForm.MainPanel.ResumeLayout(true);
               
            }
            else
            {
                //lblLogin.Text = "Invalid Username or Password";
            }
        }

        private void eyePicBox_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtPassword.PasswordChar = '\0';
                eyePicBox.Image = Properties.Resources.eye_open; // Replace with your open eye resource name
            }
            else
            {
                txtPassword.PasswordChar = '•';
                eyePicBox.Image = Properties.Resources.eye_closed; // Replace with your closed eye resource name
            }


            txtPassword.Focus();
        }

        private void signUpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.MainPanel.SuspendLayout();
            this.Hide();
            RegisterForm rForm = new RegisterForm();
            rForm.Dock = DockStyle.Fill;
            rForm.TopLevel = false;
            MainForm.MainPanel.Controls.Clear();
            MainForm.MainPanel.Controls.Add(rForm);
            rForm.Show();
            MainForm.MainPanel.ResumeLayout(true);
        }

    }
}