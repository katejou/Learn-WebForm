<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnClick_OnClientClick_FrontEndAlert.aspx.cs" Inherits="ASP.NET_EX3._4_.ASP_NET_EX3__4_" %>

<!DOCTYPE html>

<!-- 這個是我自已加入的涵式1-->
<script runat="server">
    void Button1_Click (object sender, EventArgs e)
      {
        Label1.Text += " Thank you for visiting our site.";
      }
</script>
<!-- 加入的地方到這裡 -->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClientClick="return check();" OnClick="Button1_Click" Text="Button" />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>

    <!-- 這個是我自已加入的涵式1-->
    <script type="text/javascript">
        function check()
        {
            alert("What?");  // 跳出小視窗, 要按確定才能過去。
            // Button1_Click();
            return true;  // 程式是會先做 OnClientClick 再做 OnClick 的，如果這裡回傳 false, 那 Button1_Click 就不會做了。
        }                                 // 除非在return前，呼叫 Button1_Click()
    </script>
    <!-- 加入的地方到這裡 -->

</body>
</html>
