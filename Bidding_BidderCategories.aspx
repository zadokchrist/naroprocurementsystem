<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Bidding_BidderCategories.aspx.cs" Inherits="Bidding_BidderCategories" Title="BIDDER CATEGORIES" Culture="auto" UICulture="auto" %>
 <%@ Register Assembly="AjaxControlToolkit"  Namespace="AjaxControlToolkit"  TagPrefix="ajaxToolkit" %>
 <%@ Import Namespace="System.Threading" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <%--      <ajaxToolkit:ToolkitScriptManager  ID="ScriptManager1" runat="server">
                </ajaxToolkit:ToolkitScriptManager>--%>
                   <asp:ScriptManager ID="ScriptManager1" AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>

                <table cellpadding="0" cellspacing="0" class="style12">
                    <tr>
                        <td style="width: 50%; vertical-align: middle; text-align: center;">
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            <table cellpadding="0" cellspacing="0" class="style12">
       
        <tr>
            <td style="height: 10px">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                <table align ="center" cellpadding="0" cellspacing="0" class="style12">
                    <tr>
                        <td style="vertical-align: top; width: 50%; text-align: center">
                <table align ="center" cellpadding="0" cellspacing="0" style="width: 96%">
                    <tr>
                        <td class="InterfaceHeaderLabel3" style="height: 17px">
                            MANAGE CATEGORIES AND SUB CATEGORIES</td>
                    </tr>
                </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; width: 50%; height: 2px; text-align: center">
                            <table align ="center" cellpadding="0" cellspacing="0" style="width: 55%">
                                <tr>
                                    <td class="InterFaceTableRightRowUp" colspan="3" style="height: 20px; background-color: #ffffff">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Procurement Type</td>
                                    <td class="InterFaceTableMiddleRowUp">
                                        &nbsp;</td>
                                    <td class="InterFaceTableRightRowUp">
                                        <asp:DropDownList ID="cboProcType" runat="server" CssClass="InterfaceDropdownList"
                                            OnDataBound="cboProcType_DataBound"
                                            Width="60%" style="width: 70%" AutoPostBack="True" OnSelectedIndexChanged="cboProcType_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                </tr>
                                 <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        View</td>
                                    <td class="InterFaceTableMiddleRowUp">
                                        &nbsp;</td>
                                    <td class="InterFaceTableRightRowUp">
                                        <asp:DropDownList ID="ddlView" runat="server" CssClass="InterfaceDropdownList"
                                            OnDataBound="cboProcType_DataBound"
                                            Width="60%" style="width: 70%" AutoPostBack="True" OnSelectedIndexChanged="ddlView_SelectedIndexChanged" >
                                            <asp:ListItem Text="CATEGORIES" Value="1">
                                            </asp:ListItem><asp:ListItem Text="SUB CATEGORIES" Value="2"></asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                              <%--  <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Supplier Category</td>
                                    <td class="InterFaceTableMiddleRowUp">
                                        &nbsp;</td>
                                    <td class="InterFaceTableRightRowUp">
                                        <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="InterfaceDropdownList"
                                            
                                            Width="60%" style="width: 70%" AutoPostBack="True" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged" >
                                        </asp:DropDownList></td>
                                </tr>
                                 <tr>
                                    <td class="InterFaceTableLeftRowUp">
                                        Supplier Sub Category</td>
                                    <td class="InterFaceTableMiddleRowUp">
                                        &nbsp;</td>
                                    <td class="InterFaceTableRightRowUp">
                                        <asp:DropDownList ID="ddlcategory2" runat="server" CssClass="InterfaceDropdownList"
                                            
                                            Width="60%" style="width: 70%" AutoPostBack="True" OnSelectedIndexChanged="ddlcategory2_SelectedIndexChanged" >
                                        </asp:DropDownList></td>
                                </tr>--%>
                                <tr>
                                    <td class="InterfaceItemSeparator" colspan="3">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="vertical-align: middle; text-align: center; height: 19px;">
                                        &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ADD CATEGORY" /></td>
                                </tr>
                                 <tr>
                                    <td colspan="3" style="vertical-align: middle; text-align: center; height: 19px;">
                                        &nbsp;<asp:Button ID="Button4" runat="server"  Text="ADD SUB CATEGORY" OnClick="Button4_Click" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; width: 50%; height: 2px; text-align: center">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; vertical-align: top; width: 50%">
                            <table align ="center" cellpadding="0" cellspacing="0" style="width: 95%">
                              
                                </table>
                            <asp:GridView ID="GridData" runat="server" AllowPaging="True" CssClass="gridgeneralstyle"
                                DataKeyNames="ID" EmptyDataText="NO ITEM(S) FOUND" HorizontalAlign="Center" 
                                 PageSize="11" Width="80%" OnRowCommand="GridData_RowCommand" BorderStyle="Solid" OnPageIndexChanging="GridData_PageIndexChanging" OnSelectedIndexChanged="GridData_SelectedIndexChanged">
                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                <RowStyle CssClass="gridRowStyle" />
                                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                <Columns >
                                    <asp:ButtonField CommandName="btnEdit" Text="Edit">
                                        <HeaderStyle CssClass="gridEditField" />
                                        <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                            Width="110px" />
                                    </asp:ButtonField>
                                </Columns>
                                <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                <PagerStyle HorizontalAlign="Center" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                    </asp:View>
                    &nbsp;
                    <asp:View ID="View3" runat="server">
                        <table align ="center" cellpadding="0" cellspacing="0" style="width: 55%">
                            <tr>
                                <td class="InterFaceTableRightRowUp" colspan="3" style="height: 20px; background-color: #ffffff;
                                    text-align: center">
                                    <table align ="center" cellpadding="0" cellspacing="0" style="width: 96%">
                                        <tr>
                                            <td class="InterfaceHeaderLabel3" style="height: 18px">
                                                ADD / EDIT </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableRightRowUp" colspan="3" style="height: 20px; background-color: #ffffff">
                                </td>
                            </tr>
                             <tr>
                                <td class="InterFaceTableLeftRowUp">
                                   </td>
                                <td class="InterFaceTableMiddleRowUp">
                                    &nbsp;</td>
                                <td class="InterFaceTableRightRowUp">
                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="InterfaceDropdownList"
                                            Width="60%" style="width: 70%" AutoPostBack="True" Enabled="false" >
<asp:ListItem Text="CATEGORY" Value="1"></asp:ListItem><asp:ListItem Text="SUB CATEGORY" Value="2"></asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRowUp">
                                    Procurement Category</td>
                                <td class="InterFaceTableMiddleRowUp">
                                    &nbsp;</td>
                                <td class="InterFaceTableRightRowUp">
                                    <asp:DropDownList ID="cboProcType2" runat="server" CssClass="InterfaceDropdownList"
                                            Width="60%" style="width: 70%" AutoPostBack="True" OnDataBound="cboProcType2_DataBound" OnSelectedIndexChanged="cboProcType2_SelectedIndexChanged">
                                    </asp:DropDownList></td>
                            </tr>
                           <%-- <tr>
                                <td class="InterFaceTableLeftRow" style="height: 29px">
                                    Supplier Sub Category</td>
                                <td class="InterFaceTableMiddleRow" style="height: 29px">
                                </td>
                                <td class="InterFaceTableRightRow" style="height: 29px">
                                    <asp:DropDownList ID="cboCategories" runat="server" CssClass="InterfaceDropdownList"
                                            Width="62%" style="width: 70%" OnDataBound="cboCategories_DataBound">
                                    </asp:DropDownList></td>
                            </tr>--%>
                            <%--<tr>
                                <td class="InterFaceTableLeftRow" style="height: 29px">
                                    Supplier Name</td>
                                <td class="InterFaceTableMiddleRow" style="height: 29px">
                                    &nbsp;</td>
                                <td class="InterFaceTableRightRow" style="height: 29px">
                                    <asp:TextBox ID="txtSupplierName" runat="server" CssClass="InterfaceTextboxLongReadOnly" Style="width: 70%" Width="60%"></asp:TextBox></td>
                            </tr>--%>
                            <tr>
                                <td class="InterFaceTableLeftRow" style="height: 29px">
                                    Name</td>
                                <td class="InterFaceTableMiddleRow" style="height: 29px">
                                </td>
                                <td class="InterFaceTableRightRow" style="height: 29px">
                                    <asp:TextBox ID="txtDirectorNames" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxMultiline"
                                        Font-Bold="True" TextMode="MultiLine" Width="70%"></asp:TextBox></td>
                            </tr>
                           <tr>
                                <td class="InterFaceTableLeftRow" style="height: 29px">
                                    Description</td>
                                <td class="InterFaceTableMiddleRow" style="height: 29px">
                                </td>
                                <td class="InterFaceTableRightRow" style="height: 29px">
                                    <asp:TextBox ID="txtPhysicalAddress" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxMultiline"
                                        Font-Bold="True" TextMode="MultiLine" Width="70%"></asp:TextBox></td>
                            </tr>
                           <%--    <tr>
                                <td class="InterFaceTableLeftRow" style="height: 29px">
                                    Phone Numbers</td>
                                <td class="InterFaceTableMiddleRow" style="height: 29px">
                                </td>
                                <td class="InterFaceTableRightRow" style="height: 29px">
                                    <asp:TextBox ID="txtPhoneNumbers" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxMultiline"
                                        Font-Bold="True" TextMode="MultiLine" Width="70%"></asp:TextBox></td>
                            </tr>
                          <tr>
                                <td class="InterFaceTableLeftRow">
                                    Email Address</td>
                                <td class="InterFaceTableMiddleRow">
                                </td>
                                <td class="InterFaceTableRightRow">
                                    <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="InterfaceTextboxLongReadOnly"
                                        Style="width: 70%" Width="60%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRow">
                                    Remarks</td>
                                <td class="InterFaceTableMiddleRow">
                                </td>
                                <td class="InterFaceTableRightRow">
                                    <asp:TextBox ID="txtRemarks" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxMultiline"
                                        Font-Bold="True" TextMode="MultiLine" Width="70%"></asp:TextBox></td>
                            </tr>--%>
                            <tr>
                                <td class="InterFaceTableLeftRow">
                                    Status</td>
                                <td class="InterFaceTableMiddleRow">
                                </td>
                                <td class="InterFaceTableRightRow">
                                    <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="True" Text="Is Active" /></td>
                            </tr>
                            <tr>
                                <td colspan="3" style="vertical-align: middle; height: 2px; text-align: center">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="vertical-align: middle; text-align: center">
                                    &nbsp;
                                                <asp:Button ID="Button2" runat="server" Font-Size="9pt" Height="23px" Text="OK" 
                                Width="85px" OnClick="Button2_Click" />
                                                <asp:Button ID="Button3" runat="server" Font-Size="9pt" Height="23px" 
                                Text="Cancel / Return" Width="117px" OnClick="btnCancel_Click" /></td>
                            </tr>
                            <tr>
                                <td colspan="3" style="vertical-align: middle; text-align: center; height: 19px;">
                                    <asp:Label ID="Label1" runat="server" Text="0" Visible="False" Width="46px"></asp:Label>
                                    <asp:Label ID="lblCenterID" runat="server" Text="0" Visible="False" Width="156px"></asp:Label>
                                    </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView></td>
        </tr>
        <tr>
            <td style="height: 21px">
                <asp:Label ID="lblPlanCode" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>




