using Biyahe.Models;

namespace Biyahe.UI
{
    public partial class DriverForm : Form
    {
        private Driver _currDriver;
        public DriverForm(Driver driver)
        {
            InitializeComponent();
            _currDriver = driver;
        }

        private void DriverForm_Load(object sender, EventArgs e)
        {
            if (_currDriver != null)
            {
                lblWelcome.Text = $"Welcome, {_currDriver.FirstName}!";
            }
            else
            {
                lblWelcome.Text = "No User...";
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }
    }
}
