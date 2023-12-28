using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex
{
    public partial class ajax_dynamic_js_string : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P250
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string script = @"function SayHi(){ alert('Hi, I am new！'); $get('Label1').innerHTML = 'Hi, I am new here.';}";

            ScriptManager.RegisterClientScriptBlock(
            this,
            typeof(Page),
            "JScript",
            script,
            true);

        }
    }
}