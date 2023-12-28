<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="input_autocompelet2.aspx.cs" Inherits="Project1.V_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>VERIZON 新增</title>

    <!--套用css的設計-->
    <link href="CSS/askey.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-3.5.1.js"></script>
    <script src="//code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#tb_SHIP_DATE").datepicker({
                dateFormat: 'yymmdd',
                numberOfMontpk: 1
            });
            $("#tb_CURRENT_SCHEDULE_SHIP").datepicker({
                dateFormat: 'yymmdd',
                numberOfMontpk: 1
            });
            $("#tb_O_DATE").datepicker({
                dateFormat: 'yymmdd',
                numberOfMontpk: 1
            });
            $("#tb_S_SHIP_TO").on('click', function () {
                $(this).val('');
            });
            $(".Context").attr("spellcheck", "false");


            //  和前一個的對比是放到了這裡，而不是控制項的下方。
            $("#tb_S_SHIP_TO")
            .autocomplete({
                minLength: 0,
                source: function (request, response) {
                    response(data);
                }
                ,
                change: function () {
                    inputSelect();
                }
                ,
                select: function (event, ui) {
                    document.getElementById('tb_S_SHIP_TO').value = ui.item.value;
                    inputSelect();
                }
            })
            .mousedown(function () {
                $(this).autocomplete('search', $(this).val())
            });

        });

        function inputSelect() {
            var selectId = $("#tb_S_SHIP_TO").val();
            if (selectId == "CDTI VERIZON WIRELESS") {
                document.getElementById('tb_S_ST_ASSIGNED_BY').value = '109727';
                document.getElementById('tb_S_ST_ADDREDSS1').value = '200 STEWART HUSTON DR';
                document.getElementById('tb_S_ST_CITY_NAME').value = 'COATESVILLE';
                document.getElementById('tb_S_ST_STATE_OR_PROVINCE_CODE').value = 'PA';
            }
            else if (selectId == "FRESNO FSL") {
                document.getElementById('tb_S_ST_ASSIGNED_BY').value = '399044';
                document.getElementById('tb_S_ST_ADDREDSS1').value = '3443 E CENTRAL AVE';
                document.getElementById('tb_S_ST_CITY_NAME').value = 'FRESNO';
                document.getElementById('tb_S_ST_STATE_OR_PROVINCE_CODE').value = 'CA';
            }
            else if (selectId == "FEDEX SUPPLY CHAIN") {
                document.getElementById('tb_S_ST_ASSIGNED_BY').value = '534503';
                document.getElementById('tb_S_ST_ADDREDSS1').value = '5425 EXPLORATION DR SUITE 200';
                document.getElementById('tb_S_ST_CITY_NAME').value = 'INDIANAPOLIS';
                document.getElementById('tb_S_ST_STATE_OR_PROVINCE_CODE').value = 'IN';
            }
        }

        var data = [
            { label: "CDTI VERIZON WIRELESS", value: 'CDTI VERIZON WIRELESS' },
            { label: "FRESNO FSL", value: 'FRESNO FSL' },
            { label: "FEDEX SUPPLY CHAIN", value: 'FEDEX SUPPLY CHAIN' }
        ];

        
    </script>
    <style type="text/css">
        .Title {
            font-size: large;
            font-weight: bold;
        }

        .Context {
            height: 30px;
            font-size: small;
            text-align: left;
        }

        .ColumnField {
            height: 30px;
            font-size: small;
            background-color: #E3EDFF;
            text-align: right;
            color: Darkcyan;
        }

        .ButtonField {
            width: 100%;
            height: 50px;
            text-align: left;
        }

        /*input::-webkit-calendar-picker-indicator {
            opacity: 100;
        }*/

        .ui-autocomplete.ui-widget {
            font-size: small;
            text-align: left;
            line-height: 1;
        }
    </style>
</head>
<body style="background-image: url(./image/logo_back3.gif);">
    <form id="form1" runat="server">
        <div>
            <br />
            <!--標題-->
            <span class="Title">VERIZON&nbsp;&nbsp;&nbsp; INSERT</span>
            <br />
            <br />
        </div>
        <table border="1" align="center" cellpadding="1" cellspacing="1" width="1024px">
            <tr>
                <td class="ButtonField">

                    <!--UseSubmitBehavior="false" 的意思是不要因為Button放在最前面，就任由鍵盤的Enter也可以去控制它-->
                    &nbsp;&nbsp;&nbsp;<asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Confirm" UseSubmitBehavior="false" />

                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">

                        <tr>
                            <td><strong>&nbsp;</strong></td>
                            <td><strong>&nbsp;</strong></td>
                            <td><strong>&nbsp;</strong></td>
                            <td><strong>&nbsp;</strong></td>
                        </tr>
                        <tr>
                            <td class="ColumnField">*
                                    <asp:Label ID="SHIP_DATE" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_SHIP_DATE" runat="server" autocomplete="off" Width="80%"></asp:TextBox>
                            </td>
                            <td class="ColumnField">
                                <asp:Label ID="PURPOSE_CODE" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:DropDownList ID="ddl_PURPOSE_CODE" runat="server" Width="80%">
                                    <asp:ListItem Value="00" Selected="True">00 Original</asp:ListItem>
                                    <asp:ListItem Value="01">01 Cancellation</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ColumnField">*
                                    <asp:Label ID="SHIPMENT_ID" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_SHIPMENT_ID" runat="server" autocomplete="off" Width="80%"></asp:TextBox>
                                &nbsp;&nbsp;
                            </td>
                            <td class="ColumnField">
                                <asp:Label ID="CURRENT_SCHEDULE_SHIP" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_CURRENT_SCHEDULE_SHIP" runat="server" autocomplete="off" Width="80%"></asp:TextBox>
                                &nbsp;</td>
                        </tr>

                        <tr>
                            <td width="25%"><strong>&nbsp;</strong></td>
                            <td width="25%"><strong>&nbsp;</strong></td>
                            <td width="25%"><strong>&nbsp;</strong></td>
                            <td width="25%"><strong>&nbsp;</strong></td>
                        </tr>
                        <tr>
                            <td class="ColumnField">
                                <asp:Label ID="S_WEIGHT_QUALIFIER" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_S_WEIGHT_QUALIFIER" runat="server" Text="G" Enabled="false" autocomplete="off" Width="80%"></asp:TextBox>
                            </td>
                            <td class="ColumnField">*
                                    <asp:Label ID="S_GROSS_WEIGHT_PER_PACK" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_S_GROSS_WEIGHT_PER_PACK" runat="server" autocomplete="off" Width="80%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ColumnField">
                                <asp:Label ID="S_WEIGHT_MEA_UNIT" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_S_WEIGHT_MEA_UNIT" runat="server" Text="LB" Enabled="false" autocomplete="off" Width="80%"></asp:TextBox>
                            </td>

                            <td class="ColumnField">*
                                <asp:Label ID="S_SHIP_TO" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <%--runat="server" 用來防止輸入值被PostBack洗去 --%>
                                <input id="tb_S_SHIP_TO" runat="server"
                                    onkeyup="inputSelect()" placeholder="Select..."
                                    style="width: 80%" />
                            </td>
                        </tr>
                        <tr>
                            <td class="ColumnField">*
                                <asp:Label ID="S_ST_ASSIGNED_BY" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_S_ST_ASSIGNED_BY" runat="server" autocomplete="off" Width="80%"></asp:TextBox>
                            </td>
                            <td class="ColumnField">*
                                <asp:Label ID="S_ST_STATE_OR_PROVINCE_CODE" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_S_ST_STATE_OR_PROVINCE_CODE" runat="server" autocomplete="off" Width="80%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ColumnField">*
                                <asp:Label ID="S_ST_ADDREDSS1" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_S_ST_ADDREDSS1" runat="server" autocomplete="off" Width="80%"></asp:TextBox>
                            </td>
                            <td class="ColumnField">*
                                <asp:Label ID="S_ST_CITY_NAME" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_S_ST_CITY_NAME" runat="server" autocomplete="off" Width="80%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td><strong>&nbsp;</strong></td>
                            <td><strong>&nbsp;</strong></td>
                            <td><strong>&nbsp;</strong></td>
                            <td><strong>&nbsp;</strong></td>
                        </tr>
                        <tr>
                            <td class="ColumnField">*
                                <asp:Label ID="O_PURCHASE_ORDER_NUMBER" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_O_PURCHASE_ORDER_NUMBER" runat="server" autocomplete="off" Width="80%"></asp:TextBox>
                            </td>
                            <td class="ColumnField">
                                <asp:Label ID="O_VENDOR_ORDER_NUMEBR" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_O_VENDOR_ORDER_NUMEBR" runat="server" autocomplete="off" Width="80%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ColumnField">*
                                <asp:Label ID="O_DATE" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_O_DATE" runat="server" autocomplete="off" Width="80%"></asp:TextBox>
                            </td>
                            <td class="ColumnField">
                                <asp:Label ID="O_INTERNAL_VENDOR_NUMBER" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_O_INTERNAL_VENDOR_NUMBER" runat="server" autocomplete="off" Width="80%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="ColumnField">
                                <asp:Label ID="O_DEPARTMENT_NUMBER" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_O_DEPARTMENT_NUMBER" runat="server" autocomplete="off" Width="80%"></asp:TextBox>
                            </td>
                            <td class="ColumnField">
                                <asp:Label ID="O_CUSTOMER_REFERENCE_NUMBER" runat="server"></asp:Label>
                            </td>
                            <td class="Context">
                                <asp:TextBox ID="tb_O_CUSTOMER_REFERENCE_NUMBER" runat="server" autocomplete="off" Width="80%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="ButtonField">&nbsp;&nbsp;&nbsp<asp:Button ID="btnQuery" runat="server" Text="ShopFloor" UseSubmitBehavior="false" OnClick="btnQuery_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="countSFrow" runat="server" Font-Size="Small" ForeColor="Black"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvShopFloor" runat="server" Width="100%"></asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
