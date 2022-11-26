<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Bidding_SearchProcurements.aspx.cs" Inherits="Bidding_ScheduledProcurements" Title="SEARCH PROCUREMENT(S)" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
     <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">SEARCH PROCUREMENTS</h6>
                </div>
            </div>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <label>Pr number</label>
                        <asp:TextBox ID="txtPrNumber" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <label>PROC. OFFICER</label>
                        <asp:DropDownList ID="cboProcurementOfficer" runat="server" CssClass="form-control" OnDataBound="cboProcurementOfficer_DataBound">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <label>PrOC. METHOD</label>
                        <asp:DropDownList ID="cboProcMethod" runat="server" AutoPostBack="True" CssClass="form-control"
                            OnDataBound="cboProcMethod_DataBound">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <label>AREA</label>
                        <asp:DropDownList ID="cboAreas" runat="server" AutoPostBack="True" CssClass="form-control" OnDataBound="cboAreas_DataBound1" OnSelectedIndexChanged="cboAreas_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <label>Cost CENTER</label>
                        <asp:DropDownList ID="cboCostCenters" runat="server" CssClass="form-control"
                            OnDataBound="cboCostCenter_DataBound">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <label>STATUS</label>
                        <asp:DropDownList ID="cboStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Value="23" Text="Assigned"></asp:ListItem>
                            <asp:ListItem Value="41" Text="Proc Method & Docs submitted"></asp:ListItem>
                            <asp:ListItem Value="43" Text="Proc Method approved by PM"></asp:ListItem>
                            <asp:ListItem Value="42" Text="Proc Method rejected by PM "></asp:ListItem>
                            <asp:ListItem Value="44" Text="Proc Method approval submitted to MD"></asp:ListItem>
                            <asp:ListItem Value="45" Text="Proc Method approved by MD"></asp:ListItem>
                            <asp:ListItem Value="46" Text="Proc Method rejected by MD"></asp:ListItem>
                            <asp:ListItem Value="48" Text="Bid sourcing approval submitted to MD"></asp:ListItem>
                            <asp:ListItem Value="51" Text="Bid sourcing rejected by MD"></asp:ListItem>
                            <asp:ListItem Value="50" Text="Bid sourcing approved by MD"></asp:ListItem>
                            <asp:ListItem Value="52" Text="Bid sourcing closed"></asp:ListItem>
                            <asp:ListItem Value="53" Text="Bid opening and evaluation"></asp:ListItem>
                            <asp:ListItem Value="63" Text="Bid Evaluation submitted"></asp:ListItem>
                            <asp:ListItem Value="66" Text="Contact award approval submitted"></asp:ListItem>
                            <asp:ListItem Value="69" Text="Contract awarded"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                         <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" class="btn btn-primary btn-user btn-block float-right"
                                            Text="Search" />
                    </div>
                    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                        ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid1_ItemCommand"
                        Width="100%" Style="text-align: justify">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditItemStyle BackColor="#999999" />
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                        <Columns>
                            <asp:BoundColumn DataField="RecordID" HeaderText="RecordID" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CreationDate" HeaderText="Date" DataFormatString="{0:dd MMM yyyy}" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ScalaPRNumber" ItemStyle-CssClass="gridPad" HeaderText="PR Number"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PD_Code" HeaderText="PD Code" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Subject" ItemStyle-CssClass="gridPad" HeaderText="Subject">
                                <ItemStyle Width="200px" />
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ProcurementType" ItemStyle-CssClass="gridPad" HeaderText="Type"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ProcMethodCode" HeaderText="MethodCode" Visible="False"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Method" ItemStyle-CssClass="gridPad" HeaderText="Method"></asp:BoundColumn>
                            <asp:BoundColumn DataField="EstimatedCost" ItemStyle-CssClass="gridPad" HeaderText="Est. Cost" DataFormatString="{0:N0}"></asp:BoundColumn>
                            <asp:ButtonColumn CommandName="btnViewDetails" ItemStyle-CssClass="gridPad" HeaderText="VIEW" Text="Details"></asp:ButtonColumn>

                            <asp:ButtonColumn CommandName="btnViewAttachments" ItemStyle-CssClass="gridPad" HeaderText="VIEW" Text="Attachments"></asp:ButtonColumn>
                            <asp:ButtonColumn CommandName="btnViewStatus" ItemStyle-CssClass="gridPad" HeaderText="VIEW" Text="Status"></asp:ButtonColumn>
                            <asp:ButtonColumn CommandName="btnViewForms" ItemStyle-CssClass="gridPad" HeaderText="VIEW" Text="Submission Forms" Visible="false"></asp:ButtonColumn>
                            <asp:ButtonColumn CommandName="btnViewOther" ItemStyle-CssClass="gridPad" HeaderText="VIEW" Text="PP Forms" Visible="false"></asp:ButtonColumn>
                        </Columns>
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    </asp:DataGrid>
                    <asp:Label ID="lblEmpty" runat="server" Font-Bold="True" ForeColor="Red" Text="."></asp:Label>
                </div>
            </asp:View>
            &nbsp;
                               
        <asp:View ID="View2" runat="server">
            <table id="Table3" style="width: 100%">
                <tr>
                    <td style="width: 100%; height: 21px; text-align: center"></td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">STAGES OF PROCUREMENT</td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                        <asp:Button ID="Button1" runat="server" OnClick="Button2_Click" Text="Export" />&nbsp;
                                               
                        <asp:Button ID="Button3" runat="server" OnClick="btnreturn_Click" Text="Return" /></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right"></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" Style="text-align: justify"
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
                    <td style="width: 100%; text-align: center">
                        <asp:Label ID="lblPDCodeStatus" runat="server" Text="0" Visible="False"></asp:Label></td>
                </tr>
            </table>
        </asp:View>
            <asp:View ID="View10" runat="server">
                <table style="width: 100%">
                    <tr>
                        <td colspan="1" style="width: 100%; height: 21px; text-align: center"></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" colspan="1" style="width: 100%; text-align: center">PROCUREMENT
                                                                    ATTACHMENT(S)</td>
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
                                            GridLines="None" HorizontalAlign="Center" OnRowCommand="GridAttachments_RowCommand"
                                            PageSize="15" Width="98%" AutoGenerateColumns="False">
                                            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                            <RowStyle CssClass="gridRowStyle" />
                                            <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:ButtonField CommandName="ViewDetails" Text="View">
                                                    <HeaderStyle CssClass="gridEditField" />
                                                    <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                        Width="140px" />
                                                </asp:ButtonField>
                                                <asp:BoundField DataField="FileID" HeaderText="FILE ID" />
                                                <asp:BoundField DataField="FileName" HeaderText="FILE NAME" />
                                            </Columns>
                                            <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                            <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                        </asp:GridView>
                                        <asp:Label ID="lblNoAttachments" runat="server" Font-Names="Cambria" Font-Size="11pt"
                                            ForeColor="Red" Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 16px"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" style="vertical-align: top; width: 100%; text-align: center">
                            <asp:Label ID="lblAttachRefNo" runat="server" Text="0" Visible="False"></asp:Label>
                            <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                OnClick="btnReturn_Click" Text="RETURN" Width="80px" /></td>
                    </tr>
                </table>
            </asp:View>
            &nbsp;
                                &nbsp;&nbsp;
                               
        <asp:View ID="View3" runat="server">
            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center"></td>
                </tr>
                <tr>
                    <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center; width: 100%;">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                            <tr>
                                <td class="InterfaceHeaderLabel3" style="height: 17px">&gt;&gt;&gt; &nbsp;<asp:Label ID="lblHeading" runat="server" ForeColor="Firebrick"
                                    Text="0"></asp:Label></td>
                            </tr>
                        </table>
                        <asp:Label ID="lblProcMethod" runat="server" Text="0" Visible="False"></asp:Label><asp:Label
                            ID="lblRefNo" runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblQuestionCount"
                                runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblCost" runat="server"
                                    Text="0" Visible="False"></asp:Label><asp:Label ID="lblPDCode" runat="server" Text="0"
                                        Visible="False"></asp:Label>
                        <asp:Label ID="lblSection" runat="server" Text="0" Visible="False"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center"></td>
                </tr>
                <tr>
                    <td colspan="1" style="vertical-align: top; width: 50%; text-align: center">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                            <tr>
                                <td class="InterFaceTableLeftRowUp">Reference Number</td>
                                <td class="InterFaceTableMiddleRowUp"></td>
                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                    <asp:TextBox ID="txtReferenceNo" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                        Font-Bold="True" ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRowUp">Procurement Type</td>
                                <td class="InterFaceTableMiddleRowUp">&nbsp;</td>
                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                    <asp:TextBox ID="txtProcType" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRowUp" style="height: 30px">Estimated Cost</td>
                                <td class="InterFaceTableMiddleRowUp" style="height: 30px"></td>
                                <td class="InterFaceTableRightRowUp" style="height: 30px">
                                    <asp:TextBox ID="txtEstimatedCost" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRowUp">Procurement Method</td>
                                <td class="InterFaceTableMiddleRowUp"></td>
                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                    <asp:TextBox ID="txtProcMethod" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRowUp">Date Requisitioned</td>
                                <td class="InterFaceTableMiddleRowUp"></td>
                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                    <asp:TextBox ID="txtDateRequisitioned" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                            </tr>
                        </table>
                    </td>
                    <td colspan="4" style="vertical-align: top; width: 50%; text-align: center">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                            <tr>
                                <td class="InterFaceTableLeftRowUp" style="height: 30px">Date Required</td>
                                <td class="InterFaceTableMiddleRowUp" style="height: 30px"></td>
                                <td class="InterFaceTableRightRowUp" style="height: 30px">
                                    <asp:TextBox ID="txtDateRequired" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRow">Subject of Procurement</td>
                                <td class="InterFaceTableMiddleRow"></td>
                                <td class="InterFaceTableRightRow" style="width: 66%; height: 65px">
                                    <asp:TextBox ID="txtProcSubject" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxMultiline"
                                        Font-Bold="True" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRowUp">Requisitioner</td>
                                <td class="InterFaceTableMiddleRowUp"></td>
                                <td class="InterFaceTableRightRowUp">
                                    <asp:TextBox ID="txtRequisitioner" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRowUp">Cost Center</td>
                                <td class="InterFaceTableMiddleRowUp">&nbsp;</td>
                                <td class="InterFaceTableRightRowUp">
                                    <asp:TextBox ID="txtBudgetCostCenter" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="vertical-align: top; position: static; height: 5px; text-align: center"></td>
                </tr>
                <tr>
                    <td colspan="4" style="width: 100%; text-align: center">&nbsp;&nbsp;
                                                                               
                        <asp:Button ID="Button2" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                            OnClick="btnDone_Click" Text="Return" ToolTip="Return to List of Procurements"
                            Width="120px" /></td>
                </tr>
                <tr>
                    <td colspan="4" style="vertical-align: top; position: static; height: 5px; text-align: center">&nbsp;<asp:MultiView ID="MultiView2" runat="server">
                        <asp:View ID="View9" runat="server">
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 100%; text-align: center"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: center">
                                        <asp:DataGrid ID="DataGrid3" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                                            ForeColor="#333333" GridLines="None"
                                            Width="100%" Style="text-align: justify" OnItemCommand="DataGrid3_ItemCommand">
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <EditItemStyle BackColor="#999999" />
                                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <Columns>
                                                <asp:BoundColumn DataField="NUMBER" HeaderText="NUMBER" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="ReferenceNo" HeaderText="PR Number" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="Form" HeaderText="FORM"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="FormName" HeaderText="FORM NAME"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="ReportName" HeaderText="REPORT NAME" Visible="false"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="IsEnabled" HeaderText="IsEnabled" Visible="False"></asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="ACTION">
                                                    <ItemTemplate>
                                                        <asp:LinkButton runat="server" ID="btnPrintForm" CommandName="btnPrintForm" Text="PRINT PP FORM" Visible="<%# EnablePrintButton(Container.DataItem) %>"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                            </Columns>
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                        </asp:DataGrid></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: center">
                                        <asp:Label ID="lblFormName" runat="server" Visible="False"></asp:Label>
                                        <asp:Label ID="lblReportName" runat="server" Visible="False"></asp:Label></td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View6" runat="server">
                            <table style="width: 100%">
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">VIEW SUBMISSION FORMS</td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: center">
                                        <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid; margin-top: 10px; border-left: #617da6 1px solid; width: 98%; border-bottom: #617da6 1px solid">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <table align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px; width: 95%">
                                                            <tr>
                                                                <td class="InterfaceHeaderLabel3" style="height: 17px">Form Details</td>
                                                            </tr>
                                                        </table>
                                                        &nbsp;<asp:GridView ID="dgvFormDetails" runat="server" CssClass="gridgeneralstyle" EmptyDataText="NO QUESTION HAS BEEN ANSWERED YET" GridLines="None"
                                                            HorizontalAlign="Center" OnRowCommand="dgvFormDetails_RowCommand" PageSize="1"
                                                            Style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid; border-left: #dcdcdc thin solid; border-bottom: #dcdcdc thin solid"
                                                            Width="95%" AutoGenerateColumns="False" DataKeyNames="Section">
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
                                        <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid; margin-top: 10px; border-left: #617da6 1px solid; width: 98%; border-bottom: #617da6 1px solid">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <table align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px; width: 95%">
                                                            <tr>
                                                                <td class="InterfaceHeaderLabel3" style="height: 17px">Answered Questions</td>
                                                            </tr>
                                                        </table>
                                                        &nbsp;<asp:GridView ID="dgvQuestions" runat="server" CssClass="gridgeneralstyle"
                                                            DataKeyNames="Id" EmptyDataText="PLEASE CLICK ON THE SECTION DETAILS LINK ABOVE" GridLines="None"
                                                            HorizontalAlign="Center" PageSize="1"
                                                            Style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid; border-left: #dcdcdc thin solid; border-bottom: #dcdcdc thin solid"
                                                            Width="95%">
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
                                    <td style="width: 100%; text-align: center">&nbsp; &nbsp;
                                                                               
                                        <asp:Button ID="btnPrint" runat="server" Font-Bold="True" Font-Size="9pt"
                                            Height="23px" OnClick="btnPrint_Click" Text="Print" Width="120px" Enabled="False" />
                                        <asp:Button ID="btnDone" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                            OnClick="btnDone_Click" Text="Return" ToolTip="Return to List of Procurements"
                                            Width="120px" /></td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View7" runat="server">
                            <table style="width: 100%">
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">VIEW
                                                                    PRE -BID MEETINGS</td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: center">
                                        <asp:DataGrid ID="DataGrid4" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None"
                                            Style="text-align: justify" Width="100%" OnItemCommand="DataGrid4_ItemCommand">
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <EditItemStyle BackColor="#999999" />
                                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <Columns>
                                                <asp:BoundColumn DataField="PreBidMeetingID" HeaderText="PreBidMeetingID" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="MeetingLocation" HeaderText="Meeting Location"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="MeetingDate" HeaderText="Meeting Date"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="ReasonForMeeting" HeaderText="Reason"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="MeetingMinutesFile" HeaderText="File" Visible="False"></asp:BoundColumn>
                                                <asp:ButtonColumn CommandName="btnPrintPreBidMeeting" HeaderText="PRINT" Text="PP FORM 33"></asp:ButtonColumn>
                                                <asp:ButtonColumn CommandName="btnViewAttendence" HeaderText="VIEW" Text="ATTENDENCE"></asp:ButtonColumn>
                                            </Columns>
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                                Font-Strikeout="False" Font-Underline="False" ForeColor="White" HorizontalAlign="Left" />
                                        </asp:DataGrid></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: center"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: center">&nbsp;&nbsp;
                                                                               
                                        <asp:Button ID="btnReturnBidder" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                            OnClick="btnDone_Click" Text="Return" ToolTip="Return to List of Procurements"
                                            Width="120px" /></td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View8" runat="server">
                            <table style="width: 100%">
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">VIEW BID OPENINGS</td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: center">
                                        <asp:DataGrid ID="DataGrid5" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid5_ItemCommand"
                                            Style="text-align: justify" Width="100%">
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <EditItemStyle BackColor="#999999" />
                                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                                            <Columns>
                                                <asp:BoundColumn DataField="BidOpeningID" HeaderText="BidOpeningID" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="Location" HeaderText="Location"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="DateOfOpening" HeaderText="Date Of Opening"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="OpeningTypeID" HeaderText="OpeningTypeID" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="OpeningType" HeaderText="Opening Type"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PDUMemberID" HeaderText="PDUMemberID" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="PDUMember" HeaderText="PDU Signatory"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="CCMemberID" HeaderText="CCMemberID" Visible="False"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="CCMember" HeaderText="CC Signatory"></asp:BoundColumn>
                                                <asp:ButtonColumn CommandName="btnPrintBidOpening" HeaderText="PRINT" Text="PP FORM 35"></asp:ButtonColumn>
                                                <asp:ButtonColumn CommandName="btnViewAttendence" HeaderText="VIEW" Text="ATTENDENCE"></asp:ButtonColumn>
                                            </Columns>
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                                Font-Strikeout="False" Font-Underline="False" ForeColor="White" HorizontalAlign="Left" />
                                        </asp:DataGrid></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: center"></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: center">&nbsp;&nbsp;
                                                                               
                                        <asp:Button ID="btnReturnBidOpenings" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                            OnClick="btnDone_Click" Text="Return" ToolTip="Return to List of Procurements"
                                            Width="120px" /></td>
                                </tr>
                            </table>
                        </asp:View>
                        &nbsp;
                                               
                    </asp:MultiView></td>
                </tr>
                <tr>
                    <td colspan="4" style="vertical-align: middle; height: 22px; text-align: center"></td>
                </tr>
            </table>
        </asp:View>
            &nbsp;
                               
        <asp:View ID="View5" runat="server">
            <table style="width: 100%">
                <tr>
                    <td style="width: 98%"></td>
                </tr>
                <tr>
                    <td style="width: 98%">
                        <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid; border-left: #617da6 1px solid; width: 98%; border-bottom: #617da6 1px solid">
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
            &nbsp;
                           
        </asp:MultiView>
        <asp:Label ID="lblPD_Code" runat="server" Text="0" Visible="False"></asp:Label>
    </div>
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







