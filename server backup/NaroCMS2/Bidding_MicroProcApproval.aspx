<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Bidding_MicroProcApproval.aspx.cs" Inherits="Bidding_MicroProcApproval" Title="MICRO PROCUREMENT APPROVAL" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td class="InterfaceItemSeparator2" style="height: 2px">
               <%--<ajaxToolkit:ToolkitScriptManager  ID="ScriptManager1" runat="server">
                </ajaxToolkit:ToolkitScriptManager>--%>
                   <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>

            </td>
        </tr>
        <tr>
            <td style="height: 39px">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                    <tr>
                        <td class="InterfaceHeaderLabel3" style="height: 18px">
                            MICRO PROCUREMENT APPROVAL</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 50%; height: 15px; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 50%; text-align: center">
                <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid;
                    border-left: #617da6 1px solid; width: 99%; border-bottom: #617da6 1px solid">
                    <tr>
                        <td style="vertical-align: top; text-align: center">
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                    <tr>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            Pr number</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            PROC. OFFICER</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            AREA</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            Cost CENTER</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                        </td>
                    </tr>
                    <tr>
                        <td class="ddcolortabsline2" colspan="5" style="vertical-align: middle; text-align: center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            &nbsp;<asp:TextBox ID="txtPrNumber" runat="server" Width="85%"></asp:TextBox></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:DropDownList ID="cboProcurementOfficer" runat="server" CssClass="InterfaceDropdownList"
                                OnDataBound="cboProcurementOfficer_DataBound"
                                Width="85%">
                            </asp:DropDownList></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:DropDownList ID="cboAreas" runat="server" AutoPostBack="True" CssClass="InterfaceDropdownList"
                                OnDataBound="cboAreas_DataBound1" OnSelectedIndexChanged="cboAreas_SelectedIndexChanged"
                                Width="95%">
                            </asp:DropDownList></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:DropDownList ID="cboCostCenters" runat="server" CssClass="InterfaceDropdownList"
                                OnDataBound="cboCostCenter_DataBound" Width="95%">
                            </asp:DropDownList></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Height="23px" OnClick="btnOK_Click"
                                Text="Search" Width="85px" />&nbsp;</td>
                    </tr>
                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center;" class="InterFaceTableLeftRow">
                                                <asp:Label ID="lblSearch" runat="server" Text="."></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4"  Font-Names="Verdana" Font-Size="Small"
                                                    ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid1_ItemCommand"
                                                    Width="100%" style="text-align: justify">
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <EditItemStyle BackColor="#999999" />
                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="RecordID" HeaderText="RecordID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CreationDate" HeaderText="Date" DataFormatString="{0:dd MMM yyyy}" Visible="False">
                                                            <ItemStyle Width="50px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ScalaPRNumber" HeaderText="PR Number"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Subject" HeaderText="Subject"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ProcurementType" HeaderText="Type"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ProcMethodCode" HeaderText="MethodCode" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Method" HeaderText="Method"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="EstimatedCost" HeaderText="Est. Cost" DataFormatString="{0:N0}">
                                                           
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="PD_Code" HeaderText="PD_CODE" Visible="False"></asp:BoundColumn>
                                                        <asp:ButtonColumn CommandName="btnApprove" HeaderText="ACTION" Text="Approve/Reject"></asp:ButtonColumn>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                </asp:DataGrid></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:Label ID="lblEmpty" runat="server" Font-Bold="True" ForeColor="Red" Text="."></asp:Label></td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                                                <table cellpadding="0" cellspacing="0" class="style12">
                                                    <tr>
                                                        <td class="InterfaceItemSeparator2" style="height: 2px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                <tr>
                                                                    <td colspan="2" style="vertical-align: top; text-align: center">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; height: 121px; text-align: center">
                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                            <tr>
                                                                                <td class="InterFaceTableLeftRowUp">
                                                                                    Reference Number</td>
                                                                                <td class="InterFaceTableMiddleRowUp">
                                                                                </td>
                                                                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                                                    <asp:TextBox ID="txtReferenceNo" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                                        Font-Bold="True" ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="InterFaceTableLeftRowUp">
                                                                                    Procurement Type</td>
                                                                                <td class="InterFaceTableMiddleRowUp">
                                                                                    &nbsp;</td>
                                                                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                                                    <asp:TextBox ID="txtProcType" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                                                    Estimated Cost</td>
                                                                                <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                                                </td>
                                                                                <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                                                    <asp:TextBox ID="txtEstimatedCost" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="InterFaceTableLeftRowUp">
                                                                                    Procurement Method</td>
                                                                                <td class="InterFaceTableMiddleRowUp">
                                                                                </td>
                                                                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                                                    <asp:TextBox ID="txtProcMethod" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="InterFaceTableLeftRowUp">
                                                                                    Date Requisitioned</td>
                                                                                <td class="InterFaceTableMiddleRowUp">
                                                                                </td>
                                                                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                                                    <asp:TextBox ID="txtDateRequisitioned" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; height: 121px; text-align: center">
                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                        </table>
                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                            <tr>
                                                                                <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                                                    Date Required</td>
                                                                                <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                                                </td>
                                                                                <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                                                    <asp:TextBox ID="txtDateRequired" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="InterFaceTableLeftRow">
                                                                                    Subject of Procurement</td>
                                                                                <td class="InterFaceTableMiddleRow">
                                                                                </td>
                                                                                <td class="InterFaceTableRightRow" style="width: 66%; height: 65px">
                                                                                    <asp:TextBox ID="txtProcSubject" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxMultiline"
                                                                                        Font-Bold="True" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="InterFaceTableLeftRowUp">
                                                                                    Requisitioner</td>
                                                                                <td class="InterFaceTableMiddleRowUp">
                                                                                </td>
                                                                                <td class="InterFaceTableRightRowUp">
                                                                                    <asp:TextBox ID="txtRequisitioner" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="InterFaceTableLeftRowUp">
                                                                                    Cost Center</td>
                                                                                <td class="InterFaceTableMiddleRowUp">
                                                                                    &nbsp;</td>
                                                                                <td class="InterFaceTableRightRowUp">
                                                                                    <asp:TextBox ID="txtBudgetCostCenter" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: center">
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; text-align: center">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="vertical-align: top; text-align: center">
                                                                        <asp:Button ID="Button1" runat="server" Text="View Status" Width="139px" 
                                                                            onclick="Button1_Click" />
                                                                        <asp:Button ID="btnPrintApproval" runat="server" OnClick="btnPrintApproval_Click"
                                                                            Text="Print PD04 Approval" Width="139px" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: center">
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; text-align: center">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" style="vertical-align: top; text-align: center">
                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                                                            <tr>
                                                                                <td class="InterfaceHeaderLabel3" style="height: 18px">
                                                                                    MICRO PROCUREMENT DETAILS APPROVAL</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: center">
                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                            <tr>
                                                                                <td class="InterFaceTableLeftRowUp">
                                                                                    Recommended Bidder</td>
                                                                                <td class="InterFaceTableMiddleRowUp">
                                                                                </td>
                                                                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                                                    <asp:TextBox ID="txtRecBidder" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                                        Font-Bold="True" ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="InterFaceTableLeftRowUp">
                                                                                    Final Bid Amount</td>
                                                                                <td class="InterFaceTableMiddleRowUp">
                                                                                    &nbsp;</td>
                                                                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                                                    <asp:TextBox ID="txtFinalBidAmount" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; text-align: center">
                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                            <tr>
                                                                                <td class="InterFaceTableLeftRowUp" valign="top">
                                                                                    Comment</td>
                                                                                <td class="InterFaceTableMiddleRowUp">
                                                                                </td>
                                                                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                                                    <asp:TextBox ID="txtBidComment" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxMultiline"
                                                                                        Font-Bold="True" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="vertical-align: top; width: 50%; text-align: center">
                                                                    </td>
                                                                    <td style="vertical-align: top; width: 50%; text-align: center">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; text-align: center">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                                    <tr>
                                                        <td colspan="3" style="height: 2px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                                                <tr>
                                                                    <td class="InterfaceHeaderLabel3" style="height: 18px">
                                                                        View Bid Analysis Sheet and Bids</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="height: 2px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="height: 16px">
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
                                                                </Columns>
                                                                <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                                <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            &nbsp;<asp:Label ID="lblNoAttachments" runat="server" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red"
                                                                Text="NO BID ANALYSIS SHEET FOUND" Visible="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="height: 16px">
                                                        </td>
                                                    </tr>
                                                </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 19px">
                                                            &nbsp;<asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label>&nbsp;
                                                            <asp:Label ID="lblStatusID" runat="server" Text="0" Visible="False"></asp:Label>
                                                            <asp:Label ID="lblReqCode" runat="server" Text="0" Visible="False"></asp:Label>
                                                            <asp:Label ID="lblPlanCode" runat="server" Text="0" Visible="False"></asp:Label></td>
                                                    </tr>
                                                </table>
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <td style="width: 98%">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 98%">
                                                                                <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; height: 42px; text-align: center">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                                                                                <tr>
                                                                                                    <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                                                        Submit Micro &nbsp;Procurement For Approval</td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="vertical-align: top; width: 50%; text-align: center">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp">
                                                                                                        Select Option</td>
                                                                                                    <td class="InterFaceTableMiddleRowUp">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp">
                                                                                                        <asp:RadioButtonList ID="rbnApproval" runat="server" AutoPostBack="True" CssClass="InterfaceDropdownList" OnSelectedIndexChanged="rbnApproval_SelectedIndexChanged">
                                                                                                        </asp:RadioButtonList></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp">
                                                                                                        <asp:Label ID="lblHead" runat="server" Text="Head of Department" Visible="False"></asp:Label></td>
                                                                                                    <td class="InterFaceTableMiddleRowUp">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp">
                                                                                                        <asp:TextBox ID="txtHead" runat="server" autocomplete="off" Font-Bold="True" Width="80%" Visible="False"></asp:TextBox></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <cc1:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1"
                                                                                                ServiceMethod="GetUsersByNames" ServicePath="CascadingddlService.asmx" TargetControlID="txtHead">
                                                                                            </cc1:AutoCompleteExtender></td>
                                                                                        <td style="vertical-align: top; width: 50%; text-align: center">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                            </table>
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                                                                        Comment (If Required)</td>
                                                                                                    <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                                                                        &nbsp;</td>
                                                                                                    <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                                                                        <asp:TextBox ID="txtComment" runat="server" CssClass="InterfaceTextboxMultiline"
                                                                                                            Height="80px" TextMode="MultiLine"></asp:TextBox></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <br />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            &nbsp;<asp:Button ID="btnSubmitToHOS" runat="server" Font-Bold="True" OnClick="btnSubmitToHOS_Click"
                                                                                                Text="SUBMIT" />
                                                                                            <asp:Button ID="btnCancelSubmit" runat="server" Font-Bold="True" OnClick="btnCancel_Click"
                                                                                                Text="CANCEL" /></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                &nbsp;&nbsp;&nbsp; &nbsp;
                                <asp:View ID="View5" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 98%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 98%">
                                                <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid;
                                                    border-left: #617da6 1px solid; width: 98%; border-bottom: #617da6 1px solid">
                                                    <tbody>
                                                        <tr>
                                                            <td style="vertical-align: top; width: 96%; text-align: center">
                                                                <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                                                                    ToolPanelView="None" HasPrintButton="False" Height="50px" SeparatePages="False"
                                                                    Width="350px" />--%>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View runat="server" ID='View6'>
                                
                                 <table id="Table3" style="width: 98%">
                                <tr>
                                    <td style="width: 100%; height: 21px; text-align: center">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                                        STAGES OF REQUISITION</td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                                        
                                        <asp:Button ID="Return" runat="server" Text="Return" OnClick="Return_Click" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: right">
                                    </td>
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
                                    <td style="width: 100%; text-align: right">
                                    </td>
                                </tr>
                            </table>



                                </asp:View>
                            </asp:MultiView>&nbsp;
                            &nbsp;</td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="lblPD_Code" runat="server" Text="0" Visible="False"></asp:Label></td>
        </tr>
    </table>
    &nbsp;
 
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







