using System;
using System.Web;


namespace note2_ex2
{
    public partial class profile_ex1 : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = HttpContext.Current.Profile.GetPropertyValue("ThemeName").ToString();
        }

        //private object Profile = HttpContext.Current.Profile; // <-- 失敗

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = User.Identity.Name;
                name.Text = HttpContext.Current.Profile.GetPropertyValue("UserName").ToString();
                //bir_day.Text = Profile.Birthday.ToShortDateString();  // PDF 上這樣單寫不可行。
                bir_day.Text = HttpContext.Current.Profile.GetPropertyValue("Birthday").ToString();
                mary.Checked = (bool)HttpContext.Current.Profile.GetPropertyValue("Married");
                style.Text = HttpContext.Current.Profile.GetPropertyValue("ThemeName").ToString();

                // https://dotblogs.com.tw/terrychuang/2012/02/29/70395
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // 說是匿名使用者不行，所以一定要開 Form 驗證，從 login.aspx 過來。
            HttpContext.Current.Profile.SetPropertyValue("UserName", name.Text);
            HttpContext.Current.Profile.SetPropertyValue("Birthday",DateTime.Parse(bir_day.Text));
            HttpContext.Current.Profile.SetPropertyValue("Married",mary.Checked);
            HttpContext.Current.Profile.SetPropertyValue("ThemeName",style.Text);
            Label2.Text = "存檔成功";
        }
    }
}