using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Extra
{
    public partial class Appcaltion_ex : System.Web.UI.Page
    {
        // https://ithelp.ithome.com.tw/articles/10222885

        protected void Page_Load(object sender, EventArgs e)
        {
            Application.Lock();//先把Application固定
            if (Application["visit"] == null) { Application["visit"] = 1; }
            else {
                long times = Convert.ToInt64(Application["visit"]);
                times++;
                Application["visit"] = times;
            }
            VisitingTimes.Text = Convert.ToString(Application["visit"]);
            Application.UnLock();
        }





    }
}