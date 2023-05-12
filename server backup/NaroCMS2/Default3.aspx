<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="_Default" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <!--Made with love by Mutiullah Samim -->
    <!--Bootsrap 4 CDN-->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">

    <!--Fontawesome CDN-->
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">

    <!--Custom styles-->
    <link rel="stylesheet" type="text/css" href="content/css/login-stylesheet.css" />
</head>
<body>
    <div class="header-title">
        <h1 style="font-size:60px;">Welcome to NARO Procurement System!!</h1>

    </div>
    <div class="container">
        <div class="d-flex justify-content-center h-100">
            <div class="card">
                <div class="card-body">
                    <form runat="server">
                        <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="11pt" 
                        ForeColor="Red" Text="."></asp:Label>
                        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                            <asp:View ID="View2" runat="server">
                                <div class="form-group" style="color:red"></div>
                                <div class="input-group form-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-user"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtUsername" runat="server" class="form-control" placeholder="username"></asp:TextBox>
                                </div>
                                <div class="input-group form-group">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-key"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" class="form-control" placeholder="password"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button id="Btnlogin" Text="Login" runat="server" class="btn login_btn" OnClick="Btnlogin_Click"/>
                                </div>
                                <div class="form-group justify-content-center">
                                    <asp:Button id="btnReset" class="btn btn-info btn-block" Text="RESET PASSWORD" runat="server" OnClick="btnReset_Click"/>
                                </div>
                            </asp:View>
                            <asp:View ID="View1" runat="server">
                                <h3 class="login-head hidden"><i class="fa fa-lg fa-fw fa-user"></i>CHANGE YOUR SYSTEM PASSWORD</h3>
                                <div class="form-group">
                                    <label class="control-label">Old Password</label>
                                    <asp:TextBox ID="txtOldPassword" runat="server" CssClass="InterfaceTextboxLongReadOnly"   TextMode="Password" Width="60%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label class="control-label">New Password</label>
                                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="InterfaceTextboxLongReadOnly" TextMode="Password" Width="60%"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label class="control-label"> Confirm New Password</label>
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="InterfaceTextboxLongReadOnly" TextMode="Password" Width="60%"></asp:TextBox>
                                </div>  
                                <div class="form-group btn-container">
                                    <asp:Button ID="BtnSave" runat="server" class="btn btn-primary btn-block" OnClick="BtnSave_Click" Text="Save"  />
                                    <asp:Button ID="btnCancel" runat="server"  class="btn btn-primary btn-block" OnClick="btnCancel_Click" Text="Cancel" />
                                </div>
                                <div class="form-group btn-container">
                                    <asp:Label ID="Label1" runat="server" Text="0" Visible="False"></asp:Label>
                                    <asp:Label ID="Label2" runat="server" Text="0" Visible="False"></asp:Label>     
                                </div>
                            </asp:View>
                             <asp:View ID="View3" runat="server">
                                 <h3 class="login-head hidden" style="color:white;">RESET  SYSTEM PASSWORD</h3>
                                <div class="form-group">
                                    <label class="control-label" style="color:white;">Username</label>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"   TextMode="Password"></asp:TextBox>
                                </div>
               
                                <div class="form-group btn-container">
                                    <asp:Button ID="Button1" runat="server" class="btn btn-primary btn-block" Text="RESET" OnClick="Button1_Click"  />
                                    <asp:Button ID="Button2" runat="server"  class="btn btn-primary btn-block" OnClick="btnCancel_Click" Text="CANCEL" />
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
</body>
</html>

