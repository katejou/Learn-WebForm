<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_control_ex1.aspx.cs" Inherits="note2_ex3.user_control_ex1" %>

<%@ Register Src="WebUserControl1.ascx" TagName="myCalendar" TagPrefix="Ucom" %>
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
            從WebUserControl1.ascx引用前三個控制項，並從引用之中，後端能取得它們的值
            <br />
            <br />
            <Ucom:myCalendar ID="MyCalendarl" runat="server" />
            <asp:Button ID="Button1" runat="server" Text="取得從WebUserControl1.ascx而來的值" OnClick="Button1_Click"></asp:Button>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
