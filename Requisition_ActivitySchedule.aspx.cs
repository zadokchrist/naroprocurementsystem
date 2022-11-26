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

public partial class Requisition_ActivitySchedule : System.Web.UI.Page
{
    private ProcessRequisition Process = new ProcessRequisition();
    private ProcessPlanning ProcessOther = new ProcessPlanning();

    private BusinessRequisition bll = new BusinessRequisition();
    private BusinessPlanning bll2 = new BusinessPlanning();
    DataTable dtable = new DataTable();
    SendMail mailer = new SendMail();
    private DataTable dtData = new DataTable();
    private string Title = "";
    private string Planned = "";
    private string Actual = "";
    private string ColumnNo = ".";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Label msg = (Label)Master.FindControl("lblmsg");
            msg.Text = ".";

            if (Request.QueryString["PR"] == null)
                Response.Redirect("Requisition_OfficerViewItems.aspx", true);
            else
            {
                if (IsPostBack == false)
                {
                    LoadProcurementMethods();
                    LoadFundingSource();
                    LoadPDUMembers();
                    LoadPDUSupervisors();
                    txtPRNumber.Text = Request.QueryString["PR"].ToString();
                    GetPRDetails();
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void ShowMessage(string ex)
    {
        Label msg = (Label)Master.FindControl("lblmsg");
        msg.Text = "MESSAGE:  " + ex.ToString();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ResetScheduleDetails();
        Response.Redirect("Requisition_OfficerViewItems.aspx", true);
    }
    private void ResetScheduleDetails()
    {
        //txtBidDocPrepDate.Text = "";
        //txtMtdApprovalDate.Text = "";
        //txtAdvertDate.Text = "";
        //txtBidSubmissionDate.Text = "";
        //txtBidOpeningDate.Text = "";
        //txtBidValidityExpiryDate.Text = "";
        //txtBidSecurityExpiryDate.Text = "";
        //txtEvalRptReadyDate.Text = "";
        //txtCCERApprovalDate.Text = "";
        //txtNRReportReadyDate.Text = "";
        //txtCCNRApprovalDate.Text = "";
        //txtBEBNoticeDate.Text = "";
        //txtBoardPaperSubmissionDate.Text = "";
        //txtBoardApprovalDate.Text = "";
        //txtSGPaperSubmissionDate.Text = "";
        //txtSGApprovalDate.Text = "";
        //txtFundsAvailDate.Text = "";
        //txtLPODate.Text = "";
        //txtContractSigningDate.Text = "";
        //txtPerfSecurityExpDate.Text = "";
        //// txtContractAmount.Text = "";
        //txtContractCompletionDate.Text = "";
        //txtReceiptOfPaymentDocDate.Text = "";
        //txtFinanceSubmissionDate.Text = "";
        //txtPaymentDate.Text = "";
        //txtFileClosureDate.Text = "";
        //txtContractAmount.Text = "0";
        //txtContractPrepDate.Text = "";
        //txtprebidmeeting.Text = "";
        //chkSubmit.Checked = false;

        //txtBidDocPrepDate2.Text = "";
        //txtMtdApprovalDate2.Text = "";
        //txtAdvertDate2.Text = "";
        //txtBidSubmissionDate2.Text = "";
        //txtBidOpeningDate2.Text = "";
        //txtBidValidityExpiryDate2.Text = "";
        //txtBidSecurityExpiryDate2.Text = "";
        //txtEvalRptReadyDate2.Text = "";
        //txtCCERApprovalDate2.Text = "";
        //txtNRReportReadyDate2.Text = "";
        //txtCCNRApprovalDate2.Text = "";
        //txtBEBNoticeDate2.Text = "";
        //txtBoardPaperSubmissionDate2.Text = "";
        //txtBoardApprovalDate2.Text = "";
        //txtSGPaperSubmissionDate2.Text = "";
        //txtSGApprovalDate2.Text = "";
        //txtFundsAvailDate2.Text = "";
        //txtLPODate2.Text = "";
        //txtContractSigningDate2.Text = "";
        //txtPerfSecurityExpDate2.Text = "";
        //// txtContractAmount.Text = "";
        //txtContractCompletionDate2.Text = "";
        //txtReceiptOfPaymentDocDate2.Text = "";
        //txtFinanceSubmissionDate2.Text = "";
        //txtPaymentDate2.Text = "";
        //txtFileClosureDate2.Text = "";
        //txtContractAmount2.Text = "0";
        //txtContractPrepDate2.Text = "";
        //txtprebidmeeting2.Text = "";
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            CallValidation();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void CallValidation()
    {
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required......");
        }else if (txtBidStartDate.Text == "")
        {

            ShowMessage("Bid solicitation start date is required......");
        }
        else if (txtBidEndDate.Text == "")
        {

            ShowMessage("Bid solicitation end date is required......");
        }
        else
        {
            string RefNo = txtPRNumber.Text.Trim();
    

         
            double ContractAmount = Convert.ToDouble(txtEstimatedCost.Text.Replace(",", "")); //revisit
      
            double ContractAmount2 = 0.0;
            //if (txtContractAmount2.Text != "")
            //    ContractAmount2 = Convert.ToDouble(txtContractAmount2.Text.Replace(",", ""));

            if (cboCompany.SelectedValue == "0")
            {
                ShowMessage("Please choose the Procurement entity you belong to ....");
            }
            else
            {
                string SubjectOfProcurement = txtProcDescription.Text;
                int ResponsibleOfficer = Convert.ToInt32(Session["UserID"].ToString());
                int ProcurementMethod = Convert.ToInt32(cboProcurementMethod.SelectedValue.ToString());
                int FundingSource = Convert.ToInt32(cboFunding.SelectedValue.ToString());
                int PreparedBy = Convert.ToInt32(Session["UserID"].ToString());
                int PDUHead = Convert.ToInt32(cboPDUHead.SelectedValue.ToString());
                DateTime DatePrepared = bll.ReturnDate(txtPreparationDate.Text.Trim(), 1);
                DateTime DateAssigned = bll.ReturnDate(txtDateAssigned.Text.Trim(), 1);
                DateTime start = bll.ReturnDate(txtStart.Text.Trim(), 1);
                DateTime BidInvitationDate = bll.ReturnDate(txtBidStartDate.Text.Trim(), 1);
                DateTime BidSubmissionDate = bll.ReturnDate(txtBidEndDate.Text.Trim(), 1);
                DateTime BidOpeningDate = bll.ReturnDate(txtPreparationDate.Text.Trim(), 1);
                string CummulativePeriod = txtCummulativePeriod.Text.Trim();
                int PDUCategory = Convert.ToInt32(cboCompany.SelectedValue.ToString());
                bool Submitted = Convert.ToBoolean(chkSubmit.Checked);
                DateTime EOIstart = bll.ReturnDate(txtEOIStart.Text.Trim(), 1);
                DateTime EOIend = bll.ReturnDate(txtEOIEnd.Text.Trim(), 1);

                Process.SaveEditActivityScheduleHead(RefNo, SubjectOfProcurement, ContractAmount, ProcurementMethod, FundingSource, PreparedBy, 
                    PDUHead, DateAssigned, DatePrepared, ResponsibleOfficer, PDUCategory, Submitted, CummulativePeriod);


                Process.SaveEditActivitySchedule2(RefNo, 0, BidInvitationDate,BidSubmissionDate, BidOpeningDate, ContractAmount, start,EOIstart, EOIend);


                //Process.SaveEditActivitySchedule(RefNo, true, BidDocPreparationDate, MthdApprovalDate, AdvertDate, BidSubmissionDate, BidOpeningDate, 
                //    BidValidityExpiryDate, BidSecurityExpiryDate, EvalRptReadyDate, CCERApprovalDate, NRReportReadyDate, NRApprovalDate, BEBNoticeDate, 
                //    BoardPaperSubmissionDate, BoardApprovalDate, SGPaperSubmissionDate, SGApprovalDate, FundsAvailDate, LPODate, ContractPreparationDate, 
                //    ContractSigningDate, PerfSecurityExpDate, ContractAmount, ContractCompletionDate, ReceiptOfPaymentDocDate, FinanceSubmissionDate, PaymentDate, FileClosureDate,prebidmeeting);

                //Process.SaveEditActivitySchedule(RefNo, false, BidDocPreparationDate2, MthdApprovalDate2, AdvertDate2, BidSubmissionDate2, BidOpeningDate2, 
                //    BidValidityExpiryDate2, BidSecurityExpiryDate2, EvalRptReadyDate2, CCERApprovalDate2, NRReportReadyDate2, NRApprovalDate2, BEBNoticeDate2, 
                //    BoardPaperSubmissionDate2, BoardApprovalDate2, SGPaperSubmissionDate2, SGApprovalDate2, FundsAvailDate2, LPODate2, ContractPreparationDate2, 
                //    ContractSigningDate2, PerfSecurityExpDate2, ContractAmount2, ContractCompletionDate2, ReceiptOfPaymentDocDate2, FinanceSubmissionDate2, PaymentDate2, FileClosureDate2,prebidmeeting2);

                // Notify Supervisor if submitted
                string Message = "";
                if (chkSubmit.Checked == true && bll.IsApproved(RefNo) == false)
                {
                    string UserID = Session["UserID"].ToString();

                    if (HttpContext.Current.Session["IsAreaProcess"].ToString() == "0")
                    {
                        if (bll.UserIsSupervisor(UserID) == false)
                        {


                            Process.LogandCommitRequisition(lblPD_Code.Text.Trim(), 26, "Activity Plan Sent to Procurement Supervisor");
                            Message = " And Submitted for Approval ";
                        }
                        else
                        {
                            Process.LogandCommitRequisition(lblPD_Code.Text.Trim(), 26, "Activity Plan Sent to Procurement Supervisor");
                            Message = " And Submitted for Approval ";
                            int ManagerID = Convert.ToInt32(cboPDUHead.SelectedValue.ToString());

                            string Msg = "<p>Hello " + cboPDUHead.SelectedItem.Text + ", </p> <p> You have been sent a Plan (Activity Schedule) for Approval.</p> ";
                            Msg += "<p>For more details, please access the link: http://192.168.8.110/Procurement/  to Login.</p>";
                            string By = HttpContext.Current.Session["FullName"].ToString();
                            //ProcessOther.NotifyManager(By, SubjectOfProcurement, ManagerID, Msg);
                        }

                    }
                    else
                    {
                        Process.SaveUpdateScheduleStatus(txtPRNumber.Text.Trim(), Session["UserCode"].ToString(), "26", txtComment.Text.Trim());
                        Process.LogandCommitRequisition(lblPD_Code.Text.Trim(), 26, "Activity Plan Approved by Area Procurement Supervisor");
                        Message = " HAS BEEN Approved ";
                    
                    }
                }
                else
                {
                    Process.LogandCommitRequisition(lblPD_Code.Text.Trim(), 30, "Preparing Activity Plan By ProcurementOfficer");
                }

                ResetMainData();
                ResetScheduleDetails();

                lblSuccess.Text = "Activity Schedule Successfully saved ";
                MultiView1.ActiveViewIndex = 1;
            }
        }
    }
    private void SetFocus(TextBox ctrl)
    {
        ctrl.Focus();
    }
    protected void cboFunding_DataBound(object sender, EventArgs e)
    {
        cboFunding.Items.Insert(0, new ListItem("-- Select Funding Source --", "0"));
    }
    protected void cboProcurementMethod_DataBound(object sender, EventArgs e)
    {
        cboProcurementMethod.Items.Insert(0, new ListItem("-- Select Procurement Method --", "0"));
    }
    private void LoadFundingSource()
    {
        cboFunding.DataSource = ProcessOther.GetFundSources();
        cboFunding.DataValueField = "Code";
        cboFunding.DataTextField = "Source";
        cboFunding.DataBind();
    }


   

    private void LoadPDUMembers()
    {
        //cboPreparedBy.DataSource = Process.GetPDUMembers();
        //cboPreparedBy.DataValueField = "UserID";
        //cboPreparedBy.DataTextField = "Name";
        //cboPreparedBy.DataBind();

        //cboResponsibleOfficer.DataSource = Process.GetPDUMembers();
        //cboResponsibleOfficer.DataValueField = "UserID";
        //cboResponsibleOfficer.DataTextField = "Name";
        //cboResponsibleOfficer.DataBind();

        //Session["UserID"].ToString();

        //cboPreparedBy.SelectedValue = Session["UserID"].ToString();
        //cboResponsibleOfficer.SelectedValue = Session["UserID"].ToString();



    }
    private void LoadPDUSupervisors()
    {

        if (Session["AccessLevelID"].ToString() == "4")
        {
            //Load destinations for Small  procurement
            dtable = Process.GetProcSPHead();
            cboPDUHead.DataSource = dtable;
            cboPDUHead.DataValueField = "UserID";
            cboPDUHead.DataTextField = "FullName";
            cboPDUHead.DataBind();

        }
        else if (Session["AccessLevelID"].ToString() == "1026")
        {
            //Load destinations for Large procurement
            dtable = Process.GetProcLPHead(); 
            cboPDUHead.DataSource = dtable;
            cboPDUHead.DataValueField = "UserID";
            cboPDUHead.DataTextField = "FullName";
            cboPDUHead.DataBind();
        }
    }
    private void LoadProcurementMethods()
    {
        cboProcurementMethod.DataSource = ProcessOther.GetProcurementMethods();
        cboProcurementMethod.DataValueField = "MethodCode";
        cboProcurementMethod.DataTextField = "Method";
        cboProcurementMethod.DataBind();
    }
    private void ResetMainData()
    {
        txtProcDescription.Text = "";
        cboFunding.SelectedValue = "0";
        cboProcurementMethod.SelectedValue = "0";
        txtEstimatedCost.Text = "";
       // cboPreparedBy.SelectedValue = "0";
        cboPDUHead.SelectedValue = "0";
        txtDateAssigned.Text = "";
       // cboResponsibleOfficer.SelectedValue = "0";
        txtPreparationDate.Text = "";
        txtCummulativePeriod.Text = "";
        txtPRNumber.Focus();
    }
    protected void rbnPlanned_CheckedChanged(object sender, EventArgs e)
    {

    }
    private void GetPRDetails()
    {
        try
        {
            string PRNumber = txtPRNumber.Text.Trim();
            if (!this.IsValidPRNumber(PRNumber))
            {
                ShowMessage("Please provide the PR Number (Valid).....");
            }
            else
            {
                //if (PRNumber.Length < 10)
                //{
                //    PRNumber = AppendZeros(10 - PRNumber.Length) + PRNumber.ToString();
                //    txtPRNumber.Text = PRNumber;
                //}

                DataTable dtData = Process.GetRequisitionDetailsByPRNo(PRNumber);
                int count = dtData.Rows.Count;
                if (count == 0)
                {
                    ShowMessage("No records returned for provided PR Number....");
                }
                else
                {
                    // Load PR Details.
                    txtProcDescription.Text = dtData.Rows[0]["Subject"].ToString();
                    txtEstimatedCost.Text = Convert.ToDouble(dtData.Rows[0]["RequisitionedAmount"].ToString()).ToString("#,##0");
                    lblPD_Code.Text = dtData.Rows[0]["PD_Code"].ToString();
                    cboProcurementMethod.SelectedValue = dtData.Rows[0]["ProcurementMethod"].ToString();
                    cboFunding.SelectedValue = dtData.Rows[0]["FundingSource"].ToString();
                    txtDateAssigned.Text = dtData.Rows[0]["AssignedDate"].ToString().Replace("Jul  1 2011 ", "");
                    txtPreparationDate.Text = DateTime.Today.ToString();
                    // Cummulative Period - Based on File Closure Date ( Now/File Closure Date - Date Assigned) - + Contract Signing Date

                    lblreqn.Text = dtData.Rows[0]["PD_Code"].ToString();
                    
                    // If schedule for PR Exists...
                    if (bll.ScheduleExists(PRNumber))
                    {
                        DataTable dtHead = Process.GetActivitySchedule(PRNumber);
                        DataTable dtPlans = Process.GetActivityScheduleDetails(PRNumber);

                        LoadActivityScheduleControls(dtHead, dtPlans);
                    }
                    double amount = Convert.ToDouble(txtEstimatedCost.Text);
                    string SelectedType = dtData.Rows[0]["ProcurementTypeID"].ToString();
                    
                    LoadProcMethod(amount, SelectedType);

                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
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
            string ProcMethod = ProcessOther.GetProcurementMethod(ProcTypeSelected, amount).ToString();
            cboProcurementMethod.SelectedIndex = cboProcurementMethod.Items.IndexOf(cboProcurementMethod.Items.FindByValue(ProcMethod));
            cboProcurementMethod.Enabled = true;
            //LoadProcLength(ProcMethod);
        }
        else
        {
            cboProcurementMethod.Items.Clear();
            cboProcurementMethod.Enabled = true;
            dtable = ProcessOther.GetProcMethodsForBig(ProcType, amount);
            cboProcurementMethod.DataSource = dtable;
            cboProcurementMethod.DataValueField = "MethodCode";
            cboProcurementMethod.DataTextField = "Method";
            cboProcurementMethod.DataBind();
            cboProcurementMethod.SelectedIndex = cboProcurementMethod.Items.IndexOf(cboProcurementMethod.Items.FindByValue("0"));

        }

    }
    private void LoadActivityScheduleControls(DataTable dtHead, DataTable dtPlans)
    {
        txtCummulativePeriod.Text = dtHead.Rows[0]["CummulativePeriod"].ToString();
        string PreparedBy = dtHead.Rows[0]["PreparedBy"].ToString();
        string ResponsibleOfficer = dtHead.Rows[0]["ResponsibleOfficer"].ToString();


        string PDUHead = dtHead.Rows[0]["PDUHead"].ToString();
       // if(Session["Acc"])

       // cboPreparedBy.SelectedValue = PreparedBy;
      //  cboResponsibleOfficer.SelectedValue = ResponsibleOfficer;
        txtPreparationDate.Text = dtHead.Rows[0]["DatePrepared"].ToString().Replace("Jul  1 2011 ", "");
        // For Old AS
        txtPreparationDate.Text = txtPreparationDate.Text.Trim().Replace("Jul  1 2011 ", "");
        cboPDUHead.SelectedValue = PDUHead;
        cboCompany.SelectedValue = dtHead.Rows[0]["PDUCategory"].ToString();
        chkSubmit.Checked = Convert.ToBoolean(dtHead.Rows[0]["PlanSubmitted"].ToString());
        string UserCode = Session["UserCode"].ToString();
        EnablePlannedSchedule(true);
        if (chkSubmit.Checked == true)
        {
            chkSubmit.Enabled = false;

            //if (bll.UserIsSupervisor(UserCode) == false)
            //{
            //    //EnablePlannedSchedule(false);
            //}
        }
        else
        {
            chkSubmit.Enabled = true;
            //EnablePlannedSchedule(true);
        }

        //txtBidDocPrepDate.Text = dtPlans.Rows[0]["BIDDocPrepDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtMtdApprovalDate.Text = dtPlans.Rows[0]["MethodApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtAdvertDate.Text = dtPlans.Rows[0]["BidInvitationDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtBidSubmissionDate.Text = dtPlans.Rows[0]["BidSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtBidOpeningDate.Text = dtPlans.Rows[0]["BidOpeningDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtBidValidityExpiryDate.Text = dtPlans.Rows[0]["BidValidityExpiryDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtBidSecurityExpiryDate.Text = dtPlans.Rows[0]["BidSecurityExpiryDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtEvalRptReadyDate.Text = dtPlans.Rows[0]["EvalReportReadyDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtCCERApprovalDate.Text = dtPlans.Rows[0]["CCERApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtNRReportReadyDate.Text = dtPlans.Rows[0]["NRReportReadyDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtCCNRApprovalDate.Text = dtPlans.Rows[0]["CCNRApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtBEBNoticeDate.Text = dtPlans.Rows[0]["BEBNoticeDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtBoardPaperSubmissionDate.Text = dtPlans.Rows[0]["BoardPaperSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtBoardApprovalDate.Text = dtPlans.Rows[0]["BoardApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtSGPaperSubmissionDate.Text = dtPlans.Rows[0]["SGPaperSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtSGApprovalDate.Text = dtPlans.Rows[0]["SGApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtFundsAvailDate.Text = dtPlans.Rows[0]["FundsAvailableDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtLPODate.Text = dtPlans.Rows[0]["BidAcceptanceLPODate"].ToString().Replace("Jul  1 2011 ", "");
        //txtContractPrepDate.Text = dtPlans.Rows[0]["ContractPreparationDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtContractSigningDate.Text = dtPlans.Rows[0]["ContractSigningDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtPerfSecurityExpDate.Text = dtPlans.Rows[0]["PerfSecurityExpDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtContractCompletionDate.Text = dtPlans.Rows[0]["ContractCompletionDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtReceiptOfPaymentDocDate.Text = dtPlans.Rows[0]["PaymentDocReceiptDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtFinanceSubmissionDate.Text = dtPlans.Rows[0]["FinanceSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtPaymentDate.Text = dtPlans.Rows[0]["PaymentDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtFileClosureDate.Text = dtPlans.Rows[0]["FileClosureDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtprebidmeeting.Text = dtPlans.Rows[0]["PreBidMeetingDate"].ToString().Replace("Jul  1 2011 ", "");
        //// Actual Schedule
        //txtBidDocPrepDate2.Text = dtPlans.Rows[1]["BIDDocPrepDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtMtdApprovalDate2.Text = dtPlans.Rows[1]["MethodApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtAdvertDate2.Text = dtPlans.Rows[1]["BidInvitationDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtBidSubmissionDate2.Text = dtPlans.Rows[1]["BidSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtBidOpeningDate2.Text = dtPlans.Rows[1]["BidOpeningDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtBidValidityExpiryDate2.Text = dtPlans.Rows[1]["BidValidityExpiryDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtBidSecurityExpiryDate2.Text = dtPlans.Rows[1]["BidSecurityExpiryDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtEvalRptReadyDate2.Text = dtPlans.Rows[1]["EvalReportReadyDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtCCERApprovalDate2.Text = dtPlans.Rows[1]["CCERApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtNRReportReadyDate2.Text = dtPlans.Rows[1]["NRReportReadyDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtCCNRApprovalDate2.Text = dtPlans.Rows[1]["CCNRApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtBEBNoticeDate2.Text = dtPlans.Rows[1]["BEBNoticeDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtBoardPaperSubmissionDate2.Text = dtPlans.Rows[1]["BoardPaperSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtBoardApprovalDate2.Text = dtPlans.Rows[1]["BoardApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtSGPaperSubmissionDate2.Text = dtPlans.Rows[1]["SGPaperSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtSGApprovalDate2.Text = dtPlans.Rows[1]["SGApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtFundsAvailDate2.Text = dtPlans.Rows[1]["FundsAvailableDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtLPODate2.Text = dtPlans.Rows[1]["BidAcceptanceLPODate"].ToString().Replace("Jul  1 2011 ", "");
        //txtContractPrepDate2.Text = dtPlans.Rows[1]["ContractPreparationDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtContractSigningDate2.Text = dtPlans.Rows[1]["ContractSigningDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtPerfSecurityExpDate2.Text = dtPlans.Rows[1]["PerfSecurityExpDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtContractAmount2.Text = Convert.ToDouble(dtPlans.Rows[1]["ContractAmount"].ToString()).ToString();
        //txtContractCompletionDate2.Text = dtPlans.Rows[1]["ContractCompletionDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtReceiptOfPaymentDocDate2.Text = dtPlans.Rows[1]["PaymentDocReceiptDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtFinanceSubmissionDate2.Text = dtPlans.Rows[1]["FinanceSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtPaymentDate2.Text =     dtPlans.Rows[1]["PaymentDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtFileClosureDate2.Text = dtPlans.Rows[1]["FileClosureDate"].ToString().Replace("Jul  1 2011 ", "");
        //txtprebidmeeting2.Text =   dtPlans.Rows[1]["PreBidMeetingDate"].ToString().Replace("Jul  1 2011 ", "");
        //// Cummulative Period - Based on File Closure Date ( Now/File Closure Date - Date Assigned)
        //DateTime EndDate = null;
        DateTime EndDate = DateTime.Today;
        DateTime DateAssigned = Convert.ToDateTime(bll.ReturnDate(txtDateAssigned.Text.Trim(), 1));
        DateTime FileClosureDate = Convert.ToDateTime(bll.ReturnDate(txtBidEndDate.Text.Trim(), 2));

        if (FileClosureDate < DateTime.Now)
        {
            EndDate = FileClosureDate;
        }

        TimeSpan Ts = EndDate - DateAssigned;
        txtCummulativePeriod.Text = Ts.Days.ToString();
    }
    private void EnablePlannedSchedule(bool b_val)
    {
        //txtBidDocPrepDate.Enabled = b_val;
        //txtMtdApprovalDate.Enabled = b_val;
        //txtAdvertDate.Enabled = b_val;
        //txtBidSubmissionDate.Enabled = b_val;
        //txtBidOpeningDate.Enabled = b_val;
        //txtBidValidityExpiryDate.Enabled = b_val;
        //txtBidSecurityExpiryDate.Enabled = b_val;
        //txtEvalRptReadyDate.Enabled = b_val;
        //txtCCERApprovalDate.Enabled = b_val;
        //txtNRReportReadyDate.Enabled = b_val;
        //txtCCNRApprovalDate.Enabled = b_val;
        //txtBEBNoticeDate.Enabled = b_val;
        //txtBoardPaperSubmissionDate.Enabled = b_val;
        //txtBoardApprovalDate.Enabled = b_val;
        //txtSGPaperSubmissionDate.Enabled = b_val;
        //txtSGApprovalDate.Enabled = b_val;
        //txtFundsAvailDate.Enabled = b_val;
        //txtLPODate.Enabled = b_val;
        //txtContractSigningDate.Enabled = b_val;
        //txtPerfSecurityExpDate.Enabled = b_val;
        //txtContractCompletionDate.Enabled = b_val;
        //txtReceiptOfPaymentDocDate.Enabled = b_val;
        //txtFinanceSubmissionDate.Enabled = b_val;
        //txtPaymentDate.Enabled = b_val;
        //txtFileClosureDate.Enabled = b_val;
        //txtContractPrepDate.Enabled = b_val;
        //txtprebidmeeting.Enabled = b_val;
    }
    private string ReturnUserName(string UserCode)
    {
        string Return = "";

        if (UserCode == "")
            Return = "";
        else
        {
            string Name = ""; 
            Return = UserCode + " -- " + Name;
        }
        return Return;
    }
    private bool IsValidPRNumber(string PRNumber)
    {
        bool valid = true;
        if ((PRNumber == "") || (PRNumber.Length < 2))
            valid = false;

        return valid;
    }
    private string AppendZeros(int BalanceLength)
    {
        string Zeros = "";
        for (int i = 0; i < BalanceLength; i++)
        {
            Zeros = Zeros + "0";
        }
        return Zeros;
    }
    
    #region Comment Events
    protected void btn1_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR BID DOC. PREPARATION DATE";
       // Planned = txtBidDocPrepDate.Text.Trim();
       // Actual = txtBidDocPrepDate2.Text.Trim();
        ColumnNo = "1";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }

    private void SwitchView(string Title, string ColumnNo, string PlannedDate, string ActualDate)
    {
        lblCommentTitle.Text = Title;
       // txtPlanned.Text = PlannedDate;
      //  txtActual.Text = ActualDate;
        lblColumnNo.Text = ColumnNo;
        txtComment.Text = "";
        string PRNumber = txtPRNumber.Text.Trim();
        DataTable dtComment = Process.GetActivityScheduleComment(PRNumber, ColumnNo);

        if (dtComment.Rows.Count > 0)
            txtComment.Text = dtComment.Rows[0][0].ToString();

        MultiView1.ActiveViewIndex = 1;
    }
    protected void btnCancelComment_Click(object sender, EventArgs e)
    {
        Response.Redirect("Requisition_OfficerViewItems.aspx");
    }
    protected void btn2_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR METHOD APPROVAL DATE";
       // Planned = txtMtdApprovalDate.Text.Trim();
       // Actual = txtMtdApprovalDate2.Text.Trim();
        ColumnNo = "2";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn3_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR THE ADVERT DATE";
      //  Planned = txtAdvertDate.Text.Trim();
      //  Actual = txtAdvertDate2.Text.Trim();
        ColumnNo = "3";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn4_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR BID SUBMISSION DATE";
       // Planned = txtBidSubmissionDate.Text.Trim();
       // Actual = txtBidSubmissionDate2.Text.Trim();
        ColumnNo = "4";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn5_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR METHOD APPROVAL DATE";
      //  Planned = txtBidOpeningDate.Text.Trim();
      //  Actual = txtBidOpeningDate2.Text.Trim();
        ColumnNo = "5";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn6_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR BID VALIDITY DATE";
       // Planned = txtBidValidityExpiryDate.Text.Trim();
      //  Actual = txtBidValidityExpiryDate2.Text.Trim();
        ColumnNo = "6";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn7_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR METHOD APPROVAL DATE";
       // Planned = txtBidSecurityExpiryDate.Text.Trim();
       // Actual = txtBidSecurityExpiryDate2.Text.Trim();
        ColumnNo = "7";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn8_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR EVALUATION REPORT READY DATE";
      //  Planned = txtEvalRptReadyDate.Text.Trim();
       // Actual = txtEvalRptReadyDate2.Text.Trim();
        ColumnNo = "8";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn9_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR CC(ER) APPROVAL DATE";
      //  Planned = txtCCERApprovalDate.Text.Trim();
      //  Actual = txtCCERApprovalDate2.Text.Trim();
        ColumnNo = "9";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn10_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR NEGOTIATION REPORT READY DATE";
     //   Planned = txtNRReportReadyDate.Text.Trim();
      //  Actual = txtNRReportReadyDate2.Text.Trim();
        ColumnNo = "10";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn11_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR CC - NR APPROVAL DATE";
      //  Planned = txtCCNRApprovalDate.Text.Trim();
     //   Actual = txtCCNRApprovalDate2.Text.Trim();
        ColumnNo = "11";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn12_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR BEB NOTICE DATE";
     //   Planned = txtBEBNoticeDate.Text.Trim();
      //  Actual = txtBEBNoticeDate2.Text.Trim();
        ColumnNo = "12";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn13_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR BOARD PAPER APPROVAL DATE";
    //    Planned = txtBoardPaperSubmissionDate.Text.Trim();
     //   Actual = txtBoardPaperSubmissionDate2.Text.Trim();
        ColumnNo = "13";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn14_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR BOARD PAPER APPROVAL DATE";
     //   Planned = txtBoardApprovalDate.Text.Trim();
     //   Actual = txtBoardApprovalDate2.Text.Trim();
        ColumnNo = "14";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn15_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR S.G PAPER SUBMISSION DATE";
    //    Planned = txtSGPaperSubmissionDate.Text.Trim();
     //   Actual = txtSGPaperSubmissionDate2.Text.Trim();
        ColumnNo = "15";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn16_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR SOLICITOR GENERAL APPROVAL DATE";
     //   Planned = txtSGApprovalDate.Text.Trim();
     //   Actual = txtSGApprovalDate2.Text.Trim();
        ColumnNo = "16";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn17_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR FUNDS AVAILABLE DATE";
      //  Planned = txtFundsAvailDate.Text.Trim();
      //  Actual = txtFundsAvailDate2.Text.Trim();
        ColumnNo = "17";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn18_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR BID ACCEPTANCE/L.P.O DATE";
     //   Planned = txtLPODate.Text.Trim();
     //   Actual = txtLPODate2.Text.Trim();
        ColumnNo = "18";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn19_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR CONTRACT PREPARATION DATE";
     //   Planned = txtContractPrepDate.Text.Trim();
      //  Actual = txtContractPrepDate2.Text.Trim();
        ColumnNo = "19";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn20_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR CONTRACT SIGNING DATE";
    //    Planned = txtContractSigningDate.Text.Trim();
     //   Actual = txtContractSigningDate2.Text.Trim();
        ColumnNo = "20";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn21_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR PERFORMANCE SECURITY EXPIRY DATE";
     //   Planned = txtPerfSecurityExpDate.Text.Trim();
     //   Actual = txtPerfSecurityExpDate2.Text.Trim();
        ColumnNo = "21";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn22_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR CONTRACT AMOUNT";
        Planned = txtEstimatedCost.Text.Trim();
     //   Actual = txtContractAmount2.Text.Trim();
        ColumnNo = "22";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn23_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR CONTRACT COMPLETION DATE";
      //  Planned = txtContractCompletionDate.Text.Trim();
      //  Actual = txtContractCompletionDate2.Text.Trim();
        ColumnNo = "23";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn24_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR DATE OF RECEIPT OF PAYMENT DOC DATE";
      //  Planned = txtReceiptOfPaymentDocDate.Text.Trim();
      //  Actual = txtReceiptOfPaymentDocDate2.Text.Trim();
        ColumnNo = "24";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn25_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR SUBMISSION TO FINANCE DATE";
       // Planned = txtFinanceSubmissionDate.Text.Trim();
       // Actual = txtFinanceSubmissionDate2.Text.Trim();
        ColumnNo = "25";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn26_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR PAYMENT DATE";
       // Planned = txtPaymentDate.Text.Trim();
       // Actual = txtPaymentDate2.Text.Trim();
        ColumnNo = "26";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn27_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR FILE CLOSURE DATE";
      //  Planned = txtFileClosureDate.Text.Trim();
      //  Actual = txtFileClosureDate2.Text.Trim();
        ColumnNo = "27";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    protected void btn28_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR Pre Bid Meeting";
      //  Planned = txtprebidmeeting.Text.Trim();
      //  Actual = txtprebidmeeting2.Text.Trim();
        ColumnNo = "28";
        if (txtPRNumber.Text == "")
        {
            ShowMessage("The PR Number is required .....");
        }
        else if (Planned == "" && Actual == "")
        {
            ShowMessage("Please input the Planned/Actual date .....");
        }
        else
        {
            SwitchView(Title, ColumnNo, Planned, Actual);
        }
    }
    #endregion
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string ColumnNo = lblColumnNo.Text.Trim();
            string Comment = txtComment.Text.Trim();
            string ReferenceNo = txtPRNumber.Text.Trim();
            //dac.Requisitioning_SaveEditASComment(ReferenceNo, ColumnNo, Comment);
            MultiView1.ActiveViewIndex = 0;
            ShowMessage("The Comment has been successfully Updated ....");
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
   
    protected void cboPDUHead_DataBound(object sender, EventArgs e)
    {
        cboPDUHead.Items.Insert(0, new ListItem("-- Select PDU Head/Supervisor --", "0"));
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Requisition_OfficerViewItems.aspx", true);
    }


    protected void txtBidStartDate_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtBidEndDate_TextChanged(object sender, EventArgs e)
    {

    }
}
