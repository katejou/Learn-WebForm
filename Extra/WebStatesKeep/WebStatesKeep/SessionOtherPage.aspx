<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionOtherPage.aspx.cs" Inherits="ASP.NET_Extra.SessionOtherPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            同一個網站的另一個分頁，如果用戶沒有關過連線， Session 的變數值應該還是在的。<br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="顯示另一頁存下的 Session 變數" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="ShowSession" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="在這裡修改Session變數" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="回去上一頁，看看變數是否被修改" OnClick="Button3_Click" />
            <br />
        </div>
    </form>
</body>
</html>
