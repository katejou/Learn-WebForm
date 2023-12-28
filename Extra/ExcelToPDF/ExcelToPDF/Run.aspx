<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Run.aspx.cs" Inherits="ExcelToPDF.Run" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Excel -> PDF</h2>
            <br/>
            <asp:Button runat="server" Text="開始" ID="Btn1" OnClick="Btn1_Click"></asp:Button>
        </div>
    </form>
</body>
</html>
