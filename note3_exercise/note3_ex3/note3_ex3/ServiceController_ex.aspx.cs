using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace note3_ex3
{
    public partial class ServiceController_ex : System.Web.UI.Page
    {
        ServiceController sc = new ServiceController("WatchHDService"); // <-- 這個 ServiceName 和 DisplayName 不一樣 , 見 P 447  


        protected void Page_Load(object sender, EventArgs e) { }

        /// <summary>
        /// Start
        /// </summary>
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running);
                Label1.Text = sc.DisplayName + " 啟動完成";
            }
        }

        /// <summary>
        /// Stop
        /// </summary>
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (sc.Status == ServiceControllerStatus.Running)
            {
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped);
                Label1.Text = sc.DisplayName + " 停止";
            }
        }
    }
}