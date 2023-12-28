using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_NET_9_AJAX
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OutsideLabel.Text = System.DateTime.Now.ToString();
            InsideLabel.Text = System.DateTime.Now.ToString();
            InsideLabel2.Text = System.DateTime.Now.ToString();
        }

    }
}