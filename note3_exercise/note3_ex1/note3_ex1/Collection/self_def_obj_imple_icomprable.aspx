<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="self_def_obj_imple_icomprable.aspx.cs" Inherits="note3_ex1.self_def_obj_imple_icomprable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br/><br/><br/>
            <asp:ListBox ID="ListBox1" runat="server" Width="200"></asp:ListBox>
            <asp:Button ID="Button1" runat="server" Text="排序" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
