<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="type_safe_selfDefObj_inherit_collection.aspx.cs" Inherits="note3_ex1.Dict_type_safe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="100"></asp:ListBox>
            <asp:Label ID="Label1" runat="server" Text="去點選ListBox"></asp:Label>
            <asp:GridView ID="GridView1" runat="server"/>
        </div>
    </form>
</body>
</html>
