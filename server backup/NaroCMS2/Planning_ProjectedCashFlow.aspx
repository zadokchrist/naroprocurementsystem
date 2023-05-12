<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Planning_ProjectedCashFlow.aspx.cs" Inherits="Planning_ExpectedExpenditure" Title="EXPECTED EXPENDITURE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-4 mb-3 mb-sm-0"></div>
            <div class="col-sm-14 mb-3 mb-sm-0">
            <asp:Label ID="Label1" runat="server" Text="PROJECTED CASHFLOW FOR THE FINANCIAL YEAR: 2011 - 2012"></asp:Label>
        </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>AREA</label>
                <asp:DropDownList ID="cboAreas" runat="server" AutoPostBack="True" OnDataBound="cboAreas_DataBound" OnSelectedIndexChanged="cboAreas_SelectedIndexChanged" class="form-control">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Cost Center</label>
                <asp:DropDownList ID="cboCostCenters" runat="server" CssClass="form-control"
                                OnDataBound="cboCostCenters_DataBound" >
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>FINANCIAL YEAR</label>
                <asp:DropDownList ID="cboFinancialYear" runat="server" CssClass="form-control"
                                OnDataBound="cboFinancialYear_DataBound">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>TICK</label><br />
                <asp:CheckBox ID="chkQuarter" runat="server" Font-Bold="True" Text="By Quarter" />
            </div>
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-3 mb-3 mb-sm-0">
            <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" Text="Preview" class="btn btn-primary btn-user btn-block float-right"/>
        </div>
        <div class="col-sm-3 mb-3 mb-sm-0">
            <asp:Button ID="btnPrint" runat="server" OnClick="btnPrint_Click" Text="Download Report" class="btn btn-primary btn-user btn-block float-right"/>
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-12 mb-3 mb-sm-0">
            <asp:GridView ID="ProjectedCashFlow" runat="server" AllowPaging="True" class="table table-bordered table-responsive"
                     EmptyDataText="NO PROJECTED CASH FLOW AVAILABLE" HorizontalAlign="Center" OnRowCreated="GridCCenter_RowCreated" OnPageIndexChanging="GridCCenter_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" CssClass="gridAlternatingRowStyle"></AlternatingRowStyle>

                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="gridRowStyle" />
                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></FooterStyle>

                    <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Position="TopAndBottom"></PagerSettings>

                    <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                    <PagerStyle HorizontalAlign="Center" BackColor="#FFCC66" ForeColor="#333333" />
                    <RowStyle BackColor="#FFFBD6" CssClass="gridRowStyle" ForeColor="#333333"></RowStyle>

                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy"></SelectedRowStyle>

                    <SortedAscendingCellStyle BackColor="#FDF5AC"></SortedAscendingCellStyle>

                    <SortedAscendingHeaderStyle BackColor="#4D0000"></SortedAscendingHeaderStyle>

                    <SortedDescendingCellStyle BackColor="#FCF6C0"></SortedDescendingCellStyle>

                    <SortedDescendingHeaderStyle BackColor="#820000"></SortedDescendingHeaderStyle>
                </asp:GridView>
        </div>
    </div>

</asp:Content>



