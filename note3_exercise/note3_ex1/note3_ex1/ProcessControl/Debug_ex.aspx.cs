using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace note3_ex1.ProcessControl
{
    public partial class Debug_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Debug.Assert(!string.IsNullOrEmpty(TextBox1.Text),"必輸輸入TextBox");
            // 會跳出一個系統的窗戶，
        }
    }
}