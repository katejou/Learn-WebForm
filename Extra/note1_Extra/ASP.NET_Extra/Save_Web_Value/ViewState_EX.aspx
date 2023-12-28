<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewState_EX.aspx.cs" Inherits="ASP.NET_Extra.ViewState_EX" %>

<%--EnableViewState="False"--%> 
<%--把這個加入 Page 就關了它，放在控制項上沒有用--%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            實作 <a href="https://dotblogs.com.tw/shadow/2011/04/27/23691">https://dotblogs.com.tw/shadow/2011/04/27/23691</a> 例子︰<br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="建立ViewState" EnableViewState="False" ViewStateMode="Disabled" />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="讀取ViewState" EnableViewState="False" ViewStateMode="Disabled" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text="顯示讀取出來的ViewState內容" EnableViewState="False" ViewStateMode="Disabled"></asp:Label>
            <br />
            <br />
            測試ViewState會不會消失︰<br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="重新導向回本頁" />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ViewState_EX.aspx">超連結到自己</asp:HyperLink>
            <br />
            <br />
            會。<br />
            當「重回」 / 「超連結到自己」後，<br />
            如果不先按「建立」直接按「讀取」，<br />
            結果會使「顯示」那一個 Label 被清空。<br />
            <br />
            <hr />
            <br />
            對比以靜態參數，View State 的好處是&nbsp; <br />
            每個分頁都有自己View State，不會像是 靜態參數 一樣，和其他分頁共用。<br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="new_sub_page" Text="新開分頁" />
            &nbsp;&nbsp; 請按多個分頁出來。<br />
            <br />
            靜態的變數&nbsp;&nbsp;&nbsp; 顯示出這個頁面被分出的次數。<br />
            <br />
            View State 的變數&nbsp;&nbsp;&nbsp; 顯示出自己這個本頁的以按鈕累加的數字，和第其他頁不相關。<br />
            <br />
            <hr />
            <br />
            <a href="https://yan3776.pixnet.net/blog/post/11094909">https://yan3776.pixnet.net/blog/post/11094909</a>&nbsp; :<br />
            <br />
            好處:不會佔用系統資源 (記憶體) &lt;--- 「伺服器資源」？
             
            <br />
            缺點:網頁會變大 (多了一串ViewState,會花比較久的時間Load)<br />
            <br />
            更多內容請見該網頁，如︰<br />
            &nbsp;1.&nbsp;&nbsp;
            ViewState支援的資料型態 
            <br />
            &nbsp;2.&nbsp;&nbsp;
            使用的時機 和 如何關閉&nbsp; ViewState&nbsp;&nbsp;&nbsp;&nbsp; <a href="https://ithelp.ithome.com.tw/articles/10156037">https://ithelp.ithome.com.tw/articles/10156037</a><br />
            <br />
            安全性，壓縮和解壓縮的問題︰&nbsp; 先不實作，太進階了<br />
            <a href="https://kevintsengtw.blogspot.com/2010/08/viewstate-viewstate.html">https://kevintsengtw.blogspot.com/2010/08/viewstate-viewstate.html</a><br />
            <br />
            <hr />
            <br />
            測試 關閉 ViewState :<br />
            <br />
            把 「建立」的屬性︰ ViewStateMode 改為 Disable ︰&nbsp;&nbsp; 沒有改變。<br />
            把 「讀取」的屬性︰ ViewStateMode 改為 Disable ︰&nbsp;&nbsp; 沒有改變。<br />
            把「建立」和「讀取」的 ViewStateMode 調回 Inherit (預設)
            <br />
            把「建立」和「讀取」的 EnableViewState 改為 False&nbsp; ︰&nbsp; 沒有改變。<br />
            <br />
            把 「顯示」的 ViewStateMode 改為 Disable ︰&nbsp;&nbsp; 沒有改變。<br />
            把 「顯示」的 EnableViewState 改為 False&nbsp; ︰&nbsp;&nbsp; 沒有改變。<br />
            <br />
            把所有屬性調回為預設。確定 ViewState 的開關不在 控制項上。<br />
            <br />
            <a href="https://dotblogs.com.tw/jshsshwa/2013/05/10/103442">https://dotblogs.com.tw/jshsshwa/2013/05/10/103442</a><br />
            <br />
            在 原始檔的 Page (最上面的那一行)，加入EnableViewState=&quot;False&quot; 就成功了。<br />
            <br />
            <hr />
            <br />
            有關和不關的對比中，<br />
            查看是否減少網頁大小和傳輸時間︰<br />
            <br />
            F12 = 在網頁中呼叫出開發者的視窗 
            <br />
            <br />
            到 Network 的分頁，可以找到載入時，網頁的大小和傳輸時間的資料︰<br />
            <br />
            為了看到更加清楚的效果，放個 Grid View 和 連結的資料庫 進來好了︰<br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="name" DataSourceID="SqlDataSource1" AllowPaging="True" PageSize="2">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="name" ReadOnly="True" SortExpression="name" />
                    <asp:BoundField DataField="age" HeaderText="age" SortExpression="age" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Table1]"></asp:SqlDataSource>
            <br />
            <a href="http://gowintony.blogspot.com/2017/09/sql-server_14.html">http://gowintony.blogspot.com/2017/09/sql-server_14.html</a><br />
            用 while 的方法，一次過輸入1000筆資料。<br />
            <br />
            F5 出來，開出 F12，按 「重回」對比幾次。<br />
            時間上相差不多。 
            <br />
            <br />
            只是關了的話是︰ 8.3 kb&nbsp;&nbsp; 開了的話是&nbsp;&nbsp; 8.5 kb<br />
            <br />
            <hr />
            <br />
            View State 存資料 和 其他在網頁中存資料方法&nbsp; 的比較︰<br />
            <br />
            <a href="https://dotblogs.com.tw/hatelove/2009/06/28/viewstate-session-cache-cookies-application-of-user-state">https://dotblogs.com.tw/hatelove/2009/06/28/viewstate-session-cache-cookies-application-of-user-state</a><br />
            <br />
            <a href="https://blog.xuite.net/tolarku/blog/27528606-ASP.NET+application、session、cookie、Viewstate、Postback">https://blog.xuite.net/tolarku/blog/27528606-ASP.NET+application%E3%80%81session%E3%80%81cookie%E3%80%81Viewstate%E3%80%81Postback</a><br />
            <br />
            <a href="https://ithelp.ithome.com.tw/articles/10222885">https://ithelp.ithome.com.tw/articles/10222885</a><br />
            <br />
            對比之下︰&nbsp;&nbsp;&nbsp; View State 生命週期是單頁的，存在用戶端。<br />
            <br />
            其他另開更多網頁，實作 application ,&nbsp; session 和 cookie 等<br />
            <br />
            <a href="https://www.itread01.com/p/1425105.html">https://www.itread01.com/p/1425105.html</a>&nbsp;&nbsp; &lt;-----------------&nbsp; (解釋最好的各種方法比較)<br />

        </div>
    </form>
</body>
</html>
