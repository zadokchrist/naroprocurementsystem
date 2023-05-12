<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Bidding_BidReceipt.aspx.cs" Inherits="Bidding_BidReceipt" Title="RECORD OF RECEIPT OF BIDS" UICulture="en" Culture="en-US" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td class="InterfaceItemSeparator2" style="height: 2px">
          <%--      <ajaxToolkit:ToolkitScriptManager  ID="ScriptManager1" runat="server">
                </ajaxToolkit:ToolkitScriptManager>--%>
                   <asp:ScriptManager ID="ScriptManager1" AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
            </td>
        </tr>     

        <tr>
            <td style="height: 39px">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                    <tr>
                        <td class="InterfaceHeaderLabel3" style="height: 18px">
                            ADD RECORD OF RECEIPT OF BIDS</td>
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
                                            <td style="width: 100%; text-align: center; height: 9px;">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>
                <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                    <tr>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            PR NUMBER</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            PrOC. METHOD</td>
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
                            <asp:DropDownList ID="cboProcMethod" runat="server" AutoPostBack="True" CssClass="InterfaceDropdownList"
                                OnDataBound="cboProcMethod_DataBound" Width="95%">
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
                                            <td style="height: 9px;">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" 
                                                    CellPadding="4"  Font-Names="Verdana" Font-Size="Small"
                                                    ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid1_ItemCommand"
                                                    Width="100%" style="text-align: justify" 
                                                    >
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
                                                        <asp:BoundColumn DataField="IsBidReceiptCloseEnabled" HeaderText="IsBidReceiptCloseEnabled" Visible="false"></asp:BoundColumn>
                                                        <asp:ButtonColumn CommandName="btnAddReceipt" HeaderText="ACTION" Text="Add Receipt"></asp:ButtonColumn>

                                                        <asp:TemplateColumn HeaderText="ACTION">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="btnCloseReceipt" CommandName="btnCloseReceipt" Text="Close Receipt" Visible="<%# EnableCloseButton(Container.DataItem) %>"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        
                                                         <asp:TemplateColumn HeaderText="NO BIDS">
                                                            <ItemTemplate>
                                                             <asp:LinkButton runat="server" ID="btnNoBids" CommandName="btnNoBids" Text="No Bids" ></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                         
                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                </asp:DataGrid></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center;">
                                                <asp:Label ID="lblEmpty" runat="server" Font-Bold="True" ForeColor="Red" Text="."></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                                                NO RECORD FOUND MESSAGE</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                &nbsp;&nbsp;
                                <asp:View ID="View3" runat="server">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center; width: 100%;">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                                    <tr>
                                                        <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                            &gt;&gt;&gt; &nbsp;<asp:Label ID="lblHeading" runat="server" ForeColor="Firebrick"
                                                                Text="0"></asp:Label></td>
                                                    </tr>
                                                </table>
                                                            <asp:Label ID="lblProcMethod" runat="server" Text="0" Visible="False"></asp:Label><asp:Label
                                                                ID="lblRefNo" runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblQuestionCount"
                                                                    runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblID" runat="server"
                                                                        Text="0" Visible="False"></asp:Label><asp:Label ID="lblPDCode" runat="server" Text="0"
                                                                            Visible="False"></asp:Label>
                                                <asp:Label ID="lblReceiptID" runat="server" Text="0" Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" style="vertical-align: top; width: 50%; text-align: center">
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
                                            <td colspan="4" style="vertical-align: top; width: 50%; text-align: center">
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
                                            <td colspan="4" style="vertical-align: top; position: static; height: 5px; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="vertical-align: top; position: static; height: 5px; text-align: center">
                                                &nbsp;<asp:MultiView ID="MultiView2" runat="server">
                                                    <asp:View ID="View9" runat="server"><table style="width: 100%">
                                                        <tr>
                                                            <td style="width: 100%; text-align: center">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%; text-align: center">
                                                                <table align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px; width: 60%">
                                                                    <tr>
                                                                        <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                            ADD BID RECEIPT INFORMATION</td>
                                                                    </tr>
                                                                </table>
                                                                <br />
                                                                <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                    <tr>
                                                                        <td style="vertical-align: top; width: 45%; text-align: center">
                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                <tr>
                                                                                    <td colspan="3" style="height: 9px">
                                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                            <tr>
                                                                                                <td class="InterFaceTableLeftRowUp">
                                                                                                    Deadline For Submission Date</td>
                                                                                                <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                </td>
                                                                                                <td class="InterFaceTableRightRowUp" style="color: red">
                                                                                                    <asp:TextBox ID="txtDeadline" runat="server" Width="80%"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="InterFaceTableLeftRowUp">
                                                                                                    Deadline For Submission Time</td>
                                                                                                <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                </td>
                                                                                                <td class="InterFaceTableRightRowUp" style="color: red">
                                                                                                    <asp:TextBox ID="txtDeadlineTime" runat="server" Width="80%"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="InterFaceTableLeftRowUp">
                                                                                                    Bid Receipt Method</td>
                                                                                                <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                    &nbsp;</td>
                                                                                                <td class="InterFaceTableRightRowUp">
                                                                                                    <asp:DropDownList ID="cboBidReceiptMethod" runat="server" CssClass="InterfaceDropdownList"
                                                                                                        OnDataBound="cboBidReceiptMethod_DataBound" Width="82%">
                                                                                                    </asp:DropDownList></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td style="vertical-align: top; width: 45%; color: #000000; text-align: center">
                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                            </table>
                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                <tr>
                                                                                    <td colspan="3" style="height: 9px">
                                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                            <tr>
                                                                                                <td class="InterFaceTableLeftRow" style="height: 30px">
                                                                                                    Location of Submission</td>
                                                                                                <td class="InterFaceTableMiddleRow" style="width: 2%; height: 30px">
                                                                                                </td>
                                                                                                <td class="InterFaceTableRightRow" style="width: 66%; height: 30px">
                                                                                                    <asp:TextBox ID="txtLocationOfSubmission" runat="server" autocomplete="off" Font-Bold="False"
                                                                                                        Width="80%"></asp:TextBox></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="InterFaceTableLeftRow" style="height: 30px">
                                                                                                    PDU Signatory</td>
                                                                                                <td class="InterFaceTableMiddleRow" style="width: 2%; height: 30px">
                                                                                                </td>
                                                                                                <td class="InterFaceTableRightRow" style="width: 66%; height: 30px"><asp:DropDownList ID="cboPDUSign" runat="server" CssClass="InterfaceDropdownList"
                                                                                                        OnDataBound="cboPDUSign_DataBound" Width="82%">
                                                                                                </asp:DropDownList></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="InterFaceTableLeftRow" style="height: 30px">
                                                                                                    Contracts Committee Signatory</td>
                                                                                                <td class="InterFaceTableMiddleRow" style="width: 2%; height: 30px">
                                                                                                </td>
                                                                                                <td class="InterFaceTableRightRow" style="width: 66%; height: 30px">
                                                                                                    <asp:DropDownList ID="cboContractsCommitteeSign" runat="server" CssClass="InterfaceDropdownList"
                                                                                                        OnDataBound="cboContractsCommitteeSign_DataBound" Width="82%" 
                                                                                                        >
                                                                                                </asp:DropDownList></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                                                                Enabled="True" Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtDeadline">
                                                                            </ajaxToolkit:CalendarExtender>
                                                                            <ajaxToolkit:MaskedEditExtender ID="Maskededitextender1" runat="server" DisplayMoney="None"
                                                                                ErrorTooltipEnabled="True" InputDirection="RightToLeft" Mask="99:99" MaskType="Time"
                                                                                MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                                TargetControlID="txtDeadlineTime">
                                                                            </ajaxToolkit:MaskedEditExtender>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table align="center" cellpadding="0" cellspacing="0" style="margin-top: 5px; width: 60%">
                                                                    <tr>
                                                                        <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                            ADD BID RECEIPT DETAILS</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                        <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                            <tr>
                                                                <td colspan="2" style="vertical-align: top; text-align: center">
                                                                    &nbsp;<asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="vertical-align: top; text-align: center">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="vertical-align: top; width: 45%; text-align: center">
                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                        <tr>
                                                                            <td colspan="3" style="height: 9px">
                                                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                    <tr>
                                                                                        <td class="InterFaceTableLeftRowUp">
                                                                                                                            Bidder</td>
                                                                                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                        </td>
                                                                                        <td class="InterFaceTableRightRowUp"><asp:DropDownList ID="cboBidder" runat="server" CssClass="InterfaceDropdownList"
                                                                                                        OnDataBound="cboBidder_DataBound" Width="82%">
                                                                                        </asp:DropDownList><asp:TextBox ID="txtBidder" runat="server" autocomplete="off" Font-Bold="False"
                                                                                                                                Width="80%"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="InterFaceTableLeftRowUp">
                                                                                            Bid Receipt Date</td>
                                                                                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                        </td>
                                                                                        <td class="InterFaceTableRightRowUp">
                                                                                            <asp:TextBox ID="txtBidReceiptDate" runat="server" Width="80%"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="InterFaceTableLeftRowUp">
                                                                                            Bid Receipt Time</td>
                                                                                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                        </td>
                                                                                        <td class="InterFaceTableRightRowUp" style="color: red">
                                                                                            <asp:TextBox ID="txtBidReceiptTime" runat="server" Width="80%"></asp:TextBox></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td style="vertical-align: top; width: 45%; text-align: center">
                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                    </table>
                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                        <tr>
                                                                            <td colspan="3" style="height: 9px">
                                                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                    <tr>
                                                                                        <td class="InterFaceTableLeftRow" style="height: 30px">
                                                                                            Number of Envelopes</td>
                                                                                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 30px">
                                                                                        </td>
                                                                                        <td class="InterFaceTableRightRow" style="height: 30px">
                                                                                            <asp:TextBox ID="txtNoOfEnvelopes" runat="server" Width="80%"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="InterFaceTableLeftRowUp">
                                                                                            Comments</td>
                                                                                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                        </td>
                                                                                        <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                                                            <asp:TextBox ID="txtComment" runat="server" Style="height: 19px" Width="80%"></asp:TextBox></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <ajaxToolkit:CalendarExtender ID="Calendarextender2" runat="server" CssClass="MyCalendar"
                                                                        Enabled="True" Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtBidReceiptDate">
                                                                    </ajaxToolkit:CalendarExtender>
                                                                    <ajaxToolkit:MaskedEditExtender ID="Maskededitextender3" runat="server" DisplayMoney="None"
                                                                        ErrorTooltipEnabled="True" InputDirection="RightToLeft" Mask="99:99" MaskType="Time"
                                                                        MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                        TargetControlID="txtBidReceiptTime">
                                                                    </ajaxToolkit:MaskedEditExtender>
                                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" MinimumPrefixLength="1"
                                                                                              ServiceMethod="GetBiddersByNames" UseContextKey="true" ServicePath="CascadingddlService.asmx" TargetControlID="txtBidder">
                                                                                                         </ajaxToolkit:AutoCompleteExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="vertical-align: top; text-align: center">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="vertical-align: top; text-align: center">
                                                                    <asp:Button ID="btnAdd" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                        OnClick="btnAdd_Click" Text="Add Bid Receipt Details" Width="218px" />&nbsp;&nbsp;
                                                                    <asp:Button ID="btnAddAttachments" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                        OnClick="btnAddAttachments_Click" Text="Add Attachments" Width="132px" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="vertical-align: top; text-align: center; height: 9px;">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="vertical-align: top; text-align: center">
                                                                    <asp:DataGrid ID="DataGrid2"  runat="server" AutoGenerateColumns="False" CellPadding="4"  Font-Names="Verdana" Font-Size="Small"
                                                                        ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid2_ItemCommand"
                                                                        Width="100%" style="text-align: justify">
                                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                        <EditItemStyle BackColor="#999999" />
                                                                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                        <Columns>
                                                                            <asp:BoundColumn DataField="ID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="BidderID" HeaderText="Bidder ID" Visible="False"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="BidderName" HeaderText="Name of Bidder"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="BidReceiveDate" HeaderText="Date Time of Receipt"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="NoOfEnvelopes" HeaderText="No of Envelopes"></asp:BoundColumn>
                                                                            <asp:BoundColumn DataField="Comment" HeaderText="Comments"></asp:BoundColumn>
                                                                            <asp:ButtonColumn CommandName="btnEdit" HeaderText="ACTION" Text="Edit"></asp:ButtonColumn>
                                                                            <asp:ButtonColumn CommandName="btnRemove" HeaderText="ACTION" Text="Remove">
                                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                    Font-Underline="False" ForeColor="Red" />
                                                                            </asp:ButtonColumn>
                                                                        </Columns>
                                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                                                            Font-Strikeout="False" Font-Underline="False" ForeColor="White" HorizontalAlign="Left" />
                                                                    </asp:DataGrid><asp:Label ID="lblNoRecords" runat="server" Font-Bold="True" Font-Names="Cambria"
                                                                        ForeColor="Red" Visible="False" Width="322px">NO RECORD OF BID RECEIPT TO DISPLAY</asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="vertical-align: top; text-align: center; height: 9px;">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="vertical-align: top; text-align: center"><asp:Button ID="btnSubmit" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                        OnClick="btnSubmit_Click1" Text="SUBMIT" Width="100px" Enabled="False" />
                                                                    <asp:Button ID="btnPrint" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                        OnClick="btnPrint_Click" Text="PRINT" ToolTip="Print PP Form 34  - Record of receipt of Bids"
                                                                        Width="100px" Enabled="False" />
                                                                    <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                        OnClick="btnReturn_Click" Text="CANCEL / RETURN" Width="136px" /></td>
                                                            </tr>
                                                        </table>
                                                    </asp:View>
                                                    &nbsp;&nbsp;
                                                </asp:MultiView></td>
                                        </tr>
                                    </table>
                                </asp:View>
                                &nbsp;
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
                                                                <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"--%>
                                                                    ToolPanelView="None" HasPrintButton="False" Height="50px" SeparatePages="False"
                                                                    Width="350px" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View6" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td colspan="3" style="width: 100%; height: 21px; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">
                                                BID RECEIPT ATTACHMENT(S)</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                            </td>
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
                                                            &nbsp;<asp:GridView ID="GridAttachments" runat="server" AutoGenerateColumns="False"
                                                                CssClass="gridgeneralstyle" DataKeyNames="FileID" GridLines="None" HorizontalAlign="Center"
                                                                OnRowCommand="GridAttachments_RowCommand" PageSize="15" Width="98%">
                                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                <RowStyle CssClass="gridRowStyle" />
                                                                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                                <Columns>
                                                                    <asp:ButtonField CommandName="ViewDetails" Text="View">
                                                                        <HeaderStyle CssClass="gridEditField" />
                                                                        <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                                            Width="140px" />
                                                                    </asp:ButtonField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnRemove" CommandName="btnRemove" runat="server" Text="Remove" Visible='<%# IsFileRemoveable((Int32)Eval("IsRemoveable")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="gridEditField" ForeColor="#003399" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="FileID" HeaderText="File ID" />
                                                                    <asp:BoundField DataField="FileName" HeaderText="File Name" />
                                                                    <asp:BoundField DataField="IsRemoveable" HeaderText="IsRemoveable" Visible="False" />
                                                                </Columns>
                                                                <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                                <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                            </asp:GridView>
                                                            <asp:Label ID="lblNoAttachments" runat="server" Font-Names="Cambria" Font-Size="11pt"
                                                                ForeColor="Red" Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
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
                                                <asp:Label ID="lblAttachRefNo" runat="server" Text="0" Visible="False"></asp:Label><asp:Button
                                                    ID="btnSaveFile" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                    OnClick="btnSaveFile_Click" Text="SAVE " Width="80px" />
                                                <asp:Button ID="btnAttReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                    Text="RETURN" Width="80px" OnClick="btnAttReturn_Click" /></td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>&nbsp;<br />
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







