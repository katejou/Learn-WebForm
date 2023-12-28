using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex3
{
    public partial class usingCustomCtrl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 335

            CustomControl1.currentCounter++;
            Label1.Text = CustomControl1.currentCounter.ToString();
        }

        protected void CustomControl1_Click(object sender, EventArgs e)
        {

        }
    }
}