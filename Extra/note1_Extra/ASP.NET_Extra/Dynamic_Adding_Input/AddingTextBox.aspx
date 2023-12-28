<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddingTextBox.aspx.cs" Inherits="WebApplication1.AddingTextBox" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="//code.jquery.com/jquery-3.5.1.js"></script>
    <script src="//code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        var counter = 0;
        /**
        * 編輯表格
        */
        var editTable = {
            /**
            * 新增一行
            */
            addRow: function () {

                $mtr = $("#amsTbody tr:last").clone();
                //$mtr.each(function (i, e) {
                //    $(e).find("input").val(i);
                //});
                // https://stackoverflow.com/questions/47307087/increase-index-of-a-forms-input-fields-name-attribute-in-a-dynamic-form
                counter++;
                $mtr.attr('name', 'input' + counter );
                $("#amsTbody tr:last").after($mtr);
            },
            /**
            * 刪除一行
            */
            delRow: function () {
                if ($("#amsTbody tr").length <= 1) {
                    return;
                }
                $("#amsTbody tr:last").remove();
                counter--;
            },

            /**
            * 新增一列
            */
            addCol: function () {
                $col = $("<td class='tdSet'><input type='text' /></td>");
                $("#amsTbody tr").append($col);
            },
            /**
            * 刪除一列
            */
            delCol: function () {
                alert($("#amsTbody tr").eq(0).find("td").length);
                if ($("#amsTbody tr").eq(0).find("td").length <= 2) {
                    return;
                }
                alert($("#amsTbody tr").length);
                $("#amsTbody tr td:last-child").remove();
            },
        };

    </script>
    <style type="text/css">
        .auto-style1 {
            width: 500px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" action="AddingTextBox.aspx.cs" method= "post">
        <div>
            來源︰
            <br />
            https://www.itread01.com/content/1549445766.html
            <br />
            <input type="button" value="新增一行" onclick="editTable.addRow()" />
            <input type="button" value="刪除一行" onclick="editTable.delRow()" />
            <%--<input type="button" value="新增一列" onclick="editTable.addCol()" />
            <input type="button" value="刪除一列" onclick="editTable.delCol()" />--%>
            <asp:Button runat="server" Text="取值" ID="GetInput" OnClick="GetInput_Click"></asp:Button>
        </div>
        <table>

            <tbody id="amsTbody">
                <tr class="tdSet">
                    <td class="tdSet">
                        <input type="text" class="auto-style1" name ="Input1"/>
                    </td>
                </tr>
            </tbody>

        </table>
        <asp:Label runat="server" ID="LB1"></asp:Label>
        
        <%--Get dynamic value using ajax ? 
        https://www.encodedna.com/jquery/dynamically-add-textbox-in-jquery-and-save-data-to-sqlserver-using-webmethod.htm
   --%>
        </form>
</body>
</html>
