using System;


namespace ASP.NET_EX1_.EX_11
{
    public partial class CodeJumpPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Code 302 
            //throw new Exception(" go to hahaha.");

            // Code 404 FileNotFound
            //Response.Redirect("noWhere.aspx");
        }
    }
}