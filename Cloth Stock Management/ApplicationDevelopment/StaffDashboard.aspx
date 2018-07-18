<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StaffDashboard.aspx.cs" Inherits="ApplicationDevelopment.StaffDashboard" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
     <div class="dropdown">
                <asp:Button runat="server" CausesValidation="false" Text="Accounts" class="btn btn-insert dropdown-toggle" type="button" data-toggle="dropdown"/>
                    
                <span class="caret" data-toggle="dropdown"></span>

                <ul class="dropdown-menu">
                    <li>
                        <asp:LinkButton ID="btnLogout" CausesValidation="false" runat="server" OnClick="btnLogout_Click" CssClass="normal-text" Text="Logout"></asp:LinkButton>
                    </li>
                    <li>
                        <asp:LinkButton ID="changePassword" CausesValidation="false" runat="server" PostBackUrl="~/ChangePassword.aspx" CssClass="normal-text" Text="Change Password"></asp:LinkButton>
                    </li>
                </ul>
            </div>
    <link href="css/common.css" rel="stylesheet" />
    <h2 style="color:white;" runat="server" title="List of the items">List of items currently out of stock:</h2>
        <div class="table">
            <asp:GridView ID="GridView1" runat="server" Width="300px" CssClass="table-style">
                <Columns>
                </Columns>
            </asp:GridView>

            <br />
            <hr />
            <asp:GridView ID="GridView2" runat="server" Width="0px" Height="0px" CssClass="table-style">
                <Columns>
                </Columns>
            </asp:GridView>

            <br />
            <hr />

            
            <h2 style="color:white;">All Items out of Stock</h2>
            <asp:GridView ID="GridView3" runat="server" CssClass="table-style">
                <Columns>
                </Columns>
            </asp:GridView>
            <br />
            <hr />

            <h2 style="color:white;">Item not sold in 31 days</h2>
            <asp:GridView ID="longTimeStock" runat="server" CssClass="table-style">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn-delete" CausesValidation="false" OnClick="deleteBtnClicked" Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <hr />
            <h2 style="color:white;">Pie Chart of Total Sales of Product</h2>

            <asp:Chart ID="Chart1" runat="server" Width="350px">
                <Titles>
                    <asp:Title Text="Total Sales of Items">
                    </asp:Title>
                </Titles>
                <Series>
                    <asp:Series Name="Series1" ChartArea="ChartArea1" ChartType="Pie">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                        <AxisX Title="Product">
                        </AxisX>
                        <AxisY Title="Quantity">
                        </AxisY>
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>
        </div>
    </form>
</asp:Content>
