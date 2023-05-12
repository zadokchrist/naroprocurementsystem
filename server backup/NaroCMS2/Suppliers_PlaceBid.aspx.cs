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
    int supplierId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["PR"] != null)
            {
                string PRNumber = Request.QueryString["PR"].ToString();
                Session["pr"] = PRNumber;
                LoadControls(PRNumber);
                supplierId = int.Parse(Session["supplierId"].ToString());
               // 
                //AutoCompleteExtender2.ContextKey = "0";
            }
            else
                Response.Redirect("Suppliers_Items.aspx", true);
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
    private void CreateBidDocsDataTable()
    {
        DataTable dtBidDocs = new DataTable("BidDocs");

        dtBidDocs.Columns.Add(new DataColumn("documentID", typeof(long)));
        dtBidDocs.Columns.Add(new DataColumn("Description", typeof(string)));
        dtBidDocs.Columns.Add(new DataColumn("DocType", typeof(string)));
        dtBidDocs.Columns.Add(new DataColumn("createdBy", typeof(string)));
        dtBidDocs.Columns.Add(new DataColumn("modifierId", typeof(long)));
        dtBidDocs.Columns.Add(new DataColumn("modifyDate", typeof(DateTime)));
        dtBidDocs.Rows.Clear();

        Session["dtBidDocs"] = dtBidDocs;
        dtUpdate = dtBidDocs;
    }
    private void LoadControls(string PRNumber)
    {
        dtable = Process.GetLevelProcurements("0", PRNumber, "0", "0", "", "", "");
        if (dtable.Rows.Count > 0)
        {
            txtPRNumber.Text = dtable.Rows[0]["ScalaPRNumber"].ToString();
            txtEstimatedCost.Text = Convert.ToDouble(dtable.Rows[0]["EstimatedCost"]).ToString("#,##0");
            txtProcSubject.Text = dtable.Rows[0]["Subject"].ToString();
            txtProcType.Text = dtable.Rows[0]["ProcurementType"].ToString();
           // txtProcMethod.Text = dtable.Rows[0]["Method"].ToString();
           // txtDateRequisitioned.Text = dtable.Rows[0]["CreationDate"].ToString();
          //  txtRequisitioner.Text = dtable.Rows[0]["Requisitioner"].ToString();
            txtDateRequired.Text = dtable.Rows[0]["DateRequired"].ToString();
         //   txtBudgetCostCenter.Text = dtable.Rows[0]["CostCenterName"].ToString();
            lblPDCode.Text = dtable.Rows[0]["PD_Code"].ToString();
            lblStatusID.Text = dtable.Rows[0]["StatusID"].ToString();
            ProcMethod = int.Parse(dtable.Rows[0]["ProcMethodCode"].ToString());
            lblprocmethod.Text = ProcMethod.ToString();
            ProcTypeCode = int.Parse(dtable.Rows[0]["ProcurementTypeID"].ToString());
            lblproctype.Text = ProcTypeCode.ToString();
            txtIFBEnd.Text = dtable.Rows[0]["BidSubmissionDate"].ToString();
            
        }
        supplierId = int.Parse(Session["supplierid"].ToString());
        LoadBidDocs(PRNumber, supplierId);
        //LoadBidderChoiceReasons(2);
       // LoadBidderCategories();
        
    }
    private void LoadBidderCategories()
    {
        //cboBidderCategory.DataSource = Process.GetBidderCategories();
        //cboBidderCategory.DataTextField = "CategoryName";
        //cboBidderCategory.DataValueField = "BiddercategoryID";
        //cboBidderCategory.DataBind();
    }
    private void LoadBidderChoiceReasons(int Type)
    {
        //cboReason.DataSource = Process.GetBidderReasons(Type);
        //cboReason.DataTextField = "Reason";
        //cboReason.DataValueField = "ID";
        //cboReason.DataBind();
    }
    private void LoadBidDocs(string PRNumber, int supplierId)
    {
        CreateBidDocsDataTable();
        dtable = Process.GetBidderDocuments(PRNumber, supplierId);
        if (dtable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            if (dtable.Rows.Count > 0)
            {
                foreach (DataRow dr in dtable.Rows)

                {
                    long documentId = Convert.ToInt64(dr["FileID"].ToString());
                    DateTime DateCreated = Convert.ToDateTime(dr["CreationDate"].ToString());
                    string supplierd = Session["Name"].ToString();
                    string docType = dr["DocumentType"].ToString();
                    string description = dr["FileName"].ToString();
                    string filepath = dr["FilePath"].ToString();
                    string modified = dr["lastModifed"].ToString();
                    long modifier = 1;

                    lblCreatedBy.Text = supplierId.ToString();
                    dtUpdate.Rows.Add(new object[] { documentId, description, docType, supplierd, modifier, modified });
                }
                Session["dtBidders"] = dtUpdate;
                DataGrid2.DataSource = dtable; DataGrid2.Visible = true;
                DataGrid2.DataBind(); btnPrint.Enabled = true;
            }
        }
    }
    protected void cboReason_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (cboReason.SelectedItem.Text == "Other")
        //{
        //    txtReason.Visible = true;

        //}
        //else
        //{
        //    txtReason.Visible = false;
        //}
    }
    protected void cboReason_DataBound(object sender, EventArgs e)
    {
        //cboReason.Items.Insert(0, new ListItem(" -- Select Reason -- ", "0"));
    }
    protected void btnAddBidder_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage("."); ShowMessage2(".");
            if (cboBidDocs.SelectedItem.Value=="0")
                ShowMessage2("Please Select From the List of Document Types");
             else if (!FileUpload1.HasFile)
                ShowMessage2("Please Uplaod a file");
            else
            {


            try
                {
                    HttpFileCollection uploads;
                    uploads = HttpContext.Current.Request.Files;
                    string refno = txtPRNumber.Text;
                    string c = FileUpload1.PostedFile.FileName;
                    string docType = cboBidDocs.SelectedItem.Text;
                    string docTypeid = cboBidDocs.SelectedValue;

                    string cNoSpace = c.Replace(" ", "-");
                    String suppplier = Session["supplierid"].ToString();
                    String suppllierName = Session["Name"].ToString();
                    string name = suppllierName + "_" + refno + "_" + docType;
                    String name1 = name.Replace("/", "_");
                    String name2 = name1.Replace(":", "-");
                    String fname = name2.Replace(" ", "-");
                    string Extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                    string Path = Process.GetDocPath();
                    String Filepath = Path + "" + fname;
                    FileUpload1.PostedFile.SaveAs(Filepath);

                    Process.SaveBiddingDocument(refno, Filepath, name, int.Parse(docTypeid));
                    LoadBidDocs(refno, int.Parse(suppplier));
                }catch(Exception ex)
                {

                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage2(ex.Message);
        }
    }
    private void ClearItemControls()
    {
        //ddlBidders.SelectedIndex = 0; txtReason.Text = ""; btnAddBidder.Text = "Add Bidder";
        //cboReason.SelectedValue = "0"; txtProposedBy.Text = ""; txtReason.Visible = false;
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

        //Hidetoolbar();
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
        string documentID = e.Item.Cells[0].Text.Trim();

        //string DateCreated = e.Item.Cells[1].Text.Trim();
        string description = e.Item.Cells[1].Text;
        //string ProposedBy = e.Item.Cells[3].Text;
        //string ReasonID = e.Item.Cells[4].Text; string OtherReason = e.Item.Cells[6].Text;
        int ItemRowIndex = e.Item.DataSetIndex;
        
        dtUpdate = (DataTable)Session["dtBidders"];
        ShowMessage("."); ShowMessage2(".");
        if (e.CommandName == "btnEdit")
        {
            LoadBiddocControls(documentID, description);
           
        }
        else if (e.CommandName == "btnRemove")
        {
            long SID = Convert.ToInt64(documentID);
            if (SID != 0)
                Process.FlagPotentialBidder(SID, true);
            ShowMessage2(description + " Has Been Successfully Removed ...");
         // LoadControls(txtPRNumber.Text.Trim());
            
        }
       
        dtUpdate.Rows.RemoveAt(ItemRowIndex);
        DataGrid2.DataSource = dtUpdate.DefaultView;
        DataGrid2.DataBind();
    }

    private void LoadBiddocControls(string documentID, string description)
    {
        lblShortlistID.Text = documentID;
        cboBidDocs.SelectedValue = description;
        //cboReason.SelectedValue = ReasonID;
        //ddlBidders.SelectedIndex = ddlBidders.Items.IndexOf(ddlBidders.Items.FindByValue(BidderName));
        //txtProposedBy.Text = ProposedBy; txtReason.Text = OtherReason;
        //if (cboReason.SelectedItem.Text.Trim() == "Other")
        //    txtReason.Visible = true;
        btnAddBidder.Text = "Update Bid";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        dtUpdate = (DataTable)Session["dtBidDocs"];
        ShowMessage2("."); ShowMessage(".");
        if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Bid Documents Before Submission");
            ShowMessage2("Please Add Bid Documents Before Submission");
        }
        else
        {
            string ReferenceNo = txtPRNumber.Text;
            int supplier = int.Parse(Session["supplierId"].ToString());
            Process.updateIFB(ReferenceNo, supplier);

            string Response = "Bid succesfully sent";
            //Session["dtBidders"] = dtUpdate;
            //DataTable dtBidders = (DataTable)Session["dtBidders"];
            //int StatusID = Convert.ToInt32(lblStatusID.Text); string CreatedBy;
            //if (StatusID > 40 && Process.GetShortlistedBidderDetails(txtPRNumber.Text).Rows.Count > 0)
            //    CreatedBy = lblCreatedBy.Text;
            //else
            //    CreatedBy = Session["UserID"].ToString();

            //string Response = Process.SavePotentialBidders(lblPDCode.Text.Trim(), txtPRNumber.Text.Trim(), dtBidders, CreatedBy, int.Parse(lblprocmethod.Text.Trim()), int.Parse(lblproctype.Text.Trim())); 
            //btnPrint.Enabled = true;
            //if (StatusID > 40)
            //{
            //    //string ReferenceNo = txtPRNumber.Text;
            //    //string PDUSupervisor = HttpContext.Current.Session["FullName"].ToString();
            //    //DataTable dtAlert = Process.GetBiddingDetailsForNotification(ReferenceNo);
            //    //string Subject = "Procurement Supervisor Edited Shortlisted Bidders For " + dtAlert.Rows[0]["Subject"].ToString();
            //    //string OfficerID = dtAlert.Rows[0]["POID"].ToString(); string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
            //    //string CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();

            //    ///// Notify Procurement Officer
            //    //string Message = "<p>Evaluation Committee Members for Procurement ( " + ReferenceNo + " ) from " + CostCenterName + " has been edited by Procurement Supervisor " + PDUSupervisor + " </p>";
            //    //Message += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

            //    //ProcessReq.NotifyOfficer(PDUSupervisor, Subject, OfficerID, Message);
            //}
            lblDone.Text = Response;
            MultiView1.ActiveViewIndex = 1;
        }
    }

    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        //string PreviousPage = Session["PreviousPage"].ToString();
        //Session["PreviousPage"] = "Supplier_PlaceBid.aspx";
        //Session["PRNumber"] = txtPRNumber.Text;
        Response.Redirect("Suppliers_Items.aspx", true);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        //string PreviousPage = Session["PreviousPage"].ToString();
        //Session["PreviousPage"] = "Bidding_ShortlistBidders.aspx";
        //Session["PRNumber"] = txtPRNumber.Text;
        Response.Redirect("Suppliers_Items.aspx", true);
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
       // cboBidderCategory.Items.Insert(0, new ListItem("-- Select Category --", "0"));
    }
    protected void cboBidderCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
       // AutoCompleteExtender2.ContextKey = cboBidderCategory.SelectedValue;

        //string biddercat = cboBidderCategory.SelectedItem.Value;

        //loadBiddersByCategory(biddercat);

    }
    void loadBiddersByCategory(String biddercat)
    {
        //dtable = Process.GetBidderByCategory(int.Parse(biddercat));
        //ddlBidders.DataSource = dtable;
        //ddlBidders.DataTextField = "CompanyName";
        //ddlBidders.DataValueField = "BidderID";
        //ddlBidders.DataBind();
    }
    protected void ddlBidders_DataBound(object sender, EventArgs e)
    {
        //ddlBidders.Items.Insert(0, new ListItem("-- Select Bidder --", "0"));
    }
}
