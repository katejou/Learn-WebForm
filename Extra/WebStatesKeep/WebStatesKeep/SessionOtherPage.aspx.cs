using System;
using System.Web.UI;


namespace ASP.NET_Extra
{
    public partial class SessionOtherPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ShowSession.Text = Session["SessionSave"].ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["SessionSave"] = "第二頁的 Session 值";
            ShowSession.Text = Session["SessionSave"].ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string page = "'Session_EX.aspx'";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open(" + page + ",'_blank')", true);
        }
    }
}