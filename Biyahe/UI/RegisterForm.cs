using Biyahe.DataAccess;
using Biyahe.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Biyahe.UI
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

            userRadioBtn.Click += radioButtonUser_CheckedChanged;
            driverRadioBtn.Click += radioButtonDriver_CheckedChanged;

            userRadioBtn.IsSelected = true;

            //default user for user creation
            txtPlateNumber.Visible = false;
            plateNumberLbl.Visible = false;
        }
        private void radioButtonUser_CheckedChanged(object sender, EventArgs e)
        {
            if (userRadioBtn.IsSelected)
            {
                // Show Senior/PWD, hide Plate Number
                cBoxSeniorOrPwd.Visible = true;

                txtPlateNumber.Visible = false;
                plateNumberLbl.Visible = false;
            }
        }

        private void radioButtonDriver_CheckedChanged(object sender, EventArgs e)
        {
            if (driverRadioBtn.IsSelected)
            {
                // Show Plate Number, hide Senior/PWD
                txtPlateNumber.Visible = true;
                plateNumberLbl.Visible = true;

                cBoxSeniorOrPwd.Visible = false;
            }
        }

        private void RegisterForm_Load_1(object sender, EventArgs e)
        {
            cBoxSeniorOrPwd.Visible = true;
            txtPlateNumber.Visible = false;
            plateNumberLbl.Visible = false;
            userRadioBtn.IsSelected = true;
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
            if (!userRadioBtn.IsSelected && !driverRadioBtn.IsSelected)
            {
                //txtStuff.Text = "Please select an account type.";
            }
            else if (userRadioBtn.IsSelected)
            {
                bool SeniorPwd = cBoxSeniorOrPwd.Checked;
                User u = new User(firstName, middleName, lastName, username, passwordHash, email, SeniorPwd);
                userR.AddUser(u);
            }
            else if (driverRadioBtn.IsSelected)
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

        }

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
    }
}
