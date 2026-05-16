using Biyahe.Models;
using Biyahe.Services;

namespace Biyahe.UI
{
    public partial class AboutUsForm : Form
    {
        private User _currUser;
        private Driver _currDriver;
        public AboutUsForm(User user)
        {
            _currUser = user;
            InitializeComponent();
        }

        public AboutUsForm(Driver driver)
        {
            _currDriver = driver;
            InitializeComponent();
        }

        private void linkLabelHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.LoadForm(new UserForm(_currUser));
        }
    }
}
