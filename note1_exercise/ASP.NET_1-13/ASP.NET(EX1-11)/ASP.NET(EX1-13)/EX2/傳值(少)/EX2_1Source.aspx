<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EX2_1Source.aspx.cs" Inherits="ASP.NET_EX2._1_.Source" %>

<!DOCTYPE html>
   <!--  我是註解  -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            我是來源<br />
            <br />
        </div>
        <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="測試 Query String" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" PostBackUrl="EX2_1Target2.aspx" Text="測試 Form" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" PostBackUrl="EX2_1Target3.aspx" Text="測試 PreviousPage 的 Property" />
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" PostBackUrl="EX2_1Target4.aspx" Text="測試 PreviousPage.FindControl" />
        <br />
        <br />
    </form>
</body>
</html>
