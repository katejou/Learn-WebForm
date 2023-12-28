<%@ Page Title="" Language="C#" MasterPageFile="EX6_3.Master" AutoEventWireup="true" CodeBehind="ContentPage2.aspx.cs" Inherits="ASP.NET_EX6._3_.WebForm2" %>

<%@ MasterType VirtualPath="EX6_3.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        我是Content Page 2</p>
<p>
        我是用&lt;%@ MasterType VirtualPath =&quot;XXX&quot;去做的︰<br />
    </p>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="我要去改 Master Page Label 1 的內容" />
    <p>
    </p>
</asp:Content>
