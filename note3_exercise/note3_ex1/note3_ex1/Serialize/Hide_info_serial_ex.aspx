<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hide_info_serial_ex.aspx.cs" Inherits="note3_ex1.Serialize.Hide_info_serial_ex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../JS/jquery.js"></script>
    <script src="../JS/ctrls.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <h2>由屬性給序值，判斷是否序列化某資料到檔案</h2>
            <br />
            <asp:Label ID="Label7" runat="server" Text="如果輸入值小於 3 則顯示薪水為 0 (=不序列化到檔案中)︰"></asp:Label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="序列化" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="反序列化" OnClick="Button2_Click" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Binary(bin)->物件 內容︰" BackColor="Yellow"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="SOAP(xml)->物件 內容︰" BackColor="Yellow"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="XML(xml)->物件 內容︰" BackColor="Yellow"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
