using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ShortlistBidders : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    DataTable dtable = new DataTable();
    DataTable dtUpdate = new DataTable();
    DataTable dtable2 = new DataTable();
    int ProcMethod,ProcTypeCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["PR"] != null)
            {
                string PRNumber = Request.QueryString["PR"].ToString();
                Session["pr"] = PRNumber;
                LoadControls(PRNumber);
               // 
                //AutoCompleteExtender2.ContextKey = "0";
            }
            else
                Response.Redirect("Bidding_PendingProcurements.aspx", true);
        }
        
    }
    private void ShowMessage(string MessageToDisplay)
    {
        Label msg = (Label)Master.FindControl("lblmsg");
        if (MessageToDisplay.Equals("."))
            msg.Text = ".";
        else
            msg.Text = "MESSAGE:  " + MessageToDisplay;
    }
    private void CreateBiddersDataTable()
    {
        DataTable dtBidders = new DataTable("Bidders");
     
        dtBidders.Columns.Add(new DataColumn("ShortlistID", typeof(long)));
        dtBidders.Columns.Add(new DataColumn("DateCreated", typeof(DateTime)));
        dtBidders.Columns.Add(new DataColumn("BidderID", typeof(long)));
        dtBidders.Columns.Add(new DataColumn("BidderName", typeof(string)));
        dtBidders.Columns.Add(new DataColumn("ProposedByID", typeof(long)));
        dtBidders.Columns.Add(new DataColumn("ProposedBy", typeof(string)));
        dtBidders.Columns.Add(new DataColumn("ReasonID", typeof(int)));
        dtBidders.Columns.Add(new DataColumn("Reason", typeof(string)));
        dtBidders.Columns.Add(new DataColumn("OtherReason", typeof(string)));
        dtBidders.Rows.Clear();

        Session["dtBidders"] = dtBidders;
        dtUpdate = dtBidders;
    }
    private void LoadControls(string PRNumber)
    {
        string procmethod = "1";
        dtable = Process.GetLevelProcurements("0", PRNumber, "0", "0", "", "", "");
        if (dtable.Rows.Count > 0)
        {
            txtPRNumber.Text = dtable.Rows[0]["ScalaPRNumber"].ToString();
            txtEstimatedCost.Text = Convert.ToDouble(dtable.Rows[0]["EstimatedCost"]).ToString("#,##0");
            txtProcSubject.Text = dtable.Rows[0]["Subject"].ToString();
            txtProcType.Text = dtable.Rows[0]["ProcurementType"].ToString();
            txtProcMethod.Text = dtable.Rows[0]["Method"].ToString();
            txtDateRequisitioned.Text = dtable.Rows[0]["CreationDate"].ToString();
            txtRequisitioner.Text = dtable.Rows[0]["Requisitioner"].ToString();
            txtDateRequired.Text = dtable.Rows[0]["DateRequired"].ToString();
            txtBudgetCostCenter.Text = dtable.Rows[0]["CostCenterName"].ToString();
            lblPDCode.Text = dtable.Rows[0]["PD_Code"].ToString();
            lblStatusID.Text = dtable.Rows[0]["StatusID"].ToString();
            ProcMethod = int.Parse(dtable.Rows[0]["ProcMethodCode"].ToString());
            lblprocmethod.Text = ProcMethod.ToString();
            ProcTypeCode = int.Parse(dtable.Rows[0]["ProcurementTypeID"].ToString());
            lblproctype.Text = ProcTypeCode.ToString();
            procmethod = dtable.Rows[0]["ProcMethodCode"].ToString();
        }
        if (procmethod == "4" || procmethod == "5")
        {
            LoadProcCategoryBidders(ProcTypeCode);
            btnAddBidder.Visible = false;
            cboReason.Visible = false;
        }
        else
        {
            LoadShortlistedBidders(PRNumber);
            btnAddBidder.Visible = true;
            cboReason.Visible = true;
        }

        Session["proc"] = ProcTypeCode;
        LoadBidderSubCategories(ProcTypeCode);
        LoadBidderChoiceReasons(2);
        LoadBidderCategories(ProcTypeCode);
        
    }

    private void LoadBidderSubCategories(int procTypeCode)
    {
        int type = procTypeCode;
        switch (procTypeCode)
        {
            case 1:
                type = 4;
                break;
            case 2:
                type = 1;
                break;
            case 3:
                type = 2;
                break;
            case 4:
                type = 3;
                break;
            case 5:
                type = 1;
                break;

        }
        cboBIdderSubcat.DataSource = Process.GetBidderSubCategoriesByProcType(type);
        cboBIdderSubcat.DataTextField = "subCategoryName";
        cboBIdderSubcat.DataValueField = "BiddersubcategoryID";
        cboBIdderSubcat.DataBind();
    }

    private void LoadProcCategoryBidders(int procTypeCode)
    {
        CreateBiddersDataTable();
        int type = procTypeCode;
        switch (procTypeCode)
        {
            case 1:
                type = 4;
                break;
            case 2:
                type = 1;
                break;
            case 3:
                type = 2;
                break;
            case 4:
                type = 3;
                break;
            case 5:
                type = 1;
                break;

        }

        int ProcType = procTypeCode;
        int Category = Convert.ToInt32(cboBidderCategory.SelectedValue);
        int subCategory = int.Parse(cboBIdderSubcat.SelectedValue);
        dtable = Process.GetSuppliersByCategory(ProcType, Category, subCategory);

        ddlBidders.DataSource = dtable;
        ddlBidders.DataTextField = "subcategoryname";
        ddlBidders.DataValueField = "subcategoryid";
        ddlBidders.DataBind();

        int start = 1;
        CreateBiddersDataTable();
        if (dtable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in dtable.Rows)
            {
                long ShortlistID = start; DateTime
                    DateCreated = Convert.ToDateTime(dr["DateCreated"].ToString());
                long BidderID = Convert.ToInt64(dr["BidderID"].ToString());
                string Bidder = dr["BidderName"].ToString();
                long ProposedByID = 0;
                string ProposedBy = "";
                lblCreatedBy.Text = ProposedByID.ToString();
                int ReasonID = 1;
                string Reason = "";
                string OtherReason = "";
                dtUpdate.Rows.Add(new object[] { ShortlistID, DateCreated, BidderID, Bidder, ProposedByID, ProposedBy, ReasonID, Reason, OtherReason });
                start++;
            }
            Session["dtBidders"] = dtUpdate;
            DataGrid2.DataSource = dtable; DataGrid2.Visible = true;
            DataGrid2.DataBind(); btnPrint.Enabled = true;
        }
    }

    private void LoadBidderCategories(int type)
    {
        cboBidderCategory.DataSource = Process.GetBidderCategoriesByProcType(type);
        cboBidderCategory.DataTextField = "CategoryName";
        cboBidderCategory.DataValueField = "BiddercategoryID";
        cboBidderCategory.DataBind();


  
    }
    private void LoadBidderChoiceReasons(int Type)
    {
        cboReason.DataSource = Process.GetBidderReasons(Type);
        cboReason.DataTextField = "Reason";
        cboReason.DataValueField = "ID";
        cboReason.DataBind();
    }
    private void LoadShortlistedBidders(string PRNumber)
    {
        CreateBiddersDataTable();
        dtable = Process.GetShortlistedBidderDetails(PRNumber);
        if (dtable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in dtable.Rows)
            {
                long ShortlistID = Convert.ToInt64(dr["ShortlistID"].ToString()); DateTime DateCreated = Convert.ToDateTime(dr["DateCreated"].ToString());
                long BidderID = Convert.ToInt64(dr["BidderID"].ToString()); string Bidder = dr["BidderName"].ToString();
                long ProposedByID = Convert.ToInt64(dr["ProposedByID"].ToString()); string ProposedBy = dr["ProposedBy"].ToString();
                lblCreatedBy.Text = ProposedByID.ToString();
                int ReasonID = Convert.ToInt32(dr["ReasonID"].ToString()); string Reason = dr["Reason"].ToString(); string OtherReason = dr["OtherReason"].ToString();
                dtUpdate.Rows.Add(new object[] { ShortlistID, DateCreated, BidderID, Bidder, ProposedByID, ProposedBy, ReasonID, Reason, OtherReason });
            }
            Session["dtBidders"] = dtUpdate;
            DataGrid2.DataSource = dtable; DataGrid2.Visible = true;
            DataGrid2.DataBind(); btnPrint.Enabled = true;
        }
    }
    protected void cboReason_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboReason.SelectedItem.Text == "Other")
        {
            txtReason.Visible = true;

        }
        else
        {
            txtReason.Visible = false;
        }
    }
    protected void cboReason_DataBound(object sender, EventArgs e)
    {
        cboReason.Items.Insert(0, new ListItem(" -- Select Reason -- ", "0"));
    }
    protected void btnAddBidder_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage("."); ShowMessage2(".");
            if (ddlBidders.SelectedItem.Value=="0")
                ShowMessage2("Please Select From the List of Bidders After Typing One or More Letters");
            //else if (String.IsNullOrEmpty(txtProposedBy.Text.Trim()))
            //    ShowMessage2("Please Select From the List of Users After Typing One or More Letters");
            else if (cboReason.SelectedValue == "0")
                ShowMessage2("Please Select Reason For Selection Of Bidder");
            else if (cboReason.SelectedItem.ToString() == "Other" && String.IsNullOrEmpty(txtReason.Text.Trim()))
                ShowMessage2("Please Enter Reason For Selection of Bidder");
            else
            {
                DateTime DateCreated = DateTime.Now;
                string Bidder = ddlBidders.SelectedItem.Text;
                string ProposedBy = txtProposedBy.Text.Trim();
                int ReasonID = Convert.ToInt32(cboReason.SelectedValue.ToString());
                string Reason = cboReason.SelectedItem.Text.Trim();
                string OtherReason = txtReason.Text.Trim();
                int ProposedByID = 6; int BidderID = 0;
                //dtable = Process.GetUserByName(ProposedBy);
                //if (dtable.Rows.Count == 0)
                //    throw new Exception("Please Enter Existing User OR Select from drop down returned after typing more than two letters");
                //else
                //    ProposedByID = Convert.ToInt32(dtable.Rows[0]["UserID"].ToString());
                dtable = Process.GetBidderByName(Bidder);
                if (dtable.Rows.Count == 0)
                    throw new Exception("Please Enter Existing Bidder Name OR Select from drop down returned after typing more than two letters");
                else
                    BidderID = Convert.ToInt32(dtable.Rows[0]["BidderID"].ToString());

                long ShortlistID = 0;
                
                dtUpdate = (DataTable)Session["dtBidders"];
                if (btnAddBidder.Text.Contains("Update") && lblShortlistID.Text != "0")
                {
                    ShortlistID = Convert.ToInt64(lblShortlistID.Text.Trim());
                    int i = 0;
                    foreach (DataRow dr in dtUpdate.Rows)
                    {
                        if (Convert.ToInt64(dr["ShortlistID"]) == ShortlistID)
                        {
                            dtUpdate.Rows.RemoveAt(i);
                            break;
                        }
                        i++;
                    }
                }

                dtUpdate.Rows.Add(new object[] { ShortlistID, DateCreated, BidderID, Bidder, ProposedByID, ProposedBy, ReasonID, Reason, OtherReason });
                ClearItemControls();

                ShowMessage2(Bidder + " Has Been Successfully Added");

                Session["dtBidders"] = dtUpdate;
                DataGrid2.DataSource = dtUpdate.DefaultView;
                DataGrid2.DataBind();
            }
        }
        catch (Exception ex)
        {
            ShowMessage2(ex.Message);
        }
    }
    private void ClearItemControls()
    {
        ddlBidders.SelectedIndex = 0; txtReason.Text = ""; btnAddBidder.Text = "Add Bidder";
        cboReason.SelectedValue = "0"; txtProposedBy.Text = ""; txtReason.Visible = false;
    }
    private void ShowMessage2(string Message)
    {
        if (Message == ".")
            lblMsg.Text = ".";
        else
            lblMsg.Text = "MESSAGE: " + Message;
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            string ReportName = "BidderShortlist32";
            string ReferenceNo = txtPRNumber.Text;
            dtable = Process.GetReportForShortlistedBidders(ReferenceNo);
            int rowcount = dtable.Rows.Count;

            if (rowcount != 0)
            {
                loadreport(ReportName);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Shortlist of Bidders F32");
            }
            else
            {
                ShowMessage2("No Data To Load For Report ... ");
            }
        }
        catch (Exception ex)
        {
            ShowMessage2(ex.Message);
        }
    }
    public void loadreport(string ReportName)
    {
        string appPath, physicalPath, rptName;
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        rptName = physicalPath + "\\Bin\\Reports\\Bidding\\" + ReportName + ".rpt";

        //doc.Load(rptName);
        //doc.SetDataSource(dtable);

        Hidetoolbar();
        //CrystalReportViewer1.ReportSource = doc;
    }
    private void Hidetoolbar()
    {
        //CrystalReportViewer1.HasPrintButton = false;
        //CrystalReportViewer1.HasCrystalLogo = false;
        //CrystalReportViewer1.HasDrillUpButton = false;
        //CrystalReportViewer1.HasExportButton = false;
        //CrystalReportViewer1.HasRefreshButton = false;
        //CrystalReportViewer1.HasViewList = false;
        //CrystalReportViewer1.HasZoomFactorList = false;
    }
    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        string ShortlistID = e.Item.Cells[0].Text.Trim(); string DateCreated = e.Item.Cells[1].Text.Trim();
        string BidderName = e.Item.Cells[2].Text; string ProposedBy = e.Item.Cells[3].Text;
        string ReasonID = e.Item.Cells[4].Text; string OtherReason = e.Item.Cells[6].Text;
        int ItemRowIndex = e.Item.DataSetIndex;
        
        dtUpdate = (DataTable)Session["dtBidders"];
        ShowMessage("."); ShowMessage2(".");
        if (e.CommandName == "btnEdit")
        {
            LoadBidderControls(ShortlistID, DateCreated, BidderName, ProposedBy, ReasonID, OtherReason);
           
        }
        else if (e.CommandName == "btnRemove")
        {
            long SID = Convert.ToInt64(ShortlistID);
            if (SID != 0)
                Process.FlagPotentialBidder(SID, true);
            ShowMessage2(BidderName + " Has Been Successfully Removed ...");
         // LoadControls(txtPRNumber.Text.Trim());
            
        }
       
        dtUpdate.Rows.RemoveAt(ItemRowIndex);
        DataGrid2.DataSource = dtUpdate.DefaultView;
        DataGrid2.DataBind();
    }

    private void LoadBidderControls(string ShortlistID, string DateCreated, string BidderName, string ProposedBy, string ReasonID, string OtherReason)
    {
        lblShortlistID.Text = ShortlistID; cboReason.SelectedValue = ReasonID;
        ddlBidders.SelectedIndex = ddlBidders.Items.IndexOf(ddlBidders.Items.FindByValue(BidderName));
        txtProposedBy.Text = ProposedBy; txtReason.Text = OtherReason;
        if (cboReason.SelectedItem.Text.Trim() == "Other")
            txtReason.Visible = true;
        btnAddBidder.Text = "Update Bidder";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        dtUpdate = (DataTable)Session["dtBidders"];
        ShowMessage2("."); ShowMessage(".");
        if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Potential Bidders Before Submission");
            ShowMessage2("Please Add Potential Bidders Before Submission");
        }
        else
        {
            Session["dtBidders"] = dtUpdate;
            DataTable dtBidders = (DataTable)Session["dtBidders"];
            int StatusID = Convert.ToInt32(lblStatusID.Text); string CreatedBy;
            if (StatusID > 40 && Process.GetShortlistedBidderDetails(txtPRNumber.Text).Rows.Count > 0)
                CreatedBy = lblCreatedBy.Text;
            else
                CreatedBy = Session["UserID"].ToString();

            string Response = Process.SavePotentialBidders(lblPDCode.Text.Trim(), txtPRNumber.Text.Trim(), dtBidders, CreatedBy, int.Parse(lblprocmethod.Text.Trim()), int.Parse(lblproctype.Text.Trim())); 
            btnPrint.Enabled = true;
            if (StatusID > 40)
            {
                //string ReferenceNo = txtPRNumber.Text;
                //string PDUSupervisor = HttpContext.Current.Session["FullName"].ToString();
                //DataTable dtAlert = Process.GetBiddingDetailsForNotification(ReferenceNo);
                //string Subject = "Procurement Supervisor Edited Shortlisted Bidders For " + dtAlert.Rows[0]["Subject"].ToString();
                //string OfficerID = dtAlert.Rows[0]["POID"].ToString(); string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
                //string CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();

                ///// Notify Procurement Officer
                //string Message = "<p>Evaluation Committee Members for Procurement ( " + ReferenceNo + " ) from " + CostCenterName + " has been edited by Procurement Supervisor " + PDUSupervisor + " </p>";
                //Message += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

                //ProcessReq.NotifyOfficer(PDUSupervisor, Subject, OfficerID, Message);
            }
            lblDone.Text = Response;
            MultiView1.ActiveViewIndex = 1;
        }
    }

    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        string PreviousPage = Session["PreviousPage"].ToString();
        Session["PreviousPage"] = "Bidding_ShortlistBidders.aspx";
        Session["PRNumber"] = txtPRNumber.Text;
        Response.Redirect(PreviousPage + "?transferid=1", true);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string PreviousPage = Session["PreviousPage"].ToString();
        Session["PreviousPage"] = "Bidding_ShortlistBidders.aspx";
        Session["PRNumber"] = txtPRNumber.Text;
        Response.Redirect(PreviousPage + "?transferid=1", true);
    }
    private void Page_Unload(object sender, EventArgs e)
    {
        //if (doc != null)
        //{
        //    doc.Close();
        //    doc.Dispose();
        //    GC.Collect();
        //}
    }
    protected void cboBidderCategory_DataBound(object sender, EventArgs e)
    {
        cboBidderCategory.Items.Insert(0, new ListItem("-- Select Category --", "0"));
        
    }
    protected void cboBidderCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
       // AutoCompleteExtender2.ContextKey = cboBidderCategory.SelectedValue;
         LoadBidders();

    }
    void loadBiddersByCategory(String biddercat)
    {
        dtable = Process.GetBidderByCategory(int.Parse(biddercat));
        ddlBidders.DataSource = dtable;
        ddlBidders.DataTextField = "CompanyName";
        ddlBidders.DataValueField = "BidderID";
        ddlBidders.DataBind();
       

    }
 
    protected void cboBIdderSubcat_SelectedIndexChanged(object sender, EventArgs e)
    {
   
        LoadBidders();

    }


    private void LoadBidders()
    {
        int ProcType = Convert.ToInt32(Session["proc"].ToString());
        int Category = Convert.ToInt32(cboBidderCategory.SelectedValue);
        int subCategory = int.Parse(cboBIdderSubcat.SelectedValue);
        dtable = Process.GetSuppliersByCategory(ProcType, Category, subCategory);

        ddlBidders.DataSource = dtable;
        ddlBidders.DataTextField = "companyname";
        ddlBidders.DataValueField = "bidderid";
        ddlBidders.DataBind();
        
    }


    protected void cboBIdderSubcat_DataBound(object sender, EventArgs e)
    {
        cboBIdderSubcat.Items.Insert(0, new ListItem("-- Select Area of operation --", "0"));
    }

    protected void ddlBidders_DataBound1(object sender, EventArgs e)
    {
        ddlBidders.Items.Insert(0, new ListItem("-- Select Bidder --", "0"));
    }
}
