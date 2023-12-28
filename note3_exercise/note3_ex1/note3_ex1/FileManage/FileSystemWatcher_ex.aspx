<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileSystemWatcher_ex.aspx.cs" Inherits="note3_ex1.FileManage.FileSystemWatcher_ex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JS/jquery.js"></script>
    <script src="../JS/ctrls.js"></script>
    <style>
        textarea {
            resize: none;
            height: 70px;
            width: 200px;
        }
    </style>
</head>
<body>
    <form id="form" runat="server">
        <div>

            <br />
            <asp:Label runat="server" Text="" ID="Lb1" BackColor="#ff66ff"></asp:Label>
            <br />
            <br />
            <asp:Label runat="server" Text="" ID="Lb2" BackColor="#ff9999"></asp:Label>
            <br />
            <br />
            <asp:Label runat="server" Text="" ID="Lb3" BackColor="#6699ff"></asp:Label>
            <br />
            <br />
            目前 OriginalFile.txt 檔案內容&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <%--            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            目前 NewGen.txt 檔案內容
            <br />
            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Enabled="false"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Enabled="false"></asp:TextBox>
            <br />
            <br />
            Hello World !
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="AppendAllText" runat="server" Text="File.AppendAllText" OnClick="AppendAllText_Click" />
            <br />
            <br />
            <asp:Button ID="Move" runat="server" Text="File.Move" OnClick="Move_Click" />
            剪下 OriginalFile.txt，貼上為 NewGen.txt，再創造新的 OriginalFile.txt
            <br />
            <br />
            <asp:Button ID="CreateDirectory" runat="server" Text="Directory.CreateDirectory" OnClick="CreateDirectory_Click" />
            在這個網頁目前所在的位置，創新的資料夾(如果有，會先刪後增)
        </div>
    </form>
</body>
</html>
