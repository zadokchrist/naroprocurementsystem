<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Requisition_Welcome1.aspx.cs" Inherits="Requisition_Welcome" Title="REQUISITION" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table style="width: 100%; text-align: center">
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center; text-decoration: underline">
                </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100%; text-align: center">
                <asp:Label ID="lblWelcome" runat="server" Font-Names="Verdana" Font-Size="small" Font-Bold="True" Text="."></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 20px">
            </td>
        </tr>
        <tr>
            <td style="width: 100%; text-align: center">
                <asp:Label ID="lblCostCenterInfo" runat="server" Font-Names="Verdana" Font-Size="small" Font-Bold="True" Text="."></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 20px">
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 2px; text-align: center">
                <asp:Label ID="lblUsage" runat="server"  Font-Names="Verdana"  Font-Size="small" Font-Bold="True" Text="."></asp:Label></td>
        </tr>
    </table>

</asp:Content>

