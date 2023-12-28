<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceController_ex.aspx.cs" Inherits="note3_ex3.ServiceController_ex" %>

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
            ServiceController 類別使用
            <br/>
            (前提是服務已安裝，詳見筆記)
            <br/><br/>
            <asp:Button ID="Button1" runat="server" Text="啟動" OnClick="Button1_Click" />
             <br/><br/>
            <asp:Button ID="Button2" runat="server" Text="停止" OnClick="Button2_Click" />
            <br/><br/>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br/>
            <br/>
        </div>
    </form>
</body>
</html>
