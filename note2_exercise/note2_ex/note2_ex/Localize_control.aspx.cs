using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex
{
    public partial class Localize_control : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P151 見前端
        }

        protected void bt1_Click(object sender, EventArgs e)
        {
            Localize3.Text = "Welcome to ASP.NET!! This is localized text.";
        }
    }
}