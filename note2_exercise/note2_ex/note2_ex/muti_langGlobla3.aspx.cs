using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;

namespace note2_ex
{
    public partial class muti_lang2withfiles : System.Web.UI.Page
    {
        /// <summary>
        /// 它比PageLoad先進行
        /// </summary>
        protected override void InitializeCulture()
        {
            // 1.代表第一次載入
            // 2.代表第二次載入
            // 後面的數字，是發生的先後次序，用F9測過。

            if (Session["language"] != null)
            {
                // 2.5
                Page.UICulture = Session["language"].ToString();
            }
            else
            {
                // 1.1
                // 2.1
            }
        }

        /// <summary>
        /// 它比PageLoad後進行
        /// </summary>
        protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //2.3
            Session["language"] = ddl1.SelectedValue;
            //2.4
            Response.Redirect(Request.Path); //再重新開始PageLoad  
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // https://ithelp.ithome.com.tw/articles/10159846 
            // 後半不行，無法用DDL轉變。而且我有用自己的方法改編很多，才可以跑起來不會怪怪的。
            
            // 1.2 
            // 2.2
            // 2.6
            Lang1.Text = Page.UICulture;

            // 2.7
            if (!Page.IsPostBack && Session["language"] != null) //只有第二次開這一頁才會做保留上頁DDL值
                ddl1.SelectedValue = Session["language"].ToString();
            // Zero並沒有因應UICulture而變化      

            // 第三次參考第二次的流程

            // <%Page%> 重點︰
            //Culture : 值判定與文化特性相關功能的結果(例如，日期、數字和貨幣格式等)
            //UICulture :值判定為網頁載入的資源，auto: 依照瀏覽器語言。(重點!!!!)
        }
    }
}