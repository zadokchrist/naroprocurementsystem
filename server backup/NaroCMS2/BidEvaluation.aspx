<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="BidEvaluation.aspx.cs" Inherits="Requisition_OfficerViewItems" Title="VIEW REQUISITION(S)" %>

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
                <h6 class="m-0 font-weight-bold text-primary">BID EVALUATION</h6>
            </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Pr number</label>
                <asp:TextBox ID="txtPrNumber" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>PROC. METHOD</label>
                <asp:DropDownList ID="cboProcMethod" runat="server" AutoPostBack="True" CssClass="form-control"
                                OnDataBound="cboProcMethod_DataBound">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>AREA</label>
                <asp:DropDownList ID="cboAreas" runat="server" AutoPostBack="True" CssClass="form-control"
                                OnDataBound="cboAreas_DataBound1" OnSelectedIndexChanged="cboAreas_SelectedIndexChanged">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Cost CENTER</label>
                <asp:DropDownList ID="cboCostCenters" runat="server" CssClass="form-control"
                                OnDataBound="cboCostCenter_DataBound">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Status</label>
                <asp:DropDownList ID="cbostatus" runat="server" CssClass="form-control">
                     <asp:ListItem Value="0">-- Select Status --</asp:ListItem>
                    <asp:ListItem Value="125" Text="Bids Submitted by Suppliers"></asp:ListItem>
                    <asp:ListItem Value="39" Text="Evaluation Pending Approval"></asp:ListItem>
                    <asp:ListItem Value="40" Text="Evaluation Pending MD Approval"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>&nbsp;</label>
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" class="btn btn-primary btn-user btn-block float-right" Text="Search"/>
            </div>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                                                PROCUREMENT(S) ASSIGNED TO YOU</td>
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
                                                        <asp:BoundColumn DataField="ScalaPRNumber" HeaderText="PR Number"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Subject" HeaderText="Subject">
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Method" HeaderText="Method"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CreationDate" HeaderText="Date" DataFormatString="{0:dd MMM yyyy}">
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="EstimatedCost" HeaderText="Est. Cost" DataFormatString="{0:N0}">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundColumn>
                                                        <asp:ButtonColumn CommandName="btnViewBid" HeaderText="Docs" Text="Prepared Docs">
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn CommandName="btnViewBidders" HeaderText="Bidders" Text="View Bidders">
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn CommandName="evaluateBids" HeaderText="Action" Text="Evaluate Bids">
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
                                <asp:View ID="View4" runat="server">
                                    <asp:Label ID="Label2" runat="server" Font-Names="Cambria" Font-Size="11pt" Visible="False"></asp:Label>
                                    <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4"  Font-Names="Verdana" Font-Size="Small"
                                                    ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid2_ItemCommand"
                                                    Width="100%" style="text-align: justify">
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <EditItemStyle BackColor="#999999" />
                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="BidderID" HeaderText="Bidder Id"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CompanyName" HeaderText="Supplier Name"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="PhysicalAddress" HeaderText="Physical Address">
                                                        </asp:BoundColumn>
                                                        <asp:ButtonColumn CommandName="btnViewBid" HeaderText="Docs" Text="Submited Bid Docs">
                                                        </asp:ButtonColumn>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                </asp:DataGrid>
                                    <div class="form-group row">
                                        <div class="col-sm-4 mb-3 mb-sm-0"></div>
                                        <div class="col-sm-3 mb-3 mb-sm-0">
                                            <asp:Button ID="Button1" runat="server" OnClick="btnReturn_Click" class="btn btn-primary btn-user btn-block float-right" Text="RETURN"/>
                                        </div>
                                    </div>
                                </asp:View>
                                <asp:View ID="View5" runat="server">
                                    <asp:Label ID="Label4" runat="server" Font-Names="Cambria" Font-Size="11pt" Visible="False"></asp:Label>
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                                        <tr>
                                            <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;" colspan="3">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                                                    <tr>
                                                        <td colspan="3" style="vertical-align: top; height: 19px; text-align: left">
                                                            <table align="center" cellpadding="0" cellspacing="0" style="border-right: #a4a2ca 1px solid; border-top: #a4a2ca 1px solid; border-left: #a4a2ca 1px solid; width: 90%; border-bottom: #a4a2ca 1px solid; background-color: #ffffff">

                                                                <tr>
                                                                    <td class="InterFaceTableLeftRowUp">Document Type</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:DropDownList ID="cboDocType" runat="server"
                                                                            CssClass="form-control"
                                                                            Width="80%" OnDataBound="cboDocType_DataBound">
                                                                        </asp:DropDownList>
                                                                    </td>

                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 19px">
                                                                        <br />
                                                                        <p id="upload-area">
                                                                            <input id="File2" runat="server" size="60" type="file" />
                                                                        </p>
                                                                        <p>
                                                                            <input id="ButtonAdd" onclick="addFileUploadBox()" type="button" value="Add a file" />
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Button ID="btnUpload" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" Text="UPLOAD " Width="80px" OnClick="btnUpload_Click1" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 2%; height: 280px;"></td>
                                            <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;" colspan="3">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                                                    <tr>
                                                        <td colspan="3">
                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                                                <tr>
                                                                    <td class="InterfaceHeaderLabel3" style="height: 18px">Document(s)</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="height: 16px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:GridView ID="GridView1" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                                                GridLines="None" HorizontalAlign="Center" AutoGenerateColumns="false"
                                                                PageSize="15" Width="98%" OnRowCommand="GridView1_RowCommand" CellPadding="4" ForeColor="#333333">
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
                                                            <asp:Label ID="Label3" runat="server" Font-Names="Cambria" Font-Size="11pt"
                                                                ForeColor="Red" Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="height: 16px"></td>
                                                    </tr>
                                                </table>
                                                <asp:Label ID="lblAttachRefNo" runat="server" Text="0" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="form-group row">
                                        <div class="col-sm-3 mb-3 mb-sm-0"></div>
                                         <div class="col-sm-2 mb-3 mb-sm-0">Selected Bidder to Award</div>
                                         <div class="col-sm-3 mb-3 mb-sm-0">
                                             <asp:DropDownList ID="bidderstoselect" runat="server" CssClass="form-control"
                                                OnDataBound="bidderstoselect_DataBound">
                                            </asp:DropDownList>
                                         </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-3 mb-3 mb-sm-0"></div>
                                        <div class="col-sm-2 mb-3 mb-sm-0">
                                            <asp:Button ID="Button3" runat="server" OnClick="btnReturn_Click" class="btn btn-primary btn-user btn-block float-right" Text="RETURN"/>
                                        </div>
                                        <div class="col-sm-3 mb-3 mb-sm-0">
                                            <asp:Button ID="submitevaluation" runat="server" OnClick="submitevaluation_Click" class="btn btn-primary btn-user btn-block float-right" Text="Submit For Approval"/>
                                        </div>
                                    </div>
                                </asp:View>
                                <asp:View ID="View6" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                                                PROCUREMENT(S) ASSIGNED TO YOU</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:DataGrid ID="DataGrid3" runat="server" AutoGenerateColumns="False" CellPadding="4"  Font-Names="Verdana" Font-Size="Small"
                                                    ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid3_ItemCommand"
                                                    Width="100%" style="text-align: justify">
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <EditItemStyle BackColor="#999999" />
                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="ScalaPRNumber" HeaderText="PR Number"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Subject" HeaderText="Subject">
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Method" HeaderText="Method"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CreationDate" HeaderText="Date" DataFormatString="{0:dd MMM yyyy}">
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="EstimatedCost" HeaderText="Est. Cost" DataFormatString="{0:N0}">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundColumn>
                                                        <asp:ButtonColumn CommandName="btnViewBid" HeaderText="Docs" Text="Prepared Docs">
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn CommandName="btnViewBidders" HeaderText="Bidders" Text="View Bidders">
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn CommandName="btnApprove" HeaderText="Action" Text="Approve">
                                                        </asp:ButtonColumn>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                </asp:DataGrid></td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
        
    </div>
 
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







