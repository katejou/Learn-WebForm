using System;
using System.Globalization;
using System.Threading;

namespace note3_ex1.Globalization
{
    public partial class Def_culture_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CultureAndRegionInfoBuilder DemoBuilder
                = new CultureAndRegionInfoBuilder("def_cul", CultureAndRegionModifiers.None);

            // 取原本的
            CultureInfo TW_Culture = new CultureInfo("zh-TW");
            RegionInfo JA_Region = new RegionInfo("ja-JA");

            // 引入
            DemoBuilder.LoadDataFromCultureInfo(TW_Culture);
            DemoBuilder.LoadDataFromRegionInfo(JA_Region);
            // 自定 $
            DemoBuilder.NumberFormat.CurrencySymbol = "@";
            DemoBuilder.NumberFormat.CurrencyDecimalDigits = 2;
            // 自定 Time
            DemoBuilder.GregorianDateTimeFormat.DateSeparator = ".";

            // 將自訂的文化 註冊 到電腦上  
            DemoBuilder.Register();   // 會有拒絕存取路徑的問題，要用管理者權限

            // 開始利用
            Thread.CurrentThread.CurrentCulture = new CultureInfo("def_cul");

            Label1.Text = "目前文化特性 : " + Thread.CurrentThread.CurrentCulture.Name;
            Label2.Text = "目前文化日期 : " + DateTime.Now.ToString();
            Label3.Text = "目前文化金錢格式 : " + 1000.ToString("c");

            // 取消註冊
            CultureAndRegionInfoBuilder.Unregister("def_cul");
        }
    }
}