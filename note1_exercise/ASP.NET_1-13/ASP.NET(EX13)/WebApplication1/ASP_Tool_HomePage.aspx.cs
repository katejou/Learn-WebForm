﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ASP_Tool_HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!HttpContext.Current.User.Identity.IsAuthenticated)
            //    Response.Redirect("~/ASP_Tool_loginPage.aspx");
        }
    }
}