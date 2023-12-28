<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="custom_control_ex1.aspx.cs" Inherits="note2_ex3.usingCustomCtrl" %>

<%@ Register Assembly ="note2_ex3" Namespace="note2_ex3" TagPrefix="ccs" %>
<%@ Register Assembly="note2_ex3_cusCtrl" Namespace="note2_ex3_cusCtrl" TagPrefix="ccs2" %>
<%@ Register Assembly="note2_ex3" Namespace="note2_ex3_btn_2" TagPrefix="cc" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ccs:WebCustomControl1 runat="server" Text="Hello" />
            <br />
            <ccs2:WebCustomControl2 runat="server" Text="Hi" />
            <br />
            <cc:WebCustomBtn2 runat="server" ID="CustomControl1" Text="可以累加的按鈕" />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
