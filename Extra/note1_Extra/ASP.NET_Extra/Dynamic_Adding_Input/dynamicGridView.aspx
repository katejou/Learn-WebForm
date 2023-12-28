<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dynamicGridView.aspx.cs" Inherits="WebApplication1.dynamicGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            不經由 DataBase 來對 Gridview 做操作
            <br />
            <a href="http://dotnetmis91.blogspot.com/2008/12/gridview.html">http://dotnetmis91.blogspot.com/2008/12/gridview.html</a>
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" OnClick="AddGV" Text="新增" />
            <br />
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="input_text" HeaderText="輸入" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server"
                                CommandArgument='<%#Eval("input_tex")%>'
                                OnClick="lbtnEdit_Click">刪除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>




            </asp:GridView>

        </div>
    </form>
</body>
</html>
