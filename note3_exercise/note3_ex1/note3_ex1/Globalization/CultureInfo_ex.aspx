<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CultureInfo_ex.aspx.cs" Inherits="note3_ex1.Globalization.CultureInfo_ex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>數字格式化(ToString的特定參數)</h2>
            <asp:Label ID="Label1" runat="server" Text="數量︰1000"></asp:Label>
            <br />
            "c" 化成 金額 ︰
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            "n" 化成 數字 ︰
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <br />
            <h2>將有金額的字串，化回為數字</h2>
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
            <br />
            <h2>自定文化及其中的格式化形式</h2>
            該文化原本的格式化形式︰
            <br />
            <br />
            "c" 化成 金額 ︰
            <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
            <br />
            "n" 化成 數字 ︰
            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
            <br />
            <br />
            該文化被改做後的格式化形式︰
            <br />
            <br />
            "c" 化成 金額 ︰
            <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
            <br />
            "n" 化成 數字 ︰
            <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
            <br />
            <h2>cultureInfo.DateTimeFormat.ShortDataPattern</h2>
            顯示這個文化的ShortDataPattern時間格式︰
            <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
            <br />
            這個文化的 "d" 化成 時間 ︰
            <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
            <br />
            這個文化的 ShortDataPattern 化成 時間 ︰
            <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
            <br />
            <h2>改寫 DateTimeFormat 星期 </h2>
            原 : 
            <asp:Label ID="Label12" runat="server" Text=""></asp:Label>
            <br />
            今日星期 :
             <asp:Label ID="Label13" runat="server" Text=""></asp:Label>
            <br />
            改 : 
            <asp:Label ID="Label14" runat="server" Text=""></asp:Label>
            <br />
            今日星期 : 
            <asp:Label ID="Label15" runat="server" Text=""></asp:Label>
            <br />
            <h2>改寫 NumberFormatInfo 和 DateTimeFormat.LongDatePattern</h2>
            改寫前負金額︰
            <asp:Label ID="Label16" runat="server" Text=""></asp:Label>
            <br />
            改寫後負金額︰
            <asp:Label ID="Label17" runat="server" Text=""></asp:Label>
            <br />
            改寫前"F"日期︰
            <asp:Label ID="Label18" runat="server" Text=""></asp:Label>
            <br />
            改寫後"F"日期︰
            <asp:Label ID="Label19" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
