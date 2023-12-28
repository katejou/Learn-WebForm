<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RunAPI.aspx.cs" Inherits="WebAPI_ex1.getURLonly" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://code.jquery.com/jquery-2.2.4.min.js"></script>
    <title>Candidates</title>
    <meta charset="utf-8" />
    <script>
        var apiurl = 'api/candidates';
        $(document).ready(function () {
            GetAllCandidates();
        });

        function GetAllCandidates() {
            $.ajax({
                url: apiurl,
                success: function (result) {
                    $('#divCandidates').empty();
                    $.each(result, function (key, item) {
                        $('<li>' + item.Name + ', ' + item.Id + ', ' + item.Age + ', ' + item.Email + '</li>').appendTo('#divCandidates');
                    });
                }
            });
        }

        function SearchCandidate() {
            var name = $('#candidateName').val();
            $.ajax({
                url: apiurl + '/' + name,
                success: function (result) {
                    $('#divCandidates').empty();
                    $('<li>' + result.Name + ', ' + result.Id + ', ' + result.Age + ', ' + result.Email + '</li>').appendTo('#divCandidates');
                },
                error: function (jqXHR, exception) {
                    $('#divCandidates').empty();
                    alert('Nothing');
                }
            });
        }
        function SendCandidate() {

            var str = "{\"Name\": \"Kate\", \"Id\": \"811968\", \"Age\": \"18\", \"Email\": \"kate@gmail.com\"}";
            $.ajax({
                url: apiurl,
                type: 'POST',
                data: { "": str },
                dataType: 'json',
                success: function (result, code) {
                    alert(code);
                    // 單結果 : 
                    $('<li>' + result.Name + ', ' + result.Id + ', ' + result.Age + ', ' + result.Email + '</li>').appendTo('#divCandidates');
                    // 多結果 : 
                    //$.each(result, function (key, item) {
                    //    $('<li>' + item.Name + ', ' + item.Id + ', ' + item.Age + ', ' + item.Email + '</li>').appendTo('#divCandidates');
                    //});
                },
                error: function () {
                    alert('PostFail');
                }
            });
        }

    </script>
</head>
<body>
    <div>
        <h2>Candidates</h2>
        <p>
            Name:<input id="candidateName" type="text" />
            <input type="button" value="Get" onclick="SearchCandidate();" />
            <br />
            傳送Json字串，接收到Obj 的 Post : 
            <input type="button" value="Post" onclick="SendCandidate();" />
        </p>
        <p id="divCandidates"></p>
    </div>
</body>
</html>
