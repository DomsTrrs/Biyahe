using Biyahe.Models;
using Biyahe.Services;
using Biyahe.DataAccess;
using System.Text.Json;

using System.Diagnostics;


namespace Biyahe.UI
{
    public partial class UserForm : Form
    {
        private User _currUser;
        private UserRepository _userRepo = new UserRepository();
        private RouteService _routeService = new RouteService();
        private QueueService _queueService = new QueueService();

        private bool isAnimating = false;
        private bool isOpening = false;

        private int animationStep = 0;  // fewer steps = smoother in WinForms

        private const int SidebarWidth = 280;

        private Stopwatch animationWatch = new Stopwatch();
        private const int animationDuration = 300;

        public UserForm(User user)
        {
            InitializeComponent();
            cBoxRoutes.SelectedIndexChanged += cBoxRoutes_SelectedIndexChanged;
            sidePanel.Visible = false;

            this.Controls.Add(sidePanel);
            sidePanel.BringToFront();

            // LIGHTWEIGHT smoothing only
            this.DoubleBuffered = true;

            _currUser = user;
            ResetSidebarState();
            sidebarTimer.Interval = 15;
            sidebarTimer.Tick += SidebarTimer_Tick;
        }

        private void PassengerForm_Load(object sender, EventArgs e)
        {
            cBoxRoutes.DataSource = _routeService.GetActiveRoutes();
            cBoxRoutes.DisplayMember = "RouteName";
            cBoxRoutes.ValueMember = "RouteID";
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

        private async void UserForm_Load(object sender, EventArgs e)
        {
            if (_currUser != null)
            {
                lblWelcome.Text = $"{_currUser.FirstName}";
            }
            else
            {
                lblWelcome.Text = "No user...";
            }

            await webView21.EnsureCoreWebView2Async(null);

            if (webView21.IsDisposed || webView21.CoreWebView2 == null)
            {
                return;
            }

            webView21.CoreWebView2.Settings.IsGeneralAutofillEnabled = false;

            webView21.Dock = DockStyle.Fill;
            string mapPath = Path.Combine(Application.StartupPath, "Map", "map.html");
            webView21.Source = new Uri(mapPath);

            cBoxRoutes.DisplayMember = "RouteName";
            cBoxRoutes.ValueMember = "RouteID";
            cBoxRoutes.DataSource = _routeService.GetActiveRoutes();
            cBoxRoutes.SelectedIndex = -1;
        }


        private async void cBoxRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cBoxRoutes.SelectedItem == null)
            {
                return;
            }

            Routes selectedRoute = (Routes)cBoxRoutes.SelectedItem;


            cBoxLabel.Text = "Selected Route: " + selectedRoute.RouteName;

            string coords = _routeService.GetRouteStops(selectedRoute.RouteID);

            //MessageBox.Show(coords); used for debugging to check if the coordinates are being retrieved correctly

            if (string.IsNullOrWhiteSpace(coords))
            {
                MessageBox.Show("No coordinates found.");
                return;
            }

            coords = coords.Trim();

            if (coords.StartsWith("[[") == false)
            {
                coords = "[" + coords + "]";
            }

            string routeName = JsonSerializer.Serialize(selectedRoute.RouteName);

            string script = "drawRoute(" + coords + ", " + routeName + ");";

            await webView21.CoreWebView2.ExecuteScriptAsync(script);
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

        private void linkAboutUs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.LoadForm(new AboutUsForm());

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

        private void btnLogout_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Do you wish to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MainForm.LoadForm(new LoginForm());
                this.Hide();
                LoginForm lForm = new LoginForm();
                lForm.Dock = DockStyle.Fill;
                lForm.TopLevel = false;
                MainForm.MainPanel.Controls.Clear();
                MainForm.MainPanel.Controls.Add(lForm);
                lForm.Show();
            }
        }

        private void btnQueue_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Testing");
            if(btnQueue.Text == "QUEUE")
            {
                btnQueue.Text = "CANCEL";
            } 
            else
            {
                btnQueue.Text = "QUEUE";
            }

            if (cBoxRoutes.SelectedItem is not Routes selectedRoute)
            {
                MessageBox.Show("Please select a route first.");
                return;
            }

            try
            {

                bool isQueued = false; 

                if (btnQueue.Text == "CANCEL")
                {
                    isQueued = true;

                    int userId = _currUser.UserID;

                    var result = _queueService.JoinQueue(userId, selectedRoute.RouteID);

                    MessageBox.Show(
                        $"You are now queued for {selectedRoute.RouteName}.\nYour queue position is #{result.position}.",
                        "Queue Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                } else (btnQueue.Text == "QUEUE")
                {
                    isQueued = false;
                    int userId = _currUser.UserID;
                    _queueService.LeaveQueue(userId, selectedRoute.RouteID);
                    MessageBox.Show(
                        $"You have left the queue for {selectedRoute.RouteName}.",
                        "Queue Cancelled",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to join queue: " + ex.Message,
                    "Queue Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }

        private void sidePanel_Paint(object sender, PaintEventArgs e)
        {

        }





    }
}
