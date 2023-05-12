<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_ApproveActivitySchedule.aspx.cs" Inherits="Requisition_ApproveActivitySchedule" Title="Approve Activity Schedule" %>

<%@ Register Assembly="AjaxControlToolkit"  Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                    APPROVE ACTIVITY SCHEDULE
                </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                 Activity Schedule
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                 Procurement Department
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:DropDownList ID="cboCompany" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">-- ALL DEPARTMENTS --</asp:ListItem>
                    <asp:ListItem Value="1">SMALL PROCUREMENT</asp:ListItem>
                    <asp:ListItem Value="2">LARGE PROCUREMENT</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-1 mb-3 mb-sm-0">
                Date Assigned
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtDateAssigned" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                 Ref. No/ PR Number
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtPRNumber" runat="server" CssClass="form-control"
                    Font-Bold="True" ForeColor="Firebrick" MaxLength="10" Enabled="False" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-sm-1 mb-3 mb-sm-0">
                Preparation Date
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtPreparationDate" runat="server" autocomplete="off" Font-Bold="True" ReadOnly="true" CssClass="form-control"
                                                        ForeColor=""></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                 Procurement Description
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtProcDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Enabled="False" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-sm-1 mb-3 mb-sm-0">
                Prepared By
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:DropDownList ID="cboPreparedBy" runat="server" CssClass="form-control" Enabled="false">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                 Estimated Cost
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtEstimatedCost" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-1 mb-3 mb-sm-0">
                Procurement Supervisor
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:DropDownList ID="cboPDUHead" runat="server" CssClass="form-control"
                    OnDataBound="cboPDUHead_DataBound">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                 Procurement Method
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:DropDownList ID="cboProcMethod" runat="server" CssClass="form-control" Enabled="False" OnDataBound="cboProcMethod_DataBound">
                </asp:DropDownList>
            </div>
            <div class="col-sm-1 mb-3 mb-sm-0">
                Procurement Manager
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:DropDownList ID="cboSupervisor" runat="server"
                    CssClass="form-control" Enabled="false">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                 Funding Source
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:DropDownList ID="cboFunding" runat="server" CssClass="form-control" Enabled="False" OnDataBound="cboFunding_DataBound">
                </asp:DropDownList>
            </div>
            <div class="col-sm-1 mb-3 mb-sm-0">
                Start of Bid Receipt Date
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtBidStartDate" runat="server" autocomplete="off" Font-Bold="True" ForeColor="" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                 End of Bid Receipt Date
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtBidEndDate" runat="server" autocomplete="off" Font-Bold="True" ForeColor=""
                                            CssClass="form-control" ></asp:TextBox>
            </div>
            <div class="col-sm-1 mb-3 mb-sm-0">
               Cummulative Period
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtCummulativePeriod" runat="server" autocomplete="off" Font-Bold="True"
                                                        ForeColor="" ReadOnly="True" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                 <asp:Label ID="Label2" runat="server" ForeColor="Firebrick" Text="." Visible="False"></asp:Label>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:Button ID="btnShowDetails" runat="server" Text="Show Details" class="btn btn-primary btn-user btn-block float-right" OnClick="btnShowDetails_Click" hidden="true"/>
            </div>
        </div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
            <asp:View ID="View1" runat="server">
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        ACTIVITY SCHEDULE DETAILS
                    </div>
                </div>
                <table align="center" cellpadding="0" cellspacing="0" class="style12">
                    <tr>
                        <td style="vertical-align: top; width: 50%; height: 100px; text-align: center">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="width: 30%; border-top-style: none; height: 30px">
                                        <asp:Label ID="lblColumnNo" runat="server" ForeColor="Black" Text="." Visible="False"></asp:Label></td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px"></td>
                                    <td class="InterFaceTableRightRowUp" colspan="2" style="vertical-align: middle; height: 30px; text-align: center">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Firebrick" Style="vertical-align: middle; text-align: center"
                                            Text="PLANNED VS ACTUAL"></asp:Label></td>
                                </tr>
                                <tr style="color: #000000">
                                    <td class="InterFaceTableLeftRowUp">Bid Doc. Preparation Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn1" runat="server" OnClick="btn1_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtBidDocPrepDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow">
                                        <asp:TextBox ID="txtBidDocPrepDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr style="color: #000000">
                                    <td class="InterFaceTableLeftRowUp">Method/Bid Doc Appr. Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn2" runat="server" OnClick="btn2_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtMtdApprovalDate" runat="server" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                    <td class="InterFaceTableRightRow">
                                        <asp:TextBox ID="txtMtdApprovalDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Advert Date (Bid Invitation)</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn3" runat="server" OnClick="btn3_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtAdvertDate" runat="server" Font-Bold="False" ForeColor="" Style="width: 90%"
                                            Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow">
                                        <asp:TextBox ID="txtAdvertDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Bid Submission Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn4" runat="server" OnClick="btn4_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtBidSubmissionDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow">
                                        <asp:TextBox ID="txtBidSubmissionDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Pre Bid Meeting</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn28" runat="server" Text=".." Width="100%" OnClick="btn28_Click" ToolTip="Click to add a comment" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtprebidmeeting" runat="server" Font-Bold="False"
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                        </td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtprebidmeeting2" runat="server" Font-Bold="False"
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                        </td>

                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Bid Opening Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn5" runat="server" OnClick="btn5_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtBidOpeningDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtBidOpeningDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Bid Validity Expiry &nbsp;Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn6" runat="server" OnClick="btn6_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtBidValidityExpiryDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtBidValidityExpiryDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Bid Security Expiry Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn7" runat="server" OnClick="btn7_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtBidSecurityExpiryDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtBidSecurityExpiryDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Evaluation Report Ready Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn8" runat="server" OnClick="btn8_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtEvalRptReadyDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtEvalRptReadyDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">CC. (ER) Approval &nbsp;Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn9" runat="server" OnClick="btn9_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtCCERApprovalDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtCCERApprovalDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Negott_n Report Ready Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn10" runat="server" OnClick="btn10_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtNRReportReadyDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtNRReportReadyDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">CC. (NR) Approval &nbsp;Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn11" runat="server" OnClick="btn11_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtCCNRApprovalDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" ToolTip="Negotiation Report Approval Date by CC" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtCCNRApprovalDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" ToolTip="Actual Negotiation Report Approval Date by CC"
                                            Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="width: 30%; height: 30px">BEB Notice Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px">
                                        <asp:Button ID="btn12" runat="server" OnClick="btn12_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 34%; height: 30px">
                                        <asp:TextBox ID="txtBEBNoticeDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 34%; height: 30px">
                                        <asp:TextBox ID="txtBEBNoticeDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="width: 30%; height: 30px">Board Paper Submission Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px">
                                        <asp:Button ID="btn13" runat="server" OnClick="btn13_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 34%; height: 30px">
                                        <asp:TextBox ID="txtBoardPaperSubmissionDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 34%; height: 30px">
                                        <asp:TextBox ID="txtBoardPaperSubmissionDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="width: 30%; height: 30px">Board Approval Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px">
                                        <asp:Button ID="btn14" runat="server" OnClick="btn14_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 34%; height: 30px">
                                        <asp:TextBox ID="txtBoardApprovalDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 34%; height: 30px">
                                        <asp:TextBox ID="txtBoardApprovalDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                            </table>
                        </td>
                        <td style="vertical-align: top; width: 50%; height: 100px; text-align: center">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="width: 30%; border-top-style: none; height: 30px"></td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px"></td>
                                    <td class="InterFaceTableRightRowUp" colspan="2" style="vertical-align: middle; height: 30px; text-align: center">
                                        <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Firebrick" Style="vertical-align: middle; text-align: center"
                                            Text="PLANNED VS ACTUAL"></asp:Label></td>
                                </tr>
                                <tr style="color: #000000">
                                    <td class="InterFaceTableLeftRowUp" style="width: 30%; height: 30px">S.G. Paper &nbsp;Submission Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px">
                                        <asp:Button ID="btn15" runat="server" OnClick="btn15_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 34%; height: 30px">
                                        <asp:TextBox ID="txtSGPaperSubmissionDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%; height: 30px">
                                        <asp:TextBox ID="txtSGPaperSubmissionDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="width: 30%; height: 30px">Sol. General Approval Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px">
                                        <asp:Button ID="btn16" runat="server" OnClick="btn16_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtSGApprovalDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 66%">
                                        <asp:TextBox ID="txtSGApprovalDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Funds Available Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn17" runat="server" OnClick="btn17_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtFundsAvailDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 66%">
                                        <asp:TextBox ID="txtFundsAvailDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Bid Acceptance. (LPO) &nbsp;Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn18" runat="server" OnClick="btn18_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtLPODate" runat="server" Font-Bold="False" ForeColor="" Style="width: 90%"
                                            Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 66%">
                                        <asp:TextBox ID="txtLPODate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Contract Preparation Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn19" runat="server" OnClick="btn19_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtContractPrepDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 66%">
                                        <asp:TextBox ID="txtContractPrepDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Contract Signing Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn20" runat="server" OnClick="btn20_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtContractSigningDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 66%">
                                        <asp:TextBox ID="txtContractSigningDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Perf. &nbsp;Security Exp. Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn21" runat="server" OnClick="btn21_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtPerfSecurityExpDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 66%">
                                        <asp:TextBox ID="txtPerfSecurityExpDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Contract Amount (UGX)</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn22" runat="server" OnClick="btn22_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtContractAmount" runat="server" Font-Bold="False" ForeColor="Firebrick"
                                            ReadOnly="True" Style="width: 90%" ToolTip="Planned Total Cost" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 33%; height: 30px">
                                        <asp:TextBox ID="txtContractAmount2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="Firebrick" Style="width: 90%" ToolTip="Actual Contract Amount" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Contract Completion Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn23" runat="server" OnClick="btn23_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtContractCompletionDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 66%">
                                        <asp:TextBox ID="txtContractCompletionDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Date-Receipt of Payment Doc</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn24" runat="server" OnClick="btn24_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtReceiptOfPaymentDocDate" runat="server" Font-Bold="False" Style="width: 90%"
                                            Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 66%">
                                        <asp:TextBox ID="txtReceiptOfPaymentDocDate2" runat="server" Font-Bold="True" Font-Size=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Submission To Finance Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn25" runat="server" OnClick="btn25_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtFinanceSubmissionDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 66%">
                                        <asp:TextBox ID="txtFinanceSubmissionDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Payment Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn26" runat="server" OnClick="btn26_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtPaymentDate" runat="server" Font-Bold="False" ForeColor="" Style="width: 90%"
                                            Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 66%">
                                        <asp:TextBox ID="txtPaymentDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">File Closure Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        <asp:Button ID="btn27" runat="server" OnClick="btn27_Click" Text=".." ToolTip="Click to add a comment"
                                            Width="100%" Visible="False" /></td>
                                    <td class="InterFaceTableRightRow" style="width: 33%">
                                        <asp:TextBox ID="txtFileClosureDate" runat="server" Font-Bold="False" ForeColor=""
                                            Style="width: 90%" Width="80%"></asp:TextBox>
                                        &nbsp;
                                            </td>
                                    <td class="InterFaceTableRightRow" style="width: 66%">
                                        <asp:TextBox ID="txtFileClosureDate2" runat="server" Font-Bold="True" Font-Size=""
                                            ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp"></td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%"></td>
                                    <td class="InterFaceTableRightRow" colspan="2"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="vertical-align: top; height: 15px; text-align: center">
                            <asp:Label ID="Label3" runat="server" Text="."></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="vertical-align: top; height: 15px; text-align: center"></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="vertical-align: top; text-align: center">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 20%">
                                <tr>
                                    <td style="vertical-align: middle; width: 16%; height: 23px; text-align: right">
                                        <asp:Button ID="btnUpdate" runat="server" Font-Size="9pt" Height="23px" Text="Update" Width="100px" OnClick="btnUpdate_Click" />
                                    </td>
                                    <td style="vertical-align: middle; width: 16%; height: 23px; text-align: left">
                                        <asp:Button ID="Button3" runat="server" Font-Size="9pt" Height="23px" OnClick="btnCancel_Click"
                                            Text="Cancel/Return" Width="100px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; width: 50%; text-align: center">
                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator3" runat="server" ControlExtender="MaskedEditExtender3"
                                ControlToValidate="txtContractAmount" Display="Dynamic" EmptyValueBlurredText="*"
                                EmptyValueMessage="Number is required" InvalidValueBlurredMessage="*" InvalidValueMessage="Number is invalid"
                                IsValidEmpty="False" TooltipMessage="Input the amount" ValidationGroup="MKE">
                                        </ajaxToolkit:MaskedEditValidator>
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender3" runat="server" AcceptNegative="Left"
                                DisplayMoney="None" ErrorTooltipEnabled="True" InputDirection="RightToLeft" Mask="9,999,999,999,999"
                                MaskType="Number" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtContractAmount"></ajaxToolkit:MaskedEditExtender>
                        </td>
                        <td style="vertical-align: top; width: 50%; text-align: center">
                            <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender4" runat="server" AcceptNegative="Left"
                                DisplayMoney="None" ErrorTooltipEnabled="True" InputDirection="RightToLeft" Mask="9,999,999,999,999"
                                MaskType="Number" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus"
                                OnInvalidCssClass="MaskedEditError" TargetControlID="txtContractAmount2"></ajaxToolkit:MaskedEditExtender>
                            <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator4" runat="server" ControlExtender="MaskedEditExtender4"
                                ControlToValidate="txtContractAmount2" Display="Dynamic" EmptyValueBlurredText="*"
                                EmptyValueMessage="Number is required" InvalidValueBlurredMessage="*" InvalidValueMessage="Number is invalid"
                                IsValidEmpty="False" TooltipMessage="Input the amount" ValidationGroup="MKE">
                                </ajaxToolkit:MaskedEditValidator>
                        </td>
                        <td style="vertical-align: top; width: 50%; text-align: center"></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; width: 50%; text-align: center">
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidDocPrepDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtMtdApprovalDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtAdvertDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidSubmissionDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidOpeningDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidValidityExpiryDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender9" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidSecurityExpiryDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender10" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtEvalRptReadyDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender11" runat="server" CssClass="MyCalendar"
                                Enabled="True" Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtCCERApprovalDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender12" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtNRReportReadyDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender13" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtCCNRApprovalDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender14" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBEBNoticeDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender15" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBoardPaperSubmissionDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender16" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBoardApprovalDate"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="vertical-align: top; width: 50%; text-align: center">
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender17" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtSGPaperSubmissionDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender18" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtSGApprovalDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender19" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtFundsAvailDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender20" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtLPODate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender21" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractPrepDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender22" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractSigningDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender23" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidSecurityExpiryDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender24" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtPerfSecurityExpDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender25" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractCompletionDate"></ajaxToolkit:CalendarExtender>
                            &nbsp;
                                   
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender26" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractCompletionDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender27" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtReceiptOfPaymentDocDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender28" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtFinanceSubmissionDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender29" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtPaymentDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender30" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtFileClosureDate"></ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; width: 50%; text-align: center">
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender31" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidDocPrepDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender32" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtMtdApprovalDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender33" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtAdvertDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender34" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidSubmissionDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender35" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidOpeningDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender36" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidValidityExpiryDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender37" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidSecurityExpiryDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender38" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtEvalRptReadyDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender39" runat="server" CssClass="MyCalendar"
                                Enabled="True" Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtCCERApprovalDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender40" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtNRReportReadyDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender41" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtCCNRApprovalDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender42" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBEBNoticeDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender43" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBoardPaperSubmissionDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender44" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBoardApprovalDate2"></ajaxToolkit:CalendarExtender>
                        </td>
                        <td style="vertical-align: top; width: 50%; text-align: center">
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender45" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtSGPaperSubmissionDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender46" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtSGApprovalDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender47" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtFundsAvailDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender48" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtLPODate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender49" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractPrepDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender50" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractSigningDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender51" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidSecurityExpiryDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender52" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtPerfSecurityExpDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender53" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractCompletionDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender54" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractCompletionDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender55" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtReceiptOfPaymentDocDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender56" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtFinanceSubmissionDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender57" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtPaymentDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender58" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtFileClosureDate2"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender59" runat="server" CssClass="MyCalendar"
                                Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtPreparationDate"></ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; width: 50%; text-align: center"></td>
                        <td style="vertical-align: top; width: 50%; text-align: center"></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: center" colspan="2"></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; width: 50%; text-align: center"></td>
                        <td style="vertical-align: top; width: 50%; text-align: center"></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class="form-group row">
                    <div class="col-sm-5 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        Approve/Reject Activity Schedule
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Approve Requisition</div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:RadioButtonList ID="rbnApproval" runat="server" >
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Comment (If Required)
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtComment" runat="server" CssClass="form-control"
                                            TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-5 mb-3 mb-sm-0"></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary btn-user btn-block float-right"
                                Text="SUBMIT" Font-Bold="True" OnClick="btnSubmit_Click" />
                    </div>

                </div>
            </asp:View>
                    <asp:View ID="View4" runat="server">
                        <table id="Table1" style="width: 100%">
                            <tr>
                                <td style="width: 100%; height: 21px; text-align: right">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%; text-align: center">
                                    <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"
                                        ForeColor="Maroon" Text="."></asp:Label><br />
                                    <br />
                                    <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Return"
                                        Width="89px" /></td>
                            </tr>
                            <tr>
                                <td style="width: 100%; height: 21px; text-align: right">
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <asp:Label ID="lblreqn" runat="server" Text="Label" Visible="False"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>

