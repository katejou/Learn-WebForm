<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="muti_langGlobla3.aspx.cs" Inherits="note2_ex.muti_lang2withfiles" 
   
    %>
 <%-- UICulture="auto" Culture="auto" 要取消這兩個，後端才可以自訂Page.UICulture--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_SelectedIndexChanged" >
                <asp:ListItem value="zh_TW">中文</asp:ListItem>
                <asp:ListItem value="en_US">英文</asp:ListItem>
                <asp:ListItem value="ja_JP">日文</asp:ListItem>
            </asp:DropDownList>
            <br/>
            <asp:Label ID="Lang1" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Zero1" runat="server" Text="<%$ Resources:LanguageResource, Zero %>"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
