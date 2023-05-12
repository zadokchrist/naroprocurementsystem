<%@ Page Language="C#" MasterPageFile="~/Suppliers.master" AutoEventWireup="true" CodeFile="Suppliers_Profile.aspx.cs" Inherits="Supplier_Profile" Title="EDIT USERS" %>

 <%@ Register 
 Assembly="AjaxControlToolkit" 
 Namespace="AjaxControlToolkit" 
 TagPrefix="ajaxToolkit" %>
 <%@ Import
  Namespace="System.Threading" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table>
        <tr>
            <td style="text-align: center; vertical-align: middle">
                            <table >
                                <tr>
                                    <td >
                                       </td>
                                </tr>
                            </table>
            </td>
        </tr>
        
        </table>
            


    <section>       
        <div class="form-control">       
            <form class="Supp-form" runat="server">
                 <h3 class="form-control">SUPPLIER PROFILE</h3>
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
                    <asp:Button ID="btnOK" runat="server" Text="UPDATE PROFILE" class="btn btn-info btn-block" OnClick="btnOK_Click" />
                </div>
            </form>
            </div> 
        </section>

</asp:Content>



