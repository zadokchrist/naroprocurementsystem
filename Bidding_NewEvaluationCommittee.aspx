<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Bidding_NewEvaluationCommittee.aspx.cs" Inherits="NewEvaluationCommittee" Title="SELECTION OF EVALUATION COMMITTEE MEMBERS" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="System.Threading" %>
<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


     <%--<ajaxToolkit:ToolkitScriptManager  ID="ScriptManager1" runat="server">
                </ajaxToolkit:ToolkitScriptManager>--%>
                   <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>

    <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td style="text-align: center; vertical-align: middle">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 70%">
                    <tr>
                        <td class="InterfaceHeaderLabel" style="height: 20px">SELECTION OF EVALUATION COMMITTEE MEMBERS</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="ddcolortabsline2" style="height: 12px">
            </td>
        </tr>
        </table>
                <table cellpadding="0" cellspacing="0" class="style12">
                    <tr>
                        <td style="width: 50%; vertical-align: middle; text-align: center; height: 37px;">
                <table align ="center" cellpadding="0" cellspacing="0" style="width: 60%">
                    <tr>
                        <td class="InterfaceHeaderLabel3">
                            PROCUREMENT DESCRIPTION</td>
                    </tr>
                </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle; width: 50%; height: 5px; text-align: center">
                        </td>
                    </tr>
                </table>
            <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td class="InterfaceItemSeparator2" style="height: 2px">
                &nbsp;</td>
                
        </tr>
        <tr>
            <td>
                <table align ="center" cellpadding="0" cellspacing="0" class="style12">
                    <tr>
                        <td style="text-align: center; vertical-align: top; width: 50%; height: 121px;">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Reference Number</td>
                                    <td class="InterFaceTableMiddleRowUp">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtPRNumber" runat="server"
                                            BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                            ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Procurement Type</td>
                                    <td class="InterFaceTableMiddleRowUp">
                                        &nbsp;</td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtProcType" runat="server"
                                            BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                            ReadOnly="True" Width="90%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                        Estimated Cost</td>
                                    <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="height: 30px">
                                        <asp:TextBox ID="txtEstimatedCost" runat="server"
                                            BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                            ReadOnly="True" Width="90%"></asp:TextBox></td>
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
                                        <asp:TextBox ID="txtDateRequisitioned" runat="server"
                                            BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                            ReadOnly="True" Width="90%"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td style="text-align: center; vertical-align: top; width: 50%; height: 121px;">
                            <table align ="center" cellpadding="0" cellspacing="0" style="width: 95%">
                              
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
                                    <td class="InterFaceTableRightRow" style="height: 65px; width: 66%;">
                                        <asp:TextBox ID="txtProcSubject" runat="server"
                                            BorderStyle="Solid" CssClass="InterfaceTextboxMultiline" Font-Bold="True" ReadOnly="True"
                                            TextMode="MultiLine"></asp:TextBox></td>
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
                                        <asp:TextBox ID="txtBudgetCostCenter" runat="server"
                                            BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                            ReadOnly="True" Width="90%"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; width: 50%; text-align: center">
                        </td>
                        <td style="vertical-align: top; width: 50%; text-align: center">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: center;">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center; margin-top: 0px; margin-bottom: 0px; padding-bottom: 0px; padding-top: 0px;">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 60%; padding-bottom: 0px; padding-top: 0px;">
                                        <tr>
                                            <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                EVALUATION COMMITTEE INFORMATION</td>
                                        </tr>
                                    </table>
                                    </td>
                            </tr>
                            <tr>
                            <td style="vertical-align: top; width: 50%; height: 5px; text-align: center">
                            </td>
                            <td style="vertical-align: top; width: 50%; height: 5px; text-align: center">
                            </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                        <tr>
                                            <td colspan="1" style="vertical-align: top; height: 9px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" style="vertical-align: top; height: 41px">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td class="InterfaceHeaderLabel" style="height: 20px">
                                                            <asp:Label ID="lblAddEditItemHeader" runat="server" Text="ADD MEMBER TO COMMITTEE"></asp:Label><br />
                                                            <asp:Label ID="Label1" runat="server" ForeColor="#C04000" Text="  ( REQUIRE A MINIMUM OF FOUR (4) EVALUATION COMMITTEE MEMBERS )"></asp:Label></td>
                                                    </tr>
                                                </table>
                                                <table width="100%">
                                                    <tr>
                                                        <td colspan="3" valign="top">
                                                            <asp:Label ID="lblMsg" runat="server" Font-Bold="False" Font-Names="Cambria"
                                                                Font-Size="11pt" ForeColor="Red" Text="."></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 48%" valign="top">
                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                <tr>
                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                                                        Member</td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                                                                    </td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                            <asp:TextBox ID="txtMember" runat="server" autocomplete="off" Width="80%"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                                                        Position</td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                                                                    </td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                        <asp:TextBox ID="txtPosition" runat="server" Width="80%"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                                                        Department</td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                                                                    </td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                        <asp:TextBox ID="txtDepartment" runat="server" Width="80%"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                            <asp:Label ID="lblECMemberID" runat="server" Visible="False">0</asp:Label>
                                                            <asp:Label ID="lblCreatedBy" runat="server" Text="0" Visible="False"></asp:Label>
                                                            <asp:Label ID="lblStatusID" runat="server" Text="0" Visible="False"></asp:Label></td>
                                                        <td style="width: 2%">
                                                        </td>
                                                        <td style="width: 48%" valign="top">
                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                <tr style="color: #000000">
                                                                    <td class="InterFaceTableLeftRow" valign="top">
                                                            Reason for Selection</td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%;">
                                                                    </td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%;">
                                                                        <asp:DropDownList ID="cboReason" runat="server" AutoPostBack="True"
                                                                OnDataBound="cboReason_DataBound" OnSelectedIndexChanged="cboReason_SelectedIndexChanged"
                                                                Width="82%">
                                                            </asp:DropDownList><br />
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                                                                      <ContentTemplate>
                                                                        <asp:TextBox ID="txtReason" runat="server" CssClass="InterfaceTextboxMultiline" Height="12px"
                                                                            Style="width: 90%; height: 55px" TextMode="MultiLine" Visible="False" Width="70%"></asp:TextBox></td>
                                                                </ContentTemplate>
                                                                            <Triggers>
                                                              <asp:AsyncPostbackTrigger ControlID="cboReason" EventName="SelectedIndexChanged"  />
                                                           </Triggers>
                                                        </asp:UpdatePanel>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1"
                                                                ServiceMethod="GetProfilesByNames" ServicePath="CascadingddlService.asmx" TargetControlID="txtMember">
                                                            </ajaxToolkit:AutoCompleteExtender>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" style="vertical-align: top">
                                                <asp:Button ID="btnAddMember" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                Text="Add Member" Width="164px" OnClick="btnAddMember_Click"  />
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 68%">
                                        <tr>
                                            <td class="InterfaceHeaderLabel" style="height: 20px">
                                                SELECTED EVALUATION COMMITTEE MEMBERS</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                    <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" HorizontalAlign="Center"
                                        OnItemCommand="DataGrid2_ItemCommand" Width="100%">
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <EditItemStyle BackColor="#999999" />
                                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:BoundColumn DataField="ECMemberID" HeaderText="ECMemberID" Visible="False"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="UserID" HeaderText="UserID" Visible="False"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ECMember" HeaderText="EC Member"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="Position" HeaderText="Position"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="Department" HeaderText="Department"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ReasonID" HeaderText="ReasonID" Visible="False"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="Reason" HeaderText="Reason"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="OtherReason" HeaderText="OtherReason" Visible="False"></asp:BoundColumn>
                                            <asp:ButtonColumn CommandName="btnEdit" HeaderText="Edit" Text="Edit"></asp:ButtonColumn>
                                            <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove">
                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False" ForeColor="Red" />
                                            </asp:ButtonColumn>
                                        </Columns>
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                    </asp:DataGrid></td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; width: 50%; height: 5px; text-align: center">
                                </td>
                                <td style="vertical-align: top; width: 50%; height: 5px; text-align: center">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="vertical-align: middle; height: 22px; text-align: center"><asp:Button ID="btnSubmit" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                Text="Submit" Width="100px" OnClick="btnSubmit_Click"  />
                                    &nbsp;<asp:Button ID="btnPrint" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                Text="Print" Width="100px" OnClick="btnPrint_Click" ToolTip="Print Bidder Shortlist"  />
                                    <asp:Button ID="btnCancel" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                Text="Cancel" Width="100px" OnClick="btnCancel_Click"  /></td>
                            </tr>
                        </table>
                                    <asp:Panel ID="Panel1" runat="server" Style="width: 100%" Visible="False">
                                        <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid;
                                            border-left: #617da6 1px solid; width: 98%; border-bottom: #617da6 1px solid">
                                            <tbody>
                                                <tr>
                                                    <td style="vertical-align: top; width: 96%; text-align: center">
                                                        <%--<cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"
                                                            ToolPanelView="None" hasprintbutton="False" height="50px" separatepages="False"
                                                            width="350px" BestFitPage="False"></cr:crystalreportviewer>--%>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </asp:Panel>
                        &nbsp;
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table id="Table2"  style="width: 100%">
                            <tr>
                                <td style="width: 100%; height: 21px; text-align: right">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%; text-align: center">
                                    <asp:Label ID="lblDone" ForeColor="red" runat="server"></asp:Label>
                                    <asp:Label ID="lblprocmethod" Visible="false" ForeColor="Red" runat="server"></asp:Label>
                                    <asp:Label ID="lblproctype" Visible="false" ForeColor="Red" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 100%; height: 21px; text-align: right">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%; text-align: center">
                                    <asp:Button ID="btnPrint2" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                Text="Print" Width="100px" OnClick="btnPrint_Click" ToolTip="Print Bidder Shortlist"  />
                                    <asp:Button ID="btnGoBack" runat="server" Font-Bold="True" OnClick="btnGoBack_Click"
                                        Text="Return to Procurements" /></td>
                            </tr>
                            <tr>
                                <td style="width: 100%; text-align: right">
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    &nbsp; &nbsp; &nbsp;&nbsp;
                </asp:MultiView></td>
        </tr>
                <tr>
                    <td style="height: 19px">
                        &nbsp;<asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label>&nbsp;
                        <asp:Label ID="lblQuestionCount" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblReqCode" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblPlanCode" runat="server" Text="0" Visible="False"></asp:Label></td>
                </tr>
    </table>

</asp:Content>

