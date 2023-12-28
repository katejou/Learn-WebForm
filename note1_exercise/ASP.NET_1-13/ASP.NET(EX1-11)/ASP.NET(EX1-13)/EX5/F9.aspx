<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="F9.aspx.cs" Inherits="ASP.NET_EX5._1_.ASP_NET_EX5__1_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #5B9BD5;
            font-style: italic;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span class="auto-style1"><span lang="EN-US" style="font-size:12.0pt;mso-bidi-font-size:11.0pt;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-fareast-font-family:新細明體;mso-fareast-theme-font:
minor-fareast;mso-hansi-theme-font:minor-latin;mso-bidi-font-family:&quot;Times New Roman&quot;;
mso-bidi-theme-font:minor-bidi;mso-ansi-language:EN-US;mso-fareast-language:
ZH-TW;mso-bidi-language:AR-SA">P 166 </span><span style="font-size:12.0pt;
mso-bidi-font-size:11.0pt;font-family:&quot;新細明體&quot;,serif;mso-ascii-font-family:Calibri;
mso-ascii-theme-font:minor-latin;mso-fareast-theme-font:minor-fareast;
mso-hansi-font-family:Calibri;mso-hansi-theme-font:minor-latin;mso-bidi-font-family:
&quot;Times New Roman&quot;;mso-bidi-theme-font:minor-bidi;mso-ansi-language:EN-US;
mso-fareast-language:ZH-TW;mso-bidi-language:AR-SA">實作中斷點</span><span style="font-size:12.0pt;mso-bidi-font-size:11.0pt;font-family:&quot;Calibri&quot;,sans-serif;
mso-ascii-theme-font:minor-latin;mso-fareast-font-family:新細明體;mso-fareast-theme-font:
minor-fareast;mso-hansi-theme-font:minor-latin;mso-bidi-font-family:&quot;Times New Roman&quot;;
mso-bidi-theme-font:minor-bidi;mso-ansi-language:EN-US;mso-fareast-language:
ZH-TW;mso-bidi-language:AR-SA"> </span></span>
            <br />
            <br />
        </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="點我" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
