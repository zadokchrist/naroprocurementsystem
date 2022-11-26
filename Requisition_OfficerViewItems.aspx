<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_OfficerViewItems.aspx.cs" Inherits="Requisition_OfficerViewItems" Title="VIEW REQUISITION(S)" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" AjaxFrameworkMode="Enabled" runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                REQUISITION ITEM(S) ASSIGNED TO YOU
            </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-12 mb-3 mb-sm-0">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <label>Search START Date</label>
                                <asp:TextBox ID="txtStartDate" runat="server" cssclass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <label>SEARCH END DATE</label>
                                <asp:TextBox ID="txtEndDate" runat="server" cssclass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <label>Pr number</label>
                                <asp:TextBox ID="txtPrNumber" runat="server" cssclass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
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
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <label>STATUS</label>
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="23" Text="Assigned"></asp:ListItem>
                                    <asp:ListItem Value="27" Text="Docs & Shortlist saved"></asp:ListItem>
                                    <asp:ListItem Value="26" Text="Docs & Shortlist submitted to LPM/SPM"></asp:ListItem>
                                     <asp:ListItem Value="41" Text="Docs & Shortlist approved by LPM/SPM"></asp:ListItem>
                                    <asp:ListItem Value="42" Text="Docs & Shortlist rejected by LPM/SPM"></asp:ListItem>
                                    <asp:ListItem Value="43" Text="Docs & Shortlist approved by PM"></asp:ListItem>
                                    <asp:ListItem Value="42" Text="Docs & Shortlist rejected by PM "></asp:ListItem>
                                     <asp:ListItem Value="43" Text="Docs & Shortlist approval submitted to MD"></asp:ListItem>
                                    <asp:ListItem Value="45" Text="Docs & Shortlist approved by MD"></asp:ListItem>
                                    <asp:ListItem Value="46" Text="Docs & Shortlist rejected by MD"></asp:ListItem>
                                    <asp:ListItem Value="27" Text="Draft EOI saved"></asp:ListItem>
                                    <asp:ListItem Value="33" Text="Draft EOI submitted to LPM/SPM"></asp:ListItem>
                                     <asp:ListItem Value="42" Text="Draft EOI rejected by LPM/SPM"></asp:ListItem>
                                    <asp:ListItem Value="34" Text="Draft EOI submitted to PM"></asp:ListItem>
                                     <asp:ListItem Value="42" Text="Draft EOI rejected by PM"></asp:ListItem>
                                    <asp:ListItem Value="35" Text="Draft EOI submitted to MD"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <label>.</label>
                                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click"
                                        Text="Search" class="btn btn-primary btn-user btn-block float-right"/>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12 mb-3 mb-sm-0">
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
                                                        <asp:BoundColumn DataField="PD_Code" HeaderText="PD Code" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ScalaPRNumber" HeaderText="PR Number"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Subject" HeaderText="Subject"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ProcurementType" HeaderText="Type"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CreationDate" HeaderText="Date" DataFormatString="{0:dd MMM yyyy}"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="TotalCost" HeaderText="Est. Cost" DataFormatString="{0:N0}">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundColumn>

                                                        <asp:ButtonColumn CommandName="btnPrint" HeaderText="Print" Text="Print PDF">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn CommandName="btnPrintStatus" HeaderText="Status" Text="STATUS">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn CommandName="btnFiles" HeaderText="ATTACHMENTS" Text="VIEW">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn CommandName="btnActivitySchedule" Text="PREPARE" ItemStyle-ForeColor="OrangeRed">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:ButtonColumn>

                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                </asp:DataGrid>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                <table style="width: 100%">
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">NO RECORD FOUND MESSAGE</td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:Label ID="lblEmpty" runat="server" Font-Bold="True" ForeColor="Red" Text="."></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center"></td>
                    </tr>
                </table>
            </asp:View>
                    <asp:View ID="View3" runat="server">
                <table style="width: 100%">
                    <tr>
                        <td colspan="3" style="width: 100%; height: 21px; text-align: center"></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">ATTACHMENT(S)</td>
                    </tr>
                    <tr>
                        <td colspan="3"></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="width: 100%; text-align: center">
                            <asp:Label ID="lblHeaderMsg" runat="server" Font-Bold="True" Font-Names="Cambria"
                                Font-Size="11pt" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: center" colspan="3">
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
                                            PageSize="15" Width="98%" CellPadding="4" ForeColor="#333333">
                                            <AlternatingRowStyle BackColor="White" CssClass="gridAlternatingRowStyle"></AlternatingRowStyle>
                                            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></FooterStyle>

                                            <HeaderStyle HorizontalAlign="Left" BackColor="#990000" CssClass="gridHeaderStyle" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                            <PagerSettings Position="TopAndBottom" />
                                            <PagerStyle HorizontalAlign="Center" BackColor="#FFCC66" ForeColor="#333333"></PagerStyle>

                                            <RowStyle CssClass="gridRowStyle" BackColor="#FFFBD6" ForeColor="#333333" />
                                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy"></SelectedRowStyle>

                                            <SortedAscendingCellStyle BackColor="#FDF5AC"></SortedAscendingCellStyle>

                                            <SortedAscendingHeaderStyle BackColor="#4D0000"></SortedAscendingHeaderStyle>

                                            <SortedDescendingCellStyle BackColor="#FCF6C0"></SortedDescendingCellStyle>

                                            <SortedDescendingHeaderStyle BackColor="#820000"></SortedDescendingHeaderStyle>
                                            <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                            <Columns>
                                                <asp:ButtonField CommandName="ViewDetails" Text="View">
                                                    <HeaderStyle CssClass="gridEditField" />
                                                    <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                        Width="140px" />
                                                </asp:ButtonField>
                                                <asp:ButtonField CommandName="btnRemove" Text="Remove">
                                                    <ItemStyle CssClass="gridEditField" ForeColor="#003399" />
                                                </asp:ButtonField>
                                            </Columns>
                                            <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                            <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                        </asp:GridView>
                                        <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red"
                                            Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 16px"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="vertical-align: top; width: 100%; text-align: center">
                            <asp:Label ID="Label1" runat="server" Text="0" Visible="False"></asp:Label>
                            <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                OnClick="btnReturn_Click" Text="RETURN" Width="80px" /></td>
                    </tr>
                </table>
            </asp:View>
                    <asp:View ID="View4" runat="server">
                <table id="Table2" onclick="return TABLE1_onclick()" style="width: 100%">
                    <tr>
                        <td style="width: 100%; height: 21px; text-align: right"></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">PRINT REQUISITION FOR APPROVAL</td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                            <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" Text="Print Requisition PDF" />
                            <asp:Button ID="Button1" runat="server" OnClick="btnreturn_Click" Text="Return" />&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">&nbsp;<%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />--%>
                            &nbsp;<br />
                            <asp:Label ID="Label2" runat="server" Text="0" Visible="False"></asp:Label></td>
                    </tr>
                </table>
            </asp:View>
                    <asp:View ID="View5" runat="server">
                <table id="Table1" onclick="return TABLE1_onclick()" style="width: 100%">
                    <tr>
                        <td style="width: 100%; height: 21px; text-align: right"></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">STAGES OF REQUISITION</td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                            <asp:Button ID="btnPrintStatus" runat="server" OnClick="btnPrintStatus_Click" Text="Print Status" />
                            <asp:Button ID="btnReturnProcurements" runat="server" OnClick="btnreturn_Click" Text="Return" />&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">&nbsp;
                            &nbsp;<br />
                            <asp:Label ID="Label3" runat="server" Text="0" Visible="False"></asp:Label></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View9" runat="server">
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Ref. No/ PR Number
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtPRNumber2" runat="server" CssClass="form-control" MaxLength="10" ReadOnly="True" Enabled="False"></asp:TextBox>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Procurement Department
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboCompany" runat="server" CssClass="form-control" Enabled="false">
                            <asp:ListItem Value="1">SMALL PROCUREMENT</asp:ListItem>
                            <asp:ListItem Value="2">LARGE PROCUREMENT</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Procurement Description
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtProcDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Enabled="False"></asp:TextBox>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Procurement Supervisor
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboPDUHead" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Estimated Cost
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtCost" runat="server" Font-Bold="True" onkeyup="javascript:this.value=Comma(this.value);" Enabled="False" CssClass="form-control"></asp:TextBox>
                        <br />
                        <cc1:FilteredTextBoxExtender ID="FTEEstimatedCost" runat="server" FilterType="Custom,Numbers"
                                                        TargetControlID="txtCost" ValidChars=","></cc1:FilteredTextBoxExtender>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Procurement Manager
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboSupervisor" runat="server" CssClass="form-control" Enabled="false">
                                           <asp:ListItem Value="6">Lawrence Adebola</asp:ListItem>
                                    </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Funding Source
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboFunding" runat="server" CssClass="form-control" Enabled="false"
                                                        OnDataBound="cboFunding_DataBound">
                                                    </asp:DropDownList>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Procurement Type
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboProcType" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Date Assigned
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtDateAssigned" runat="server" ReadOnly="True" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Procurement Method
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboProcurementMethod" runat="server" CssClass="form-control" OnDataBound="cboProcurementMethod_DataBound" Enabled="false" AutoPostBack="True" OnSelectedIndexChanged="cboProcurementMethod_SelectedIndexChanged">
                                                    </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Preparation Date
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtPreparationDate" runat="server" autocomplete="off" cssclass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Start of Bid Receipt Date
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtStart" runat="server" autocomplete="off" OnTextChanged="txtStart_TextChanged" AutoPostBack="True" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        
                        <asp:Label ID="lblcumulativePeriod" runat="server">Cummulative period (days)</asp:Label>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtCummulativePeriod" runat="server" autocomplete="off" Font-Bold="True" ForeColor="" ReadOnly="True" Enabled="False" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        <asp:Label ID="lblbidreceiptdate" runat="server">End of Bid Receipt Date</asp:Label>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtBidEndDate" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        <%--Start of Bid Receipt Date--%>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtBidStartDate" runat="server" autocomplete="off" OnTextChanged="txtBidStartDate_TextChanged" AutoPostBack="True" CssClass="form-control" Enabled="false" Visible="false"></asp:TextBox>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        <asp:Label runat="server" ID="lblEOIStart" Text="EOI submission start date"></asp:Label>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtEOIStart" runat="server" Font-Bold="False" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                 <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:Label runat="server" ID="lblEOIEnd" Text="EOI submission end date"></asp:Label>
                    </div>
                     <div class="col-sm-3 mb-3 mb-sm-0">
                         <asp:TextBox ID="txtEOIEnd" runat="server" Font-Bold="False" CssClass="form-control"></asp:TextBox>
                     </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-5 mb-3 mb-sm-0"></div>
                     <div class="col-sm-6 mb-3 mb-sm-0">
                         <asp:Label ID="lblreqn" runat="server" ForeColor="Firebrick" Text="." Visible="False"></asp:Label>
                         <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="MyCalendar"
                                Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtStart"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="MyCalendar"
                                Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtBidStartDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="MyCalendar"
                                Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtBidEndDate"></ajaxToolkit:CalendarExtender>

                            <ajaxToolkit:CalendarExtender ID="CalendarExtender6" runat="server" CssClass="MyCalendar"
                                Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtPreparationDate"></ajaxToolkit:CalendarExtender>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender7" runat="server" CssClass="MyCalendar"
                                Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtEOIStart"></ajaxToolkit:CalendarExtender><ajaxToolkit:CalendarExtender ID="CalendarExtender8" runat="server" CssClass="MyCalendar"
                                Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtEOIEnd"></ajaxToolkit:CalendarExtender>
               
                     </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-5 mb-3 mb-sm-0"></div>
                     <div class="col-sm-6 mb-3 mb-sm-0">
                         <asp:Label ID="txtPlanApproved" runat="server" Text="." ForeColor="Firebrick"></asp:Label>
                         <asp:Label ID="Label5" runat="server" Text="PD_Code" Visible="False"></asp:Label>
                     </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-5 mb-3 mb-sm-0"></div>
                     <div class="col-sm-6 mb-3 mb-sm-0">
                         <asp:Label ID="lblColumnNo" runat="server" ForeColor="Black" Text="." Visible="False"></asp:Label>
                     </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Job To Be Advertised?</div>
                     <div class="col-sm-3 mb-3 mb-sm-0">
                         <asp:RadioButtonList ID="advertised" runat="server" CssClass="InterfaceDropdownList" AutoPostBack="True" OnSelectedIndexChanged="advertised_SelectedIndexChanged">
                             <asp:ListItem Value="1">Yes</asp:ListItem>
                             <asp:ListItem Value="2">No</asp:ListItem>
                         </asp:RadioButtonList>
                     </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                     <div class="col-sm-6 mb-3 mb-sm-0">
                         Upload document(s)
                     </div>
                </div>
                <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">


                    <tr>
                        <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;" colspan="3">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                                <tr>
                                    <td colspan="3" style="vertical-align: top; height: 19px; text-align: left">
                                        <table align="center" cellpadding="0" cellspacing="0" style="border-right: #a4a2ca 1px solid; border-top: #a4a2ca 1px solid; border-left: #a4a2ca 1px solid; width: 90%; border-bottom: #a4a2ca 1px solid; background-color: #ffffff">

                                            <tr>
                                                <td class="InterFaceTableLeftRowUp">Document Type</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="cboDocType" runat="server"
                                                        CssClass="form-control"
                                                        Width="80%" OnDataBound="cboDocType_DataBound">
                                                    </asp:DropDownList>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="height: 19px">
                                                    <br />
                                                    <p id="upload-area">
                                                        <input id="File2" runat="server" size="60" type="file" />
                                                    </p>
                                                    <p>
                                                        <input id="ButtonAdd" onclick="addFileUploadBox()" type="button" value="Add a file" />
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnUpload" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" Text="UPLOAD " Width="80px" OnClick="btnUpload_Click1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 2%; height: 280px;"></td>
                        <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;" colspan="3">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                                <tr>
                                    <td colspan="3">
                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                            <tr>
                                                <td class="InterfaceHeaderLabel3" style="height: 18px">Document(s)</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 16px"></td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:GridView ID="GridView2" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                            GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false"
                                            PageSize="15" Width="98%" OnRowCommand="GridView2_RowCommand" CellPadding="4" ForeColor="#333333">
                                            <AlternatingRowStyle BackColor="White" CssClass="gridAlternatingRowStyle"></AlternatingRowStyle>
                                            <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                                            <HeaderStyle HorizontalAlign="Left" BackColor="#507CD1" CssClass="gridHeaderStyle" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                            <PagerSettings Position="TopAndBottom" />
                                            <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                                            <RowStyle CssClass="gridRowStyle" BackColor="#EFF3FB" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                                            <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                                            <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                                            <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                                            <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                                            <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                            <Columns>

                                                <asp:BoundField HeaderText="FileID" DataField="FileID" />
                                                <asp:BoundField HeaderText="FileName" DataField="FileName" />
                                                <asp:BoundField HeaderText="Document Type" DataField="DocumentType" />
                                                <asp:BoundField HeaderText="IsRemoveable" DataField="IsRemoveable" Visible="false" />
                                                <asp:ButtonField CommandName="ViewDetails" Text="View">
                                                    <HeaderStyle CssClass="gridEditField" />
                                                    <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center" />
                                                </asp:ButtonField>
                                                <asp:ButtonField CommandName="btnRemove" runat="server" Text="Remove">
                                                    <ItemStyle CssClass="gridEditField" Width="80px" ForeColor="OrangeRed" />
                                                </asp:ButtonField>
                                            </Columns>
                                            <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                            <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                        </asp:GridView>
                                        <asp:Label ID="Label6" runat="server" Font-Names="Cambria" Font-Size="11pt"
                                            ForeColor="Red" Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="height: 16px"></td>
                                </tr>
                            </table>
                            <asp:Label ID="lblAttachRefNo" runat="server" Text="0" Visible="False"></asp:Label>
                        </td>
                    </tr>
<%--                    <tr>
                        <td colspan="6" style="vertical-align: top; width: 100%; text-align: center">
                            
                            <asp:Button ID="Button6" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" Text="SAVE " Width="80px"/>
                            <asp:Button ID="Button7" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"Text="RETURN" Width="80px" />
                        </td>
                    </tr>--%>
                </table>
            </asp:View>
                </asp:MultiView>
                <asp:MultiView runat="server" ID="MultiView2">
                    <asp:View ID="View10" runat="server">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center; margin-top: 0px; margin-bottom: 0px; padding-bottom: 0px; padding-top: 0px;">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 60%; padding-bottom: 0px; padding-top: 0px;">
                                        <tr>
                                            <td class="InterfaceHeaderLabel3" style="height: 17px">BIDDER SHORTLIST INFORMATION</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; width: 50%; height: 5px; text-align: center"></td>
                                <td style="vertical-align: top; width: 50%; height: 5px; text-align: center"></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                        <tr>
                                            <td colspan="1" style="vertical-align: top; height: 9px"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" style="vertical-align: top; height: 41px">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td class="InterfaceHeaderLabel" style="height: 20px">
                                                            <asp:Label ID="lblAddEditItemHeader" runat="server" Text="ADD POTENTIAL BIDDERS"></asp:Label>
                                                            <br />
                                                            <asp:Label ID="Label4" runat="server" ForeColor="#C04000" Text="  ( REQUIRE A MINIMUM OF THREE (3) BIDDERS )"></asp:Label></td>
                                                    </tr>
                                                </table>
                                                <table width="100%">
                                                    <tr>
                                                        <td colspan="3" valign="top">
                                                            <asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Cambria"
                                                                Font-Size="11pt" ForeColor="Red" Text="."></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 48%" valign="top">
                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                <tr>
                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">Bidder Category</td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px"></td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                        <asp:DropDownList ID="cboBidderCategory" runat="server" AutoPostBack="True"
                                                                            OnDataBound="cboBidderCategory_DataBound" OnSelectedIndexChanged="cboBidderCategory_SelectedIndexChanged"
                                                                            Width="82%">
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">Area of operation</td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px"></td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                        <asp:DropDownList ID="cboBIdderSubcat" runat="server" AutoPostBack="True"
                                                                            Width="82%" OnDataBound="cboBIdderSubcat_DataBound" OnSelectedIndexChanged="cboBIdderSubcat_SelectedIndexChanged">
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                                                        <asp:Label ID="lblBidder" runat="server" Text="Potential Bidder"></asp:Label>
                                                                    </td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px"></td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">

                                                                        <asp:DropDownList ID="ddlBidders" runat="server" AutoPostBack="True"
                                                                            Width="82%" OnDataBound="ddlBidders_DataBound1">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <asp:Label ID="lblShortlistID" runat="server" Visible="False"></asp:Label><asp:Label
                                                                ID="lblCreatedBy" runat="server" Text="0" Visible="False"></asp:Label><asp:Label
                                                                    ID="lblStatusID" runat="server" Text="0" Visible="False"></asp:Label></td>
                                                        <td style="width: 2%"></td>
                                                        <td style="width: 48%" valign="top">
                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                <tr style="color: #000000">
                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                                                        <%-- Proposed By--%></td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px"></td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                        <asp:TextBox ID="txtProposedBy" runat="server" autocomplete="off" Width="80%" Visible="false"></asp:TextBox></td>
                                                                </tr>
                                                                <tr style="color: #000000">
                                                                    <td class="InterFaceTableLeftRow" valign="top">
                                                                        <asp:Label ID="reason" runat="server">Reason for Selection</asp:Label>
                                                                    </td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%;"></td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%;">

                                                                        <asp:DropDownList ID="cboReason" runat="server" AutoPostBack="true" OnDataBound="cboReason_DataBound" OnSelectedIndexChanged="cboReason_SelectedIndexChanged"
                                                                            Width="82%">
                                                                        </asp:DropDownList>


                                                                        <br />
                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="txtReason" runat="server" CssClass="InterfaceTextboxMultiline" Height="12px"
                                                                                    Style="width: 90%; height: 55px" TextMode="MultiLine" Visible="False" Width="70%"></asp:TextBox></td>
                                                                            </ContentTemplate>
                                                                            <Triggers>
                                                                                <asp:AsyncPostBackTrigger ControlID="cboReason" EventName="SelectedIndexChanged" />
                                                                            </Triggers>
                                                                        </asp:UpdatePanel>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1"
                                                    ServiceMethod="GetUsersByNames" ServicePath="CascadingddlService.asmx" TargetControlID="txtProposedBy">
                                                </ajaxToolkit:AutoCompleteExtender>
                                                <%--<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" MinimumPrefixLength="1"
                                                                ServiceMethod="GetBiddersByNamesWithContext" UseContextKey="true" ContextKey="CategoryID" ServicePath="CascadingddlService.asmx" TargetControlID="txtBidder">
                                                            </ajaxToolkit:AutoCompleteExtender>--%>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" style="vertical-align: top">
                                                <asp:Button ID="btnAddBidder" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                    Text="Add Bidder" Width="158px" OnClick="btnAddBidder_Click" />
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="vertical-align: top; height: 5px; text-align: center"></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 68%">
                                        <tr>
                                            <td class="InterfaceHeaderLabel" style="height: 20px">
                                                <asp:Label ID="lblshrtlisted" runat="server">SHORTLISTED BIDDERS</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">

                                    <asp:Button ID="btnPrint2" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                        Text="Print" Width="100px" OnClick="btnPrint2_Click" ToolTip="Print Bidder Shortlist" Enabled="False" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                    <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" HorizontalAlign="Center"
                                        OnItemCommand="DataGrid2_ItemCommand" Width="100%" OnSelectedIndexChanged="DataGrid2_SelectedIndexChanged" PageSize="15">
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <EditItemStyle BackColor="#999999" />
                                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                        <Columns>
                                            <asp:BoundColumn DataField="ShortlistID" HeaderText="ShortlistID" Visible="false"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="DateCreated" HeaderText="Date Created"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="CompanyName" HeaderText="Bidder Name"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ProposedBy" HeaderText="Proposed By"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="ReasonID" HeaderText="ReasonID" Visible="false"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="Reason" HeaderText="Reason"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="OtherReason" HeaderText="OtherReason" Visible="false"></asp:BoundColumn>
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
                                <td style="vertical-align: top; width: 50%; height: 5px; text-align: center"></td>
                                <td style="vertical-align: top; width: 50%; height: 5px; text-align: center"></td>
                            </tr>

                        </table>
                        <asp:Panel ID="Panel1" runat="server" Style="width: 100%" Visible="False">
                            <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid; border-left: #617da6 1px solid; width: 98%; border-bottom: #617da6 1px solid">
                                <tbody>
                                    <tr>
                                        <td style="vertical-align: top; width: 96%; text-align: center">
                                            <%--<CR:CrystalReportViewer ID="CrystalReportViewer3" runat="server" AutoDataBind="true"
                                        ToolPanelView="None" HasPrintButton="False" Height="50px" SeparatePages="False"
                                        Width="350px" BestFitPage="False"></CR:CrystalReportViewer>--%>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                        &nbsp;
                    </asp:View>
                    <asp:View ID="View6" runat="server"></asp:View>

                </asp:MultiView>
                <asp:MultiView runat="server" ID="Submit">
              <asp:View runat="server" ID="View11">
                  <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                
                        <tr>
                                              <td></td>
                                           

                                                <td  class="InterFaceTableRightRow">
                                                    <asp:CheckBox ID="chkSubmit" CssClass="form-control" runat="server" Text="SUBMIT FOR APPROVAL" OnCheckedChanged="chkSubmit_CheckedChanged" AutoPostBack="True" /></td>
                                            </tr>
                 <tr>
                        <td colspan="4" style="vertical-align: middle; height: 22px; text-align: center">
                            <asp:Button ID="btnSubmit" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                Text="SAVE" Width="100px"   OnClick="Button6_Click"  />
                            <asp:Button ID="btnCancel" runat="server" Font-Bold="True"  OnClick="btnReturn_Click"  Font-Size="9pt" Height="23px"
                                Text="Cancel / Return" Width="110px" /></td>
                    </tr>
                      </table>
            </asp:View>
        </asp:MultiView>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-5 mb-3 mb-sm-0">
                <asp:Label ID="lblPD_Code" runat="server" Text="0" Visible="False"></asp:Label>
            </div>
        </div>
    </div>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
        Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtStartDate"></cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
        Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtEndDate"></cc1:CalendarExtender>

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







