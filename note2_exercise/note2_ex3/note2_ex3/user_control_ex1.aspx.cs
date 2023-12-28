using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex3
{
    public partial class user_control_ex1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 306
            // 日曆顯示 > 選日期 > 出現日期
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = MyCalendarl.myData; // MyCalendarl是我在這裡給這個引用所取的ID
        }
    }
}