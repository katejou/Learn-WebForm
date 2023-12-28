using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX6._3_
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static int times = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ++times;
            // 我強制地轉了型別, 推斷這邊的 Master 不是原本真正的 Master所產出 的 Class , 而是他的兒子。
            ((EX6_3)this.Master).TextValue = "我是被content page 1 所改的內容, 次數 ︰  " + times;
            // MasterPage 只有一個 Label 有 TextValue 所以才不會搞混？
        }
    }
}