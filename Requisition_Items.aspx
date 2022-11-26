<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_Items.aspx.cs" Inherits="Requisition_PlannedItems" Title="ITEMS TO REQUISITION" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">PLANNED ITEMS TO REQUISITION</h6>
            </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>Search (PLAN CODE)</label>
                <asp:TextBox ID="txtSearch" runat="server" cssclass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>SEARCH (DESCRIPTION)</label>
                <asp:TextBox ID="txtDesc" runat="server" cssclass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>Procurement type</label>
                <asp:DropDownList ID="cboProcType" runat="server" CssClass="form-control"  OnDataBound="cboProcType_DataBound">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>SELECT</label>
                <asp:DropDownList ID="cboPlanned" runat="server" CssClass="form-control"
                                OnDataBound="cboProcType_DataBound" AutoPostBack="True" OnSelectedIndexChanged="cboPlanned_SelectedIndexChanged">
                                <asp:ListItem Value="1">Planned</asp:ListItem>
                                <asp:ListItem Value="0">Unplanned</asp:ListItem>
                            </asp:DropDownList>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>Quarter</label>
                <asp:DropDownList ID="cboQuarters" runat="server" CssClass="form-control"
                                OnDataBound="cboQuarters_DataBound">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>.</label>
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" class="btn btn-primary btn-user btn-block float-right"
                                Text="Search"/>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-5 mb-3 mb-sm-0">

            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <asp:Button ID="btnCreateItem" runat="server" Text="New Unplanned Item" OnClick="btnCreateItem_Click" class="btn btn-primary btn-user btn-block float-right"/>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-2 mb-3 mb-sm-0">

            </div>
            <div class="col-sm-5 mb-3 mb-sm-0">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Cambria" Text="Please Tick When Consolidating -"></asp:Label>
                            <asp:CheckBox ID="CheckBox1" runat="server" Font-Names="Cambria" Text="Consolidated Requisitions" />
            </div>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                                                PLANNED ITEM(S)</td>
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
                                                        <asp:BoundColumn DataField="PlanCode" HeaderText="Code"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Description" HeaderText="Description"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CostCenter" HeaderText="Cost Center"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="IsGroupItem" HeaderText="Group"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Quantity" HeaderText="Initial Qty"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CurrentQuantity" HeaderText="Current Qty"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Unit" HeaderText="Unit"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="UnitCost" HeaderText="Unit Cost" DataFormatString="{0:N0}">
                                                            <ItemStyle Width="120px" HorizontalAlign="Left" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="TotalCost" HeaderText="Total Cost" DataFormatString="{0:N0}">
                                                            <ItemStyle Width="120px" HorizontalAlign="Left" />
                                                        </asp:BoundColumn>
                                                        <asp:BoundColumn DataField="MarketPrice" HeaderText="Market Price for Plan" DataFormatString="{0:N0}">
                                                            <ItemStyle Width="120px" HorizontalAlign="Left" />
                                                        </asp:BoundColumn>
                                                        <asp:ButtonColumn CommandName="btnRequisition" HeaderText="Requisition"  Text="CREATE">
                                                            <ItemStyle Font-Bold="True" />
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
                                                UNPLANNED ITEM(S)</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                            <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Left" Font-Names="Verdana" Font-Size="Small"
                                                ForeColor="#333333" GridLines="None" Width="100%" OnItemCommand="DataGrid2_ItemCommand" AllowPaging="True" OnPageIndexChanged="DataGrid2_PageIndexChanged" PageSize="20">
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <EditItemStyle BackColor="#999999" />
                                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" Mode="NumericPages" HorizontalAlign="Center" />
                                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" VerticalAlign="Top" />
                                                <ItemStyle HorizontalAlign="Left" BackColor="#F7F6F3" ForeColor="#333333" />
                                                <Columns>
                                                    <asp:BoundColumn DataField="PlanCode" HeaderText="Code"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="CostCenter" HeaderText="Cost Center">
                                                        <ItemStyle Width="200px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Description" HeaderText="Description">
                                                        <ItemStyle Width="450px" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="IsGroupItem" HeaderText="Group"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Quantity" HeaderText="Initial Qty"></asp:BoundColumn>
                                                    <asp:BoundColumn DataField="CurrentQuantity" HeaderText="Current Qty">
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="UnitCost" HeaderText="Unit Cost" DataFormatString="{0:N0}">
                                                        <ItemStyle Width="120px"  HorizontalAlign="Right" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="TotalCost" HeaderText="Total Cost" DataFormatString="{0:N0}">
                                                        <ItemStyle Width="120px" HorizontalAlign="Right" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="MarketPrice" HeaderText="Market Price" DataFormatString="{0:N0}">
                                                            <ItemStyle Width="120px" HorizontalAlign="Right" />
                                                        </asp:BoundColumn>
                                                    <asp:ButtonColumn CommandName="btnRequisition" HeaderText="Requisition"  Text="CREATE">
                                                            <ItemStyle Font-Bold="True" />
                                                        </asp:ButtonColumn>
                                                </Columns>
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                            </asp:DataGrid></td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
    </div>
</asp:Content>

