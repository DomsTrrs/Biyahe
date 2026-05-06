namespace Biyahe.UI
{
    partial class DriverForm
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
            DriverDashboard = new Label();
            lblWelcome = new Label();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // DriverDashboard
            // 
            DriverDashboard.AutoSize = true;
            DriverDashboard.Location = new Point(30, 28);
            DriverDashboard.Name = "DriverDashboard";
            DriverDashboard.Size = new Size(152, 25);
            DriverDashboard.TabIndex = 0;
            DriverDashboard.Text = "Driver Dashboard";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(370, 256);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(24, 25);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "...";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(330, 296);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 34);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // DriverForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(btnLogout);
            Controls.Add(lblWelcome);
            Controls.Add(DriverDashboard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DriverForm";
            Text = "DriverForm";
            Load += DriverForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label DriverDashboard;
        private Label lblWelcome;
        private Button btnLogout;
    }
}