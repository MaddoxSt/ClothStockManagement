<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="stock.aspx.cs" Inherits="ApplicationDevelopment.stock" %>

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

                    <legend><span class="number">1</span> Add Stock</legend>

                    <asp:Label ID="Label1" CssClass="label" runat="server" Text="Stock ID:" Width="160px"></asp:Label>
                    <asp:TextBox ID="idBox" CssClass="textbox" runat="server" Width="350px" placeholder="Enter Stock ID:**"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="idBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                    <br />
                    <br />

                    <asp:Label ID="Label2" CssClass="label" runat="server" Text="Quantity:" Width="160px"></asp:Label>
                    <asp:TextBox ID="qtyBox" CssClass="textbox" TextMode="Number" runat="server" Width="350px" placeholder="Enter Quantity*"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="qtyBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <%--<asp:RangeValidator runat="server" ErrorMessage="Negative Values not allowed" ForeColor="Red" ControlToValidate="qtyBox" MinimumValue="1" MaximumValue="100"></asp:RangeValidator>--%>

                    <br />
                    <br />

                    <asp:Label ID="Label5" CssClass="label" runat="server" Text="Date:" Width="160px"></asp:Label>
                    <asp:TextBox ID="stockDateBox" CssClass="textbox" type="date" runat="server" Width="350px" placeholder="Enter Stock Date*"></asp:TextBox>
                    <br />
                    <br />

                    <asp:Label ID="Label6" CssClass="label" runat="server" Text="Stock Added By:" Width="160px"></asp:Label>
                    <asp:DropDownList ID="userDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="userIndexChanged" CssClass="textbox" Width="350px"></asp:DropDownList>
                    <asp:DropDownList ID="userIdDropDown" runat="server" Enabled="false" CssClass="textbox" Width="350px"></asp:DropDownList>
                    <br />
                    <br />

                    <asp:Label ID="Label3" CssClass="label" runat="server" Text="Product Name:" Width="160px"></asp:Label>
                    <asp:DropDownList ID="productDropDown" runat="server" AutoPostBack="true" OnSelectedIndexChanged="productIndexChanged" CssClass="textbox" Width="350px"></asp:DropDownList>
                    <asp:DropDownList ID="productIDDropDown" runat="server" Enabled="false" CssClass="textbox" Width="350px"></asp:DropDownList>
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
                        <asp:DropDownList ID="searchIDDropDown" runat="server" CssClass="textbox" Width="170px" OnSelectedIndexChanged="stockIndexChanged"></asp:DropDownList>
                        <asp:Button ID="SearchBtn" CausesValidation="false" runat="server" CssClass="btn-search" Text="Search " OnClick="searchBtnClicked" Width="160px" /><br />
                        <div class="table-responsive">
                            <asp:GridView ID="searchResult" CssClass="table" runat="server">
                                <Columns>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </asp:Panel>
                    <br />
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

                    <div class="table">
                        <legend><span class="number">4 </span>Display a list of all items in the stock where no item has been sold in the last 31 days.</legend>
                        <asp:Button CausesValidation="false"  CssClass="btn-insert" runat="server" Text="Display" OnClick="displayStock" />
                        <asp:GridView ID="GridView2" CssClass="table-style" runat="server">
                            <Columns>
                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
            </form>
        </fieldset>
    </body>
    </html>

</asp:Content>
