<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_FinanceViewItems.aspx.cs" Inherits="Requisition_FinanceViewItems" Title="VIEW REQUISITION(S)" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                REQUISITION ITEM(S) SENT TO YOU
            </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Search START Date</label>
                <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>SEARCH END DATE</label>
                <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Procurement type</label>
                <asp:DropDownList ID="cboProcType" runat="server" CssClass="form-control"
                                OnDataBound="cboProcType_DataBound">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>AREA</label>
                <asp:DropDownList ID="cboAreas" runat="server" AutoPostBack="True" CssClass="form-control"
                                OnDataBound="cboAreas_DataBound" OnSelectedIndexChanged="cboAreas_SelectedIndexChanged">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Cost CENTER</label>
                <asp:DropDownList ID="cboCostCenters" runat="server" CssClass="form-control"
                                OnDataBound="cboCostCenter_DataBound">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>.</label>
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" class="btn btn-primary btn-user btn-block float-right"
                                Text="Search" />
            </div>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                                                REQUISITION(S) SENT TO YOU FOR FUND APPROVAL</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                                                    ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid1_ItemCommand" Width="100%" style="text-align: justify">
                                                    <FooterStyle Font-Bold="True" ForeColor="White" />
                                                    <EditItemStyle BackColor="#999999" />
                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" Mode="NumericPages" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" VerticalAlign="Top" />
                                                    <ItemStyle HorizontalAlign="Left" BackColor="#F7F6F3" ForeColor="#333333" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="RecordID" HeaderText="RecordID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="PD_Code" HeaderText="PD Code" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CostCenterName" HeaderText="Cost Center"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Subject" HeaderText="Subject"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ProcurementType" HeaderText="Type"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CreationDate" HeaderText="Date" DataFormatString="{0:dd MMM yyyy}">
                                                            <ItemStyle Width="50px" />
                                                        </asp:BoundColumn>
                                                         <asp:BoundColumn DataField="IsProject" HeaderText="IS PROJECT" Visible ="false"></asp:BoundColumn>
                                                         <asp:BoundColumn DataField="ProjectTotalCost" HeaderText="Project Total Cost" Visible="false"></asp:BoundColumn>
                                                        <asp:ButtonColumn CommandName="btnFiles" HeaderText="FILES" Text="View"></asp:ButtonColumn>
                                                        <asp:ButtonColumn CommandName="btnAction" HeaderText="Action" Text="Approve/Reject"></asp:ButtonColumn>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                </asp:DataGrid></td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                                                NO RECORDS FOUND</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                                                <asp:Label ID="lblEmpty" runat="server" Font-Bold="True" ForeColor="Red" Text="."></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View3" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td colspan="1" style="width: 100%; height: 21px; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" colspan="1" style="width: 100%; text-align: center">
                                                ATTACHMENT(S)</td>
                                        </tr>
                                        <tr>
                                            <td colspan="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" style="width: 100%; text-align: center">
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
                                            <td colspan="1" style="vertical-align: top; width: 100%; text-align: center">
                                                <asp:Label ID="Label1" runat="server" Text="0" Visible="False"></asp:Label>
                                                <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                    OnClick="btnReturn_Click" Text="RETURN" Width="80px" /></td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                 <asp:Label ID="lblPD_Code" runat="server" Text="0" Visible="False"></asp:Label>
            </div>
        </div>
    </div>
    <cc1:calendarextender id="CalendarExtender1" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtStartDate"></cc1:calendarextender>
    <cc1:calendarextender id="CalendarExtender2" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtEndDate"></cc1:calendarextender>
 
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

