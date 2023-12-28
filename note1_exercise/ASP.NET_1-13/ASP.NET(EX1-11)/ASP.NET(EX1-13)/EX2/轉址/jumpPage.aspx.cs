
using System;


namespace ASP.NET_EX2_
{
    public partial class ASP_Net_EX2_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("EX2_0Target.aspx");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("EX2_0Target.aspx");
        }


    }
}