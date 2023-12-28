<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page_Application_err.aspx.cs" Inherits="ASP.NET_EX1_.EX_11.Page_err" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        EX&nbsp;&nbsp; 11.1&nbsp;
        <br />
        <br />
        <br />
        頁面層級錯誤攔截&nbsp;&nbsp; -------------<br />
        <br />
        當 Page Load 中只有&nbsp; 
        :&nbsp;&nbsp;&nbsp;&nbsp;
        String s = &quot;2009/ 2/30&quot;; DateTime d = DateTime.Parse(s);<br />
        F5 會出錯&nbsp; 並停住 在後端&nbsp; ，前端會一直空白<br />
        新增一個 Err.html ( html 的網頁就是只有前端的那種 )&nbsp;&nbsp; 和&nbsp;&nbsp; Page_Error 的方法在後端<br />
        <br />
        F5 這一頁的時候，還是在 後端卡一下，按「繼續」才跳去錯誤頁面。<br />
        Ctrl&nbsp; +&nbsp; F5&nbsp; 會直接跳去錯誤頁面。<br />
        <br />
        <br />
        <br />
        應用層級錯誤攔截&nbsp;&nbsp; ------------<br />
        <br />
        註解 後端 Page_Error ,&nbsp; Page Load 的錯誤會引到&nbsp; Global.asax 的 Application_Error 去處理<br />
        <br />
        F5 的話，要按三下( 開始 &gt; PageLoad &gt; Page_err )才會跳到 Err.html 然後靜止不能。 
        <br />
        自己新增的 Global.asax&nbsp; 要放在 Web.congif 的旁邊，也就是最外層才會被感應到。<br />
        因應它是網站共用的。<br />
        <br />
        <br />
        Global.asax 的用途<br />
        <a href="https://www.itread01.com/content/1548230061.html">https://www.itread01.com/content/1548230061.html</a><br />
        <br />
    </form>
</body>
</html>
