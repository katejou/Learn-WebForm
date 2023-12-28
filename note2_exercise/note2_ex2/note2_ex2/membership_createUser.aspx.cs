using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note2_ex2
{
    public partial class membership : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 要來到這個網頁之前，先去把web.config中的「拒絕匿名存取者」注解掉

            // P 264
            // https://docs.microsoft.com/zh-tw/dotnet/api/system.web.security.membership.createuser?view=netframework-4.8
            // 有許多障礙，包括在machine.config之中設定，要去看Doc筆記。
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MembershipCreateStatus status;
            MembershipUser muser;
            muser = Membership.CreateUser(
                "Admin", "P@sswOrd", "Admin@asp.net",
                "Question", "Answer", true, out status);

            switch (status)
            {
                case MembershipCreateStatus.Success:
                    Label1.Text = muser.UserName + "建立成功";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    Label1.Text = "帳號名稱重複";
                    break;
                default:
                    Label1.Text = "帳號建立失敗";
                    break;
            }

        }
    }
}