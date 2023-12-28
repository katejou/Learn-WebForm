using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 349
            CustomControl1.currentCounter++;
            Label1.Text = CustomControl1.currentCounter.ToString();
        }
    }
}