<%@ Page Title="" Language="C#" MasterPageFile="Master2.Master" AutoEventWireup="true" CodeBehind="ContentPage2.aspx.cs" Inherits="ASP.NET_EX6._4_.ContentPage2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        我是Content Page 2</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="我要跳過去Content Page 1" OnClick="Button1_Click" />
    </p>
    <p>
        &nbsp;</p>
</asp:Content>
