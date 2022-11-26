<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="AddWorkFlow.aspx.cs" Inherits="AddWorkFlow" 
Title="MANAGE ROLES" Culture="auto" UICulture="auto" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
 <%@ Import Namespace="System.Threading" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <link href="content2/plugins/tables/css/datatable/dataTables.bootstrap4.min.css" rel="stylesheet"/>
    <link href="content2/css/style.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card shadow mb-4">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" class="btn btn-primary btn-user btn-block float-right" Text="Add Work Flow" />
                    </div>
                </div>
                <div  class="card-body">
                    <asp:DataGrid ID="DataGrid1" runat="server" DataKeyField="RecordId" AllowPaging="True" OnPageIndexChanged="DataGrid1_PageIndexChanged" AutoGenerateColumns="False" class="table table-striped table-bordered zero-configuration" OnItemCommand="DataGrid2_ItemCommand" HorizontalAlign="Center">
                        <PagerStyle Mode="NumericPages" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#999999" />
                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                <Columns>
                    <asp:BoundColumn DataField="RecordId" HeaderText="RecordId" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn DataField="WorkFlowName" HeaderText="WorkFlowName"></asp:BoundColumn>
                    <asp:BoundColumn DataField="DateCreated" HeaderText="DateCreated"></asp:BoundColumn>
                    <asp:ButtonColumn CommandName="btnEdit" HeaderText="Action" Text="Edit"></asp:ButtonColumn>
                </Columns>
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            </asp:DataGrid>
                </div>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <formview>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0"></div>
                        <div class="col-sm-6 mb-3 mb-sm-0">
                            <div class="card-header py-3">
                                Edit WorkFlow
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0"><asp:Label ID="workflowid" runat="server" Visible="false"></asp:Label></div>
                        <div class="col-sm-3 mb-3 mb-sm-0"><label>Workflow Name</label></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:TextBox ID="txtCcCode"  runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0"></div>
                        <div class="col-sm-3 mb-3 mb-sm-0"><label>Active/De-active</label></div>
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
                                Add WorkFlow
                            </div>
                        </div>
                    </div>
                    <div class="form-group  row">
                        <div class="col-sm-1 mb-3 mb-sm-0"></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <label>WorkFlow Name</label>
                        </div>
                        <div class="col-sm-5 mb-3 mb-sm-0">
                            <asp:TextBox ID="txtAName" runat="server" class="form-control"></asp:TextBox>
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
                            <asp:Button ID="Button2" runat="server" Text="OK" OnClick="Button2_Click1" class="btn btn-primary btn-user btn-block" />
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


