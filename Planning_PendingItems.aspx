<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Planning_PendingItems1.aspx.cs" Inherits="Planning_PendingItems" Title="PENDING PLAN ITEMS" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <label>Search (DESCRIPTION)</label>
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <label>Procurement type</label>
                        <asp:DropDownList ID="cboProcType" runat="server" CssClass="form-control" OnDataBound="cboProcType_DataBound" Width="95%">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <label>QUARTER</label>
                        <asp:DropDownList ID="cboQuarter" runat="server" CssClass="form-control"
                            OnDataBound="cboQuarter_DataBound">
                        </asp:DropDownList>
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <label>.</label>
                        <asp:Button ID="btnOK" runat="server" Font-Size="9pt" OnClick="btnOK_Click" Text="Search" CssClass="btn btn-primary btn-user btn-block float-right" />
                    </div>
                </div>
    <table style="width: 100%">
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="height: 20px;"></td>
        </tr>
            <tr>
                <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                    PENDING PLAN ITEM(S)</td>
            </tr>
        <tr>
            <td style="width: 100%; text-align: right">
            </td>
        </tr>
        <tr>
            <td style="width: 100%; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 65%">
                    <tr>
                        <td class="InterFaceTableLeftRow" style="width: 25%; height: 30px">
                            Submit Plans To:</td>
                        <td style="vertical-align: middle; width: 50%; height: 30px; text-align: left">
                            &nbsp;<asp:DropDownList ID="cboTopAreaManagers" runat="server" OnDataBound="cboTopAreaManagers_DataBound"
                                Width="80%" AutoPostBack="True" OnSelectedIndexChanged="cboTopAreaManagers_SelectedIndexChanged1" Enabled="false">
                            </asp:DropDownList></td>
                        <td style="vertical-align: middle; width: 25%; height: 30px; text-align: left">
                            <asp:Button ID="Button2" runat="server" Font-Bold="True" OnClick="btnSubmit_Click"
                    Text="Submit" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%; text-align: right">
                <asp:CheckBox ID="chkSelect" runat="server" Font-Bold="True" Text="Select All" AutoPostBack="True" OnCheckedChanged="chkSelect_CheckedChanged" /></td>
        </tr>
        <tr>
            <td style="width: 100%; text-align: center">
                <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Left" Font-Names="Verdana" Font-Size="Small"
                    ForeColor="#333333" GridLines="None" Width="100%" OnItemCommand="DataGrid1_ItemCommand">
                    <HeaderStyle HorizontalAlign="Left" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditItemStyle BackColor="#999999" />
                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" Mode="NumericPages" HorizontalAlign="Center" />
                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Left" BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:ButtonColumn CommandName="btnView" HeaderText="VIEW" Text="View"></asp:ButtonColumn>
                        <asp:ButtonColumn CommandName="btnEdit" HeaderText="EDIT" Text="Edit"></asp:ButtonColumn>
                        <asp:ButtonColumn CommandName="btnDelete" HeaderText="DELETE" Text="Delete"></asp:ButtonColumn>
                        <asp:BoundColumn DataField="PlanCode" HeaderText="Serial No"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Description" HeaderText="Description"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ProcurementType" HeaderText="Proc Type"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Quarter" HeaderText="Quarter"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Quantity" HeaderText="Qty"></asp:BoundColumn>
                        <asp:BoundColumn DataField="UnitCost" HeaderText="Unit Cost" ItemStyle-HorizontalAlign="Left"
                         DataFormatString="{0:N0}"></asp:BoundColumn>
                         <asp:BoundColumn DataField="MarketPrice" HeaderText="Market Price" ItemStyle-HorizontalAlign="Left"
                         DataFormatString="{0:N0}"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Total Cost" HeaderText="Total Cost" ItemStyle-HorizontalAlign="Left"
                         DataFormatString="{0:N0}"></asp:BoundColumn>
                        <asp:ButtonColumn CommandName="btnFiles" HeaderText="FILES" Text="View/Add"></asp:ButtonColumn>
                        <asp:TemplateColumn HeaderText="Submit">
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Approved") %>'
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
                <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="True" Text="Select All" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" /></td>
        </tr>
        <tr>
            <td style="width: 100%; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 65%">
                    <tr>
                        <td class="InterFaceTableLeftRow" style="width: 25%; height: 30px">
                            Submit Plans To:</td>
                        <td style="vertical-align: middle; width: 50%; height: 30px; text-align: left">
                            &nbsp;<asp:DropDownList ID="cboAreaManagers" runat="server" OnDataBound="cboAreaManagers_DataBound" Enabled="false"
                                Width="80%" AutoPostBack="True" OnSelectedIndexChanged="cboAreaManagers_SelectedIndexChanged">
                            </asp:DropDownList></td>
                        <td style="vertical-align: middle; width: 25%; height: 30px; text-align: left">
                <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="btnSubmit_Click"
                    Text="Submit" /></td>
                    </tr>
                </table>
                </td>
        </tr>
    </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
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
                                        OnRowCreated="GridAttachments_RowCreated" OnSelectedIndexChanged="GridAttachments_SelectedIndexChanged"
                                        PageSize="15" Width="98%">
                                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                        <RowStyle CssClass="gridRowStyle" />
                                        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:ButtonField CommandName="ViewDetails" Text="View">
                                                <HeaderStyle CssClass="gridEditField" />
                                                <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                    Width="140px" />
                                            </asp:ButtonField>
                                            <asp:ButtonField CommandName="btnRemove" Text="Remove">
                                                <ItemStyle CssClass="gridEditField" ForeColor="#003399" />
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
                        <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                            OnClick="btnReturn_Click" Text="RETURN" Width="80px" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View3" runat="server">
                    <table cellpadding="0" cellspacing="0" class="style12">
            <tr>
                <td colspan="2" style="height: 19px">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <table align ="center" cellpadding="0" cellspacing="0" style="width: 70%">
                        <tr>
                            <td class="InterfaceHeaderLabel" style="height: 20px">
                                <asp:Label ID="lblDeleteHeader" runat="server" Text="Delete Plan : "></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td  colspan="2" style="height: 10px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <table align="center" cellpadding="0" cellspacing="0" style="width: 70%">
                        <tr>
                            <td class="InterFaceTableLeftRowUp">Plan Code</td>
                            <td class="InterFaceTableRightRowUp">
                                <asp:Label ID="lblDeleteStatusLabel" runat="server" Visible="false" Text="StatusID"></asp:Label>
                                <asp:Label ID="lblDeletePlanLabel" runat="server" Text="Plan Code" Width="290px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="InterFaceTableLeftRowUp">Comment</td>
                            <td class="InterFaceTableRightRowUp">
                                <asp:TextBox ID="txtComment" runat="server" Rows="6" TextMode="MultiLine" Width="343px" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="btnSubmitComment" runat="server" Text="Delete Plan" OnClick="btnSubmitComment_Click" />
                                <asp:Button ID="btnReturnToView" runat="server" Text="Return" OnClick="btnReturnToView_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </asp:View>
        <asp:View ID="View4" runat="server">
               <table style="width: 100%">
                    <tr>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;"></td>
                    </tr>
                        <tr>
                            <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                                NO PLAN ITEM(S) FOUND</td>
                        </tr>
                   <tr>
                       <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                       </td>
                   </tr>
                   <tr>
                       <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                           <asp:Label ID="lblEmpty" runat="server" Font-Bold="True" ForeColor="Red" Text="."></asp:Label></td>
                   </tr>
                    <tr>
                        <td style="width: 100%; text-align: right">
                        </td>
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
    
</asp:Content>



