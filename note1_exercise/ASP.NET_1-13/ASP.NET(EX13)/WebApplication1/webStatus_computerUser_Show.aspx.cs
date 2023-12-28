using System;
//using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // PDF 的方法，無法顯示
            Label1.Text = User.Identity.Name;
            Label2.Text = User.Identity.AuthenticationType;
            // PDF 的方法，正常顯示︰
            Label3.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            // https://html.developreference.com/article/27411846/HttpContext.Current.User.Identity.Name+is+always+string.Empty
            // 網址的方法一︰
            Label4.Text = HttpContext.Current.User.Identity.Name;
            Label5.Text = HttpContext.Current.User.Identity.AuthenticationType;
            // 網址的方法二︰
            Label6.Text = System.Web.HttpContext.Current.Request.LogonUserIdentity.Name;
            Label7.Text = System.Web.HttpContext.Current.Request.LogonUserIdentity.AuthenticationType;
            ////////// Label6 可以正常的顯示。
            //https://docs.microsoft.com/en-us/dotnet/api/system.web.httprequest.logonuseridentity?redirectedfrom=MSDN&view=netframework-4.8#System_Web_HttpRequest_LogonUserIdentity
            //https://forums.asp.net/t/1444151.aspx?request+LogonUserIdentity+AuthenticationType+value+is+empty
            ////////// Label2 無法顯示。
            //無法顯示的原因可能是 ︰
            // https://docs.microsoft.com/zh-tw/dotnet/api/system.directoryservices.authenticationtypes?view=dotnet-plat-ext-3.1
            

            


        }
    }
}