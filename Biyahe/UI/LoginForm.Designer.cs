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
            loginPnl = new Panel();
            signUpLink = new LinkLabel();
            eyePicBox = new PictureBox();
            lblLogin = new Label();
            noAccLbl = new Label();
            txtUsername = new RoundedTextBox();
            btnLogin = new RoundedButton();
            usernameLbl = new Label();
            txtPassword = new RoundedTextBox();
            passwordLbl = new Label();
            mainPnl = new RoundedPanel();
            logoPnl = new RoundedPanel();
            logoPicBox = new PictureBox();
            lblTag = new Label();
            loginPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)eyePicBox).BeginInit();
            mainPnl.SuspendLayout();
            logoPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPicBox).BeginInit();
            SuspendLayout();
            // 
            // loginPnl
            // 
            loginPnl.Controls.Add(lblTag);
            loginPnl.Controls.Add(signUpLink);
            loginPnl.Controls.Add(eyePicBox);
            loginPnl.Controls.Add(lblLogin);
            loginPnl.Controls.Add(noAccLbl);
            loginPnl.Controls.Add(txtUsername);
            loginPnl.Controls.Add(btnLogin);
            loginPnl.Controls.Add(usernameLbl);
            loginPnl.Controls.Add(txtPassword);
            loginPnl.Controls.Add(passwordLbl);
            loginPnl.Dock = DockStyle.Right;
            loginPnl.Location = new Point(751, 0);
            loginPnl.Margin = new Padding(4, 4, 4, 4);
            loginPnl.Name = "loginPnl";
            loginPnl.Size = new Size(545, 629);
            loginPnl.TabIndex = 2;
            // 
            // signUpLink
            // 
            signUpLink.ActiveLinkColor = Color.FromArgb(51, 64, 129);
            signUpLink.AutoSize = true;
            signUpLink.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signUpLink.LinkBehavior = LinkBehavior.NeverUnderline;
            signUpLink.LinkColor = Color.FromArgb(81, 112, 255);
            signUpLink.Location = new Point(332, 559);
            signUpLink.Margin = new Padding(4, 0, 4, 0);
            signUpLink.Name = "signUpLink";
            signUpLink.Size = new Size(88, 30);
            signUpLink.TabIndex = 8;
            signUpLink.TabStop = true;
            signUpLink.Text = "Sign Up";
            signUpLink.VisitedLinkColor = Color.FromArgb(81, 112, 255);
            signUpLink.LinkClicked += signUpLink_LinkClicked;
            // 
            // eyePicBox
            // 
            eyePicBox.Image = Properties.Resources.eye_closed;
            eyePicBox.ImageLocation = "";
            eyePicBox.InitialImage = Properties.Resources.eye_closed;
            eyePicBox.Location = new Point(436, 349);
            eyePicBox.Margin = new Padding(4, 4, 4, 4);
            eyePicBox.Name = "eyePicBox";
            eyePicBox.Size = new Size(69, 64);
            eyePicBox.SizeMode = PictureBoxSizeMode.Zoom;
            eyePicBox.TabIndex = 5;
            eyePicBox.TabStop = false;
            eyePicBox.Click += eyePicBox_Click;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Impact", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLogin.ForeColor = Color.FromArgb(81, 112, 255);
            lblLogin.Location = new Point(178, 28);
            lblLogin.Margin = new Padding(4, 0, 4, 0);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(202, 87);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "LOGIN";
            // 
            // noAccLbl
            // 
            noAccLbl.AutoSize = true;
            noAccLbl.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            noAccLbl.ForeColor = Color.FromArgb(81, 112, 255);
            noAccLbl.Location = new Point(106, 559);
            noAccLbl.Margin = new Padding(4, 0, 4, 0);
            noAccLbl.Name = "noAccLbl";
            noAccLbl.Size = new Size(227, 30);
            noAccLbl.TabIndex = 7;
            noAccLbl.Text = "Dont have an account?";
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.None;
            txtUsername.BackgroundColor = Color.White;
            txtUsername.BackgroundImageLayout = ImageLayout.Center;
            txtUsername.BorderColor = Color.FromArgb(91, 121, 255);
            txtUsername.BorderThickness = 3;
            txtUsername.CornerRadiusBottomLeft = 30;
            txtUsername.CornerRadiusBottomRight = 30;
            txtUsername.CornerRadiusTopLeft = 30;
            txtUsername.CornerRadiusTopRight = 30;
            txtUsername.FocusBorderColor = Color.FromArgb(91, 121, 255);
            txtUsername.Location = new Point(41, 225);
            txtUsername.Margin = new Padding(4, 4, 4, 4);
            txtUsername.MaxLength = 32767;
            txtUsername.Name = "txtUsername";
            txtUsername.Padding = new Padding(10, 0, 10, 0);
            txtUsername.PasswordChar = '\0';
            txtUsername.PlaceholderText = "";
            txtUsername.Size = new Size(388, 64);
            txtUsername.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.None;
            btnLogin.BackColor = Color.FromArgb(81, 112, 255);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Impact", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.HoverColor = Color.FromArgb(73, 96, 206);
            btnLogin.Location = new Point(156, 460);
            btnLogin.Margin = new Padding(4, 4, 4, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.NormalColor = Color.FromArgb(81, 112, 255);
            btnLogin.Size = new Size(211, 84);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "LOGIN";
            btnLogin.TextImageRelation = TextImageRelation.TextAboveImage;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameLbl.ForeColor = Color.FromArgb(81, 112, 255);
            usernameLbl.Location = new Point(56, 190);
            usernameLbl.Margin = new Padding(4, 0, 4, 0);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(198, 30);
            usernameLbl.TabIndex = 1;
            usernameLbl.Text = "Username or Email";
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
            txtPassword.Location = new Point(41, 349);
            txtPassword.Margin = new Padding(4, 4, 4, 4);
            txtPassword.MaxLength = 32767;
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(10, 0, 10, 0);
            txtPassword.PasswordChar = '\0';
            txtPassword.PlaceholderText = "";
            txtPassword.Size = new Size(388, 64);
            txtPassword.TabIndex = 3;
            // 
            // passwordLbl
            // 
            passwordLbl.AutoSize = true;
            passwordLbl.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            passwordLbl.ForeColor = Color.FromArgb(81, 112, 255);
            passwordLbl.Location = new Point(56, 314);
            passwordLbl.Margin = new Padding(4, 0, 4, 0);
            passwordLbl.Name = "passwordLbl";
            passwordLbl.Size = new Size(105, 30);
            passwordLbl.TabIndex = 4;
            passwordLbl.Text = "Password";
            // 
            // mainPnl
            // 
            mainPnl.Anchor = AnchorStyles.None;
            mainPnl.BackColor = Color.Transparent;
            mainPnl.Controls.Add(logoPnl);
            mainPnl.Controls.Add(loginPnl);
            mainPnl.CornerRadiusBottomLeft = 30;
            mainPnl.CornerRadiusBottomRight = 30;
            mainPnl.CornerRadiusTopLeft = 30;
            mainPnl.CornerRadiusTopRight = 30;
            mainPnl.GlassBorderColor = Color.FromArgb(120, 255, 255, 255);
            mainPnl.GlassShineColor = Color.FromArgb(80, 255, 255, 255);
            mainPnl.GlassTintColor = Color.FromArgb(50, 255, 255, 255);
            mainPnl.Location = new Point(134, 106);
            mainPnl.Margin = new Padding(4, 4, 4, 4);
            mainPnl.Name = "mainPnl";
            mainPnl.PanelColor = Color.White;
            mainPnl.Size = new Size(1296, 629);
            mainPnl.TabIndex = 0;
            // 
            // logoPnl
            // 
            logoPnl.BackgroundImage = Properties.Resources.logoPnlImg;
            logoPnl.BackgroundImageLayout = ImageLayout.Stretch;
            logoPnl.Controls.Add(logoPicBox);
            logoPnl.CornerRadiusBottomRight = 0;
            logoPnl.CornerRadiusTopRight = 0;
            logoPnl.Dock = DockStyle.Left;
            logoPnl.GlassBorderColor = Color.FromArgb(120, 255, 255, 255);
            logoPnl.GlassShineColor = Color.FromArgb(80, 255, 255, 255);
            logoPnl.GlassTintColor = Color.FromArgb(50, 255, 255, 255);
            logoPnl.Location = new Point(0, 0);
            logoPnl.Margin = new Padding(4, 4, 4, 4);
            logoPnl.Name = "logoPnl";
            logoPnl.PanelColor = Color.Transparent;
            logoPnl.Size = new Size(751, 629);
            logoPnl.TabIndex = 3;
            // 
            // logoPicBox
            // 
            logoPicBox.Image = Properties.Resources.BiyaheLogo;
            logoPicBox.Location = new Point(22, 95);
            logoPicBox.Margin = new Padding(4, 4, 4, 4);
            logoPicBox.Name = "logoPicBox";
            logoPicBox.Size = new Size(708, 554);
            logoPicBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPicBox.TabIndex = 0;
            logoPicBox.TabStop = false;
            // 
            // lblTag
            // 
            lblTag.AutoSize = true;
            lblTag.ForeColor = Color.FromArgb(81, 112, 255);
            lblTag.Location = new Point(56, 417);
            lblTag.Name = "lblTag";
            lblTag.Size = new Size(0, 25);
            lblTag.TabIndex = 9;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            BackgroundImage = Properties.Resources.bgImg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1578, 841);
            Controls.Add(mainPnl);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 4, 4, 4);
            Name = "LoginForm";
            Text = "Login";
            Load += LoginForm_Load;
            loginPnl.ResumeLayout(false);
            loginPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)eyePicBox).EndInit();
            mainPnl.ResumeLayout(false);
            logoPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPicBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox eyePictureBox;
        private Panel loginPnl;
        private LinkLabel signUpLink;
        private PictureBox eyePicBox;
        private Label lblLogin;
        private Label noAccLbl;
        private RoundedTextBox txtUsername;
        private RoundedButton btnLogin;
        private Label usernameLbl;
        private RoundedTextBox txtPassword;
        private Label passwordLbl;
        private RoundedPanel mainPnl;
        private PictureBox logoPicBox;
        private RoundedPanel logoPnl;
        private Label lblTag;
    }
}