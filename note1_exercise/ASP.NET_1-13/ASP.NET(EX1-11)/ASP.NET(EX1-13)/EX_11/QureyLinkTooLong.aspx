<%@ Page Language="C#" Trace = "True" TraceMode ="SortByCategory" AutoEventWireup="true" CodeBehind="QureyLinkTooLong.aspx.cs" Inherits="ASP.NET_EX1_.EX_11.QureyLinkTooLong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            11.6<br />
            <br />
            測網頁字串長度&nbsp; 限製修改 和 跳往指定的自設錯誤頁面<br />
            <br />
            在 Web.config 的 system.webServer 有修改。<br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="跳到有QueryString的本頁" />
            <br />
            <br />
            在網址上多加一個字都會過長。<br />
            <br />
            <a href="https://www.bbsmax.com/A/B0zq6wwNJv/">https://www.bbsmax.com/A/B0zq6wwNJv/</a>&nbsp;&nbsp;&nbsp; &lt;-- 每個瀏覽器都有他們自設最長的長度。<br />
            <br />
            <a href="https://blog.csdn.net/woddle/article/details/105764198">https://blog.csdn.net/woddle/article/details/105764198</a>&nbsp;&nbsp; &lt;-- 限製文件上傳的大小也是差不多。<br />
            <br />
            <a href="https://forums.asp.net/t/1642328.aspx?What+s+the+purposes+of+and+differences+between+system+web+and+system+webServer+">https://forums.asp.net/t/1642328.aspx?What+s+the+purposes+of+and+differences+between+system+web+and+system+webServer+</a>&nbsp;&nbsp; &lt;--&nbsp; system.webServer 和 system.web 的分別<br />
            <br />
            <a href="https://support.microsoft.com/zh-tw/help/943891/the-http-status-code-in-iis-7-0-iis-7-5-and-iis-8-0">https://support.microsoft.com/zh-tw/help/943891/the-http-status-code-in-iis-7-0-iis-7-5-and-iis-8-0</a>&nbsp; &lt;-- 錯誤 Code 的含意<br />
            <br />
            <a href="https://kknews.cc/zh-tw/tech/jz3aqkl.html">https://kknews.cc/zh-tw/tech/jz3aqkl.html</a>&nbsp; &lt;-- customErrors 和 httpErrors 的區別<br />
            <br />
            我開了 Trace 再加上 /Trace.axd&nbsp; 就可以看到每次來回的 Code 是什麼&nbsp; 404.15&nbsp; 也是 404<br />
            在 system.webServer 上去限的 長度，錯誤不會被 system.web 去捉到。<br />
            在&nbsp; system.web 去限長度，錯誤的 Code 卻不是 404 ?&nbsp; (就是撈得到，但會去了defaultRedirect 那裡&nbsp; )&nbsp;
            <br />
&nbsp;<br />
            如果封了轉跳的畫面，看到的是︰<br />
            HttpException (0x80004005): 此要求的查詢字串長度超過設定的 maxQueryStringLength 值<br />
            但錯誤代碼是？&nbsp; 官網也沒有寫…<br />
            <br />
            <a href="https://docs.microsoft.com/zh-tw/aspnet/web-forms/overview/older-versions-getting-started/deploying-web-site-projects/displaying-a-custom-error-page-cs">https://docs.microsoft.com/zh-tw/aspnet/web-forms/overview/older-versions-getting-started/deploying-web-site-projects/displaying-a-custom-error-page-cs</a><br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
