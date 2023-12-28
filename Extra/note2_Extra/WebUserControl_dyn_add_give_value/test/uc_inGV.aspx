<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uc_inGV.aspx.cs" Inherits="test.dyn_can_del" %>
<%@ Register Src="uc2.ascx" TagName="myUc" TagPrefix="uc" %>
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

            <br />
            <br />
            <asp:Button ID="Add_One" runat="server" Text="新增" OnClick="Add_Click" />
            <br />
            <br />
            <asp:GridView
                ID="GV"
                runat="server"
                AutoGenerateColumns="false" ShowHeader="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="Del_Box" runat="server" Text="刪除" OnClick="Del_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <uc:myUc ID="myUc" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <%--            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>--%>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
