<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomValidator.aspx.cs" Inherits="ASP.NET_EX4._2_.ASP_NET_EX4__2_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>自定義檢查</title>
    <script type="text/javascript" > 
        function Client_Validate(sender,e) 
        { 
        if (e.Value % 2 ==0) 
            e.IsValid=true; 
        else 
            e.IsValid=false; 
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="必須為偶數" EnableClientScript="False" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="123456" ValidationExpression="\d"></asp:RegularExpressionValidator>
            <br />
            <asp:Button ID="Button1" runat="server" Text="檢查" />
        </div>
    </form>
</body>
</html>
