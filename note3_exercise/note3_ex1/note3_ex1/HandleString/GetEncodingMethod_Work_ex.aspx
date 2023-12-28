<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetEncodingMethod_Work_ex.aspx.cs" Inherits="note3_ex1.HandleString.GetEncodingMethod_Work_ex" %>

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
            <asp:TextBox ID="TextBox1" runat="server" Enabled="false">testOK_UTF8.txt</asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button_isUTF8" runat="server" Text="這個檔案，是用什麼編碼方法的？" OnClick="UTF8_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Enabled="false" TextMode="MultiLine"></asp:TextBox>
            <br />
            <hr />
            <br />
            <asp:TextBox ID="TextBox3" runat="server" Enabled="false">testOK_BIG5.txt</asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="這個檔案，是用什麼編碼方法的？" OnClick="BIG5_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TextBox4" runat="server" Enabled="false" TextMode="MultiLine"></asp:TextBox>
        </div>
    </form>
</body>
</html>
