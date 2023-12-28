<%@ Page Language="C#"
    Culture="auto" UICulture="auto" meta:resourceKey="Page"
    AutoEventWireup="true" CodeBehind="muti_langLocal.aspx.cs" Inherits="note2_ex.Properties.muti_langLocal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:Button ID="Button1" runat="server" Text="<%$ Resources:Button1Res.Text %>" ToolTip="<%$ Resources:Button1Res.ToolTip %>"></asp:Button>
            <br />
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Label1Res.Text %>" ToolTip="<%$ Resources:Label1Res.ToolTip %>"></asp:Label>
            <br />
            <br />
            <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Name %>"></asp:Literal>
            <br />
            <br />
            <asp:Label ID="Lb2" runat="server" Text="後端寫入"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Lb3" runat="server" Text="fail"></asp:Label>
        </div>

    </form>
</body>
</html>
