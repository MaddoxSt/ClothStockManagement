<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ApplicationDevelopment.Login" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Login V10</title>
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
                    <span class="login100-form-title p-b-51">Login
                    </span>

                    <div class="wrap-input100 validate-input m-b-16" data-validate="Username is required">
                        <asp:TextBox ID="userNameBox" runat="server" class="input100" type="text" name="username" placeholder="Username" />
                        <span class="focus-input100"></span>
                    </div>


                    <div class="wrap-input100 validate-input m-b-16" data-validate="Password is required">
                        <asp:TextBox ID="passwordBox" runat="server" class="input100" type="password" name="pass" placeholder="Password" />
                        <span class="focus-input100"></span>
                    </div>

                    <div class="flex-sb-m w-full p-t-3 p-b-24">
                        <div class="contact100-form-checkbox">
                            <asp:LinkButton ID="signUp" Text="New User? Sign Up!" PostBackUrl="~/Register.aspx" runat="server" class="txt1"></asp:LinkButton>
                        </div>

                        <div>
                            <div>
                                
                            </div>
                        </div>

                        <!--Modal-->
                        <div class="modal fade" id="fP" tabindex="-1">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">Forgot Password</h4>
                                        <button class="close" data-dismiss="modal">&times;</button>
                                    </div>
                                    <div class="modal-body">
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <asp:Label ID="messageBox" runat="server"></asp:Label>
                    <div class="container-login100-form-btn m-t-17">
                        <asp:Button CausesValidation="false" ID="btnLogin" OnClick="btnLogin_Click" runat="server" Text="Login" class="login100-form-btn"></asp:Button>
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