<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="General_Area.aspx.cs" Inherits="General_Areas" 
Title="MANAGE AREAS" Culture="auto" UICulture="auto" %>
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
                            <h6 class="m-0 font-weight-bold text-primary"> View Areas</h6>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0">

                    </div>
                    <div class="col-sm-4 mb-3 mb-sm-0">
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <label>.</label>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" class="btn btn-primary btn-user btn-block float-right" Text="Add Area" />
                    </div>
                </div>
                <div  class="card-body">
                    <asp:GridView ID="GridCCenter" runat="server" AllowPaging="True" class="table table-bordered table-responsive"
                                DataKeyNames="AreaID" EmptyDataText="NO COST CENTER FOUND" HorizontalAlign="Center" 
                                 PageSize="5" OnRowCommand="GridCCenter_RowCommand" OnRowCreated="GridCCenter_RowCreated" BorderStyle="Solid" OnPageIndexChanging="GridCCenter_PageIndexChanging">
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
            <asp:View ID="View2" runat="server">
                <formview>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            Edit Area
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0"><label>Category</label></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:DropDownList ID="cboCompany" runat="server" class="form-control" AutoPostBack="True">
                                <asp:ListItem Text="LWC Area" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0"><label>Area Name</label></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:TextBox ID="txtCcCode"  runat="server" class="form-control"></asp:TextBox>
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
                        <label>Add Area</label>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0"><label>Area Name</label></div>
                        <div class="col-sm-4 mb-3 mb-sm-0">
                            <asp:TextBox   ID="txtAName" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0"><label>Category</label></div>
                        <div class="col-sm-4 mb-3 mb-sm-0">
                            <asp:DropDownList ID="cboCategory" runat="server" class="form-control" AutoPostBack="True">
                                    <asp:ListItem Text="LWC Area" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0"><label>Active/De-active</label></div>
                        <div class="col-sm-4 mb-3 mb-sm-0">
                            <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="True" class="form-control" Text="Active" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-4 mb-3 mb-sm-0">
                            <asp:Button ID="Button2" runat="server" Text="OK"  OnClick="Button2_Click1" class="btn btn-primary btn-user btn-block"/>
                        </div>
                        <div class="col-sm-4 mb-3 mb-sm-0">
                            <asp:Button ID="Button3" runat="server" Text="Return" OnClick="btnCancel_Click" class="btn btn-primary btn-user btn-block"/>
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


