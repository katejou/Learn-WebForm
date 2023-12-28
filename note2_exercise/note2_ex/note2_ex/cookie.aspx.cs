using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex
{
    public partial class cookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // P195
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie myCookie = new HttpCookie("Userlnfo");
            myCookie.Values.Add("Username", "我本人");
            myCookie.Values.Add("visitTime", DateTime.Now.ToString());
            Response.Cookies.Add(myCookie);
            Label1.Text = "Cookie 寫入OK ";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HttpCookie myCookie = Request.Cookies["Userlnfo"];
            if (myCookie != null)
            {
                Label1.Text = "使用者 ︰ " + myCookie.Values["Username"].ToString();
                Label1.Text += "       ||    存取時間 : " + myCookie.Values["visitTime"].ToString();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            HttpCookie myCookie = new HttpCookie("Userlnfo2");
            myCookie.Values.Add("Username", "我本人2");
            myCookie.Values.Add("visitTime", DateTime.Now.ToString());
            //這一行是重點︰
            myCookie.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Add(myCookie);
            Label2.Text = "Cookie2 寫入OK ";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // 一分鐘內關了再開它還在。
            HttpCookie myCookie = Request.Cookies["Userlnfo2"];
            if (myCookie != null)
            {
                Label2.Text = "使用者 ︰ " + myCookie.Values["Username"].ToString();
                Label2.Text += "       ||    存取時間 : " + myCookie.Values["visitTime"].ToString();
            }
        }
    }
}