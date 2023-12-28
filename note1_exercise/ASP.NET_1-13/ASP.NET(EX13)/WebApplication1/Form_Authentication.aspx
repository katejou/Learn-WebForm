<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form_Authentication.aspx.cs" Inherits="WebApplication1.Form_Authentication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <p>
        登入頁面︰</p>
    <form id="form1" runat="server">
        <p>
            帳號︰&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            密碼︰&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登入" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
