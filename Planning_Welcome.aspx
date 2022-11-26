<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Planning_Welcome.aspx.cs" Inherits="Planning_Welcome" Title="PLANNING" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table style="width: 100%; text-align: center">
        <tr>
            <td style="width: 70%">
            </td>
        </tr>
        <tr>
            <td class="InterFaceTableLeftRowUp" colspan="1" style="text-align: center; text-decoration: underline">
                </td>
        </tr>
        <tr>
            <td style="width: 70%">
            </td>
        </tr>
        <tr>
            <td style="width: 70%; text-align: center">
                <asp:Label ID="lblWelcome" runat="server" Font-Names="Verdana" Font-Size="small" Font-Bold="True" Text="."></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 70%; height: 20px">
            </td>
        </tr>
        <tr>
            <td style="width: 70%; text-align: center">
                <asp:Label ID="lblCostCenterInfo" runat="server" Font-Names="Verdana" Font-Size="small" Font-Bold="True" Text="."></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 70%; height: 20px">
            </td>
        </tr>
        <tr>
            <td style="width: 70%; height: 2px; text-align: center">
                <asp:Label ID="lblUsage" runat="server"  Font-Names="Verdana"  Font-Size="small" Font-Bold="True" Text="."></asp:Label></td>
        </tr>
        <hr />
    </table>

</asp:Content>

