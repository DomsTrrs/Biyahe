using Biyahe.Models;
using Biyahe.Services;
using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;

namespace Biyahe.UI
{
    public partial class DriverForm : Form
    {
        private Driver _currDriver;

        private bool isAnimating = false;
        private bool isOpening = false;

        private int animationStep = 0;  // fewer steps = smoother in WinForms

        private const int SidebarWidth = 280;

        private Stopwatch animationWatch = new Stopwatch();
        private const int animationDuration = 300;
        public DriverForm(Driver driver)
        {
            InitializeComponent();
            _currDriver = driver;

            sidePanel.Visible = false;

            this.Controls.Add(sidePanel);
            sidePanel.BringToFront();

            // LIGHTWEIGHT smoothing only
            this.DoubleBuffered = true;

            ResetSidebarState();
            sidebarTimer.Interval = 15;
            sidebarTimer.Tick += SidebarTimer_Tick;
        }

        private void DriverForm_Load(object sender, EventArgs e)
        {
            if (_currDriver != null)
            {
                lblWelcome.Text = $"{_currDriver.FirstName}";
            }
            else
            {
                lblWelcome.Text = "No User...";
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you wish to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MainForm.LoadForm(new LoginForm());
            }
        }

        private void btnDrive_Click(object sender, EventArgs e)
        {
            if (btnDrive.Text == "DRIVE")
            {
                btnDrive.Text = "ON TRIP";
                btnDrive.BackColor = Color.FromArgb(255, 64, 64);
                btnDrive.NormalColor = Color.FromArgb(255, 64, 64);
                btnDrive.HoverColor = Color.FromArgb(201, 48, 48);
            }
            else
            {
                btnDrive.Text = "DRIVE";
                btnDrive.BackColor = Color.FromArgb(81, 112, 255);
                btnDrive.NormalColor = Color.FromArgb(81, 112, 255);
                btnDrive.HoverColor = Color.FromArgb(73, 96, 206);
            }
        }

        private void linkAboutUs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.LoadForm(new AboutUsForm(_currDriver));
        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            sidePanel.Visible = true;
            sidePanel.BringToFront();

            isAnimating = true;
            isOpening = true;

            animationWatch.Restart();
            sidebarTimer.Start();
        }

        private void ResetSidebarState()
        {
            isAnimating = false;
            isOpening = false;
            animationStep = 0;

            if (sidePanel != null)
            {
                sidePanel.Width = SidebarWidth;
                sidePanel.Left = -SidebarWidth; // hidden off-screen
                sidePanel.Visible = false;
            }
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            double elapsed = animationWatch.Elapsed.TotalMilliseconds;
            float progress = (float)(elapsed / animationDuration);

            if (progress >= 1f)
                progress = 1f;

            // Easing
            float eased;
            if (isOpening)
                eased = 1f - (float)Math.Pow(1f - progress, 3f);
            else
                eased = (float)Math.Pow(progress, 3f);

            // Position
            int targetX;
            if (isOpening)
                targetX = (int)(-SidebarWidth + (SidebarWidth * eased));
            else
                targetX = (int)(0 - (SidebarWidth * eased));

            sidePanel.Left = targetX;
            sidePanel.Invalidate();

            // Done
            if (progress >= 1f)
            {
                sidebarTimer.Stop();
                isAnimating = false;

                if (isOpening)
                    sidePanel.Left = 0;
                else
                {
                    sidePanel.Left = -SidebarWidth;
                    sidePanel.Visible = false;
                }
            }
        }

        private void btnSidePnlClose_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            isAnimating = true;
            isOpening = false;

            animationWatch.Restart();
            sidebarTimer.Start();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                return cp;
            }
        }

        protected override void DestroyHandle()
        {
            try { sidebarTimer?.Stop(); } catch { }
            base.DestroyHandle();
        }

        private void btnBoard_Click(object sender, EventArgs e)
        {

        }
    }
}
