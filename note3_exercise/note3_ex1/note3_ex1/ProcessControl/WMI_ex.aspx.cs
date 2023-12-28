using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management;


namespace note3_ex1.ProcessControl
{
    public partial class WMI_ex : System.Web.UI.Page
    {
        ManagementEventWatcher watcher;

        protected void Page_Load(object sender, EventArgs e)
        {
            // P 388
        }

        /// <summary>
        /// 開始監控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            WqlEventQuery equery = new WqlEventQuery(
            "_InstanceCreationEvent",
            new TimeSpan(0, 0, 2),
            "TargetInstance isa \"Win32_Account\"");
            watcher = new ManagementEventWatcher(equery);
            watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
            watcher.Start();  // 執行後會卡在這裡，說︰類別無效... 不知道是怎樣，我不實作了。
            Button1.Enabled = false;
            Button2.Enabled = true;
        }

        void watcher_EventArrived(Object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject mbo;
            mbo = (ManagementBaseObject)e.NewEvent;
            ManagementBaseObject serviceMO;
            serviceMO = (ManagementBaseObject)(mbo["TargetInstance"]);
            Label1.Text = $"新建立帳號︰{serviceMO["Name"]}\r\nSID:{serviceMO["SID"]}";
        }


        /// <summary>
        /// 停止監控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (watcher == null)
                return;

            watcher.Stop();
            Button1.Enabled = true;
            Button2.Enabled = false;

            
        }

        /// <summary>
        /// 建新帳號
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            //....
        }

        /// <summary>
        /// 刪新帳號
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button4_Click(object sender, EventArgs e)
        {
            //.....
        }
    }
}