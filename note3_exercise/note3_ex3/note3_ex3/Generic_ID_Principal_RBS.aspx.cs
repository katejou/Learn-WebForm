using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace note3_ex3
{
    public partial class Generic_ID_Principal_RBS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenericIdentity iden = new GenericIdentity("Kate");
            //string[] roles = new string[] { "Administrators" };     // <-- 切換身份，以對比效果
            string[] roles = new string[] { "NOT_Administrators" };
            Thread.CurrentPrincipal = new GenericPrincipal(iden, roles);
            Label1.Text = "登入者 :  " + Thread.CurrentPrincipal.Identity.Name;
            Label2.Text = "身份驗証成功？ :  " + Thread.CurrentPrincipal.Identity.IsAuthenticated;

        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                AdminsOnly();
                Label3.Text = "成功使用";
            }
            catch 
            {
                Label3.Text = "無法使用";
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        void AdminsOnly() 
        { 
        
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Thread.CurrentPrincipal.IsInRole("Administrators"))
                Label3.Text = "售價﹑成本";
            else
                Label3.Text = "售價";

        }
    }
}