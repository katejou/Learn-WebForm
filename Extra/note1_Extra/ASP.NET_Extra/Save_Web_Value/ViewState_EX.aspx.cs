using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Extra
{
    public partial class ViewState_EX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ViewState["Testing"] = "我是ViewState中的文字";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label1.Text = (string)ViewState["Testing"];
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewState_EX.aspx");
        }

        protected void new_sub_page(object sender, EventArgs e)
        {
            string page = "'ViewStateSubPage2.aspx'";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open(" + page + ",'_blank')", true);
        }
    }
}