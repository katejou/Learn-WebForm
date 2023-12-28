<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Appcaltion_ex.aspx.cs" Inherits="ASP.NET_Extra.Appcaltion_ex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <a href="https://blog.xuite.net/tolarku/blog/27528606-ASP.NET+application、session、cookie、Viewstate、Postback">https://blog.xuite.net/tolarku/blog/27528606-ASP.NET+application%E3%80%81session%E3%80%81cookie%E3%80%81Viewstate%E3%80%81Postback</a><br />
&nbsp;<br />
            用途：不同使用者之間（不同連線）共用某些系統變數，例如:網頁瀏覽次數。<br />
                    資料存放在伺服器端，會佔用伺服器系統資源。<br />
                    當IIS或網頁伺服器重新啟動、修改Global.asax、修改 web.config時， Application的值便會遺失。<br />
                    使用方式：application("變數名稱")=變數值<br />
                    Q：因為該變數是共用，所以會有互相搶用的問題，所以在修改該值時都應該先 Lock。<br />
                    Application.Lock() → Application("count")+=1 → Application.UnLock()<br />
            <br />
            <a href="https://dotblogs.com.tw/shadow/2012/03/16/70801">https://dotblogs.com.tw/shadow/2012/03/16/70801</a>&nbsp; <br />
            <br />
            用途，和 Cache 一樣，減少資料庫的訪問。<br />
            和Cache 的分別是？&nbsp;&nbsp; <a href="https://sophieprofession.pixnet.net/blog/post/17348982">https://sophieprofession.pixnet.net/blog/post/17348982</a><br />
            那Cache 的使用需要 Lock 嗎？&nbsp; 還是Cache 傾向是只讀不改的，所以不需要。但 Application 就經常的修改，例如網頁瀏覽的次數？<br />
            使用Application.Lock和Applicaiton.Unlock方法来避免写操作的同步,但是它串行化了对Application对象的请求,当网站访问量大的时候会产生严重的性能瓶颈.因此最好不要用此对象保存大的数据集合。<br />
            <a href="https://www.cnblogs.com/qiantuwuliang/archive/2009/12/27/1633110.html">https://www.cnblogs.com/qiantuwuliang/archive/2009/12/27/1633110.html</a><br />
            和Cache 的另一個分別是 保存的時間，不能指定。&nbsp; Application 的值只能和上述所說的那樣 「遺失」。<br />
            <br />
            <a href="https://codertw.com/前端開發/259252/">https://codertw.com/%E5%89%8D%E7%AB%AF%E9%96%8B%E7%99%BC/259252/</a><br />
            Application物件非常適合儲存應用程式後設資料（Config file data）???<br />
            在應用程式執行中無論什麼時候對Config檔案做了修改快取資料必需失效，這時Application方式就不能提供這樣的支援了。在這種情況下，就要考慮cache物件了&nbsp; ???<br />
            <br />
            實作 : <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="顯示從PageLoad數出來的瀏覽次數︰"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="VisitingTimes" runat="server"></asp:Label>
&nbsp;
            <br />
            <br />
            <br />
            F5&nbsp; &gt;&nbsp; 瀏覽器關閉 就回到&nbsp; 1 。<br />
            用 Ctrl + F5 開出來的這一頁，瀏覽器關閉了再開。 數字還是會一直累加。&nbsp;&nbsp;&nbsp;&nbsp; 但是如果關了Visual Studio，再 Ctrl +F5 就又回到&nbsp;&nbsp; 1 。<br />
            試把它掛到 IIS 的自家侗服器上，再 每次用 虛擬路徑的網址上這一頁，都會累加。 用 虛擬路徑 開出來的，和用 Ctrl +F5 , F5 開出來的累加數不會相通。<br />
            但我估計這個伺服器，就是這一台電腦關閉的話，應該就會清空這一個累加？對，它又變回 1 了。<br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
