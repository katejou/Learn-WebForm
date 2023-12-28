<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attribute_XML_serial_ex.aspx.cs" Inherits="note3_ex1.Serialize.Attribute_XML_serial_ex" %>

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
            <h2>XML 序列化 : 使用 Attri 和 組合其他物件 的物件 </h2>
            <h3>使用 Attri</h3>
            <asp:Label ID="Label1" runat="server" Text="物件->序列化->檔案 : "></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="檔案->反序列化->物件 : "></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>

            <h3>「不用 Attri」的 物件串列物件 </h3>
            <asp:Label ID="Label4" runat="server" Text="物件->序列化->檔案 : "></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text="檔案->反序列化->物件 : "></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>

            <h3>「使用 Attri」的 物件串列物件 </h3>
            <asp:Label ID="Label7" runat="server" Text="物件->序列化->檔案 : "></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" Text="檔案->反序列化->物件 : "></asp:Label>
            <br />
            <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
