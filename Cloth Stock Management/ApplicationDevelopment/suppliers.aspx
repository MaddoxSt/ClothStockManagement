<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="suppliers.aspx.cs" Inherits="ApplicationDevelopment.suppliers" %>

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

                    <legend><span class="number">1</span> Add Suppliers</legend>


                    <asp:Label ID="Label1" CssClass="label" runat="server" Text="Supplier ID:" Width="160px"></asp:Label>
                    <asp:TextBox ID="txtSupplierId" runat="server" CssClass="textbox" Width="350px" placeholder="Enter Supplier ID*"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtSupplierId" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                    <br />
                    <br />

                    <asp:Label ID="Label2" CssClass="label" runat="server" Text="Company Name:" Width="160px"></asp:Label>
                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="textbox" Width="350px" placeholder="Enter Company Name*"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtCompanyName" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                    <br />
                    <br />

                    <asp:Label ID="Label3" CssClass="label" runat="server" Text="Address:" Width="160px"></asp:Label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="textbox" Width="350px" placeholder="Enter Address*"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtAddress" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                    <br />
                    <br />

                    <asp:Label ID="Label4" CssClass="label" runat="server" Text="Contact Number:" Width="160px"></asp:Label>
                    <asp:TextBox ID="txtContactNumber" CssClass="textbox" runat="server" Width="350px" placeholder="Enter Contact Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtContactNumber" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                    <br />
                    <br />

                    <asp:Label ID="Label5" CssClass="label" runat="server" Text="Email:" Width="160px"></asp:Label>
                    <asp:TextBox ID="txtEmail" CssClass="textbox" runat="server" Width="350px" placeholder="Enter Email*"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtEmail" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                    <br />
                    <br />

                    <asp:Label ID="Label6" CssClass="label" runat="server" Text="Contact Person:" Width="160px"></asp:Label>
                    <asp:TextBox ID="txtContactPerson" CssClass="textbox" runat="server" Width="350px" placeholder="Enter Contact Person*"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtContactPerson" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>

                    <br />
                    <br />

                    <asp:Label ID="Label7" CssClass="label" runat="server" Text="Added By:" Width="160px"></asp:Label>
                    <asp:DropDownList ID="userDropDown" runat="server" CssClass="textbox" AutoPostBack="true" OnSelectedIndexChanged="userIndexChanged" Width="350px" /><asp:DropDownList ID="userIdDropDown" Enabled="false" runat="server" CssClass="textbox" Width="350px" />
                    <br />
                    <br />

                    <asp:Button ID="insertBtn" runat="server" CssClass="btn-insert" Text="Insert" OnClick="insertBtnClicked" Width="160px" />

                    <asp:Button ID="updateBtn" runat="server" CssClass="btn-update" Text="Update" OnClick="updateBtnClicked" Width="160px" />

                    <asp:Button ID="cancelBtn" runat="server" CssClass="btn-cancel" Text="Cancel " OnClick="cancelBtnClicked" Width="160px" />

                    <br />
                    <br />

                    <legend><span class="number">2 </span>Supplier List </legend>
                    <div class="table">
                        <asp:GridView ID="GridView1" CssClass="table-style" runat="server">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" CssClass="btn-insert" runat="server" CausesValidation="false" OnClick="editBtnClicked" Text="Edit" />
                                        <asp:Button ID="btnDelete" runat="server" CssClass="btn-insert" CausesValidation="false" OnClick="deleteBtnClicked" Text="Delete" />
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
