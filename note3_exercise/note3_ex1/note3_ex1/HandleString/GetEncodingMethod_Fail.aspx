<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetEncodingMethod_Fail.aspx.cs" Inherits="note3_ex1.HandleString.GetEncodingMethod" %>

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
            <asp:TextBox ID="TextBox1" runat="server" Enabled="false">test.txt</asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button_isUTF8" runat="server" Text="是否UTF8的文件？" OnClick="Button_isUTF8_Click" />
            <br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Enabled="false" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
