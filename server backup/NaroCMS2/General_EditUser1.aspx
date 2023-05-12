<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="General_EditUser1.aspx.cs" Inherits="General_EditUser" Title="EDIT USERS" %>

 <%@ Register 
 Assembly="AjaxControlToolkit" 
 Namespace="AjaxControlToolkit" 
 TagPrefix="ajaxToolkit" %>
 <%@ Import
  Namespace="System.Threading" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    

    
    
    <table cellpadding="0" cellspacing="0" class="style12">
        <tr>
            <td style="text-align: center; vertical-align: middle">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 50%">
                                <tr>
                                    <td class="InterfaceHeaderLabel">
                                        EDIT
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
            <td style="width: 100%;">
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
                        <td style="text-align: left; vertical-align: top; width: 50%; height: 200px;">
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
                                                                            Username</td>
                                                                        <td class="InterFaceTableMiddleRow">
                                                                            &nbsp;</td>
                                                                        <td class="InterFaceTableRightRow">
                                                                            <asp:TextBox ID="txtUsername" runat="server" CssClass="InterfaceTextboxLongReadOnly"
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
                                                                        <td class="InterFaceTableLeftRow" style="height: 30px">
                                                                            Uploaded Signature</td>
                                                                        <td class="InterFaceTableMiddleRow" style="height: 30px">
                                                                        </td>
                                                                        <td class="InterFaceTableRightRow" style="height: 30px">
                                                                            <asp:Image ID="Image1" runat="server" Height="50px" Style="width: 200px" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="InterFaceTableLeftRow">
                                                                        </td>
                                                                        <td class="InterFaceTableMiddleRow">
                                                                        </td>
                                                                        <td class="InterFaceTableRightRow">
                                                                            <asp:CheckBox ID="chkIsInventoryStaff" runat="server"
                                                                                Text="Is Inventory Staff" /><br />
                                                                            <asp:CheckBox ID="chkIsPDUMember" runat="server" AutoPostBack="True" OnCheckedChanged="chkIsPDUMember_CheckedChanged"
                                                                                Text="Is PDU Member" /><br />
                                                                            <asp:CheckBox ID="chkIsPDUSupervisor" runat="server" Text="Is Procurement Supervisor" Visible="False" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="InterfaceItemSeparator" colspan="3">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="vertical-align: top; width: 4%; height: 200px; text-align: center">
                        </td>
                        <td style="text-align: left; vertical-align: top; width: 48%; height: 200px;"><table style="width: 100%">
                            <tr>
                                <td style="width: 48%">
                                    
                                        
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
                                                Reset Password</td>
                                            <td class="InterFaceTableMiddleRow">
                                            </td>
                                            <td class="InterFaceTableRightRow">
                                                <asp:CheckBox ID="CheckBox1" runat="server" Font-Bold="True" Text="Yes" /></td>
                                        </tr>
                                         <tr>
                                            <td class="InterFaceTableLeftRow">
                                 <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Red" Text=" Remove account"></asp:Label>
                                            </td>
                                            <td class="InterFaceTableMiddleRow">
                                            </td>
                                            <td class="InterFaceTableRightRow">
                                                <asp:CheckBox ID="CheckBox2" runat="server" ForeColor="Red" Font-Bold="True" Text="Yes" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="height: 2px">
                                                &nbsp;&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="InterfaceHeaderLabel3" colspan="3" style="text-align: center; height: 18px;">
                                                    System Modules</td>
                                        </tr>
                                        <tr>
                                            <td class="InterFaceTableRightRow" colspan="3" style="text-align: center">
                                                <asp:MultiView ID="MultiView1" runat="server">
                                                    <asp:View ID="View1" runat="server">
                                                        &nbsp;<table style="width: 100%">
                                                            <tr>
                                                                <td style="width: 100%; text-align: center;">
                                                        <asp:GridView ID="GridData" runat="server" CssClass="gridgeneralstyle" DataKeyNames="Code"
                                                            EmptyDataText="NO MODULE(S) FOUND" HorizontalAlign="Center" OnRowCommand="GridData_RowCommand"
                                                            PageSize="4" Width="90%">
                                                            <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                                            <RowStyle CssClass="gridRowStyle" />
                                                            <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                                            <Columns>
                                                                <asp:ButtonField CommandName="btnRemove" Text="Remove">
                                                                    <HeaderStyle CssClass="gridEditField" />
                                                                    <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center"
                                                                        Width="110px" />
                                                                </asp:ButtonField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="gridHeaderStyle" Font-Bold="True" HorizontalAlign="Left" />
                                                            <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                                        </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%; height: 2px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%; text-align: center">
                                                                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" /></td>
                                                            </tr>
                                                        </table>
                                                    </asp:View>
                                                    <asp:View ID="View2" runat="server">
                                                        <table align="center" style="border-right: #617da6 1px solid; border-top: #617da6 1px solid;
                                                            border-left: #617da6 1px solid; width: 80%; border-bottom: #617da6 1px solid; height: 50px;">
                                                            <tr>
                                                                <td style="vertical-align: top; height: 147px; text-align: center">
                                                                    <asp:CheckBoxList ID="chkModule" runat="server" CssClass="InterfaceDropdownList"
                                                                        Enabled="False" Font-Bold="True" Font-Size="8pt" Height="110px" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="chkModule_SelectedIndexChanged">
                                                                        <asp:ListItem Value="2">Planning Module</asp:ListItem>
                                                                        <asp:ListItem Value="3">Requisition Module</asp:ListItem>
                                                                        <asp:ListItem Value="4">Bidding and Evaluation Module</asp:ListItem>
                                                                    </asp:CheckBoxList>
                                                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red" Text="User has All Active Module"></asp:Label>
                                                                    <asp:Button ID="Button1" runat="server" Text="Return" OnClick="Button1_Click" /></td>
                                                            </tr>
                                                        </table>
                                                    </asp:View>
                                                </asp:MultiView></td>
                                        </tr>
                                        <tr>
                                            <td class="InterfaceItemSeparator" colspan="3">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                        </ContentTemplate>
                                    </ajaxToolkit:UpdatePanel>
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
                <asp:Label ID="lblCode" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Label ID="Label1" runat="server" Text="0" Visible="False"></asp:Label><br />
                        <asp:Label ID="lblUsername" runat="server" Text="0" Visible="False"></asp:Label></td>
                </tr>
    </table>

</asp:Content>



