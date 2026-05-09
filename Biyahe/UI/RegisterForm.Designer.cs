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
            parentPnl = new RoundedPanel();
            childPnl = new Panel();
            lineInBetweenRadioBtns = new Panel();
            btnSignUp = new RoundedButton();
            userRadioBtn = new RadioButton();
            driverRadioBtn = new RadioButton();
            txtPlateNumber = new RoundedTextBox();
            txtPassword = new RoundedTextBox();
            txtEmailAdd = new RoundedTextBox();
            txtUsername = new RoundedTextBox();
            txtLastName = new RoundedTextBox();
            txtMiddleName = new RoundedTextBox();
            txtFirstName = new RoundedTextBox();
            required5 = new Label();
            required3 = new Label();
            required2 = new Label();
            required1 = new Label();
            required4 = new Label();
            cBoxSeniorOrPwd = new CheckBox();
            plateNumberLbl = new Label();
            passwordLbl = new Label();
            emailLbl = new Label();
            usernameLbl = new Label();
            lastnameLbl = new Label();
            middlenameLbl = new Label();
            linkLogin = new LinkLabel();
            haveAccLbl = new Label();
            firstnameLbl = new Label();
            lblSIgnUp = new Label();
            parentPnl.SuspendLayout();
            childPnl.SuspendLayout();
            SuspendLayout();
            // 
            // parentPnl
            // 
            parentPnl.BackColor = Color.Transparent;
            parentPnl.Controls.Add(childPnl);
            parentPnl.Location = new Point(106, 86);
            parentPnl.Margin = new Padding(3, 2, 3, 2);
            parentPnl.Name = "parentPnl";
            parentPnl.PanelColor = Color.White;
            parentPnl.Size = new Size(1037, 503);
            parentPnl.TabIndex = 1;
            // 
            // childPnl
            // 
            childPnl.Controls.Add(lineInBetweenRadioBtns);
            childPnl.Controls.Add(btnSignUp);
            childPnl.Controls.Add(userRadioBtn);
            childPnl.Controls.Add(driverRadioBtn);
            childPnl.Controls.Add(txtPlateNumber);
            childPnl.Controls.Add(txtPassword);
            childPnl.Controls.Add(txtEmailAdd);
            childPnl.Controls.Add(txtUsername);
            childPnl.Controls.Add(txtLastName);
            childPnl.Controls.Add(txtMiddleName);
            childPnl.Controls.Add(txtFirstName);
            childPnl.Controls.Add(required5);
            childPnl.Controls.Add(required3);
            childPnl.Controls.Add(required2);
            childPnl.Controls.Add(required1);
            childPnl.Controls.Add(required4);
            childPnl.Controls.Add(cBoxSeniorOrPwd);
            childPnl.Controls.Add(plateNumberLbl);
            childPnl.Controls.Add(passwordLbl);
            childPnl.Controls.Add(emailLbl);
            childPnl.Controls.Add(usernameLbl);
            childPnl.Controls.Add(lastnameLbl);
            childPnl.Controls.Add(middlenameLbl);
            childPnl.Controls.Add(linkLogin);
            childPnl.Controls.Add(haveAccLbl);
            childPnl.Controls.Add(firstnameLbl);
            childPnl.Controls.Add(lblSIgnUp);
            childPnl.Dock = DockStyle.Fill;
            childPnl.ForeColor = Color.FromArgb(81, 112, 255);
            childPnl.Location = new Point(0, 0);
            childPnl.Margin = new Padding(3, 2, 3, 2);
            childPnl.Name = "childPnl";
            childPnl.Size = new Size(1037, 503);
            childPnl.TabIndex = 1;
            // 
            // lineInBetweenRadioBtns
            // 
            lineInBetweenRadioBtns.BackColor = Color.FromArgb(48, 63, 138);
            lineInBetweenRadioBtns.Location = new Point(846, 250);
            lineInBetweenRadioBtns.Name = "lineInBetweenRadioBtns";
            lineInBetweenRadioBtns.Size = new Size(5, 51);
            lineInBetweenRadioBtns.TabIndex = 35;
            // 
            // btnSignUp
            // 
            btnSignUp.Anchor = AnchorStyles.None;
            btnSignUp.BackColor = Color.FromArgb(81, 112, 255);
            btnSignUp.CornerRadiusBottomLeft = 30;
            btnSignUp.CornerRadiusBottomRight = 30;
            btnSignUp.CornerRadiusTopLeft = 30;
            btnSignUp.CornerRadiusTopRight = 30;
            btnSignUp.FlatAppearance.BorderSize = 0;
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.Font = new Font("Impact", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSignUp.ForeColor = Color.White;
            btnSignUp.HoverColor = Color.FromArgb(73, 96, 206);
            btnSignUp.Location = new Point(760, 328);
            btnSignUp.Margin = new Padding(3, 2, 3, 2);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.NormalColor = Color.FromArgb(81, 112, 255);
            btnSignUp.Size = new Size(182, 82);
            btnSignUp.TabIndex = 34;
            btnSignUp.Text = "SIGN UP";
            btnSignUp.TextImageRelation = TextImageRelation.TextAboveImage;
            btnSignUp.UseVisualStyleBackColor = false;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // userRadioBtn
            // 
            userRadioBtn.Anchor = AnchorStyles.None;
            userRadioBtn.BackColor = Color.FromArgb(62, 79, 160);
            userRadioBtn.BackgroundImageLayout = ImageLayout.Zoom;
            userRadioBtn.ButtonImage = Properties.Resources.userIcon;
            userRadioBtn.ButtonImageLayout = ImageLayout.Zoom;
            userRadioBtn.CornerRadiusBottomLeft = 30;
            userRadioBtn.CornerRadiusBottomRight = 0;
            userRadioBtn.CornerRadiusTopLeft = 30;
            userRadioBtn.CornerRadiusTopRight = 0;
            userRadioBtn.FlatAppearance.BorderSize = 0;
            userRadioBtn.FlatStyle = FlatStyle.Flat;
            userRadioBtn.Font = new Font("Segoe UI", 10F);
            userRadioBtn.ForeColor = Color.FromArgb(81, 112, 255);
            userRadioBtn.GlowColor = Color.FromArgb(103, 131, 255);
            userRadioBtn.HoverColor = Color.FromArgb(103, 131, 255);
            userRadioBtn.Location = new Point(723, 250);
            userRadioBtn.Margin = new Padding(3, 2, 3, 2);
            userRadioBtn.Name = "userRadioBtn";
            userRadioBtn.SelectedColor = Color.FromArgb(81, 112, 255);
            userRadioBtn.SelectedTextColor = Color.White;
            userRadioBtn.Size = new Size(123, 51);
            userRadioBtn.TabIndex = 0;
            userRadioBtn.UnselectedColor = Color.FromArgb(62, 79, 160);
            userRadioBtn.UnselectedTextColor = Color.FromArgb(81, 112, 255);
            userRadioBtn.UseVisualStyleBackColor = false;
            // 
            // driverRadioBtn
            // 
            driverRadioBtn.Anchor = AnchorStyles.None;
            driverRadioBtn.BackColor = Color.FromArgb(62, 79, 160);
            driverRadioBtn.ButtonImage = Properties.Resources.driverIcon;
            driverRadioBtn.ButtonImageLayout = ImageLayout.Zoom;
            driverRadioBtn.CornerRadiusBottomLeft = 0;
            driverRadioBtn.CornerRadiusBottomRight = 30;
            driverRadioBtn.CornerRadiusTopLeft = 0;
            driverRadioBtn.CornerRadiusTopRight = 30;
            driverRadioBtn.FlatAppearance.BorderSize = 0;
            driverRadioBtn.FlatStyle = FlatStyle.Flat;
            driverRadioBtn.Font = new Font("Segoe UI", 10F);
            driverRadioBtn.ForeColor = Color.FromArgb(62, 79, 160);
            driverRadioBtn.GlowColor = Color.FromArgb(100, 255, 255, 255);
            driverRadioBtn.HoverColor = Color.FromArgb(103, 131, 255);
            driverRadioBtn.Location = new Point(851, 250);
            driverRadioBtn.Margin = new Padding(3, 2, 3, 2);
            driverRadioBtn.Name = "driverRadioBtn";
            driverRadioBtn.SelectedColor = Color.FromArgb(81, 112, 255);
            driverRadioBtn.SelectedTextColor = Color.White;
            driverRadioBtn.Size = new Size(123, 51);
            driverRadioBtn.TabIndex = 1;
            driverRadioBtn.UnselectedColor = Color.FromArgb(62, 79, 160);
            driverRadioBtn.UnselectedTextColor = Color.FromArgb(62, 79, 160);
            driverRadioBtn.UseVisualStyleBackColor = false;
            // 
            // txtPlateNumber
            // 
            txtPlateNumber.Anchor = AnchorStyles.None;
            txtPlateNumber.BackgroundColor = Color.White;
            txtPlateNumber.BorderColor = Color.FromArgb(91, 121, 255);
            txtPlateNumber.BorderThickness = 3;
            txtPlateNumber.CornerRadiusBottomLeft = 30;
            txtPlateNumber.CornerRadiusBottomRight = 30;
            txtPlateNumber.CornerRadiusTopLeft = 30;
            txtPlateNumber.CornerRadiusTopRight = 30;
            txtPlateNumber.FocusBorderColor = Color.FromArgb(91, 121, 255);
            txtPlateNumber.Location = new Point(704, 149);
            txtPlateNumber.Margin = new Padding(3, 2, 3, 2);
            txtPlateNumber.MaxLength = 32767;
            txtPlateNumber.Name = "txtPlateNumber";
            txtPlateNumber.Padding = new Padding(7, 0, 7, 0);
            txtPlateNumber.PasswordChar = '\0';
            txtPlateNumber.PlaceholderText = "";
            txtPlateNumber.Size = new Size(290, 51);
            txtPlateNumber.TabIndex = 33;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.BackgroundColor = Color.White;
            txtPassword.BorderColor = Color.FromArgb(91, 121, 255);
            txtPassword.BorderThickness = 3;
            txtPassword.CornerRadiusBottomLeft = 30;
            txtPassword.CornerRadiusBottomRight = 30;
            txtPassword.CornerRadiusTopLeft = 30;
            txtPassword.CornerRadiusTopRight = 30;
            txtPassword.FocusBorderColor = Color.FromArgb(91, 121, 255);
            txtPassword.Location = new Point(377, 359);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.MaxLength = 32767;
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(7, 0, 7, 0);
            txtPassword.PasswordChar = '\0';
            txtPassword.PlaceholderText = "";
            txtPassword.Size = new Size(310, 51);
            txtPassword.TabIndex = 32;
            // 
            // txtEmailAdd
            // 
            txtEmailAdd.BackgroundColor = Color.White;
            txtEmailAdd.BorderColor = Color.FromArgb(91, 121, 255);
            txtEmailAdd.BorderThickness = 3;
            txtEmailAdd.CornerRadiusBottomLeft = 30;
            txtEmailAdd.CornerRadiusBottomRight = 30;
            txtEmailAdd.CornerRadiusTopLeft = 30;
            txtEmailAdd.CornerRadiusTopRight = 30;
            txtEmailAdd.FocusBorderColor = Color.FromArgb(91, 121, 255);
            txtEmailAdd.Location = new Point(377, 250);
            txtEmailAdd.Margin = new Padding(3, 2, 3, 2);
            txtEmailAdd.MaxLength = 32767;
            txtEmailAdd.Name = "txtEmailAdd";
            txtEmailAdd.Padding = new Padding(7, 0, 7, 0);
            txtEmailAdd.PasswordChar = '\0';
            txtEmailAdd.PlaceholderText = "";
            txtEmailAdd.Size = new Size(310, 51);
            txtEmailAdd.TabIndex = 31;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.None;
            txtUsername.BackgroundColor = Color.White;
            txtUsername.BorderColor = Color.FromArgb(91, 121, 255);
            txtUsername.BorderThickness = 3;
            txtUsername.CornerRadiusBottomLeft = 30;
            txtUsername.CornerRadiusBottomRight = 30;
            txtUsername.CornerRadiusTopLeft = 30;
            txtUsername.CornerRadiusTopRight = 30;
            txtUsername.FocusBorderColor = Color.FromArgb(91, 121, 255);
            txtUsername.Location = new Point(377, 149);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.MaxLength = 32767;
            txtUsername.Name = "txtUsername";
            txtUsername.Padding = new Padding(7, 0, 7, 0);
            txtUsername.PasswordChar = '\0';
            txtUsername.PlaceholderText = "";
            txtUsername.Size = new Size(310, 51);
            txtUsername.TabIndex = 30;
            // 
            // txtLastName
            // 
            txtLastName.Anchor = AnchorStyles.None;
            txtLastName.BackgroundColor = Color.White;
            txtLastName.BorderColor = Color.FromArgb(91, 121, 255);
            txtLastName.BorderThickness = 3;
            txtLastName.CornerRadiusBottomLeft = 30;
            txtLastName.CornerRadiusBottomRight = 30;
            txtLastName.CornerRadiusTopLeft = 30;
            txtLastName.CornerRadiusTopRight = 30;
            txtLastName.FocusBorderColor = Color.FromArgb(91, 121, 255);
            txtLastName.Location = new Point(49, 359);
            txtLastName.Margin = new Padding(3, 2, 3, 2);
            txtLastName.MaxLength = 32767;
            txtLastName.Name = "txtLastName";
            txtLastName.Padding = new Padding(7, 0, 7, 0);
            txtLastName.PasswordChar = '\0';
            txtLastName.PlaceholderText = "";
            txtLastName.Size = new Size(310, 51);
            txtLastName.TabIndex = 29;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Anchor = AnchorStyles.None;
            txtMiddleName.BackgroundColor = Color.White;
            txtMiddleName.BorderColor = Color.FromArgb(91, 121, 255);
            txtMiddleName.BorderThickness = 3;
            txtMiddleName.CornerRadiusBottomLeft = 30;
            txtMiddleName.CornerRadiusBottomRight = 30;
            txtMiddleName.CornerRadiusTopLeft = 30;
            txtMiddleName.CornerRadiusTopRight = 30;
            txtMiddleName.FocusBorderColor = Color.FromArgb(91, 121, 255);
            txtMiddleName.Location = new Point(49, 250);
            txtMiddleName.Margin = new Padding(3, 2, 3, 2);
            txtMiddleName.MaxLength = 32767;
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Padding = new Padding(7, 0, 7, 0);
            txtMiddleName.PasswordChar = '\0';
            txtMiddleName.PlaceholderText = "";
            txtMiddleName.Size = new Size(310, 51);
            txtMiddleName.TabIndex = 28;
            // 
            // txtFirstName
            // 
            txtFirstName.Anchor = AnchorStyles.None;
            txtFirstName.BackgroundColor = Color.White;
            txtFirstName.BorderColor = Color.FromArgb(91, 121, 255);
            txtFirstName.BorderThickness = 3;
            txtFirstName.CornerRadiusBottomLeft = 30;
            txtFirstName.CornerRadiusBottomRight = 30;
            txtFirstName.CornerRadiusTopLeft = 30;
            txtFirstName.CornerRadiusTopRight = 30;
            txtFirstName.FocusBorderColor = Color.FromArgb(91, 121, 255);
            txtFirstName.Location = new Point(49, 149);
            txtFirstName.Margin = new Padding(3, 2, 3, 2);
            txtFirstName.MaxLength = 32767;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Padding = new Padding(7, 0, 7, 0);
            txtFirstName.PasswordChar = '\0';
            txtFirstName.PlaceholderText = "";
            txtFirstName.Size = new Size(310, 51);
            txtFirstName.TabIndex = 27;
            // 
            // required5
            // 
            required5.AutoSize = true;
            required5.Font = new Font("Arial Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            required5.ForeColor = Color.Red;
            required5.Location = new Point(478, 328);
            required5.Name = "required5";
            required5.Size = new Size(19, 24);
            required5.TabIndex = 26;
            required5.Text = "*";
            // 
            // required3
            // 
            required3.AutoSize = true;
            required3.Font = new Font("Arial Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            required3.ForeColor = Color.Red;
            required3.Location = new Point(485, 120);
            required3.Name = "required3";
            required3.Size = new Size(19, 24);
            required3.TabIndex = 25;
            required3.Text = "*";
            // 
            // required2
            // 
            required2.AutoSize = true;
            required2.Font = new Font("Arial Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            required2.ForeColor = Color.Red;
            required2.Location = new Point(159, 330);
            required2.Name = "required2";
            required2.Size = new Size(19, 24);
            required2.TabIndex = 24;
            required2.Text = "*";
            // 
            // required1
            // 
            required1.AutoSize = true;
            required1.Font = new Font("Arial Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            required1.ForeColor = Color.Red;
            required1.Location = new Point(163, 119);
            required1.Name = "required1";
            required1.Size = new Size(19, 24);
            required1.TabIndex = 23;
            required1.Text = "*";
            // 
            // required4
            // 
            required4.AutoSize = true;
            required4.Font = new Font("Arial Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            required4.ForeColor = Color.Red;
            required4.Location = new Point(443, 218);
            required4.Name = "required4";
            required4.Size = new Size(19, 24);
            required4.TabIndex = 22;
            required4.Text = "*";
            // 
            // cBoxSeniorOrPwd
            // 
            cBoxSeniorOrPwd.AutoSize = true;
            cBoxSeniorOrPwd.BackColor = Color.Transparent;
            cBoxSeniorOrPwd.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            cBoxSeniorOrPwd.Location = new Point(727, 155);
            cBoxSeniorOrPwd.Margin = new Padding(3, 2, 3, 2);
            cBoxSeniorOrPwd.Name = "cBoxSeniorOrPwd";
            cBoxSeniorOrPwd.Size = new Size(183, 36);
            cBoxSeniorOrPwd.TabIndex = 17;
            cBoxSeniorOrPwd.Text = "Senior / PWD";
            cBoxSeniorOrPwd.UseVisualStyleBackColor = false;
            // 
            // plateNumberLbl
            // 
            plateNumberLbl.AutoSize = true;
            plateNumberLbl.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            plateNumberLbl.Location = new Point(723, 122);
            plateNumberLbl.Name = "plateNumberLbl";
            plateNumberLbl.Size = new Size(128, 25);
            plateNumberLbl.TabIndex = 15;
            plateNumberLbl.Text = "Plate Number";
            // 
            // passwordLbl
            // 
            passwordLbl.AutoSize = true;
            passwordLbl.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordLbl.Location = new Point(395, 332);
            passwordLbl.Name = "passwordLbl";
            passwordLbl.Size = new Size(90, 25);
            passwordLbl.TabIndex = 13;
            passwordLbl.Text = "Password";
            // 
            // emailLbl
            // 
            emailLbl.AutoSize = true;
            emailLbl.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            emailLbl.Location = new Point(395, 223);
            emailLbl.Name = "emailLbl";
            emailLbl.Size = new Size(56, 25);
            emailLbl.TabIndex = 11;
            emailLbl.Text = "Email";
            // 
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameLbl.Location = new Point(395, 122);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(96, 25);
            usernameLbl.TabIndex = 3;
            usernameLbl.Text = "Username";
            // 
            // lastnameLbl
            // 
            lastnameLbl.AutoSize = true;
            lastnameLbl.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lastnameLbl.Location = new Point(68, 332);
            lastnameLbl.Name = "lastnameLbl";
            lastnameLbl.Size = new Size(99, 25);
            lastnameLbl.TabIndex = 9;
            lastnameLbl.Text = "Last Name";
            // 
            // middlenameLbl
            // 
            middlenameLbl.AutoSize = true;
            middlenameLbl.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            middlenameLbl.Location = new Point(68, 223);
            middlenameLbl.Name = "middlenameLbl";
            middlenameLbl.Size = new Size(125, 25);
            middlenameLbl.TabIndex = 7;
            middlenameLbl.Text = "Middle Name";
            // 
            // linkLogin
            // 
            linkLogin.AutoSize = true;
            linkLogin.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            linkLogin.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLogin.Location = new Point(916, 421);
            linkLogin.Name = "linkLogin";
            linkLogin.Size = new Size(52, 23);
            linkLogin.TabIndex = 6;
            linkLogin.TabStop = true;
            linkLogin.Text = "Login";
            linkLogin.LinkClicked += linkLogin_LinkClicked;
            // 
            // haveAccLbl
            // 
            haveAccLbl.AutoSize = true;
            haveAccLbl.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            haveAccLbl.Location = new Point(723, 421);
            haveAccLbl.Name = "haveAccLbl";
            haveAccLbl.Size = new Size(206, 23);
            haveAccLbl.TabIndex = 5;
            haveAccLbl.Text = "Already have an account?";
            // 
            // firstnameLbl
            // 
            firstnameLbl.AutoSize = true;
            firstnameLbl.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            firstnameLbl.Location = new Point(68, 122);
            firstnameLbl.Name = "firstnameLbl";
            firstnameLbl.Size = new Size(102, 25);
            firstnameLbl.TabIndex = 1;
            firstnameLbl.Text = "First Name";
            // 
            // lblSIgnUp
            // 
            lblSIgnUp.AutoSize = true;
            lblSIgnUp.Font = new Font("Impact", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSIgnUp.ForeColor = Color.FromArgb(81, 112, 255);
            lblSIgnUp.Location = new Point(424, 25);
            lblSIgnUp.Name = "lblSIgnUp";
            lblSIgnUp.Size = new Size(219, 75);
            lblSIgnUp.TabIndex = 0;
            lblSIgnUp.Text = "SIGN UP";
            // 
            // RegisterForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.bgImg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1262, 673);
            Controls.Add(parentPnl);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "RegisterForm";
            Text = "Register";
            Load += RegisterForm_Load_1;
            parentPnl.ResumeLayout(false);
            childPnl.ResumeLayout(false);
            childPnl.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel parentPnl;
        private Panel childPnl;
        private Label haveAccLbl;
        private Label firstnameLbl;
        private Label plateNumberLbl;
        private Label passwordLbl;
        private Label emailLbl;
        private Label usernameLbl;
        private Label lastnameLbl;
        private Label middlenameLbl;
        private LinkLabel linkLogin;
        private CheckBox cBoxSeniorOrPwd;
        private Label required4;
        private Label required2;
        private Label required1;
        private Label required5;
        private Label required3;
        private RadioButton userRadioBtn;
        private Label lblSIgnUp;
        private RoundedTextBox txtFirstName;
        private RoundedTextBox txtLastName;
        private RoundedTextBox txtMiddleName;
        private RadioButton driverRadioBtn;
        private RoundedTextBox txtUsername;
        private RoundedTextBox txtPassword;
        private RoundedTextBox txtEmailAdd;
        private RoundedTextBox txtPlateNumber;
        private RoundedButton btnSignUp;
        private Panel lineInBetweenRadioBtns;
    }
}