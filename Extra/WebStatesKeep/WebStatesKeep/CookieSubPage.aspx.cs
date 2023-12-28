using System;
using System.Web;
using System.Web.UI;

namespace ASP.NET_Extra
{
    public partial class Cookie_Sever : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["CK"];
            if (cookie.Value == null) { Label1.Text = "Null"; }
            else { Label1.Text = Server.UrlDecode(cookie.Value); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //產生一個Cookie
            HttpCookie cookie = new HttpCookie("CK");  // 與另一個Cookie 設為同名，就可以覆蓋它。 
            //設定多值(這裡只能以字串的方式設定)
            cookie.Values.Add("1", "二維值一");
            cookie.Values.Add("2", Server.UrlEncode("二維值二"));  // 為什麼寫第二個值要Server.UrlEncode ? 
            cookie.Values.Add("3", Server.UrlEncode("二維值三"));
            //設定過期日
            cookie.Expires = DateTime.Now.AddDays(1);
            //寫到用戶端
            Response.Cookies.Add(cookie);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["CK"];
            if (cookie.Value == null) { Label1.Text = "Null"; }
            else { Label2.Text = Server.UrlDecode(cookie.Value); }    // 唔…第一個值變成了亂碼
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["CK"];
            Label3.Text = cookie.Values["1"];                        // 第一和三個值變成了亂碼！
            Label4.Text = Server.UrlDecode(cookie.Values["2"]);
            Label5.Text = cookie.Values["3"];
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string page = "'Cookie.aspx'";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popup", "window.open(" + page + ",'_blank')", true);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //產生一個Cookie
            HttpCookie cookie = new HttpCookie("CK");  // 與另一個Cookie 設為同名，就可以覆蓋它。 
            //設定多值(這裡只能以字串的方式設定)
            cookie.Values.Add("1", Server.UrlEncode("二維值一"));
            cookie.Values.Add("2", Server.UrlEncode("二維值二"));  // 為什麼寫第二個值要Server.UrlEncode ? 
            cookie.Values.Add("3", Server.UrlEncode("二維值三"));
            //設定過期日
            cookie.Expires = DateTime.Now.AddDays(2);
            //寫到用戶端
            Response.Cookies.Add(cookie);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["CK"];
            if (cookie.Value == null) { Label1.Text = "Null"; }
            else { Label6.Text = Server.UrlDecode(cookie.Value); }    
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["CK"];
            Label7.Text = Server.UrlDecode(cookie.Values["1"]);                        
            Label8.Text = Server.UrlDecode(cookie.Values["2"]);
            Label9.Text = Server.UrlDecode(cookie.Values["3"]);
        }
    }
}