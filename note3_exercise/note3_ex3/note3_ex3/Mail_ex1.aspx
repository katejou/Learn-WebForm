<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mail_ex1.aspx.cs" Inherits="note3_ex3.Mail_ex1" Async="true" %>

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
            <br />
            <br />
            在VPN的連線下無法使用公司的電郵伺服器
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="寄一封郵件給自己" OnClick="Button1_Click" />
            之前工作上的實例
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="寄一封郵件給自己" OnClick="Button2_Click" />
            PDF上的實作一
            P638<br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="寄一封郵件給自己" OnClick="Button3_Click" />
            PDF上的實作二
            P654<br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
