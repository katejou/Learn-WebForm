<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostForm.aspx.cs" Inherits="ASP.NET_Extra.PostForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Request.Form[]&nbsp;&nbsp; (Post)<br />
            <br />
            <a href="https://www.blueshop.com.tw/board/FUM20041006161839LRJ/BRD20180910221554XY3.html">https://www.blueshop.com.tw/board/FUM20041006161839LRJ/BRD20180910221554XY3.html</a><br />
            它和 Request.QueryString[] 的關係是，它們都可以用 request[] 來簡寫  
            <br />
            <br />
            他是承接別的頁面中的Form，裡面有&lt;input type=&quot;text&quot; name=&quot;no&quot; value=&quot;1234&quot; /&gt;</span><br style="color: rgb(102, 102, 102); font-family: Arial, Helvetica, sans-serif, 微軟正黑體; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;" />
            透過『表單』，用『Post』送出<br />
            <br />
            Request還有第3種狀況 : 如果你有把no存在cookie ,&nbsp; 當網址(QueryString)沒有no參數, 也不是從別的頁面post資料來的話, 會直接抓cookie的值.......
            <br />
            <br />
            <a href="https://www.wibibi.com/info.php?tid=235">https://www.wibibi.com/info.php?tid=235</a><br />
            Get(QueryString)&nbsp; 和 Post 的差異&nbsp;&nbsp; :&nbsp;&nbsp; 資料傳遞時，網址並不會改變。 &gt; 安全 + 沒有長度限製&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <br />
            // 不，網址還是會改為 下一頁的那個，不像 Server.Transfer 。 只是資料不會顯示在網址上而已。<br />
            <br />
            實作︰&nbsp; 
            <br />
            <a href="https://sky731017.pixnet.net/blog/post/25351461">https://sky731017.pixnet.net/blog/post/25351461</a>
            <br />
            <a href="https://adamschen9921.pixnet.net/blog/post/83235611">https://adamschen9921.pixnet.net/blog/post/83235611</a><br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="用PostBackUrl屬性把TextBox中的值傳到另一頁" PostBackUrl="PostTo.aspx" />
            <br />
            <br />
            我猜 PostBackUrl 也是和 Server.Transfer 一樣， 是「單程」去轉頁的，所以到了另一頁的PostBack<br />
            還能找到這一邊的值。<br />
            <br />
            <a href="https://dotblogs.com.tw/topcat/2008/03/05/1200">https://dotblogs.com.tw/topcat/2008/03/05/1200</a>
            <br />

            <br />
            Form 的第二種方法&nbsp;&nbsp;&nbsp;&nbsp;
            (FormSubmit)<br />
        </div>
    </form>

    <form action="PostTo.aspx" method="post" id="form2" name="form2">
        <input type="text" id="text1" name="text1" /><br />
        <input type="text" id="text2" name="text2" /><br />
        <input type="submit" value="Submit" id="submit1" name="submit1" />
        <br />
        <br />
        這個Input ,不是 ASP.NET 的 控制項。<br />
        <br />
    </form>

    <form action="PostTo.aspx" method="post" id="form3" name="form3">
        第二種方法，但傳的是 checkbox
        <br />
        結果︰&nbsp;&nbsp; 例子的語法，無法實施。<br />
<%--        <%for y = 1 to 10%>
        <input type="checkbox" id="chkId" name="chkId" value="<%=y%>"/><%=y%> <br/>
        <input type="submit" value="Submit" id="submit2" name="submit2" />--%>
    </form>
</body>
</html>
