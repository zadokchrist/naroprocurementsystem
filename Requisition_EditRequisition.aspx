<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_EditRequisition.aspx.cs" Inherits="Requisition_NewRequisition" Title="NEW REQUISITION" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                EDIT A REQUISITION
                        <asp:Label ID="lblRequisition" runat="server"></asp:Label>
            </div>
            </div>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-5 mb-3 mb-sm-0">
                        SERIAL: --&gt;&gt; (
                        <asp:Label ID="lblEntity" runat="server" Font-Names="cambria" Font-Size="13pt" ForeColor="Red"></asp:Label>)
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Select Requisition Type
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="CboRequisition" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0">- Select Requisition Type -</asp:ListItem>
                                <asp:ListItem Value="1">Normal Requisition</asp:ListItem>
                                <asp:ListItem Value="2">Emergency Requisition</asp:ListItem>
                            </asp:DropDownList>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Location of Delivery</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboLocation" runat="server" CssClass="form-control" OnDataBound="cboLocation_DataBound">
                            </asp:DropDownList>
                            <asp:Label ID="lblLoc" runat="server" Text="." Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Subject of Procurement
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Date Required</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtDateRequired" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Tick if applicable
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:CheckBox ID="chkIsFramework" runat="server" AutoPostBack="True" Font-Bold="True"
                                        Font-Italic="True" Text="Is FrameWork" />
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Ware House
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboWareHouse" runat="server" CssClass="form-control" OnDataBound="cboWareHouse_DataBound">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-5 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        EDIT CURRENT REQUISITION ITEMS
                    </div>
                </div>
    <table style="width: 95%" align="center">
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
            <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                            ForeColor="#333333" GridLines="None" Width="100%" HorizontalAlign="Left" OnItemCommand="DataGrid2_ItemCommand">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#999999" />
                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                <Columns>
                    <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove">
                        <ItemStyle ForeColor="Red" />
                    </asp:ButtonColumn>
                    <asp:BoundColumn DataField="Item Code" HeaderText="Record ID"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PlanCode" HeaderText="Plan Code"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Description" HeaderText="Item Description"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Ranking" HeaderText="Rank"></asp:BoundColumn>
                    <asp:BoundColumn DataField="QuantityRemaining" HeaderText="Rem Qty"></asp:BoundColumn>
                    <asp:BoundColumn DataField="NumberOfItems" HeaderText="Current Qty"></asp:BoundColumn>
                    <asp:BoundColumn DataField="UnitCost" HeaderText="Unit Cost" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                     <asp:BoundColumn DataField="MarketPrice" HeaderText="Market Price" DataFormatString="{0:N0}">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                      <ItemStyle Width="120px" HorizontalAlign="Left" />
                                                </asp:BoundColumn>
                    <asp:BoundColumn DataField="TotalCost" HeaderText="Total Cost" DataFormatString="{0:N0}">
                        <ItemStyle HorizontalAlign="Right" />
                        <HeaderStyle HorizontalAlign="Right" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="UnitCode" HeaderText="UnitCode" Visible="False"></asp:BoundColumn>
                   
                    <asp:TemplateColumn HeaderText="New Qty">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQtyRequired" runat="server" EnableViewState="true" Text='<%# DataBinder.Eval(Container, "DataItem.NumberOfItems") %>'
                                Width="50px">
		                                </asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Edit">
                        <ItemTemplate>
                            <asp:CheckBox ID="chbAdd" runat="server" Checked="false"
                                            Width="40px" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateColumn>
                </Columns>
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            </asp:DataGrid></td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
                <asp:Label ID="lblTotal" runat="server" Text="Label" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; height: 28px; text-align: center">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
                &nbsp;<asp:Button ID="Button1" runat="server" Text="Submit" Font-Bold="False" OnClick="Button1_Click" />
                <asp:Button ID="btnAddNewItems" runat="server" OnClick="btnAddNewItems_Click" Text="Add New Items" />
                <asp:Button ID="Button2" runat="server" Text="Add/Edit Attachments" OnClick="Button2_Click" />
                <asp:Button ID="btnCancel2" runat="server" Text="Cancel" OnClick="btnCancel2_Click" /></td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtDateRequired">
                </ajaxToolkit:CalendarExtender>
                <asp:Label ID="lblRecordCode" runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblItemID" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblInitail" runat="server" Text="." Visible="False"></asp:Label>
                <asp:Label ID="lblDesc" runat="server" Text="." Visible="False"></asp:Label>
                <asp:Label ID="lblYear" runat="server" Text="." Visible="False"></asp:Label>
                <asp:Label ID="lblPlanCode" runat="server" Text="0" Visible="False"></asp:Label>
                </td>
        </tr>
    </table>
        </asp:View>
            <asp:View ID="View2" runat="server">
            <table id="Table2" onclick="return TABLE1_onclick()" style="width: 100%">
                <tr>
                    <td style="width: 100%; height: 21px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:Label ID="lblQn" runat="server" Font-Bold="True" ForeColor="Maroon" Text="." Font-Names="Verdana" Font-Size="Small"></asp:Label><br />
                        <br />
                        <asp:Button
                            ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Return" Width="159px" /></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right; height: 21px;">
                    </td>
                </tr>
            </table>
        </asp:View>
            <asp:View ID="View3" runat="server">
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        ADDING OTHER ITEM(S) TO REQUISITION
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <label>SEARCh (DESCRIPTION)</label>
                        <asp:TextBox ID="txtDesc" runat="server" cssclass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-4 mb-3 mb-sm-0">
                        <label>.</label>
                        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" class="btn btn-primary btn-user btn-block float-right"
                                        Text="Search" />
                    </div>
                </div>
            <table style="width: 100%">
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 30px; text-align: center">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 50%">
                            <tr>
                                <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                                    text-align: center">
                                    SEARCh (DESCRIPTION)</td>
                                <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                                    text-align: center">
                                </td>
                            </tr>
                            <tr>
                                <td class="ddcolortabsline2" colspan="2" style="vertical-align: middle; text-align: center">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                                    </td>
                                <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                        &nbsp;ITEM(S)</td>
                </tr>
                <tr>
                    <td style="width: 100px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%">
                        <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                            ForeColor="#333333" GridLines="None" Width="100%" HorizontalAlign="Left">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditItemStyle BackColor="#999999" />
                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                            <Columns>
                                <asp:BoundColumn DataField="PlanCode" HeaderText="Code"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CostCenter" HeaderText="Cost Center">
                                    <ItemStyle Width="200px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Description" HeaderText="Description">
                                    <ItemStyle Width="450px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Quantity" HeaderText="Init. Qty"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CurrentQuantity" HeaderText="Current Qty">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="UnitCost" HeaderText="UnitCost" DataFormatString="{0:N0}">
                                    <ItemStyle Width="120px" HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="TotalCost" HeaderText="TotalCost" DataFormatString="{0:N0}">
                                    <ItemStyle Width="120px" HorizontalAlign="Right" />
                                    <HeaderStyle HorizontalAlign="Right" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="UnitCodeID" HeaderText="UnitCodeID" Visible="False"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="QtyRequired">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQtyRequired" runat="server" EnableViewState="true" Text='<%# DataBinder.Eval(Container, "DataItem.CurrentQuantity") %>'
                                            Width="50px">
		                                </asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Add">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chbAdd" runat="server" Checked="false"
                                            Width="40px" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateColumn>
                            </Columns>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        </asp:DataGrid></td>
                </tr>
            </table>
            <asp:Button ID="btnAddItems" runat="server" Text="Add Items" OnClick="btnAddItems_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></asp:View>
            <asp:View id="View4" runat="server">
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
                                                <br  />
                                                <p id="upload-area">
                                                    <input id="FileField" runat="server" size="60" type="file"  />
                                                </p>
                                                <p>
                                                    <input id="ButtonAdd" onclick="addFileUploadBox()" type="button" value="Add a file"  />
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
                                        GridLines="None" HorizontalAlign="Center" OnRowCommand="GridAttachments_RowCommand" PageSize="15" Width="98%">
                                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom"  />
                                        <RowStyle CssClass="gridRowStyle"  />
                                        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center"  />
                                        <Columns>
                                            <asp:ButtonField CommandName="ViewDetails" Text="View">
                                                <HeaderStyle CssClass="gridEditField"  />
                                                <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                    Width="140px"  />
                                            </asp:ButtonField>
                                            <asp:ButtonField CommandName="btnRemove" Text="Remove">
                                                <ItemStyle CssClass="gridEditField" ForeColor="#003399"  />
                                            </asp:ButtonField>
                                        </Columns>
                                        <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left"  />
                                        <AlternatingRowStyle CssClass="gridAlternatingRowStyle"  />
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
                        <asp:Label ID="lblPD_Code" runat="server" Text="0" Visible="False"></asp:Label><asp:Button
                            ID="btnSaveFile" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                            OnClick="btnSaveFile_Click" Text="SAVE " Width="80px"  />
                        <asp:Button
                            ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                            OnClick="btnReturn_Click" Text="RETURN" Width="80px"  /></td>
                </tr>
            </table>
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

    <asp:Label ID="lblTypeID" runat="server" Text="0" Visible="False"></asp:Label>
</asp:Content>

