<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CASDeclare_ex.aspx.cs" Inherits="note3_ex3.CASDeclare_ex" %>

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
            <asp:Label ID="Label1" runat="server" Text="連線字串︰"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Link1" runat="server" Text="Data Source=.;Initial Catalog=test;Integrated Security=True"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Build1" runat="server" Text="建立" OnClick="Build1_Click" />
            <asp:Label ID="R1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Link2" runat="server" Text="Data Source=.;Initial Catalog=Custom_Doc;Integrated Security=True"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Build2" runat="server" Text="建立" OnClick="Build2_Click" />
            <asp:Label ID="R2" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
