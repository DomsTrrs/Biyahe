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
            panel1 = new Panel();
            roundedPanel2 = new RoundedPanel();
            pictureBox2 = new PictureBox();
            archetype = new Label();
            btnLogout = new RoundedButton();
            pictureBox1 = new PictureBox();
            version = new Label();
            linkAboutUs = new LinkLabel();
            sidebarTimer = new System.Windows.Forms.Timer(components);
            cBoxRoutes = new RoundComboBox();
            roundedPanel1 = new RoundedPanel();
            btnPanel = new PictureBox();
            pBoxNavbar = new PictureBox();
            cBoxLabel = new Label();
            roundedButton1 = new RoundedButton();
            roundedPanel3 = new RoundedPanel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            sidePanel.SuspendLayout();
            roundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            roundedPanel1.SuspendLayout();
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
            lblWelcome.Location = new Point(96, 16);
            lblWelcome.Margin = new Padding(2, 0, 2, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(27, 25);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "...";
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(618, 297);
            webView21.Margin = new Padding(2);
            webView21.Name = "webView21";
            webView21.Size = new Size(90, 27);
            webView21.TabIndex = 3;
            webView21.ZoomFactor = 1D;
            // 
            // sidePanel
            // 
            sidePanel.BackColor = Color.White;
            sidePanel.BorderStyle = BorderStyle.FixedSingle;
            sidePanel.Controls.Add(roundedPanel3);
            sidePanel.Controls.Add(panel1);
            sidePanel.Controls.Add(roundedPanel2);
            sidePanel.Controls.Add(btnLogout);
            sidePanel.Controls.Add(pictureBox1);
            sidePanel.Location = new Point(1, 1);
            sidePanel.Margin = new Padding(2);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(280, 671);
            sidePanel.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.Location = new Point(10, 317);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 2);
            panel1.TabIndex = 13;
            // 
            // roundedPanel2
            // 
            roundedPanel2.BackColor = Color.Transparent;
            roundedPanel2.Controls.Add(pictureBox2);
            roundedPanel2.Controls.Add(lblWelcome);
            roundedPanel2.Controls.Add(archetype);
            roundedPanel2.GlassBorderColor = Color.FromArgb(120, 255, 255, 255);
            roundedPanel2.GlassShineColor = Color.FromArgb(80, 255, 255, 255);
            roundedPanel2.GlassTintColor = Color.FromArgb(50, 255, 255, 255);
            roundedPanel2.Location = new Point(10, 190);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.PanelColor = Color.FromArgb(235, 239, 255);
            roundedPanel2.Size = new Size(250, 113);
            roundedPanel2.TabIndex = 13;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.profileIcon;
            pictureBox2.Location = new Point(6, 16);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(88, 84);
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
            archetype.Location = new Point(96, 70);
            archetype.Margin = new Padding(2, 0, 2, 0);
            archetype.Name = "archetype";
            archetype.Size = new Size(78, 20);
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
            btnLogout.Location = new Point(10, 579);
            btnLogout.Name = "btnLogout";
            btnLogout.NormalColor = Color.FromArgb(81, 112, 255);
            btnLogout.Size = new Size(250, 52);
            btnLogout.TabIndex = 11;
            btnLogout.Text = "LOGOUT";
            btnLogout.TextImageRelation = TextImageRelation.TextAboveImage;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.logo;
            pictureBox1.Location = new Point(45, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(168, 162);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // version
            // 
            version.AutoSize = true;
            version.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            version.ForeColor = Color.FromArgb(81, 112, 255);
            version.Location = new Point(472, 527);
            version.Margin = new Padding(2, 0, 2, 0);
            version.Name = "version";
            version.Size = new Size(119, 25);
            version.TabIndex = 4;
            version.Text = "Version: 0.0.1";
            // 
            // linkAboutUs
            // 
            linkAboutUs.AutoSize = true;
            linkAboutUs.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkAboutUs.ForeColor = Color.FromArgb(81, 112, 255);
            linkAboutUs.LinkBehavior = LinkBehavior.NeverUnderline;
            linkAboutUs.LinkColor = Color.FromArgb(81, 112, 255);
            linkAboutUs.Location = new Point(448, 409);
            linkAboutUs.Margin = new Padding(2, 0, 2, 0);
            linkAboutUs.Name = "linkAboutUs";
            linkAboutUs.Size = new Size(93, 25);
            linkAboutUs.TabIndex = 3;
            linkAboutUs.TabStop = true;
            linkAboutUs.Text = "About us ";
            linkAboutUs.LinkClicked += linkAboutUs_LinkClicked;
            // 
            // cBoxRoutes
            // 
            cBoxRoutes.BackColor = Color.Transparent;
            cBoxRoutes.BorderColor = Color.FromArgb(120, 255, 255, 255);
            cBoxRoutes.DataSource = null;
            cBoxRoutes.DisplayMember = null;
            cBoxRoutes.ForeColor = SystemColors.ControlText;
            cBoxRoutes.GlassShineColor = Color.FromArgb(70, 255, 255, 255);
            cBoxRoutes.GlassTintColor = Color.FromArgb(40, 255, 255, 255);
            cBoxRoutes.Location = new Point(748, 604);
            cBoxRoutes.Name = "cBoxRoutes";
            cBoxRoutes.SelectedIndex = -1;
            cBoxRoutes.Size = new Size(250, 50);
            cBoxRoutes.TabIndex = 8;
            cBoxRoutes.TextColor = Color.FromArgb(81, 112, 255);
            cBoxRoutes.ValueMember = null;
            // 
            // roundedPanel1
            // 
            roundedPanel1.BackgroundImage = Properties.Resources.bgImg;
            roundedPanel1.Controls.Add(btnPanel);
            roundedPanel1.Controls.Add(pBoxNavbar);
            roundedPanel1.GlassBorderColor = Color.FromArgb(120, 255, 255, 255);
            roundedPanel1.GlassShineColor = Color.FromArgb(80, 255, 255, 255);
            roundedPanel1.GlassTintColor = Color.FromArgb(50, 255, 255, 255);
            roundedPanel1.Location = new Point(44, 32);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.PanelColor = Color.Transparent;
            roundedPanel1.Size = new Size(1162, 59);
            roundedPanel1.TabIndex = 9;
            // 
            // btnPanel
            // 
            btnPanel.BackColor = Color.Transparent;
            btnPanel.Image = Properties.Resources.menuIcon;
            btnPanel.Location = new Point(21, 3);
            btnPanel.Name = "btnPanel";
            btnPanel.Size = new Size(52, 54);
            btnPanel.SizeMode = PictureBoxSizeMode.Zoom;
            btnPanel.TabIndex = 10;
            btnPanel.TabStop = false;
            // 
            // pBoxNavbar
            // 
            pBoxNavbar.BackColor = Color.Transparent;
            pBoxNavbar.Image = Properties.Resources.navbarLogo;
            pBoxNavbar.Location = new Point(976, -48);
            pBoxNavbar.Name = "pBoxNavbar";
            pBoxNavbar.Size = new Size(237, 160);
            pBoxNavbar.SizeMode = PictureBoxSizeMode.Zoom;
            pBoxNavbar.TabIndex = 10;
            pBoxNavbar.TabStop = false;
            // 
            // cBoxLabel
            // 
            cBoxLabel.AutoSize = true;
            cBoxLabel.BackColor = Color.Transparent;
            cBoxLabel.Location = new Point(763, 581);
            cBoxLabel.Name = "cBoxLabel";
            cBoxLabel.Size = new Size(116, 20);
            cBoxLabel.TabIndex = 5;
            cBoxLabel.Text = "Route Selected: ";
            // 
            // roundedButton1
            // 
            roundedButton1.Anchor = AnchorStyles.None;
            roundedButton1.BackColor = Color.FromArgb(81, 112, 255);
            roundedButton1.CornerRadiusBottomLeft = 10;
            roundedButton1.CornerRadiusBottomRight = 10;
            roundedButton1.CornerRadiusTopLeft = 10;
            roundedButton1.CornerRadiusTopRight = 10;
            roundedButton1.FlatAppearance.BorderSize = 0;
            roundedButton1.FlatStyle = FlatStyle.Flat;
            roundedButton1.Font = new Font("Impact", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            roundedButton1.ForeColor = Color.White;
            roundedButton1.HoverColor = Color.FromArgb(73, 96, 206);
            roundedButton1.Location = new Point(1038, 581);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.NormalColor = Color.FromArgb(81, 112, 255);
            roundedButton1.Size = new Size(188, 70);
            roundedButton1.TabIndex = 12;
            roundedButton1.Text = "QUEUE";
            roundedButton1.TextImageRelation = TextImageRelation.TextAboveImage;
            roundedButton1.UseVisualStyleBackColor = false;
            // 
            // roundedPanel3
            // 
            roundedPanel3.GlassBorderColor = Color.FromArgb(120, 255, 255, 255);
            roundedPanel3.GlassShineColor = Color.FromArgb(80, 255, 255, 255);
            roundedPanel3.GlassTintColor = Color.FromArgb(50, 255, 255, 255);
            roundedPanel3.Location = new Point(10, 335);
            roundedPanel3.Name = "roundedPanel3";
            roundedPanel3.Size = new Size(250, 57);
            roundedPanel3.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(841, 99);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 13;
            label1.Text = "label1";
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(roundedButton1);
            Controls.Add(version);
            Controls.Add(cBoxLabel);
            Controls.Add(linkAboutUs);
            Controls.Add(sidePanel);
            Controls.Add(roundedPanel1);
            Controls.Add(cBoxRoutes);
            Controls.Add(webView21);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "UserForm";
            Text = "UserForm";
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            sidePanel.ResumeLayout(false);
            roundedPanel2.ResumeLayout(false);
            roundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            roundedPanel1.ResumeLayout(false);
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
        private RoundedPanel roundedPanel1;
        private PictureBox pBoxNavbar;
        private PictureBox btnPanel;
        private PictureBox pictureBox1;
        private RoundedButton btnLogout;
        private Label cBoxLabel;
        private RoundedButton roundedButton1;
        private RoundedPanel roundedPanel2;
        private Panel panel1;
        private PictureBox pictureBox2;
        private RoundedPanel roundedPanel3;
        private Label label1;
    }
}