<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alterConfig_Save.aspx.cs" Inherits="note3_ex1.ConfigAlter.alterConfig_Save" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <h3>動態修改 Web.config</h3>
            <hr />
            <br />
            <asp:Button ID="alertCS" runat="server" Text="改ConnectionString" OnClick="alertCS_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="更改後為目前的年月日時分秒︰"></asp:Label>
            <asp:Label ID="CSnow" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <hr />
            <br />
            <asp:Button ID="Button1" runat="server" Text="改appSettings" OnClick="alertAS_Click" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="更改後為目前的日期時間︰"></asp:Label>
            <asp:Label ID="ASnow" runat="server" Text=""></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
