<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajax_prevent_repeat_click.aspx.cs" Inherits="note2_ex.ajax_prevent_repeat_click" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script>
        var elem
        function pageLoad() {
            var pm = Sys.WebForms.PageRequestManager.getInstance();
            // 攔 - 起
            pm.add_beginRequest(OnBeginRequest);
            // 攔 - 終
            pm.add_endRequest(OnEndRequest);
        }
        function OnBeginRequest(sender, args) {
            elem = args.get_postBackElement();
            if (elem.id == "Button1")
                $get("Button1").disabled = true;
            //封
        }
        function OnEndRequest(sender, args) {
            if (elem.id == "Button1")
                $get("Button1").disabled = false;
            //解
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="background-color: aqua; width: 250px">
                        <tr>
                            <td>UpdatePanel
                                <br />
                                <asp:Label ID="Label1" runat="server" Text="時間?"></asp:Label>
                                <br />
                                <asp:Button ID="Button1" runat="server" Text="GetData" OnClick="Button1_Click" />
                                <br />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    作業中，請稍候…    
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
