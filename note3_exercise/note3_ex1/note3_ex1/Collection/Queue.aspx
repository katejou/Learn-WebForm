<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Queue.aspx.cs" Inherits="note3_ex1.Queue" %>

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
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="抽號碼牌" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="第一號櫃台處理" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="第二號櫃台處理" OnClick="Button2_Click" />
            <asp:Button ID="Button4" runat="server" Text="第三號櫃台處理" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" Text="清場" OnClick="Button3_Click" />
        </div>
    </form>
</body>
</html>
