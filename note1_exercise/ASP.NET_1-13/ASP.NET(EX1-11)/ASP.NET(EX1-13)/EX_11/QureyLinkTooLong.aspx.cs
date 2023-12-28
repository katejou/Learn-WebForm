using System;


namespace ASP.NET_EX1_.EX_11
{
    public partial class QureyLinkTooLong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)  // 放了這個，還是會不停的迴圈
            //{
            //    Response.Redirect("~/EX_11/QureyLinkTooLong.aspx?abc=1");
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/EX_11/QureyLinkTooLong.aspx?abc=1");
        }
    }
}