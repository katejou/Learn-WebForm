<%@ Page Title="" Language="C#" MasterPageFile="Master1.Master" AutoEventWireup="true" CodeBehind="ContentPage3.aspx.cs" Inherits="ASP.NET_EX6._4_.ContentPage3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        我是 Content Page 3<br />
    </p>
    <asp:Button ID="Button1" runat="server" Text="我要跳過去Content Page 1" OnClick="Button1_Click" />
    <p>
        &nbsp;</p>
</asp:Content>
