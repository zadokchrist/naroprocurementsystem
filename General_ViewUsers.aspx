<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" EnableEventValidation="false"  AutoEventWireup="true" CodeFile="General_ViewUsers.aspx.cs" Inherits="General_ViewUsers" Title="SYSTEM USERS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card shadow mb-4">
        <div class="text-center">
            <h6 class="m-0 font-weight-bold text-primary">List of System Users</h6>
        </div>
        <div class=" row">
            <div class="col-sm-2 mb-3 mb-sm-0"></div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Search String(Names)</label>
                <asp:TextBox ID="txtSearch" class="form-control" runat="server"></asp:TextBox>

            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Access Levels</label>
                <asp:DropDownList ID="cboAreas" runat="server" AutoPostBack="True" class="form-control" OnDataBound="cboAreas_DataBound" OnSelectedIndexChanged="cboAreas_SelectedIndexChanged" />
            </div>
            <div class="col-sm-3">
                <label>.</label>
                <asp:Button ID="btnOK" runat="server" class="btn btn-primary btn-user btn-block" OnClick="btnOK_Click"
                    Text="Search" />
            </div>
        </div>

        <div class="card-body">
            <asp:DataGrid ID="DataGrid1" runat="server" DataKeyField="Code" AllowPaging="True" OnPageIndexChanged="DataGrid1_PageIndexChanged" AutoGenerateColumns="False" class="table table-striped table-bordered zero-configuration" OnItemCommand="DataGrid2_ItemCommand" HorizontalAlign="Center">
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditItemStyle BackColor="#999999" />
                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                <Columns>
                    <asp:BoundColumn DataField="Code" HeaderText="Code" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn DataField="username" HeaderText="Username"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Names" HeaderText="Name"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Email" HeaderText="Email"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Level" HeaderText="AccessLevel"></asp:BoundColumn>
                    <asp:BoundColumn DataField="Active" HeaderText="Active"></asp:BoundColumn>
                    <asp:ButtonColumn CommandName="btnenable" HeaderText="Action" Text="Enable/Disable">
                        <ItemStyle CssClass="btn-secondary " ForeColor="White"/>
                    </asp:ButtonColumn>
                    <%--<asp:ButtonColumn CommandName="btnEdit" HeaderText="Edit" Text="Edit"></asp:ButtonColumn>--%>

                    <asp:ButtonColumn CommandName="btnreset" HeaderText="Reset" Text="Reset Password">
                        <ItemStyle CssClass=" btn-dark " ForeColor="White"/>
                    </asp:ButtonColumn>
                </Columns>
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
            </asp:DataGrid>
    </div>

    </div>
</asp:Content>