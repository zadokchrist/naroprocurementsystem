<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Bidding_Negotiations.aspx.cs" Inherits="Bidding_Negotiations" Title="RECORD OF NEGOTIATION" %>

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
                            RECORD OF NEGOTIATION</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 21px">
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
                                            <td style="width: 100px; text-align: right; height: 9px;">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                    <tr>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            Pr number</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            PROC. METHOD</td>
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
                                            <td style="width: 100px; text-align: right; height: 9px;">
                                                </td>
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
                                                        <asp:ButtonColumn CommandName="btnAddMeeting" HeaderText="ADD" Text="Meeting"></asp:ButtonColumn>
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
                                                                ID="lblRefNo" runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblID" runat="server"
                                                                        Text="0" Visible="False"></asp:Label><asp:Label ID="lblPDCode" runat="server" Text="0"
                                                                            Visible="False"></asp:Label>
                                                <asp:Label ID="lblMeetingID" runat="server" Text="0" Visible="False"></asp:Label></td>
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
                                                    <asp:View ID="View9" runat="server">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="width: 100%; text-align: center">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%; text-align: center">
                                                                <table align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px; width: 60%">
                                                                    <tr>
                                                                        <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                            ADD NEGOTIATION DETAILS</td>
                                                                    </tr>
                                                                </table>
                                                                <br />
                                                                <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                    <tr>
                                                                        <td colspan="2" style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td colspan="2" style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="."></asp:Label></td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                            <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                                <tr>
                                                                                    <td style="vertical-align: top; width: 45%; text-align: center">
                                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                            <tr>
                                                                                                <td colspan="3">
                                                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td class="InterFaceTableLeftRowUp">
                                                                                                                Meeting Location</td>
                                                                                                            <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                                &nbsp;</td>
                                                                                                            <td class="InterFaceTableRightRowUp">
                                                                                                                <asp:TextBox ID="txtMeetingLocation" runat="server" Width="80%"></asp:TextBox></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="InterFaceTableLeftRowUp">
                                                                                                                Meeting Date</td>
                                                                                                            <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                            </td>
                                                                                                            <td class="InterFaceTableRightRowUp">
                                                                                                                <asp:TextBox ID="txtMeetingDate" runat="server" Width="50%"></asp:TextBox></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="InterFaceTableLeftRowUp">
                                                                                                                Meeting Time</td>
                                                                                                            <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                            </td>
                                                                                                            <td class="InterFaceTableRightRowUp">
                                                                                                                <asp:TextBox
                                                                                                                    ID="txtMeetingTime" runat="server" Width="28%"></asp:TextBox></td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                    <asp:Label ID="lblPreBidMeetID" runat="server" Text="0" Visible="False"></asp:Label></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        &nbsp;&nbsp;
                                                                                    </td>
                                                                                    <td style="vertical-align: top; width: 45%; color: #000000; text-align: center">
                                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                        </table>
                                                                                        <table cellpadding="0" cellspacing="0" class="style12" style="width: 95%">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 100%; height: 55px">
                                                                                                        <tr>
                                                                                                            <td class="InterFaceTableLeftRow" style="height: 50px">
                                                                                                                Reason for Meeting</td>
                                                                                                            <td class="InterFaceTableMiddleRow" style="width: 2%; height: 55px">
                                                                                                            </td>
                                                                                                            <td class="InterFaceTableRightRow" style="height: 50px">
                                                                                                                <asp:TextBox ID="txtReasonForMeeting" runat="server" autocomplete="off" Font-Bold="False"
                                                                                                                    Style="height: 55px" TextMode="MultiLine" Width="95%"></asp:TextBox></td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                    &nbsp;</td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                                                                                            Enabled="True" Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtMeetingDate">
                                                                                        </ajaxToolkit:CalendarExtender>
                                                                                        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" DisplayMoney="None"
                                                                                            ErrorTooltipEnabled="True" InputDirection="RightToLeft" Mask="99:99" MaskType="Time"
                                                                                            MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                                                                                            TargetControlID="txtMeetingTime">
                                                                                        </ajaxToolkit:MaskedEditExtender>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                                        </td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                        <asp:Button ID="btnAdd" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                                            OnClick="btnAdd_Click" Text="Add Meeting" Width="134px" /></td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td colspan="2" style="vertical-align: top; height: 19px; text-align: center">
                                                                            <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4"  Font-Names="Verdana" Font-Size="Small"
                                                                                ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid2_ItemCommand"
                                                                                Width="100%" style="text-align: justify">
                                                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                <EditItemStyle BackColor="#999999" />
                                                                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                                <Columns>
                                                                                    <asp:BoundColumn DataField="PreBidMeetingID" HeaderText="PreBidMeetingID" Visible="False" />
                                                                                    <asp:BoundColumn DataField="MeetingLocation" HeaderText="Meeting Location" />
                                                                                    <asp:BoundColumn DataField="MeetingDate" HeaderText="Meeting Date" />
                                                                                    <asp:BoundColumn DataField="ReasonForMeeting" HeaderText="Reason" />
                                                                                    <asp:BoundColumn DataField="MeetingMinutesFile" HeaderText="File" Visible="False" />
                                                                                    <asp:ButtonColumn CommandName="btnEdit" HeaderText="Edit" Text="Edit" />
                                                                                    <asp:TemplateColumn HeaderText="ADD">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton runat="server" ID="btnAddMeetingDetails" CommandName="btnAddMeetingDetails" Text="Meeting Details" Visible="<%# EnableDetailsLink(Container.DataItem) %>"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove" >
                                                                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="Red" />
                                                                                    </asp:ButtonColumn>
                                                                                </Columns>
                                                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                                                                    Font-Strikeout="False" Font-Underline="False" ForeColor="White" HorizontalAlign="Left" />
                                                                            </asp:DataGrid>
                                                                            <asp:Label ID="lblNoMeetings" runat="server" Font-Bold="True" Font-Names="Cambria"
                                                                                ForeColor="Red" Visible="False" Width="550px">NO PRE-BID MEETINGS CURRENTLY AVAILABLE</asp:Label></td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td colspan="2" style="vertical-align: top; height: 19px; text-align: center">
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td colspan="2" style="vertical-align: top; height: 19px; text-align: center">
                                                                            <asp:Button ID="btnSubmitMeeting" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                                            OnClick="btnSubmitMeeting_Click" Text="SUBMIT MEETING" ToolTip="Hide this section" Width="144px" />
                                                                            <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                                            OnClick="btnReturn_Click" Text="CANCEL / RETURN" ToolTip="Hide this section" Width="138px" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                            &nbsp;&nbsp;&nbsp; &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    </asp:View>
                                                    &nbsp;
                                                </asp:MultiView></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="vertical-align: middle; text-align: center">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="ViewMeetingDetails" runat="server"><table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center; width: 100%;">
                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                                <tr>
                                                    <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                        &gt;&gt;&gt; &nbsp;<asp:Label ID="lblPreBidMeetingHeading" runat="server" ForeColor="Firebrick"
                                                            Text="0"></asp:Label></td>
                                                </tr>
                                            </table>
                                            </td>
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
                                                        Meeting Location</td>
                                                    <td class="InterFaceTableMiddleRowUp">
                                                    </td>
                                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                        <asp:TextBox ID="txtMeetingLocation1" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                            Font-Bold="True" ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="InterFaceTableLeftRowUp">
                                                        Meeting Date</td>
                                                    <td class="InterFaceTableMiddleRowUp">
                                                        &nbsp;</td>
                                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                        <asp:TextBox ID="txtMeetingDate1" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                            Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                            <asp:Label ID="lblPreBidMeetingID" runat="server" Text="0" Visible="False"></asp:Label></td>
                                        <td colspan="4" style="vertical-align: top; width: 50%; text-align: center">
                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                <tr>
                                                    <td class="InterFaceTableLeftRow">
                                                        Reason For Meeting</td>
                                                    <td class="InterFaceTableMiddleRow">
                                                    </td>
                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 65px">
                                                        <asp:TextBox ID="txtReasonForMeeting1" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxMultiline"
                                                            Font-Bold="True" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
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
                                            &nbsp;<asp:MultiView ID="MultiView3" runat="server">
                                                <asp:View ID="View7" runat="server">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="width: 100%; text-align: center">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%; text-align: center">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%; text-align: center">
                                                                <asp:Button ID="btnPreBidMeetingDetails" runat="server" OnClick="btnPreBidMeetingDetails_Click"
                                                                    Text="Add/Edit Pre-Bid Meeting Questions" /><asp:Button ID="btnPreBidMeetingAttendence"
                                                                        runat="server" OnClick="btnPreBidMeetingAttendence_Click" Text="Add/Edit Attendence" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%; text-align: center">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                
                                                </asp:View>
                                                <asp:View ID="View6" runat="server">
                                                    <table style="width: 100%"><tr>
                                                        <td style="width: 100%; text-align: center">
                                                            <table align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px; width: 60%">
                                                                <tr>
                                                                    <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                        ADD RECORD OF PRE-BID MEETING [PP Form 33 Part 1]</td>
                                                                    </tr>
                                                                </table>
                                                                <br />
                                                                <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                    <tr>
                                                                        <td colspan="2" style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td colspan="2" style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                            <asp:Label ID="lblMsg2" runat="server" ForeColor="Red" Text="."></asp:Label></td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                            <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                                <tr>
                                                                                    <td style="vertical-align: top; width: 45%; text-align: center">
                                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                            <tr>
                                                                                                <td colspan="3">
                                                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td class="InterFaceTableLeftRowUp">
                                                                                                                Question Asked</td>
                                                                                                            <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                                &nbsp;</td>
                                                                                                            <td class="InterFaceTableRightRowUp">
                                                                                                                <asp:TextBox ID="txtQuestionAsked" runat="server" autocomplete="off" Font-Bold="False"
                                                                                                                    Style="height: 55px" TextMode="MultiLine" Width="95%"></asp:TextBox></td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <asp:Label ID="lblIDQ" runat="server" Text="0" Visible="False"></asp:Label>
                                                                                        &nbsp;
                                                                                        <asp:Label ID="lblPreBidMeetingIDQ" runat="server" Text="0" Visible="False"></asp:Label></td>
                                                                                    <td style="vertical-align: top; width: 45%; color: #000000; text-align: center">
                                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                        </table>
                                                                                        <table cellpadding="0" cellspacing="0" class="style12" style="width: 95%">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 100%; height: 55px">
                                                                                                        <tr>
                                                                                                            <td class="InterFaceTableLeftRow" style="height: 50px">
                                                                                                                Response Given</td>
                                                                                                            <td class="InterFaceTableMiddleRow" style="width: 2%; height: 55px">
                                                                                                            </td>
                                                                                                            <td class="InterFaceTableRightRow" style="height: 50px">
                                                                                                                <asp:TextBox style="height: 55px;" autocomplete="off" Font-Bold="False" ID="txtResponseGiven" runat="server" TextMode="MultiLine" Width="95%"></asp:TextBox></td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                    &nbsp;</td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                            <asp:Button ID="btnAddQuestionResponse" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" Text="Add Question and Response" Width="214px" OnClick="btnAddQuestionResponse_Click" /></td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td colspan="2" style="vertical-align: top; height: 19px; text-align: center">
                                                                            <asp:DataGrid ID="DataGrid4" runat="server" AutoGenerateColumns="False" CellPadding="4"  Font-Names="Verdana" Font-Size="Small"
                                                                                ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid4_ItemCommand"
                                                                                Width="100%" style="text-align: justify">
                                                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                <EditItemStyle BackColor="#999999" />
                                                                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                                                                                <Columns>
                                                                                    <asp:BoundColumn DataField="ID" HeaderText="ID" Visible="False" />
                                                                                    <asp:BoundColumn DataField="PreBidMeetingID" HeaderText="PreBidMeetingID" Visible="False" />
                                                                                    <asp:BoundColumn DataField="Question" HeaderText="Question Asked" />
                                                                                    <asp:BoundColumn DataField="Answer" HeaderText="Response Given" />
                                                                                    <asp:ButtonColumn CommandName="btnEdit" HeaderText="Edit" Text="Edit" />
                                                                                    <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove" >
                                                                                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                            Font-Underline="False" ForeColor="Red" />
                                                                                    </asp:ButtonColumn>
                                                                                </Columns>
                                                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                                                                    Font-Strikeout="False" Font-Underline="False" ForeColor="White" HorizontalAlign="Left" />
                                                                            </asp:DataGrid>
                                                                            <asp:Label ID="lblNoQuestions" runat="server" Font-Bold="True" Font-Names="Cambria" ForeColor="Red"
                                                                                Visible="False" Width="70%">NO PRE-BID MEETING QUESTION(S) AND ANSWER(S) CURRENTLY AVAILABLE</asp:Label></td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td colspan="2" style="vertical-align: top; height: 19px; text-align: center">
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td colspan="2" style="vertical-align: top; height: 19px; text-align: center">
                                                                            <asp:Button ID="btnSubmitQuestion" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                                            OnClick="btnSubmitQuestion_Click" Text="SUBMIT QUESTION AND RESPONSE" ToolTip="Hide this section" Width="236px" />
                                                                            <asp:Button ID="btnPrintQn" runat="server" Font-Bold="True" OnClick="btnPrintQn_Click"
                                                                                Text="PRINT" Width="68px" />
                                                                            <asp:Button ID="btnCancelQuestion" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" Text="CANCEL" ToolTip="Hide this section" Width="120px" OnClick="btnCancelQuestion_Click" /></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:View>
                                                <asp:View ID="View4" runat="server">
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
                                                                <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                    OnClick="btnReturn_Click" Text="RETURN" Width="80px" /></td>
                                                        </tr>
                                                    </table>
                                                </asp:View>
                                                &nbsp;
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                            </asp:MultiView></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="vertical-align: middle; text-align: center">
                                        </td>
                                    </tr>
                                </table>
                                    
                                </asp:View>
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
                                                               <%-- <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
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







