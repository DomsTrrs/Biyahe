using System;
using System.Drawing.Text;
using System.Windows.Forms;
using Biyahe.Models;
using Biyahe.Services;

namespace Biyahe.UI
{
    public partial class UserForm : Form
    {
        private User _currUser;
        private RouteService rService = new RouteService();
        public UserForm(User user)
        {
            InitializeComponent();
            _currUser = user;
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

            string mapPath = Path.Combine(Application.StartupPath, "Map", "map.html");

            webView21.Source = new Uri(mapPath);
            webView21.Dock = DockStyle.Fill;

            cBoxRoutes.DataSource = rService.GetActiveRoutes();
            cBoxRoutes.DisplayMember = "RouteName";
            cBoxRoutes.ValueMember = "RouteID";

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
            string StartPoint = selectedRoute.StartPoint;
            string EndPoint = selectedRoute.EndPoint;
            cBoxLabel.Text = $"Selected Route: {selectedRoute.RouteName}";

            
        }
    }
}
