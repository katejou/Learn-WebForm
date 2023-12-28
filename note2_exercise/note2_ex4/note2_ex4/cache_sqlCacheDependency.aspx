<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cache_sqlCacheDependency.aspx.cs" Inherits="note2_ex4.cache_sqlCacheDependency" %>

<%@ OutputCache Duration="10" VaryByParam="None" SqlDependency="NorthwindCacheDependencyName:Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="更新GridView" OnClick="Button2_Click" />
            <br />
            <asp:Button ID="Button1" runat="server" Text="改資料庫Table資料" OnClick="Button1_Click" />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <br />
            <br />

            <asp:GridView runat="server" ID="GridView1" 
                DataSourceID ="SqlDataSource1"
                AutoGenerateColumns="False" DataKeyNames="EmployeeID" EmptyDataText="沒有資料錄可顯示。">
                <Columns>
                    <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ReadOnly="True" SortExpression="EmployeeID"></asp:BoundField>
                    <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString1 %>" 
                ProviderName="<%$ ConnectionStrings:NorthwindConnectionString1.ProviderName %>" 
                SelectCommand="SELECT [EmployeeID], [LastName] FROM [Employees] Where EmployeeID = 1"
                UpdateCommand="SELECT [EmployeeID], [LastName] FROM [Employees] Where EmployeeID = 1"
                >
            </asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
