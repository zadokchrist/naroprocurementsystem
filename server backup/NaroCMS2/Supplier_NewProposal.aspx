<%@ Page Language="C#" MasterPageFile="~/Suppliers.master" AutoEventWireup="true" CodeFile="Supplier_NewProposal.aspx.cs" Inherits="Requisition_NewRequisition" Title="NEW REQUISITION" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <table cellpadding="0" cellspacing="0" class="style12">
       
        <tr>
            <td style="vertical-align: middle; text-align: center">
               RESPOND TO RFQ
                
            </td>
        </tr>
       
    </table>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table>
                
                            <tr>


                                <td class="InterFaceTableLeftRow" style="height: 29px">Subject of Procurement</td>

                                <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                    <asp:TextBox ID="txtSubject" runat="server" CssClass="InterfaceTextboxMultiline" Style="width: 80%; height: 55px"
                                      Enabled="false"  TextMode="MultiLine" Width="85%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="InterFaceTableLeftRow" style="height: 29px">Details</td>


                                <td class="InterFaceTableRightRow" style="width: 66%; height: 29px">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="InterfaceTextboxMultiline" Enabled="false"
                                        TextMode="MultiLine" Width="85%" Style="width: 80%; height: 55px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="height: 29px;" class="InterFaceTableLeftRow">Date Of Expiry</td>
                                <td style="width: 65%; height: 29px;" class="InterFaceTableRightRow">
                                    <asp:TextBox ID="txtDateRequired" Enabled="false" runat="server" CssClass="InterfaceTextboxLongReadOnly" Width="78%"></asp:TextBox>
                                </td>
                            </tr>
          <tr>
            <td style="height: 30px;" class="InterFaceTableLeftRow">
                Procurement Type</td>
            <td class="InterFaceTableRightRow" style="width: 66%; height: 30px">
                <asp:TextBox ID="txtDescription" Enabled="false" runat="server" CssClass="InterfaceTextboxMultiline" TextMode="MultiLine" Width="80%"></asp:TextBox>
            </td>
        </tr>
              
               
                <tr>
                    <td colspan="3" style="vertical-align: top">
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom,Numbers" TargetControlID="txtRequired" ValidChars="," />
                    </td>
                </tr>
    </table>
                
            <table style="width: 100%">
                <tr>
                    <td colspan="3" style="width: 100%; height: 21px; text-align: center"></td>
                </tr>
                <tr>
                    <td class="InterFaceTableLeftRowUp" colspan="3" style="width: 100%; text-align: center">ATTACHMENT(S)</td>
                </tr>
                <tr>
                    <td colspan="3"></td>
                </tr>
                <tr>
                    <td colspan="3" style="width: 100%; text-align: center">
                        <asp:Label ID="lblHeaderMsg" runat="server" Font-Bold="True" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; width: 49%; text-align: center">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                            <tr>
                                <td colspan="3">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                        <tr>
                                            <td class="InterfaceHeaderLabel3" style="height: 18px">New Attachments</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 16px"></td>
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
                    <td style="width: 2%"></td>
                    <td style="vertical-align: top; width: 49%; text-align: center">
                        <table align="center" cellpadding="0" cellspacing="0" style="width: 99%">
                            <tr>
                                <td colspan="3">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 98%">
                                        <tr>
                                            <td class="InterfaceHeaderLabel3" style="height: 18px">View Attachments</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 16px">
                                    <asp:GridView ID="GridAttachments" runat="server" AutoGenerateColumns="false" CssClass="gridgeneralstyle" DataKeyNames="FileID" GridLines="None" HorizontalAlign="Center" OnRowCommand="GridAttachments_RowCommand" PageSize="15" Width="98%">
                                        <PagerSettings Mode="NumericFirstLast" Position="TopAndBottom" />
                                        <RowStyle CssClass="gridRowStyle" />
                                        <EmptyDataRowStyle Font-Bold="True" ForeColor="Red" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:ButtonField CommandName="ViewDetails" Text="View">
                                            <HeaderStyle CssClass="gridEditField" />
                                            <ItemStyle CssClass="gridEditField" ForeColor="#003399" HorizontalAlign="Center" Width="140px" />
                                            </asp:ButtonField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnRemove" runat="server" CommandArgument='<%# Eval("FileID") %>' CommandName="btnRemove" Text="Remove" Visible='<%# IsFileRemoveable((Int32)Eval("IsRemoveable")) %>'></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="gridEditField" ForeColor="#003399" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FileID" HeaderText="FileID" />
                                            <asp:BoundField DataField="FileName" HeaderText="FileName" />
                                            <asp:BoundField DataField="IsRemoveable" HeaderText="IsRemoveable" Visible="false" />
                                        </Columns>
                                        <HeaderStyle CssClass="gridHeaderStyle" HorizontalAlign="Left" />
                                        <AlternatingRowStyle CssClass="gridAlternatingRowStyle" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">&nbsp;<asp:Label ID="lblNoAttachments" runat="server" Font-Names="Cambria" Font-Size="11pt" ForeColor="Red" Text="NO ATTACHMENTS FOUND" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="height: 16px"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="vertical-align: top; width: 100%; text-align: center">
                        <asp:Label ID="lblAttachRefNo" runat="server" Text="0" Visible="False"></asp:Label>
                        <asp:Button ID="btnSaveFile" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" OnClick="btnSaveFile_Click" Text="SAVE " Width="80px" />
                        <asp:Button ID="btnReturn" runat="server" Font-Bold="True" Font-Size="9pt" Height="23px" OnClick="btnReturn_Click" Text="RETURN" Width="80px" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="lblRecordCode" runat="server" Text="0" Visible="False"></asp:Label>
            <asp:Label ID="lblItemID" runat="server" Text="0" Visible="False"></asp:Label>
            <asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label>
            <asp:Label ID="lblInitail" runat="server" Text="." Visible="False"></asp:Label>
            <asp:Label ID="lblDesc" runat="server" Text="." Visible="False"></asp:Label>
            <asp:Label ID="lblYear" runat="server" Text="." Visible="False"></asp:Label>
            <asp:Label ID="lblPlanCode" runat="server" Text="0" Visible="False"></asp:Label>
            <asp:Label ID="lblInitQty" runat="server" Text="0" Visible="False"></asp:Label>
            
            &nbsp;<br />
            <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="Button1_Click" style="height: 26px" Text="Submit" />
            <asp:Button ID="btnCancel" runat="server" Font-Bold="True" OnClick="btnCancel_Click" Text="Cancel" />
            </td>
            </tr>
            <tr>
                <td colspan="3" style="vertical-align: top; text-align: center">
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar" Format="MMMM d, yyyy" PopupPosition="TopLeft" TargetControlID="txtDateRequired" />
                </td>
            </tr>
            </table>



        </asp:View>
    </asp:MultiView>
 

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

    <asp:Label ID="lblTypeID" runat="server" Text="0" Visible="False"></asp:Label>
</asp:Content>

