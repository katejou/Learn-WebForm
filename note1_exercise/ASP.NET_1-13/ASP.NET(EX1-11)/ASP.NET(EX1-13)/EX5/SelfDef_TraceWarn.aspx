<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelfDef_TraceWarn.aspx.cs" Inherits="ASP.NET_EX5._6_.ASP_NET_EX_5_6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            在Web.config開 trace , pageOutput=&quot;false&quot;, mostRecent=&quot;true&quot;<br />
            Button1_Click 出 Trace.Warn(&quot;Test message&quot;, &quot;自設的Trace.Warn&quot;)<br />
            Page_Load :&nbsp; Trace.TraceFinished += new TraceContextEventHandler(Trace_TraceFinished);<br />
            Trace_TraceFinished 是一個 method , 這method的兩個參數，不知道為什麼會被滿足，但是<br />
            Trace_TraceFinished進行了，就捉出個一個運行的訊息「內容」<br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="我是個會寫出紅字的Trace.Warn()" />
            <br />
        </div>
    </form>
</body>
</html>
