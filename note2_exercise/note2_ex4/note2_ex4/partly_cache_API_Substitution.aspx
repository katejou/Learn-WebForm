<%--<%@ OutputCache CacheProfile="myprofile" %>--%>
<%@ OutputCache Duration="10" VaryByParam="None" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="partly_cache_API_Substitution.aspx.cs" Inherits="note2_ex4.partly_cache_API" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Button runat="server" Text="更新時間。但是我知道它10秒之內。(上面)Cache會給我同一個結果，(下面是即時的)"></asp:Button>
            <br />
            <% Response.WriteSubstitution(new HttpResponseSubstitutionCallback(GetCurrentDate));%>
            <%-- 記得加 ; 號 ( PDF沒有提 ) --%>
            <br />
            <asp:Substitution ID="Substitution1" runat="server" MethodName="GetCurrentDate" />
        </div>
    </form>
</body>
</html>
