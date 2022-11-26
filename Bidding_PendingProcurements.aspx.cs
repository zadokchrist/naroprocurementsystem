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
    BusinessPlanning bll2 = new BusinessPlanning();
    private string Status = "36";
    DataTable dtUpdate = new DataTable();
    DataTable datatableitems = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {

                LoadAreas(); LoadProcMethod();
                lblBidderId.Text = "0";
                Details.ActiveViewIndex = -1;
                if (Request.QueryString["transferid"] != null)
                {
                    //txtPrNumber.Text = Session["PRNumber"].ToString();
                    cboProcMethod.SelectedIndex = cboProcMethod.Items.IndexOf(cboProcMethod.Items.FindByValue(Session["ProcMethod"].ToString()));
                    cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue(Session["Area"].ToString()));
                    cboCostCenters.SelectedIndex = cboCostCenters.Items.IndexOf(cboCostCenters.Items.FindByValue(Session["CostCenter"].ToString()));
                    if (Session["PreviousStatus"] != null)
                    {

                        Status = Session["PreviousStatus"].ToString();
                        LoadItems();
           

                    }
                    else
                    {
                        // ShowMessage("Nullllll");
                        LoadItems();
                    }
                }
                MultiView1.ActiveViewIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void GetPreviousSelectedValues()
    {
        Session["PreviousPage"] = "Bidding_PendingProcurements.aspx";
        Session["PRNumber"] = txtPrNumber.Text.Trim();
        Session["ProcMethod"] = cboProcMethod.SelectedValue;
        Session["Area"] = cboAreas.SelectedValue; Session["CostCenter"] = cboCostCenters.SelectedValue;
    }

    private void LoadFundingSource()
    {
        cboFunding.DataSource = ProcessPlan.GetFundSources();
        cboFunding.DataValueField = "Code";
        cboFunding.DataTextField = "Source";
        cboFunding.DataBind();
    }
    private void LoadAreas()
    {
        datatable = data.GetAreas();
        cboAreas.DataSource = datatable;
        cboAreas.DataValueField = "AreaID";
        cboAreas.DataTextField = "Area";
        cboAreas.DataBind();

        if (Session["IsAreaProcess"].ToString() == "1")
        {
            cboAreas.SelectedValue = Session["AreaCode"].ToString();
            int AreaID = Convert.ToInt32(cboAreas.SelectedValue);
            LoadCostCenters(AreaID);
            cboAreas.Enabled = false;
            //cbostatus.Items.RemoveAt(2);
        }
        else
        {
            cboAreas.Enabled = true;
            LoadCostCenters(cboAreas.SelectedIndex);
        }
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
    private void LoadProcMethod()
    {
        datatable = ProcessPlan.GetProcurementMethods();
        cboProcMethod.DataSource = datatable;
        cboProcMethod.DataValueField = "MethodCode";
        cboProcMethod.DataTextField = "Method";
        cboProcMethod.DataBind();

        DropDownList1.DataSource = datatable;
        DropDownList1.DataValueField = "MethodCode";
        DropDownList1.DataTextField = "Method";
        DropDownList1.DataBind();
    }
    private void LoadItems()
    {
        string RecordID = "0"; string PrNumber = txtPrNumber.Text.Trim();
        string ProcMethod = cboProcMethod.SelectedValue.ToString(); string ProcOfficer = Session["UserID"].ToString(); //cboProcurementOfficer.SelectedValue.ToString();
        string CostCenterCode = cboCostCenters.SelectedValue.ToString(); string AreaCode = cboAreas.SelectedValue.ToString();
        Status = cbostatus.SelectedValue.ToString();
        datatable = Process.GetAssignedProcurements(RecordID, PrNumber, ProcMethod, ProcOfficer, Status, AreaCode, CostCenterCode);
        if (datatable.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 0;
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind(); DataGrid1.Visible = true;
            lblEmpty.Text = ".";
        }
        else
        {
            DataGrid1.Visible = false;
            string EmptyMessage = "No " + cbostatus.SelectedItem + " in the System from Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
            lblEmpty.Text = EmptyMessage;
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
    public bool DisableLinkBidders(object dataItem)
    {

        //if ((DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "5") || (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "13") || (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "6") || (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "2"))
        //    return false;
        //else 
        
        if (DataBinder.Eval(dataItem, "StatusID").ToString() == "45")
            return true;

        else
            return false;
    }
    public bool DisableLinkEC(object dataItem)
    {

        if ((DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "1") || (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "11"))
            return false;
        else if ((DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "5") || (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "13") || (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "6") || (DataBinder.Eval(dataItem, "ProcMethodCode").ToString() == "2"))
            return false;
        else if (DataBinder.Eval(dataItem, "StatusID").ToString() == "46")
            return false;
        else
            return true;
    }
    public bool DisableViewComment(object dataItem)
    {


        if ((DataBinder.Eval(dataItem, "StatusID").ToString() == "42") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "46") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "47"))
            return true;
        else
            return false;
    }
    public bool DisableForm(object dataItem)
    {


        if ((DataBinder.Eval(dataItem, "StatusID").ToString() == "50") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "52") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "53") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "54") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "58") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "65") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "74"))
            return true;
        else
            return false;
    }



    public bool DisableEval(object dataItem)
    {


        if ((DataBinder.Eval(dataItem, "StatusID").ToString() == "53") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "54") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "58") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "65") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "74"))
            return true;
        else
            return false;
    }

    public bool DisableEOI(object dataItem)
    {


        if ((DataBinder.Eval(dataItem, "StatusID").ToString() == "36")  || (DataBinder.Eval(dataItem, "StatusID").ToString() == "37") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "28"))
            return true;
        else
            return false;
    }

    public bool DisableRFP(object dataItem)
    {


        if ((DataBinder.Eval(dataItem, "StatusID").ToString() == "48") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "28") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "44"))
            return true;
        else
            return false;
    }

    public bool DisableContract(object dataItem)
    {


        if ((DataBinder.Eval(dataItem, "StatusID").ToString() == "69") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "61") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "77") || (DataBinder.Eval(dataItem, "StatusID").ToString() == "76"))
            return true;
        else
            return false;
    }

    public bool EnableTextbox(object dataItem)
    {

        if ((DataBinder.Eval(dataItem, "Code").ToString() == "G2") || (DataBinder.Eval(dataItem, "Code").ToString() == "G4") || (DataBinder.Eval(dataItem, "Code").ToString() == "H2") || (DataBinder.Eval(dataItem, "Code").ToString() == "H4"))
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
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            string RecordID = e.Item.Cells[0].Text;
            string PRNumber = e.Item.Cells[2].Text;
            string Subject = e.Item.Cells[3].Text;
            int ProcMethodCode = Convert.ToInt32(e.Item.Cells[5].Text);
            string previousStatus = e.Item.Cells[8].Text;
            string RemarkComment = e.Item.Cells[9].Text;
            string RemarkCreationDate = e.Item.Cells[10].Text;
            lblReferenceNo.Text = e.Item.Cells[2].Text;
            string HasVat = e.Item.Cells[16].Text;
            ProcMethodCode = ReturnProcMethod(ProcMethodCode);
            string Form = Process.GetForm(ProcMethodCode);
            

            lblAttachRefNo.Text = PRNumber;
            LoadFundingSource();
            LoadPDUSupervisors();
            LoadProcMethod();
            Details.ActiveViewIndex = 0;
            DataTable dtData = ProcessReq.GetRequisitionDetailsByPRNo(PRNumber);
            int count = dtData.Rows.Count;
            if (count == 0)
            {
                ShowMessage("No records returned for provided PR Number....");
            }
            else
            {
                // Load PR Details.

                txtProcDescription.Text = dtData.Rows[0]["Subject"].ToString();
                TextBox2.Text = Convert.ToDouble(dtData.Rows[0]["RequisitionedAmount"].ToString()).ToString("#,##0");
                lblPD_Code.Text = dtData.Rows[0]["PD_Code"].ToString();
                DropDownList1.SelectedValue = dtData.Rows[0]["ProcurementMethod"].ToString();
                cboFunding.SelectedValue = dtData.Rows[0]["FundingSource"].ToString();
                txtDateAssigned.Text = dtData.Rows[0]["AssignedDate"].ToString().Replace("Jul  1 2011 ", "");
                txtPreparationDate.Text = dtData.Rows[0]["DatePrepared"].ToString();
                txtStart.Text = dtData.Rows[0]["AssignedDate"].ToString();
                txtBidStartDate.Text = dtData.Rows[0]["BidInvitationDate"].ToString();
                txtBidEndDate.Text = dtData.Rows[0]["BidSubmissionDate"].ToString();
                Session["officerId"] = int.Parse(dtData.Rows[0]["ResponsibleOfficer"].ToString());
                Session["createdby"] = int.Parse(dtData.Rows[0]["CreatedBy"].ToString());
                Session["StatusID"] = int.Parse(dtData.Rows[0]["StatusID"].ToString());
                // Cummulative Period - Based on File Closure Date ( Now/File Closure Date - Date Assigned) - + Contract Signing Date
                txtCummulativePeriod.Text = dtData.Rows[0]["CumulativePeriod"].ToString();
                TextBox1.Text = PRNumber;
                lblreqn.Text = dtData.Rows[0]["PD_Code"].ToString();
                

                double amount = Convert.ToDouble(TextBox2.Text);
                string SelectedType = dtData.Rows[0]["ProcurementTypeID"].ToString();

                LoadProcMethod(amount, SelectedType);

                // If schedule for PR Exists...
                if (bll.ScheduleExists(PRNumber))
                {
                    DataTable dtHead = ProcessReq.GetActivitySchedule(PRNumber);
                    DataTable dtPlans = ProcessReq.GetActivityScheduleDetails(PRNumber);

                    // LoadActivityScheduleControls(dtHead, dtPlans);

                    string PDUHead = dtHead.Rows[0]["PDUHead"].ToString();
                    // if(Session["Acc"])

                    // cboPreparedBy.SelectedValue = PreparedBy;
                    //  cboResponsibleOfficer.SelectedValue = ResponsibleOfficer;
                    txtPreparationDate.Text = dtHead.Rows[0]["DatePrepared"].ToString().Replace("Jul  1 2011 ", "");
                    // For Old AS
                    txtPreparationDate.Text = txtPreparationDate.Text.Trim().Replace("Jul  1 2011 ", "");
                    // cboPDUHead.SelectedValue = PDUHead;
                    cboCompany.SelectedValue = dtHead.Rows[0]["PDUCategory"].ToString();

                }

            }


            if (e.CommandName == "btnView")
            {
                GetPreviousSelectedValues();
                Response.Redirect("Bidding_ViewRequisition.aspx?transferid=" + RecordID, true);
            }
            else if (e.CommandName == "btnEOI")
            {
                MultiView1.ActiveViewIndex = 9;
                LoadEOIDocuments();
                //GetPreviousSelectedValues();
                //Session["PreviousStatus"] = previousStatus;
                //Response.Redirect("Bidding_ShortlistBidders.aspx?PR=" + PRNumber, true);
            }
            else if (e.CommandName == "btnRFP")
            {
                MultiView1.ActiveViewIndex = 10;
                LoadRFPDocuments();
            }
            else if (e.CommandName == "btnContract")
            {
                MultiView1.ActiveViewIndex = 12;
                LoadDraftContract();
            }
            else if (e.CommandName == "btnPrepare")
            {
                try
                {

                    if (!this.IsValidPRNumber(PRNumber))
                    {
                        ShowMessage("Please provide the PR Number (Valid).....");
                    }
                    else
                    {
                        LoadBidDocuments();
                    }

                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                }

            }
            else if (e.CommandName == "btnFillForm")
            {
                chkIsVat.Checked = Convert.ToBoolean(HasVat);
                IsVat1.Checked = Convert.ToBoolean(HasVat);
                if (ProcMethodCode.Equals(11))
                {
                    lblHeading.Text = Subject + " - [" + Form + "]";
                    ClearMicroProcurementControls();
                    lblReferenceNo.Text = PRNumber;
                    LoadMicroProcurementDetails(PRNumber);
                    LoadProcurementMethods1();
                    MultiView1.ActiveViewIndex = 3;
                }
                else
                {

                    lblHeading.Text = Subject + " - [" + Form + "]";
                    lblProcMethod.Text = ProcMethodCode.ToString();
                    lblRefNo.Text = PRNumber;
                    LoadControls(PRNumber);
                    datatable = Process.GetSections4Questions(ProcMethodCode, 1);

                    if (txtProcType.Text.Equals("CONSULTATIONAL SERVICES"))
                    {

                        datatable = Process.GetSections4Questions2(ProcMethodCode, 1, 2);
                    }
                    else
                    {

                        datatable = Process.GetSections4Questions2(ProcMethodCode, 1, 1);

                    }

                    if (datatable.Rows.Count > 0)
                    {
                        //datatable.DefaultView.Sort = "Code asc";
                        cboDashboard.DataSource = datatable;

                        cboDashboard.DataTextField = "Narration";
                        cboDashboard.DataValueField = "Section";
                        cboDashboard.DataBind();
                    }


                    MultiView1.ActiveViewIndex = 2;
                }
                LoadProcurementMethods();
                cboProcurementMethod.SelectedValue = ProcMethodCode.ToString();
                cboProcMethod1.SelectedValue = ProcMethodCode.ToString();
            }
            else if (e.CommandName == "btnProposeEC")
            {
                Session["PreviousStatus"] = previousStatus;
                GetPreviousSelectedValues();
                Response.Redirect("Bidding_NewEvaluationCommittee.aspx?PR=" + PRNumber, true);
            }
            else if (e.CommandName == "btnAddBiddingDoc")
            {
                MultiView1.ActiveViewIndex = 5;
                lblAttachRefNo.Text = PRNumber;
                lblHeaderMsg.Text = Subject;
                //LoadDocuments();

                //Confirm Start of Bid Opening session and send email to bidders to log on 

                datatable = Process.GetShortlistedBidderDetails(PRNumber);
                if (datatable.Rows.Count > 0)
                {
                    DataGrid5.DataSource = datatable;
                    DataGrid5.DataBind();
                }

            }
            else if (e.CommandName == "btnEvaluation")//Evaluation
            {
                string status = Session["StatusID"].ToString();
                if (status == "54")
                {
                    MultiView1.ActiveViewIndex = 10;
                    Details.ActiveViewIndex = 0;
                    LoadTechEvalDocs();

                }
                else if (status == "53" || status == "58")
                {

                    string RefNo = lblReferenceNo.Text.Trim();

                    datatable = Process.GetBidderEvaluations(RefNo);
                    if (datatable.Rows.Count > 0)
                    {
                        dgvEval.DataSource = datatable;
                        dgvEval.DataBind();
                    }
                    else
                    {
                        ShowMessage("No Evaluations found");
                    }

                    datatable = Process.GetShortlistedBidderDetails(RefNo);
                    if (datatable.Rows.Count > 0)
                    {
                        ddlBEB.DataSource = datatable;
                        ddlBEB.DataValueField = "bidderId";
                        ddlBEB.DataTextField = "BidderName";
                        ddlBEB.DataBind();
                        ddlBEB.Items.Insert(0, new ListItem("-- Select BEB --", "0"));
                    }
                    else
                    {
                        ShowMessage("No bidder found");
                    }
                    LoadDocuments2();
                    MultiView1.ActiveViewIndex = 7;

                }
            }
            }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }


    private bool IsValidPRNumber(string PRNumber)
    {
        bool valid = true;
        if ((PRNumber == "") || (PRNumber.Length < 2))
            valid = false;

        return valid;
    }

    private void LoadProcMethod(double amount, string ProcTypeSelected)
    {
        int ProcType = Convert.ToInt32(ProcTypeSelected);
        if (bll2.isSpecificMethod(ProcType, amount))
        {
            //cboProcurementMethod.Items.Clear();
            //dtable = ProcessOther.GetProcurementMethods();
            //cboProcurementMethod.DataSource = dtable;
            //cboProcurementMethod.DataValueField = "MethodCode";
            //cboProcurementMethod.DataTextField = "Method";
            //cboProcurementMethod.DataBind();
            string ProcMethod = ProcessPlan.GetProcurementMethod(ProcTypeSelected, amount).ToString();
            cboProcurementMethod.SelectedIndex = cboProcurementMethod.Items.IndexOf(cboProcurementMethod.Items.FindByValue(ProcMethod));
            cboProcurementMethod.Enabled = true;
            //LoadProcLength(ProcMethod);
        }
        else
        {
            cboProcurementMethod.Items.Clear();
            cboProcurementMethod.Enabled = true;
            datatable = ProcessPlan.GetProcMethodsForBig(ProcType, amount);
            cboProcurementMethod.DataSource = datatable;
            cboProcurementMethod.DataValueField = "MethodCode";
            cboProcurementMethod.DataTextField = "Method";
            cboProcurementMethod.DataBind();
            cboProcurementMethod.SelectedIndex = cboProcurementMethod.Items.IndexOf(cboProcurementMethod.Items.FindByValue("0"));

        }

    }

    protected void btnSaveFile_Click(object sender, EventArgs e)
    {
        try
        {
            //ShowMessage(".");
            //string RefNo = lblAttachRefNo.Text.Trim();
            //UploadFiles2(RefNo);
            //LoadDocuments();
            if (txtBidAmount.Text == "")
            {
                ShowMessage("Enter bid amount");
            }
            else if (txtDiscount.Text == "")
            {
                ShowMessage("Enter discount");
            }
            else if (txtBidderRemark.Text == "")
            {
                ShowMessage("Enter remark");
            }
            else if (lblSelectedBidder.Text == ".")
            {
                ShowMessage("Select a bidder");
            }
            else
            {
                string prnumber = lblReferenceNo.Text.Trim();
                string bidder = lblBidderId.Text.Trim();
                string amount = txtBidAmount.Text;
                string remark = txtBidderRemark.Text;
                string discount = txtDiscount.Text.Trim();
                Process.SaveEditBidOpeningDetail(prnumber, bidder,amount,discount, remark);
                ShowMessage("Evaluation details saved");
                lblBidderId.Text = ".";
                lblSelectedBidder.Text = ".";
                GridAttachments.DataSource = null;
                txtBidAmount.Text = "";
                txtBidderRemark.Text = "";
                txtDiscount.Text = "";


            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void UploadFiles2(string ReferenceNo)
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
                File1.PostedFile.SaveAs(Path + "" + c1);
                Process.SaveBiddingDocument(ReferenceNo, (Path + "" + c1), c, 5);
                LoadDocuments2();
            }
        }
    }

    private void LoadDocuments2()
    {
        MultiView1.ActiveViewIndex = 7;
        string RefNo = lblAttachRefNo.Text.Trim();
        datatable = Process.GetBiddingDocuments2(RefNo, 6);
        if (datatable.Rows.Count > 0)
        {
            GridView1.DataSource = datatable;
            GridView1.DataBind();
            GridView1.Visible = true;
            Label2.Visible = false;
        }
        else
        {
            Label2.Visible = true;
            GridView1.Visible = false;
        }
    }

    private void LoadEOIDocuments()
    {
        // MultiView1.ActiveViewIndex = 7;
        string RefNo = lblAttachRefNo.Text.Trim();
        datatable = Process.GetBiddingDocuments2(RefNo, 1009);
        if (datatable.Rows.Count > 0)
        {
            GridView4.DataSource = datatable;
            GridView4.DataBind();
            GridView4.Visible = true;
            Label12.Visible = false;
        }
        else
        {
            Label12.Visible = true;
            GridView4.Visible = false;
        }
    }

    private void LoadRFPDocuments()
    {
        // MultiView1.ActiveViewIndex = 7;
        string RefNo = lblAttachRefNo.Text.Trim();
        datatable = Process.GetBiddingDocuments2(RefNo, 10);
        if (datatable.Rows.Count > 0)
        {
            GridView5.DataSource = datatable;
            GridView5.DataBind();
            GridView5.Visible = true;
            Label14.Visible = false;
        }
        else
        {
            Label14.Visible = true;
            GridView5.Visible = false;
        }
    }

    private void LoadDraftContract()
    {
        // MultiView1.ActiveViewIndex = 7;
        string RefNo = lblAttachRefNo.Text.Trim();
        datatable = Process.GetBiddingDocuments2(RefNo, 1010);
        if (datatable.Rows.Count > 0)
        {
            GridView7.DataSource = datatable;
            GridView7.DataBind();
            GridView7.Visible = true;
            Label20.Visible = false;
        }
        else
        {
            Label20.Visible = true;
            GridView7.Visible = false;
        }
    }

    private void LoadEvalDocs()
    {
        // MultiView1.ActiveViewIndex = 7;
        string RefNo = lblAttachRefNo.Text.Trim();
        datatable = Process.GetBiddingDocuments2(RefNo, 6);
        if (datatable.Rows.Count > 0)
        {
            GridView1.DataSource = datatable;
            GridView1.DataBind();
            GridView1.Visible = true;
            Label2.Visible = false;
        }
        else
        {
            Label2.Visible = true;
            GridView1.Visible = false;
        }
    }

    private void LoadTechEvalDocs()
    {
        // MultiView1.ActiveViewIndex = 7;
        string RefNo = lblAttachRefNo.Text.Trim();
        datatable = Process.GetBiddingDocuments2(RefNo, 7);
        if (datatable.Rows.Count > 0)
        {
            GridView6.DataSource = datatable;
            GridView6.DataBind();
            GridView6.Visible = true;
            Label17.Visible = false;
        }
        else
        {
            Label17.Visible = true;
            GridView6.Visible = false;
        }
    }

    private void LoadBidDocuments()
    {
       // MultiView1.ActiveViewIndex = 7;
        string RefNo = lblAttachRefNo.Text.Trim();
        datatable = Process.GetBiddingDocuments2(RefNo, 8);
        if (datatable.Rows.Count > 0)
        {
            //GridView2.DataSource = datatable;
            //GridView2.DataBind();
            //GridView2.Visible = true;
            //Label6.Visible = false;
        }
        else
        {
            //Label6.Visible = true;
            //GridView2.Visible = false;
        }
    }
    private void LoadAnsweredFormGrid(DataTable dt4)
    {
        dgvFormDetails.DataSource = dt4;
        dgvFormDetails.DataBind();
    }
    protected void cboProcurementMethod_DataBound(object sender, EventArgs e)
    {
        cboProcurementMethod.Items.Insert(0, new ListItem("-- Select Procurement Method --", "0"));
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
            lblPDCode.Text = datatable.Rows[0]["PD_Code"].ToString();
        }
        DataGrid3.Visible = false;
        // btnPrint.Enabled = true;
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            if (cbostatus.SelectedValue.Equals("0"))
            {
                ShowMessage("Please Select a Status...");
            }
            else
            {

                if (cbostatus.SelectedIndex.ToString().Equals("1"))
                {
                  //  lblTitle.Text = "Assigned Procurements PENDING SUBMISSION ";
                    Status = cbostatus.SelectedValue.ToString();
                }
                else if (cbostatus.SelectedIndex.ToString().Equals("2"))
                {
                  //  lblTitle.Text = "Procurement Proc Method approved by Procurement manager";
                    Status = cbostatus.SelectedValue.ToString();
                }
                else if (cbostatus.SelectedIndex.ToString().Equals("3"))
                {
                //    lblTitle.Text = "Procurements for Bid Opening";
                    Status = cbostatus.SelectedValue.ToString();
                }
                else if (cbostatus.SelectedIndex.ToString().Equals("4"))
                {
                 //   lblTitle.Text = "Procurement Proc Method/Bid Docs DEFERRED BY CONTRACTS COMMITTEE";
                    Status = cbostatus.SelectedValue.ToString();
                }

                ShowMessage(".");
                LoadItems();
            }

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
        int AreaID = Convert.ToInt32(cboAreas.SelectedValue);
        LoadCostCenters(AreaID);
    }
    protected void cboAreas_DataBound1(object sender, EventArgs e)
    {
        cboAreas.Items.Insert(0, new ListItem(" -- All Areas -- ", "0"));
    }
    protected void cboDashboard_DataBound(object sender, EventArgs e)
    {
        cboDashboard.Items.Insert(0, new ListItem(" -- Select a Section -- ", "0"));
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int QuestionID; string Answer; string ReferenceNo = lblRefNo.Text.Trim();
            int UserID = Convert.ToInt32(Session["UserID"].ToString());

            foreach (DataGridItem Record in DataGrid3.Items)
            {

                QuestionID = Convert.ToInt32(Record.Cells[0].Text);
                TextBox txtAnswer = ((TextBox)(Record.FindControl("txtAnswer")));
                Answer = txtAnswer.Text.Trim();
                if ((Record.ItemIndex == 0) && (chkIsVat.Checked == true))
                {

                    Double cost = Convert.ToDouble(txtEstimatedCost.Text.ToString());
                    Answer = Answer + "  and has final total of " + ((0.18 * cost) + cost).ToString() + " Vat Inclusive";

                }

                Process.SaveEditQuestions(ReferenceNo, QuestionID, Answer, UserID);
            }
            ShowMessage("Form Section Has Been Successfully Saved...");
            btnPrint.Enabled = true;
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboDashboard_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cboDashboard.SelectedValue == "0")
                btnPrint.Enabled = false;
            else
                btnPrint.Enabled = true;

            string Section = cboDashboard.SelectedValue.ToString();
            string ReferenceNo = lblRefNo.Text;
            int ProcMethod = Convert.ToInt32(lblProcMethod.Text);
            ProcMethod = ReturnProcMethod(ProcMethod);
            DataTable dt1 = new DataTable();
            datatable = Process.GetSectionAnswers(Section, ReferenceNo);
            int rowno = datatable.Rows.Count;
            if (datatable.Rows.Count < 3 && datatable.Rows.Count > 0)
            {


                dt1 = Process.GetSectionQuestions(ProcMethod, Section);
                if (Section == "G" || Section == "H")
                {
                    if (datatable.Rows[0]["Code"].ToString().Equals("G2") || datatable.Rows[0]["Code"].ToString().Equals("H2"))
                    {
                        dt1.Rows[1]["Id"] = datatable.Rows[0]["Id"];
                        dt1.Rows[1]["Code"] = datatable.Rows[0]["Code"];
                        dt1.Rows[1]["Question"] = datatable.Rows[0]["Question"];
                        dt1.Rows[1]["Answer"] = datatable.Rows[0]["Answer"];
                    }
                    else
                    {
                        DataRow[] result = new DataRow[] { };
                        if (Section == "G")
                        {
                            result = datatable.Select("Code = 'G2'");
                        }
                        else if (Section == "H")
                        {
                            result = datatable.Select("Code = 'H2'");
                        }

                        if (result.Length > 0)
                        {
                            dt1.Rows[1]["Id"] = result[0]["Id"];
                            dt1.Rows[1]["Code"] = result[0]["Code"];
                            dt1.Rows[1]["Question"] = result[0]["Question"];
                            dt1.Rows[1]["Answer"] = result[0]["Answer"];
                        }

                    }
                    if (datatable.Rows[0]["Code"].ToString().Equals("G4") || datatable.Rows[0]["Code"].ToString().Equals("H4"))
                    {

                        dt1.Rows[3]["Id"] = datatable.Rows[0]["Id"];
                        dt1.Rows[3]["Code"] = datatable.Rows[0]["Code"];
                        dt1.Rows[3]["Question"] = datatable.Rows[0]["Question"];
                        dt1.Rows[3]["Answer"] = datatable.Rows[0]["Answer"];
                    }
                    else
                    {

                        DataRow[] result = new DataRow[] { };
                        if (Section == "G")
                        {
                            result = datatable.Select("Code = 'G4'");
                        }
                        else if (Section == "H")
                        {
                            result = datatable.Select("Code = 'H4'");
                        }


                        if (result.Length > 0)
                        {
                            dt1.Rows[3]["Id"] = result[0]["Id"];
                            dt1.Rows[3]["Code"] = result[0]["Code"];
                            dt1.Rows[3]["Question"] = result[0]["Question"];
                            dt1.Rows[3]["Answer"] = result[0]["Answer"];
                        }
                    }
                    dt1.Rows[0]["Answer"] = txtProcMethod.Text + " is Within threshold";
                    datatable = dt1;
                }
                datatable.DefaultView.Sort = "Code asc";

                DataGrid3.DataSource = datatable;
                DataGrid3.DataBind();
                DataGrid3.Visible = true;
                btnPrint.Enabled = true;
            }
            else if (datatable.Rows.Count > 2)
            {
                //datatable.Rows[0]["Answer"] = txtProcMethod.Text;
                datatable.DefaultView.Sort = "Code asc";
                DataGrid3.DataSource = datatable;
                DataGrid3.DataBind();
                DataGrid3.Visible = true;
                btnPrint.Enabled = true;


            }
            else
            {
                datatable = Process.GetSectionQuestions(ProcMethod, Section);
                if (Section == "G" || Section == "H")
                {
                    datatable.Rows[0]["Answer"] = txtProcMethod.Text;
                    datatable.Rows[1]["Answer"] = " ";
                    datatable.Rows[2]["Answer"] = " ";
                    datatable.Rows[3]["Answer"] = " ";
                    datatable.Rows[4]["Answer"] = " ";
                    datatable.Rows[5]["Answer"] = " ";
                }
                datatable.DefaultView.Sort = "Code asc";
                DataGrid3.DataSource = datatable;
                DataGrid3.DataBind();
                DataGrid3.Visible = true;
                btnPrint.Enabled = false;
            }



        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

        try
        {

            if (cboDashboard.SelectedValue.ToString().Equals("G"))
            {


                int AreaId = int.Parse(Session["AreaCode"].ToString());
                string refno = lblRefNo.Text.Trim();
                MultiView1.ActiveViewIndex = 4;
                loadreports("Form5", refno, "G", AreaId);
            }
            else if (cboDashboard.SelectedValue.ToString().Equals("H"))
            {

                int AreaId = int.Parse(Session["AreaCode"].ToString());
                string refno = lblRefNo.Text.Trim();
                MultiView1.ActiveViewIndex = 4;
                loadreports("Form18", refno, "H", AreaId);
            }
            else
            {

                string ReferenceNo = lblRefNo.Text.Trim();
                int ProcMethod = Convert.ToInt32(lblProcMethod.Text.Trim());
                datatable = Process.GetFormNumberByProcMethod(ProcMethod, 1);

                string FormNumber = datatable.Rows[0]["FormNumber"].ToString();
                string Section = cboDashboard.SelectedValue.ToString();
                int NewProcMethod = ReturnProcMethod(ProcMethod);
                string ReportName = Process.GetReportName(NewProcMethod, FormNumber, Section, true);

                datatable = Process.GetForm1ForReport(ReferenceNo, FormNumber, Section);
                int rowcount = datatable.Rows.Count;

                if (rowcount != 0)
                {
                    MultiView1.ActiveViewIndex = 4;
                    btnPrint.Enabled = true;
                    loadreport(ReportName);


                }
                else
                    ShowMessage("No Data To Load For Report Form Selected ...");
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

    public void loadreports(string ReportName, string refno, string section, int AreaId)
    {
        DataTable dtFormDetails = new DataTable();
        DataTable dtSectionAnswers = new DataTable();

        dtFormDetails = Process.GetFormDetails(refno, AreaId);

        dtSectionAnswers = Process.GetSectionAnswers(section, refno);


        string appPath, physicalPath, rptName;
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        rptName = physicalPath + "\\Bin\\Reports\\Bidding\\newreports\\" + ReportName + ".rpt";
        //doc.Load(rptName);
        //doc.Database.Tables[0].SetDataSource(dtFormDetails);
        //doc.Database.Tables[1].SetDataSource(dtSectionAnswers);
        //doc.Subreports[0].SetDataSource(dtSectionAnswers);

        Hidetoolbar();
        //CrystalReportViewer1.ReportSource = doc;
    }
    private void Hidetoolbar()
    {
        //CrystalReportViewer1.HasCrystalLogo = false;
        //CrystalReportViewer1.HasRefreshButton = false;
        //CrystalReportViewer1.HasExportButton = false;
        //CrystalReportViewer1.HasPrintButton = false;
        //CrystalReportViewer1.HasPageNavigationButtons = false;
        //CrystalReportViewer1.HasSearchButton = false;
        //CrystalReportViewer1.HasGotoPageButton = false;
        //CrystalReportViewer1.HasZoomFactorList = false;
        //CrystalReportViewer1.HasToggleGroupTreeButton = false;
        //CrystalReportViewer1.EnableDrillDown = false;
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
    private void ClearMicroProcurementControls()
    {
        lblReferenceNo.Text = "0"; lblMicroProcurementID.Text = "0"; txtClosingDateTime.Text = ""; ShowMessageMicroMsg(".");
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
            LoadPDO2Items(lblReferenceNo.Text.Trim()); btnPrintMicro.Enabled = true;
        }
        else
        {
            LoadPDO2Items(ReferenceNo); btnPrintMicro.Enabled = false;
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void btnMicroSubmit_Click(object sender, EventArgs e)
    {
        ShowMessageMicroMsg("."); ShowMessage(".");
        if (String.IsNullOrEmpty(txtClosingDateTime.Text.Trim()))
            ShowMessage("Please Enter Closing Date");
        else if (String.IsNullOrEmpty(txtClosingTime.Text.Trim()))
            ShowMessage("Please Enter Closing Time in 24 Hour Mode");
        else
        {
            long CreatedBy = Convert.ToInt64(Session["UserID"].ToString());
            long MicroProcurementID = Convert.ToInt64(lblMicroProcurementID.Text.Trim());
            string RefNo = lblReferenceNo.Text.Trim();
            DateTime ClosingDate = Convert.ToDateTime(txtClosingDateTime.Text.Trim());
            string[] ClosingTime = txtClosingTime.Text.Trim().Split(':');
            int Hour = Convert.ToInt32(ClosingTime[0]); int Min = Convert.ToInt32(ClosingTime[1]);
            DateTime ClosingDateTime = new DateTime(ClosingDate.Year, ClosingDate.Month, ClosingDate.Day, Hour, Min, 0);
            datatableitems = Process.GetMicroProcurementItems(RefNo);
            if (datatableitems.Rows.Count > 0)
            {

                Process.SaveEditMicroProcurementDetails(MicroProcurementID, RefNo, ClosingDateTime, CreatedBy);

                Process.SaveEditMicroProcurementItems(RefNo, datatableitems, CreatedBy);
                ShowMessageMicroMsg("Micro Procurement Has Been Successfully Saved ... "); btnPrintMicro.Enabled = true;
            }


        }
    }
    protected void btnPrintMicro_Click(object sender, EventArgs e)
    {
        try
        {
            datatable = Process.GetReportForMicroProcurements(lblReferenceNo.Text);
            if (datatable.Rows.Count == 0)
                ShowMessageMicroMsg("There is no data for Form PD 02 ...");
            else
            {
                string ReferenceNo = lblReferenceNo.Text.Trim();

                int rowcount = datatable.Rows.Count;
                string ReportName = "PD02";

                if (rowcount != 0)
                {
                    btnPrint.Enabled = true;
                    loadreport(ReportName);

                    Response.Buffer = false;
                    Response.ClearContent();
                    Response.ClearHeaders();
                    //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Form PD 02");
                }
                else
                {
                    ShowMessageMicroMsg("No data to load for report Form selected ....." + ReferenceNo);
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessageMicroMsg(ex.Message);
        }
    }
    protected void cboProcMethod_DataBound(object sender, EventArgs e)
    {
        cboProcMethod.Items.Insert(0, new ListItem(" -- All Proc. Methods --", "0"));
    }
    protected void btnSaveFile_Click2(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            string RefNo = lblAttachRefNo.Text.Trim();
            UploadFiles(RefNo);
            LoadDocuments2();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    public bool IsFileRemoveable(int IsRemoveable)
    {
        if (IsRemoveable == 1)
            return true;
        else
            return false;
    }
    private void LoadDocuments()
    {
        MultiView1.ActiveViewIndex = 5;
        string RefNo = lblAttachRefNo.Text.Trim();
        datatable = Process.GetBiddingDocuments(RefNo, 0);
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
                // string Path = Process.GetDocPath();
                // FileField.PostedFile.SaveAs(Path + "" + c1);
                string Path = Process.GetDocPath();
                String Filepath = Path + "" + c1;
                File1.PostedFile.SaveAs(Filepath);
                Process.SaveBiddingDocument(ReferenceNo, (Path + "" + c1), c, 1);
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
                string FileCode = e.CommandArgument.ToString();
                //string FileCode = Convert.ToString(GridAttachments.DataKeys[intIndex].Value);
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

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnRemove")
            {
                int intIndex = int.Parse(e.CommandArgument.ToString());
               string FileCode = Convert.ToString(GridView1.DataKeys[intIndex].Value);
                Process.RemoveDocument(FileCode);
                LoadDocuments();
            }
            else
            {
                // View 
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridView1.DataKeys[intIndex].Value);
                string Path = Process.GetDocumentPath(FileCode);
                Process.DownloadFile(Path, true);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        Details.ActiveViewIndex = -1;
    }
    protected void btnMicroReturn_Click(object sender, EventArgs e)
    {
        ClearMicroProcurementControls();
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnDone_Click(object sender, EventArgs e)
    {

        MultiView1.ActiveViewIndex = 0;
        Details.ActiveViewIndex = -1;
    }
    protected void btnStagesExport_Click(object sender, EventArgs e)
    {

    }
    protected void btnStagesReturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        Details.ActiveViewIndex = -1;
    }
    protected void DataGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnreturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        Details.ActiveViewIndex = -1;
    }
    protected void btnPrintForm_Click(object sender, EventArgs e)
    {
        try
        {

            if (cboDashboard.SelectedValue.ToString().Equals("G"))
            {


                int AreaId = int.Parse(Session["AreaCode"].ToString());
                string refno = lblRefNo.Text.Trim();

                loadreports("Form5", refno, "G", AreaId);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Form 5");


            }
            else if (cboDashboard.SelectedValue.ToString().Equals("H"))
            {

                int AreaId = int.Parse(Session["AreaCode"].ToString());
                string refno = lblRefNo.Text.Trim();

                loadreports("Form18", refno, "H", AreaId);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Form 18");
            }
            else
            {


                string ReferenceNo = lblRefNo.Text.Trim();
                int ProcMethod = Convert.ToInt32(lblProcMethod.Text.Trim());
                datatable = Process.GetFormNumberByProcMethod(ProcMethod, 1);

                string FormNumber = datatable.Rows[0]["FormNumber"].ToString();
                string Section = cboDashboard.SelectedValue.ToString();
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
                    ShowMessage("No Data To Load For Report Form Selected ...");
            }


        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }

    }
    protected void cboFunding_DataBound(object sender, EventArgs e)
    {
        cboFunding.Items.Insert(0, new ListItem("-- Select Funding Source --", "0"));
    }


    private void LoadGrid(string ReferenceNo, string ProcMethod, string Section)
    {
        DataTable dt3 = new DataTable();
        dt3 = Process.GetGridAnswers(ReferenceNo, ProcMethod, Section);
        dt3.DefaultView.Sort = "Code asc";
        dgvQuestions.DataSource = dt3;
        dgvQuestions.DataBind();

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
    protected void chkIsVat_CheckedChanged(object sender, EventArgs e)
    {
        DataRequisition data = new DataRequisition();

        if (chkIsVat.Checked)
        {

            data.UpdateVatColumn(txtReferenceNo.Text.ToString().Trim(), true);
        }
        else
        {

            data.UpdateVatColumn(txtReferenceNo.Text.ToString().Trim(), false);
        }
    }
    private void LoadProcurementMethods()
    {
        cboProcurementMethod.DataSource = ProcessPlan.GetProcurementMethods();
        cboProcurementMethod.DataValueField = "MethodCode";
        cboProcurementMethod.DataTextField = "Method";
        cboProcurementMethod.DataBind();

    }
    
    private void LoadPDUSupervisors()
    {

        if (Session["AccessLevelID"].ToString() == "4")
        {
            //Load destinations for Small and Large procurement
            datatable = ProcessReq.GetProcLPHead();
            cboPDUHead.DataSource = datatable;
            cboPDUHead.DataValueField = "UserID";
            cboPDUHead.DataTextField = "FullName";
            cboPDUHead.DataBind();

        }
        else if (Session["AccessLevelID"].ToString() == "1026")
        {
            //Load destinations for Small procurement
            datatable = ProcessReq.GetProcSPHead();
            cboPDUHead.DataSource = datatable;
            cboPDUHead.DataValueField = "UserID";
            cboPDUHead.DataTextField = "FullName";
            cboPDUHead.DataBind();
        }
    }

    private void LoadProcurementMethods1()
    {
        cboProcMethod1.DataSource = ProcessPlan.GetProcurementMethods();
        cboProcMethod1.DataValueField = "MethodCode";
        cboProcMethod1.DataTextField = "Method";
        cboProcMethod1.DataBind();

    }


    protected void UpdateProcMethod_Click(object sender, EventArgs e)
    {
        data.UpdateProcMethod(txtReferenceNo.Text.ToString(), cboProcurementMethod.SelectedValue.ToString());
        ShowMessage("Procurement Method Has Been Updated");
        LoadItems();
    }
    protected void IsVat1_CheckedChanged(object sender, EventArgs e)
    {
        DataRequisition data = new DataRequisition();

        if (IsVat1.Checked)
        {

            data.UpdateVatColumn(lblReferenceNo.Text.ToString().Trim(), true);
        }
        else
        {

            data.UpdateVatColumn(lblReferenceNo.Text.ToString().Trim(), false);
        }


    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        data.UpdateProcMethod(lblReferenceNo.Text.ToString(), cboProcMethod1.SelectedValue.ToString());
        ShowMessage("Procurement Method Has Been Updated");
        LoadItems();
    }

    protected void DataGrid5_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "btnViewBiddingDocs")
        {
            string bidderid = e.Item.Cells[0].Text;
            lblSelectedBidder.Text = e.Item.Cells[1].Text;
            lblBidderId.Text = e.Item.Cells[0].Text;
            datatable = Process.GetBidderDocuments(lblReferenceNo.Text, int.Parse(bidderid));
            if (datatable.Rows.Count > 0)
            {
                GridAttachments.DataSource = null;
                GridAttachments.Visible = true;
                GridAttachments.DataSource = datatable;
                GridAttachments.DataBind();
                ShowMessage(datatable.Rows.Count+" document(s) found");
            }
            else
            {
                GridAttachments.DataSource = null;
                GridAttachments.Visible = false;
                lblBidderId.Text = "0";
                ShowMessage("No documents found");
                lblSelectedBidder.Text = ".";
            }
        }
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            if (Button4.Text == "SAVE")
            {
                ShowMessage(".");
                string RefNo = lblAttachRefNo.Text.Trim();
                UploadFiles2(RefNo);
                LoadDocuments2();
            }else if (Button4.Text == "SUBMIT" && chkSubmit.Checked)
            {
                if (txtComment3.Text == "")
                {
                    ShowMessage("Enter a comment before submission");
                }
                else if (ddlBEB.SelectedValue == "0")
                {
                    ShowMessage("Select the BEB");
                }
                else
                {

                    string RefNo = lblReferenceNo.Text.Trim();
                    UploadFiles2(RefNo);

                    string beb = ddlBEB.SelectedValue;
                    string comment = txtComment3.Text;
                    Process.updateBEB(RefNo, int.Parse(beb), comment);

                    ShowMessage(ddlBEB.SelectedItem + " is selected as BEB and sumbmitted for approval");
                    LoadDocuments2();
                    Process.LogandCommitBiddingDetails(RefNo, 60, "");
                    MultiView1.ActiveViewIndex = 0;
                    LoadItems();
                }

            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void chkSubmit_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSubmit.Checked)
        {
            Button4.Text = "SUBMIT";
        }
        else
        {
            Button4.Text = "SAVE";
        }
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            ShowMessage("The PR Number is required......");
        }
        else if (txtBidStartDate.Text == "")
        {
            ShowMessage("Bid solicitation start date is required......");
        }
        else if (txtBidEndDate.Text == "")
        {

            ShowMessage("Bid solicitation end date is required......");
        }
        else if (txtStart.Text == "")
        {

            ShowMessage("Procurement start date is required......");
        }
        else
        {
            string RefNo = TextBox1.Text.Trim();
            double ContractAmount = Convert.ToDouble(TextBox2.Text.Replace(",", "")); //revisit

            if (cboCompany.SelectedValue == "0")
            {
                ShowMessage("Please choose the Procurement entity you belong to ....");
            }
            else
            {
                string SubjectOfProcurement = txtProcDescription.Text;
                int ResponsibleOfficer = Convert.ToInt32(Session["UserID"].ToString());
                int ProcurementMethod = Convert.ToInt32(DropDownList1.SelectedValue.ToString());
                int FundingSource = Convert.ToInt32(cboFunding.SelectedValue.ToString());
                int PreparedBy = Convert.ToInt32(Session["UserID"].ToString());
                int PDUHead = Convert.ToInt32(cboPDUHead.SelectedValue.ToString());
                DateTime DatePrepared = bll.ReturnDate(txtPreparationDate.Text.Trim(), 1);
                DateTime DateAssigned = bll.ReturnDate(txtDateAssigned.Text.Trim(), 1);
                DateTime startDate = bll.ReturnDate(txtStart.Text.Trim(), 1);
                DateTime BidInvitationDate = bll.ReturnDate(txtPreparationDate.Text.Trim(), 1);
                DateTime BidSubmissionDate = bll.ReturnDate(txtPreparationDate.Text.Trim(), 1);
                DateTime BidOpeningDate = bll.ReturnDate(txtPreparationDate.Text.Trim(), 1);
                string CummulativePeriod = txtCummulativePeriod.Text.Trim();
                int PDUCategory = Convert.ToInt32(cboCompany.SelectedValue.ToString());
                bool Submitted = Convert.ToBoolean(chkSubmit.Checked);
                DateTime EOIstart = bll.ReturnDate(txtEOIStart.Text.Trim(), 1);
                DateTime EOIend = bll.ReturnDate(txtEOIEnd.Text.Trim(), 1);

                ProcessReq.SaveEditActivityScheduleHead(RefNo, SubjectOfProcurement, ContractAmount, ProcurementMethod, FundingSource, PreparedBy,
                    PDUHead, DateAssigned, DatePrepared, ResponsibleOfficer, PDUCategory, Submitted, CummulativePeriod);
                
                ProcessReq.SaveEditActivitySchedule2(RefNo, 0, BidInvitationDate, BidSubmissionDate, BidOpeningDate, ContractAmount, startDate, EOIstart, EOIend);
                
            }
            UploadBidDocs(RefNo);
            ShowMessage("Procurement details saved");
        }
    }

    private void UploadBidDocs(string ReferenceNo)
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
              //  File2.PostedFile.SaveAs(Path + "" + c1);
                Process.SaveBiddingDocument(ReferenceNo, (Path + "" + c1), c, 8);
                LoadBidDocuments();
            }
        }
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnRemove")
            {
                //int intIndex = Convert.ToInt32(e.CommandArgument);
                //string FileCode = Convert.ToString(GridView2.DataKeys[intIndex].Value);
                //Process.RemoveDocument(FileCode);
                //LoadBidDocuments();
            }
            else
            {
                // View 
                //int intIndex = Convert.ToInt32(e.CommandArgument);
                //string FileCode = Convert.ToString(GridView2.DataKeys[intIndex].Value);
                //string Path = Process.GetDocumentPath(FileCode);
                //Process.DownloadFile(Path, true);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    

    protected void Button8_Click1(object sender, EventArgs e)//EOI
    {
        try
        {
            string ReferenceNo = lblReferenceNo.Text.Trim();
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
                    File3.PostedFile.SaveAs(Path + "" + c1);
                    Process.SaveBiddingDocument(ReferenceNo, (Path + "" + c1), c, 1009);
                    LoadEOIDocuments();
                }
            }

            int StatusID = 37;
            String message = "EOI submission evaluation saved";
            if (chkEoi.Checked)
            {
                StatusID = 38;
                String Message3 = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + txtProcSubject.Text + "</strong> EOI submission evaluation has been submitted for approval </p>";

                Message3 += "<p>Comment: " + txtComment.Text.Trim() + "</p>";
                Message3 += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";
           
                String PDUSupervisor = cboPDUHead.SelectedItem.Text;
                string OfficerID = Session["officerId"].ToString();
                string Requisitioner = Session["createdby"].ToString();

                ProcessReq.NotifyOfficer(PDUSupervisor, txtProcDescription.Text, OfficerID, Message3);
                ProcessPlan.NotifyPlanner(PDUSupervisor, txtProcDescription.Text, Requisitioner, Message3);

                message = "EOI submission evaluation has been successfully submitted";
            }

            //Log and commit 
            //Forward to LPM/SPM
            ShowMessage(message);
            Process.LogandCommitBiddingDetails(ReferenceNo, StatusID, txtComment.Text.Trim());

        }
        catch(Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }


    protected void Button10_Click(object sender, EventArgs e)//Draft RFP
    {
        try
        {
            string ReferenceNo = lblReferenceNo.Text.Trim();
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
                    File5.PostedFile.SaveAs(Path + "" + c1);

                    Process.SaveBiddingDocument(ReferenceNo, (Path + "" + c1), c, 10);
                    LoadRFPDocuments();
                }
            }

            //Log and commit 
            //Forward to LPM/SPM


            int StatusID = 48;
            String message = "Draft RFP";
            if (chkDraft.Checked)
            {
                StatusID = 49;
                String Message3 = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + txtProcSubject.Text + "</strong> Draft RFP has been submitted for approval </p>";

                Message3 += "<p>Comment: " + txtComment.Text.Trim() + "</p>";
                Message3 += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

                String PDUSupervisor = cboPDUHead.SelectedItem.Text;
                string OfficerID = Session["officerId"].ToString();
                string Requisitioner = Session["createdby"].ToString();

                ProcessReq.NotifyOfficer(PDUSupervisor, txtProcDescription.Text, OfficerID, Message3);
                ProcessPlan.NotifyPlanner(PDUSupervisor, txtProcDescription.Text, Requisitioner, Message3);

                message = "Draft RFP has been successfully submitted";
            }

            //Log and commit 
            //Forward to LPM/SPM
            ShowMessage(message);
            Process.LogandCommitBiddingDetails(ReferenceNo, StatusID, txtComment.Text.Trim());

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void Button12_Click(object sender, EventArgs e)//Eval
    {
        try
        {
            string ReferenceNo = lblReferenceNo.Text.Trim();
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
                    File5.PostedFile.SaveAs(Path + "" + c1);
                   
                    Process.SaveBiddingDocument(ReferenceNo, (Path + "" + c1), c, 7);
                    LoadTechEvalDocs();
                }
            }

            //Log and commit 
            //Forward to LPM/SPM


            int StatusID = 54;
            String message = "Technical evaluation saved";
            if (chkDraft.Checked)
            {
                StatusID = 55;
                String Message3 = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + txtProcSubject.Text + "</strong> Technical evaluation has been submitted for approval </p>";

                Message3 += "<p>Comment: " + txtComment.Text.Trim() + "</p>";
                Message3 += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

                String PDUSupervisor = cboPDUHead.SelectedItem.Text;
                string OfficerID = Session["officerId"].ToString();
                string Requisitioner = Session["createdby"].ToString();

                ProcessReq.NotifyOfficer(PDUSupervisor, txtProcDescription.Text, OfficerID, Message3);
                ProcessPlan.NotifyPlanner(PDUSupervisor, txtProcDescription.Text, Requisitioner, Message3);

                message = "Technical evaluation has been successfully submitted";
            }

            //Log and commit 
            //Forward to LPM/SPM
            ShowMessage(message);
            Process.LogandCommitBiddingDetails(ReferenceNo, StatusID, txtComment.Text.Trim());

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void Button14_Click(object sender, EventArgs e)//Draft contract
    {
        try
        {
            string ReferenceNo = lblReferenceNo.Text.Trim();
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
                   // File2.PostedFile.SaveAs(Path + "" + c1);
                    Process.SaveBiddingDocument(ReferenceNo, (Path + "" + c1), c, 8);
                    LoadBidDocuments();
                }
            }

            //Log and commit 
            //Forward to LPM/SPM


            int StatusID = 61;
            String message = "Draft contract saved";
            if (chkDraft.Checked)
            {
                StatusID = 62;
                String Message3 = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + txtProcSubject.Text + "</strong> Draft contract has been submitted for approval </p>";

                Message3 += "<p>Comment: " + txtComment.Text.Trim() + "</p>";
                Message3 += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

                String PDUSupervisor = cboPDUHead.SelectedItem.Text;
                string OfficerID = Session["officerId"].ToString();
                string Requisitioner = Session["createdby"].ToString();

                ProcessReq.NotifyOfficer(PDUSupervisor, txtProcDescription.Text, OfficerID, Message3);
                ProcessPlan.NotifyPlanner(PDUSupervisor, txtProcDescription.Text, Requisitioner, Message3);

                message = "Draft contract has been successfully submitted";
            }

            //Log and commit 
            //Forward to LPM/SPM
            ShowMessage(message);
            Process.LogandCommitBiddingDetails(ReferenceNo, StatusID, txtComment.Text.Trim());

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void chkDraft_CheckedChanged(object sender, EventArgs e)//draft contract
    {
        if (chkDraft.Checked)
        {
            Button14.Text = "SUBMIT";
        }else
        {
            Button14.Text = "SAVE";
        }
    }

    protected void chkEval_CheckedChanged(object sender, EventArgs e)
    {
        if (chkEval.Checked)
        {
            Button12.Text = "SUBMIT";
        }
        else
        {
            Button12.Text = "SAVE";
        }
    }

    protected void chkRFP_CheckedChanged(object sender, EventArgs e)
    {
        if (chkRFP.Checked)
        {
            Button10.Text = "SUBMIT";
        }
        else
        {
            Button10.Text = "SAVE";
        }
    }

    protected void chkEoi_CheckedChanged(object sender, EventArgs e)
    {
        if (chkEoi.Checked)
        {
            Button8.Text = "SUBMIT";
        }
        else
        {
            Button8.Text = "SAVE";
        }
    }
}
