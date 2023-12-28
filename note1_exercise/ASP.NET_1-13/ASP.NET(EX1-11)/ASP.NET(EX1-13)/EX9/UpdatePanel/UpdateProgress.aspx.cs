using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX9._2_
{
    public partial class EX9_3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToLongTimeString();
            //Label3.Text = DateTime.Now.ToLongTimeString();
        }

        private string GetData()
        {
            int r = new Random().Next(1, 11);
            return r.ToString();
        }

        protected void Timer1_Tick1(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);

            Label1.Text = DateTime.Now.ToLongTimeString();
            Label2.Text = GetData();
        }


        protected void Timer2_Tick2(object sender, EventArgs e)
        {  // 為什麼 5 秒後不會進入這個事件的常式中呢？只會跳到 Post Back 去更新 Label3 ， Label 4 的內容完全沒有顯示。
            System.Threading.Thread.Sleep(10000);

            Label3.Text = DateTime.Now.ToLongTimeString();
            Label4.Text = GetData();
        }
    }
}