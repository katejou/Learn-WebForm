<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventLog2.aspx.cs" Inherits="note3_ex1.ProcessControl.EventLog2" %>

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
            <br />
            <asp:Button ID="Button1" runat="server" Text="讀取" OnClick="Button1_Click" />
            <%--<asp:Button ID="Button2" runat="server" Text="刪除" OnClick="Button2_Click" />--%>
            <br />
            EntryType   |  Message    |    TimeWritten
            <br />
            <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="Button2_Click" Width="150"></asp:ListBox>
            <asp:ListBox ID="ListBox2" runat="server" OnSelectedIndexChanged="Button2_Click" Width="150"></asp:ListBox>
            <asp:ListBox ID="ListBox3" runat="server" OnSelectedIndexChanged="Button2_Click" Width="150"></asp:ListBox>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="刪除" OnClick="Button2_Click" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <br />
        </div>

    </form>
</body>
</html>
