using System;
using System.Globalization;
using System.Text;
using System.Web.UI.WebControls;

namespace note3_ex1.Globalization
{
    public partial class GetAllCulture_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P165
            foreach (CultureInfo info in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                ListItem item = new ListItem(info.DisplayName,info.Name);
                ListBox1.Items.Add(item);
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo selectedCulture = new CultureInfo(ListBox1.SelectedValue);
            RegionInfo region = new RegionInfo(ListBox1.SelectedValue);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<br/> 名稱 : ");
            sb.AppendLine("<br/> DisplayName :" + selectedCulture.DisplayName);
            sb.AppendLine("<br/> NativeName : " + selectedCulture.NativeName);
            sb.AppendLine("<br/> EnglishName : " + selectedCulture.EnglishName);
            sb.AppendLine("<br/> 貨幣 : ");
            sb.AppendLine("<br/> CurrencySymbol : " + region.CurrencySymbol);
            sb.AppendLine("<br/> CurrencyNativeName : " + region.CurrencyNativeName);
            sb.AppendLine("<br/> CurrencyEnglishName : " + region.CurrencyEnglishName);
            Label1.Text = sb.ToString();
        }
    }
}