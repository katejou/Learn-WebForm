<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrentCulture_ex.aspx.cs" Inherits="note3_ex1.Globalization.CurrentCulture_ex" %>

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
            <h2>文化特性 CultureInfo</h2>
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <h2>指定特別語系</h2>
            <br />
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <h2>SpecificCultures 和 NeutrualCultures 的差別</h2>
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Width="200"></asp:ListBox>
            &nbsp;&nbsp;&nbsp;
            <asp:ListBox ID="ListBox2" runat="server" Width="200"></asp:ListBox>
            &nbsp;&nbsp;&nbsp;
            不懂，但平常好像都在用SpecificCultures
            <br />
            <br />
            <h2>RegionInfo</h2>
            <br />
            <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
