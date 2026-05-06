namespace Biyahe.UI
{
    partial class UserForm
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
            lblWelcome = new Label();
            btnLogout = new Button();
            UserDashboard = new Label();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(360, 225);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(24, 25);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "...";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(319, 262);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 34);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout ";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // UserDashboard
            // 
            UserDashboard.AutoSize = true;
            UserDashboard.Location = new Point(38, 23);
            UserDashboard.Name = "UserDashboard";
            UserDashboard.Size = new Size(140, 25);
            UserDashboard.TabIndex = 2;
            UserDashboard.Text = "User Dashboard";
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(UserDashboard);
            Controls.Add(btnLogout);
            Controls.Add(lblWelcome);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserForm";
            Text = "UserForm";
            Load += UserForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnLogout;
        private Label UserDashboard;
    }
}