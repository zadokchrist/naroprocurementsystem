<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_NewGroupRequisition.aspx.cs" Inherits="Requisition_NewGroupRequisition" Title="New Group Requisition" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                ADD A REQUISITION :
                            <asp:Label ID="lblGroupRequisition" runat="server"></asp:Label>
            </div>
            </div>
        </div>
        
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-2 mb-3 mb-sm-0"> Procurement Type</div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                 <asp:DropDownList ID="cboProcType" runat="server" CssClass="form-control" OnDataBound="cboProcType_DataBound" AutoPostBack="True" OnSelectedIndexChanged="cboProcType_SelectedIndexChanged">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0"> Date Required</div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:TextBox ID="txtDateRequired" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0">Requisition Type</div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:DropDownList ID="CboRequisition" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0">- Select Requisition Type -</asp:ListItem>
                                <asp:ListItem Value="1">Normal Requisition</asp:ListItem>
                                <asp:ListItem Value="2">Emergency Requisition</asp:ListItem>
                            </asp:DropDownList>
                </div>
                <div class="col-sm-2 mb-3 mb-sm-0"> Submit Requisition To</div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:DropDownList ID="cboAreaManagers" runat="server" OnDataBound="cboAreaManagers_DataBound" CssClass="form-control" Enabled="false">
                            </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0">Subject of Procurement</div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="col-sm-2 mb-3 mb-sm-0"> Plan -
                            Initial Total Cost</div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:Label ID="lblPlanAmount" runat="server" Text="lblPlanAmount"></asp:Label>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0">Tick if applicable</div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:CheckBox ID="chkIsFramework" runat="server" AutoPostBack="True" Font-Bold="True"
                                        Font-Italic="True" Text="Is FrameWork" 
                            oncheckedchanged="chkIsFramework_CheckedChanged" />
                    <asp:CheckBox ID="chkIsProject" runat="server" AutoPostBack="True" Font-Bold="True"
                                        Font-Italic="True" Text="Is Project " 
                            oncheckedchanged="chkIsProject_CheckedChanged" />
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0"><asp:Label runat="server" ID="lblDelivery" Text="Location of Delivery"></asp:Label></div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:DropDownList ID="cboLocation" runat="server" CssClass="form-control" OnDataBound="cboLocation_DataBound">
                            </asp:DropDownList>
                            <asp:Label ID="lblLoc" runat="server" Text="." Visible="False" Width="4px"></asp:Label>
                </div>
                <div class="col-sm-2 mb-3 mb-sm-0">
                    <asp:Label runat="server" ID="lblWarehouse" Text=" Ware House"></asp:Label>
                </div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:DropDownList ID="cboWareHouses" runat="server" CssClass="form-control" OnDataBound="cboWareHouses_DataBound" Width="81%">
                            </asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-5 mb-3 mb-sm-0"></div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                     ADD ITEM DETAILS
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0"> Item Name/Description</div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:TextBox CssClass="form-control" ID="txtDescription" runat="server" TextMode="MultiLine" ></asp:TextBox>
                </div>
                <div class="col-sm-2 mb-3 mb-sm-0"> <asp:Label ID="lblContractOrMarket" runat="server" Text="Current Market Price" Visible="True"></asp:Label></div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:TextBox ID="txtMarketprice" runat="server" Font-Bold="True" ReadOnly ="false" CssClass="form-control"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTEtxtMarketprice" runat="server" TargetControlID="txtMarketprice" FilterType="Custom, Numbers" ValidChars=",">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0"> 
                    Quantity Required
                </div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:TextBox AutoPostBack="True" CssClass="form-control" ID="txtRequired" OnTextChanged="txtRequired_TextChanged" runat="server"></asp:TextBox>
                    <asp:Label Text="." ForeColor="Red" ID="lblWarning" runat="server" Visible="False"></asp:Label>
                </div>
                <div class="col-sm-2 mb-3 mb-sm-0">
                    Units
                </div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:DropDownList ID="cboUnits" runat="server" CssClass="form-control" OnDataBound="cboUnits_DataBound"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0">
                     Unit Cost
                </div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:TextBox ID="txtUnitCost1" runat="server" AutoPostBack="True" CssClass="form-control" OnTextChanged="txtUnitCost1_TextChanged"></asp:TextBox>
                </div>
                <div class="col-sm-2 mb-3 mb-sm-0">
                    Total Cost
                </div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:TextBox ID="txtTotalCost" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0"></div>
                <div class="col-sm-7 mb-3 mb-sm-0">
                    Current Requisition
                            Amount Balance:
                            <asp:Label ID="lblAmount" runat="server" Text="0" Font-Bold="True" ForeColor="Maroon" OnDataBinding="lblAmount_DataBinding"></asp:Label>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0">
                     <asp:Label ID="lblStockItem" runat="server" Text="Tick if appropriate" Visible="False"></asp:Label>
                </div>
                <div class="col-sm-2 mb-3 mb-sm-0"></div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:CheckBox ID="ChkStockItem" runat="server" CssClass="InterfaceDropdownList" Font-Bold="False"
                                                            Text="Is Stock Item" Visible="False" AutoPostBack="True" OnCheckedChanged="ChkStockItem_CheckedChanged" />
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0">
                    <asp:Label ID="lblStockName" runat="server" Text="Stock Code" Visible="False"></asp:Label>
                </div>
                <div class="col-sm-2 mb-3 mb-sm-0"></div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:TextBox AutoPostBack="True" CssClass="form-control" autocomplete="off" Font-Bold="True"
                                                    ForeColor="Firebrick" ID="txtStockName" runat="server" Visible="False" Enabled="False"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0">
                    <asp:Label ID="lblContractAmount2" runat="server" Text="Contract Amount" Visible="False"></asp:Label>
                </div>
                <div class="col-sm-2 mb-3 mb-sm-0"></div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:TextBox  CssClass="InterfaceTextboxLongReadOnly" autocomplete="off" Font-Bold="True"
                                                    ForeColor="Firebrick" ID="txtContractAmount" runat="server" Visible="False" Width="80%" Enabled="False"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0"></div>
                <div class="col-sm-5 mb-3 mb-sm-0">
                    <asp:Label ID="lblFinYearStartDate" runat="server" Text="0" Visible="False"></asp:Label>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0">
                </div>
                <div class="col-sm-5 mb-3 mb-sm-0"></div>
            </div>
            
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0"></div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <ajaxToolkit:AutoCompleteExtender ID="ACEStockName" MinimumPrefixLength="1" runat="server" UseContextKey="true" ContextKey="CompanyCode"
                                     ServiceMethod="GetStockItemsByCode" ServicePath="CascadingddlService.asmx" TargetControlID="txtStockName" />
                                    <br />
                                    &nbsp;<asp:Button ID="btnAddItem" runat="server" OnClick="btnAddItem_Click" Text="Add Item" />
                </div>
            </div>

            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0"></div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    CURRENT ITEM DETAILS
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-12 mb-3 mb-sm-0">
                    <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                        ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid2_ItemCommand" HorizontalAlign="Center">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditItemStyle BackColor="#999999" />
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundColumn DataField="ItemDesc" HeaderText="Item Description"></asp:BoundColumn>
                            <asp:BoundColumn DataField="StockName" HeaderText="Stock Name"></asp:BoundColumn>
                            <asp:BoundColumn DataField="StockBalance" HeaderText="Stock Balance"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Quantity" HeaderText="Qty"></asp:BoundColumn>
                            <asp:BoundColumn DataField="UnitCode" HeaderText="UnitCode"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Units" HeaderText="Unit"></asp:BoundColumn>
                                <asp:BoundColumn DataField="UnitCost" HeaderText="Unit Cost" DataFormatString="{0:N0}">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                          
                            <asp:BoundColumn DataField="TotalCost" HeaderText="Total Cost" DataFormatString="{0:N0}">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundColumn>
                                <asp:BoundColumn DataField="MarketPrice" HeaderText="Market Price" DataFormatString="{0:N0}">
                            <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="120px" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                            <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove"></asp:ButtonColumn>
                        </Columns>
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    </asp:DataGrid>
                    <asp:Label ID="lblTotal" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"></asp:Label><ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                    FilterType="Custom,Numbers" TargetControlID="txtRequired" ValidChars=",.">
                </ajaxToolkit:FilteredTextBoxExtender>
                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                    FilterType="Custom,Numbers" TargetControlID="txtUnitCost1" ValidChars=",.">
                </ajaxToolkit:FilteredTextBoxExtender>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0"></div>
                <div class="col-sm-7 mb-3 mb-sm-0">
                    <table align="center" cellpadding="0" cellspacing="10" style="border-right: #a4a2ca 1px solid; border-top: #a4a2ca 1px solid; border-left: #a4a2ca 1px solid; width: 90%; border-bottom: #a4a2ca 1px solid; background-color: #ffffff">
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblUploadType" Text="."></asp:Label>
                            </td>
                        </tr>
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
                </div>
            </div>
            <table style="width: 95%" align="center">
        <tr>
            <td style="vertical-align: top; width: 49%; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                    
                    
                    
                </table>
            </td>
            <td style="width: 2%">
            </td>
            <td style="vertical-align: top; width: 49%; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td colspan="3" style="height: 16px">
                        </td>
                    </tr>
                </table>
                            
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: center; height: 22px;">
            </td>
            <td style="vertical-align: top; height: 22px; text-align: center">
            </td>
            <td style="vertical-align: top; height: 22px; text-align: center">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
                
                    
                        <table cellspacing="5" width="100%">
                            <tr>
                                <td class="InterFaceTableLeftRow" style="width: 100%; text-align: center">
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 100%">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%; text-align: center">
                            <asp:Label ID="lblItemError" runat="server" Text="." Font-Bold="False" Font-Names="Cambria" ForeColor="Red"></asp:Label></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
                </td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
                <asp:Button ID="Button1" runat="server" Text="Submit" Font-Bold="True" OnClick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" Text="Cancel" Font-Bold="True" OnClick="Button2_Click" /></td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
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
            <table id="Table2" onclick="return TABLE1_onclick()" style="width: 100%">
                <tr>
                    <td style="width: 100%; height: 21px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:Label ID="lblQn" runat="server" Font-Bold="True" ForeColor="Maroon" Text="."></asp:Label><asp:Button
                            ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" /><asp:Button ID="btnNo"
                                runat="server" OnClick="btnNo_Click" Text="No" /></td>
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

    <asp:Label ID="lblTypeID" runat="server" Text="0"></asp:Label>
    </div>
    
</asp:Content>

