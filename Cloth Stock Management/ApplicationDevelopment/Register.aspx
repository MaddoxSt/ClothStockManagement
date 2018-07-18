<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ApplicationDevelopment.Register" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Register User</title>
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
                    <span class="login100-form-title p-b-51">Register
                    </span>

                    <div class="wrap-input100 validate-input m-b-16" data-validate="ID is required">
                        <asp:TextBox ID="idBox" runat="server" class="input100" name="username" placeholder="User Id" />
                        <span class="focus-input100"></span>
                    </div>


                    <div class="wrap-input100 validate-input m-b-16" data-validate="Name is required">
                        <asp:TextBox ID="nameBox" runat="server" class="input100" type="text" name="username" placeholder="Name" />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="wrap-input100 validate-input m-b-16" data-validate="Address is required">
                        <asp:TextBox ID="addressBox" runat="server" class="input100" type="text" name="username" placeholder="Address" />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="wrap-input100 validate-input m-b-16" data-validate="Contact Number is required">
                        <asp:TextBox ID="contactBox" runat="server" class="input100" type="text" name="username" placeholder="Contact Number" />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="wrap-input100 validate-input m-b-16" data-validate="Email is required">
                        <asp:TextBox ID="emailBox" runat="server" class="input100" type="email" name="username" placeholder="Email" />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="wrap-input100 validate-input m-b-16" data-validate="Date is required">
                        <asp:TextBox ID="dobBox" runat="server" class="input100" type="date" name="username" placeholder="Date of Birth" />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="wrap-input100 validate-input m-b-16" data-validate="Username is required">
                        <asp:DropDownList ID="userTypeDW" runat="server" class="input100" />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="wrap-input100 validate-input m-b-16" data-validate="Password is required">
                        <asp:TextBox ID="passwordBox" runat="server" class="input100" type="password" name="pass" placeholder="Password" />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="wrap-input100 validate-input m-b-16" data-validate="Re-Password is required">
                        <asp:TextBox ID="rePasswordBox" runat="server" class="input100" type="password" name="pass" placeholder="Re-Type Password" />
                        <asp:CompareValidator ID="comparePassword" runat="server" ControlToValidate="rePasswordBox" ForeColor="Red" ControlToCompare="passwordBox" Text="Password Doesn't Match" ErrorMessage="Password Doesn't Match"></asp:CompareValidator>
                        <span class="focus-input100"></span>
                    </div>

                    <h4 style="font-family: Ubuntu; margin-bottom: 5px;">What is your childhoods name?
                    </h4>
                    <div class="wrap-input100 validate-input m-b-16" data-validate="Answer is required">
                        <asp:TextBox ID="recoveryAnsBox" runat="server" class="input100" type="text" name="username" placeholder="Recovery Answer" />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="flex-sb-m w-full p-t-3 p-b-24">
                    </div>
                    <asp:Label ID="messageBox" runat="server"></asp:Label>
                    <div class="contact100-form-checkbox">
                            <asp:LinkButton ID="back" CausesValidation="false" Text="Back to Login Page" PostBackUrl="~/Login.aspx" runat="server" class="txt1"></asp:LinkButton>
                        </div>
                    <div class="container-login100-form-btn m-t-17">
                        <asp:Button ID="btnRegister" OnClick="btnRegister_Click" runat="server" Text="Register" class="login100-form-btn"></asp:Button>

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

    <script src="Login/js/main.js"></script>

</body>
</html>