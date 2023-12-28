<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ACL.aspx.cs" Inherits="note3_ex3.ACL" %>

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
            <br/>
            <asp:Button ID="Button1" runat="server" Text="修改檔案權限" OnClick="Button1_Click" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br/>
            <br/>
            <asp:Button ID="Button2" runat="server" Text="改回原本的權限" OnClick="Button2_Click" />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br/>
            <br/>
            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
            <br/>
        </div>
        
    </form>
</body>
</html>
