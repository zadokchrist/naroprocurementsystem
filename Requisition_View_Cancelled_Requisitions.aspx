<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Requisition_View_Cancelled_Requisitions.aspx.cs" Inherits="Requisition_View_Cancelled_Requisitions" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    
    
    <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
        <tr>
            <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 15%; height: 18px;
                text-align: center">
                SEARCH START DATE</td>
            <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 15%; height: 18px;
                text-align: center">
                Search&nbsp; END DATE</td>
            <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                text-align: center">
               Scala PR NuMBER</td>
            <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                text-align: center">
                AREA</td>
            <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                text-align: center">
                Cost Center</td>
                <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                text-align: center">
                Procurement type</td>
        </tr>
        <tr>
            <td class="ddcolortabsline2" colspan="5" style="vertical-align: middle; text-align: center">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="vertical-align: middle; width: 15%; height: 23px; text-align: center">
                <asp:TextBox ID="txtStartDate" runat="server" Width="85%"></asp:TextBox></td>
            <td style="vertical-align: middle; width: 15%; height: 23px; text-align: center">
                <asp:TextBox ID="txtEndDate" runat="server" Width="85%"></asp:TextBox>&nbsp;</td>
            <td style="vertical-align: middle; width: 15%; height: 23px; text-align: center">
                <asp:TextBox ID="txtPrNumber" runat="server" Width="85%"></asp:TextBox></td>
            <td style="vertical-align: middle; width: 20%; height: 23px; text-align: center">
                <asp:DropDownList ID="cboAreas" runat="server" AutoPostBack="True" CssClass="InterfaceDropdownList"
                    OnDataBound="cboAreas_DataBound"
                    Width="95%" onselectedindexchanged="cboAreas_SelectedIndexChanged" >
                </asp:DropDownList></td>
            <td style="vertical-align: middle; width: 20%; height: 23px; text-align: center">
                <asp:DropDownList ID="cboCostCenters" runat="server" CssClass="InterfaceDropdownList" OnDataBound="cboCostCenters_DataBound"
                     Width="95%">
                </asp:DropDownList></td>
                <td style="vertical-align: middle; width: 20%; height: 23px; text-align: center"> 
                <asp:DropDownList ID="cboProcType" runat="server" CssClass="InterfaceDropdownList"
                   Width="95%"  OnDataBound="cboProcType_DataBound" ></asp:DropDownList>
                </td>
            <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                <asp:Button ID="btnOK" runat="server"  Font-Size="9pt" Height="30px" OnClick="btnOK_Click"
                    Text="Search" Width="85px" />&nbsp;</td>
        </tr>
    </table>
    <asp:MultiView ID="MultiViewForCancelRequisition" runat="server">
        <asp:View ID="View1" runat="server">
            <table id="Table2" style="width: 100%">
                <tr>
                    <td style="width: 100%; height: 21px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center" class="InterFaceTableLeftRowUp">
                        REQUISITION (S) THAT HAVE REACHED CONTRACTS COMMITTEE AND HAVE BEEN CANCELLED &amp; 
                        DELETED</td>
                </tr>
                
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                            ForeColor="#333333" GridLines="None" Width="100%" style="text-align: justify">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Top" />
                            <EditItemStyle BackColor="#999999" />
                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                 <asp:BoundColumn DataField="PD_Code" HeaderText="PD_Code"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ScalaPRNumber" HeaderText="Scala PR Number">    
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Subject" HeaderText="Subject"></asp:BoundColumn>
                                <asp:BoundColumn DataField="TotalAmount" HeaderText="Amount"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CostCenterName" HeaderText="CostCenter"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CreationDate" HeaderText="Date Created"></asp:BoundColumn> 
                                <asp:BoundColumn DataField="AssignedDate" HeaderText="Date Assigned to You"></asp:BoundColumn>    
                            </Columns>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        </asp:DataGrid></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                        &nbsp;</td>
                </tr>
                
                <tr>
                    <td style="width: 100%; height: 26px; text-align: center" class="InterFaceTableLeftRowUp">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:View>
        </asp:MultiView>
   <AjaxControlToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtStartDate">
    </AjaxControlToolkit:CalendarExtender>
    <AjaxControlToolkit:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtEndDate">
    </AjaxControlToolkit:CalendarExtender>

















</asp:Content>

