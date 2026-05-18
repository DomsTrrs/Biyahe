using Biyahe.DataAccess;
using Biyahe.Models;
using Biyahe.Services;
using System.Diagnostics;
using System.Text.Json;

namespace Biyahe.UI
{
    public partial class DriverForm : Form
    {
        private Driver _currDriver;
        private Routes? _selectedRoute;

        private DriverRepository _driverRepo = new DriverRepository();
        private QueueRepository _queueRepo = new QueueRepository();

        private RouteService _routeService = new RouteService();
        private DriverService _driverService = new DriverService();
        private QueueService _queueService = new QueueService();

        private bool isAnimating = false;
        private bool isOpening = false;

        private int animationStep = 0;
        private const int SidebarWidth = 280;

        private Stopwatch animationWatch = new Stopwatch();
        private const int animationDuration = 300;

        private int _currentRouteId;

        private System.Windows.Forms.Timer _locationTimer = new System.Windows.Forms.Timer();

        private record LocationMessage(string Type, double Lat, double Lng);

        public DriverForm(Driver driver)
        {
            InitializeComponent();

            _currDriver = driver;

            cBoxRoutes.SelectedIndexChanged += cBoxRoutes_SelectedIndexChanged;

            sidePanel.Visible = false;

            this.Controls.Add(sidePanel);
            sidePanel.BringToFront();

            this.DoubleBuffered = true;

            ResetSidebarState();

            sidebarTimer.Interval = 15;
            sidebarTimer.Tick += SidebarTimer_Tick;
        }

        private async void DriverForm_Load(object sender, EventArgs e)
        {
            if (_currDriver != null)
            {
                lblWelcome.Text = $"{_currDriver.FirstName}";
            }
            else
            {
                lblWelcome.Text = "No User...";
            }

            await webView21.EnsureCoreWebView2Async(null);

            if (webView21.IsDisposed || webView21.CoreWebView2 == null)
            {
                return;
            }

            webView21.CoreWebView2.Settings.IsGeneralAutofillEnabled = false;

            webView21.CoreWebView2.WebMessageReceived += (s, args) =>
            {
                var message = JsonSerializer.Deserialize<LocationMessage>(
                    args.WebMessageAsJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (message?.Type == "locationChanged")
                {
                    _driverRepo.UpdateLocation(
                        _currDriver.DriverID,
                        message.Lat,
                        message.Lng
                    );
                }
            };

            webView21.NavigationCompleted += async (s, args) =>
            {
                await webView21.CoreWebView2.ExecuteScriptAsync(
                    "startLocationWatch('driver');"
                );
            };

            webView21.Dock = DockStyle.Fill;

            string mapPath = Path.Combine(Application.StartupPath, "Map", "map.html");
            webView21.Source = new Uri(mapPath);

            StartUserLocationUpdates();

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

            _selectedRoute = (Routes)cBoxRoutes.SelectedItem;

            _currentRouteId = _selectedRoute.RouteID;

            cBoxLabel.Text = "Selected Route: " + _selectedRoute.RouteName;

            string coords = _routeService.GetRouteStops(_selectedRoute.RouteID);

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

            string routeName = JsonSerializer.Serialize(_selectedRoute.RouteName);

            string script = "drawRoute(" + coords + ", " + routeName + ");";

            await webView21.CoreWebView2.ExecuteScriptAsync(script);
        }

        private void StartUserLocationUpdates()
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

                var users = _queueRepo.GetQueuedUserLocationsByRoute(_currentRouteId);
                string json = JsonSerializer.Serialize(users);

                await webView21.CoreWebView2.ExecuteScriptAsync(
                    $"showUserLocations({json});"
                );
            };

            _locationTimer.Start();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Do you wish to logout?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                MainForm.LoadForm(new LoginForm());
            }
        }

        private void btnDrive_Click(object sender, EventArgs e)
        {
            if (cBoxRoutes.SelectedItem is not Routes selectedRoute)
            {
                MessageBox.Show("Please select a route first.");
                return;
            }

            if (btnDrive.Text == "DRIVE NOW")
            {
                _driverService.setOnTrip(
                    _currDriver.DriverID,
                    selectedRoute.RouteID,
                    true
                );

                btnDrive.Text = "ON TRIP";
                btnDrive.BackColor = Color.FromArgb(255, 64, 64);
                btnDrive.NormalColor = Color.FromArgb(255, 64, 64);
                btnDrive.HoverColor = Color.FromArgb(201, 48, 48);
            }
            else if (btnDrive.Text == "ON TRIP")
            {
                _driverService.unsetOnTrip(
                    _currDriver.DriverID,
                    null,
                    false
                );

                btnDrive.Text = "DRIVE NOW";
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
                sidePanel.Left = -SidebarWidth;
                sidePanel.Visible = false;
            }
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            double elapsed = animationWatch.Elapsed.TotalMilliseconds;
            float progress = (float)(elapsed / animationDuration);

            if (progress >= 1f)
            {
                progress = 1f;
            }

            float eased;

            if (isOpening)
            {
                eased = 1f - (float)Math.Pow(1f - progress, 3f);
            }
            else
            {
                eased = (float)Math.Pow(progress, 3f);
            }

            int targetX;

            if (isOpening)
            {
                targetX = (int)(-SidebarWidth + (SidebarWidth * eased));
            }
            else
            {
                targetX = (int)(0 - (SidebarWidth * eased));
            }

            sidePanel.Left = targetX;
            sidePanel.Invalidate();

            if (progress >= 1f)
            {
                sidebarTimer.Stop();
                isAnimating = false;

                if (isOpening)
                {
                    sidePanel.Left = 0;
                }
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
            try { _locationTimer?.Stop(); } catch { }

            base.DestroyHandle();
        }

        private void btnBoard_Click(object sender, EventArgs e)
        {
            if (cBoxRoutes.SelectedItem is not Routes selectedRoute)
            {
                MessageBox.Show("Please select a route first.");
                return;
            }

            if (_currDriver.MaxCapacity <= 0)
            {
                MessageBox.Show("Driver capacity is not set.");
                return;
            }

            var boarded = _queueService.BoardPassengers(
                selectedRoute.RouteID,
                _currDriver.DriverID,
                _currDriver.MaxCapacity
            );

            if (boarded.Count == 0)
            {
                MessageBox.Show("No passengers waiting for this route.");
                return;
            }

            MessageBox.Show($"Boarded {boarded.Count} passenger(s).");
        }
    }
}