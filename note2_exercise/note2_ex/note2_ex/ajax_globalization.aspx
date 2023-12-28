<%@ Page Language="C#"
    Culture="auto"
    AutoEventWireup="true" CodeBehind="ajax_globalization.aspx.cs" Inherits="note2_ex.ajax_globalization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <script>
        function pageLoad() {

            //alert(Sys.CultureInfo.CurrentCulture.dateTimeFormat.ShortDatePattern);
            var culture = Sys.CultureInfo.CurrentCulture.name;
            var d = new Date();
            alert(culture + " : " + d.localeFormat("D"));

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server" ID="ScriptManagerl"
                EnableScriptGlobalization="true">
            </asp:ScriptManager>
        </div>
    </form>
</body>
</html>

<%--EnableScriptLocalization="true"  UICulture="auto"--%>
