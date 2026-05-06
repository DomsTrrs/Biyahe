using BCrypt.Net;
using Biyahe.DataAccess;
using Biyahe.Models;


namespace Biyahe.UI
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            userRadioButton.Click += userRadioButton_CheckedChanged;
            driverRadioButton.Click += driverRadioButton_CheckedChanged;
            userRadioButton.IsSelected = true;

            //default user for user creation
            txtPlateNumber.Visible = false;
            PlateNumber.Visible = false;
        }

        private void userRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (userRadioButton.IsSelected)
            {
                // Show Senior/PWD, hide Plate Number
                cBoxSeniorOrPwd.Visible = true;

                txtPlateNumber.Visible = false;
                PlateNumber.Visible = false;
            }
        }
        private void driverRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (driverRadioButton.IsSelected)
            {
                // Show Plate Number, hide Senior/PWD
                txtPlateNumber.Visible = true;
                PlateNumber.Visible = true;

                cBoxSeniorOrPwd.Visible = false;
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            UserRepository userR = new UserRepository();
            DriverRepository driverR = new DriverRepository();

            string firstName = txtFirstName.Text.Trim();
            string middleName = txtMiddleName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password, 12);
            string email = txtEmailAdd.Text.Trim();

           
            //radio button account type selection
            if (!userRadioButton.IsSelected && !driverRadioButton.IsSelected)
            {
                txtStuff.Text = "Please select an account type.";
            }
            else if (userRadioButton.IsSelected)
            {
                bool SeniorPwd = cBoxSeniorOrPwd.Checked;
                User u = new User(firstName, middleName, lastName, username, passwordHash, email, SeniorPwd);
                userR.AddUser(u);
            }
            else if (driverRadioButton.IsSelected)
            {
                string plateNumber = txtPlateNumber.Text.Trim();
                Driver d = new Driver(firstName, middleName, lastName, username, passwordHash, email, plateNumber);
                driverR.addDriver(d);
            }

            //after sign up back to log in 
            this.Hide();
            LoginForm lForm = new LoginForm();
            lForm.Dock = DockStyle.Fill;
            lForm.TopLevel = false;
            MainForm.MainPanel.Controls.Clear();
            MainForm.MainPanel.Controls.Add(lForm);
            lForm.Show();


        } //button click method

        //back to login
        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); 
            LoginForm lForm = new LoginForm();
            lForm.Dock = DockStyle.Fill;
            lForm.TopLevel = false; 
            MainForm.MainPanel.Controls.Clear();
            MainForm.MainPanel.Controls.Add(lForm);
            lForm.Show();
        }
    }//class
}//namespace
