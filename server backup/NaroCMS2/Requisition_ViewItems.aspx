<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Requisition_ViewItems.aspx.cs" Inherits="Requisition_ViewItems" Title="VIEW REQUISITION(S)" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>SEARCH START DATE</label>
                <asp:TextBox ID="txtStartDate" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>Search END DATE</label>
                <asp:TextBox ID="txtEndDate" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Procurement type</label>
                <asp:DropDownList ID="cboProcType" runat="server" CssClass="form-control"
                    OnDataBound="cboProcType_DataBound">
                </asp:DropDownList>
            </div>
            <div class="col-sm-2 mb-3 mb-sm-0">
                <label>STATUS</label>
                <asp:DropDownList ID="cboStatus" runat="server" CssClass="form-control" >
                    <asp:ListItem Value="0">-- Select Status --</asp:ListItem>
                    <asp:ListItem Value="1">Approved</asp:ListItem>
                    <asp:ListItem Value="2">Rejected</asp:ListItem>
                    <asp:ListItem Value="3">Pending</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>.</label>
                <asp:Button ID="btnOK" runat="server" OnClick="btnOK_Click" class="btn btn-primary btn-user btn-block float-right"
                    Text="Search" />
            </div>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table id="TABLE1" style="width: 100%">
                <tr>
                    <td style="width: 100%; height: 21px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                        APPROVED REQUISITION ITEM(S)</td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Left" Font-Names="Verdana" Font-Size="Small"
                            ForeColor="#333333" GridLines="None" Width="100%" OnItemCommand="DataGrid1_ItemCommand">
                            <FooterStyle Font-Bold="True" ForeColor="White" />
                            <EditItemStyle BackColor="#999999" />
                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" Mode="NumericPages" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Left" BackColor="#F7F6F3" ForeColor="#333333"  VerticalAlign="Top" />
                            <Columns>
                                <asp:BoundColumn DataField="RecordID" HeaderText="RecordID" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="PD_Code" HeaderText="PD Code"><ItemStyle Width="220px" /></asp:BoundColumn>
                                <asp:BoundColumn DataField="Subject" HeaderText="Subject"></asp:BoundColumn>
                                <asp:BoundColumn DataField="LevelAT" HeaderText="Position"></asp:BoundColumn>
                                <asp:ButtonColumn CommandName="btnAction" HeaderText="View" Text="Details"></asp:ButtonColumn>
                                <asp:ButtonColumn CommandName="btnFiles" HeaderText="FILES" Text="View/Add"></asp:ButtonColumn>
                                <asp:ButtonColumn CommandName="btnStatus" HeaderText="View" Text="Stage"></asp:ButtonColumn>
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
            <table id="Table2" style="width: 100%">
                <tr>
                    <td style="width: 100%; height: 21px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center" class="InterFaceTableLeftRowUp">
                        REJECTED REQUISITION ITEM(S)</td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                        <asp:Button ID="Button1" runat="server" Text="Re-Submit" OnClick="btnResubmit_Click" />&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                        <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" Font-Bold="True"
                            OnCheckedChanged="CheckBox3_CheckedChanged" Text="Select All" /></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                            ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid2_ItemCommand" Width="100%" style="text-align: justify">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" VerticalAlign="Top" />
                            <EditItemStyle BackColor="#999999" />
                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:BoundColumn DataField="RecordID" HeaderText="RecordCode" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="PD_Code" HeaderText="PD Code">
                                    <ItemStyle Width="220px" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Subject" HeaderText="Subject"></asp:BoundColumn>
                                <asp:BoundColumn DataField="IsGrouped" HeaderText="GROUPED" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="StatusID" HeaderText="StatusID" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="RejectedBy" HeaderText="Rejected By"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Remark" HeaderText="Remark"></asp:BoundColumn>
                               
                                <asp:ButtonColumn CommandName="btnFiles" HeaderText="Files" Text="View/Add"></asp:ButtonColumn>
                                <asp:ButtonColumn CommandName="btnEdit" HeaderText="Edit" Text="Edit"></asp:ButtonColumn>
                                <asp:ButtonColumn CommandName="btnDelete" HeaderText="Delete" Text="Delete">
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" ForeColor="Red" />
                                </asp:ButtonColumn>
                                 <asp:TemplateColumn HeaderText="Submit">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Approved") %>'
                                            Width="40px" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateColumn>
                            </Columns>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        </asp:DataGrid></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                        &nbsp;<asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" Font-Bold="True"
                            OnCheckedChanged="chkSelect_CheckedChanged" Text="Select All" /></td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 26px; text-align: center">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                            <tr>
                                <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                    Comment</td>
                                <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                    &nbsp;</td>
                                <td class="InterFaceTableRightRowUp" style="height: 30px">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="InterfaceTextboxMultiline" Height="80px"
                                        TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 26px; text-align: center" class="InterFaceTableLeftRowUp">
                        <asp:Button ID="btnResubmit" runat="server" Text="Re-Submit" OnClick="btnResubmit_Click" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <table style="width: 100%">
                <tr>
                    <td colspan="3" style="width: 100%; height: 21px; text-align: center">
                    </td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">
                        ATTACHMENT(S)</td>
                </tr>
                <tr>
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="width: 100%; text-align: center">
                        <asp:Label ID="lblHeaderMsg" runat="server" Font-Bold="True" Font-Names="Cambria"
                            Font-Size="11pt" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 49%; text-align: center">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                            <tr>
                                <td colspan="3">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                        <tr>
                                            <td class="InterfaceHeaderLabel3" style="height: 18px">
                                                New Attachments</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 16px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="vertical-align: top; height: 19px; text-align: left">
                                    <table align="center" cellpadding="0" cellspacing="0" style="border-right: #a4a2ca 1px solid;
                                        border-top: #a4a2ca 1px solid; border-left: #a4a2ca 1px solid; width: 90%; border-bottom: #a4a2ca 1px solid;
                                        background-color: #ffffff">
                                        <tr>
                                            <td style="height: 19px">
                                                <br />
                                                <p id="upload-area">
                                                    <input id="FileField" runat="server" size="60" type="file" />
                                                </p>
                                                <p>
                                                    <input id="ButtonAdd" onclick="addFileUploadBox()" type="button" value="Add a file" />
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 2%">
                    </td>
                    <td style="vertical-align: top; width: 49%; text-align: center">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                            <tr>
                                <td colspan="3">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                        <tr>
                                            <td class="InterfaceHeaderLabel3" style="height: 18px">
                                                View Attachments</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 16px">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:GridView ID="GridAttachments" runat="server" CssClass="gridgeneralstyle" DataKeyNames="FileID"
                                        GridLines="None" HorizontalAlign="Center" OnRowCommand="GridAttachments_RowCommand" PageSize="15" Width="98%">
                                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                        <RowStyle CssClass="gridRowStyle" />
                                        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:ButtonField CommandName="ViewDetails" Text="View">
                                                <HeaderStyle CssClass="gridEditField" />
                                                <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                    Width="140px" />
                                            </asp:ButtonField>
                                            <asp:ButtonField CommandName="btnRemove" Text="Remove">
                                                <ItemStyle CssClass="gridEditField" ForeColor="#003399" />
                                            </asp:ButtonField>
                                        </Columns>
                                        <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                        <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                    </asp:GridView>
                                    <asp:Label ID="lblmsg" runat="server" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red"
                                        Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 16px">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="vertical-align: top; width: 100%; text-align: center">
                        <asp:Label ID="lblPD_Code" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Button ID="btnSaveFile" runat="server" OnClick="btnSaveFile_Click" Text="SAVE" class="btn btn-primary btn-user btn-block float-right" />
                        <asp:Button ID="btnReturn" runat="server" Font-Bold="True" OnClick="btnReturn_Click" Text="RETURN" class="btn btn-primary btn-user btn-block float-right"/></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View4" runat="server">
            <table style="width: 100%">
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; text-align: center">
                        NO RECORD FOUND MESSAGE</td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:Label ID="lblEmpty" runat="server" Font-Bold="True" ForeColor="Red" Text="." Font-Names="Verdana" Font-Size="Small"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View5" runat="server">
            <table id="Table3" style="width: 100%">
                <tr>
                    <td style="width: 100%; height: 21px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" style="width: 100%; height: 21px; text-align: center">
                        PENDING REQUISITION ITEM(S)</td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                    
                        <asp:DataGrid ID="DataGrid3" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                            ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid3_ItemCommand" Width="100%" style="text-align: justify">
                            <FooterStyle Font-Bold="True" ForeColor="White" />
                            <EditItemStyle BackColor="#999999" />
                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" Mode="NumericPages" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" VerticalAlign="Top" />
                            <ItemStyle HorizontalAlign="Left" BackColor="#F7F6F3" ForeColor="#333333"  VerticalAlign="Top" />
                            <Columns>
                                <asp:BoundColumn DataField="RecordID" HeaderText="RecordID" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="PD_Code" HeaderText="PD Code"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Subject" HeaderText="Subject"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ProcurementType" HeaderText="Type"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CreationDate" HeaderText="Date" DataFormatString="{0:dd MMM yyyy}"></asp:BoundColumn>
                                <asp:BoundColumn DataField="RequisitionType" HeaderText="RequisitionType" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="StatusID" HeaderText="StatusID" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="IsGrouped" HeaderText="IsGrouped" Visible="False"></asp:BoundColumn>
                                <asp:ButtonColumn CommandName="btnFiles" HeaderText="FILES" Text="View/Add"></asp:ButtonColumn>
                                <asp:ButtonColumn CommandName="btnAction" HeaderText="VIEW" Text="Details"></asp:ButtonColumn>
                                <asp:ButtonColumn CommandName="btnEdit" HeaderText="EDIT" Text="Edit"></asp:ButtonColumn>
                                <asp:ButtonColumn CommandName="btnForward" HeaderText="FORWARD" Text="Forward"></asp:ButtonColumn>
                                <asp:ButtonColumn CommandName="btnDelete" HeaderText="DELETE" Text="Delete">
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" ForeColor="Red" />
                                </asp:ButtonColumn>
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
        <asp:View id="View7" runat="server">
            <TABLE class="style12" cellSpacing=0 cellPadding=0>
                <TBODY>
                    <TR>
                        <TD style="HEIGHT: 19px" colSpan=2>&nbsp;</TD>
                    </TR>
                    <TR>
                        <TD colSpan=2>
                            <TABLE style="WIDTH: 70%" cellSpacing=0 cellPadding=0 align=center>
                                <TBODY>
                                    <TR>
                                        <TD style="HEIGHT: 20px" class="InterfaceHeaderLabel">
                                            <asp:Label id="lblForwardHeader" runat="server" Text="Forward Requisition : "></asp:Label> 
                                        </TD>
                                    </TR></TBODY></TABLE></TD></TR><TR><TD style="HEIGHT: 10px" colSpan=2>&nbsp;</TD></TR>
                    <tr>
                        <td colspan="2" style="height: 10px">
                        </td>
                    </tr>
                    <TR><TD colSpan=2><TABLE style="WIDTH: 70%" cellSpacing=0 cellPadding=0 align=center><TBODY><TR><TD class="InterFaceTableLeftRowUp">
                                        PD Code</TD><TD class="InterFaceTableRightRowUp"><asp:Label id="lblStatusLabel" runat="server" Text="StatusID" Visible="False"></asp:Label> <asp:Label id="lblPD_CodeLabel" runat="server" Text="PD Code" Width="290px" Font-Bold="True"></asp:Label> 
                                            <asp:Label ID="lblRequisitionType" runat="server" Text="RequisitionType" Visible="False"></asp:Label></TD></TR>
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp">
                                                Submit Requisition To</td>
                                            <td class="InterFaceTableRightRowUp">
                                                <asp:DropDownList ID="cboAreaManagers" runat="server" OnDataBound="cboAreaManagers_DataBound"
                                                    Width="75%">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <TR><TD class="InterFaceTableLeftRowUp">Comment</TD><TD class="InterFaceTableRightRowUp"><asp:TextBox id="txtComment" runat="server" Width="74%" TextMode="MultiLine" Rows="6"></asp:TextBox> </TD></TR>
                        <tr>
                            <td style="height: 24px">
                            </td>
                            <td style="height: 24px">
                            </td>
                        </tr>
                        <TR><TD></TD><TD><asp:Button id="btnForwardReq" onclick="btnSubmitComment_Click" runat="server" Text="Forward Requisition"></asp:Button> <asp:Button id="btnReturnToView" onclick="btnReturnToView_Click" runat="server" Text="Return"></asp:Button> </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
        </asp:View>
        <asp:View ID="View6" runat="server">
            <table id="Table4" style="width: 98%">
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
                        <asp:Button ID="Button3" runat="server" OnClick="Button2_Click" Text="Export" class="btn btn-primary btn-user btn-block float-right"/>&nbsp;
                        <asp:Button ID="Button2" runat="server" OnClick="btnreturn_Click" Text="Return" class="btn btn-primary btn-user btn-block float-right"/></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:DataGrid ID="DataGrid4" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                            ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid1_ItemCommand" Style="text-align: justify"
                            Width="100%">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditItemStyle BackColor="#999999" />
                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" VerticalAlign="Top" />
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
        <asp:View ID="View8" runat="server">
            <table cellpadding="0" cellspacing="0" class="style12">
                <tr>
                    <td colspan="2" style="height: 19px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 70%">
                            <tr>
                                <td class="InterfaceHeaderLabel" style="height: 20px">
                                    <asp:Label ID="lblDeleteHeader" runat="server" Text="Delete Requisition"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 10px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 70%">
                            <tr>
                                <td class="InterFaceTableLeftRowUp">
                                    Requisition Code</td>
                                <td class="InterFaceTableRightRowUp">
                                    <asp:Label ID="lblDeleteStatusLabel" runat="server" Text="StatusID" Visible="false"></asp:Label>
                                    <asp:Label ID="lblDeleteReqLabel" runat="server" Text="Req Code" Width="290px"></asp:Label>
                                    <asp:Label ID="lblPlanCode" runat="server" Text="Label" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRowUp">
                                    Requisition Description</td>
                                <td class="InterFaceTableRightRowUp">
                                    <asp:Label ID="lblDesc" runat="server" Text="Description" Width="290px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRowUp" valign="top">
                                    Comment</td>
                                <td class="InterFaceTableRightRowUp">
                                    <asp:TextBox ID="txtDeleteComment" runat="server" Rows="6" TextMode="MultiLine" Width="343px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="btnDeleteReq" runat="server" OnClick="btnDeleteReq_Click" Text="Delete Requisition" />
                                    <asp:Button ID="btnCancelDelete" runat="server" Text="Return" OnClick="btnCancelDelete_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    </div>
    
    <script type="text/javascript">
   function addFileUploadBox()
   {
   if (!document.getElementById || !document.createElement)
   return false;
   
   var uploadArea = document.getElementById("upload-area");
   if (!uploadArea)
   return;
   
   var newline = document.createElement("br");
   uploadArea.appendChild(newline);
   
   var newUploadBox = document.createElement("input");
   newUploadBox.type= "file";
   newUploadBox.size = "60";
   if (!addFileUploadBox.lastAssignedId)
   addFileUploadBox.lastAssignedId = 100;
   
   newUploadBox.setAttribute("id", "FileField" + addFileUploadBox.lastAssignedId);
   newUploadBox.setAttribute("name", "FileField" + addFileUploadBox.lastAssignedId);
   uploadArea.appendChild(newUploadBox);
   addFileUploadBox.lastAssignedId++;
   }
   </script>

    <AjaxControlToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtStartDate">
    </AjaxControlToolkit:CalendarExtender>
    <AjaxControlToolkit:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                    Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtEndDate">
    </AjaxControlToolkit:CalendarExtender>
    <%--<cr:crystalreportviewer id="CrystalReportViewer1" runat="server" autodatabind="true"
        visible="False"></cr:crystalreportviewer>--%>
</asp:Content>





