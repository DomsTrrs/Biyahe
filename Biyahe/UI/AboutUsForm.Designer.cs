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
            labelAboutUs = new Label();
            linkLabelHome = new LinkLabel();
            SuspendLayout();
            // 
            // labelAboutUs
            // 
            labelAboutUs.AutoSize = true;
            labelAboutUs.Location = new Point(23, 20);
            labelAboutUs.Name = "labelAboutUs";
            labelAboutUs.Size = new Size(87, 25);
            labelAboutUs.TabIndex = 0;
            labelAboutUs.Text = "About Us";
            // 
            // linkLabelHome
            // 
            linkLabelHome.AutoSize = true;
            linkLabelHome.Location = new Point(116, 20);
            linkLabelHome.Name = "linkLabelHome";
            linkLabelHome.Size = new Size(98, 25);
            linkLabelHome.TabIndex = 1;
            linkLabelHome.TabStop = true;
            linkLabelHome.Text = "homepage";
            linkLabelHome.LinkClicked += linkLabelHome_LinkClicked;
            // 
            // AboutUsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(linkLabelHome);
            Controls.Add(labelAboutUs);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AboutUsForm";
            Text = "AboutUs";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelAboutUs;
        private LinkLabel linkLabelHome;
    }
}