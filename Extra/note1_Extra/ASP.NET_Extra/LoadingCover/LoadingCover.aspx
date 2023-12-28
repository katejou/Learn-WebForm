<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadingCover.aspx.cs" Inherits="ASP.NET_Extra.LoadingCover" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <%--JQuerry--%>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-3.5.1.js"></script>
    <script src="//code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link rel="stylesheet" href="http://jqueryui.com/resources/demos/style.css" />
    <%--版本的更新要看這裡︰https://code.jquery.com/--%>

    <script>
        // 顯示讀取遮罩
        function ShowProgressBar() {
            displayProgress();
            displayMaskFrame();
        }

        // 隱藏讀取遮罩
        function HideProgressBar() {
            var progress = $('#divProgress');
            var maskFrame = $("#divMaskFrame");
            progress.hide();
            maskFrame.hide();
        }
        // 顯示讀取畫面
        function displayProgress() {
            var w = $(document).width();
            var h = $(window).height();
            var progress = $('#divProgress');
            progress.css({ "z-index": 999999, "top": (h / 2) - (progress.height() / 2), "left": (w / 2) - (progress.width() / 2) });
            progress.show();
        }
        // 顯示遮罩畫面
        function displayMaskFrame() {
            var w = $(window).width();
            var h = $(document).height();
            var maskFrame = $("#divMaskFrame");
            maskFrame.css({ "z-index": 999998, "opacity": 0.7, "width": w, "height": h });
            maskFrame.show();
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="divProgress" style="text-align: center; display: none; position: fixed; top: 50%; left: 50%;">
            <asp:Image ID="imgLoading" runat="server" ImageUrl="loading.gif" />
            <br />
            <font color="#1B3563" size="2px">資料處理中</font>
        </div>
        <div id="divMaskFrame" style="background-color: #F2F4F7; display: none; left: 0px; position: absolute; top: 0px;">
        </div>
        <asp:Button ID="Button1" runat="server" Text="顯示 Loading" OnClientClick="ShowProgressBar();" OnClick="Button1_Click" />
    </form>
</body>
</html>
