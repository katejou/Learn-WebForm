using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX2._1_
{
    public partial class Target1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Request.QueryString["myText"]);
        } // 起動這個頁面時，把呼喚我的那一頁，叫出他 QueryString 中的 myText 拿給我。
    }
}