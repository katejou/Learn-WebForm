<%@ Page Language="C#" EnableViewState="false" AutoEventWireup="true" CodeBehind="custom_control_state_keep.aspx.cs" Inherits="note2_ex3.WebForm1" %>

<!DOCTYPE html>
<%@ Register Assembly="note2_ex3_cusBtn" Namespace="note2_ex3_btn" TagPrefix="cc" %>
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
            <cc:WebCustomBtn runat="server" ID="CustomControl1" Text="可以累加的按鈕" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
