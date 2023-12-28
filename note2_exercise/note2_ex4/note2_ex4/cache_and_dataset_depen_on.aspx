<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cache_and_dataset_depen_on.aspx.cs" Inherits="note2_ex4.cache_and_dataset_do" %>
<%@ import Namespace= "System.Data" %>
<%@ import Namespace= "System.Data.SqlClient" %> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br/>
            修改了Cache["key1"]， Cache["Region"]就不存在了
            <br/>
            我設Cache["Region"] 為 DataSet，Cache["key1"] 為普通字串
            <br/>
            <br/>
            <asp:Button ID="Button2" runat="server" Text="改Key1資料" OnClick="Button2_Click" />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br/>
            <br/>
            <asp:Button ID="Button1" runat="server" Text="取Key2資料" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br/>
            <br/>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
