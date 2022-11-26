<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Bidding_PendingProcurements.aspx.cs" Inherits="Bidding_PendingProcurements" Title="PENDING PROCUREMENT(S)" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                <asp:label id="lblTitle" runat="server" text="ASSIGNED
                            PROCUREMENTS" ForeColor="Red" />
            </div>
            </div>
        </div>
    </div>
    <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td style="vertical-align: top; width: 50%; text-align: center">
                <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid;
                    border-left: #617da6 1px solid; width: 99%; border-bottom: #617da6 1px solid">
                    <tr>
                        <td style="vertical-align: top; text-align: center">
                            <asp:MultiView ID="Details" runat="server">
                                <asp:View ID="View9" runat="server">
        <table  align="center" cellpadding="0" cellspacing="0" style="width: 99%">
        <tr>
            <td style="vertical-align: top; width: 50%; height: 50px; text-align: center" colspan="3">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                    <tr>
                        <td colspan="3" style="vertical-align: top; height: 10px; text-align: center">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">PDU Category</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px"></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%; height: 30px">
                                        <asp:DropDownList ID="cboCompany" runat="server" CssClass="InterfaceDropdownList"
                                            Width="82%">
                                               <asp:ListItem Value="1">SMALL PROCUREMENT</asp:ListItem>
                                <asp:ListItem Value="2">LARGE PROCUREMENT</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">Ref. No/ PR Number</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px;"></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%; height: 30px;">
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="InterfaceTextboxLongReadOnly"
                                            Width="80%" MaxLength="10" Font-Bold="True" ForeColor="Firebrick" ReadOnly="True" Enabled="False"></asp:TextBox>&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Procurement Description</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%"></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtProcDescription" runat="server" CssClass="InterfaceTextboxMultiline"
                                            Style="width: 80%; height: 55px" TextMode="MultiLine" Width="95%" Height="12px" Enabled="False"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Estimated Cost</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%"></td>
                                    <td class="InterFaceTableRightRow">
                                        <asp:TextBox ID="TextBox2" runat="server" Font-Bold="True" onkeyup="javascript:this.value=Comma(this.value);"
                                            Font-Size="" ForeColor="Firebrick"
                                            Width="80%" Enabled="False"></asp:TextBox>
                                        <br />
                                        <cc1:FilteredTextBoxExtender ID="FTEEstimatedCost" runat="server" FilterType="Custom,Numbers"
                                            TargetControlID="txtEstimatedCost" ValidChars=","></cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">Funding Source</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px;"></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%; height: 30px;">
                                        <asp:DropDownList ID="cboFunding" runat="server" CssClass="InterfaceDropdownList" Enabled="false"
                                            OnDataBound="cboFunding_DataBound" Width="82%">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Start Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%"></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtStart" runat="server" autocomplete="off" Font-Bold="True" ForeColor=""
                                            Width="80%" ></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Procurement Method</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%"></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:DropDownList ID="DropDownList1" runat="server"
                                            CssClass="InterfaceDropdownList" OnDataBound="cboProcurementMethod_DataBound" Enabled="false"
                                            Width="82%">
                                        </asp:DropDownList></td>
                                </tr>

                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Start of Bid Receipt Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%"></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtBidStartDate" runat="server" autocomplete="off" Font-Bold="True" ForeColor=""
                                            Width="80%" ></asp:TextBox>&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td class="InterFaceTableLeftRowUp">End of Bid Receipt Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%"></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtBidEndDate" runat="server" autocomplete="off" Font-Bold="True" ForeColor=""
                                            Width="80%"></asp:TextBox>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Cummulative Period</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%"></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtCummulativePeriod" runat="server" autocomplete="off" Font-Bold="True" ForeColor=""
                                            Width="80%" ReadOnly="True" Enabled="False" ></asp:TextBox>&nbsp;
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
                                      <asp:Label runat="server" ID="Label6" Text="EOI submission end date"></asp:Label> </td>
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

                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtStart"></ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtBidStartDate"></ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtBidEndDate"></ajaxToolkit:CalendarExtender>

                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtPreparationDate"></ajaxToolkit:CalendarExtender>

            </td>
            <td style="vertical-align: top; width: 50%; height: 100px; text-align: center" colspan="3">
               
                <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                    <tr>
                        <td colspan="3" style="vertical-align: top; height: 10px; text-align: center">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Date Assigned</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%"></td>
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
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                        Responsible Officer
                                        </td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px;">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%; height: 30px;"><asp:DropDownList ID="cboResponsibleOfficer" runat="server"
                                            CssClass="InterfaceDropdownList"
                                            Width="82%">
                                        <asp:ListItem Value="7">Procurement Officer</asp:ListItem>
                                    </asp:DropDownList></td>
                                </tr>--%>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Preparation Date</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%"></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtPreparationDate" runat="server" autocomplete="off"
                                            Font-Bold="True" ForeColor="" Width="80%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">Procurement Supervisor</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%"></td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:DropDownList ID="cboPDUHead" runat="server"
                                            CssClass="InterfaceDropdownList"
                                            Width="82%">
                                            <%-- <asp:ListItem Value="7">Procurement Manager</asp:ListItem>--%>
                                        </asp:DropDownList></td>
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
                                        <asp:Label ID="Label5" runat="server" Text="PD_Code" Visible="False"></asp:Label></td>


                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%; height: 30px"></td>
                                </tr>
                                <tr>

                                    <td class="InterFaceTableLeftRowUp" style="width: 30%; border-top-style: none; height: 30px">
                                        <asp:Label ID="lblColumnNo" runat="server" ForeColor="Black" Text="." Visible="False"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <span style="font-size: 14px; color: #000066; font-family: Cambria; background-color: #ebf3ff; height: 50px;"></span></td>
        </tr>

        </table>
    </asp:View>
                            </asp:MultiView>
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
                            PROC. METHOD</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            AREA</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            Cost CENTER</td>
                            <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                           STATUS</td>
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
                            <asp:DropDownList ID="cbostatus" runat="server" CssClass="InterfaceDropdownList"
                               Width="95%">
                     <asp:ListItem Value="0">-- Select Status --</asp:ListItem>
                  
                                <asp:ListItem Value="45" Text="Docs & Shortlist Approved"></asp:ListItem>
                                <asp:ListItem Value="36" Text="EOI submission open"></asp:ListItem>
                                <asp:ListItem Value="37" Text="EOI submission evaluation saved"></asp:ListItem>
                                <asp:ListItem Value="28" Text="EOI evaluation rejected"></asp:ListItem>
                                <asp:ListItem Value="44" Text="EOI evaluation approved by MD"></asp:ListItem>
                                <asp:ListItem Value="48" Text="Draft RFP saved"></asp:ListItem>
                                <asp:ListItem Value="28" Text="Draft RFP rejected"></asp:ListItem>
                                <asp:ListItem Value="50" Text="Bid/Proposal submission open"></asp:ListItem>
                                <asp:ListItem Value="52" Text="Bid/Proposal submission closed"></asp:ListItem>
                                <asp:ListItem Value="54" Text="Technical evaluation"></asp:ListItem>
                                <asp:ListItem Value="58" Text="Technical evaluation approved"></asp:ListItem>
                                <asp:ListItem Value="53" Text="Technical & Financial evaluation"></asp:ListItem>
                                <asp:ListItem Value="65" Text="Technical & Financial evaluation rejected by Supervisor"></asp:ListItem>
                                <asp:ListItem Value="74" Text="Technical & Financial evaluation rejected by MD"></asp:ListItem>
                                <asp:ListItem Value="69" Text="Award of contract approved by MD"></asp:ListItem>
                                <asp:ListItem Value="61" Text="Draft contract saved"></asp:ListItem>
                                <asp:ListItem Value="76" Text="Draft contract rejected"></asp:ListItem>
                                <asp:ListItem Value="77" Text="Contract sent to firm by PM"></asp:ListItem>
                                <asp:ListItem Value="125" Text="Bid documents Received from supplier"></asp:ListItem>
                     <%--<asp:ListItem Value="47">Procurement Proc Method/Bid Docs Deferred By MD</asp:ListItem>--%>
                            </asp:DropDownList></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Height="23px" OnClick="btnOK_Click"
                                Text="Search" Width="85px" />&nbsp;</td>
                    </tr>
                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">
                                            <asp:Label ID="lblSection" runat="server" Text="0" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; margin-left: 40px;">
                                                <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="5" GridLines="None" Font-Names="Verdana" Font-Size="Small"
                                                    ForeColor="#333333"  OnItemCommand="DataGrid1_ItemCommand"
                                                    Width="100%" style="text-align: justify">
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <EditItemStyle BackColor="#999999" />
                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" Height="50" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="RecordID" HeaderText="RecordID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CreationDate" HeaderText="Date" DataFormatString="{0:dd MMM yyyy}" Visible="False">
                                                            
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ScalaPRNumber"  ItemStyle-CssClass="gridPad" ItemStyle-Wrap="true" ItemStyle-Width="100" HeaderText="PR Number"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Subject" ItemStyle-Wrap="true" ItemStyle-Width="200" ItemStyle-CssClass="gridPad" HeaderText="Subject"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ProcurementType" ItemStyle-CssClass="gridPad" ItemStyle-Wrap="true"  HeaderText="Type"></asp:BoundColumn>
                                                         <asp:BoundColumn DataField="ProcMethodCode" HeaderText="CreationDate" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Method" ItemStyle-CssClass="gridPad" HeaderText="Method"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="EstimatedCost" ItemStyle-CssClass="gridPad" HeaderText="Est. Cost" DataFormatString="{0:N0}">
                                                        </asp:BoundColumn>
                                                           <asp:BoundColumn DataField="StatusID" HeaderText="Status ID" Visible="False"></asp:BoundColumn>
                                                           <asp:BoundColumn DataField="Remark" HeaderText="Remark" Visible="False"></asp:BoundColumn>
                                                           <asp:BoundColumn DataField="RemarkCreation" HeaderText="CreationDate" Visible="False"></asp:BoundColumn>
                                                       

                                                        <asp:BoundColumn DataField="IsSubmitEnabled" HeaderText="IsSubmitEnabled" Visible="False"></asp:BoundColumn>
                                                        <asp:ButtonColumn CommandName="btnView" HeaderText="VIEW" Text="DETAILS" Visible="False"></asp:ButtonColumn>
                                                      
                                                    
                                                       <asp:TemplateColumn HeaderStyle-CssClass="gridPad"  HeaderText="EOI" >
                                                            <ItemTemplate >
                                                                <asp:LinkButton CssClass="gridPad"   runat="server" ID="btnEOI" CommandName="btnEOI" Text="EOI" Visible="<%# DisableEOI(Container.DataItem) %>"  ></asp:LinkButton> 
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                         <asp:TemplateColumn HeaderText="RFP" >
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" CssClass="gridPad" ID="btnRFP" CommandName="btnRFP" Text="RFP" Visible="<%# DisableRFP(Container.DataItem) %>" ></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                       <%-- <asp:TemplateColumn HeaderText="PROPOSE" HeaderStyle-CssClass="gridPad">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="btnProposeEC" CommandName="btnProposeEC" Text="EC" Visible="<%# DisableLinkEC(Container.DataItem) %>"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>--%>
                                                        
                                                        <asp:TemplateColumn HeaderText="RFP/IFB">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" CssClass="gridPad" ID="btnAddBiddingDoc" CommandName="btnAddBiddingDoc" Text="SUBMISSIONS" Visible="<%# DisableForm(Container.DataItem) %>"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>

                                                          <asp:TemplateColumn  HeaderText="EVALUATION"  >
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="btnEvaluation" CommandName="btnEvaluation" Text= "EVALUATION" Visible="<%# DisableEval(Container.DataItem) %>">  </asp:LinkButton> 
                                                            </ItemTemplate>
                                                              
                                                               <%--Visible="<%# DisableViewComment(Container.DataItem) %>"--%>
                                                        </asp:TemplateColumn>


                                                        <asp:TemplateColumn  HeaderText="CONTRACT">
                                                             <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="btnContract" CommandName="btnContract" Text= "CONTRACT" Visible="<%# DisableContract(Container.DataItem) %>" ></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>

                                                        <%--<asp:TemplateColumn  HeaderText="STATUS">
                                                             <ItemTemplate>
                                                                <asp:LinkButton runat="server" ID="btnStatus" CommandName="btnStatus" Text= "STATUS" ForeColor="OrangeRed" ></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>--%>


                                                     <asp:BoundColumn DataField="HasVat" HeaderText="HasVat" Visible="False"></asp:BoundColumn>

                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                </asp:DataGrid></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:Label ID="lblEmpty" runat="server" Font-Bold="True" ForeColor="Red" Text="."></asp:Label></td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <table id="Table3"  style="width: 98%">
                                        <tr>
                                            <td style="width: 100%; height: 21px; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                                                STAGES OF PROCUREMENT</td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                                                <asp:Button ID="btnStagesExport" runat="server" OnClick="btnStagesExport_Click" Text="Export" />&nbsp;
                                                <asp:Button ID="btnStagesReturn" runat="server" OnClick="btnStagesReturn_Click" Text="Return" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: right">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                                                <asp:DataGrid ID="DataGrid4" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid1_ItemCommand"
                                                    Style="text-align: justify" Width="100%">
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
                                            <td style="width: 100%; text-align: right">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                &nbsp;&nbsp;
                                <asp:View ID="View3" runat="server">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center; width: 940px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center; width: 940px;">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                                    <tr>
                                                        <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                            &gt;&gt;&gt; &nbsp;<asp:Label ID="lblHeading" runat="server" ForeColor="Firebrick"
                                                                Text="0"></asp:Label></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center; width: 50%;">
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
                                                    <tr>
                                                        <td class="InterFaceTableLeftRowUp">
                                                           Is Vat Inclusive</td>
                                                        <td class="InterFaceTableMiddleRowUp">
                                                        </td>
                                                        <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                      <asp:CheckBox ID="chkIsVat" runat="server" AutoPostBack="True" Font-Bold="True"
                                        Font-Italic="True" Text="" oncheckedchanged="chkIsVat_CheckedChanged" />
                                                            </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td colspan="2" style="text-align: center;  width: 50%;">
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
                                            <td colspan="4" style="text-align: center;">
                                                &nbsp;<table align="center" cellpadding="0" cellspacing="0" style="width: 97%">
                                                    <tr>
                                                        <td class="InterFaceTableLeftRowUp">
                                                            Choose Submission Form Section:</td>
                                                        <td class="InterFaceTableMiddleRowUp">
                                                        </td>
                                                        <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                            <asp:DropDownList ID="cboDashboard" runat="server" AutoPostBack="True" BackColor="AliceBlue"
                                                                Font-Bold="True" OnDataBound="cboDashboard_DataBound" OnSelectedIndexChanged="cboDashboard_SelectedIndexChanged"
                                                                Width="96%">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                </table>
                                                            <asp:Label ID="lblProcMethod" runat="server" Text="0" Visible="False"></asp:Label><asp:Label
                                                                ID="lblRefNo" runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblPDCode" runat="server" Text="0"
                                                                            Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="vertical-align: top; width: 940px; position: static; height: 5px;
                                                text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: center; height: 273px;">
                                                &nbsp;
                                                <asp:DataGrid ID="DataGrid3" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" HorizontalAlign="Left"
                                                    Width="97%">
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <EditItemStyle BackColor="#999999" />
                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="Id" HeaderText="Question ID" Visible="false"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Code" HeaderText=" "></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Question" HeaderText="Question">
                                                            <ItemStyle Width="300px" />
                                                        </asp:BoundColumn>
                                                        <asp:TemplateColumn HeaderText="Answer">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtAnswer" runat="server" EnableViewState="true" Text='<%# DataBinder.Eval(Container, "DataItem.Answer") %>'
                                                                    TextMode="MultiLine" Width="300px" Enabled="<%# EnableTextbox(Container.DataItem) %>">
		                                </asp:TextBox>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                </asp:DataGrid></td>
                                        </tr>
                                        <tr align="center">
                                        <td align="center"  class="InterfaceHeaderLabel" style="height: 20px">
                                        Update Procurement Method from here if update is neccessary
                                        </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="text-align: center">
                                            <asp:DropDownList ID="cboProcurementMethod" runat="server"
                                            CssClass="InterfaceDropdownList" OnDataBound="cboProcurementMethod_DataBound"
                                            Width="50%">
                                        </asp:DropDownList>
                                            </td>
                                            <td>
                                            <asp:Button ID="UpdateProcMethod" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                Text="Update ProcMethod"    Width="130px" 
                                                    onclick="UpdateProcMethod_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="text-align: center">
                                                &nbsp;<asp:Button ID="btnSubmit" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                                            OnClick="btnSubmit_Click" Text="Submit" Width="85px" />
                                                            <asp:Button ID="btnPrint" runat="server" Enabled="False" Font-Bold="True" Font-Size="9pt"
                                                                Height="23px" OnClick="btnPrint_Click" Text="Preview" Width="120px" />
                                                            <asp:Button ID="btnDone" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                                OnClick="btnDone_Click" Text="Return" ToolTip="Return to List of Procurements"
                                                                Width="120px" /></td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View4" runat="server">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td colspan="1" style="vertical-align: top; height: 41px">
                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%;margin-left:195px">
                                                                <tr>
                                                                    <td class="InterfaceHeaderLabel" style="height: 20px;margin-left:150px;">
                                                                        <asp:Label ID="lblAddEditItemHeader" runat="server" Text="ADD MICRO PROCUREMENT DETAILS"></asp:Label></td>
                                                                </tr>
                                                            </table>
                                                            <table style="padding-left:30px;margin-left:220px" align="center" width="100%">
                                                                <tr>
                                                                    <td colspan="1" valign="top">
                                                                        <asp:Label ID="lblMsg" runat="server" Font-Bold="False" Font-Names="Cambria" Font-Size="11pt"
                                                                            ForeColor="Red" Text="."></asp:Label></td>
                                                                </tr>
                                                                <tr style="color: #000000">
                                                                    <td style="width: 48%" valign="top">
                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 70%">
                                                                            <tr style="color: #000000">
                                                                                <td class="InterFaceTableLeftRow" style="height: 30px">
                                                                                    Closing Date</td>
                                                                                <td class="InterFaceTableMiddleRow" style="width: 2%; height: 30px">
                                                                                </td>
                                                                                <td class="InterFaceTableRightRow" style="width: 66%; height: 30px">
                                                                                    <asp:TextBox ID="txtClosingDateTime" runat="server" Width="80%"></asp:TextBox><strong>&nbsp;
                                                                                    </strong></td>
                                                                            </tr>
                                                                            <tr style="color: #000000">
                                                                                <td class="InterFaceTableLeftRow" style="height: 30px">
                                                                                    Closing Time</td>
                                                                                <td class="InterFaceTableMiddleRow" style="width: 2%; height: 30px">
                                                                                </td>
                                                                                <td class="InterFaceTableRightRow" style="width: 66%; height: 30px">
                                                                                    <asp:TextBox ID="txtClosingTime" runat="server" Width="80%"></asp:TextBox></td>
                                                                            </tr>
                                                        <tr>
                                                        <td class="InterFaceTableLeftRowUp">
                                                           Is Vat Inclusive</td>
                                                        <td class="InterFaceTableMiddleRowUp">
                                                        </td>
                                                      <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                      <asp:CheckBox ID="IsVat1" runat="server" AutoPostBack="True" Font-Bold="True"
                                        Font-Italic="True" Text="" oncheckedchanged="IsVat1_CheckedChanged" />
                                                            </td>
                                                    </tr>
                                                                            
                                                                        </table>
                                                                        
                                                                        </td>
                                                                </tr>
                                                                
                                                            </table>
                                                        </td>
                                                    </tr>
                                                  
                                                        <tr>
                                                            <td colspan="3" style="text-align: center">
                                                                <asp:DropDownList ID="cboProcMethod1" runat="server" 
                                                                    CssClass="InterfaceDropdownList" OnDataBound="cboProcurementMethod_DataBound" 
                                                                    Width="50%">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="Button3" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                                    Height="23px"  Text="Update ProcMethod" 
                                                                    Width="130px" onclick="Button3_Click" />
                                                            </td>
                                                        </tr>
                                                    
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:Label ID="lblReferenceNo" runat="server" Visible="False">0</asp:Label>
                                    <asp:Label ID="lblMicroProcurementID" runat="server" Visible="False">0</asp:Label>
                                    <asp:Label ID="lblItemCode" runat="server" Font-Bold="True" ForeColor="Red" 
                                        Text="0" Visible="False"></asp:Label>
                                    &nbsp;<cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        CssClass="MyCalendar" Enabled="True" Format="MMMM d, yyyy" 
                                        PopupPosition="TopLeft" TargetControlID="txtClosingDateTime"></cc1:CalendarExtender>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                                        DisplayMoney="None" ErrorTooltipEnabled="True" InputDirection="RightToLeft" 
                                        Mask="99:99" MaskType="Time" MessageValidatorTip="true" 
                                        OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" 
                                        TargetControlID="txtClosingTime"></cc1:MaskedEditExtender>
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
                                                    <td class="InterfaceHeaderLabel" style="height: 20px">
                                                        MICRO PROCUREMENT ITEM DETAILS</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                            <asp:Label ID="lblMicroMsg" runat="server" Font-Bold="False" 
                                                Font-Names="Cambria" Font-Size="11pt" ForeColor="Red" Text="."></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" 
                                            style="vertical-align: middle; height: 22px; text-align: center">
                                            <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" 
                                                CellPadding="4" Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" 
                                                GridLines="None" HorizontalAlign="Center" style="text-align: justify" 
                                                Width="70%">
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <EditItemStyle BackColor="#999999" />
                                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                                                    VerticalAlign="Top" />
                                                <Columns>
                                                    <asp:BoundColumn DataField="ItemID" HeaderText="ItemID" Visible="False">
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="ItemDescription" HeaderText="Item Description">
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Quantity" HeaderText="Qty"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Unit" HeaderText="Units"></asp:BoundColumn>
                                                </Columns>
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" 
                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                    ForeColor="White" HorizontalAlign="Left" VerticalAlign="Top" />
                                            </asp:DataGrid>
                                            <asp:Label ID="lblNoRecords" runat="server" Font-Bold="True" 
                                                Font-Names="Cambria" ForeColor="Red" Visible="False" Width="550px">NO ITEMS CURRENTLY AVAILABLE</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" 
                                            style="vertical-align: middle; height: 22px; text-align: center">
                                            <asp:Button ID="btnMicroSubmit" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                Height="23px" OnClick="btnMicroSubmit_Click" Text="SUBMIT" Width="120px" />
                                            <asp:Button ID="btnPrintMicro" runat="server" Enabled="False" Font-Bold="True" 
                                                Font-Size="9pt" Height="23px" OnClick="btnPrintMicro_Click" Text="PRINT" 
                                                Width="120px" />
                                            &nbsp;
                                            <asp:Button ID="btnMicroReturn" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                Height="23px" OnClick="btnMicroReturn_Click" Text="RETURN" Width="120px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" 
                                            style="vertical-align: middle; height: 22px; text-align: center">
                                        </td>
                                    </tr>
                                    </table>
                                    &nbsp; &nbsp;
                                    <br />
                                </asp:View>
                                <asp:View ID="View5" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 98%">
                                            <asp:Button ID="Button1" runat="server" Text="Print Form" OnClick="btnPrintForm_Click" />
                                            <asp:Button ID="Button2" runat="server" Text="Return" OnClick="btnreturn_Click" />&nbsp;</td>
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
                                </asp:View><asp:View ID="View6" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td colspan="3" style="width: 100%; height: 21px; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">
                                                IFB/RFP SUBMISSIONS</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">

                                                  <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                                        <tr>
                                                            <asp:DataGrid ID="DataGrid5" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" 
                                                    Style="text-align: justify" Width="100%" OnItemCommand="DataGrid5_ItemCommand" AllowPaging="True">
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <EditItemStyle BackColor="#999999" />
                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" PageButtonCount="20" />
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="BidderID" HeaderText="BidderID" ></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="BidderName" HeaderText="Bidder Name">
                                                            <ItemStyle Width="450px" />
                                                        </asp:BoundColumn>
                                                           <asp:TemplateColumn HeaderText="VIEW">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" CssClass="gridPad" ID="btnViewBiddingDocs" CommandName="btnViewBiddingDocs" Text="View Docs" Visible="<%# DisableForm(Container.DataItem) %>"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>

                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                </asp:DataGrid>
                                                        </tr>
                                                    </table>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="width: 100%; text-align: center">
                                                <asp:Label ID="lblHeaderMsg" runat="server" Font-Bold="True" Font-Names="Cambria"
                                                    Font-Size="11pt" ForeColor="Red"></asp:Label></td>
                                        </tr>
                                        <tr>
                                           <%--  <td style="vertical-align: top; width: 49%; text-align: center">
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
                                            </td>--%>
                                            
                                            <td style="vertical-align: top; width: 49%; text-align: center">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                                                    <tr>
                                                        <td colspan="3">
                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                                                <tr>
                                                                    <td class="InterfaceHeaderLabel3" style="height: 18px">
                                                                        View Documents</td>
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
                                                                    
                                                                    <asp:TemplateField>
                                                                       <%-- <ItemTemplate>
                                                                            <asp:LinkButton ID="btnRemove" CommandName="btnRemove" CommandArgument='<%# Eval("FileID") %>' runat="server" Text="Remove" Visible='<%# IsFileRemoveable((Int32)Eval("IsRemoveable")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>--%>
                                                                        <ItemStyle CssClass="gridEditField" ForeColor="#003399" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="FileID" HeaderText="FileID" />
                                                                    <asp:BoundField DataField="FileName" HeaderText="FileName" />
                                                                    <asp:BoundField DataField="DocumentType" HeaderText="Document Type" />
                                                                     <asp:BoundField DataField="SubmissionDate" HeaderText="Date submitted" />
                                                                    <asp:ButtonField CommandName="ViewDetails" Text="Open">
                                                                        <HeaderStyle CssClass="gridEditField" />
                                                                        <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                                            Width="140px" />
                                                                    </asp:ButtonField>
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
                                                         <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">
                                                             UPDATE BID DETAILS FOR&nbsp;&nbsp; 
                                                             <asp:Label runat="server" ID="lblSelectedBidder" Text="."></asp:Label>
                                                         </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="height: 16px">


                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Amount</td>
                                    <td class="InterFaceTableMiddleRowUp">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtBidAmount" runat="server"
                                            BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                            ForeColor="Firebrick"  Width="90%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Discount Offered</td>
                                    <td class="InterFaceTableMiddleRowUp">
                                        &nbsp;</td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:TextBox ID="txtDiscount" runat="server"
                                            BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                            Width="90%"></asp:TextBox></td>
                                </tr>
                                    <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Cover letter signed</td>
                                    <td class="InterFaceTableMiddleRowUp">
                                        &nbsp;</td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:DropDownList runat="server" ID="cboLetterSigned"  CssClass="InterfaceDropdownList" Width="90%" >
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                        </asp:DropDownList> </td>
                                </tr>

                                                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Bid form signed</td>
                                    <td class="InterFaceTableMiddleRowUp">
                                        &nbsp;</td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:DropDownList runat="server" ID="cboBidFormSigned" CssClass="InterfaceDropdownList" Width="90%">
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                        </asp:DropDownList> </td>
                                </tr>
                                                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Power of attorney</td>
                                    <td class="InterFaceTableMiddleRowUp">
                                        &nbsp;</td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:DropDownList runat="server" ID="cboPowerAttorney" CssClass="InterfaceDropdownList" Width="90%" >
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                        </asp:DropDownList> </td>
                                </tr>
                                                 

                             <tr>
                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                        Comment (Include score)</td>
                                    <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="height: 30px">
                                        <asp:TextBox ID="txtBidderRemark" runat="server"
                                            BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                             Width="90%" TextMode="MultiLine" Height="52px"></asp:TextBox></td>
                                </tr>
                                <%--   <tr>
                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                        End of IFB</td>
                                    <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="height: 30px">
                                        <asp:TextBox ID="txtIFBEnd" runat="server"
                                            BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                            ReadOnly="True" Width="90%"></asp:TextBox></td>
                                </tr>--%>
                            
                            </table>

                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="vertical-align: top; width: 100%; text-align: center">
                                                <asp:Label ID="lblBidderId" runat="server" Text="0" Visible="False"></asp:Label>
                                                <asp:Label ID="lblAttachRefNo" runat="server" Text="0" Visible="False"></asp:Label><asp:Button
                                                    ID="btnSaveFile" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                    OnClick="btnSaveFile_Click" Text="SAVE " Width="80px" />
                                                <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                    OnClick="btnReturn_Click" Text="RETURN" Width="80px" /></td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View7" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td colspan="3" style="width: 100%; height: 21px; text-align: center">
                                            <asp:Label runat="server" ForeColor="Red" Font-Size="Medium" Font-Bold="true" Text="DETAILS OF PROCUREMENT"></asp:Label>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                        <td >

                                            <asp:Label ID="lblcomment" runat="server">Date When Action was Taken : </asp:Label><p></p>
                                             <asp:TextBox ID="txtCreationDate" runat="server"
                                                                            Height="20px"  Enabled="false"></asp:TextBox>
                                            </td>
                                            
                                        </tr>
                                     <tr>
                                            <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">
                                                COMMENT(S)</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="width: 100%; text-align: center">
                                             
                                                    <asp:TextBox ID="txtComment" runat="server" CssClass="InterfaceTextboxMultiline"
                                                                            Height="80px" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                                                    
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
                                                                                                Shortlisted Bidders Details</td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    &nbsp;<asp:GridView ID="gvBidders" runat="server" CssClass="gridgeneralstyle" EmptyDataText="NO BIDDERS HAVE BEEN ENTERED" GridLines="None"
                                                                                HorizontalAlign="Center"  PageSize="1"
                                                                                Style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid; border-left: #dcdcdc thin solid;
                                                                                border-bottom: #dcdcdc thin solid" Width="95%" AutoGenerateColumns="False" DataKeyNames="ShortlistID">
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
                                                                <td style="width: 100%; text-align: center">
                                                                    <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid;
                                                                margin-top: 10px; border-left: #617da6 1px solid; width: 98%; border-bottom: #617da6 1px solid">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <table align="center" cellpadding="0" cellspacing="0" style="margin-top: 10px; width: 95%">
                                                                                        <tr>
                                                                                            <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                                                Evaluation Committee Details</td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    &nbsp;<asp:GridView ID="gvEC" runat="server" CssClass="gridgeneralstyle" EmptyDataText="NO EVALUATION COMMITTEE MEMBERS HAVE BEEN ADDED" GridLines="None"
                                                                                HorizontalAlign="Center" PageSize="1"
                                                                                Style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid; border-left: #dcdcdc thin solid;
                                                                                border-bottom: #dcdcdc thin solid" Width="95%" AutoGenerateColumns="False" DataKeyNames="ECMemberID">
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
                                                                    <td style="width: 100%; text-align: center">
                                                                       <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid;
                                                                margin-top: 10px; border-left: #617da6 1px solid; width: 98%; border-bottom: #617da6 1px solid">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table align="center" cellpadding="0" cellspacing="0" 
                                                                                            style="margin-top: 10px; width: 95%">
                                                                                            <tr>
                                                                                                <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                                                    Form Details</td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        &nbsp;<asp:GridView ID="dgvFormDetails" runat="server" AutoGenerateColumns="False" 
                                                                                            CssClass="gridgeneralstyle" DataKeyNames="Section" 
                                                                                            EmptyDataText="NO QUESTION HAS BEEN ANSWERED YET" GridLines="None" 
                                                                                            HorizontalAlign="Center" OnRowCommand="dgvFormDetails_RowCommand" PageSize="1" Style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid; border-left: #dcdcdc thin solid;
                                                                                border-bottom: #dcdcdc thin solid" Width="95%">
                                                                                            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                                            <RowStyle CssClass="gridRowStyle" />
                                                                                            <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                                                            <Columns>
                                                                                                <asp:ButtonField CommandName="btnView" HeaderText="VIEW" 
                                                                                                    Text="Section Details" />
                                                                                                <asp:BoundField DataField="ReferenceNo" HeaderText="ReferenceNo" 
                                                                                                    Visible="False" />
                                                                                                <asp:BoundField DataField="ProcurementMethodCode" HeaderText="ProcMethod" 
                                                                                                    Visible="False" />
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
                                                                        <table align="center" 
                                                                            style="border-right: #617da6 1px solid; border-top: #617da6 1px solid;
                                                                margin-top: 10px; border-left: #617da6 1px solid; width: 98%; border-bottom: #617da6 1px solid">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table align="center" cellpadding="0" cellspacing="0" 
                                                                                            style="margin-top: 10px; width: 95%">
                                                                                            <tr>
                                                                                                <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                                                    Answered Questions</td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        &nbsp;<asp:GridView ID="dgvQuestions" runat="server" CssClass="gridgeneralstyle" 
                                                                                            DataKeyNames="Id" 
                                                                                            EmptyDataText="PLEASE CLICK SECTION DETAILS LINK TO VIEW QUESTIONS" 
                                                                                            GridLines="None" HorizontalAlign="Center" 
                                                                                            PageSize="1" Style="border-right: #dcdcdc thin solid; border-top: #dcdcdc thin solid; border-left: #dcdcdc thin solid;
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
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="3" style="vertical-align: top; width: 95%; text-align: center">
                                                                        <asp:Label ID="Label3" runat="server" Text="0" Visible="False"></asp:Label>
                                                                        <asp:Button ID="Button5" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                                            Height="23px" OnClick="btnReturn_Click" Text="RETURN" Width="80px" />
                                                                    </td>
                                                                </tr>
                                       
                                    </table>
                                   
                                </asp:View>


    <asp:View ID="View8" runat="server">
                                    <table style="width: 100%">
                                         <tr>
                                            <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">
                                                SUBMISSION DETAILS</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="width: 100%; height: 21px; text-align: center">

                                                <asp:DataGrid ID="dgvEval" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" 
                                                    Style="text-align: justify" Width="100%" OnItemCommand="DataGrid5_ItemCommand">
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <EditItemStyle BackColor="#999999" />
                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="BidderID" HeaderText="BidderID" ></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="BidderName" HeaderText="Bidder Name">
                                                           </asp:BoundColumn>
                                                          <asp:BoundColumn DataField="BidValue" HeaderText="Bid Amount">
                                                           </asp:BoundColumn>
                                                         <asp:BoundColumn DataField="discountOffered" HeaderText="Discount">
                                                           </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="bidFormSigned" HeaderText="Bid Form Signed">
                                                           </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="powerAttorney" HeaderText="Power of Attorney">
                                                           </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="bidderPresent" HeaderText="Bidder present">
                                                           </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Reason" HeaderText="Remark">
                                                            <ItemStyle Width="150px"  />
                                                        </asp:BoundColumn>
                                                       

                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">
                                                &nbsp;TECHNICAL &amp; FINANCIAL EVALUATION REPORT</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">

                                               
                                                    <tr>
                                                        <td colspan="3" style="height: 16px">


                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Select Best Evaluated Bidder&nbsp;</td>
                                    <td class="InterFaceTableMiddleRowUp">
                                    </td>
                                    <td class="InterFaceTableRightRowUp" style="width: 66%">
                                        <asp:DropDownList runat="server" ID="ddlBEB" Width="60%"></asp:DropDownList></td>
                                </tr>
                               
                            
                            </table>

                                                        </td>
                                                    </tr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="width: 100%; text-align: center">
                                                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Cambria"
                                                    Font-Size="11pt" ForeColor="Red"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;">
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
                                                                            <input id="File1" runat="server" size="60" type="file" />
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
                                            <td style="width: 2%; height: 280px;">
                                            </td>
                                            <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;">
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
                                                            <asp:GridView ID="GridView1" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                                                GridLines="None" HorizontalAlign="Center" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false"
                                                                PageSize="15" Width="98%">
                                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                <RowStyle CssClass="gridRowStyle" />
                                                                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                                <Columns>
                                                                    <asp:ButtonField CommandName="ViewDetails" Text="View"><HeaderStyle CssClass="gridEditField" /><ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                                            Width="100px" /></asp:ButtonField>
                                                                    <asp:TemplateField><ItemTemplate><asp:LinkButton ID="btnRemove" CommandName="btnRemove" runat="server" Text="Remove" Visible='<%# IsFileRemoveable((Int32)Eval("IsRemoveable")) %>' /></ItemTemplate><ItemStyle CssClass="gridEditField" ForeColor="#003399" /></asp:TemplateField>
                                                                    <asp:BoundField HeaderText="FileID" DataField="FileID" />
                                                                    <asp:BoundField HeaderText="FileName" DataField="FileName" />
                                                                    <asp:BoundField HeaderText="Document Type" DataField="DocumentType" />
                                                                    <asp:BoundField HeaderText="IsRemoveable" DataField="IsRemoveable" Visible="false" />
                                                                </Columns>
                                                                <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                                <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                            </asp:GridView>
                                                            <asp:Label ID="Label2" runat="server" Font-Names="Cambria" Font-Size="11pt"
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
                                            <td class="InterFaceTableLeftRowUp" colspan="2" style="width: 100%; text-align: center">
                                                COMMENT(S)</td><td></td>
                                        </tr>
                                                                                      <tr>
                        
                       
                                <td colspan="2">
                                                    <asp:TextBox ID="txtComment3" runat="server" CssClass="InterfaceTextboxMultiline"
                                                                            Height="80px" TextMode="MultiLine" ></asp:TextBox>
                                                    </td>
                                                                                           <td class="InterFaceTableRightRow" >
                            <asp:CheckBox ID="chkSubmit" CssClass="form-control" runat="server"  Text="SUBMIT FOR APPROVAL" OnCheckedChanged="chkSubmit_CheckedChanged" AutoPostBack="True" /></td>
                                                                                      
                    </tr>
                                        <caption>
                                            <br />
                                            <tr>
                                                <td colspan="3" style="vertical-align: top; width: 100%; text-align: center">
                                                    <asp:Label ID="Label4" runat="server" Text="0" Visible="False"></asp:Label>
                                                    <asp:Button ID="Button4" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" OnClick="Button4_Click" Text="SAVE " Width="80px" />
                                                    <asp:Button ID="btnAttReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" OnClick="btnReturn_Click" Text="RETURN" Width="80px" />
                                                </td>
                                            </tr>
                                        </caption>
                                        </tr>
                                    </table>
                                </asp:View>
    
    <asp:View runat="server" ID="view10">
        <table style="width: 100%">
                                        <tr>
                                            <td colspan="3" style="width: 100%; height: 21px; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">
                                                EOI SUBMISSIONS</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">

                                                  <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                                        <tr>
                                                            <asp:DataGrid ID="DataGrid6" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" 
                                                    Style="text-align: justify" Width="100%" OnItemCommand="DataGrid5_ItemCommand">
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <EditItemStyle BackColor="#999999" />
                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="BidderID" HeaderText="BidderID" ></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="BidderName" HeaderText="Bidder Name">
                                                            <ItemStyle Width="450px" />
                                                        </asp:BoundColumn>

                                                          <asp:TemplateColumn HeaderText="VIEW">
                                                            <ItemTemplate>
                                                                <asp:LinkButton runat="server" CssClass="gridPad" ID="btnViewBiddingDocs" CommandName="btnViewBiddingDocs" Text="View Docs" Visible="<%# DisableForm(Container.DataItem) %>"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>

                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                </asp:DataGrid>
                                                        </tr>
                                                    </table>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="width: 100%; text-align: center">
                                                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Cambria"
                                                    Font-Size="11pt" ForeColor="Red"></asp:Label></td>
                                        </tr>
                                        <tr>
                                           <%--  <td style="vertical-align: top; width: 49%; text-align: center">
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
                                            </td>--%>
                                            
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
                                                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" CssClass="gridgeneralstyle"
                                                                DataKeyNames="FileID" GridLines="None" HorizontalAlign="Center" OnRowCommand="GridAttachments_RowCommand"
                                                                PageSize="15" Width="98%">
                                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                <RowStyle CssClass="gridRowStyle" />
                                                                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                                <Columns>
                                                                    
                                                                    <asp:TemplateField>
                                                                       <%-- <ItemTemplate>
                                                                            <asp:LinkButton ID="btnRemove" CommandName="btnRemove" CommandArgument='<%# Eval("FileID") %>' runat="server" Text="Remove" Visible='<%# IsFileRemoveable((Int32)Eval("IsRemoveable")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>--%>
                                                                        <ItemStyle CssClass="gridEditField" ForeColor="#003399" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="FileID" HeaderText="FileID" />
                                                                    <asp:BoundField DataField="FileName" HeaderText="FileName" />
                                                                    <asp:BoundField DataField="DocumentType" HeaderText="Document Type" />
                                                                    <asp:ButtonField CommandName="ViewDetails" Text="Open">
                                                                        <HeaderStyle CssClass="gridEditField" />
                                                                        <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                                            Width="140px" />
                                                                    </asp:ButtonField>
                                                                </Columns>
                                                                <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                                <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            &nbsp;<asp:Label ID="Label9" runat="server" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red"
                                                                Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
                                                    </tr>
                                                       <tr>
                                            <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">
                                                EOI SUBMISSION EVALUATION REPORT</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">

                                               
                                                    <tr>
                                                        <td colspan="3" style="height: 16px">


                                                        </td>
                                                    </tr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="width: 100%; text-align: center">
                                                <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Names="Cambria"
                                                    Font-Size="11pt" ForeColor="Red"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;">
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
                                                                            <input id="File3" runat="server" size="60" type="file" />
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
                                            <td style="width: 2%; height: 280px;">
                                            </td>
                                            <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;">
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
                                                            <asp:GridView ID="GridView4" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                                                GridLines="None" HorizontalAlign="Center" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false"
                                                                PageSize="15" Width="98%">
                                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                <RowStyle CssClass="gridRowStyle" />
                                                                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                                <Columns>
                                                                    <asp:ButtonField CommandName="ViewDetails" Text="View"><HeaderStyle CssClass="gridEditField" /><ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                                            Width="100px" /></asp:ButtonField>
                                                                    <asp:TemplateField><ItemTemplate><asp:LinkButton ID="btnRemove" CommandName="btnRemove" runat="server" Text="Remove" Visible='<%# IsFileRemoveable((Int32)Eval("IsRemoveable")) %>' /></ItemTemplate><ItemStyle CssClass="gridEditField" ForeColor="#003399" /></asp:TemplateField>
                                                                    <asp:BoundField HeaderText="FileID" DataField="FileID" />
                                                                    <asp:BoundField HeaderText="FileName" DataField="FileName" />
                                                                    <asp:BoundField HeaderText="Document Type" DataField="DocumentType" />
                                                                    <asp:BoundField HeaderText="IsRemoveable" DataField="IsRemoveable" Visible="false" />
                                                                </Columns>
                                                                <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                                <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                            </asp:GridView>
                                                            <asp:Label ID="Label12" runat="server" Font-Names="Cambria" Font-Size="11pt"
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
                                            <td class="InterFaceTableLeftRowUp" colspan="2" style="width: 100%; text-align: center">
                                                COMMENT(S)</td><td></td>
                                        </tr>
                                                                                      <tr>
                        
                       
                                <td colspan="2">
                                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="InterfaceTextboxMultiline"
                                                                            Height="80px" TextMode="MultiLine" ></asp:TextBox>
                                                    </td>
                                                                                           <td class="InterFaceTableRightRow" >
                            <asp:CheckBox ID="chkEoi" CssClass="form-control" runat="server"  Text="SUBMIT FOR APPROVAL" OnCheckedChanged="chkEoi_CheckedChanged" AutoPostBack="True" /></td>
                                                                                      
                    </tr>
                                        <caption>
                                            <br />
                                            <tr>
                                                <td colspan="3" style="vertical-align: top; width: 100%; text-align: center">
                                                    <asp:Label ID="Label13" runat="server" Text="0" Visible="False"></asp:Label>
                                                    <asp:Button ID="Button8" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"  Text="SAVE " Width="80px" OnClick="Button8_Click1" />
                                                    <asp:Button ID="Button9" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" OnClick="btnReturn_Click" Text="RETURN" Width="80px" />
                                                </td>
                                            </tr>
                                        </caption>
                                        </tr>
                                    </table>
    </asp:View>
    <asp:view ID="view11" runat="server">
        <table style="width: 100%">
            <tr>
                <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">DRAFT RFP</td>
            </tr>
          
            <tr>
                <td colspan="3" style="width: 100%; text-align: center">
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Names="Cambria"
                        Font-Size="11pt" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;">
                    <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                        <tr>
                            <td colspan="3">
                                <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                    <tr>
                                        <td class="InterfaceHeaderLabel3" style="height: 18px">New Attachments</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 16px"></td>
                        </tr>
                        <tr>
                            <td colspan="3" style="vertical-align: top; height: 19px; text-align: left">
                                <table align="center" cellpadding="0" cellspacing="0" style="border-right: #a4a2ca 1px solid; border-top: #a4a2ca 1px solid; border-left: #a4a2ca 1px solid; width: 90%; border-bottom: #a4a2ca 1px solid; background-color: #ffffff">
                                    <tr>
                                        <td style="height: 19px">
                                            <br />
                                            <p id="upload-area">
                                                <input id="File4" runat="server" size="60" type="file" />
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
                <td style="width: 2%; height: 280px;"></td>
                <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;">
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
                                <asp:GridView ID="GridView5" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                    GridLines="None" HorizontalAlign="Center" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false"
                                    PageSize="15" Width="98%">
                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                    <RowStyle CssClass="gridRowStyle" />
                                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:ButtonField CommandName="ViewDetails" Text="View">
                                            <HeaderStyle CssClass="gridEditField" />
                                            <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                Width="100px" />
                                        </asp:ButtonField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnRemove" CommandName="btnRemove" runat="server" Text="Remove" Visible='<%# IsFileRemoveable((Int32)Eval("IsRemoveable")) %>' /></ItemTemplate>
                                            <ItemStyle CssClass="gridEditField" ForeColor="#003399" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="FileID" DataField="FileID" />
                                        <asp:BoundField HeaderText="FileName" DataField="FileName" />
                                        <asp:BoundField HeaderText="Document Type" DataField="DocumentType" />
                                        <asp:BoundField HeaderText="IsRemoveable" DataField="IsRemoveable" Visible="false" />
                                    </Columns>
                                    <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                    <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                </asp:GridView>
                                <asp:Label ID="Label14" runat="server" Font-Names="Cambria" Font-Size="11pt"
                                    ForeColor="Red" Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 16px"></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="InterFaceTableLeftRowUp" colspan="2" style="width: 100%; text-align: center">COMMENT(S)</td>
                <td></td>
            </tr>
            <tr>


                <td colspan="2">
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="InterfaceTextboxMultiline"
                        Height="80px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="InterFaceTableRightRow">
                    <asp:CheckBox ID="chkRFP" CssClass="form-control" runat="server" Text="SUBMIT FOR APPROVAL" OnCheckedChanged="chkRFP_CheckedChanged" AutoPostBack="True" /></td>

            </tr>
            <caption>
                <br />
                <tr>
                    <td colspan="3" style="vertical-align: top; width: 100%; text-align: center">
                        <asp:Label ID="Label15" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Button ID="Button10" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" Text="SAVE " Width="80px" OnClick="Button10_Click" />
                        <asp:Button ID="Button11" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" OnClick="btnReturn_Click" Text="RETURN" Width="80px" />
                    </td>
                </tr>
            </caption>
           
        </table>
    </asp:view>
    <asp:view ID="view12" runat="server">
        <table style="width: 100%">
            <tr>
                <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">TECHNICAL EVALUATION</td>
            </tr>
          
            <tr>
                <td colspan="3" style="width: 100%; text-align: center">
                    <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Names="Cambria"
                        Font-Size="11pt" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;">
                    <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                        <tr>
                            <td colspan="3">
                                <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                    <tr>
                                        <td class="InterfaceHeaderLabel3" style="height: 18px">New Attachments</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 16px"></td>
                        </tr>
                        <tr>
                            <td colspan="3" style="vertical-align: top; height: 19px; text-align: left">
                                <table align="center" cellpadding="0" cellspacing="0" style="border-right: #a4a2ca 1px solid; border-top: #a4a2ca 1px solid; border-left: #a4a2ca 1px solid; width: 90%; border-bottom: #a4a2ca 1px solid; background-color: #ffffff">
                                    
                                 <%--      <tr>
                                    <td class="InterFaceTableLeftRowUp">Status</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%"></td>
                                           <td class="InterFaceTableRightRowUp" style="width: 66%">
                                               <asp:DropDownList ID="DropDownList3" runat="server"
                                                   CssClass="InterfaceDropdownList" Enabled="false"
                                                   Width="82%">
                                                   <asp:ListItem Value="43">Technical Evaluation saved</asp:ListItem>
                                                   <asp:ListItem Value="42">Financial Evaluation rejected</asp:ListItem>
                                                   <asp:ListItem Value="43">Technical Evaluation approved</asp:ListItem>
                                                   <asp:ListItem Value="42">Financial Evaluation saved</asp:ListItem>
                                                   <asp:ListItem Value="42">Financial Evaluation rejected</asp:ListItem>
                                               </asp:DropDownList></td>
                                </tr>  
                                    <tr>
                                    <td class="InterFaceTableLeftRowUp">Evaluation Type</td>
                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%"></td>
                                           <td class="InterFaceTableRightRowUp" style="width: 66%">
                                               <asp:DropDownList ID="cboEvalType" runat="server"
                                                   CssClass="InterfaceDropdownList" Enabled="false"
                                                   Width="82%">
                                                   <asp:ListItem Value="7">Technical Evaluation</asp:ListItem>
                                                   <asp:ListItem Value="6">Technical & Financial Evaluation</asp:ListItem>
                                               </asp:DropDownList></td>
                                </tr>--%>
                                    <tr>
                                        <td style="height: 19px">
                                            <br />
                                            <p id="upload-area1">
                                                <input id="File5" runat="server" size="60" type="file" />
                                            </p>
                                            <p>
                                                <input id="ButtonAdd1" onclick="addFileUploadBox()" type="button" value="Add a file" />
                                            </p>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 2%; height: 280px;"></td>
                <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;">
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
                                <asp:GridView ID="GridView6" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                    GridLines="None" HorizontalAlign="Center" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false"
                                    PageSize="15" Width="98%">
                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                    <RowStyle CssClass="gridRowStyle" />
                                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:ButtonField CommandName="ViewDetails" Text="View">
                                            <HeaderStyle CssClass="gridEditField" />
                                            <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                Width="100px" />
                                        </asp:ButtonField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnRemove" CommandName="btnRemove" runat="server" Text="Remove" Visible='<%# IsFileRemoveable((Int32)Eval("IsRemoveable")) %>' /></ItemTemplate>
                                            <ItemStyle CssClass="gridEditField" ForeColor="#003399" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="FileID" DataField="FileID" />
                                        <asp:BoundField HeaderText="FileName" DataField="FileName" />
                                        <asp:BoundField HeaderText="Document Type" DataField="DocumentType" />
                                        <asp:BoundField HeaderText="IsRemoveable" DataField="IsRemoveable" Visible="false" />
                                    </Columns>
                                    <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                    <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                </asp:GridView>
                                <asp:Label ID="Label17" runat="server" Font-Names="Cambria" Font-Size="11pt"
                                    ForeColor="Red" Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 16px"></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="InterFaceTableLeftRowUp" colspan="2" style="width: 100%; text-align: center">COMMENT(S)</td>
                <td></td>
            </tr>
            <tr>


                <td colspan="2">
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="InterfaceTextboxMultiline"
                        Height="80px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="InterFaceTableRightRow">
                    <asp:CheckBox ID="chkEval" CssClass="form-control" runat="server" Text="SUBMIT FOR APPROVAL" OnCheckedChanged="chkEval_CheckedChanged" AutoPostBack="True" /></td>

            </tr>
            <caption>
                <br />
                <tr>
                    <td colspan="3" style="vertical-align: top; width: 100%; text-align: center">
                        <asp:Label ID="Label18" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Button ID="Button12" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"  Text="SAVE " Width="80px" OnClick="Button12_Click" />
                        <asp:Button ID="Button13" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" OnClick="btnReturn_Click" Text="RETURN" Width="80px" />
                    </td>
                </tr>
            </caption>
           
        </table>
    </asp:view>
    <asp:view ID="view13" runat="server">
        <table style="width: 100%">
            <tr>
                <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">DRAFT CONTRACT</td>
            </tr>
          
            <tr>
                <td colspan="3" style="width: 100%; text-align: center">
                    <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Names="Cambria"
                        Font-Size="11pt" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;">
                    <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                        <tr>
                            <td colspan="3">
                                <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                    <tr>
                                        <td class="InterfaceHeaderLabel3" style="height: 18px">New Attachments</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 16px"></td>
                        </tr>
                        <tr>
                            <td colspan="3" style="vertical-align: top; height: 19px; text-align: left">
                                <table align="center" cellpadding="0" cellspacing="0" style="border-right: #a4a2ca 1px solid; border-top: #a4a2ca 1px solid; border-left: #a4a2ca 1px solid; width: 90%; border-bottom: #a4a2ca 1px solid; background-color: #ffffff">
                                    <tr>
                                        <td style="height: 19px">
                                            <br />
                                            <p id="upload-area">
                                                <input id="File6" runat="server" size="60" type="file" />
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
                <td style="width: 2%; height: 280px;"></td>
                <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;">
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
                                <asp:GridView ID="GridView7" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                    GridLines="None" HorizontalAlign="Center" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false"
                                    PageSize="15" Width="98%">
                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                    <RowStyle CssClass="gridRowStyle" />
                                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:ButtonField CommandName="ViewDetails" Text="View">
                                            <HeaderStyle CssClass="gridEditField" />
                                            <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                Width="100px" />
                                        </asp:ButtonField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnRemove" CommandName="btnRemove" runat="server" Text="Remove" Visible='<%# IsFileRemoveable((Int32)Eval("IsRemoveable")) %>' /></ItemTemplate>
                                            <ItemStyle CssClass="gridEditField" ForeColor="#003399" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="FileID" DataField="FileID" />
                                        <asp:BoundField HeaderText="FileName" DataField="FileName" />
                                        <asp:BoundField HeaderText="Document Type" DataField="DocumentType" />
                                        <asp:BoundField HeaderText="IsRemoveable" DataField="IsRemoveable" Visible="false" />
                                    </Columns>
                                    <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                    <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                </asp:GridView>
                                <asp:Label ID="Label20" runat="server" Font-Names="Cambria" Font-Size="11pt"
                                    ForeColor="Red" Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 16px"></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="InterFaceTableLeftRowUp" colspan="2" style="width: 100%; text-align: center">COMMENT(S)</td>
                <td></td>
            </tr>
            <tr>


                <td colspan="2">
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="InterfaceTextboxMultiline"
                        Height="80px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="InterFaceTableRightRow">
                    <asp:CheckBox ID="chkDraft" CssClass="form-control" runat="server" Text="SUBMIT FOR APPROVAL" OnCheckedChanged="chkDraft_CheckedChanged" AutoPostBack="True" /></td>

            </tr>
            <caption>
                <br />
                <tr>
                    <td colspan="3" style="vertical-align: top; width: 100%; text-align: center">
                        <asp:Label ID="Label21" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Button ID="Button14" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" Text="SAVE " Width="80px" OnClick="Button14_Click" />
                        <asp:Button ID="Button15" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" OnClick="btnReturn_Click" Text="RETURN" Width="80px" />
                    </td>
                </tr>
            </caption>
           
        </table>
    </asp:view>
                            </asp:MultiView>
    </td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="lblPD_Code" runat="server" Text="0" Visible="False"></asp:Label></td>
        </tr>
    </table>
    &nbsp;
 
   <script type="text/javascript">
       function addFileUploadBox() {
           if (!document.getElementById || !document.createElement)
               return false;

           var uploadArea = document.getElementById("upload-area");
           if (!uploadArea)
               return;

           var newline = document.createElement("br");
           uploadArea.appendChild(newline);

           var newUploadBox = document.createElement("input");
           newUploadBox.type = "file";
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







