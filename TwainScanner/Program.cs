using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwainScanner
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


            String name = Process.GetCurrentProcess().ProcessName;
            Process[] localByName = Process.GetProcessesByName(name);
            if (localByName.Length > 1) Environment.Exit(0);

            Application.Run(new Form1());
        }
    }
}
