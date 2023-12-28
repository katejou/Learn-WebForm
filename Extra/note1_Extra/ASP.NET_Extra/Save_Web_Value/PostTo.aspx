<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostTo.aspx.cs" Inherits="ASP.NET_Extra.Save_Web_Value.PostTo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="我可以不在PageLoad 的地方取得上頁的值嗎？" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 不可以。再按一次，經過Post Back，他的上頁也已經變成了自己了。抓不到值，但是也不會出Exception之類的錯誤。<br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="回去上一頁" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </div>
    </form>

</body>
</html>
