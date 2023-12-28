<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASP.NET_EX7._2_.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            我是網頁 1<br />
            <br />
            在測網站層級的主題套用<br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="我要去隔壁看看他的Theme是不是和我一樣" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="我要測某個元件不套用主題" EnableTheming="false"/>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="我要去測是否某頁可以不套用主題" OnClick="Button3_Click" />
        </div>
    </form>
</body>
</html>
