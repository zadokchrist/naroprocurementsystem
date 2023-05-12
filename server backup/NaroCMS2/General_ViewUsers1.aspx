<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="General_ViewUsers1.aspx.cs" Inherits="General_ViewUsers" Title="SYSTEM USERS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td style="width: 98%; height: 2px">
            </td>
        </tr>
        <tr>
            <td style="width: 98%; height: 15px">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 80%">
                    <tr>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            Search String(Names)</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            Area</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            COST CENTER</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                        </td>
                    </tr>
                    <tr>
                        <td class="ddcolortabsline2" colspan="4" style="vertical-align: middle; text-align: center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            &nbsp;<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:DropDownList ID="cboAreas" runat="server" AutoPostBack="True" CssClass="InterfaceDropdownList"
                                OnDataBound="cboAreas_DataBound" OnSelectedIndexChanged="cboAreas_SelectedIndexChanged"
                                Width="95%">
                            </asp:DropDownList></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            &nbsp;<asp:DropDownList ID="cboCostCenter" runat="server" CssClass="InterfaceDropdownList"
                                OnDataBound="cboCostCenter_DataBound" Width="85%">
                            </asp:DropDownList></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Height="23px" OnClick="btnOK_Click"
                                Text="Search" Width="85px" />&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 98%">
            </td>
        </tr>
        <tr>
            <td style="width: 98%; height: 2px">
                <asp:GridView ID="GridData" runat="server" CssClass="gridgeneralstyle" DataKeyNames="Code"
                    EmptyDataText="NO USER(S) FOUND" HorizontalAlign="Center" OnRowCommand="GridData_RowCommand"
                    PageSize="30" Width="90%" AllowPaging="True" OnPageIndexChanging="GridData_PageIndexChanging">
                    <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                    <RowStyle CssClass="gridRowStyle" />
                    <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                    <Columns>
                        <asp:ButtonField CommandName="btnEdit" Text="Edit User">
                            <HeaderStyle CssClass="gridEditField" />
                            <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                Width="110px" />
                        </asp:ButtonField>
                        <asp:ButtonField CommandName="btnenable" Text="Dis/Enable" />
                    </Columns>
                    <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" Font-Bold="True" />
                    <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

