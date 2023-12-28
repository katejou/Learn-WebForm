<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="callingASHX.aspx.cs" Inherits="note2_ex4.callingASHX" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/JPGHandler.ashx">我要小狗</asp:HyperLink>
        </div>
    </form>
</body>
</html>
