<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HiddenField.aspx.cs" Inherits="ASP.NET_EX3._1_.ASP_NET_EX3__1_" %>

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
            <asp:Label ID="Label1" runat="server" Text="帳號  ︰"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="密碼  ︰"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登入" />
            <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
            <br />
            這個 HiddenField 出現的地方，老是在最上面。 無法指定在下方。<br />
            因為它就不是用來顯示。<br />
            <br />
            它可以傳值︰<br />
            <a href="https://nelman.pixnet.net/blog/post/22127643">https://nelman.pixnet.net/blog/post/22127643</a><br />
            <br />
            存儲少量頁面 中經常改動的資訊，多和用戶端腳本一塊使用，<br />
            典型利用場合為：<br />
            用戶端經歷一系列驗證之後向伺服器端回發，伺服器端從用戶端HiddenField中獲取值，進行處理。 
            <br />
            例如 ：LeyserHomepage中，要刪除一項產品，<br />
            需要在用戶端彈出確認Form，用戶確認之後再PostBack回伺服器端進行資料庫Delete操作， 
            <br />
            當用戶確認要刪除時，將當前要刪除的產品ID存放到一個HiddenField中，然後執行 Form(0).submit回發到伺服器端，<br />
            伺服器端再從HiddenField獲取產品ID值，進行資料庫操作。<br />
            <br />
            或用來和其他元件聯手︰<br />
            <br />
            Hidden Field 和 Grid View 聯手︰ (未實作)<br />
            <a href="https://dotblogs.com.tw/puma/2008/03/16/1656">https://dotblogs.com.tw/puma/2008/03/16/1656</a><br />
        </div>
    </form>
</body>
</html>
