using System;
using System.Globalization;
using System.Threading;


namespace note3_ex1.Globalization
{
    public partial class CurrentCulture_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P161 
            CultureInfo UsersCulture = Thread.CurrentThread.CurrentCulture;
            Label1.Text = "目前的文化特性︰ " + UsersCulture.Name;
            Label2.Text = "文化特性的日期格式︰ " + DateTime.Now.ToString();
            Label3.Text = "文化特性的貨幣格式︰ " + 1000.ToString("c");

            Thread.CurrentThread.CurrentCulture = new CultureInfo("jp-JP");
            UsersCulture = Thread.CurrentThread.CurrentCulture;

            Label4.Text = "指定的文化特性︰ " + UsersCulture.Name;
            Label5.Text = "指定文化的日期格式︰ " + DateTime.Now.ToString();
            Label6.Text = "指定文化的貨幣格式︰ " + 1000.ToString("c");

            foreach (CultureInfo cul_info in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                ListBox1.Items.Add(cul_info.Name);

            foreach (CultureInfo cul_info in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
                ListBox2.Items.Add(cul_info.Name);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-TW");
            UsersCulture = Thread.CurrentThread.CurrentCulture;
            RegionInfo region = new RegionInfo(UsersCulture.Name);
            Label7.Text = "DisplayName︰ " + region.DisplayName;
            Label8.Text = "EnglishName︰ " + region.EnglishName;
            Label9.Text = "NativeName︰ " + region.NativeName;
            Label10.Text = "CurrencyEnglishName︰ " + region.CurrencyEnglishName;
            Label11.Text = "CurrencyNativeName︰ " + region.CurrencyNativeName;

        }
    }
}