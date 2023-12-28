<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppDomin_ex.aspx.cs" Inherits="note3_ex3.AppDomin_ex" %>

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
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br/>
            <br/>
            <asp:Button ID="Load" runat="server" Text="載入" OnClick="Load_Click" />
            <br/>
            <br/>
            <asp:Button ID="Query" runat="server" Text="查詢" OnClick="Query_Click" />
            <br/>
            <br/>
            <asp:Button ID="KillDomain" runat="server" Text="缷載" OnClick="KillDomain_Click" />
            <br/>
            <br/>
            <br/>
        </div>
    </form>
</body>
</html>
