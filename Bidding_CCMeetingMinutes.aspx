<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Bidding_CCMeetingMinutes.aspx.cs" Inherits="Bidding_CCMeetingMinutes" Title="CONTRACTS COMMITTEE MEETING MINUTES" %>

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
                            <asp:Label ID="Label1" runat="server" Text="CONTRACTS COMMITTEE MEETING MINUTES"></asp:Label></td>
                    </tr>
                </table>
            </td>
    </tr>
    <tr>
    </tr>
    <tr>
        <td style="vertical-align: top; text-align: center">
        </td>
    </tr>
          <tr>
                        <td style="vertical-align: top; text-align: center">
                            <asp:MultiView ID="MultiView1" runat="server">
                                <asp:View ID="View1" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td colspan="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1">
            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                <tr>
                    <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 20%; height: 18px;
                        text-align: center">
                        CONTRACTS COMMITTEE</td>
                    <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 20%; height: 18px;
                        text-align: center">
                        MEETING REF. NO.</td>
                    <td class="InterfaceHeaderLabel2" style="vertical-align: middle; width: 20%; height: 18px;
                        text-align: center">
                        </td>
                </tr>
                <tr>
                    <td class="ddcolortabsline2" colspan="3" style="vertical-align: middle; text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="vertical-align: middle; width: 20%; text-align: center; height: 23px;">
                        <asp:DropDownList ID="cboCC" runat="server" AutoPostBack="True" OnDataBound="cboCC_DataBound" Width="90%">
                        </asp:DropDownList></td>
                    <td style="vertical-align: middle; width: 20%; text-align: center; height: 23px;">
                        <asp:TextBox ID="txtMeetingRefNo" runat="server" Enabled="False"></asp:TextBox></td>
                    <td style="vertical-align: middle; width: 20%; height: 23px; text-align: center">
                        <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Height="23px" OnClick="btnOK_Click"
                            Text="SEARCH" Width="100px" Font-Bold="True" /></td>
                </tr>
                <tr>
                    <td style="vertical-align: middle; width: 20%; height: 23px; text-align: center">
                    </td>
                    <td style="vertical-align: middle; width: 20%; height: 23px; text-align: center">
                    </td>
                    <td style="vertical-align: middle; width: 20%; height: 23px; text-align: center">
                    </td>
                </tr>
            </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1">
                                                <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                    OnClick="Button1_Click" Text="ADD CC MEETING MINUTES" Width="192px" /></td>
                                        </tr>
                                        <tr>
                                            <td style="vertical-align: top; width: 49%; text-align: center">
                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                                                    <tr>
                                                        <td colspan="3" style="height: 16px">
                                                            <asp:GridView ID="GridAttachments" runat="server" AutoGenerateColumns="false" CssClass="gridgeneralstyle"
                                                                DataKeyNames="FileID" GridLines="None" HorizontalAlign="Center" OnRowCommand="GridAttachments_RowCommand"
                                                                PageSize="15" Width="95%">
                                                                <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                                <RowStyle CssClass="gridRowStyle" />
                                                                <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                                <Columns>
                                                                    <asp:ButtonField CommandName="ViewDetails" Text="View">
                                                                        <HeaderStyle CssClass="gridEditField" />
                                                                        <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                                            Width="140px" />
                                                                    </asp:ButtonField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="btnRemove" CommandName="btnRemove" runat="server" Text="Remove" Visible='<%# IsFileRemoveable((Int32)Eval("IsRemoveable")) %>'></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="gridEditField" ForeColor="#003399" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="FileID" HeaderText="FileID" />
                                                                    <asp:BoundField DataField="FileName" HeaderText="FileName" />
                                                                    <asp:BoundField DataField="IsRemoveable" HeaderText="IsRemoveable" Visible="False" />
                                                                </Columns>
                                                                <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                                                <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            &nbsp;<asp:Label ID="lblNoAttachments" runat="server" Font-Bold="True" Font-Names="Cambria"
                                                                Font-Size="11pt" ForeColor="Red" Text="NO CC MEETING MINUTES FOUND" Visible="False"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="height: 16px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" colspan="1" style="width: 100%; text-align: center">
                                                CC MEETING MINUTES</td>
                                        </tr>
                                        <tr>
                                            <td colspan="1">
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
                                                                        New Attachments</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="height: 16px">
                                                            <table align="center" cellpadding="0" cellspacing="0" style="width: 90%">
                                                                <tr>
                                                                    <td class="InterFaceTableLeftRowUp">
                                                                        CC
                        Meeting Ref No.</td>
                                                                    <td class="InterFaceTableMiddleRowUp">
                                                                    </td>
                                                                    <td class="InterFaceTableRightRowUp">
                                                                        <asp:TextBox ID="txtCCRefNo" runat="server" Font-Bold="True" Width="85%"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
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
                                        </tr>
                                        <tr>
                                            <td colspan="1" style="vertical-align: top; width: 100%; text-align: center">
                                                <asp:Button ID="btnSaveFile" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                    OnClick="btnSaveFile_Click" Text="SAVE " Width="80px" />
                                                <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px"
                                                    OnClick="btnReturn_Click" Text="RETURN" Width="80px" /></td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView></td>
                    </tr>
    <tr>
        <td style="vertical-align: top; text-align: center">
        </td>
    </tr>
</table>

</asp:Content>

