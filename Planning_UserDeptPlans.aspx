<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Planning_UserDeptPlans.aspx.cs" Inherits="Planning_UserDeptPlans" Title="CONSOLIDATED USER DEPT PLAN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0">

            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <asp:Label ID="Label1" runat="server" Text="USER DEPARTMENT PLAN FOR THE FINANCIAL YEAR: "></asp:Label>
            </div>
        </div>
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>AREA</label>
                <asp:DropDownList ID="cboAreas" runat="server" AutoPostBack="True" OnDataBound="cboAreas_DataBound" CssClass="form-control"
                            OnSelectedIndexChanged="cboAreas_SelectedIndexChanged">
                        </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Cost Center</label>
                <asp:DropDownList ID="cboCostCenters" runat="server" CssClass="form-control"
                            OnDataBound="cboCostCenters_DataBound">
                        </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>FINANCIAL YEAR</label>
                <asp:DropDownList ID="cboFinancialYear" runat="server" CssClass="form-control"
                            OnDataBound="cboFinancialYear_DataBound">
                        </asp:DropDownList>
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
            <div class="col-sm-2 mb-3 mb-sm-0" ></div>
            <div class="col-sm-7 mb-3 mb-sm-0" id="preview">
                <asp:GridView ID="DeptPlans" runat="server" AllowPaging="True" class="table table-bordered table-responsive"
                    DataKeyNames="PlanID" EmptyDataText="NO DEPT PLANS AVAILABLE" HorizontalAlign="Center" OnRowCreated="GridCCenter_RowCreated" OnPageIndexChanging="GridCCenter_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None">
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
    </div>
</asp:Content>



