<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProgress.aspx.cs" Inherits="ASP.NET_EX9._2_.EX9_3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type = "text/css">
#UpdateProgress1{width: 100% ; top: 0%; left: 20px; position: absolute;}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Update Progress 實作<br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <hr/>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick1">
                    </asp:Timer>
                    <br />
                    系統時間 ︰&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <br />
                    亂數 ︰&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                    <br />
                    <br />
                    每一秒一次更新。<br /> 
                    <br />
                    放入一個 Update Progress
                    <hr/><hr/>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                        <ProgressTemplate>
                            放入一個 image&nbsp;&nbsp; <br />
                            <asp:Image ID="Image1" runat="server" ImageUrl="../loading.gif" />
                            &nbsp;&nbsp;
                            <br />
                            Image 的 ImageUrl 屬性 設為 ../loading.gif<br />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <hr/><hr/>
                    <br />
                    在&lt;/head&gt; 標籤上方，加入以下CSS樣式︰<br /> &nbsp;<br /> &lt;style type = &quot;text/css&quot;&gt;<br /> ##UpdateProgress1{width: 100% ; top: 0%; left: 20px; position: absolute;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;---&nbsp; 限好 UpdateProgress 的位置 ，它不會出現在兩條橫線中。<br /> &lt;/style&gt;<br />
                    <br />
                    在 Timer1_Tick 事件加入︰<br /> 
                    <br />
                    System.Threading.Thread.Sleep(3000);<br /> &nbsp;Labell.Text = DateTime.Now.ToLongTimeString();
                    <br />
                    Label2.Text = GetData();
                    <br />
                    <br />
                    運行結果︰<br /> 
                    <br />
                    Update Progress 的 窗戶是在網頁/這個 Panel 的最下方 ?&nbsp; 顯示的，兩條間隔線的地方會被收縮起來。 (因為被 CSS 的樣式固定了？應該是。)<br /> Update Progress 是在 Timer1_Tick 事件 的 System.Threading.Thread.Sleep(3000); 才跳出來的。<br /> 
                    <br />
                    Update Progress 只會在局部更新的「進行時」出現，之後就會消失。<br /> 
                    <br />
                    每一秒更新一次，每更新一次，用三秒，共使用 4 秒。<br />
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <hr/>
            進一步的測試︰<br />  
            用 AssociatedUpdatePanelID 屬性來關聯某個 Update Panel
            <br />
            <br />
            <hr />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
<br />
                    這是另一個 UpdatePanel
                    <br />
                    這個的更新時間，設 5 秒一個更新的時間和亂數，期間沉睡 10 秒。 共使用 15 秒。<br /> 然後試在 Update Progress 指定 不同的 Update Panel 看看。<br /> 
                    <br />
                    <asp:Timer ID="Timer2" runat="server" Interval="5000" OnTick="Timer2_Tick2">
                    </asp:Timer>
                    <br />
                    系統時間 ︰&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                    <br />
                    亂數 ︰&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                    <br />
                    <br />
                </ContentTemplate>
            
            </asp:UpdatePanel>
            <hr />
            <br />
            結果︰<br />
            因為 UpdatePanel&nbsp; 1&nbsp; 在 更新時，會連動到 UpdatePanel&nbsp; 2&nbsp; 的 Label3 進行 Post Back 。<br />
            所以UpdatePanel&nbsp; 2 永遠都等不足 5 秒來進入更新。<br />
            <br />
            所以，<br />
            如果 Update Progress 的 AssociatedUpdatePanelID 指定為 UpdatePanel&nbsp; 2 就永遠都不會顯示，Label 4 也不會有亂數。<br />
            <br />
            測試︰<br />
            UpdatePanel 1 設 Update Mode = Conditional ,&nbsp;&nbsp;&nbsp;&nbsp; ChildrenAsTrigger = false<br />
            把 UpdatePanel 1 的更新限製在 局部，不連動別人。<br />
            <br />
            結果︰<br />
            Timer1 依然還在進行。<br />
            只是 UpdatePanel 1 的 Label 1,2 動不了，但是&nbsp;&nbsp; UpdatePanel 2 的&nbsp; Label 3 被動了。<br />
            <br />
            把Timer1 Enable = False 。<br />
            <br />
            Ladel 3, Lable 4 , Update Progress 都有出現了。<br />
            <br />
            把 UpdatePanel&nbsp; 1 的 Update Mode , ChildrenAsTrigger 調回 Always , true 。&nbsp; Update Progress 調回 UpdatePanel&nbsp; 1<br />
            <br />
            問題一︰<br />
            但如何使兩個 UpdatePanel 的 Timer 都 Enable 的情況下，各不相干呢？因為他們都會被PostBack動到…<br />
            <br />
            問題二︰<br />
            為什麼gif檔不會轉動？<br />
            <br />
            開一個EX9_4去測試，這裡太擠了。<br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            </span>
            <br />
        </div>
    </form>
</body>
</html>
