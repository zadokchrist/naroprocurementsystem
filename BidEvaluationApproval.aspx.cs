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

public partial class Requisition_ApproveActivitySchedule : System.Web.UI.Page
{
    private ProcessRequisition Process = new ProcessRequisition();
    private ProcessPlanning ProcessOther = new ProcessPlanning();
    private BusinessRequisition bll = new BusinessRequisition();
    SendMail mailer = new SendMail();
    private DataTable dtData = new DataTable();
    
    private int countfiles = 0;
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

            if (IsPostBack == false)
            {
                if (Request.QueryString["PR"] == null)
                    Response.Redirect("BidEvaluation.aspx", true);
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
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void GetPRDetails()
    {
        try
        {
            dtData = Process.GetRequisitionDetailsByPRNo(txtPRNumber.Text.Trim());
            lblreqn.Text = dtData.Rows[0]["PD_Code"].ToString();
            txtBidStartDate.Text = dtData.Rows[0]["BidInvitationDate"].ToString().Replace("Jul  1 2011 ", "");
            txtBidEndDate.Text = dtData.Rows[0]["BidSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
            txtCummulativePeriod.Text = dtData.Rows[0]["CumulativePeriod"].ToString();
            string status = dtData.Rows[0]["StatusID"].ToString();
            dtData = Process.GetActivitySchedule(txtPRNumber.Text.Trim());
            txtProcDescription.Text = dtData.Rows[0]["SubjectOfProcurement"].ToString();
            txtEstimatedCost.Text = Convert.ToDouble(dtData.Rows[0]["EstimatedCost"].ToString()).ToString();
            cboFunding.SelectedValue = dtData.Rows[0]["FundingSource"].ToString();
            txtDateAssigned.Text = dtData.Rows[0]["AssignmentDate"].ToString().Replace("Jul  1 2011 ", "");
            txtPreparationDate.Text = dtData.Rows[0]["DatePrepared"].ToString().Replace("Jul  1 2011 ", "");
            cboProcMethod.SelectedValue = dtData.Rows[0]["ProcurementMethod"].ToString();
            cboPDUHead.SelectedValue = dtData.Rows[0]["PDUHead"].ToString();
            cboPreparedBy.SelectedValue = dtData.Rows[0]["ResponsibleOfficer"].ToString();
            cboCompany.SelectedValue = dtData.Rows[0]["PDUCategory"].ToString();
            Session["Officer"] = dtData.Rows[0]["ResponsibleOfficer"].ToString();
         
            string off = dtData.Rows[0]["ResponsibleOfficer"].ToString();
            if (txtEstimatedCost.Text != "")
                txtContractAmount.Text = txtEstimatedCost.Text;
           
            if (status == "39")// Send Evaluation to the MD/Reject evaluation by the manager
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("EOI evaluation Sent To MD For Approval", "40"));
                rbnApproval.Items.Insert(1, new ListItem("Reject Evaluation", "125"));
            }
            else if (status.Equals("40"))
            {
                rbnApproval.DataSource = null;
                rbnApproval.DataBind();
                rbnApproval.Items.Insert(0, new ListItem("Approve Evaluation", "36"));
                rbnApproval.Items.Insert(1, new ListItem("Reject Evaluation", "125"));
            }

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }


    /// <summary>
    /// Message to display to user
    /// </summary>
    /// <param name="Message"></param>
    private void ShowMessage(string Message)
    {
        Label msg = (Label)Master.FindControl("lblmsg");
        if (Message.Equals("."))
        {
            msg.Text = ".";
        }
        else
        {
            msg.Text = "MESSAGE:  " + Message;
        }
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
        cboPreparedBy.DataSource = Process.GetPDUMembers();
        cboPreparedBy.DataValueField = "UserID";
        cboPreparedBy.DataTextField = "Name";
        cboPreparedBy.DataBind();
        
        cboSupervisor.DataSource = Process.GetPDUMembers();
        cboSupervisor.DataValueField = "UserID";
        cboSupervisor.DataTextField = "Name";
        cboSupervisor.DataBind();
    }

    private void LoadPDUSupervisors()
    {

        if (Session["AccessLevelID"].ToString() == "4" )
        {
            //Load destinations for Small  procurement
            dtData = Process.GetProcSPHead();
            cboPDUHead.DataSource = dtData;
            cboPDUHead.DataValueField = "UserID";
            cboPDUHead.DataTextField = "FullName";
            cboPDUHead.DataBind();

        }
        else if (Session["AccessLevelID"].ToString() == "1025")
        {
            //Load destinations for Large procurement
            dtData = Process.GetProcLPHead();
            cboPDUHead.DataSource = dtData;
            cboPDUHead.DataValueField = "UserID";
            cboPDUHead.DataTextField = "FullName";
            cboPDUHead.DataBind();
        }else if (Session["AccessLevelID"].ToString() == "3" || Session["AccessLevelID"].ToString() == "17")
        {
            cboPDUHead.DataSource = Process.GetPDUMembers();
            cboPDUHead.DataValueField = "UserID";
            cboPDUHead.DataTextField = "Name";
            cboPDUHead.DataBind();

        }
        else if (Session["AccessLevelID"].ToString() == "1027")
        {
            cboPDUHead.DataSource = Process.GetProcPManagers();
            cboPDUHead.DataValueField = "UserID";
            cboPDUHead.DataTextField = "FullName";
            cboPDUHead.DataBind();
        }
    }

    private void LoadProcurementMethods()
    {
        cboProcMethod.DataSource = ProcessOther.GetProcurementMethods();
        cboProcMethod.DataValueField = "MethodCode";
        cboProcMethod.DataTextField = "Method";
        cboProcMethod.DataBind();
    }

    #region Comment Events
    protected void btn1_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR BID DOC. PREPARATION DATE";
        Planned = txtBidDocPrepDate.Text.Trim();
        Actual = txtBidDocPrepDate2.Text.Trim();
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
        //lblCommentTitle.Text = Title;
        //txtPlanned.Text = PlannedDate;
        //txtActual.Text = ActualDate;
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
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btn2_Click(object sender, EventArgs e)
    {
        Title = "ADD COMMENT FOR METHOD APPROVAL DATE";
        Planned = txtMtdApprovalDate.Text.Trim();
        Actual = txtMtdApprovalDate2.Text.Trim();
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
        Planned = txtAdvertDate.Text.Trim();
        Actual = txtAdvertDate2.Text.Trim();
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
        Planned = txtBidSubmissionDate.Text.Trim();
        Actual = txtBidSubmissionDate2.Text.Trim();
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
        Planned = txtBidOpeningDate.Text.Trim();
        Actual = txtBidOpeningDate2.Text.Trim();
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
        Planned = txtBidValidityExpiryDate.Text.Trim();
        Actual = txtBidValidityExpiryDate2.Text.Trim();
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
        Planned = txtBidSecurityExpiryDate.Text.Trim();
        Actual = txtBidSecurityExpiryDate2.Text.Trim();
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
        Planned = txtEvalRptReadyDate.Text.Trim();
        Actual = txtEvalRptReadyDate2.Text.Trim();
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
        Planned = txtCCERApprovalDate.Text.Trim();
        Actual = txtCCERApprovalDate2.Text.Trim();
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
        Planned = txtNRReportReadyDate.Text.Trim();
        Actual = txtNRReportReadyDate2.Text.Trim();
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
        Planned = txtCCNRApprovalDate.Text.Trim();
        Actual = txtCCNRApprovalDate2.Text.Trim();
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
        Planned = txtBEBNoticeDate.Text.Trim();
        Actual = txtBEBNoticeDate2.Text.Trim();
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
        Planned = txtBoardPaperSubmissionDate.Text.Trim();
        Actual = txtBoardPaperSubmissionDate2.Text.Trim();
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
        Planned = txtBoardApprovalDate.Text.Trim();
        Actual = txtBoardApprovalDate2.Text.Trim();
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
        Planned = txtSGPaperSubmissionDate.Text.Trim();
        Actual = txtSGPaperSubmissionDate2.Text.Trim();
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
        Planned = txtSGApprovalDate.Text.Trim();
        Actual = txtSGApprovalDate2.Text.Trim();
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
        Planned = txtFundsAvailDate.Text.Trim();
        Actual = txtFundsAvailDate2.Text.Trim();
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
        Planned = txtLPODate.Text.Trim();
        Actual = txtLPODate2.Text.Trim();
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
        Planned = txtContractPrepDate.Text.Trim();
        Actual = txtContractPrepDate2.Text.Trim();
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
        Planned = txtContractSigningDate.Text.Trim();
        Actual = txtContractSigningDate2.Text.Trim();
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
        Planned = txtPerfSecurityExpDate.Text.Trim();
        Actual = txtPerfSecurityExpDate2.Text.Trim();
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
        Planned = txtContractAmount.Text.Trim();
        Actual = txtContractAmount2.Text.Trim();
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
        Planned = txtContractCompletionDate.Text.Trim();
        Actual = txtContractCompletionDate2.Text.Trim();
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
        Planned = txtReceiptOfPaymentDocDate.Text.Trim();
        Actual = txtReceiptOfPaymentDocDate2.Text.Trim();
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
        Planned = txtFinanceSubmissionDate.Text.Trim();
        Actual = txtFinanceSubmissionDate2.Text.Trim();
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
        Planned = txtPaymentDate.Text.Trim();
        Actual = txtPaymentDate2.Text.Trim();
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
        Planned = txtFileClosureDate.Text.Trim();
        Actual = txtFileClosureDate2.Text.Trim();
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
        Planned = txtprebidmeeting.Text.Trim();
        Actual = txtprebidmeeting2.Text.Trim();
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


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnShowDetails.Visible = true;
        MultiView1.ActiveViewIndex = 1;
    }

    
    private void LoadActivityScheduleControls(DataTable dtHead, DataTable dtPlans)
    {
        //txtCummulativePeriod.Text = dtHead.Rows[0]["CummulativePeriod"].ToString();
        string PreparedBy = dtHead.Rows[0]["PreparedBy"].ToString();
        string ReponsibleOfficer = dtHead.Rows[0]["ResponsibleOfficer"].ToString();
        Session["Officer"] = dtHead.Rows[0]["ResponsibleOfficer"].ToString();
        string PDUHead = dtHead.Rows[0]["PDUHead"].ToString();
        Session["Officer"] = PreparedBy;
       // cboResponsibleOfficer.SelectedValue = ReponsibleOfficer;
        txtPreparationDate.Text = dtHead.Rows[0]["DatePrepared"].ToString();
        cboSupervisor.SelectedValue = dtHead.Rows[0]["PDUSupervisor"].ToString();
        cboPDUHead.SelectedValue = PDUHead;
        cboCompany.SelectedValue = dtHead.Rows[0]["PDUCategory"].ToString();
        cboProcMethod.SelectedValue = dtHead.Rows[0]["ProcurementMethod"].ToString();
        string UserID = Session["UserID"].ToString();

        txtBidDocPrepDate.Text = dtPlans.Rows[0]["BIDDocPrepDate"].ToString().Replace("Jul  1 2011 ", "");
        txtMtdApprovalDate.Text = dtPlans.Rows[0]["MethodApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        txtAdvertDate.Text = dtPlans.Rows[0]["BidInvitationDate"].ToString().Replace("Jul  1 2011 ", "");
        txtBidSubmissionDate.Text = dtPlans.Rows[0]["BidSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        txtBidOpeningDate.Text = dtPlans.Rows[0]["BidOpeningDate"].ToString().Replace("Jul  1 2011 ", "");
        txtBidValidityExpiryDate.Text = dtPlans.Rows[0]["BidValidityExpiryDate"].ToString().Replace("Jul  1 2011 ", "");
        txtBidSecurityExpiryDate.Text = dtPlans.Rows[0]["BidSecurityExpiryDate"].ToString().Replace("Jul  1 2011 ", "");
        txtEvalRptReadyDate.Text = dtPlans.Rows[0]["EvalReportReadyDate"].ToString().Replace("Jul  1 2011 ", "");
        txtCCERApprovalDate.Text = dtPlans.Rows[0]["CCERApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        txtNRReportReadyDate.Text = dtPlans.Rows[0]["NRReportReadyDate"].ToString().Replace("Jul  1 2011 ", "");
        txtCCNRApprovalDate.Text = dtPlans.Rows[0]["CCNRApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        txtBEBNoticeDate.Text = dtPlans.Rows[0]["BEBNoticeDate"].ToString().Replace("Jul  1 2011 ", "");
        txtBoardPaperSubmissionDate.Text = dtPlans.Rows[0]["BoardPaperSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        txtBoardApprovalDate.Text = dtPlans.Rows[0]["BoardApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        txtSGPaperSubmissionDate.Text = dtPlans.Rows[0]["SGPaperSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        txtSGApprovalDate.Text = dtPlans.Rows[0]["SGApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        txtFundsAvailDate.Text = dtPlans.Rows[0]["FundsAvailableDate"].ToString().Replace("Jul  1 2011 ", "");
        txtLPODate.Text = dtPlans.Rows[0]["BidAcceptanceLPODate"].ToString().Replace("Jul  1 2011 ", "");
        txtContractPrepDate.Text = dtPlans.Rows[0]["ContractPreparationDate"].ToString().Replace("Jul  1 2011 ", "");
        txtContractSigningDate.Text = dtPlans.Rows[0]["ContractSigningDate"].ToString().Replace("Jul  1 2011 ", "");
        txtPerfSecurityExpDate.Text = dtPlans.Rows[0]["PerfSecurityExpDate"].ToString().Replace("Jul  1 2011 ", "");
        txtContractCompletionDate.Text = dtPlans.Rows[0]["ContractCompletionDate"].ToString().Replace("Jul  1 2011 ", "");
        txtReceiptOfPaymentDocDate.Text = dtPlans.Rows[0]["PaymentDocReceiptDate"].ToString().Replace("Jul  1 2011 ", "");
        txtFinanceSubmissionDate.Text = dtPlans.Rows[0]["FinanceSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        txtPaymentDate.Text = dtPlans.Rows[0]["PaymentDate"].ToString().Replace("Jul  1 2011 ", "");
        txtFileClosureDate.Text = dtPlans.Rows[0]["FileClosureDate"].ToString().Replace("Jul  1 2011 ", "");
        txtprebidmeeting.Text =   dtPlans.Rows[0]["PreBidMeetingDate"].ToString().Replace("Jul  1 2011 ", "");

        // Actual Schedule
        txtBidDocPrepDate2.Text = dtPlans.Rows[1]["BIDDocPrepDate"].ToString().Replace("Jul  1 2011 ", "");
        txtMtdApprovalDate2.Text = dtPlans.Rows[1]["MethodApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        txtAdvertDate2.Text = dtPlans.Rows[1]["BidInvitationDate"].ToString().Replace("Jul  1 2011 ", "");
        txtBidSubmissionDate2.Text = dtPlans.Rows[1]["BidSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        txtBidOpeningDate2.Text = dtPlans.Rows[1]["BidOpeningDate"].ToString().Replace("Jul  1 2011 ", "");
        txtBidValidityExpiryDate2.Text = dtPlans.Rows[1]["BidValidityExpiryDate"].ToString().Replace("Jul  1 2011 ", "");
        txtBidSecurityExpiryDate2.Text = dtPlans.Rows[1]["BidSecurityExpiryDate"].ToString().Replace("Jul  1 2011 ", "");
        txtEvalRptReadyDate2.Text = dtPlans.Rows[1]["EvalReportReadyDate"].ToString().Replace("Jul  1 2011 ", "");
        txtCCERApprovalDate2.Text = dtPlans.Rows[1]["CCERApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        txtNRReportReadyDate2.Text = dtPlans.Rows[1]["NRReportReadyDate"].ToString().Replace("Jul  1 2011 ", "");
        txtCCNRApprovalDate2.Text = dtPlans.Rows[1]["CCNRApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        txtBEBNoticeDate2.Text = dtPlans.Rows[1]["BEBNoticeDate"].ToString().Replace("Jul  1 2011 ", "");
        txtBoardPaperSubmissionDate2.Text = dtPlans.Rows[1]["BoardPaperSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        txtBoardApprovalDate2.Text = dtPlans.Rows[1]["BoardApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        txtSGPaperSubmissionDate2.Text = dtPlans.Rows[1]["SGPaperSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        txtSGApprovalDate2.Text = dtPlans.Rows[1]["SGApprovalDate"].ToString().Replace("Jul  1 2011 ", "");
        txtFundsAvailDate2.Text = dtPlans.Rows[1]["FundsAvailableDate"].ToString().Replace("Jul  1 2011 ", "");
        txtLPODate2.Text = dtPlans.Rows[1]["BidAcceptanceLPODate"].ToString().Replace("Jul  1 2011 ", "");
        txtContractPrepDate2.Text = dtPlans.Rows[1]["ContractPreparationDate"].ToString().Replace("Jul  1 2011 ", "");
        txtContractSigningDate2.Text = dtPlans.Rows[1]["ContractSigningDate"].ToString().Replace("Jul  1 2011 ", "");
        txtPerfSecurityExpDate2.Text = dtPlans.Rows[1]["PerfSecurityExpDate"].ToString().Replace("Jul  1 2011 ", "");
        txtContractAmount2.Text = Convert.ToDouble(dtPlans.Rows[1]["ContractAmount"].ToString()).ToString();
        txtContractCompletionDate2.Text = dtPlans.Rows[1]["ContractCompletionDate"].ToString().Replace("Jul  1 2011 ", "");
        txtReceiptOfPaymentDocDate2.Text = dtPlans.Rows[1]["PaymentDocReceiptDate"].ToString().Replace("Jul  1 2011 ", "");
        txtFinanceSubmissionDate2.Text = dtPlans.Rows[1]["FinanceSubmissionDate"].ToString().Replace("Jul  1 2011 ", "");
        txtPaymentDate2.Text = dtPlans.Rows[1]["PaymentDate"].ToString().Replace("Jul  1 2011 ", "");
        txtFileClosureDate2.Text = dtPlans.Rows[1]["FileClosureDate"].ToString().Replace("Jul  1 2011 ", "");
        txtprebidmeeting2.Text = dtPlans.Rows[1]["PreBidMeetingDate"].ToString().Replace("Jul  1 2011 ", "");
        CleanUpOldScheduleDates(dtPlans);

        // Cummulative Period - Based on File Closure Date ( Now/File Closure Date - Date Assigned)
        //DateTime EndDate = null;
        DateTime EndDate = DateTime.Today;
        DateTime EndDate2 = DateTime.Today;
        DateTime DateAssigned = Convert.ToDateTime(bll.ReturnDate(txtDateAssigned.Text.Trim(), 1));
        DateTime FileClosureDate = Convert.ToDateTime(bll.ReturnDate(txtFileClosureDate2.Text.Trim(), 2));
        DateTime ContractSigningDate = Convert.ToDateTime(bll.ReturnDate(txtContractSigningDate2.Text.Trim(), 2));

        if (FileClosureDate < DateTime.Now)
        {
            EndDate = FileClosureDate;
        }
        if (ContractSigningDate < DateTime.Now)
        {
            EndDate2 = ContractSigningDate;
        }

        TimeSpan Ts = EndDate - DateAssigned;
        TimeSpan Ts2 = EndDate2 - DateAssigned;
       // txtCummulativePeriod.Text = Ts.Days.ToString() + " Days";
        //txtCummulativeByConstractSigning.Text = Ts2.Days.ToString() + " Days";
    }

    private void CleanUpOldScheduleDates(DataTable dtPlans)
    {
        // For Old AS
        txtPreparationDate.Text = txtPreparationDate.Text.Trim().Replace("Jan  1 1900 ", "");
        txtBidDocPrepDate.Text = dtPlans.Rows[0]["BIDDocPrepDate"].ToString().Replace("Jan  1 1900 ", "");
        txtMtdApprovalDate.Text = dtPlans.Rows[0]["MethodApprovalDate"].ToString().Replace("Jan  1 1900 ", "");
        txtAdvertDate.Text = dtPlans.Rows[0]["BidInvitationDate"].ToString().Replace("Jan  1 1900 ", "");
        txtBidSubmissionDate.Text = dtPlans.Rows[0]["BidSubmissionDate"].ToString().Replace("Jan  1 1900 ", "");
        txtBidOpeningDate.Text = dtPlans.Rows[0]["BidOpeningDate"].ToString().Replace("Jan  1 1900 ", "");
        txtBidValidityExpiryDate.Text = dtPlans.Rows[0]["BidValidityExpiryDate"].ToString().Replace("Jan  1 1900 ", "");
        txtBidSecurityExpiryDate.Text = dtPlans.Rows[0]["BidSecurityExpiryDate"].ToString().Replace("Jan  1 1900 ", "");
        txtEvalRptReadyDate.Text = dtPlans.Rows[0]["EvalReportReadyDate"].ToString().Replace("Jan  1 1900 ", "");
        txtCCERApprovalDate.Text = dtPlans.Rows[0]["CCERApprovalDate"].ToString().Replace("Jan  1 1900 ", "");
        txtNRReportReadyDate.Text = dtPlans.Rows[0]["NRReportReadyDate"].ToString().Replace("Jan  1 1900 ", "");
        txtCCNRApprovalDate.Text = dtPlans.Rows[0]["CCNRApprovalDate"].ToString().Replace("Jan  1 1900 ", "");
        txtBEBNoticeDate.Text = dtPlans.Rows[0]["BEBNoticeDate"].ToString().Replace("Jan  1 1900 ", "");
        txtBoardPaperSubmissionDate.Text = dtPlans.Rows[0]["BoardPaperSubmissionDate"].ToString().Replace("Jan  1 1900 ", "");
        txtBoardApprovalDate.Text = dtPlans.Rows[0]["BoardApprovalDate"].ToString().Replace("Jan  1 1900 ", "");
        txtSGPaperSubmissionDate.Text = dtPlans.Rows[0]["SGPaperSubmissionDate"].ToString().Replace("Jan  1 1900 ", "");
        txtSGApprovalDate.Text = dtPlans.Rows[0]["SGApprovalDate"].ToString().Replace("Jan  1 1900 ", "");
        txtFundsAvailDate.Text = dtPlans.Rows[0]["FundsAvailableDate"].ToString().Replace("Jan  1 1900 ", "");
        txtLPODate.Text = dtPlans.Rows[0]["BidAcceptanceLPODate"].ToString().Replace("Jan  1 1900 ", "");
        txtContractPrepDate.Text = dtPlans.Rows[0]["ContractPreparationDate"].ToString().Replace("Jan  1 1900 ", "");
        txtContractSigningDate.Text = dtPlans.Rows[0]["ContractSigningDate"].ToString().Replace("Jan  1 1900 ", "");
        txtPerfSecurityExpDate.Text = dtPlans.Rows[0]["PerfSecurityExpDate"].ToString().Replace("Jan  1 1900 ", "");
        txtContractCompletionDate.Text = dtPlans.Rows[0]["ContractCompletionDate"].ToString().Replace("Jan  1 1900 ", "");
        txtReceiptOfPaymentDocDate.Text = dtPlans.Rows[0]["PaymentDocReceiptDate"].ToString().Replace("Jan  1 1900 ", "");
        txtFinanceSubmissionDate.Text = dtPlans.Rows[0]["FinanceSubmissionDate"].ToString().Replace("Jan  1 1900 ", "");
        txtPaymentDate.Text = dtPlans.Rows[0]["PaymentDate"].ToString().Replace("Jan  1 1900 ", "");
        txtFileClosureDate.Text = dtPlans.Rows[0]["FileClosureDate"].ToString().Replace("Jan  1 1900 ", "");
        txtprebidmeeting.Text = dtPlans.Rows[0]["PreBidMeetingDate"].ToString().Replace("Jan  1 1900 ", "");
        // Actual Schedule
        txtBidDocPrepDate2.Text = dtPlans.Rows[1]["BIDDocPrepDate"].ToString().Replace("Jan  1 1900 ", "");
        txtMtdApprovalDate2.Text = dtPlans.Rows[1]["MethodApprovalDate"].ToString().Replace("Jan  1 1900 ", "");
        txtAdvertDate2.Text = dtPlans.Rows[1]["BidInvitationDate"].ToString().Replace("Jan  1 1900 ", "");
        txtBidSubmissionDate2.Text = dtPlans.Rows[1]["BidSubmissionDate"].ToString().Replace("Jan  1 1900 ", "");
        txtBidOpeningDate2.Text = dtPlans.Rows[1]["BidOpeningDate"].ToString().Replace("Jan  1 1900 ", "");
        txtBidValidityExpiryDate2.Text = dtPlans.Rows[1]["BidValidityExpiryDate"].ToString().Replace("Jan  1 1900 ", "");
        txtBidSecurityExpiryDate2.Text = dtPlans.Rows[1]["BidSecurityExpiryDate"].ToString().Replace("Jan  1 1900 ", "");
        txtEvalRptReadyDate2.Text = dtPlans.Rows[1]["EvalReportReadyDate"].ToString().Replace("Jan  1 1900 ", "");
        txtCCERApprovalDate2.Text = dtPlans.Rows[1]["CCERApprovalDate"].ToString().Replace("Jan  1 1900 ", "");
        txtNRReportReadyDate2.Text = dtPlans.Rows[1]["NRReportReadyDate"].ToString().Replace("Jan  1 1900 ", "");
        txtCCNRApprovalDate2.Text = dtPlans.Rows[1]["CCNRApprovalDate"].ToString().Replace("Jan  1 1900 ", "");
        txtBEBNoticeDate2.Text = dtPlans.Rows[1]["BEBNoticeDate"].ToString().Replace("Jan  1 1900 ", "");
        txtBoardPaperSubmissionDate2.Text = dtPlans.Rows[1]["BoardPaperSubmissionDate"].ToString().Replace("Jan  1 1900 ", "");
        txtBoardApprovalDate2.Text = dtPlans.Rows[1]["BoardApprovalDate"].ToString().Replace("Jan  1 1900 ", "");
        txtSGPaperSubmissionDate2.Text = dtPlans.Rows[1]["SGPaperSubmissionDate"].ToString().Replace("Jan  1 1900 ", "");
        txtSGApprovalDate2.Text = dtPlans.Rows[1]["SGApprovalDate"].ToString().Replace("Jan  1 1900 ", "");
        txtFundsAvailDate2.Text = dtPlans.Rows[1]["FundsAvailableDate"].ToString().Replace("Jan  1 1900 ", "");
        txtLPODate2.Text = dtPlans.Rows[1]["BidAcceptanceLPODate"].ToString().Replace("Jan  1 1900 ", "");
        txtContractPrepDate2.Text = dtPlans.Rows[1]["ContractPreparationDate"].ToString().Replace("Jan  1 1900 ", "");
        txtContractSigningDate2.Text = dtPlans.Rows[1]["ContractSigningDate"].ToString().Replace("Jan  1 1900 ", "");
        txtPerfSecurityExpDate2.Text = dtPlans.Rows[1]["PerfSecurityExpDate"].ToString().Replace("Jan  1 1900 ", "");
        txtContractAmount2.Text = Convert.ToDouble(dtPlans.Rows[1]["ContractAmount"].ToString()).ToString();
        txtContractCompletionDate2.Text = dtPlans.Rows[1]["ContractCompletionDate"].ToString().Replace("Jan  1 1900 ", "");
        txtReceiptOfPaymentDocDate2.Text = dtPlans.Rows[1]["PaymentDocReceiptDate"].ToString().Replace("Jan  1 1900 ", "");
        txtFinanceSubmissionDate2.Text = dtPlans.Rows[1]["FinanceSubmissionDate"].ToString().Replace("Jan  1 1900 ", "");
        txtPaymentDate2.Text = dtPlans.Rows[1]["PaymentDate"].ToString().Replace("Jan  1 1900 ", "");
        txtFileClosureDate2.Text = dtPlans.Rows[1]["FileClosureDate"].ToString().Replace("Jan  1 1900 ", "");
        txtprebidmeeting2.Text =   dtPlans.Rows[1]["PreBidMeetingDate"].ToString().Replace("Jan  1 1900 ", "");
    }
    private void EnablePlannedSchedule(bool b_val)
    {
        txtBidDocPrepDate.Enabled = b_val;
        txtMtdApprovalDate.Enabled = b_val;
        txtAdvertDate.Enabled = b_val;
        txtBidSubmissionDate.Enabled = b_val;
        txtBidOpeningDate.Enabled = b_val;
        txtBidValidityExpiryDate.Enabled = b_val;
        txtBidSecurityExpiryDate.Enabled = b_val;
        txtEvalRptReadyDate.Enabled = b_val;
        txtCCERApprovalDate.Enabled = b_val;
        txtNRReportReadyDate.Enabled = b_val;
        txtCCNRApprovalDate.Enabled = b_val;
        txtBEBNoticeDate.Enabled = b_val;
        txtBoardPaperSubmissionDate.Enabled = b_val;
        txtBoardApprovalDate.Enabled = b_val;
        txtSGPaperSubmissionDate.Enabled = b_val;
        txtSGApprovalDate.Enabled = b_val;
        txtFundsAvailDate.Enabled = b_val;
        txtLPODate.Enabled = b_val;
        txtContractSigningDate.Enabled = b_val;
        txtPerfSecurityExpDate.Enabled = b_val;
        txtContractCompletionDate.Enabled = b_val;
        txtReceiptOfPaymentDocDate.Enabled = b_val;
        txtFinanceSubmissionDate.Enabled = b_val;
        txtPaymentDate.Enabled = b_val;
        txtFileClosureDate.Enabled = b_val;
        txtContractPrepDate.Enabled = b_val;
        txtprebidmeeting.Enabled = b_val;
    }
    
    protected void btnUpdate_Click(object sender, EventArgs e)
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
        }
        else
        {
            string RefNo = txtPRNumber.Text.Trim();
            //bool Planned = Convert.ToBoolean(rbnPlanned.Checked);
            // Planned Activity Schedule

            DateTime BidDocPreparationDate = bll.ReturnDate(txtBidDocPrepDate.Text.Trim(), 1);
            DateTime MthdApprovalDate = bll.ReturnDate(txtMtdApprovalDate.Text.Trim(), 1);
            DateTime AdvertDate = bll.ReturnDate(txtAdvertDate.Text.Trim(), 1);
            DateTime BidSubmissionDate = bll.ReturnDate(txtBidSubmissionDate.Text, 1);
            DateTime BidOpeningDate = bll.ReturnDate(txtBidOpeningDate.Text.Trim(), 1);
            DateTime BidValidityExpiryDate = bll.ReturnDate(txtBidValidityExpiryDate.Text.Trim(), 1);
            DateTime BidSecurityExpiryDate = bll.ReturnDate(txtBidSecurityExpiryDate.Text.Trim(), 1);
            DateTime EvalRptReadyDate = bll.ReturnDate(txtEvalRptReadyDate.Text.Trim(), 1);
            DateTime CCERApprovalDate = bll.ReturnDate(txtCCERApprovalDate.Text.Trim(), 1);
            DateTime NRReportReadyDate = bll.ReturnDate(txtNRReportReadyDate.Text.Trim(), 1);
            DateTime NRApprovalDate = bll.ReturnDate(txtCCNRApprovalDate.Text.Trim(), 1);
            DateTime BEBNoticeDate = bll.ReturnDate(txtBEBNoticeDate.Text.Trim(), 1);
            DateTime BoardPaperSubmissionDate = bll.ReturnDate(txtBoardPaperSubmissionDate.Text.Trim(), 1);
            DateTime BoardApprovalDate = bll.ReturnDate(txtBoardApprovalDate.Text.Trim(), 1);
            DateTime SGPaperSubmissionDate = bll.ReturnDate(txtSGPaperSubmissionDate.Text.Trim(), 1);
            DateTime SGApprovalDate = bll.ReturnDate(txtSGApprovalDate.Text.Trim(), 1);
            DateTime FundsAvailDate = bll.ReturnDate(txtFundsAvailDate.Text.Trim(), 1);
            DateTime LPODate = bll.ReturnDate(txtLPODate.Text.Trim(), 1);
            DateTime ContractPreparationDate = bll.ReturnDate(txtContractPrepDate.Text.Trim(), 1);
            DateTime ContractSigningDate = bll.ReturnDate(txtContractSigningDate.Text.Trim(), 1);
            DateTime PerfSecurityExpDate = bll.ReturnDate(txtPerfSecurityExpDate.Text.Trim(), 1);
            double ContractAmount = Convert.ToDouble(txtContractAmount.Text.Replace(",", "")); //revisit
            DateTime ContractCompletionDate = bll.ReturnDate(txtContractCompletionDate.Text.Trim(), 1);
            DateTime ReceiptOfPaymentDocDate = bll.ReturnDate(txtReceiptOfPaymentDocDate.Text.Trim(), 1);
            DateTime FinanceSubmissionDate = bll.ReturnDate(txtFinanceSubmissionDate.Text.Trim(), 1);
            DateTime PaymentDate = bll.ReturnDate(txtPaymentDate.Text.Trim(), 1);
            DateTime FileClosureDate = bll.ReturnDate(txtFileClosureDate.Text.Trim(), 1);
            DateTime prebidmeeting = bll.ReturnDate(txtprebidmeeting.Text.Trim(), 1);
            //double ContractAmount = Convert.ToDouble(txtEstimatedCost.Text.Replace(",", ""));

            // Actual Schedule
            DateTime BidDocPreparationDate2 = bll.ReturnDate(txtBidDocPrepDate2.Text.Trim(), 1);
            DateTime MthdApprovalDate2 = bll.ReturnDate(txtMtdApprovalDate2.Text.Trim(), 1);
            DateTime AdvertDate2 = bll.ReturnDate(txtAdvertDate2.Text.Trim(), 1);
            DateTime BidSubmissionDate2 = bll.ReturnDate(txtBidSubmissionDate2.Text, 1);
            DateTime BidOpeningDate2 = bll.ReturnDate(txtBidOpeningDate2.Text.Trim(), 1);
            DateTime BidValidityExpiryDate2 = bll.ReturnDate(txtBidValidityExpiryDate2.Text.Trim(), 1);
            DateTime BidSecurityExpiryDate2 = bll.ReturnDate(txtBidSecurityExpiryDate2.Text.Trim(), 1);
            DateTime EvalRptReadyDate2 = bll.ReturnDate(txtEvalRptReadyDate2.Text.Trim(), 1);
            DateTime CCERApprovalDate2 = bll.ReturnDate(txtCCERApprovalDate2.Text.Trim(), 1);
            DateTime NRReportReadyDate2 = bll.ReturnDate(txtNRReportReadyDate2.Text.Trim(), 1);
            DateTime NRApprovalDate2 = bll.ReturnDate(txtCCNRApprovalDate2.Text.Trim(), 1);
            DateTime BEBNoticeDate2 = bll.ReturnDate(txtBEBNoticeDate2.Text.Trim(), 1);
            DateTime BoardPaperSubmissionDate2 = bll.ReturnDate(txtBoardPaperSubmissionDate2.Text.Trim(), 1);
            DateTime BoardApprovalDate2 = bll.ReturnDate(txtBoardApprovalDate2.Text.Trim(), 1);
            DateTime SGPaperSubmissionDate2 = bll.ReturnDate(txtSGPaperSubmissionDate2.Text.Trim(), 1);
            DateTime SGApprovalDate2 = bll.ReturnDate(txtSGApprovalDate2.Text.Trim(), 1);
            DateTime FundsAvailDate2 = bll.ReturnDate(txtFundsAvailDate2.Text.Trim(), 1);
            DateTime LPODate2 = bll.ReturnDate(txtLPODate2.Text.Trim(), 1);
            DateTime ContractPreparationDate2 = bll.ReturnDate(txtContractPrepDate2.Text.Trim(), 1);
            DateTime ContractSigningDate2 = bll.ReturnDate(txtContractSigningDate2.Text.Trim(), 1);
            DateTime PerfSecurityExpDate2 = bll.ReturnDate(txtPerfSecurityExpDate2.Text.Trim(), 1);
            //double ContractAmount2 = Convert.ToDouble(txtContractAmount2.Text.Replace(",", "")); ///revisit
            DateTime ContractCompletionDate2 = bll.ReturnDate(txtContractCompletionDate2.Text.Trim(), 1);
            DateTime ReceiptOfPaymentDocDate2 = bll.ReturnDate(txtReceiptOfPaymentDocDate2.Text.Trim(), 1);
            DateTime FinanceSubmissionDate2 = bll.ReturnDate(txtFinanceSubmissionDate2.Text.Trim(), 1);
            DateTime PaymentDate2 = bll.ReturnDate(txtPaymentDate2.Text.Trim(), 1);
            DateTime FileClosureDate2 = bll.ReturnDate(txtFileClosureDate2.Text.Trim(), 1);
            DateTime prebidmeeting2 = bll.ReturnDate(txtprebidmeeting2.Text.Trim(), 1);
            //double ContractAmount2 = Convert.ToDouble(txtEstimatedCost2.Text.Replace(",", ""));
            double ContractAmount2 = 0.0;
            if (txtContractAmount2.Text != "")
                ContractAmount2 = Convert.ToDouble(txtContractAmount2.Text.Replace(",", ""));

            string CreatedBy = Session["UserCode"].ToString();
            if (cboCompany.SelectedValue == "0")
            {
                ShowMessage("Please choose the PDU you belong to ....");
            }
            else
            {
                string SubjectOfProcurement = txtProcDescription.Text;
                int ResponsibleOfficer = Convert.ToInt32(Session["Officer"].ToString());
                int ProcurementMethod = Convert.ToInt32(cboProcMethod.SelectedValue.ToString());
                int FundingSource = Convert.ToInt32(cboFunding.SelectedValue.ToString());
                int PreparedBy = Convert.ToInt32(Session["Officer"].ToString());

                int PDUHead = Convert.ToInt32(cboPDUHead.SelectedValue.ToString());

                DateTime DateAssigned = bll.ReturnDate(txtDateAssigned.Text.Trim(), 1);
                DateTime DatePrepared = bll.ReturnDate(txtPreparationDate.Text.Trim(), 1);
                string CummulativePeriod = "";
                string CummulativePeriod2 = "";
                int PDUCategory = Convert.ToInt32(cboCompany.SelectedValue.ToString());
                bool Submitted = true;

                Process.SaveEditActivityScheduleHead(RefNo, SubjectOfProcurement, ContractAmount, ProcurementMethod, FundingSource, PreparedBy, PDUHead, DateAssigned, DatePrepared, ResponsibleOfficer, PDUCategory, Submitted, CummulativePeriod);

                //Process.SaveEditActivitySchedule(RefNo, true, BidDocPreparationDate, MthdApprovalDate, AdvertDate, BidSubmissionDate, BidOpeningDate, BidValidityExpiryDate, BidSecurityExpiryDate, EvalRptReadyDate, CCERApprovalDate, NRReportReadyDate, NRApprovalDate, BEBNoticeDate, BoardPaperSubmissionDate, BoardApprovalDate, SGPaperSubmissionDate, SGApprovalDate, FundsAvailDate, LPODate, ContractPreparationDate, ContractSigningDate, PerfSecurityExpDate, ContractAmount, ContractCompletionDate, ReceiptOfPaymentDocDate, FinanceSubmissionDate, PaymentDate, FileClosureDate, prebidmeeting);
                //Process.SaveEditActivitySchedule(RefNo, false, BidDocPreparationDate2, MthdApprovalDate2, AdvertDate2, BidSubmissionDate2, BidOpeningDate2, BidValidityExpiryDate2, BidSecurityExpiryDate2, EvalRptReadyDate2, CCERApprovalDate2, NRReportReadyDate2, NRApprovalDate2, BEBNoticeDate2, BoardPaperSubmissionDate2, BoardApprovalDate2, SGPaperSubmissionDate2, SGApprovalDate2, FundsAvailDate2, LPODate2, ContractPreparationDate2, ContractSigningDate2, PerfSecurityExpDate2, ContractAmount2, ContractCompletionDate2, ReceiptOfPaymentDocDate2, FinanceSubmissionDate2, PaymentDate2, FileClosureDate2, prebidmeeting2);

                ShowMessage("Activity Schedule Successfully updated ....");
            }
        }
    }
    private void SaveStatus()
    {
        Process.SaveUpdateScheduleStatus(txtPRNumber.Text.Trim(), Session["UserID"].ToString(), "20", "No comment....");
    }
    private void SetFocus(TextBox ctrl)
    {
        ctrl.Focus();
    }
    
    private void ResetMainData()
    {
        txtPRNumber.Text = "";
        cboProcMethod.SelectedValue = "0";
        cboCompany.SelectedValue = "1";
        txtProcDescription.Text = "";
        cboFunding.SelectedValue = "0";
        cboProcMethod.SelectedValue = "0";
        txtEstimatedCost.Text = "";
       //  cboPreparedBy.SelectedValue = "0";
       // cboResponsibleOfficer.SelectedValue = "0";
        cboPDUHead.SelectedValue = "0";
        txtDateAssigned.Text = "";
        txtPreparationDate.Text = "";
       // txtCummulativePeriod.Text = "";
       // txtCummulativeByConstractSigning.Text = "";
        txtPRNumber.Focus();
    }
    /// <summary>
    /// Reset the Scheduled Dates
    /// </summary>
    private void ResetScheduleDetails()
    {
        txtBidDocPrepDate.Text = "";
        txtMtdApprovalDate.Text = "";
        txtAdvertDate.Text = "";
        txtBidSubmissionDate.Text = "";
        txtBidOpeningDate.Text = "";
        txtBidValidityExpiryDate.Text = "";
        txtBidSecurityExpiryDate.Text = "";
        txtEvalRptReadyDate.Text = "";
        txtCCERApprovalDate.Text = "";
        txtNRReportReadyDate.Text = "";
        txtCCNRApprovalDate.Text = "";
        txtBEBNoticeDate.Text = "";
        txtBoardPaperSubmissionDate.Text = "";
        txtBoardApprovalDate.Text = "";
        txtSGPaperSubmissionDate.Text = "";
        txtSGApprovalDate.Text = "";
        txtFundsAvailDate.Text = "";
        txtLPODate.Text = "";
        txtContractSigningDate.Text = "";
        txtPerfSecurityExpDate.Text = "";
        // txtContractAmount.Text = "";
        txtContractCompletionDate.Text = "";
        txtReceiptOfPaymentDocDate.Text = "";
        txtFinanceSubmissionDate.Text = "";
        txtPaymentDate.Text = "";
        txtFileClosureDate.Text = "";
        txtContractAmount.Text = "0";
        txtContractPrepDate.Text = "";
        txtprebidmeeting.Text = "";

        txtBidDocPrepDate2.Text = "";
        txtMtdApprovalDate2.Text = "";
        txtAdvertDate2.Text = "";
        txtBidSubmissionDate2.Text = "";
        txtBidOpeningDate2.Text = "";
        txtBidValidityExpiryDate2.Text = "";
        txtBidSecurityExpiryDate2.Text = "";
        txtEvalRptReadyDate2.Text = "";
        txtCCERApprovalDate2.Text = "";
        txtNRReportReadyDate2.Text = "";
        txtCCNRApprovalDate2.Text = "";
        txtBEBNoticeDate2.Text = "";
        txtBoardPaperSubmissionDate2.Text = "";
        txtBoardApprovalDate2.Text = "";
        txtSGPaperSubmissionDate2.Text = "";
        txtSGApprovalDate2.Text = "";
        txtFundsAvailDate2.Text = "";
        txtLPODate2.Text = "";
        txtContractSigningDate2.Text = "";
        txtPerfSecurityExpDate2.Text = "";
        // txtContractAmount.Text = "";
        txtContractCompletionDate2.Text = "";
        txtReceiptOfPaymentDocDate2.Text = "";
        txtFinanceSubmissionDate2.Text = "";
        txtPaymentDate2.Text = "";
        txtFileClosureDate2.Text = "";
        txtContractAmount2.Text = "0";
        txtContractPrepDate2.Text = "";
        txtprebidmeeting2.Text = "";
    }
    protected void cboProcMethod_DataBound(object sender, EventArgs e)
    {
        cboProcMethod.Items.Insert(0, new ListItem(" -- Select Procurement Method -- ", "0"));
    }

    protected void cboFunding_DataBound(object sender, EventArgs e)
    {
        cboFunding.Items.Insert(0, new ListItem(" -- Select Funding Source -- ", "0"));
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (rbnApproval.SelectedIndex == -1)
        {
            ShowMessage("Please Approve / Reject Evaluation...");
        }
        else if (rbnApproval.SelectedValue.ToString().Equals("39") && txtComment.Text == "")
        {
            ShowMessage("Please Provide A Comment For Rejection ...");
        }
        else
        {
            string Comment = txtComment.Text.Trim();
            string Item = txtProcDescription.Text.Trim();

            string ApprovalStatus = "Accepted";

            int status = int.Parse(rbnApproval.SelectedValue.ToString());
            int access = int.Parse(Session["AccessLevelID"].ToString());

            if (access.Equals(3))
            {
                if (rbnApproval.SelectedIndex.Equals(1))// this is a rejection
                {
                    status = 39;
                }
            }
            else if (access.Equals(17))
            {
                if (rbnApproval.SelectedIndex.Equals(1))// this is a rejection
                {
                    status = 125;
                }
            }

            if (rbnApproval.SelectedValue == "39" || rbnApproval.SelectedValue == "125")
                ApprovalStatus = "Rejected";

            Process.LogandCommitRequisition(lblreqn.Text.Trim(), status, txtComment.Text.Trim());
            string reference = Process.GetRequisitionDetailsByPDCode(lblreqn.Text.Trim()).Rows[0]["ScalaPRNumber"].ToString();
            if (status.Equals(36))// evaluation approved by MD and contract needs to be sent to the supplier
            {
                DataTable selectedbidderdetails = Process.GetSelectedBidderDetails(reference);
                if (selectedbidderdetails.Rows.Count>0)
                {
                    string bideremail = selectedbidderdetails.Rows[0]["EmailAddress"].ToString();
                    string biddername = selectedbidderdetails.Rows[0]["CompanyName"].ToString();
                    string By = HttpContext.Current.Session["FullName"].ToString();
                    string Message = "<p>Your Bid for [" + Item + "] that you submitted  has been " + ApprovalStatus + "</p> and please login to the procurement portal to dowload the offer letter and a contract";
                    Message += "For more details, please access the link: http://192.168.8.110/Procurement/  to Login.";
                    ProcessOther.NotifyBidder(By, "NOTIFICATION TO DOWNLOAD CONTRACT", biddername, bideremail, Message);
                }
            }
            else
            {
                // Notify Responsible Officer
                int OfficerID = Convert.ToInt32(Session["Officer"].ToString());

                lblSuccess.Text = "Te Evaluation of " + Item + "]  has been " + ApprovalStatus;

                string Message = "<p>Bid Evaluation for [" + Item + "] that you submitted for approval has been " + ApprovalStatus + "</p> and Sent to MD for approval";
                Message += "<p>Comment: " + Comment + "</p>";
                Message += "For more details, please access the link: http://192.168.8.110/Procurement/  to Login.";
                string By = HttpContext.Current.Session["FullName"].ToString();
                ProcessOther.NotifyManager(By, Item, OfficerID, Message);
                if (rbnApproval.SelectedValue.Equals("45"))
                {
                    ShowMessage("Evaluation has been sccessful .....");
                }
                ResetMainData();
                MultiView1.ActiveViewIndex = 2;
                rbnApproval.SelectedIndex = -1;
            }
            
        }
    }

    
    protected void cboPDUHead_DataBound(object sender, EventArgs e)
    {
        cboPDUHead.Items.Insert(0, new ListItem("-- Please Select PDU Head --", "0"));
    }

    protected void btnShowDetails_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("BidEvaluation.aspx", true);
    }
}
