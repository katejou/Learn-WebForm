using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AddingTextBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GetInput_Click(object sender, EventArgs e)
        {
            //// https://adamschen9921.pixnet.net/blog/post/95052736

            //int count = 1;
            //LB1.Text = "";
            //Int32.TryParse(Request.Form["Count"], out count);
            //StringBuilder sb1 = new StringBuilder();
            //count = count - 1;
            //sb1.Append("There are " + count + " input<br/>");
            //for (int i = 1; i <= count; i++)
            //{
            //    string name1 = "input" + i;
            //    string value1 = Request.Form[name1];
            //    sb1.AppendFormat("name:{0} value:{1}<br/>", name1, value1);
            //}

            //LB1.Text = sb1.ToString();
        }

        // 因為 Request.Form[name1]; 抓不到值，所以試用另一個方法新增 input
        // https://stackoverflow.com/questions/47307087/increase-index-of-a-forms-input-fields-name-attribute-in-a-dynamic-form
    }
}