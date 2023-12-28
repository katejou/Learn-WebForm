using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace custom_test
{
    public partial class P1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddl_bill_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_bill_to.SelectedIndex != 0)
                pl_same.Visible = true;
            else
                pl_same.Visible = false;
        }

        protected void Last_Page(object sender, EventArgs e)
        {
            // 取消
        }

        protected void Next_Page(object sender, EventArgs e)
        {
            Response.Redirect("~/P2.aspx");
        }
    }
}