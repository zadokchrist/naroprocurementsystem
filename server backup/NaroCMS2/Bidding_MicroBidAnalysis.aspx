<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Bidding_MicroBidAnalysis.aspx.cs" Inherits="Bidding_MicroBidAnalysis" Title="MICRO PROCUREMENT - BID ANALYSIS" %>

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
                            MICRO PROCUREMENTS - BID ANALYSIS</td>
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
                            AREA</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            Cost CENTER</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                        </td>
                    </tr>
                    <tr>
                        <td class="ddcolortabsline2" colspan="4" style="vertical-align: middle; text-align: center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            &nbsp;<asp:TextBox ID="txtPrNumber" runat="server" Width="85%"></asp:TextBox></td>
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
                            <asp:DropDownList ID="cbostatus" runat="server" CssClass="InterfaceDropdownList"
                               Width="95%">
                     <asp:ListItem Value="0">-- Select Status --</asp:ListItem>
                     <asp:ListItem Value="91">Pending Submission</asp:ListItem>
                     
                     <asp:ListItem Value="95">Rejected By  Head Of Department</asp:ListItem>
                     <asp:ListItem Value="99">Rejected By Contracts Committee</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Height="23px" OnClick="btnOK_Click"
                                Text="Search" Width="85px" />&nbsp;</td>
                                
                    </tr>
                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
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
                                                        <asp:BoundColumn DataField="StatusID" HeaderText="StatusID" Visible="false"> </asp:BoundColumn>
                                                         <asp:TemplateColumn HeaderText="Comment"><ItemTemplate><asp:TextBox ID="txtbxComment" Width="300px" runat="server" Text = "<%# ViewComment(Container.DataItem) %>" Visible="<%# DisableViewComment(Container.DataItem) %>" Enabled = "false" TextMode="MultiLine"></asp:TextBox></ItemTemplate></asp:TemplateColumn> 
                                                        <asp:ButtonColumn CommandName="btnPrintPDO2" HeaderText="PRINT" Text="PD 02"></asp:ButtonColumn>
                                                         <asp:TemplateColumn HeaderText="ACTION"><ItemTemplate><asp:LinkButton runat="server" ID="btnAddBidAnalysis" CommandName="btnAddBidAnalysis" Text="Bid Analysis" Visible="<%# Disable(Container.DataItem) %>"></asp:LinkButton></ItemTemplate></asp:TemplateColumn>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                </asp:DataGrid></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:Label ID="lblEmpty" runat="server" Font-Bold="True" ForeColor="Red" Text="."></asp:Label></td>
                                                <asp:Label ID="lblstatus" runat="server" Text="0" Visible="false"></asp:Label>
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
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 19px">
                                                            &nbsp;<asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label>&nbsp;
                                                            <asp:Label ID="lblQuestionCount" runat="server" Text="0" Visible="False"></asp:Label>
                                                            <asp:Label ID="lblReqCode" runat="server" Text="0" Visible="False"></asp:Label>
                                                            <asp:Label ID="lblPlanCode" runat="server" Text="0" Visible="False"></asp:Label></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                <TABLE style="WIDTH: 100%"><TBODY>
                                    <tr>
                                        <td style="width: 98%">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">
                                                ATTACH BID ANALYSIS SHEET AND BIDS</td>
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
                                                            <asp:GridView ID="GridAttachments" runat="server" AutoGenerateColumns="false" CssClass="gridgeneralstyle"
                                                                DataKeyNames="FileID" GridLines="None" HorizontalAlign="Center" OnRowCommand="GridAttachments_RowCommand"
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
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnRemove" CommandArgument='<%# Eval("FileID") %>' CommandName="Remove" runat="server" Text="Remove" Visible='<%# IsFileRemoveable((Int32)Eval("IsRemoveable")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="gridEditField" ForeColor="#003399" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="FileID" HeaderText="FileID" />
                                                                    <asp:BoundField DataField="FileName" HeaderText="FileName" />
                                                                    <asp:BoundField DataField="IsRemoveable" HeaderText="IsRemoveable" Visible="false" />
                                                                </Columns>
                                                                <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                                <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            &nbsp;<asp:Label ID="lblNoAttachments" runat="server" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red"
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
                                                <asp:Label ID="lblAttachRefNo" runat="server" Text="0" Visible="False"></asp:Label><asp:Button
                                                    ID="btnSaveFile" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                    OnClick="btnSaveFile_Click" Text="SAVE " Width="80px" />
                                                <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                    OnClick="btnReturn_Click" Text="RETURN" Width="80px" /></td>
                                        </tr>
                                    </table>
                                        </td>
                                    </tr>
                                    <TR><TD style="WIDTH: 98%"></TD></TR><TR><TD style="WIDTH: 98%"><TABLE class="style12" cellSpacing=0 cellPadding=0 align=center><TBODY><TR><TD style="VERTICAL-ALIGN: top; HEIGHT: 42px; TEXT-ALIGN: center" colSpan=2><TABLE style="WIDTH: 60%" cellSpacing=0 cellPadding=0 align=center><TBODY><TR><TD style="HEIGHT: 17px" class="InterfaceHeaderLabel3">Submit Micro &nbsp;Procurement For Approval</TD></TR></TBODY></TABLE></TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 50%; TEXT-ALIGN: center"><TABLE style="WIDTH: 95%" cellSpacing=0 cellPadding=0 align=center><TBODY><TR><TD class="InterFaceTableLeftRowUp">Head of Department</TD><TD class="InterFaceTableMiddleRowUp"></TD><TD class="InterFaceTableRightRowUp"><asp:TextBox id="txtHOS" runat="server" autocomplete="off" Font-Bold="True" Width="80%"></asp:TextBox></TD></TR><TR><TD class="InterFaceTableLeftRowUp">Recommended Bidder</TD><TD class="InterFaceTableMiddleRowUp"></TD><TD class="InterFaceTableRightRowUp">
                                        <asp:DropDownList ID="cboBidder" runat="server" OnDataBound="cboBidder_DataBound"
                                            Width="82%">
                                        </asp:DropDownList></TD></TR>
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp">
                                                Currency</td>
                                            <td class="InterFaceTableMiddleRowUp">
                                            </td>
                                            <td class="InterFaceTableRightRowUp">
                                                <asp:DropDownList ID="cboCurrency" runat="server" CssClass="InterfaceDropdownList"
                                                    OnDataBound="cboCurrency_DataBound" Width="82%">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <TR><TD class="InterFaceTableLeftRowUp">Final Amount</TD><TD class="InterFaceTableMiddleRowUp"></TD><TD class="InterFaceTableRightRowUp"><asp:TextBox id="txtAmount" runat="server" onkeyup="javascript:this.value=Comma(this.value);" Font-Bold="True" Width="80%"></asp:TextBox></TD></TR></TBODY></TABLE><cc1:AutoCompleteExtender id="AutoCompleteExtender1" runat="server" TargetControlID="txtHOS" ServicePath="CascadingddlService.asmx" ServiceMethod="GetUsersByNames" MinimumPrefixLength="1">
                                                                                            </cc1:AutoCompleteExtender>
                                        &nbsp;
                                    </TD><TD style="VERTICAL-ALIGN: top; WIDTH: 50%; TEXT-ALIGN: center"><TABLE style="WIDTH: 95%" cellSpacing=0 cellPadding=0 align=center><TBODY></TBODY></TABLE><TABLE style="WIDTH: 95%" cellSpacing=0 cellPadding=0 align=center><TBODY><TR><TD style="HEIGHT: 30px" class="InterFaceTableLeftRowUp">Comment (If Required)</TD><TD style="HEIGHT: 30px" class="InterFaceTableMiddleRowUp">&nbsp;</TD><TD style="HEIGHT: 30px" class="InterFaceTableRightRowUp"><asp:TextBox id="txtComment" runat="server" Height="80px" CssClass="InterfaceTextboxMultiline" TextMode="MultiLine"></asp:TextBox></TD></TR></TBODY></TABLE>
                                        <cc1:FilteredTextBoxExtender ID="FTEAmount" runat="server" FilterType="Custom,Numbers"
                                            TargetControlID="txtAmount" ValidChars=",">
                                        </cc1:FilteredTextBoxExtender>
                                    </TD></TR><TR><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: center" colSpan=2></TD></TR><TR><TD style="VERTICAL-ALIGN: top; TEXT-ALIGN: center" colSpan=2>&nbsp;<asp:Button id="btnSubmitToHOS" onclick="btnSubmitToHOS_Click" runat="server" Text="SUBMIT" Font-Bold="True"></asp:Button> <asp:Button id="btnCancelSubmit" onclick="btnCancel_Click" runat="server" Text="CANCEL" Font-Bold="True"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
                                </asp:View>
                                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
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
   
    function Comma(Num)
    {
       Num += '';
       Num = Num.replace(',' , '');Num = Num.replace(',' , '');Num = Num.replace(',' , '');
       Num = Num.replace(',' , '');Num = Num.replace(',' , '');Num = Num.replace(',' , '');
       x = Num.split('.');
       x1 = x[0];
       x2 = x.length > 1 ? '.' + x[1] : '';
       var rgx = /(\d+)(\d{3})/;
       while (rgx.test(x1))
       x1 = x1.replace(rgx, '$1' + ',' + '$2');
       return x1 + x2;
    }
    
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







