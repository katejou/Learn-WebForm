<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WMI_ex.aspx.cs" Inherits="note3_ex1.ProcessControl.WMI_ex" %>

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
            <asp:Label ID="Label1" runat="server" Text="非同步處理，監控新建立帳號"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="開始監控" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="停止監控" OnClick="Button2_Click" />
            <br />
            <br />
            無法進行 第 11( P 391 ) 個步驟，我猜它的意思是，在關閉這個運行之前，請一定要按下「停止監控」<br />
            我不知道在 WebForm 可以怎麼做，所以我只好手動了…
            <br />
            <br />
            <br />
            後知「開始監控」的方法無法實作，所以這個練習失敗，只是留個紀綠。
        </div>
    </form>
</body>
</html>
