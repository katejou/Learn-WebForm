<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hash_ex.aspx.cs" Inherits="note3_ex3.Hash_ex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Hash</h1>
            <br />
            文字輸入:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="產生第一個Hash" OnClick="Button1_Click" />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="產生第二個Hash + 驗証是否一樣" OnClick="Button2_Click" />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <br />
            驗証結果︰
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <hr />
            P580 練習&nbsp;&nbsp;&nbsp; 將密碼寫入檔案<br />
            <br />
            <br />
            設定密碼︰
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="存檔" OnClick="Button3_Click" />
            <asp:Label ID="Label4" runat="server" ></asp:Label>
            <br />
            <br />
            輸入密碼︰
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text="讀取檔案 + 對比輸入密碼" OnClick="Button4_Click" />
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" ></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
