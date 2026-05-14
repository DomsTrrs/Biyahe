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
                    //MainForm.LoadForm(new UserForm(user));
                }
                else if (driver != null)
                {
                    MainForm.LoadForm(new DriverForm(driver));
                }
                else
                {
                    lblTag.Text = "Invalid Username or Password";
                }
            } else
            {
                lblTag.Text = "No input detected.";
            }
        }

        private void eyePicBox_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtPassword.PasswordChar = '\0';
                eyePicBox.Image = Properties.Resources.eye_open; 
            }
            else
            {
                txtPassword.PasswordChar = '•';
                eyePicBox.Image = Properties.Resources.eye_closed; 
            }


            txtPassword.Focus();
        }

        private void signUpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.LoadForm(new RegisterForm());
        }

    }
}