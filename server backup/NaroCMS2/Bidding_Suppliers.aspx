<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="Bidding_Suppliers.aspx.cs" Inherits="Bidding_Suppliers" Title="SUPPLIERS" Culture="auto" UICulture="auto" %>
 <%@ Register Assembly="AjaxControlToolkit"  Namespace="AjaxControlToolkit"  TagPrefix="ajaxToolkit" %>
 <%@ Import Namespace="System.Threading" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card shadow mb-4">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">MANAGE FIRMS</h6>
                    </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Procurement Type</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboProcType" runat="server" CssClass="form-control"
                            OnDataBound="cboProcType_DataBound" AutoPostBack="True" OnSelectedIndexChanged="cboProcType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Firm Category</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="form-control"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0">Firm Sub Category</div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:DropDownList ID="ddlcategory2" runat="server" CssClass="form-control"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlcategory2_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <table align="center" cellpadding="0" cellspacing="0" class="style12">
                    <tr>
                        <td style="vertical-align: top; width: 50%; height: 2px; text-align: center"></td>
                    </tr>
                    <tr>
                        <td style="text-align: center; vertical-align: top; width: 50%">
                            <table align="center" cellpadding="0" cellspacing="0" style="width: 95%">
                            </table>
                            <asp:DataGrid ID="GridData" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                Font-Names="Verdana" Font-Size="Small" ForeColor="#333333"
                                Style="text-align: justify" Width="100%" OnItemCommand="GridData_ItemCommand" BorderStyle="None">
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <EditItemStyle BackColor="#999999" />
                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundColumn DataField="BidderID" HeaderText="BidderID"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="CompanyName" HeaderText="Company Name"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="PhysicalAddress" HeaderText="PhysicalAddress"></asp:BoundColumn>

                                    <asp:BoundColumn DataField="EmailAddress" HeaderText="Email Address"></asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CssClass="gridPad" ID="btnEdit" CommandName="btnEdit" Text="Edit"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="View">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" CssClass="gridPad" ID="btnClassifications" CommandName="btnClassifications" Text="Classifications"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                </Columns>
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            </asp:DataGrid>


                        </td>
                    </tr>
                </table>
            </asp:View>
                    &nbsp;
                    <asp:View ID="View3" runat="server">
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <div class="card-header py-3">
                                    <h6 class="m-0 font-weight-bold text-primary">ADD / EDIT FIRM</h6>
                                </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-2 mb-3 mb-sm-0">
                                Firm Category
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <asp:DropDownList ID="cboProcType2" runat="server" CssClass="form-control" AutoPostBack="True" OnDataBound="cboProcType2_DataBound" OnSelectedIndexChanged="cboProcType2_SelectedIndexChanged">
                                    </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-2 mb-3 mb-sm-0">
                                Firm Sub Category
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <asp:DropDownList ID="cboCategories" runat="server" CssClass="form-control"
                                    OnDataBound="cboCategories_DataBound">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-2 mb-3 mb-sm-0">
                                Firm Name
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <asp:TextBox ID="txtSupplierName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-2 mb-3 mb-sm-0">
                                Director Names
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <asp:TextBox ID="txtDirectorNames" runat="server" BorderStyle="Solid" CssClass="form-control"
                                        Font-Bold="True" TextMode="MultiLine" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-2 mb-3 mb-sm-0">
                                Physical Address
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <asp:TextBox ID="txtPhysicalAddress" runat="server" BorderStyle="Solid" CssClass="form-control"
                                        Font-Bold="True" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-2 mb-3 mb-sm-0">
                                Phone Numbers
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <asp:TextBox ID="txtPhoneNumbers" runat="server" BorderStyle="Solid" CssClass="form-control"
                                        Font-Bold="True" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-2 mb-3 mb-sm-0">
                                Email Address
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-2 mb-3 mb-sm-0">
                                PPA Registration Number
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <asp:TextBox ID="txtPPACode" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-2 mb-3 mb-sm-0">
                                Designation
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <asp:TextBox ID="txtRemarks" runat="server" BorderStyle="Solid" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-2 mb-3 mb-sm-0">
                                
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <asp:CheckBox ID="CheckBox2" runat="server" Font-Bold="True" Text="Is Active" />
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-2 mb-3 mb-sm-0">
                                <asp:Button ID="Button2" runat="server" Text="OK" OnClick="Button2_Click" class="btn btn-primary btn-user btn-block float-right"/>
                            </div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <asp:Button ID="Button3" runat="server" Text="Cancel / Return" OnClick="btnCancel_Click" class="btn btn-primary btn-user btn-block float-right"/>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-2 mb-3 mb-sm-0">
                                <asp:Label ID="Label1" runat="server" Text="0" Visible="False"></asp:Label>
                                    <asp:Label ID="lblCenterID" runat="server" Text="0" Visible="False"></asp:Label>
                            </div>
                        </div>
                    </asp:View>
                    <asp:View ID="View6" runat="server">
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-6 mb-3 mb-sm-0">
                                <div class="card-header py-3">
                                <h6 class="m-0 font-weight-bold text-primary">BID CLASSIFICATIONS</h6>
                            </div>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-12 mb-3 mb-sm-0">
                                <asp:DataGrid ID="DataGrid5" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    Font-Names="Verdana" Font-Size="Small" ForeColor="#333333" GridLines="None"
                                    Style="text-align: justify" Width="100%" OnItemCommand="DataGrid5_ItemCommand">
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <EditItemStyle BackColor="#999999" />
                                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:BoundColumn DataField="recordId" HeaderText="RecordID"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="CategoryCode" HeaderText="CATEGORY"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="subCategoryName" HeaderText="SUB CATEGORY"></asp:BoundColumn>

                                        <asp:TemplateColumn HeaderText="REMOVE">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" CssClass="gridPad" ID="btnRemove" CommandName="btnRemove" Text="Remove"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>

                                    </Columns>
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                </asp:DataGrid>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-2 mb-3 mb-sm-0">CATEGORY</div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <asp:DropDownList ID="ddlCategories2" runat="server" CssClass="form-control" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0"></div>
                            <div class="col-sm-2 mb-3 mb-sm-0">SUB CATEGORY</div>
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <asp:DropDownList ID="ddlSubCategories2" runat="server" CssClass="form-control" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-sm-3 mb-3 mb-sm-0">
                                <asp:Label ID="lblBidderId" runat="server" Text="0" Visible="False"></asp:Label>
                            </div>
                            <div class="col-sm-2 mb-3 mb-sm-0">
                                <asp:Button ID="btnSaveFile" runat="server" Font-Bold="True" OnClick="btnSaveFile_Click" Text="ADD " class="btn btn-primary btn-user btn-block float-right"/>
                            </div>
                            <div class="col-sm-2 mb-3 mb-sm-0">
                                <asp:Button ID="btnReturn" runat="server" Font-Bold="True" OnClick="btnReturn_Click" Text="RETURN" class="btn btn-primary btn-user btn-block float-right"/>
                            </div>
                        </div>
                    </asp:View>
                </asp:MultiView>
         <asp:Label ID="lblPlanCode" runat="server" Text="Label" Visible="False"></asp:Label>
    </div>
    <asp:ScriptManager ID="ScriptManager1" AjaxFrameworkMode="Enabled"  runat="server"></asp:ScriptManager>

</asp:Content>




