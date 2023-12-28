<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IsolatedStorageFile_ex.aspx.cs" Inherits="note3_ex1.FileManage.IsolatedStorageFile_ex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JS/jquery.js"></script>
    <script src="../JS/ctrls.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <h3>IsolatedStorageFile</h3>
            <br />
            <asp:Button ID="OpenRead" runat="server" Text="開啟及讀出" OnClick="OpenRead_Click" />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Enabled="False"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <hr />
            <br />
            <asp:Button ID="OpenWrite" runat="server" Text="開啟及寫入" OnClick="OpenWrite_Click" />
            <br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <hr />
            <br />

        </div>
    </form>
</body>
</html>
