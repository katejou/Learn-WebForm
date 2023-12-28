<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webStatus_computerUser_Show.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            User.Identity.name <br />
            Name&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;
            <asp:Label runat="server" ID="Label1" ForeColor="Fuchsia"></asp:Label>
            <br /> <br />
            User.Identity.AuthenticationType <br />
            Authentication Type&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp; <asp:Label runat="server" ID="Label2" ForeColor="Fuchsia"></asp:Label>
            <br /> <br />
            System.Security.Principal.WindowsIdentity.GetCurrent().Name <br />
            Window Identity&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp; <asp:Label runat="server" ID="Label3" ForeColor="Fuchsia"></asp:Label>
            <br /> <br />
            HttpContext.Current.User.Identity.Name <br />
            Name&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp; <asp:Label runat="server" ID="Label4" ForeColor="Fuchsia"></asp:Label>
            <br /> <br />
            HttpContext.Current.User.Identity.AuthenticationType <br />
            AuthenticationType&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp; <asp:Label runat="server" ID="Label5" ForeColor="Fuchsia"></asp:Label>
            <br /> <br />
            HttpContext.Current.Request.LogonUserIdentity.Name <br />
            Name&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp; <asp:Label runat="server" ID="Label6" ForeColor="Fuchsia"></asp:Label>
            <br /> <br />
            HttpContext.Current.Request.LogonUserIdentity.AuthenticationType; <br />
            AuthenticationType&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp; <asp:Label runat="server" ID="Label7" ForeColor="Fuchsia"></asp:Label>
            <br /> <br />
        </div>
    </form>
</body>
</html>
