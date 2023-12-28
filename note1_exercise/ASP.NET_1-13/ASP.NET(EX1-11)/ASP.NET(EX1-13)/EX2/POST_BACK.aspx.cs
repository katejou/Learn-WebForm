using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_2._2_
{
    public partial class POST_BACK : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = System.DateTime.Now.ToString();
            }

            if (Page.IsPostBack)    // 這個判斷式會判斷它不會在第一次進入這個程式去執行，反過來的話，在前面加上 !
            {
                Label2.Text = System.DateTime.Now.ToString();
            }

        }


    }
}