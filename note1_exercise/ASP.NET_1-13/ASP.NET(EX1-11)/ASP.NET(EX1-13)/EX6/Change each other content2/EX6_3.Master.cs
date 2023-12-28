using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX6._3_
{
    public partial class EX6_3 : System.Web.UI.MasterPage
    {
        public string TextValue { get { return Label1.Text; } set { Label1.Text = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}