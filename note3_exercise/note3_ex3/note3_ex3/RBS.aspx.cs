using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Security.Principal;

namespace note3_ex3
{
    public partial class RBS : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // P 516 原實作
            AppDomain.CurrentDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
            Label1.Text += Thread.CurrentPrincipal.Identity.Name;
            Label2.Text += Thread.CurrentPrincipal.IsInRole(@"BUILTIN\Users");

            // 我自主實作 P 514 ︰
            WindowsIdentity iden = WindowsIdentity.GetCurrent();
            WindowsPrincipal prin = new WindowsPrincipal(iden);
            ListBox1.Items.Add("使用者︰" + iden.Name);
            ListBox1.Items.Add("AuthenticationType: " + iden.AuthenticationType);
            ListBox1.Items.Add("Group: ");
            foreach (IdentityReference group in iden.Groups)
            {
                NTAccount ntGroup = (NTAccount)group.Translate(typeof(NTAccount));
                ListBox1.Items.Add("--------------" + ntGroup.Value);
            }
            ListBox1.Items.Add("是 Administrator ?" + prin.IsInRole(WindowsBuiltInRole.Administrator));

            // 我自主實作 P 515  
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            WindowsPrincipal prin2 = (WindowsPrincipal)Thread.CurrentPrincipal;
            Label4.Text += prin2.IsInRole(@"BUILTIN\Users");

        }
        }
}