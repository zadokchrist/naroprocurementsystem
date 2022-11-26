<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Bidding_CCSchedule.aspx.cs" Inherits="Bidding_CCSchedule" Title="CONTRACTS COMMITTEE SCHEDULE" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellpadding="0" cellspacing="0" class="style12">
    <tr>
        <td>
                &nbsp;</td>
    </tr>
    <tr>
        <td>
                <table align ="center" cellpadding="0" cellspacing="0" style="width: 60%">
                    <tr>
                        <td class="InterfaceHeaderLabel">
                            <asp:Label ID="Label1" runat="server" Text="CONTRACTS COMMITTEE SCHEDULE"></asp:Label></td>
                    </tr>
                </table>
            </td>
    </tr>
    <tr>
        <td style="height: 2px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="height: 70px">
            <table align="center" cellpadding="0" cellspacing="0" style="width: 90%">
                <tr>
                    <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 20%; height: 18px;
                        text-align: center">
                        SELECT CONTRACTS COMMITTEE</td>
                    <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 20%; height: 18px;
                        text-align: center">
                        SELECT SCHEDULE</td>
                    <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 20%; height: 18px;
                        text-align: center">
                        SELECT STATUS</td>
                    <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 20%; height: 18px;
                        text-align: center">
                        Meeting REF. No.</td>
                </tr>
                <tr>
                    <td class="ddcolortabsline2" colspan="4" style="vertical-align: middle; text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="vertical-align: middle; width: 20%; text-align: center; height: 23px;">
                        <asp:DropDownList ID="cboCC" runat="server" AutoPostBack="True" OnDataBound="cboCC_DataBound" Width="90%">
                        </asp:DropDownList></td>
                    <td style="vertical-align: middle; width: 20%; text-align: center; height: 23px;">
                        <asp:DropDownList ID="cboSchedule" runat="server" CssClass="InterfaceDropdownList" Width="95%">
                            <asp:ListItem Value="0">-- Select Schedule --</asp:ListItem>
                            <asp:ListItem Value="1">Procurement Method</asp:ListItem>
                            <asp:ListItem Value="2">Award Of Contracts</asp:ListItem>
                            <asp:ListItem Value="3">Ractification</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="vertical-align: middle; width: 20%; height: 23px; text-align: center">
                        <asp:DropDownList ID="cboStatus" runat="server" CssClass="InterfaceDropdownList" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="cboStatus_SelectedIndexChanged">
                            <asp:ListItem Value="0">-- Select Status --</asp:ListItem>
                            <asp:ListItem Value="1">Pending</asp:ListItem>
                            <asp:ListItem Value="2">Approved</asp:ListItem>
                        </asp:DropDownList></td>
                    <td style="vertical-align: middle; width: 20%; height: 23px; text-align: center">
                        <asp:TextBox ID="txtMeetingRefNo" runat="server" Enabled="False"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="vertical-align: middle; width: 20%; height: 23px; text-align: center">
                    </td>
                    <td style="vertical-align: middle; width: 20%; height: 23px; text-align: center">
                    </td>
                    <td style="vertical-align: middle; width: 20%; height: 23px; text-align: center">
                    </td>
                    <td style="vertical-align: middle; width: 20%; height: 23px; text-align: center">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="vertical-align: middle; text-align: right">
                        <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Height="23px" OnClick="btnOK_Click"
                            Text="Preview" Width="100px" />
                        <asp:Button ID="btnPrint" runat="server" Font-Size="9pt" Height="23px" OnClick="btnPrint_Click"
                            Text="Export To PDF" Width="126px" Enabled="False" />
                        <asp:Button ID="btnExportToExcel" runat="server" Font-Size="9pt" Height="23px" OnClick="btnExportToExcel_Click"
                            Text="Export To Excel" Width="126px" Enabled="False" /></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="height: 10px">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
    </tr>
          <tr>
                        <td style="vertical-align: top; height: 19px; text-align: left">
                            <table align ="center"style="width: 90%; border-right: #617da6 1px solid; border-top: #617da6 1px solid; border-left: #617da6 1px solid; border-bottom: #617da6 1px solid; height: 100px;">
                    <tr>
                        <td style="width: 100%; vertical-align: top; text-align: left;">
                            <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"--%> 
                    ToolPanelView="None" Height="991px" Width="725px"/>
                        </td>
                    </tr>
                </table>
                            </td>
                    </tr>
</table>

</asp:Content>

