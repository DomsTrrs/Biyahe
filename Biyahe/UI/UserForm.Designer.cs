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
            components = new System.ComponentModel.Container();
            lblWelcome = new Label();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            sidePanel = new Panel();
            btnSidePnlClose = new Button();
            panel2 = new Panel();
            aboutUsPnl = new RoundedPanel();
            pictureBox3 = new PictureBox();
            linkAboutUs = new LinkLabel();
            version = new Label();
            panel1 = new Panel();
            userPnl = new RoundedPanel();
            pictureBox2 = new PictureBox();
            archetype = new Label();
            btnLogout = new RoundedButton();
            pictureBox1 = new PictureBox();
            sidebarTimer = new System.Windows.Forms.Timer(components);
            cBoxRoutes = new RoundComboBox();
            navbarPnl = new RoundedPanel();
            btnPanel = new PictureBox();
            pBoxNavbar = new PictureBox();
            cBoxLabel = new Label();
            btnQueue = new RoundedButton();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            sidePanel.SuspendLayout();
            aboutUsPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            userPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            navbarPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnPanel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pBoxNavbar).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.BackColor = Color.Transparent;
            lblWelcome.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.ForeColor = Color.FromArgb(81, 112, 255);
            lblWelcome.ImageAlign = ContentAlignment.MiddleLeft;
            lblWelcome.Location = new Point(120, 20);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(31, 30);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "...";
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(772, 371);
            webView21.Margin = new Padding(2);
            webView21.Name = "webView21";
            webView21.Size = new Size(112, 34);
            webView21.TabIndex = 3;
            webView21.ZoomFactor = 1D;
            // 
            // sidePanel
            // 
            sidePanel.BackColor = Color.White;
            sidePanel.BorderStyle = BorderStyle.FixedSingle;
            sidePanel.Controls.Add(btnSidePnlClose);
            sidePanel.Controls.Add(panel2);
            sidePanel.Controls.Add(aboutUsPnl);
            sidePanel.Controls.Add(version);
            sidePanel.Controls.Add(panel1);
            sidePanel.Controls.Add(userPnl);
            sidePanel.Controls.Add(btnLogout);
            sidePanel.Controls.Add(pictureBox1);
            sidePanel.Location = new Point(1, 1);
            sidePanel.Margin = new Padding(2);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(350, 838);
            sidePanel.TabIndex = 6;
            // 
            // btnSidePnlClose
            // 
            btnSidePnlClose.Location = new Point(289, 52);
            btnSidePnlClose.Margin = new Padding(4, 4, 4, 4);
            btnSidePnlClose.Name = "btnSidePnlClose";
            btnSidePnlClose.Size = new Size(36, 36);
            btnSidePnlClose.TabIndex = 13;
            btnSidePnlClose.UseVisualStyleBackColor = true;
            btnSidePnlClose.Click += btnSidePnlClose_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkGray;
            panel2.Location = new Point(12, 511);
            panel2.Margin = new Padding(4, 4, 4, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(312, 2);
            panel2.TabIndex = 14;
            // 
            // aboutUsPnl
            // 
            aboutUsPnl.Controls.Add(pictureBox3);
            aboutUsPnl.Controls.Add(linkAboutUs);
            aboutUsPnl.GlassBorderColor = Color.FromArgb(120, 255, 255, 255);
            aboutUsPnl.GlassShineColor = Color.FromArgb(80, 255, 255, 255);
            aboutUsPnl.GlassTintColor = Color.FromArgb(50, 255, 255, 255);
            aboutUsPnl.Location = new Point(12, 419);
            aboutUsPnl.Margin = new Padding(4, 4, 4, 4);
            aboutUsPnl.Name = "aboutUsPnl";
            aboutUsPnl.PanelColor = Color.FromArgb(73, 96, 206);
            aboutUsPnl.Size = new Size(312, 71);
            aboutUsPnl.TabIndex = 13;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.Image = Properties.Resources.infoIcon;
            pictureBox3.Location = new Point(45, 15);
            pictureBox3.Margin = new Padding(4, 4, 4, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(39, 42);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 14;
            pictureBox3.TabStop = false;
            // 
            // linkAboutUs
            // 
            linkAboutUs.AutoSize = true;
            linkAboutUs.BackColor = Color.Transparent;
            linkAboutUs.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkAboutUs.ForeColor = Color.FromArgb(81, 112, 255);
            linkAboutUs.LinkBehavior = LinkBehavior.NeverUnderline;
            linkAboutUs.LinkColor = Color.White;
            linkAboutUs.Location = new Point(90, 15);
            linkAboutUs.Margin = new Padding(2, 0, 2, 0);
            linkAboutUs.Name = "linkAboutUs";
            linkAboutUs.Size = new Size(152, 38);
            linkAboutUs.TabIndex = 3;
            linkAboutUs.TabStop = true;
            linkAboutUs.Text = "About us ";
            linkAboutUs.LinkClicked += linkAboutUs_LinkClicked;
            // 
            // version
            // 
            version.AutoSize = true;
            version.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            version.ForeColor = Color.FromArgb(81, 112, 255);
            version.Location = new Point(20, 531);
            version.Margin = new Padding(2, 0, 2, 0);
            version.Name = "version";
            version.Size = new Size(141, 30);
            version.TabIndex = 4;
            version.Text = "Version: 0.0.1";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.Location = new Point(12, 396);
            panel1.Margin = new Padding(4, 4, 4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(312, 2);
            panel1.TabIndex = 13;
            // 
            // userPnl
            // 
            userPnl.BackColor = Color.Transparent;
            userPnl.Controls.Add(pictureBox2);
            userPnl.Controls.Add(lblWelcome);
            userPnl.Controls.Add(archetype);
            userPnl.GlassBorderColor = Color.FromArgb(120, 255, 255, 255);
            userPnl.GlassShineColor = Color.FromArgb(80, 255, 255, 255);
            userPnl.GlassTintColor = Color.FromArgb(50, 255, 255, 255);
            userPnl.Location = new Point(12, 238);
            userPnl.Margin = new Padding(4, 4, 4, 4);
            userPnl.Name = "userPnl";
            userPnl.PanelColor = Color.FromArgb(235, 239, 255);
            userPnl.Size = new Size(312, 141);
            userPnl.TabIndex = 13;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.profileIcon;
            pictureBox2.Location = new Point(8, 20);
            pictureBox2.Margin = new Padding(4, 4, 4, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(110, 105);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            // 
            // archetype
            // 
            archetype.AutoSize = true;
            archetype.BackColor = Color.Transparent;
            archetype.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            archetype.ForeColor = Color.FromArgb(81, 112, 255);
            archetype.Location = new Point(120, 88);
            archetype.Margin = new Padding(2, 0, 2, 0);
            archetype.Name = "archetype";
            archetype.Size = new Size(96, 25);
            archetype.TabIndex = 2;
            archetype.Text = "Passenger";
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.None;
            btnLogout.BackColor = Color.FromArgb(81, 112, 255);
            btnLogout.CornerRadiusBottomLeft = 10;
            btnLogout.CornerRadiusBottomRight = 10;
            btnLogout.CornerRadiusTopLeft = 10;
            btnLogout.CornerRadiusTopRight = 10;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Impact", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.HoverColor = Color.FromArgb(73, 96, 206);
            btnLogout.Location = new Point(12, 724);
            btnLogout.Margin = new Padding(4, 4, 4, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.NormalColor = Color.FromArgb(81, 112, 255);
            btnLogout.Size = new Size(312, 65);
            btnLogout.TabIndex = 11;
            btnLogout.Text = "LOGOUT";
            btnLogout.TextImageRelation = TextImageRelation.TextAboveImage;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(12, -1);
            pictureBox1.Margin = new Padding(4, 4, 4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(301, 259);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // cBoxRoutes
            // 
            cBoxRoutes.BackColor = Color.Transparent;
            cBoxRoutes.DataSource = null;
            cBoxRoutes.DisplayMember = null;
            cBoxRoutes.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cBoxRoutes.ForeColor = Color.FromArgb(81, 112, 255);
            cBoxRoutes.Location = new Point(926, 761);
            cBoxRoutes.Margin = new Padding(4, 4, 4, 4);
            cBoxRoutes.Name = "cBoxRoutes";
            cBoxRoutes.SelectedIndex = -1;
            cBoxRoutes.Size = new Size(312, 52);
            cBoxRoutes.TabIndex = 8;
            cBoxRoutes.ValueMember = null;
            // 
            // navbarPnl
            // 
            navbarPnl.BackgroundImage = Properties.Resources.bgImg;
            navbarPnl.Controls.Add(btnPanel);
            navbarPnl.Controls.Add(pBoxNavbar);
            navbarPnl.GlassBorderColor = Color.FromArgb(120, 255, 255, 255);
            navbarPnl.GlassShineColor = Color.FromArgb(80, 255, 255, 255);
            navbarPnl.GlassTintColor = Color.FromArgb(50, 255, 255, 255);
            navbarPnl.Location = new Point(55, 40);
            navbarPnl.Margin = new Padding(4, 4, 4, 4);
            navbarPnl.Name = "navbarPnl";
            navbarPnl.PanelColor = Color.Transparent;
            navbarPnl.Size = new Size(1452, 74);
            navbarPnl.TabIndex = 9;
            // 
            // btnPanel
            // 
            btnPanel.BackColor = Color.Transparent;
            btnPanel.Image = Properties.Resources.menuIcon;
            btnPanel.Location = new Point(26, 4);
            btnPanel.Margin = new Padding(4, 4, 4, 4);
            btnPanel.Name = "btnPanel";
            btnPanel.Size = new Size(65, 68);
            btnPanel.SizeMode = PictureBoxSizeMode.Zoom;
            btnPanel.TabIndex = 10;
            btnPanel.TabStop = false;
            btnPanel.Click += btnPanel_Click;
            // 
            // pBoxNavbar
            // 
            pBoxNavbar.BackColor = Color.Transparent;
            pBoxNavbar.Image = Properties.Resources.navbarLogo;
            pBoxNavbar.Location = new Point(1220, -60);
            pBoxNavbar.Margin = new Padding(4, 4, 4, 4);
            pBoxNavbar.Name = "pBoxNavbar";
            pBoxNavbar.Size = new Size(296, 200);
            pBoxNavbar.SizeMode = PictureBoxSizeMode.Zoom;
            pBoxNavbar.TabIndex = 10;
            pBoxNavbar.TabStop = false;
            // 
            // cBoxLabel
            // 
            cBoxLabel.AutoSize = true;
            cBoxLabel.BackColor = Color.Transparent;
            cBoxLabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cBoxLabel.ForeColor = Color.FromArgb(81, 112, 255);
            cBoxLabel.Location = new Point(949, 726);
            cBoxLabel.Margin = new Padding(4, 0, 4, 0);
            cBoxLabel.Name = "cBoxLabel";
            cBoxLabel.Size = new Size(166, 30);
            cBoxLabel.TabIndex = 5;
            cBoxLabel.Text = "Route Selected: ";
            // 
            // btnQueue
            // 
            btnQueue.Anchor = AnchorStyles.None;
            btnQueue.BackColor = Color.FromArgb(81, 112, 255);
            btnQueue.CornerRadiusBottomLeft = 10;
            btnQueue.CornerRadiusBottomRight = 10;
            btnQueue.CornerRadiusTopLeft = 10;
            btnQueue.CornerRadiusTopRight = 10;
            btnQueue.FlatAppearance.BorderSize = 0;
            btnQueue.FlatStyle = FlatStyle.Flat;
            btnQueue.Font = new Font("Impact", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnQueue.ForeColor = Color.White;
            btnQueue.HoverColor = Color.FromArgb(73, 96, 206);
            btnQueue.Location = new Point(1298, 726);
            btnQueue.Margin = new Padding(4, 4, 4, 4);
            btnQueue.Name = "btnQueue";
            btnQueue.NormalColor = Color.FromArgb(81, 112, 255);
            btnQueue.Size = new Size(235, 88);
            btnQueue.TabIndex = 12;
            btnQueue.Text = "QUEUE";
            btnQueue.TextImageRelation = TextImageRelation.TextAboveImage;
            btnQueue.UseVisualStyleBackColor = false;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 841);
            ControlBox = false;
            Controls.Add(sidePanel);
            Controls.Add(btnQueue);
            Controls.Add(cBoxLabel);
            Controls.Add(navbarPnl);
            Controls.Add(cBoxRoutes);
            Controls.Add(webView21);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "UserForm";
            Text = "2222222222222222222222222222222222222222222222222222222";
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            sidePanel.ResumeLayout(false);
            sidePanel.PerformLayout();
            aboutUsPnl.ResumeLayout(false);
            aboutUsPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            userPnl.ResumeLayout(false);
            userPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            navbarPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnPanel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pBoxNavbar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Panel sidePanel;
        private Label archetype;
        private LinkLabel linkAboutUs;
        private Label version;
        private System.Windows.Forms.Timer sidebarTimer;
        private RoundComboBox cBoxRoutes;
        private RoundedPanel navbarPnl;
        private PictureBox pBoxNavbar;
        private PictureBox btnPanel;
        private PictureBox pictureBox1;
        private RoundedButton btnLogout;
        private Label cBoxLabel;
        private RoundedButton btnQueue;
        private RoundedPanel userPnl;
        private Panel panel1;
        private PictureBox pictureBox2;
        private RoundedPanel aboutUsPnl;
        private PictureBox pictureBox3;
        private Panel panel2;
        private Button btnSidePnlClose;
    }
}