<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_Search.aspx.cs" Inherits="Requisition_Print" Title="VIEW REQUISITION(S) FOR PRINT" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" AjaxFrameworkMode="Enabled" runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>SEARCH START DATE</label>
                <asp:TextBox ID="txtStartDate" runat="server" cssclass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>Search END DATE</label>
                <asp:TextBox ID="txtEndDate" runat="server" cssclass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>PR NuMBER</label>
                <asp:TextBox ID="txtPrNumber" runat="server" cssclass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>AREA</label>
                <asp:DropDownList ID="cboAreas" runat="server" AutoPostBack="True" CssClass="form-control"
                    OnDataBound="cboAreas_DataBound1" OnSelectedIndexChanged="cboAreas_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>Cost Center</label>
                <asp:DropDownList ID="cboCostCenters" runat="server" CssClass="form-control"
                    OnDataBound="cboCostCenters_DataBound">
                </asp:DropDownList>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>.</label>
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" class="btn btn-primary btn-user btn-block float-right"
                    Text="Search"/>
            </div>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table id="TABLE1"  style="width: 98%">
                <tr>
                    <td style="width: 100%; height: 21px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                        &nbsp;REQUISITION ITEM(S)</td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:DataGrid ID="DataGrid1" runat="server"  AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Left" Font-Names="Verdana" Font-Size="Small"
                        ForeColor="#333333" GridLines="None" Width="100%" OnItemCommand="DataGrid1_ItemCommand" OnPageIndexChanged="DataGrid1_PageIndexChanged" AllowPaging="True" PageSize="20">
                        <FooterStyle Font-Bold="True" ForeColor="White" />
                        <EditItemStyle BackColor="#999999" />
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" Mode="NumericPages" HorizontalAlign="Center" />
                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" VerticalAlign="Top" />
                        <ItemStyle HorizontalAlign="Left" BackColor="#F7F6F3" ForeColor="#333333" VerticalAlign="Top" />
                            <Columns>
                                <asp:BoundColumn DataField="RecordID" HeaderText="RecordID" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="PD_Code" HeaderText="PD Code"><ItemStyle Width="210px" /></asp:BoundColumn>
                                <asp:BoundColumn DataField="Subject" HeaderText="Subject">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="LevelAT" HeaderText="Position"></asp:BoundColumn>
                                <asp:ButtonColumn CommandName="btnPrint" HeaderText="Print PDF" Text="Print"></asp:ButtonColumn>
                                <asp:ButtonColumn CommandName="btnView" HeaderText="View" Text="Details"></asp:ButtonColumn>
                                <asp:ButtonColumn CommandName="btnStatus" HeaderText="View" Text="Status"></asp:ButtonColumn>
                            </Columns>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        </asp:DataGrid></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table id="Table2"  style="width: 100%">
                <tr>
                    <td style="width: 100%; height: 21px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center" class="InterFaceTableLeftRowUp">
                        REQUISITION ITEM</td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                        <asp:Button ID="btnPrint" runat="server" Text="Print Form" OnClick="btnPrint_Click" />
                        <asp:Button ID="btnreturn" runat="server" Text="Return" OnClick="btnreturn_Click" />&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />--%>
                        &nbsp;&nbsp;<br />
                        <asp:Label ID="lblPD_Code" runat="server" Text="0" Visible="False"></asp:Label></td>
                </tr>
            </table>
        </asp:View>
        &nbsp; &nbsp;
        <asp:View ID="View3" runat="server">
            <table style="width: 100%">
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                        NO RECORD FOUND MESSAGE</td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:Label ID="lblEmpty" runat="server" Font-Bold="True" ForeColor="Red" Text="."></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View4" runat="server">
            <table id="Table3"  style="width: 98%">
                <tr>
                    <td style="width: 100%; height: 21px; text-align: center">
                    </td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                        STAGES OF REQUISITION</td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                        <asp:Button ID="Button2" runat="server" Text="Export" OnClick="Button2_Click" />&nbsp;
                        <asp:Button ID="Button1" runat="server" Text="Return" OnClick="btnreturn_Click" /></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                            ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid1_ItemCommand" Width="100%" OnSelectedIndexChanged="DataGrid1_SelectedIndexChanged" style="text-align: justify">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditItemStyle BackColor="#999999" />
                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundColumn DataField="RecordID" HeaderText="RecordID" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Description" HeaderText="Stage">
                                    <ItemStyle Width="450px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Remark" HeaderText="Comment "></asp:BoundColumn>
                                <asp:BoundColumn DataField="CreationDate" HeaderText="Date/Time"></asp:BoundColumn>
                                <asp:BoundColumn DataField="MadeBy" HeaderText="Made By"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Level" HeaderText="System Level"></asp:BoundColumn>
                            </Columns>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        </asp:DataGrid></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                    </td>
                </tr>
            </table>
        </asp:View>
        &nbsp;&nbsp;
    </asp:MultiView>
    </div>
    
   <AjaxControlToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtStartDate">
    </AjaxControlToolkit:CalendarExtender>
    <AjaxControlToolkit:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtEndDate">
    </AjaxControlToolkit:CalendarExtender>
</asp:Content>







