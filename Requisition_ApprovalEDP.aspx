<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Requisition_ApprovalEDP.aspx.cs" Inherits="Requisition_ApprovalED" Title="REQUISITION APPROVAL" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="ajaxToolkit" %>
<%@ Import  Namespace="System.Threading" %>
<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td style="text-align: center; vertical-align: middle">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 80%">
                                <tr>
                                    <td class="InterfaceHeaderLabel" style="height: 20px">
                                        APPROVE / REJECT REQUISITION</td>
                                </tr>
                            </table>
            </td>
        </tr>
        </table>
        
        <table cellpadding="0" cellspacing="0" class="style12">
            <tr>
                <td style="height: 30px;"></td>
            </tr>
            <tr>
                <td style="text-align: center; vertical-align: middle">

                    <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="View1" runat="server">
                                    <table cellpadding="0" cellspacing="0" class="style12">
                                        <tr>
                                            <td style="width: 50%; vertical-align: middle; text-align: center; height: 37px;">
                                    <table align ="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                        <tr>
                                            <td class="InterfaceHeaderLabel3">
                                                Requisition Description</td>
                                        </tr>
                                    </table>
                                            </td>
                                        </tr>
                                    </table>
                                <table cellpadding="0" cellspacing="0" class="style12">
                            <tr>
                                <td>
                                    <table align ="center" cellpadding="0" cellspacing="0" class="style12">
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; height: 35px; text-align: center">
                                                <span style="font-size: 13pt; font-family: Cambria">SERIAL: --&gt;&gt; ( </span>
                                                <asp:Label ID="lblEntity" runat="server" Font-Names="cambria" Font-Size="13pt" ForeColor="Red"></asp:Label>
                                                <span style="font-size: 13pt; font-family: Cambria">
                                                )</span></td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center; vertical-align: top; width: 50%; height: 121px;">
                                                <table align ="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                    <tr>
                                                        <td class="InterFaceTableLeftRowUp">
                                                            Procurement Type</td>
                                                        <td class="InterFaceTableMiddleRowUp">
                                                            &nbsp;</td>
                                                        <td class="InterFaceTableRightRowUp">
                                                            <asp:TextBox ID="txtProcType" runat="server" CssClass="InterfaceTextboxLongReadOnly"
                                                                Width="90%" BorderStyle="Solid" Font-Bold="True" ReadOnly="True"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="InterFaceTableLeftRow" style="height: 65px">
                                                            Subject of Procurement</td>
                                                        <td class="InterFaceTableMiddleRow" style="height: 65px">
                                                        </td>
                                                        <td class="InterFaceTableRightRow" style="height: 65px">
                                                            <asp:TextBox ID="txtProcSubject" runat="server" CssClass="InterfaceTextboxMultiline"
                                                                TextMode="MultiLine" BorderStyle="Solid" Font-Bold="True" ReadOnly="True"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="InterFaceTableLeftRow">
                                                            Type of Requisition</td>
                                                        <td class="InterFaceTableMiddleRow">
                                                        </td>
                                                        <td class="InterFaceTableRightRow">
                                                            <asp:TextBox ID="txtRequisitionType" runat="server" 
                                                                BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                                                 ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="InterFaceTableLeftRow">
                                                Location of Delivery</td>
                                                        <td class="InterFaceTableMiddleRow">
                                                        </td>
                                                        <td class="InterFaceTableRightRow">
                                                            <asp:TextBox ID="txtDeliveryLocation" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                Font-Bold="True" ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="InterFaceTableLeftRow">
                                                            Ware House</td>
                                                        <td class="InterFaceTableMiddleRow">
                                                        </td>
                                                        <td class="InterFaceTableRightRow">
                                                            <asp:TextBox ID="txtWareHouse" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                Font-Bold="True" ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="text-align: center; vertical-align: top; width: 50%; height: 121px;">
                                                <table align ="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                  
                                                    </table>
                                    <table align ="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                Date Requisitioned</td>
                                            <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                            </td>
                                            <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                <asp:TextBox ID="txtDateRequisitioned" runat="server" 
                                                    BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                                    ReadOnly="True" Width="90%"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                Date Required</td>
                                            <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                &nbsp;</td>
                                            <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                            <asp:TextBox ID="txtDateRequired" runat="server" 
                                                                CssClass="InterfaceTextboxLongReadOnly" Width="90%" BorderStyle="Solid" Font-Bold="True" ReadOnly="True"></asp:TextBox></td>
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
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp">
                                                            Requisitioner</td>
                                            <td class="InterFaceTableMiddleRowUp">
                                            </td>
                                            <td class="InterFaceTableRightRowUp">
                                                            <asp:TextBox ID="txtRequisitioner" runat="server"
                                                                BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                                                ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp">
                                                Cost Center Manager</td>
                                            <td class="InterFaceTableMiddleRowUp">
                                            </td>
                                            <td class="InterFaceTableRightRowUp">
                                                <asp:TextBox ID="txtManager" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                    Font-Bold="True" ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                        </tr>
                                        
                                          </table>
                                                <asp:Label ID="lblCreatedBy" runat="server" Visible="False"></asp:Label>
                                                <asp:Label ID="lblWareHouse" runat="server" Visible="False"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 35px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 30px">
                                                                            <asp:Button ID="btnShowHideFiles" runat="server" Font-Bold="True" Font-Size="9pt"
                                                                                Height="23px" Text=" View Attachments"
                                                                                Width="146px" OnClick="btnShowHideFiles_Click" />
                                                <asp:Button ID="btnViewStatus" runat="server" Font-Bold="True" Font-Size="9pt"
                                                                                Height="23px" Text=" View Status"
                                                                                Width="146px" OnClick="btnViewStatus_Click" />
                                                <asp:Button ID="btnPrintPR" runat="server" Font-Bold="True" Font-Size="9pt"
                                                                                Height="23px" Text="Print Requisition"
                                                                                Width="146px" OnClick="btnPrintPR_Click" /></td>
                                        </tr>
                                    </table>
                                                <asp:Label ID="lblPlanCode" runat="server" Font-Names="cambria" Font-Size="13pt" Visible="False">0</asp:Label>
                                    <asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label>
                                    <asp:Label ID="lblRecordCode" runat="server" Text="0" Visible="False"></asp:Label>
                                    <asp:Label ID="lblCostCenterCode" runat="server" Text="0" Visible="False"></asp:Label>
                                    <asp:Label ID="lblScalaPR" runat="server" Text="0" Visible="False"></asp:Label>
                                    <asp:Label ID="lblCostCenterForBudget" runat="server" Text="0" Visible="False"></asp:Label>
                                    <asp:Label ID="lblStatus" runat="server" Text="0" Visible="False"></asp:Label>
                                     <asp:Label ID="lblIsProject" runat="server" Text="0" Visible="False"></asp:Label>
                                    </td>
                            </tr>
                                    <tr>
                                        <td>
                                            <TABLE style="WIDTH: 98%" align=center><TBODY><TR>
                                                    <TD style="WIDTH: 100%; TEXT-ALIGN: center; height: 21px;"></TD></TR><TR>
                                                        <td class="InterFaceTableLeftRowUp" 
                                                    style="WIDTH: 100%; TEXT-ALIGN: center">
                                                            <table align="center" cellpadding="0" cellspacing="0" 
                                                    style="WIDTH: 62%">
                                                                <tbody><tr>
                                                                    <td class="InterfaceHeaderLabel3" style="HEIGHT: 17px">
                                                                        <asp:Label 
                                                    ID="lblPDDesc" runat="server" Font-Underline="False" Text="."></asp:Label></td></tr></tbody></table></td></TR>
                                                    <tr><td style="WIDTH: 100%; TEXT-ALIGN: center">
                                            
                                            <asp:GridView ID="GridItems" runat="server" AllowPaging="True" 
                                                    AutoGenerateColumns="False" CssClass="gridgeneralstyle" 
                                                    DataKeyNames="Item Code" EmptyDataText="REQUSITION HAS NO ITEMS" 
                                                    GridLines="None" HorizontalAlign="Left" 
                                                    OnPageIndexChanging="GridItems_PageIndexChanging" 
                                                    OnSelectedIndexChanged="GridItems_SelectedIndexChanged" PageSize="15" 
                                                    Width="100%">
                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                <RowStyle CssClass="gridRowStyle" VerticalAlign="Top" />
                                                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                <Columns>
                                                    <asp:BoundField DataField="Item Code" HeaderText="Item Code">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PlanCode" HeaderText="Plan Code">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Description" HeaderText="Item Description">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Ranking" HeaderText="Rank">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MarketPrice" DataFormatString="{0:N0}" 
                                                        HeaderText="Market Price">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TotalCost" DataFormatString="{0:N0}" 
                                                        HeaderText="Total Cost">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PlannedUnitCost" DataFormatString="{0:N0}" 
                                                        HeaderText="Planned Unit Cost">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView> 
                                            </td></tr><tr>
                                                        <td class="InterFaceTableLeftRowUp" 
                                                    style="WIDTH: 100%; TEXT-ALIGN: center"><asp:Label ID="lblTotal" 
                                                    runat="server" Font-Bold="True" Font-Names="Calibri" Text="." Visible="False"></asp:Label> 
                                            </td></tr></TBODY></TABLE>
                                                                </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top; text-align: center; height: 23px;">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="height: 2px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: center">
                                            
                                            <asp:MultiView id="MultiView3" runat="server">
                                                <asp:View ID="View4" runat="server">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="vertical-align: middle; height: 23px; text-align: center">
                                                                <table align ="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                                                    <tr>
                                                                        <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                            Write To Procurement Manager</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="vertical-align: middle; height: 23px; text-align: center">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="vertical-align: middle; height: 23px; text-align: center">
                                                              <asp:TextBox ID="FCKeditor1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:View>
                                        </asp:MultiView>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 2px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: middle; text-align: center">
                                            <asp:MultiView ID="MultiView2" runat="server">
                                                <asp:View ID="View5" runat="server">
                                                    &nbsp;
                                                   
                                                    <table align ="center" cellpadding="0" cellspacing="0" class="style12">
                                                        <tr>
                                                            <td colspan="2" style="vertical-align: top; text-align: center; height: 42px;">
                                            <table align ="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                                <tr>
                                                    <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                        Approve / Reject &nbsp;Requisition</td>
                                                </tr>
                                            </table>
                                                            </td>
                                                        </tr>
                                            <tr>
                                                <td style="text-align: center; vertical-align: top; width: 50%;">
                                                    <table align ="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                        <tr>
                                                            <td class="InterFaceTableLeftRowUp">
                                                                Approve Requisition</td>
                                                            <td class="InterFaceTableMiddleRowUp">
                                                                &nbsp;</td>
                                                            <td class="InterFaceTableRightRowUp">
                                                                <asp:RadioButtonList ID="rbnApproval" runat="server" CssClass="InterfaceDropdownList" AutoPostBack="True" OnSelectedIndexChanged="rbnApproval_SelectedIndexChanged">
                                                                    <asp:ListItem Value="1">Approve Requisition</asp:ListItem>
                                                                    <asp:ListItem Value="2">Reject Requisition</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="InterFaceTableLeftRowUp">
                                                                <asp:Label ID="lblDestination" runat="server" Text="Destination"></asp:Label></td>
                                                            <td class="InterFaceTableMiddleRowUp">
                                                            </td>
                                                            <td class="InterFaceTableRightRowUp">
                                                                <asp:DropDownList ID="cboSendTo" runat="server" OnDataBound="cboSendTo_DataBound"
                                                                    Width="80%" OnSelectedIndexChanged="cboSendTo_SelectedIndexChanged">
                                                                </asp:DropDownList></td>
                                                            <td>

                                                               
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="text-align: center; vertical-align: top; width: 50%;">
                                                    <table align ="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                    </table>
                                                    <table align ="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                        <tr>
                                                            <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                                Comment (If Required)</td>
                                                            <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                                &nbsp;</td>
                                                            <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                                <asp:TextBox ID="txtComment" runat="server" CssClass="InterfaceTextboxMultiline" TextMode="MultiLine" Height="80px"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                                        <tr>
                                                            <td colspan="2" style="vertical-align: top; text-align: center">
                                                            </td>
                                                        </tr>
                                        </table>
                                                        </ContentTemplate>
                                                    </ajaxToolkit:UpdatePanel>
                                                    <br />
                                                    <asp:Button ID="btnSubmitRequistn" runat="server" Font-Bold="True" Font-Size="9pt"
                                                        Height="23px" OnClick="btnSubmitRequistn_Click" Text="SUBMIT" Width="120px" />
                                                    <asp:Button ID="btnCancel" runat="server" Font-Bold="True" OnClick="btnCancel_Click"
                                                        Text="CANCEL" /></asp:View>
                                                &nbsp;
                                            </asp:MultiView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: middle; height: 23px; text-align: center">
                                    <asp:Label ID="lblreqn" runat="server" Text="Label" Visible="False"></asp:Label><asp:Label
                                        ID="lblCostCenter" runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblCostCenterID"
                                            runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblAreaID" runat="server" Text="0" Visible="False"></asp:Label>
                                            <asp:Label ID="lblRankNumber" runat="server" Text="0" Visible="False"></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                        </table>
                        </asp:View>
                              <asp:View ID="View2" runat="server">
                                  <table style="width: 100%">
                                      <tr>
                                          <td colspan="3" style="width: 100%; height: 21px; text-align: center">
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">
                                              ATTACHMENT(S)</td>
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
                                                      </td>
                                                  </tr>
                                                  <tr>
                                                      <td colspan="3">
                                                          <asp:GridView ID="GridAttachments" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                                              GridLines="None" HorizontalAlign="Left" OnRowCommand="GridAttachments_RowCommand"
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
                                                      <td colspan="3" style="height: 16px">
                                                      </td>
                                                  </tr>
                                              </table>
                                          </td>
                                      </tr>
                                      <tr>
                                          <td colspan="3" style="vertical-align: top; width: 100%; text-align: center">
                                              <asp:Label ID="Label1" runat="server" Text="0" Visible="False"></asp:Label><asp:Button
                                                  ID="btnSaveFile" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                  OnClick="btnSaveFile_Click" Text="SAVE " Width="80px" />
                                              <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                  OnClick="btnReturn_Click" Text="RETURN" Width="80px" /></td>
                                      </tr>
                                  </table>
                              </asp:View>
                              <asp:View ID="View3" runat="server">
                                  <table id="Table2" onclick="return TABLE1_onclick()" style="width: 100%">
                                      <tr>
                                          <td style="width: 100%; height: 21px; text-align: right">
                                          </td>
                                      </tr>
                                      <tr>
                                          <td style="width: 100%; text-align: center">
                                              <asp:Button ID="btnGoBack"
                                                      runat="server" OnClick="btnGoBack_Click" Text="Return to Requisitions" /></td>
                                      </tr>
                                      <tr>
                                          <td style="width: 100%; text-align: right">
                                          </td>
                                      </tr>
                                  </table>
                              </asp:View>
                        <asp:View ID="View6" runat="server">
                            <table id="Table3"  style="width: 98%">
                                <tr>
                                    <td style="width: 100%; height: 21px; text-align: center">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                                        STAGES OF REQUISITION</td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Export" />&nbsp;
                                        <asp:Button ID="Button1" runat="server" Text="Return" OnClick="Button1_Click" /></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: right">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: center">
                                        <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                            Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid1_ItemCommand" Style="text-align: justify"
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
                                    <td style="width: 100%; text-align: right">
                                    </td>
                                </tr>
                            </table>
                        </asp:View>
                        <asp:View ID="View7" runat="server">
                            <table id="Table2" onclick="return TABLE1_onclick()" style="width: 100%">
                                <tr>
                                    <td style="width: 100%; height: 21px; text-align: right">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                                        REQUISITION ITEM</td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                                        <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" Text="Print Form" />
                                        <asp:Button ID="btnPrintReturn" runat="server" Text="Return" OnClick="btnPrintReturn_Click" />&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: center">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; text-align: center">
                                        <%--<cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"></cr:crystalreportviewer>--%>
                                        &nbsp;&nbsp;<br />
                                        <asp:Label ID="lblPD_Code" runat="server" Text="0" Visible="False"></asp:Label></td>
                                </tr>
                            </table>
                        </asp:View><asp:View ID="View8" runat="server">
                            <table style="width: 100%">
                                <tr>
                                    <td colspan="1" style="width: 100%; height: 21px; text-align: center">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp" colspan="1" style="width: 100%; text-align: center">
                                        ATTACHMENT(S)</td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1" style="width: 100%; text-align: center">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Cambria" Font-Size="11pt"
                                            ForeColor="Red"></asp:Label></td>
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
                                                    <asp:GridView ID="GridView1" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                                              GridLines="None" HorizontalAlign="Left" OnRowCommand="GridView1_RowCommand"
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
                                                    <asp:Label ID="Label3" runat="server" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red"
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
                                    <td colspan="1" style="vertical-align: top; width: 100%; text-align: center">
                                        <asp:Label ID="Label4" runat="server" Text="0" Visible="False"></asp:Label>
                                        <asp:Button ID="Button5" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                  OnClick="btnReturn_Click" Text="RETURN" Width="80px" /></td>
                                </tr>
                            </table>
                        </asp:View>
                    </asp:MultiView>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; vertical-align: middle">
                
                    
                </td>
            </tr>
            <tr>
                <td style="text-align: center; vertical-align: middle">
                    </td>
            </tr>
            </table>
      
    
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




