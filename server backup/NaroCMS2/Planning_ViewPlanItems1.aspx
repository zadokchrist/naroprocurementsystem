<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Planning_ViewPlanItems1.aspx.cs" Inherits="Planning_ViewPlanItems" Title="VIEW PLAN ITEMS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    
    <table align="center" cellpadding="0" cellspacing="0" style="width: 80%">
        <tr>
            <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                text-align: center">
                Search (DESCRIPTION)</td>
            <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                text-align: center">
                Procurement type</td>
            <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                text-align: center">
                STATUS</td>
            <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                text-align: center">
            </td>
        </tr>
        <tr>
            <td class="ddcolortabsline2" colspan="4" style="vertical-align: middle; text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                &nbsp;<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></td>
            <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                <asp:DropDownList ID="cboProcType" runat="server" CssClass="InterfaceDropdownList"
                    OnDataBound="cboProcType_DataBound" Width="95%">
                </asp:DropDownList></td>
            <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                <asp:DropDownList ID="cboStatus" runat="server" CssClass="InterfaceDropdownList"
                    OnDataBound="cboProcType_DataBound" Width="95%">
                    <asp:ListItem Value="0">-- All Statuses --</asp:ListItem>
                    <asp:ListItem Value="4">Pending</asp:ListItem>
                    <asp:ListItem Value="1">Approved</asp:ListItem>
                    <asp:ListItem Value="2">Consolidated</asp:ListItem>
                    <asp:ListItem Value="3">Rejected</asp:ListItem>
                </asp:DropDownList></td>
            <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Height="23px" OnClick="btnOK_Click"
                    Text="Search" Width="85px" />&nbsp;</td>
        </tr>
    </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table id="TABLE1" onclick="return TABLE1_onclick()" style="width: 100%">
                <tr>
                    <td style="width: 100%; height: 21px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                        <asp:Label ID="lblSearchLabel" runat="server" Text="lblSearchLabel"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Left" Font-Names="Verdana" Font-Size="Small"
                    ForeColor="#333333" GridLines="None" Width="100%" AllowPaging="true" OnItemCommand="DataGrid1_ItemCommand" OnPageIndexChanged="DataGrid1_PageIndexChanged" PageSize="15">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditItemStyle BackColor="#999999" />
                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" Mode="NumericPages" HorizontalAlign="Center" />
                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Left" BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:ButtonColumn CommandName="btnView" HeaderText="VIEW" Text="View"></asp:ButtonColumn>
                                <asp:BoundColumn DataField="PlanCode" HeaderText="Serial No"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Description" HeaderText="Item Description"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Quantity" HeaderText="Quantity"></asp:BoundColumn>
                                <asp:BoundColumn DataField="UnitCost" HeaderText="UnitCost" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="left" />
                                    <HeaderStyle HorizontalAlign="left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Total Cost" HeaderText="Total Cost" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="left" />
                                    <HeaderStyle HorizontalAlign="left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="MarketPrice" HeaderText="Price" ItemStyle-HorizontalAlign="left"
                         DataFormatString="{0:N0}"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
                                <asp:ButtonColumn CommandName="btnFiles" HeaderText="Files" Text="View/Add"></asp:ButtonColumn>
                            </Columns>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        </asp:DataGrid></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
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
                    <td style="width: 100%; text-align: center" class="InterFaceTableLeftRowUp">
                        REJECTED PLAN ITEM(S)</td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                        <asp:Button ID="Button1" runat="server" Text="Re-Submit" OnClick="btnResubmit_Click" />&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                        <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" Font-Bold="True"
                            OnCheckedChanged="CheckBox3_CheckedChanged" OnUnload="CheckBox3_Unload" Text="Select All" /></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        
                    <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Left" Font-Names="Verdana" Font-Size="Small"
                    ForeColor="#333333" GridLines="None" Width="100%" OnItemCommand="DataGrid2_ItemCommand">
                    <HeaderStyle HorizontalAlign="Left" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditItemStyle BackColor="#999999" />
                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" Mode="NumericPages" HorizontalAlign="Center" />
                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Left" BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundColumn DataField="PlanCode" HeaderText="Serial No">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Description" HeaderText="Description"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Quantity" HeaderText="Quantity"></asp:BoundColumn>
                                <asp:BoundColumn DataField="UnitCost" HeaderText="UnitCost" DataFormatString="{0:N0}"></asp:BoundColumn>
                                <asp:BoundColumn DataField="MarketPrice" HeaderText="Price" ItemStyle-HorizontalAlign="Right"
                         DataFormatString="{0:N0}"></asp:BoundColumn>
                                <asp:BoundColumn DataField="By" HeaderText="Rejected By"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Remark" HeaderText="Reason"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" CommandName="btnEdit" Visible="<%# EnableGridButtons() %>" runat="server">Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:ButtonColumn CommandName="btnFiles" HeaderText="Files" Text="View/Add"></asp:ButtonColumn>
                                 <asp:TemplateColumn HeaderText="Submit">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Approved") %>' 
                                        Visible='<%# EnableGridButtons() %>' Enabled='<%# EnableGridButtons() %>'
                                            Width="40px" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="2%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateColumn>
                            </Columns>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        </asp:DataGrid></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                        &nbsp;<asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Font-Bold="True"
                            OnCheckedChanged="chkSelect_CheckedChanged" Text="Select All" /></td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 26px; text-align: center" class="InterFaceTableLeftRowUp">
                        <asp:Button ID="btnResubmit" runat="server" Text="Re-Submit" OnClick="btnResubmit_Click" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View3" runat="server">
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
                                        GridLines="None" HorizontalAlign="Center" OnRowCommand="GridAttachments_RowCommand"
                                        OnRowCreated="GridAttachments_RowCreated" PageSize="15" Width="98%" OnSelectedIndexChanged="GridAttachments_SelectedIndexChanged">
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
                                                <ItemStyle CssClass="gridEditField" ForeColor="#003399" />
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:ButtonField>
                                        </Columns>
                                        <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                        <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
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
                        <asp:Label ID="lblPlanCode" runat="server" Text="0" Visible="False"></asp:Label><asp:Button
                            ID="btnSaveFile" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                            OnClick="btnSaveFile_Click" Text="SAVE " Width="80px" />
                        <asp:Button
                            ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                            OnClick="btnReturn_Click" Text="RETURN" Width="80px" /></td>
                </tr>
            </table>
        </asp:View><asp:View ID="View4" runat="server">
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
                        <asp:Label ID="lblReadOnly" runat="server" Font-Bold="True" Font-Names="Cambria"
                            Font-Size="11pt" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: center" colspan="3">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 80%">
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
                                    <asp:GridView ID="GridReadOnlyAttachments" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                        GridLines="None" HorizontalAlign="Center" OnRowCommand="GridReadOnlyAttachments_RowCommand" PageSize="15" Width="98%">
                                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                        <RowStyle CssClass="gridRowStyle" />
                                        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:ButtonField CommandName="ViewDetails" Text="View">
                                                <HeaderStyle CssClass="gridEditField" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                    Width="140px" />
                                            </asp:ButtonField>
                                        </Columns>
                                        <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                        <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                    </asp:GridView>
                                    <asp:Label ID="lblNoAttachments" runat="server" Font-Names="Cambria" Font-Size="11pt"
                                        ForeColor="Red" Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
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
                        <asp:Label ID="Label3" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Button
                            ID="Button4" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                            OnClick="btnReturn_Click" Text="RETURN" Width="80px" /></td>
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
</asp:Content>

