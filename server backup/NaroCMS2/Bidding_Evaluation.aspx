<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Bidding_Evaluation.aspx.cs" Inherits="Bidding_Evaluation" Title="PENDING PROCUREMENT(S) FOR EVALUATION" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td class="InterfaceItemSeparator2" style="height: 2px">
                  <%--<ajaxToolkit:ToolkitScriptManager  ID="ScriptManager1" runat="server">
                </ajaxToolkit:ToolkitScriptManager>--%>
                   <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>

            </td>
            </td>
        </tr>
        <tr>
            <td style="height: 39px">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                    <tr>
                        <td class="InterfaceHeaderLabel3" style="height: 18px">
                            PREPARE EVALUATON FORM AND REPORT FOR SUBMISSION</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 50%; height: 15px; text-align: center">
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 50%; text-align: center">
                <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid;
                    border-left: #617da6 1px solid; width: 99%; border-bottom: #617da6 1px solid">
                    <tr>
                        <td style="vertical-align: top; text-align: center">
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                    <tr>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            PR NUMBER</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            PROC. METHOD</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            AREA</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                            Cost CENTER</td>
                        <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 17%; height: 18px;
                            text-align: center">
                        </td>
                    </tr>
                    <tr>
                        <td class="ddcolortabsline2" colspan="5" style="vertical-align: middle; text-align: center">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:TextBox ID="txtPrNumber" runat="server" Width="85%"></asp:TextBox></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:DropDownList ID="cboProcMethod" runat="server" AutoPostBack="True" CssClass="InterfaceDropdownList"
                                OnDataBound="cboProcMethod_DataBound"
                                Width="95%">
                            </asp:DropDownList></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:DropDownList ID="cboAreas" runat="server" AutoPostBack="True" CssClass="InterfaceDropdownList"
                                OnDataBound="cboAreas_DataBound1" OnSelectedIndexChanged="cboAreas_SelectedIndexChanged"
                                Width="95%">
                            </asp:DropDownList></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:DropDownList ID="cboCostCenters" runat="server" CssClass="InterfaceDropdownList"
                                OnDataBound="cboCostCenter_DataBound" Width="95%">
                            </asp:DropDownList></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:DropDownList ID="cbostatus" runat="server" CssClass="InterfaceDropdownList"
                               Width="95%" >
                     <asp:ListItem Value="0">-- Select Status --</asp:ListItem>
                     <asp:ListItem Value="1">  All Procurement Evaluations Pending Submission </asp:ListItem>
                     <asp:ListItem Value="65"> Procurement Combined  Evaluation Rejected By Procurement Supervisor</asp:ListItem>
                     <asp:ListItem Value="107">Procurement Technical Evaluation Rejected By Procurement Supervisor</asp:ListItem>
                     <asp:ListItem Value="111">Procurement Financial Evaluation Rejected By Procurement Supervisor</asp:ListItem>
                     <asp:ListItem Value="72"> Procurement Combined  Evaluation Deferred By Contracts Committee </asp:ListItem>
                     <asp:ListItem Value="118">Procurement Technical Evaluation Deferred By Contracts Committee </asp:ListItem>
                     <asp:ListItem Value="87"> Procurement Financial Evaluation Deferred By Contracts Committee </asp:ListItem>
                     <asp:ListItem Value="74"> Procurement Rejected By Contracts Committee </asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="vertical-align: middle; width: 17%; height: 23px; text-align: center">
                            <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Height="23px" OnClick="btnOK_Click"
                                Text="Search" Width="85px" />&nbsp;</td>
                    </tr>
                </table>
            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%; height: 9px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4"  Font-Names="Verdana" Font-Size="Small"
                                                    ForeColor="#333333" GridLines="None" OnItemCommand="DataGrid1_ItemCommand"
                                                    Width="100%" style="text-align: justify">
                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                    <EditItemStyle BackColor="#999999" />
                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                                                    <Columns>
                                                        <asp:BoundColumn DataField="RecordID" HeaderText="RecordID" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="CreationDate" HeaderText="Date" DataFormatString="{0:dd MMM yyyy}" Visible="False"><ItemStyle Width="50px" /></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ScalaPRNumber" HeaderText="PR Number"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Subject" ItemStyle-Wrap="true" ItemStyle-Width="150"  HeaderText="Subject"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ProcurementType" HeaderText="Type"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="ProcMethodCode" HeaderText="MethodCode" Visible="False"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="Method" HeaderText="Method"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="EstimatedCost" HeaderText="Est. Cost" DataFormatString="{0:N0}"></asp:BoundColumn>
                                                        <asp:BoundColumn DataField="IsSubmitEnabled" HeaderText="IsSubmitEnabled" Visible="False"></asp:BoundColumn>
                                                        <asp:TemplateColumn  HeaderText="Upload" ><ItemTemplate><asp:LinkButton runat="server"  CommandName="btnFillEvaluationForm" Text="Eval. Form" Visible="<%# Disable(Container.DataItem) %>" ></asp:LinkButton></ItemTemplate></asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="ADD" ><ItemTemplate><asp:LinkButton runat="server"  CommandName="btnAddNegotiationPlan"  Text="Neg. Plan" Visible="<%# Disable(Container.DataItem) %>" ></asp:LinkButton></ItemTemplate></asp:TemplateColumn>

                                                      
                                                      
                                                        <asp:TemplateColumn HeaderText="Comment"><ItemTemplate><asp:TextBox ID="txtbxComment" Width="300px" runat="server" Text = "<%# ViewComment(Container.DataItem) %>" Visible="<%# DisableViewComment(Container.DataItem) %>" Enabled = "false" TextMode="MultiLine"></asp:TextBox></ItemTemplate></asp:TemplateColumn> 


                                                        <asp:TemplateColumn HeaderText="ACTION"><ItemTemplate><asp:LinkButton runat="server" ID="btnSubmit" CommandName="btnSubmit" Text="Submit" Visible="<%# EnableSubmitButton(Container.DataItem) %>"></asp:LinkButton></ItemTemplate></asp:TemplateColumn>
                                                      <asp:BoundColumn DataField="StatusID" HeaderText="StatusID" Visible="False"></asp:BoundColumn>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                                </asp:DataGrid></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100%">
                                                <asp:Label ID="lblEmpty" runat="server" Font-Bold="True" ForeColor="Red" Text="."></asp:Label></td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td colspan="3" style="width: 100%; height: 21px; text-align: center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">
                                                EVALUATION REPORT</td>
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
                                            <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;">
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
                                            <td style="width: 2%; height: 280px;">
                                            </td>
                                            <td style="vertical-align: top; width: 49%; text-align: center; height: 280px;">
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
                                                                GridLines="None" HorizontalAlign="Center" OnRowCommand="GridAttachments_RowCommand" AutoGenerateColumns="false"
                                                                PageSize="15" Width="98%">
                                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                <RowStyle CssClass="gridRowStyle" />
                                                                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                                <Columns>
                                                                    <asp:ButtonField CommandName="ViewDetails" Text="View"><HeaderStyle CssClass="gridEditField" /><ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                                            Width="140px" /></asp:ButtonField>
                                                                    <asp:TemplateField><ItemTemplate><asp:LinkButton ID="btnRemove" CommandName="btnRemove" runat="server" Text="Remove" Visible='<%# IsFileRemoveable((Int32)Eval("IsRemoveable")) %>' /></ItemTemplate><ItemStyle CssClass="gridEditField" ForeColor="#003399" /></asp:TemplateField>
                                                                    <asp:BoundField HeaderText="FileID" DataField="FileID" />
                                                                    <asp:BoundField HeaderText="FileName" DataField="FileName" />
                                                                    <asp:BoundField HeaderText="IsRemoveable" DataField="IsRemoveable" Visible="false" />
                                                                </Columns>
                                                                <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                                <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                            </asp:GridView>
                                                            <asp:Label ID="lblNoAttachments" runat="server" Font-Names="Cambria" Font-Size="11pt"
                                                                ForeColor="Red" Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label></td>
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
                                                <asp:Label ID="lblAttachRefNo" runat="server" Text="0" Visible="False"></asp:Label><asp:Button
                                                    ID="btnSaveFile" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                    OnClick="btnSaveFile_Click" Text="SAVE " Width="80px" />
                                                <asp:Button ID="btnAttReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                    OnClick="btnAttReturn_Click" Text="RETURN" Width="80px" /></td>
                                        </tr>
                                    </table>
                                </asp:View>
                                &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                <asp:View ID="View5" runat="server">
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
                                                            <td style="vertical-align: top; width: 96%; text-align: center">
                                                                <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"--%>
                                                                    ToolPanelView="None" HasPrintButton="False" Height="50px" SeparatePages="False"
                                                                    Width="350px" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                &nbsp; &nbsp;
                                &nbsp; &nbsp;
                                <asp:View ID="View10" runat="server">
                                    <asp:MultiView ID="MultiView2" runat="server">
                                        <asp:View ID="View11" runat="server">
                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="vertical-align: middle; width: 100%; height: 5px; text-align: center">
                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                                            <tr>
                                                                <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                    &gt;&gt;&gt; &nbsp;<asp:Label ID="Label1" runat="server" ForeColor="Firebrick" Text="0"></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                        <asp:Label ID="Label3" runat="server" Text="0" Visible="False"></asp:Label><asp:Label
                                                            ID="Label4" runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="Label5"
                                                                runat="server" Text="0" Visible="False"></asp:Label><asp:Label ID="lblID" runat="server"
                                                                    Text="0" Visible="False"></asp:Label><asp:Label ID="Label6" runat="server" Text="0"
                                                                        Visible="False"></asp:Label>
                                                        <asp:Label ID="lblNegotiationPlanID" runat="server" Text="0" Visible="False"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="1" style="vertical-align: top; width: 50%; text-align: center">
                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                            <tr>
                                                                <td class="InterFaceTableLeftRowUp">
                                                                    Reference Number</td>
                                                                <td class="InterFaceTableMiddleRowUp">
                                                                </td>
                                                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                                    <asp:TextBox ID="txtReferenceNo" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                        Font-Bold="True" ForeColor="Firebrick" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="InterFaceTableLeftRowUp">
                                                                    Procurement Type</td>
                                                                <td class="InterFaceTableMiddleRowUp">
                                                                    &nbsp;</td>
                                                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                                    <asp:TextBox ID="txtProcType" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                                    Estimated Cost</td>
                                                                <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                                </td>
                                                                <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                                    <asp:TextBox ID="txtEstimatedCost" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="InterFaceTableLeftRowUp">
                                                                    Procurement Method</td>
                                                                <td class="InterFaceTableMiddleRowUp">
                                                                </td>
                                                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                                    <asp:TextBox ID="txtProcMethod" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="InterFaceTableLeftRowUp">
                                                                    Date Requisitioned</td>
                                                                <td class="InterFaceTableMiddleRowUp">
                                                                </td>
                                                                <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                                    <asp:TextBox ID="txtDateRequisitioned" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td colspan="4" style="vertical-align: top; width: 50%; text-align: center">
                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                            <tr>
                                                                <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                                    Date Required</td>
                                                                <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                                </td>
                                                                <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                                    <asp:TextBox ID="txtDateRequired" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
                                                                        Font-Bold="True" ReadOnly="True" Width="90%"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="InterFaceTableLeftRow">
                                                                    Subject of Procurement</td>
                                                                <td class="InterFaceTableMiddleRow">
                                                                </td>
                                                                <td class="InterFaceTableRightRow" style="width: 66%; height: 65px">
                                                                    <asp:TextBox ID="txtProcSubject" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxMultiline"
                                                                        Font-Bold="True" ReadOnly="True" TextMode="MultiLine"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="InterFaceTableLeftRowUp">
                                                                    Requisitioner</td>
                                                                <td class="InterFaceTableMiddleRowUp">
                                                                </td>
                                                                <td class="InterFaceTableRightRowUp">
                                                                    <asp:TextBox ID="txtRequisitioner" runat="server" BorderStyle="Solid" CssClass="InterfaceTextboxLongReadOnly"
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
                                                        </table>
                                                    </td>
                                                </tr>
                                               
                                                </tr>
                                              
                                                    <tr>
                                                        <td colspan="4" 
                                                            style="vertical-align: top; position: static; height: 5px; text-align: center">
                                                            &nbsp;<asp:MultiView ID="MultiView4" runat="server">
                                                                <asp:View ID="View9" runat="server">
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <td style="width: 100%; text-align: center">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100%; text-align: center">
                                                                                <table align="center" cellpadding="0" cellspacing="0" 
                                                                                    style="margin-top: 10px; width: 60%">
                                                                                    <tr>
                                                                                        <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                                            ADD NEGOTIATION PLAN DETAILS</td>
                                                                                    </tr>
                                                                                </table>
                                                                                <br />
                                                                                <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                                    <tr>
                                                                                        <td colspan="2" 
                                                                                            style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="color: #000000">
                                                                                        <td colspan="2" 
                                                                                            style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="."></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="color: #000000">
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                                                <tr>
                                                                                                    <td style="vertical-align: top; width: 45%; text-align: center">
                                                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                                            <tr>
                                                                                                                <td colspan="3">
                                                                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                                                        <tr>
                                                                                                                            <td class="InterFaceTableLeftRowUp">
                                                                                                                                Name of Provider</td>
                                                                                                                            <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                                                &nbsp;</td>
                                                                                                                            <td class="InterFaceTableRightRowUp">
                                                                                                                                <asp:DropDownList ID="cboProvider" runat="server" 
                                                                                                                                    CssClass="InterfaceDropdownList" OnDataBound="cboProvider_DataBound" 
                                                                                                                                    Width="82%">
                                                                                                                                </asp:DropDownList>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                        &nbsp;&nbsp;
                                                                                                    </td>
                                                                                                    <td style="vertical-align: top; width: 45%; color: #000000; text-align: center">
                                                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                                        </table>
                                                                                                        <table cellpadding="0" cellspacing="0" class="style12" style="width: 95%">
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                                                        <tr>
                                                                                                                            <td class="InterFaceTableLeftRowUp">
                                                                                                                                Negotiations Proposed By</td>
                                                                                                                            <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                                                &nbsp;</td>
                                                                                                                            <td class="InterFaceTableRightRowUp">
                                                                                                                                <asp:TextBox ID="txtProposedBy" runat="server" autocomplete="off" Width="80%"></asp:TextBox>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                    &nbsp;</td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" 
                                                                                                MinimumPrefixLength="1" ServiceMethod="GetUsersByNames" 
                                                                                                ServicePath="CascadingddlService.asmx" TargetControlID="txtProposedBy"></cc1:AutoCompleteExtender>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="color: #000000">
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <asp:Button ID="btnAdd" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                                                                Height="23px" OnClick="btnAdd_Click" Text="Add Negotiation Plan" 
                                                                                                Width="166px" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="color: #000000">
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="color: #000000">
                                                                                        <td colspan="2" style="vertical-align: top; height: 19px; text-align: center">
                                                                                            <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" 
                                                                                                CellPadding="4" Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" 
                                                                                                GridLines="None" OnItemCommand="DataGrid2_ItemCommand" 
                                                                                                Style="text-align: justify" Width="100%">
                                                                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                                <EditItemStyle BackColor="#999999" />
                                                                                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                                                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                                                                                                    VerticalAlign="Top" />
                                                                                                <Columns>
                                                                                                    <asp:BoundColumn DataField="NegotiationPlanID" HeaderText="NegotiationPlanID" 
                                                                                                        Visible="False"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="ProviderID" HeaderText="ProviderID" Visible="False"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="ProviderName" HeaderText="Provider Name"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="ProposedByID" HeaderText="ProposedByID" 
                                                                                                        Visible="False"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="ProposedBy" HeaderText="Proposed By"></asp:BoundColumn>
                                                                                                    <asp:ButtonColumn CommandName="btnEdit" HeaderText="Edit" Text="Edit"></asp:ButtonColumn>
                                                                                                    <asp:TemplateColumn HeaderText="ADD"><ItemTemplate><asp:LinkButton ID="btnAddNegPlanDetails" runat="server" 
                                                                                                                CommandName="btnAddNegPlanDetails" Text="Negotiation Plan" 
                                                                                                                Visible="<%# EnableNegPlanLink(Container.DataItem) %>"></asp:LinkButton></ItemTemplate></asp:TemplateColumn>
                                                                                                    <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove"><ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                                            Font-Strikeout="False" Font-Underline="False" ForeColor="Red" /></asp:ButtonColumn>
                                                                                                </Columns>
                                                                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" 
                                                                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                                    ForeColor="White" HorizontalAlign="Left" />
                                                                                            </asp:DataGrid>
                                                                                            <asp:Label ID="lblNoNegotiationPlans" runat="server" Font-Bold="True" 
                                                                                                Font-Names="Cambria" ForeColor="Red" Visible="False" Width="550px">NO NEGOTIATION PLANS CURRENTLY AVAILABLE</asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="color: #000000">
                                                                                        <td colspan="2" style="vertical-align: top; height: 19px; text-align: center">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="color: #000000">
                                                                                        <td colspan="2" style="vertical-align: top; height: 19px; text-align: center">
                                                                                            <asp:Button ID="btnSubmitNegotiationPlan" runat="server" Font-Bold="True" 
                                                                                                Font-Size="9pt" Height="23px" OnClick="btnSubmitNegotiationPlan_Click" 
                                                                                                Text="SUBMIT" Width="144px" />
                                                                                            <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                                                                Height="23px" OnClick="btnReturn_Click" Text="CANCEL" 
                                                                                                ToolTip="Hide this section" Width="120px" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:View>
                                                                <asp:View ID="View8" runat="server">
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <td style="width: 100%; text-align: center">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table align="center" cellpadding="0" cellspacing="0" 
                                                                        style="margin-top: 10px; width: 60%">
                                                                        <tr>
                                                                            <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                                ADD NEGOTIATION PLAN DETAILS AND NEGOTIATION TEAM
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <br />
                                                                    <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                        <tr>
                                                                            <td colspan="2" 
                                                                                style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" 
                                                                                style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                                <asp:DataGrid ID="DataGrid3" runat="server" AutoGenerateColumns="False" 
                                                                                    CellPadding="4" Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" 
                                                                                    GridLines="None" OnItemCommand="DataGrid3_ItemCommand" 
                                                                                    Style="text-align: justify" Width="100%">
                                                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                    <EditItemStyle BackColor="#999999" />
                                                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                                                                                        VerticalAlign="Top" />
                                                                                    <Columns>
                                                                                        <asp:BoundColumn DataField="NegotiationPlanID" HeaderText="NegotiationPlanID" 
                                                                                            Visible="False"></asp:BoundColumn>
                                                                                        <asp:BoundColumn DataField="ProviderID" HeaderText="ProviderID" Visible="False"></asp:BoundColumn>
                                                                                        <asp:BoundColumn DataField="ProviderName" HeaderText="Provider Name"></asp:BoundColumn>
                                                                                        <asp:BoundColumn DataField="ProposedByID" HeaderText="ProposedByID" 
                                                                                            Visible="False"></asp:BoundColumn>
                                                                                        <asp:BoundColumn DataField="ProposedBy" HeaderText="Proposed By"></asp:BoundColumn>
                                                                                        <asp:ButtonColumn CommandName="btnAddIssue" HeaderText="ADD" Text="Issue"></asp:ButtonColumn>
                                                                                        <asp:ButtonColumn CommandName="btnAddTeam" HeaderText="ADD" Text="Team"></asp:ButtonColumn>
                                                                                    </Columns>
                                                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" 
                                                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                        ForeColor="White" HorizontalAlign="Left" />
                                                                                </asp:DataGrid>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="color: #000000">
                                                                            <td colspan="2" 
                                                                                style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                                <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                                                    Height="23px" OnClick="btnReturn_Click" Text="RETURN" 
                                                                                    ToolTip="Hide this section" Width="120px" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="color: #000000">
                                                                            <td colspan="2" 
                                                                                style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:View>
                                                                <asp:View ID="ViewNegotiationPlan" runat="server">
                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                        <tr>
                                                                            <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="4" 
                                                                                style="vertical-align: middle; width: 100%; height: 5px; text-align: center">
                                                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                                                                    <tr>
                                                                                        <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                                            &gt;&gt;&gt; &nbsp;<asp:Label ID="lblPreBidMeetingHeading" runat="server" 
                                                                                                ForeColor="Firebrick" Text="0"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:Label ID="lblNegPlanID" runat="server" Text="0" Visible="False"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="1" style="vertical-align: top; width: 50%; text-align: center">
                                                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                    <tr style="color: #000000">
                                                                                        <td class="InterFaceTableLeftRow">
                                                                                            Name of Provider</td>
                                                                                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                                                                                        </td>
                                                                                        <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                                            <asp:TextBox ID="txtProviderNameD" runat="server" autocomplete="off" 
                                                                                                Enabled="False" Font-Bold="True" Font-Size="11pt" ForeColor="Firebrick" 
                                                                                                Width="80%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td colspan="4" style="vertical-align: top; width: 50%; text-align: center">
                                                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                    <tr style="color: #000000">
                                                                                        <td class="InterFaceTableLeftRow">
                                                                                            Negotiation Proposed By</td>
                                                                                        <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                                                                                        </td>
                                                                                        <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                                            <asp:TextBox ID="txtProposedByD" runat="server" autocomplete="off" 
                                                                                                Enabled="False" Font-Bold="True" Font-Size="11pt" ForeColor="Firebrick" 
                                                                                                Width="80%"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="4" 
                                                                                style="vertical-align: top; position: static; height: 5px; text-align: center">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="4" 
                                                                                style="vertical-align: top; position: static; height: 5px; text-align: center">
                                                                                &nbsp;<asp:MultiView ID="MultiView3" runat="server">
                                                                                    <asp:View ID="View6" runat="server">
                                                                                        <table style="width: 100%">
                                                                                            <tr>
                                                                                                <td style="width: 100%; text-align: center">
                                                                                                    <table align="center" cellpadding="0" cellspacing="0" 
                                                                                                        style="margin-top: 10px; width: 60%">
                                                                                                        <tr>
                                                                                                            <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                                                                ADD NEGOTIATION PLAN DETAILS [PP Form 50]</td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                    <br />
                                                                                                    <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                                                        <tr>
                                                                                                            <td colspan="2" 
                                                                                                                style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr style="color: #000000">
                                                                                                            <td colspan="2" 
                                                                                                                style="margin: 0px; vertical-align: top; height: 5px; text-align: center">
                                                                                                                <asp:Label ID="lblMsg2" runat="server" ForeColor="Red" Text="."></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr style="color: #000000">
                                                                                                            <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                                                <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                                                                    <tr>
                                                                                                                        <td style="vertical-align: top; width: 45%; text-align: center">
                                                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                                                                <tr>
                                                                                                                                    <td class="InterFaceTableLeftRowUp">
                                                                                                                                        Issue</td>
                                                                                                                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                                                    </td>
                                                                                                                                    <td class="InterFaceTableRightRowUp">
                                                                                                                                        <asp:TextBox ID="txtIssue" runat="server" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td class="InterFaceTableLeftRowUp">
                                                                                                                                        Objective</td>
                                                                                                                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                                                        &nbsp;</td>
                                                                                                                                    <td class="InterFaceTableRightRowUp">
                                                                                                                                        <asp:TextBox ID="txtObjective" runat="server" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                            &nbsp;&nbsp;
                                                                                                                        </td>
                                                                                                                        <td style="vertical-align: top; width: 45%; color: #000000; text-align: center">
                                                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                                                            </table>
                                                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                                                                <tr>
                                                                                                                                    <td class="InterFaceTableLeftRowUp">
                                                                                                                                        Negotiation Parameter</td>
                                                                                                                                    <td class="InterFaceTableMiddleRowUp" style="width: 2%">
                                                                                                                                    </td>
                                                                                                                                    <td class="InterFaceTableRightRowUp">
                                                                                                                                        <asp:TextBox ID="txtParameter" runat="server" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                            <asp:Label ID="lblNegPlanDetailID" runat="server" Text="0" Visible="False"></asp:Label>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr style="color: #000000">
                                                                                                            <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                                                <asp:Button ID="btnAddDetails" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                                                                                    Height="23px" OnClick="btnAddDetails_Click" Text="Add Negotiation Plan Details" 
                                                                                                                    Width="214px" />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr style="color: #000000">
                                                                                                            <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr style="color: #000000">
                                                                                                            <td colspan="2" style="vertical-align: top; height: 19px; text-align: center">
                                                                                                                <asp:DataGrid ID="DataGrid4" runat="server" AutoGenerateColumns="False" 
                                                                                                                    CellPadding="4" Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" 
                                                                                                                    GridLines="None" OnItemCommand="DataGrid4_ItemCommand" 
                                                                                                                    Style="text-align: justify" Width="100%">
                                                                                                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                                                    <EditItemStyle BackColor="#999999" />
                                                                                                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                                                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                                                                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                                                                                                                        VerticalAlign="Top" />
                                                                                                                    <Columns>
                                                                                                                        <asp:BoundColumn DataField="NegotiationPlanDetailID" 
                                                                                                                            HeaderText="NegotiationPlanDetailID" Visible="False"></asp:BoundColumn>
                                                                                                                        <asp:BoundColumn DataField="Issue" HeaderText="Issue"></asp:BoundColumn>
                                                                                                                        <asp:BoundColumn DataField="Objective" HeaderText="Objective"></asp:BoundColumn>
                                                                                                                        <asp:BoundColumn DataField="NegotiationParameters" 
                                                                                                                            HeaderText="Negotiation Parameter"></asp:BoundColumn>
                                                                                                                        <asp:ButtonColumn CommandName="btnEdit" HeaderText="Edit" Text="Edit"></asp:ButtonColumn>
                                                                                                                        <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove"><ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                                                                Font-Strikeout="False" Font-Underline="False" ForeColor="Red" /></asp:ButtonColumn>
                                                                                                                    </Columns>
                                                                                                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" 
                                                                                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                                                        ForeColor="White" HorizontalAlign="Left" />
                                                                                                                </asp:DataGrid>
                                                                                                                <asp:Label ID="lblNoNegIssues" runat="server" Font-Bold="True" 
                                                                                                                    Font-Names="Cambria" ForeColor="Red" Visible="False" Width="70%">NO NEGOTIATION ISSUE(S) CURRENTLY AVAILABLE</asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr style="color: #000000">
                                                                                                            <td colspan="2" style="vertical-align: top; height: 19px; text-align: center">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr style="color: #000000">
                                                                                                            <td colspan="2" style="vertical-align: top; height: 19px; text-align: center">
                                                                                                                <asp:Button ID="btnSubmitIssue" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                                                                                    Height="23px" OnClick="btnSubmitDetails_Click" Text="SUBMIT DETAILS" 
                                                                                                                    Width="154px" />
                                                                                                                <asp:Button ID="btnPrintDetails" runat="server" Font-Bold="True" 
                                                                                                                    OnClick="btnPrintDetails_Click" Text="PRINT" Width="68px" />
                                                                                                                <asp:Button ID="btnCancelDetails" runat="server" Font-Bold="True" 
                                                                                                                    Font-Size="9pt" Height="23px" OnClick="btnCancelDetails_Click" 
                                                                                                                    Text="CANCEL / RETURN" ToolTip="Hide this section" Width="138px" />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:View>
                                                                                    &nbsp;&nbsp;
                                                                                    <asp:View ID="View7" runat="server">
                                                                                        <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                            <tr>
                                                                                                <td colspan="4" style="margin-top: 0px; margin-bottom: 0px; padding-bottom: 0px;
                                                                                                vertical-align: middle; padding-top: 0px; height: 5px; text-align: center">
                                                                                                    <table align="center" cellpadding="0" cellspacing="0" style="padding-bottom: 0px;
                                                                                                    width: 60%; padding-top: 0px">
                                                                                                        <tr>
                                                                                                            <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                                                                NEGOTIATION TEAM INFORMATION</td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="vertical-align: top; width: 50%; height: 5px; text-align: center">
                                                                                                </td>
                                                                                                <td style="vertical-align: top; width: 50%; height: 5px; text-align: center">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                                                                                        <tr>
                                                                                                            <td colspan="1" style="vertical-align: top; height: 9px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td colspan="1" style="vertical-align: top; height: 41px">
                                                                                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                                                    <tr>
                                                                                                                        <td class="InterfaceHeaderLabel" style="height: 20px">
                                                                                                                            <asp:Label ID="lblAddEditItemHeader" runat="server" Text="ADD MEMBER TO TEAM"></asp:Label>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                                <table width="100%">
                                                                                                                    <tr>
                                                                                                                        <td colspan="3" valign="top">
                                                                                                                            <asp:Label ID="lblMsg3" runat="server" Font-Bold="False" Font-Names="Cambria" 
                                                                                                                                Font-Size="11pt" ForeColor="Red" Text="."></asp:Label>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr style="font-size: 12pt; color: #000000; font-family: Times New Roman">
                                                                                                                        <td style="width: 48%" valign="top">
                                                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                                                                <tr>
                                                                                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                                                                                                                        Member</td>
                                                                                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                                                                                                                                    </td>
                                                                                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                                                                                        <asp:TextBox ID="txtMember" runat="server" autocomplete="false" Width="80%"></asp:TextBox>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                                <tr>
                                                                                                                                    <td class="InterFaceTableLeftRow" style="height: 29px">
                                                                                                                                        Position</td>
                                                                                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%; height: 29px">
                                                                                                                                    </td>
                                                                                                                                    <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                                                                                                                        <asp:TextBox ID="txtPosition" runat="server" autocomplete="false" Width="80%"></asp:TextBox>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                            <asp:Label ID="lblMemberID" runat="server" Visible="False">0</asp:Label>
                                                                                                                        </td>
                                                                                                                        <td style="width: 2%">
                                                                                                                        </td>
                                                                                                                        <td style="width: 48%" valign="top">
                                                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                                                                                <tr style="color: #000000">
                                                                                                                                    <td class="InterFaceTableLeftRow" valign="top">
                                                                                                                                        Reason for Selection</td>
                                                                                                                                    <td class="InterFaceTableMiddleRow" style="width: 2%">
                                                                                                                                    </td>
                                                                                                                                    <td class="InterFaceTableRightRow" style="width: 66%">
                                                                                                                                        <asp:DropDownList ID="cboReason" runat="server" AutoPostBack="True" 
                                                                                                                                            OnDataBound="cboReason_DataBound" 
                                                                                                                                            OnSelectedIndexChanged="cboReason_SelectedIndexChanged" Width="82%">
                                                                                                                                        </asp:DropDownList>
                                                                                                                                        <br />
                                                                                                                                        <asp:TextBox ID="txtReason" runat="server" CssClass="InterfaceTextboxMultiline" 
                                                                                                                                            Height="12px" Style="width: 90%; height: 55px" TextMode="MultiLine" 
                                                                                                                                            Visible="False" Width="70%"></asp:TextBox>
                                                                                                                                    </td>
                                                                                                                                </tr>
                                                                                                                            </table>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" 
                                                                                                                    MinimumPrefixLength="1" ServiceMethod="GetUsersByNames" 
                                                                                                                    ServicePath="CascadingddlService.asmx" TargetControlID="txtMember"></cc1:AutoCompleteExtender>
                                                                                                                &nbsp;
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td colspan="1" style="vertical-align: top">
                                                                                                                <asp:Button ID="btnAddMember" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                                                                                    Height="23px" OnClick="btnAddMember_Click" Text="Add Member" Width="132px" />
                                                                                                                &nbsp;&nbsp;
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 68%">
                                                                                                        <tr>
                                                                                                            <td class="InterfaceHeaderLabel" style="height: 20px">
                                                                                                                SELECTED NEGOTIATION TEAM MEMBERS</td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" style="vertical-align: top; height: 5px; text-align: center">
                                                                                                    <asp:DataGrid ID="DataGrid5" runat="server" AutoGenerateColumns="False" 
                                                                                                        CellPadding="4" Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" 
                                                                                                        GridLines="None" HorizontalAlign="Center" 
                                                                                                        OnItemCommand="DataGrid5_ItemCommand1" Width="100%">
                                                                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                                        <EditItemStyle BackColor="#999999" />
                                                                                                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                                                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                                                                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                                                                                        <Columns>
                                                                                                            <asp:BoundColumn DataField="MemberID" HeaderText="MemberID" Visible="False"></asp:BoundColumn>
                                                                                                            <asp:BoundColumn DataField="UserID" HeaderText="UserID" Visible="False"></asp:BoundColumn>
                                                                                                            <asp:BoundColumn DataField="Member" HeaderText="Member"></asp:BoundColumn>
                                                                                                            <asp:BoundColumn DataField="Position" HeaderText="Position"></asp:BoundColumn>
                                                                                                            <asp:BoundColumn DataField="ReasonID" HeaderText="ReasonID" Visible="False"></asp:BoundColumn>
                                                                                                            <asp:BoundColumn DataField="Reason" HeaderText="Reason"></asp:BoundColumn>
                                                                                                            <asp:BoundColumn DataField="OtherReason" HeaderText="OtherReason" 
                                                                                                                Visible="False"></asp:BoundColumn>
                                                                                                            <asp:ButtonColumn CommandName="btnEdit" HeaderText="Edit" Text="Edit"></asp:ButtonColumn>
                                                                                                            <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove"><ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                                                    Font-Strikeout="False" Font-Underline="False" ForeColor="Red" /></asp:ButtonColumn>
                                                                                                        </Columns>
                                                                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                                                                                            HorizontalAlign="Left" />
                                                                                                    </asp:DataGrid>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="vertical-align: top; width: 50%; height: 5px; text-align: center">
                                                                                                </td>
                                                                                                <td style="vertical-align: top; width: 50%; height: 5px; text-align: center">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="4" 
                                                                                                    style="vertical-align: middle; height: 22px; text-align: center">
                                                                                                    <asp:Button ID="btnSubmitTeam" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                                                                        Height="23px" OnClick="btnSubmitTeam_Click" Text="SUBMIT" Width="100px" />
                                                                                                    &nbsp;<asp:Button ID="btnPrintTeam" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                                                                        Height="23px" OnClick="btnPrintTeam_Click" Text="PRINT" 
                                                                                                        ToolTip="Print Negotiation Team" Width="100px" />
                                                                                                    <asp:Button ID="btnCancelTeam" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                                                                        Height="23px" OnClick="btnCancelTeam_Click" Text="CANCEL / RETURN" 
                                                                                                        Width="138px" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </asp:View>
                                                                                </asp:MultiView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="4" style="vertical-align: middle; text-align: center">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:View>
                                                                <asp:View ID="View12" runat="server">
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <td style="width: 98%">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 98%">
                                                                                <asp:Label ID="lblQn" runat="server" Font-Bold="True" ForeColor="Maroon" 
                                                                                    Text="Was Procurement Lotted?"></asp:Label>
                                                                                <asp:Button ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" />
                                                                                <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 98%">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:View>
                                                                <asp:View ID="View4" runat="server">
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <td style="width: 98%">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 98%">
                                                                                <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; height: 42px; text-align: center">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                                                                                <tr>
                                                                                                    <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                                                        Submit Procurement To Contracts Committee</td>
                                                                                                </tr>
                                                                                                <tr>
                                                        <td colspan="4" class="InterfaceHeaderLabel3"
                                                            style="vertical-align: top; position: static; height: 5px; text-align: center">
                                                            SELECT FORM YOUR SUBMITTING</td>
                                                    </tr>
                                                    <tr>
                                                        <td >
                                                            <asp:RadioButtonList ID="rbnForm"  runat="server" 
                                                                CssClass="InterfaceDropdownList" 
                                                                onselectedindexchanged="rbnForm_SelectedIndexChanged" >
                                                                <asp:ListItem Value="63">Form 16</asp:ListItem>
                                                                <asp:ListItem Value="106">Form 24</asp:ListItem>
                                                               
                                                                <asp:ListItem Value="110">Form 26</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 97%">
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                                                                        <asp:Label ID="lblCCOption" runat="server" Text="Select Appropriate" 
                                                                                                            Visible="False"></asp:Label>
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                                                                        <asp:DropDownList ID="cboCCOption" runat="server" Visible="False" Width="87%">
                                                                                                            <asp:ListItem Value="0">-- Select Option --</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">Award of Contract</asp:ListItem>
                                                                                                           
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; height: 3px; text-align: center">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="vertical-align: top; width: 50%; text-align: center">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp">
                                                                                                        <asp:Label ID="lblSupplier" runat="server" Text="Supplier"></asp:Label>
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableMiddleRowUp">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp">
                                                                                                        <asp:DropDownList ID="cboBidder" runat="server" 
                                                                                                            OnDataBound="cboBidder_DataBound" Width="87%">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableMiddleRowUp">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp">
                                                                                                        <asp:CheckBox ID="chkIsBidderAwarded" runat="server" Font-Bold="True" 
                                                                                                            Text="Is Best Evaluated Bidder" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp">
                                                                                                        Bid Value Currency</td>
                                                                                                    <td class="InterFaceTableMiddleRowUp">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp">
                                                                                                        <asp:DropDownList ID="cboCurrency" runat="server" 
                                                                                                            OnDataBound="cboUnit_DataBound" Width="87%">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <asp:Label ID="lblReferenceNo" runat="server" Text="0" Visible="False"></asp:Label>
                                                                                            <asp:Label ID="lblExchangeRate" runat="server" Text="0" Visible="False"></asp:Label>
                                                                                            <asp:Label ID="lblRecordID" runat="server" Text="0" Visible="False"></asp:Label>
                                                                                            <asp:Label ID="lblAreaStatus" runat="server" Text="0" Visible="False"></asp:Label>
                                                                                            <asp:Label ID="lblMsgs" runat="server" Text=" " Visible="False"></asp:Label>
                                                                                            <cc1:FilteredTextBoxExtender ID="FTEBidValue" runat="server" 
                                                                                                FilterType="Custom,Numbers" TargetControlID="txtBidValue" ValidChars=","></cc1:FilteredTextBoxExtender>
                                                                                        </td>
                                                                                        <td style="vertical-align: top; width: 50%; text-align: center">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                                                                        <asp:Label ID="lblFinalBidValue" runat="server" Text="Final Bid Value"></asp:Label>
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                                                                        <asp:TextBox ID="txtBidValue" runat="server" Font-Bold="True" 
                                                                                                            onkeyup="javascript:this.value=Comma(this.value);" Width="85%"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                                                                        Reason(include the score as well)</td>
                                                                                                    <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                                                                        <asp:TextBox ID="txtComment" runat="server" 
                                                                                                            CssClass="InterfaceTextboxMultiline" Height="80px" TextMode="MultiLine" 
                                                                                                            Width="86%"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <asp:Button ID="btnAddBiddingDetails" runat="server" Font-Bold="True" 
                                                                                                OnClick="btnAddBiddingDetails_Click" Text="ADD DETAILS" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <asp:DataGrid ID="DataGrid7" runat="server" AutoGenerateColumns="False" 
                                                                                                CellPadding="4" Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" 
                                                                                                GridLines="None" OnItemCommand="DataGrid7_ItemCommand" 
                                                                                                Style="text-align: justify" Width="100%">
                                                                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                                <EditItemStyle BackColor="#999999" />
                                                                                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                                                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                                                                                                    VerticalAlign="Top" />
                                                                                                <Columns>
                                                                                                    <asp:BoundColumn DataField="RecordID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="BidderID" HeaderText="Bidder ID" Visible="False"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="BidderName" HeaderText="Bidder Name"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="IsBEB" HeaderText="IsBEB"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="BidUnitID" HeaderText="BidUnitID" Visible="False"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="Unit" HeaderText="Currency"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="BidValue" DataFormatString="{0:N0}" 
                                                                                                        HeaderText="Bid Amount"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="Reason" HeaderText="Reason"></asp:BoundColumn>
                                                                                                    <asp:ButtonColumn CommandName="btnEdit" HeaderText="Edit" Text="Edit"></asp:ButtonColumn>
                                                                                                    <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove"><ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                                            Font-Strikeout="False" Font-Underline="False" ForeColor="Red" /></asp:ButtonColumn>
                                                                                                </Columns>
                                                                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" 
                                                                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                                    ForeColor="White" HorizontalAlign="Left" />
                                                                                            </asp:DataGrid>
                                                                                            <asp:Label ID="lblNoRecords" runat="server" Font-Bold="True" 
                                                                                                Font-Names="Cambria" ForeColor="Red" Visible="False" Width="550px">NO EVALUATION DETAILS CURRENTLY AVAILABLE</asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <asp:Button ID="btnSave" runat="server" Font-Bold="True" 
                                                                                                OnClick="btnSave_Click" Text="SAVE" Width="84px" />
                                                                                            &nbsp;<asp:Button ID="btnSubmitToCC" runat="server" Font-Bold="True" 
                                                                                                OnClick="btnSubmitToCC_Click" Text="SUBMIT TO CC / HQ PDU" Width="260px" />
                                                                                            <asp:Button ID="btnCancelSubmit" runat="server" Font-Bold="True" 
                                                                                                OnClick="btnCancel_Click" Text="CANCEL" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:View>
                                                                <asp:View ID="View14" runat="server">
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <td style="width: 98%">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 98%">
                                                                                <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                                                                                <tr>
                                                                                                    <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                                                        PROCUREMENT LOTT DETAILS</td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <asp:Label ID="lblMsg4" runat="server" Font-Bold="False" Font-Names="Cambria" 
                                                                                                Font-Size="11pt" ForeColor="Red" Text="."></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="vertical-align: top; width: 50%; text-align: center">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp">
                                                                                                        Enter Lott Number</td>
                                                                                                    <td class="InterFaceTableMiddleRowUp">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp">
                                                                                                        <asp:TextBox ID="txtLottNumber" runat="server" Font-Bold="True" 
                                                                                                            onkeyup="javascript:this.value=Comma(this.value);" Width="85%"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <asp:Label ID="lblLottID" runat="server" Text="0" Visible="False"></asp:Label>
                                                                                            &nbsp;
                                                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" 
                                                                                                FilterType="Custom,Numbers" TargetControlID="txtLottNumber" ValidChars=","></cc1:FilteredTextBoxExtender>
                                                                                        </td>
                                                                                        <td style="vertical-align: top; width: 50%; text-align: center">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                            </table>
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                                                                        Enter Lott Description</td>
                                                                                                    <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                                                                        &nbsp;</td>
                                                                                                    <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                                                                        <asp:TextBox ID="txtLottDescription" runat="server" 
                                                                                                            CssClass="InterfaceTextboxMultiline" Height="80px" TextMode="MultiLine" 
                                                                                                            Width="86%"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <br />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <asp:Button ID="btnAddLott" runat="server" Font-Bold="True" 
                                                                                                OnClick="btnAddLott_Click" Text="ADD LOTT" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <asp:DataGrid ID="DataGrid8" runat="server" AutoGenerateColumns="False" 
                                                                                                CellPadding="4" Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" 
                                                                                                GridLines="None" OnItemCommand="DataGrid8_ItemCommand" 
                                                                                                Style="text-align: justify" Width="100%">
                                                                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                                <EditItemStyle BackColor="#999999" />
                                                                                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                                                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                                                                                                    VerticalAlign="Top" />
                                                                                                <Columns>
                                                                                                    <asp:BoundColumn DataField="LottID" HeaderText="LottID" Visible="False"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="LottNumber" HeaderText="Lott No."></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="LottDescription" HeaderText="Lott Description"></asp:BoundColumn>
                                                                                                    <asp:ButtonColumn CommandName="btnEdit" HeaderText="Edit" Text="Edit"></asp:ButtonColumn>
                                                                                                    <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove"><ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                                            Font-Strikeout="False" Font-Underline="False" ForeColor="Red" /></asp:ButtonColumn>
                                                                                                </Columns>
                                                                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" 
                                                                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                                    ForeColor="White" HorizontalAlign="Left" />
                                                                                            </asp:DataGrid>
                                                                                            <asp:Label ID="lblNoLotts" runat="server" Font-Bold="True" Font-Names="Cambria" 
                                                                                                ForeColor="Red" Visible="False" Width="550px">NO LOTTS CURRENTLY AVAILABLE</asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <asp:Button ID="btnSaveLotts" runat="server" Font-Bold="True" 
                                                                                                OnClick="btnSaveLotts_Click" Text="SAVE" Width="84px" />
                                                                                            &nbsp;&nbsp;<asp:Button ID="btnAddLottDetails" runat="server" Enabled="False" 
                                                                                                Font-Bold="True" OnClick="btnAddLottDetails_Click" Text="ADD LOTT EVALUATIONS" 
                                                                                                Width="198px" />
                                                                                            <asp:Button ID="btnLottCancel" runat="server" Font-Bold="True" 
                                                                                                OnClick="btnLottCancel_Click" Text="CANCEL / RETURN" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:View>
                                                                <asp:View ID="View15" runat="server">
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <td style="width: 98%">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 98%">
                                                                                <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; height: 42px; text-align: center">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 60%">
                                                                                                <tr>
                                                                                                    <td class="InterfaceHeaderLabel3" style="height: 17px">
                                                                                                        Submit Procurement To Contracts Committee</td>
                                                                                                </tr>
                                                                                             
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 97%">
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                                                                        <asp:Label ID="lblCCOptionLott" runat="server" Text="Select Appropriate" 
                                                                                                            Visible="False"></asp:Label>
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                                                                        <asp:DropDownList ID="cboCCOptionLott" runat="server" Visible="False" 
                                                                                                            Width="87%">
                                                                                                            <asp:ListItem Value="0">-- Select Option --</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">Award of Contract</asp:ListItem>
                                                                                                            <asp:ListItem Value="2">Negotiation</asp:ListItem>
                                                                                                            <asp:ListItem Value="3">Post Qualification</asp:ListItem>
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    
                                                                                    <tr>
                                                                                        <td style="vertical-align: top; width: 50%; text-align: center">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp">
                                                                                                        <asp:Label ID="Label2" runat="server" Text="Supplier"></asp:Label>
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableMiddleRowUp">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp">
                                                                                                        <asp:DropDownList ID="cboSupplierLott" runat="server" 
                                                                                                            OnDataBound="cboSupplierLott_DataBound" Width="87%">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableMiddleRowUp">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp">
                                                                                                        <asp:CheckBox ID="chkIsBidderAwardedLott" runat="server" Font-Bold="True" 
                                                                                                            Text="Is Best Evaluated Bidder" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp">
                                                                                                        Lott</td>
                                                                                                    <td class="InterFaceTableMiddleRowUp">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp">
                                                                                                        <asp:DropDownList ID="cboLott" runat="server" OnDataBound="cboLott_DataBound" 
                                                                                                            Width="87%">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp">
                                                                                                        Bid Value Currency</td>
                                                                                                    <td class="InterFaceTableMiddleRowUp">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp">
                                                                                                        <asp:DropDownList ID="cboCurrencyLott" runat="server" 
                                                                                                            OnDataBound="cboCurrencyLott_DataBound" Width="87%">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <asp:Label ID="lblLottReference" runat="server" Text="0" Visible="False"></asp:Label>
                                                                                            &nbsp;
                                                                                            <asp:Label ID="lblRecordIDLott" runat="server" Text="0"></asp:Label>
                                                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" 
                                                                                                FilterType="Custom,Numbers" TargetControlID="txtBidValueLott" ValidChars=","></cc1:FilteredTextBoxExtender>
                                                                                        </td>
                                                                                        <td style="vertical-align: top; width: 50%; text-align: center">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                            </table>
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                                                                        <asp:Label ID="Label7" runat="server" Text="Final Bid Value"></asp:Label>
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                                                                        <asp:TextBox ID="txtBidValueLott" runat="server" Font-Bold="True" 
                                                                                                            onkeyup="javascript:this.value=Comma(this.value);" Width="85%"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="InterFaceTableLeftRowUp" style="height: 30px">
                                                                                                        Reason</td>
                                                                                                    <td class="InterFaceTableMiddleRowUp" style="height: 30px">
                                                                                                    </td>
                                                                                                    <td class="InterFaceTableRightRowUp" style="height: 30px">
                                                                                                        <asp:TextBox ID="txtCommentLott" runat="server" 
                                                                                                            CssClass="InterfaceTextboxMultiline" Height="80px" TextMode="MultiLine" 
                                                                                                            Width="86%"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <asp:Button ID="btnAddLottEvaluations" runat="server" Font-Bold="True" 
                                                                                                OnClick="btnAddLottEvaluations_Click" Text="ADD DETAILS" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <asp:DataGrid ID="DataGrid9" runat="server" AutoGenerateColumns="False" 
                                                                                                CellPadding="4" Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" 
                                                                                                GridLines="None" Style="text-align: justify" Width="100%">
                                                                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                                <EditItemStyle BackColor="#999999" />
                                                                                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                                                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" 
                                                                                                    VerticalAlign="Top" />
                                                                                                <Columns>
                                                                                                    <asp:BoundColumn DataField="RecordID" HeaderText="ID" Visible="False"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="BidderID" HeaderText="Bidder ID" Visible="False"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="BidderName" HeaderText="Bidder Name"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="IsBEB" HeaderText="IsBEB"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="LottID" HeaderText="Lott ID" Visible="false"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="LottNumber" HeaderText="Lott No."></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="LottDescription" HeaderText="Lott Description"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="BidUnitID" HeaderText="BidUnitID" Visible="False"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="Unit" HeaderText="Currency"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="BidValue" DataFormatString="{0:N0}" 
                                                                                                        HeaderText="Bid Amount"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="Reason" HeaderText="Reason"></asp:BoundColumn>
                                                                                                    <asp:ButtonColumn CommandName="btnEdit" HeaderText="Edit" Text="Edit"></asp:ButtonColumn>
                                                                                                    <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove"><ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" 
                                                                                                            Font-Strikeout="False" Font-Underline="False" ForeColor="Red" /></asp:ButtonColumn>
                                                                                                </Columns>
                                                                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" Font-Italic="False" 
                                                                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
                                                                                                    ForeColor="White" HorizontalAlign="Left" />
                                                                                            </asp:DataGrid>
                                                                                            <asp:Label ID="lblNoLottEvaluations" runat="server" Font-Bold="True" 
                                                                                                Font-Names="Cambria" ForeColor="Red" Visible="False" Width="550px">NO EVALUATION DETAILS CURRENTLY AVAILABLE</asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <asp:Button ID="btnSaveLottDetails" runat="server" Font-Bold="True" 
                                                                                                OnClick="btnSaveLottDetails_Click" Text="SAVE" Width="84px" />
                                                                                            &nbsp;&nbsp;
                                                                                            <asp:Button ID="btnSubmitLotts" runat="server" Font-Bold="True" 
                                                                                                OnClick="btnSubmitLotts_Click" Text="SUBMIT TO CC / PDU" Width="164px" />
                                                                                            <asp:Button ID="btnCancelLottDetails" runat="server" Font-Bold="True" 
                                                                                                OnClick="btnCancelLottDetails_Click" Text="CANCEL / RETURN" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:View>
                                                                <asp:View ID="View3" runat="server">
                                                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                        <tr>
                                                                            <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="4" style="vertical-align: middle; height: 5px; text-align: center">
                                                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 97%">
                                                                                    <tr>
                                                                                        <td class="InterFaceTableLeftRowUp">
                                                                                            Choose Submission Form Section:</td>
                                                                                        <td class="InterFaceTableMiddleRowUp">
                                                                                        </td>
                                                                                        <td class="InterFaceTableRightRowUp" style="width: 66%">
                                                                                            <asp:DropDownList ID="cboDashboard" runat="server" AutoPostBack="True" 
                                                                                                BackColor="AliceBlue" EnableViewState="true" Font-Bold="True" 
                                                                                                OnDataBound="cboDashboard_DataBound" 
                                                                                                OnSelectedIndexChanged="cboDashboard_SelectedIndexChanged" Width="96%">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:Label ID="lblProcMethod" runat="server" Text="0" Visible="False"></asp:Label>
                                                                                <asp:Label ID="lblRefNo" runat="server" Text="0" Visible="False"></asp:Label>
                                                                                <asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="4" style="vertical-align: middle; height: 9px; text-align: center">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="4" 
                                                                                style="vertical-align: middle; height: 22px; text-align: center">
                                                                                <table align="center" cellpadding="0" cellspacing="0" class="style12">
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; text-align: center">
                                                                                            <asp:DataGrid ID="DataGrid6" runat="server" AutoGenerateColumns="False" 
                                                                                                CellPadding="4" Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" 
                                                                                                GridLines="None" HorizontalAlign="Center" Width="97%">
                                                                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                                                <EditItemStyle BackColor="#999999" />
                                                                                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                                                                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                                                                                                <Columns>
                                                                                                    <asp:BoundColumn DataField="Id" HeaderText="Question ID" Visible="False"></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="Code" HeaderText=" "></asp:BoundColumn>
                                                                                                    <asp:BoundColumn DataField="Question" HeaderText="Question"><ItemStyle Width="300px" /></asp:BoundColumn>
                                                                                                    <asp:TemplateColumn HeaderText="Answer"><ItemTemplate><asp:TextBox ID="txtAnswer" runat="server" EnableViewState="true" 
                                                                                                                Text='<%# DataBinder.Eval(Container, "DataItem.Answer") %>' 
                                                                                                                TextMode="MultiLine" Width="300px">
		                                </asp:TextBox></ItemTemplate><ItemStyle HorizontalAlign="Center" /></asp:TemplateColumn>
                                                                                                </Columns>
                                                                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                                                                                                    HorizontalAlign="Left" />
                                                                                            </asp:DataGrid>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; height: 10px; text-align: center">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; height: 10px; text-align: center">
                                                                                            <asp:Button ID="btnPrint" runat="server" Enabled="False" Font-Bold="True" 
                                                                                                Font-Size="9pt" Height="23px" OnClick="btnPrint_Click" Text="PRINT" 
                                                                                                Visible="False" Width="120px" />
                                                                                            <asp:Button ID="btnDone" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                                                                Height="23px" OnClick="btnDone_Click" Text="CANCEL / RETURN" 
                                                                                                ToolTip="Return to List of Procurements" Width="138px" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" style="vertical-align: top; height: 10px; text-align: center">
                                                                                            &nbsp; &nbsp;&nbsp;</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:View>
                                                                &nbsp;
                                                                <asp:View ID="View13" runat="server">
                                                                    <table style="width: 100%">
                                                                        <tr>
                                                                            <td colspan="3" style="width: 100%; height: 21px; text-align: center">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="InterFaceTableLeftRowUp" colspan="3" 
                                                                                style="width: 100%; text-align: center">
                                                                                <asp:Label ID="lblsubheading" runat="server" Font-Bold="True" 
                                                                                    Font-Names="Cambria" Font-Size="11pt"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" style="width: 100%; text-align: center">
                                                                                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Cambria" 
                                                                                    Font-Size="11pt" ForeColor="Red"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="vertical-align: top; width: 49%; text-align: center">
                                                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                                                                                    <tr>
                                                                                        <td colspan="3">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                                                                                <tr>
                                                                                                    <td class="InterfaceHeaderLabel3" style="height: 18px">
                                                                                                        Attach Form</td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="3" style="height: 16px">
                                                                                            <br />
                                                                                            <asp:Button ID="btndownload" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                                                                ForeColor="Red" Height="23px" OnClick="btndownload_click" 
                                                                                                Text="Click HERE to Download Form template" Width="260px" />
                                                                                            <br />
                                                                                            <br />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="3" style="vertical-align: top; height: 19px; text-align: left">
                                                                                            <table align="center" cellpadding="0" cellspacing="0" style="border-right: #a4a2ca 1px solid;
                                                                border-top: #a4a2ca 1px solid; border-left: #a4a2ca 1px solid; width: 90%; border-bottom: #a4a2ca 1px solid;
                                                                background-color: #ffffff">
                                                                                                <tr>
                                                                                                    <td style="height: 19px">
                                                                                                        UPLOAD COMPLETELY FILLED IN FORM FOR SUBMISSION
                                                                                                        <br />
                                                                                                        <p ID="upload-area2">
                                                                                                            <input id="FileField1" runat="server" size="60" type="file" />
                                                                                                        </p>
                                                                                                        <p>
                                                                                                            <input id="Button2" onclick="addFileUploadBox1()" type="button" value="Add a file" />
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
                                                                                                        View Attachment</td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="3" style="height: 16px">
                                                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                                                                                                CssClass="gridgeneralstyle" DataKeyNames="FileID" GridLines="None" 
                                                                                                HorizontalAlign="Center" OnRowCommand="GridView1_RowCommand" PageSize="15" 
                                                                                                Width="98%">
                                                                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                                                <RowStyle CssClass="gridRowStyle" />
                                                                                                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                                                                <Columns>
                                                                                                    <asp:ButtonField CommandName="ViewDetails" Text="View"><HeaderStyle CssClass="gridEditField" /><ItemStyle CssClass="gridEditField" ForeColor="#003399" 
                                                                                                        HorizontalAlign="Center" Width="140px" /></asp:ButtonField>
                                                                                                    <asp:TemplateField><ItemTemplate><asp:LinkButton ID="btnRemove" runat="server" 
                                                                                                                CommandArgument='<%# Eval("FileID") %>' CommandName="btnRemove" Text="Remove" 
                                                                                                                Visible='<%# IsFileRemoveable((Int32)Eval("IsRemoveable")) %>'></asp:LinkButton></ItemTemplate><ItemStyle CssClass="gridEditField" ForeColor="#003399" /></asp:TemplateField>
                                                                                                    <asp:BoundField DataField="FileID" HeaderText="FileID" />
                                                                                                    <asp:BoundField DataField="FileName" HeaderText="FileName" />
                                                                                                    <asp:BoundField DataField="IsRemoveable" HeaderText="IsRemoveable" 
                                                                                                        Visible="false" />
                                                                                                </Columns>
                                                                                                <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                                                                <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                                                            </asp:GridView>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="3">
                                                                                            &nbsp;<asp:Label ID="lblNoAttachments1" runat="server" Font-Names="Cambria" 
                                                                                                Font-Size="11pt" ForeColor="Red" Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label>
                                                                                        </td>
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
                                                                                <asp:Label ID="lblattach" runat="server" Text="0" Visible="False"></asp:Label>
                                                                                <asp:Button ID="btnSubmitFinal" runat="server" Enabled="true" Font-Bold="True" 
                                                                                    Font-Size="9pt" Height="23px" OnClick="btnSubmitFinal_Click" 
                                                                                    Text="UPLOAD AND SUBMIT" Width="150px" />
                                                                                <asp:Button ID="Button4" runat="server" Font-Bold="True" Font-Size="9pt" 
                                                                                    Height="23px" OnClick="btnReturn_Click" Text="RETURN" Width="80px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:View>
                                                            </asp:MultiView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" 
                                                            style="vertical-align: middle; height: 19px; text-align: center">
                                                        </td>
                                                    </tr>
                                                
                                            </table>
                                        </asp:View>
                                    </asp:MultiView></asp:View>
                            </asp:MultiView>&nbsp;&nbsp;<br />
                            &nbsp;</td>
                    </tr>
                </table>
                <br />
                <asp:Label ID="lblPD_Code" runat="server" Text="0" Visible="False"></asp:Label></td>
        </tr>
    </table>
    &nbsp;
 
   <script type="text/javascript">
    function Comma(Num)
    {
       Num += '';
       Num = Num.replace(',' , '');Num = Num.replace(',' , '');Num = Num.replace(',' , '');
       Num = Num.replace(',' , '');Num = Num.replace(',' , '');Num = Num.replace(',' , '');
       x = Num.split('.');
       x1 = x[0];
       x2 = x.length > 1 ? '.' + x[1] : '';
       var rgx = /(\d+)(\d{3})/;
       while (rgx.test(x1))
       x1 = x1.replace(rgx, '$1' + ',' + '$2');
       return x1 + x2;
    }
   
</script>

 <script type="text/javascript">
     function addFileUploadBox() {
         if (!document.getElementById || !document.createElement)
             return false;

         var uploadArea = document.getElementById("upload-area");
         if (!uploadArea)
             return;

         var newline = document.createElement("br");
         uploadArea.appendChild(newline);

         var newUploadBox = document.createElement("input");
         newUploadBox.type = "file";
         newUploadBox.size = "60";
         if (!addFileUploadBox.lastAssignedId)
             addFileUploadBox.lastAssignedId = 100;

         newUploadBox.setAttribute("id", "FileField" + addFileUploadBox.lastAssignedId);
         newUploadBox.setAttribute("name", "FileField" + addFileUploadBox.lastAssignedId);
         uploadArea.appendChild(newUploadBox);
         addFileUploadBox.lastAssignedId++;
     }

     function addFileUploadBox1() {
         if (!document.getElementById || !document.createElement)
             return false;

         var uploadArea = document.getElementById("upload-area2");
         if (!uploadArea)
             return;

         var newline = document.createElement("br");
         uploadArea.appendChild(newline);

         var newUploadBox = document.createElement("input");
         newUploadBox.type = "file";
         newUploadBox.size = "60";
         if (!addFileUploadBox.lastAssignedId)
             addFileUploadBox.lastAssignedId = 100;

         newUploadBox.setAttribute("id", "FileField1" + addFileUploadBox.lastAssignedId);
         newUploadBox.setAttribute("name", "FileField1" + addFileUploadBox.lastAssignedId);
         uploadArea.appendChild(newUploadBox);
         addFileUploadBox.lastAssignedId++;
     }

   </script>
</asp:Content>







