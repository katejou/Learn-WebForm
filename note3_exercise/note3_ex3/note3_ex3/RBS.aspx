<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RBS.aspx.cs" Inherits="note3_ex3.RBS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br/>
            <br/>
            <asp:Label ID="Label1" runat="server" Text="Thread.CurrentPrincipal.Identity.Name  :  空白"></asp:Label>
            <br/>
            <asp:Label ID="Label2" runat="server" Text="Thread.CurrentPrincipal.IsInRole(BUILTIN\User)   :  "></asp:Label>
            <br/>
            <asp:ListBox ID="ListBox1" runat="server" Width="500px" Height="500px"></asp:ListBox>
            <br/>
            <asp:Label ID="Label4" runat="server" Text="WindowsPrincipal.IsInRole(BUILTIN\Users)   :  "></asp:Label>
            <br/>
            <br/>
        </div>
    </form>
</body>
</html>
