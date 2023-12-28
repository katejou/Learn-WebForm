<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dyn_Once_userControl.aspx.cs" Inherits="note2_ex3.dynamic_userControl" %>

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
            <asp:Button ID="Button2" runat="server" Text="重新載入和給值" OnClick="Load_Click" />
            <br />
            <asp:Button ID="Button3" runat="server" Text="PostBack洗不去" OnClick="PostBack_Click" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="取目前所有輸入值" OnClick="GetValue_Click" />
            <br />
            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
