<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="customer.aspx.cs" Inherits="ApplicationDevelopment.customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
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

                    <legend><span class="number">1</span> Add Customer</legend>

                    <div>

                        <div>
                            <asp:Label ID="Label1" CssClass="label" runat="server" Text="Customer ID:" Width="160px"></asp:Label>
                            <asp:TextBox ID="idBox" CssClass="textbox" runat="server" Width="350px" placeholder="Enter Customer ID*"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="idBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                            <br />
                            <br />

                            <asp:Label ID="Label2" CssClass="label" runat="server" Text="Customer Name:" Width="160px"></asp:Label>
                            <asp:TextBox ID="nameBox" CssClass="textbox" runat="server" Width="350px" placeholder="Enter Customer Name*"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="nameBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                            <br />
                            <br />

                            <asp:Label ID="Label3" CssClass="label" runat="server" Text="Customer Address:" Width="160px"></asp:Label>
                            <asp:TextBox ID="addressBox" CssClass="textbox" runat="server" Width="350px" placeholder="Enter Customer Address*"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="addressBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                            <br />
                            <br />

                            <asp:Label ID="Label4" CssClass="label" runat="server" Text="Customer Contact:" Width="160px"></asp:Label>
                            <asp:TextBox ID="contactBox" CssClass="textbox" runat="server" Width="350px" placeholder="Enter Customer Contact*"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="contactBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                            <br />
                            <br />

                            <asp:Label ID="Label5" CssClass="label" runat="server" Text="Customer Email:" Width="160px"></asp:Label>
                            <asp:TextBox ID="emailBox" CssClass="textbox" runat="server" Width="350px" placeholder="Enter Customer Email*"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="emailBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                            <br />
                            <br />

                            <asp:Label ID="Label6" CssClass="label" runat="server" Text="Added By:" Width="160px"></asp:Label>
                            <asp:DropDownList ID="userDropDown" runat="server" AutoPostBack="true" CssClass="textbox" Width="350px" OnSelectedIndexChanged="userIndexChanged"></asp:DropDownList>
                            <asp:DropDownList ID="userIdDropDown" Enabled="false" runat="server" CssClass="textbox" Width="350px"></asp:DropDownList>
                            <br />
                            <br />

                            <asp:Button ID="insertBtn" runat="server" CssClass="btn-insert" Text="Insert" OnClick="insertBtnClicked" Width="160px" />

                            <asp:Button ID="updateBtn" runat="server" CssClass="btn-update" Text="Update" OnClick="updateBtnClicked" Width="160px" />

                            <asp:Button ID="cancelBtn" runat="server" CssClass="btn-cancel" Text="Cancel " OnClick="cancelBtnClicked" Width="160px" />
                            <br />
                            <br />

                            <asp:Panel ID="Panel1" runat="server" Height="232px">
                                <legend><span class="number">2 </span>Search Customer </legend>
                                <br />
                                <asp:DropDownList ID="searchDropDown" runat="server" CssClass="textbox" Width="170px" AutoPostBack="true" OnSelectedIndexChanged="customerIndexChanged"></asp:DropDownList>
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


                        </div>


                    </div>


                    <legend><span class="number">3 </span>Stock List </legend>
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
                    
                        <br />
                        <br />
                    <div class="table">
                        <legend><span class="number">4 </span>Select Customer to view Purchase Details</legend>
                        <asp:DropDownList ID="customerNameDropDown" runat="server" AutoPostBack="true" CssClass="textbox" Width="200px" OnSelectedIndexChanged="cusIndexChanged"></asp:DropDownList>
                        <asp:DropDownList ID="customerDropDown" Enabled="false" runat="server" CssClass="textbox" Width="150px"></asp:DropDownList>
                        <asp:Button runat="server" CausesValidation="false" CssClass="btn-insert" Text="Show" OnClick="purchaseCust" />
                        <asp:GridView ID="purchaseGrid" CssClass="table-style" runat="server">
                            <Columns>
                            </Columns>
                        </asp:GridView>

                    </div>

                    <div class="table">
                        <legend><span class="number">5 </span>Produce a list of all customers who have not bought any item in the last 31 days</legend>
                        <asp:Button runat="server" CssClass="btn-insert" CausesValidation="false" Text="Display" OnClick="unactiveCustomer" />
                        <asp:GridView ID="GridView2" CssClass="table-style" runat="server">
                            <Columns>
                            </Columns>
                        </asp:GridView>

                    </div>
            </fieldset>

        </form>
    </body>
    </html>
</asp:Content>
