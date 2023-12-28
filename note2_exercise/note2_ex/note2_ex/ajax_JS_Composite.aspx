<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajax_JS_Composite.aspx.cs" Inherits="note2_ex.ajax_JS_Composite" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <CompositeScript>
                    <Scripts>
                        <asp:ScriptReference Path="~/composite_part1.js" />
                        <asp:ScriptReference Path="~/composite_part2.js" />
                    </Scripts>
                </CompositeScript>
            </asp:ScriptManager>
            <asp:Button ID="Button1" runat="server" Text="使用組合的指令碼" OnClientClick="sayHello(); return false;" />
        </div>
    </form>
</body>
</html>
