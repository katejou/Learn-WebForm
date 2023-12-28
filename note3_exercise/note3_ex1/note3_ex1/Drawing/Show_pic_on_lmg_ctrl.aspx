<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show_pic_on_lmg_ctrl.aspx.cs" Inherits="note3_ex1.Drawing.Show_pic_on_lmg_ctrl" %>

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
            <br/>
            <h2>顯示程式畫的圖片於指定控制項</h2>
            <br/>
            <br/>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Drawing/flag_pic.ashx"/>
            <br/>
            <br/>
            <br/>
        </div>
    </form>
</body>
</html>
