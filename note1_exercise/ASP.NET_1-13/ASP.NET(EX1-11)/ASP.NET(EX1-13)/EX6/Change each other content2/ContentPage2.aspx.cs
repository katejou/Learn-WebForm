using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX6._3_
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        static int times = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {   ++times;
            Master.TextValue = "我是被content page 2 所改的內容, 次數 ︰ " + times;
        }
    }
}