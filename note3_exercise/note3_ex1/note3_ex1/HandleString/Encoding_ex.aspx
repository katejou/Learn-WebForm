<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encoding_ex.aspx.cs" Inherits="note3_ex1.HandleString.Encoding_ex" %>

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
            <br />
            <asp:Label runat="server" Text="原文︰" ID="LB1" BackColor="Yellow"></asp:Label>
            <br />
            <asp:Label runat="server" Text="字串我是原文，我是中文，中文。" ID="LB2"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Big5編碼後︰" ID="LB3" BackColor="Yellow"></asp:Label>
            <br />
            <asp:Label runat="server" Text="" ID="LB4"></asp:Label>
            <br />
            <asp:Label runat="server" Text="再轉回文字︰" ID="LB5" BackColor="Yellow"></asp:Label>
            <br />
            <asp:Label runat="server" Text="" ID="LB6"></asp:Label>
            <br />
            <asp:Label runat="server" Text="用UTF8編碼後︰" ID="LB7" BackColor="Yellow"></asp:Label>
            <br />
            <asp:Label runat="server" Text="" ID="LB8"></asp:Label>
            <br />
            <asp:Label runat="server" Text="再轉回文字︰" ID="LB9" BackColor="Yellow"></asp:Label>
            <br />
            <asp:Label runat="server" Text="" ID="LB10"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
