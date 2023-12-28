using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Extra
{
    public partial class Context_later2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)  // 如果不加這一行，在 「回去上一頁」 的 ButtonClick 方法進行前，到了這一個Page Load, 就出錯了，因為這次的「上一頁」是它自己，而它的類型並不是Context_former
            {
                try
                {
                    Context_former former = (Context_former)Context.Handler;

                    //DataTable dt = Context.Items["data"] as DataTable;
                    ArrayList list = Context.Items["FormerPageList1"] as ArrayList;
                    foreach (var str in list)
                    {
                        Response.Write(str + " <br/>");
                    }

                    result.Text = former.add(1, 2).ToString();

                }
                catch
                {
                    Response.Write("Error get data from parent transfer page!");
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Context_former.aspx");
        }


    }
}