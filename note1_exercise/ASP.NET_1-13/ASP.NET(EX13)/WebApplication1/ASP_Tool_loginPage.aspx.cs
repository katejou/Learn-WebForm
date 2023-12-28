using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ASP_Login_Tool : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (Login1.UserName == "User_ASP_Tool" & Login1.Password == "PWD")
                e.Authenticated = true;
            else
                e.Authenticated = false;

        }
    }
}