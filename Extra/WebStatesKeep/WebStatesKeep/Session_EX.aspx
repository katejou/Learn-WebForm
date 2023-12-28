<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Session_EX.aspx.cs" Inherits="ASP.NET_Extra.Session_EX" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Session 實作<br />
            <br />
            放在server的記憶體  伺服器 給每個瀏覽器一個 Session ID  保存每一個連線用戶的 Session資料  小心用戶太多會過載。<br />
            鎖定同一瀏覽器(關 Chrome 重開不認得)<br />
            關掉網頁就消失。也可設定存活時間(預設為20分鐘) ?<br />
            或 閒置︰ 預定存 20 分鐘  ? 不閒置(=瀏覽器一直開著 ,不是關分頁而已) : 一直在  <br />

            最大長處  :  變數可跨多的分頁  
            <br />
            <br />
            修改session 的壽命，還有逾期警告，和永遠維持的方法等，太高深，暫不實作︰<br />
            <a href="https://blog.darkthread.net/blog/prevent-aspnet-session-timeout/">https://blog.darkthread.net/blog/prevent-aspnet-session-timeout/</a><br />

            <br />
            最簡單的使用 session :<br />
            <a href="http://imagine-code.blogspot.com/2013/07/aspnet-session.html">http://imagine-code.blogspot.com/2013/07/aspnet-session.html</a><br />
            <a href="https://ithelp.ithome.com.tw/articles/10222885">https://ithelp.ithome.com.tw/articles/10222885</a><br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="設下Session變數" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="顯示Session變數" OnClick="Button2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="ShowSession" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="到另外一個分頁，看看 Session變數 還在不在" OnClick="Button3_Click" />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text="顯示另一頁更改後的Session變數" OnClick="Button4_Click" />
&nbsp;&nbsp;
            <asp:Label ID="ShowSession0" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" Text="刪除這一個Session變數" OnClick="Button5_Click" />
            <br />
            <br />
            <asp:Button ID="Button6" runat="server" Text="設下多個Session變數" OnClick="Button6_Click" />
            <br />
            <br />
            <asp:Button ID="Button7" runat="server" Text="RemoveALL Session變數" OnClick="Button7_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button8" runat="server" Text="Clear Session變數" OnClick="Button8_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button10" runat="server" Text="Abandon Session變數" OnClick="Button10_Click" />
&nbsp;&nbsp;&nbsp; 三個刪除的方法<br />
            <br />
            <asp:Button ID="Button9" runat="server" Text="顯示多個Session變數" OnClick="Button9_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="ShowSession1" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            如果session無故自己消失︰<br />
            <a href="https://blog.miniasp.com/post/2008/01/12/How-to-avoid-Session-data-loss-in-ASPNET">https://blog.miniasp.com/post/2008/01/12/How-to-avoid-Session-data-loss-in-ASPNET</a><br />
            <br />
            Session 的功能缺陷︰<br />
            <a href="https://icejuly.pixnet.net/blog/post/27181308">https://icejuly.pixnet.net/blog/post/27181308</a><br />
            <br />
            網站的服務器可能不止一個 ....
            <br />
            實際上客戶端的Session信息是存儲與Cookie中的??????，如果客戶端完全禁用掉了Cookie功能..... <br />
            <br />
            Web.config文件中的Session配置信息 ?<br />
            把 session 值改存到 SQL 資料庫之中？<br />
            <br />
            <a href="https://www.itread01.com/p/1425105.html">https://www.itread01.com/p/1425105.html</a>&nbsp;&nbsp; &lt;-----------------&nbsp; (解釋最好的各種方法比較)<br />
            <br />
            <a href="https://blog.darkthread.net/blog/session-alternative/">https://blog.darkthread.net/blog/session-alternative/</a>&nbsp;&nbsp;&nbsp; &lt;---------------- 更進階的 Session 缺點和 存值方法。 (有空再說。)<br />
            <br />
             HttpContext.Current.Session 和 Session 的區別<br />
            <br />
            <a href="https://www.itread01.com/content/1502812759.html">https://www.itread01.com/content/1502812759.html</a><br />
        </div>
    </form>
</body>
</html>
