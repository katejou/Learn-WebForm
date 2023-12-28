<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASP.NET_EX8._3_.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>資料連結元件</title>
 
</head>
<body>
    <br />
    <form id="form1" runat="server">
        <hr/>
        <br />
    實作GridView  <br />
        自動格式化 , 分頁, 排序(點欄名，因順逆變色), 總標題<br />
        <br />
        <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource3" EmptyDataText="沒有資料錄可顯示。" ForeColor="#333333" GridLines="None" PageSize="3" Height="100px" Width="200px" Caption="Person" EnableSortingAndPagingCallbacks="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="age" HeaderText="age" SortExpression="age" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#FF33CC" />
            <SortedAscendingHeaderStyle BackColor="#FF6666" />
            <SortedDescendingCellStyle BackColor="#00CC00" />
            <SortedDescendingHeaderStyle BackColor="#99FF66" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:data_baseConnectionString %>" SelectCommand="SELECT * FROM [preson]" DeleteCommand="DELETE FROM [preson] WHERE [name] = @name" InsertCommand="INSERT INTO [preson] ([name], [age]) VALUES (@name, @age)" UpdateCommand="UPDATE [preson] SET [age] = @age WHERE [name] = @name">
            <DeleteParameters>
                <asp:Parameter Name="name" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="age" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="age" Type="Int32" />
                <asp:Parameter Name="name" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        更改顯示資料格式﹐選取變色效果<br />
        <br />
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="datetime" DataFormatString="{0:dd/MM/yyyy}" HeaderText="datetime" SortExpression="datetime" />
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <SelectedRowStyle BackColor="Lime" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:data_baseConnectionString %>" SelectCommand="SELECT * FROM [formatChange]"></asp:SqlDataSource>
        <br />
        <br />
        <br />
        <hr/>

        <br />
        實作 FormView<br />
        分頁<br />
        <br />
        <asp:FormView ID="FormView1" runat="server" AllowPaging="True" DataSourceID="SqlDataSource4">
            <EditItemTemplate>
                name:
                <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
                <br />
                age:
                <asp:TextBox ID="ageTextBox" runat="server" Text='<%# Bind("age") %>' />
                <br />
                <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="更新" />
                &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
            </EditItemTemplate>
            <InsertItemTemplate>
                name:
                <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
                <br />
                age:
                <asp:TextBox ID="ageTextBox" runat="server" Text='<%# Bind("age") %>' />
                <br />
                <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="插入" />
                &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" />
            </InsertItemTemplate>
            <ItemTemplate>
                name:
                <asp:Label ID="nameLabel" runat="server" Text='<%# Bind("name") %>' />
                <br />
                age:
                <asp:Label ID="ageLabel" runat="server" Text='<%# Bind("age") %>' />
                <br />

            </ItemTemplate>
        </asp:FormView>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:data_baseConnectionString %>" SelectCommand="SELECT * FROM [preson]" DeleteCommand="DELETE FROM [preson] WHERE [name] = @name" InsertCommand="INSERT INTO [preson] ([name], [age]) VALUES (@name, @age)" UpdateCommand="UPDATE [preson] SET [age] = @age WHERE [name] = @name">
            <DeleteParameters>
                <asp:Parameter Name="name" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="age" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="age" Type="Int32" />
                <asp:Parameter Name="name" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <hr/>

        <br />
        實作 DetailView<br />
        自動格式化 , 分頁, 調屬性 height &amp; width ,&nbsp; 開放修改資料的功能<br />
        <br />
        <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="SqlDataSource4" Height="50px" Width="309px" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateInsertButton="True">
            <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="name" HeaderText="名字" SortExpression="name" >
                <HeaderStyle Width="90px" />
                </asp:BoundField>
                <asp:BoundField DataField="age" HeaderText="年紀" SortExpression="age" />
            </Fields>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        </asp:DetailsView>
        <br />
        Default Mode : EDIT<br />
        <asp:DetailsView ID="DetailsView2" runat="server" AllowPaging="True" AutoGenerateRows="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="SqlDataSource4" Height="50px" Width="309px" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateInsertButton="True" DefaultMode="Edit">
            <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="name" HeaderText="名字" SortExpression="name" >
                <HeaderStyle Width="90px" />
                </asp:BoundField>
                <asp:BoundField DataField="age" HeaderText="年紀" SortExpression="age" />
            </Fields>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        </asp:DetailsView>
        <br />
        Default Mode : INSERT<br />
        <asp:DetailsView ID="DetailsView3" runat="server" AllowPaging="True" AutoGenerateRows="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataSourceID="SqlDataSource4" Height="50px" Width="309px" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" AutoGenerateInsertButton="True" DefaultMode="Insert">
            <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="name" HeaderText="名字" SortExpression="name" >
                <HeaderStyle Width="90px" />
                </asp:BoundField>
                <asp:BoundField DataField="age" HeaderText="年紀" SortExpression="age" />
            </Fields>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        </asp:DetailsView>
        <br />
        <br />
        <hr/>

        <br /> 
        實作 DataList <br />
        <br /> <br />
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource4">
            <ItemTemplate>
                name:
                <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                <br />
                age:
                <asp:Label ID="ageLabel" runat="server" Text='<%# Eval("age") %>' />
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
        <div>
            <br />
            <hr/>
            <br />
            實作 ListView&nbsp; +&nbsp; DataPager 分頁<br />
            <br />
            <br />
            <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource4">
                <AlternatingItemTemplate>
                    <tr style="background-color: #FFFFFF;color: #284775;">
                        <td>
                            <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ageLabel" runat="server" Text='<%# Eval("age") %>' />
                        </td>
                    </tr>
                </AlternatingItemTemplate>
                <EditItemTemplate>
                    <tr style="background-color: #999999;">
                        <td>
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                        </td>
                        <td>
                            <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ageTextBox" runat="server" Text='<%# Bind("age") %>' />
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                        <tr>
                            <td>未傳回資料。</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td>
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                        </td>
                        <td>
                            <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ageTextBox" runat="server" Text='<%# Bind("age") %>' />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="background-color: #E0FFFF;color: #333333;">
                        <td>
                            <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ageLabel" runat="server" Text='<%# Eval("age") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                    <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                                        <th runat="server">name</th>
                                        <th runat="server">age</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="3">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                        <asp:NumericPagerField />
                                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <SelectedItemTemplate>
                    <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                        <td>
                            <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ageLabel" runat="server" Text='<%# Eval("age") %>' />
                        </td>
                    </tr>
                </SelectedItemTemplate>
            </asp:ListView>
            <br />
            <br />
        </div>
    </form>
    <br />
    <br />
</body>
</html>
