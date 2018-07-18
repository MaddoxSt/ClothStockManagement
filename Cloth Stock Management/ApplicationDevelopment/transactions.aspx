<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="transactions.aspx.cs" Inherits="ApplicationDevelopment.transactions" %>

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

                    <legend><span class="number">1</span> Create Transaction</legend>

                    <asp:Label ID="Label1" CssClass="label" runat="server" Text="Transaction Id:" Width="160px"></asp:Label>
                    <asp:TextBox ID="idBox" CssClass="textbox" runat="server" Width="350px" placeholder="Enter Transaction ID*"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="idBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                    <br />
                    <br />

                    <asp:Label ID="Label2" CssClass="label" runat="server" Text="Transaction Date:" Width="160px"></asp:Label>
                    <asp:TextBox ID="dateBox" CssClass="textbox" type="Date" runat="server" Width="350px"></asp:TextBox>
                    <br />
                    <br />

                    <asp:Label ID="Label6" CssClass="label" runat="server" Text="Payment Amount:" Width="160px"></asp:Label>
                    <asp:TextBox ID="paymentBox" CssClass="textbox" runat="server" Width="350px" placeholder="Enter Payment Amount*"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="paymentBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <%--<asp:RangeValidator runat="server" ErrorMessage="Negative Values not allowed" ForeColor="Red" ControlToValidate="paymentBox" MinimumValue="1" MaximumValue="100"></asp:RangeValidator>--%>

                    <br />
                    <br />

                    <asp:Label ID="Label3" CssClass="label" runat="server" Text="Quantity:" Width="160px"></asp:Label>
                    <asp:TextBox ID="quantityBox" CssClass="textbox" type="number" runat="server" Width="350px"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="quantityBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                    <%--<asp:RangeValidator runat="server" ErrorMessage="Negative Values not allowed" ForeColor="Red" ControlToValidate="quantityBox" MinimumValue="1" MaximumValue="100"></asp:RangeValidator>--%>

                    <br />
                    <br />

                    <asp:Button ID="insertBtn" runat="server" CssClass="btn-insert" Text="Insert" OnClick="insertBtnClicked" Width="160px" />

                    <asp:Button ID="updateBtn" runat="server" CssClass="btn-update" Text="Update" OnClick="updateBtnClicked" Width="160px" />

                    <asp:Button ID="cancelBtn" runat="server" CssClass="btn-cancel" Text="Cancel " OnClick="cancelBtnClicked" Width="160px" />
                    <br />
                    <br />

                    <legend><span class="number">2 </span>Transaction List </legend>

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
