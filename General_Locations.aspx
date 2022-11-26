<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" 
AutoEventWireup="true" CodeFile="General_Locations.aspx.cs" Inherits="CostCenter" Title="Cost Center" 
Culture="auto" UICulture="auto" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
 <%@ Import Namespace="System.Threading" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card shadow mb-4">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">View Delivery Locations</h6>
                    </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0">

                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <label>.</label>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" class="btn btn-primary btn-user btn-block float-right" Text="Add Delivery Location" />
                    </div>
                </div>
                <div  class="card-body">
                    <asp:GridView ID="GridCCenter" runat="server" AllowPaging="True" class="table table-bordered table-responsive"
                        DataKeyNames="LocationID" EmptyDataText="NO COST CENTER FOUND" HorizontalAlign="Center" 
                            PageSize="20" OnRowCommand="GridCCenter_RowCommand" OnRowCreated="GridCCenter_RowCreated" BorderStyle="Solid" OnPageIndexChanging="GridCCenter_PageIndexChanging">
                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                        <RowStyle CssClass="gridRowStyle" />
                        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                        <Columns >
                            <asp:ButtonField CommandName="btnEdit" Text="Edit Item" ControlStyle-CssClass="btn btn-primary btn-user btn-block">
                                <HeaderStyle CssClass="gridEditField" />
                                <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center" />
                            </asp:ButtonField>
                        </Columns>
                        <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                        <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <formview>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            Edit Delivery Location
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0"><label>Delivery Location Name</label></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:TextBox ID="txtCcCode"  runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:Button ID="btnOK" runat="server" Text="OK" class="btn btn-primary btn-user btn-block" OnClick="btnOK_Click" />
                        </div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:Button ID="btnCancel" runat="server" Text="Return" class="btn btn-primary btn-user btn-block" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:Label ID="lblcode" runat="server" Text="0" Visible="False"></asp:Label>
                            <asp:Label ID="lblCcCode" runat="server" Text="0" Visible="False"></asp:Label>
                            <asp:Label ID="lblInitials" runat="server" Text="x" Visible="False"></asp:Label>
                        </div>
                    </div>
                </formview>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <formview>
                    <div class="form-group row center">
                        <label>Add Delivery Location</label>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0"><label>Delivery Location Name</label></div>
                        <div class="col-sm-4 mb-3 mb-sm-0">
                            <asp:TextBox   ID="txtAName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-4 mb-3 mb-sm-0">
                            <asp:Button ID="Button2" runat="server" class="btn btn-primary btn-user btn-block" Text="OK" OnClick="Button2_Click1" />
                        </div>
                        <div class="col-sm-4 mb-3 mb-sm-0">
                            <asp:Button ID="Button3" runat="server" class="btn btn-primary btn-user btn-block" Text="Return" OnClick="btnCancel_Click" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:Label ID="Label1" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblCenterID" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text="x" Visible="False"></asp:Label>
                        </div>
                    </div>
                </formview>
            </asp:View>
        </asp:MultiView>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:Label ID="lblPlanCode" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>