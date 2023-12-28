<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Timer.aspx.cs" Inherits="ASP.NET_EX9._2_.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Timer
            <br />
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <hr/>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    放入一個 Timer 的 UpdatePanel<br />
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                    </asp:Timer>
<br />
                    系統時間 ︰&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <br />
                    亂數 ︰&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server"></asp:Label>
<br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <hr/>
            <br />
            Timer 設 Interval 屬性 = 1000<br />
            在 Timer 的屬性，找閃電的標誌(events)，雙擊 Tick 事件，產件處理的常式︰<br />
            跳到了 .cs 檔，加入︰<br />
            <br />
            Label1.Text = DateTime.Now.ToLongTimeString();<br />
            Label2.Text = GetData();<br />
            <br />
            private string GetData() <br />
            { int r = new Random().Next(1, 11); return r.ToString(); }<br />
            <br />
            在 Page Load 加入︰<br />
            <br />
            Label1.Text = DateTime.Now.ToLongTimeString();
            <br />
            (注意，Page Load 並沒有設 Label2.Text， 打開這一頁的第一秒是沒有亂數的。)<br />
            <br />
            <br />
            結果︰&nbsp; 每一秒鐘，產生一個亂數。<br />
            <br />
            測試︰ Timer 設 Enable = false ,&nbsp; Label2.Text 就永遠 = 空白了。<br />
            <br />
        </div>
    </form>
</body>
</html>
