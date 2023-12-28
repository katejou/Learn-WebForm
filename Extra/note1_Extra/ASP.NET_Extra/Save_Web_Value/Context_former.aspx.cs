using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

            //DataTable dt = new DataTable();
            //dt.Columns.Add("A");
            //DataRow dr = dt.NewRow();
            //dr["A"] = "1";
            //dt.Rows.Add(dr);
            //Context.Items["data"] = dt;

            Server.Transfer("Context_later2.aspx");
        }


        public int add(int a, int b)
        {
            return a + b;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("A");
            DataRow dr = dt.NewRow();
            dr["A"] = "1";
            dt.Rows.Add(dr);

            //Context.Items.Add("data", dt);
            Context.Items["data"] = dt;
            // 開分頁
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", $"window.open('Context_later.aspx','_blank')", true);
        }
    }
}