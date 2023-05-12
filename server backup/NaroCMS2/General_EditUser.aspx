<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="General_EditUser.aspx.cs" Inherits="General_EditUser" Title="EDIT USERS" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
 <%@ Import Namespace="System.Threading" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-group row">
        <div class="col-sm-6 mb-3 mb-sm-0">
            <label> EDIT SYSTEM USER</label>
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-6 mb-3 mb-sm-0">
            <label>First Name</label>
            <asp:TextBox ID="TxtFname" runat="server" class="form-control form-control-user"></asp:TextBox>
        </div>
        <div class="col-sm-6 mb-3 mb-sm-0">
            <label>Middle Name</label>
            <asp:TextBox ID="txtMiddleName" runat="server" class="form-control form-control-user"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-6 mb-3 mb-sm-0">
            <label>Last Name</label>
            <asp:TextBox ID="txtLname" runat="server" class="form-control form-control-user"></asp:TextBox>
        </div>
        <div class="col-sm-6 mb-3 mb-sm-0">
            <label>UserName</label>
            <asp:TextBox ID="txtUsername" runat="server" class="form-control form-control-user" ></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-6 mb-3 mb-sm-0">
            <label>Email</label>
            <asp:TextBox ID="txtemail" runat="server" class="form-control form-control-user"></asp:TextBox>
        </div>
        <div class="col-sm mb-3 mb-sm-0">
            <label>Phone</label>
            <asp:TextBox ID="txtphone" runat="server" class="form-control form-control-user"></asp:TextBox>
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-6 mb-3 mb-sm-0">
            <label>Title/Designation</label>
            <asp:TextBox ID="txtDesignation" runat="server" class="form-control form-control-user" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="col-sm-6 mb-3 mb-sm-0">
            <label>Upload Signature</label>
            <asp:FileUpload ID="imgUpload" class="form-control form-control-user" runat="server"/>
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-6 mb-3 mb-sm-0">
            <asp:CheckBox ID="chkIsInventoryStaff" runat="server" Text="Is Inventory Staff" /><br />
            <asp:CheckBox ID="chkIsPDUMember" runat="server" AutoPostBack="True" OnCheckedChanged="chkIsPDUMember_CheckedChanged" Text="Is PDU Member" /><br />
            <asp:CheckBox ID="chkIsPDUSupervisor" runat="server" Text="Is Procurement Supervisor" Visible="False" />
        </div>
        <div class="col-sm-6 mb-3 mb-sm-0">
            <label>Uploaded Signature</label>
            <asp:Image ID="Image1" class="form-control form-control-user" runat="server" />
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-6 mb-3 mb-sm-0">
            <label>Company</label>
            <asp:DropDownList ID="cboAreas" class="form-control form-control-user" runat="server" AutoPostBack="True" OnDataBound="cboAreas_DataBound" OnSelectedIndexChanged="cboAreas_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="col-sm-6 mb-3 mb-sm-0">
            <label>Cost Center</label>
            <asp:DropDownList ID="cboCostCenter" runat="server" class="form-control form-control-user" OnDataBound="cboCostCenter_DataBound"></asp:DropDownList>
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-6 mb-3 mb-sm-0">
            <label>Access Level</label>
            <asp:DropDownList ID="cboAccessLevel" runat="server" class="form-control form-control-user" AutoPostBack="True" OnDataBound="cboAccessLevel_DataBound" OnSelectedIndexChanged="cboAccessLevel_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="col-sm-6 mb-3 mb-sm-0">
            <label>Reset Password</label>
            <asp:CheckBox ID="CheckBox1" class="form-control" runat="server" Font-Bold="True" Text="Yes" />
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-6 mb-3 mb-sm-0">
            <label style="color:Red">Remove Account</label>
            <asp:CheckBox ID="CheckBox2" runat="server" class="form-control form-control-user" ForeColor="Red" Font-Bold="True" Text="Yes" />
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-6 mb-3 mb-sm-0">
            <label>System Modules</label>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <div class="form-group row">
                        <div class="col-sm-6 mb-3 mb-sm-0">
                            <asp:GridView ID="GridData" runat="server" CssClass="gridgeneralstyle" DataKeyNames="Code" EmptyDataText="NO MODULE(S) FOUND" HorizontalAlign="Center" OnRowCommand="GridData_RowCommand" PageSize="4">
                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                <RowStyle CssClass="gridRowStyle" />
                                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:ButtonField CommandName="btnRemove" Text="Remove">
                                        <HeaderStyle CssClass="gridEditField" />
                                        <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"/>
                                    </asp:ButtonField>
                                </Columns>
                                <HeaderStyle CssClass="gridHeaderStyle" Font-Bold="True" HorizontalAlign="Left" />
                                <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                            </asp:GridView>
                        </div>
                        <div class="col-sm-6 mb-3 mb-sm-0">
                            <asp:Button ID="btnAdd" runat="server" Text="Add" class="btn btn-primary btn-user btn-block" OnClick="btnAdd_Click" />
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="form-group row">
                        <div class="col-sm-6 mb-3 mb-sm-0">
                            <asp:CheckBoxList ID="chkModule" runat="server" CssClass="InterfaceDropdownList" Enabled="False" Font-Bold="True" AutoPostBack="True" OnSelectedIndexChanged="chkModule_SelectedIndexChanged">
                                <asp:ListItem Value="2">Planning Module</asp:ListItem>
                                <asp:ListItem Value="3">Requisition Module</asp:ListItem>
                                <asp:ListItem Value="4">Bidding and Evaluation Module</asp:ListItem>
                            </asp:CheckBoxList>
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red" Text="User has All Active Module"></asp:Label>
                            <asp:Button ID="Button1" runat="server" Text="Return" OnClick="Button1_Click" />
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-6 mb-3 mb-sm-0">
            <asp:Button ID="btnOK" runat="server"   Text="SAVE USER" OnClick="btnOK_Click" />
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-6 mb-3 mb-sm-0">
            <asp:Label ID="lblCode" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text="0" Visible="False"></asp:Label><br />
                        <asp:Label ID="lblUsername" runat="server" Text="0" Visible="False"></asp:Label>
        </div>
    </div>

</asp:Content>



