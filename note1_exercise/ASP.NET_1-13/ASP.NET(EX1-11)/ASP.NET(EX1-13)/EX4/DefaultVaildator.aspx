<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultVaildator.aspx.cs" Inherits="ASP.NET_EX4._1_.ASP_NET_EX4__1_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="TextBox1"></asp:Label>
        </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="帳號必須輸入"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label2" runat="server" Text="TextBox2"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="必須介於 10-80 " MaximumValue="80" MinimumValue="10" Type="Integer"></asp:RangeValidator>
        <br />
        <asp:Label ID="Label3" runat="server" Text="TextBox3"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="TextBox4"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox3" ControlToValidate="TextBox4" ErrorMessage="TextBox 4 要和 3 一致"></asp:CompareValidator>
        <br />
        <asp:Label ID="Label5" runat="server" Text="TextBox5"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox5" ErrorMessage="要電郵格式" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    </form>
</body>
</html>
