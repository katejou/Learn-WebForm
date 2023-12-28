using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX6._4_
{
    public partial class ContentPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.QueryString["no"] == "2")
                 Page.MasterPageFile = "Master2.master";
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContentPage3.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContentPage2.aspx");
        }
    }
}