<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cache_and_dataset_abs_time.aspx.cs" Inherits="note2_ex4.cache_and_dataset_at" %>
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
            設定，「絕對」於成立後的 5 秒後消失 ( ) = 每 5 秒更新一次
            <br/>
            <br/>
            <asp:Button ID="Button1" runat="server" Text="取資料" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br/>
            <br/>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
