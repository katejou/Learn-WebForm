<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompareInfo_ex.aspx.cs" Inherits="note3_ex1.Globalization.CompareInfo_ex" %>

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
            <h1>CompareInfo</h1>
            <br />
            string.CompareTo :  
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            CompareInfo.Compare : 
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
