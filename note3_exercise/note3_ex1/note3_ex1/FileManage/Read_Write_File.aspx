<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Read_Write_File.aspx.cs" Inherits="note3_ex1.FileManage.Read_Write_File" %>

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
            OriginalFile.txt
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="讀檔->顯示內容" OnClick="Button1_Click"></asp:Button>
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="內容->寫回檔案" OnClick="Button2_Click"></asp:Button>
        </div>
    </form>
</body>
</html>
