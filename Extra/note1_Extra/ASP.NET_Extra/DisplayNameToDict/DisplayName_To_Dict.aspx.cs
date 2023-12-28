using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DisplayName_To_Dict_Test
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Dictionary<string, string> info = TypeDescriptor.GetProperties(typeof(DisplayObj)).Cast<PropertyDescriptor>().ToDictionary(p => p.Name, p => p.DisplayName);

        protected void Page_Load(object sender, EventArgs e)
        {
            string result = "";
            List<string> trans = new List<string>{ "A", "B" };
            foreach (string s in trans) { result += info[s]; }

            Label1.Text = result;
        }
    }
}