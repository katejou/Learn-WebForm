<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BufferStream_ex.aspx.cs" Inherits="note3_ex1.FileManage.BufferStream_ex" %>

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
            用網路WebRequest上傳和WebResponse下載檔案，來實作BufferStream
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Upload" runat="server" Text="Upload" OnClick="Upload_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Download" runat="server" Text="Download" OnClick="Download_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            HelloWorld ! 
        </div>
    </form>
</body>
</html>
