<%@ Page Language="C#" MasterPageFile="~/PlanningGeneric.master" AutoEventWireup="true" CodeFile="Planning_PPDAProcPlans.aspx.cs" Inherits="Planning_PPDAProcPlans" Title="CONSOLIDATED PPDA PROCUREMENT PLAN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
     <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                <asp:Label ID="Label1" runat="server" Text="NON-CONSULTANCY PROCUREMENT PLAN FOR THE FINANCIAL YEAR: "></asp:Label>
            </div>
            </div>
        </div>
         <div class="form-group row">
             <div class="col-sm-2 mb-3 mb-sm-0"></div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>AREA</label>
                <asp:DropDownList ID="cboAreas" runat="server" AutoPostBack="True" OnDataBound="cboAreas_DataBound" CssClass="form-control"
                            OnSelectedIndexChanged="cboAreas_SelectedIndexChanged">
                        </asp:DropDownList>
            </div>
             <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Cost Center</label>
                <asp:DropDownList ID="cboCostCenters" runat="server" CssClass="form-control"
                            OnDataBound="cboCostCenters_DataBound">
                        </asp:DropDownList>
            </div>
             <div class="col-sm-3 mb-3 mb-sm-0">
                <label>FINANCIAL YEAR</label>
                <asp:DropDownList ID="cboFinancialYear" runat="server" CssClass="form-control"
                            OnDataBound="cboFinancialYear_DataBound">
                        </asp:DropDownList>
            </div>
        </div>
         <div class="form-group row">
             <div class="col-sm-3 mb-3 mb-sm-0">
                 <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" class="btn btn-primary btn-user btn-block float-right"
                            Text="Preview"/>
             </div>
             <div class="col-sm-3 mb-3 mb-sm-0">
                 <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" class="btn btn-primary btn-user btn-block float-right"
                            Text="Print Report"/>
             </div>
         </div>
         <div class="form-group row">
             <div class="col-sm-12 mb-3 mb-sm-0">
                 <table align ="center"style="width: 90%; border-right: #617da6 1px solid; border-top: #617da6 1px solid; border-left: #617da6 1px solid; border-bottom: #617da6 1px solid; height: 100px;">
                    <tr>
                        <td style="width: 100%; vertical-align: top; text-align: left;">
                        </td>
                    </tr>
                </table>
             </div>
             
         </div>
     </div>

</asp:Content>



