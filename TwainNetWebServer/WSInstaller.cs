using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace TwainNetWebServer
{
    [RunInstaller(true)]
    public class WSInstaller : System.Configuration.Install.Installer
    {
        public WSInstaller()
        {
            ServiceProcessInstaller process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            ServiceInstaller serviceAdmin = new ServiceInstaller();
            serviceAdmin.StartType = ServiceStartMode.Automatic;
            serviceAdmin.ServiceName = Utility.Name;
            serviceAdmin.DisplayName = Utility.Name;
            Installers.Add(process);
            Installers.Add(serviceAdmin);

        }



    }


}
