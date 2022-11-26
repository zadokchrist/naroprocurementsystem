<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_InventoryApproval.aspx.cs" Inherits="Requisition_Approval" Title="REQUISITION APPROVAL" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="ajaxToolkit" %>
<%@ Import  Namespace="System.Threading" %>
<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                    CAPTURE/REVIEW REQUISITION DETAILS
            </div>
            </div>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="form-group row">
                    <div class="col-sm-5 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        Requisition Description
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-5 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <span style="font-size: 13pt; font-family: Cambria">SERIAL: --&gt;&gt; ( </span>
                                        <asp:Label ID="lblEntity" runat="server" Font-Names="cambria" Font-Size="13pt" ForeColor="Red"></asp:Label>
                                        <span style="font-size: 13pt; font-family: Cambria">)</span>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">SERIAL:</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtEntityCode" runat="server" CssClass="form-control" Font-Bold="True"
                                                        ReadOnly="True" ></asp:TextBox>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Date Requisitioned</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtDateRequisitioned" runat="server" CssClass="form-control" Font-Bold="True"
                                                        ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Procurement Type</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtProcType" runat="server" CssClass="form-control" BorderStyle="Solid" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Date Required</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtDateRequired" runat="server"
                                                        CssClass="form-control" BorderStyle="Solid" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Subject of Procurement</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtProcSubject" runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Location of Delivery</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtDeliveryLocation" runat="server" CssClass="form-control" Font-Bold="True" ReadOnly="True" ></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Type of Requisition</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtRequisitionType" runat="server" CssClass="form-control" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Cost Center</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtBudgetCostCenter" runat="server" CssClass="form-control" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Is Group</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Label ID="lblIsGroup" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Requisitioner</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtRequisitioner" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Cost Center Manager</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtManager" runat="server" BorderStyle="Solid" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Button ID="btnShowHideFiles" runat="server" Text=" View Attachments" OnClick="btnShowHideFiles_Click" class="btn btn-primary btn-user btn-block float-right"/>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        <asp:Button ID="btnViewStatus" runat="server" Text=" View Status" OnClick="btnViewStatus_Click" class="btn btn-primary btn-user btn-block float-right"/>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Button ID="btnPrintPR" runat="server" Text="Print Requisition" OnClick="btnPrintPR_Click" class="btn btn-primary btn-user btn-block float-right"/>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Button ID="btnEditPRItems" runat="server" Text="Edit PR Items" OnClick="btnEditPRItems_Click" class="btn btn-primary btn-user btn-block float-right"/>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:Label ID="lblPlanCode" runat="server" Font-Names="cambria" Font-Size="13pt" Visible="False">0</asp:Label>
                            <asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label>
                            <asp:Label ID="lblRecordCode" runat="server" Text="0" Visible="False"></asp:Label>
                            <asp:Label ID="lblCostCenterCode" runat="server" Text="0" Visible="False"></asp:Label>
                            <asp:Label ID="lblScalaPR" runat="server" Text="0" Visible="False"></asp:Label>
                            <asp:Label ID="lblCostCenterForBudget" runat="server" Text="0" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:Label ID="lblPDDesc" runat="server" Text="." Font-Underline="False"></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-12 mb-3 mb-sm-0">
                        <asp:GridView ID="GridItems" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="gridgeneralstyle" PageSize="15" HorizontalAlign="Left" GridLines="None" DataKeyNames="Item Code" EmptyDataText="REQUSITION HAS NO ITEMS" AllowPaging="True" CellPadding="4" ForeColor="#333333">
                            <AlternatingRowStyle BackColor="White" CssClass="gridAlternatingRowStyle"></AlternatingRowStyle>
                            <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                            <HeaderStyle HorizontalAlign="Left" BackColor="#507CD1" CssClass="gridHeaderStyle" Font-Bold="True" ForeColor="White"></HeaderStyle>

                            <PagerSettings Position="TopAndBottom" />
                            <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                            <RowStyle CssClass="gridRowStyle" BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                            <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                            <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                            <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                            <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                            <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                            <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                            <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                            <Columns>
                                <asp:BoundField DataField="Item Code" HeaderText="Item Code">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PlanCode" HeaderText="Plan Code">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="Item Description">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Ranking" HeaderText="Rank">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <table cellpadding="0" cellspacing="0" class="style12">
                    <tr>
                        <td>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 98%" align="center">
                                <tbody>
                                    <tr>
                                        <td style="width: 100%; text-align: center"
                                            class="InterFaceTableLeftRowUp">
                                            <asp:Label ID="lblTotal" runat="server" Text="." Font-Names="Calibri" Font-Bold="True" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; height: 23px; text-align: center"></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; height: 23px; text-align: center">
                            <table
                                style="width: 62%" cellspacing="0" cellpadding="0" align="center">
                                <tbody>
                                    <tr>
                                        <td style="height: 17px"
                                            class="InterfaceHeaderLabel3">FUND AVAILABILITY</td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: center; height: 23px;">&nbsp;<table style="width: 98%;" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="vertical-align: middle; width: 17%; text-align: center" class="InterfaceHeaderLabel3">Budget Code</td>
                                <td class="InterfaceHeaderLabel3" style="vertical-align: middle; width: 17%; text-align: center">Amount Approved</td>
                                <td class="InterfaceHeaderLabel3" style="vertical-align: middle; width: 17%; text-align: center">Expenditure To Date</td>
                                <td style="vertical-align: middle; width: 17%; text-align: center" class="InterfaceHeaderLabel3">Requisitions To Date</td>
                                <td class="InterfaceHeaderLabel3" style="vertical-align: middle; width: 15%; text-align: center">Balance On Budget&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle; text-align: center;" class="ddcolortabsline2" colspan="4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle; width: 17%; text-align: center">&nbsp;<asp:TextBox BackColor="#EEEEEE" BorderColor="#EEEEEE" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True" ForeColor="Firebrick" ID="txtBudgetCode" ReadOnly="True" runat="server" Width="90%"></asp:TextBox></td>
                                <td style="vertical-align: middle; width: 17%; text-align: center;">
                                    <asp:TextBox BackColor="#EEEEEE" BorderColor="#EEEEEE" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True" ForeColor="Firebrick" ID="txtAmountApproved" ReadOnly="True" runat="server" Width="90%"></asp:TextBox>&nbsp;</td>
                                <td style="vertical-align: middle; width: 17%; text-align: center">&nbsp;<asp:TextBox ID="txtExpenditure" runat="server" ForeColor="Firebrick" Font-Bold="True" Width="90%" ReadOnly="True" CssClass="InterfaceTextboxLongReadOnly" BorderStyle="Solid" BackColor="#EEEEEE" BorderColor="#EEEEEE"></asp:TextBox></td>
                                <td style="vertical-align: middle; text-align: center; width: 17%;">
                                    <asp:TextBox BackColor="#EEEEEE" BorderColor="#EEEEEE" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True" ForeColor="Firebrick" ID="txtRequisition" ReadOnly="True" runat="server" Width="90%" />&nbsp;</td>
                                <td style="vertical-align: middle; text-align: center; width: 15%;">
                                    <asp:TextBox ID="txtBalanceOnBudet" runat="server" BackColor="#EEEEEE" BorderColor="#EEEEEE"
                                        BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                        ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox>&nbsp;</td>
                            </tr>
                        </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; height: 23px; text-align: center"></td>
                    </tr>
                    <tr>
                        <td style="height: 2px"></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle; text-align: center">
                            <asp:MultiView ID="MultiView2" runat="server">
                                <asp:View ID="View5" runat="server">
                                    &nbsp;
                                                        
                                                   

                                    <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; text-align: center; height: 42px;">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                                    <tr>
                                                        <td class="InterfaceHeaderLabel3" style="height: 17px">Approve Requisition</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center; vertical-align: top; width: 50%;">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                    <tr>
                                                        <td class="InterFaceTableMiddleRowUp">&nbsp;</td>
                                                        <td class="InterFaceTableRightRowUp">
                                                            <asp:RadioButtonList ID="rbnApproval" runat="server" CssClass="InterfaceDropdownList" AutoPostBack="True">
                                                                <asp:ListItem Value="1">Submit to Managing Director</asp:ListItem>
                                                                <asp:ListItem Value="2">Reject Reqisition</asp:ListItem>
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="text-align: center; vertical-align: top; width: 50%;">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                </table>
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                    <tr>
                                                        <td class="InterFaceTableLeftRowUp" style="height: 30px">Comment (If Required)</td>
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
                                    <asp:Button ID="btnSubmitRequistn" runat="server" Font-Bold="True" Font-Size="9pt"
                                        Height="23px" OnClick="btnSubmitRequistn_Click" Text="SUBMIT" Width="120px" />
                                </asp:View>
                                &nbsp;
                                           
                            </asp:MultiView>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle; height: 23px; text-align: center">
                            <asp:Label ID="lblreqn" runat="server" Text="Label" Visible="False"></asp:Label><asp:Label
                                ID="lblCostCenter" runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblCostCenterID"
                                    runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblAreaID" runat="server" Text="0" Visible="False"></asp:Label>
                            <asp:Label ID="lblRankNumber" runat="server" Text="0" Visible="False"></asp:Label>&nbsp;
                                        </td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table style="width: 100%">
                    <tr>
                        <td colspan="1" style="width: 100%; height: 21px; text-align: center"></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" colspan="1" style="width: 100%; text-align: center">ATTACHMENT(S)</td>
                    </tr>
                    <tr>
                        <td colspan="1"></td>
                    </tr>
                    <tr>
                        <td colspan="1" style="width: 100%; text-align: center">
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
                                            GridLines="None" HorizontalAlign="Left" OnRowCommand="GridAttachments_RowCommand"
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
                        <td colspan="1" style="vertical-align: top; width: 100%; text-align: center">
                            <asp:Label ID="Label1" runat="server" Text="0" Visible="False"></asp:Label>
                            <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                OnClick="btnReturn_Click" Text="RETURN" Width="80px" /></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <table id="Table2" onclick="return TABLE1_onclick()" style="width: 100%">
                    <tr>
                        <td style="width: 100%; height: 21px; text-align: right"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:Button ID="btnGoBack"
                                runat="server" OnClick="btnGoBack_Click" Text="Return to Requisitions" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: right"></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View6" runat="server">
                <table id="Table3" onclick="return TABLE1_onclick()" style="width: 98%">
                    <tr>
                        <td style="width: 100%; height: 21px; text-align: center"></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">STAGES OF REQUISITION</td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Export" />&nbsp;
                                       
                            <asp:Button ID="Button1" runat="server" Text="Return" OnClick="Button1_Click" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: right"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid2_ItemCommand" Style="text-align: justify"
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
            <asp:View ID="View7" runat="server">
                <table id="Table2" onclick="return TABLE1_onclick()" style="width: 100%">
                    <tr>
                        <td style="width: 100%; height: 21px; text-align: right"></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">REQUISITION ITEM</td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                            <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" Text="Print Form" />
                            <asp:Button ID="btnPrintReturn" runat="server" Text="Return" OnClick="btnPrintReturn_Click" />&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <%--<cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"></cr:crystalreportviewer>--%>
                                        &nbsp;&nbsp;<br />
                            <asp:Label ID="lblPD_Code" runat="server" Text="0" Visible="False"></asp:Label></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View8" runat="server">
                <table id="Table1" onclick="return TABLE1_onclick()" style="width: 98%">
                    <tr>
                        <td style="width: 100%; height: 21px; text-align: center"></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">ATTACH STOCK CODES / EDIT PR ITEM QUANTITIES</td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: right"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                                ForeColor="#333333" GridLines="Vertical" Width="100%" HorizontalAlign="Left">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#999999" />
                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                                <Columns>
                                    <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove" Visible="false">
                                        <ItemStyle ForeColor="Red" />
                                    </asp:ButtonColumn>
                                    <asp:BoundColumn DataField="Item Code" HeaderText="Record ID"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="PlanCode" HeaderText="PlanCode" Visible="false"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Description" HeaderText="Item Description">
                                        <ItemStyle Width="300px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Ranking" HeaderText="Rank" Visible="false"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="QuantityRemaining" HeaderText="Planned Qty"></asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Stock Code">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtStockName" runat="server" EnableViewState="true" Text='<%# DataBinder.Eval(Container, "DataItem.StockName") %>'
                                                Width="150px"></asp:TextBox>
                                            <ajaxToolkit:AutoCompleteExtender ID="ACEStockCode" runat="server" TargetControlID="txtStockName" ServicePath="CascadingddlService.asmx" ServiceMethod="GetStockItemsByName" MinimumPrefixLength="1">
                                            </ajaxToolkit:AutoCompleteExtender>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Stock Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtStockQty" runat="server" EnableViewState="true" Text="0"
                                                Width="50px" OnTextChanged="txtQtyRequired_TextChanged" AutoPostBack="true">
                                                                </asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="NumberOfItems" HeaderText="Requested Qty"></asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="New Qty">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtQtyRequired" runat="server" EnableViewState="true" Text='<%# DataBinder.Eval(Container, "DataItem.NumberOfItems") %>'
                                                Width="50px" Enabled="false">
                                                                </asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="UnitCost" HeaderText="Unit Cost" DataFormatString="{0:N0}">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="TotalCost" HeaderText="Total  " DataFormatString="{0:N0}">
                                        <ItemStyle HorizontalAlign="Right" />
                                        <HeaderStyle HorizontalAlign="Right" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="EDIT">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chbAdd" runat="server" Checked="false"
                                                Width="40px" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                </Columns>
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center" class="InterFaceTableLeftRowUp">
                            <asp:Label ID="lblAttachStockCodeTotal" runat="server"></asp:Label>&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:Button ID="btnEditItems" runat="server" OnClick="btnEditItems_Click" Text="Edit Items" />
                            <asp:Button ID="btnCancelEditItems" runat="server" OnClick="btnCancelEditItems_Click"
                                Text="Cancel" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center"></td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </div>
      
    
<script type="text/javascript">
   function addFileUploadBox()
   {
   if (!document.getElementById || !document.createElement)
   return false;
   
   var uploadArea = document.getElementById("upload-area");
   if (!uploadArea)
   return;
   
   var newline = document.createElement("br");
   uploadArea.appendChild(newline);
   
   var newUploadBox = document.createElement("input");
   newUploadBox.type= "file";
   newUploadBox.size = "60";
   if (!addFileUploadBox.lastAssignedId)
   addFileUploadBox.lastAssignedId = 100;
   
   newUploadBox.setAttribute("id", "FileField" + addFileUploadBox.lastAssignedId);
   newUploadBox.setAttribute("name", "FileField" + addFileUploadBox.lastAssignedId);
   uploadArea.appendChild(newUploadBox);
   addFileUploadBox.lastAssignedId++;
   }


</script>
</asp:Content>




