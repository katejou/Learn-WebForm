<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListBox.aspx.cs" Inherits="ASP.NET_EX3._2_.ASP_NET_EX3__2_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="lbSource" runat="server" SelectionMode="Multiple"></asp:ListBox>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="&gt;&gt;" />
            <asp:ListBox ID="lbTarget" runat="server" SelectionMode="Multiple"></asp:ListBox>
        </div>
    </form>
</body>
</html>
