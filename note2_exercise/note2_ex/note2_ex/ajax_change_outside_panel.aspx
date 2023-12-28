<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ajax_change_outside_panel.aspx.cs" Inherits="note2_ex.ajax_change_outside_panel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%--不知道為什麼script放在這裡話，反而沒有辨法去更新到Label3，連方法都沒有跑進去。--%>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <script type="text/javascript">
                Sys.WebForms.PageRequestManager.getInstance().add_pageLoading(PageLoadingHandler);
                function PageLoadingHandler(sender, args) {
                    var dataItems = args.get_dataItems();
                    if ($get('Label3') !== null)
                        $get('Label3').innerHTML = dataItems['Label3'];
                }
            </script>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="background-color: aqua; width: 250px">
                        <tr>
                            <td>UpdatePanel
                                <br />
                                <asp:Label ID="Label1" runat="server" Text="日期?"></asp:Label>
                                <br />
                                <asp:Label ID="Label2" runat="server" Text="時間?"></asp:Label>
                                <br />
                                <asp:Button ID="Button1" runat="server" Text="GetData" OnClick="Button1_Click" />
                                <br />

                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <table style="background-co or: aquamarine; width: 250px">
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="年中第幾日？"></asp:Label>
                        <br />
                    </td>
                </tr>
            </table>
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
