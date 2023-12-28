using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX3._2_
{
    public partial class ASP_NET_EX3__2_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false) // 如果是第一次入這個頁面的話
            {
                string[] ary = new string[] { "成員一", "成員二", "成員三", "成員四", "成員五", "成員六" };
                lbSource.DataSource = ary;    // 將以上的串列加入這一個清單
                lbSource.DataBind();  // 把這些資料記憶下來？還是綁定？因為按下按鈕就PostBack就不會再做這件事了。
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lbSource.Items)  // 在左手邊的清單
            {
                if (item.Selected)  // 如果有被選中的話
                {
                    item.Selected = false; // 把選中的紀錄歸零
                    lbTarget.Items.Add(item); // 加入右邊的清單。
                }
            }
            foreach (ListItem item in lbTarget.Items)  // 在右手邊的清單
            {
                if (lbSource.Items.Contains(item))   // 如果左邊的清單有右手邊清單的元素
                {
                    lbSource.Items.Remove(item);   // 從左手邊刪去。
                }
            }
            
            // 就是從左邊的清單搬到右，直到左邊一個不剩的意思。

        }
    }
}