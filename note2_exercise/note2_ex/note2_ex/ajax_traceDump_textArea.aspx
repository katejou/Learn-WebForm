<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajax_traceDump_textArea.aspx.cs" Inherits="note2_ex.ajax_traceDump_textArea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <script type="text/javascript"> 
                function pageLoad() {
                    var a = ['Cabbage', 'Turnip', 'Radish', 'Carrot'];
                    // 重點︰textarea 的 id 名。
                    Sys.Debug.traceDump(a, "info");
                }
            </script>
            <textarea id="TraceConsole" cols="20" rows="5"></textarea>
            <%-- cols 和 rows是長寛 --%>
        </div>
    </form>
</body>
</html>
