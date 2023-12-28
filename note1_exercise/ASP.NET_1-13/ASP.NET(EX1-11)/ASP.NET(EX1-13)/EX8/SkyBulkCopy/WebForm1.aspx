<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASP.NET_EX8._5_.WebForm14" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 342px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="pig" DataSourceID="SqlDataSource123" PageSize="5">
                        <Columns>
                            <asp:BoundField DataField="pig" HeaderText="pig" ReadOnly="True" SortExpression="pig" />
                            <asp:BoundField DataField="pork" HeaderText="pork" SortExpression="pork" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource123" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSBK %>" SelectCommand="SELECT * FROM [farm]"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="suasage" DataSourceID="SqlDataSource223" PageSize="5">
                        <Columns>
                            <asp:BoundField DataField="suasage" HeaderText="suasage" ReadOnly="True" SortExpression="suasage" />
                            <asp:BoundField DataField="soul" HeaderText="soul" SortExpression="soul" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource223" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringSBK %>" SelectCommand="SELECT * FROM [factory]"></asp:SqlDataSource>
                </td>
            </tr>
        </table>

        <p>
            SqlBulkCopy
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="一次過加入大量資料" />
        </p>
        <div>
            將 DataTable 一次過輸入表格<br />
            <br />
            DataTable 可以是來自另一個表格的搜尋結果<br />
            <br />
            欄名可以不同，在輸入時做個對照就好了。<br />
            <br />
            以上的將要被輸入的資料表 farm 是用 Visual Studio 去建的。只有兩個欄位，名叫 pig , pork<br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="轉移表格" />
            <br />
            <br />
            當資料輸入後，再轉移到另一個表格 factory ，有另外兩個欄位︰ sausage , soul
            <br />
            <br />
            這兩個欄位的名稱不同，次序也相反。<br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="清除資料" />
            <br />
            <br />
            再下一個按鈕，清除這兩個表格的資料。<br />
            <br />
            進階的提醒功能，暫不實作，要了解請看筆記中的參考網址。<br />
        </div>
    </form>
</body>
</html>
