using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using note2_ex.App_LocalResources;

namespace note2_ex.Properties
{
    public partial class muti_langLocal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P137-138  依着筆記做不下去…
            // 跳到 P140 做不下去…
            // 參考︰
            // https://dotblogs.com.tw/yc421206/2015/11/27/asp_net_multiple_language_local_global_resource
            // 前半部份都寫在前端。
            Lb2.Text = GetLocalResourceObject("Name").ToString();
            // 記得要using
            //Lb3.Text = muti_langLocal_aspx.Label1Res_Text.ToString();
            // 上行會在執行時有錯誤，但我不想研究了，至今還沒有成功切到另一個語言的資源檔…
        }
    }
}