<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="productSupplier.aspx.cs" Inherits="ApplicationDevelopment.productSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
        .auto-style1 {
            margin-left: 640px;
        }
    </style>
    
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
        <div>
            <asp:Label ID="Label1" CssClass="label" runat="server" Text="Product ID:" Width="160px"></asp:Label>
            <asp:TextBox ID="productIdBox" CssClass="textbox" runat="server" Width="350px"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label2" CssClass="label" runat="server" Text="Supplier ID:" Width="160px"></asp:Label>
            <asp:TextBox ID="supplierIdBox" CssClass="textbox" runat="server" Width="350px"></asp:TextBox>
            <br /><br />

            <asp:Button ID="insert" runat="server" Text="Insert" OnClick="insertProductSupplier" Width="160px"/>
            <br />
        </div>
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <div class="auto-style1">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>

</asp:Content>
