<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="table_inGV.aspx.cs" Inherits="test.table_inGV" %>

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
            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Add_Click" />
            <br />
            <br />
            <asp:GridView
                ID="GV"
                runat="server"
                Width="500"
                AutoGenerateColumns="false" CellPadding="10" ShowHeader="false">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="Del_Box" runat="server" Text="刪除" OnClick="Del_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div>
                                <asp:Label runat="server" Text="A" Font-Size="Small"></asp:Label>
                                <asp:TextBox ID="A" runat="server"></asp:TextBox>

                            </div>
                            <div>
                                <asp:Label runat="server" Text="C" Font-Size="Small"></asp:Label>
                                <asp:TextBox ID="C" runat="server"></asp:TextBox>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div>
                                <asp:Label runat="server" Text="B" Font-Size="Small"></asp:Label>
                                <asp:TextBox ID="B" runat="server"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label runat="server" Text="D" Font-Size="Small"></asp:Label>
                                <asp:TextBox ID="D" runat="server"></asp:TextBox>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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
