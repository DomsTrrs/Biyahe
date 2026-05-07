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

        private void eyePictureBox_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtPassword.PasswordChar = '\0';
                eyePictureBox.Image = Properties.Resources.eye_open; // Replace with your open eye resource name
            }
            else
            {
                txtPassword.PasswordChar = '•';
                eyePictureBox.Image = Properties.Resources.eye_closed; // Replace with your closed eye resource name
            }


            txtPassword.Focus();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { }
        private void roundedButton1_Click(object sender, EventArgs e) { }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '•';

            eyePictureBox.Image = Properties.Resources.eye_closed;
            eyePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            eyePictureBox.Cursor = Cursors.Hand;
        }
    }
}