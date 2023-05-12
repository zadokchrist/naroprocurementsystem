<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_NewRequisition.aspx.cs" Inherits="Requisition_NewRequisition" Title="NEW REQUISITION" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                    CREATE A REQUISITION
                </div>
            </div>
        </div>

        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
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
                    <div class="col-sm-1 mb-3 mb-sm-0">
                        Date Required</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtDateRequired" runat="server" CssClass="form-control" ></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Subject of Procurement
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"
                            TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-sm-1 mb-3 mb-sm-0">
                        <asp:Label runat="server" ID="txtDelivery" Text=" Location of Delivery"></asp:Label>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboLocation" runat="server" CssClass="form-control" OnDataBound="cboLocation_DataBound">
                        </asp:DropDownList>
                        <asp:Label ID="lblLoc" runat="server" Text="." Visible="False" Width="4px"></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Submit Requisition To
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboAreaManagers" runat="server" OnDataBound="cboAreaManagers_DataBound" CssClass="form-control">
                                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-1 mb-3 mb-sm-0">
                        <asp:Label runat="server" ID="txtWarehouse" Text="WareHouse"></asp:Label>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboWareHouses" runat="server" CssClass="form-control" OnDataBound="cboWareHouses_DataBound">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Tick if applicable
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:CheckBox ID="chkIsFramework" runat="server" AutoPostBack="True" Font-Bold="True"
                            Font-Italic="True" Text="Is FrameWork"
                            OnCheckedChanged="chkIsFramework_CheckedChanged" />
                        <asp:CheckBox ID="chkIsProject" runat="server" AutoPostBack="True" Font-Bold="True"
                            Font-Italic="True" Text="Is Project " Visible="false"
                            OnCheckedChanged="chkIsProject_CheckedChanged" />
                    </div>
                    <div class="col-sm-1 mb-3 mb-sm-0">
                        
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-5 mb-3 mb-sm-0">
                        <asp:Label ID="lblFinYearStartDate" runat="server" Text="0" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-5 mb-3 mb-sm-0"></div>
                    <div class="col-sm-1 mb-3 mb-sm-0">ITEM DETAILS</div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Item Name/Description
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"
                            TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Quantity Balance
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Label ID="lblQuantity" runat="server" Text="0" Font-Bold="True" ForeColor="Maroon"></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Unit Cost
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Label ID="lblAmount" runat="server" Text="0" Font-Bold="True" ForeColor="Maroon" Visible="False"></asp:Label>
                        <asp:Label ID="lblUnitCost" runat="server" Font-Bold="True" ForeColor="Maroon" Text="0"></asp:Label>
                        <asp:Label ID="lblUnitCode" runat="server" Font-Bold="True" ForeColor="Maroon" Text="0" Visible="False"></asp:Label>
                    </div>
                    <div class="col-sm-1 mb-3 mb-sm-0">
                       Current Market price:
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtMarketprice" runat="server" Font-Bold="True" ReadOnly="false" CssClass="form-control"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FTEtxtMarketprice" runat="server" TargetControlID="txtMarketprice" FilterType="Custom, Numbers" ValidChars=","></ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                       Quantity Required
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtRequired" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtRequired_TextChanged"></asp:TextBox>
                        <asp:Label ID="lblWarning" runat="server" ForeColor="Red" Text="." Visible="False"></asp:Label>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                FilterType="Custom,Numbers" TargetControlID="txtRequired" ValidChars=","></ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                    <div class="col-sm-1 mb-3 mb-sm-0">
                      Total Cost Required
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-5 mb-3 mb-sm-0"></div>
                    <div class="col-sm-1 mb-3 mb-sm-0">
                        <asp:Label ID="lblRecordCode" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblItemID" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblInitail" runat="server" Text="." Visible="False"></asp:Label>
                        <asp:Label ID="lblDesc" runat="server" Text="." Visible="False"></asp:Label>
                        <asp:Label ID="lblYear" runat="server" Text="." Visible="False"></asp:Label>
                        <asp:Label ID="lblPlanCode" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="lblInitQty" runat="server" Text="0" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Button ID="Button1" runat="server" Text="Submit" Font-Bold="True" class="btn btn-primary btn-user btn-block float-right"
                    OnClick="Button1_Click" />
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Button ID="btnCancel" runat="server" Font-Bold="True" OnClick="btnCancel_Click" class="btn btn-primary btn-user btn-block float-right"
                    Text="Cancel" />
                    </div>
                </div>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                        Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtDateRequired"></ajaxToolkit:CalendarExtender>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table id="Table2" onclick="return TABLE1_onclick()" style="width: 100%">
                    <tr>
                        <td style="width: 100%; height: 21px; text-align: right"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:Label ID="lblQn" runat="server" Font-Bold="True" ForeColor="Maroon" Text="."></asp:Label><asp:Button
                                ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" /><asp:Button ID="btnNo"
                                    runat="server" OnClick="btnNo_Click" Text="No" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: right; height: 21px;"></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <table style="width: 100%">
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 30px; text-align: center">ADDING OTHER ITEM(S) TO REQUISITION</td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 30px; text-align: center">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 50%">
                                <tr>
                                    <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px; text-align: center">SEARCh (DESCRIPTION)</td>
                                    <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px; text-align: center"></td>
                                </tr>
                                <tr>
                                    <td class="ddcolortabsline2" colspan="2" style="vertical-align: middle; text-align: center">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                                        <asp:TextBox ID="txtDesc" runat="server" Width="98%"></asp:TextBox></td>
                                    <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                                        <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Height="23px" OnClick="btnOK_Click"
                                            Text="Search" Width="85px" />&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">&nbsp;ITEM(S)</td>
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
                                    <asp:BoundColumn DataField="CurrentQuantity" HeaderText="Current Qty"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="UnitCost" HeaderText="UnitCost" DataFormatString="{0:N0}">
                                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="TotalCost" HeaderText="TotalCost" DataFormatString="{0:N0}">
                                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="MarketPrice" HeaderText="Market Price" DataFormatString="{0:N0}">
                                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="UnitCodeID" HeaderText="UnitCode" Visible="False"></asp:BoundColumn>
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
                <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="Cancel" />
            </asp:View>
            <asp:View ID="View4" runat="server">
                <table id="Table1" onclick="return TABLE1_onclick()" style="width: 100%">
                    <tr>
                        <td style="width: 100%; height: 21px; text-align: right"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" ForeColor="Maroon" Text="." Font-Names="Verdana" Font-Size="Small"></asp:Label><br />
                            <br />
                            <asp:Button ID="btnReturnToReqItems"
                                runat="server" OnClick="btnReturnToReqItems_Click" Text="Return" Width="89px" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: right; height: 21px;"></td>
                    </tr>
                </table>
            </asp:View>
            <asp:View ID="View5" runat="server">
                <table style="width: 95%" align="center">
                    <tr>
                        <td colspan="3" style="vertical-align: top; height: 2px; text-align: center">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 63%">
                                <tr>
                                    <td class="InterfaceHeaderLabel" style="height: 20px">CONFIRM NEW REQUISITION DETAILS</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="vertical-align: top; height: 2px; text-align: center"></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; width: 49%; text-align: center; height: 146px;">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td class="InterFaceTableLeftRow" style="height: 29px">Select Requisition Type</td>
                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px"></td>
                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                        <asp:DropDownList ID="cboReqType1" runat="server" CssClass="InterfaceDropdownList"
                                            Width="81%" OnDataBound="cboReqType1_DataBound">
                                            <asp:ListItem Value="0">- Select Requisition Type -</asp:ListItem>
                                            <asp:ListItem Value="1">Normal Requisition</asp:ListItem>
                                            <asp:ListItem Value="2">Emergency Requisition</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRow" style="height: 29px">Subject of Procurement</td>
                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px"></td>
                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                        <asp:TextBox ID="txtSubject1" runat="server" CssClass="InterfaceTextboxMultiline" Style="width: 80%; height: 55px"
                                            TextMode="MultiLine" Width="85%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRow" style="height: 29px">Submit Requisition To</td>
                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px"></td>
                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                        <asp:DropDownList ID="cboAreaManagers1" runat="server" OnDataBound="cboAreaManagers1_DataBound"
                                            Width="81%">
                                        </asp:DropDownList></td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 2%; height: 146px;"></td>
                        <td style="vertical-align: top; width: 49%; text-align: center; height: 146px;">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td class="InterFaceTableLeftRow" style="height: 29px">Date Required</td>
                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px"></td>
                                    <td class="InterFaceTableRightRow" style="width: 65%; height: 29px">
                                        <asp:TextBox ID="txtDateRequired1" runat="server" CssClass="InterfaceTextboxLongReadOnly"
                                            Width="78%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                        <asp:Label runat="server" ID="lblDelivery2" Text="Location of Delivery"></asp:Label>
                                    </td>
                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px"></td>
                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                        <asp:DropDownList ID="cboLocations1" runat="server" CssClass="InterfaceDropdownList"
                                            Width="80%" OnDataBound="cboLocations1_DataBound">
                                        </asp:DropDownList>
                                        <asp:Label ID="Label1" runat="server" Text="." Visible="False" Width="4px"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                        <asp:Label runat="server" ID="lblWarehouse" Text="WareHouse"></asp:Label>
                                    </td>
                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px"></td>
                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                        <asp:DropDownList ID="cboWareHouses1" runat="server" CssClass="InterfaceDropdownList"
                                            Width="80%" OnDataBound="cboWareHouses1_DataBound">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRow" style="width: 191px">Tick if applicable</td>
                                    <td class="InterFaceTableMiddleRow" style="width: 2%"></td>
                                    <td class="InterFaceTableRightRow" style="width: 64%">
                                        <asp:CheckBox ID="chkIsFramework1" runat="server" AutoPostBack="True" Font-Bold="True"
                                            Font-Italic="True" Text="Is FrameWork"
                                            OnCheckedChanged="chkIsFramework1_CheckedChanged" />
                                        <asp:CheckBox ID="chkIsProject1" runat="server" AutoPostBack="True" Font-Bold="True"
                                            Font-Italic="True" Text="Is Project "
                                            OnCheckedChanged="chkIsProject1_CheckedChanged" Visible="false" />

                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table align="center" cellpadding="0" cellspacing="0" style="border-right: #a4a2ca 1px solid; border-top: #a4a2ca 1px solid; border-left: #a4a2ca 1px solid; width: 90%; border-bottom: #a4a2ca 1px solid; background-color: #ffffff">
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
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="vertical-align: top; text-align: center; height: 25px;">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 63%">
                                <tr>
                                    <td class="InterfaceHeaderLabel" style="height: 20px">ITEM DETAILS</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="vertical-align: top; text-align: center">
                            <asp:DataGrid ID="dgFinalItems" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                                ForeColor="#333333" GridLines="None" Width="100%" HorizontalAlign="Left">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#999999" />
                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                <Columns>
                                    <asp:BoundColumn DataField="PlanCode" HeaderText="Plan Code"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Description" HeaderText="Item Description">
                                        <ItemStyle Width="450px" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="InitialQty" HeaderText="Init. Qty"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="CurrentQty" HeaderText="Current Qty"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="UnitCode" HeaderText="UnitCode" Visible="False"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="UnitCost" HeaderText="Planned Unit Cost" DataFormatString="{0:N0}">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="TotalCost" HeaderText="Total Cost as per Market Price" DataFormatString="{0:N0}">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="RequiredQty" HeaderText="Required Qty"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="MarketPrice" HeaderText="Unit Current Market Price" DataFormatString="{0:N0}">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle Width="120px" HorizontalAlign="Left" />
                                    </asp:BoundColumn>


                                </Columns>
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            </asp:DataGrid><br />
                            <asp:Label ID="lblTotal" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="vertical-align: top; text-align: center">&nbsp;&nbsp;<br />
                            <asp:Button ID="btnSaveRequisition" runat="server" Text="Submit" Font-Bold="True" OnClick="btnSaveRequisition_Click" />
                            <asp:Button ID="Button4" runat="server" Font-Bold="True" OnClick="btnCancel_Click"
                                Text="Cancel" /></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="vertical-align: top; text-align: center">
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtDateRequired"></ajaxToolkit:CalendarExtender>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
        <asp:MultiView ID="MultiView2" runat="server">
            <asp:View ID="View6" runat="server">

                <table cellspacing="5" width="100%">
                    <tr>
                        <td class="InterFaceTableLeftRow" style="width: 100%; text-align: center">
                        Project Details
                           
                    </tr>
                    <tr>
                        <td style="width: 100%"></td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:Label ID="lblItemError" runat="server" Text="." Font-Bold="False" Font-Names="Cambria" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 50%; text-align: center"
                            width="50%">Enter Total Cost for This Financial Year <%  Response.Write(Session["RFinancialYear"].ToString()); %> </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtFinCurrentFinYearCost" runat="server" Style="width: 50%; text-align: center"
                                Width="50%"></asp:TextBox></td>
                    </tr>

                    <tr>
                        <td style="width: 100%">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td class="InterfaceHeaderLabel" style="height: 20px">ADD PROJECT DETAILS</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 48%; height: 154px;" valign="top">
                                        <table style="width: 100%" align="center" cellpadding="0" cellspacing="0">
                                            <tr style="color: #000000;">
                                                <td class="InterFaceTableLeftRow">Project  Item</td>
                                                <td class="InterFaceTableMiddleRow" style="height: 29px; width: 2%;"></td>
                                                <td style="width: 66%; height: 29px" class="InterFaceTableRightRow">
                                                    <asp:TextBox CssClass="InterfaceTextboxMultiline" ID="txtProjectDescription" runat="server" TextMode="MultiLine" Width="80%"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td class="InterFaceTableLeftRow" style="width: 149px">Cost For Project Item</td>
                                                <td class="InterFaceTableMiddleRow"></td>
                                                <td class="InterFaceTableRightRow">
                                                    <asp:TextBox ID="txtProjectMarketPx" runat="server" Font-Bold="True" ReadOnly="false"
                                                        Font-Size="10pt" ForeColor="Firebrick"
                                                        Width="80%"></asp:TextBox>


                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 29px" class="InterFaceTableLeftRow">Enter Financial Year</td>
                                                <td style="width: 2%; height: 29px" class="InterFaceTableMiddleRow" />
                                                <td style="width: 66%; height: 29px" class="InterFaceTableRightRow">
                                                    <asp:TextBox ID="txtFinYear" runat="server" CssClass="InterfaceTextboxLongReadOnly"
                                                        Width="80%" OnTextChanged="txtUnitCostCurrentFinYear_TextChanged"></asp:TextBox></td>
                                            </tr>

                                            <tr>
                                                <!--   <td style="height: 29px" class="InterFaceTableLeftRow" >
                                                        <asp:Label ID="lblStockItem" runat="server" Text="Tick if appropriate" Visible="False"></asp:Label></td>
                                                    <td style="width: 2%; height: 29px" class="InterFaceTableMiddleRow" />
                                                  <td style="width: 66%; height: 29px" class="InterFaceTableRightRow" >
                                                        <asp:CheckBox ID="ChkFinYear" runat="server" CssClass="InterfaceDropdownList" Font-Bold="False"
                                                            Text="Is Current Financial Year" Visible="False" AutoPostBack="True"  /></td> -->
                                            </tr>

                                        </table>
                                    </td>
                                    <td style="width: 2%; height: 154px;"></td>
                                    <td style="width: 48%; height: 154px;" valign="top">
                                        <table style="width: 100%" align="center" cellpadding="0" cellspacing="0">
                                        </table>
                                        <asp:Label ID="Label4" runat="server" Text="0" Visible="False"></asp:Label></td>
                                </tr>
                            </table>

                            <br />
                            &nbsp;<asp:Button ID="btnAddProjectItem" runat="server" Text="Add Item" OnClick="btnAddProjectItem_Click" /></td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr>
                                    <td class="InterfaceHeaderLabel" style="height: 20px">CURRENT ITEM DETAILS</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                                ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid2_ItemCommand" Width="100%" HorizontalAlign="Center">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#999999" />
                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                <Columns>

                                    <asp:BoundColumn DataField="finYear" HeaderText="Financial Year"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="ItemDesc" HeaderText="Item Description"></asp:BoundColumn>



                                    <asp:BoundColumn DataField="TotalCost" HeaderText="Cost for Financial Year" DataFormatString="{0:N0}">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>

                                    <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove"></asp:ButtonColumn>
                                </Columns>
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            </asp:DataGrid><asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="vertical-align: top; text-align: center">
                            <asp:Button ID="btnProjectSubmit" runat="server" Text="Submit" Font-Bold="True" OnClick="btnProjectSubmit_Click" />
                            <asp:Button ID="btnCancelProject" runat="server" Text="Cancel" Font-Bold="True" /></td>
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

