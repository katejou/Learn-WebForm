<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ASP_Tool_loginPage.aspx.cs" Inherits="WebApplication1.ASP_Login_Tool" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="ASP_Tool_HomePage.aspx" OnAuthenticate="Login1_Authenticate"
            DisplayRememberMe ="false">
        </asp:Login>
        <br />
        按下登入後沒有反應？<br />
        <a href="https://dotblogs.com.tw/sywang/2010/07/30/16905">https://dotblogs.com.tw/sywang/2010/07/30/16905</a><br />
        還是要設一下帳密和後端的動作。<br />
        <br />
        <asp:Button ID="Button1" runat="server" PostBackUrl="~/ASP_Tool_AddUser.aspx" Text="註冊帳號" />
        &nbsp;&nbsp;&nbsp; (失敗放棄，不使用ASP的工具會比較好。)<br />
        <br />
        「 記憶密碼供下次使用」無效？<br />
        (不是一打User 的名稱就會自動填入密碼之類的嗎？)<br />
        (如果無法克服，可以讓它不要顯示嗎？)<br />
        <a href="http://www.blueshop.com.tw/board/FUM20041006161839LRJ/BRD20070306165703TFE.html">http://www.blueshop.com.tw/board/FUM20041006161839LRJ/BRD20070306165703TFE.html</a><br />
        要用 cookie 來存。<br />
        <a href="https://stackoverflow.com/questions/18082710/remember-me-with-asp-net-web-pages/18083245">https://stackoverflow.com/questions/18082710/remember-me-with-asp-net-web-pages/18083245</a><br />
        設 cookie 的存活期。<br />
        <br />
        直接關了這個功能︰ DisplayRememberMe =&quot;false&quot;<br />
        <br />
        <br />
        如何 引用 資料庫來驗証帳密 ? <br />
        就是用傳統的 SQL 指令和操作，&nbsp; select...from ... where ....user_name=yy and pwd=xxx....<br />
        有結果和沒有結果。</form>
</body>
</html>
