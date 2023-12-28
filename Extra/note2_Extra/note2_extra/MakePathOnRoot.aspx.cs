using System;
using System.IO;

namespace note2_extra
{
    public partial class MakePathOnRoot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 要開權限給根目錄寫入。
            // 要掛到這個地方，C:\inetpub\wwwroot
            // 在裡面更改權限，才可以找到 (本機User/這公司內網訪問這網站的User)，給他們寫入。
            if (!Directory.Exists(Server.MapPath("~/Log")))
                Directory.CreateDirectory(Server.MapPath("~/Log"));
        }
    }
}