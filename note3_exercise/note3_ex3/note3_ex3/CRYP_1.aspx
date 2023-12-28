<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRYP_1.aspx.cs" Inherits="note3_ex3.SYN_CRYP" %>

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
            TripleDESCryptoServiceProvider
            <br/>
            <asp:Button ID="Button1" runat="server" Text="加密" OnClick="Button1_Click" />
            <br/>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br/>
            <asp:Button ID="Button2" runat="server" Text="解密" OnClick="Button2_Click" />
            <br/>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br/>
            <hr/>
            <br/>
            DESCryptoServiceProvider<br/>
            <asp:Button ID="Button3" runat="server" Text="加密" OnClick="Button3_Click" />
            <br/>
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <br/>
            <asp:Button ID="Button4" runat="server" Text="解密" OnClick="Button4_Click" />
            <br/>
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            <br/>
        </div>
    </form>
</body>
</html>
