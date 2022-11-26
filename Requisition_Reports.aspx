<%@ Page Title="" Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_Reports.aspx.cs" Inherits="Requisition_Reports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Complied List of Procurements</h6>
            </div>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>Scala PR Number</label>
                <asp:TextBox ID="txtPrNumber" runat="server" autocomplete="off" Font-Bold="True" ForeColor="Firebrick" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>Budget Code</label>
                <asp:TextBox ID="txtBugetCode" runat="server" autocomplete="off" Font-Bold="True" ForeColor="Firebrick"  CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>Financial Year</label>
                <asp:DropDownList ID="cboFinYear" runat="server" CssClass="form-control" OnDataBound="cboFinYear_DataBound">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>Cost CENTER</label>
                <asp:DropDownList ID="cboCostCenters" runat="server" CssClass="form-control" OnDataBound="cboCostCenter_DataBound">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>.</label>
                <asp:DropDownList ID="cboStatus" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0">-- Select Status --</asp:ListItem>
                    <asp:ListItem Value="1">Approved Requisitions</asp:ListItem>
                    <asp:ListItem Value="2">Requisitions Cancelled by CC & Deleted </asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>.</label>
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="Search" class="btn btn-primary btn-user btn-block float-right"/>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-2 mb-3 mb-sm-0">
                <asp:Button ID="btnPrint" runat="server" Enabled="false" OnClick="btnPrint_Click" class="btn btn-primary btn-user btn-block float-right"
                            Text="Download PDF Report"/>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <asp:Button ID="btnPrint2" runat="server" Enabled="false" OnClick="btnPrint2_Click" class="btn btn-primary btn-user btn-block float-right"
                        Text="Download Excel Report"/>
            </div>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                                               Complied List of EProcurement Cost Center Expenditure </td>

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
                                                        <asp:BoundColumn DataField="ScalaPRNumber" HeaderText="PR Number" Visible="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="BudgetCode" HeaderText="Budget Code" Visible="True"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CostCenterName" HeaderText="Cost Center"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Subject" HeaderText="Subject"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ApprovedAmount" HeaderText="Amount Approved On Budget "></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="RequisitionToDate" HeaderText="Requisition Amount ToDate"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Expenditure"     HeaderText="Expenditure To date"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="BudgetBalance"     HeaderText="Balance On Budget"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CreationDate" HeaderText="Date Created" DataFormatString="{0:dd MMM yyyy}">    
                                                        </asp:BoundColumn>
                                                       
                                                     
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
                              
                            </asp:MultiView>
        <asp:Label ID="lblPD_Code" runat="server" Text="0" Visible="False"></asp:Label>
    </div> 
</asp:Content>
