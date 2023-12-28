using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ShowTextBoxONEbyOne : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void abt_Click(object sender, EventArgs e)
        {
            abt.Visible = false;

            PlaceHolder1.Visible = true;
            bbt_add.Visible = true;
            bbt_close.Visible = true;
        }

        protected void bbtadd_Click(object sender, EventArgs e)
        {
            bbt_add.Visible = false;
            bbt_close.Visible = false;

            PlaceHolder2.Visible = true;
            bbc_add.Visible = true;
            bbc_close.Visible = true;
        }

        protected void bbt_close_Click(object sender, EventArgs e)
        {
            btb.Text = "";
            PlaceHolder1.Visible = false;

            //PlaceHolder0.Visible = true;
            abt.Visible = true;
        }

        protected void bbc_add_Click(object sender, EventArgs e)
        {
            //  這會寫得非常非常長。 雖然很簡單。
        }

        protected void bbc_close_Click(object sender, EventArgs e)
        {
            ctb.Text = "";
            PlaceHolder2.Visible = false;
            bbt_add.Visible = true;
            bbt_close.Visible = true;
        }
    }
}