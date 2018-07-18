<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="customerTransaction.aspx.cs" Inherits="ApplicationDevelopment.customerTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

    <html>
    <head>
        <title></title>

    </head>
    <body>

        <form id="form1" runat="server">
           
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
            <fieldset>


                <div class="record-form">

                    <legend><span class="number">1</span> Add Customer Sales</legend>


                    <asp:Label ID="Label3" CssClass="label" runat="server" Text="Customer ID:" Width="160px"></asp:Label>
                    <asp:DropDownList ID="customerNameDropDown" runat="server" AutoPostBack="true" CssClass="textbox" Width="350px" OnSelectedIndexChanged="customerIndexChanged"></asp:DropDownList>
                    <asp:DropDownList ID="customerDropDown" Enabled="false" runat="server" CssClass="textbox" Width="350px"></asp:DropDownList>
                    <br />
                    <br />

                    <asp:Label ID="Label2" CssClass="label" runat="server" Text="User ID:" Width="160px"></asp:Label>
                    <asp:DropDownList ID="userNameDropDown" runat="server" AutoPostBack="true" CssClass="textbox" Width="350px" OnSelectedIndexChanged="userIndexChanged"></asp:DropDownList>
                    <asp:DropDownList ID="userDropDown" Enabled="false" runat="server" CssClass="textbox" Width="350px"></asp:DropDownList>
                    <br />
                    <br />

                    <asp:Label ID="Label4" CssClass="label" runat="server" Text="Product ID:" Width="160px"></asp:Label>
                    <asp:DropDownList ID="productNameDropDown" runat="server" AutoPostBack="true" CssClass="textbox" Width="350px" OnSelectedIndexChanged="productIndexChanged"></asp:DropDownList>
                    <asp:DropDownList ID="productDropDown" Enabled="false" runat="server" CssClass="textbox" Width="350px"></asp:DropDownList>
                    <br />
                    <br />

                    <asp:Label ID="Label5" CssClass="label" runat="server" Text="Stock ID:" Width="160px"></asp:Label>
                    <asp:DropDownList ID="stockDropDown" runat="server" CssClass="textbox" Width="350px"></asp:DropDownList>
                    <br />
                    <br />

                    <asp:Label ID="Label1" CssClass="label" runat="server" Text="Transactions ID:" Width="160px"></asp:Label>
                    <asp:DropDownList ID="transactionDropDown" runat="server" CssClass="textbox" Width="350px"></asp:DropDownList>
                    <br />
                    <br />

                    <asp:Button ID="insertBtn" runat="server" CssClass="btn-insert" Text="Insert" OnClick="insertBtnClicked" Width="160px" />

                    <asp:Button ID="updateBtn" runat="server" CssClass="btn-update" Text="Update" OnClick="updateBtnClicked" Width="160px" />

                    <asp:Button ID="cancelBtn" runat="server" CssClass="btn-cancel" Text="Cancel " OnClick="cancelBtnClicked" Width="160px" />

                    <asp:Label ID="qtyCheck" CssClass="label" runat="server" Width="160px"></asp:Label>
                    <asp:Label ID="Label6" CssClass="label" runat="server" Width="160px"></asp:Label>

                    <br />
                    <br />

                    <legend><span class="number">3 </span>Customer Sales List </legend>
                    <div class="table">
                        <asp:GridView ID="GridView1" CssClass="table-style" runat="server">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" CssClass="btn-update" CausesValidation="false" OnClick="editBtnClicked" Text="Edit" />
                                        <asp:Button ID="btnDelete" runat="server" CssClass="btn-delete" CausesValidation="false" OnClick="deleteBtnClicked" Text="Delete" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridView2" runat="server" visible="false">

                        </asp:GridView>
                    </div>
                    </div>
            </fieldset>
        </form>
    </body>
    </html>

</asp:Content>
