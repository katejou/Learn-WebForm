using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX3._3_
{

    public partial class ASP_NET_EX3__3_ : System.Web.UI.Page
    {

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Day.IsSelectable = !e.Day.IsWeekend;

            if (e.Day.Date == new DateTime(2008,11,15))
            {
                Label Ib = new Label();
                Ib.Text = "<br>生日";
                Ib.ForeColor = System.Drawing.Color.Red;
                e.Cell.Controls.Add(Ib);
            }

        }

            protected void Page_Load(object sender, EventArgs e)
        {

        }

    }
}