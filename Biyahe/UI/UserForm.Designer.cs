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
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            cBoxRoutes = new ComboBox();
            cBoxLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(286, 285);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(18, 20);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "...";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(255, 307);
            btnLogout.Margin = new Padding(2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(90, 27);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout ";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // UserDashboard
            // 
            UserDashboard.AutoSize = true;
            UserDashboard.Location = new Point(30, 18);
            UserDashboard.Margin = new Padding(2, 0, 2, 0);
            UserDashboard.Name = "UserDashboard";
            UserDashboard.Size = new Size(115, 20);
            UserDashboard.TabIndex = 2;
            UserDashboard.Text = "User Dashboard";
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(255, 150);
            webView21.Margin = new Padding(2);
            webView21.Name = "webView21";
            webView21.Size = new Size(90, 27);
            webView21.TabIndex = 3;
            webView21.ZoomFactor = 1D;
            // 
            // cBoxRoutes
            // 
            cBoxRoutes.FormattingEnabled = true;
            cBoxRoutes.Location = new Point(38, 384);
            cBoxRoutes.Name = "cBoxRoutes";
            cBoxRoutes.Size = new Size(257, 33);
            cBoxRoutes.TabIndex = 4;
            cBoxRoutes.SelectedIndexChanged += cBoxRoutes_SelectedIndexChanged;
            // 
            // cBoxLabel
            // 
            cBoxLabel.AutoSize = true;
            cBoxLabel.BackColor = Color.Transparent;
            cBoxLabel.Location = new Point(44, 348);
            cBoxLabel.Name = "cBoxLabel";
            cBoxLabel.Size = new Size(138, 25);
            cBoxLabel.TabIndex = 5;
            cBoxLabel.Text = "Route Selected: ";
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            ControlBox = false;
            Controls.Add(cBoxLabel);
            Controls.Add(cBoxRoutes);
            Controls.Add(UserDashboard);
            Controls.Add(lblWelcome);
            Controls.Add(btnLogout);
            Controls.Add(webView21);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "UserForm";
            Text = "UserForm";
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnLogout;
        private Label UserDashboard;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private ComboBox cBoxRoutes;
        private Label cBoxLabel;
    }
}