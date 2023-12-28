<%--<%@ OutputCache CacheProfile="myprofile" %>--%>
<%@ OutputCache Duration="10" VaryByParam="None" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cache_profile_or_tag_ex1.aspx.cs" Inherits="note2_ex4.cache_profile_ex1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:Button runat="server" Text="更新時間。但是我知道它10秒之內，Cache會給我同一個結果"></asp:Button>
        </div>
    </form>
</body>
</html>
