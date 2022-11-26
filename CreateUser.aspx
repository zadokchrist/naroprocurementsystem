<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" EnableEventValidation="false"  AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" 
Inherits="CreateUser" 
Title="NEW SYSTEM USER" Culture="auto" UICulture="auto" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
 <%@ Import Namespace="System.Threading" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                    SYSTEM USER DETAILS
                </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                First Name
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
               <asp:TextBox ID="TxtFname" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-1 mb-3 mb-sm-0">
                Middle Name
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
               <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                Last Name
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
               <asp:TextBox ID="txtLname" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-1 mb-3 mb-sm-0">
                Access Level
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:DropDownList ID="cboAccessLevel" runat="server" AutoPostBack="True" OnDataBound="cboAccessLevel_DataBound" OnSelectedIndexChanged="cboAccessLevel_SelectedIndexChanged" CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                Email
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
               <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-1 mb-3 mb-sm-0">
                Access Level
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:CheckBox ID="chkIsPDUMember" runat="server" AutoPostBack="True" OnCheckedChanged="chkIsPDUMember_CheckedChanged"
                                                    Text="Is PDU Member" /><br />
                                                <asp:CheckBox ID="chkIsPDUSupervisor" runat="server" Text="Is Procurement Supervisor" Visible="False" />
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                Phone
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
               <asp:TextBox ID="txtphone" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-1 mb-3 mb-sm-0">
                Title / Designation
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtDesignation" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                Upload Signature
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
               <asp:FileUpload ID="imgUpload" runat="server" CssClass="form-control-file" />
                <p>Upload an image (.jpg) of max size: 20Kb</p>
                <asp:Button ID="btnUpload" Text="Preview Signature" runat="server" OnClick="UploadFile" />
            </div>
            <div class="col-sm-1 mb-3 mb-sm-0">
                Uploaded Signature
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:Image ID="Image1" runat="server" Height="50px" Style="width: 200px" />
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                System Modules
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-9 mb-3 mb-sm-0">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-row">
                            <asp:CheckBoxList ID="chkModule" runat="server" CssClass="form-check"  Enabled="False" Font-Bold="True">
                                <asp:ListItem Value="2">Planning Module</asp:ListItem>
                                <asp:ListItem Value="3">Requisition Module</asp:ListItem>
                                <asp:ListItem Value="4">Bidding and Evaluation Module</asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:Button ID="btnOK" runat="server" Text="SAVE USER" Font-Bold="True" OnClick="btnOK_Click" class="btn btn-primary btn-user btn-block float-right"/>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-4 mb-3 mb-sm-0"></div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:Label ID="lblCode" runat="server" Text="0" Visible="False"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

