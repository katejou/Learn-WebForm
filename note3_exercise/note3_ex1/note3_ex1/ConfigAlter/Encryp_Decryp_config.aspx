<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encryp_Decryp_config.aspx.cs" Inherits="note3_ex1.ConfigAlter.Encryp_Decryp_config" %>

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
            <h3>動態加密解密 Web.config </h3>
            <hr />
            <br />
            <asp:Button ID="Encrypt" runat="server" Text="加密" OnClick="Encrypt_Click" />
            <br />
            <br />
            <asp:Button ID="Decrypt" runat="server" Text="解密" OnClick="Decrypt_Click" />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
