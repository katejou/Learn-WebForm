using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX2._1_
{
    public partial class Target2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  // Rquest.From
            Response.Write(Request.Form["TextBox1"]);
        } // 直接從來源頁的元件去拿值。
    }
}