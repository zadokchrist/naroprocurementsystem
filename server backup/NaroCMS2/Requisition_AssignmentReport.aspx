<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Requisition_AssignmentReport.aspx.cs" Inherits="Requisition_ActivityScheduleReport" Title="Activity Schedule Report" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
 <%@ Register Assembly="AjaxControlToolkit"  Namespace="AjaxControlToolkit"  TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   

<table cellpadding="0" cellspacing="0" class="style12">
    <tr>
        <td class="lblgridmessage" style="height: 19px">
                &nbsp;</td>
    </tr>
    <tr>
        <td>
                <table align ="center" cellpadding="0" cellspacing="0" style="width: 50%">
                    <tr>
                        <td class="InterfaceHeaderLabel">
                            PROCUREMENT ACTIVITY SCHEDULE (PDU)&nbsp; [A3 Size]</td>
                    </tr>
                </table>
            </td>
    </tr>
    <tr>
        <td style="height: 2px">
            <table style="width: 100%">
                <tr>
                    <td colspan="2">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                            <tr>
                                <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 25%; text-align: center">
                                    report type</td>
                                <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; text-align: center">
                        Procurement officer</td>
                                <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; text-align: center">
                        pdu category</td>
                                <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; text-align: center">
                                    FINANCIAL YEAR</td>
                                <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 13%; text-align: center">
                                </td>
                                <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 12%; text-align: center">
                                </td>
                            </tr>
                            <tr>
                                <td class="ddcolortabsline2" colspan="6" style="vertical-align: middle; height: 1px;
                                    text-align: center">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle; width: 25%; height: 23px; text-align: center">
                                    &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" CssClass="InterfaceDropdownList"
                                        OnDataBound="cboProcurementOfficer_DataBound" Width="85%">
                                        <asp:ListItem Value="2">PDU REPORT</asp:ListItem>
                                        <asp:ListItem Value="1">GENERAL REPORT</asp:ListItem>
                                        <asp:ListItem Value="3">SCHEDULE BY OFFICER</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td style="vertical-align: middle; width: 25%; height: 23px; text-align: center">
                                    <asp:DropDownList ID="cboProcurementOfficer" runat="server" CssClass="InterfaceDropdownList"
                                        OnDataBound="cboProcurementOfficer_DataBound" Width="85%">
                                    </asp:DropDownList></td>
                                <td style="vertical-align: middle; width: 25%; height: 23px; text-align: center">
                                    &nbsp;<asp:DropDownList ID="cboPDUCategory" runat="server" CssClass="InterfaceDropdownList"
                                        Width="85%">
                                        <asp:ListItem Value="0">-- ALL PDUs --</asp:ListItem>
                                        <asp:ListItem Value="1">HEAD QUARTERS</asp:ListItem>
                                        <asp:ListItem Value="2">KAMPALA WATER</asp:ListItem>
                                        <asp:ListItem Value="3">NWSC - AREAS</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td style="vertical-align: middle; width: 25%; height: 23px; text-align: center">
                                    <asp:DropDownList ID="cboFinancialYear" runat="server" CssClass="InterfaceDropdownList"
                                        OnDataBound="cboFinancialYear_DataBound" Width="90%">
                                    </asp:DropDownList></td>
                                <td style="vertical-align: middle; width: 13%; height: 23px; text-align: center">
                                    <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Height="23px" OnClick="btnOK_Click"
                                        Text="Generate" Width="85px" />&nbsp;</td>
                                <td style="vertical-align: middle; width: 12%; height: 23px; text-align: center">
                                    <asp:Button ID="btnPrint" runat="server" Enabled="False" Font-Size="9pt" Height="23px"
                                        OnClick="btnPrint_Click" Text="Print" Width="85px" />&nbsp;</td>
                            </tr>
                        </table>
                        &nbsp;</td>
                </tr>
            </table>
            </td>
    </tr>
    <tr>
        <td style="text-align: left; vertical-align: middle; height: 15px;">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 98%">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 98%">
                              <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid;
                border-left: #617da6 1px solid; width: 98%; border-bottom: #617da6 1px solid">
                <tbody>
                    <tr>
                        <td style="width: 96%; text-align: center; vertical-align: top;">
                            <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ToolPanelView="None" Height="50px" SeparatePages="False" Width="350px" HasPrintButton="False" />--%>
                        </td>
                    </tr>
                </tbody>
            </table>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                &nbsp;
            </asp:MultiView></td>
    </tr>
    <tr>
        <td class="ddcolortabsline2">
            &nbsp;&nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;
                </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table>

</asp:Content>

