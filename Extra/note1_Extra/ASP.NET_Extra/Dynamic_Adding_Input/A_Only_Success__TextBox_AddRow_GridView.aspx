<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="A_Only_Success__TextBox_AddRow_GridView.aspx.cs" Inherits="WebApplication1.TAG" %>

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
            <a href="https://www.aspsnippets.com/Articles/Adding-Dynamic-Rows-in-ASP.Net-GridView-Control-with-TextBoxes.aspx">https://www.aspsnippets.com/Articles/Adding-Dynamic-Rows-in-ASP.Net-GridView-Control-with-TextBoxes.aspx</a><br />
            <br />
            <br />





            <asp:GridView ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false"  >

                <Columns>

                    <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />

                    <asp:TemplateField HeaderText="Header 1">

                        <ItemTemplate>

                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Header 2">

                        <ItemTemplate>

                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Header 3">

                        <ItemTemplate>

                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

                        </ItemTemplate>

                        <FooterStyle HorizontalAlign="Right" />

                        <FooterTemplate>

                            <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" onclick="ButtonAdd_Click"/>

                        </FooterTemplate>

                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
