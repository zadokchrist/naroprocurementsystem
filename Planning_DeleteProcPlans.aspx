<%@ Page Title="" Language="C#" MasterPageFile="~/PlanningGeneric.master" AutoEventWireup="true" CodeFile="Planning_DeleteProcPlans.aspx.cs" Inherits="Planning_DeleteProcPlans" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="ScriptManager1"  AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>
    <script language="javascript" type="text/javascript">
    // <!CDATA[
    function TABLE1_onclick() {

    }
    // ]]>
</script>
    <div class="card shadow mb-4">
        <div class="form-group row">
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Plan Code</label>
                <asp:TextBox id="txtplancode" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>AREA</label>
                <asp:DropDownList id="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" OnDataBound="DropDownList1_DataBound" CssClass="form-control">
                        </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Cost Center</label>
                <asp:DropDownList id="cboCostCenters" runat="server" AutoPostBack="True" OnDataBound="cboCostCenters_DataBound" CssClass="form-control">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>Procurement type</label>
                <asp:DropDownList id="cboProcType" runat="server" OnDataBound="cboProcType_DataBound" CssClass="form-control">
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>STATUS</label>
                <asp:DropDownList id="cbodeletechoice" runat="server"  CssClass="form-control">
                     <asp:ListItem Value="0">-- NOT DELETED --</asp:ListItem>
                     <asp:ListItem Value="1">  DELETED </asp:ListItem>
                            </asp:DropDownList>
            </div>
            <div class="col-sm-3 mb-3 mb-sm-0">
                <label>.</label>
                <asp:Button id="btnOK" onclick="btnOK_Click" runat="server" Text="Search" Font-Size="9pt" class="btn btn-primary btn-user btn-block float-right"></asp:Button>
            </div>

        </div>
            <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <table style="width: 100%" id="TABLE1">
                <tr>
                    <td style="width: 100%; text-align: center; height: 21px;" class="InterFaceTableLeftRowUp">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Grand Total Cost"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="."></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right">
                                  

                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" Font-Bold="True"
                            OnCheckedChanged="chkSelect_CheckedChanged" Text="Select All" /></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4" HorizontalAlign="Left" Font-Names="Verdana" Font-Size="Small"
                    ForeColor="#333333" GridLines="None" Width="100%" OnItemCommand="DataGrid1_ItemCommand" AllowPaging="True" OnPageIndexChanged="DataGrid1_PageIndexChanged" PageSize="15">
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditItemStyle BackColor="#999999" />
                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" Mode="NumericPages" HorizontalAlign="Center" />
                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" VerticalAlign="Top" />
                    <ItemStyle HorizontalAlign="Left" BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundColumn DataField="PlanCode" HeaderText="Serial No"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Description" HeaderText="Item Description"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CostCenterName" HeaderText="Cost Center"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Quantity" HeaderText="Quantity" DataFormatString="{0:N0}"></asp:BoundColumn>
                                <asp:BoundColumn DataField="UnitCost" HeaderText="UnitCost" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Total Cost" HeaderText="Total Cost" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="MarketPrice" HeaderText="Market Price" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Unit" HeaderText="Units"></asp:BoundColumn>
                                
                                <asp:TemplateColumn HeaderText="Submit">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server"
                                            Width="40px" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="2%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateColumn>
                            </Columns>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        </asp:DataGrid></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: right; height: 23px;">
                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Font-Bold="True"
                            OnCheckedChanged="CheckBox2_CheckedChanged" Text="Select All" /></td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <table align="center" cellpadding="0" cellspacing="0" class="style12">
                            <tr>
                                <td rowspan="2" style="vertical-align: top; width: 50%; text-align: center">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                                    </table>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; width: 50%; height: 111px; text-align: center">
                                    <table align="center" cellpadding="0" cellspacing="0" style="width: 95%; height: 80px">
                                        <tr>
                                            <td class="InterFaceTableLeftRowUp" style="vertical-align: middle; height: 80px;
                                                text-align: left">
                                                Comment (If Required)</td>
                                            <td class="InterFaceTableMiddleRowUp" style="height: 80px">
                                                &nbsp;</td>
                                            <td class="InterFaceTableRightRowUp" style="vertical-align: top; height: 80px; text-align: left">
                                                <asp:TextBox ID="txtComment" runat="server" CssClass="InterfaceTextboxMultiline"
                                                    Height="99px" Style="height: 80px" TextMode="MultiLine"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; text-align: center">
                        <asp:Button ID="Button1" runat="server" Font-Bold="True" OnClick="btnSubmit_Click"
                            Text="DELETE PLAN ITEMS" /></td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
        <table align="center" 
                style="width: 70%; border-right: #617da6 1px solid; border-top: #617da6 1px solid; border-left: #617da6 1px solid; border-bottom: #617da6 1px solid; height: 100px;">
        <tr>
      
        <td style="width: 100%; text-align: center">
                        <asp:Button ID="btnOK1" runat="server" Font-Size="9pt" Height="23px"
                            Text="Preview" Width="100px" onclick="btnOK1_Click" /> &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        <asp:Button ID="btnPrint" runat="server" Font-Size="9pt" Height="23px" OnClick="btnPrint_Click"
                            Text="Print PDF Report" Width="108px" Enabled="false" /> &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        </td>
    </tr>
            
                <tr>
                    <td style="width: 100%; vertical-align: top; text-align: left;">
                        <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                            AutoDataBind="True" Height="991px" ToolPanelView="None" Width="725px" />--%>
                    </td>
                </tr>
            
          
        
        </table>
        </asp:View>
    </asp:MultiView>

    </div>

    


</asp:Content>

