<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajax_dynamic_js_string.aspx.cs" Inherits="note2_ex.ajax_dynamic_js_string" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:Button ID="Button2" runat="server" Text="加入指令碼" OnClick="Button2_Click" />
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="Button1" runat="server" Text="操作加入指令碼的按鈕" OnClientClick="SayHi();return false;" />
                    <%--在加入指令碼之前，Button1的操作，沒有任何反應。--%>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="顯示結果"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
