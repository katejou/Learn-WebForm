<%@ Page Title="" Language="C#" MasterPageFile="EX6_1.Master" AutoEventWireup="true" CodeBehind="EX6_1ContentPage1.aspx.cs" Inherits="ASP.NET_EX6._1_.EX6_11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        我是Content Page 1所定義的 Holder 1</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p>
       我是Content Page 1所定義的 Holder 2 <br>
        <br>
        因為這個 HOLDER 是在這個 CONTENT PAGE 之後建立的<br>
        所以我在原始檔中，自己置入這個ASP元件(/控制項)。</p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br>       
    </p>
</asp:Content>
