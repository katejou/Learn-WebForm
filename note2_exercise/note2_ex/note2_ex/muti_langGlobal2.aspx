<%@ Page
    Culture="auto" UICulture="auto"
    Language="C#" AutoEventWireup="true" CodeBehind="muti_langGlobal2.aspx.cs" Inherits="note2_ex.muti_langGlobal2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script>
        function Backup() {
<%--            if (!confirm('<%=this.GetGlobalResourceObject(("LanguageResource","Zero")%>'))
                return;--%>
            //在前端使用資源檔
            // 警告說版本太舊，無法使用。
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources: LanguageResource, Zero %>"></asp:Literal>
            <br />
            <asp:Label ID="Label1" runat="server" Text="後端方法一"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="後端方法二"></asp:Label>
        </div>
    </form>
</body>
</html>
