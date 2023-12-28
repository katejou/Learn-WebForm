using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX4._4_
{
    public partial class ASP_NET_EX4__4_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            Validate("G1");
            if (this.IsPostBack)
            {
                Validate("G2");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Validate();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // G3 的驗證
        }
    }
}