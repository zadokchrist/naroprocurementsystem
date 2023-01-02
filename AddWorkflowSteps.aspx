<%@ Page Language="C#" enableEventValidation="false" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="AddWorkflowSteps.aspx.cs" Inherits="AddWorkflowSteps" Title="New Group Requisition" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0"></div>
            <div class="col-sm-6 mb-3 mb-sm-0">
                <div class="card-header py-3">
                ADD STEPS TO WORKFLOW :
                            <asp:Label ID="lblGroupRequisition" runat="server"></asp:Label>
            </div>
            </div>
        </div>
        
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="form-group row">
                <div class="col-sm-5 mb-3 mb-sm-0"></div>
                <div class="col-sm-4 mb-3 mb-sm-0">
                     ADD STEPS
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0"> Workflow Name</div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                     <asp:DropDownList ID="workflowname" runat="server" DataValueField="RecordId" DataTextField="WorkFlowName" CssClass="form-control" OnDataBound="workflow_DataBound"></asp:DropDownList>
                </div>
                <div class="col-sm-2 mb-3 mb-sm-0">Status</div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:TextBox ID="txtStatus" runat="server" Font-Bold="True" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0"> Description</div>
                <div class="col-sm-8 mb-3 mb-sm-0">
                     <asp:TextBox ID="description" runat="server" Font-Bold="True" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0"> 
                    Maker
                </div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:DropDownList ID="fromrole" runat="server" DataValueField="LevelID" DataTextField="LevelName" CssClass="form-control" OnDataBound="fromrole_DataBound"></asp:DropDownList>
                </div>
                <div class="col-sm-2 mb-3 mb-sm-0">
                    Checker
                </div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:DropDownList ID="torole" runat="server" DataValueField="LevelID" DataTextField="LevelName" CssClass="form-control" OnDataBound="torole_DataBound"></asp:DropDownList>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0">
                     Tick if applicable
                </div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:CheckBox ID="canapprove" runat="server" Font-Bold="True"
                                        Font-Italic="True" Text="Checker Can Approve/Reject" 
                            />
                </div>
                <div class="col-sm-2 mb-3 mb-sm-0">
                    <asp:CheckBox ID="canupload" runat="server" Font-Bold="True"
                                        Font-Italic="True" Text="Checker Can Upload Documents" />
                </div>
                <div class="col-sm-2 mb-3 mb-sm-0">
                    <asp:CheckBox ID="canaddmilestones" runat="server" Font-Bold="True"
                                        Font-Italic="True" Text="Can add milestones" />
                </div>
                
                
            </div>
            <div class="form-group row">
                <div class="col-sm-1 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0"></div>
                <div class="col-sm-2 mb-3 mb-sm-0">
                    <asp:CheckBox ID="cancompletemilestones" runat="server" Font-Bold="True"
                                        Font-Italic="True" Text="Can Complete Milestones" />
                </div>
                <div class="col-sm-2 mb-3 mb-sm-0">
                    <asp:CheckBox ID="laststep" runat="server" Font-Bold="True"
                                        Font-Italic="True" Text="Mark this as last step" />
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-4 mb-3 mb-sm-0"></div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <br />
                    &nbsp;<asp:Button ID="btnAddItem" runat="server" CssClass="btn btn-primary btn-block" OnClick="btnAddItem_Click" Text="Add Step" />
                </div>
            </div>

            <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0"></div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    CURRENT ITEM DETAILS
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-12 mb-3 mb-sm-0">
                    <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered zero-configuration" OnItemCommand="DataGrid2_ItemCommand" HorizontalAlign="Center">
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <EditItemStyle BackColor="#999999" />
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" />
                        <Columns>
                            <asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
                            <asp:BoundColumn DataField="FromRole" HeaderText="From Role"></asp:BoundColumn>
                            <asp:BoundColumn DataField="ToRole" HeaderText="To Role"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CanApprove" HeaderText="Can Approve"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CanDownload" HeaderText="Can Upload Documents"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Description" HeaderText="Descrition"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CanAddMilestones" HeaderText="Add Milestones"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CanAddMilestones" HeaderText="Add Milestones"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CanCompleteMilestones" HeaderText="Complete Milestones"></asp:BoundColumn>
                            <asp:BoundColumn DataField="LastStep" HeaderText="Last Step"></asp:BoundColumn>
                            <asp:ButtonColumn CommandName="btnRemove" HeaderText="Remove" Text="Remove"></asp:ButtonColumn>
                        </Columns>
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    </asp:DataGrid>
                    <asp:Label ID="lblTotal" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="Small"></asp:Label>
                </div>
            </div>
            <table style="width: 95%" align="center">
        <tr>
            <td style="vertical-align: top; width: 49%; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                    
                    
                    
                </table>
            </td>
            <td style="width: 2%">
            </td>
            <td style="vertical-align: top; width: 49%; text-align: center">
                <table align="center" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td colspan="3" style="height: 16px">
                        </td>
                    </tr>
                </table>
                            
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; text-align: center; height: 22px;">
            </td>
            <td style="vertical-align: top; height: 22px; text-align: center">
            </td>
            <td style="vertical-align: top; height: 22px; text-align: center">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
                
                    
                        <table cellspacing="5" width="100%">
                            <tr>
                                <td class="InterFaceTableLeftRow" style="width: 100%; text-align: center">
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 100%">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%; text-align: center">
                            <asp:Label ID="lblItemError" runat="server" Text="." Font-Bold="False" Font-Names="Cambria" ForeColor="Red"></asp:Label></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: top; text-align: center">
                
                <asp:Label ID="lblRecordCode" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblItemID" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblPDCode" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:Label ID="lblInitail" runat="server" Text="." Visible="False"></asp:Label>
                <asp:Label ID="lblDesc" runat="server" Text="." Visible="False"></asp:Label>
                <asp:Label ID="lblYear" runat="server" Text="." Visible="False"></asp:Label>
                <asp:Label ID="lblPlanCode" runat="server" Text="0" Visible="False"></asp:Label></td>
        </tr>
    </table>
             <div class="form-group row">
                <div class="col-sm-3 mb-3 mb-sm-0"></div>
                <div class="col-sm-3 mb-3 mb-sm-0">
                    <asp:Button ID="Button1" runat="server" Text="Submit" Font-Bold="True" CssClass="btn btn-primary btn-block" OnClick="Button1_Click" />
                </div>
                 <div class="col-sm-3 mb-3 mb-sm-0">
                     <asp:Button ID="Button2" runat="server" Text="Cancel" Font-Bold="True" CssClass="btn btn-primary btn-block" OnClick="Button2_Click" /></td>
                 </div>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table id="Table2" onclick="return TABLE1_onclick()" style="width: 100%">
                <tr>
                    <td style="width: 100%; height: 21px; text-align: right">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:Label ID="lblQn" runat="server" Font-Bold="True" ForeColor="Maroon" Text="."></asp:Label><asp:Button
                            ID="btnYes" runat="server" OnClick="btnYes_Click" Text="Yes" /><asp:Button ID="btnNo"
                                runat="server" OnClick="btnNo_Click" Text="No" /></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right; height: 21px;">
                    </td>
                </tr>
            </table>
        </asp:View>
        &nbsp;
    </asp:MultiView>
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


</script>

    <asp:Label ID="lblTypeID" runat="server" Text="0"></asp:Label>
    </div>
    
</asp:Content>

