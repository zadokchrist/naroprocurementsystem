<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeFile="Default_Suppliers.aspx.cs" Inherits="_Default" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="plugins/jquery-datatable/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
    <!-- CSS-->
    <link rel="stylesheet" type="text/css" href="css/main.css"/>
    <!-- Font-icon css-->
    <link rel="stylesheet" type="text/css" href="font-awesome-4.7.0/css/font-awesome.css"/>
    <link href="light-box/lightbox.min.css" rel="stylesheet" type="text/css" media="screen" />
    <link rel="stylesheet" type="text/css" href="alert/jquery-confirm.min.css" />
    <link href="css/jquery.tabFrozenScroll.css" rel="stylesheet"/>
    <link rel="stylesheet" href="css/material-modal.css"/>
    <link rel="stylesheet" href="gis/esri.css"/>
     <link rel="stylesheet" href="gis/tundra.css"/>
    <title>LWC Sourcing Platform</title>
</head>
<body>
     <section class="material-half-bg">
      <div class="cover"></div>
    </section>
<section class="login-content" >
      <div class="logo">
        <h1>LWC Sourcing Platform</h1>
      </div>
      <div class="login-box" style="width:450px">
          <div class="row" id="row" runat="server" visible="false">
          <div class="col-md-12">
            <div class="card">
              <h3 class="card-title red_txt" id="msg" runat="server">Hello</h3>
                </div>
              </div>
        </div>
        <form class="login-form"  runat="server" >
            <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="11pt" 
                        ForeColor="Red" Text="."></asp:Label>
             <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

              <asp:View ID="View2" runat="server">

            
            <div class="left">
          <img class="img-rounded" src="images/logo.png" alt="User Image"
                           height="100" width="95%"/>
                </div>
          <h3 class="login-head hidden"><i class="fa fa-lg fa-fw fa-user"></i>SUPPLIER SIGN IN</h3>
          <div class="form-group">
                   
        <label class="control-label">USERNAME</label>
         <asp:TextBox ID="txtUsername" runat="server" Width="60%"></asp:TextBox>
   
         
          </div>
          <div class="form-group">

           <label class="control-label">PASSWORD
              </label>
           &nbsp;<asp:TextBox ID="txtpassword" runat="server" Width="60%" TextMode="Password"></asp:TextBox>
                                         
             </div>
        
          <div class="form-group btn-container">

            <asp:Button id="Btnlogin" class="btn btn-primary btn-block" Text="SIGN IN" runat="server" OnClick="Btnlogin_Click"><%--<i class="fa fa-sign-in fa-lg fa-fw"></i>SIGN IN--%></asp:Button>
                  <asp:Button ID="BtnSignUp" runat="server" class="btn btn-info btn-block" Text="SIGN UP" OnClick="BtnSignUp_Click"><%--<i class="fa fa-sign-in fa-lg fa-fw"></i>SIGN IN--%></asp:Button>  
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
                   <asp:Button ID="BtnSave" runat="server" class="btn btn-primary btn-block"
                                                                    OnClick="BtnSave_Click" Text="Save"  />
                   
              <asp:Button ID="btnCancel" runat="server"  class="btn btn-primary btn-block"
                                                                    OnClick="btnCancel_Click" Text="Cancel" />
                  </div>
              <div class="form-group btn-container">
                    <asp:Label ID="Label1" runat="server" Text="0" Visible="False"></asp:Label>
                     <asp:Label ID="Label2" runat="server" Text="0" Visible="False"></asp:Label>     
                  </div>                               
            </asp:View>
                 <asp:View ID="View3" runat="server">

                      
            
                <div class="form-group">
                  <label class="control-label">Company Name</label>
                  <asp:TextBox ID="TxtFname" runat="server" CssClass="InterfaceTextboxLongReadOnly" Width="60%"></asp:TextBox>
                   </div>
                
                     <div class="form-group">
                  <label class="control-label">Account Email</label>
                  <asp:TextBox ID="txtemail" runat="server" CssClass="InterfaceTextboxLongReadOnly" Width="60%"></asp:TextBox>
                   </div>

                      <div class="form-group">
                  <label class="control-label">Contact Phone</label>
                  <asp:TextBox ID="txtphone" runat="server" CssClass="InterfaceTextboxLongReadOnly" Width="60%"></asp:TextBox>
                   </div>

                     <div class="form-group">
                  <label class="control-label">Title / Designation</label>
                  <asp:TextBox ID="txtDesignation" runat="server" CssClass="InterfaceTextboxLongReadOnly" Width="60%"></asp:TextBox>
                   </div>
           

                      

            <div class="form-group">
                  <label class="control-label">Company Address</label>
                  <asp:TextBox ID="txtAddress" runat="server" CssClass="InterfaceTextboxLongReadOnly" Width="60%"></asp:TextBox>
                   </div>

                     <div class="form-group">
                  <label class="control-label">PPA Supplier Number</label>
                  <asp:TextBox ID="txtxPPA" runat="server" CssClass="InterfaceTextboxLongReadOnly" Width="60%"></asp:TextBox>
                   </div>

                <div class="form-group btn-container">
               <asp:Button ID="btnOK" runat="server" Text="SIGN UP"  class="btn btn-info btn-block" OnClick="btnOK_Click" />
           </div>
                 </asp:View>                              
          </asp:MultiView>


        </form>



<%--          <form class="login-form" method="post" action="">
         
            <div class="left">
          <img class="img-rounded" src="images/logo.png" alt="User Image"
                           height="100" width="95%"/>
                </div>
          <h3 class="login-head hidden"><i class="fa fa-lg fa-fw fa-user"></i>CHANGE YOUR SYSTEM PASSWORD</h3>
          <div class="form-group">
            <label class="control-label">OLD PASSWORD</label>
            <input class="form-control" id="txtOldPassword" type="text" placeholder="username" autofocus name="email">
          </div>
          <div class="form-group">
            <label class="control-label">NEW PASSWORD</label>
            <input class="form-control" id="txtNewPassword" type="password" placeholder="Password" name="password">
          </div>
            <div class="form-group">
            <label class="control-label">CONFIRM PASSWORD</label>
            <input class="form-control" id="txtConfirmPassword" type="password" placeholder="Password" name="password">
          </div>
      
          <div class="form-group btn-container">

            <button id="BtnSave" class="btn btn-primary btn-block" name="login"><i class="fa fa-sign-in fa-lg fa-fw"></i>SIGN IN</button>
          </div>
        </form>


        <form class="forget-form" action="index.html">
          <h3 class="login-head"><i class="fa fa-lg fa-fw fa-lock"></i>Forgot Password ?</h3>
          <div class="form-group">
            <label class="control-label">EMAIL</label>
            <input class="form-control" type="text" placeholder="Email">
          </div>
          <div class="form-group btn-container">
            <button class="btn btn-primary btn-block"><i class="fa fa-unlock fa-lg fa-fw"></i>RESET</button>
          </div>
          <div class="form-group mt-20">
            <p class="semibold-text mb-0"><a data-toggle="flip"><i class="fa fa-angle-left fa-fw"></i> Back to Login</a></p>
          </div>
        </form>

          --%>


      </div>
    </section>




</body>

</html>
