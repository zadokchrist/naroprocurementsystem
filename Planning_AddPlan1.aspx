<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Planning_AddPlan1.aspx.cs" Inherits="Planning_AddPlan" Title="NEW PLAN ITEM" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="3" style="height: 5px">
               

 <asp:ScriptManager ID="ToolkitScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
                <table align="center" cellpadding="0" cellspacing="0" style="width: 50%">
                    <tr>
                        <td class="InterfaceHeaderLabel">
                            <asp:Label ID="lblHeader" runat="server" Text="ADD NEW PLAN ITEM"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View id="View1" runat="server">
                    
                        <table style="width: 100%">
                                <tr>
                                    <td colspan="3" style="vertical-align: top; text-align: center">
                        <table style="width: 98%; text-align: center;" align="center">
                            <tr>
                                <td class="InterFaceTableLeftRowUp" colspan="1" style="width: 49%">
                                    Select Procurement Category</td>
                                <td class="InterFaceTableRightRowUp" style="width: 48%">
                                    <asp:DropDownList ID="cboProcType" runat="server" AutoPostBack="True" CssClass="InterfaceDropdownList"
                                        OnDataBound="cboProcType_DataBound" OnSelectedIndexChanged="cboProcType_SelectedIndexChanged"
                                        Width="88%">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRowUp" colspan="1" style="width: 49%"> Tips *</td>
                                <td><p>Works : This refers to procurements for works to be done</p>
                                    <p>Goods : This refers to procurements to purchase items</p>
                                    <p>Services : This refers to procurements to provide services (consulational, non consultational)</p>
                                </td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRowUp" colspan="1" style="width: 49%">
                                    <asp:Label ID="lblStockItem" runat="server" Text="Tick if appropriate" Visible="False"></asp:Label></td>
                                <td class="InterFaceTableRightRowUp" style="width: 48%">
                                    <asp:CheckBox id="ChkStockItem" runat="server" Font-Bold="False" Text="Is Stock Item" CssClass="InterfaceDropdownList" Visible="False" AutoPostBack="True" OnCheckedChanged="ChkStockItem_CheckedChanged"></asp:CheckBox></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableRightRowUp" colspan="3" style="height: 10px; text-align: center" valign="middle">
                                    <table style="width: 80%" align="center">
                                        <tr>
                                            <td style="width: 50%; text-align: center">
                                    <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" Checked="True"
                                        GroupName="Budget" OnCheckedChanged="rdOperational_CheckedChanged" Text="Operational Item" Font-Bold="True" Width="151px"  Visible="false" /></td>
                                            <td style="width: 50%; text-align: center">
                                    <asp:RadioButton ID="rdCapital" runat="server" AutoPostBack="True" GroupName="Budget"
                                        OnCheckedChanged="rdCapital_CheckedChanged" Text="Capital Item" Font-Bold="True" Width="116px" Visible="false" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                                    </td>
                                </tr>

                            </table>
                    </asp:View>
                
                
                </asp:MultiView>
            
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:MultiView ID="MultiView2" runat="server">
                    
                    <asp:View ID="View2" runat="server">
                            <table style="width: 100%">
                                <tr>
                                    <td colspan="5">
                                        <updatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                        <table width="100%" cellspacing="0" cellpadding="0">
                                            <tr>
                                    <td colspan="3" class="InterFaceTableLeftRow" style="vertical-align: top; text-align: center">
                                        <asp:Label ID="lblBudgetName" runat="server" Font-Bold="True" ForeColor="#C00000"
                                            Text="."></asp:Label></td>
                                </tr>
                                <tr style="color: #000000">
                                    <td colspan="3" style="height: 30px; vertical-align: top; height: 2px; text-align: center">
                                    </td>
                                </tr>
                                <tr style="color: #000000">
                                    <td style="vertical-align: top; width: 49%; text-align: center">
                                        
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                            <tr>
                                <td class="InterFaceTableLeftRow" style="width: 191px">
                                    Item Category</td>
                                <td class="InterFaceTableMiddleRow" style="width: 2%">
                                    &nbsp;</td>
                                <td class="InterFaceTableRightRow" style="width: 64%">
                                    <asp:DropDownList ID="cboItemCategory" runat="server" CssClass="InterfaceDropdownList"
                                        OnDataBound="cboItemCategory_DataBound" Width="80%">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRow" style="width: 191px">
                                    Tick if applicable</td>
                                <td class="InterFaceTableMiddleRow" style="width: 2%">
                                </td>
                                <td class="InterFaceTableRightRow" style="width: 64%">
                                    <asp:CheckBox ID="chkQuantitifiable" runat="server" AutoPostBack="True" Font-Bold="True"
                                        Font-Italic="True" OnCheckedChanged="chkQuantitifiable_CheckedChanged" Text="Is Group Plan" />
                                        <asp:CheckBox ID="chkIsFramework" runat="server" AutoPostBack="True" Font-Bold="True"
                                        Font-Italic="True" Text="Is FrameWork" /></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRow" style="width: 191px">
                                    <asp:Label ID="lblStockName" runat="server" Text="Stock Name / Category" Visible="False"></asp:Label></td>
                                <td class="InterFaceTableMiddleRow" style="width: 2%">
                                </td>
                                <td class="InterFaceTableRightRow" style="width: 64%">
                                    &nbsp;<asp:TextBox ID="txtStockName" runat="server" AutoPostBack="True" CssClass="InterfaceTextboxLongReadOnly"  autocomplete="off" Font-Bold="True"
                                                    ForeColor="Firebrick" Width="78%" Visible="False"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRow" style="width: 191px">
                                    <asp:Label ID="lblNonStockCatType" runat="server" Text="Non Stock Item Category Type"></asp:Label></td>
                                <td class="InterFaceTableMiddleRow" style="width: 2%">
                                </td>
                                <td class="InterFaceTableRightRow" style="width: 64%">
                            <asp:DropDownList ID="cboNonStockCatType" runat="server" CssClass="InterfaceDropdownList"
                                        OnDataBound="cboNonStockCatType_DataBound" Width="80%" OnSelectedIndexChanged="cboNonStockCatType_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRow" style="width: 191px">
                                    <asp:Label ID="lblNonStockItemCat" runat="server" Text="Non Stock Item Category"></asp:Label></td>
                                <td class="InterFaceTableMiddleRow" style="width: 2%">
                                </td>
                                <td class="InterFaceTableRightRow" style="width: 64%">
                            <asp:DropDownList ID="cboNonStockCat" runat="server" CssClass="InterfaceDropdownList"
                                        OnDataBound="cboNonStockCat_DataBound" Width="80%">
                                </asp:DropDownList></td>
                            </tr>
                        </table>
                                        <ajaxToolkit:AutoCompleteExtender ID="ACEStockName" runat="server" MinimumPrefixLength="1"
                                            ServiceMethod="GetStockItemsByName" ServicePath="CascadingddlService.asmx" TargetControlID="txtStockName">
                                        </ajaxToolkit:AutoCompleteExtender>
                                    </td>
                                    <td style="width: 3px">
                                    </td>
                                    <td style="vertical-align: top; width: 49%; text-align: center">
                                <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                <tr>
                                    <td class="InterFaceTableLeftRow" style="width: 149px">
                            Currency</td>
                                    <td class="InterFaceTableMiddleRow">
                                    </td>
                                    <td class="InterFaceTableRightRow">
                                    <asp:DropDownList ID="cboCurrency" runat="server" OnSelectedIndexChanged="cboCurrency_SelectedIndexChanged"
                                        Width="80%" AutoPostBack="True">
                                    </asp:DropDownList><asp:Label ID="Label1" runat="server" Text="."
                                        Width="20%" Visible="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRow" style="width: 149px">
                                        Quantity</td>
                                    <td class="InterFaceTableMiddleRow">
                                    </td>
                                    <td class="InterFaceTableRightRow">
                                        <asp:TextBox ID="txtQuantity" CssClass="InterfaceTextboxLongReadOnly" AutoPostBack="true"
                                            Width="80%" OnTextChanged="txtQuantity_TextChanged"  runat="server"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTEQuantity" runat="server" TargetControlID="txtQuantity"  FilterType="Custom,Numbers" ValidChars=",">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRow" style="width: 149px">
                                        Unit Cost</td>
                                    <td class="InterFaceTableMiddleRow">
                                    </td>
                                    <td class="InterFaceTableRightRow">
                                        <asp:TextBox ID="txtUnitCost" runat="server" Font-Bold="True" AutoPostBack="true"
                                            Font-Size="13pt" ForeColor="Firebrick" OnTextChanged="txtUnitCost_TextChanged"
                                            Width="80%"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTEtxtUnitCost" runat="server" TargetControlID="txtUnitCost" FilterType="Custom, Numbers" ValidChars=",">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRow" style="width: 149px">
                                        Total Cost (NGN)</td>
                                    <td class="InterFaceTableMiddleRow">
                                    </td>
                                    <td class="InterFaceTableRightRow">
                                        <asp:TextBox ID="txtTotalCost" runat="server" autocomplete="off" BackColor="#EEEEEE"
                                            BorderColor="#EEEEEE" CssClass="InterfaceTextboxLongReadOnly" Font-Bold="True"
                                            Font-Size="12pt" ForeColor="Firebrick" ReadOnly="True" Width="80%">0</asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRow" style="width: 149px; height: 30px">
                                        Procurement Method</td>
                                    <td class="InterFaceTableMiddleRow" style="height: 30px">
                                    </td>
                                    <td class="InterFaceTableRightRow" style="height: 30px">
                                        <asp:DropDownList ID="cboProcurementMethod" runat="server" AutoPostBack="True" CssClass="InterfaceDropdownList"
                                            Enabled="False" OnDataBound="cboProcurementMethod_DataBound" OnSelectedIndexChanged="cboProcurementMethod_SelectedIndexChanged"
                                            Width="80%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRow" style="width: 149px">
                                       <%-- Market price of the procurement--%></td>
                                    <td class="InterFaceTableMiddleRow">
                                    </td>
                                    <td class="InterFaceTableRightRow">
                                        <asp:TextBox ID="txtMarketPrice" runat="server" Font-Bold="True" ReadOnly ="false"
                                            Font-Size="13pt" ForeColor="Firebrick" 
                                            Width="80%" Visible="false"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTEtxtMarketPrice" runat="server" TargetControlID="txtMarketPrice" FilterType="Custom, Numbers" ValidChars=",">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                            </table>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                FilterType="Numbers" TargetControlID="txtQuantity">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <asp:TextBox ID="txtProclength" runat="server" CssClass="InterfaceTextboxLongReadOnly"
                        Style="vertical-align: middle; text-align: center" Width="5%" Visible="False">1</asp:TextBox>
                                            
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRow" colspan="3" style="text-align: center">
                            <asp:Label ID="lblProcLength" runat="server" ForeColor="#C00000" Text="." Font-Bold="True"></asp:Label></td>
                                </tr>
                                        
                                        </table>
                                        </ContentTemplate>
                                        </updatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRow" colspan="1" style="text-align: center; vertical-align: top; width: 49%;" valign="top">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td class="InterFaceTableLeftRow" style="height: 45px; width: 191px;">
                            Item/Service Description</td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 45px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 64%; height: 45px">
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="InterfaceTextboxMultiline"
                                Style="width: 80%; height: 55px" TextMode="MultiLine" Width="80%"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRow" style="height: 29px; width: 191px;">
                            Units</td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 64%; height: 29px">
                            <asp:DropDownList ID="cboUnits" runat="server" CssClass="InterfaceDropdownList" OnDataBound="cboUnits_DataBound"
                                Width="82%">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRow" style="height: 29px; width: 191px;">
                           <%-- Payable in<--%></td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 64%; height: 29px">
                            <asp:DropDownList ID="cboPayPeriod" runat="server" CssClass="InterfaceDropdownList"
                                OnDataBound="cboItemCategory_DataBound" Width="82%" Visible="false">
                                <asp:ListItem Value="1">One Off  (Annual)</asp:ListItem>
                                <asp:ListItem Value="2">Quarterly</asp:ListItem>
                                <asp:ListItem Value="3">Monthly</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="1">
                        </td>
                    </tr>
                </table>
                                        <table width="100%">
                                            <tr>
                                                <td style="width: 100px;">
                            <br />
                                                <table cellspacing="5">
                                                    <tr>
                                                        <td style="width: 100px">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                <tr>
                                    <td class="InterfaceHeaderLabel3" style="height: 18px; text-align: center">
                                        Add New File Attachments</td>
                                </tr>
                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
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
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100%; text-align: center">
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
                                                    </asp:MultiView></td>
                                                    </tr>
                                                </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100px">
                                                    </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="InterFaceTableLeftRow" colspan="3" style="text-align: center" valign="top">
                                        <updatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                    <tr>
                        <td style=" width: 5%; height: 45px">
                        </td>
                        <td class="InterFaceTableLeftRow" style="height: 45px">
                            Plan Justification</td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 45px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 64%; height: 45px">
                            <asp:TextBox ID="txtJustify" runat="server" CssClass="InterfaceTextboxMultiline" Style="width: 80%;
                                height: 55px" TextMode="MultiLine"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style=" width: 5%; height: 45px">
                        </td>
                        <td class="InterFaceTableLeftRow" style="height: 29px">
                            Quarter When Needed</td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 64%; height: 29px">
                            <asp:DropDownList ID="cboQuarter" runat="server" CssClass="InterfaceDropdownList"
                                OnDataBound="cboQuarter_DataBound" OnSelectedIndexChanged="cboQuarter_SelectedIndexChanged"
                                Width="40%" AutoPostBack="True">
                            </asp:DropDownList>
                            &nbsp;
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Red" Text="." Width="50%"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style=" width: 5%; height: 45px">
                        </td>
                        <td class="InterFaceTableLeftRow" style="height: 29px">
                            Date When Needed</td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 64%; height: 29px">
                            <asp:TextBox ID="txtDateWhenNeeded" runat="server" CssClass="InterfaceTextboxLongReadOnly" Width="80%" Enabled="False" AutoPostBack="True" OnTextChanged="txtDateWhenNeeded_TextChanged"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style=" width: 5%; height: 45px">
                        </td>
                        <td class="InterFaceTableLeftRow" style="height: 29px">
                           <%-- Date To Initiate Form5--%></td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 64%; height: 29px">
                            <asp:TextBox ID="txtDate4PP20" runat="server" CssClass="InterfaceTextboxLongReadOnly" Width="80%" Enabled="False" Visible="false" Text="Jun 1, 2018"></asp:TextBox></td>
                    </tr>
                  <%--  <tr>
                        <td style=" width: 5%; height: 45px">
                        </td>
                        <td class="InterFaceTableLeftRow" style="height: 29px">
                            Payment Month</td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 64%; height: 29px">
                            <asp:DropDownList ID="cboPaymentMonth" runat="server" CssClass="InterfaceDropdownList"
                                OnDataBound="cboItemCategory_DataBound" Width="81%">
                                <asp:ListItem Value="0">--- Select Payment Month---</asp:ListItem>
                                <asp:ListItem Value="1">January</asp:ListItem>
                                <asp:ListItem Value="2">February</asp:ListItem>
                                <asp:ListItem Value="3">March</asp:ListItem>
                                <asp:ListItem Value="4">April</asp:ListItem>
                                <asp:ListItem Value="5">May</asp:ListItem>
                                <asp:ListItem Value="6">June</asp:ListItem>
                                <asp:ListItem Value="7">July</asp:ListItem>
                                <asp:ListItem Value="8">August</asp:ListItem>
                                <asp:ListItem Value="9">September</asp:ListItem>
                                <asp:ListItem Value="10">October</asp:ListItem>
                                <asp:ListItem Value="11">November</asp:ListItem>
                                <asp:ListItem Value="12">December</asp:ListItem>
                            </asp:DropDownList></td>
                    </tr>--%>
                    <tr>
                        <td style=" width: 5%; height: 45px">
                        </td>
                        <td class="InterFaceTableLeftRow" style="height: 29px">
                            Source of Funding</td>
                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 64%; height: 29px">
                            <asp:DropDownList ID="cboFunding" runat="server" CssClass="InterfaceDropdownList"
                                OnDataBound="cboFunding_DataBound" Width="81%">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td style=" width: 5%; height: 45px">
                        </td>
                        <td colspan="3" style="height: 19px">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtDateWhenNeeded">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtDate4PP20">
                </ajaxToolkit:CalendarExtender>
                                            </ContentTemplate>
                                        </updatePanel>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRow" colspan="4" style="text-align: center">
                                        &nbsp;</td>
                                </tr>
                            <tr>
                                <td class="InterFaceTableLeftRow" colspan="4" style="text-align: center">
                                    <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Height="23px" OnClick="btnOK_Click"
                                        Text="SUBMIT" Width="131px" /><asp:Button ID="btnCancel" runat="server" Font-Size="9pt"
                                            Height="23px" OnClick="btnCancel_Click" Text="Cancel" Width="85px" />
                                    </td>
                            </tr>
                            
                            </table>
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
            </td>
        </tr>
        <tr>
            <td colspan="3">
                
                &nbsp;
            </td>
        </tr>
    </table>
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

