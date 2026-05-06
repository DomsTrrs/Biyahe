using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biyahe.UI
{
    public partial class MainForm : Form
    {
        public static Panel MainPanel;
        public MainForm()
        {
            InitializeComponent();
            MainPanel = pnlMain;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Dock = DockStyle.Fill;
            login.TopLevel = false;
            pnlMain.Controls.Clear(); 
            pnlMain.Controls.Add(login);
            login.Show();
        }
    }                                  
}
