<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Bidding_SolicitBidders.aspx.cs" Inherits="Bidding_SolicitBidders" Title="RECORD ISSUE OF SOLICITATION DOCUMENTS" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
                            ADD ISSUE OF SOLICITATION DOCUMENTS</td>
                    </tr>
                    <tr>
                    <td style="width: 100%;">
                                                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Text="."></asp:Label></td>
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
                                            <td style="width: 100%; height: 9px; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center">
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
                                                        <asp:BoundColumn DataField="EstimatedCost" HeaderText="Est. Cost" DataFormatString="{0:N0}"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="PreBidMeeting" HeaderText="PreBidMeeting" Visible="False"></asp:BoundColumn>
                                                                              
                                                        <asp:ButtonColumn CommandName="btnAddIssue" HeaderText="ACTION" Text="Add Issue"></asp:ButtonColumn>
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
                                                <asp:Label ID="lblDocID" runat="server" Text="0" Visible="False"></asp:Label></td>
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
                                                                            ADD SOLICITATION DOCUMENTS ISSUE INFORMATION</td>
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
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                            <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                                <tr>
                                                                                    <td style="vertical-align: top; width: 45%; text-align: center">
                                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                            <tr>
                                                                                                <td colspan="3" style="height: 9px">
                                                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td class="InterFaceTableLeftRow" style="height: 21px">
                                                                                                                Date Notice Published</td>
                                                                                                            <td class="InterFaceTableMiddleRow" style="width: 2%; height: 21px">
                                                                                                            </td>
                                                                                                            <td class="InterFaceTableRightRow" style="height: 30px">
                                                                                                                <asp:TextBox ID="txtDateNoticePublished" runat="server" autocomplete="off" Font-Bold="False"
                                                                                                                    Width="80%"></asp:TextBox></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="InterFaceTableLeftRowUp">
                                                                                                                Date Document Available</td>
                                                                                                            <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                            </td>
                                                                                                            <td class="InterFaceTableRightRowUp">
                                                                                                                <asp:TextBox ID="txtDateDocumentAvailable" runat="server" autocomplete="off" Font-Bold="False"
                                                                                                                    Width="80%"></asp:TextBox></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="InterFaceTableLeftRowUp">
                                                                                                            </td>
                                                                                                            <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                            </td>
                                                                                                            <td class="InterFaceTableRightRowUp">
                                                                                                    <asp:CheckBox ID="chkIsFeePayable" runat="server"
                                                                                                        Font-Bold="True" ForeColor="Firebrick"
                                                                                                        Text="Fee Is Payable" ToolTip="Check if a Fee is Payable for the Solicitation Documents" AutoPostBack="True" OnCheckedChanged="chkIsFeePayable_CheckedChanged" /></td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                    </td>
                                                                                            </tr>
                                                                                        </table>
                                                                            <ajaxToolkit:CalendarExtender id="CalendarExtender3" runat="server" CssClass="MyCalendar"
                                                                                Format="MMMM d, yyyy" TargetControlID="txtDateNoticePublished">
                                                                            </ajaxToolkit:CalendarExtender>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td style="vertical-align: top; width: 45%; color: #000000; text-align: center">
                                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                        </table>
                                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                            <tr>
                                                                                                <td colspan="3" style="height: 9px">
                                                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                                        <tr>
                                                                                                            <td class="InterFaceTableLeftRowUp">
                                                                                                                Addendum Number</td>
                                                                                                            <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                            </td>
                                                                                                            <td class="InterFaceTableRightRowUp">
                                                                                                                <asp:TextBox ID="txtAddendumNumber" runat="server" Width="80%"></asp:TextBox></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="InterFaceTableLeftRowUp">
                                                                                                                <asp:Label ID="lblCostOfDoc" runat="server" Text="Cost of the Documents (UGX)"></asp:Label></td>
                                                                                                            <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                            </td>
                                                                                                            <td class="InterFaceTableRightRowUp">
                                                                                                                <asp:TextBox ID="txtCostOfDocuments" runat="server" autocomplete="off" Font-Bold="False"
                                                                                                                    onkeyup="javascript:this.value=Comma(this.value);" Width="80%">
                                                                </asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                            <ajaxToolkit:CalendarExtender id="CalendarExtender4" runat="server" CssClass="MyCalendar"
                                                                                Format="MMMM d, yyyy" TargetControlID="txtDateDocumentAvailable">
                                                                            </ajaxToolkit:CalendarExtender>
                                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTECost" runat="server" FilterType="Custom,Numbers"
                                                                                            TargetControlID="txtCostOfDocuments" ValidChars=",">
                                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                            &nbsp;&nbsp;
                                                                            
                                                                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                <ContentTemplate> 
                                                                            <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                                <tr>
                                                                                    <td colspan="2" style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                                        <table align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px;
                                                                                width: 60%">
                                                                                <tr>
                                                                                    <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                                        ADD SOLICITATION DOCUMENTS ISSUE DETAILS</td>
                                                                                </tr>
                                                                            </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="color: #000000">
                                                                                    <td colspan="2" style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                                        <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="Red">.</asp:Label></td>
                                                                                </tr>
                                                                                <tr style="color: #000000">
                                                                                    <td colspan="2" style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="color: #000000">
                                                                                    <td colspan="2" style="vertical-align: top; height: 10px; text-align: center">
                                                                                        <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                                            <tr>
                                                                                                <td style="vertical-align: top; width: 45%; text-align: center">
                                                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                                        <tr>
                                                                                                            <td colspan="3" style="height: 9px">
                                                                                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                                                    <tr>
                                                                                                                        <td class="InterFaceTableLeftRow" style="height: 21px">
                                                                                                                            Bidder</td>
                                                                                                                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 21px">
                                                                                                                        </td>
                                                                                                                        <td class="InterFaceTableRightRow" style="height: 30px">

                                                                                                                            <asp:TextBox ID="txtBidder" runat="server" autocomplete="off" Font-Bold="False"
                                                                                                                                Width="80%"></asp:TextBox><asp:DropDownList ID="cboBidder" runat="server" OnDataBound="cboBidder_DataBound"
                                                                                                                                    Width="82%">
                                                                                                                                </asp:DropDownList></td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td class="InterFaceTableLeftRow" style="height: 21px">
                                                                                                                            Request Received (Date)</td>
                                                                                                                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 21px">
                                                                                                                        </td>
                                                                                                                        <td class="InterFaceTableRightRow" style="height: 30px">
                                                                                                                            <asp:TextBox ID="txtRequestReceivedDate" runat="server" autocomplete="off" Font-Bold="False"
                                                                                                                                Width="80%"></asp:TextBox></td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td class="InterFaceTableLeftRowUp">
                                                                                                                            <asp:Label ID="lblFeePaidDate" runat="server" Text="Fee Paid (Date)"></asp:Label></td>
                                                                                                                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                                        </td>
                                                                                                                        <td class="InterFaceTableRightRowUp">
                                                                                                                            <asp:TextBox ID="txtFeePaidDate" runat="server" autocomplete="off" Font-Bold="False"
                                                                                                                                Width="80%"></asp:TextBox></td>
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
                                                                                                                        <td class="InterFaceTableLeftRowUp">
                                                                                                                            Documents Issued (Date)</td>
                                                                                                                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                                        </td>
                                                                                                                        <td class="InterFaceTableRightRowUp">
                                                                                                                            <asp:TextBox ID="txtDocsIssuedDate" runat="server" autocomplete="off" Font-Bold="False"
                                                                                                                                Width="80%"></asp:TextBox></td>
                                                                                                                    </tr>
                                                                                                                    <tr style="color: #000000">
                                                                                                                        <td class="InterFaceTableLeftRowUp">
                                                                                                                Issuing Officer</td>
                                                                                                                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                                        </td>
                                                                                                                        <td class="InterFaceTableRightRowUp">
                                                                                                                            <asp:TextBox ID="txtOfficer" runat="server" Font-Bold="False"
                                                                                                                                Width="80%" Enabled="false" ></asp:TextBox></td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" style="margin-top: 10px; vertical-align: top; padding-top: 20px;
                                                                                        height: 12px; text-align: center">
                                                                                        <asp:Button ID="btnAdd" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                                            OnClick="btnAdd_Click" Text="Add Issue" Width="120px" />&nbsp;&nbsp;
                                                                                        </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" style="vertical-align: top; padding-top: 10px; text-align: center">
                                                                                        &nbsp;<ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" CssClass="MyCalendar"
                                                                                            Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtRequestReceivedDate">
                                                                                        </ajaxToolkit:CalendarExtender>
                                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" CssClass="MyCalendar"
                                                                                            Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtFeePaidDate">
                                                                                        </ajaxToolkit:CalendarExtender>
                                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" CssClass="MyCalendar"
                                                                                            Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtDocsIssuedDate">
                                                                                        </ajaxToolkit:CalendarExtender>
                                                                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" MinimumPrefixLength="1"
                                                                                              ServiceMethod="GetBiddersByNames" UseContextKey="true" ServicePath="CascadingddlService.asmx" TargetControlID="txtBidder">
                                                                                                         </ajaxToolkit:AutoCompleteExtender>
                                                                                        
                                                                                    </td>
                                                                                </tr>
                                                                                <tr align="center">
                                                                                    <td align="center" colspan="2" style="vertical-align: top">
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
                                                                                                <asp:BoundColumn DataField="ID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                                                                <asp:BoundColumn DataField="BidderName" HeaderText="Bidder Name"></asp:BoundColumn>
                                                                                                <asp:BoundColumn DataField="RequestReceivedDate" HeaderText="Request Received Date" DataFormatString="{0:dd MMM yyyy}">
                                                                                                </asp:BoundColumn>
                                                                                                <asp:BoundColumn DataField="FeePaidDate" HeaderText="Fee Paid Date" DataFormatString="{0:dd MMM yyyy}"></asp:BoundColumn>
                                                                                                <asp:BoundColumn DataField="DocumentsIssuedDate" HeaderText="Documents Issued Date" DataFormatString="{0:dd MMM yyyy}">
                                                                                                </asp:BoundColumn>
                                                                                                <asp:BoundColumn DataField="IssuingOfficerName" HeaderText="Issuing Officer"></asp:BoundColumn>
                                                                                                <asp:ButtonColumn CommandName="btnEdit" HeaderText="Edit" Text="Edit"></asp:ButtonColumn>
                                                                                                <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove">
                                                                                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                                                        Font-Underline="False" ForeColor="Red" />
                                                                                                </asp:ButtonColumn>
                                                                                            </Columns>
                                                                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                                                                                Font-Strikeout="False" Font-Underline="False" ForeColor="White" HorizontalAlign="Left" />
                                                                                        </asp:DataGrid></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" style="vertical-align: top; height: 19px; text-align: center">
                                                                                        <asp:Label ID="lblNoRecords" runat="server" Font-Bold="True" Font-Names="Cambria"
                                                                                            ForeColor="Red" Visible="False" Width="550px">NO RECORD OF ISSUE OF SOLICITATION DOCS CURRENTLY AVAILABLE</asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                        &nbsp;</td>
                                                                                </tr>
                                                                            </table>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                        <asp:Button ID="btnSubmit" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                                            OnClick="btnSubmit_Click" Text="Save" Width="120px" />
                                                                                       <asp:Button ID="btnPrint" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" Text="Print" Width="120px" OnClick="btnPrint_Click" Enabled="False" /><asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel / Return" Font-Bold="True" Width="130px" />&nbsp;
                                                                        </td>

                                                                    </tr>

                                                                    <tr>
                                                                    <td colspan="2" style="vertical-align: top; padding-top: 5px; text-align: center">
                                                                    <asp:Button ID="btnfinalSubmit" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                                            OnClick="btnfinalSubmit_Click" Text="Submit" ForeColor="Red" Width="120px" />
                                                                     
                                                                                            </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    </asp:View>
                                                    &nbsp;&nbsp;
                                                </asp:MultiView></td>
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