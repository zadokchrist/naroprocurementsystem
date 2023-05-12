<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Requisition_RankApproval.aspx.cs" Inherits="Requisition_RankApproval" Title="RANK APPROVING" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="ajaxToolkit" %>
<%@ Import  Namespace="System.Threading" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>

    <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td style="text-align: center; vertical-align: middle">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 80%">
                                <tr>
                                    <td class="InterfaceHeaderLabel" style="height: 20px">
                                        APPROVE PRIORITY/RANK</td>
                                </tr>
                            </table>
            </td>
        </tr>
        </table>
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
            <td style="height: 209px">
                <table align ="center" cellpadding="0" cellspacing="0" class="style12">
                    <tr>
                        <td style="text-align: center; vertical-align: top; width: 50%; height: 121px;">
                            <table align ="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        SERIAL:</td>
                                    <td class="InterFaceTableMiddleRowUp">
                                    </td>
                                    <td class="InterFaceTableRightRowUp">
                                        <asp:TextBox ID="txtEntityCode" runat="server"  
                                            BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                             ReadOnly="True" Width="90%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Procurement Type</td>
                                    <td class="InterFaceTableMiddleRowUp">
                                        &nbsp;</td>
                                    <td class="InterFaceTableRightRowUp">
                                        <asp:TextBox ID="txtProcType" runat="server" CssClass="InterfaceTextboxLongReadOnly"
                                            Width="90%"  BorderStyle="Solid" Font-Bold="False" ReadOnly="True"></asp:TextBox></td>
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
                        <td class="InterFaceTableLeftRowUp" style="height: 30px">
                            Location of Delivery</td>
                        <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                        </td>
                        <td class="InterFaceTableRightRowUp" style="height: 30px">
                            <asp:TextBox ID="txtDeliveryLocation" runat="server"
                                BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
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
                      </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
              <table style="width: 100%" align="center">
                  <tr>
                      <td style="width: 100%; text-align: center">
                      </td>
                  </tr>
                  <tr>
                      <td style="width: 100%; text-align: center" class="InterFaceTableLeftRowUp">
                                    <table align ="center" cellpadding="0" cellspacing="0" style="width: 70%">
                                        <tr>
                                            <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                <asp:Label ID="lblPDDesc" runat="server" Text="."></asp:Label></td>
                                        </tr>
                                    </table>
                      </td>
                  </tr>
                  <tr>
                      <td style="width: 100%; text-align: center">
                          <asp:Label ID="lblmsg2" runat="server" Font-Names="Cambria" Font-Size="11pt" Font-Underline="True"
                              ForeColor="Red" Text="(PLEASE NOTE: ITEMS WITH RANK = 1 ARE OF MORE PRIORITY THAN THOSE OF RANK = 5)"></asp:Label></td>
                  </tr>
                  <tr>
                      <td style="width: 100%; text-align: center">
                        <asp:GridView ID="GridItems" runat="server" AllowPaging="True" CssClass="gridgeneralstyle" AutoGenerateColumns="false"
                            DataKeyNames="Item Code" EmptyDataText="REQUSITION HAS NO ITEMS" GridLines="None"
                            HorizontalAlign="Left" PageSize="15" Width="98%">
                            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                            <RowStyle CssClass="gridRowStyle" VerticalAlign="Top" />
                            <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                            <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                            <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                            <Columns>
                                <asp:BoundField DataField="ITEM CODE" HeaderText="Item Code" />
                                <asp:BoundField DataField="PLANCODE" HeaderText="Plan Code" />
                                <asp:BoundField DataField="DESCRIPTION" HeaderText="Item Description" />
                                <asp:BoundField DataField="RANKING" HeaderText="Ranking" />
                                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                <asp:BoundField DataField="QuantityRemaining" HeaderText="Remaining Quantity" />
                                <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" DataFormatString="{0:N2}">
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" DataFormatString="{0:N2}">
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MarketPrice" HeaderText="Market Price" Visible="false" DataFormatString="{0:N2}">
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                      </td>
                  </tr>
                  <tr>
                      <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                          <asp:Label ID="lblTotal" runat="server" Font-Bold="True" Font-Names="Calibri" Text="."
                              Visible="False"></asp:Label>
                      </td>
                  </tr>
                  <tr>
                      <td style="width: 100%; text-align: center">
                      </td>
                  </tr>
              </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="vertical-align: top; text-align: center">
                        </td>
                    </tr>
                </table>
                            <asp:Label ID="lblPlanCode" runat="server" Font-Names="cambria" Font-Size="13pt" Visible="False">0</asp:Label>
                <asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblRecordCode" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblCostCenterCode" runat="server" Text="0" Visible="False"></asp:Label></td>
        </tr>
                <tr>
                    <td style="vertical-align: top; text-align: center; height: 23px;">
                        &nbsp;<asp:Button ID="btnShowHideFiles" runat="server" Font-Bold="True" Font-Size="9pt"
                                                            Height="23px" Text=" VIEW ATTACHMENTS"
                                                            Width="168px" OnClick="btnShowHideFiles_Click" />
                        <asp:Button ID="btnViewStatus" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                            OnClick="btnViewStatus_Click" Text=" View Status" Width="146px" /></td>
                </tr>
                <tr>
                    <td style="height: 2px">
                        </td>
                </tr>
                <tr>
                    <td style="vertical-align: middle; text-align: center">
                        <asp:MultiView ID="MultiView2" runat="server">
                            <asp:View ID="View5" runat="server">
                                <table align ="center" cellpadding="0" cellspacing="0" class="style12">
                                    <tr>
                                        <td colspan="2" style="vertical-align: top; text-align: center">
                        <table align ="center" cellpadding="0" cellspacing="0" style="width: 60%">
                            <tr>
                                <td class="InterfaceHeaderLabel3" style="height: 17px">
                                    Approve Requisition</td>
                            </tr>
                        </table>
                                        </td>
                                    </tr>
                        <tr>
                            <td style="text-align: center; vertical-align: top; width: 50%;">
                                <table align ="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                    <tr>
                                        <td class="InterFaceTableRightRowUp">
                                            <asp:RadioButtonList ID="rbnApproval" runat="server" CssClass="InterfaceDropdownList">
                                                <asp:ListItem Value="1">Accept Requisition</asp:ListItem>
                                                <asp:ListItem Value="2">Reject Requisition</asp:ListItem>
                                            </asp:RadioButtonList></td>
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
                                            <asp:TextBox ID="txtComment" runat="server" CssClass="InterfaceTextboxMultiline" TextMode="MultiLine"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                                    <tr>
                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                        </td>
                                    </tr>
                    </table>
                    <asp:Button ID="btnSubmitRequistn" runat="server" Font-Size="9pt" Height="23px"
                                            Text="SUBMIT" Width="120px" Font-Bold="True" OnClick="btnSubmitRequistn_Click" /></asp:View>
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
                                          GridLines="None" HorizontalAlign="Center" OnRowCommand="GridAttachments_RowCommand"
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
                      <td colspan="1" style="vertical-align: top; width: 100%; text-align: center">
                          <asp:Label ID="Label1" runat="server" Text="0" Visible="False"></asp:Label>
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
          <asp:View ID="View4" runat="server">
          </asp:View>
          <asp:View ID="View6" runat="server">
              <table id="Table3" onclick="return TABLE1_onclick()" style="width: 98%">
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
                          &nbsp;
                          <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Return" /></td>
                  </tr>
                  <tr>
                      <td style="width: 100%; text-align: right">
                      </td>
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
                      <td style="width: 100%; text-align: right">
                      </td>
                  </tr>
              </table>
          </asp:View>
    </asp:MultiView>&nbsp;
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






