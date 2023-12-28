using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex4
{
    public partial class cache_profile_ex1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 375 

            Label1.Text = "Page: " + System.DateTime.Now.ToString();

        }
    }
}