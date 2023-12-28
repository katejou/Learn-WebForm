<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ASP_Tool_HomePage.aspx.cs" Inherits="WebApplication1.ASP_Tool_HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            設定這個為起始頁<br />
            <br />
            1.&nbsp;&nbsp;&nbsp;&nbsp;
            Login Status&nbsp; :&nbsp;&nbsp;&nbsp;
            <asp:LoginStatus ID="LoginStatus1" runat="server" LoginPageUrl="~/ASP_Tool_loginPage.aspx" LogoutAction="RedirectToLoginPage" />
            &nbsp;&nbsp;&nbsp;
            <br />
            (未登時，連結到登入的頁面。已登入時，會成為登出的按鈕，再回到登入的頁面)<br />
            <br />
            要在 web. config 中修改預設的登入頁面是哪一個，無法在屬性中調整。<br />
            <a href="http://blog.sina.com.cn/s/blog_830fddc80102wtum.html">http://blog.sina.com.cn/s/blog_830fddc80102wtum.html</a><br />
            出現︰System.InvalidOperationException:
            <br />
            WebForms UnobtrusiveValidationMode 需要 &#39;jquery&#39; 的 ScriptResourceMapping。<br />
            請加入 ScriptResourceMapping 命名的 jquery (區分大小寫)。<br />
            解決︰<br />
            <a href="https://social.msdn.microsoft.com/Forums/zh-TW/fba39566-bda5-4b57-ace8-e0ec273c35af/395113565725511210463891737679354923533824687?forum=236">https://social.msdn.microsoft.com/Forums/zh-TW/fba39566-bda5-4b57-ace8-e0ec273c35af/395113565725511210463891737679354923533824687?forum=236</a><br />
            加入 &lt;appSettings&gt; .... 見 web.config
            <br />
            <br />
            要把 屬性 LogoutAction=&quot;RedirectToLoginPage&quot; 要不然登出後，還是留在原頁。<br />
            <br />
            2.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            UserName :&nbsp;&nbsp;&nbsp;
            <asp:LoginName ID="LoginName1" runat="server" ForeColor="#CC33FF" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            (只有在登入後，才會顯示名稱)<br />
            <br />
            3.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Login View&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:LoginView ID="LoginView1" runat="server">
                <AnonymousTemplate>
                    <h4 style="color: #CC33FF">
                        尚未登入時，所顯示的畫面
                    </h4>
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <h4 style="color: #CC33FF">
                        已經登入後，才顯示的畫面
                    </h4>
                    <asp:LoginName ID="LoginName2" runat="server" ForeColor="#CC33FF" />

                </LoggedInTemplate>
            </asp:LoginView>
            <br />
            <br />
            可以把 UserName 等，放入 LoginView 之中。<br />
            <br />
            <br />
            強迫未登入的網頁訪問者直接進到登入頁面:<br />
            在 Page Load :
            <br />
            if (!HttpContext.Current.User.Identity.IsAuthenticated) Response.Redirect(&quot;~/ASP_Tool_loginPage.aspx&quot;);<br />
            <br />
            <br />
            值得參考的網站︰<br />
            <a href="https://ithelp.ithome.com.tw/articles/10028527">https://ithelp.ithome.com.tw/articles/10028527</a><br />
            <br />
            <a href="https://www.itread01.com/p/630308.html">https://www.itread01.com/p/630308.html</a><br />
        </div>
    </form>
</body>
</html>
