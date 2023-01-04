<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="ManageRejectedContracts.aspx.cs" Inherits="ManageRejectedContracts" 
Title="MANAGE ROLES" %>
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


                <div class="card-body">
                    <div class="form-group row">
                        <div class="col-sm-6 mb-3 mb-sm-0"></div>
                        <div class="col-sm-6">
                            <label class="btn btn-primary btn-user float-right">Contract Management</label>
                        </div>
                    </div>
                    <asp:DataGrid ID="DataGrid1" runat="server" DataKeyField="ContractId" AutoGenerateColumns="False" class="table table-striped table-bordered zero-configuration" OnItemCommand="DataGrid2_ItemCommand" HorizontalAlign="Center">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditItemStyle BackColor="#999999" />
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundColumn DataField="ContractId" HeaderText="ContractId" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Workflowid" HeaderText="Worflowid" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ContractName" HeaderText="ContractName"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Subject" HeaderText="Subject"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ContractType" HeaderText="Contract Type"></asp:BoundColumn>
                            <asp:BoundColumn DataField="StatusName" HeaderText="Status"></asp:BoundColumn>
                            <asp:ButtonColumn CommandName="btnFiles" HeaderText="FILES" Text="View">
                                <ItemStyle CssClass=" btn-warning" ForeColor="White"/>
                            </asp:ButtonColumn>
                            <asp:ButtonColumn CommandName="btnStatus" HeaderText="Status" Text="View">
                                <ItemStyle CssClass=" btn-info " ForeColor="White"/>
                            </asp:ButtonColumn>
                            <asp:ButtonColumn CommandName="btnMileStones" HeaderText="Milestones" Text="View">
                                <ItemStyle CssClass="btn-secondary " ForeColor="White"/>
                            </asp:ButtonColumn>
                        </Columns>
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    </asp:DataGrid>

                    <!--Previous gridflor-->
                    <asp:GridView ID="GridWorkFLow" runat="server" AllowPaging="True" class="table table-striped table-bordered zero-configuration"
                        DataKeyNames="ContractId" EmptyDataText="NO UPLOADED CONTRACTS FOUND" HorizontalAlign="Center"
                        PageSize="5" OnRowCommand="GridWorkFlow_RowCommand" OnRowCreated="GridCCenter_RowCreated" BorderStyle="Solid" OnPageIndexChanging="GridCCenter_PageIndexChanging">
                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                        <Columns>
                            <asp:ButtonField CommandName="btnFiles" Text="View/Add" HeaderText="Files"></asp:ButtonField>
                            <asp:ButtonField CommandName="btnStatus" Text="Status" HeaderText="Contract Trails"></asp:ButtonField>
                            <asp:ButtonField CommandName="btnAction" Text="Approve/Reject" HeaderText="Action"></asp:ButtonField>
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
                                Edit WorkFlow
                            </div>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:Label ID="workflowid" runat="server" Visible="false"></asp:Label></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <label>Workflow Name</label></div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:TextBox ID="txtCcCode" runat="server" class="form-control"></asp:TextBox>
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
            <asp:View ID="View4" runat="server">
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-4 mb-3 mb-sm-0">
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">View Attachments</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    
                    <div class="col-sm-2 mb-3 mb-sm-0">
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red"
                                            Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label>
                        <asp:DataGrid ID="DataGridAttachments" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered zero-configuration" OnItemCommand="DataGridAttachments_ItemCommand" HorizontalAlign="Center">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditItemStyle BackColor="#999999" />
                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundColumn DataField="FileID" HeaderText="FileID" Visible="false"></asp:BoundColumn>
                                <asp:BoundColumn DataField="FileName" HeaderText="FileName"></asp:BoundColumn>
                                <asp:ButtonColumn CommandName="btnEdit" HeaderText="Action" Text="View">
                                    <ItemStyle CssClass="mb-1 btn-warning" />
                                </asp:ButtonColumn>
                            </Columns>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        </asp:DataGrid>
                                        
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        <asp:Button ID="btnReturn" runat="server" class="btn btn-primary btn-user float-left" OnClick="btnReturn_Click" Text="RETURN" />
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                    </div>
                </div>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-4 mb-3 mb-sm-0">
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        STAGES OF CONTRACT
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                       
                    </div>
                </div>
                    <div class="form-group row">
                        <div class="col-sm-1 mb-3 mb-sm-0"></div>
                        <div class="col-sm-4 mb-3 mb-sm-0">
                        </div>
                        <div class="col-sm-3 mb-3 mb-sm-0">
                            <asp:Button ID="Button5" runat="server" Text="Return" OnClick="btnCancel_Click" class="btn btn-primary btn-user btn-block" />
                        </div>
                        <div class="col-sm-2 mb-3 mb-sm-0">
                        </div>
                    </div>
                    <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid1_ItemCommand" Style="text-align: justify"
                                Width="100%">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#999999" />
                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundColumn DataField="RecordID" HeaderText="RecordID" Visible="False"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Description" HeaderText="Stage">
                                        <ItemStyle Width="450px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Remark" HeaderText="Comment "></asp:BoundColumn>
                                    <asp:BoundColumn DataField="CreationDate" HeaderText="Date/Time"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="MadeBy" HeaderText="Made By"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Level" HeaderText="System Level"></asp:BoundColumn>
                                </Columns>
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            </asp:DataGrid>
                </div>
            </asp:View>
            <asp:View ID="View6" runat="server">
                <div class="form-group row">
                    <div class="col-sm-5 mb-3 mb-sm-0"></div>
                    <div class="col-sm-5 mb-3 mb-sm-0">Approve / Reject Contract</div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        <asp:Label runat="server" ID="contid" Visible="false"></asp:Label>
                        Approve Requisition
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        <asp:RadioButtonList ID="rbnApproval" runat="server" CssClass="InterfaceDropdownList" AutoPostBack="True">
                            <asp:ListItem Value="1">Approve Requisition</asp:ListItem>
                            <asp:ListItem Value="2">Reject Requisition</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Comment/Memo(If Required)
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtComment" runat="server" CssClass="InterfaceTextboxMultiline" TextMode="MultiLine" Height="80px"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-2 mb-3 mb-sm-0"></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Button ID="btnSubmitRequistn" runat="server" class="btn btn-primary btn-user btn-block float-right" OnClick="btnSubmitRequistn_Click" Text="SUBMIT" />
                    </div>
                    <div class="col-sm-1 mb-1 mb-sm-0"></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                         <asp:Button ID="Button4" runat="server" Font-Bold="True" OnClick="btnCancel_Click" class="btn btn-primary btn-user btn-block float-right"
                    Text="CANCEL" />
                    </div>
                </div>
                <br />
                
               
            </asp:View>
            <asp:View ID="View7" runat="server">
                <asp:ScriptManager ID="ScriptManager1" AjaxFrameworkMode="Enabled" runat="server"></asp:ScriptManager>
                <div class="text-center">
                    <h6 class="m-0 font-weight-bold text-primary">Milestone Management</h6>
                </div>
                <div class="form-group row">
                    <asp:Label runat="server" ID="contraid" Visible="false"></asp:Label>
                    <asp:Label runat="server" ID="milestoneid" Visible="false"></asp:Label>
                </div>
                <div class="form-group row">
                    <div class="col-sm-12 mb-3 mb-sm-0">
                        <asp:DataGrid ID="DataGrid3" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered zero-configuration" OnItemCommand="DataGrid3_ItemCommand" HorizontalAlign="Center">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditItemStyle BackColor="#999999" />
                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundColumn DataField="RecordId" HeaderText="Id" Visible="false"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Milestone" HeaderText="Milestone"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DateRequired" HeaderText="Date Required"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CreationDate" HeaderText="Completed Date"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Active" HeaderText="Status"></asp:BoundColumn>
                                <asp:ButtonColumn CommandName="btnDownloadFile" HeaderText="Action" Text="Proof Of Completion">
                                    <ItemStyle CssClass=" btn-warning" ForeColor="White"/>
                                </asp:ButtonColumn>
                            </Columns>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        </asp:DataGrid>
                    </div>
                </div>
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


