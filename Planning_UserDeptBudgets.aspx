<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Planning_UserDeptBudgets.aspx.cs" Inherits="Planning_UserDeptBudgets" Title="COST CENTER BUDGETS" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                <asp:Label ID="Label1" runat="server" Text="COST CENTER BUDGETS FOR THE FINANCIAL YEAR: "></asp:Label>
            </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-1 mb-3 mb-sm-0"></div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>AREA</label>
                <asp:DropDownList ID="cboAreas" runat="server" AutoPostBack="True" OnDataBound="cboAreas_DataBound" CssClass="form-control"
                            OnSelectedIndexChanged="cboAreas_SelectedIndexChanged">
                        </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Cost Center</label>
                <asp:DropDownList ID="cboCostCenters" runat="server" CssClass="form-control"
                            OnDataBound="cboCostCenters_DataBound" AutoPostBack="True" OnSelectedIndexChanged="cboCostCenters_SelectedIndexChanged">
                        </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>FINANCIAL YEAR</label>
                <asp:DropDownList ID="cboFinancialYear" runat="server" CssClass="form-control"
                            OnDataBound="cboFinancialYear_DataBound" AutoPostBack="True" OnSelectedIndexChanged="cboFinancialYear_SelectedIndexChanged">
                        </asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-12 mb-3 mb-sm-0">
                <asp:MultiView ID="Multiview1" runat="server">
                    <asp:View runat="server" ID="view1">
                        <tr >
                            <td  align="center" style="height: 10px">
                                            <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Height="23px" OnClick="btnOK_Click"
                                                Text="Download template" />
                                            <asp:Button ID="btnPrint" runat="server" Font-Size="9pt" Height="23px" OnClick="btnPrint_Click"
                                                Text="Upload file" Width="100px" /></td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top; height: 19px; text-align: left">
                <table align="center" style="width: 90%; border-right: #617da6 1px solid; border-top: #617da6 1px solid; border-left: #617da6 1px solid; border-bottom: #617da6 1px solid; height: 100px;">
                    <tr>
                        <td style="width: 100%; vertical-align: top; text-align: left;">


                            <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                                ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid1_ItemCommand" AllowPaging="True" PageSize="20"
                                Width="100%" Style="text-align: justify" OnPageIndexChanged="DataGrid1_PageIndexChanged">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#999999" />
                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Mode="NumericPages" />
                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                <Columns>
                                    <asp:BoundColumn DataField="RecordID" HeaderText="RecordID" Visible="False"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="BudgetCode" HeaderText="Budget Code"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="CostCenterCode" HeaderText="Cost Center Code"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="CostCenterName" HeaderText="Cost center"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Description" HeaderText="Amount" DataFormatString="{0:N0}"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Spent" HeaderText="Spent " DataFormatString="{0:N0}"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Balance" HeaderText="Balance" DataFormatString="{0:N0}">
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:ButtonColumn CommandName="btnRemove" HeaderText="" Text="Remove" ItemStyle-ForeColor="Red">
                                        <ItemStyle ForeColor="Red" />
                                    </asp:ButtonColumn>
                                </Columns>
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            </asp:DataGrid>
                        </td>
                    </tr>
                </table>
            </td>
                        </tr>
                    </asp:View>
                    <asp:View runat="server" ID="view2">   
           

                <td align="center" style="height: 10px">

                    <asp:FileUpload ID="fileUpload1" runat="server"/>
                    </td>
                <tr>
                 <br />
                <tr>
                 <td align="center" style="height: 10px">
                     <asp:Label runat="server" ID="lblResult" ForeColor="Red" Text="."></asp:Label>
                     </td>
            </tr>     
            
                
                <tr align="center" >
                <td style="height: 10px">
                    <asp:Button ID="btnConfirm" runat="server" Font-Size="9pt" Height="23px"
                        Text="Confirm & Upload budgets" OnClick="btnConfirm_Click" />
                    <asp:Button ID="btnCancel" runat="server" Font-Size="9pt" Height="23px"
                        Text="Cancel" Width="100px" OnClick="btnCancel_Click" /></td>
            </tr>
        </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
</asp:Content>



