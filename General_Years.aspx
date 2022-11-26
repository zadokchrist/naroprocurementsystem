<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="General_Years1.aspx.cs" Inherits="General_Years"
Title="FINANCIAL YEARS" Culture="auto" 
UICulture="auto" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
 <%@ Import Namespace="System.Threading" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0"></div>
                <div class="col-sm-6 mb-3 mb-sm-0">
                    <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">View Financial Years</h6>
                </div>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0">

                </div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <label>.</label>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" class="btn btn-primary btn-user btn-block float-right" Text="Add Financial Years" />
                </div>
            </div>
            <div  class="card-body">
                <asp:GridView ID="GridData" runat="server" AllowPaging="True" class="table table-bordered table-responsive"
                    DataKeyNames="Code" EmptyDataText="NO ITEM(S) FOUND" HorizontalAlign="Center" 
                        PageSize="11" OnRowCommand="GridData_RowCommand" BorderStyle="Solid" OnPageIndexChanging="GridData_PageIndexChanging">
                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="gridRowStyle" />
                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                    <Columns >
                        <asp:ButtonField CommandName="btnEdit" Text="Edit Item" ControlStyle-CssClass="btn btn-primary btn-user btn-block">
                            <HeaderStyle CssClass="gridEditField" />
                            <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"/>
                        </asp:ButtonField>
                    </Columns>
                    <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                    <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                    <PagerStyle HorizontalAlign="Center" />
                </asp:GridView>
            </div>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <formview>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        Add Financial Years
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"><label>Start Date</label></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtStartDate" runat="server" class="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"><label>End Date</label></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtEndDate" runat="server" class="form-control" MaxLength="1"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"><label>Active/De-active</label></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="True" Text="Active" CssClass="form-check" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Button ID="Button2" runat="server" Text="OK" class="btn btn-primary btn-user btn-block" OnClick="Button2_Click" />
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Button ID="Button3" runat="server" Text="Return" class="btn btn-primary btn-user btn-block" OnClick="btnCancel_Click" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Label ID="Label1" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblCenterID" runat="server" Text="0" Visible="False"></asp:Label>
                    </div>
                </div>
            </formview>
        </asp:View>
    </asp:MultiView>
    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
        Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtStartDate">
    </ajaxToolkit:CalendarExtender>
    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
        Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtEndDate">
    </ajaxToolkit:CalendarExtender>
</asp:Content>






