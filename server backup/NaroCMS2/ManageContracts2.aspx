<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="ManageContracts2.aspx.cs" Inherits="AddWorkFlow" 
Title="MANAGE ROLES" Culture="auto" UICulture="auto" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
 <%@ Import Namespace="System.Threading" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <link href="content2/plugins/tables/css/datatable/dataTables.bootstrap4.min.css" rel="stylesheet"/>
    <link href="content2/css/style.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card shadow mb-4">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                    </div>
                </div>
                <div class="card-body">
                    <asp:GridView ID="GridWorkFLow" runat="server" AllowPaging="True" AutoGenerateColumns="False"  class="table table-striped table-bordered zero-configuration"
                        DataKeyNames="ContractId" EmptyDataText="NO CONTRACT UPLOADED" HorizontalAlign="Center"
                        PageSize="5" OnRowCommand="GridWorkFlow_RowCommand" BorderStyle="Solid" OnPageIndexChanging="GridCCenter_PageIndexChanging">
                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                        <RowStyle CssClass="gridRowStyle" />
                        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                        <Columns>
                            <asp:ButtonField CommandName="btnEdit" Text="Edit Item" ControlStyle-CssClass="btn btn-primary btn-user btn-block">
                                <HeaderStyle CssClass="gridEditField" />
                                <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center" />
                            </asp:ButtonField>
                             <asp:BoundField DataField="RecordID" HeaderText="RecordID" Visible="False" />
                            <asp:BoundField DataField="Subject" HeaderText="Subject"></asp:BoundField>
                            <asp:BoundField DataField="ContractName" HeaderText="Contract Name"></asp:BoundField>
                            <asp:BoundField DataField="ContractType" HeaderText="Type"></asp:BoundField>
                            <asp:BoundField DataField="StatusName" HeaderText="Status"></asp:BoundField>
                            <asp:BoundField DataField="DateCreated" HeaderText="Date Created"></asp:BoundField>
                          <%--  <asp:BoundField DataField="DateCreated" HeaderText="Date" DataFormatString="{0:dd MMM yyyy}"></asp:BoundField>
                            <asp:BoundField CommandName="btnFiles" HeaderText="FILES" Text="View/Add"></asp:BoundField>
                            <asp:BoundField CommandName="btnAction" HeaderText="Action" Text="Approve/Reject"></asp:BoundField>--%>
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
                        <div class="col-sm-3 mb-3 mb-sm-0"></div>
                        <div class="col-sm-6 mb-3 mb-sm-0">
                            <div class="card-header py-3">
                                Edit Contract
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:Label ID="workflowid" runat="server" Visible="false"></asp:Label></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <label>Contract Name</label></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:TextBox ID="txtCcCode" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <label>Contract Type</label></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:TextBox ID="tracttype" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group  row">
                        <div class="col-sm-1 mb-3 mb-sm-0"></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <label>WorkFlow</label>
                        </div>
                        <div class="col-sm-5 mb-3 mb-sm-0">
                            <asp:DropDownList ID="workflowedit" runat="server" DataValueField="RecordId" DataTextField="WorkFlowName" CssClass="form-control" OnDataBound="workflow_DataBound"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0"></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <label>Active/De-active</label></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:CheckBox ID="CheckBox1" runat="server" class="form-control" Text="Active" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0"></div>
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
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0"></div>
                        <div class="col-sm-6 mb-3 mb-sm-0">
                            <div class="card-header py-3">
                                Add Contract
                            </div>
                        </div>
                    </div>
                    <div class="form-group  row">
                        <div class="col-sm-1 mb-3 mb-sm-0"></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <label>Contract Name</label>
                        </div>
                        <div class="col-sm-5 mb-3 mb-sm-0">
                            <asp:TextBox ID="txtAName" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group  row">
                        <div class="col-sm-1 mb-3 mb-sm-0"></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <label>Contract Type</label>
                        </div>
                        <div class="col-sm-5 mb-3 mb-sm-0">
                            <asp:TextBox ID="contracttype" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group  row">
                        <div class="col-sm-1 mb-3 mb-sm-0"></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <label>WorkFlow</label>
                        </div>
                        <div class="col-sm-5 mb-3 mb-sm-0">
                            <asp:DropDownList ID="workflowname" runat="server" DataValueField="RecordId" DataTextField="WorkFlowName" CssClass="form-control" OnDataBound="workflow_DataBound"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-1 mb-3 mb-sm-0"></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <label>Active/De-active</label>
                        </div>
                        <div class="col-sm-5 mb-3 mb-sm-0">
                            <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="True" class="form-control" Text="Active" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-1 mb-3 mb-sm-0"></div>
                        <div class="col-sm-4 mb-3 mb-sm-0">
                            <asp:Button ID="Button2" runat="server" Text="Save Contract" OnClick="Button2_Click1" class="btn btn-primary btn-user btn-block" />
                        </div>
                        <div class="col-sm-4 mb-3 mb-sm-0">
                            <asp:Button ID="Button3" runat="server" Text="Return" OnClick="btnCancel_Click" class="btn btn-primary btn-user btn-block" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-1 mb-3 mb-sm-0"></div>
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
    <!--**********************************
        Scripts
    ***********************************-->
    <script src="content2/plugins/common/common.min.js"></script>
    <script src="content2/js/custom.min.js"></script>
    <script src="content2/js/settings.js"></script>
    <script src="content2/js/gleek.js"></script>
    <script src="content2/js/styleSwitcher.js"></script>

    <script src="content2/plugins/tables/js/jquery.dataTables.min.js"></script>
    <script src="content2/plugins/tables/js/datatable/dataTables.bootstrap4.min.js"></script>
    <script src="./plugins/tables/js/datatable-init/datatable-basic.min.js"></script>
</asp:Content>


