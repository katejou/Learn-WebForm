<%@ Page Title="" Language="C#" MasterPageFile="EX6_2.Master" AutoEventWireup="true" CodeBehind="EX6_2ContentPage1.aspx.cs" Inherits="ASP.NET_EX6._2_.EX6_2ContentPage1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Content Page 1 的 Content Place Holder 1<br />
Label 1 :<p>
    <asp:Label ID="Label1" runat="server" Text="我是未被改變的 Content Page 的 Label 1"></asp:Label>
</p>
    <p>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="我要改變 Master Page 的 Label 1 內容 " />
</p>
</asp:Content>
