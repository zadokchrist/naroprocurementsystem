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


public partial class Bidding_MicroProcApproval : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    ProcessPlanning ProcessPlan = new ProcessPlanning();
    BusinessBidding bll = new BusinessBidding();
    DataTable datatable = new DataTable();
    DataLogin data = new DataLogin();
    DataSet dataSet = new DataSet();
    private string Status = "38";
    DataTable dtUpdate = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadAreas(); LoadOfficers();
                MultiView1.ActiveViewIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
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
    private void LoadOfficers()
    {
        cboProcurementOfficer.DataSource = ProcessReq.GetPDUMembers();
        cboProcurementOfficer.DataValueField = "UserID";
        cboProcurementOfficer.DataTextField = "Name";
        cboProcurementOfficer.DataBind();
    }
    private void LoadItems()
    {


        //ShowMessage(".");
        string RecordID = "0"; string PrNumber = txtPrNumber.Text.Trim();
        string ProcOfficer = cboProcurementOfficer.SelectedValue.ToString();
        string CostCenterCode = cboCostCenters.SelectedValue.ToString(); string AreaCode = cboAreas.SelectedValue.ToString();

        string ChairmanCode = Session["UserID"].ToString();
        if (bll.IsContractsCommitteeChairman(ChairmanCode))
        {
            datatable = Process.GetMicroProcurementCCChairmanApprovals(RecordID, PrNumber, ProcOfficer, ChairmanCode, AreaCode, CostCenterCode);
            if (datatable.Rows.Count > 0)
            {
                MultiView1.ActiveViewIndex = 0;
                DataGrid1.DataSource = datatable;
                DataGrid1.DataBind(); DataGrid1.Visible = true;
                lblEmpty.Text = ".";
                lblSearch.Text = "CHAIRMAN CONTRACTS COMMITTEE - MICRO PROCUREMENTS APPROVAL";
            }
            else
            {
                lblSearch.Text = "CHAIRMAN CONTRACTS COMMITTEE - MICRO PROCUREMENTS APPROVAL";
                DataGrid1.Visible = false;
                string EmptyMessage = "No Micro Procurement(s) Pending Approval Found in the System from Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
                lblEmpty.Text = EmptyMessage;
            }
        }
        else
        {
                 string HeadOfDepartment = Session["UserID"].ToString();

           
                datatable = Process.GetMicroProcurementHODApprovals(RecordID, PrNumber, ProcOfficer, HeadOfDepartment, AreaCode, CostCenterCode);

                if (datatable.Rows.Count > 0)
                {
                    MultiView1.ActiveViewIndex = 0;
                    DataGrid1.DataSource = datatable;
                    DataGrid1.DataBind(); DataGrid1.Visible = true;
                    lblEmpty.Text = ".";
                    lblSearch.Text = "HEAD OF DEPARTMENT - MICRO PROCUREMENTS APPROVAL";
                }
                else
                {
                    lblSearch.Text = "HEAD OF SECTION/DEPARTMENT - MICRO PROCUREMENTS APPROVAL";
                    DataGrid1.Visible = false;
                    string EmptyMessage = "No Micro Procurement(s) Pending Approval Found in the System from Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
                    lblEmpty.Text = EmptyMessage;
                }
            
        }
    }
    public bool EnableSubmitCheckBox(object dataItem)
    {
        bool IsSubmitEnabled = Convert.ToBoolean(DataBinder.Eval(dataItem, "IsSubmitEnabled").ToString());

        if (IsSubmitEnabled)
            return true;
        else
            return false;
    }
    public bool DisableLink(object dataItem)
    {
        if (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "1")
            return false;
        else
            return true;
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
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            string RecordID = e.Item.Cells[0].Text;
            string PRNumber = e.Item.Cells[2].Text;
            string Subject = e.Item.Cells[3].Text;
            int ProcMethodCode = Convert.ToInt32(e.Item.Cells[5].Text);
            lblPDCode.Text = e.Item.Cells[8].Text;
            LoadControls(PRNumber);

            if (e.CommandName == "btnApprove")
            {
                MultiView1.ActiveViewIndex = 1;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadControls(string PRNumber)
    {
        datatable = Process.GetMicroProcurementApprovals("0", PRNumber, "0", "0", "", "");
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

            txtRecBidder.Text = datatable.Rows[0]["BidderName"].ToString();
            txtFinalBidAmount.Text = datatable.Rows[0]["BidAmount"].ToString();
            txtBidComment.Text = datatable.Rows[0]["Comment"].ToString();
            lblStatusID.Text = datatable.Rows[0]["StatusID"].ToString();

            LoadDocuments();

            if (lblStatusID.Text == "94")
            {
                lblHead.Visible = false; txtHead.Visible = false;
                rbnApproval.Items.Clear();
                rbnApproval.Items.Add(new ListItem("Approve Procurement", "96"));
                rbnApproval.Items.Add(new ListItem("Not Approve Procurement", "95"));
            }
            else if (lblStatusID.Text == "96")
            {
                lblHead.Visible = false; txtHead.Visible = false;
                rbnApproval.Items.Clear();
                rbnApproval.Items.Add(new ListItem("Approve Procurement", "97"));
                rbnApproval.Items.Add(new ListItem("Reject  Procurement", "99"));

            }
            else if (lblStatusID.Text == "97") 
            {
                lblHead.Visible = false; txtHead.Visible = false;
                rbnApproval.Items.Clear();
                rbnApproval.Items.Add(new ListItem("Approve & Ratify Procurement", "98"));
                rbnApproval.Items.Add(new ListItem("Reject  Procurement", "99"));
            
            }
            
        }
        
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
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
        //doc.SetDatabaseLogon("sa", "Terrible");
        //doc.SetParameterValue("ReferenceNo", txtReferenceNo.Text);

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
    protected void cboProcurementOfficer_DataBound(object sender, EventArgs e)
    {
        cboProcurementOfficer.Items.Insert(0, new ListItem(" -- All Proc. Officers -- ", "0"));
    }
    private void LoadDocuments()
    {
        MultiView1.ActiveViewIndex = 1;
        string RefNo = txtReferenceNo.Text;
        datatable = Process.GetBiddingDocuments(RefNo, 2);
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
    }
    protected void GridAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnRemove")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridAttachments.DataKeys[intIndex].Value);
                //ConfirmRemoveDocument(FileCode);
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
        MultiView1.ActiveViewIndex = 0;
        LoadItems();
    }
    protected void btnSubmitToHOS_Click(object sender, EventArgs e)
    {
        try
        {
            long HOD = 0; string Comment;
            if (txtHead.Visible == true && txtHead.Text.Trim() == "")
                    ShowMessage("Please Enter Head of Department");
            else if (txtComment.Text.Trim() == "")
                ShowMessage("Please Enter Comment");
            else
            {
                long Approver = Convert.ToInt64(Session["UserID"].ToString());
                Comment = txtComment.Text.Trim();
                string StatusID = lblStatusID.Text;
                int NewStatusID = Convert.ToInt32(rbnApproval.SelectedValue);
                if (StatusID == "94")
                {
                    Process.HODMicroProcurementApproval(txtReferenceNo.Text, Approver, NewStatusID, Comment);
                }
                else if (StatusID == "96")
                    Process.CCChairmanMicroProcurementApproval(txtReferenceNo.Text, Approver, NewStatusID, Comment);
                
               // Process.LogandCommitBiddingDetails(txtReferenceNo.Text, NewStatusID, Comment);

               if (StatusID == "94")
                   ShowMessage("Micro Procurement " + txtReferenceNo.Text + " Has Been Successfully Submitted to Chairman Contracts Committee");
                else
                   ShowMessage("Micro Procurement " + txtReferenceNo.Text + " Has Been Successfully Approved");
                LoadItems(); MultiView1.ActiveViewIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void rbnApproval_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbnApproval.SelectedValue == "92" || rbnApproval.SelectedValue == "94")
        {
            lblHead.Visible = true; txtHead.Visible = true;
        }
        else
        {
            lblHead.Visible = false; txtHead.Visible = false;
        }
    }
    protected void btnPrintApproval_Click(object sender, EventArgs e)
    {
        try
        {
            LoadReport();
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
           // doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Micro Procurement Approval");
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadReport()
    {
        string appPath, physicalPath, rptName;
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);

        datatable = Process.GetReportForMicroProcurementApproval(txtReferenceNo.Text);
        rptName = physicalPath + "\\Bin\\Reports\\Bidding\\PD04Approvals.rpt";

        if (datatable.Rows.Count > 0)
        {
            //doc.Load(rptName);
            //doc.SetDataSource(datatable);
            Hidetoolbar();
            //CrystalReportViewer1.ReportSource = doc;
            //CrystalReportViewer1.Visible = true;
        }
        else
        {   ShowMessage("No Record(s) Found ...");
            //CrystalReportViewer1.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string PD_Code = lblPDCode.Text.Trim();
        DataTable dtable = ProcessReq.GetLogs(PD_Code);
        DataGrid2.DataSource = dtable;
        DataGrid2.DataBind();
        MultiView1.ActiveViewIndex = 3;
    }
    protected void Return_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
}
