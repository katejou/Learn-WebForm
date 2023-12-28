<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cookie.aspx.cs" Inherits="note2_ex.cookie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="寫入" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="顯示" OnClick="Button2_Click" />
            <asp:Label ID="Label1" runat="server" Text="非持續性Cookie(關視窗消失)"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="寫入" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" Text="顯示" OnClick="Button4_Click" />
            <asp:Label ID="Label2" runat="server" Text="持續性Cookie(關視窗Keep)"></asp:Label>
        </div>
    </form>
</body>
</html>
