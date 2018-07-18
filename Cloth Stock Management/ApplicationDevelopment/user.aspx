<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="ApplicationDevelopment.user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            
            <legend><span class="number">1</span> Add User</legend>

            <asp:Label ID="Label1" CssClass="label" runat="server" Text="User ID:" Width="160px"></asp:Label>
            <asp:TextBox ID="idBox" CssClass="textbox" runat="server" Width="350px" placeholder ="Enter User ID*"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label2" CssClass="label" runat="server" Text="User Name:" Width="160px"></asp:Label>
            <asp:TextBox ID="nameBox" CssClass="textbox" runat="server" Width="350px" placeholder ="Enter Name*"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label3" CssClass="label" runat="server" Text="User Address:" Width="160px"></asp:Label>
            <asp:TextBox ID="addressBox" CssClass="textbox" runat="server" Width="350px" placeholder ="Enter Address*"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label4" CssClass="label" runat="server" Text="User Contact:" Width="160px"></asp:Label>
            <asp:TextBox ID="contactBox" CssClass="textbox" runat="server" Width="350px" placeholder ="Enter Contact Number*"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label5" CssClass="label" runat="server" Text="User Email:" Width="160px"></asp:Label>
            <asp:TextBox ID="emailBox" CssClass="textbox" runat="server" Width="350px" placeholder ="Enter Email*"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label6" CssClass="label" runat="server" Text="User DOB:" Width="160px"></asp:Label>
            <asp:TextBox ID="dobBox" CssClass="textbox" type="Date" runat="server" Width="350px" ></asp:TextBox>
            <br /><br />

            <asp:Button ID="insertBtn" runat="server" CssClass="btn-insert" Text="Insert" OnClick="insertUser" Width="160px"/>
            <asp:Button ID="updateBtn" runat="server" CssClass="btn-update" Text="Update" OnClick="updateBtn_Click" Width="160px" />
            <asp:Button ID="cancelBtn" runat="server" CssClass="btn-cancel" Text="Cancel " OnClick="cancelBtn_Click"  Width="160px" />
            <br />
            <br />
            
            <legend><span class="number">2 </span> User List </legend>

        <div class="table">
            <asp:GridView ID="GridView1" CssClass="table-style"  runat="server">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" CssClass="btn-update" CausesValidation="false" OnClick="btnEdit_Click" Text="Edit" />
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn-delete" CausesValidation="false" OnClick="btnDelete_Click" Text="Delete" />

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
