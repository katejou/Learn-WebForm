<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MutiView_FileUpload.aspx.cs" Inherits="ASP.NET_EX10_.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            FileUpload&nbsp; (外加 Muti View)<br />
            <br />
            1. 加入一個RadioButtonList<asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">檢視內容</asp:ListItem>
                <asp:ListItem>上傳</asp:ListItem>
            </asp:RadioButtonList>
            設 AutoPostBack為 True&nbsp; ,&nbsp; RepeatDirection為 Hrizontal&nbsp; ,&nbsp;&nbsp;&nbsp;
            加入兩個 item ，前者的 Selected = True = 預設被選<br />
            <br />
            3. RadioButtonList 的 SelectedIndexChange 事件處理式加入︰<br />
            MultiView1.ActiveViewIndex = RadioButtonList1.SelectedIndex;<br />
            <br />
            有兩個 List Item 就要有兩個 View ，不然兩個 Index 對不上會出現 Error<br />
            這個事件的意思是改 SelectedIndex = 改 View 的顯示。&nbsp;&nbsp;&nbsp;
            MutiView 就是會翻頁的東東。<br />
            <br />
            <br />
            加入一個 Muti View<br />
            <br />
            <hr/>
            <asp:MultiView ID="MultiView1" runat="server">
                加入兩個 View ( &lt;-- 這個只能放在 Muti View 之中 )<br />
                <asp:View ID="View1" runat="server">
                    檢視資料夾內容 
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    <br />
                    <br />
                </asp:View>
                <asp:View ID="View2" runat="server">
                    2. 加入 Lable ,&nbsp; FileUpload , Button<br />
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="請選擇檔案"></asp:Label>
                    &nbsp;( P340 的範例在上方有得選？怎做，沒這步驟呀？)<br />
                    <br />
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="確認上傳" />
                    &nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                    <br />
                    <br />
                    <br />
                    4. Button Click 的事件處理<br />
                    <br />
                    if (FileUpload1.HasFile)
                    <br />
                    FileUpload1.SaveAs(Server.MapPath(@&quot;NewFolder1\&quot; + FileUpload1.FileName));
                    <br />
                </asp:View>
                <br />
            </asp:MultiView>
            <hr/>
            <br />
            5. 試 F5 的時候，第三個步驟導致出錯，先去了解 Muti View<br />
            <br />
            <a href="https://dotblogs.com.tw/mikeceo/2015/03/03/150619">https://dotblogs.com.tw/mikeceo/2015/03/03/150619</a><br />
            回去補充第三步。<br />
            <br />
            6. 研究如何顯示某個資料夾中的檔案內容於 View1<br />
            <br />
            <a href="https://blog.xuite.net/tolarku/blog/213947444-[ASP.NET]+列出某目錄下所有檔案並給予連結+-+使用+Label+-+C%2523">https://blog.xuite.net/tolarku/blog/213947444-%5BASP.NET%5D+%E5%88%97%E5%87%BA%E6%9F%90%E7%9B%AE%E9%8C%84%E4%B8%8B%E6%89%80%E6%9C%89%E6%AA%94%E6%A1%88%E4%B8%A6%E7%B5%A6%E4%BA%88%E9%80%A3%E7%B5%90+-+%E4%BD%BF%E7%94%A8+Label+-+C%23</a><br />
            補充了 View1 和 Page Load , xDirFileList<br />
            <br />
            7.&nbsp; 第一次載入頁面時，即使 Radio Button List 選在第一個，但是 View1 沒有出現？<br />
            <br />
            在 page load 加入&nbsp;
            MultiView1.ActiveViewIndex = RadioButtonList1.SelectedIndex;&nbsp; 來解決<br />
            <br />
            8.&nbsp; 發現如果 txt 檔是無資料的話，就無法上傳。打幾個字入去又好了。因為&nbsp; FileUpload1.HasFile 可以判斷裡面是否為空。<br />
            <br />
            9. 為什麼上傳失敗也不會出錯誤訊息呢？沒有預設？<br />
            <br />
            自己加入else 和 try...catch 和 Label 3 顯示。&nbsp; 但發現 檔案太大時，會直接當了網頁，而不是由 catch 處理？<br />
            <br />
            10.&nbsp;&nbsp; 判斷檔案的大小和有否重覆<br />
            <a href="https://melomelo1988.pixnet.net/blog/post/162838827">https://melomelo1988.pixnet.net/blog/post/162838827</a><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 檔案的大小單位<br />
            <a href="https://blog.miniasp.com/post/2010/04/08/unit-information-Bit-Byte-KB-MB-GB-TB-PB-EB-ZB-YB">https://blog.miniasp.com/post/2010/04/08/unit-information-Bit-Byte-KB-MB-GB-TB-PB-EB-ZB-YB</a><br />
            見 Button 中的實作<br />
            <br />
            11. 判斷型別<br />
            <a href="https://codertw.com/前端開發/221540/">https://codertw.com/%E5%89%8D%E7%AB%AF%E9%96%8B%E7%99%BC/221540/</a><br />
            見 Button 中的實作<br />
            (目前只實作了網頁中其中一種的方法，如果用到的話，再研究。)<br />
            <br />
            12. 如果病毒的檔案偽裝了副案名？ ... 很複雜，以後討論。<br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
