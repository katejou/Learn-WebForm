<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RunAPI2.aspx.cs" Inherits="WebAPI_ex1.GetRespon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="https://code.jquery.com/jquery-2.2.4.min.js"></script>
    <script>

        function getIHAR() {
            var temp = document.getElementById('isError').checked;
            $.ajax({
                type: "get",
                url: 'api/ihttp',
                data: { isError: temp , name : "Kate", id: "811968" , age: "18" ,email: "kate@mail.com" },
                success: function (result, status) {
                    alert(status);
                    if (status == "success") {
                        $('<li>' + result.Data.Name + ', ' + result.Data.Id + ', ' + result.Data.Age + ', ' + result.Data.Email + '</li>').appendTo('#divCandidates1');
                    }
                },
                error: function (result, status) {
                    alert(status);
                    $('<li>' + result.responseJSON.Code + result.responseJSON.Message + '</li>').appendTo('#divCandidates1');
                }
            });
        }
        function getHRM() {
            var temp = document.getElementById('isError').checked;
            $.ajax({
                url: 'api/httpResp',
                data: { isError: temp, name: "Kate", id: "811968", age: "18", email: "kate@mail.com" },
                success: function (result, status) {
                    alert(status);
                    if (status == "success") {
                        $('<li>' + result.Data.Name + ', ' + result.Data.Id + ', ' + result.Data.Age + ', ' + result.Data.Email + '</li>').appendTo('#divCandidates2');
                    }
                },
                error: function (result, status) {
                    alert(status);
                    $('<li>' + result.responseJSON.Code + result.responseJSON.Message + '</li>').appendTo('#divCandidates2');
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>GetRespon</h2>
            <br />
            <p>
                我想要它回傳一個Error給我看看 ? :  
                <asp:CheckBox ID="isError" runat="server" />
            </p>
            <br />
            <input type="button" value="Get IHttpActionResult" onclick="getIHAR();" />
            <p id="divCandidates1"></p>
            <br />
            <input type="button" value="Get HttpResponseMessage" onclick="getHRM();" />
            <p id="divCandidates2"></p>
        </div>
    </form>
</body>
</html>
