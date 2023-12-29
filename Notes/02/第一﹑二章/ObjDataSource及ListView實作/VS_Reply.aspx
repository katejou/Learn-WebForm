<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VS_Reply.aspx.cs" Inherits="Project1.VS_Reply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>VSAP 850 Reply</title>
    <link rel="stylesheet" href="~/CSS/askey.css" />
    <link rel="stylesheet" href="~/CSS/jquery-ui.css" />
    <link rel="stylesheet" href="~/CSS/ADD_Common.css" />
    <script src="<%: ResolveUrl("~/JS/jquery.js") %>"></script>
    <script src="<%: ResolveUrl("~/JS/jquery-ui.js") %>"></script>
    <script src="<%: ResolveUrl("~/JS/Reply_VS.js") %>"></script>
    <script></script>
    <style>
        /* keep DDL text center */
        select {
            text-align-last: center;
        }
        input {
            text-align-last: center;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" onkeydown="return(event.keyCode!=13)">
        <div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <!--標題-->
            <span class="Title">
                <asp:Label runat="server" ID="Title">VSAP 850 Reply</asp:Label>
            </span>
            <br />
            <br />
        </div>
        <table border="1" align="center" cellpadding="1" cellspacing="1" width="1024px">
            <tr>
                <td class="ButtonField">&nbsp;&nbsp;&nbsp;<asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Confirm" OnClientClick="return verify();" />
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td class="ColumnField" width="25%">
                                <asp:Label ID="lb_PO" runat="server">訂單號碼</asp:Label>
                            </td>
                            <td class="Context" width="25%">
                                <asp:ObjectDataSource ID="ObjectDataSource2" runat="server"
                                    SelectMethod="get850_PO"
                                    TypeName="Project1.App_Code.VS850.ObjDataSource">
                                    <SelectParameters>
                                        <asp:QueryStringParameter
                                            Name="seqid"
                                            QueryStringField="HEAD"
                                            Type="String"></asp:QueryStringParameter>
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:Repeater ID="rpt" runat="server" DataSourceID="ObjectDataSource2">
                                    <ItemTemplate>
                                        <asp:TextBox ID="tb_PO" runat="server" Width="80%" ReadOnly="true" Text='<%#Eval("PURCHASE_ORDER_NUMBER")%>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </td>
                            <td class="ColumnField" width="25%">
                                <asp:Label ID="lb_ACKNOWLEDGMENT_TYPE" runat="server">回覆類型</asp:Label>
                            </td>
                            <td class="Context" width="25%">
                                <asp:DropDownList ID="ddl_ACKNOWLEDGMENT_TYPE" runat="server" Width="80%" onchange="ac_type_change(this.value);">
                                    <asp:ListItem Value="AD">AD -- 訂單無變更</asp:ListItem>
                                    <asp:ListItem Value="AC">AC -- 訂單有變更</asp:ListItem>
                                    <asp:ListItem Value="AE">AE -- 訂單Exception</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="div_LV" style="display: none">
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"
                            SelectMethod="get850_LV"
                            TypeName="Project1.App_Code.VS850.ObjDataSource">
                            <SelectParameters>
                                <asp:QueryStringParameter
                                    Name="seqid"
                                    QueryStringField="HEAD"
                                    Type="String"></asp:QueryStringParameter>
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ListView ID="ListView_Line" runat="server"
                            ItemPlaceholderID="itemPlaceholder" DataSourceID="ObjectDataSource1">
                            <LayoutTemplate>
                                <table border="1" id="LV_Line" style="color: #000066; width: 1024px; border-collapse: collapse; text-align: center;">
                                    <tbody>
                                        <tr>
                                            <th scope="col">序列號</th>
                                            <th scope="col" width="10%">料號</th>
                                            <th scope="col" width="15%">明細狀態</th>
                                            <th scope="col" width="20%">修改訂單日期</th>
                                            <th scope="col">訂單日期</th>
                                            <th scope="col" width="20%">修改訂單數量</th>
                                            <th scope="col">訂單數量</th>
                                        </tr>
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr style="background-color: White; height:26px;">
                                    <td>
                                        <asp:Label ID="lb_PODETAIL_SEQID" runat="server" Text='<%#Eval("PODETAIL_SEQID")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="lb_MANUFACTURER_ID" runat="server" Text='<%#Eval("MANUFACTURER_ID")%>' />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="LINE_ITEM_STATUS_CODE" Width="200" Style="text-align: center;" runat="server" onchange="SC_ddlChange(this)">
                                            <asp:ListItem Value="IA">IA -- ACCEPT</asp:ListItem>
                                            <asp:ListItem Value="BP">BP -- 變更數量</asp:ListItem>
                                            <asp:ListItem Value="DR">DR -- 變更日期</asp:ListItem>
                                            <asp:ListItem Value="ID">ID -- DELETE</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="tb1" ID="PROMISED_FOR_SHIPMENT_DATE" runat="server" Style="display: inline-block;" />
                                    </td>
                                    <td>
                                        <asp:Label ID="hf_SD" runat="server" Text='<%#Eval("REQUESTED_SHIP_DATE")%>' />
                                    </td>
                                    <td>
                                        <asp:TextBox ID="BACKORDERED_QUANTITY" autocomplete="off" runat="server" Style="display: inline-block;" onkeyup="value=value.replace(/[^\d]/g,'')" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lb_QUANTITY_ORDERED" runat="server" Text='<%#Eval("QUANTITY_ORDERED")%>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
