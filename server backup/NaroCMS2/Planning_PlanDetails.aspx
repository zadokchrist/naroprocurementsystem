<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Planning_PlanDetails.aspx.cs" Inherits="Planning_PlanDetails" Title="VIEW PLAN ITEM" %>

 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager  runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" />
        
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0"></div>
                <div class="col-sm-6 mb-3 mb-sm-0">
                    <asp:Button ID="btnOK0" runat="server" Text="RETURN" class="btn btn-primary btn-user btn-block float-right"  onclick="btnOK_Click" />
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    Item Description
                </div>
                <div class="col-sm-1 mb-3 mb-sm-0">
                </div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    Procurement Details
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Plan Serial Number</label>
                    <asp:TextBox ID="txtPlanCode" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="col-sm-1 mb-3 mb-sm-0">
                </div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Procurement Type</label>
                    <asp:TextBox ID="txtProcType" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>.</label><br />
                    <asp:CheckBox ID="chbIsGroup" runat="server" Font-Bold="True" Font-Italic="True" Text=" Is Group Item" />
                    <asp:CheckBox ID="chkIsFramework" runat="server" AutoPostBack="True" Font-Bold="True" Font-Italic="True" Text="Is FrameWork" />
                </div>
                <div class="col-sm-1 mb-3 mb-sm-0">
                </div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Procurement Method</label>
                    <asp:TextBox ID="txtProcMethod" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Stock Name / Category</label><br />
                    <asp:TextBox ID="txtStockName" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="col-sm-1 mb-3 mb-sm-0">
                </div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Quarter When Needed</label>
                    <asp:TextBox ID="txtQuater" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Priority Ranking</label><br />
                    <asp:TextBox ID="txtPriorityRanking" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="col-sm-1 mb-3 mb-sm-0">
                </div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Date When Needed</label>
                    <asp:TextBox ID="txtDateWhenNeeded" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Non Stock Item Category Type</label><br />
                    <asp:TextBox ID="txtItemCategoryType" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="col-sm-1 mb-3 mb-sm-0">
                </div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Date To Initiate PP20</label>
                    <asp:TextBox ID="txtPP20Date" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Non Stock Item Category</label><br />
                    <asp:TextBox ID="txtItemCategory" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="col-sm-1 mb-3 mb-sm-0">
                </div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Other Details</label>
                    
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Item Name</label><br />
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="col-sm-1 mb-3 mb-sm-0">
                </div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Status Level</label>
                    <asp:TextBox ID="txtStatusLevel" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                    <asp:Label ID="lblStatusID" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Units</label><br />
                    <asp:TextBox ID="txtUnits" runat="server" CssClass="form-control" ReadOnly="True"/>
                </div>
                <div class="col-sm-1 mb-3 mb-sm-0">
                </div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Level of Authority Required</label>
                    <asp:TextBox ID="txtAuthority" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Quantity</label><br />
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="col-sm-1 mb-3 mb-sm-0">
                </div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Source of Funding</label>
                    <asp:TextBox ID="txtFunding" runat="server"  CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Unit Cost</label><br />
                    <asp:TextBox ID="txtUnitCost" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-1 mb-3 mb-sm-0">
                </div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Plan Recorded By</label>
                    <asp:TextBox ID="txtPlanRecorder" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>Budget Cost Center</label><br />
                    <asp:TextBox ID="txtBudgetCostCenter" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="col-sm-1 mb-3 mb-sm-0">
                </div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <label>MarketPrice</label>
                    <asp:TextBox ID="txtMarketPrice" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <asp:Button ID="btnViewAttachments" runat="server" Text="View Attachments" OnClick="btnViewAttachments_Click" class="btn btn-primary btn-user btn-block float-right" />
                </div>
                <div class="col-sm-1 mb-3 mb-sm-0">
                </div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                    <asp:Button ID="btnViewStatus" runat="server" Text="View Status" OnClick="btnViewStatus_Click" class="btn btn-primary btn-user btn-block float-right" />
                </div>
            </div>
        </asp:View>

        <asp:View ID="View2" runat="server"> 
            <table cellpadding="5" cellspacing="0" width="100%">
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="text-align: center">
                        PLAN ITEM LOG</td>
                </tr>
                <tr>
                    <td>
                    <asp:DataGrid ID="dgPlanLog" runat="server" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Left" Font-Names="Verdana" Font-Size="Small"
                    ForeColor="#333333" GridLines="None" Width="100%">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditItemStyle BackColor="#999999" />
                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" Mode="NumericPages" HorizontalAlign="Center" />
                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Left" BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundColumn DataField="CreationDate" HeaderText="Date"></asp:BoundColumn>
                            <asp:BoundColumn DataField="MadeBy" HeaderText="Created By"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Level" HeaderText="System Access Level"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Description" HeaderText="Plan Status"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Remark" HeaderText="Comments/Remarks"></asp:BoundColumn>
                        </Columns>
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    </asp:DataGrid>
                    
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click" class="btn btn-primary btn-user btn-block float-right"
                            Text="Return to Plan Item" /></td>
                </tr>
                
            </table>
        </asp:View>
        <asp:View id="View3" runat="server">
            <table style="width: 100%">
                <tr>
                    <td colspan="3" style="width: 100%; height: 21px; text-align: center">
                    </td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">
                        ATTACHMENT(S)</td>
                </tr>
                <tr>
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="width: 100%; text-align: center">
                        <asp:Label ID="lblAttachmentEditHeader" runat="server" Font-Bold="True" Font-Names="Cambria"
                            Font-Size="11pt" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 49%; text-align: center">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                            <tr>
                                <td colspan="3">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                        <tr>
                                            <td class="InterfaceHeaderLabel3" style="height: 18px">
                                                New Attachments</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 16px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="vertical-align: top; height: 19px; text-align: left">
                                    <table align="center" cellpadding="0" cellspacing="0" style="border-right: #a4a2ca 1px solid;
                                        border-top: #a4a2ca 1px solid; border-left: #a4a2ca 1px solid; width: 90%; border-bottom: #a4a2ca 1px solid;
                                        background-color: #ffffff">
                                        <tr>
                                            <td style="height: 19px">
                                                <br  />
                                                <p id="upload-area">
                                                    <input id="FileField" runat="server" size="60" type="file"  />
                                                </p>
                                                <p>
                                                    <input id="ButtonAdd" onclick="addFileUploadBox()" type="button" value="Add a file"  />
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 2%">
                    </td>
                    <td style="vertical-align: top; width: 49%; text-align: center">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                            <tr>
                                <td colspan="3">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                        <tr>
                                            <td class="InterfaceHeaderLabel3" style="height: 18px">
                                                View Attachments</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 16px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:GridView ID="GridView1" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                        GridLines="None" HorizontalAlign="Center" OnRowCommand="GridView1_RowCommand"
                                        OnRowCreated="GridAttachments_RowCreated" OnSelectedIndexChanged="GridAttachments_SelectedIndexChanged"
                                        PageSize="15" Width="98%">
                                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom"  />
                                        <RowStyle CssClass="gridRowStyle"  />
                                        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center"  />
                                        <Columns>
                                            <asp:ButtonField CommandName="ViewDetails" Text="View">
                                                <HeaderStyle CssClass="gridEditField"  />
                                                <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                    Width="140px"  />
                                            </asp:ButtonField>
                                            <asp:ButtonField CommandName="btnRemove" Text="Remove">
                                                <ItemStyle CssClass="gridEditField" ForeColor="#003399"  />
                                            </asp:ButtonField>
                                        </Columns>
                                        <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left"  />
                                        <AlternatingRowStyle CssClass="gridAlternatingRowStyle"  />
                                    </asp:GridView>
                                    <asp:Label ID="Label2" runat="server" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red"
                                        Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 16px">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="vertical-align: top; width: 100%; text-align: center">
                        <asp:Label ID="Label3" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Button ID="btnSaveFile" runat="server" Font-Bold="True" OnClick="btnSaveFile_Click" Text="SAVE "  />
                        <asp:Button ID="btnReturn" runat="server" Font-Bold="True"
                            OnClick="btnReturn_Click" Text="RETURN" class="btn btn-primary btn-user btn-block float-right"  /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View4" runat="server">
            <table align="center" cellpadding="0" cellspacing="0" style="width: 90%">
                <tr>
                    <td colspan="3" style="text-align: center">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                            <tr>
                                <td class="InterfaceHeaderLabel" style="height: 20px">
                                                ATTACHMENTS</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="vertical-align: top; height: 2px; text-align: center">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="vertical-align: top; height: 18px; text-align: center">
                        <asp:Label ID="lblHeaderMsg" runat="server" Font-Bold="True" Font-Names="Cambria"
                            Font-Size="11pt" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 2px; text-align: center">
                    </td>
                </tr>
                <tr>
                    <td style="height: 203px">
                        <table align="center" cellpadding="0" cellspacing="0" class="style12">
                            <tr>
                                <td style="vertical-align: top; width: 50%; height: 121px; text-align: center">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                    </table>
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                                        <tr>
                                            <td colspan="3">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                                    <tr>
                                                        <td class="InterfaceHeaderLabel3" style="height: 18px">
                                                                        View Attachments</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="height: 2px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:GridView ID="GridAttachments" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                                    GridLines="None" HorizontalAlign="Center" OnRowCommand="GridAttachments_RowCommand"
                                                    PageSize="5" Width="98%">
                                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                    <RowStyle CssClass="gridRowStyle" />
                                                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                    <Columns>
                                                        <asp:ButtonField CommandName="btnView" Text="View">
                                                            <HeaderStyle CssClass="gridEditField" />
                                                            <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                                Width="140px" />
                                                        </asp:ButtonField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                    <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                </asp:GridView>
                                                <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red"
                                                    Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:Button ID="Button2" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                            OnClick="btnReturn_Click" Text="RETURN" Width="80px" /><asp:Label ID="lblPlanCode"
                                runat="server" Text="0" Visible="False"></asp:Label></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View5" runat="server">
            <table style="width: 100%">
                <tr>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                        REMOVE ATTACHMENT</td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                        <asp:Label ID="lblFileCode" runat="server" Visible="False"></asp:Label></td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                        <asp:Label ID="lblRemoveAtt" runat="server" Font-Bold="True" ForeColor="Red" Text="."></asp:Label>
                        <asp:Button ID="btnYesAtt" runat="server" OnClick="btnYesAtt_Click" Text="Yes" />
                        <asp:Button ID="btnNoAtt" runat="server" OnClick="btnNoAtt_Click" Text="No" /></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                    </td>
                </tr>
            </table>
        </asp:View>
                    
                </asp:MultiView>
                
</asp:Content>


