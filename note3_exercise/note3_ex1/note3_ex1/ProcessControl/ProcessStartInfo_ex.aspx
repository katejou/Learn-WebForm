<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProcessStartInfo_ex.aspx.cs" Inherits="note3_ex1.ProcessControl.ProcessStartInfo_ex" %>

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
            <hr />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="用程式開啟程序" OnClick="Button1_Click" />
            &nbsp;&nbsp;
            <asp:CheckBox ID="CheckBox1" runat="server" />
            不要勾這個步驟，因為目前沒有想研究這個身份驗証東東
            <br />
            <br />
            <hr />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="Button2" runat="server" Text="用程式關閉程序" OnClick="Button2_Click" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
