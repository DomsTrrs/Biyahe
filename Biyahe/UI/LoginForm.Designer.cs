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
            loginPnl = new Panel();
            eyePictureBox = new PictureBox();
            btnLogin = new RoundedButton();
            signUpLink = new LinkLabel();
            noAccLbl = new Label();
            txtPassword = new TextBox();
            passwordLbl = new Label();
            txtUsername = new TextBox();
            usernameLbl = new Label();
            label1 = new Label();
            logoPnl = new Panel();
            logo = new PictureBox();
            mainPnl.SuspendLayout();
            loginPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)eyePictureBox).BeginInit();
            logoPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // mainPnl
            // 
            mainPnl.BackColor = Color.Transparent;
            mainPnl.Controls.Add(loginPnl);
            mainPnl.Controls.Add(logoPnl);
            mainPnl.Location = new Point(96, 61);
            mainPnl.Name = "mainPnl";
            mainPnl.PanelColor = Color.White;
            mainPnl.Size = new Size(596, 325);
            mainPnl.TabIndex = 0;
            // 
            // loginPnl
            // 
            loginPnl.Controls.Add(eyePictureBox);
            loginPnl.Controls.Add(btnLogin);
            loginPnl.Controls.Add(signUpLink);
            loginPnl.Controls.Add(noAccLbl);
            loginPnl.Controls.Add(txtPassword);
            loginPnl.Controls.Add(passwordLbl);
            loginPnl.Controls.Add(txtUsername);
            loginPnl.Controls.Add(usernameLbl);
            loginPnl.Controls.Add(label1);
            loginPnl.Dock = DockStyle.Fill;
            loginPnl.Location = new Point(250, 0);
            loginPnl.Name = "loginPnl";
            loginPnl.Size = new Size(346, 325);
            loginPnl.TabIndex = 1;
            // 
            // eyePictureBox
            // 
            eyePictureBox.InitialImage = null;
            eyePictureBox.Location = new Point(289, 165);
            eyePictureBox.Name = "eyePictureBox";
            eyePictureBox.Size = new Size(36, 36);
            eyePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            eyePictureBox.TabIndex = 9;
            eyePictureBox.TabStop = false;
            eyePictureBox.Click += eyePictureBox_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Silver;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Impact", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.ActiveCaptionText;
            btnLogin.Location = new Point(105, 217);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(133, 46);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // signUpLink
            // 
            signUpLink.AutoSize = true;
            signUpLink.LinkBehavior = LinkBehavior.NeverUnderline;
            signUpLink.Location = new Point(201, 278);
            signUpLink.Name = "signUpLink";
            signUpLink.Size = new Size(61, 20);
            signUpLink.TabIndex = 6;
            signUpLink.TabStop = true;
            signUpLink.Text = "Sign Up";
            signUpLink.LinkClicked += signUpLink_LinkClicked;
            // 
            // noAccLbl
            // 
            noAccLbl.AutoSize = true;
            noAccLbl.Location = new Point(44, 278);
            noAccLbl.Name = "noAccLbl";
            noAccLbl.Size = new Size(160, 20);
            noAccLbl.TabIndex = 5;
            noAccLbl.Text = "Dont have an account?";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(25, 169);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 27);
            txtPassword.TabIndex = 4;
            // 
            // passwordLbl
            // 
            passwordLbl.AutoSize = true;
            passwordLbl.Location = new Point(25, 146);
            passwordLbl.Name = "passwordLbl";
            passwordLbl.Size = new Size(70, 20);
            passwordLbl.TabIndex = 3;
            passwordLbl.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(25, 103);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 27);
            txtUsername.TabIndex = 2;
            // 
            // usernameLbl
            // 
            usernameLbl.AutoSize = true;
            usernameLbl.Location = new Point(25, 80);
            usernameLbl.Name = "usernameLbl";
            usernameLbl.Size = new Size(134, 20);
            usernameLbl.TabIndex = 1;
            usernameLbl.Text = "Username or Email";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(128, 29);
            label1.Name = "label1";
            label1.Size = new Size(86, 37);
            label1.TabIndex = 0;
            label1.Text = "LOGIN";
            // 
            // logoPnl
            // 
            logoPnl.Controls.Add(logo);
            logoPnl.Dock = DockStyle.Left;
            logoPnl.Location = new Point(0, 0);
            logoPnl.Name = "logoPnl";
            logoPnl.Size = new Size(250, 325);
            logoPnl.TabIndex = 0;
            // 
            // logo
            // 
            logo.Image = Properties.Resources.BiyaheLogo;
            logo.InitialImage = Properties.Resources.BiyaheLogo;
            logo.Location = new Point(27, 80);
            logo.Name = "logo";
            logo.Size = new Size(195, 166);
            logo.SizeMode = PictureBoxSizeMode.Zoom;
            logo.TabIndex = 0;
            logo.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 450);
            Controls.Add(mainPnl);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            Text = "Login";
            Load += LoginForm_Load;
            mainPnl.ResumeLayout(false);
            loginPnl.ResumeLayout(false);
            loginPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)eyePictureBox).EndInit();
            logoPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RoundedPanel mainPnl;
        private Panel loginPnl;
        private Label label1;
        private Panel logoPnl;
        private PictureBox logo;
        private Label noAccLbl;
        private TextBox txtPassword;
        private Label passwordLbl;
        private TextBox txtUsername;
        private Label usernameLbl;
        private LinkLabel signUpLink;
        private RoundedButton btnLogin;
        private PictureBox eyePictureBox;
    }
}