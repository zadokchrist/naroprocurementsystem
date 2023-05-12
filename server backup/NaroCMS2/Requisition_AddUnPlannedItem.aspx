<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_AddUnPlannedItem.aspx.cs" Inherits="Planning_AddPlan" Title="NEW UN PLANNED ITEM" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                    <asp:Label ID="lblHeader" runat="server" Text="ADD NEW UN PLANNNED ITEM"></asp:Label>
                </div>
            </div>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View id="View1" runat="server">
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                         Select Procurement Type
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboProcType" runat="server" AutoPostBack="True" CssClass="form-control"
                                        OnDataBound="cboProcType_DataBound" OnSelectedIndexChanged="cboProcType_SelectedIndexChanged">
                                    </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                         <asp:Label ID="lblStockItem" runat="server" Text="Tick if appropriate" Visible="False"></asp:Label>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:CheckBox id="ChkStockItem" runat="server" Font-Bold="False" Text="Is Stock Item" CssClass="InterfaceDropdownList" Visible="False" AutoPostBack="True" OnCheckedChanged="ChkStockItem_CheckedChanged"></asp:CheckBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                         <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" Checked="True"
                                        GroupName="Budget" OnCheckedChanged="rdOperational_CheckedChanged" Text="Operational Item" Font-Bold="True" Width="151px"  />
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:RadioButton ID="rdCapital" runat="server" AutoPostBack="True" GroupName="Budget"
                                        OnCheckedChanged="rdCapital_CheckedChanged" Text="Capital Item" Font-Bold="True"  />
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
        <asp:MultiView ID="MultiView2" runat="server">
            <asp:View ID="View2" runat="server">
                <div class="form-group row">
                    <div class="col-sm-2 mb-3 mb-sm-0"></div>
                    <div class="col-sm-7 mb-3 mb-sm-0">
                        <asp:Label ID="lblBudgetName" runat="server" Font-Bold="True" ForeColor="#C00000" Text="."></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Item Category
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboItemCategory" runat="server" CssClass="form-control" OnDataBound="cboItemCategory_DataBound">
                                    </asp:DropDownList>
                    </div>
                    <div class="col-sm-1 mb-3 mb-sm-0">
                        Currency
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboCurrency" runat="server" OnSelectedIndexChanged="cboCurrency_SelectedIndexChanged" AutoPostBack="True" CssClass="form-control">
                                    </asp:DropDownList>
                        <asp:Label ID="Label1" runat="server" Text="." Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Tick if applicable
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:CheckBox ID="chkQuantitifiable" runat="server" AutoPostBack="True" Font-Bold="True" Font-Italic
                            ="True" OnCheckedChanged="chkQuantitifiable_CheckedChanged" Text="Is Group Plan" />
                        <asp:CheckBox ID="chkFrameWork" runat="server" AutoPostBack="True" Font-Bold="True"
                                        Font-Italic="True" Text="Is FrameWork" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        <asp:Label ID="lblStockName" runat="server" Text="Stock Name / Category" Visible="False"></asp:Label>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtStockName" runat="server" AutoPostBack="True" CssClass="form-control" Visible="False"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        <asp:Label ID="lblNonStockCatType" runat="server" Text="Non Stock Item Category Type"></asp:Label>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboNonStockCatType" runat="server" CssClass="form-control"
                                        OnDataBound="cboNonStockCatType_DataBound" OnSelectedIndexChanged="cboNonStockCatType_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                    </div>
                    <div class="col-sm-1 mb-3 mb-sm-0">
                        Quantity
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtQuantity" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtQuantity_TextChanged"  runat="server"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTEQuantity" runat="server" TargetControlID="txtQuantity"  FilterType="Custom,Numbers" ValidChars=",">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        <asp:Label ID="lblNonStockItemCat" runat="server" Text="Non Stock Item Category"></asp:Label>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboNonStockCat" runat="server" CssClass="form-control" OnDataBound="cboNonStockCat_DataBound">
                                </asp:DropDownList>
                        <ajaxToolkit:AutoCompleteExtender ID="ACEStockName" runat="server" MinimumPrefixLength="1"
                                            ServiceMethod="GetStockItemsByName" ServicePath="CascadingddlService.asmx" TargetControlID="txtStockName">
                                        </ajaxToolkit:AutoCompleteExtender>
                    </div>
                    <div class="col-sm-1 mb-3 mb-sm-0">
                        Unit Cost
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtUnitCost" runat="server" Font-Bold="True" AutoPostBack="true" OnTextChanged="txtUnitCost_TextChanged" CssClass="form-control"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FTEtxtUnitCost" runat="server" TargetControlID="txtUnitCost" FilterType="Custom, Numbers" ValidChars=","></ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Item/Service Description
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" ></asp:TextBox>
                    </div>
                    <div class="col-sm-1 mb-3 mb-sm-0">
                        Total Cost (NGN)
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtTotalCost" runat="server" autocomplete="off" BackColor="#EEEEEE"
                                            BorderColor="#EEEEEE" CssClass="form-control" Font-Bold="True"
                                            Font-Size="12pt" ForeColor="Firebrick" ReadOnly="True">0</asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Units
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboUnits" runat="server" CssClass="form-control" OnDataBound="cboUnits_DataBound">
                            </asp:DropDownList>
                    </div>
                    <div class="col-sm-1 mb-3 mb-sm-0">
                        Procurement Method		
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboProcurementMethod" runat="server" AutoPostBack="True" CssClass="form-control"
                                            Enabled="False" OnDataBound="cboProcurementMethod_DataBound" OnSelectedIndexChanged="cboProcurementMethod_SelectedIndexChanged">
                                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Quarter When Needed
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboQuarter" runat="server" CssClass="form-control"
                                OnDataBound="cboQuarter_DataBound" OnSelectedIndexChanged="cboQuarter_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            &nbsp;
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Red" Text="." Width="50%"></asp:Label>
                    </div>
                    <div class="col-sm-1 mb-3 mb-sm-0">
                        	Date When Needed	
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtDateWhenNeeded" runat="server" CssClass="form-control"  Enabled="False" AutoPostBack="True" OnTextChanged="txtDateWhenNeeded_TextChanged"></asp:TextBox>
                    </div>
                 </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        Plan Justification
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtJustify" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="col-sm-1 mb-3 mb-sm-0">
                        Source of Funding
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboFunding" runat="server" CssClass="form-control"
                                OnDataBound="cboFunding_DataBound">
                            </asp:DropDownList>
                    </div>
                 </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0"></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtMarketPrice" runat="server" autocomplete="off" BackColor="#EEEEEE"
                                            BorderColor="#EEEEEE" CssClass="form-control" Font-Bold="True"
                                            Font-Size="12pt" ForeColor="Firebrick" ReadOnly="True" Visible="false"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTEtxtMarketPrice" runat="server" TargetControlID="txtMarketPrice"  FilterType="Custom,Numbers" ValidChars=",">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                    </div>
                    <div class="col-sm-1 mb-3 mb-sm-0">
                        
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                FilterType="Numbers" TargetControlID="txtQuantity">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <asp:TextBox ID="txtProclength" runat="server" CssClass="form-control" Visible="False">1</asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-15 mb-3 mb-sm-0">
                        <asp:Label ID="lblProcLength" runat="server" ForeColor="#C00000" Text="." Font-Bold="True"></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1 mb-3 mb-sm-0"></div>
                    <div class="col-sm-5 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboPayPeriod" runat="server" CssClass="form-control"
                                OnDataBound="cboItemCategory_DataBound" Visible="false">
                                <asp:ListItem Value="0">--- Select Pay Period---</asp:ListItem>
                                <asp:ListItem Value="1">One Off  (Annual)</asp:ListItem>
                                <asp:ListItem Value="2">Quarterly</asp:ListItem>
                                <asp:ListItem Value="3">Monthly</asp:ListItem>
                            </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-4 mb-3 mb-sm-0"></div>
                    <div class="col-sm-5 mb-3 mb-sm-0">
                            Add New File Attachments
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-5 mb-3 mb-sm-0">
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
                                            <input id="Button1" onclick="addFileUploadBox()" type="button" value="Add a file" />
                                        </p>
                                    </td>
                                </tr>
                            </table>
                    </div>
                </div>
                <div class="form-group row">
                    <asp:MultiView ID="MultiView3" runat="server">
                        <asp:View ID="View4" runat="server">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                <tr>
                                                                    <td class="InterfaceHeaderLabel3" style="height: 18px; text-align: center">
                                                                        Add/Remove Existing File Attachments</td>
                                                                </tr>
                                                            </table>
                            <br />
                            <asp:GridView ID="GridAttachments" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                                                GridLines="None" HorizontalAlign="Center" OnRowCommand="GridAttachments_RowCommand"
                                                                OnSelectedIndexChanged="GridAttachments_SelectedIndexChanged" PageSize="15" Width="95%">
                                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                <RowStyle CssClass="gridRowStyle" />
                                                                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                                <Columns>
                                                                    <asp:ButtonField CommandName="ViewDetails" Text="View">
                                                                        <HeaderStyle CssClass="gridEditField" HorizontalAlign="Left" />
                                                                        <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                                            Width="140px" />
                                                                    </asp:ButtonField>
                                                                    <asp:ButtonField CommandName="btnRemove" Text="Remove">
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle CssClass="gridEditField" ForeColor="#003399" />
                                                                    </asp:ButtonField>
                                                                </Columns>
                                                                <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                                <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                            </asp:GridView>
                            <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red"
                                                                Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></asp:View>
                    </asp:MultiView>
                </div>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtDateWhenNeeded">
                </ajaxToolkit:CalendarExtender>
                <div class="form-group row">
                    <div class="col-sm-4 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="SUBMIT" class="btn btn-primary btn-user btn-block"/>
                    </div>
                    <div class="col-sm-2 mb-3 mb-sm-0">
                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" class="btn btn-primary btn-user btn-block"/>
                    </div>
                </div>
                    </asp:View>
                    
                    <asp:View ID="View3" runat="server">
                        <table style="width: 100%" align="center">
                            <tr>
                                <td style="width: 80px">
                                </td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                <asp:Label ID="lblQn" runat="server" ForeColor="Maroon" Text="." Font-Bold="True"></asp:Label><asp:Button
                    ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" /><asp:Button ID="btnNo"
                        runat="server" OnClick="btnNo_Click" Text="No" /></td>
                            </tr>
                            <tr>
                                <td style="width: 80px">
                                    <asp:Label ID="lblPlanCode" runat="server" Text="0" Visible="False"
                                    Width="82px"></asp:Label></td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View5" runat="server">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 20px">
                                </td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                                    REMOVE ATTACHMENT</td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                                    <asp:Label ID="lblFileCode" runat="server" Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                                    <asp:Label ID="lblRemoveAtt" runat="server" Font-Bold="True" ForeColor="Red" Text="."></asp:Label>
                                    <asp:Button ID="btnYesAtt" runat="server" OnClick="btnYesAtt_Click" Text="Yes" />
                                    <asp:Button ID="btnNoAtt" runat="server" OnClick="btnNoAtt_Click" Text="No" /></td>
                            </tr>
                            <tr>
                                <td style="width: 100%; text-align: right">
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    
                </asp:MultiView>
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

