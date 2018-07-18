<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="ApplicationDevelopment.ChangePassword" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Change Password</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />

    <link rel="stylesheet" type="text/css" href="Login/vendor/bootstrap/css/bootstrap.min.css">

    <link rel="stylesheet" type="text/css" href="Login/fonts/font-awesome-4.7.0/css/font-awesome.min.css">

    <link rel="stylesheet" type="text/css" href="Login/fonts/Linearicons-Free-v1.0.0/icon-font.min.css">

    <link rel="stylesheet" type="text/css" href="Login/vendor/animate/animate.css">

    <link rel="stylesheet" type="text/css" href="Login/vendor/css-hamburgers/hamburgers.min.css">

    <link rel="stylesheet" type="text/css" href="Login/vendor/animsition/css/animsition.min.css">

    <link rel="stylesheet" type="text/css" href="Login/vendor/select2/select2.min.css">

    <link rel="stylesheet" type="text/css" href="Login/vendor/daterangepicker/daterangepicker.css">

    <link rel="stylesheet" type="text/css" href="Login/css/util.css">

    <link rel="stylesheet" type="text/css" href="Login/css/main.css">
</head>
<body>

    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100 p-t-50 p-b-90">
                <form class="login100-form validate-form flex-sb flex-w" runat="server">
                    <span class="login100-form-title p-b-51">Change Password
                    </span>

                    <div class="wrap-input100 validate-input m-b-16" data-validate="Username is required">
                        <asp:TextBox ID="idBox" runat="server" class="input100" type="text" name="username" placeholder="User ID" />
                        <span class="focus-input100"></span>
                    </div>
                    <asp:RequiredFieldValidator ControlToValidate="idBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>



                    <%--<div class="wrap-input100 validate-input m-b-16" data-validate="Password is required">
                        <asp:TextBox ID="oldPasswordBox" runat="server" class="input100" name="pass" placeholder="Old Password" />
                        <span class="focus-input100"></span>
                    </div>
                    <asp:RequiredFieldValidator ControlToValidate="oldPasswordBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>--%>


                    <div class="wrap-input100 validate-input m-b-16" data-validate="Password is required">
                        <asp:TextBox ID="newPasswordBox" runat="server" type="password" class="input100" name="pass" placeholder="New Password" />
                        <span class="focus-input100"></span>
                    </div>
                    <asp:RequiredFieldValidator ControlToValidate="newPasswordBox" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>


                    <asp:Label ID="messageBox" runat="server"></asp:Label>
                           <div class="contact100-form-checkbox">
                            <asp:LinkButton ID="back" CausesValidation="false" Text="Back to Login Page" PostBackUrl="~/Login.aspx" runat="server" class="txt1"></asp:LinkButton>
                        </div>
                    <div class="container-login100-form-btn m-t-17">
                        <asp:Button CausesValidation="true" ID="changePassword"  OnClick="changePassword_Click" runat="server" Text="Change Password" class="login100-form-btn"></asp:Button>
                    </div>
                                     

                </form>
            </div>
        </div>
    </div>


    <div id="dropDownSelect1"></div>


    <script src="Login/vendor/jquery/jquery-3.2.1.min.js"></script>

    <script src="Login/vendor/animsition/js/animsition.min.js"></script>

    <script src="Login/vendor/bootstrap/js/popper.js"></script>
    <script src="Login/vendor/bootstrap/js/bootstrap.min.js"></script>

    <script src="Login/vendor/select2/select2.min.js"></script>

    <script src="Login/vendor/daterangepicker/moment.min.js"></script>
    <script src="Login/vendor/daterangepicker/daterangepicker.js"></script>

    <script src="Login/vendor/countdowntime/countdowntime.js"></script>

    <%--	<script src="Login/js/main.js"></script>--%>
</body>
</html>