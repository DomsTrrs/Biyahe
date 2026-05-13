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
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            cBoxRoutes = new ComboBox();
            cBoxLabel = new Label();
            sidePanel = new Panel();
            Version = new Label();
            linkAboutUs = new LinkLabel();
            Archetype = new Label();
            btnPanel = new Button();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            sidePanel.SuspendLayout();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(38, 260);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(24, 25);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "...";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(85, 436);
            btnLogout.Margin = new Padding(2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 34);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Logout ";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(907, 374);
            webView21.Margin = new Padding(2);
            webView21.Name = "webView21";
            webView21.Size = new Size(112, 34);
            webView21.TabIndex = 3;
            webView21.ZoomFactor = 1D;
            // 
            // cBoxRoutes
            // 
            cBoxRoutes.FormattingEnabled = true;
            cBoxRoutes.Location = new Point(55, 782);
            cBoxRoutes.Margin = new Padding(4);
            cBoxRoutes.Name = "cBoxRoutes";
            cBoxRoutes.Size = new Size(320, 33);
            cBoxRoutes.TabIndex = 4;
            cBoxRoutes.SelectedIndexChanged += cBoxRoutes_SelectedIndexChanged;
            // 
            // cBoxLabel
            // 
            cBoxLabel.AutoSize = true;
            cBoxLabel.BackColor = Color.Transparent;
            cBoxLabel.Location = new Point(55, 737);
            cBoxLabel.Margin = new Padding(4, 0, 4, 0);
            cBoxLabel.Name = "cBoxLabel";
            cBoxLabel.Size = new Size(138, 25);
            cBoxLabel.TabIndex = 5;
            cBoxLabel.Text = "Route Selected: ";
            // 
            // sidePanel
            // 
            sidePanel.Controls.Add(Version);
            sidePanel.Controls.Add(linkAboutUs);
            sidePanel.Controls.Add(Archetype);
            sidePanel.Controls.Add(btnLogout);
            sidePanel.Controls.Add(lblWelcome);
            sidePanel.Location = new Point(1, 52);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(300, 671);
            sidePanel.TabIndex = 6;
            // 
            // Version
            // 
            Version.AutoSize = true;
            Version.Location = new Point(80, 390);
            Version.Name = "Version";
            Version.Size = new Size(117, 25);
            Version.TabIndex = 4;
            Version.Text = "Version: 0.0.1";
            // 
            // linkAboutUs
            // 
            linkAboutUs.AutoSize = true;
            linkAboutUs.Location = new Point(92, 347);
            linkAboutUs.Name = "linkAboutUs";
            linkAboutUs.Size = new Size(90, 25);
            linkAboutUs.TabIndex = 3;
            linkAboutUs.TabStop = true;
            linkAboutUs.Text = "About us ";
            linkAboutUs.LinkClicked += linkAboutUs_LinkClicked;
            // 
            // Archetype
            // 
            Archetype.AutoSize = true;
            Archetype.Location = new Point(54, 299);
            Archetype.Name = "Archetype";
            Archetype.Size = new Size(180, 25);
            Archetype.TabIndex = 2;
            Archetype.Text = "Archetype: Passenger";
            // 
            // btnPanel
            // 
            btnPanel.Location = new Point(12, 12);
            btnPanel.Name = "btnPanel";
            btnPanel.Size = new Size(112, 34);
            btnPanel.TabIndex = 7;
            btnPanel.Text = "...";
            btnPanel.UseVisualStyleBackColor = true;
            btnPanel.Click += btnPanel_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 841);
            ControlBox = false;
            Controls.Add(btnPanel);
            Controls.Add(sidePanel);
            Controls.Add(cBoxLabel);
            Controls.Add(cBoxRoutes);
            Controls.Add(webView21);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "UserForm";
            Text = "UserForm";
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            sidePanel.ResumeLayout(false);
            sidePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Button btnLogout;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private ComboBox cBoxRoutes;
        private Label cBoxLabel;
        private Panel sidePanel;
        private Button btnPanel;
        private Label Archetype;
        private LinkLabel linkAboutUs;
        private Label Version;
    }
}