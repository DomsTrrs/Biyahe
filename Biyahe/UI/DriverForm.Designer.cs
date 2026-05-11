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
            DriverDashboard.Location = new Point(24, 22);
            DriverDashboard.Margin = new Padding(2, 0, 2, 0);
            DriverDashboard.Name = "DriverDashboard";
            DriverDashboard.Size = new Size(126, 20);
            DriverDashboard.TabIndex = 0;
            DriverDashboard.Text = "Driver Dashboard";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(296, 205);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(18, 20);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "...";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(264, 237);
            btnLogout.Margin = new Padding(2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(90, 27);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // DriverForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1262, 673);
            ControlBox = false;
            Controls.Add(btnLogout);
            Controls.Add(lblWelcome);
            Controls.Add(DriverDashboard);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
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