<%@ Page Language="C#" ErrorPage="~/EX_11/Err.html" AutoEventWireup="true" CodeBehind="Page_attri.aspx.cs" Inherits="ASP.NET_EX1_.EX_11.Page_attri" %>

<%--ErrorPage="~/EX_11/Err.html"--%>
<%--ErrorPage="~/EX_11/Err_aspx.aspx"--%>    <%--這個可以看到「是由哪一頁的錯誤」引導致「自設錯誤的頁面」--%>。
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            EX&nbsp; 11.2<br />
            <br />
            <br />
            &lt;%
            Page Language = "C#" ErrorPage = "~/EX_11/Err.html" .....%&gt;<br />
            <br />
            PageLoad 會出現 Exception
            <br />
            <br />
            Web.config 有  &lt;system.web&gt;  customErrors mode = "On" &lt;/system.web&gt;
            <br />
            <br />
            //&nbsp; 之後可以 拿走&nbsp; &lt;% Page&nbsp; 裡的 ErrorPage 屬性看看。<br />
            // 結果出現說︰ Web.config 中的&nbsp; customErrors mode&nbsp; 要設成什麼什麼的預設錯誤頁面。<br />
            <br />
            <a href="https://dotblogs.com.tw/joysdw12/2013/05/20/104561">https://dotblogs.com.tw/joysdw12/2013/05/20/104561</a>
            <br />
            <a href="http://vito-note.blogspot.com/2012/10/blog-post_60.html">http://vito-note.blogspot.com/2012/10/blog-post_60.html</a>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
