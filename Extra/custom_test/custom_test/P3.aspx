<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="P3.aspx.cs" Inherits="custom_test.P3" %>

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
            <table>
                <tr>
                    <td style="padding: 0px 20px 0px 20px;">
                        <asp:Button ID="Last" runat="server" Text="上一步" OnClick="Last_Page" Width="225px" />
                    </td>
                    <td style="text-align: center;">
                        <asp:Label ID="title_lb" runat="server" Text="Invoice" Font-Size="Larger" Font-Bold="True" Width="870px"></asp:Label>
                    </td>
                    <td style="padding: 0px 20px 0px 20px;">
                        <asp:Button ID="Next" runat="server" Text="下一步" OnClick="Next_Page" Width="225px" /></td>
                </tr>
            </table>
            <hr />
            <table style =" width:1410px; text-align:center;">
                <tr>
                    <td >
                        <asp:GridView
                            ID="Inv_GV"
                            runat="server"
                            AutoGenerateColumns="false" CellPadding="3">
                            <HeaderStyle BackColor="Black" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="貨號" Font-Size="Small"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="item_no" runat="server" Width="50" BackColor="Black" ForeColor="White" Style="text-align: center;"><%# (Container.DataItemIndex+1).ToString()%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="單據號碼" Font-Size="Small" Width="150"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="inv_no" runat="server" Width="150" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="ASKEY PN" Font-Size="Small" Width="150"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="askey_pn" runat="server" Width="150"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="Description of Goods" Font-Size="Small"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="desc_good" runat="server" Enabled="false" Width="150"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="核銷報單/項次" Font-Size="Small"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="dec_item" runat="server" Width="150"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="H.S. CODE" Font-Size="Small"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="hs_code" runat="server" Width="100"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="BRAND" Font-Size="Small"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="brand" runat="server" Width="150"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="C.O.O." Font-Size="Small"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="coo" runat="server" Width="150"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="QTY. (PSC)" Font-Size="Small"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="qty" runat="server" Width="100"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="UNIT PRICE" Font-Size="Small"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="unit_price" runat="server" Width="100"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
