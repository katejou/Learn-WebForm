<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IrrCypt.aspx.cs" Inherits="ASP.NET_Extra.Cryptography.cypt2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            不可逆加密&nbsp;&nbsp; ????<br />
            <br />
            三種加密的對比︰<br />
            <a href="https://www.itread01.com/content/1546781262.html">https://www.itread01.com/content/1546781262.html</a>&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            沒有 KEY 也沒有&nbsp; IV ，只有明文的輸入。用來對比和之前的輸入否一致。<br />
            因為不需要傳 KEY 之類的東東，所以一般登入密碼的驗證都是這東東。<br />
            把加密後的明文放在資料庫中，即使被 黑走了， 黑客也是無法 倒回為 明文來輸入。&nbsp; 
            <br />
            (&nbsp; 除非他再把網站黑了變成 不用密碼 或者用 窮舉法 之類。，否則無法破解)<br />
            <br />
            實作︰<br />
            <a href="https://www.twblogs.net/a/5cb770b8bd9eee0f00a204d6">https://www.twblogs.net/a/5cb770b8bd9eee0f00a204d6</a><br />
            <a href="https://www.itdaan.com/tw/abb8c05e0c6a6d563a26fdfead290bf5">https://www.itdaan.com/tw/abb8c05e0c6a6d563a26fdfead290bf5</a><br />
            <a href="https://dotblogs.com.tw/marcus116/2012/06/24/73009">https://dotblogs.com.tw/marcus116/2012/06/24/73009</a>&nbsp;&nbsp; &lt;-
            <br />
            ^ 這有三個MD5 (16 , 32用ComputeHash , 32用HashPasswordForStoringInConfigFile)<br />
            只實作一個&nbsp;&nbsp;&nbsp; 32用ComputeHash<br />
            <br />
            <asp:TextBox ID="tb_SHA1" runat="server"></asp:TextBox>
&nbsp;<br />
&nbsp;<asp:Button ID="SHA1_button" runat="server" OnClick="SHA1_Click" Text="SHA1" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="SHA1encypt_1" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<asp:Button ID="SHA1encypt" runat="server" OnClick="SHA1encypt_Click" Text="SHA1對比" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="SHA1decypt_1" runat="server"></asp:Label>
            <br />
            <asp:TextBox ID="tb_MD5" runat="server"></asp:TextBox>
&nbsp;<br />
&nbsp;<asp:Button ID="MD5_1" runat="server" OnClick="MD5_Click" Text="MD5" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="MD5encypt_1" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<asp:Button ID="MD5_1encypt" runat="server" OnClick="MD5encypt_Click" Text="MD5對比" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="MD5decypt_1" runat="server"></asp:Label>
            <br />
            <br />
            SHA1 被 Google 破解的新聞︰ (2017)<br />
            <a href="https://www.ithome.com.tw/news/112347">https://www.ithome.com.tw/news/112347</a><br />
            <br />
        </div>
    </form>
</body>
</html>
