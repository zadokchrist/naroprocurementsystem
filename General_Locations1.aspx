<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" 
AutoEventWireup="true" CodeFile="General_Locations1.aspx.cs" 
Inherits="CostCenter" 
Title="Cost Center" 
Culture="auto" 
UICulture="auto" %>
 <%@ Register 
 Assembly="AjaxControlToolkit" 
 Namespace="AjaxControlToolkit" 
 TagPrefix="ajaxToolkit" %>
 <%@ Import
  Namespace="System.Threading" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    

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
                            View Delivery Locations</td>
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
                                    <td class="InterfaceItemSeparator" colspan="3">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="vertical-align: middle; text-align: center; height: 19px;">
                                        &nbsp;<asp:Button ID="Button1" runat="server"  Text="Add Delivery Location" OnClick="Button1_Click" /></td>
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
                            <asp:GridView ID="GridCCenter" runat="server" AllowPaging="True" CssClass="gridgeneralstyle"
                                DataKeyNames="LocationID" EmptyDataText="NO COST CENTER FOUND" HorizontalAlign="Center" 
                                 PageSize="20" Width="80%" OnRowCommand="GridCCenter_RowCommand" OnRowCreated="GridCCenter_RowCreated" BorderStyle="Solid" OnPageIndexChanging="GridCCenter_PageIndexChanging">
                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                <RowStyle CssClass="gridRowStyle" />
                                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                <Columns >
                                    <asp:ButtonField CommandName="btnEdit" Text="Edit Item">
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
                    <asp:View ID="View2" runat="server">
                        <table align ="center" cellpadding="0" cellspacing="0" style="width: 55%">
                            <tr>
                                <td class="InterFaceTableRightRowUp" colspan="3" style="height: 20px; background-color: #ffffff;
                                    text-align: center">
                <table align ="center" cellpadding="0" cellspacing="0" style="width: 96%">
                    <tr>
                        <td class="InterfaceHeaderLabel3" style="height: 18px">
                            Edit Delivery Location </td>
                    </tr>
                </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableRightRowUp" colspan="3" style="height: 20px; background-color: #ffffff">
                                </td>
                            </tr>
                         
                                <tr>
                                    <td class="InterFaceTableLeftRow" style="height: 30px">
                                       Delivery Location Name</td>
                                    <td class="InterFaceTableMiddleRow" style="height: 30px">
                                    </td>
                                    <td class="InterFaceTableRightRow" style="height: 30px">
                                        <asp:TextBox ID="txtCcCode"  runat="server" style="width: 70%" Width="124px" ></asp:TextBox></td>
                                </tr>
                            
                                <tr>
                                    <td colspan="3" style="vertical-align: middle; text-align: center">
                                        &nbsp;<table align ="center" cellpadding="0" cellspacing="0" style="width: 45%">
                    <tr>
                        <td style="vertical-align: middle; text-align: right; width: 16%;">
                            <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Height="23px" Text="OK" 
                                Width="85px" OnClick="btnOK_Click" />
                        </td>
                        <td style="vertical-align: middle; text-align: right; width: 16%;">
                            <asp:Button ID="btnCancel" runat="server" Font-Size="9pt" Height="23px" 
                                Text="Return" Width="85px" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="vertical-align: middle; text-align: center">
                                        <asp:Label ID="lblcode" runat="server" Text="0" Visible="False" Width="46px"></asp:Label>
                                        <asp:Label ID="lblCcCode" runat="server" Text="0" Width="156px" Visible="False"></asp:Label>
                                        <asp:Label ID="lblInitials" runat="server" Text="x" Width="144px" Visible="False"></asp:Label></td>
                                </tr>
                            </table>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                        <table align ="center" cellpadding="0" cellspacing="0" style="width: 55%">
                            <tr>
                                <td class="InterFaceTableRightRowUp" colspan="3" style="height: 20px; background-color: #ffffff;
                                    text-align: center">
                                    <table align ="center" cellpadding="0" cellspacing="0" style="width: 96%">
                                        <tr>
                                            <td class="InterfaceHeaderLabel3" style="height: 18px">
                                                Add Delivery Location</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableRightRowUp" colspan="3" style="height: 20px; background-color: #ffffff">
                                </td>
                            </tr>
                            
                              <tr>
                                <td class="InterFaceTableLeftRow" style="height: 29px">
                                   Delivery Location Name</td>
                                <td class="InterFaceTableMiddleRow" style="height: 29px">
                                    &nbsp;</td>
                                <td class="InterFaceTableRightRow" style="height: 29px">
                                    <asp:TextBox   ID="txtAName" runat="server" Style="width: 70%" Width="60%"></asp:TextBox></td>
                            </tr>
                           
                          
                            <tr>
                                <td colspan="3" style="vertical-align: middle; text-align: center">
                                    &nbsp;<table align ="center" cellpadding="0" cellspacing="0" style="width: 45%">
                                        <tr>
                                            <td style="vertical-align: middle; text-align: right; width: 16%;">
                                                <asp:Button ID="Button2" runat="server" Font-Size="9pt" Height="23px" Text="OK" 
                                Width="85px" OnClick="Button2_Click1" />
                                            </td>
                                            <td style="vertical-align: middle; text-align: right; width: 16%;">
                                                <asp:Button ID="Button3" runat="server" Font-Size="9pt" Height="23px" 
                                Text="Return" Width="85px" OnClick="btnCancel_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="vertical-align: middle; text-align: center; height: 19px;">
                                    <asp:Label ID="Label1" runat="server" Text="0" Visible="False" Width="46px"></asp:Label>
                                    <asp:Label ID="lblCenterID" runat="server" Text="0" Visible="False" Width="156px"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text="x" Visible="False" Width="144px"></asp:Label></td>
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