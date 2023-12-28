<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cache.aspx.cs" Inherits="ASP.NET_Extra.Cache" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Cache(快取，或緩存)<br />
            <br />
            <a href="https://www.itread01.com/p/1425105.html">https://www.itread01.com/p/1425105.html</a>&nbsp;&nbsp; &lt;-----------------&nbsp; (解釋最好的各種方法比較)<br />
            <br />
            <a href="https://ithelp.ithome.com.tw/articles/10219502">https://ithelp.ithome.com.tw/articles/10219502</a><br />
            資料存放在伺服器端，主要是以降低資料庫使用率為出發<br />
            所有瀏覽器在同時間共用一個, 
            <br />
            自己設定時間，時間到消失，不受網頁關閉或關機影響<br />
            如果你今天每一個訪客到首頁你都去資料庫重新抓一次所有的資料，
            那對資料庫的負擔會非常非常大。<br />
            這些資訊基本上短期之內是不會變的，所以很適合儲存起來，等到伺服器再次接到請求時若是發現已經看過且預存在Cache後，就可以用極快的速度撈出來，而不是再到資料庫裡面重新算一次，<br />
            <br />
            <a href="https://dotblogs.com.tw/lapland/2015/12/10/110306">https://dotblogs.com.tw/lapland/2015/12/10/110306</a><br />
            最簡單的使用︰<br />
            <a href="https://ithelp.ithome.com.tw/articles/10198630">https://ithelp.ithome.com.tw/articles/10198630</a><br />
            深一點的使用︰<br />
            <a href="https://blog.darkthread.net/blog/tips-asp-net-cache-mini-guide">https://blog.darkthread.net/blog/tips-asp-net-cache-mini-guide</a><br />
            <br />
            要將資料放入Cache，可以用Insert或Add，二者最大的不同是<br />
            Insert時會不論Cache中是否已有該Key值的CacheItem時，一律新增或覆寫為傳入的value；<br />
            而Add在Cache中已存在該Key時，會直接傳回現有物件，不做更新。<br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insert 一個 cache" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="取這一個資料︰" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <asp:Button ID="Button2" runat="server" Text="add 同一個 cache" OnClick="Button2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="取這一個資料︰" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            因為 add 的時候，已經在一個同名的資料存在了，所以Add 不會覆寫原值，取出時，還是「Insert」的資料。<br />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="用 Insert 覆蓋原值" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="取這一個資料︰" />
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
            如何刪除 Cache 資料？&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <a href="https://columns.chicken-house.net/2009/12/19/設計案例-清除cache物件-1-問題與作法/">https://columns.chicken-house.net/2009/12/19/%E8%A8%AD%E8%A8%88%E6%A1%88%E4%BE%8B-%E6%B8%85%E9%99%A4cache%E7%89%A9%E4%BB%B6-1-%E5%95%8F%E9%A1%8C%E8%88%87%E4%BD%9C%E6%B3%95/</a>&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="刪除指定 Cache 內容" />
            <br />
            如何設多個Cache值，再用迴圈刪。<br />
            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="設多個 Cache 值" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="用迴圈顥示多個 Cache 值" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <br />
            <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="用迴圈刪多個 Cache 值" />
            <br />
            <a href="https://www.itdaan.com/tw/5f5134263eadb9cf09b07c920030eb62">https://www.itdaan.com/tw/5f5134263eadb9cf09b07c920030eb62</a><br />
            <br />
            PageLoad 中有每次開都清除 Cache 記錄的方法。<br />
            還可以調整到底是使用哪裡的 Cache ︰ NoCache, Private, Public, Server
            <br />
            <a href="https://mark528.pixnet.net/blog/post/13624433">https://mark528.pixnet.net/blog/post/13624433</a><br />
            如何判斷Cache 沒有資料 ( 沒有就去資料庫再抓回來，再存一次Cache )<br />
            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="判斷 Cache 有沒有資料" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server"></asp:Label>
            <br />
            <a href="https://ithelp.ithome.com.tw/articles/10198644">https://ithelp.ithome.com.tw/articles/10198644</a><br />
            轉成其他快取方式&nbsp; ------------------------------------這個目前用不上?
            <br />
            用更高階的類別使用Cache ,
            <br />
            <br />
            將可設定屬性解釋得最清楚的網址︰ 有時間可慢慢實作<br />
            <a href="http://vito-note.blogspot.com/2012/10/blog-post_17.html">http://vito-note.blogspot.com/2012/10/blog-post_17.html</a><br />
            <a href="https://www.itdaan.com/tw/5f5134263eadb9cf09b07c920030eb62">https://www.itdaan.com/tw/5f5134263eadb9cf09b07c920030eb62</a><br />
            <br />
            Cache 的好處︰<br />
            <a href="https://codertw.com/前端開發/259252/">https://codertw.com/%E5%89%8D%E7%AB%AF%E9%96%8B%E7%99%BC/259252/</a><br />
             Application和Cache物件非常相似，主要區別在於Cache物件有擁有更多的特性，像過期策略、快取依賴。它意味著資料儲存在快取物件可以根據預定義時間或它依賴的實體變化時過期或清楚，而這個特性Application物件是不支援的。<br />
            <br />
             檔案依賴（File Dependency）- 當磁碟檔案無論何時發生變化時自動清除快取物件。<br />
             鍵依賴（Key Dependency）當Cache依賴的條目發生改變時或被刪除時，快取會自動失效。 ????? 看不懂。<br />
             過期策略（Expiration Policy）:&nbsp; 基於時間的過期（Time based expiration）: Absolute Expiration 和 Sliding Expiration<br />
             清除（scavenging）:&nbsp; CacheItemPriority這個引數 ,&nbsp; 這個優先權告訴Cache當記憶體一旦很低時，這個優先順序會指示物件的釋放順序<br />
            <br />
            </span>
            <br />
            這個網頁還提到 Remoting 和 Memory-Mapped files 和  ASP.NET Page Output Caching&nbsp; (和 ASP.NET Cache Object 不同)&nbsp;
            和&nbsp;&nbsp; Hidden fields
            <br />
            <br />
            </span>
            <br />
            <br />

        </div>
    </form>
</body>
</html>
