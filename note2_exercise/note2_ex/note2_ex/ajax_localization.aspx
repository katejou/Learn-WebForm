<%@ Page Language="C#"
    UICulture="auto"
    AutoEventWireup="true" CodeBehind="ajax_localization.aspx.cs" Inherits="note2_ex.ajax_localization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script>
        function pageLoad() {

            Add();
            //alert(Add(1, 2));
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager runat="server" ID="ScriptManagerl"
                EnableScriptLocalization="true">
                <Scripts>
                    <asp:ScriptReference
                        Name="MyAjaxClassLibrary1.ajax_localization.js"
                        Assembly="MyAjaxClassLibrary1" />
                </Scripts>
            </asp:ScriptManager>
        </div>
    </form>
</body>
</html>
