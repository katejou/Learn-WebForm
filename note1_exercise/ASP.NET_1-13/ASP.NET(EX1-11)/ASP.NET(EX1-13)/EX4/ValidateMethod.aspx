<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidateMethod.aspx.cs" Inherits="ASP.NET_EX4._4_.ASP_NET_EX4__4_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:Label ID="Label1" runat="server" Text="這個是AUTO POST BACK 的 TEXT BOX"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="我是第一項的必填錯誤訊息"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="輸入，按ENTER = 通過(沒有POST BACK)"></asp:Label>
        <br />
        <asp:Label ID="Label7" runat="server" Text="刪除內容, 按ENTER = 顯示錯誤訊息(沒有POST BACK)"></asp:Label>
        <br />
        輸入內容，點一下頁面 = 通過 (有POST BACK, 雖然我在POST BACK中並沒有提過它。)<br />
        <asp:Label ID="Label2" runat="server" Text="刪除內容，點一下頁面 = 錯誤的訊息會一閃而逝(因為有POST BACK，而POST BACK 清洗了它的ERROR MESSAGE)"></asp:Label>
        <br />
        <br />
        Enter = 前端驗證，Click = Post Back
        <br />
        <asp:Label ID="Label9" runat="server" Text="因為錯誤的訊息是前端的，開了AUTO POST BACK 要HOLD 訊息的話，如下︰"></asp:Label>
        <br />
        <br />
        ---------------------------------------------------------------------------------------------<br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="以下是開了AUTO POST BACK"></asp:Label>
        <br />
        <asp:Label ID="Label10" runat="server" Text="關了檢驗的 ENABLE CLIENT SCRIPT"></asp:Label>
        <br />
        我指定了一個 Group (G1) 給檢驗項<br />
        在POST BACK 中，Validate(&quot;G1&quot;) 去驗了這個項目。<br />
        <asp:Label ID="Label11" runat="server" Text="的 TEXT BOX :"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" EnableClientScript="False" ErrorMessage="我是第二項的錯誤訊息" ValidationGroup="G1"></asp:RequiredFieldValidator>
        <br />
        <br />
        特點︰<br />
        因為它有POST BACK 檢查，它第一次開啟就會有ERROR MESSAGE。<br />
        它不論是ENTER還是點擊，都會POST BACK, 因為他沒有了ENABLE CLIENT SCRIPT。<br />
        <br />
        ---------------------------------------------------------------------------------------------<br />
        <br />
        <asp:Label ID="Label15" runat="server" Text="以下是保留第二項所有設定"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label26" runat="server" Text="除了改 設定Group 為 G2"></asp:Label>
        <br />
        <asp:Label ID="Label16" runat="server" Text="加上 SET FOUCE ON ERROR = TURE "></asp:Label>
        <br />
        <asp:Label ID="Label17" runat="server" Text="和 if (IsPostBack) 的才Validate(&quot;G2&quot;)"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="TextBox3" runat="server" AutoPostBack="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" EnableClientScript="False" ErrorMessage="第三項的ERROR MESSAGE" SetFocusOnError="True" ValidationGroup="G2"></asp:RequiredFieldValidator>
        <br />
        <br />
        特點︰<br />
        <asp:Label ID="Label18" runat="server" Text="它和第二項不同，它不是一開頁就驗，它POST BACK 之後才驗"></asp:Label>
        。<br />
        <asp:Label ID="Label19" runat="server" Text="而且他一驗了就每次POST BACK後游標停留在上面，直到對為止。"></asp:Label>
        <br />
        ---------------------------------------------------------------------------------------------<br />
        <br />
        <asp:Label ID="Label21" runat="server" Text="下面這個驗證的BUTTON做了 CausesValidation = false "></asp:Label>
        <br />
        但是它綁了GROUP G3, 和一個SUMMARY。<br />
        <asp:Label ID="Label36" runat="server" Text="輸入框也開了AUTO POST BACK"></asp:Label>
        <br />
        但是POST BACK 中沒有提過他。<br />
        <br />
        <asp:TextBox ID="TextBox4" runat="server" ValidationGroup="G3" AutoPostBack="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="第四項的ERROR MESSAGE" ValidationGroup="G3">*</asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="G3" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" CausesValidation="False" OnClick="Button3_Click" OnClientClick="False" Text="G3 的驗證" ValidationGroup="G3" />
        <br />
        <br />
        輸入內容, 再ENTER, 畫面就會跳，代表有POST BACK&nbsp; = 清空<br />
        內容刪除, 再按ENTER = ERROR 的 TEXT&nbsp; * 會出現&nbsp; = 沒有POST BACK<br />
        ( 結論︰按ENTER的話，有ERROR就會被前端擋下, 通過的話就會去後端POST BACK。)<br />
        <br />
        按 G3驗證Button 只會POST BACK = 清空 = 如果有 * 也會一閃而逝。<br />
        把CauseValidation開了感受一它原本是可以引發SUMMARY的。<br />
        關上CauseValidation 。<br />
        <br />
        <br />
        ---------------------------------------------------------------------------------------------<br />
        <br />
        書說它可以做整頁的驗證顯示，不論是封了Cause Validation, 還是有AUTO POST BACK 清理所有 ERROR MESSAGE 的。<br />
        但它其實有先後的次序︰<br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="做 Validate()" OnClick="Button1_Click" />
        <br />
        <br />
        先把POST BACK 中的 Validate(&quot;G1&quot;) 到 (&quot;G2&quot;)的內容 註解掉<br />
        把所有驗證項的 ENABLE CLIENT SCRIPT開了(預設為開。第二三項是我手動關了的。)<br />
        再按下這個Validate()︰<br />
        <br />
        它不會POST BACK 因為它卡在第一項的錯誤，直到第一項完成為止。<br />
        輸入第一項，再按︰<br />
        它會POST BACK 但只驗查了第一項沒有問題。第二到四項沒有驗查。<br />
        再按︰<br />
        它會POST BACK 顯示第二到四項的ERROR MESSAGE, 但是他是每按一次都POST BACK, 不像第一項ERROR那般會卡住POST BACK。<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (結論︰第一項和 2~4 的分別是沒有設定GROUP, 有否GROUP, 對Validate()這個動作有影響。<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 單項比GROUP 先，有GROUP的，又會是同一個先後。<br />
        <br />
        <br />
        輸入第二項，再按︰<br />
        第三四項的ERROR也不見了，再按︰<br />
        第三四項的ERROR 才重新出現。<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (結論︰Validate()收到了第一個通過的訊息，它退出了。)<br />
        <br />
        把第1~2 項的內容刪了，再按Validate() :<br />
        POST BACK 但沒有任何1~4的ERROR Message!<br />
        再按︰<br />
        又回到無POST BACK, 卡在第一項的情形。<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (結論︰Validate()又收到了ERROR的反應，又馬上退出了？)<br />
        <br />
        <br />
        如果我反過來，關了所有的 ENABLE CLIENT SCRIPT。<br />
        <br />
        第一次按下Validate()就會顯示所有的ERROR MESSAGE<br />
        輸入第一項再按Validate() :
        <br />
        所有的ERROR MESSAGE 取消<br />
        再按一下︰<br />
        2~4出現<br />
        輸入第2 , 第按下︰<br />
        所有MESSAGE取消。<br />
        刪除第2，按下︰<br />
        所有MESSAGE取消。<br />
        <br />
        (結論︰當頁面有改變時，不論是輸入還是刪除，第一下的Validate()是會不給出任何MESSAGE的，第二下才會。)<br />
        (結論二︰關了所有的 ENABLE CLIENT SCRIPT 會把單項和GROUP的先後同步，每次都會POST BACK。)<br />
        <br />
        <br />
        也會同時的顯示所有訊息。<br />
        <br />
        還原︰<br />
        <br />
        把 1 , 4 的 ENABLE CLIENT SCRIPT 開啟<br />
        <asp:Label ID="Label31" runat="server" Text="把Page Load 的關於G1和G2的內容 取消註解"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label32" runat="server" Text="還原後︰第一和四項的ERROR MESSAGE 是這個按鈕做的。"></asp:Label>
        <br />
        第二﹑三項是PAGE LOAD去做的。<br />
        <br />
        顯示的次序如下︰<br />
        第二項一開就出現，因為PAGE LOAD<br />
        <br />
        按Validate()︰&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <br />
        第一項就會開始出現並卡住不給 PAGE LOAD。<br />
        <br />
        輸入第一項後，按Validate()︰&nbsp;&nbsp; 
        <br />
        第三項會出現，但第四項尚未出現。<br />
        (因為Validate()面對改變要隔一下才做，第三項是因為POST BACK 才出現的。)<br />
        <br />
        再按一下︰<br />
        第四項才出現。<br />
        <br />
        <br />
        建議︰如無必要，不要開Validate(), 用Validate(&quot;群組&quot;)就夠了。<br />
        ---------------------------------------------------------------------------------------------<br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
