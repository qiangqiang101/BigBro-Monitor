<%@ Page Title="Login" Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>Admin - Login</title>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />

    <!-- Custom styles for this template-->
    <link href="css/sb-admin-2.min.css" rel="stylesheet" />
    <link href="https://lipis.github.io/bootstrap-sweetalert/dist/sweetalert.css" rel="stylesheet" />
    <script src="https://lipis.github.io/bootstrap-sweetalert/dist/sweetalert.js"></script>
</head>
<body class="bg-gradient-primary">
    <form class="user" id="form1" runat="server">
        <div class="container">

            <!-- Outer Row -->
            <div class="row justify-content-center">

                <div class="col-xl-10 col-lg-12 col-md-9">

                    <div class="card o-hidden border-0 shadow-lg my-5">
                        <div class="card-body p-0">
                            <!-- Nested Row within Card Body -->
                            <div class="row">
                                <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                                <div class="col-lg-6">
                                    <div class="p-5">
                                        <div class="text-center">
                                            <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox class="form-control form-control-user" ID="txtUserID" runat="server" aria-describedby="emailHelp" placeholder="User Name" required="Required"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox type="password" class="form-control form-control-user" ID="txtPassword" runat="server" placeholder="Password" TextMode="Password" required="Required"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <div class="custom-control custom-checkbox small">
                                                <asp:CheckBox class="form-check-input" ID="cbRemember" runat="server" Text="&nbsp Remember me" />
                                            </div>
                                        </div>
                                        <asp:Button class="btn btn-primary btn-user btn-block" ID="btnLogin" runat="server" Text="Login" />
                                        <hr>
                                        <div class="text-center">
                                            <a class="small" href="#">Forgot Password?</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Bootstrap core JavaScript-->
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <!-- Core plugin JavaScript-->
        <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

        <!-- Custom scripts for all pages-->
        <script src="js/sb-admin-2.min.js"></script>
    </form>
</body>
</html>
