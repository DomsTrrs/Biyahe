using Biyahe.DataAccess;
using Biyahe.Models;
using Biyahe.Services;
using System.Diagnostics;
using System.Text.Json;


namespace Biyahe.UI
{
    public partial class UserForm : Form
    {
        private User _currUser;
        private UserRepository _userRepo = new UserRepository();
        private DriverRepository _driverRepo = new DriverRepository();

        private RouteService _routeService = new RouteService();
        private QueueService _queueService = new QueueService();


        private bool isAnimating = false;
        private bool isOpening = false;

        private int animationStep = 0;

        private const int SidebarWidth = 280;

        private Stopwatch animationWatch = new Stopwatch();
        private const int animationDuration = 300;

        //other variables 
        private int _currentUserId;
        private int _currentRouteId;
        private int _currentQueueId;
        private string _currentRouteName;


        private record LocationMessage(string Type, double Lat, double Lng);
        private System.Windows.Forms.Timer _locationTimer = new System.Windows.Forms.Timer();


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

        private void ResetSidebarState()
        {
            isAnimating = false;
            isOpening = false;
            animationStep = 0;

            if (sidePanel != null)
            {
                sidePanel.Width = SidebarWidth;
                sidePanel.Left = -SidebarWidth;
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

            webView21.CoreWebView2.WebMessageReceived += (s, args) =>
            {
                var message = JsonSerializer.Deserialize<LocationMessage>(
                    args.WebMessageAsJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (message?.Type == "locationChanged")
                {
                    _userRepo.UpdateLocation(_currUser.UserID, message.Lat, message.Lng);
                }
            };

            webView21.NavigationCompleted += async (s, args) =>
            {
                await webView21.CoreWebView2.ExecuteScriptAsync("startLocationWatch('user');");
            };

            if (webView21.IsDisposed || webView21.CoreWebView2 == null)
            {
                return;
            }

            webView21.CoreWebView2.Settings.IsGeneralAutofillEnabled = false;

            webView21.Dock = DockStyle.Fill;
            string mapPath = Path.Combine(Application.StartupPath, "Map", "map.html");
            webView21.Source = new Uri(mapPath);
            StartDriverLocationUpdates();

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
            _currentRouteId = selectedRoute.RouteID;


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
            MainForm.LoadForm(new AboutUsForm(_currUser));

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
            try { _locationTimer?.Stop(); } catch { }

            base.DestroyHandle();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Do you wish to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MainForm.LoadForm(new LoginForm());
            }
        }

        private void btnQueue_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = _currUser.UserID;

                if (btnQueue.Text == "QUEUE")
                {
                    if (cBoxRoutes.SelectedItem is not Routes selectedRoute)
                    {
                        MessageBox.Show("Please select a route first.");
                        return;
                    }

                    var result = _queueService.JoinQueue(userId, selectedRoute.RouteID);

                    _currentUserId = userId;
                    _currentRouteId = selectedRoute.RouteID;
                    _currentRouteName = selectedRoute.RouteName;
                    _currentQueueId = result.queueId;

                    btnQueue.Text = "CANCEL";
                    btnQueue.BackColor = Color.FromArgb(255, 64, 64);
                    btnQueue.NormalColor = Color.FromArgb(255, 64, 64);
                    btnQueue.HoverColor = Color.FromArgb(201, 48, 48);

                    cBoxRoutes.Enabled = false;

                    MessageBox.Show(
                        $"You are now queued for {_currentRouteName}.\nYour queue position is #{result.position}.",
                        "Queue Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else if (btnQueue.Text == "CANCEL")
                {
                    if (_currentQueueId == 0)
                    {
                        MessageBox.Show("No active queue found.");
                        return;
                    }

                    _queueService.CancelQueue(_currentQueueId, _currentRouteId);

                    MessageBox.Show(
                        $"You have left the queue for {_currentRouteName}.",
                        "Queue Cancelled",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    _currentUserId = 0;
                    _currentRouteId = 0;
                    _currentQueueId = 0;
                    _currentRouteName = "";

                    btnQueue.Text = "QUEUE";
                    btnQueue.BackColor = Color.FromArgb(81, 112, 255);
                    btnQueue.NormalColor = Color.FromArgb(81, 112, 255);
                    btnQueue.HoverColor = Color.FromArgb(73, 96, 206);

                    cBoxRoutes.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Queue action failed: " + ex.Message,
                    "Queue Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void StartDriverLocationUpdates()
        {
            _locationTimer.Interval = 3000;

            _locationTimer.Tick += async (s, e) =>
            {
                if (_currentRouteId == 0)
                {
                    return;
                }

                if (webView21.IsDisposed || webView21.CoreWebView2 == null)
                {
                    return;
                }

                var drivers = _driverRepo.GetActiveDriverLocationsByRoute(_currentRouteId);
                string json = JsonSerializer.Serialize(drivers);

                await webView21.CoreWebView2.ExecuteScriptAsync(
                    $"showDriverLocations({json});"
                );
            };

            _locationTimer.Start();
        }

        private void btnUnboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentQueueId == 0)
                {
                    MessageBox.Show(
                        "You have no active boarded trip.",
                        "Unboard",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                DialogResult result = MessageBox.Show(
                    "Do you want to unboard from this trip?",
                    "Unboard Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result != DialogResult.Yes)
                {
                    return;
                }

                bool unboarded = _queueService.UnboardPassenger(
                    _currentQueueId,
                    _currUser.UserID
                );

                if (!unboarded)
                {
                    MessageBox.Show(
                        "You can only unboard after the driver has boarded you.",
                        "Unboard Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                MessageBox.Show(
                    $"You have unboarded from {_currentRouteName}.",
                    "Unboarded",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                _currentUserId = 0;
                _currentQueueId = 0;
                _currentRouteName = "";

                btnQueue.Text = "QUEUE";
                btnQueue.BackColor = Color.FromArgb(81, 112, 255);
                btnQueue.NormalColor = Color.FromArgb(81, 112, 255);
                btnQueue.HoverColor = Color.FromArgb(73, 96, 206);

                cBoxRoutes.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unboard failed: " + ex.Message,
                    "Unboard Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

    }
}