using Biyahe.Models;
using Biyahe.Services;
using System.Text.Json;



namespace Biyahe.UI
{
    public partial class UserForm : Form
    {
        private User _currUser;
        private RouteService _routeService = new RouteService();
        private QueueService _queueService = new QueueService();

        private bool sidebarExpand = false;
        private const int SidebarExpandedWidth = 280;
        private const int SidebarCollapsedWidth = 0;
        private const int SidebarSpeed = 20;

        public UserForm(User user)
        {
            InitializeComponent();
            cBoxRoutes.SelectedIndexChanged += cBoxRoutes_SelectedIndexChanged;
            _currUser = user;
            sidePanel.Visible = false;
            sidePanel.Width = SidebarCollapsedWidth;

            sidebarTimer.Interval = 10;
            sidebarTimer.Tick += SidebarTimer_Tick;
        }

        private async void UserForm_Load(object sender, EventArgs e)
        {
            if (_currUser != null)
            {
                lblWelcome.Text = $"{_currUser.FirstName} {_currUser.MiddleName} {_currUser.LastName}";
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
            sidebarTimer.Start();
            sidePanel.Visible = true;
            sidePanel.BringToFront();
            sidebarExpand = false;
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand) // COLLAPSE MODE
            {
                int speed = SidebarSpeed;
                if (sidePanel.Width <= 50) speed = SidebarSpeed / 2;

                sidePanel.Width -= speed;

                if (sidePanel.Width <= SidebarCollapsedWidth)
                {
                    sidePanel.Width = SidebarCollapsedWidth;
                    sidebarTimer.Stop();
                    sidePanel.Visible = false;
                    return; // Early exit
                }
            }
            else // EXPAND MODE
            {
                int speed = SidebarSpeed;
                if (sidePanel.Width >= SidebarExpandedWidth - 20)
                    speed = SidebarSpeed / 2;

                sidePanel.Width += speed;

                // CHECK WIDTH FIRST - Higher priority clamping
                if (sidePanel.Width >= SidebarExpandedWidth)
                {
                    sidePanel.Width = SidebarExpandedWidth; // FORCE exact 250px
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                    return; // Early exit
                }
            }
        }

        private void linkAboutUs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.LoadForm(new AboutUsForm());

        }

        private void btnSidePnlClose_Click(object sender, EventArgs e)
        {
            sidebarExpand = true; // Start collapsing (true = collapsing)
            if (!sidebarTimer.Enabled)
                sidebarTimer.Start();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Do you wish to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
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

            if (cBoxRoutes.SelectedItem is not Routes selectedRoute)
            {
                MessageBox.Show("Please select a route first.");
                return;
            }

            try
            {
                int userId = _currUser.UserID; // replace with your logged-in user

                var result = _queueService.JoinQueue(userId, selectedRoute.RouteID);

                MessageBox.Show(
                    $"You are now queued for {selectedRoute.RouteName}.\nYour queue position is #{result.position}.",
                    "Queue Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
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





    }
}
