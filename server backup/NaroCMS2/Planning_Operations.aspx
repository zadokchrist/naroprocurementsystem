<%@ Page Language="C#" MasterPageFile="~/PlanningGeneric.master" AutoEventWireup="true" CodeFile="Planning_Operations.aspx.cs" Inherits="Planning_Operations" Title="OPERATIONS - MANAGE PLAN ITEMS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    
    <script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}

// ]]>
</script>

        <table style="WIDTH: 85%" cellspacing="0" cellpadding="0" align="center"><TBODY><TR><TD 
    style="VERTICAL-ALIGN: middle; WIDTH: 20%; HEIGHT: 18px; TEXT-ALIGN: center" 
    class="InterfaceHeaderLabel2">AREA</TD><TD 
    style="VERTICAL-ALIGN: middle; WIDTH: 25%; HEIGHT: 18px; TEXT-ALIGN: center" 
    class="InterfaceHeaderLabel2">Cost 
    Center</TD><TD 
    style="VERTICAL-ALIGN: middle; WIDTH: 25%; HEIGHT: 18px; TEXT-ALIGN: center" 
    class="InterfaceHeaderLabel2">Procurement 
    type</TD><TD 
    style="VERTICAL-ALIGN: middle; WIDTH: 25%; HEIGHT: 18px; TEXT-ALIGN: center" 
    class="InterfaceHeaderLabel2"></TD></TR><TR><TD 
    style="VERTICAL-ALIGN: middle; HEIGHT: 1px; TEXT-ALIGN: center" 
    class="ddcolortabsline2" colSpan=4> &nbsp;&nbsp;&nbsp;</TD></TR><TR><TD 
    style="VERTICAL-ALIGN: middle; WIDTH: 25%; HEIGHT: 23px; TEXT-ALIGN: center"><asp:DropDownList id="DropDownList1" runat="server" Width="95%" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" OnDataBound="DropDownList1_DataBound" CssClass="InterfaceDropdownList">
                        </asp:DropDownList></TD><TD 
    style="VERTICAL-ALIGN: middle; WIDTH: 25%; HEIGHT: 23px; TEXT-ALIGN: center"><asp:DropDownList id="cboCostCenters" runat="server" Width="95%" AutoPostBack="True" OnDataBound="cboCostCenters_DataBound" CssClass="InterfaceDropdownList">
                            </asp:DropDownList></TD><TD 
    style="VERTICAL-ALIGN: middle; WIDTH: 25%; HEIGHT: 23px; TEXT-ALIGN: center"><asp:DropDownList id="cboProcType" runat="server" Width="95%" OnDataBound="cboProcType_DataBound" CssClass="InterfaceDropdownList">
                            </asp:DropDownList></TD><TD 
    style="VERTICAL-ALIGN: middle; WIDTH: 25%; HEIGHT: 23px; TEXT-ALIGN: center"> &nbsp;&nbsp;&nbsp;<asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Text="Search" Font-Size="9pt" Width="40%" Height="23px"></asp:Button></TD></TR><TR><TD 
    style="VERTICAL-ALIGN: middle; HEIGHT: 23px; TEXT-ALIGN: center" colSpan=4></TD></TR></TBODY></TABLE>

    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table style="width: 100%" id="TABLE1" onclick="return TABLE1_onclick()">
                <tr>
                    <td style="width: 100%; text-align: center; height: 21px;" class="InterFaceTableLeftRowUp">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Grand Total Cost"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="."></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" Font-Bold="True"
                            OnCheckedChanged="chkSelect_CheckedChanged" Text="Select All" /></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Left" Font-Names="Verdana" Font-Size="Small"
                    ForeColor="#333333" GridLines="None" Width="100%" OnItemCommand="DataGrid1_ItemCommand" AllowPaging="True" OnPageIndexChanged="DataGrid1_PageIndexChanged" PageSize="15">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditItemStyle BackColor="#999999" />
                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" Mode="NumericPages" HorizontalAlign="Center" />
                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Left" BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:ButtonColumn CommandName="btnDetail" HeaderText="VIEW" Text="View"></asp:ButtonColumn>
                                <asp:BoundColumn DataField="PlanCode" HeaderText="Serial No"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Description" HeaderText="Item Description"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CostCenterName" HeaderText="Cost Center"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:N0}"></asp:BoundColumn>
                                <asp:BoundColumn DataField="UnitCost" HeaderText="UnitCost" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Total Cost" HeaderText="Total Cost" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Unit" HeaderText="Units"></asp:BoundColumn>
                                <asp:ButtonColumn HeaderText="FILES" Text="View/Add" CommandName="btnFiles"></asp:ButtonColumn>
                                <asp:TemplateColumn HeaderText="Submit">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Consolidated") %>'
                                            Width="40px" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="2%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateColumn>
                            </Columns>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        </asp:DataGrid></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right; height: 23px;">
                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Font-Bold="True"
                            OnCheckedChanged="CheckBox2_CheckedChanged" Text="Select All" /></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 95%; height: 80px">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="vertical-align: middle; height: 80px;
                                                text-align: left">
                                                Reason for Deletion</td>
                                            <td class="InterFaceTableMiddleRowUp" style="height: 80px">
                                                &nbsp;</td>
                                            <td class="InterFaceTableRightRowUp" style="vertical-align: top; height: 80px; text-align: left">
                                                <asp:TextBox ID="txtComment" runat="server" CssClass="InterfaceTextboxMultiline"
                                                    Height="99px" Style="height: 80px" TextMode="MultiLine"></asp:TextBox></td>
                                        </tr>
                                    </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="btnSubmit_Click"
                            Text="REMOVE PLAN ITEMS" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table align="center" cellpadding="0" cellspacing="0" style="width: 90%">
                <tr>
                    <td colspan="3" style="text-align: center">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                            <tr>
                                <td class="InterfaceHeaderLabel" style="height: 20px">
                                    ATTACHMENTS</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="vertical-align: top; height: 2px; text-align: center">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="vertical-align: top; height: 18px; text-align: center">
                        <asp:Label ID="lblHeaderMsg" runat="server" Font-Bold="True" Font-Names="Cambria"
                            Font-Size="11pt" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 2px; text-align: center">
                    </td>
                </tr>
                <tr>
                    <td style="height: 203px">
                        <table align="center" cellpadding="0" cellspacing="0" class="style12">
                            <tr>
                                <td style="vertical-align: top; width: 50%; height: 121px; text-align: center">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                    </table>
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
                                            <td colspan="3" style="height: 2px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:GridView ID="GridAttachments" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                                    GridLines="None" HorizontalAlign="Center" OnRowCommand="GridAttachments_RowCommand"
                                                    PageSize="5" Width="98%">
                                                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                    <RowStyle CssClass="gridRowStyle" />
                                                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                    <Columns>
                                                        <asp:ButtonField CommandName="btnView" Text="View">
                                                            <HeaderStyle CssClass="gridEditField" />
                                                            <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                                Width="140px" />
                                                        </asp:ButtonField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                    <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                </asp:GridView>
                                                <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red"
                                                    Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    <asp:Button
                            ID="Button2" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" OnClick="btnReturn_Click"
                            Text="RETURN" Width="80px" /><asp:Label ID="lblPlanCode" runat="server" Text="0" Visible="False"></asp:Label></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View3" runat="server"><table style="width: 100%" id="Table2" onclick="return TABLE1_onclick()">
            <tr>
                <td style="width: 100%; text-align: right; height: 21px;">
                </td>
            </tr>
            <tr>
                <td style="width: 100%; text-align: center">
                    <asp:Label ID="lblQn" runat="server" ForeColor="Maroon" Text="." Font-Bold="True"></asp:Label><asp:Button
                        ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" /><asp:Button ID="btnNo"
                            runat="server" OnClick="btnNo_Click" Text="No" /></td>
            </tr>
            <tr>
                <td style="width: 100%; text-align: right">
                </td>
            </tr>
            <tr>
                <td style="width: 100%; text-align: center">
                </td>
            </tr>
        </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>


