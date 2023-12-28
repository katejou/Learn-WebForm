<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Blob_download.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: auto; margin-top: 100px; text-align: center; vertical-align: central;">
            <asp:Label ID="Label1" runat="server" Text="FILE_ID : "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" autocomplete="off"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="下載" OnClick="Button1_Click" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center"></asp:GridView>
        </div>
    </form>
</body>
</html>
