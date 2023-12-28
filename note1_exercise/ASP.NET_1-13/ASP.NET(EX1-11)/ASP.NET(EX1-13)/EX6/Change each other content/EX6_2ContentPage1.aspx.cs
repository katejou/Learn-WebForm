using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX6._2_
{
    public partial class EX6_2ContentPage1 : System.Web.UI.Page
    {
        static int times = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            times++;
            Label tmp = (Label)Master.FindControl("Label1");
            tmp.Text = "Content Page 1 改變 Master Page 的 Label 1 內容"
                + " 次數  :   "+ times;

        }
    }
}