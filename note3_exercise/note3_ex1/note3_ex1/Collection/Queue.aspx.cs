using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex1
{
    public partial class Queue : System.Web.UI.Page
    {
        // P 40
        static int nextNum = 1;
        static Queue<int> PaiDui = new Queue<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowCount();
        }

        private void ShowCount()
        {
            Label1.Text = string.Format("目前尚有{0}人在等待，下個號碼是{1}", PaiDui.Count, nextNum);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            PaiDui.Enqueue(nextNum);
            nextNum += 1;
            ShowCount();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (PaiDui.Count == 0)
            {
                Response.Write("<script> alert('沒有人排隊') </script>");
                return;
            }

            int num = PaiDui.Dequeue();
            Response.Write("<script> alert('我處理了" + num + "號') </script>");
            ShowCount();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            PaiDui.Clear();
            nextNum = 1;
            ShowCount();
        }
    }
}