<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CAS_Declarative_Imperative.aspx.cs" Inherits="note3_ex3.CAS_Declarative_Imperative" %>

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
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br/>
            <asp:Button ID="Declarative" runat="server" Text="使用宣告式" OnClick="Declarative_Click" />
            <br/>
            <br/>
            <asp:Button ID="Imperative" runat="server" Text="使用命令式" OnClick="Imperative_Click" />
            <br/>
        </div>
    </form>
</body>
</html>
