namespace Biyahe.UI
{
    partial class AboutUsForm
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
            linkLabelHome = new LinkLabel();
            pictureBox1 = new PictureBox();
            homepagePnl = new RoundedPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            homepagePnl.SuspendLayout();
            SuspendLayout();
            // 
            // linkLabelHome
            // 
            linkLabelHome.ActiveLinkColor = Color.White;
            linkLabelHome.AutoSize = true;
            linkLabelHome.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkLabelHome.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelHome.LinkColor = Color.White;
            linkLabelHome.Location = new Point(32, 6);
            linkLabelHome.Margin = new Padding(2, 0, 2, 0);
            linkLabelHome.Name = "linkLabelHome";
            linkLabelHome.Size = new Size(105, 25);
            linkLabelHome.TabIndex = 1;
            linkLabelHome.TabStop = true;
            linkLabelHome.Text = "Homepage";
            linkLabelHome.VisitedLinkColor = Color.White;
            linkLabelHome.LinkClicked += linkLabelHome_LinkClicked;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.aboutUs;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1262, 673);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // homepagePnl
            // 
            homepagePnl.BackColor = Color.Transparent;
            homepagePnl.Controls.Add(linkLabelHome);
            homepagePnl.CornerRadiusBottomLeft = 10;
            homepagePnl.CornerRadiusBottomRight = 10;
            homepagePnl.CornerRadiusTopLeft = 10;
            homepagePnl.CornerRadiusTopRight = 10;
            homepagePnl.GlassBorderColor = Color.FromArgb(120, 255, 255, 255);
            homepagePnl.GlassShineColor = Color.FromArgb(80, 255, 255, 255);
            homepagePnl.GlassTintColor = Color.FromArgb(50, 255, 255, 255);
            homepagePnl.Location = new Point(439, 605);
            homepagePnl.Name = "homepagePnl";
            homepagePnl.PanelColor = Color.FromArgb(81, 112, 255);
            homepagePnl.Size = new Size(174, 38);
            homepagePnl.TabIndex = 3;
            // 
            // AboutUsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1262, 673);
            ControlBox = false;
            Controls.Add(homepagePnl);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "AboutUsForm";
            Text = "AboutUs";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            homepagePnl.ResumeLayout(false);
            homepagePnl.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private LinkLabel linkLabelHome;
        private PictureBox pictureBox1;
        private RoundedPanel homepagePnl;
    }
}