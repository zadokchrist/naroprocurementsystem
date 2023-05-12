<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_finance.aspx.cs" Inherits="Requisition_finance" Title="FINANCE APPROVAL" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="ajaxToolkit" %>
<%@ Import  Namespace="System.Threading" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <%--<asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="9pt"
                                            Height="23px" Text=" View Attachments"
                                            Width="146px" OnClick="btnShowHideFiles_Click" />--%>
        
        <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                Requisition Description
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <span style="font-size: 13pt; font-family: Cambria">SERIAL: --&gt;&gt; ( </span>
                            <asp:Label ID="lblEntity" runat="server" Font-Names="cambria" Font-Size="13pt" ForeColor="Red"></asp:Label>
                            <span style="font-size: 13pt; font-family: Cambria">)</span>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">SERIAL:</div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtEntityCode" runat="server" BorderStyle="Solid" CssClass="form-control" Font-Bold="True" ForeColor="Firebrick" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">Date Requisitioned</div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtDateRequisitioned" runat="server" CssClass="form-control" Font-Bold="True"
                                ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">Procurement Type</div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtProcType" runat="server" CssClass="form-control" BorderStyle="Solid" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">Date Required</div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtDateRequired" runat="server" CssClass="form-control" BorderStyle="Solid" Font-Bold="True" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">Subject of Procurement</div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtProcSubject" runat="server" CssClass="form-control" TextMode="MultiLine" BorderStyle="Solid" Font-Bold="True" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">Location of Delivery</div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtDeliveryLocation" runat="server" BorderStyle="Solid" CssClass="form-control" Font-Bold="True"
                                ForeColor="Firebrick" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">Subject of Procurement</div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" TextMode="MultiLine" BorderStyle="Solid" Font-Bold="True" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">Cost Center</div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtBudgetCostCenter" runat="server" BorderStyle="Solid" CssClass="form-control" Font-Bold="True"
                    ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">Requisition Type</div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtRequisitionType" runat="server"
                                            BorderStyle="Solid" CssClass="form-control" Font-Bold="True"
                                            ForeColor="Firebrick" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">Budget Cost Center</div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="TextBox1" runat="server" BorderStyle="Solid" CssClass="form-control" Font-Bold="True"
                                            ForeColor="Firebrick" ReadOnly="true"></asp:TextBox>
            </div>
        </div>
            <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">Requisitioner</div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtRequisitioner" runat="server" BorderStyle="Solid" CssClass="form-control"
                                            Font-Bold="True" ForeColor="Firebrick" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-5 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                List of Items
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-12 mb-3 mb-sm-0">
                <asp:GridView ID="GridItems" runat="server" AllowPaging="True" CssClass="gridgeneralstyle"
                    DataKeyNames="Item Code" EmptyDataText="REQUSITION HAS NO ITEMS" GridLines="None"
                    HorizontalAlign="Center" Width="98%" AutoGenerateColumns="false" OnPageIndexChanging="GridItems_PageIndexChanging" CellPadding="4" ForeColor="#333333">
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
                        <asp:BoundField DataField="UnitCost" HeaderText="Unit Cost" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MarketPrice" HeaderText="Contract Amount" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" />
                            <HeaderStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-5 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <asp:Label ID="lblTotal" runat="server" Font-Bold="True" Font-Names="Calibri" Text="."
                              Visible="False"></asp:Label>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <asp:Button ID="btnShowHideFiles" runat="server" Text="VIEW ATTACHMENTS"  class="btn btn-primary btn-user btn-block float-right" OnClick="btnShowHideFiles_Click" />
            </div>
        </div>
        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" MinimumPrefixLength="1"
                                    ServiceMethod="GetAccountingCodes" ServicePath="CascadingddlService.asmx" TargetControlID="txtBugetCode">
                                </ajaxToolkit:AutoCompleteExtender>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" MinimumPrefixLength="1"
                                    ServiceMethod="GetCostCenterItems" ServicePath="CascadingddlService.asmx" TargetControlID="txtCostCenterForBudget">
                                </ajaxToolkit:AutoCompleteExtender>
        <div class="form-group row">
            <div class="col-sm-2 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">COST CENTER</div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <asp:TextBox ID="txtCostCenterForBudget" runat="server" autocomplete="off" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-2 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0"><asp:Label ID="lblbudgetCode" runat="server" Text="TYPE BUDGET CODE"></asp:Label></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <asp:TextBox ID="txtBugetCode" runat="server" autocomplete="off" Font-Bold="True" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-2 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <asp:Button ID="BtnGetBudget" runat="server" CausesValidation="False" Font-Bold="True" OnClick="BtnGetBudget_Click" Text="GET BUDGET" Visible="false"  class="btn btn-primary btn-user btn-block float-right"/>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-2 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="."></asp:Label>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-2 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <asp:Label ID="lblmsgBudget" runat="server" Font-Names="Cambria" Font-Size="11pt"
                                                ForeColor="Red" Text="." Visible="False"></asp:Label>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>Amount Approved On Budget</label>
                <asp:TextBox ID="txtbudgetAmount" runat="server" Font-Bold="True" onkeyup="javascript:this.value=Comma(this.value);" CssClass="form-control">0</asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FTEBudgetAmount" runat="server" TargetControlID="txtbudgetAmount"  FilterType="Custom,Numbers" ValidChars=",-">
                                                </ajaxToolkit:FilteredTextBoxExtender>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>Expenditure to Date</label>
                <asp:TextBox ID="txtExpenditure" runat="server" Font-Bold="True" onkeyup="javascript:this.value=Comma(this.value);" CssClass="form-control">0</asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FTEExpenditure" runat="server" TargetControlID="txtExpenditure"  FilterType="Custom,Numbers" ValidChars=",-">
                                                </ajaxToolkit:FilteredTextBoxExtender>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>Current Requisition Amount</label>
                <asp:TextBox ID="txtRequisitionAmount" runat="server" Font-Bold="True" onkeyup="javascript:this.value=Comma(this.value);" CssClass="form-control" Enabled="False"></asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FTERequisition" runat="server" TargetControlID="txtRequisitionAmount"  FilterType="Custom,Numbers" ValidChars=",-">
                                                </ajaxToolkit:FilteredTextBoxExtender>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>Balance on Budget</label>
                <asp:TextBox ID="txtBalance" runat="server" AutoPostBack="True"   Enabled="False" CssClass="form-control"></asp:TextBox>
                                            &nbsp;&nbsp;
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FTEBalance" runat="server" TargetControlID="txtBalance"  FilterType="Custom,Numbers" ValidChars=",-">
                                                </ajaxToolkit:FilteredTextBoxExtender>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <%--<label>Total Requisitioned Amount</label>--%>
                <asp:TextBox ID="txtPendingSum" runat="server" Enabled="False" Font-Bold="True" onkeyup="javascript:this.value=Comma(this.value);" CssClass="form-control" Visible="false"></asp:TextBox>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <asp:TextBox ID="txtBalanceMinusPending" runat="server" AutoPostBack="True" Enabled="False" Visible="False" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-5 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                Approve Requisition
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-2 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                Approve Requisition
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <asp:RadioButtonList ID="rbnApproval" runat="server" CssClass="InterfaceDropdownList">
                                                <asp:ListItem Value="1">Funds Available</asp:ListItem>
                                                <asp:ListItem Value="2">Funds Not Available/Changes Required</asp:ListItem>
                                            </asp:RadioButtonList>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-2 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
               Comment (If Required)
            </div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-4 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <asp:Button ID="btnSubmitRequistn" runat="server" Text="SUBMIT" Font-Bold="True" OnClick="btnSubmitRequistn_Click" Enabled="False"  class="btn btn-primary btn-user btn-block float-right"/>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <asp:Button ID="btnFinalReturn" runat="server" OnClick="btnFinalReturn_Click" Text="Return"  class="btn btn-primary btn-user btn-block float-right"/>
            </div>
        </div>
            <table cellpadding="0" cellspacing="0" class="style12">
                <tr>
                    <td style="vertical-align: middle; text-align: center; height: 23px;"></td>
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
    </asp:MultiView>&nbsp;
    </div>
      
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





