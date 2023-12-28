using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Extra
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NewDropDownList.Values.Add("1", "A");
                NewDropDownList.Values.Add("2", "B");
                NewDropDownList.Values.Add("3", "C");
                //用NewDropDownList.Text.ToString()取值
            }
        }
    }
}