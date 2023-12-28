using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Extra.Save_Web_Value
{
    public partial class PostTo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = Request.Form["TextBox1"];
            Response.Write(a);

            Label2.Text = Request.Form["text1"];
            Label3.Text = Request.Form["text2"];

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("PostForm.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string a = Request.Form["TextBox1"];
            Label1.Text = a;
        }
    }
}