using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX5._3_
{
    public partial class ASP_NET_EX5__3_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String data = TextBox1.Text;

            if (data.Length == 0)
            {

                Trace.Warn("My trace data", "No data input! !");
            }
            else
            {
                Trace.Write("My trace data", "Data = " + data);
            }
        }
    }
}