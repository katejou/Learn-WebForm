<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewSubPage.aspx.cs" Inherits="ASP.NET_Extra.ViewSubPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            這是第幾個 分頁的靜態參數︰&nbsp;&nbsp; 
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            這個是以按鈕累加的 View State 參數。<br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="分頁累加" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
&nbsp;<br />
            <br />
        </div>
    </form>
</body>
</html>
