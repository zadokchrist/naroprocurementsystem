<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="General_CostCenter.aspx.cs" 
Inherits="CostCenter" Title="Cost Center" Culture="auto" UICulture="auto" %>
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
                                <h6 class="m-0 font-weight-bold text-primary">List of Cost Centers</h6>
                            </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0">

                            </div>
                            <div class="col-sm-4 mb-3 mb-sm-0">
                                <label>Area</label>
                                <asp:DropDownList ID="cboAreas" runat="server" class="form-control" OnDataBound="cboAreas_DataBound" AutoPostBack="True" OnSelectedIndexChanged="cboAreas_SelectedIndexChanged">
                                        </asp:DropDownList>
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <label>.</label>
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" class="btn btn-primary btn-user btn-block float-right" Text="Add Cost Center" />
                            </div>
                        </div>
                        <div  class="card-body">
                            <asp:GridView ID="GridCCenter" runat="server" AllowPaging="True" class="table table-bordered table-responsive"
                                DataKeyNames="CostCenterID" EmptyDataText="NO COST CENTER FOUND" HorizontalAlign="Center" 
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
                                        Edit Cost Center
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0"><label>Area</label></div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <asp:DropDownList ID="cboCompany" runat="server" class="form-control" OnDataBound="cboCompany_DataBound" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0"><label>Cost Center Code</label></div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txtCcCode" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0"><label>Cost Center</label></div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txtCCenter" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0"><label>Cost Center Initial</label></div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txtCCIntial" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0"><label>Tick If Appropriate<</label></div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        
                                        <asp:CheckBox ID="CheckBox4" runat="server" class="form-control" Text="Is Multi Cost Center" />
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0"><label>Active/De-active</label></div>
                                    <div class="col-sm-3 mb-3 mb-sm-0">
                                        <asp:CheckBox ID="CheckBox1" runat="server" class="form-control" Text="Active" />
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
                                        <asp:Label ID="lblcode" runat="server" Text="0" Visible="False" Width="46px"></asp:Label>
                                        <asp:Label ID="lblCcCode" runat="server" Text="0" Width="156px" Visible="False"></asp:Label>
                                        <asp:Label ID="lblInitials" runat="server" Text="x" Width="144px" Visible="False"></asp:Label>
                                    </div>
                                </div>
                        </formview>
                            </asp:View>
                    <asp:View ID="View3" runat="server">
                        <formview>
                            <div class="form-group row center">
                                <label>Add Cost Center</label>
                            </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"><label>Area Category</label></div>
                            <div class="col-sm-4 mb-3 mb-sm-0">
                                <asp:DropDownList ID="cboCategory" runat="server" class="form-control"  OnDataBound="cboCategory_DataBound" AutoPostBack="True" OnSelectedIndexChanged="cboCategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"><label>Area</label></div>
                            <div class="col-sm-4 mb-3 mb-sm-0">                                
                                <asp:DropDownList ID="cboCompany2" runat="server" CssClass="form-control"
                                            OnDataBound="cboCompany2_DataBound" AutoPostBack="True">
                                    </asp:DropDownList>
                            </div>
                        </div>
                            <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0"><label>Cost Center Name</label></div>
                                    <div class="col-sm-4 mb-3 mb-sm-0">
                                        
                                        <asp:TextBox ID="cboCostCenterNames" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0"><label>Cost Center Code</label></div>
                                    <div class="col-sm-4 mb-3 mb-sm-0">                                        
                                        <asp:TextBox ID="txtCode" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0"><label>Cost Center Initial</label></div>
                                    <div class="col-sm-4 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txtInitial" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0"><label>Tick If Appropriate</label></div>
                                    <div class="col-sm-4 mb-3 mb-sm-0">                                        
                                        <asp:CheckBox ID="CheckBox3" runat="server" CssClass="form-control" Font-Bold="True" Text="Is Multi Cost Center" />
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-sm-3 mb-3 mb-sm-0"><label>Active/De-active</label></div>
                                    <div class="col-sm-4 mb-3 mb-sm-0">
                                        <asp:CheckBox ID="CheckBox2" runat="server" CssClass="form-control" Font-Bold="True" Text="Active" />
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


