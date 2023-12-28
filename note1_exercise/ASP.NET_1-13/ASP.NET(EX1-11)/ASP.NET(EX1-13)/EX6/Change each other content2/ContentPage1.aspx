<%@ Page Title="" Language="C#" MasterPageFile="EX6_3.Master" AutoEventWireup="true" CodeBehind="ContentPage1.aspx.cs" Inherits="ASP.NET_EX6._3_.WebForm1" %>

<%@ MasterType VirtualPath="EX6_3.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        我是 Content Page 1 </p>
    <p>
        我是用強轉型別指令 ((EX6_3)this.Master).TextValue = &quot;XXX&quot;; 去做&nbsp; :</p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="我要去改變 Master Page 的 Label 1" />
    <p>
        &nbsp;</p>
</asp:Content>
