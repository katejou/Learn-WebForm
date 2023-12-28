<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASP.NET_EX7._3_.WebForm1" %>

<!DOCTYPE html>

<script runat= "server">
protected void Page_PreInit(object sender, EventArgs e)
{ Page.Theme = Request.QueryString["theme"]; }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            測動態改佈景主題，用<meta charset="utf-8" />Request.QueryString()的方法。<br />
            實作HyperLink 元件，<br />
            只要在 NavigateUrl屬性 去改要傳送到的地址<br />
            還可以在後面加 ?theme=theme1 等要傳送的值。<br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="WebForm1.aspx?theme=theme2">佈景主題一</asp:HyperLink>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="WebForm1.aspx?theme=theme3">佈景主題二</asp:HyperLink>
        </div>
    </form>
</body>
</html>
