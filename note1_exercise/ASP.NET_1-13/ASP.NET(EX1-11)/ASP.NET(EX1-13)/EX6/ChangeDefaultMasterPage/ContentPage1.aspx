<%@ Page Title="" Language="C#" MasterPageFile="Master1.Master" AutoEventWireup="true" CodeBehind="ContentPage1.aspx.cs" Inherits="ASP.NET_EX6._4_.ContentPage1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        我是Content Page 1
        ,
        我預設是 Master Page 1</p>
    <p>
        如果是 Content Page 2 跳入來的話，我的Master Page 會是 2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-top: 0px" Text="我要去Content Page 2" />
    </p>
    <p>
        如果是 Content Page 3 跳入來的話，我的Master Page 會是 1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="我要去Content Page 3" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        因為我在後端加入 一段內容 動態地覆寫了要載入的Master Page。</p>
    <p>
        也用了第一種網頁間傳值的功能(見上方的網址) 做判斷。</p>
</asp:Content>
