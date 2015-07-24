using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using NTwain;
using NTwain.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwainNetWebServer
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        private System.Diagnostics.EventLog eventLog1;

        static readonly TwainSession twain = InitTwain();

        private static TwainSession InitTwain()
        {
            var twain = new TwainSession(TWIdentity.CreateFromAssembly(DataGroups.Image, Assembly.GetExecutingAssembly()));
            twain.TransferReady += (s, e) =>
            {
                Console.WriteLine("Got xfer ready on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            };

            twain.SourceDisabled += (s, e) =>
            {
                Console.WriteLine("Source disabled on thread {0}.", Thread.CurrentThread.ManagedThreadId);
                var rc = twain.CurrentSource.Close();
                rc = twain.Close();
            };
            return twain;
        }



        protected override void OnStart(string[] args)
        {
            eventLog1 = new System.Diagnostics.EventLog();

            if (!System.Diagnostics.EventLog.SourceExists(Utility.Name))
            {
                System.Diagnostics.EventLog.CreateEventSource(
                    Utility.Name, "Application");
            }

            eventLog1.Source = Utility.Name;
            eventLog1.Log = "Application";

            eventLog1.WriteEntry("In OnStart");
            string url = "http://localhost:8080";
            WebApp.Start(url);

        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("In OnStop");
        }

        public class MyHub : Hub
        {
            public void GetList(string id)
            {
                var rc = twain.Open();
                var list = twain.ToList();
                Clients.Client(id).addMessage(list.Select(i => i.Name));
                twain.Close();
            }

            public void Scan(string id, string name)
            {
                var rc = twain.Open();

                if (rc == ReturnCode.Success)
                {
                    var hit = twain.FirstOrDefault(s => string.Equals(s.Name, name));

                    if (hit == null)
                    {
                        Clients.Client(id).scanresponse("The sample source \"" + name + "\" is not installed.");
                        twain.Close();
                    }
                    else
                    {
                        rc = hit.Open();

                        if (rc == ReturnCode.Success)
                        {
                            Clients.Client(id).scanresponse("Starting capture from the sample source...");
                            rc = hit.Enable(SourceEnableMode.NoUI, false, IntPtr.Zero);

                            twain.DataTransferred += (s, e) =>
                            {
                                //var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                                // Context.ConnectionId;

                                if (e.NativeData != IntPtr.Zero)
                                {
                                    Clients.Client(id).scanresponse("SUCCESS! Got twain data on thread {0}.", Thread.CurrentThread.ManagedThreadId);

                                    // example on getting ext image info
                                    var infos = e.GetExtImageInfo(ExtendedImageInfo.Camera).Where(it => it.ReturnCode == ReturnCode.Success);
                                    foreach (var it in infos)
                                    {
                                        var values = it.ReadValues();
                                        PlatformInfo.Current.Log.Info(string.Format("{0} = {1}", it.InfoID, values.FirstOrDefault()));
                                        break;
                                    }

                                    // handle image data
                                    byte[] img = null;
                                    if (e.NativeData != IntPtr.Zero)
                                    {
                                        var stream = e.GetNativeImageStream();
                                        if (stream != null)
                                        {
                                            using (MemoryStream ms = new MemoryStream())
                                            {
                                                stream.CopyTo(ms);
                                                img = ms.ToArray();
                                            }
                                        }
                                    }
                                    else if (!string.IsNullOrEmpty(e.FileDataPath))
                                    {
                                        img = File.ReadAllBytes(e.FileDataPath);
                                    }

                                    //File.WriteAllBytes(@"C:\temp\sample.jpg", img);

                                    var base64 = Convert.ToBase64String(img);

                                    Clients.Client(id).scandata(base64);
                                }
                                else
                                {
                                    Clients.Client(id).scanresponse("BUMMER! No twain data on thread {0}.", Thread.CurrentThread.ManagedThreadId);
                                }
                            };
                        }
                        else
                        {
                            twain.Close();
                        }
                    }
                }
                else
                {
                    Clients.Client(id).scanresponse("Failed to open dsm with rc={0}!", rc);
                }
            }
        }
    }
}
