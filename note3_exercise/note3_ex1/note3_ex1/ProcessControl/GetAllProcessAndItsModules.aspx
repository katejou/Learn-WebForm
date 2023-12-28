<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetAllProcessAndItsModules.aspx.cs" Inherits="note3_ex1.Process_ex.GetAllProcessAndItsModules" %>

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
            <asp:Button ID="GetPorcesses" runat="server" Text="取目前這台電腦所有的Processes" OnClick="GetPorcesses_Click" />
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Width="300" Height="300" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
            <br />
            <br />
            顯示上面選中的Process所載入的模組︰
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <asp:ListBox ID="ListBox2" runat="server" Width="300" Height="300"></asp:ListBox>
            
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
