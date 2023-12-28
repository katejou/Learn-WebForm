using System;

using System.Web.UI.WebControls;

namespace ASP.NET_EX2._1_
{
    public partial class Target4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox tmp = (TextBox)PreviousPage.FindControl("TextBox1");
            Response.Write(tmp.Text);
        }  // 第四種方法，取前頁的某個元件，雖然要先知道是什麼元件類型。
    }
}