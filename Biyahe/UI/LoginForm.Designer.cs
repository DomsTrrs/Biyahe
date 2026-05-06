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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            lblLogin = new Label();
            lblLog = new Label();
            label1 = new Label();
            linkSignUp = new LinkLabel();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(186, 174);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(429, 31);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(186, 229);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(429, 31);
            txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Control;
            btnLogin.Location = new Point(349, 279);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(112, 34);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(186, 137);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(0, 25);
            lblLogin.TabIndex = 3;
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.Location = new Point(16, 13);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(56, 25);
            lblLog.TabIndex = 4;
            lblLog.Text = "Login";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(186, 339);
            label1.Name = "label1";
            label1.Size = new Size(193, 25);
            label1.TabIndex = 5;
            label1.Text = "Dont have an account?";
            // 
            // linkSignUp
            // 
            linkSignUp.AutoSize = true;
            linkSignUp.Location = new Point(374, 339);
            linkSignUp.Name = "linkSignUp";
            linkSignUp.Size = new Size(73, 25);
            linkSignUp.TabIndex = 6;
            linkSignUp.TabStop = true;
            linkSignUp.Text = "Sign up";
            linkSignUp.LinkClicked += linkSignUp_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(linkSignUp);
            Controls.Add(label1);
            Controls.Add(lblLog);
            Controls.Add(lblLogin);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblLogin;
        private Label lblLog;
        private Label label1;
        private LinkLabel linkSignUp;
    }
}