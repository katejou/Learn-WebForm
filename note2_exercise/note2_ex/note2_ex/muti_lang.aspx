<%@ Page Language="C#" Culture="auto" AutoEventWireup="true" CodeBehind="muti_lang.aspx.cs" Inherits="note2_ex.muti_lang" %>

<%--Culture="auto"，單設這一頁優先依用戶瀏覽器--%>
<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Threading" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lb0" runat="server" Text="CultrueName"></asp:Label><br />
            <asp:Label ID="lb1" runat="server" Text="CultrueName"></asp:Label><br />
            <asp:Label ID="lb2" runat="server" Text="CultrueName"></asp:Label><br />
            <asp:Label ID="lb3" runat="server" Text="CultrueName"></asp:Label><br />
            <asp:Label ID="lb4" runat="server" Text="CultrueName"></asp:Label><br />
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            <br />
            <%--在下這個範圍內的東西，因為Timer，每一秒做一下PageLoad--%> 
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lb5" runat="server" Text="time"></asp:Label><br />
                    <asp:Label ID="lb6" runat="server" Text="time"></asp:Label><br />
                    <asp:Label ID="lb7" runat="server" Text="time"></asp:Label><br />
                    <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </form>
</body>
</html>
