<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profile_ex1.aspx.cs" Inherits="note2_ex2.profile_ex1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>登入者︰</td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>名稱︰</td>
                    <td>
                        <asp:TextBox ID="name" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>生日︰</td>
                    <td>
                        <asp:TextBox ID="bir_day" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>婚姻︰</td>
                    <td>
                        <asp:CheckBox ID="mary" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>風格︰</td>
                    <td>
                        <asp:TextBox ID="style" runat="server"></asp:TextBox>
                        CH / JP
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="存檔" OnClick="Button1_Click" />

                    </td>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/login.aspx">回登入頁</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
