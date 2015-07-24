using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwainNetWebServer.Installer;

namespace TwainNetWebServer
{
    static class Program
    {
        //http://superuser.com/questions/465726/run-windows-services-without-administrator-privileges
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            bool _IsInstalled = false;
            bool serviceStarting = false; // Thanks to SMESSER's implementation V2.0
            string SERVICE_NAME = Utility.Name;

            var service = ServiceController.GetServices().FirstOrDefault(i => i.ServiceName.Equals(SERVICE_NAME));

            if(service != null)
            {
                _IsInstalled = true;
                if (service.Status == ServiceControllerStatus.StartPending)
                {
                    // If the status is StartPending then the service was started via the SCM             
                    serviceStarting = true;
                }
            }

            if (!serviceStarting)
            {
                if (_IsInstalled)
                {
                    // Thanks to PIEBALDconsult's Concern V2.0
                    DialogResult dr = new DialogResult();
                    dr = MessageBox.Show("Do you REALLY like to uninstall the " + SERVICE_NAME + "?", "Danger", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        if(SelfInstaller.UninstallMe())
                        {
                            MessageBox.Show("Successfully uninstalled the " + SERVICE_NAME, "Status",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Impossible to uninstall", "Danger");
                        }
                    }
                }
                else
                {
                    DialogResult dr = new DialogResult();
                    dr = MessageBox.Show("Do you REALLY like to install the " + SERVICE_NAME + "?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        if(SelfInstaller.InstallMe())
                        {
                            MessageBox.Show("Successfully installed the " + SERVICE_NAME, "Status",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("The service should be run under administration rights", "Danger");
                        }
                    }
                }
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                { 
                    new Service1() 
                };
                    ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
