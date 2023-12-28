<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupValidator.aspx.cs" Inherits="ASP.NET_EX4._3_.ASP_NET_EX4__3_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

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
            <asp:Label ID="Label1" runat="server" Text="RequiredFieldValidator"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="必填" ValidationGroup="group1">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label2" runat="server" Text="RangeValidator             "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="10-20的數字" MaximumValue="20" MinimumValue="10" Type="Integer" ValidationGroup="group1">*</asp:RangeValidator>
            <br />
            <asp:Label ID="Label3" runat="server" Text="CompareValidator"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="CompareValidator"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox3" ControlToValidate="TextBox4" ErrorMessage="上下欄對比不合" ValidationGroup="group1">*</asp:CompareValidator>
            <br />
            <asp:Label ID="Label5" runat="server" Text="RegularExpressionValidator"></asp:Label>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox5" ErrorMessage="a / b" ValidationExpression="a|b" ValidationGroup="group1">*</asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="檢查上面的" ValidationGroup="group1" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="group1" Font-Names="Arial" Font-Size="Large" ForeColor="Black" HeaderText="錯誤如下︰" Height="49px" Width="100%" />
            <br />
            <br />
            <br />
            <br />
            CustomValidator<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox6" ErrorMessage="要偶數" OnServerValidate="CustomValidator1_ServerValidate">*</asp:CustomValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox6" ErrorMessage="必需是數字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="檢查下面的" />
            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
