using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex3
{
    public partial class AppDomin_ex : System.Web.UI.Page
    {
        AppDomain newAppDomain = AppDomain.CreateDomain("NewDomain");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text += "這個class有一個AppDomain屬性 : " + newAppDomain.FriendlyName;
            }
        }

        protected void Load_Click(object sender, EventArgs e)
        {
            newAppDomain.ExecuteAssembly(@"C:\Users\kate_jou\source\repos\Learning\ASP.NET\note3_exercise\note3_ex2\note3_ex2\bin\Debug\netcoreapp3.1\note3_ex2.exe");
        }

        protected void Query_Click(object sender, EventArgs e)
        {
            Label1.Text =
                "目前定義域名稱︰ " + AppDomain.CurrentDomain.FriendlyName + "\r\n" +
                "路徑位置︰ " + AppDomain.CurrentDomain.BaseDirectory;
        }

        protected void KillDomain_Click(object sender, EventArgs e)
        {
            AppDomain.Unload(newAppDomain);
        }


    }
}