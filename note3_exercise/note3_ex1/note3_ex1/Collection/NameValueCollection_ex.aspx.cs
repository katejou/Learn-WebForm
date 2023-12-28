using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex1
{
    public partial class NameValueCollection_ex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection member = new NameValueCollection();
            member.Add("A", "Anita");
            member.Add("A", "Alice");
            member.Add("B", "Bob");
            member.Add("C", "Candy");
            member.Add("C", "Charlie");
            member.Add("C", "Carol");
            string tmp = "";
            foreach (string k in member.Keys)
            {
                tmp += "Key: " + k;
                tmp += "\tValues:" +  string.Join("," , member.GetValues(k));
                tmp += "<br/>";
            }
            Label1.Text = tmp;
        }
    }
}