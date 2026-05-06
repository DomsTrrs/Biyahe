using System.Windows.Forms;
using Biyahe.UI;

namespace BiyaheApp
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm()); 
        }
    }
}