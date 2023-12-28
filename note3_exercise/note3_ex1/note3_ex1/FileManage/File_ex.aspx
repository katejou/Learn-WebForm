<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="File_ex.aspx.cs" Inherits="note3_ex1.FileManage.File_ex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JS/jquery.js"></script>
    <script src="../JS/ctrls.js"></script>
</head>
<body>
    <form id="form" runat="server">
        <div>
            <br />
            <br />
            <asp:Button ID="WriteAllLine" runat="server" Text="WriteAllLine" OnClick="WriteAllLine_Click" />
            <br />
            <br />
            寫入檔名︰
            <asp:TextBox ID="TextBox1" runat="server" Enabled="False">NewGenFile.txt</asp:TextBox>
            <br />
            <br />
            寫入內容︰
            <br />
            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
            Hello World ! 
            <br />
            <br />
            <asp:Button ID="ReadAllLine" runat="server" Text="ReadAllLine" OnClick="ReadAllLine_Click" />
            <br />
            <br />
            讀取檔名︰
            <asp:TextBox ID="TextBox3" runat="server" Enabled="False">NewGenFile.txt</asp:TextBox>
            <br />
            <br />
            讀出內容︰
            <br />
            <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
        </div>
    </form>
</body>
</html>
