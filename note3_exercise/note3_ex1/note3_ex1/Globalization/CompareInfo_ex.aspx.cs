using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex1.Globalization
{
    public partial class CompareInfo_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("zh-TW");
            string s1 = "123";
            string s2 = "１２３";

            CompareInfo compStr = ci.CompareInfo;
            Label1.Text = string.Format("{0} {1} {2}", s1, (s1.CompareTo(s2) == 0 ? " = " : " != "), s2);
            Label2.Text = string.Format("{0} {1} {2}", s1, (compStr.Compare(s1, s2, CompareOptions.IgnoreWidth) == 0 ? " = " : " != "), s2);
        }
    }
}