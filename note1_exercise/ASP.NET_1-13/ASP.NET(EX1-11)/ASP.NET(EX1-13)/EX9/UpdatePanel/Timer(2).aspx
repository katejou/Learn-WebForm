<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Timer(2).aspx.cs" Inherits="ASP.NET_EX9._2_.EX9_5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            在不同Button 按下後，所在 Panel分別會出現 GIF 的實作<br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            Panel 1 :<br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    Update Mode = Condional , ChildrenAsTriggers = true<br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button 1" />
                    &nbsp; = 沉睡 10 秒<br /> 
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                        <ProgressTemplate>
                            我會在沉睡時出現 ?
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1" />
                </Triggers>
            </asp:UpdatePanel>
            <br />
            Panel 2 :<br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    Update Mode = Condional , ChildrenAsTriggers = true<br />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button 2" />
                    &nbsp; = 沉睡 10 秒<br /> 
                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                        <ProgressTemplate>
                            我會在沉睡時出現 ?
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button2" />
                </Triggers>
            </asp:UpdatePanel>
            <br />
            結果︰<br />
            當按其中一個按鈕時，兩個 Progess 都出現了！<br />
            <br />
            測試︰<br />
            在兩個 panel 各自加入一個 trigger 去指定 Button1 / Button2 為 不同步更新<br />
            <br />
            結果︰完全沒有用，還是同一個結果，Progress 會同時出現???<br />
            <br />
            答案在 <a href="https://docs.microsoft.com/zh-tw/dotnet/api/system.web.ui.updateprogress?view=netframework-4.8">https://docs.microsoft.com/zh-tw/dotnet/api/system.web.ui.updateprogress?view=netframework-4.8</a><br />
            上找到，Progess 要指定 Panel 的 ID 啦！<br />
            <span class="hljs-attr" style="box-sizing: inherit; outline-color: inherit; color: rgb(4, 81, 165); font-family: SFMono-Regular, Consolas, &quot;Liberation Mono&quot;, Menlo, Courier, monospace; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: pre; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(250, 250, 250); text-decoration-style: initial; text-decoration-color: initial;">AssociatedUpdatePanelID</span><span style="color: rgb(1, 1, 253); font-family: SFMono-Regular, Consolas, &quot;Liberation Mono&quot;, Menlo, Courier, monospace; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: pre; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(250, 250, 250); text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">=</span><span class="hljs-string" style="box-sizing: inherit; outline-color: inherit; color: rgb(163, 21, 21); font-family: SFMono-Regular, Consolas, &quot;Liberation Mono&quot;, Menlo, Courier, monospace; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: pre; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(250, 250, 250); text-decoration-style: initial; text-decoration-color: initial;">&quot;UpdatePanel1&quot;</span><br />
            <br />
            又一個問題︰<br />
            <br />
            Progess 不會同時出現，一個 Button 會中斷另一個Button。 所以要應用到將兩個 panel 分到不同的執行緒？<br />
            <a href="https://docs.microsoft.com/zh-tw/dotnet/framework/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls">https://docs.microsoft.com/zh-tw/dotnet/framework/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls</a><br />
            <br />
            太複雜了，暫時不想去理會，.cs 中有一點測試的殘留，不刪了，但也不想做下去。<br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
