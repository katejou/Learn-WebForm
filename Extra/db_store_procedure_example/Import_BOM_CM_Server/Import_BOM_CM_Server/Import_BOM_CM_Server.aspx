<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Import_BOM_CM_Server.aspx.cs" Inherits="Import_BOM_CM_Server.Import_BOM_CM_Server" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Import BOM CM Server</title>
    <link rel="stylesheet" type="text/css" href="css/askey.css" />
    <script language="javascript" type="text/javascript">
        window.onbeforeunload = function () {
            var inpt = document.getElementsByTagName("INPUT");
            if (inpt != null) {
                for (var i = 0; i < inpt.length; i++) {
                    //	if(inpt[i].type == "submit")
                    //{
                    inpt[i].disabled = true;
                    //}
                }
            }
        }
        function checkinclude() {
            //var checkCheckBoxList = false;
            if (document.getElementById("FileUpload1").value.length <= 0) {
                alert('請選擇檔案');
                window.event.returnValue = false;
            }
        }
        function disbutton() {
            var inpt = document.getElementsByTagName("INPUT");
            if (inpt != null) {
                for (var i = 0; i < inpt.length; i++) {
                    // if (inpt[i].type == "submit" || inpt[i].type == "button") {
                    inpt[i].disabled = true;
                    // }
                }
            }
        }
    </script>
    <style type="text/css">
        .style2 {
            font-size: medium;
        }

        .style3 {
            font-size: medium;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="900">
        </asp:ScriptManager>
        <div>
            <table border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="pageHeaderLeft">&nbsp;
                    </td>
                    <td class="pageHeaderCenter">
                        <div id="mark">
                            <font class="h1">Import BOM CM TW</font>
                        </div>
                    </td>
                    <td class="pageHeaderRight">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="pageBodyLeft">&nbsp;
                    </td>
                    <td>
                        <div id="container">
                            <div id="supportingText">
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <font class="h1">BOM CM <b><font color="red">TW</font></b></font></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    Cagetory:<asp:DropDownList ID="DropDownList_Category" runat="server"
                                                        DataTextField="type" AppendDataBoundItems="True">
                                                        <asp:ListItem Text="==請選擇=="></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>CM座標位置檔:<asp:DropDownList ID="DropDownList_CM_DESIGNATOR" runat="server" AppendDataBoundItems="True" DataTextField="flex_column1">
                                            <asp:ListItem>--請選擇--</asp:ListItem>
                                            <asp:ListItem Value="">不選擇</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="CheckBox_Open_Flag" runat="server" Checked="True"
                                                Text="OPEN FLAG CHECK" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    &nbsp;<a href="sample/90SV038A-S01CE0_BOM.xlsx" target="_blank">檔案範例(example)</a>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:Button ID="Button_Include" runat="server" Text="匯入檔案" OnClick="Button_Include_Click" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="Button_Include" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Loading.gif" />
                                                            <b><span class="style2">處理中，請稍候，未完成請勿關閉此視窗... </span></b>
                                                            <br />
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <asp:Label ID="Label_Error" runat="server" Style="font-size: large; color: #FF0000"
                                                        Visible="False"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="Label_Warning" runat="server" Style="font-size: large; color: #FF8C00"
                                                        Visible="False"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="Label_Create_Date" runat="server" Text="" Style="color: #FF3300"></asp:Label>
                                                    <br />
                                                    <asp:Label ID="Label_TOP_ASSEMBLY" runat="server" Text="" Style="color: #FF3300"></asp:Label>
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                                                        OnRowDataBound="GridView1_RowDataBound" Style="text-align: left">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="NO">
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_NO" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="主料/替料">
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_LTYPE" runat="server" Text='<%# Eval("主料替料").ToString().Replace(" ","&nbsp") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="上階料號">
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_Assemble_Num" runat="server" Text='<%# Bind("上階料號") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="料號">
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_Item_Num" runat="server" Text='<%# Bind("料號") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="品名/規格">
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_Item_Desc" runat="server" Text='<%# Bind("品名規格") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="QVL">
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_Qvl" runat="server" Text='<%# Bind("QVL") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="發料單位">
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_MEASURE" runat="server" Text='<%# Bind("發料單位") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Qty">
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_UNIT" runat="server" Text='<%# Bind("QTY") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Marking">
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_MARKING" runat="server" Text='<%# Bind("MARKING") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Config Code">
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_Config_Code" runat="server" Text='<%# Bind("CONFIG_CODE") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ECN#">
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_ECN" runat="server" Text='<%# Bind("ECN") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="GA Flag">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_Ga_Flag" runat="server" Text='<%# Bind("Ga_Flag") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="插件位置">
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_Desigator" runat="server" Text='<%# Bind("插件位置") %>' Style="word-break: break-all"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="展BOM時間">
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_BOM_Create_Date" runat="server" Text='<%# Bind("展BOM時間") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Open Flag">
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_Open_Flag" runat="server" Text='<%# Bind("[Open_Flag]") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Off_line">
                                                                <EditItemTemplate>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Label_Offline" runat="server" Text='<%# Bind("Offline") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" DynamicLayout="False">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Loading.gif" />
                                                            <span class="style3">處理中，請稍候，未完成請勿關閉此視窗...</span>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <asp:Button ID="Button_Import" runat="server" Text="存入資料庫" OnClick="Button_Import_Click"
                                                        Enabled="False" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                    <td class="pageBodyRight">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="pageFooterLeft">&nbsp;
                    </td>
                    <td class="pageFooterCenter">&nbsp;
                    </td>
                    <td class="pageFooterRight">&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
