using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Extra
{
    public partial class Context_later : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)  // 如果不加這一行，在 「回去上一頁」 的 ButtonClick 方法進行前，到了這一個Page Load, 就出錯了，因為這次的「上一頁」是它自己，而它的類型並不是Context_former
            {
                try
                {
                    //转换一下即可获得前一页面中输入的数据
                    Context_former queryPage = (Context_former)Context.Handler;    //注意：引用页面句柄
                    Response.Write("取出前頁的屬性 : <br/>");
                    Response.Write("SomeAttribute：");
                    Response.Write(queryPage.SomeAttribute);
                }
                catch
                {
                    Response.Write("Error get data from parent transfer page!");
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Context_former.aspx");
        }
    }
}