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

public partial class Bidding_PendingProcurements : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    ProcessPlanning ProcessPlan = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable datatable = new DataTable();
    DataLogin data = new DataLogin();
    DataSet dataSet = new DataSet();
    DataTable datatableitems = new DataTable();
    private string Status = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
               //if (Request.QueryString["transferid"] != null)
               // {
               //     string StatusToSelect = Request.QueryString["transferid"].ToString();
               //     cboCostCenters.SelectedIndex = cboCostCenters.Items.IndexOf(cboCostCenters.Items.FindByValue(StatusToSelect));
               // }
                LoadAreas(); LoadProcMethod();
              LoadPDUSupervisors();
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
    protected void cboProcMethod_DataBound(object sender, EventArgs e)
    {
        cboProcMethod.Items.Insert(0, new ListItem(" -- All Proc. Methods --", "0"));
    }
    private void LoadPDUSupervisors()
    {


        if (Session["AccessLevelID"].ToString() == "4")
        {
            //Load destinations for Small  procurement


            //cboTopPDUSupervisors.DataSource = ProcessReq.GetProcSPHead();
            //cboTopPDUSupervisors.DataValueField = "UserID";
            //cboTopPDUSupervisors.DataTextField = "FullName";
            //cboTopPDUSupervisors.DataBind();

            //cboPDUSupervisors.DataSource = ProcessReq.GetProcSPHead();
            //cboPDUSupervisors.DataValueField = "UserID";
            //cboPDUSupervisors.DataTextField = "FullName";
            //cboPDUSupervisors.DataBind();

        }
        else if (Session["AccessLevelID"].ToString() == "1026")
        {
            //Load destinations for Large procurement
    

            //cboTopPDUSupervisors.DataSource = ProcessReq.GetProcLPHead();
            //cboTopPDUSupervisors.DataValueField = "UserID";
            //cboTopPDUSupervisors.DataTextField = "FullName";
            //cboTopPDUSupervisors.DataBind();

            //cboPDUSupervisors.DataSource = ProcessReq.GetProcLPHead();
            //cboPDUSupervisors.DataValueField = "UserID";
            //cboPDUSupervisors.DataTextField = "FullName";
            //cboPDUSupervisors.DataBind();
        }
     
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

        datatable = Process.GetProcurementsForSupervisorSubmission(RecordID, PrNumber, ProcOfficer, ProcMethod, Status, AreaCode, CostCenterCode, false);
        
        if (datatable.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 0;
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind();
            lblEmpty.Text = ".";
        }
        else
        {
            MultiView1.ActiveViewIndex = 1;
            string EmptyMessage = "No Procurement(s) Ready For Submission in the system From Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
            lblEmpty.Text = EmptyMessage;
        }
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
        string ProcOfficer = Session["UserID"].ToString();
        datatable = Process.GetAssignedProcurements("0", PRNumber, "0", ProcOfficer, "", "", "");
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
            string Form = Process.GetForm(ProcMethodCode);
            lblHeading.Text = Subject + " - [" + Form + "]";
            lblProcMethod.Text = ProcMethodCode.ToString();
            lblRefNo.Text = PRNumber;

            if (e.CommandName == "btnViewForm")
            {

                if (ProcMethodCode.ToString().Equals("11"))
                {
                    MultiView1.ActiveViewIndex = 2;

                    ClearMicroProcurementControls();
                    lblReferenceNo.Text = PRNumber;
                    LoadMicroProcurementDetails(PRNumber);

                    MultiView2.ActiveViewIndex = 3;
                
                }else{
                    datatable = Process.GetAnsweredFormDetails(PRNumber);
                    MultiView1.ActiveViewIndex = 2;

                    if (datatable.Rows.Count > 0)
                    {
                        LoadAnsweredFormGrid();

                    }
                    else
                    {

                        DataTable dtcancel = new DataTable();
                        dgvFormDetails.DataSource = dtcancel;
                        dgvFormDetails.DataBind();
                        DataTable dtcancel2 = new DataTable();
                        dgvQuestions.DataSource = dtcancel2;
                        dgvQuestions.DataBind();
                    }
                    MultiView2.ActiveViewIndex = 0;
               
                }
            }
            else if (e.CommandName == "btnViewBidders")
            {
                datatable = Process.GetShortlistedBidderDetails(PRNumber);
                MultiView1.ActiveViewIndex = 2;
                MultiView2.ActiveViewIndex = 1;
                if (datatable.Rows.Count > 0)
                {
                    gvBidders.DataSource = datatable;
                    gvBidders.DataBind();
                }
            }
            else if (e.CommandName == "btnViewEC")
            {
                datatable = Process.GetECMemberDetails(PRNumber);
                MultiView1.ActiveViewIndex = 2;
                MultiView2.ActiveViewIndex = 2;
                if (datatable.Rows.Count > 0)
                {
                    gvEC.DataSource = datatable;
                    gvEC.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadAnsweredFormGrid()
    {
        dgvFormDetails.DataSource = datatable;
        dgvFormDetails.DataBind();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            DataTable dtcancel = new DataTable();
            dgvFormDetails.DataSource = dtcancel;
            dgvFormDetails.DataBind();
            DataTable dtcancel2 = new DataTable();
            dgvQuestions.DataSource = dtcancel2;
            dgvQuestions.DataBind();
            LoadItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
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
    
    private void LoadGrid(string ReferenceNo, string ProcMethod, string Section)
    {
              
              datatable = Process.GetGridAnswers(ReferenceNo, ProcMethod, Section);
              datatable.DefaultView.Sort = "Code asc";
            dgvQuestions.DataSource = datatable;
            dgvQuestions.DataBind();
            
    }
    public bool DisableLinkBidders(object dataItem)
    {

        if ((DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "5") || (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "13") || (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "6") || (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "2"))
            return false;
        else
            return true;
    }
    public bool DisableLinkEC(object dataItem)
    {

        if ((DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "1") || (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "11"))
            return false;
        else if ((DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "5") || (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "13") || (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "6") || (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "2"))
            return false;
        else
            return true;
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            if (dgvQuestions.Rows.Count == 0)
            {
                ShowMessage("There is no data for the report ...");
            }
            else
            {
                string ReferenceNo = lblRefNo.Text.Trim();
                int ProcMethod = Convert.ToInt32(lblProcMethod.Text.Trim());
                datatable = Process.GetFormNumberByProcMethod(ProcMethod, 1);

                string FormNumber = datatable.Rows[0]["FormNumber"].ToString();
                string Section = lblSection.Text.Trim();
                int NewProcMethod = ReturnProcMethod(ProcMethod);
                string ReportName = Process.GetReportName(NewProcMethod, FormNumber, Section, true);

                datatable = Process.GetForm1ForReport(ReferenceNo, FormNumber, Section);
                int rowcount = datatable.Rows.Count;

                if (rowcount != 0)
                {
                    btnPrint.Enabled = true;
                    loadreport(ReportName);

                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "PPForm");
                }
                else
                {
                    ShowMessage("No Data To Load For Report Form Selected ...");
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
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
    protected void btnFiles_Click(object sender, EventArgs e)
    {

    }
    protected void dgvQuestions_RowCommand(object sender, GridViewCommandEventArgs e)
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

    protected void btnSubmitSupervisor_Click(object sender, EventArgs e)
    {
        //if (cboTopPDUSupervisors.SelectedValue == "0")
        //    ShowMessage("Please Select Procurement Supervisor To Submit To");
        //else
        //{
            ShowMessage(".");
            SubmitProcurements();
        //}
    }

    private void SubmitProcurements()
    {
        string ItemArr = GetItemsToSubmit().TrimEnd(',');

        //if EOI Evaluation Submission then status =
        //if Draft RFP then status =
        //if Technical evluation then status =
        //if EOI Submission then status =

        int Status = 125;


        int PDUSupervisorID = 6;//Convert.ToInt32(cboPDUSupervisors.SelectedValue.ToString());
        long OfficerID = Convert.ToInt64(Session["UserID"].ToString());
        string PDUSupervisor = "6";//cboPDUSupervisors.SelectedItem.Text.ToString();
        string returned = Process.SubmitBiddingDetailsForSourcing(ItemArr, PDUSupervisorID, PDUSupervisor, OfficerID, Status);
        ShowMessage(returned);
        LoadItems();
    }

    private string GetItemsToSubmit()
    {
        int Count = 0;
        string ItemArr = "";
        foreach (DataGridItem Items in DataGrid1.Items)
        {
            CheckBox chk = ((CheckBox)(Items.FindControl("chbSubmit")));
            if (chk.Checked)
            {
                Count++;
                string ItemFound = Items.Cells[2].Text;
                ItemArr = ItemArr += ItemFound + ",";
            }
        }
        return ItemArr;
    }

    private void SelectAllItems(bool IsSelected)
    {
        foreach (DataGridItem Items in DataGrid1.Items)
        {
            CheckBox chk = ((CheckBox)(Items.FindControl("chbSubmit")));
            if (IsSelected)
                chk.Checked = true;
            else
                chk.Checked = false;
        }
    }
    protected void dgvFormDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "btnView")
        {
            int intIndex = Convert.ToInt32(e.CommandArgument);
            string Section = Convert.ToString(dgvFormDetails.DataKeys[intIndex].Value);
            lblSection.Text = Section;
            LoadGrid(lblRefNo.Text.Trim(), lblProcMethod.Text.Trim(), Section);
        }
    }

    protected void cboPDUSupervisors_DataBound(object sender, EventArgs e)
    {
        //cboPDUSupervisors.Items.Insert(0, new ListItem(" -- Select Procurement Supervisor -- ", "0"));
    }

    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        try
        {   
            if (chkSelect.Checked == true)
            {
                SelectAllItems(true);
                CheckBox2.Checked = true;
            }
            else
            {
                SelectAllItems(false);
                CheckBox2.Checked = false;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (CheckBox2.Checked == true)
            {
                SelectAllItems(true);
                chkSelect.Checked = true;
            }
            else
            {
                SelectAllItems(false);
                chkSelect.Checked = false;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void cboTopPDUSupervisors_SelectedIndexChanged(object sender, EventArgs e)
    {
        //cboPDUSupervisors.SelectedIndex = cboTopPDUSupervisors.SelectedIndex;
    }
    protected void cboPDUSupervisors_SelectedIndexChanged(object sender, EventArgs e)
    {
        //cboTopPDUSupervisors.SelectedIndex = cboPDUSupervisors.SelectedIndex;
    }

    protected void btnDone_Click(object sender, EventArgs e)
    {
        DataTable dtcancel = new DataTable();
        dgvQuestions.DataSource = dtcancel;
        dgvQuestions.DataBind();
       
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnPrintBidders_Click(object sender, EventArgs e)
    {
        try
        {
            string ReportName = "BidderShortlist32";
            string ReferenceNo = txtReferenceNo.Text.Trim();
            datatable = Process.GetReportForShortlistedBidders(ReferenceNo);
            int rowcount = datatable.Rows.Count;

            if (rowcount != 0)
            {
                loadreport(ReportName);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Shortlist of Bidders");
            }
            else
            {
                ShowMessage("No Data To Load For Report ... ");
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnPrintEC_Click(object sender, EventArgs e)
    {
        try
        {
            string ReportName = "ECMembers40";
            string ReferenceNo = txtReferenceNo.Text.Trim();
            datatable = Process.GetReportForECMembers(ReferenceNo);
            int rowcount = datatable.Rows.Count;

            if (rowcount != 0)
            {
                loadreport(ReportName);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Evaluation Committee");
            }
            else
            {
                ShowMessage("No Data To Load For Report ... ");
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboTopPDUSupervisors_DataBound(object sender, EventArgs e)
    {
        //cboTopPDUSupervisors.Items.Insert(0, new ListItem(" -- Select Procurement Supervisor -- ", "0"));
    }
    private void LoadMicroProcurementDetails(string ReferenceNo)
    {
        datatable = Process.GetMicroProcurementDetails(ReferenceNo);
        if (datatable.Rows.Count > 0)
        {
            lblReferenceNo.Text = datatable.Rows[0]["ReferenceNo"].ToString();
            lblMicroProcurementID.Text = datatable.Rows[0]["MicroProcurementID"].ToString();
            DateTime ClosingDateTime = Convert.ToDateTime(datatable.Rows[0]["ClosingDateTime"].ToString());
            txtClosingDateTime.Text = ClosingDateTime.ToString("dd MMM yyyy");
            txtClosingTime.Text = ClosingDateTime.Hour + ":" + ClosingDateTime.Minute;
            LoadPDO2Items(lblReferenceNo.Text.Trim()); 
        }
        else
        {
            LoadPDO2Items(ReferenceNo); 
        }
    }
    private void LoadPDO2Items(string ReferenceNo)
    {
        datatableitems = Process.GetMicroProcurementItems(ReferenceNo);
        if (datatableitems.Rows.Count > 0)
        {
            DataGrid2.DataSource = datatableitems;
            DataGrid2.DataBind();
            lblNoRecords.Visible = false;
        }
        else
            lblNoRecords.Visible = true;
    }
    private void ClearMicroProcurementControls()
    {
        lblReferenceNo.Text = "0"; lblMicroProcurementID.Text = "0"; txtClosingDateTime.Text = ""; ShowMessageMicroMsg(".");
    }
    private void ShowMessageMicroMsg(string Message)
    {
        if (Message == ".")
        {
            lblMicroMsg.Text = ".";
        }
        else
        {
            lblMicroMsg.Text = "MESSAGE: " + Message;
        }
    }
}
