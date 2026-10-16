
using BusinessLayer;
using BusinessLayer.Models;
using DVLD.Forms;
using DVLD.Forms.Applications;
using DVLD.Presentation.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Presentation.Forms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ThemeManager.LoadTheme();

            string [] data=  RememberME.ReadInFile();
            if (data == null) { Application.Run(new frmLogin()); return;  }

            else if (Users.login(data[0], data[1]) != Users.LoginResult.Success) {  Application.Run(new frmLogin()); }
            else { Application.Run(new frmMainMenu()); }
        }

    }

}
