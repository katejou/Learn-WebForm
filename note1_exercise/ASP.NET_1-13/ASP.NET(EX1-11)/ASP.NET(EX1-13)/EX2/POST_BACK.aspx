<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="POST_BACK.aspx.cs" Inherits="ASP.NET_2._2_.POST_BACK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            我第一次載入頁面的時間︰
        </div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        我最近是更新頁面的時間︰    <asp:Button ID="Button2" runat="server" Text="PostBack" />
        <br />
        <asp:Label ID="Label2" runat="server"></asp:Label>
        
    </form>
</body>
</html>
