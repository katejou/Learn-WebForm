<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Context_later2.aspx.cs" Inherits="ASP.NET_Extra.Context_later2" %>

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
            使用上頁方法取得結果︰&nbsp; <asp:Label ID="result" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="回去上一頁" />
            <br />
        </div>
    </form>
</body>
</html>
