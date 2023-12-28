using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex
{
    public partial class Session_Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string temp = "";
            if (Session["BookList"] != null)
                foreach (var book in (List<string>)Session["BookList"])
                    temp += book + "<br//>";
            Label1.Text = temp;

        }
    }
}