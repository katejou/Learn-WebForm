<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="partly_cache_loadViewState_userCtrl.aspx.cs" Inherits="note2_ex3.loadViewState_userCtrl" %>

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
            因為 UserControl 加入了 Cache，所有 UserCtrl 的 PostBack 都要「隔十秒」才給你一個新的反應。 
            <br />
            但是CheckBox就是原生頁上的，所以沒有Cache。<br />
            <br />
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" 
                Text="是否顯示(/載入)這個動態加入來的userControl" 
                OnCheckedChanged="CheckBox1_CheckedChanged" 
                AutoPostBack="true"/>
            <br />
            <asp:Button ID="Button1" runat="server" Text="測PostBack反應的Btn(顯示它即使是動態加入的還是不受影響，像是原生的一樣)" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
