<%@ Page Language="C#" MasterPageFile="~/GenericMasterPage.master" AutoEventWireup="true" CodeFile="AddNewPlanFileUpload.aspx.cs" Inherits="AddNewPlanFileUpload" Title="NEW PLAN ITEM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="card shadow mb-4">
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <div class="card-header py-3">
                            <asp:Label ID="lblHeader" runat="server" Text="PLAN BULK UPLOADS"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                           <a href="PlanningTemplate/planningtemplate.xlsx">Download Guide/Template</a>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-2 mb-3 mb-sm-0"></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        Select Procurement Category
                    </div>
                    <div class="col-sm-4 mb-3 mb-sm-0">
                        <asp:DropDownList ID="cboProcType" runat="server" CssClass="form-control" OnDataBound="cboProcType_DataBound">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-2 mb-3 mb-sm-0"></div>
                    <div class="col-sm-2 mb-3 mb-sm-0"></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        Add New File Attachments
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-2 mb-3 mb-sm-0"></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <p id="upload-area">
                            <input id="FileField" class="form-control-file" runat="server" size="60" type="file" />
                        </p>
                    </div>
                    <div class="col-sm-4 mb-3 mb-sm-0">
                        <p>
                            <input id="Button1" onclick="addFileUploadBox()" class="btn btn-primary btn-user btn-block" type="button" value="Add a file" />
                        </p>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Button ID="btnOK" runat="server" class="btn btn-primary btn-user btn-block" OnClick="btnOK_Click"
                            Text="SUBMIT" />
                    </div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div class="card shadow mb-4">
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <div class="card-header py-3">
                            <asp:Label ID="error" runat="server" Text="PLAN BULK UPLOADS ERRORS"></asp:Label>
                        </div>
                    </div>
                </div>
                <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                            ForeColor="#333333" GridLines="None" Style="text-align: justify">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditItemStyle BackColor="#999999" />
                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:BoundColumn DataField="ItemCategory" HeaderText="ItemCategory"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DateNeeded" HeaderText="Date Needed" DataFormatString="{0:dd MMM yyyy}"></asp:BoundColumn>
                                <asp:BoundColumn DataField="FundingSource" HeaderText="FundingSource"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Reason" HeaderText="Reason"></asp:BoundColumn>
                            </Columns>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        </asp:DataGrid>
            </div>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <div class="card shadow mb-4">
                <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0"></div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <div class="card-header py-3">
                            <asp:Label ID="Label1" runat="server" Text="PLAN BULK UPLOADS TO CONFIRM"></asp:Label>
                        </div>
                    </div>
                </div>
                <asp:DataGrid ID="DataGrid2" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="Small"
                            ForeColor="#333333" GridLines="None" Style="text-align: justify">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditItemStyle BackColor="#999999" />
                            <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                            <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Left" VerticalAlign="Top" />
                            <Columns>
                                <asp:BoundColumn DataField="ItemCategory" HeaderText="ItemCategory"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DateNeeded" HeaderText="Date Needed" DataFormatString="{0:dd MMM yyyy}"></asp:BoundColumn>
                                <asp:BoundColumn DataField="FundingSource" HeaderText="FundingSource"></asp:BoundColumn>
                            </Columns>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        </asp:DataGrid>
            </div>
            <div class="form-group row">
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Button ID="cancel" runat="server" class="btn btn-primary btn-user btn-block" OnClick="cancel_Click"
                            Text="CANCEL" />
                    </div>
                    <div class="col-sm-3 mb-3 mb-sm-0">
                        <asp:Button ID="proceed" runat="server" class="btn btn-primary btn-user btn-block" OnClick="proceed_Click"
                            Text="PROCEED" />
                    </div>
                </div>
        </asp:View>
    </asp:MultiView>
    
    <script type="text/javascript">

        function Comma(Num) {
            Num += '';
            Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
            Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
            x = Num.split('.');
            x1 = x[0];
            x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1))
                x1 = x1.replace(rgx, '$1' + ',' + '$2');
            return x1 + x2;
        }

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
</asp:Content>