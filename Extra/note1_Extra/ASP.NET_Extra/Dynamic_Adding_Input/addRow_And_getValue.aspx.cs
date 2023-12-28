using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class addRow_And_getValue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }
        protected void Button1_Click(object sender, EventArgs e)   //儲存

        {

            //取出TextBox_Username
            int count = 1;
            Label1.Text = "";
            Int32.TryParse(Request.Form["Count"], out count);
            StringBuilder sb1 = new StringBuilder();
            count = count - 1;
            sb1.Append("There are " + count + " TextBox<br/>");
            for (int i = 1; i <= count; i++)
            {
                string name1 = "TextBox_Username" + i;
                string value1 = Request.Form[name1];
                sb1.AppendFormat("name:{0} value:{1}<br/>", name1, value1);
            }
            Label1.Text = sb1.ToString();

            //取出TextBox_Tel
            count = 1;
            Label2.Text = "";
            Int32.TryParse(Request.Form["Count"], out count);
            StringBuilder sb2 = new StringBuilder();
            count = count - 1;
            sb2.Append("There are " + count + " TextBox<br/>");
            for (int i = 1; i <= count; i++)
            {
                string name2 = "TextBox_Tel" + i;
                string value2 = Request.Form[name2];
                sb2.AppendFormat("name:{0} value:{1}<br/>", name2, value2);
            }
            Label2.Text = sb2.ToString();

            //取出DropDownList
            count = 1;
            Label3.Text = "";
            Int32.TryParse(Request.Form["Count"], out count);
            StringBuilder sb3 = new StringBuilder();
            count = count - 1;
            sb3.Append("There are " + count + " DropDownList<br/>");
            for (int i = 1; i <= count; i++)
            {
                string name3 = "DropDownList_" + i;
                string value3 = Request.Form[name3];
                sb3.AppendFormat("name:{0} value:{1}<br/>", name3, value3);
            }
            Label3.Text = sb3.ToString();

            //取出RadioButton
            count = 1;
            Label4.Text = "";
            Int32.TryParse(Request.Form["Count"], out count);
            StringBuilder sb4 = new StringBuilder();
            count = count - 1;
            sb4.Append("There are " + count + " RadioButton<br/>");
            for (int i = 1; i <= count; i++)
            {
                string name4 = "RadioButton_" + i;
                string value4 = Request.Form[name4];

                sb4.AppendFormat("name:{0} value:{1}<br/>", name4, value4);
            }

            Label4.Text = sb4.ToString();
        }


    }
}