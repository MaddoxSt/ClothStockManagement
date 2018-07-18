<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprivellage.aspx.cs" Inherits="ApplicationDevelopment.userprivellage" %>
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
        <div>
            <asp:Label ID="Label1" CssClass="label" runat="server" Text="User ID:" Width="160px"></asp:Label>
            <asp:TextBox ID="idBox" CssClass="textbox" runat="server" Width="350px"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label2" CssClass="label" runat="server" Text="User Type:" Width="160px"></asp:Label>
            <asp:TextBox ID="typeBox" CssClass="textbox" runat="server" Width="350px"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label3" CssClass="label" runat="server" Text="Password:" Width="160px"></asp:Label>
            <asp:TextBox ID="passwordBox" CssClass="textbox" runat="server" Width="350px"></asp:TextBox>
            <br /><br />

            <asp:Label ID="Label4" CssClass="label" runat="server" Text="Recovery Ans:" Width="160px"></asp:Label>
            <asp:TextBox ID="ansBox" CssClass="textbox" runat="server" Width="350px"></asp:TextBox>
            <br /><br />
            
            <asp:Button ID="insert" runat="server" Text="Insert" OnClick="insertPrivilege" Width="160px"/>
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
