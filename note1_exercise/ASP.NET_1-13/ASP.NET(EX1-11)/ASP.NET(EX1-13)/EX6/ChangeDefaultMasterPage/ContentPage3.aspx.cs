using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX6._4_
{
    public partial class ContentPage3 : System.Web.UI.Page
    {
        public string MasterPageNumber { get { return "1"; } }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContentPage1.aspx?no=" + MasterPageNumber);
        }
    }
}