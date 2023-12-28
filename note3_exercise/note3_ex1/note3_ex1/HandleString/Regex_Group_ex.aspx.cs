using System;
using System.Text.RegularExpressions;


namespace note3_ex1.HandleString
{
    public partial class Regex_Group_ex : System.Web.UI.Page
    {
        // P 141 
        protected void Page_Load(object sender, EventArgs e)
        {
            string InputText = "10411";
            Match m = Regex.Match(InputText, @"^(?<Part1>\d{3})(?<Part2>\d{2})?$");
            if (m.Success)
                Label1.Text = String.Format("Part1 : {0} , Part2 : {1}", m.Groups["Part1"].Value, m.Groups["Part2"].Value);
        }
    }
}