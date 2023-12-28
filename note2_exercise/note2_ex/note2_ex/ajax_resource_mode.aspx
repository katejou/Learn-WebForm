<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajax_resource_mode.aspx.cs" Inherits="note2_ex.ajax_resource_mode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script>
        function pageLoad() {

            alert(Add(10, 3));
            //alert(Add());
            //alert(Add(null,null));
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference
                        Name="MyAjaxClassLibrary1.ajax_JScript.js"
                        Assembly="MyAjaxClassLibrary1"
                        ScriptMode="Release" />
                        <%--ScriptMode="Release"ScriptMode="Debug"--%>
                </Scripts>
            </asp:ScriptManager>
        </div>
    </form>
</body>
</html>
