<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Localize_control.aspx.cs" Inherits="note2_ex.Localize_control"
    Culture="auto" UICulture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Lb1" runat="server" Text="meta:resourcekey 和 Localize控制項 的使用"></asp:Label>
            <br />
            <asp:Localize ID="Localize1" runat="server"
                meta:resourceKey="Localize1">
            </asp:Localize>
            <br />
            <asp:Label ID="Label1" runat="server"
                meta:resourceKey="Localize1"></asp:Label>
            <br />
            <asp:Localize ID="Localize2" runat="server"
                Text="<%$Resources:LanguageResource,Zero%>"> 
            </asp:Localize>
            <br />
            <br />
            搞不懂Localize和Label有什麼差別︰
            <br />
            https://docs.microsoft.com/zh-tw/dotnet/api/system.web.ui.webcontrols.localize?view=netframework-4.8
            <br />
            <br />
            <asp:Button ID="bt1" runat="server" Text="<%$ Resources:name %>" OnClick="bt1_Click"></asp:Button>
            <br />
            <asp:Localize ID="Localize3" runat="server"
                Text="Hello World!!"> 
            </asp:Localize>
            <br />
            <br />
            https://stackoverflow.com/questions/5123287/when-should-i-use-a-localize-control-instead-of-a-literal
             <br />
            這個網頁說︰Localize控制項，可以讓你在「頁面設計模式」下工作時，「看到默認值」。其他和Label沒有差。
        </div>
    </form>
</body>
</html>
