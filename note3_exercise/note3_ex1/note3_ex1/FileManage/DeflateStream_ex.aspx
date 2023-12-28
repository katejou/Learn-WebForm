<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeflateStream_ex.aspx.cs" Inherits="note3_ex1.FileManage.DeflateStream_ex" %>

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
            DeflateStream 壓縮 和 解壓縮
            <br />
            <br />
            <asp:Button ID="Compress" runat="server" Text="壓縮檔案" OnClick="Compress_Click" />
            &nbsp;
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <asp:Button ID="DeCompress" runat="server" Text="解壓縮檔案" OnClick="DeCompress_Click" />
            &nbsp;
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
