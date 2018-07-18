<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="ApplicationDevelopment.product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

    <html>
    <head>
        <title></title>

    </head>
    <body>
        <form id="form1" runat="server">

            <div class="dropdown">
                <asp:Button runat="server" CausesValidation="false" Text="Accounts" class="btn btn-insert dropdown-toggle" type="button" data-toggle="dropdown" />

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


                    <legend><span class="number">1</span> Add Products</legend>


                    <asp:Label ID="Label1" CssClass="label" runat="server" Text="Product Id:" Width="160px"></asp:Label>
                    <asp:TextBox ID="idBox" CssClass="textbox" runat="server" Width="350px" placeholder="Enter Product ID*"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="idBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                    <br />
                    <br />

                    <asp:Label ID="Label2" CssClass="label" runat="server" Text="Product Name:" Width="160px"></asp:Label>
                    <asp:TextBox ID="nameBox" CssClass="textbox" runat="server" Width="350px" placeholder="Enter Product Name*"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="nameBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                    <br />
                    <br />

                    <asp:Label ID="Label6" CssClass="label" runat="server" Text="Product Description:" Width="160px"></asp:Label>
                    <asp:TextBox ID="descriptionBox" CssClass="textbox" runat="server" Width="350px" placeholder="Enter Product Description*"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="descriptionBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                    <br />
                    <br />

                    <asp:Label ID="Label3" CssClass="label" runat="server" Text="Price:" Width="160px"></asp:Label>
                    <asp:TextBox ID="priceBox" CssClass="textbox" runat="server" Width="350px" placeholder="Enter Product Price*"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="priceBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                    <%--<asp:RangeValidator runat="server" ErrorMessage="Negative Values not allowed" ForeColor="Red" ControlToValidate="priceBox" MinimumValue="1" MaximumValue="1000000"></asp:RangeValidator>--%>

                    <br />
                    <br />

                    <asp:Label ID="Label4" CssClass="label" runat="server" Text="Purchase Date:" Width="160px"></asp:Label>
                    <asp:TextBox ID="purchaseBox" CssClass="textbox" type="date" runat="server" Width="350px"></asp:TextBox>
                    <br />
                    <br />

                    <asp:Label ID="Label5" CssClass="label" runat="server" Text="Category:" Width="160px"></asp:Label>
                    <asp:DropDownList ID="categoryDropDown" runat="server" CssClass="textbox" Width="175px"></asp:DropDownList>
                    <br />
                    <br />

                    <asp:Label ID="Label7" CssClass="label" runat="server" Text="User Name:" Width="160px"></asp:Label>
                    <asp:DropDownList ID="userDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="userIndexChanged" CssClass="textbox" Width="350px"></asp:DropDownList>
                    <asp:DropDownList ID="userIdDropDown" runat="server" Enabled="false" CssClass="textbox" Width="350px"></asp:DropDownList>

                    <br />
                    <br />

                    <asp:Label ID="Label8" CssClass="label" runat="server" Text="Supplier Name:" Width="160px"></asp:Label>
                    <asp:DropDownList ID="supplierNameDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="supplierIndexChanged" CssClass="textbox" Width="350px"></asp:DropDownList>
                    <asp:DropDownList ID="supplierIdDropDown" Enabled="false" runat="server" CssClass="textbox" Width="350px"></asp:DropDownList>
                    <br />
                    <br />

                    <asp:Button ID="insertBtn" runat="server" CssClass="btn-insert" Text="Insert" OnClick="insertBtnClicked" Width="160px" />

                    <asp:Button ID="updateBtn" runat="server" CssClass="btn-update" Text="Update" OnClick="updateBtnClicked" Width="160px" />

                    <asp:Button ID="cancelBtn" runat="server" CssClass="btn-cancel" Text="Cancel " OnClick="cancelBtnClicked" Width="160px" />

                    <br />
                    <br />
                    <asp:Panel ID="Panel1" runat="server" Height="232px">
                        <legend><span class="number">2 </span>Search products </legend>
                        <br />
                        <asp:DropDownList ID="searchDropDown" runat="server" CssClass="textbox" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="productIndexChanged"></asp:DropDownList>
                        <asp:DropDownList ID="searchIDDropDown" Enabled="false" runat="server" CssClass="textbox" Width="170px"></asp:DropDownList>
                        <asp:Button CausesValidation="false" ID="SearchBtn" runat="server" CssClass="btn-search" Text="Search " OnClick="searchBtnClicked" Width="160px" /><br />
                        <div class="table-responsive">
                            <asp:GridView ID="searchResult" CssClass="table" runat="server">
                                <Columns>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </asp:Panel>
                    <br />

                    <legend><span class="number">3 </span>Product List </legend>
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
                    </div>
                </div>
            </fieldset>
        </form>
    </body>
    </html>
</asp:Content>
