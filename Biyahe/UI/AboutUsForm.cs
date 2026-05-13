using Biyahe.Models;
using Biyahe.Services;

namespace Biyahe.UI
{
    public partial class AboutUsForm : Form
    {
        private User _currUser;
        public AboutUsForm()
        {
            InitializeComponent();
        }

        private void linkLabelHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            UserForm uForm = new UserForm(_currUser);
            uForm.Dock = DockStyle.Fill;
            uForm.TopLevel = false;
            MainForm.MainPanel.Controls.Clear();
            MainForm.MainPanel.Controls.Add(uForm);
            uForm.Show();
        }
    }
}
