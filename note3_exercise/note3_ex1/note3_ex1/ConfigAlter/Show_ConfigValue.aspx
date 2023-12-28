<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show_ConfigValue.aspx.cs" Inherits="note3_ex1.ConfigAlter.Show_ConfigValue" %>

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
            <h3>顯示 Web.config 資訊</h3>
            <hr />
            <br />
            <asp:Label ID="Label1" runat="server" Text="顯示所有的 ConnectionStrings : " BackColor="#FF9999"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="顯示所有的 appSetting : " BackColor="#FF9999"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
