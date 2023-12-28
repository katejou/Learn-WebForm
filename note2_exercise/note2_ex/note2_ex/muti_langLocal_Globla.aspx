<%@ Page
    Culture="auto" UICulture="auto"
    Language="C#" AutoEventWireup="true" CodeBehind="muti_langLocal_Globla.aspx.cs" Inherits="note2_ex.muti_langLocal2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="後端給值1"></asp:Label>
            <br /><br />
            <asp:Label ID="Label2" runat="server" Text="後端給值2"></asp:Label>
            <br /><br />
            <asp:Label ID="Label3" runat="server" Text="後端給值3"></asp:Label>
            <br /><br />
            <asp:Label ID="Label4" runat="server" Text="後端給值4"></asp:Label>
            <br /><br />
            <asp:Button ID="Button1" runat="server" Text="會Alert的按鈕" OnClick="Button1_Click" Style="height: 27px"></asp:Button>
            <br /><br />
            <asp:Label ID="Label5" runat="server" Text="前端給值(Local)  :  "></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Text="<%$ Resources:Label1Res.Text %>"></asp:Label>
            <br /><br />
            <asp:Label ID="Label7" runat="server" Text="前端給值2(指定ClassKey來找到Global)  :  "></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" Text="<%$ Resources:LanguageResource, Zero %>"></asp:Label>

        </div>
    </form>
</body>
</html>
