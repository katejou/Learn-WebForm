using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex4
{
    public partial class cache_obj_ex2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 376 

            Label1.Text = "Page: " + System.DateTime.Now.ToString();

            Response.Cache.SetExpires(DateTime.Now.AddSeconds(10));
            Response.Cache.SetCacheability(HttpCacheability.Public);
            Response.Cache.SetValidUntilExpires(true);

            // https://docs.microsoft.com/zh-tw/previous-versions/aspnet/y18he7cw(v=vs.100)?redirectedfrom=MSDN

            // https://stackoverflow.com/a/17983775/14169082
            // 這一句也非常重要，但是官網沒有提，PDF 也沒有說。

            Response.Cache.VaryByParams.IgnoreParams = true; // in case we are not using any VaryByParams parameter.
            // 前端不放 tag 的時候，要加這一句。
        }
    }
}