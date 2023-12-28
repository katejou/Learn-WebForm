using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex3
{
    public partial class custom_control_compo_css : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 363
            ProductControl1.ProductID = "A001";
            ProductControl1.ProductName = "ASP.NET";
            ProductControl1.UnitPrice = 30;
            ProductControl1.DataBind();

            //ProductControl2.txt.Text = "txt";

        }
    }
}