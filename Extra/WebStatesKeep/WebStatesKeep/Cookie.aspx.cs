using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_Extra
{
    public partial class Cookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //產生一個Cookie
            HttpCookie cookie = new HttpCookie("CK");   // 這個是內容的 KEY
            //設定單值
            cookie.Value = Server.UrlEncode("設值一");  //  這個是內容的 VALUE
            //設定過期日
            cookie.Expires = DateTime.Now.AddDays(1);
            //寫到用戶端
            Response.Cookies.Add(cookie);

            //  (這裡是伺服器端)  如果寫到用戶端值是抓 輸入項中 成功登入的用戶名等，那麼就可以在顯示時，因不同人，秀出不同內容。

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //產生一個Cookie
            HttpCookie cookie = new HttpCookie("CK");  // 與另一個Cookie 設為同名，就可以覆蓋它。 
            //設定單值
            cookie.Value = Server.UrlEncode("設值二");
            //設定過期日
            cookie.Expires = DateTime.Now.AddDays(1);
            //寫到用戶端
            Response.Cookies.Add(cookie);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["CK"];
            Cookie_Result.Text = Server.UrlDecode(cookie.Value); 
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string page = "'CookieSubPage.aspx'";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open(" + page + ",'_blank')", true);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("CK");
            cookie.Expires = DateTime.Now.AddMonths(-1); //cookie的銷燬，給他設定一個多去了的時間，他就被銷燬了。
            Response.Cookies.Add(cookie);//將建立的cookie檔案輸入到瀏覽器端


        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["CK"];

            foreach (string value in cookie.Values)
            {
                //if (value == null) { Cookie_Result0.Text = "NULL"; }else
                Cookie_Result0.Text += value;
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            //產生一個Cookie
            HttpCookie cookie = new HttpCookie("SEX");  
            //設定單值
            cookie.Value = Server.UrlEncode("F");
            //設定過期日
            cookie.Expires = DateTime.Now.AddDays(1);
            //寫到用戶端
            Response.Cookies.Add(cookie);
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            //產生一個Cookie
            HttpCookie cookie = new HttpCookie("SEX");
            //設定單值
            cookie.Value = Server.UrlEncode("M");
            //設定過期日
            cookie.Expires = DateTime.Now.AddDays(1);
            //寫到用戶端
            Response.Cookies.Add(cookie);
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["SEX"];
            Cookie_Result1.Text = Server.UrlDecode(cookie.Value);
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            HttpCookie c = Request.Cookies["CK"];
            if (c == null)
            {
                Cookie_Result2.Text = "NO cookie found";
            }
            else
            {
                Cookie_Result2.Text = c.Value;
            }
        }
    }
}