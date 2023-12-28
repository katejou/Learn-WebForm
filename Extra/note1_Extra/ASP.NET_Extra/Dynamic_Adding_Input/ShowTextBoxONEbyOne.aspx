<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowTextBoxONEbyOne.aspx.cs" Inherits="WebApplication1.ShowTextBoxONEbyOne" %>

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
            PlaceHolder與TextBox
            <br />
            <br />
            <asp:PlaceHolder ID="PlaceHolder0" runat="server" Visible="true">
                <asp:TextBox ID="atb" runat="server"></asp:TextBox>
                <asp:Button runat="server" ID="abt" Text="+" OnClick="abt_Click"></asp:Button>
            </asp:PlaceHolder>
            <br />
            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
                <asp:TextBox runat="server" ID="btb"></asp:TextBox>
                <asp:Button runat="server" Text="+" ID="bbt_add" OnClick="bbtadd_Click"></asp:Button>
                <asp:Button runat="server" Text="-" ID="bbt_close" OnClick="bbt_close_Click"></asp:Button>
            </asp:PlaceHolder>
            <br />
            <br />
            <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
                <asp:TextBox runat="server" ID="ctb"></asp:TextBox>
                <asp:Button runat="server" Text="+" ID="bbc_add" OnClick="bbc_add_Click"></asp:Button>
                <asp:Button runat="server" Text="-" ID="bbc_close" OnClick="bbc_close_Click"></asp:Button>
            </asp:PlaceHolder>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
