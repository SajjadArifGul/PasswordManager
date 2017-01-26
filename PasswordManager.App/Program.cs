using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //setting DatabaseConnectionString from app.config file.
            Globals.DatabaseConnection.Instance().SetValue(Properties.Settings.Default["PasswordManagerDBConnection"].ToString());

            Application.Run(new Login());
        }
    }
}
