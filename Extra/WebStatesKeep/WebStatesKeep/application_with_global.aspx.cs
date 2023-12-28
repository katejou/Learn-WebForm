using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex
{
    public partial class application_with_global : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P164
            lb2.Text = Application["counter"].ToString();

        }
    }
}