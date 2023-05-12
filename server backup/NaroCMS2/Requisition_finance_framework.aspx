<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Requisition_finance_framework.aspx.cs" Inherits="Requisition_finance" Title="FINANCE APPROVAL" %>
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
                                       FINANCE APPROVE FRAMEWORK CONTRACT REQUISITION</td>
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
                            FRAMEWORK DESCRIPTION</td>
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
                        <td colspan="2" style="vertical-align: top; height: 35px; text-align: center">
                            <span style="font-size: 13pt; font-family: Cambria">SERIAL: --&gt;&gt; ( </span>
                            <asp:Label ID="lblEntity" runat="server" Font-Names="cambria" Font-Size="13pt" ForeColor="Red"></asp:Label>
                            <span style="font-size: 13pt; font-family: Cambria">)</span></td>
                    </tr>
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
                                            ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                </tr>
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
                                            TextMode="MultiLine" BorderStyle="Solid" Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRow">
                                        Type of Requisition</td>
                                    <td class="InterFaceTableMiddleRow">
                                    </td>
                                    <td class="InterFaceTableRightRow">
                                        <asp:TextBox ID="txtRequisitionType" runat="server"
                                            BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                            ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRow">
                                        Requisitioner</td>
                                    <td class="InterFaceTableMiddleRow">
                                    </td>
                                    <td class="InterFaceTableRightRow">
                                        <asp:TextBox ID="txtRequisitioner" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
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
                        <td class="InterFaceTableRightRowUp" style="height: 30px; width: 64%;">
                            <asp:TextBox ID="txtDateRequisitioned" runat="server"
                                BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                ReadOnly="True" Width="90%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="height: 30px">
                            Date Required</td>
                        <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                            &nbsp;</td>
                        <td class="InterFaceTableRightRowUp" style="height: 30px; width: 64%;">
                                        <asp:TextBox ID="txtDateRequired" runat="server" 
                                            CssClass="InterfaceTextboxLongReadOnly" Width="90%" BorderStyle="Solid" Font-Bold="True" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="height: 30px">
                            Location of Delivery</td>
                        <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                        </td>
                        <td class="InterFaceTableRightRowUp" style="height: 30px; width: 64%;">
                            <asp:TextBox ID="txtDeliveryLocation" runat="server"
                                BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="height: 30px">
                            Cost Center</td>
                        <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                            &nbsp;</td>
                        <td class="InterFaceTableRightRowUp" style="width: 64%; height: 30px">
                            <asp:TextBox ID="txtBudgetCostCenter" runat="server"
                                BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                ReadOnly="True" Width="90%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp">
                            Budget Cost Center</td>
                        <td class="InterFaceTableMiddleRowUp">
                        </td>
                        <td class="InterFaceTableRightRowUp" style="width: 64%">
                                        <asp:TextBox ID="TextBox1" runat="server"
                                            BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                            ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                    </tr>
                      </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 34px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
              <table style="width: 100%" align="center">
                  <tr>
                      <td style="width: 100%; text-align: center"><table align ="center" cellpadding="0" cellspacing="0" style="width: 60%">
                          <tr>
                              <td class="InterfaceHeaderLabel3">
                                  List of Items</td>
                          </tr>
                      </table>
                      </td>
                  </tr>
                  <tr>
                      <td style="width: 100%; text-align: center">
                <asp:GridView ID="GridItems" runat="server" AllowPaging="True" CssClass="gridgeneralstyle"
                    DataKeyNames="Item Code" EmptyDataText="REQUSITION HAS NO ITEMS" GridLines="None"
                    HorizontalAlign="Center" Width="98%" AutoGenerateColumns="false" OnPageIndexChanging="GridItems_PageIndexChanging">
                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="gridRowStyle" />
                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                    <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                    <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                    <Columns>
                        <asp:BoundField DataField="Item Code" HeaderText="Item Code" >
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PlanCode" HeaderText="Plan Code" >
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Item Description" >
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Ranking" HeaderText="Rank">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" >
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" />
                            <HeaderStyle HorizontalAlign="Right" />
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
              </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                </table>
                                                        <asp:Button ID="btnShowHideFiles" runat="server" Font-Bold="True" Font-Size="9pt"
                                                            Height="23px" Text="VIEW ATTACHMENTS"
                                                            Width="152px" OnClick="btnShowHideFiles_Click" />
                &nbsp;
            </td>
        </tr>
                <tr>
                    <td style="vertical-align: top; height: 23px; text-align: center">
                        
                            
                                
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" MinimumPrefixLength="1"
                                    ServiceMethod="GetCostCenterItems" ServicePath="CascadingddlService.asmx" TargetControlID="txtCostCenterForBudget">
                                </ajaxToolkit:AutoCompleteExtender>
                                &nbsp;&nbsp;
                                <table align="center" cellpadding="0" cellspacing="0" style="width: 90%">
                                    <tr>
                                        <td colspan="4" style="vertical-align: middle; height: 18px; text-align: center">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="vertical-align: middle; height: 35px; text-align: center" class="InterFaceTableLeftRowUp">
                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 90%">
                                                <tr>
                                                    <td class="InterfaceHeaderLabel3a" style="color: black; height: 17px">
                                                        <table class="InterFaceTableRightRowUp" style="width: 100%">
                                                            <tr>
                                                                <td colspan="3" style="vertical-align: middle; height: 2px; text-align: right">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="vertical-align: middle; width: 20%; text-align: right">
                                                                    <span id="ctl00_ContentPlaceHolder1_Label1" style="display: inline-block; width: 100%">
                                                                        COST CENTER</span></td>
                                                                <td style="vertical-align: middle; width: 60%; text-align: center">
                                                                    <asp:TextBox ID="txtCostCenterForBudget" runat="server" autocomplete="off" Font-Bold="True"
                                                                        Font-Size="11pt" ForeColor="Firebrick" Width="85%"></asp:TextBox></td>
                                                                <td style="vertical-align: middle; width: 20%; text-align: center">
                                                                    <span style="color: #ff0000">(Zero[0] = Global)</span></td>
                                                            </tr>
                                                            <%--<tr>
                                                                <td style="vertical-align: middle; width: 20%; text-align: right">
                                                                    <asp:Label ID="lblbudgetCode" runat="server" Text="TYPE BUDGET CODE" Width="100%"></asp:Label></td>
                                                                <td style="vertical-align: middle; width: 60%; text-align: center">
                                                                    <asp:TextBox ID="txtBugetCode" runat="server" autocomplete="off" Font-Bold="True"
                                                                        Font-Size="11pt" ForeColor="Firebrick" Width="85%"></asp:TextBox></td>
                                                                <td style="vertical-align: middle; width: 20%; text-align: center">
                                                                    <asp:Button ID="BtnGetBudget" runat="server" CausesValidation="False" Font-Bold="True"
                                                                        Font-Size="9pt" Height="23px" OnClick="BtnGetBudget_Click" Text="GET BUDGET"
                                                                        Width="130px" /></td>
                                                            </tr>--%>
                                                        </table>
                                                        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="."></asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="vertical-align: middle; height: 10px; text-align: center" class="InterFaceTableLeftRowUp">
                                            <asp:Label ID="lblmsgBudget" runat="server" Font-Names="Cambria" Font-Size="11pt"
                                                ForeColor="Red" Text="." Visible="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="InterFaceTableLeftRowUp" colspan="4" style="vertical-align: middle; height: 10px;
                                            text-align: center">
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="InterfaceHeaderLabel3" style="vertical-align: middle; width: 100%; height: 18px;
                                            text-align: center">
                                            Framework Contract Requisition Amount</td>
                                        
                                    </tr>
                                    <tr>
                                        <td class="ddcolortabsline2" colspan="4" style="vertical-align: middle; height: 1px;
                                            text-align: center">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        
                                        <td style="vertical-align: middle; width: 20%; text-align: center">
                                            <asp:TextBox ID="txtRequisitionAmount" style="text-align: center" runat="server" Font-Bold="True" Font-Size="13pt" onkeyup="javascript:this.value=Comma(this.value);"
                                                ForeColor="Firebrick" Width="85%" Enabled="False"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FTERequisition" runat="server" TargetControlID="txtRequisitionAmount"  FilterType="Custom,Numbers" ValidChars=",-">
                                                </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td class="InterfaceHeaderLabel3" style="vertical-align: middle; width: 20%; text-align: center">
                                        </td>
                                        <td class="InterfaceHeaderLabel3" style="vertical-align: middle; width: 20%; text-align: center">
                                        </td>
                                        
                                        <td class="InterfaceHeaderLabel3" style="vertical-align: middle; width: 20%; text-align: center">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: middle; width: 20%; text-align: center">
                                        </td>
                                        <td style="vertical-align: middle; width: 20%; text-align: center">
                                        </td>
                                        
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </ajaxToolkit:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="height: 2px">
                        </td>
                </tr>
                <tr>
                    <td style="vertical-align: middle; text-align: center; height: 21px;" class="InterFaceTableLeftRowUp">
                        <table align ="center" cellpadding="0" cellspacing="0" style="width: 60%">
                            <tr>
                                <td class="InterfaceHeaderLabel3" style="height: 17px">
                                    Approve Framework Contract Requisition</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: middle; text-align: center"><table align ="center" cellpadding="0" cellspacing="0" class="style12">
                        <tr>
                            <td style="text-align: center; vertical-align: top; width: 50%;">
                                <table align ="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                    <tr>
                                        <td class="InterFaceTableLeftRowUp">
                                            Approve Framework Contract Requisition</td>
                                        <td class="InterFaceTableMiddleRowUp">
                                            &nbsp;</td>
                                        <td class="InterFaceTableRightRowUp">
                                            <asp:RadioButtonList ID="rbnApproval" runat="server" CssClass="InterfaceDropdownList">
                                                <asp:ListItem Value="1">Approve Framework Contract Requisition</asp:ListItem>
                                                <asp:ListItem Value="2">Reject Framework Contract Requisition</asp:ListItem>
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
                    </table>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: middle; height: 2px; text-align: center">
                        </td>
                </tr>
                <tr>
                    <td style="vertical-align: middle; text-align: center; height: 23px;"><asp:Button ID="btnSubmitRequistn" runat="server" Font-Size="9pt" Height="23px"
                                            Text="SUBMIT" Width="120px" Font-Bold="True" OnClick="btnSubmitRequistn_Click" Enabled="False" />
                        <asp:Button ID="btnFinalReturn" runat="server" OnClick="btnFinalReturn_Click" Text="Return"
                            Width="81px" /></td>
                </tr>
                <tr>
                    <td style="vertical-align: middle; height: 23px; text-align: center">
                <asp:Label ID="lblreqn" runat="server" Text="Label" Visible="False"></asp:Label>
                        <asp:Label ID="lblPlanCode" runat="server" Font-Names="cambria" Font-Size="13pt" Visible="False">0</asp:Label><asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblRecordCode" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblCostCenter" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblCostCenterID" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblAreaID" runat="server" Text="0" Visible="False"></asp:Label></td>
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
                          <asp:Label ID="Label11" runat="server" Text="0" Visible="False"></asp:Label>
                          <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                              OnClick="btnReturn_Click" Text="RETURN" Width="80px" /></td>
                  </tr>
              </table>
          </asp:View>
          <asp:View ID="View3" runat="server">
              <table id="Table2"  style="width: 100%">
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
    </asp:MultiView>&nbsp;
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





