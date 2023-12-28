<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="errorlog_webConfig.aspx.cs" Inherits="ASP.NET_EX1_.EX_11.errorlog_webConfig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            11.4&nbsp; 應用程式層級 與 自訂錯誤<br />
            <br />
            1.&nbsp; Global.asax.cs 的 Application_Error 設定&nbsp; 寫 log&nbsp;
            <br />
            <br />
            它居然捉得到 Exception&nbsp; ?&nbsp;
            <br />
            Exception ex = Server.GetLastError();<br />
            ex.InnerException.Message<br />
            <br />
            2.&nbsp;&nbsp; Web.config 設定<br />
            <br />
            3. Page Load 扔自設的 Exception&nbsp;
            <br />
            <br />
            <a href="https://kknews.cc/zh-tw/tech/jz3aqkl.html">https://kknews.cc/zh-tw/tech/jz3aqkl.html</a><br />
            <br />
        </div>
    </form>
</body>
</html>
