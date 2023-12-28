<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetAllCulture_ex.aspx.cs" Inherits="note3_ex1.Globalization.GetAllCulture_ex" %>

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
            <h2>顯示所有文化及其相關資訊</h2>
            <br />
            請點選其中一個︰
            <br />
            <div style="float: left">
                <asp:ListBox ID="ListBox1" runat="server" Width="200" Height="300" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostback="true"></asp:ListBox>
            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="" Width="500"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
