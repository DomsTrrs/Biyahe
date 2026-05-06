using System;
using System.Windows.Forms;
using Biyahe.Models;

namespace Biyahe.UI
{
    public partial class UserForm : Form
    {
        private User _currUser;
        public UserForm(User user)
        {
            InitializeComponent();
            _currUser = user;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            if (_currUser != null)
            {
                lblWelcome.Text = $"Welcome, {_currUser.FirstName}!";
            }
            else
            {
                lblWelcome.Text = "No user...";
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lForm = new LoginForm();
            lForm.Dock = DockStyle.Fill;
            lForm.TopLevel = false;
            MainForm.MainPanel.Controls.Clear();
            MainForm.MainPanel.Controls.Add(lForm);
            lForm.Show();
        }

       
    }
}
