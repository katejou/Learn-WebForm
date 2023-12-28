<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Debug_ex.aspx.cs" Inherits="note3_ex1.ProcessControl.Debug_ex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br/><br/>
            <asp:TextBox ID="TextBox1" runat="server" Text=""></asp:TextBox>
            <br/><br/>
            <asp:Button ID="Button1" runat="server" Text="上面不輸入，會跳出警告窗戶" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
