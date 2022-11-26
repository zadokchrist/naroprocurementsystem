<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Planning_Procu.aspx.cs" Inherits="Planning_Procu" Title="PLAN ITEMS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <script language="javascript" type="text/javascript">
// <!CDATA[

function TABLE1_onclick() {

}
// ]]>
</script>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>AREA</label>
                <asp:DropDownList id="DropDownList1" runat="server" Width="95%" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" OnDataBound="DropDownList1_DataBound" CssClass="form-control">
                        </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Cost Center</label>
                <asp:DropDownList id="cboCostCenters" runat="server" AutoPostBack="True" OnDataBound="cboCostCenters_DataBound" CssClass="form-control">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Procurement type</label>
                <asp:DropDownList id="cboProcType" runat="server" Width="95%" OnDataBound="cboProcType_DataBound" CssClass="form-control">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>.</label>
                <asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Text="Search" class="btn btn-primary btn-user btn-block float-right"></asp:Button>
            </div>
        </div>
    </div>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0"></div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Grand Total Cost"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="."></asp:Label>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0"></div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" Font-Bold="True"
                            OnCheckedChanged="chkSelect_CheckedChanged" Text="Select All" />
                </div>
            </div>
            <div class="form-group row">
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
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Total Cost" HeaderText="Total Cost" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="MarketPrice" HeaderText="Market Price" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="left" />
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
                        </asp:DataGrid>
            </div>
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0"></div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Font-Bold="True"
                            OnCheckedChanged="CheckBox2_CheckedChanged" Text="Select All" />
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-15 mb-3 mb-sm-0">
                    <asp:RadioButtonList ID="rbnApproval" runat="server" CssClass="form-control">
                        <asp:ListItem Value="1">Approve and Consolidate Selected Plan Items</asp:ListItem>
                        <asp:ListItem Value="2">Reject Selected Plan Items</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <label>Comment (If Required)</label>
                </div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0">
                    
                </div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="btnSubmit_Click" class="btn btn-primary btn-user btn-block float-right"
                            Text="SUBMIT PLAN ITEMS" />
                </div>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0">

                </div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    ATTACHMENTS
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0">

                </div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:Label ID="lblHeaderMsg" runat="server" Font-Bold="True" Font-Names="Cambria"
                            Font-Size="11pt" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0">

                </div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    View Attachments
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-15 mb-3 mb-sm-0">
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
                                                    Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0">

                </div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:Button ID="Button2" runat="server" Font-Bold="True" OnClick="btnReturn_Click" class="btn btn-primary btn-user btn-block float-right" Text="RETURN"/>
                    <asp:Label ID="lblPlanCode" runat="server" Text="0" Visible="False"></asp:Label>
                </div>
            </div>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <table style="width: 100%" id="Table2" onclick="return TABLE1_onclick()">
            <tr>
                <td style="width: 100%; text-align: center">
                    <asp:Label ID="lblQn" runat="server" ForeColor="Maroon" Text="." Font-Bold="True"></asp:Label><asp:Button
                        ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" /><asp:Button ID="btnNo"
                            runat="server" OnClick="btnNo_Click" Text="No" /></td>
            </tr>
        </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>


