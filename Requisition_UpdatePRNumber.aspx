<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Requisition_UpdatePRNumber.aspx.cs" Inherits="Requisition_UpdatePRNumber" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    
    <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td style="vertical-align: middle; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 80%">
                    <tr>
                        <td class="InterfaceHeaderLabel" style="height: 20px">
                            UPDATE PR Number</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td style="height: 30px">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: center; height: 19px;">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table cellpadding="0" cellspacing="0" class="style12">
                            <tr>
                                <td style="vertical-align: middle; width: 50%; height: 37px; text-align: center">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                        <tr>
                                            <td class="InterfaceHeaderLabel3">
                                                Requisition Description</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" class="style12">
                            <tr>
                                <td>
                                    <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                        <tr>
                                            <td class="InterFaceTableRightRowUp" colspan="2" style="vertical-align: top; height: 35px;
                                                text-align: center">
                                                <strong>PD CODE</strong> &nbsp;<asp:TextBox ID="txtPDCode" runat="server"></asp:TextBox>
                                                <asp:Button ID="btnSearch" runat="server" Font-Bold="True" Font-Size="9pt"
                                                Height="23px" OnClick="btnSearch_Click" Text="SEARCH" Width="120px" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="vertical-align: top; height: 35px; text-align: center">
                                                <span style="font-size: 13pt; font-family: Cambria">SERIAL: --&gt;&gt; ( </span>
                                                <asp:Label ID="lblEntity" runat="server" Font-Names="cambria" Font-Size="13pt" ForeColor="Red"></asp:Label>
                                                <span style="font-size: 13pt; font-family: Cambria">)</span></td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; width: 50%; height: 121px; text-align: center">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                    <tr>
                                                        <td class="InterFaceTableLeftRowUp">
                                                            Procurement Type</td>
                                                        <td class="InterFaceTableMiddleRowUp">
                                                            &nbsp;</td>
                                                        <td class="InterFaceTableRightRowUp">
                                                            <asp:TextBox ID="txtProcType" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="InterFaceTableLeftRow" style="height: 65px">
                                                            Subject of Procurement</td>
                                                        <td class="InterFaceTableMiddleRow" style="height: 65px">
                                                        </td>
                                                        <td class="InterFaceTableRightRow" style="height: 65px">
                                                            <asp:TextBox ID="txtProcSubject" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxMultiline"
                                                                Font-Bold="True" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="InterFaceTableLeftRow">
                                                            Type of Requisition</td>
                                                        <td class="InterFaceTableMiddleRow">
                                                        </td>
                                                        <td class="InterFaceTableRightRow">
                                                            <asp:TextBox ID="txtRequisitionType" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="InterFaceTableLeftRow">
                                                            Location of Delivery</td>
                                                        <td class="InterFaceTableMiddleRow">
                                                        </td>
                                                        <td class="InterFaceTableRightRow">
                                                            <asp:TextBox ID="txtDeliveryLocation" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                Font-Bold="True" ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="InterFaceTableLeftRow">
                                                            Ware House</td>
                                                        <td class="InterFaceTableMiddleRow">
                                                        </td>
                                                        <td class="InterFaceTableRightRow">
                                                            <asp:TextBox ID="txtWareHouse" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                Font-Bold="True" ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="vertical-align: top; width: 50%; height: 121px; text-align: center">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                </table>
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                    <tr>
                                                        <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                            Date Requisitioned</td>
                                                        <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                        </td>
                                                        <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                            <asp:TextBox ID="txtDateRequisitioned" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                            Date Required</td>
                                                        <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                            &nbsp;</td>
                                                        <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                            <asp:TextBox ID="txtDateRequired" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="InterFaceTableLeftRowUp">
                                                            Cost Center</td>
                                                        <td class="InterFaceTableMiddleRowUp">
                                                            &nbsp;</td>
                                                        <td class="InterFaceTableRightRowUp">
                                                            <asp:TextBox ID="txtBudgetCostCenter" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="InterFaceTableLeftRowUp">
                                                            Requisitioner</td>
                                                        <td class="InterFaceTableMiddleRowUp">
                                                        </td>
                                                        <td class="InterFaceTableRightRowUp">
                                                            <asp:TextBox ID="txtRequisitioner" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                Font-Bold="True" ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="InterFaceTableLeftRowUp">
                                                            Cost Center Manager</td>
                                                        <td class="InterFaceTableMiddleRowUp">
                                                        </td>
                                                        <td class="InterFaceTableRightRowUp">
                                                            <asp:TextBox ID="txtManager" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                Font-Bold="True" ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                                <asp:Label ID="lblCreatedBy" runat="server" Visible="False"></asp:Label></td>
                                        </tr>
                                    </table>
                                    <asp:Label ID="lblPlanCode" runat="server" Font-Names="cambria" Font-Size="13pt"
                                        Visible="False">0</asp:Label>
                                    <asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label>
                                    <asp:Label ID="lblRecordCode" runat="server" Text="0" Visible="False"></asp:Label>
                                    <asp:Label ID="lblCostCenterCode" runat="server" Text="0" Visible="False"></asp:Label>
                                    <asp:Label ID="lblScalaPR" runat="server" Text="0" Visible="False"></asp:Label>
                                    <asp:Label ID="lblCostCenterForBudget" runat="server" Text="0" Visible="False"></asp:Label>
                                    <asp:Label ID="lblStatus" runat="server" Text="0" Visible="False"></asp:Label></td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Times New Roman">
                                <td style="height: 2px">
                                </td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Times New Roman">
                                <td style="vertical-align: middle; text-align: center"><asp:Button ID="btnUpdatePR" runat="server" Font-Bold="True" Font-Size="9pt"
                                                Height="23px" OnClick="btnSubmitRequistn_Click" Text="SUBMIT" Width="120px" />
                                    &nbsp;<asp:Button ID="btnCancel" runat="server" Font-Bold="True" OnClick="btnCancel_Click"
                                                Text="CANCEL" /></td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Times New Roman">
                                <td style="height: 2px">
                                </td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Times New Roman">
                                <td style="vertical-align: middle; text-align: center">
                                    &nbsp;</td>
                            </tr>
                            <tr style="font-size: 12pt; font-family: Times New Roman">
                                <td style="vertical-align: middle; height: 23px; text-align: center">
                                    <asp:Label ID="lblreqn" runat="server" Text="Label" Visible="False"></asp:Label><asp:Label
                                        ID="lblCostCenter" runat="server" Text="0" Visible="False"></asp:Label><asp:Label
                                            ID="lblCostCenterID" runat="server" Text="0" Visible="False"></asp:Label><asp:Label
                                                ID="lblAreaID" runat="server" Text="0" Visible="False"></asp:Label>
                                    <asp:Label ID="lblRankNumber" runat="server" Text="0" Visible="False"></asp:Label>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>&nbsp;</td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: middle; text-align: center">
            </td>
        </tr>
    </table>
</asp:Content>

