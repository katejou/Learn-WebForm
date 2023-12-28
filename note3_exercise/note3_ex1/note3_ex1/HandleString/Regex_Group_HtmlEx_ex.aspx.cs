using System;
using System.Text.RegularExpressions;

namespace note3_ex1.HandleString
{
    public partial class Regex_Group_HtmlEx_ex : System.Web.UI.Page
    {
        // P 142
        protected void Page_Load(object sender, EventArgs e)
        {
            string InputText = " <h1>title1</h1><h2>title2</h2><h3>title3</h3>";
            Regex ex = new Regex(@"\<h(?<Level>\d{1})\>(?<title>\w*)\</h\d{1}\>");
            foreach (Match m in ex.Matches(InputText))
                ListBox1.Items.Add(m.Groups["Level"].Value + "." + m.Groups["title"].Value);
        }
    }
}