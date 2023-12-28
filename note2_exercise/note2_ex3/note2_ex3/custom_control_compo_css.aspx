<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="custom_control_compo_css.aspx.cs" Inherits="note2_ex3.custom_control_compo_css" %>

<!DOCTYPE html>
<%@ Register Assembly="note2_ex3_compo_calendar" Namespace="note2_ex3_compo_css" TagPrefix="cc" %>
<%@ Register Assembly="note2_ex3_compo_calendar" Namespace="note2_ex3_compo_calendar" TagPrefix="cc2" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .text {
            color: aqua;
        }
        .tb {
            background-color: aquamarine;
        }
        .btn {
            color: blueviolet;
        }
        .cal {
            color: chocolate;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <cc:compo_with_css ID="ProductControl1" runat="server">
                <ItemTemplate>
                    <h2 class="text">產品代號 : <%# Container.ProductID %> </h2>
                    <br />
                    <h2 class="text">產品名稱 : <%# Container.ProductName %> </h2>
                    <br />
                    <h2 class="text">單價 : <%# Container.UnitPrice %>  </h2>
                </ItemTemplate>
            </cc:compo_with_css>
            <cc2:compo_ca2_css ID="ProductControl2" runat="server">
                <ItemTemplate>
                    <%# Container.txt %>
                    <br />
                    <%# Container.btn %>
                    <br />
                    <%# Container.cal %>
                </ItemTemplate>
            </cc2:compo_ca2_css>

        </div>
    </form>
</body>
</html>
