<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Bidding_CCEvaluationReportApproval.aspx.cs" Inherits="Bidding_CCEvaluationReportApproval" Title="PENDING PROCUREMENT(S) FOR CC EVALUATION APPROVALS" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td class="InterfaceItemSeparator2" style="height: 2px">
                < <%--      <ajaxToolkit:ToolkitScriptManager  ID="ScriptManager1" runat="server">
                </ajaxToolkit:ToolkitScriptManager>--%>
                   <asp:ScriptManager ID="ScriptManager1" AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
            </td>
        </tr>
        <tr>
            <td style="height: 39px">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 70%">
                    <tr>
                        <td class="InterfaceHeaderLabel3" style="height: 18px">
                            PROCUREMENT(S) SUBMITTED TO CONTRACTS COMMITTEE (
                                                <asp:Label ID="lblCC" runat="server"></asp:Label>
                            ) FOR EVALUATION APPROVAL</td>
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
                                            <td style="width: 100px; height: 9px;">
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
                            PROC. OFFICER</td>
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
                        <td class="ddcolortabsline2" colspan="6" style="vertical-align: middle; text-align: center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            &nbsp;<asp:TextBox ID="txtPrNumber" runat="server" Width="85%"></asp:TextBox></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:DropDownList ID="cboProcurementOfficer" runat="server" CssClass="InterfaceDropdownList"
                                OnDataBound="cboProcurementOfficer_DataBound" Width="85%">
                            </asp:DropDownList></td>
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
                                            <td style="width: 100px; height: 9px;">
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
                                                        <asp:ButtonColumn CommandName="btnViewDetails" HeaderText="ACTION" Text="Approve/Reject"></asp:ButtonColumn>
                                                        <asp:BoundColumn DataField="StatusID" HeaderText="StatusID" Visible = "false"></asp:BoundColumn>
                                                        <asp:TemplateColumn HeaderText="STAGE">
                                                            <ItemTemplate>
                                                                <asp:Label runat="server" ID="Status" Text="<%# EnableFindStatus(Container.DataItem) %>" Visible = "true"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                </asp:DataGrid></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%;">
                                                <asp:Label ID="lblEmpty" runat="server" Font-Bold="True" ForeColor="Red" Text="."></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
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
                                                                    runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblStatusID" runat="server"
                                                                        Text="0" Visible="False"></asp:Label><asp:Label ID="lblPDCode" runat="server" Text="0"
                                                                            Visible="False"></asp:Label>
                                                <asp:Label ID="lblSection" runat="server" Text="0" Visible="False"></asp:Label></td>
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
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%; text-align: center">
                                                <asp:Button ID="btnFormDetails" runat="server" Text="View Form Details" OnClick="btnFormDetails_Click" />
                                                                <asp:Button ID="btnViewEvalReport" runat="server" Text="View Evaluation Report" OnClick="btnViewEvalReport_Click" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100%; text-align: center">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    </asp:View>
                                                    <asp:View ID="View6" runat="server">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%; text-align: center"><table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid;
                                                                margin-top: 10px; border-left: #617da6 1px solid; width: 98%; border-bottom: #617da6 1px solid">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <table align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px; width: 95%">
                                                                    <tr>
                                                                        <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                            Form Details</td>
                                                                    </tr>
                                                                </table>
                                                                &nbsp;<asp:GridView ID="dgvFormDetails" runat="server" CssClass="gridgeneralstyle" EmptyDataText="NO QUESTION HAS BEEN ANSWERED YET" GridLines="None"
                                                                                HorizontalAlign="Center" OnRowCommand="dgvFormDetails_RowCommand" PageSize="1"
                                                                                Style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid; border-left: #dcdcdc thin solid;
                                                                                border-bottom: #dcdcdc thin solid" Width="95%" AutoGenerateColumns="False" DataKeyNames="Section">
                                                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                    <RowStyle CssClass="gridRowStyle" />
                                                                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                                    <Columns>
                                                                        <asp:ButtonField CommandName="btnView" HeaderText="VIEW" Text="Section Details" />
                                                                        <asp:BoundField DataField="ReferenceNo" HeaderText="ReferenceNo" Visible="False" />
                                                                        <asp:BoundField DataField="ProcurementMethodCode" HeaderText="ProcMethod" Visible="False" />
                                                                        <asp:BoundField DataField="Section" HeaderText="Section" Visible="False" />
                                                                        <asp:BoundField DataField="Narration" HeaderText="SECTION" />
                                                                        <asp:BoundField DataField="NumAnswered" HeaderText="QUESTIONS ANSWERED" />
                                                                    </Columns>
                                                                    <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                                    <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%; text-align: center">
                                                            <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid;
                                                                margin-top: 10px; border-left: #617da6 1px solid; width: 98%; border-bottom: #617da6 1px solid">
                                                                <tbody>
                                                                    <tr>
                                                                        <td>
                                                                            <table align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px; width: 95%">
                                                                                <tr>
                                                                                    <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                                        Answered Questions</td>
                                                                                </tr>
                                                                            </table>
                                                                            &nbsp;<asp:GridView ID="dgvQuestions" runat="server" CssClass="gridgeneralstyle"
                                                                                DataKeyNames="Id" EmptyDataText="NO QUESTION HAS BEEN ANSWERED YET" GridLines="None"
                                                                                HorizontalAlign="Center" PageSize="1"
                                                                                Style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid; border-left: #dcdcdc thin solid;
                                                                                border-bottom: #dcdcdc thin solid" Width="95%">
                                                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                                <RowStyle CssClass="gridRowStyle" />
                                                                                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                                                <Columns>
                                                                                    <asp:ButtonField CommandName="btnEdit" Text="Edit Answer" Visible="False">
                                                                                        <HeaderStyle CssClass="gridEditField" />
                                                                                        <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Left"
                                                                                            Width="180px" />
                                                                                    </asp:ButtonField>
                                                                                </Columns>
                                                                                <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                                                <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%; text-align: center">
                                                                    &nbsp;<asp:Button ID="btnPrint" runat="server" Font-Bold="True" Font-Size="9pt"
                                                                Height="23px" OnClick="btnPrint_Click" Text="PRINT" Width="120px" />
                                                                                <asp:Button ID="btnDone" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                OnClick="btnDone_Click" Text="HIDE" ToolTip="Return to List of Procurements"
                                                                Width="120px" /></td>
                                                            </tr>
                                                        </table>
                                                    </asp:View>
                                                    &nbsp;<asp:View ID="View4" runat="server">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td colspan="1" style="width: 100%; height: 21px; text-align: center">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="InterFaceTableLeftRowUp" colspan="1" style="width: 100%; text-align: center">
                                                                    EVALUATION REPORT</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="1">
                                                                </td>
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
                                                                <td colspan="1" style="vertical-align: top; width: 100%; text-align: center">
                                                                    <asp:Label ID="lblAttachRefNo" runat="server" Text="0" Visible="False"></asp:Label>
                                                                    <asp:Button ID="btnAttReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                        OnClick="btnAttReturn_Click" Text="HIDE" Width="80px" /></td>
                                                            </tr>
                                                        </table>
                                                    </asp:View>
                                                </asp:MultiView></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="vertical-align: top; position: static; height: 5px; text-align: center">
                                                <asp:DataGrid ID="DataGrid7" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" Style="text-align: justify"
                                                    Width="100%">
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <EditItemStyle BackColor="#999999" />
                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="RecordID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="BidderID" HeaderText="Bidder ID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="BidderName" HeaderText="Bidder Name"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="IsBEB" HeaderText="IsBEB"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="BidUnitID" HeaderText="BidUnitID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Unit" HeaderText="Currency"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="BidValue" DataFormatString="{0:N0}" HeaderText="Bid Amount">
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Reason" HeaderText="Reason"></asp:BoundColumn>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                                        Font-Strikeout="False" Font-Underline="False" ForeColor="White" HorizontalAlign="Left" />
                                                </asp:DataGrid><asp:DataGrid ID="DataGrid8" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None"
                                                    Style="text-align: justify" Width="100%">
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <EditItemStyle BackColor="#999999" />
                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="RecordID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="BidderID" HeaderText="Bidder ID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="BidderName" HeaderText="Bidder Name"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="IsBEB" HeaderText="IsBEB"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="LottID" HeaderText="Lott ID" Visible="false"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="LottNumber" HeaderText="Lott No."></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="LottDescription" HeaderText="Lott Description"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="BidUnitID" HeaderText="BidUnitID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Unit" HeaderText="Currency"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="BidValue" DataFormatString="{0:N0}" HeaderText="Bid Amount">
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Reason" HeaderText="Reason"></asp:BoundColumn>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                                        Font-Strikeout="False" Font-Underline="False" ForeColor="White" HorizontalAlign="Left" />
                                                </asp:DataGrid><asp:Label ID="lblNoRecords" runat="server" Font-Bold="True" Font-Names="Cambria"
                                                    ForeColor="Red" Visible="False" Width="550px">NO EVALUATION DETAILS CURRENTLY AVAILABLE</asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="vertical-align: top; position: static; height: 5px; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="vertical-align: top; position: static; height: 5px; text-align: center">
                                                <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                    <tr>
                                                        <td colspan="2" style="vertical-align: top; height: 42px; text-align: center">
                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                                                <tr>
                                                                    <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                        Approve/Reject &nbsp;Procurement (Proc. Method, Shortlisted Bidders and EC)</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top; width: 50%; text-align: center">
                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                <tr>
                                                                    <td class="InterFaceTableLeftRowUp">
                                                                        CC Meeting Ref No.</td>
                                                                    <td class="InterFaceTableMiddleRowUp">
                                                                    </td>
                                                                    <td class="InterFaceTableRightRowUp">
                                                                        <asp:TextBox ID="txtCCRefNo" runat="server" Width="85%"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="InterFaceTableLeftRowUp">
                                                                        Select Option</td>
                                                                    <td class="InterFaceTableMiddleRowUp">
                                                                        &nbsp;</td>
                                                                    <td class="InterFaceTableRightRowUp">
                                                                        <asp:RadioButtonList ID="rbnApproval" runat="server" CssClass="InterfaceDropdownList" OnSelectedIndexChanged="rbnApproval_SelectedIndexChanged" >
                                                                        </asp:RadioButtonList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="InterFaceTableLeftRowUp">
                                                                        <asp:Label ID="lblApprovals" runat="server" Text="Approve" Visible="False"></asp:Label></td>
                                                                    <td class="InterFaceTableMiddleRowUp">
                                                                    </td>
                                                                    <td class="InterFaceTableRightRowUp">
                                                                        <asp:RadioButtonList ID="rbnSubmission" runat="server" Visible="False" CssClass="InterfaceDropdownList" AutoPostBack="True">
                                                                        </asp:RadioButtonList></td>
                                                                </tr>
                                                            </table>
                                                        </td>
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
                                                            <table align="center" cellpadding="0" cellspacing="0" style="border-right: #a4a2ca 1px solid;
                                                                border-top: #a4a2ca 1px solid; border-left: #a4a2ca 1px solid; width: 90%; border-bottom: #a4a2ca 1px solid;
                                                                background-color: #ffffff">
                                                                <tr>
                                                                    <td style="height: 19px">
                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                            <tr>
                                                                                <td class="InterfaceHeaderLabel3" style="height: 18px">
                                                                                    CC Meeting Minutes</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
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
                                                    <tr>
                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                            &nbsp;<asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="SUBMIT" />
                                                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="CANCEL" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="vertical-align: middle; height: 22px; text-align: center">
                                            </td>
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







