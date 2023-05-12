<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_ViewDetails.aspx.cs" Inherits="Requisition_Approval" Title="REQUISITION APPROVAL" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="ajaxToolkit" %>
<%@ Import  Namespace="System.Threading" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                    APPROVE REQUISITION
                </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Text="Return" class="btn btn-primary btn-user btn-block float-right" OnClick="btnReturn_Click2" />
            </div>
        </div>
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
                 <div class="col-sm-6 mb-3 mb-sm-0">
                    <span style="font-size: 13pt; font-family: Cambria">SERIAL: --&gt;&gt; ( </span>
                    <asp:Label ID="lblEntity" runat="server" Font-Names="cambria" Font-Size="13pt" ForeColor="Red"></asp:Label>
                    <span style="font-size: 13pt; font-family: Cambria">)</span>
                 </div>
             </div>
             <div class="form-group row">
                 <div class="col-sm-1 mb-3 mb-sm-0"></div>
                 <div class="col-sm-2 mb-3 mb-sm-0">
                     Procurement Type
                 </div>
                 <div class="col-sm-3 mb-3 mb-sm-0">
                     <asp:TextBox ID="txtProcType" runat="server" CssClass="form-control" BorderStyle="Solid" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                 </div>
                 <div class="col-sm-1 mb-3 mb-sm-0">
                     Date Requisitioned		
                 </div>
                 <div class="col-sm-3 mb-3 mb-sm-0">
                     <asp:TextBox ID="txtDateRequisitioned" runat="server" BorderStyle="Solid" CssClass="form-control" Font-Bold="True"
                                                         ReadOnly="True"></asp:TextBox>
                 </div>
             </div>
             <div class="form-group row">
                 <div class="col-sm-1 mb-3 mb-sm-0"></div>
                 <div class="col-sm-2 mb-3 mb-sm-0">
                    Subject of Procurement
                 </div>
                 <div class="col-sm-3 mb-3 mb-sm-0">
                     <asp:TextBox ID="txtProcSubject" runat="server" CssClass="form-control"
                                                         TextMode="MultiLine" BorderStyle="Solid" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                 </div>
                 <div class="col-sm-1 mb-3 mb-sm-0">
                     Date Required
                 </div>
                 <div class="col-sm-3 mb-3 mb-sm-0">
                     <asp:TextBox ID="txtDateRequired" runat="server" CssClass="form-control" BorderStyle="Solid" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                 </div>
             </div>
             <div class="form-group row">
                 <div class="col-sm-1 mb-3 mb-sm-0"></div>
                 <div class="col-sm-2 mb-3 mb-sm-0">
                    Type of Requisition
                 </div>
                 <div class="col-sm-3 mb-3 mb-sm-0">
                     <asp:TextBox ID="txtRequisitionType" runat="server"
                         BorderStyle="Solid" CssClass="form-control" Font-Bold="True"
                         ReadOnly="True"></asp:TextBox>
                 </div>
                 <div class="col-sm-1 mb-3 mb-sm-0">
                     Location of Delivery
                 </div>
                 <div class="col-sm-3 mb-3 mb-sm-0">
                     <asp:TextBox ID="txtDeliveryLocation" runat="server" BorderStyle="Solid" CssClass="form-control"
                                                         Font-Bold="True" ForeColor="Firebrick" ReadOnly="True"></asp:TextBox>
                 </div>
             </div>
             <div class="form-group row">
                 <div class="col-sm-1 mb-3 mb-sm-0"></div>
                 <div class="col-sm-2 mb-3 mb-sm-0">
                     Ware House
                 </div>
                 <div class="col-sm-3 mb-3 mb-sm-0">
                     <asp:TextBox ID="txtWareHouse" runat="server" BorderStyle="Solid" CssClass="form-control"
                                                         Font-Bold="True" ForeColor="Firebrick" ReadOnly="True"></asp:TextBox>
                 </div>
                 <div class="col-sm-1 mb-3 mb-sm-0">
                     Cost Center
                 </div>
                 <div class="col-sm-3 mb-3 mb-sm-0">
                     <asp:TextBox ID="txtBudgetCostCenter" runat="server" BorderStyle="Solid" CssClass="form-control" Font-Bold="True"
                         ReadOnly="True"></asp:TextBox>
                 </div>
             </div>
             <div class="form-group row">
                 <div class="col-sm-1 mb-3 mb-sm-0"></div>
                 <div class="col-sm-2 mb-3 mb-sm-0">
                     Requisitioner
                 </div>
                 <div class="col-sm-3 mb-3 mb-sm-0">
                     <asp:TextBox ID="txtRequisitioner" runat="server"
                         BorderStyle="Solid" CssClass="form-control" Font-Bold="True"
                         ForeColor="Firebrick" ReadOnly="True"></asp:TextBox>
                 </div>
                 <div class="col-sm-1 mb-3 mb-sm-0">
                     Cost Center Manager
                 </div>
                 <div class="col-sm-3 mb-3 mb-sm-0">
                     <asp:TextBox ID="txtManager" runat="server" BorderStyle="Solid" CssClass="form-control"
                                                         Font-Bold="True" ForeColor="Firebrick" ReadOnly="True"></asp:TextBox>
                 </div>
             </div>
             <div class="form-group row">
                 <div class="col-sm-1 mb-3 mb-sm-0"></div>
                 <div class="col-sm-2 mb-3 mb-sm-0">
                     
                 </div>
                 <div class="col-sm-3 mb-3 mb-sm-0">
                     <asp:Label ID="lblCreatedBy" runat="server" Visible="False"></asp:Label>
                 </div>
             </div>
             <div class="form-group row">
                 <div class="col-sm-1 mb-3 mb-sm-0"></div>
                 <div class="col-sm-2 mb-3 mb-sm-0">
                     <asp:Button ID="btnShowHideFiles" runat="server" Font-Bold="True"  class="btn btn-primary btn-user btn-block float-right" Text=" View Attachments" OnClick="btnShowHideFiles_Click" />
                 </div>
                 <div class="col-sm-3 mb-3 mb-sm-0">
                     <asp:Button ID="btnViewStatus" runat="server" Font-Bold="True" Text=" View Status" class="btn btn-primary btn-user btn-block float-right"
                         OnClick="btnViewStatus_Click" />
                 </div>
                 <div class="col-sm-3 mb-3 mb-sm-0">
                     <asp:Button ID="btnPrintPR" runat="server" Font-Bold="True"  class="btn btn-primary btn-user btn-block float-right"
                         Text="Print Requisition" OnClick="btnPrintPR_Click" />
                 </div>
             </div>
             <div class="form-group row">
                 <div class="col-sm-1 mb-3 mb-sm-0"></div>
                 <div class="col-sm-7 mb-3 mb-sm-0">
                     <asp:Label ID="lblPlanCode" runat="server" Font-Names="cambria" Font-Size="13pt" Visible="False">0</asp:Label>
                        <asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblRecordCode" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblCostCenterCode" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblScalaPR" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblCostCenterForBudget" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblStatus" runat="server" Text="0" Visible="False"></asp:Label>
                 </div>
             </div>
             <div class="form-group row">
                 <div class="col-sm-1 mb-3 mb-sm-0"></div>
                 <div class="col-sm-7 mb-3 mb-sm-0">
                     <asp:Label ID="lblPDDesc" runat="server" Text="." Font-Underline="False"></asp:Label>
                 </div>
             </div>
             <div class="form-group row">
                 <div class="col-sm-12 mb-3 mb-sm-0">
                     <asp:GridView ID="GridItems" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="gridgeneralstyle" PageSize="15" HorizontalAlign="Left" GridLines="None" DataKeyNames="Item Code" EmptyDataText="REQUSITION HAS NO ITEMS" AllowPaging="True">
                         <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                         <RowStyle CssClass="gridRowStyle" />
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
                                 <ItemStyle HorizontalAlign="Left" />
                                 <HeaderStyle HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:BoundField DataField="TotalCost" HeaderText="Total Cost" DataFormatString="{0:N0}">
                                 <ItemStyle HorizontalAlign="Left" />
                                 <HeaderStyle HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:BoundField DataField="MarketPrice" HeaderText="Market Price" DataFormatString="{0:N0}">
                                 <ItemStyle HorizontalAlign="Left" />
                                 <HeaderStyle HorizontalAlign="Left" />
                             </asp:BoundField>
                         </Columns>
                     </asp:GridView>
                 </div>
             </div>
             <div class="form-group row">
                 <div class="col-sm-1 mb-3 mb-sm-0"></div>
                 <div class="col-sm-7 mb-3 mb-sm-0">
                     <asp:Label ID="lblTotal" runat="server" Text="." Font-Names="Calibri" Font-Bold="True" Visible="False"></asp:Label>
                 </div>
             </div>
             </asp:View>
             <asp:View ID="View6" runat="server">
                 <table id="Table3" onclick="return TABLE1_onclick()" style="width: 98%">
                     <tr>
                         <td style="width: 100%; height: 21px; text-align: center"></td>
                     </tr>
                     <tr>
                         <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">STAGES OF REQUISITION</td>
                     </tr>
                     <tr>
                         <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                             <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Export" />&nbsp;
                                       
                             <asp:Button ID="Button1" runat="server" Text="Return" OnClick="Button1_Click" /></td>
                     </tr>
                     <tr>
                         <td style="width: 100%; text-align: right"></td>
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
                         <td style="width: 100%; text-align: right"></td>
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
                        </asp:View>
             <asp:View ID="View8" runat="server">
                 <div class="form-group row">
                     <div class="col-sm-3 mb-3 mb-sm-0"></div>
                     <div class="col-sm-6 mb-3 mb-sm-0">
                             ATTACHMENT(S)
                     </div>
                 </div>
                 <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Cambria" Font-Size="11pt"
                                    ForeColor="Red"></asp:Label>
                    </div>
                </div>
                 <div class="form-group row">
                     <div class="col-sm-3 mb-3 mb-sm-0"></div>
                     <div class="col-sm-6 mb-3 mb-sm-0">
                         View Attachments
                     </div>
                 </div>
                 <div class="form-group row">
                     <div class="col-sm-12 mb-3 mb-sm-0">
                         <asp:GridView ID="GridView1" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                             GridLines="None" HorizontalAlign="Left" OnRowCommand="GridView1_RowCommand"
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
                                                        </Columns>
                                                        <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                        <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                    </asp:GridView>
                     </div>
                 </div>
                 <div class="form-group row">
                     <div class="col-sm-3 mb-3 mb-sm-0"></div>
                     <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:Label ID="Label3" runat="server" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red"
                                                        Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label>
                     </div>
                 </div>
                 <div class="form-group row">
                     <div class="col-sm-3 mb-3 mb-sm-0"></div>
                     <div class="col-sm-6 mb-3 mb-sm-0">
                         <asp:Label ID="Label4" runat="server" Text="0" Visible="False"></asp:Label>
                                        <asp:Button ID="Button5" runat="server"
                                                  OnClick="btnReturn_Click" Text="RETURN" class="btn btn-primary btn-user btn-block float-right" />
                     </div>
                 </div>
                        </asp:View>
                    </asp:MultiView>
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




