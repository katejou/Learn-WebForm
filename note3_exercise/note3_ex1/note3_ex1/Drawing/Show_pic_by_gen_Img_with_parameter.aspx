<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show_pic_by_gen_Img_with_parameter.aspx.cs" Inherits="note3_ex1.Drawing.Show_pic_by_gen_Img_with_parameter" %>

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
            <h2>輸入參數，用程式畫棒形圖</h2>
            <br />
            <asp:Label ID="Label1" runat="server" Text="輸入 ( 0 ~ 100 ) ︰ "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="輸入 ( 0 ~ 100 ) ︰ "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="輸入 ( 0 ~ 100 ) ︰ "></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="生成圖片" OnClick="Button1_Click" />
            <br />
            <br />
            <hr />
            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <br />
        </div>
    </form>
</body>
</html>
