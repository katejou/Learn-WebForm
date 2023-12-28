using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Extra
{

    public partial class Context_former : System.Web.UI.Page
    {
        public string someAttri = "fomer attribute";

        public string SomeAttribute
        {
            get { return someAttri; }
            set { someAttri = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Context_later.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SomeAttribute = TextBox1.Text;
            TextBox1.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SomeAttribute = TextBox2.Text;
            Server.Transfer("Context_later.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            // https://blog.csdn.net/zhanglei5415/article/details/1595470

            ArrayList list = new ArrayList(2);
            list.Add(TextBox1.Text);
            list.Add(TextBox2.Text);
            Context.Items["FormerPageList1"] = list;
            Server.Transfer("Context_later2.aspx");
        }


        public int add(int a, int b)
        {
            return a + b;
        }





    }
}