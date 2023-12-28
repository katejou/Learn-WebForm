using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex1.Globalization
{
    public partial class CultureInfo_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P 170
            int thousand = 1000;
            Label2.Text = thousand.ToString("c");
            Label3.Text = thousand.ToString("n");

            decimal money;
            if (decimal.TryParse(Label2.Text, NumberStyles.Currency, null, out money))
                Label4.Text = money.ToString();
            else
                Label4.Text = "轉化失敗";

            // P 171 
            CultureInfo jalnfo = new CultureInfo("ja-jp");

            Label5.Text = thousand.ToString("c", jalnfo);
            Label6.Text = thousand.ToString("n", jalnfo);

            jalnfo.NumberFormat.CurrencyDecimalDigits = 4;
            jalnfo.NumberFormat.NumberDecimalDigits = 4;

            Label7.Text = thousand.ToString("c", jalnfo);
            Label8.Text = thousand.ToString("n", jalnfo);


            // P 173
            DateTime now = DateTime.Now;
            Label9.Text = jalnfo.DateTimeFormat.ShortDatePattern;
            Label10.Text = now.ToString("d", jalnfo);
            Label11.Text = now.ToString(jalnfo.DateTimeFormat.ShortDatePattern);

            StringBuilder sb = new StringBuilder();
            foreach (var dn in jalnfo.DateTimeFormat.DayNames)
                sb.Append(dn + " ");
            Label12.Text = sb.ToString();

            Label13.Text = jalnfo.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);

            jalnfo.DateTimeFormat.DayNames = new string[] { "A", "B", "C", "D", "E", "F", "G" };
            sb.Clear();
            foreach (var dn in jalnfo.DateTimeFormat.DayNames)
                sb.Append(dn + " ");
            Label14.Text = sb.ToString();

            Label15.Text = jalnfo.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);

            // P 176
            thousand = -1000;
            Label16.Text = thousand.ToString("c", jalnfo);
            NumberFormatInfo JAnumInfo = jalnfo.NumberFormat;
            JAnumInfo.CurrencyNegativePattern = 2;
            Label17.Text = thousand.ToString("c", JAnumInfo);

            // https://stackoverflow.com/questions/5272760/show-currency-symbol-after-values
            // https://docs.microsoft.com/zh-TW/dotnet/api/system.globalization.numberformatinfo.currencynegativepattern?view=net-5.0

            CultureInfo ci = new CultureInfo("zh-TW", false);
            Label18.Text = now.ToString("D", ci);
            ci.DateTimeFormat.LongDatePattern = "yyyy年MMMdd日dddd";
            Label19.Text = now.ToString("D", ci);

        }
    }
}