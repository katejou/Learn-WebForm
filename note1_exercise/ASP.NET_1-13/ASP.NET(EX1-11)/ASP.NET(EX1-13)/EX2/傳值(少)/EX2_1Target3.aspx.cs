using System;


namespace ASP.NET_EX2._1_
{
    public partial class Target3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(PreviousPage.myText);  //   PreviousPage  設在前端 ︰  <%@ PreviousPageType VirtualPath= "EX2_1Source.aspx" %>
        }
    }
}