<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DriveInfo_ex.aspx.cs" Inherits="note3_ex1.FileManage.DriveInfo_ex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>DriveInfo</h3>
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Width="300"></asp:ListBox>
            <br />
            <br />
            <hr />
            <h3>Directory.GetLogicalDrives</h3>
            <br />
            <asp:ListBox ID="ListBox2" runat="server" Width="300"></asp:ListBox>
            <br />
            <br />
            <hr />
        </div>
    </form>
</body>
</html>
