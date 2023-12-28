using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex3
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 306
            // 日曆顯示 > 選日期 > 出現日期
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            Label1.Text = Calendar1.SelectedDate.ToString("d"); // 這個簡短日期的 ToString要記住！
            Calendar1.Visible = false;
        }
        public string myData
        {
            get
            {
                return Label1.Text;
            }
        }
    }
}