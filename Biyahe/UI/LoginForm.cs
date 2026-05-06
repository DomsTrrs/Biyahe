using Biyahe.Models;
using Biyahe.Services;
using System.Windows.Forms;


namespace Biyahe.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        //login button function
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            AuthService service = new AuthService();
            User user = service.userLogin(username, password);
            Driver driver = service.driverLogin(username, password);

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

        }

        //go to register
        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegisterForm rForm = new RegisterForm();
            rForm.Dock = DockStyle.Fill;
            rForm.TopLevel = false;
            MainForm.MainPanel.Controls.Clear();
            MainForm.MainPanel.Controls.Add(rForm);
            rForm.Show();
        }
    }
}
