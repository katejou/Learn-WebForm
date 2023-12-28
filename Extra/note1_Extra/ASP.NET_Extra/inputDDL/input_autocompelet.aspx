<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="input_autocompelet.aspx.cs" Inherits="input_DDL.WebForm2" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="utf-8">
    <title>autocomplete demo</title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-3.5.1.js"></script>
    <script src="//code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        function inputSelect() {
            var selectId = $("#tb_S_SHIP_TO").val();
            if (selectId == "A") {
                document.getElementById('TextBox1').value = 'A';
            }
            if (selectId == "B") {
                document.getElementById('TextBox1').value = 'B';
            }
        }
    </script>
    <style type="text/css">
        .ui-autocomplete.ui-widget {
            font-size: 15px;
            line-height: 1;
        }
    </style>
</head>
<body>

    <form id="form1" runat="server">

        <%--<label for="autocomplete">Select: </label>--%>
        <input id="tb_S_SHIP_TO" runat="server"
            onkeyup="inputSelect()"
            placeholder="Select..." />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<p>
            &nbsp;
        </p>
        <script>
            var data = [
                { label: "A", value: 'A' },
                { label: "B", value: 'B' }
            ];

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
        </script>

        <p>
            &nbsp;
        </p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
    </form>

</body>
</html>
