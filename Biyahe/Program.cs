using System.Windows.Forms;
using Biyahe.UI;

namespace BiyaheApp
{
    public static class Program
    {

        //FINAL PROJECT: BIYAHE!

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm()); 
        }
    }
}