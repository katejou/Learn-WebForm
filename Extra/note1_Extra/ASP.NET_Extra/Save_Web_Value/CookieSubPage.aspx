<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CookieSubPage.aspx.cs" Inherits="ASP.NET_Extra.Cookie_Sever" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            顯示另一頁的 Cookie 值︰&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <a href="https://dotblogs.com.tw/shadow/2011/12/15/62306">https://dotblogs.com.tw/shadow/2011/12/15/62306</a><br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="更改這一個Cookie變成二維" />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="一次列印二維Cookie" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="分開列印二維Cookie" Width="222px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <br />
            <br />
            測到了有沒有 Server.UrlEncode 和 Server.UrlDecode 的差別，為了防止亂碼，還是所有 Cookie 值設或讀時 都加上這兩個東西吧。<br />
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="更改這一個Cookie變成二維" />
            <br />
            <br />
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="一次列印二維Cookie" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label6" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="分開列印二維Cookie" Width="222px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label7" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="回去上一頁，實作調整時效" Width="222px" />
            <br />
        </div>
    </form>
</body>
</html>
