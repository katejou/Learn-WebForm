using System;


namespace ASP.NET_EX1_.EX_11
{
    public partial class errorlog_webConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            throw new Exception("Custom Error");
        }
    } 
}