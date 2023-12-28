<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="P1.aspx.cs" Inherits="custom_test.P1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 27px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />
            <table>
                <tr>
                    <td style="padding: 0px 20px 0px 20px;">
                        <asp:Button ID="Cancel" runat="server" Text="回到主頁" OnClick="Last_Page" Width="225px" />
                    </td>
                    <td style="text-align: center; ">
                        <asp:Label ID="title_lb" runat="server" Text="Address & Others" Font-Size="Larger" Font-Bold="True" Width="870px"></asp:Label>
                    </td>
                    <td style="padding: 0px 20px 0px 20px;">
                        <asp:Button ID="Next" runat="server" Text="下一步" OnClick="Next_Page" Width="225px" /></td>
                </tr>
            </table>
            <hr />
            <table>
                <tr>
                    <td colspan="2" class="auto-style1">
                        <div style="float: left; text-align: center; padding: 0px 20px 0px 20px;">
                            <asp:Label ID="lb_ship_from" runat="server" Text="Ship From" Font-Bold="true" BackColor="Black" ForeColor="White" Width="225"></asp:Label>
                        </div>
                        <div style="float: left; padding: 0px 20px 0px 20px;">
                            <asp:DropDownList ID="ddl_ship_from" runat="server" Width="225px">
                                <asp:ListItem>地點一</asp:ListItem>
                                <asp:ListItem>地點二</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="float: left; text-align: center;">
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:Label ID="lb_sfc" runat="server" Text="Company" Width="223" BorderWidth="1"></asp:Label>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:Label ID="lb_sfa" runat="server" Text="Address" Width="223" BorderWidth="1"></asp:Label>
                        </div>
                    </td>
                    <td>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:TextBox ID="tb_sfc" runat="server" Width="200"></asp:TextBox>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:TextBox ID="tb_sfa" runat="server" Width="800"></asp:TextBox>
                        </div>
                    </td>
                </tr>
            </table>
            <hr />
            <table>
                <tr>
                    <td colspan="2">
                        <div style="text-align: center; padding: 0px 20px 0px 20px; float: left;" >
                            <asp:Label ID="lb_ship_to" runat="server" Text="Ship To" Font-Bold="true" BackColor="Black" ForeColor="White" Width="225"></asp:Label>
                        </div>
                        <div style="float: left; padding: 0px 20px 0px 20px;">
                            <asp:DropDownList ID="ddl_ship_to" runat="server" Width="225px">
                                <asp:ListItem>地點一</asp:ListItem>
                                <asp:ListItem>地點二</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="float: left; text-align: center;">
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:Label ID="lb_stc" runat="server" Text="Company" Width="223" BorderWidth="1"></asp:Label>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:Label ID="lb_sta" runat="server" Text="Address" Width="223" BorderWidth="1"></asp:Label>
                        </div>
                    </td>
                    <td>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:TextBox ID="tb_stc" runat="server" Width="200"></asp:TextBox>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:TextBox ID="tb_sta" runat="server" Width="800"></asp:TextBox>
                        </div>
                    </td>
                </tr>
            </table>
            <hr />
            <table>
                <tr>
                    <td colspan="2">
                        <div style="float: left; text-align: center; padding: 0px 20px 0px 20px;">
                            <asp:Label ID="lb_bill_to" runat="server" Text="Bill To" Font-Bold="true" BackColor="Black" ForeColor="White" Width="225"></asp:Label>
                        </div>
                        <div style="float: left; padding: 0px 20px 0px 20px;">
                            <asp:DropDownList ID="ddl_bill_to" runat="server" Width="225px" AutoPostBack="true" OnSelectedIndexChanged="ddl_bill_to_SelectedIndexChanged">
                                <asp:ListItem>同上</asp:ListItem>
                                <asp:ListItem>地點二</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
            </table>
            <asp:PlaceHolder ID="pl_same" runat="server" Visible="false">
                 <table>
                    <tr>
                        <td style="float: left; text-align: center;">
                            <div style="padding: 5px 20px 5px 20px;">
                                <asp:Label ID="lb_btc" runat="server" Text="Company" Width="223" BorderWidth="1"></asp:Label>
                            </div>
                            <div style="padding: 5px 20px 5px 20px;">
                                <asp:Label ID="lb_bta" runat="server" Text="Address" Width="223" BorderWidth="1"></asp:Label>
                            </div>
                        </td>
                        <td>
                            <div style="padding: 5px 20px 5px 20px;">
                                <asp:TextBox ID="tb_btc" runat="server" Width="200"></asp:TextBox>
                            </div>
                            <div style="padding: 5px 20px 5px 20px;">
                                <asp:TextBox ID="tb_bta" runat="server" Width="800"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                 </table>
            </asp:PlaceHolder>
            <hr />
            <table>
                <tr>
                    <td colspan="2">
                        <div style="float: left; text-align: center; padding: 0px 20px 0px 20px;">
                            <asp:Label ID="lb_others" runat="server" Text="Others" Font-Bold="true" BackColor="Black" ForeColor="White" Width="225"></asp:Label>
                        </div>
                        <div style="float: left; padding: 0px 20px 0px 20px;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="float: left; text-align: center;">
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:Label ID="lb_inv" runat="server" Text="InvoiceNo" Width="223" BorderWidth="1"></asp:Label>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:Label ID="lb_dn" runat="server" Text="DeclarationNo" Width="223" BorderWidth="1"></asp:Label>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:Label ID="lb_rf" runat="server" Text="Reference" Width="223" BorderWidth="1"></asp:Label>
                        </div>
                    </td>
                    <td>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:TextBox ID="tb_inv" runat="server" Width="300"></asp:TextBox>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:TextBox ID="tb_dn" runat="server" Width="300"></asp:TextBox>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:TextBox ID="tb_rf" runat="server" Width="300"></asp:TextBox>
                        </div>
                    </td>
                    <td style="float: left; text-align: center;">
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:Label ID="lb_date" runat="server" Text="Date" Width="223" BorderWidth="1"></asp:Label>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:Label ID="lb_inc" runat="server" Text="Incoterm" Width="223" BorderWidth="1"></asp:Label>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:Label ID="lb_pt" runat="server" Text="Package Total" Width="223" BorderWidth="1"></asp:Label>
                        </div>
                    </td>
                    <td>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:TextBox ID="tb_date" runat="server" Width="300"></asp:TextBox>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:TextBox ID="tb_inc" runat="server" Width="300">DAP</asp:TextBox>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:TextBox ID="tb_pt" runat="server" Width="300"></asp:TextBox>
                        </div>

                    </td>

                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td style="float: left; text-align: center;">
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:Label ID="lb_att1" runat="server" Text="Attriubte1" Width="223" BorderWidth="1"></asp:Label>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:Label ID="lb_att3" runat="server" Text="Attriubte3" Width="223" BorderWidth="1"></asp:Label>
                        </div>
                    </td>
                    <td>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:TextBox ID="tb_att1" runat="server" Width="300">"#NUM#{WO_NO1/WO_NO2...}#NUM#"</asp:TextBox>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:TextBox ID="tb_att3" runat="server" Width="300"></asp:TextBox>
                        </div>
                    </td>
                    <td style="float: left; text-align: center;">
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:Label ID="lb_att2" runat="server" Text="Attriubte2" Width="223" BorderWidth="1"></asp:Label>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:Label ID="lb_att4" runat="server" Text="Attriubte4" Width="223" BorderWidth="1"></asp:Label>
                        </div>
                    </td>
                    <td>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:TextBox ID="tb_att2" runat="server" Width="300">"#INV#"{InvoiceNo}"#INV#"</asp:TextBox>
                        </div>
                        <div style="padding: 5px 20px 5px 20px;">
                            <asp:TextBox ID="tb_att4" runat="server" Width="300"></asp:TextBox>
                        </div>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
