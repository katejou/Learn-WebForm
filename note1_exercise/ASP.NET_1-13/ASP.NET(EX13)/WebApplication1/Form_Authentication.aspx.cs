using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Form_Authentication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "User_FormAu" || TextBox2.Text == "PWD")
            {
                FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, false);
            }
            else
            {
                Label1.Text = "帳密有誤";
            }
        }
    }
}