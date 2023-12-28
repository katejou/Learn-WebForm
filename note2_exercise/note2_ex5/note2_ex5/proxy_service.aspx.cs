using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex5
{
    public partial class proxy_service : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient ws = new ServiceReference1.WebService1SoapClient();
            Response.Write(ws.HelloWorld(DateTime.Now.ToString("F")));
        }
    }
}