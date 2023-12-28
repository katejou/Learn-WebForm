using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_EX3._1_
{
    public partial class ASP_NET_EX3__1_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "UCOM" && txtPassword.Text == "111")
            {
                Response.Write("帳號密碼正確");
            }
            else
            {
                int count = Convert.ToInt32(HiddenField1.Value);
                count++;
                if (count > 3)
                {
                    Response.Write("帳號密碼不正確，錯誤次數 : " + count.ToString());
                }
                HiddenField1.Value = count.ToString();
            }
        }
    }
}