namespace Biyahe.UI
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtLastName = new TextBox();
            txtPassword = new TextBox();
            btnSignUp = new Button();
            lblSignUp = new Label();
            txtMiddleName = new TextBox();
            txtFirstName = new TextBox();
            txtUsername = new TextBox();
            txtEmailAdd = new TextBox();
            firstName = new Label();
            MiddleName = new Label();
            LastName = new Label();
            Username = new Label();
            Password = new Label();
            email = new Label();
            cBoxSeniorOrPwd = new CheckBox();
            userRadioButton = new RadioButton();
            driverRadioButton = new RadioButton();
            txtStuff = new Label();
            txtPlateNumber = new TextBox();
            PlateNumber = new Label();
            AlreadyHaveAnAccount = new Label();
            linkLogin = new LinkLabel();
            SuspendLayout();
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(59, 258);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(223, 31);
            txtLastName.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(312, 188);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(223, 31);
            txtPassword.TabIndex = 1;
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(565, 255);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(112, 34);
            btnSignUp.TabIndex = 2;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // lblSignUp
            // 
            lblSignUp.AutoSize = true;
            lblSignUp.Location = new Point(12, 9);
            lblSignUp.Name = "lblSignUp";
            lblSignUp.Size = new Size(75, 25);
            lblSignUp.TabIndex = 3;
            lblSignUp.Text = "Sign Up";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(59, 188);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(223, 31);
            txtMiddleName.TabIndex = 4;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(59, 116);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(223, 31);
            txtFirstName.TabIndex = 5;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(312, 116);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(223, 31);
            txtUsername.TabIndex = 6;
            // 
            // txtEmailAdd
            // 
            txtEmailAdd.Location = new Point(312, 258);
            txtEmailAdd.Name = "txtEmailAdd";
            txtEmailAdd.Size = new Size(223, 31);
            txtEmailAdd.TabIndex = 7;
            // 
            // firstName
            // 
            firstName.AutoSize = true;
            firstName.BackColor = Color.Transparent;
            firstName.Location = new Point(59, 88);
            firstName.Name = "firstName";
            firstName.Size = new Size(102, 25);
            firstName.TabIndex = 9;
            firstName.Text = "First Name ";
            // 
            // MiddleName
            // 
            MiddleName.AutoSize = true;
            MiddleName.BackColor = Color.Transparent;
            MiddleName.Location = new Point(59, 160);
            MiddleName.Name = "MiddleName";
            MiddleName.Size = new Size(119, 25);
            MiddleName.TabIndex = 10;
            MiddleName.Text = "Middle Name";
            // 
            // LastName
            // 
            LastName.AutoSize = true;
            LastName.BackColor = Color.Transparent;
            LastName.Location = new Point(59, 230);
            LastName.Name = "LastName";
            LastName.Size = new Size(100, 25);
            LastName.TabIndex = 11;
            LastName.Text = "Last Name ";
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.BackColor = Color.Transparent;
            Username.Location = new Point(312, 88);
            Username.Name = "Username";
            Username.Size = new Size(91, 25);
            Username.TabIndex = 12;
            Username.Text = "Username";
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.BackColor = Color.Transparent;
            Password.Location = new Point(312, 160);
            Password.Name = "Password";
            Password.Size = new Size(87, 25);
            Password.TabIndex = 13;
            Password.Text = "Password";
            // 
            // email
            // 
            email.AutoSize = true;
            email.BackColor = Color.Transparent;
            email.Location = new Point(312, 230);
            email.Name = "email";
            email.Size = new Size(124, 25);
            email.TabIndex = 14;
            email.Text = "Email Address";
            // 
            // cBoxSeniorOrPwd
            // 
            cBoxSeniorOrPwd.AutoSize = true;
            cBoxSeniorOrPwd.Location = new Point(565, 188);
            cBoxSeniorOrPwd.Name = "cBoxSeniorOrPwd";
            cBoxSeniorOrPwd.Size = new Size(163, 29);
            cBoxSeniorOrPwd.TabIndex = 15;
            cBoxSeniorOrPwd.Text = "Senior or PWD?";
            cBoxSeniorOrPwd.UseVisualStyleBackColor = true;
            // 
            // userRadioButton
            // 
            userRadioButton.BackColor = Color.FromArgb(230, 230, 230);
            userRadioButton.FlatAppearance.BorderSize = 0;
            userRadioButton.FlatStyle = FlatStyle.Flat;
            userRadioButton.Font = new Font("Segoe UI", 10F);
            userRadioButton.ForeColor = Color.FromArgb(100, 100, 100);
            userRadioButton.IsSelected = false;
            userRadioButton.Location = new Point(59, 315);
            userRadioButton.Name = "userRadioButton";
            userRadioButton.SelectedColor = Color.FromArgb(52, 152, 219);
            userRadioButton.Size = new Size(137, 38);
            userRadioButton.TabIndex = 16;
            userRadioButton.Text = "User";
            userRadioButton.UnselectedColor = Color.FromArgb(230, 230, 230);
            userRadioButton.UseVisualStyleBackColor = false;
            // 
            // driverRadioButton
            // 
            driverRadioButton.BackColor = Color.FromArgb(230, 230, 230);
            driverRadioButton.FlatAppearance.BorderSize = 0;
            driverRadioButton.FlatStyle = FlatStyle.Flat;
            driverRadioButton.Font = new Font("Segoe UI", 10F);
            driverRadioButton.ForeColor = Color.FromArgb(100, 100, 100);
            driverRadioButton.IsSelected = false;
            driverRadioButton.Location = new Point(202, 315);
            driverRadioButton.Name = "driverRadioButton";
            driverRadioButton.SelectedColor = Color.FromArgb(52, 152, 219);
            driverRadioButton.Size = new Size(137, 38);
            driverRadioButton.TabIndex = 17;
            driverRadioButton.Text = "Driver";
            driverRadioButton.UnselectedColor = Color.FromArgb(230, 230, 230);
            driverRadioButton.UseVisualStyleBackColor = false;
            // 
            // txtStuff
            // 
            txtStuff.AutoSize = true;
            txtStuff.Location = new Point(587, 245);
            txtStuff.Name = "txtStuff";
            txtStuff.Size = new Size(0, 25);
            txtStuff.TabIndex = 18;
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.Location = new Point(565, 116);
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Size = new Size(223, 31);
            txtPlateNumber.TabIndex = 19;
            // 
            // PlateNumber
            // 
            PlateNumber.AutoSize = true;
            PlateNumber.BackColor = Color.Transparent;
            PlateNumber.Location = new Point(565, 88);
            PlateNumber.Name = "PlateNumber";
            PlateNumber.Size = new Size(120, 25);
            PlateNumber.TabIndex = 20;
            PlateNumber.Text = "Plate Number";
            // 
            // AlreadyHaveAnAccount
            // 
            AlreadyHaveAnAccount.AutoSize = true;
            AlreadyHaveAnAccount.Location = new Point(59, 369);
            AlreadyHaveAnAccount.Name = "AlreadyHaveAnAccount";
            AlreadyHaveAnAccount.Size = new Size(213, 25);
            AlreadyHaveAnAccount.TabIndex = 21;
            AlreadyHaveAnAccount.Text = "Already have an account?";
            // 
            // linkLogin
            // 
            linkLogin.AutoSize = true;
            linkLogin.Location = new Point(266, 369);
            linkLogin.Name = "linkLogin";
            linkLogin.Size = new Size(61, 25);
            linkLogin.TabIndex = 22;
            linkLogin.TabStop = true;
            linkLogin.Text = "Log in";
            linkLogin.LinkClicked += linkLogin_LinkClicked;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 450);
            Controls.Add(linkLogin);
            Controls.Add(AlreadyHaveAnAccount);
            Controls.Add(PlateNumber);
            Controls.Add(txtPlateNumber);
            Controls.Add(txtStuff);
            Controls.Add(driverRadioButton);
            Controls.Add(userRadioButton);
            Controls.Add(cBoxSeniorOrPwd);
            Controls.Add(email);
            Controls.Add(Password);
            Controls.Add(Username);
            Controls.Add(LastName);
            Controls.Add(MiddleName);
            Controls.Add(firstName);
            Controls.Add(txtEmailAdd);
            Controls.Add(txtUsername);
            Controls.Add(txtFirstName);
            Controls.Add(txtMiddleName);
            Controls.Add(lblSignUp);
            Controls.Add(btnSignUp);
            Controls.Add(txtPassword);
            Controls.Add(txtLastName);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLastName;
        private TextBox txtPassword;
        private Button btnSignUp;
        private Label lblSignUp;
        private TextBox txtMiddleName;
        private TextBox txtFirstName;
        private TextBox txtUsername;
        private TextBox txtEmailAdd;
        private Label firstName;
        private Label MiddleName;
        private Label LastName;
        private Label Username;
        private Label Password;
        private Label email;
        private CheckBox cBoxSeniorOrPwd;
        private RadioButton userRadioButton;
        private RadioButton driverRadioButton;
        private Label txtStuff;
        private TextBox txtPlateNumber;
        private Label PlateNumber;
        private Label AlreadyHaveAnAccount;
        private LinkLabel linkLogin;
    }
}