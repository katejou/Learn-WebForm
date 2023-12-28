<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="role.aspx.cs" Inherits="note2_ex2.role" %>

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
            之前建立的「成員」︰Admin
            <br />
            現在建立的「角色」︰Admins﹑Users
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="建立角色" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="顯示結果"></asp:Label>
            <br />
            <br />
            「成員」>>>>>>>>>>>>>>>>>>>>>「角色」
            <br />
            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
            <asp:Button ID="Button2" runat="server" Text="將「成員」加入到「角色」中" OnClick="Button2_Click" />
            <asp:ListBox ID="ListBox2" runat="server"></asp:ListBox>
            <br />
            <br />
            (將一個成員，加入到不同的兩個角色)
             <br />
            右邊ListBox應該只能選其中一個才對？唔，這兩個ListBox都只能單選。
        </div>
    </form>
</body>
</html>
