<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dynamic_userControl.aspx.cs" Inherits="note2_ex3.dynamic_userControl" %>

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
            <asp:Button ID="Button1" runat="server" Text="ADD_userControl" />
            <br />
            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
