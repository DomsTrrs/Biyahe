using Biyahe.Models;
using Biyahe.Services;


namespace Biyahe.UI
{
    public partial class UserForm : Form
    {
        private User _currUser;
        private RouteService _routeService = new RouteService();
        public UserForm(User user)
        {
            InitializeComponent();
            _currUser = user;
            sidePanel.Visible = false;
        }

        private async void UserForm_Load(object sender, EventArgs e)
        {
            if (_currUser != null)
            {
                lblWelcome.Text = $"Welcome, {_currUser.FirstName}!";
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

            cBoxRoutes.DataSource = _routeService.GetActiveRoutes();
            cBoxRoutes.DisplayMember = "RouteName";
            cBoxRoutes.ValueMember = "RouteID";
            cBoxRoutes.SelectedIndex = -1;
        }

        private void CoreWebView2_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            // Map is fully loaded — ExecuteScriptAsync is now safe to use
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm lForm = new LoginForm();
            lForm.Dock = DockStyle.Fill;
            lForm.TopLevel = false;
            MainForm.MainPanel.Controls.Clear();
            MainForm.MainPanel.Controls.Add(lForm);
            lForm.Show();
        }

        private async void cBoxRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxRoutes.SelectedItem == null)
            {
                cBoxRoutes.Text = "Selected Route: None";
                return;
            }

            Routes selectedRoute = (Routes)cBoxRoutes.SelectedItem;
            cBoxLabel.Text = $"Selected Route: {selectedRoute.RouteName}";

            string coords = _routeService.GetRouteStops(selectedRoute.RouteID);

            //MessageBox.Show(coords);

            await webView21.CoreWebView2.ExecuteScriptAsync(
            $"drawRoute([{coords}], '{selectedRoute.RouteName}')"
            );


        }

        private void btnPanel_Click(object sender, EventArgs e)
        {
            sidePanel.Visible = !sidePanel.Visible;
        }

        private void linkAboutUs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            AboutUsForm aForm = new AboutUsForm();
            aForm.Dock = DockStyle.Fill;
            aForm.TopLevel = false;
            MainForm.MainPanel.Controls.Clear();
            MainForm.MainPanel.Controls.Add(aForm);
            aForm.Show();

        }
    }
}
