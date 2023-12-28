using System;


namespace ASP.NET_EX1_.EX_12
{
    public partial class EX12_1_iis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Request.ServerVariables["SERVER_SOFTWARE"]);
        }
    }
}