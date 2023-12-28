using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Extra
{
    public partial class ViewStateSubPage2 : System.Web.UI.Page
    {
        static int howManySubPage = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                howManySubPage++;
                Label1.Text = howManySubPage.ToString();
                ViewState["AddNumber"] = 0;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int vn = Convert.ToInt32(ViewState["AddNumber"]);
            Label2.Text = (++vn).ToString();
            ViewState["AddNumber"] = vn;
        }
    }
}