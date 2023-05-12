<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <title>NARO CMS</title>
    <!-- Favicon icon -->
    <%--<link rel="icon" type="image/png" sizes="16x16" href="../../assets/images/favicon.png">--%>
    <!-- <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous"> -->
    <link href="content2/css/style.css" rel="stylesheet">
</head>
<body class="h-100">
    <!--*******************
        Preloader start
    ********************-->
    <div id="preloader">
        <div class="loader">
            <svg class="circular" viewBox="25 25 50 50">
                <circle class="path" cx="50" cy="50" r="20" fill="none" stroke-width="3" stroke-miterlimit="10" />
            </svg>
        </div>
    </div>
    <!--*******************
        Preloader end
    ********************-->
    <div class="login-form-bg h-100">
        <div class="container h-100">
            <div class="row justify-content-center h-100">
                <div class="col-xl-6">
                    <div class="form-input-content">
                        <div class="card login-form mb-0">
                            <div class="card-body pt-5">
                                <a class="text-center" href="index.html">
                                    <h4>NARO CMS</h4>
                                </a>

                                <form class="mt-5 mb-5 login-input" runat="server">
                                    <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red" Text="."></asp:Label>
                                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                        <asp:View ID="View2" runat="server">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="username"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" class="form-control" placeholder="password"></asp:TextBox>
                                            </div>
                                            <asp:Button ID="Btnlogin" Text="Login" runat="server" class="btn login-form__btn submit w-100" OnClick="Btnlogin_Click" />
                                        </asp:View>
                                        <asp:View ID="View1" runat="server">
                                            <h3 class="login-head hidden"><i class="fa fa-lg fa-fw fa-user"></i>CHANGE YOUR SYSTEM PASSWORD</h3>
                                            <div class="form-group">
                                                <label class="control-label">Old Password</label>
                                                <asp:TextBox ID="txtOldPassword" runat="server" class="form-control" TextMode="Password" Width="60%"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">New Password</label>
                                                <asp:TextBox ID="txtNewPassword" runat="server" class="form-control" TextMode="Password" Width="60%"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="control-label">Confirm New Password</label>
                                                <asp:TextBox ID="txtConfirmPassword" runat="server" class="form-control" TextMode="Password" Width="60%"></asp:TextBox>
                                            </div>
                                            <div class="form-group btn-container">
                                                <asp:Button ID="BtnSave" runat="server" class="btn btn-primary btn-block" OnClick="BtnSave_Click" Text="Save" />
                                                <asp:Button ID="btnCancel" runat="server" class="btn btn-primary btn-block" OnClick="btnCancel_Click" Text="Cancel" />
                                            </div>
                                            <div class="form-group btn-container">
                                                <asp:Label ID="Label1" runat="server" Text="0" Visible="False"></asp:Label>
                                                <asp:Label ID="Label2" runat="server" Text="0" Visible="False"></asp:Label>
                                            </div>
                                        </asp:View>
                                        <asp:View ID="View3" runat="server">
                                            <h3 class="login-head hidden" style="color: white;">RESET  SYSTEM PASSWORD</h3>
                                            <div class="form-group">
                                                <label class="control-label" style="color: white;">Username</label>
                                                <asp:TextBox ID="TextBox1" runat="server" class="form-control" TextMode="Password"></asp:TextBox>
                                            </div>

                                            <div class="form-group btn-container">
                                                <asp:Button ID="Button1" runat="server" class="btn btn-primary btn-block" Text="RESET" OnClick="Button1_Click" />
                                                <asp:Button ID="Button2" runat="server" class="btn btn-primary btn-block" OnClick="btnCancel_Click" Text="CANCEL" />
                                            </div>
                                            <div class="form-group btn-container">
                                                <asp:Label ID="Label3" runat="server" Text="0" Visible="False"></asp:Label>
                                                <asp:Label ID="Label4" runat="server" Text="0" Visible="False"></asp:Label>
                                            </div>
                                        </asp:View>
                                    </asp:MultiView>
                                </form>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>




    <!--**********************************
        Scripts
    ***********************************-->
    <script src="content2/plugins/common/common.min.js"></script>
    <script src="content2/js/custom.min.js"></script>
    <script src="content2/js/settings.js"></script>
    <script src="content2/js/gleek.js"></script>
    <script src="content2/js/styleSwitcher.js"></script>
</body>
</html>
