using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX3._6_
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GroupABCMethod(sender,Button1.CommandName);
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            GroupABCMethod(sender, Button2.CommandName);
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            GroupABCMethod(sender, Button3.CommandName);
        }

        protected void GroupABCMethod(object sender, string CommandName)
        {
            switch (CommandName)
            {
                case "IamA":
                    Label1.Text = "A";
                    Response.Write("A");
                    break;
                case "IamB":
                    Label1.Text = "B";
                    Response.Write("B");
                    break;
                case "IamC":
                    Label1.Text = "C";
                    Response.Write("C");
                    break;
                    // Response.Write() 也是不會累績的，因為每次 POST BACK 的時候，都會清空。 
            }
        }


    }
}