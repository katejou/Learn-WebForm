<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Timer(1).aspx.cs" Inherits="ASP.NET_EX9._2_.EX9_4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            為什麼 GIF 動不了？&nbsp; 因為沒有正確的下載 .... <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick">
                    </asp:Timer>
                    <br />
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <div class="loading">
                                <%--<img class="item" src="https://media.giphy.com/media/gibvnAbdWQEiGtPlk3/source.gif" />--%>  
                                <asp:Image ID="Image1" class="item" runat="server" ImageUrl="https://i.stack.imgur.com/8puiO.gif" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    ( PageLoad ) PostBack : <asp:Label ID="Label_1" runat="server"></asp:Label>
                    <br />
                    ( Timer/Internal ) PostBack : <asp:Label ID="Label_2" runat="server"></asp:Label>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            答案︰<br />
            <br />
            直接在Google的圖片去下載圖片是不可行的。&nbsp;
            即使改名為GIF檔，但實際上它並不會動。 (要找到他預設就是 GIF 檔名的那種 )<br />
            還有可以在那一個網頁，右鍵那個圖片，「複製圖片地址」，
            把那個地址貼到 ImageUrl 的屬性。<br />
            <br />
            <br />
            如何有兩個 
            panel,&nbsp; timer 不互相干擾？<br />
            <br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Timer ID="Timer2" runat="server" Interval="2000" OnTick="Timer2_Tick">
                    </asp:Timer>
<br />
                    <asp:Image ID="Image2" runat="server" class="item" ImageUrl="https://i.stack.imgur.com/8puiO.gif" />
<br />
                    ( PageLoad ) PostBack : <asp:Label ID="Label_3" runat="server"></asp:Label>
                    <br />
                    ( Timer/Internal ) PostBack : <asp:Label ID="Label_4" runat="server"></asp:Label>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            答案︰<br />
            兩個 Panel 都設 Timer 的 interval 不同 ， Panel 的 Update Mode = Conditional ,&nbsp;&nbsp;&nbsp;&nbsp; ChildrenAsTrigger = true<br />
            <br />
            依它們在 Label 顯示的 數字來看，他們終於是互不相干的。<br />
            上一個練習應該只是做得太亂，其中一個 Panel 沒有設好?&nbsp; 還是設下 Update Progress 會有影響？<br />
            <br />
            答案︰<br />
            這個練習和上一個不同，GIF 不是放在 Update Progress 中的，GIF 是在 Timer 在休息時消失。和上一個練習剛剛相反。 <br />
            <br />
            如何做到︰ 只是按下一個按鈕，正在運行時才出現這個 GIF 才是實務中會用到的吧… (而且是各自的 Panel)<br />
&nbsp;<br />
            答案︰<br />
            衍生在 EX9_5<br />
            <br />
        </div>
    </form>
</body>
</html>
