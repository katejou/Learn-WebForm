<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc2.ascx.cs" Inherits="test.uc2" ClassName="uc2" %>
<style type="text/css">
    .Context {
        height: 30px;
        font-size: small;
        text-align: left;
        width: 25%;
    }

    .ColumnField {
        height: 30px;
        font-size: small;
        background-color: #E3EDFF;
        text-align: right;
        color: Darkcyan;
        width: 25%;
    }

    Button {
        height: 10px;
    }

    .LabelPaddingStyle {
        padding: 10px 0px 10px 0px;
        text-align: center;
        background-color: white;
        border-color: silver;
        color: Darkcyan;
        height: 30px;
        width: 1024px;
        font-size: x-large;
        font-weight: bold;
    }
</style>

<table style="width: 1000px;">
    <tr>
        <td colspan="4"><strong>&nbsp;</strong></td>
    </tr>
    <tr>
        <td class="ColumnField">
            <asp:Label ID="ASSIGNED_ID" runat="server">ASSIGNED_ID</asp:Label>
        </td>
        <td class="Context">
            <asp:TextBox ID="tb_ASSIGNED_ID" runat="server" MaxLength="20" Width="80%"></asp:TextBox>
        </td>
        <td class="ColumnField">
            <asp:Label ID="QUANTITY_ORDERED" runat="server">QUANTITY_ORDERED</asp:Label>
        </td>
        <td class="Context">
            <asp:TextBox ID="tb_QUANTITY_ORDERED" runat="server" MaxLength="15" Width="80%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="ColumnField">
            <asp:Label ID="UNIT_OF_MEASURE_CODE" runat="server">UNIT_OF_MEASURE_CODE</asp:Label>
        </td>
        <td class="Context">
            <asp:TextBox ID="tb_UNIT_OF_MEASURE_CODE" runat="server" Text="EA" MaxLength="2" Width="80%"></asp:TextBox>
        </td>
        <td class="ColumnField">
            <asp:Label ID="UNIT_PRICE" runat="server">UNIT_PRICE</asp:Label>
        </td>
        <td class="Context">
            <asp:TextBox ID="tb_UNIT_PRICE" runat="server" MaxLength="10" Width="80%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="ColumnField">
            <asp:Label ID="PRODUCT_ID_QUAL1" runat="server">PRODUCT_ID_QUAL1</asp:Label>
        </td>
        <td class="Context">
            <asp:DropDownList ID="ddl_PRODUCT_ID_QUAL1" runat="server" Width="80%">
                <asp:ListItem Value="BP">BP - Buyer's Part Number</asp:ListItem>
                <asp:ListItem Value="VP">VP - Vendor's Part Number</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="ColumnField">
            <asp:Label ID="PRODUCT_ID1" runat="server">PRODUCT_ID1</asp:Label>
        </td>
        <td class="Context">
            <asp:TextBox ID="tb_PRODUCT_ID1" runat="server" MaxLength="48" Width="80%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="ColumnField">
            <asp:Label ID="PRODUCT_ID_QUAL2" runat="server">PRODUCT_ID_QUAL2</asp:Label>
        </td>
        <td class="Context">
            <asp:DropDownList ID="ddl_PRODUCT_ID_QUAL2" runat="server" Width="80%">
                <asp:ListItem Value=""></asp:ListItem>
                <asp:ListItem Value="BP">BP - Buyer's Part Number</asp:ListItem>
                <asp:ListItem Value="VP">VP - Vendor's Part Number</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="ColumnField">
            <asp:Label ID="PRODUCT_ID2" runat="server">PRODUCT_ID2</asp:Label>
        </td>
        <td class="Context">
            <asp:TextBox ID="tb_PRODUCT_ID2" runat="server" MaxLength="48" Width="80%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="ColumnField">
            <asp:Label ID="PRODUCT_DESCRIPTION" runat="server">PRODUCT_DESCRIPTION</asp:Label>
        </td>
        <td class="Context">
            <asp:TextBox ID="tb_PRODUCT_DESCRIPTION" runat="server" MaxLength="80" Width="80%"></asp:TextBox>
        </td>
        <td class="ColumnField">
            <asp:Label ID="QUOTE_QUAL" runat="server">QUOTE_QUAL</asp:Label>
        </td>
        <td class="Context">
            <asp:DropDownList ID="ddl_QUOTE_QUAL" runat="server" Width="80%">
                <asp:ListItem Value="PR">PR - Price Quote</asp:ListItem>
                <asp:ListItem Value="DQ">DQ- Delivery Quote</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="ColumnField">
            <asp:Label ID="QUOTE_NUMBER" runat="server">QUOTE_NUMBER</asp:Label>
        </td>
        <td class="Context">
            <asp:TextBox ID="tb_QUOTE_NUMBER" runat="server" MaxLength="30" Width="80%"></asp:TextBox>
        </td>
        <td class="ColumnField">
            <asp:Label ID="QUANTITY" runat="server">QUANTITY</asp:Label>
        </td>
        <td class="Context">
            <asp:TextBox ID="tb_QUANTITY" runat="server" MaxLength="15" Width="80%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="ColumnField">*
           <asp:Label ID="ARRIVALDATE" runat="server">ARRIVALDATE</asp:Label>
        </td>
        <td class="Context">
            <asp:TextBox ID="tb_ARRIVALDATE" runat="server" MaxLength="8" Width="80%"></asp:TextBox>
        </td>
        <td class="ColumnField">
            <asp:Label ID="ITEM_DESCRIPTION" runat="server">ITEM_DESCRIPTION</asp:Label>
        </td>
        <td class="Context">
            <asp:TextBox ID="tb_ITEM_DESCRIPTION" runat="server" MaxLength="45" Width="80%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="ColumnField">
            <asp:Label ID="ITEM_MSG" runat="server">ITEM_MSG</asp:Label>
        </td>
        <td class="Context">
            <asp:TextBox ID="tb_ITEM_MSG" runat="server" MaxLength="264" Width="80%"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td colspan="4"><strong>&nbsp;</strong></td>
    </tr>
</table>
