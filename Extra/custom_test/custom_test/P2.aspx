<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="P2.aspx.cs" Inherits="custom_test.P2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .btngreen {
            background-color: #90ee90;
            width: 225px;
        }
    </style>
    <script>
        var last_sele = -1;
        //var muti_sele = document.getElementById('muti_sele'); // 不能放在外面，否則抓不到 

        function selected_box_change(ctrl) {

            // 使用者勾
            if (ctrl.checked) {
                // 找所有的 checkbox  
                var cbs = document.querySelectorAll("[name$=box_selected]");
                // 清除所有的箱子勾選
                for (var i = 0; i < cbs.length; i++) 
                        cbs[i].checked = false;
                // 只留下他自己
                ctrl.checked = true; 
            }

        }

        function selected_item_change(ctrl) {

            var muti_sele = document.getElementById('muti_sele');

            // 取得行號(這個index包括了Header那一行)
            var index = ctrl.parentElement.parentElement.rowIndex;

            // 使用者勾
            if (ctrl.checked) {

                // 如果在這個模式，有「上次勾選」記錄 -- > 連續勾
                if (muti_sele.checked && last_sele != -1) {

                    // 拿範圍
                    var ary = [];
                    if (last_sele > index)
                        for (var tmp = index; last_sele > tmp; tmp++)
                            ary.push(tmp);
                    if (last_sele < index)
                        for (var tmp = last_sele; index >= tmp; tmp++)
                            ary.push(tmp);

                    // 找所有的 checkbox  
                    var cbs = document.querySelectorAll("[name$=item_selected]");
                    // 如果 checkbox 在範圍內就勾
                    for (var i = 0; i < cbs.length; i++) {
                        if (ary.indexOf(i + 1) != -1)
                            cbs[i].checked = true;
                    };

                    last_sele = -1; // 完成這次任務，取消上次記錄
                }

                // 如果有這個模式，但沒有上次勾選，就記錄下來
                else if (muti_sele.checked)
                    last_sele = index;

                // 沒有開這個模式就取消上次勾選記錄
                else
                    last_sele = -1;

            }

            // 使用者取消勾
            else {
                last_sele = -1;
            }



        }

        function muti_sele_on_off(ctrl) {

            var muti_sele = document.getElementById('muti_sele');

            // 如開即關
            if (muti_sele.checked) {
                muti_sele.checked = false;
                ctrl.className = "";
                // ctrl.style = "width:225px;";
                //alert(muti_sele);
            }
            // 如關則開
            else {
                muti_sele.checked = true;
                ctrl.className = "btngreen";
                //ctrl.style = "width:225px;background-color:#90ee90;";
                //alert(muti_sele);
            }
        }

        function clear_sele() {
            var cbs = document.querySelectorAll("[name$=item_selected]");
            for (var i = 0; i < cbs.length; i++)
                cbs[i].checked = false;
        }

        function reverse_sele() {
            var cbs = document.querySelectorAll("[name$=item_selected]");
            for (var i = 0; i < cbs.length; i++)
                if (cbs[i].checked)
                    cbs[i].checked = false;
                else
                    cbs[i].checked = true;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <table>
                <tr>
                    <td style="padding: 0px 20px 0px 20px;">
                        <asp:Button ID="Last" runat="server" Text="上一步" OnClick="Last_Page" Width="225px" />
                    </td>
                    <td style="text-align: center; width: 870px;">
                        <asp:Label ID="title_lb" runat="server" Text="Packing List" Font-Size="Larger" Font-Bold="true"></asp:Label>
                    </td>
                    <td style="padding: 0px 20px 0px 20px;">
                        <asp:Button ID="Next" runat="server" Text="下一步" OnClick="Next_Page" Width="225px" /></td>
                </tr>
            </table>
            <hr />
            <table>
                <tr>
                    <td style="vertical-align: bottom; padding: 20px 20px 0px 20px;">
                        <asp:Button ID="Add_Box" runat="server" Text="增加箱子" OnClick="add_box" Width="225px" />
                        <br />
                        <br />
                        <asp:Button ID="All_In_Div" runat="server" OnClick="all_in_div" Text="未入箱的貨物獨立包裝" Width="225px" />
                        <br />
                        <br />
                        <asp:Button ID="All_In_One" runat="server" OnClick="all_in_one" Text="未入箱的貨物包成一箱" Width="225px" />
                        <br />
                        <br />
                        <asp:Button ID="Sele_to_Sele" runat="server" Text="選中的貨物放入選中的箱子" Width="225px" OnClick="sele_to_sele" />
                    </td>
                    <td style="vertical-align: bottom; padding: 20px 20px 0px 20px;">
                        <asp:GridView
                            ID="Box_GV"
                            runat="server"
                            AutoGenerateColumns="false">
                            <HeaderStyle BackColor="Black" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="箱號" Font-Size="Small"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="box_no" runat="server" Width="50" BackColor="Black" ForeColor="White" Style="text-align: center;"><%# (Container.DataItemIndex+1).ToString()%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="box_selected" runat="server" onclick="javascript:selected_box_change(this)" ClientIDMode="Static" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="箱內貨號" Font-Size="Small" Width="255"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="word-break: break-all; word-wrap: normal; padding: 2px 2px 2px 2px;">
                                            <asp:Label ID="boxs_item_no" runat="server" Font-Size="Small"></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="Del_Box" runat="server" Text="刪除" OnClick="del_box" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="淨重(N.W.)KG" Font-Size="Small"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="nw" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="毛重(G.W.)KG" Font-Size="Small"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="gw" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="大小(L*W*H)CM" Font-Size="Small"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="size" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <br />
            <hr />
            <br />
            <table>
                <tr>
                    <td style="vertical-align: top; padding: 0px 20px 20px 20px;">
                        <asp:Button ID="Add_Item" runat="server" Text="新增貨物" OnClick="add_item" Width="225px" />
                        <br />
                        <br />
                        <asp:Button ID="On_Off_Sele_Range" runat="server" Text="開啟 /  關閉多選" Width="225px" OnClientClick="muti_sele_on_off(this);return false;" />
                        <div style="display: none;">
                            <asp:CheckBox ID="muti_sele" runat="server" />
                        </div>
                        <br />
                        <br />
                        <asp:Button ID="Clear_Sele" runat="server" Text="清除全部勾選" Width="225px" OnClientClick="clear_sele();return false;" />
                        <br />
                        <br />
                        <asp:Button ID="Reverse_Sele" runat="server" Text="反選" Width="225px" OnClientClick="reverse_sele();return false;" />
                    </td>
                    <td style="vertical-align: top; padding: 0px 20px 20px 20px;">
                        <asp:GridView
                            ID="Item_GV"
                            runat="server"
                            AutoGenerateColumns="false">
                            <HeaderStyle BackColor="Black" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="貨號" Font-Size="Small"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="item_no" runat="server" Width="50" BackColor="Gray" ForeColor="White" Style="text-align: center;"><%# (Container.DataItemIndex+1).ToString()%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="item_selected" runat="server" onclick="javascript:selected_item_change(this)" ClientIDMode="Static" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="箱號" Font-Size="Small"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="box_no" runat="server" Width="50" BackColor="Black" ForeColor="White" Style="text-align: center;"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="Del_Item" runat="server" Text="刪除" OnClick="del_item" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="ASKEY PN" Font-Size="Small" Width="150"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="askey_pn" runat="server" Width="150"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="LoadData" runat="server" Text="匯入" OnClick="load_data" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="Description of Goods" Font-Size="Small"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="desc_good" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="Package Qty<br/>(PCS)" Font-Size="Small" Width="80"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="pack_qty" runat="server" Width="80"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="Carton QTY" Font-Size="Small" Width="80"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="cart_qty" runat="server" Width="80"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <asp:Label ID="header" runat="server" Text="Remark" Font-Size="Small" Width="150"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="remark" runat="server" Width="150"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
