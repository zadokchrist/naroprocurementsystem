<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Requisition_ActivitySchedule.aspx.cs" Inherits="Requisition_ActivitySchedule" Title="ACTIVITY SCHEDULE" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table align="center" cellpadding="0" cellspacing="0" class="form-control">
        <tr>
            <td colspan="2" style="vertical-align: top; height: 16px; text-align: center">
                 <%--<ajaxToolkit:ToolkitScriptManager  ID="ScriptManager1" runat="server">
                </ajaxToolkit:ToolkitScriptManager>--%>
                   <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>

                <table align="center" cellpadding="0" cellspacing="0" style="width: 50%">
                    <tr>
                        <td class="InterfaceHeaderLabel" style="height: 20px">
                            <asp:Label ID="lblHeader" runat="server" Text="PROCUREMENT PLAN ACTIVITY SCHEDULE"></asp:Label>
                            
                            </td>
                    </tr>
                </table>
                </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 50%; height: 16px; text-align: center">
            </td>
            <td style="vertical-align: top; width: 50%; height: 16px; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; height: 10px; text-align: center" colspan="2">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 60%; height: 20px">
                    <tr>
                        <td class="InterfaceHeaderLabel3" style="height: 10px">
                            Activity Schedule</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="vertical-align: top; height: 10px; text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 50%; height: 5px; text-align: center">
            </td>
            <td style="vertical-align: top; width: 50%; height: 5px; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 50%; height: 50px; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                    <tr>
                        <td colspan="3" style="vertical-align: top; height: 10px; text-align: center">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                        PDU Category</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%; height: 30px">
                                        <asp:DropDownList ID="cboCompany" runat="server" CssClass="InterfaceDropdownList"
                                            Width="82%">
                                                    <asp:ListItem Value="0">-- ALL DEPARTMENTS --</asp:ListItem>
                                <asp:ListItem Value="1">SMALL PROCUREMENT</asp:ListItem>
                                <asp:ListItem Value="2">LARGE PROCUREMENT</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                        Ref. No/ PR Number</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px;">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%; height: 30px;">
                                        <asp:TextBox ID="txtPRNumber" runat="server" CssClass="InterfaceTextboxLongReadOnly"
                                            Width="80%" MaxLength="10" Font-Bold="True" ForeColor="Firebrick" ReadOnly="True" Enabled="False"></asp:TextBox>&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Procurement Description</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtProcDescription" runat="server" CssClass="InterfaceTextboxMultiline"
                                            Style="width: 80%; height: 55px" TextMode="MultiLine" Width="95%" Height="12px" Enabled="False"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Estimated Cost</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                    </td>
                                    <td class="InterFaceTableRightRow">
                                        <asp:TextBox ID="txtEstimatedCost" runat="server" Font-Bold="True"  onkeyup="javascript:this.value=Comma(this.value);"
                                            Font-Size="" ForeColor="Firebrick"
                                            Width="80%" Enabled="False"></asp:TextBox>
                                        <br />
                                        <cc1:FilteredTextBoxExtender id="FTEEstimatedCost" runat="server" FilterType="Custom,Numbers"
                                            TargetControlID="txtEstimatedCost" ValidChars=",">
                                        </cc1:FilteredTextBoxExtender></td>
                                </tr>
                                
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                        Funding Source</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px;">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%; height: 30px;">
                                        <asp:DropDownList ID="cboFunding" runat="server" CssClass="InterfaceDropdownList"
                                            OnDataBound="cboFunding_DataBound" Width="82%">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Start Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtStart" runat="server" autocomplete="off" Font-Bold="True" ForeColor=""
                                            Width="80%" ></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Procurement Method</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:DropDownList ID="cboProcurementMethod" runat="server"
                                            CssClass="InterfaceDropdownList" OnDataBound="cboProcurementMethod_DataBound"
                                            Width="82%">
                                        </asp:DropDownList></td>
                                </tr>
                            
                                 <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                       Start of Bid/Proposal Receipt Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtBidStartDate" runat="server" autocomplete="off" Font-Bold="True" ForeColor=""
                                            Width="80%" OnTextChanged="txtBidStartDate_TextChanged"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                       End of Bid/Proposal Receipt Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtBidEndDate" runat="server" autocomplete="off" Font-Bold="True" ForeColor=""
                                            Width="80%" OnTextChanged="txtBidEndDate_TextChanged"  ></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                     <tr>
                                                <td class="InterFaceTableLeftRowUp">
                                            Cummulative Period  &nbsp;</td>
                                                <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                </td>
                                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                    <asp:TextBox ID="txtCummulativePeriod" runat="server" autocomplete="off" Font-Bold="True"
                                                        ForeColor="" ReadOnly="True" Width="80%"></asp:TextBox>&nbsp;
                                                </td>
                                            </tr>
                                <tr>
                        <td class="InterFaceTableLeftRowUp">
                                      <asp:Label runat="server" ID="lbl1" Text="EOI submission start date"></asp:Label> </td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                    </td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtEOIStart" runat="server" Font-Bold="False"  
                                ForeColor="Firebrick" Style="width: 90%" ToolTip="Planned Total Cost" Width="80%" ReadOnly="True"></asp:TextBox>
                            &nbsp;
                        </td>
                    </tr>
                                            <tr>
                        <td class="InterFaceTableLeftRowUp">
                                      <asp:Label runat="server" ID="Label1" Text="EOI submission end date"></asp:Label> </td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                    </td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtEOIEnd" runat="server" Font-Bold="False"  
                                ForeColor="Firebrick" Style="width: 90%" ToolTip="Planned Total Cost" Width="80%" ReadOnly="True"></asp:TextBox>
                            &nbsp;
                        </td>
                    </tr>
                            </table>
                            <asp:Label ID="lblreqn" runat="server" ForeColor="Firebrick" Text="." Visible="False"></asp:Label></td>
                    </tr>
                </table>
                
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtStart">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtBidStartDate">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtBidEndDate">
                </ajaxToolkit:CalendarExtender>
            </td>
            <td style="vertical-align: top; width: 50%; height: 100px; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                </table><table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                    <tr>
                        <td colspan="3" style="vertical-align: top; height: 10px; text-align: center">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Date Assigned</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtDateAssigned" runat="server" Width="80%" ReadOnly="True"></asp:TextBox></td>
                                </tr>
                               <%-- 
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Prepared By</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%"><asp:DropDownList ID="cboPreparedBy" runat="server"
                                            CssClass="InterfaceDropdownList" 
                                            Width="82%">
                                          <asp:ListItem Value="7">Procurement Officer</asp:ListItem>
                                    </asp:DropDownList></td>
                                </tr>--%>
                              
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Preparation Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtPreparationDate" runat="server" autocomplete="off"
                                            Font-Bold="True" ForeColor="" Width="80%"></asp:TextBox></td>
                                </tr>
                                  <tr>
                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                        Procurement Supervisor
                                        </td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px;">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%; height: 30px;">
                                         <asp:DropDownList ID="cboPDUHead" runat="server"
                                            CssClass="InterfaceDropdownList" 
                                            Width="82%">
                                       <%-- <asp:ListItem Value="7">Procurement Manager</asp:ListItem>--%>
                                    </asp:DropDownList>


                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Procurement Manager</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:DropDownList ID="cboSupervisor" runat="server"
                                            CssClass="InterfaceDropdownList"
                                            Width="82%">
                                        
                                    </asp:DropDownList>
                                       </td>
                                </tr>

                      
                                            
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" colspan="3" style="padding-left: 50px;">
                                        <asp:Label ID="txtPlanApproved" runat="server" Text="." ForeColor="Firebrick"></asp:Label>
                                        <asp:Label ID="lblPD_Code" runat="server" Text="PD_Code" Visible="False"></asp:Label></td>
                                    
                        
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px">
                        </td>
                                </tr>
                                 <tr>
                        
                        <td class="InterFaceTableRightRow" colspan="2">
                            <asp:CheckBox ID="chkSubmit" CssClass="form-control" runat="server"  Text="SUBMIT FOR APPROVAL" /></td>
                    </tr>
                                <tr>

                                    <td class="InterFaceTableLeftRowUp" style="width: 30%; border-top-style: none; height: 30px">
                            <asp:Label ID="lblColumnNo" runat="server" ForeColor="Black" Text="." Visible="False"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <span style="font-size: 14px; color: #000066; font-family: Cambria; background-color: #ebf3ff; height: 50px;">
                </span></td>
        </tr>
        <tr>
            <td colspan="2" style="vertical-align: top; height: 15px; text-align: center">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="vertical-align: top; height: 15px; text-align: center">
            </td>
        </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
        <%--<asp:View ID="View1" runat="server">
            <table align="center" cellpadding="0" cellspacing="0" class="style12">
                <tr>
                    <td style="vertical-align: top; width: 50%; height: 16px; text-align: center">
                    </td>
                    <td style="vertical-align: top; width: 50%; height: 16px; text-align: center">
                    </td>
                </tr>
        <tr>
            <td colspan="2" style="vertical-align: top; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 99%; height: 20px">
                    <tr>
                        <td class="InterfaceHeaderLabel3" style="height: 10px">
                            Activity Schedule Details</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="vertical-align: top; text-align: center; height: 10px;">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 50%; height: 100px; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 30%; border-top-style: none; height: 30px">
                            <asp:Label ID="lblColumnNo" runat="server" ForeColor="Black" Text="." Visible="False"></asp:Label></td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px">
                        </td>
                        <td class="InterFaceTableRightRowUp" colspan="2" style="vertical-align: middle; height: 30px;
                            text-align: center">
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Firebrick" Style="vertical-align: middle;
                                text-align: center" Text="PLANNED VS ACTUAL"></asp:Label></td>
                    </tr>
                    <tr style="color: #000000">
                        <td class="InterFaceTableLeftRowUp">
                            Bid Doc. Preparation Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn1" runat="server" Text=".." Width="100%" OnClick="btn1_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtBidDocPrepDate" runat="server" Font-Bold="False"
                                ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow">
                            <asp:TextBox ID="txtBidDocPrepDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr style="color: #000000">
                        <td class="InterFaceTableLeftRowUp">
                            Method/Bid Doc Appr. Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn2" runat="server" Text=".." Width="100%" OnClick="btn2_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtMtdApprovalDate" runat="server" style="width: 90%" Width="80%"></asp:TextBox></td>
                        <td class="InterFaceTableRightRow">
                            <asp:TextBox ID="txtMtdApprovalDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            Advert Date (Bid Invitation)</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn3" runat="server" Text=".." Width="100%" OnClick="btn3_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtAdvertDate" runat="server" Font-Bold="False"
                                ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow">
                            <asp:TextBox ID="txtAdvertDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            Bid Submission Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn4" runat="server" Text=".." Width="100%" OnClick="btn4_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtBidSubmissionDate" runat="server" Font-Bold="False"
                                ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow">
                            <asp:TextBox ID="txtBidSubmissionDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                           Pre Bid Meeting</td>
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
                        <td class="InterFaceTableLeftRowUp">
                            Bid Opening Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn5" runat="server" Text=".." Width="100%" OnClick="btn5_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtBidOpeningDate" runat="server" Font-Bold="False"
                                ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtBidOpeningDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            Bid Validity Expiry &nbsp;Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn6" runat="server" Text=".." Width="100%" OnClick="btn6_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtBidValidityExpiryDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtBidValidityExpiryDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            Bid Security Expiry Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn7" runat="server" Text=".." Width="100%" OnClick="btn7_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtBidSecurityExpiryDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtBidSecurityExpiryDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            Evaluation Report Ready Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn8" runat="server" Text=".." Width="100%" OnClick="btn8_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtEvalRptReadyDate" runat="server" Font-Bold="False"
                                ForeColor="" Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtEvalRptReadyDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            CC. (ER) Approval &nbsp;Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn9" runat="server" Text=".." Width="100%" OnClick="btn9_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtCCERApprovalDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtCCERApprovalDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            Negott_n Report Ready Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn10" runat="server" Text=".." Width="100%" OnClick="btn10_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtNRReportReadyDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtNRReportReadyDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            CC. (NR) Approval &nbsp;Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn11" runat="server" Text=".." Width="100%" OnClick="btn11_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtCCNRApprovalDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%" ToolTip="Negotiation Report Approval Date by CC"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtCCNRApprovalDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%" ToolTip="Actual Negotiation Report Approval Date by CC"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="height: 30px; width: 30%;">
                                        BEB Notice Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px;">
                            <asp:Button ID="btn12" runat="server" Text=".." Width="100%" OnClick="btn12_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRowUp" style="width: 34%; height: 30px;">
                            <asp:TextBox ID="txtBEBNoticeDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                        <td class="InterFaceTableRightRowUp" style="width: 34%; height: 30px">
                            <asp:TextBox ID="txtBEBNoticeDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="height: 30px; width: 30%;">
                            Board Paper Submission Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px;">
                            <asp:Button ID="btn13" runat="server" Text=".." Width="100%" OnClick="btn13_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRowUp" style="width: 34%; height: 30px;">
                            <asp:TextBox ID="txtBoardPaperSubmissionDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                        <td class="InterFaceTableRightRowUp" style="width: 34%; height: 30px">
                            <asp:TextBox ID="txtBoardPaperSubmissionDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="height: 30px; width: 30%;">
                            Board Approval Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px;">
                            <asp:Button ID="btn14" runat="server" Text=".." Width="100%" OnClick="btn14_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRowUp" style="width: 34%; height: 30px;">
                            <asp:TextBox ID="txtBoardApprovalDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                        <td class="InterFaceTableRightRowUp" style="width: 34%; height: 30px">
                            <asp:TextBox ID="txtBoardApprovalDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                </table>
            </td>
            <td style="vertical-align: top; width: 50%; height: 100px; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 30%; border-top-style: none; height: 30px">
                        </td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px">
                        </td>
                        <td class="InterFaceTableRightRowUp" colspan="2" style="vertical-align: middle; height: 30px;
                            text-align: center">
                            <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Firebrick" Style="vertical-align: middle;
                                text-align: center" Text="PLANNED VS ACTUAL"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="height: 30px; width: 30%;">
                            S.G. Paper &nbsp;Submission Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px;">
                            <asp:Button ID="btn15" runat="server" Text=".." Width="100%" OnClick="btn15_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRowUp" style="width: 34%; height: 30px;">
                            <asp:TextBox ID="txtSGPaperSubmissionDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                        <td class="InterFaceTableRightRowUp" style="width: 66%; height: 30px">
                            <asp:TextBox ID="txtSGPaperSubmissionDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="height: 30px; width: 30%;">
                            Sol. General Approval Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px;">
                            <asp:Button ID="btn16" runat="server" Text=".." Width="100%" OnClick="btn16_Click" ToolTip="Click to add a comment" /></td><td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtSGApprovalDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%">
                            <asp:TextBox ID="txtSGApprovalDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                                        Funds Available Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn17" runat="server" Text=".." Width="100%" OnClick="btn17_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtFundsAvailDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%">
                            <asp:TextBox ID="txtFundsAvailDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            Bid Acceptance. (LPO) &nbsp;Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn18" runat="server" Text=".." Width="100%" OnClick="btn18_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtLPODate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%">
                            <asp:TextBox ID="txtLPODate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            Contract Preparation Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn19" runat="server" Text=".." Width="100%" OnClick="btn19_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtContractPrepDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%">
                            <asp:TextBox ID="txtContractPrepDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                                        Contract Signing Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn20" runat="server" Text=".." Width="100%" OnClick="btn20_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtContractSigningDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%">
                            <asp:TextBox ID="txtContractSigningDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            Perf. &nbsp;Security Exp. Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn21" runat="server" Text=".." Width="100%" OnClick="btn21_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtPerfSecurityExpDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%">
                            <asp:TextBox ID="txtPerfSecurityExpDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                                        Contract Amount (UGX)</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn22" runat="server" Text=".." Width="100%" OnClick="btn22_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtContractAmount" runat="server" Font-Bold="False"  onkeyup="javascript:this.value=Comma(this.value);"
                                ForeColor="Firebrick" Style="width: 90%" ToolTip="Planned Total Cost" Width="80%" ReadOnly="True"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 33%; height: 30px">
                            <asp:TextBox ID="txtContractAmount2" runat="server" Font-Bold="True" Font-Size=""  onkeyup="javascript:this.value=Comma(this.value);"
                                ForeColor="Firebrick" Style="width: 90%" ToolTip="Actual Contract Amount" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            Contract
                            Completion Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn23" runat="server" Text=".." Width="100%" OnClick="btn23_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtContractCompletionDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%">
                            <asp:TextBox ID="txtContractCompletionDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            Date-Receipt of Payment Doc</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn24" runat="server" Text=".." Width="100%" OnClick="btn24_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtReceiptOfPaymentDocDate" runat="server" Font-Bold="False"
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%">
                            <asp:TextBox ID="txtReceiptOfPaymentDocDate2" runat="server" Font-Bold="True" Font-Size=""
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            Submission To Finance Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn25" runat="server" Text=".." Width="100%" OnClick="btn25_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtFinanceSubmissionDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%">
                            <asp:TextBox ID="txtFinanceSubmissionDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            Payment Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn26" runat="server" Text=".." Width="100%" OnClick="btn26_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtPaymentDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%">
                            <asp:TextBox ID="txtPaymentDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            File Closure Date</td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                            <asp:Button ID="btn27" runat="server" Text=".." Width="100%" OnClick="btn27_Click" ToolTip="Click to add a comment" /></td>
                        <td class="InterFaceTableRightRow" style="width: 33%">
                            <asp:TextBox ID="txtFileClosureDate" runat="server" Font-Bold="False" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox>
                            &nbsp;
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%">
                            <asp:TextBox ID="txtFileClosureDate2" runat="server" Font-Bold="True" Font-Size="" ForeColor=""
                                Style="width: 90%" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                        </td>
                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                        </td>
                        <td class="InterFaceTableRightRow" colspan="2">
                            <asp:CheckBox ID="chkSubmit" runat="server" Font-Bold="True" Text="SUBMIT FOR APPROVAL" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="vertical-align: top; height: 15px; text-align: center">
                <asp:Label ID="Label1" runat="server" Text="."></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="vertical-align: top; height: 15px; text-align: center">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="vertical-align: top; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 20%">
                    <tr>
                        <td style="vertical-align: middle; width: 16%; height: 23px; text-align: right">
                            <asp:Button ID="Button2" runat="server" Font-Size="9pt" Height="23px"
                                OnClick="btnOK_Click" Text="OK" Width="85px" />
                        </td>
                        <td style="vertical-align: middle; width: 16%; height: 23px; text-align: left">
                            <asp:Button ID="Button3" runat="server" Font-Size="9pt" Height="23px" OnClick="btnCancel_Click"
                                Text="Cancel" Width="85px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
                <tr>
                    <td style="vertical-align: top; width: 50%; text-align: center; height: 46px;">
                        &nbsp;<cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender3" runat="server" FilterType="Custom,Numbers"
                                            TargetControlID="txtContractAmount" ValidChars=",">
                        </cc1:FilteredTextBoxExtender>
                    </td>
                    <td style="vertical-align: top; width: 50%; text-align: center; height: 46px;">
                        &nbsp;<cc1:FilteredTextBoxExtender id="FilteredTextBoxExtender2" runat="server" FilterType="Custom,Numbers"
                                            TargetControlID="txtContractAmount2" ValidChars=",">
                        </cc1:FilteredTextBoxExtender>
                    </td>
                    <td style="vertical-align: top; width: 50%; text-align: center; height: 46px;">
                    </td>
                </tr>
        <tr>
            <td style="vertical-align: top; width: 50%; text-align: center">
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidDocPrepDate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtMtdApprovalDate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtAdvertDate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidSubmissionDate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidOpeningDate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender6" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidValidityExpiryDate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender7" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidSecurityExpiryDate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender8" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtEvalRptReadyDate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender9" runat="server" CssClass="MyCalendar"
                    Enabled="True" Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtCCERApprovalDate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender10" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtNRReportReadyDate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender11" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtCCNRApprovalDate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender12" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBEBNoticeDate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender13" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBoardPaperSubmissionDate">
                </cc1:CalendarExtender>
                <cc1:CalendarExtender ID="CalendarExtender14" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBoardApprovalDate">
                </cc1:CalendarExtender>
            </td>
                    <td style="vertical-align: top; width: 50%; text-align: center">
                        <cc1:CalendarExtender ID="CalendarExtender15" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtSGPaperSubmissionDate">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender16" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtSGApprovalDate">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender17" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtFundsAvailDate">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender19" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtLPODate">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender18" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractPrepDate">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender20" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractSigningDate">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender21" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidSecurityExpiryDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender22" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtPerfSecurityExpDate">
                        </cc1:CalendarExtender><cc1:CalendarExtender ID="CalendarExtender23" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractCompletionDate">
                        </cc1:CalendarExtender>
                        &nbsp;
                        <cc1:CalendarExtender ID="CalendarExtender24" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractCompletionDate">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender25" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtReceiptOfPaymentDocDate">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender26" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtFinanceSubmissionDate">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender27" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtPaymentDate">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender28" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtFileClosureDate">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender58" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtprebidmeeting">
                        </cc1:CalendarExtender>
                    </td>
        </tr>
                <tr>
                    <td style="vertical-align: top; width: 50%; text-align: center">
                        <cc1:CalendarExtender ID="CalendarExtender29" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidDocPrepDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender30" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtMtdApprovalDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender31" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtAdvertDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender32" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidSubmissionDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender33" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidOpeningDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender34" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidValidityExpiryDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender35" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidSecurityExpiryDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender36" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtEvalRptReadyDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender37" runat="server" CssClass="MyCalendar"
                    Enabled="True" Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtCCERApprovalDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender38" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtNRReportReadyDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender39" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtCCNRApprovalDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender40" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBEBNoticeDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender41" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBoardPaperSubmissionDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender42" runat="server" CssClass="MyCalendar"
                    Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBoardApprovalDate2">
                        </cc1:CalendarExtender>
                    </td>
                    <td style="vertical-align: top; width: 50%; text-align: center">
                        <cc1:CalendarExtender ID="CalendarExtender43" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtSGPaperSubmissionDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender44" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtSGApprovalDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender45" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtFundsAvailDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender46" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtLPODate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender47" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractPrepDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender48" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractSigningDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender49" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtBidSecurityExpiryDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender50" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtPerfSecurityExpDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender51" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractCompletionDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender52" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtContractCompletionDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender53" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtReceiptOfPaymentDocDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender54" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtFinanceSubmissionDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender55" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtPaymentDate2">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender56" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtFileClosureDate2">
                        </cc1:CalendarExtender><cc1:CalendarExtender ID="CalendarExtender57" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtPreparationDate">
                        </cc1:CalendarExtender>
                        <cc1:CalendarExtender ID="CalendarExtender59" runat="server" CssClass="MyCalendar"
                            Format="MMMM d,yyyy" PopupPosition="TopLeft" TargetControlID="txtprebidmeeting2">
                        </cc1:CalendarExtender>

                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 50%; text-align: center">
                    </td>
                    <td style="vertical-align: top; width: 50%; text-align: center">
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 50%; text-align: center">
                    </td>
                    <td style="vertical-align: top; width: 50%; text-align: center">
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 50%; text-align: center">
                    </td>
                    <td style="vertical-align: top; width: 50%; text-align: center">
                    </td>
                </tr>
            </table>
        </asp:View>--%>
        <asp:View ID="View2" runat="server">
            <table align="center" cellpadding="0" cellspacing="0" class="style12">
                <tr>
                    <td colspan="2" style="vertical-align: top; height: 16px; text-align: center">
                        &nbsp;<table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                            <tr>
                                <td class="InterfaceHeaderLabel" style="height: 20px">
                                    <asp:Label ID="lblCommentTitle" runat="server" Text="ADD COMMENTS" ForeColor="Firebrick"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="vertical-align: top; height: 100px; text-align: center">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td colspan="3" style="vertical-align: top; height: 10px; text-align: center"><table align="center" cellpadding="0" cellspacing="0" width="60%">
                                 <%--   <tr>
                                        <td class="InterFaceTableLeftRowUp" style="width: 30%">
                                            Planned</td>
                                        <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                        </td>
                                        <td class="InterFaceTableRightRowUp" style="width: 68%">
                                            <asp:TextBox ID="txtPlanned" runat="server" Font-Bold="True" ReadOnly="True" Width="40%"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="InterFaceTableLeftRowUp" style="width: 30%; height: 30px">
                                            Actual</td>
                                        <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px;">
                                        </td>
                                        <td class="InterFaceTableRightRowUp" style="width: 68%; height: 30px;">
                                            <asp:TextBox ID="txtActual" runat="server" autocomplete="off" Font-Bold="True" ForeColor=""
                                                ReadOnly="True" Width="40%"></asp:TextBox>&nbsp;
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="InterFaceTableLeftRowUp" colspan="3" style="padding-left: 50px;">
                                        </td>
                                    </tr>
                                </table>
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="width: 30%">
                                                COMMENTS / REMARK:</td>
                                            <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                            </td>
                                            <td class="InterFaceTableRightRowUp" style="width: 68%">
                                                <asp:TextBox ID="txtComment" runat="server" CssClass="InterfaceTextboxMultiline" Height="15px"
                                                    Style="width: 95%; height: 50px" TextMode="MultiLine" Width="80%"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="3" style="vertical-align: top; height: 10px; text-align: center">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 20%">
                            <tr>
                                <td style="vertical-align: middle;  text-align: right">
                                    <asp:Button ID="btnSave" runat="server" Font-Size="9pt" Height="23px"
                                OnClick="btnOK_Click" Text="Save" Width="95px" />
                                </td>
                                <td style="vertical-align: middle;  text-align: left">
                                    <asp:Button ID="btnCancelComment" runat="server" Font-Size="9pt" Height="23px"
                                OnClick="btnCancelComment_Click" Text="Cancel/Return" Width="95px" /></td>
                            </tr>
                        </table>
                                </td>
                            </tr>
                        </table>
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                        </table>
                        <span style="font-size: 14px; color: #000066; font-family: Cambria; background-color: #ebf3ff; height: 50px;"></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="vertical-align: top; height: 15px; text-align: center">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="vertical-align: top; text-align: center">
                    </td>
                </tr>
            </table>
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
                        <asp:Button ID="btnReturn" runat="server"
                            Text="Return" Width="89px" OnClick="btnReturn_Click" /></td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 21px; text-align: right">
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>    
    
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
    
    </script>
        
</asp:Content>

