<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_AssignedPRs.aspx.cs" Inherits="Requisition_AssignedPRs" Title="VIEW ASSIGNED PROCUREMENT REQUISITIONS" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                    VIEW ASSIGNED PROCUREMENT REQUISITIONS
                </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>START DATE</label>
                <asp:TextBox ID="txtStartDate" runat="server" cssclass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>END DATE</label>
                <asp:TextBox ID="txtEndDate" runat="server" cssclass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>AREA</label>
                <asp:DropDownList ID="cboAreas" runat="server" AutoPostBack="True" CssClass="form-control"
                    OnDataBound="cboAreas_DataBound">
                </asp:DropDownList>
            </div>
             <div class="col-sm-3 mb-3 mb-sm-0">
                <label>PROC. OFFICERS</label>
                 <asp:DropDownList ID="cboProcOfficers" runat="server" AutoPostBack="True" CssClass="form-control"
                     OnDataBound="cboProcOfficers_DataBound">
                 </asp:DropDownList>
             </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>.</label>
                 <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" class="btn btn-primary btn-user btn-block float-right"
                                Text="Preview" />
             </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-2 mb-3 mb-sm-0">
                <asp:Button ID="btnExportToExcel" runat="server" OnClick="btnExportToExcel_Click" class="btn btn-primary btn-user btn-block float-right"
                    Text="Export To Excel" />
            </div>
            <div class="col-sm-1 mb-3 mb-sm-0">
                <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" class="btn btn-primary btn-user btn-block float-right"
                    Text="Print Report" />
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-12 mb-3 mb-sm-0" id="preview">

            </div>
        </div>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtStartDate"></cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtEndDate"></cc1:CalendarExtender>
    </div>
</asp:Content>

