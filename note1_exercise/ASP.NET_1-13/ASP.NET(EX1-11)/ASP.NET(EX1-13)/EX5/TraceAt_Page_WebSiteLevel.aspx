<%@ Page Language="C#" Trace = "True" TraceMode ="SortByCategory" AutoEventWireup ="true" CodeBehind="TraceAt_Page_WebSiteLevel.aspx.cs" Inherits="ASP.NET_EX5._3_.ASP_NET_EX5__3_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            執行頁面層級追蹤<br />
            <br />
            &lt;%@Page ...... Trace = &quot;True&quot; ......%&gt;<br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
&nbsp;&nbsp;&nbsp;&nbsp; 下方有 很多資料，輸入123 再按 Button, 看看。<br />
            <br />
            然後 Page ...... Trace = &quot;False&quot; &lt; --- 或刪了它<br />
            <br />
            在 Web.Config 加入&nbsp;&nbsp;&nbsp; <br />
            &lt; system. web&gt;
            <br />
            &lt;<br />
            ...<br />
            trace enabled=&quot;true&quot;
            <br />
            pageOutput= &quot;false&quot;<br />
            localOnly= &quot;true&quot;<br />
            requestLimit=&quot;10&quot;<br />
            traceMode=&quot;SortByCategory&quot;
            <br />
            ....<br />
            /&gt;<br />
            &lt; /system. web&gt;
<trace enabled="true" 

pageOutput= "fa Ise" 

localOnly= "true" 

requestLi m it="1 A" 

traceMode="SortByCategory" /> 

            <br />
            <br />
            F5 後，在網址後加入&nbsp; /Trace.axd&nbsp; 來看檔案<br />
&nbsp;<br />
        </div>
    </form>
</body>
</html>
