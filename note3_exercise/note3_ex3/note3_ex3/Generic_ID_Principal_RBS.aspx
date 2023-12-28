<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Generic_ID_Principal_RBS.aspx.cs" Inherits="note3_ex3.Generic_ID_Principal_RBS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br/>
            <br/>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br/>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br/>
            <asp:Button ID="Button1" runat="server" Text="宣告式(管理者使用方法)" OnClick="Button1_Click" />
            <br/>
            <asp:Button ID="Button2" runat="server" Text="命令式(顯示不同查詢資料)" OnClick="Button2_Click" />
            <br/>
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <br/>
        </div>
    </form>
</body>
</html>
