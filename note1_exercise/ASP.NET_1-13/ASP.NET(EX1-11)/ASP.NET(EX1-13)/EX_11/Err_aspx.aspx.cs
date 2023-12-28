using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX1_.EX_11
{
    public partial class Err_aspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object errPath = Request.QueryString["AspxErrorPath"];
            Label1.Text = errPath.ToString();

        }
    }
}