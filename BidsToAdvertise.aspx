<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="BidsToAdvertise.aspx.cs" Inherits="Bidding_PendingProcurements" Title="PENDING PROCUREMENT(S)" %>

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
                    PROCUREMENTS PENDING SOURCING
                </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>PR NUMBER</label>
                <asp:TextBox ID="txtPrNumber" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>PrOC. METHOD</label>
                <asp:DropDownList ID="cboProcMethod" runat="server" AutoPostBack="True" CssClass="form-control"
                    OnDataBound="cboProcMethod_DataBound">
                </asp:DropDownList>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>AREA</label>
                <asp:DropDownList ID="cboAreas" runat="server" AutoPostBack="True" CssClass="form-control"
                    OnDataBound="cboAreas_DataBound1" OnSelectedIndexChanged="cboAreas_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Cost CENTER</label>
                <asp:DropDownList ID="cboCostCenters" runat="server" CssClass="form-control"
                    OnDataBound="cboCostCenter_DataBound">
                </asp:DropDownList>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>&nbsp;</label>
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click"
                                Text="Search" class="btn btn-primary btn-user btn-block float-right"/>
            </div>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                                                BIDS PENDING TO BE ADVERTISED</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 65%">
                                                    <tr>
                                                        <td class="InterFaceTableLeftRow" style="width: 31%; height: 30px">
                                                            <%--Submit Procurements To:--%></td>
                                                        <td style="vertical-align: middle; width: 50%; height: 30px; text-align: left">
                                                            &nbsp;<%--<asp:DropDownList ID="cboTopPDUSupervisors" runat="server" AutoPostBack="True"
                                                                Width="80%" OnSelectedIndexChanged="cboTopPDUSupervisors_SelectedIndexChanged" OnDataBound="cboTopPDUSupervisors_DataBound">
                                                            
                                     
                                                                  </asp:DropDownList>--%></td>
                                                        <td style="vertical-align: middle; width: 25%; height: 30px; text-align: left">
                                                            <asp:Button ID="btnTopSubmit" runat="server" Font-Bold="True" OnClick="btnSubmitSupervisor_Click"
                                                                Text="Submit" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">
                                                <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" Font-Bold="True"
                                                    OnCheckedChanged="chkSelect_CheckedChanged" Text="Select All" /></td>
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
                                                        <asp:BoundColumn DataField="CreationDate" HeaderText="Date" DataFormatString="{0:dd MMM yyyy}" Visible="false">
                                                            <ItemStyle Width="50px" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ScalaPRNumber" HeaderText="PR Number"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Subject" HeaderText="Subject"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ProcurementType" HeaderText="Type"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ProcMethodCode" HeaderText="MethodCode" Visible="false"  ></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Method" HeaderText="Method" ></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="EstimatedCost" HeaderText="Est. Cost" DataFormatString="{0:N0}">
                                                            
                                                        </asp:BoundColumn>
                                                       
                                                        <asp:ButtonColumn CommandName="btnViewDetails" HeaderText="VIEW" Text="DETAILS" Visible="false"></asp:ButtonColumn>
                                                        <asp:ButtonColumn CommandName="btnViewForm" HeaderText="VIEW" Text="FORM"></asp:ButtonColumn>
                                                 
                                                        
                                                        <asp:TemplateColumn HeaderText="VIEW">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="btnBidders" CommandName="btnViewBidders" Text="BIDDERS" Visible="<%# DisableLinkBidders(Container.DataItem) %>"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:TemplateColumn HeaderText="SUBMIT">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chbSubmit" runat="server" Checked="false" Width="40px" />
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="2%" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                </asp:DataGrid></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: right;">
                                                <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Font-Bold="True"
                                                    OnCheckedChanged="CheckBox2_CheckedChanged" Text="Select All" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%"><table align="center" cellpadding="0" cellspacing="0" style="width: 65%">
                                                <tr>
                                                    <td class="InterFaceTableLeftRow" style="width: 31%; height: 30px">
                                                        <%--Submit Procurements To:--%></td>
                                                    <td style="vertical-align: middle; width: 50%; height: 30px; text-align: left">
                                                        &nbsp;<%--<asp:DropDownList ID="cboPDUSupervisors" runat="server" AutoPostBack="True"
                                                                OnDataBound="cboPDUSupervisors_DataBound"
                                                                Width="80%" OnSelectedIndexChanged="cboPDUSupervisors_SelectedIndexChanged">
                                                            
                                       
                                                        </asp:DropDownList>--%>

                                                    </td>
                                                    <td style="vertical-align: middle; width: 25%; height: 30px; text-align: left">
                                                        <asp:Button ID="btnBottomSubmit" runat="server" Font-Bold="True" OnClick="btnSubmitSupervisor_Click"
                                                                Text="Submit" /></td>
                                                </tr>
                                            </table>
                                            </td>
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
                                                <asp:Label ID="lblEmpty" runat="server" Font-Bold="True" ForeColor="Red" Text="."></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View3" runat="server">
                                    <div class="form-group row">
                                        <div class="col-sm-3 mb-3 mb-sm-0"></div>
                                        <div class="col-sm-6 mb-3 mb-sm-0">
                                            <asp:Label ID="lblHeading" runat="server" ForeColor="Firebrick" Text="0"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-3 mb-3 mb-sm-0"></div>
                                        <div class="col-sm-6 mb-3 mb-sm-0">
                                            <asp:Label ID="lblProcMethod" runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblRefNo" runat="server" Text="0" Visible="False"></asp:Label>
                                            <asp:Label ID="lblQuestionCount" runat="server" Text="0" Visible="False"></asp:Label>
                                            <asp:Label ID="lblCost" runat="server" Text="0" Visible="False"></asp:Label>
                                            <asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label>
                                            <asp:Label ID="lblSection" runat="server" Text="0" Visible="False"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-1 mb-3 mb-sm-0"></div>
                                        <div class="col-sm-1 mb-3 mb-sm-0">
                                            Reference Number
                                        </div>
                                        <div class="col-sm-3 mb-3 mb-sm-0">
                                            <asp:TextBox ID="txtReferenceNo" runat="server" BorderStyle="Solid" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-1 mb-3 mb-sm-0">
                                            Date Required
                                        </div>
                                        <div class="col-sm-3 mb-3 mb-sm-0">
                                            <asp:TextBox ID="txtDateRequired" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-1 mb-3 mb-sm-0"></div>
                                        <div class="col-sm-1 mb-3 mb-sm-0">
                                            Procurement Type
                                        </div>
                                        <div class="col-sm-3 mb-3 mb-sm-0">
                                            <asp:TextBox ID="txtProcType" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-1 mb-3 mb-sm-0">
                                            Subject of Procurement
                                        </div>
                                        <div class="col-sm-3 mb-3 mb-sm-0">
                                            <asp:TextBox ID="txtProcSubject" runat="server" CssClass="form-control" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-1 mb-3 mb-sm-0"></div>
                                        <div class="col-sm-1 mb-3 mb-sm-0">
                                            Estimated Cost
                                        </div>
                                        <div class="col-sm-3 mb-3 mb-sm-0">
                                            <asp:TextBox ID="txtEstimatedCost" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-1 mb-3 mb-sm-0">
                                            Requisitioner
                                        </div>
                                        <div class="col-sm-3 mb-3 mb-sm-0">
                                            <asp:TextBox ID="txtRequisitioner" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-1 mb-3 mb-sm-0"></div>
                                        <div class="col-sm-1 mb-3 mb-sm-0">
                                            Procurement Method
                                        </div>
                                        <div class="col-sm-3 mb-3 mb-sm-0">
                                            <asp:TextBox ID="txtProcMethod" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-1 mb-3 mb-sm-0">
                                            Cost Center
                                        </div>
                                        <div class="col-sm-3 mb-3 mb-sm-0">
                                            <asp:TextBox ID="txtBudgetCostCenter" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-1 mb-3 mb-sm-0"></div>
                                        <div class="col-sm-1 mb-3 mb-sm-0">
                                            Date Requisitioned
                                        </div>
                                        <div class="col-sm-3 mb-3 mb-sm-0">
                                            <asp:TextBox ID="txtDateRequisitioned" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">

                    <tr>
                        <td colspan="4" style="vertical-align: top; position: static; height: 5px; text-align: center">&nbsp;<asp:MultiView ID="MultiView2" runat="server">
                            <asp:View ID="View6" runat="server">
                                <table style="width: 100%">
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
                                                                DataKeyNames="Id" EmptyDataText="PLEASE CLICK SECTION DETAILS LINK TO VIEW QUESTIONS" GridLines="None"
                                                                HorizontalAlign="Center" OnRowCommand="dgvQuestions_RowCommand" PageSize="1"
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
                                        <td style="width: 100%; text-align: center">
                                            <table align="center" cellpadding="0" cellspacing="0" style="border-right: buttonface thin solid; border-top: buttonface thin solid; margin-top: 10px; border-left: buttonface thin solid; width: 300px; border-bottom: buttonface thin solid">
                                                <tr>
                                                    <td class="InterFaceTableLeftRow" colspan="3" style="vertical-align: middle; height: 30px; text-align: center">&nbsp; &nbsp;
                                                                               
                                                        <asp:Button ID="btnPrint" runat="server" Font-Bold="True" Font-Size="9pt"
                                                            Height="23px" OnClick="btnPrint_Click" Text="Print" Width="120px" Visible="false" />&nbsp;
                                                                               
                                                        <asp:Button ID="btnDone" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                            OnClick="btnDone_Click" Text="Return" ToolTip="Return to List of Procurements"
                                                            Width="120px" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View7" runat="server">
                                <table style="width: 100%">
                                    <tr>
                                        <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; text-align: center">
                                            <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid; margin-top: 10px; border-left: #617da6 1px solid; width: 98%; border-bottom: #617da6 1px solid">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <table align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px; width: 95%">
                                                                <tr>
                                                                    <td class="InterfaceHeaderLabel3" style="height: 17px">Shortlisted Bidders Details</td>
                                                                </tr>
                                                            </table>
                                                            &nbsp;<asp:GridView ID="gvBidders" runat="server" CssClass="gridgeneralstyle" EmptyDataText="NO BIDDERS HAVE BEEN ENTERED" GridLines="None"
                                                                HorizontalAlign="Center" PageSize="1"
                                                                Style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid; border-left: #dcdcdc thin solid; border-bottom: #dcdcdc thin solid"
                                                                Width="95%" AutoGenerateColumns="False" DataKeyNames="ShortlistID">
                                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                <RowStyle CssClass="gridRowStyle" />
                                                                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="BidderName" HeaderText="BIDDER NAME" />
                                                                    <asp:BoundField DataField="Reason" HeaderText="REASON" />
                                                                    <asp:BoundField DataField="ProposedBy" HeaderText="PROPOSED BY" />
                                                                    <asp:BoundField DataField="CreatedBy" HeaderText="CREATED BY" />
                                                                    <asp:BoundField DataField="DateCreated" HeaderText="PROPOSED DATE" />
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
                                        <td style="width: 100%; text-align: center"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; text-align: center">
                                            <table align="center" cellpadding="0" cellspacing="0" style="border-right: buttonface thin solid; border-top: buttonface thin solid; margin-top: 10px; border-left: buttonface thin solid; width: 300px; border-bottom: buttonface thin solid">
                                                <tr>
                                                    <td class="InterFaceTableLeftRow" colspan="3" style="vertical-align: middle; height: 30px; text-align: center">&nbsp; &nbsp;
                                                                               
                                                        <asp:Button ID="btnPrintBidders" runat="server" Font-Bold="True" Font-Size="9pt"
                                                            Height="23px" OnClick="btnPrintBidders_Click" Text="Print" Width="120px" />&nbsp;
                                                                               
                                                        <asp:Button ID="btnReturnBidder" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                            OnClick="btnDone_Click" Text="Return" ToolTip="Return to List of Procurements"
                                                            Width="120px" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View8" runat="server">
                                <table style="width: 100%">
                                    <tr>
                                        <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; text-align: center">
                                            <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid; margin-top: 10px; border-left: #617da6 1px solid; width: 98%; border-bottom: #617da6 1px solid">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <table align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px; width: 95%">
                                                                <tr>
                                                                    <td class="InterfaceHeaderLabel3" style="height: 17px">Evaluation Committee Details</td>
                                                                </tr>
                                                            </table>
                                                            &nbsp;<asp:GridView ID="gvEC" runat="server" CssClass="gridgeneralstyle" EmptyDataText="NO EVALUATION COMMITTEE MEMBERS HAVE BEEN ADDED" GridLines="None"
                                                                HorizontalAlign="Center" OnRowCommand="dgvFormDetails_RowCommand" PageSize="1"
                                                                Style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid; border-left: #dcdcdc thin solid; border-bottom: #dcdcdc thin solid"
                                                                Width="95%" AutoGenerateColumns="False" DataKeyNames="ECMemberID">
                                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                <RowStyle CssClass="gridRowStyle" />
                                                                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="ECMember" HeaderText="NAME" />
                                                                    <asp:BoundField DataField="Position" HeaderText="POSITION" />
                                                                    <asp:BoundField DataField="Reason" HeaderText="REASON" />
                                                                    <asp:BoundField DataField="CreatedBy" HeaderText="CREATED BY" />
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
                                        <td style="width: 100%; text-align: center"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%; text-align: center">
                                            <table align="center" cellpadding="0" cellspacing="0" style="border-right: buttonface thin solid; border-top: buttonface thin solid; margin-top: 10px; border-left: buttonface thin solid; width: 300px; border-bottom: buttonface thin solid">
                                                <tr>
                                                    <td class="InterFaceTableLeftRow" colspan="3" style="vertical-align: middle; height: 30px; text-align: center">&nbsp; &nbsp;
                                                                               
                                                        <asp:Button ID="btnPrintEC" runat="server" Font-Bold="True" Font-Size="9pt"
                                                            Height="23px" OnClick="btnPrintEC_Click" Text="Print" Width="120px" />&nbsp;
                                                                               
                                                        <asp:Button ID="btnReturnEC" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                            OnClick="btnDone_Click" Text="Return" ToolTip="Return to List of Procurements"
                                                            Width="120px" /></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View4" runat="server">
                                For Micro Procurements
                                  
                                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="1" style="vertical-align: top; height: 41px">
                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                            <tr>
                                                                <td class="InterfaceHeaderLabel" style="height: 20px">
                                                                    <asp:Label ID="lblAddEditItemHeader" runat="server" Text="ADD MICRO PROCUREMENT DETAILS"></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                        <table width="100%">
                                                            <tr>
                                                                <td colspan="1" valign="top">
                                                                    <asp:Label ID="lblMsg" runat="server" Font-Bold="False" Font-Names="Cambria" Font-Size="11pt"
                                                                        ForeColor="Red" Text="."></asp:Label></td>
                                                            </tr>
                                                            <tr style="color: #000000">
                                                                <td style="width: 48%" valign="top">
                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 70%">
                                                                        <tr style="color: #000000">
                                                                            <td class="InterFaceTableLeftRow" style="height: 30px">Closing Date</td>
                                                                            <td class="InterFaceTableMiddleRow" style="width: 2%; height: 30px"></td>
                                                                            <td class="InterFaceTableRightRow" style="width: 66%; height: 30px">
                                                                                <asp:TextBox ID="txtClosingDateTime" runat="server" Width="80%" Enabled="false"></asp:TextBox><strong>&nbsp;
                                                                                    </strong></td>
                                                                        </tr>
                                                                        <tr style="color: #000000">
                                                                            <td class="InterFaceTableLeftRow" style="height: 30px">Closing Time</td>
                                                                            <td class="InterFaceTableMiddleRow" style="width: 2%; height: 30px"></td>
                                                                            <td class="InterFaceTableRightRow" style="width: 66%; height: 30px">
                                                                                <asp:TextBox ID="txtClosingTime" runat="server" Width="80%" Enabled="false"></asp:TextBox></td>
                                                                        </tr>
                                                                    </table>

                                                                    <asp:Label ID="lblReferenceNo" runat="server" Visible="False">0</asp:Label>
                                                                    <asp:Label ID="lblMicroProcurementID" runat="server" Visible="False">0</asp:Label>
                                                                    <asp:Label ID="lblItemCode" runat="server" Font-Bold="True" ForeColor="Red" Text="0"
                                                                        Visible="False"></asp:Label>&nbsp;<cc1:CalendarExtender ID="CalendarExtender1"
                                                                            runat="server" CssClass="MyCalendar" Enabled="True" Format="MMMM d, yyyy" PopupPosition="TopLeft"
                                                                            TargetControlID="txtClosingDateTime"></cc1:CalendarExtender>
                                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                                                        DisplayMoney="None" ErrorTooltipEnabled="True" InputDirection="RightToLeft" Mask="99:99"
                                                                        MaskType="Time" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                                                        OnInvalidCssClass="MaskedEditError" TargetControlID="txtClosingTime"></cc1:MaskedEditExtender>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        &nbsp;
                                                        </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 70%">
                                                <tr>
                                                    <td class="InterfaceHeaderLabel" style="height: 20px">MICRO PROCUREMENT ITEM DETAILS</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                            <asp:Label ID="lblMicroMsg" runat="server" Font-Bold="False" Font-Names="Cambria" Font-Size="11pt"
                                                ForeColor="Red" Text="."></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="vertical-align: middle; height: 22px; text-align: center">
                                            <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                                                ForeColor="#333333" GridLines="None"
                                                Width="70%" Style="text-align: justify" HorizontalAlign="Center">
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <EditItemStyle BackColor="#999999" />
                                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                                                <Columns>
                                                    <asp:BoundColumn DataField="ItemID" HeaderText="ItemID" Visible="False"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="ItemDescription" HeaderText="Item Description"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Quantity" HeaderText="Qty"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Unit" HeaderText="Units"></asp:BoundColumn>
                                                </Columns>
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                                    Font-Strikeout="False" Font-Underline="False" ForeColor="White" HorizontalAlign="Left"
                                                    VerticalAlign="Top" />
                                            </asp:DataGrid>
                                            <asp:Label ID="lblNoRecords" runat="server" Font-Bold="True" Font-Names="Cambria"
                                                ForeColor="Red" Visible="False" Width="550px">NO ITEMS CURRENTLY AVAILABLE</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="vertical-align: middle; height: 22px; text-align: center">&nbsp;
                                               
                                            <asp:Button ID="btnMicroReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                OnClick="btnDone_Click" Text="RETURN" Width="120px" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="vertical-align: middle; height: 22px; text-align: center"></td>
                                    </tr>
                                </table>
                                &nbsp; &nbsp;
                                   
                                <br />

                            </asp:View>
                        </asp:MultiView><br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="vertical-align: middle; height: 22px; text-align: center">
                            <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                <tr>
                                    <td colspan="2" style="vertical-align: top; height: 12px; text-align: center"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="vertical-align: middle; height: 22px; text-align: center"></td>
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
                            </asp:MultiView>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <asp:Label ID="lblPD_Code" runat="server" Text="0" Visible="False"></asp:Label>
            </div>
        </div>
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







