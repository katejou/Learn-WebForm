<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="custom_control_composite.aspx.cs" Inherits="note2_ex3.custom_control_composite" %>

<!DOCTYPE html>
<%@ Register assembly="note2_ex3_compo_calendar" namespace="note2_ex3_compo_calendar" tagprefix="cc" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <cc:compo_ca runat="server"/>
        </div>
    </form>
</body>
</html>
