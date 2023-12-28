<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attri_inherit_xml_serial_ex.aspx.cs" Inherits="note3_ex1.Serialize.Attri_inherit_xml_serial_ex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br/>
            <h2> 繼承﹑標籤組合物件 和序列化</h2>
            <h3>組合物件同時收納父型與子型時</h3>
            <asp:Label ID="Label1" runat="server" Text="物件->序列化->檔案 : "></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="檔案->反序列化->物件 : "></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <br/>
            <br/>
            <br/>
            <br/>
            <br/>
        </div>
    </form>
</body>
</html>
