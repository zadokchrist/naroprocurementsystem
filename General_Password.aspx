<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="General_Password.aspx.cs" Inherits="GeneralPassword" Title="SYSTEM PASSWORD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
        <tr>
            <td colspan="3" style="vertical-align: middle; height: 17px; text-align: center">
            </td>
        </tr>
        <tr>
            <td class="InterfaceHeaderLabel2" colspan="3" style="vertical-align: middle; height: 17px;
                text-align: center">
                Change password</td>
        </tr>
        <tr>
            <td class="ddcolortabsline2" colspan="3" style="vertical-align: middle; text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: middle; height: 2px; text-align: center">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: middle; height: 23px; text-align: center">
                <table style="width: 100%">
                    <tr>
                        <td class="InterFaceTableLeftRow" style="width: 48%; text-align: right">
                            Old Password</td>
                        <td style="width: 2%">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 52%">
                            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRow" style="width: 48%; text-align: right">
                            New Password</td>
                        <td style="width: 2%">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 52%">
                            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 2px">
                        </td>
                    </tr>
                    <tr>
                        <td class="InterFaceTableLeftRow" style="width: 48%; text-align: right">
                            Confirm Password</td>
                        <td style="width: 2%">
                        </td>
                        <td class="InterFaceTableRightRow" style="width: 52%">
                            <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="height: 2px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center">
                            <asp:Button ID="btnSave" runat="server" Font-Bold="True" OnClick="btnSave_Click"
                                Text="Change Password" /></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

