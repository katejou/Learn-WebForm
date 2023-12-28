using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace note3_ex3_WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer serviceTimer;

        public Service1()
        {
            InitializeComponent();

            serviceTimer = new System.Timers.Timer();
            serviceTimer.Elapsed += new
            System.Timers.ElapsedEventHandler(serviceTimer_Elapsed);
            serviceTimer.Interval = 60000;
        }

        protected override void OnStart(string[] args)
        {
            serviceTimer.Start();
        }

        protected override void OnStop()
        {
            serviceTimer.Stop();
        }

        void serviceTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            DriveInfo cDrive = new DriveInfo(@"C:\"); 
            EventLog.WriteEntry("目前C磁碟剩餘的空間  : " + cDrive.TotalFreeSpace);

        }
    }
}
