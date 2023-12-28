<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XML_serial_ex.aspx.cs" Inherits="note3_ex1.Serialize.XML_serial_ex" %>

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
            <h2>XML序列化</h2>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="物件->序列化->檔案 : " ></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="檔案->反序列化->物件 : " ></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
