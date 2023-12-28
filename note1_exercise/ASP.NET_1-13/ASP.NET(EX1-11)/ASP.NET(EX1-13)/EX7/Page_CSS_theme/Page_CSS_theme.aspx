<%@ Page Language="C#" Theme="theme1" AutoEventWireup="true" CodeBehind="Page_CSS_theme.aspx.cs" Inherits="ASP.NET_EX7._1_.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            測網頁層級的套用<br />
        </div>
        <br />
        這兩個Button是測 面板 的<br />
        <br />
        <asp:Button ID="Button1" SkinID ="loginBtn" runat="server" Text="Button" />
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <br />
    </form>
    <p>我是用來測 樣式板&nbsp;&nbsp; 的&nbsp;&nbsp; Element base Style </p>
    <ul typeof ="disc" class ="intro"><li>我是用來測&nbsp;&nbsp; 樣式板&nbsp;&nbsp;&nbsp;&nbsp; 的&nbsp; Class base Style </li></ul>
    <ol type="I" id ="top"><li>我是用來測&nbsp;&nbsp; 樣式板&nbsp;&nbsp;&nbsp;&nbsp; 的&nbsp; ID base Style</li></ol>
</body>
</html>
