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
using System.IO;

public partial class Bidding_Negotiations : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    ProcessPlanning ProcessPlan = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable datatable = new DataTable();
    DataTable dtUpdate = new DataTable();
    DataLogin data = new DataLogin();
    DataSet dataSet = new DataSet();

    private string Status = "61,70";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadAreas(); LoadProcMethod();
                MultiView1.ActiveViewIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadProcMethod()
    {
        datatable = ProcessPlan.GetProcurementMethods();
        cboProcMethod.DataSource = datatable;
        cboProcMethod.DataValueField = "MethodCode";
        cboProcMethod.DataTextField = "Method";
        cboProcMethod.DataBind();
    }
    private void CreateNegotiationDataTable()
    {
        DataTable dtNegotiation = new DataTable("Negotiations");
        dtNegotiation.Columns.Add(new DataColumn("NegotiationID", typeof(long)));
        dtNegotiation.Columns.Add(new DataColumn("RecommendationsToCC", typeof(string)));
        dtNegotiation.Rows.Clear();

        Session["dtNegotiation"] = dtNegotiation;
        dtUpdate = dtNegotiation;
        ClearItemControls(); ClearMeetingsItemControls();
    }
    private void CreateNegotiationDetailsDataTable()
    {
        DataTable dtNegotiationDetails = new DataTable("NegotiationDetails");
        dtNegotiationDetails.Columns.Add(new DataColumn("IssueID", typeof(long)));
        dtNegotiationDetails.Columns.Add(new DataColumn("NegotiationID", typeof(long)));
        dtNegotiationDetails.Columns.Add(new DataColumn("Issue", typeof(string)));
        dtNegotiationDetails.Columns.Add(new DataColumn("Agreement", typeof(string)));

        dtNegotiationDetails.Rows.Clear();

        Session["dtNegotiationDetails"] = dtNegotiationDetails;
        dtUpdate = dtNegotiationDetails;
        ClearItemControls(); ClearQuestionItemControls();
    }
    private void LoadAreas()
    {
        datatable = data.GetAreas();
        cboAreas.DataSource = datatable;
        cboAreas.DataValueField = "AreaID";
        cboAreas.DataTextField = "Area";
        cboAreas.DataBind();

        LoadCostCenters(cboAreas.SelectedIndex);
    }
    private void ToggleCenter()
    {
        int AccessLevelID = Convert.ToInt32(Session["AccessLevelID"].ToString());
        string AreaID = Session["AreaCode"].ToString();
        cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue(AreaID));
    }
    private void LoadCostCenters(int AreaID)
    {
        string AreaCode = AreaID.ToString();
        datatable = ProcessPlan.GetCostCentersByName("", AreaCode);
        cboCostCenters.DataSource = datatable;
        cboCostCenters.DataValueField = "CostCenterID";
        cboCostCenters.DataTextField = "CostCenterDesc";
        cboCostCenters.DataBind();
    }
    private void LoadItems()
    {
        string RecordID = "0"; string PrNumber = txtPrNumber.Text.Trim();
        string ProcMethod = cboProcMethod.SelectedValue.ToString(); string ProcOfficer = Session["UserID"].ToString();
        string CostCenterCode = cboCostCenters.SelectedValue.ToString(); string AreaCode = cboAreas.SelectedValue.ToString();
        
        datatable = Process.GetBiddingProcurements(RecordID, PrNumber, ProcMethod, ProcOfficer, Status, AreaCode, CostCenterCode);

        if (datatable.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 0;
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind();
            lblEmpty.Text = ".";
        }
        else
        {
            MultiView1.ActiveViewIndex = 0; 
            string EmptyMessage = "No Procurement(s) Requiring Negotiations in the system From Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
            lblEmpty.Text = EmptyMessage;
        }
    }
    public bool EnableDetailsLink(object dataItem)
    {
        string NegotiationID = DataBinder.Eval(dataItem, "NegotiationID").ToString();

        if (NegotiationID != "0")
            return true;
        else
            return false;
    }
    private void ShowMessage(string Message)
    {
        Label msg = (Label)Master.FindControl("lblmsg");
        if (Message == ".")
        {
            msg.Text = ".";
        }
        else
        {
            msg.Text = "MESSAGE: " + Message;
        }
    }
    private void LoadControls(string PRNumber)
    {
        datatable = Process.GetLevelProcurements("0", PRNumber, "0", "0", "", "", "");
        if (datatable.Rows.Count > 0)
        {
            txtReferenceNo.Text = datatable.Rows[0]["ScalaPRNumber"].ToString();
            txtEstimatedCost.Text = Convert.ToDouble(datatable.Rows[0]["EstimatedCost"]).ToString("#,##0");
            txtProcSubject.Text = datatable.Rows[0]["Subject"].ToString();
            txtProcType.Text = datatable.Rows[0]["ProcurementType"].ToString();
            txtProcMethod.Text = datatable.Rows[0]["Method"].ToString();
            txtDateRequisitioned.Text = datatable.Rows[0]["CreationDate"].ToString();
            txtRequisitioner.Text = datatable.Rows[0]["Requisitioner"].ToString();
            txtDateRequired.Text = datatable.Rows[0]["DateRequired"].ToString();
            txtBudgetCostCenter.Text = datatable.Rows[0]["CostCenterName"].ToString();
        }
        LoadNegotiationDetails(PRNumber);
    }
    private void LoadNegotiationDetails(string PRNumber)
    {
        CreateNegotiationDataTable();
        datatable = Process.GetNegotiations(PRNumber);
        if (datatable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in datatable.Rows)
            {
                long NegotiationID = Convert.ToInt64(dr["NegotiationID"].ToString());
                DateTime RecommendationsToCC = Convert.ToDateTime(dr["RecommendationsToCC"].ToString()); 

                dtUpdate.Rows.Add(new object[] { NegotiationID, RecommendationsToCC });
            }
            Session["dtNegotiation"] = dtUpdate;
            DataGrid2.DataSource = datatable;
            DataGrid2.DataBind(); DataGrid2.Visible = true;
            lblNoMeetings.Visible = false;
        }
        else
        {
            DataGrid2.DataSource = null; DataGrid2.Visible = false;
            lblNoMeetings.Visible = true;
        }
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            string RecordID = e.Item.Cells[0].Text;
            string PRNumber = e.Item.Cells[2].Text;
            LoadControls(PRNumber);       
            string Subject = e.Item.Cells[3].Text;
            int ProcMethodCode = Convert.ToInt32(e.Item.Cells[5].Text);
            ProcMethodCode = ReturnProcMethod(ProcMethodCode);
            lblHeading.Text = Subject;
            lblProcMethod.Text = ProcMethodCode.ToString();
            lblRefNo.Text = PRNumber;

            if (e.CommandName == "btnAddNegotiation")
            {
                MultiView1.ActiveViewIndex = 2;
                MultiView2.ActiveViewIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            ClearMessages();
            LoadItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void ClearMessages()
    {
        ShowMessage("."); ShowMessage2("."); ShowMessage3(".");
    }
    protected void cboCostCenter_DataBound(object sender, EventArgs e)
    {
        cboCostCenters.Items.Insert(0, new ListItem("- - All Cost Centers - -", "0"));
    }
    protected void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        int AreaID = Convert.ToInt32(cboAreas.SelectedValue.ToString());
        LoadCostCenters(AreaID);
    }
    protected void cboAreas_DataBound1(object sender, EventArgs e)
    {
        cboAreas.Items.Insert(0, new ListItem(" -- All Areas -- ", "0"));
    }
    private int ReturnProcMethod(int ProcurementMethod)
    {
        int NewMthd = 0;
        switch (ProcurementMethod)
        {
            case 3:
                NewMthd = 2;
                break;
            case 6:
                NewMthd = 5;
                break;
            default:
                NewMthd = ProcurementMethod;
                break;
        }
        return NewMthd;
    }
    public void loadreport(string ReportName)
    {
        string appPath, physicalPath, rptName;
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        rptName = physicalPath + "\\Bin\\Reports\\Bidding\\" + ReportName + ".rpt";

        //doc.Load(rptName);
        //doc.SetDataSource(datatable);

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
    protected void btnFiles_Click(object sender, EventArgs e)
    {

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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage2(".");
            if (String.IsNullOrEmpty(txtMeetingLocation.Text.Trim()))
                ShowMessage2("Please Enter The Meeting Location");
            else if (String.IsNullOrEmpty(txtMeetingDate.Text.Trim()))
                ShowMessage2("Please Enter The Meeting Date");
            else if (String.IsNullOrEmpty(txtReasonForMeeting.Text.Trim()))
                ShowMessage2("Please The Reason For The Pre-Bid Meeting");
            else
            {
                string MeetingLocation = txtMeetingLocation.Text.Trim(); 
                DateTime MeetingDate = Convert.ToDateTime(txtMeetingDate.Text.Trim());
                string[] MeetingTime = txtMeetingTime.Text.Trim().Split(':');
                int Hour = Convert.ToInt32(MeetingTime[0]); int Min = Convert.ToInt32(MeetingTime[1]);
                DateTime MeetingDateTime = new DateTime(MeetingDate.Year, MeetingDate.Month, MeetingDate.Day, Hour, Min, 0);
            
                string ReasonForMeeting = txtReasonForMeeting.Text.Trim();
                long PreBidMeetingID = 0;

                dtUpdate = (DataTable)Session["dtMeetingDetails"];
                if (btnAdd.Text.Contains("Update"))
                {
                    PreBidMeetingID = Convert.ToInt64(lblPreBidMeetID.Text);
                    int i = 0;
                    foreach (DataRow dr in dtUpdate.Rows)
                    {
                        if (Convert.ToInt64(dr["PreBidMeetingID"]) == PreBidMeetingID)
                        {
                            dtUpdate.Rows.RemoveAt(i);
                            break;
                        }
                        i++;
                    }
                }
                dtUpdate.Rows.Add(new object[] { PreBidMeetingID, MeetingLocation, MeetingDate, ReasonForMeeting, "" });
                ClearItemControls();

                ShowMessage2("Pre-Bid Meeting Details Has Been Successfully Added/Updated");

                Session["dtMeetingDetails"] = dtUpdate;
                DataGrid2.DataSource = dtUpdate.DefaultView;
                DataGrid2.DataBind(); DataGrid2.Visible = true;
                lblNoMeetings.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ShowMessage2(ex.Message);
        }
    }
    private void ClearMeetingsItemControls()
    {
        txtMeetingDate.Text = ""; txtMeetingLocation.Text = ""; txtReasonForMeeting.Text = "";
        btnAdd.Text = "Add Meeting";
    }
    private void ShowMessage2(string Message)
    {
        if (Message == ".")
            lblMsg.Text = ".";
        else
            lblMsg.Text = "MESSAGE: " + Message;
    }
    private void ShowMessage3(string Message)
    {
        if (Message == ".")
            lblMsg2.Text = ".";
        else
            lblMsg2.Text = "MESSAGE: " + Message;
    }
    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        string ID = e.Item.Cells[0].Text; string MeetingLocation = e.Item.Cells[1].Text;
        string MeetingDate = e.Item.Cells[2].Text; string ReasonForMeeting = e.Item.Cells[3].Text;
        long PreBidMeetingID = Convert.ToInt64(ID); lblPreBidMeetID.Text = ID;
        lblPreBidMeetingIDQ.Text = ID; lblHeading.Text = txtProcSubject.Text;
        int ItemRowIndex = e.Item.DataSetIndex; dtUpdate = (DataTable)Session["dtMeetingDetails"];
        if (e.CommandName == "btnEdit")
            LoadMeetingDetailsControls(ID, MeetingLocation, MeetingDate, ReasonForMeeting);
        else if (e.CommandName == "btnRemove")
        {
            ShowMessage2(".");
            if (ID == "0")
                dtUpdate.Rows.RemoveAt(ItemRowIndex);
            else
            {
                Process.FlagPreBidMeeting(PreBidMeetingID, true);
            }
            ShowMessage2("Pre-Bid Meeting Details Have Been Successfully Removed ...");
            LoadControls(txtReferenceNo.Text.Trim());
        }
        else if (e.CommandName == "btnAddMeetingDetails")
        {
            LoadMeetingQuestionDetails(PreBidMeetingID);
            lblAttachRefNo.Text = txtReferenceNo.Text;
            LoadDocuments();
            MultiView1.ActiveViewIndex = 3;
            MultiView3.ActiveViewIndex = 0;
        }
    }
    private void LoadMeetingDetailsControls(string PreBidMeetingID, string MeetingLocation, string MeetingDate, string Reason)
    {
        lblMeetingID.Text = PreBidMeetingID; txtMeetingLocation.Text = MeetingLocation; txtMeetingDate.Text = MeetingDate; 
        txtReasonForMeeting.Text = Reason; btnAdd.Text = "Update Meeting";
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        ClearItemControls(); 
        MultiView1.ActiveViewIndex = 2;
        MultiView2.ActiveViewIndex = 0;
    }
    private void ClearItemControls()
    {
        ClearMeetingsItemControls();
        ClearQuestionItemControls();
    }
    protected void btnSubmitMeeting_Click(object sender, EventArgs e)
    {
        dtUpdate = (DataTable)Session["dtMeetingDetails"];
        ShowMessage2("."); ShowMessage(".");
        
        if (dtUpdate.Rows.Count == 0)
        {
          ShowMessage2("Please Add Pre-Bid Meeting Details");
        }
        else
        {
            Session["dtMeetingDetails"] = dtUpdate;
            DataTable dtMeetingDetails = (DataTable)Session["dtMeetingDetails"];
            long CreatedBy = Convert.ToInt64(Session["UserID"].ToString()); string RefNo = txtReferenceNo.Text.Trim();
            long PreBidMeetingID = 0; string MeetingLocation; DateTime MeetingDate; string ReasonForMeeting; string MeetingMinutesFile;
            
            foreach (DataRow dr in dtMeetingDetails.Rows)
            {
                PreBidMeetingID = Convert.ToInt64(dr["PreBidMeetingID"].ToString()); MeetingLocation = dr["MeetingLocation"].ToString();
                MeetingDate = Convert.ToDateTime(dr["MeetingDate"].ToString()); ReasonForMeeting = dr["ReasonForMeeting"].ToString();
                MeetingMinutesFile = "";

                Process.SaveEditPreBidMeeting(PreBidMeetingID, RefNo, MeetingLocation, MeetingDate, ReasonForMeeting, CreatedBy);
            }
            ShowMessage2("Pre-Bid Meeting Details Have Been Successfully Added to Procurement " + RefNo);
            LoadControls(txtReferenceNo.Text);
        }
    }
    private void LoadMeetingQuestionDetails(long PreBidMeetingID)
    {
        CreateNegotiationDetailsDataTable();
        datatable = Process.GetPreBidMeetingByID(PreBidMeetingID);
        if (datatable.Rows.Count > 0)
        {
            txtMeetingDate1.Text = datatable.Rows[0]["MeetingDate"].ToString();
            txtMeetingLocation1.Text = datatable.Rows[0]["MeetingLocation"].ToString();
            txtReasonForMeeting1.Text = datatable.Rows[0]["ReasonForMeeting"].ToString();
        }
        datatable = Process.GetPreBidMeetingQuestions(PreBidMeetingID);
        if (datatable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in datatable.Rows)
            {
                long ID = Convert.ToInt64(dr["ID"].ToString());
                string Question = dr["Question"].ToString(); string Answer = dr["Answer"].ToString();

                dtUpdate.Rows.Add(new object[] { ID, PreBidMeetingID, Question, Answer });
            }
            Session["dtMeetingQuestionDetails"] = dtUpdate;
            DataGrid4.DataSource = datatable; DataGrid4.Visible = true;
            DataGrid4.DataBind(); DataGrid4.Visible = true; btnPrintQn.Enabled = true;
            lblNoQuestions.Visible = false;
        }
        else
        {
            DataGrid4.Visible = false; lblNoQuestions.Visible = false; btnPrintQn.Enabled = false;
        }
    }
    public void ClearQuestionItemControls()
    {
        txtQuestionAsked.Text = ""; txtResponseGiven.Text = ""; 
        btnAddQuestionResponse.Text = "Add Question and Response";
    }
    public void LoadMeetingQuestionDetailsControls(string ID, string Question, string Answer)
    {
        lblIDQ.Text = ID; txtQuestionAsked.Text = Question; txtResponseGiven.Text = Answer;
        btnAddQuestionResponse.Text = "Update Question and Response";
    }
    protected void btnAddQuestionResponse_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage3(".");
            if (String.IsNullOrEmpty(txtQuestionAsked.Text.Trim()))
                ShowMessage3("Please Enter The Question Asked");
            else if (String.IsNullOrEmpty(txtResponseGiven.Text.Trim()))
                ShowMessage3("Please Enter The Response Given");
            else
            {
                string Question = txtQuestionAsked.Text.Trim(); string Answer = txtResponseGiven.Text.Trim();
                long ID = 0; long PreBidMeetingID = Convert.ToInt64(lblPreBidMeetingIDQ.Text.Trim());

                dtUpdate = (DataTable)Session["dtMeetingQuestionDetails"];
                if (btnAdd.Text.Contains("Update"))
                {
                    ID = Convert.ToInt64(lblIDQ.Text.Trim());
                    int i = 0;
                    foreach (DataRow dr in dtUpdate.Rows)
                    {
                        if (Convert.ToInt64(dr["ID"]) == ID)
                        {
                            dtUpdate.Rows.RemoveAt(i);
                            break;
                        }
                        i++;
                    }
                }
                dtUpdate.Rows.Add(new object[] { ID, PreBidMeetingID, Question, Answer });
                ClearItemControls();

                ShowMessage3("Question and Response Has Been Successfully Added");

                Session["dtMeetingQuestionDetails"] = dtUpdate;
                DataGrid4.DataSource = dtUpdate.DefaultView;
                DataGrid4.DataBind(); DataGrid4.Visible = true;
                lblNoQuestions.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ShowMessage3(ex.Message);
        }
    }
    protected void btnSubmitQuestion_Click(object sender, EventArgs e)
    {
        dtUpdate = (DataTable)Session["dtMeetingQuestionDetails"];
        ShowMessage3("."); ShowMessage(".");

        if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Question(s) Asked and Response(s) Responded  Details");
            ShowMessage3("Please Add Question(s) Asked and Response(s) Responded  Details");
        }
        else
        {
            Session["dtMeetingQuestionDetails"] = dtUpdate;
            DataTable dtMeetingQuestionDetails = (DataTable)Session["dtMeetingQuestionDetails"];
            long ID = 0; long PreBidMeetingID = Convert.ToInt64(lblPreBidMeetingIDQ.Text.Trim());
            long CreatedBy = Convert.ToInt64(Session["UserID"].ToString());
            string Question; string Answer;

            foreach (DataRow dr in dtMeetingQuestionDetails.Rows)
            {
                ID = Convert.ToInt64(dr["ID"].ToString()); Question = dr["Question"].ToString();
                Answer = dr["Answer"].ToString();

                Process.SaveEditPrebidMeetingQuestions(ID, PreBidMeetingID, Question, Answer, CreatedBy); 
            }
            ShowMessage("Pre-Bid Meeting Question(s) and Response(s) Have Been Successfully Added to Meeting ");
            btnPrintQn.Enabled = true;
            LoadMeetingQuestionDetails(Convert.ToInt64(lblIDQ.Text));
        }
    }
    protected void DataGrid4_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        string ID = e.Item.Cells[0].Text; string PreBidMeetingID = e.Item.Cells[1].Text;
        string Question = e.Item.Cells[2].Text; string Answer = e.Item.Cells[3].Text;
        int ItemRowIndex = e.Item.DataSetIndex; dtUpdate = (DataTable)Session["dtMeetingDetails"];
        if (e.CommandName == "btnEdit")
            LoadMeetingQuestionDetailsControls(ID, Question, Answer);
        else if (e.CommandName == "btnRemove")
        {
            ShowMessage3(".");
            if (ID == "0")
                dtUpdate.Rows.RemoveAt(ItemRowIndex);
            else
            {
                long QuestionID = Convert.ToInt64(ID);
                Process.FlagPreBidMeetingQuestion(QuestionID, true);
            }
            ShowMessage3("Pre-Bid Meeting Question and Response Details Have Been Successfully Removed ...");
            LoadMeetingQuestionDetails(Convert.ToInt64(PreBidMeetingID));
        }
    }
    protected void btnCancelQuestion_Click(object sender, EventArgs e)
    {
        ClearItemControls();
        MultiView1.ActiveViewIndex = 2;
        MultiView2.ActiveViewIndex = 0;
    }
    protected void btnPrintQn_Click(object sender, EventArgs e)
    {
        try
        {
            ClearMessages();
            if (DataGrid4.Items.Count == 0)
            {
                ShowMessage("There is not data to print for the record of PreBid Meeting ...");
            }
            else
            {
                string ReportName = "PreBidMeetingMinutes";
                long PreBidMeetingID = Convert.ToInt64(lblPreBidMeetingIDQ.Text);
                datatable = Process.GetReportForPreBidMeetingQuestions(PreBidMeetingID);
                int rowcount = datatable.Rows.Count;

                if (rowcount != 0)
                {
                    loadreport(ReportName);

                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Record of Pre-Bid Meeting PP Form 33(Part 1)");
                }
                else
                {
                    ShowMessage("No data to load for report ..... ");
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboProcMethod_DataBound(object sender, EventArgs e)
    {
        cboProcMethod.Items.Insert(0, new ListItem(" -- All Proc. Methods --", "0"));
    }
    public bool IsFileRemoveable(int IsRemoveable)
    {
        if (IsRemoveable == 1)
            return true;
        else
            return false;
    }
    protected void btnSaveFile_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            string RefNo = lblAttachRefNo.Text.Trim();
            UploadFiles(RefNo);
            LoadDocuments();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadDocuments()
    {
        string RefNo = lblAttachRefNo.Text.Trim();
        datatable = Process.GetBiddingDocuments(RefNo, 6);
        if (datatable.Rows.Count > 0)
        {
            GridAttachments.DataSource = datatable;
            GridAttachments.DataBind();
            GridAttachments.Visible = true;
            lblNoAttachments.Visible = false;
        }
        else
        {
            lblNoAttachments.Visible = true;
            GridAttachments.Visible = false;
        }
        MultiView1.ActiveViewIndex = 3;
        MultiView3.ActiveViewIndex = 1;
    }
    private void UploadFiles(string ReferenceNo)
    {
        HttpFileCollection uploads;
        uploads = HttpContext.Current.Request.Files;
        int countfiles = 0;
        for (int i = 0; i <= (uploads.Count - 1); i++)
        {
            if (uploads[i].ContentLength > 0)
            {
                string c = System.IO.Path.GetFileName(uploads[i].FileName);
                string cNoSpace = c.Replace(" ", "-");
                string c1 = ReferenceNo + "_" + (countfiles + i + 1) + "_" + cNoSpace;
                string Path = Process.GetDocPath();
                FileField.PostedFile.SaveAs(Path + "" + c1);
                Process.SaveBiddingDocument(ReferenceNo, (Path + "" + c1), c, 6);
                LoadDocuments();
            }
        }
    }
    protected void GridAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnRemove")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridAttachments.DataKeys[intIndex].Value);
                Process.RemoveDocument(FileCode);
                LoadDocuments();
            }
            else
            {
                // View 
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridAttachments.DataKeys[intIndex].Value);
                string Path = Process.GetDocumentPath(FileCode);
                Process.DownloadFile(Path, true);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnPreBidMeetingDetails_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
        MultiView3.ActiveViewIndex = 1;
    }
    protected void btnPreBidMeetingAttendence_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 3;
        MultiView3.ActiveViewIndex = 2;
    }
}
