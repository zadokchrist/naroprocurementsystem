<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="ManageContracts.aspx.cs" Inherits="ManageContracts" 
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
                            <asp:ButtonColumn CommandName="btnFiles" HeaderText="FILES" Text="View/Add"></asp:ButtonColumn>
                            <asp:ButtonColumn CommandName="btnStatus" HeaderText="Status" Text="View"></asp:ButtonColumn>
                            <asp:ButtonColumn CommandName="btnMileStones" HeaderText="Milestones" Text="Add/View"></asp:ButtonColumn>
                            <asp:ButtonColumn CommandName="btnApprove" HeaderText="Action" Text="Approve/Reject"></asp:ButtonColumn>
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
                <table style="width: 100%">
                    <tr>
                        <td colspan="3" style="width: 100%; height: 21px; text-align: center"></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">ATTACHMENT(S)</td>
                    </tr>
                    <tr>
                        <td colspan="3"></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="width: 100%; text-align: center">
                            <asp:Label ID="lblHeaderMsg" runat="server" Font-Bold="True" Font-Names="Cambria"
                                Font-Size="11pt" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; width: 49%; text-align: center">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                                <tr>
                                    <td colspan="3">
                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                            <tr>
                                                <td class="InterfaceHeaderLabel3" style="height: 18px">New Attachments</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 16px"></td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="vertical-align: top; height: 19px; text-align: left">
                                        <table align="center" cellpadding="0" cellspacing="0" style="border-right: #a4a2ca 1px solid; border-top: #a4a2ca 1px solid; border-left: #a4a2ca 1px solid; width: 90%; border-bottom: #a4a2ca 1px solid; background-color: #ffffff">
                                            <tr>
                                                <td style="height: 19px">
                                                    <br />
                                                    <p id="upload-area">
                                                        <input id="FileField" runat="server" size="60" type="file" />
                                                    </p>
                                                    <p>
                                                        <input id="ButtonAdd" onclick="addFileUploadBox()" type="button" value="Add a file" />
                                                    </p>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 2%"></td>
                        <td style="vertical-align: top; width: 49%; text-align: center">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                                <tr>
                                    <td colspan="3">
                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                            <tr>
                                                <td class="InterfaceHeaderLabel3" style="height: 18px">View Attachments</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 16px"></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:GridView ID="GridAttachments" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                            GridLines="None" HorizontalAlign="Center" OnRowCommand="GridAttachments_RowCommand"
                                            PageSize="15" Width="98%">
                                            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                            <RowStyle CssClass="gridRowStyle" />
                                            <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:ButtonField CommandName="ViewDetails" Text="View">
                                                    <HeaderStyle CssClass="gridEditField" />
                                                    <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                        Width="140px" />
                                                </asp:ButtonField>
                                                <asp:ButtonField CommandName="btnRemove" Text="Remove">
                                                    <ItemStyle CssClass="gridEditField" ForeColor="#003399" />
                                                </asp:ButtonField>
                                            </Columns>
                                            <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                            <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                        </asp:GridView>
                                        <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red"
                                            Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 16px"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="vertical-align: top; width: 100%; text-align: center">
                            <asp:Label ID="Label2" runat="server" Text="0" Visible="False"></asp:Label><asp:Button
                                ID="btnSaveFile" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                OnClick="btnSaveFile_Click" Text="SAVE " Width="80px" />
                            <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                OnClick="btnReturn_Click" Text="RETURN" Width="80px" /></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <table id="Table3" style="width: 98%">
                    <tr>
                        <td style="width: 100%; height: 21px; text-align: center"></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">STAGES OF CONTRACT</td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                            <asp:Button ID="Button5" runat="server" Text="Return" OnClick="btnCancel_Click" class="btn btn-primary btn-user btn-block float-right" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: right"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">
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
                            </asp:DataGrid></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: right"></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View6" runat="server">
                <table align="center" cellpadding="0" cellspacing="0" class="style12">
                    <tr>
                        <td colspan="2" style="vertical-align: top; text-align: center; height: 42px;">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                <tr>
                                    <td class="InterfaceHeaderLabel3" style="height: 17px">Approve / Reject &nbsp;Requisition</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; vertical-align: top; width: 50%;">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                <tr>
                                    <asp:Label runat="server" ID="contid"></asp:Label>
                                    <td class="InterFaceTableLeftRowUp">Approve Requisition</td>
                                    <td class="InterFaceTableMiddleRowUp">&nbsp;</td>
                                    <td class="InterFaceTableRightRowUp">
                                        <asp:RadioButtonList ID="rbnApproval" runat="server" CssClass="InterfaceDropdownList" AutoPostBack="True" OnSelectedIndexChanged="rbnApproval_SelectedIndexChanged">
                                            <asp:ListItem Value="1">Approve Requisition</asp:ListItem>
                                            <asp:ListItem Value="2">Reject Requisition</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                            </table>
                        </td>
                        <td style="text-align: center; vertical-align: top; width: 50%;">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                            </table>
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">Comment/Memo(If Required)</td>
                                    <td class="InterFaceTableMiddleRowUp" style="height: 30px">&nbsp;</td>
                                    <td class="InterFaceTableRightRowUp" style="height: 30px">
                                        <asp:TextBox ID="txtComment" runat="server" CssClass="InterfaceTextboxMultiline" TextMode="MultiLine" Height="80px"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="vertical-align: top; text-align: center"></td>
                    </tr>
                </table>
                </ContentTemplate>
                                                    </ajaxToolkit:UpdatePanel>
                                                    <br />
                <asp:Button ID="btnSubmitRequistn" runat="server" class="btn btn-primary btn-user btn-block float-right" OnClick="btnSubmitRequistn_Click" Text="SUBMIT" />
                <asp:Button ID="Button4" runat="server" Font-Bold="True" OnClick="btnCancel_Click" class="btn btn-primary btn-user btn-block float-right"
                    Text="CANCEL" />
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
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Milestone Name</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="milestonename" runat="server" Font-Bold="True" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Date Required</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="milestondate" runat="server" Font-Bold="True" CssClass="form-control"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                            Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="milestondate"></ajaxToolkit:CalendarExtender>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Certificate of Completion</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <p id="upload2-area">
                            <input id="File1" runat="server" size="60" type="file" visible="false" />
                        </p>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-3 mb-3 mb-sm-0 float-right">
                        <asp:Button ID="btnAddMilestone" runat="server" OnClick="btnAddItem_Click" class="btn btn-primary btn-user float-right" Text="Add Milestones" />
                    </div>
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
                                <asp:BoundColumn DataField="CreationDate" HeaderText="Creation Date"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Active" HeaderText="IsComplete"></asp:BoundColumn>
                                
                                <asp:ButtonColumn CommandName="btnCompleteMilestone" HeaderText="Add File" Text="Upload Certificate"></asp:ButtonColumn>
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


