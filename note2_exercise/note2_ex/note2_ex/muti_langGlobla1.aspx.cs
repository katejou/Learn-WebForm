using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex
{
    public partial class global_lang_res : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.UICulture = "ja-JP";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String message = Resources.LanguageResource.Zero;
            String script = "alert('" + message + "');"; 
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "mykey", script, true);
        }
    }
}