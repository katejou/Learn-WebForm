<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdatePanel.aspx.cs" Inherits="ASP_NET_9_AJAX.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">

 p.MsoNormal
	{margin-bottom:.0001pt;
	font-size:12.0pt;
	font-family:"Calibri",sans-serif;
	        margin-left: 0cm;
            margin-right: 0cm;
            margin-top: 0cm;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Update Panel 練習<br />
            <br />
            外 ︰&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="OutsideLabel" runat="server" Text="UpdatedTimeLabel1"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text="內外更新" />
            &nbsp;&nbsp; &lt;--- 這個只是最單純的 Button<br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="內更新" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;--- 這個被 Update Panal 中的 Trigger 屬性設定為 
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AsyncPostBackTrigger 的 ControlID<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; AsyncPostBackTrigger 是由加入那邊的下拉選單新增出來的。<br />
            <br />
            <hr/>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <br />
                    內 ︰&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="InsideLabel" runat="server" Text="UpdatedTimeLabel2"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="內更新" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;--- 這個只是最單純的 Button<br />
<br />
                    <asp:Button ID="Button3" runat="server" Text="內外更新" />
                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;--- 這個被 Update Panal 中的 Trigger 屬性設定為 
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; PostBackTrigger 的 ControlID<br />
                    <br />

                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button1"/>
                    <asp:PostBackTrigger ControlID="Button3" />
                </Triggers>
            </asp:UpdatePanel>
            <hr/>
            <br />
                    這個 UpdatePanel 的&nbsp; : <br />
                    UpdateMode 為 Conditional&nbsp;&nbsp; ,&nbsp;&nbsp;&nbsp; ChildernAsTrigger&nbsp; 為 True<br />
                    放了個 ScriptMabager 但沒有做什麼，只是因為F5跑出來時，程式告訴我必須放一個。<br />
            <br />
            PageLoad 放了兩行︰<br />
            OutsideLabel.Text = System.DateTime.Now.ToString();
            <br />
            InsideLabel.Text = System.DateTime.Now.ToString();<br />
            <br />
            推測︰<br />
            <br />
                    UpdateMode 為 Conditional 但 外面最單純的 Button 卻可以做到內外同時更新？<br />
            應該是因為 Update Panal 指定了另外一個按鈕為 AsyncPostBackTrigger ，所以使外面的Post Back 可以干預到內部。<br />
            <br />
            驗證︰<br />
            <br />
            <hr/>
            <br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                <ContentTemplate>
                    這個 Update Panel 應該不會被 最上面的按鈕影響 ?&nbsp;&nbsp;&nbsp; PageLoad 多放一行︰ InsideLabel2.Text = System.DateTime.Now.ToString();<br />
<br />
                    &nbsp;結果︰&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="InsideLabel2" runat="server" Text="UpdatedTimeLabel3"></asp:Label>
                    <br />
                    <br />
                    不論<br /> UpdateMode 為 Conditional 或&nbsp; Always&nbsp; ,&nbsp; ChildernAsTrigger&nbsp; 為 True&nbsp; 或&nbsp; False&nbsp; ,<br /> &nbsp;* UpdateMode 為 Always 時，ChildernAsTrigger 不可為 False<br /> &nbsp;* 這個頁面只可以加入一個 ScriptMabager 的個體。<br />
                    <br />
                    這個 UpdataTimeLabel3 都會被 外部的 Post Back 影響。 
                    <br />
                    <br />
                    那麼如果 UpdateMode 為 Conditional&nbsp; ,&nbsp;&nbsp; ChildernAsTrigger&nbsp; 為&nbsp; false&nbsp; , 這裡的按鈕可以影響外部的 Post Back 嗎？<br /> 
                    <br />
                    <asp:Button ID="Button5" runat="server" Text="試圖內外更新的按鈕" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;--- 這個只是最單純的 Button<br />
                    <br />
                    結果︰&nbsp;&nbsp;&nbsp; 完全沒有反應，內外的更新都做不到。<br /> 
                    <br />
                    所以︰ 如果&nbsp; ChildernAsTrigger&nbsp; 為&nbsp; false&nbsp; ，&nbsp; Panel 內部的 Button 連自己的更新都做不到。<br /> 
                    <br />
                    再測試︰&nbsp; 果然，如果&nbsp; ChildernAsTrigger&nbsp; 為&nbsp; ture ，這個內部的單純按鈕就可以控制 Panel 內部的更新 了。<br /> 
                    <br />
                    測試二︰<br /> 
                    <br />
                    <asp:Button ID="Button7" runat="server" Text="試圖內外更新的按鈕2" />
                    &nbsp; &lt;--- 這個被 Update Panal 中的 Trigger 屬性設定為&nbsp; PostBackTrigger 的 ControlID<br />
                    <br />
                    但是如果 Panel 的 ChildernAsTrigger&nbsp; 為&nbsp; false ，它還可以影響到外面嗎？<br /> 
                    <br />
                    結果︰&nbsp;&nbsp; 可以。 內外都被影響了。 
                    <br />
                    <br />
                    推測︰ Trigger 屬性 的權力比 ChildernAsTrigger 大？ ChildernAsTrigger 只是在控制 Panel 內部可不可自己局部更新，其他管不了。<br />
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="Button7" />
                </Triggers>
            </asp:UpdatePanel>
            <br />
            <hr/>
            <br />
            結論︰<br />
            <br />
            UpdateMode 為 Conditional = 按 ChildernAsTrigger 來判斷︰是否可以內部更新。<br />
            <br />
            <br />
            如果指定外面的其中一個按鈕，來更新這個 Panel，那這個按鈕的權力是小了，而不是大了。因為它更新不到外面。<br />
            如果指定裡面的其中一個按鈕，去 Post Back ，那這個按鈕的權力就是大了，不是小了。<br />
            <br />
            <br />
            問題二︰如果&nbsp; UpdateMode 為 Always
            <p class="MsoNormal">
                &nbsp;</p>
            <p class="MsoNormal">
                <span lang="ZH-HK" style="font-family:&quot;新細明體&quot;,serif;mso-ascii-font-family:
Calibri;mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;
mso-hansi-font-family:Calibri;mso-fareast-language:ZH-HK">只要</span><span lang="ZH-HK"> </span><span lang="EN-US">PostBack </span><span lang="ZH-HK" style="font-family:&quot;新細明體&quot;,serif;mso-ascii-font-family:Calibri;mso-fareast-font-family:
新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:Calibri;
mso-fareast-language:ZH-HK">所有在</span><span lang="EN-US"> Panel </span><span lang="ZH-HK" style="font-family:&quot;新細明體&quot;,serif;mso-ascii-font-family:Calibri;
mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:
Calibri;mso-fareast-language:ZH-HK">上的內容都會更新，包括</span><span lang="ZH-HK"> </span><span lang="ZH-HK" style="font-family:&quot;新細明體&quot;,serif;mso-ascii-font-family:Calibri;
mso-fareast-font-family:新細明體;mso-fareast-theme-font:minor-fareast;mso-hansi-font-family:
Calibri;color:red;mso-fareast-language:ZH-HK">非同步</span><span lang="EN-US" style="color:red">PostBack ?<o:p></o:p></span></p>
            <p class="MsoNormal">
                <o:p></o:p>
            </p>
            <p class="MsoNormal" >
                驗證︰</p>
            <p class="MsoNormal" >
                &nbsp;</p>
            <p class="MsoNormal" >
                將 UpdatedTimeLabel2 所在的 Updata Label 改為 UpdateMode = Always 看看。</p>
            <p class="MsoNormal" >
                結果︰沒有看到任何的差別，但發現︰</p>
            <p class="MsoNormal" >
                &nbsp;</p>
            <p class="MsoNormal" >
                外部的「內更新」的按鈕不只更新了 UpdatedTimeLabel2 還有&nbsp; UpdatedTimeLabel3&nbsp; ( 外部的UpdatedTimeLabel1沒有受影響)</p>
            <br />
            UpdatedTimeLabel2&nbsp; 和&nbsp; UpdatedTimeLabel3 被歸到同一個非同步更新的階層了嗎？ (外部的「內更新」的按鈕 是在 Panel 1 被指定了 AsyncPostBackTrigger 的。)<br />
            <br />
            <br />
            總之，這個聽說不會在 MVC 用得上，所以不深究下去了。
            <br />
            <br />
            <br />
            <br />
                    <br />
                    <br />
        </div>
    </form>
</body>
</html>
