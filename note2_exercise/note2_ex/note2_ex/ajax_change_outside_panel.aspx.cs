using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex
{
    public partial class ajax_change_outside_panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 220
            // 參考︰
            // https://docs.microsoft.com/zh-tw/dotnet/api/system.web.ui.scriptmanager.registerdataitem?view=netframework-4.8
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = System.DateTime.Now.ToShortDateString();
            Label2.Text = System.DateTime.Now.ToShortTimeString();
            ScriptManager1.RegisterDataItem(Label3, DateTime.Now.ToUniversalTime().DayOfYear.ToString());
        }
    }
}