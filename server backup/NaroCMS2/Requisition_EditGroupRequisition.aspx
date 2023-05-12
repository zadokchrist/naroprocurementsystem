<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Requisition_EditGroupRequisition.aspx.cs" Inherits="Requisition_NewGroupRequisition" Title="Edit Group Requisition" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td style="vertical-align: middle; text-align: center">
                
                
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                    <tr>
                        <td class="InterfaceHeaderLabel" style="height: 20px">
                            EDIT A REQUISITION :
                            <asp:Label ID="lblGroupRequisition" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="ddcolortabsline2" style="height: 12px">
                &nbsp;</td>
        </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
    <table style="width: 95%" align="center">
        <tr>
            <td colspan="3" style="vertical-align: top; height: 2px; text-align: center">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; height: 25px; text-align: center">
                <span style="font-size: 13pt; font-family: Cambria">SERIAL: --&gt;&gt; ( </span>
                <asp:Label ID="lblEntity" runat="server" Font-Names="cambria" Font-Size="13pt" ForeColor="Red"></asp:Label>
                <span style="font-size: 13pt; font-family: Cambria">)</span></td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 49%; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="InterFaceTableLeftRow" style="height: 29px">
                            Select Requisition Type</td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                            <asp:DropDownList ID="CboRequisition" runat="server" CssClass="InterfaceDropdownList"
                                Width="81%">
                                <asp:ListItem Value="0">- Select Requisition Type -</asp:ListItem>
                                <asp:ListItem Value="1">Normal Requisition</asp:ListItem>
                                <asp:ListItem Value="2">Emergency Requisition</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRow" style="height: 29px">
                                    Subject of Procurement</td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                    <asp:TextBox ID="txtSubject" runat="server" CssClass="InterfaceTextboxMultiline" Style="width: 80%;
                                        height: 55px" TextMode="MultiLine" Width="90%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRow" style="height: 29px">
                            Location of Delivery</td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                            <asp:DropDownList ID="cboLocation" runat="server" CssClass="InterfaceDropdownList"
                                Width="81%" OnDataBound="cboLocation_DataBound">
                            </asp:DropDownList>
                            <asp:Label ID="lblLoc" runat="server" Text="." Visible="False" Width="4px"></asp:Label></td>
                    </tr>
                      <tr>
                    <td class="InterFaceTableLeftRow" style="width: 191px">
                                    Tick if applicable</td>
                                <td class="InterFaceTableMiddleRow" style="width: 2%">
                                </td>
                    <td class="InterFaceTableRightRow" style="width: 64%">
                     <asp:CheckBox ID="chkIsFramework" runat="server" AutoPostBack="True" Font-Bold="True"
                                        Font-Italic="True" Text="Is FrameWork" 
                            oncheckedchanged="chkIsFramework_CheckedChanged" />
                    <asp:CheckBox ID="chkIsProject" runat="server" AutoPostBack="True" Font-Bold="True"
                                        Font-Italic="True" Text="Is Project " 
                            oncheckedchanged="chkIsProject_CheckedChanged" />
                    </td>
                    </tr>
                </table>
            </td>
            <td style="width: 2%">
            </td>
            <td style="vertical-align: top; width: 49%; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="InterFaceTableLeftRow" style="height: 29px">
                            Date Required</td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                            <asp:TextBox ID="txtDateRequired" runat="server" CssClass="InterfaceTextboxLongReadOnly" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRow" style="height: 29px">
                            Ware House</td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%; height: 29px"><asp:DropDownList ID="cboWareHouse" runat="server" CssClass="InterfaceDropdownList"
                                Width="82%" OnDataBound="cboWareHouse_DataBound">
                        </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRow" style="height: 29px">
                            Current Plan Balance</td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                <asp:Label ID="lblCurrentPlanAmount" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRow" style="height: 29px">
                            Current Requisition Cost</td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                            <asp:Label ID="lblPlanAmount" runat="server" Text="lblPlanAmount"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 16px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
               
                <table width="100%" cellspacing="5">
                    <tr>
                        <td>
                            <strong>Current Requisition
                            Amount Balance:</strong>
                            <asp:Label ID="lblAmount" runat="server" Text="0" Font-Bold="True" ForeColor="Maroon" OnDataBinding="lblAmount_DataBinding"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRow" style="height: 7px">
                            </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; text-align: center">
                            <asp:Label ID="lblItemError" runat="server" Text="." Font-Bold="False" Font-Names="Cambria" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                        <asp:MultiView ID="MultiView2" runat="server">
                            <asp:View ID="View21" runat="server">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 68%">
                                                    <tr>
                                                        <td class="InterfaceHeaderLabel" style="height: 20px">
                                                            CURRENT REQUISITION ITEMS</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px"></td>
                                        </tr>
                                        <tr>
                                                <td style="vertical-align: top">
                                                    <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                                                                ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid1_ItemCommand" Width="100%" HorizontalAlign="Center">
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <EditItemStyle BackColor="#999999" />
                                                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                                        <Columns>
                                                            <asp:BoundColumn DataField="RecordID" HeaderText="RecordID" Visible="False"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="ItemDesc" HeaderText="Item Description"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="StockName" HeaderText="Stock Name"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="StockBalance" HeaderText="Stock Balance"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="Quantity" HeaderText="Qty">
                                                            </asp:BoundColumn>
                                                            <asp:BoundColumn DataField="UnitCost" HeaderText="Unit Cost" DataFormatString="{0:N0}">
                                                                <ItemStyle HorizontalAlign="left" />
                                                                <HeaderStyle HorizontalAlign="left" />
                                                            </asp:BoundColumn>
                                                          
                                                            <asp:BoundColumn DataField="TotalCost" HeaderText="Total Cost" DataFormatString="{0:N0}">
                                                                <ItemStyle HorizontalAlign="left" />
                                                                <HeaderStyle HorizontalAlign="left" />
                                                            </asp:BoundColumn>
                                                              <asp:BoundColumn DataField="MarketPrice" HeaderText="Market Price" DataFormatString="{0:N0}">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                      <ItemStyle Width="120px" HorizontalAlign="Left" />
                                                </asp:BoundColumn>
                                                            <asp:ButtonColumn CommandName="btnEdit" HeaderText="Edit" Text="Edit"></asp:ButtonColumn>
                                                            <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove">
                                                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                                    Font-Underline="False" ForeColor="Red" />
                                                            </asp:ButtonColumn>
                                                        </Columns>
                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                    </asp:DataGrid>
                                                    <asp:Label ID="lblTotal" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"></asp:Label><br />
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                        FilterType="Custom,Numbers" TargetControlID="txtRequired" ValidChars=",">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                        FilterType="Custom,Numbers" TargetControlID="txtUnitCost1" ValidChars=",">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>
                                            </tr>
                                    </table>
                                
                            </asp:View>
                            <asp:View ID="View22" runat="server">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                        <tr>
                                            <td colspan="1" style="vertical-align: top; height: 9px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" style="vertical-align: top; height: 41px;">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                    <tr>
                                                        <td class="InterfaceHeaderLabel" style="height: 20px">
                                                            <asp:Label ID="lblAddEditItemHeader" runat="server" Text="ADD ITEM DETAILS"></asp:Label></td>
                                                    </tr>
                                                </table>
                                                <table width="100%">
                                                    <tr>
                                                        <td style="width: 48%; height: 154px" valign="top">
                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                <tr style="color: #000000">
                                                                    <td class="InterFaceTableLeftRow">
                                                                                    Item Name/Description</td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                                                                    </td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                        <asp:TextBox ID="txtDescription" runat="server" CssClass="InterfaceTextboxMultiline"
                                                                            TextMode="MultiLine" Width="80%"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                                                        <asp:Label ID="lblStockItem" runat="server" Text="Tick if appropriate" Visible="False"></asp:Label></td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                                                                    </td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                        <asp:CheckBox ID="ChkStockItem" runat="server" CssClass="InterfaceDropdownList" Font-Bold="False"
                                                                            Text="Is Stock Item" Visible="False" OnCheckedChanged="ChkStockItem_CheckedChanged" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                                                        <asp:Label ID="lblStockName" runat="server" Text="Stock Code" Visible="False"></asp:Label></td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                                                                    </td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                        <asp:TextBox AutoPostBack="True" CssClass="InterfaceTextboxLongReadOnly" autocomplete="off" Font-Bold="True"
                                                    ForeColor="Firebrick" ID="txtStockName" runat="server" Visible="False" Width="80%" Enabled="False"></asp:TextBox></td>
                                                                </tr>
                                                                 <tr>
                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                                                        <asp:Label ID="lblContractAmount" runat="server" Text="Contract Amount" Visible="False"></asp:Label></td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                                                                    </td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                        <asp:TextBox AutoPostBack="True" CssClass="InterfaceTextboxLongReadOnly" autocomplete="off" Font-Bold="True"
                                                    ForeColor="Firebrick" ID="txtContractAmount" runat="server" Visible="False" Width="80%" ></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="width: 2%; height: 154px">
                                                        </td>
                                                        <td style="width: 48%; height: 154px" valign="top">
                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                <tr style="color: #000000">
                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                                                            Quantity Required</td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                                                                    </td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                        <asp:TextBox ID="txtRequired" runat="server" AutoPostBack="True" CssClass="InterfaceTextboxLongReadOnly"
                                                                            OnTextChanged="txtRequired_TextChanged" Width="24%"></asp:TextBox>
                                                                        <asp:Label ID="lblOldQuantity" runat="server" Text="." Visible="False"></asp:Label>
                                                                        <asp:Label ID="lblWarning" runat="server" ForeColor="Red" Text="." Visible="False"
                                                                            Width="80%"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                                                        Units</td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                                                                    </td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                        <asp:DropDownList ID="cboUnits" runat="server" CssClass="InterfaceDropdownList" OnDataBound="cboUnits_DataBound"
                                                                            Width="82%">
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                                                            Unit Cost</td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                                                                    </td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                        <asp:TextBox ID="txtUnitCost1" runat="server" AutoPostBack="True" CssClass="InterfaceTextboxLongReadOnly"
                                                                            OnTextChanged="txtUnitCost1_TextChanged" Width="80%"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                                                            Total Cost</td>
                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                                                                    </td>
                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                        <asp:TextBox ID="txtTotalCost" runat="server" CssClass="InterfaceTextboxLongReadOnly"
                                                                            Enabled="False" Width="80%"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <ajaxToolkit:AutoCompleteExtender ID="ACEStockName" runat="server" ContextKey="CompanyCode"
                                                    MinimumPrefixLength="1" ServiceMethod="GetStockItemsByCode" ServicePath="CascadingddlService.asmx"
                                                    TargetControlID="txtStockName" UseContextKey="true">
                                                </ajaxToolkit:AutoCompleteExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" style="vertical-align: top">
                                                                <asp:Button ID="btnAddItem" runat="server" OnClick="btnAddItem_Click" Text="Add Item" />
                                                        <asp:Label ID="lblPrevTotalCost" runat="server" Text="0" Visible="False"></asp:Label>
                                                        <asp:Label ID="lblItemIndex" runat="server" Text="0" Visible="False"></asp:Label>
                                                        <asp:Label ID="lblRecordID" runat="server" Text="0" Visible="False"></asp:Label></td>
                                        </tr>

                                    </table>
                            </asp:View>
                        </asp:MultiView>
                        </td>
                    </tr>
                </table>                                     
                    
            </td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
                &nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
                <asp:Button ID="Button1" runat="server" Text="Submit" Font-Bold="True" OnClick="Button1_Click" />
                <asp:Button ID="btnCancel" runat="server" Font-Bold="True" OnClick="btnCancel_Click"
                    Text="Cancel" /></td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
                &nbsp;
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtDateRequired">
                </ajaxToolkit:CalendarExtender>
                <asp:Label ID="lblRecordCode" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblItemID" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblInitail" runat="server" Text="." Visible="False"></asp:Label>
                <asp:Label ID="lblDesc" runat="server" Text="." Visible="False"></asp:Label>
                <asp:Label ID="lblYear" runat="server" Text="." Visible="False"></asp:Label>
                <asp:Label ID="lblPlanCode" runat="server" Text="0" Visible="False"></asp:Label></td>
        </tr>
    </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table id="Table2" style="width: 100%">
                <tr>
                    <td style="width: 100%; height: 21px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" ForeColor="Maroon" Text="." Font-Names="Verdana" Font-Size="Small"></asp:Label><br />
                        <br />
                        <asp:Button ID="btnReturnItems" runat="server" Text="RETURN" OnClick="btnReturnItems_Click" /></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right; height: 21px;">
                    </td>
                </tr>
            </table>
        </asp:View>
        &nbsp;
    </asp:MultiView>
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

