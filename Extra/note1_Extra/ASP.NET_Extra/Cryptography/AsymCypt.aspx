<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsymCypt.aspx.cs" Inherits="ASP.NET_Extra.Cryptography.AsymCypt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            不對稱加密<br />
            <br />
            <a href="https://www.itread01.com/content/1546781262.html">https://www.itread01.com/content/1546781262.html</a><br />
            <br />
            加密明文時採用公鑰加密，解密密文時使用私鑰才能完成，
            <br />
            而且發信方（加密者）知道收信方的公鑰，只有收信方（解密者）才是唯一知道自己私鑰的人
             
            <br />
            (不能從公鑰推敲出私鑰？)<br />
            廣泛應用的非對稱加密演算法有&nbsp; RSA&nbsp;&nbsp; 演算法和美國國家標準局提出的&nbsp;&nbsp; DSA
            <br />
            加密和解密花費時間長、速度慢，它不適合於對檔案加密而只適用於對少量資料進行加密
             
            <br />
            <br />
            <a href="https://www.itread01.com/content/1543510334.html">https://www.itread01.com/content/1543510334.html</a><br />
            <a href="https://docs.microsoft.com/zh-tw/dotnet/standard/io/how-to-read-text-from-a-file">https://docs.microsoft.com/zh-tw/dotnet/standard/io/how-to-read-text-from-a-file</a><br />
            <br />
            <asp:Button ID="ReadPubKey" runat="server" OnClick="ReadPubKey_Click" Text="讀出從PageLoad生成的公鑰" />
&nbsp;&nbsp;&nbsp;<br />
&nbsp;<asp:Label ID="puKey" runat="server"></asp:Label>
            <br />
            <asp:Button ID="ReadPriKey" runat="server" OnClick="ReadPriKey_Click" Text="(略)生成的私鑰" />
&nbsp;&nbsp;&nbsp;<br />
&nbsp;<asp:Label ID="prKey" runat="server"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="plain_text" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="RSAencypt" runat="server" OnClick="RSAencypt_Click" Text="RSA加密" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            &nbsp;&nbsp;<asp:Label ID="encypt" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <asp:Button ID="RHAdecypt" runat="server" OnClick="RHAdecypt_Click" Text="RSA解密" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            &nbsp;
            <asp:Label ID="decypt" runat="server"></asp:Label>
            <br />
            <br />
            <a href="https://blog.xuite.net/hellothere/blog/49077338-RSA非對稱加密演算法+++公開密鑰加密+++加密+++數位簽章">https://blog.xuite.net/hellothere/blog/49077338-RSA%E9%9D%9E%E5%B0%8D%E7%A8%B1%E5%8A%A0%E5%AF%86%E6%BC%94%E7%AE%97%E6%B3%95+%2B+%E5%85%AC%E9%96%8B%E5%AF%86%E9%91%B0%E5%8A%A0%E5%AF%86+%2B+%E5%8A%A0%E5%AF%86+%2B+%E6%95%B8%E4%BD%8D%E7%B0%BD%E7%AB%A0</a><br />
            RSA 的歷史<br />
            <br />
        </div>
    </form>
</body>
</html>
