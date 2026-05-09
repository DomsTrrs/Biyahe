namespace Biyahe.UI
{
    partial class LoginForm
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
            mainPnl = new RoundedPanel();
            loginPnl = new RoundedPanel();
            signUpLink = new LinkLabel();
            noAccLbl = new Label();
            btnLogin = new RoundedButton();
            eyePicBox = new PictureBox();
            passwordLbl = new Label();
            txtPassword = new RoundedTextBox();
            txtUsername = new RoundedTextBox();
            usernameLbl = new Label();
            lblLogin = new Label();
            logoPnl = new RoundedPanel();
            logoPicBox = new PictureBox();
            mainPnl.SuspendLayout();
            loginPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)eyePicBox).BeginInit();
            logoPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPicBox).BeginInit();
            SuspendLayout();
            // 
            // mainPnl
            // 
            mainPnl.BackColor = Color.Transparent;
            mainPnl.Controls.Add(loginPnl);
            mainPnl.Controls.Add(logoPnl);
            mainPnl.CornerRadiusBottomLeft = 30;
            mainPnl.CornerRadiusBottomRight = 30;
            mainPnl.CornerRadiusTopLeft = 30;
            mainPnl.CornerRadiusTopRight = 30;
            mainPnl.Location = new Point(108, 85);
            mainPnl.Name = "mainPnl";
            mainPnl.PanelColor = Color.White;
            mainPnl.Size = new Size(1037, 503);
            mainPnl.TabIndex = 0;
            // 
            // loginPnl
            // 
            loginPnl.Controls.Add(signUpLink);
            loginPnl.Controls.Add(noAccLbl);
            loginPnl.Controls.Add(btnLogin);
            loginPnl.Controls.Add(eyePicBox);
            loginPnl.Controls.Add(passwordLbl);
            loginPnl.Controls.Add(txtPassword);
            loginPnl.Controls.Add(txtUsername);
            loginPnl.Controls.Add(usernameLbl);
            loginPnl.Controls.Add(lblLogin);
            loginPnl.CornerRadiusBottomLeft = 0;
            loginPnl.CornerRadiusTopLeft = 0;
            loginPnl.Dock = DockStyle.Right;
            loginPnl.Location = new Point(600, 0);
            loginPnl.Name = "loginPnl";
            loginPnl.PanelColor = Color.Transparent;
            loginPnl.Size = new Size(437, 503);
            loginPnl.TabIndex = 1;
            // 
            // signUpLink
            // 
            signUpLink.ActiveLinkColor = Color.FromArgb(51, 64, 129);
            signUpLink.AutoSize = true;
            signUpLink.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signUpLink.LinkBehavior = LinkBehavior.NeverUnderline;
            signUpLink.LinkColor = Color.FromArgb(81, 112, 255);
            signUpLink.Location = new Point(283, 459);
            signUpLink.Name = "signUpLink";
            signUpLink.Size = new Size(70, 23);
            signUpLink.TabIndex = 8;
            signUpLink.TabStop = true;
            signUpLink.Text = "Sign Up";
            signUpLink.VisitedLinkColor = Color.FromArgb(81, 112, 255);
            signUpLink.LinkClicked += signUpLink_LinkClicked;
            // 
            // noAccLbl
            // 
            noAccLbl.AutoSize = true;
            noAccLbl.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            noAccLbl.ForeColor = Color.FromArgb(81, 112, 255);
            noAccLbl.Location = new Point(102, 459);
            noAccLbl.Name = "noAccLbl";
            noAccLbl.Size = new Size(187, 23);
            noAccLbl.TabIndex = 7;
            noAccLbl.Text = "Dont have an account?";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(81, 112, 255);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Impact", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.HoverColor = Color.FromArgb(73, 96, 206);
            btnLogin.Location = new Point(140, 380);
            btnLogin.Name = "btnLogin";
            btnLogin.NormalColor = Color.FromArgb(81, 112, 255);
            btnLogin.Size = new Size(169, 67);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "LOGIN";
            btnLogin.TextImageRelation = TextImageRelation.TextAboveImage;
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // eyePicBox
            // 
            eyePicBox.Image = Properties.Resources.eye_closed;
            eyePicBox.ImageLocation = "";
            eyePicBox.InitialImage = Properties.Resources.eye_closed;
            eyePicBox.Location = new Point(351, 288);
            eyePicBox.Name = "eyePicBox";
            eyePicBox.Size = new Size(55, 50);
            eyePicBox.SizeMode = PictureBoxSizeMode.Zoom;
            eyePicBox.TabIndex = 5;
            eyePicBox.TabStop = false;
            eyePicBox.Click += eyePicBox_Click;
            // 
            // passwordLbl
            // 
            passwordLbl.AutoSize = true;
            passwordLbl.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordLbl.ForeColor = Color.FromArgb(81, 112, 255);
            passwordLbl.Location = new Point(49, 260);
            passwordLbl.Name = "passwordLbl";
            passwordLbl.Size = new Size(90, 25);
            passwordLbl.TabIndex = 4;
            passwordLbl.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BackgroundColor = Color.White;
            txtPassword.BorderColor = Color.FromArgb(91, 121, 255);
            txtPassword.BorderThickness = 3;
            txtPassword.CornerRadiusBottomLeft = 30;
            txtPassword.CornerRadiusBottomRight = 30;
            txtPassword.CornerRadiusTopLeft = 30;
            txtPassword.CornerRadiusTopRight = 30;
            txtPassword.FocusBorderColor = Color.FromArgb(91, 121, 255);
            txtPassword.Location = new Point(35, 288);
            txtPassword.MaxLength = 32767;
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(8, 0, 8, 0);
            txtPassword.PasswordChar = '\0';
            txtPassword.PlaceholderText = "";
            txtPassword.Size = new Size(310, 50);
            txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.BackgroundColor = Color.White;
            txtUsername.BackgroundImageLayout = ImageLayout.Center;
            txtUsername.BorderColor = Color.FromArgb(91, 121, 255);
            txtUsername.BorderThickness = 3;
            txtUsername.CornerRadiusBottomLeft = 30;
            txtUsername.CornerRadiusBottomRight = 30;
            txtUsername.CornerRadiusTopLeft = 30;
            txtUsername.CornerRadiusTopRight = 30;
            txtUsername.FocusBorderColor = Color.FromArgb(91, 121, 255);
            txtUsername.Location = new Point(35, 188);
            txtUsername.MaxLength = 32767;
            txtUsername.Name = "txtUsername";
            txtUsername.Padding = new Padding(8, 0, 8, 0);
            txtUsername.PasswordChar = '\0';
            txtUsername.PlaceholderText = "";
            txtUsername.Size = new Size(310, 50);
            txtUsername.TabIndex = 2;
            // 
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameLbl.ForeColor = Color.FromArgb(81, 112, 255);
            usernameLbl.Location = new Point(49, 160);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(168, 25);
            usernameLbl.TabIndex = 1;
            usernameLbl.Text = "Username or Email";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Impact", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLogin.ForeColor = Color.FromArgb(81, 112, 255);
            lblLogin.Location = new Point(140, 29);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(169, 75);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "LOGIN";
            // 
            // logoPnl
            // 
            logoPnl.BackgroundImage = Properties.Resources.logoPnlImg;
            logoPnl.BackgroundImageLayout = ImageLayout.Stretch;
            logoPnl.Controls.Add(logoPicBox);
            logoPnl.CornerRadiusBottomRight = 0;
            logoPnl.CornerRadiusTopRight = 0;
            logoPnl.Dock = DockStyle.Left;
            logoPnl.Location = new Point(0, 0);
            logoPnl.Name = "logoPnl";
            logoPnl.PanelColor = Color.Transparent;
            logoPnl.Size = new Size(600, 503);
            logoPnl.TabIndex = 0;
            // 
            // logoPicBox
            // 
            logoPicBox.Image = Properties.Resources.BiyaheLogo;
            logoPicBox.Location = new Point(14, 60);
            logoPicBox.Name = "logoPicBox";
            logoPicBox.Size = new Size(566, 443);
            logoPicBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPicBox.TabIndex = 0;
            logoPicBox.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            BackgroundImage = Properties.Resources.bgImg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1262, 673);
            Controls.Add(mainPnl);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            Text = "Login";
            Load += LoginForm_Load;
            mainPnl.ResumeLayout(false);
            loginPnl.ResumeLayout(false);
            loginPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)eyePicBox).EndInit();
            logoPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPicBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox eyePictureBox;
        private RoundedPanel mainPnl;
        private RoundedPanel logoPnl;
        private PictureBox logoPicBox;
        private RoundedPanel loginPnl;
        private LinkLabel signUpLink;
        private Label noAccLbl;
        private RoundedButton btnLogin;
        private PictureBox eyePicBox;
        private Label passwordLbl;
        private RoundedTextBox txtPassword;
        private RoundedTextBox txtUsername;
        private Label usernameLbl;
        private Label lblLogin;
    }
}