using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX4._2_
{
    public partial class ASP_NET_EX4__2_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (int.Parse(args.Value) % 2 == 0)
                args.IsValid = true;
            else
                args.IsValid = false;
        }
    }
}