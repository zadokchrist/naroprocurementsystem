<%@ Page Language="C#" MasterPageFile="~/Suppliers.master" AutoEventWireup="true" CodeFile="Suppliers_PendingRFQ.aspx.cs" Inherits="Requisition_PlannedItems" Title="ITEMS TO REQUISITION" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td class="InterfaceItemSeparator2" style="height: 2px">
            </td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                    <tr>
                        <td class="InterfaceHeaderLabel3" style="height: 18px">
                            PENDING RFQs</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 21px">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 50%; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                    <tr>
                        
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            SEARCH (DESCRIPTION)</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            STATUS</td>
                        
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                        </td>
                    </tr>
                    <tr>
                        <td class="ddcolortabsline2" colspan="6" style="vertical-align: middle; text-align: center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:DropDownList ID="cboProcType" runat="server" CssClass="InterfaceDropdownList"
                                 Width="95%">

                       <asp:ListItem Value="0">-- Select Status --</asp:ListItem>
                     <asp:ListItem Value="50">Running RFQ</asp:ListItem>
                     <asp:ListItem Value="43">Pending RFQ</asp:ListItem>
                     <asp:ListItem Value="53">Submitted RFQ</asp:ListItem>

                            </asp:DropDownList></td>
                        
                        
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Height="23px" OnClick="btnOK_Click"
                                Text="Search" Width="85px" />&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
       
        <tr>
            <td style="vertical-align: top; width: 50%; height: 15px; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 50%; text-align: center">
                <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid;
                    border-left: #617da6 1px solid; width: 99%; border-bottom: #617da6 1px solid">
                    <tr>
                        <td style="vertical-align: top; text-align: center">
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                                                OPEN RFQ(S)</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Left" Font-Names="Verdana" Font-Size="Small"
                                                    ForeColor="#333333" GridLines="None" Width="100%" OnItemCommand="DataGrid1_ItemCommand"  OnItemDataBound="DataGrid1_ItemDataBound" AllowPaging="True" PageSize="20" OnPageIndexChanged="DataGrid1_PageIndexChanged1">
                                                    <FooterStyle Font-Bold="True" ForeColor="White" />
                                                    <EditItemStyle BackColor="#999999" />
                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" Mode="NumericPages" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" VerticalAlign="Top" />
                                                    <ItemStyle HorizontalAlign="Left" BackColor="#F7F6F3" ForeColor="#333333" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="ScalaPRNumber" HeaderText="Reference Number"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Subject" HeaderText="Description"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ProcurementType" HeaderText="Procurement Type"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="EstimatedCost" HeaderText="Total Cost" DataFormatString="{0:N0}">
                                                            <ItemStyle Width="120px" HorizontalAlign="Left" />
                                                        </asp:BoundColumn>
                                                       
                                                        <asp:ButtonColumn CommandName="btnDetails" HeaderText="Respond"  Text="VIEW">
                                                            <ItemStyle Font-Bold="True" />
                                                        </asp:ButtonColumn>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                </asp:DataGrid></td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <table id="Table3"  style="width: 98%">
                                        <tr>
                                            <td style="width: 100%; height: 21px; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                                                STATUS</td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                                                <asp:Button ID="btnStagesExport" runat="server" OnClick="btnStagesExport_Click" Text="Export" />&nbsp;
                                                <asp:Button ID="btnStagesReturn" runat="server" OnClick="btnStagesReturn_Click" Text="Return" /></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: right">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                                                <asp:DataGrid ID="DataGrid4" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid1_ItemCommand"
                                                    Style="text-align: justify" Width="100%">
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
                                            <td style="width: 100%; text-align: right">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>&nbsp;<br />
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

