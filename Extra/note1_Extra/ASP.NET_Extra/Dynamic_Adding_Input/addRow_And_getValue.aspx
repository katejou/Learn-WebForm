<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addRow_And_getValue.aspx.cs" Inherits="WebApplication1.addRow_And_getValue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui-1.8.16.custom.min.js"></script>
    <script type="text/javascript"> 
        $(function () {
            $("#button1").click(addItem);
        });
        function addItem() {
            var next_number = document.getElementById("Count");
            var c = next_number.value;
            var now_records = document.getElementById("Count_now_records");
            var c_now_records = now_records.value;
            var box1 = "<span style='display: inline-block;height: 24px;' id='td1_" + c + "'><input type='text' id='TextBox_Username" + c + "' name='TextBox_Username" + c + "' value='this is Username" + c + "' /></span><br />";
            $("#TextBoxDiv1 > span:last").each(function () { $(this).next().after(box1); });
            $("#TextBoxDiv1 > span:first").each(function() { $(this).before(box1); }); //新增的項次加在最前項
            //var box2 = "<span style='display: inline-block;height: 24px;' id='td2_" + c + "'><input type='text' id='TextBox_Tel" + c + "' name='TextBox_Tel" + c + "' value='this is TextBox_Tel" + c + "' /></span><br />";
            //$("#TextBoxDiv2 > span:last").each(function () { $(this).next().after(box2); });
            //$("#TextBoxDiv2 > span:first").each(function() { $(this).before(box2); }); //新增的項次加在最前項
            //var rlist1 = "<span style='display: inline-block;height: 24px;' id='td3_" + c + "'><select id='DropDownList_" + c + "' name='DropDownList_" + c + "'><option value='男'>男</option><option value='女'>女</option></select></span><br />";
            //$("#DropDownListDiv1 > span:last").each(function () { $(this).next().after(rlist1); });
            //$("#DropDownListDiv1 > span:first").each(function() { $(this).before(rlist1); }); //新增的項次加在最前項
            //var rbutton1 = "<span style='display: inline-block;height: 24px;' id='td4_" + c + "'><input type='radio' id='RadioButton_" + c + "' name='RadioButton_" + c + "' value='0' ><label id='LabelA_" + c + "' name='LabelA_" + c + "'>葷</label><input type='radio' id='RadioButton_" + c + "' name='RadioButton_" + c + "' value='1' ><label id='LabelB_" + c + "' name='LabelB_" + c + "'>素</label></span><br />";
            //$("#RadioButtonDiv1 > span:last").each(function () { $(this).next().after(rbutton1); });
            //$("#RadioButtonDiv1 > span:first").each(function() { $(this).before(rbutton1); }); //新增的項次加在最前項
            //var button1 = "<span style='display: inline-block;height: 24px;' id='td5_" + c + "'><input type='button' value='Delete' id='deleteButton" + c + "' name='deleteButton" + c + "' onclick='delete_item(" + c + ")' ></span><br />";
            //$("#ButtonDiv1 > span:last").each(function () { $(this).next().after(button1); });
            //$("#ButtonDiv1 > span:first").each(function() { $(this).before(button1); }); //新增的項次加在最前項
            var count = Number(c) + 1;
            next_number.value = count;
            var count_now_records = Number(c_now_records) + 1;
            now_records.value = count_now_records;

        }

    </script>

    <script type="text/javascript">

        function delete_item(item) {

            if (Number(document.getElementById("Count_now_records").value) > 1) {
                alert(item);
                var now_records = document.getElementById("Count_now_records");
                var c_now_records = now_records.value;
                var count_now_records = Number(c_now_records) - 1;
                now_records.value = count_now_records;

                //刪除<br>空行

                $("#td1_" + item + " + br").remove();
                //$("#td2_" + item + " + br").remove();
                //$("#td3_" + item + " + br").remove();
                //$("#td4_" + item + " + br").remove();
                //$("#td5_" + item + " + br").remove();

                //刪除span
                $("#td1_" + item).remove();
                //$("#td2_" + item).remove();
                //$("#td3_" + item).remove();
                //$("#td4_" + item).remove();
                //$("#td5_" + item).remove();

            } else {

                alert('只剩一筆,不可刪除!');

            }

        }

    </script>
</head>
<body>
    <form id="form1" runat="server">

        <table border="0">

            <tr>
                <td></td>

                <tr>
                    <td>

                        <table border="1">

                            <tr>
                                <td>姓名</td>
                                <%--                                <td>公司電話</td>
                                <td>性別</td>
                                <td>是否吃素?</td>--%>
                                <tr>
                                    <td>
                                        <div id="TextBoxDiv1">
                                            <span style="display: inline-block; height: 24px;" id="td1_1">
                                                <input type="text" id="TextBox_Username1" name="TextBox_Username1" value="this is Username1" /></span><br />
                                        </div>
                                        </td>
                                        <%--                                        <td>
                                            <div id="TextBoxDiv2">

                                                <span style="display: inline-block; height: 24px;" id="td2_1">
                                                    <input type="text" id="TextBox_Tel1" name="TextBox_Tel1" value="this is TextBox_Tel1" /></span><br />

                                            </div>
                                            <td>
                                                <div id="DropDownListDiv1">

                                                    <span style="display: inline-block; height: 24px;" id="td3_1">
                                                        <select id="DropDownList_1" name="DropDownList_1">
                                                            <option value="男">男</option>
                                                            <option value="女">女</option>
                                                        </select></span><br />

                                                </div>
                                                <td>
                                                    <div id="RadioButtonDiv1">

                                                        <span style="display: inline-block; height: 24px;" id="td4_1">
                                                            <input type="radio" id="RadioButton_1" name="RadioButton_1" value="0"><label id="LabelA_1" name="LabelA_1">葷</label>
                                                            <input type="radio" id="RadioButton_2" name="RadioButton_1" value="1"><label id="LabelB_1" name="LabelB_1">素</label></span><br />

                                                    </div>
                                                    <td>--%>
                                        <td>
                                            <div id="ButtonDiv1">
                                                <span style="display: inline-block; height: 24px;" id="td5_1">
                                                    <input type="button" value="Delete" id="deleteButton1" name="deleteButton1" onclick="delete_item(1)" /></span><br />
                                            </div>
                                        </td>
                                </tr>
                        </table>

                    </td>
        </table>



        <div id="ContentDiv">

            <input type="button" id="button1" value="增加一筆" />

            <input type="hidden" id="Count" name="Count" value="2" />

            <input type="hidden" id="Count_now_records" name="Count_now_records" value="1" />

            <asp:Button ID="Button1" runat="server" Text="儲存" OnClick="Button1_Click" />





            <div id="ShowValueDiv">

                <asp:Label runat="server" ID="Label1"></asp:Label>

                <br>
                --------<br>

                <asp:Label runat="server" ID="Label2"></asp:Label>

                <br>
                --------<br>

                <asp:Label runat="server" ID="Label3"></asp:Label>

                <br>
                --------<br>

                <asp:Label runat="server" ID="Label4"></asp:Label>

            </div>

        </div>



        <asp:Label ID="Label99" runat="server" Text=""></asp:Label>

    </form>
</body>
</html>
