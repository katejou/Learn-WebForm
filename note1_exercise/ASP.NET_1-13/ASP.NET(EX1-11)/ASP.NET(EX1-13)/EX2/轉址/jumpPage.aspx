<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jumpPage.aspx.cs" Inherits="ASP.NET_EX2_.ASP_Net_EX2_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            網頁間的單純導向，不傳資料<br />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="EX2_0Target.aspx">測試超連結</asp:HyperLink>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="瀏覧器重新導向" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" PostBackUrl="EX2_0Target.aspx" Text="跨網頁 POST" />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="伺服器重導向" />
            <br />
        </div>
    </form>
</body>
</html>
