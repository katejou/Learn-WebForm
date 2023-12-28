using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX6._2_
{
    public partial class EX6_2 : System.Web.UI.MasterPage
    {
        static int times = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ++times;
            Label tmp = (Label)ContentPlaceHolder1.FindControl("Label1");
            tmp.Text = "Master Page 改變的 Holder 1 的 Label 1 內容  " +
                "次數 ︰ " + times;
        }
    }
}