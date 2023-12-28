using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class dynamicGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private DataTable BuiltOriginalTable()
        {
            // 每次回來，都要建一個和原本一樣的空Table
            DataTable dt = new DataTable();
            dt.Columns.Add("input_Text");
            //dt.Rows.Add(new object[])



            return dt;
        }

        protected void AddGV(object sender, EventArgs e)
        {
            DataTable dt = BuiltOriginalTable();

            for (int i = 0; i< gv.Rows.Count; i++)
            {
                if (TextBox1.Text != string.Empty)
                {
                    //dt.Rows.Add(new object[])
                    // 未完成
                }
            }
        }
    }
}