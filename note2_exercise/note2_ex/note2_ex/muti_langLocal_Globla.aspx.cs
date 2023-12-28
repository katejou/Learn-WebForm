using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using note2_ex.App_LocalResources;

namespace note2_ex
{
    public partial class muti_langLocal2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //P142 使用應用程式取「另一頁的」Local資源
            //Label1.Text = HttpContext.GetLocalResourceObject("muti_langLocal.aspx", "Button1Res.Text").ToString();
            // 此處不允許相對虛擬路徑 'muti_langLocal.aspx'
            //Label1.Text = HttpContext.GetLocalResourceObject("App_LocalResources/muti_langLocal.aspx", "Button1Res.Text").ToString();
            // 找不到此頁面的資源類別。請檢查資源檔是否存在並再試一次。
            //Label1.Text = HttpContext.GetLocalResourceObject("~/App_LocalResources/muti_langLocal.aspx", "Button1Res.Text").ToString();
            // 同上。

            //https://www.itread01.com/content/1547697118.html
            // 又一個取全域變數的方法，但是其實不用那麼麻煩，見之前的例子。
            Label1.Text = HttpContext.GetGlobalResourceObject("LanguageResource", "Zero").ToString();
            Label4.Text = Resources.LanguageResource.Zero; // 簡化版
            // 讓兩個語言，同一個單字，同時顯示的另一種方法。
            Label2.Text = HttpContext.GetGlobalResourceObject("LanguageResource", "Zero", new CultureInfo("en-us")).ToString();

            // 如果又要Local又要跨頁，真的找不到辨法，不如做成Global好了，不研究。

            // https://docs.microsoft.com/zh-tw/dotnet/api/system.web.ui.templatecontrol.getlocalresourceobject?view=netframework-4.8
            Label3.Text = (String)GetLocalResourceObject("Name"); // 依這個頁面命名的LoaclaResources

            


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //P148練習
            String message = Resources.LanguageResource.Zero;
            String script = "alert('" + message + "');"; 
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "mykey", script, true);

        }
    }
}