<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Session_buybucket.aspx.cs" Inherits="note2_ex.Session_buybucket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                <asp:ListItem Value="Book1"></asp:ListItem>
                <asp:ListItem Value="Book2"></asp:ListItem>
                <asp:ListItem Value="Book3"></asp:ListItem>
                <asp:ListItem Value="Book4"></asp:ListItem>
            </asp:CheckBoxList>
            <asp:Button ID="Button1" runat="server" Text="加入購物籃" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" PostBackUrl="~/Session_Payment.aspx" Text="結帳" />
            <br />
<%--            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Session_Payment.aspx">結帳</asp:HyperLink>--%>
            <br/>

        </div>
    </form>
</body>
</html>
