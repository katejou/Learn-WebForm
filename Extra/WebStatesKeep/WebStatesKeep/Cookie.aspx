<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cookie.aspx.cs" Inherits="ASP.NET_Extra.Cookie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Cookie 實作<br />
            <br />
            <a href="https://www.itread01.com/p/1425105.html">https://www.itread01.com/p/1425105.html</a>&nbsp;&nbsp; &lt;-----------------&nbsp; (解釋最好的各種方法比較)<br />
            <br />
            存放在使用者電腦
             
            <br />
            在Web Server和瀏覽器之間，伴隨request和網頁傳送的一小段文字<br />
            Cookie的使用要配合ASP.NET內建物件Request來使用
            <br />
            <br />
            存在時間通常為1000分鐘  也可以自己設時間
             
            <br />
            數量及大小受限於瀏覽器設定
            ，大大多瀏覽器限制檔案大小不得超過 4096 Bytes，<br />
            每個網站最多存放20個 Cookie。通常用來記錄使用者名稱、帳號、上次到訪時間......等等。<br />
            若名稱相同會覆蓋過去
             
             
            <br />
             
            <br />
            "每次"發請求都會夾帶 Cookie，會影響訪問網站的速度<br />
            有群組功能，減少容量<br />
            <br />
            <a href="https://kknews.cc/zh-tw/tech/oy3zop.html">https://kknews.cc/zh-tw/tech/oy3zop.html</a><br />
            <br />
            原理和類型<br />
            <br />
            <a href="https://codertw.com/前端開發/205178/">https://codertw.com/%E5%89%8D%E7%AB%AF%E9%96%8B%E7%99%BC/205178/</a><br />
            <br />
            <a href="https://read01.com/zh-tw/4DDAjG.html#.Xs8VUGgzZPY">https://read01.com/zh-tw/4DDAjG.html#.Xs8VUGgzZPY</a><br />
            <br />
            Cookie 和 Session 的對比<br />
            <br />
            <a href="https://juejin.im/post/5d28970b6fb9a07f070e594e">https://juejin.im/post/5d28970b6fb9a07f070e594e</a><br />
            這個做法不可行，但是步驟解釋得很好。<br />
            <br />
            Cookie 的做法︰
            <a href="https://ithelp.ithome.com.tw/articles/10222885">https://ithelp.ithome.com.tw/articles/10222885</a><br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="設值1 並存到客戶端" />
&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="設值2 並存到客戶端" />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="從客戶端取得並顯示結果" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="Cookie_Result" runat="server"></asp:Label>
            <br />
            <br />
            -------------------------------------------------<br />
            測跨頁的功能︰<br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="開另一個分頁" />
&nbsp;&nbsp;
            <br />
            -------------------------------------------------<br />
            如何修改存在時間？<br />
            <br />
            因為 設值 1 和 2 的時候，寫了 1 天 的生存期，所以 即使關了這個網頁，再開，再按「顯示結果」。<br />
            <br />
            !!!! 這個 Cookie 還在！這就是和 Session 的最大不同。<br />
            <br />
            <a href="https://blog.xuite.net/octopus12209/wretch/135543573-電腦裡的cookies是什麼?">https://blog.xuite.net/octopus12209/wretch/135543573-%E9%9B%BB%E8%85%A6%E8%A3%A1%E7%9A%84cookies%E6%98%AF%E4%BB%80%E9%BA%BC%3F</a><br />
            <br />
            <br />
            1. 如何手動使 Cookie 過期 (登出時應該應用)<br />
            <a href="https://codertw.com/前端開發/259509/">https://codertw.com/%E5%89%8D%E7%AB%AF%E9%96%8B%E7%99%BC/259509/</a><br />
            <br />
            <asp:Button ID="Button5" runat="server" Text="刪除 Cookie" OnClick="Button5_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="從客戶端取得並顯示結果" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Cookie_Result2" runat="server"></asp:Label>
            <br />
            <br />
            // 成功例子:&nbsp; HttpCookie c = Request.Cookies[&quot;CK&quot;]; if (c == null)<br />
            // 如&nbsp; foreach (string value in cookie.Values) ,string z = Server.UrlDecode(cookie.Value);&nbsp;&nbsp;&nbsp;&nbsp; ||&nbsp; if (cookie.Value == null) { Label1.Text = &quot;Null&quot;; } 等  
            <br />
            // 全部都出錯，因為 cookie 己經不存在了。(所以不要沒有設值的時候跳到另一頁，不然他們就就看見了。)<br />
            <br />
            <br />
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="用迴圈取得並顯示結果" />
            <br />
            <br />
            <asp:Label ID="Cookie_Result0" runat="server"></asp:Label>
            <br />
            <br />
            // <a href="https://dotblogs.com.tw/shadow/2011/12/15/62306">https://dotblogs.com.tw/shadow/2011/12/15/62306</a><br />
            用迴圈取得結果，這個 string value in cookie.Values 的 foreach 只會在多值的時候顯示 KEY 的值，而不真的是其中的 Value (在另一分頁按下多值再回來顯示就知道了。)<br />
            而有單值時，它也是空白的，連 0 都沒有。 
            <br />
            <br />
            <br />
            實作︰<br />
            因為客戶端的伺服器存了不同的 Cookie ，於是顯示不同的內容︰<br />
            <br />
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="我是女性" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="我是男性" />
            <br />
            <br />
            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="顯示內容︰ " />
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Cookie_Result1" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            2. 使多設定細則&nbsp; Domain , Path , Secure&nbsp; , 使用 JavaScript 建立和讀取︰      <a href="https://dotblogs.com.tw/yc421206/2015/04/09/150998">https://dotblogs.com.tw/yc421206/2015/04/09/150998</a><br />
            <a href="https://dotblogs.com.tw/shunnien/2013/05/05/102828">https://dotblohttps://dotblogs.com.tw/shunnien/2013/05/05/102828</a><br />
            <br />
            暫不實作。<br />
            <br />
            進階︰如何設定︰<br />
            長期存在(一段時間內每次關機都在)&nbsp; 和&nbsp;&nbsp; 短期存在(關了網頁就沒有)&nbsp;&nbsp; ... 還沒有找到例子……<br />
            <br />
            暫不實作。<br />
            <br />
            -------------------------------------------------      Chrome 存 Cookie 的位置︰(沒有測試)<br />
            <a href="https://chunhsing.pixnet.net/blog/post/59050831-[chrome]-cookie-存放位置">https://chunhsing.pixnet.net/blog/post/59050831-%5Bchrome%5D-cookie-%E5%AD%98%E6%94%BE%E4%BD%8D%E7%BD%AE</a><br />
            Chorme 自家的管理說明︰(可刪特定網站的)<br />
            <a href="https://support.google.com/chrome/answer/95647?co=GENIE.Platform%3DDesktop&amp;hl=zh-Hant">https://support.google.com/chrome/answer/95647?co=GENIE.Platform%3DDesktop&amp;hl=zh-Hant</a><br />
            <br />
            <br />
            Persistent Cookies的問題 :
            <br />
            <a href="https://dotblogs.com.tw/rainmaker/2012/02/24/70187">https://dotblogs.com.tw/rainmaker/2012/02/24/70187</a><br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
