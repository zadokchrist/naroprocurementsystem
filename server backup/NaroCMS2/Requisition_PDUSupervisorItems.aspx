<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_PDUSupervisorItems.aspx.cs" Inherits="Requisition_OfficerViewItems" Title="VIEW REQUISITION(S)" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">ACTIVITY SCHEDULE(S) ASSIGNED TO YOU</h6>
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
                <label>Pr number</label>
                <asp:TextBox ID="txtPrNumber" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label> PROCUREMENT METHOD</label>
                <asp:DropDownList ID="cboProcurementMethod" runat="server" CssClass="form-control"
                                OnDataBound="cboProcurementMethod_DataBound" >
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>PDU CATEGORY</label>
                <asp:DropDownList ID="cboPDUCategory" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0">-- ALL DEPARTMENTS --</asp:ListItem>
                                <asp:ListItem Value="1">SMALL PROCUREMENT</asp:ListItem>
                                <asp:ListItem Value="2">LARGE PROCUREMENT</asp:ListItem>
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>STATUS</label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                    <asp:ListItem Value="23" Text="Assigned"></asp:ListItem>
                    <asp:ListItem Value="27" Text="Docs & Shortlist saved"></asp:ListItem>
                    <asp:ListItem Value="41" Text="Docs Bids Prepared and Waiting for approval"></asp:ListItem>
                    <asp:ListItem Value="26" Text="Docs & Shortlist submitted to LPM/SPM"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>.</label>
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" class="btn btn-primary btn-user btn-block float-right" Text="Search"/>
            </div>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                                                REQUISITION(S) ASSIGNED TO YOU</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4"  Font-Names="Verdana" Font-Size="Small"
                                                    ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid1_ItemCommand"
                                                    Width="100%" style="text-align: justify">
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <EditItemStyle BackColor="#999999" />
                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="ReferenceNo" HeaderText="PR Number"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="SubjectOfProcurement" HeaderText="Subject">
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Method" HeaderText="Method"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="SubmissionDate" HeaderText="Date" DataFormatString="{0:dd MMM yyyy}">
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="EstimatedCost" HeaderText="Est. Cost" DataFormatString="{0:N0}">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="PlanSubmittedBy" HeaderText="Submitted By"></asp:BoundColumn>
                                                        <asp:ButtonColumn CommandName="btnViewBid" HeaderText="Docs" Text="Prepared Docs">
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn CommandName="btnApprove" HeaderText="Action" Text="Approve">
                                                        </asp:ButtonColumn>
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
                                                NO RECORD FOUND MESSAGE</td>
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
                                    <asp:Label ID="Label1" runat="server" Font-Names="Cambria" Font-Size="11pt" Visible="False"></asp:Label>
                                    <asp:GridView ID="GridView2" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                            GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false"
                                            PageSize="15" Width="98%" OnRowCommand="GridView2_RowCommand" CellPadding="4" ForeColor="#333333">
                                            <AlternatingRowStyle BackColor="White" CssClass="gridAlternatingRowStyle"></AlternatingRowStyle>
                                            <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                                            <HeaderStyle HorizontalAlign="Left" BackColor="#507CD1" CssClass="gridHeaderStyle" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                            <PagerSettings Position="TopAndBottom" />
                                            <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                                            <RowStyle CssClass="gridRowStyle" BackColor="#EFF3FB" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                                            <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                                            <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                                            <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                                            <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                                            <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                            <Columns>

                                                <asp:BoundField HeaderText="FileID" DataField="FileID" />
                                                <asp:BoundField HeaderText="FileName" DataField="FileName" />
                                                <asp:BoundField HeaderText="Document Type" DataField="DocumentType" />
                                                <asp:BoundField HeaderText="IsRemoveable" DataField="IsRemoveable" Visible="false" />
                                                <asp:ButtonField CommandName="ViewDetails" Text="View">
                                                    <HeaderStyle CssClass="gridEditField" />
                                                    <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center" />
                                                </asp:ButtonField>
                                                <asp:ButtonField CommandName="btnRemove" runat="server" Text="Remove">
                                                    <ItemStyle CssClass="gridEditField" Width="80px" ForeColor="OrangeRed" />
                                                </asp:ButtonField>
                                            </Columns>
                                            <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                            <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                        </asp:GridView>
                                        <asp:Label ID="Label6" runat="server" Font-Names="Cambria" Font-Size="11pt"
                                            ForeColor="Red" Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label>
                                    <div class="form-group row">
                                        <div class="col-sm-4 mb-3 mb-sm-0"></div>
                                        <div class="col-sm-3 mb-3 mb-sm-0">
                                            <asp:Button ID="return" runat="server" OnClick="btnReturn_Click" class="btn btn-primary btn-user btn-block float-right" Text="RETURN"/>
                                        </div>
                                    </div>
                                </asp:View>
                                &nbsp;&nbsp;
                            </asp:MultiView>
        
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







