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


public partial class NewEvaluationCommittee : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    DataTable dtable = new DataTable();
    DataTable dtUpdate = new DataTable();
    DataLogin data = new DataLogin();
    ProcessPlanning ProcessPlanning = new ProcessPlanning();
    int ProcMethod, ProcTypeCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AutoCompleteExtender1.ContextKey = "0";
            if (Request.QueryString["PR"] != null)
            {
                string PRNumber = Request.QueryString["PR"].ToString();
                LoadControls(PRNumber);
            }
            else
                Response.Redirect("Bidding_PendingProcurements.aspx?transferid=1", true);
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
    private void CreateECMembersDataTable()
    {
        DataTable dtMembers = new DataTable("Members");

        dtMembers.Columns.Add(new DataColumn("ECMemberID", typeof(long)));
        dtMembers.Columns.Add(new DataColumn("UserID", typeof(long)));
        dtMembers.Columns.Add(new DataColumn("ECMember", typeof(string)));
        dtMembers.Columns.Add(new DataColumn("Position", typeof(string)));
        dtMembers.Columns.Add(new DataColumn("Department", typeof(string)));
        dtMembers.Columns.Add(new DataColumn("ReasonID", typeof(int)));
        dtMembers.Columns.Add(new DataColumn("Reason", typeof(string)));
        dtMembers.Columns.Add(new DataColumn("OtherReason", typeof(string)));
        dtMembers.Rows.Clear();

        Session["dtMembers"] = dtMembers;
        dtUpdate = dtMembers;
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
            txtProcMethod.Text = dtable.Rows[0]["Method"].ToString();
            txtDateRequisitioned.Text = dtable.Rows[0]["CreationDate"].ToString();
            txtRequisitioner.Text = dtable.Rows[0]["Requisitioner"].ToString();
            txtDateRequired.Text = dtable.Rows[0]["DateRequired"].ToString();
            txtBudgetCostCenter.Text = dtable.Rows[0]["CostCenterName"].ToString();
            lblPDCode.Text = dtable.Rows[0]["PD_Code"].ToString();
            lblStatusID.Text = dtable.Rows[0]["StatusID"].ToString();
            ProcMethod = int.Parse(dtable.Rows[0]["ProcMethodCode"].ToString());
            ProcTypeCode = int.Parse(dtable.Rows[0]["ProcurementTypeCode"].ToString());
            lblprocmethod.Text = ProcMethod.ToString();
            lblproctype.Text = ProcTypeCode.ToString();
        
        }
        LoadECMembers(PRNumber);
        LoadECMemberReasons(1);
    }
    private void LoadECMemberReasons(int Type)
    {
        cboReason.DataSource = Process.GetBidderReasons(Type);
        cboReason.DataTextField = "Reason";
        cboReason.DataValueField = "ID";
        cboReason.DataBind();
    }
    private void LoadECMembers(string PRNumber)
    {
        CreateECMembersDataTable();
        dtable = Process.GetECMemberDetails(PRNumber);
        if (dtable.Rows.Count > 0)
        {
            string CreatedByID = "0";
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in dtable.Rows)
            {
                long ECMemberID = Convert.ToInt64(dr["ECMemberID"].ToString()); long UserID = Convert.ToInt64(dr["UserID"].ToString());
                string ECMember = dr["ECMember"].ToString(); string Position = dr["Position"].ToString(); string Department = dr["Department"].ToString();
                int ReasonID = Convert.ToInt32(dr["ReasonID"].ToString());
                string Reason = dr["Reason"].ToString(); string OtherReason = dr["OtherReason"].ToString(); CreatedByID = dr["CreatedByID"].ToString();
                dtUpdate.Rows.Add(new object[] { ECMemberID, UserID, ECMember, Position, Department, ReasonID, Reason, OtherReason });
            }
            Session["dtMembers"] = dtUpdate;
            DataGrid2.DataSource = dtable;
            DataGrid2.DataBind();
            int StatusID = Convert.ToInt32(lblStatusID.Text);
            if (StatusID > 30) 
                lblCreatedBy.Text = CreatedByID;
        }
        else
            btnPrint.Enabled = false;
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
    protected void btnAddMember_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage2(".");
            if (String.IsNullOrEmpty(txtMember.Text.Trim()))
                ShowMessage2("Please Select From the List of Members After Typing One or More Letters");
            else if (String.IsNullOrEmpty(txtPosition.Text.Trim()))
                ShowMessage2("Please Enter Position of Member");
            else if (String.IsNullOrEmpty(txtDepartment.Text.Trim()))
                ShowMessage2("Please Enter Department of Member");
            else if (cboReason.SelectedValue == "0")
                ShowMessage2("Please Select Reason For Selection Of Member");
            else if (cboReason.SelectedItem.ToString() == "Other" && String.IsNullOrEmpty(txtReason.Text.Trim()))
                ShowMessage2("Please Enter Other Reason For Selection of Member");
            else
            {
                string ECMember = txtMember.Text.Trim();
                string Position = txtPosition.Text.Trim().ToUpper();
                string Department = txtDepartment.Text.Trim().ToUpper();
                int ReasonID = Convert.ToInt32(cboReason.SelectedValue.ToString());
                string Reason = cboReason.SelectedItem.Text.Trim();
                string OtherReason = txtReason.Text.Trim().ToUpper();
                int UserID = 0;
                dtable = Process.GetProfileByName(ECMember);
                if (dtable.Rows.Count == 0)
                    throw new Exception("Please Enter Existing User OR Select from drop down returned after typing more than two letters");
                else
                    UserID = Convert.ToInt32(dtable.Rows[0]["ProfileID"].ToString());

                long ECMemberID = 0;
                dtUpdate = (DataTable)Session["dtMembers"];
                if (btnAddMember.Text.Contains("Update") && lblECMemberID.Text != "0")
                {
                    ECMemberID = Convert.ToInt64(lblECMemberID.Text.Trim());
                    int i = 0;
                    foreach (DataRow dr in dtUpdate.Rows)
                    {
                        if (Convert.ToInt64(dr["ECMemberID"]) == ECMemberID)
                        {
                            dtUpdate.Rows.RemoveAt(i);
                            break;
                        }
                        i++;
                    }
                }

                dtUpdate.Rows.Add(new object[] { ECMemberID, UserID, ECMember, Position, Department, ReasonID, Reason, OtherReason });
                ClearItemControls();

                ShowMessage2("EC Member Has Been Successfully Added");

                Session["dtMembers"] = dtUpdate;
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
        txtMember.Text = ""; txtReason.Text = ""; btnAddMember.Text = "Add Member"; txtDepartment.Text = "";
        txtPosition.Text = ""; cboReason.SelectedValue = "0"; txtMember.Text = ""; txtReason.Visible = false;
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
            string ReportName = "ECMembers40";
            string ReferenceNo = txtPRNumber.Text;
            dtable = Process.GetReportForECMembers(ReferenceNo);
            int rowcount = dtable.Rows.Count;

            if (rowcount != 0)
            {
                loadreport(ReportName);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "EC Members");
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
        string ECMemberID = e.Item.Cells[0].Text.Trim(); string UserID = e.Item.Cells[1].Text.Trim();
        string ECMember = e.Item.Cells[2].Text; string Position = e.Item.Cells[3].Text;
        string Department = e.Item.Cells[4].Text; 
        string ReasonID = e.Item.Cells[5].Text; string OtherReason = e.Item.Cells[7].Text;
        int ItemRowIndex = e.Item.DataSetIndex; dtUpdate = (DataTable)Session["dtMembers"];
        if (e.CommandName == "btnEdit")
        {
            if (ECMemberID == "0")
            {
                dtUpdate.Rows.RemoveAt(ItemRowIndex);
            }
            LoadECControls(ECMemberID, UserID, ECMember, Position, Department, ReasonID, OtherReason);
            DataGrid2.DataSource = dtUpdate.DefaultView;
            DataGrid2.DataBind();
        }
        else if (e.CommandName == "btnRemove")
        {
            if (ECMemberID == "0")
            {
                dtUpdate.Rows.RemoveAt(ItemRowIndex);
            }
            else
            {
                long ECUserID = Convert.ToInt64(ECMemberID);
                Process.FlagPotentialECMember(ECUserID, true);
            }
            ShowMessage2(ECMember + " Has Been Successfully Removed");
            LoadControls(txtPRNumber.Text.Trim());
        }
    }
    private void LoadECControls(string ECMemberID, string UserID, string ECMember, string Position, string Department, string ReasonID, string OtherReason)
    {
        lblECMemberID.Text = ECMemberID; txtMember.Text = ECMember; cboReason.SelectedValue = ReasonID;
        txtPosition.Text = Position; txtDepartment.Text = Department; txtReason.Text = OtherReason;
        if (cboReason.SelectedItem.Text.Trim() == "Other")
            txtReason.Visible = true;
        btnAddMember.Text = "Update EC Member";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        dtUpdate = (DataTable)Session["dtMembers"];
        ShowMessage2("."); ShowMessage(".");
        if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add EC Members Before Submission");
            ShowMessage2("Please Add EC Members Before Submission");
        }
        else
        {
            Session["dtMembers"] = dtUpdate;
            DataTable dtMembers = (DataTable)Session["dtMembers"];
            int StatusID = Convert.ToInt32(lblStatusID.Text); string CreatedBy;
            if (StatusID > 40 && Process.GetECMemberDetails(txtPRNumber.Text).Rows.Count > 0)
                CreatedBy = lblCreatedBy.Text;
            else
                CreatedBy = Session["UserID"].ToString();
            string Response = Process.SaveEvaluationCommitteeMembers(txtPRNumber.Text.Trim(), dtMembers, CreatedBy, int.Parse(lblprocmethod.Text.Trim()), int.Parse(lblproctype.Text.Trim()) );
            // Email Proc. Officer if Procurement Supervisor Editing EC Members
            if (StatusID > 40)
            {
                string ReferenceNo = txtPRNumber.Text;
                string PDUSupervisor = HttpContext.Current.Session["FullName"].ToString();
                DataTable dtAlert = Process.GetBiddingDetailsForNotification(ReferenceNo);
                string Subject = "Procurement Supervisor Edited EC Members For " + dtAlert.Rows[0]["Subject"].ToString();
                string OfficerID = dtAlert.Rows[0]["POID"].ToString(); string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
                string CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();

                /// Notify Procurement Officer
                string Message = "<p>Evaluation Committee Members for Procurement ( " + ReferenceNo + " ) from " + CostCenterName + " has been edited by Procurement Supervisor " + PDUSupervisor + " </p>";
                Message += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

                ProcessReq.NotifyOfficer(PDUSupervisor, Subject, OfficerID, Message);
            }
            lblDone.Text = Response;
            MultiView1.ActiveViewIndex = 1;
        }
    }
    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        string PreviousPage = Session["PreviousPage"].ToString();
        Session["PreviousPage"] = "Bidding_NewEvaluationCommittee.aspx";
        Session["PRNumber"] = txtPRNumber.Text;
        Response.Redirect(PreviousPage + "?transferid=1", true);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string PreviousPage = Session["PreviousPage"].ToString();
        Session["PreviousPage"] = "Bidding_NewEvaluationCommittee.aspx";
        Session["PRNumber"] = txtPRNumber.Text;
        if (PreviousPage.Equals("Bidding_ECSubmission.aspx"))
        {
            Response.Redirect(PreviousPage, true);
        }
        else
        {
            Response.Redirect(PreviousPage + "?transferid=1", true);
        }
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
}
