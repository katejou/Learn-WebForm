<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cache_and_dataset_still_time.aspx.cs" Inherits="note2_ex4.cache_and_dataset_st" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
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
            閒置 5 秒後，Cache 會消失 
            <br />
            () = 一直按，會FormCache | 隔 5 秒按，會From DB
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="取資料" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
