<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerformanceCounter_ex.aspx.cs" Inherits="note3_ex1.ProcessControl.PerformanceCounter_ex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br/><br/><br/>
            <asp:Button ID="Button1" runat="server" Text="建立效能計數器與種類" OnClick="Button1_Click" />
            &nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br/><br/><br/>
            <asp:Button ID="Button2" runat="server" Text="建立新訂單" OnClick="Button2_Click" />
            &nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br/><br/><br/>
        </div>
    </form>
</body>
</html>
