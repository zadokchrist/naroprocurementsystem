<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="General_AddUser1.aspx.cs" 
Inherits="AddUser" 
Title="NEW SYSTEM USER"

Culture="auto" 
UICulture="auto" %>
 <%@ Register 
 Assembly="AjaxControlToolkit" 
 Namespace="AjaxControlToolkit" 
 TagPrefix="ajaxToolkit" %>
 <%@ Import
  Namespace="System.Threading" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


      <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>

    
    
    <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td style="text-align: center; vertical-align: middle">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 50%">
                                <tr>
                                    <td class="InterfaceHeaderLabel">
                                        SYSTEM USERS</td>
                                </tr>
                            </table>
            </td>
        </tr>
        <tr>
            <td class="ddcolortabsline2" style="height: 12px">
                &nbsp;</td>
        </tr>
        </table>
            <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td style="width: 100%">
                <table align ="center" cellpadding="0" cellspacing="0" class="style12" width="92%">
                    <tr>
                        <td style="vertical-align: top; width: 50%; text-align: left; height: 5px;">
                <table align ="center" cellpadding="0" cellspacing="0" style="width: 96%">
                    <tr>
                        <td class="InterfaceHeaderLabel3" style="height: 18px">
                            User Details</td>
                    </tr>
                </table>
                        </td>
                        <td style="vertical-align: top; width: 4%; text-align: center; height: 5px;">
                        </td>
                        <td style="vertical-align: top; width: 48%; text-align: left; height: 5px;">
                <table align ="center" cellpadding="0" cellspacing="0" style="width: 96%">
                    <tr>
                        <td class="InterfaceHeaderLabel3">
                            System Module Access Levels</td>
                    </tr>
                </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; vertical-align: top; width: 50%; height: 250px;">
                            <table style="width: 100%">
                                <tr>
                                    <td style="width: 48%">
                                                                <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                                                    <tr>
                                                                        <td class="InterFaceTableLeftRowUp">
                                                                            First Name</td>
                                                                        <td class="InterFaceTableMiddleRowUp">
                                                                        </td>
                                                                        <td class="InterFaceTableRightRowUp">
                                                                            <asp:TextBox ID="TxtFname" runat="server" CssClass="InterfaceTextboxLongReadOnly"
                                                                                Width="60%"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="InterFaceTableLeftRowUp">
                                                                            Middle Name</td>
                                                                        <td class="InterFaceTableMiddleRowUp">
                                                                        </td>
                                                                        <td class="InterFaceTableRightRowUp">
                                                                            <asp:TextBox ID="txtMiddleName" runat="server" CssClass="InterfaceTextboxLongReadOnly"
                                                                                Width="60%"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="InterFaceTableLeftRow">
                                                                            Last Name</td>
                                                                        <td class="InterFaceTableMiddleRow">
                                                                            &nbsp;</td>
                                                                        <td class="InterFaceTableRightRow">
                                                                            <asp:TextBox ID="txtLname" runat="server" CssClass="InterfaceTextboxLongReadOnly"
                                                                                Width="60%"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="InterFaceTableLeftRow">
                                                                            Email</td>
                                                                        <td class="InterFaceTableMiddleRow">
                                                                            &nbsp;</td>
                                                                        <td class="InterFaceTableRightRow">
                                                                            <asp:TextBox ID="txtemail" runat="server" CssClass="InterfaceTextboxLongReadOnly"
                                                                                Width="60%"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="InterFaceTableLeftRow">
                                                                            Phone</td>
                                                                        <td class="InterFaceTableMiddleRow">
                                                                        </td>
                                                                        <td class="InterFaceTableRightRow">
                                                                            <asp:TextBox ID="txtphone" runat="server" CssClass="InterfaceTextboxLongReadOnly"
                                                                                Width="60%"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="InterFaceTableLeftRow">
                                                                            Title / Designation</td>
                                                                        <td class="InterFaceTableMiddleRow">
                                                                        </td>
                                                                        <td class="InterFaceTableRightRow">
                                                                            <asp:TextBox ID="txtDesignation" runat="server" CssClass="InterfaceTextboxMultiline"
                                                                                Height="40px" TextMode="MultiLine" Width="60%"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="InterFaceTableLeftRow">
                                                                            Upload
                                                                            Signature</td>
                                                                        <td class="InterFaceTableMiddleRow">
                                                                        </td>
                                                                        <td class="InterFaceTableRightRow">
                                                                            <asp:FileUpload ID="imgUpload" runat="server" Width="98%" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" style="height: 12px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="InterFaceTableLeftRow">
                                                                            Uploaded Signature</td>
                                                                        <td class="InterFaceTableMiddleRow">
                                                                        </td>
                                                                        <td class="InterFaceTableRightRow">
                                                                            <asp:Image ID="Image1" runat="server" Height="50px" Style="width: 200px" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="InterfaceItemSeparator" >
                                                                            &nbsp;</td>
                                                                        <td class="InterfaceItemSeparator" >
                                                                            &nbsp;</td>
                                                                        <td class="InterfaceItemSeparator" >
                                                                            <p>Upload an image (.jpg) of max size: </p>
                                                                            &nbsp; 20Kb</td>

                                                                    </tr>
                                                                </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="vertical-align: top; width: 4%; height: 250px; text-align: center">
                        </td>
                        <td style="text-align: left; vertical-align: top; width: 48%; height: 369px;"><table style="width: 100%">
                            <tr>
                                <td style="width: 48%; height: 250px;">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp">
                                                Company</td>
                                            <td class="InterFaceTableMiddleRowUp">
                                            </td>
                                            <td class="InterFaceTableRightRowUp">
                                                <asp:DropDownList ID="cboAreas" runat="server" Width="60%" AutoPostBack="True" OnDataBound="cboAreas_DataBound" OnSelectedIndexChanged="cboAreas_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp">
                                                Cost Center</td>
                                            <td class="InterFaceTableMiddleRowUp">
                                            </td>
                                            <td class="InterFaceTableRightRowUp">
                                                <asp:DropDownList ID="cboCostCenter" runat="server" Width="60%" OnDataBound="cboCostCenter_DataBound">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableLeftRow">
                                                Access Level</td>
                                            <td class="InterFaceTableMiddleRow">
                                                &nbsp;</td>
                                            <td class="InterFaceTableRightRow">
                                                <asp:DropDownList ID="cboAccessLevel" runat="server" Width="60%" AutoPostBack="True" OnDataBound="cboAccessLevel_DataBound" OnSelectedIndexChanged="cboAccessLevel_SelectedIndexChanged">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableLeftRow">
                                            </td>
                                            <td class="InterFaceTableMiddleRow">
                                            </td>
                                            <td class="InterFaceTableRightRow">
                                                <asp:CheckBox ID="chkIsPDUMember" runat="server" AutoPostBack="True" OnCheckedChanged="chkIsPDUMember_CheckedChanged"
                                                    Text="Is PDU Member" /><br />
                                                <asp:CheckBox ID="chkIsPDUSupervisor" runat="server" Text="Is Procurement Supervisor" Visible="False" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="InterfaceHeaderLabel3" colspan="3" style="text-align: center">
                                                    System Modules</td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableRightRow" colspan="3" style="text-align: center">
                                        <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid;
                                            border-left: #617da6 1px solid; width: 80%; border-bottom: #617da6 1px solid">
                                            <tr>
                                                <td style="vertical-align: top; text-align: left; height: 147px;">
                                                    <asp:CheckBoxList ID="chkModule" runat="server" CssClass="InterfaceDropdownList"
                                                        Font-Size="8pt" Height="110px" Width="95%" Enabled="False" Font-Bold="True">
                                                        <asp:ListItem Value="2">Planning Module</asp:ListItem>
                                                        <asp:ListItem Value="3">Requisition Module</asp:ListItem>
                                                        <asp:ListItem Value="4">Bidding and Evaluation Module</asp:ListItem>
                                                    </asp:CheckBoxList></td>
                                            </tr>
                                        </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="InterfaceItemSeparator" colspan="3">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        </td>
                    </tr>
                </table>
                                                                <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Height="23px"
                                                                    Text="SAVE USER" Width="150px" Font-Bold="True" OnClick="btnOK_Click" /></td>
        </tr>
                <tr>
                    <td style="height: 5px">
                <asp:Label ID="lblCode" runat="server" Text="0" Visible="False"></asp:Label><br />
                    </td>
                </tr>
    </table>

</asp:Content>

