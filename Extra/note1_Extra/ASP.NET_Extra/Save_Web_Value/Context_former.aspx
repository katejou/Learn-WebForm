<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Context_former.aspx.cs" Inherits="ASP.NET_Extra.Context_former" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            實作︰<br />
            asp.net Context.Handler 页面间传值方法<br />
            <a href="https://blog.csdn.net/zhanglei5415/article/details/1595470">https://blog.csdn.net/zhanglei5415/article/details/1595470</a><br />
            <a href="https://www.cnblogs.com/sntetwt/archive/2011/09/09/2172875.html">https://www.cnblogs.com/sntetwt/archive/2011/09/09/2172875.html</a><br />
            理論︰<br />
            Context 限在 Server Transfer , 只能在同一個網站，對比於 Session 的好處，應該就是可存的資料量較大。<br />
            <a href="http://justanycode.blogspot.com/2014/04/aspnet.html">http://justanycode.blogspot.com/2014/04/aspnet.html</a><br />
            Response Redirect 以 2KB 為限，能去任何網頁。 
            <br />
            但 Session 的資料很大的話，會對伺服器有很大的負擔，因為Session 會為每一個連線用戶，分出一份記憶體。<br />
            <a href="https://blog.xuite.net/tolarku/blog/27528606-ASP.NET+application、session、cookie、Viewstate、Postback">https://blog.xuite.net/tolarku/blog/27528606-ASP.NET+application%E3%80%81session%E3%80%81cookie%E3%80%81Viewstate%E3%80%81Postback</a><br />
            Context 只能夠取一次？&nbsp;&nbsp; 不同Session 一樣，能來回傳值到不同分頁？&nbsp;&nbsp;&nbsp;&nbsp; 沒錯，&nbsp; Context&nbsp; 只能 第一次 Page Load 一下，之後就沒有了。<br />
            <a href="https://ithelp.ithome.com.tw/articles/10219006">https://ithelp.ithome.com.tw/articles/10219006</a><br />
            Response.Redirect() 和  Server.Transfer() 的差別 (有圖)&nbsp;&nbsp;&nbsp; 2 個來回和&nbsp; 1 個來回<br />
            <a href="https://www.itread01.com/p/1425105.html">https://www.itread01.com/p/1425105.html</a>&nbsp;&nbsp; &lt;-----------------&nbsp; (解釋最好的各種方法比較)<br />
            HttpContext 是 ASP.NET 特有的方法
            方式:asp.net特有方式 。利用HttpContext獲取發請求的頁面的資訊。<br />
            特點:可以直接儲存物件。<br />
            缺點:注意強制轉換的型別要正確。<br />
            適用資料:各種資料。<br />
            適用範圍:頁面之間傳遞複雜資料。<br />
            用法:獲取Context.Handler將其轉換為發請求的頁面的例項,隨後就可以輕鬆訪問其form中的欄位、甚至屬性。<br />
            其中的Context是指HttpContext物件,Handler是其屬性,<br />
            Context.Handler的意思可以理解為建立源頁類的例項變數,而得到此例項之後,就可以直接訪問其中的屬性和Public方法了
             
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Server.Transfer 到另一頁" />
            <br />
            <br />
            輸入要存到下一頁的資料&nbsp; ︰ 
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="更改傳值" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Server.Transfer 到另一頁" />
            &nbsp;&nbsp;&nbsp;&nbsp; 更改不成功，在另一頁抓到的值，依然是更改之前的，沒有保住輸入。另一頁抓的值是預設的。<br />
            <br />
            應該是要在「更改傳值」的時候，就順帶 Server.Transer
            <br />
            <br />
            輸入要存到下一頁的資料&nbsp; ︰ 
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="更改傳值和跳頁" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 成功更改傳值。<br />
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="放入以上兩個 TextBox 的值，一起傳到另一頁" />
            &nbsp;&nbsp;&nbsp;&nbsp; 使用 Context.Items<br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
