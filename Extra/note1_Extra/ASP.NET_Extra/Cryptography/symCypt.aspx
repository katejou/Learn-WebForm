<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="symCypt.aspx.cs" Inherits="ASP.NET_Extra.Cryptography.C1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="https://www.twblogs.net/a/5cb770b8bd9eee0f00a204d6">https://www.twblogs.net/a/5cb770b8bd9eee0f00a204d6</a><br />
            對稱加密算法的特點是算法公開、計算量小、加密速度快、加密效率高。不足之處是，交易雙方都使用同樣鑰匙，安全性得不到保證。對稱加密算法有DES、IDEA和AES、常用的對稱加密算法是DES，安全性比較高，目前只有窮舉法可以破解該算法。<br />
            <hr />
            <br />
            Aes 對稱加密︰<br />
            <br />
            <a href="https://dotblogs.com.tw/shadow/2019/03/20/232821">https://dotblogs.com.tw/shadow/2019/03/20/232821</a><br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
            <a href="https://docs.microsoft.com/zh-tw/dotnet/api/system.security.cryptography.aes?view=netcore-3.1">https://docs.microsoft.com/zh-tw/dotnet/api/system.security.cryptography.aes?view=netcore-3.1</a><br />
            <br />
            Rijndael是AES前身，由於KeySize和IV (BlockSize)長度關係，微軟官方建議使用AES替代Rijndael演算法
            <br />
            <br />
            <hr />
            <br />
            DES 對稱加密︰<br />
            <br />
            <a href="https://dotblogs.com.tw/yc421206/2012/04/18/71609">https://dotblogs.com.tw/yc421206/2012/04/18/71609</a><br />
            <br />
            DES&nbsp; 和 AES 不同在於&nbsp;&nbsp; KEY&nbsp;&nbsp; 和&nbsp;&nbsp; IV&nbsp;&nbsp; 的長度都是&nbsp;&nbsp;&nbsp;&nbsp; 64&nbsp;&nbsp; Bit
            <br />
            AES 的&nbsp;&nbsp; KEY&nbsp;&nbsp; 和&nbsp;&nbsp; IV&nbsp;&nbsp; 的長度&nbsp;&nbsp;&nbsp; 128&nbsp; ,&nbsp; 192&nbsp; ,&nbsp; 256&nbsp;&nbsp;&nbsp;Bit
            <br />
            &nbsp;
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server"></asp:Label>
            &nbsp;
            <br />
            <br />
            DES 對稱加密 2︰<br />
            <br />
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server"></asp:Label>
            <br />
            <br />
            DES 加密檔案︰<br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="加密檔案" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="解密檔案" OnClick="Button2_Click" />
            <br />
            <br />
            要自己去方案總管那邊開來看， 原本是 Text.txt , 其他兩個刪刪看，會自己生出來的。<br />
            <br />
            <hr />
            <br />
            關於 Key 和&nbsp; IV&nbsp; 如何自己生成為符合的長度︰<br />
            <br />
            請亂輸入︰&nbsp;&nbsp; 
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Rfc2898DeriveBytes 生成" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <br />
            化為的&nbsp;&nbsp; KEY /&nbsp; IV&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label7" runat="server"></asp:Label>
            <br />
            <br />
            化成 8 組數字， 這個&nbsp; byte[]&nbsp; 可以直接給&nbsp; DESCryptoServiceProvider&nbsp; 使用<br />
            <br />
            其他的生成，暫不實作，還沒有用到。&nbsp; 
            <br />
            <br />
            ( 還有︰&nbsp;&nbsp; 
            <br />
            PasswordDeriveBytes 
            <br />
            RNGCryptoServiceProvider <br />
            SHA256CryptoServiceProvider
            <br />
            MD5CryptoServiceProvider<br />
            )<br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
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
