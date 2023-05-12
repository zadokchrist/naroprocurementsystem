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

public partial class Requisition_OfficerViewItems : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOthers = new ProcessPlanning();
private BusinessPlanning bll2 = new BusinessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    ProcessBidding bidd = new ProcessBidding();
    DataTable datatable = new DataTable();
    DataLogin data = new DataLogin();
    DataSet dataSet = new DataSet();
    DataTable dtable = new DataTable();
    DataTable dtUpdate = new DataTable();
    private string Status = "23";
    int ProcMethod, ProcTypeCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
               if (Request.QueryString["transferid"] != null)
                {
                    string StatusToSelect = Request.QueryString["transferid"].ToString();
                    cboCostCenters.SelectedIndex = cboCostCenters.Items.IndexOf(cboCostCenters.Items.FindByValue(StatusToSelect));
                }
                LoadAreas();
                LoadItems();
                LoadProcurementMethods();
                LoadProcurementTypes();
                LoadFundingSource();
                LoadPDUMembers();
                LoadPDUSupervisors();
                LoadDocumentTypes();
                LoadBidderChoiceReasons(2);
                MultiView1.ActiveViewIndex = 0;
                MultiView2.ActiveViewIndex = -1;
                Submit.ActiveViewIndex = -1;

            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadBidderChoiceReasons(int Type)
    {
        cboReason.DataSource = bidd.GetBidderReasons(Type);
        cboReason.DataTextField = "Reason";
        cboReason.DataValueField = "ID";
        cboReason.DataBind();
    }

    private void LoadDocumentTypes()
    {
        cboDocType.DataSource = bidd.GetOfficerDocTypes();
        cboDocType.DataValueField = "DocumentTypeID";
        cboDocType.DataTextField = "DocumentType";
        cboDocType.DataBind();
    }
    private void LoadFundingSource()
    {
        cboFunding.DataSource = ProcessOthers.GetFundSources();
        cboFunding.DataValueField = "Code";
        cboFunding.DataTextField = "Source";
        cboFunding.DataBind();
    }

    private void LoadProcurementMethods()
    {
        cboProcurementMethod.DataSource = ProcessOthers.GetProcurementMethods();
        cboProcurementMethod.DataValueField = "MethodCode";
        cboProcurementMethod.DataTextField = "Method";
        cboProcurementMethod.DataBind();
    }

    private void LoadProcurementTypes()
    {
        cboProcType.DataSource = ProcessOthers.GetProcurementTypes();
        cboProcType.DataValueField = "Code";
        cboProcType.DataTextField = "Type";
        cboProcType.DataBind();
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
            datatable = Process.GetProcSPHead();
            cboPDUHead.DataSource = datatable;
            cboPDUHead.DataValueField = "UserID";
            cboPDUHead.DataTextField = "FullName";
            cboPDUHead.DataBind();
            //datatable = Process.GetProcPMOfficers();
            //cboSupervisor.DataSource = datatable;
            //cboSupervisor.DataValueField = "UserID";
            //cboSupervisor.DataTextField = "FullName";
            //cboSupervisor.DataBind();

        }
        else if (Session["AccessLevelID"].ToString() == "1026")
        {
            //Load destinations for Large procurement
            datatable = Process.GetProcLPHead();
            cboPDUHead.DataSource = datatable;
            cboPDUHead.DataValueField = "UserID";
            cboPDUHead.DataTextField = "FullName";
            cboPDUHead.DataBind();
            //datatable = Process.GetProcLPHead();
            //cboSupervisor.DataSource = datatable;
            //cboSupervisor.DataValueField = "UserID";
            //cboSupervisor.DataTextField = "FullName";
            //cboSupervisor.DataBind();
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
    private void LoadCostCenters(int AreaID)
    {
        string AreaCode = AreaID.ToString();
        datatable = ProcessOthers.GetCostCentersByName("", AreaCode);
        cboCostCenters.DataSource = datatable;
        cboCostCenters.DataValueField = "CostCenterID";
        cboCostCenters.DataTextField = "CostCenterDesc";
        cboCostCenters.DataBind();
    }
    private void LoadItems()
    {
        string RecordID = "0";
        string StartDate = txtStartDate.Text.Trim();
        string EndDate = txtEndDate.Text.Trim();
        string CostCenterCode = cboCostCenters.SelectedValue.ToString();
        string AreaCode = cboAreas.SelectedValue.ToString();
        string PrNumber = txtPrNumber.Text.Trim();
        datatable = Process.GetOfficerItems(RecordID,PrNumber, StartDate, EndDate, Status, AreaCode, CostCenterCode);
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
            string EmptyMessage = "No New requisition(s) in the system from Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
            EmptyMessage += "from " + bll.ReturnDate(StartDate, 1).ToString("dd-MMM-yyyy") + " to " + bll.ReturnDate(EndDate, 2).ToString("dd-MMM-yyyy");
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
   
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            string RecordID = e.Item.Cells[0].Text;
            string PD_Code = e.Item.Cells[1].Text;
            string Desc = e.Item.Cells[3].Text;
            string PRNumber = e.Item.Cells[2].Text;
           if (e.CommandName == "btnFiles")
            {
                lblPD_Code.Text = PD_Code;
                lblHeaderMsg.Text = Desc;
                btnOK.Enabled = false;
                txtStartDate.Enabled = false;
                txtEndDate.Enabled = false;
                cboCostCenters.Enabled = false;
                LoadDocuments();
            }
            else if (e.CommandName == "btnPrint")
            {
                Session["Center"] = cboCostCenters.SelectedValue.ToString();
                lblPD_Code.Text = PD_Code;
                //LoadReport();
                try
                {
                    PrintReport();
                }
                catch (Exception ex)
                {
                    ShowMessage(ex.Message);
                }
            }
            else if (e.CommandName == "btnPrintStatus")
            {
                Session["Center"] = cboCostCenters.SelectedValue.ToString();
                lblPD_Code.Text = PD_Code;
                LoadStatusReport();
            }
            else if (e.CommandName == "btnActivitySchedule")
            {
                // Response.Redirect("Requisition_ActivitySchedule.aspx?PR=" + PRNumber, true);
                MultiView1.ActiveViewIndex = 5;
                txtPRNumber2.Text = PRNumber;
                GetPRDetails();
               // LoadBidDocuments();
                

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
    private void GetPRDetails()
    {
        try
        {
            string PRNumber = txtPRNumber2.Text.Trim();
            if (!this.IsValidPRNumber(PRNumber))
            {
                ShowMessage("Please provide the PR Number (Valid).....");
            }
            else
            {
              
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
                    txtCost.Text = Convert.ToDouble(dtData.Rows[0]["RequisitionedAmount"].ToString()).ToString("#,##0");
                    lblPD_Code.Text = dtData.Rows[0]["PD_Code"].ToString();
                    ProcTypeCode = int.Parse(dtData.Rows[0]["ProcurementTypeID"].ToString());
                    cboProcType.SelectedValue = dtData.Rows[0]["ProcurementTypeID"].ToString();
                    cboFunding.SelectedValue = dtData.Rows[0]["FundingSource"].ToString();

                    String comp = dtData.Rows[0]["PDUCategory"].ToString();
                    String lvl = Session["AccessLevelID"].ToString();
                    if (comp == "0")
                    {
                        if (lvl == "4")
                            comp = "1";
                        else if (lvl == "1026")
                            comp = "2";
                    }
                    cboCompany.SelectedValue = comp;


                    txtDateAssigned.Text = dtData.Rows[0]["AssignedDate"].ToString().Replace("Jul  1 2011 ", "");
                    txtPreparationDate.Text = DateTime.Today.ToString();
                    if(dtData.Rows[0]["PDUSupervisor"].ToString()!="")
                        cboPDUHead.SelectedValue = dtData.Rows[0]["PDUHead"].ToString();
                    cboSupervisor.SelectedValue = dtData.Rows[0]["PDUHead"].ToString();
                    txtStartDate.Text = dtData.Rows[0]["BIDDocPrepDate"].ToString();
                    txtBidStartDate.Text = dtData.Rows[0]["BidInvitationDate"].ToString();
                    txtBidEndDate.Text = dtData.Rows[0]["BidSubmissionDate"].ToString();
                    txtCummulativePeriod.Text = dtData.Rows[0]["CumulativePeriod"].ToString();
                    // Cummulative Period - Based on File Closure Date ( Now/File Closure Date - Date Assigned) - + Contract Signing Date

                    txtEOIEnd.Text = dtData.Rows[0]["EOIend"].ToString().Replace("Jul  1 2011 ", "");
                    txtEOIStart.Text = dtData.Rows[0]["EOIstart"].ToString().Replace("Jul  1 2011 ", "");
                    lblreqn.Text = dtData.Rows[0]["PD_Code"].ToString();
                    txtStart.Text = dtData.Rows[0]["BidInvitationDate"].ToString();


                    double amount = Convert.ToDouble(txtCost.Text);
                    string SelectedType = dtData.Rows[0]["ProcurementTypeID"].ToString();

                    LoadProcMethod(amount, SelectedType);

                    cboProcurementMethod.SelectedValue = dtData.Rows[0]["ProcurementMethod"].ToString();

                    Session["proc"] = ProcTypeCode;
                    if( ProcTypeCode == 3 || ProcTypeCode == 5){ //Goods and works

                        MultiView2.ActiveViewIndex = -1;
                        txtEOIStart.Visible = true;
                        txtEOIEnd.Visible = true;
                        lblEOIStart.Visible = true;
                        lblEOIEnd.Visible = true;
                    }
                    else if (ProcTypeCode == 2)// consultancy
                    {
                        MultiView2.ActiveViewIndex = 0;
                        txtEOIStart.Visible = false;
                        txtEOIEnd.Visible = false;
                        lblEOIStart.Visible = false;
                        lblEOIEnd.Visible = false;
                    }
                    else //Consultancy
                    {
                        MultiView2.ActiveViewIndex = 0;
                        txtEOIStart.Visible = false;
                        txtEOIEnd.Visible = false;
                        lblEOIStart.Visible = false;
                        lblEOIEnd.Visible = false;
                    }
                    CreateBiddersDataTable();
                    string procmethod = cboProcurementMethod.SelectedValue;
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

                    LoadDocuments2();
                    LoadBidderSubCategories(ProcTypeCode);
                    LoadBidderCategories(ProcTypeCode);
                    Submit.ActiveViewIndex = 0;
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
            string ProcMethod = ProcessOthers.GetProcurementMethod(ProcTypeSelected, amount).ToString();
            cboProcurementMethod.SelectedIndex = cboProcurementMethod.Items.IndexOf(cboProcurementMethod.Items.FindByValue(ProcMethod));
            cboProcurementMethod.Enabled = true;
            //LoadProcLength(ProcMethod);
        }
        else
        {
            cboProcurementMethod.Items.Clear();
            cboProcurementMethod.Enabled = true;
            datatable = ProcessOthers.GetProcMethodsForBig(ProcType, amount);
            cboProcurementMethod.DataSource = datatable;
            cboProcurementMethod.DataValueField = "MethodCode";
            cboProcurementMethod.DataTextField = "Method";
            cboProcurementMethod.DataBind();
            cboProcurementMethod.SelectedIndex = cboProcurementMethod.Items.IndexOf(cboProcurementMethod.Items.FindByValue("0"));

        }

    }
    private void CallValidation()
    {
        string procType = Session["proc"].ToString();
        int ProcurementMethod = Convert.ToInt32(cboProcurementMethod.SelectedValue.ToString());

        if (txtPRNumber2.Text == "")
        {
            ShowMessage("The PR Number is required......");
        }
        else if (txtStart.Text == "")
        {

            ShowMessage("Start date is required......");
        } else if (GridView2.Rows.Count < 1)
        {
            ShowMessage("Upload necessary attachments.....");
        }
        else if (txtBidStartDate.Text == "" && txtStart.Text == "")
        {

            ShowMessage("Bid solicitation start date is required......");
        }
        else if (txtBidEndDate.Text == "")
        {

            ShowMessage("Bid solicitation end date is required......");
        }
        //else if (txtEOIEnd.Text=="" && (procType == "2" || procType == "3" || procType == "5"))
        //{
        //    ShowMessage("EOI end date is required......");
        //}
        //else if (txtEOIEnd.Text == "" && (procType == "2" || procType == "3" || procType == "5"))
        //{
        //    ShowMessage("EOI start date is required......");
        //}
        else if (chkSubmit.Checked && GridView2.Rows.Count < 1 && (procType == "2" || procType == "3" || procType == "5"))
        {
            ShowMessage("Upload draft EOI");
        }
        else if (DataGrid2.Items.Count < 3 && (ProcurementMethod == 4 || ProcurementMethod == 5))
        {
            ShowMessage("Minimum of 3 bidders required");
        }
        else if (advertised.SelectedValue.Equals("2") && DataGrid2.Items.Count < 3)
        {
            ShowMessage("Minimum of 3 bidders required");
        }
        else if (advertised.SelectedValue.Equals(null))
        {
            ShowMessage("Please select whether the job is for advertisement");
        }
        else
        {
            string RefNo = txtPRNumber2.Text.Trim();
            txtBidStartDate.Text = txtStart.Text;
            double ContractAmount = Convert.ToDouble(txtCost.Text.Replace(",", "")); //revisit
            if (procType == "2" || procType == "3" || procType == "5")
            {
                txtEOIEnd.Text = txtStart.Text;
                txtEOIEnd.Text = txtEndDate.Text;
            }

            if (cboCompany.SelectedValue == "0")
            {
                ShowMessage("Please choose the Procurement entity you belong to ....");
            }
            else
            {
                string SubjectOfProcurement = txtProcDescription.Text;
                int ResponsibleOfficer = Convert.ToInt32(Session["UserID"].ToString());
                
                int FundingSource = Convert.ToInt32(cboFunding.SelectedValue.ToString());
                int PreparedBy = Convert.ToInt32(Session["UserID"].ToString());
                int PDUHead = Convert.ToInt32(cboPDUHead.SelectedValue.ToString());
                DateTime DatePrepared = bll.ReturnDate(txtPreparationDate.Text.Trim(), 1);
                DateTime DateAssigned = bll.ReturnDate(txtDateAssigned.Text.Trim(), 1);
                DateTime startDate = bll.ReturnDate(txtStartDate.Text.Trim(), 1);
                DateTime BidInvitationDate = bll.ReturnDate(txtBidStartDate.Text.Trim(), 1);
                DateTime BidSubmissionDate = bll.ReturnDate(txtBidEndDate.Text.Trim(), 1);
                DateTime BidOpeningDate = bll.ReturnDate(txtPreparationDate.Text.Trim(), 1);
                DateTime EOIstart = bll.ReturnDate(txtEOIStart.Text.Trim(), 1);
                DateTime EOIend = bll.ReturnDate(txtEOIEnd.Text.Trim(), 1);
                string CummulativePeriod = txtCummulativePeriod.Text.Trim();
                int PDUCategory = Convert.ToInt32(cboCompany.SelectedValue.ToString());
                bool Submitted = Convert.ToBoolean(chkSubmit.Checked);

                Process.UpdateAdvertType(lblPD_Code.Text.Trim(), advertised.SelectedValue);
                Process.SaveEditActivityScheduleHead(RefNo, SubjectOfProcurement, ContractAmount, ProcurementMethod, FundingSource, PreparedBy,
                    PDUHead, DateAssigned, DatePrepared, ResponsibleOfficer, PDUCategory, Submitted, CummulativePeriod);

                //DataTable reqtrack = Process.GetRequisitionAssignmentRecord(RefNo);
                //if (reqtrack.Rows.Count>0)
                //{
                //    string assignee = reqtrack.Rows[0]["AssignedTo"].ToString();//HttpContext.Current.Session["UserID"];
                //    string assignedto = reqtrack.Rows[0]["@Assignee"].ToString();
                //    Process.UpdateRecordAssignment(assignee, assignedto, RefNo);
                //}

                Process.SaveEditActivitySchedule2(RefNo, 0, BidInvitationDate, BidSubmissionDate, BidOpeningDate, ContractAmount, startDate,EOIstart, EOIend);
            
                //Check conditions for submitting
                

                // Notify Supervisor if submitted
                string Message = "";
                if (chkSubmit.Checked == true)
                {
                    
                    string UserID = Session["UserID"].ToString();
                    procType = Session["proc"].ToString();
                    int status = 26; // Send method, docs & bidders to supervisor
                    string item = "Activity Plan";

                    if (procType == "2" || procType == "3" || procType == "5")//
                    {
                       
                            status = 33; //Send draft EOI to supervisor
                            item = "Draft EOI";
                        
                    }

                    if (ProcurementMethod == 4 || ProcurementMethod == 5)
                    {
                            saveBidderList();
                        
                    }

                    if (advertised.SelectedValue.Equals("2"))
                    {
                        saveBidderList();
                    }

                   
                        Process.LogandCommitRequisition(lblPD_Code.Text.Trim(), status, item + " Sent to Procurement Supervisor");
                        Message = item+" saved And submitted for Approval ";
                    //ShowMessage(Message);
                        int ManagerID = Convert.ToInt32(cboPDUHead.SelectedValue.ToString());
                    Message = Message+ " to "+cboPDUHead.SelectedItem.Text;
                    ShowMessage(Message);
                    string Msg = "<p>Hello " + cboPDUHead.SelectedItem.Text + ", </p> <p> You have been sent a "+item+" for Approval.</p> ";
                        Msg += "<p>For more details, please access the link: http://192.168.8.110/Procurement/  to Login.</p>";
                        string By = HttpContext.Current.Session["FullName"].ToString();
                    ProcessPlanning plan = new ProcessPlanning();
                    plan.NotifyManager(By, SubjectOfProcurement, ManagerID, Msg);
                    


                }
                else
                {
                     procType = Session["proc"].ToString();
                    int status = 27; // Saved method, docs & bidders
                    string item = "Activity Plan";
                    if (procType == "2" || procType == "3" || procType == "5")
                    {
                        status = 30; //Save draft EOI
                        item = "Draft EOI";
                    }
                    if (ProcurementMethod == 4 || ProcurementMethod == 5)
                    {
                        saveBidderList();
                    }
                    Process.LogandCommitRequisition(lblPD_Code.Text.Trim(), 30, item + " Saved By Procurement Officer");
                    ShowMessage(item + " has been successfully saved ");
                                    }


                LoadItems();
                MultiView1.ActiveViewIndex = 0;
                MultiView2.ActiveViewIndex = -1;
                Submit.ActiveViewIndex = -1;
            }
        }
    }

    private void saveBidderList()
    {
        dtUpdate = (DataTable)Session["dtBidders"];
        ShowMessage2("."); ShowMessage(".");
        if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Potential Bidders Before Submission");
        }
        else
        {
            Session["dtBidders"] = dtUpdate;
            DataTable dtBidders = (DataTable)Session["dtBidders"];
            int StatusID = Convert.ToInt32(lblStatusID.Text);
            string CreatedBy = Session["UserID"].ToString();

            string Response = bidd.SavePotentialBidders(Label5.Text.Trim(), txtPRNumber2.Text.Trim(), dtBidders, CreatedBy, int.Parse(cboProcurementMethod.SelectedValue.ToString().Trim()), int.Parse(cboProcType.SelectedValue.ToString().Trim()));
            btnPrint.Enabled = true;
        
            ShowMessage(Response);
            MultiView1.ActiveViewIndex = 1;
        }
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnRemove")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridView2.DataKeys[intIndex].Value);
                bidd.RemoveDocument(FileCode);
                LoadDocuments2();
            }
            else
            {
                // View 
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridView2.DataKeys[intIndex].Value);
                string Path = bidd.GetDocumentPath(FileCode);
                bidd.DownloadFile(Path, true);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadBidDocuments()
    {
        // MultiView1.ActiveViewIndex = 7;
        string RefNo = lblAttachRefNo.Text.Trim();
        datatable = bidd.GetBiddingDocuments2(RefNo, 8);
        if (datatable.Rows.Count > 0)
        {
            GridView2.DataSource = datatable;
            GridView2.DataBind();
            GridView2.Visible = true;
            Label6.Visible = false;
        }
        else
        {
            Label6.Visible = true;
            GridView2.Visible = false;
        }
    }

    protected void cboFunding_DataBound(object sender, EventArgs e)
    {
        cboFunding.Items.Insert(0, new ListItem("-- Select Funding Source --", "0"));
    }

    protected void cboProcurementMethod_DataBound(object sender, EventArgs e)
    {
       cboProcurementMethod.Items.Insert(0, new ListItem("-- Select Procurement Method --", "0"));
    }
    private void LoadReport()
    {
        string PD_Code = lblPD_Code.Text.Trim();
        datatable = Process.GetRequisitionDetailform20(PD_Code);
        if (datatable.Rows.Count > 0)
        {
            btnOK.Enabled = false;
            cboCostCenters.Enabled = false;
            MultiView1.ActiveViewIndex = 3;
            string appPath, physicalPath, rptName;
            appPath = HttpContext.Current.Request.ApplicationPath;
            physicalPath = HttpContext.Current.Request.MapPath(appPath);
            rptName = physicalPath + "\\Bin\\Reports\\Requisitioning.rpt";
            //doc.Load(rptName);
            //doc.SetDataSource(datatable);
            //Hidetoolbar();
            //CrystalReportViewer1.ReportSource = doc;
            btnPrint.Enabled = true;
        }
        else
        {
            btnPrint.Enabled = false;
        }
    }
    private void LoadStatusReport()
    {
        string PD_Code = lblPD_Code.Text.Trim();
        datatable = Process.GetReportLogs(PD_Code);
        if (datatable.Rows.Count > 0)
        {
            string appPath, physicalPath, rptName;
            appPath = HttpContext.Current.Request.ApplicationPath;
            physicalPath = HttpContext.Current.Request.MapPath(appPath);
            rptName = physicalPath + "\\Bin\\Reports\\PRStatus.rpt";
            //doc.Load(rptName);
            //doc.SetDataSource(datatable);
            //Hidetoolbar();
            //CrystalReportViewer2.ReportSource = doc;
            btnPrintStatus.Enabled = true;
            MultiView1.ActiveViewIndex = 4;
        }
        else
            btnPrintStatus.Enabled = false;
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
    }
    private void LoadDocuments()
    {
        MultiView1.ActiveViewIndex = 2;
        string PD_Code = lblPD_Code.Text.Trim();
        datatable = ProcessOthers.GetPlanDocuments("", PD_Code);
        if (datatable.Rows.Count > 0)
        {
            GridAttachments.DataSource = datatable;
            GridAttachments.DataBind();
            GridAttachments.Visible = true;
            lblmsg.Visible = false;
        }
        else
        {
            lblmsg.Visible = true;
            GridAttachments.Visible = false;
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        try 
        {
            MultiView1.ActiveViewIndex = 0;
            MultiView2.ActiveViewIndex = -1;
            Submit.ActiveViewIndex = -1;
            cboCostCenters.Enabled = true;
            btnOK.Enabled = true;
            txtStartDate.Enabled = true;
            txtEndDate.Enabled = true;
            LoadItems();
            lblPD_Code.Text = "0";
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void GridAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnRemove")
            {
            }
            else
            {
                // View 
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridAttachments.DataKeys[intIndex].Value);
                string Path = ProcessOthers.GetDocumentPath(FileCode);
                DownloadFile(Path, true);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void DownloadFile(string path, bool forceDownload)
    {
        string name = Path.GetFileName(path);
        string ext = Path.GetExtension(path);
        string type = "";
        // set known types based on file extension  
        if (ext != null)
        {
            switch (ext.ToLower())
            {
                case ".htm":
                case ".html":
                    type = "text/HTML";
                    break;

                case ".txt":
                    type = "text/plain";
                    break;
                case ".docx":
                case ".doc":
                case ".rtf":
                    type = "Application/msword";
                    break;
                case ".xls":
                case ".xlsx":
                    type = "Application/vnd.ms-excel";
                    break;
                case ".pdf":
                    type = "Application/pdf";
                    break;
            }
        }
        if (forceDownload)
        {
            Response.AppendHeader("content-disposition",
                "attachment; filename=" + name);
        }
        if (type != "")
            Response.ContentType = type;
        Response.WriteFile(path);
        Response.End();
    }
    
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
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
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        try
        {
            PrintReport();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void PrintReport()
    {
        LoadReport();
        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
        //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Requisition.pdf");
    }
    protected void btnreturn_Click(object sender, EventArgs e)
    {
        try
        {
            btnOK.Enabled = true;
            cboCostCenters.Enabled = true;
            string PreviousCenter = Session["Center"].ToString();
            cboCostCenters.SelectedIndex = cboCostCenters.Items.IndexOf(cboCostCenters.Items.FindByValue(PreviousCenter));
            LoadItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
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

    protected void Page_Unload(object sender, EventArgs e)
    {
        //if (doc != null)
        //{
        //    doc.Close();
        //    doc.Dispose();
        //}
    }

    protected void btnPrintStatus_Click(object sender, EventArgs e)
    {
        try
        {
            PrintStatusReport();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void PrintStatusReport()
    {
        LoadStatusReport();
        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
        //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Requisition Status.pdf");

    }

    protected void txtStart_TextChanged(object sender, EventArgs e)
    {
        try
        {
            String start = txtStart.Text;
            DateTime startdate = bll.ReturnDate(start.Trim(), 1);
            String procmthd = cboProcurementMethod.SelectedValue;
            if(startdate < DateTime.Now.AddDays(-1))
            {
                ShowMessage("Select a valid start date");
            }else
            {
                ProcessPlanning plan = new ProcessPlanning();
                int len= plan.GetProcurementLength(procmthd);

                DateTime end = startdate.AddMonths(len+1);
                DateTime bidStart = startdate.AddMonths(1);
                txtBidEndDate.Text = end.ToLongDateString();
                txtBidStartDate.Text = bidStart.ToLongDateString();
                TimeSpan period = end.Subtract(startdate);
                string per = period.TotalDays.ToString();
                txtCummulativePeriod.Text = per;
                ShowMessage(".");
            }
        }
        catch(Exception ex)
        {

        }
    }

    protected void txtBidStartDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            String start = txtBidStartDate.Text;
            DateTime startdate = bll.ReturnDate(start.Trim(), 1);
            String procmthd = cboProcurementMethod.SelectedValue;
            if (startdate < DateTime.Now.AddDays(-1))
            {
                ShowMessage("Select a valid start date");
            }
            else
            {
                ProcessPlanning plan = new ProcessPlanning();
                int len = plan.GetProcurementLength(procmthd);

                DateTime end = startdate.AddMonths(len);
                txtBidEndDate.Text = end.ToLongDateString();
                TimeSpan period = end.Subtract(startdate);
                string per = period.TotalDays.ToString();
                txtCummulativePeriod.Text = per;
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void Button6_Click(object sender, EventArgs e)
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

    protected void chkSubmit_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSubmit.Checked)
        {
            btnSubmit.Text = "SUBMIT";
        }
        else
        {
            btnSubmit.Text = "SAVE";
        }
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
        cboBIdderSubcat.DataSource = bidd.GetBidderSubCategoriesByProcType(type);
        cboBIdderSubcat.DataTextField = "subCategoryName";
        cboBIdderSubcat.DataValueField = "BiddersubcategoryID";
        cboBIdderSubcat.DataBind();
    }

    private void LoadProcCategoryBidders(int procTypeCode)
    {
       // CreateBiddersDataTable();
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

        int ProcType = type;
        LoadBidderCategories(ProcType);
        LoadBidderCategories(ProcType);
        LoadBidderSubCategories(ProcType);
        int Category = Convert.ToInt32(cboBidderCategory.SelectedValue);
        int subCategory = int.Parse(cboBIdderSubcat.SelectedValue);
        datatable = bidd.GetSuppliersByCategory(ProcType, Category, subCategory);

        ddlBidders.DataSource = datatable;
        ddlBidders.DataTextField = "CompanyName";
        ddlBidders.DataValueField = "BidderID";
        ddlBidders.DataBind();

        int start = 1;
        CreateBiddersDataTable();
        if (datatable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in datatable.Rows)
            {
                long ShortlistID = start;
                DateTime DateCreated = DateTime.Today;
                long BidderID = Convert.ToInt64(dr["BidderID"].ToString());
                string Bidder = dr["CompanyName"].ToString();
                long ProposedByID = 0;
                string ProposedBy = cboCompany.SelectedItem.ToString();
                lblCreatedBy.Text = ProposedByID.ToString();
                int ReasonID = 1;
                string Reason = "";
                string OtherReason = "";
                dtUpdate.Rows.Add(new object[] { ShortlistID, DateCreated.ToShortDateString(), BidderID, Bidder, ProposedByID, ProposedBy, ReasonID, Reason, OtherReason });
                start++;
            }
            Session["dtBidders"] = dtUpdate;
            DataGrid2.DataSource = dtUpdate;
            DataGrid2.DataBind();
            DataGrid2.Visible = true;
            btnPrint2.Enabled = true;
           
        }
    }

    private void LoadBidderCategories(int proctype)
    {
        int type = 0;
        switch (proctype)
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

        cboBidderCategory.DataSource = bidd.GetBidderCategoriesByProcType(type);
        cboBidderCategory.DataTextField = "CategoryName";
        cboBidderCategory.DataValueField = "BiddercategoryID";
        cboBidderCategory.DataBind();



    }

    private void LoadShortlistedBidders(string PRNumber)
    {
        
        datatable = bidd.GetShortlistedBidderDetails(PRNumber);
        if (datatable.Rows.Count > 0)
        {
            dtUpdate.Rows.Clear();
            foreach (DataRow dr in datatable.Rows)
            {
                long ShortlistID = Convert.ToInt64(dr["ShortlistID"].ToString()); DateTime DateCreated = Convert.ToDateTime(dr["DateCreated"].ToString());
                long BidderID = Convert.ToInt64(dr["BidderID"].ToString()); string Bidder = dr["CompanyName"].ToString();
                long ProposedByID = Convert.ToInt64(dr["ProposedByID"].ToString()); string ProposedBy = cboCompany.SelectedItem.ToString();
                lblCreatedBy.Text = ProposedByID.ToString();
                int ReasonID = Convert.ToInt32(dr["ReasonID"].ToString()); string Reason = dr["Reason"].ToString(); string OtherReason = dr["OtherReason"].ToString();
                dtUpdate.Rows.Add(new object[] { ShortlistID, DateCreated.ToShortDateString(), BidderID, Bidder, ProposedByID, ProposedBy, ReasonID, Reason, OtherReason });
            }
            Session["dtBidders"] = dtUpdate;
            DataGrid2.DataSource = dtUpdate; DataGrid2.Visible = true;
            DataGrid2.DataBind(); btnPrint2.Enabled = true;
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
            if (ddlBidders.SelectedItem.Value == "0")
                ShowMessage("Please Select Potential Bidders");
            //else if (String.IsNullOrEmpty(txtProposedBy.Text.Trim()))
            //    ShowMessage2("Please Select From the List of Users After Typing One or More Letters");
            else if (cboReason.SelectedValue == "0")
                ShowMessage("Please Select Reason For Selection Of Bidder");
            else if (cboReason.SelectedItem.ToString() == "Other" && String.IsNullOrEmpty(txtReason.Text.Trim()))
                ShowMessage("Please Enter Reason For Selection of Bidder");
            else
            {
                DateTime DateCreated = DateTime.Now;
                string Bidder = ddlBidders.SelectedItem.Text;
                string ProposedBy = cboCompany.SelectedItem.ToString();
                int ReasonID = Convert.ToInt32(cboReason.SelectedValue.ToString());
                string Reason = cboReason.SelectedItem.Text.Trim();
                string OtherReason = txtReason.Text.Trim();
                int ProposedByID = 6; int BidderID = 0;
                //dtable = Process.GetUserByName(ProposedBy);
                //if (dtable.Rows.Count == 0)
                //    throw new Exception("Please Enter Existing User OR Select from drop down returned after typing more than two letters");
                //else
                //    ProposedByID = Convert.ToInt32(dtable.Rows[0]["UserID"].ToString());
                datatable = bidd.GetBidderByName(Bidder);
                if (datatable.Rows.Count == 0)
                    throw new Exception("Please Enter Existing Bidder Name OR Select from drop down returned after typing more than two letters");
                else
                    BidderID = Convert.ToInt32(datatable.Rows[0]["BidderID"].ToString());

                long ShortlistID = 0;
                string PRNumber = txtPRNumber2.Text;
                //CreateBiddersDataTable();
                datatable = bidd.GetShortlistedBidderDetails(PRNumber);
                if (datatable.Rows.Count > 0)
                {
                    dtUpdate.Rows.Clear();
                    foreach (DataRow dr in datatable.Rows)
                    {
                         ShortlistID = Convert.ToInt64(dr["ShortlistID"].ToString());
                        DateCreated = Convert.ToDateTime(dr["DateCreated"].ToString());
                         BidderID = Convert.ToInt32(dr["BidderID"].ToString());
                         Bidder = dr["CompanyName"].ToString();
                         ProposedByID = Convert.ToInt32(dr["ProposedByID"].ToString());
                         ProposedBy = cboCompany.SelectedItem.ToString();
                        lblCreatedBy.Text = ProposedByID.ToString();
                         ReasonID = Convert.ToInt32(dr["ReasonID"].ToString());
                         Reason = dr["Reason"].ToString();
                         OtherReason = dr["OtherReason"].ToString();

                        dtUpdate.Rows.Add(new object[] { ShortlistID, DateCreated.ToShortDateString(), BidderID, Bidder, ProposedByID, ProposedBy, ReasonID, Reason, OtherReason });
                    }
                    Session["dtBidders"] = dtUpdate;
                }

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
                dtUpdate.Rows.Add(new object[] { ShortlistID, DateCreated.ToShortDateString(), BidderID, Bidder, ProposedByID, ProposedBy, ReasonID, Reason, OtherReason });
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
            lblmsg.Text = ".";
        else
            lblmsg.Text = "MESSAGE: " + Message;
    }
    protected void btnPrint2_Click(object sender, EventArgs e)
    {
        try
        {
            string ReportName = "BidderShortlist32";
            string ReferenceNo = txtPRNumber2.Text;
            datatable = bidd.GetReportForShortlistedBidders(ReferenceNo);
            int rowcount = datatable.Rows.Count;

            if (rowcount != 0)
            {
                loadreport(ReportName);
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Shortlist.pdf");
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
        //doc.SetDataSource(datatable);

        Hidetoolbar();
        //CrystalReportViewer1.ReportSource = doc;
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
                bidd.FlagPotentialBidder(SID, true);
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


    protected void cboBidderCategory_DataBound(object sender, EventArgs e)
    {
        cboBidderCategory.Items.Insert(0, new ListItem("-- Select Category --", "0"));

    }
    protected void cboBidderCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        // AutoCompleteExtender2.ContextKey = cboBidderCategory.SelectedValue;
        LoadBidders();

        string procMthd = cboProcurementMethod.SelectedValue;
        if ((procMthd == "4" || procMthd == "5") && cboBidderCategory.SelectedValue != "0") {
            int procType = int.Parse(cboProcType.SelectedValue);
            LoadProcCategoryBidders(procType);
        }
    }
    void loadBiddersByCategory(String biddercat)
    {
        datatable = bidd.GetBidderByCategory(int.Parse(biddercat));
        ddlBidders.DataSource = datatable;
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
        int type = 0;
        switch (ProcType)
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
        int Category = Convert.ToInt32(cboBidderCategory.SelectedValue);
        int subCategory = int.Parse(cboBIdderSubcat.SelectedValue);
        dtable = bidd.GetSuppliersByCategory(type, Category, subCategory);
        
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

    private void CreateBiddersDataTable()
    {
        DataTable dtBidders = new DataTable("Bidders");

        dtBidders.Columns.Add(new DataColumn("ShortlistID", typeof(long)));
        dtBidders.Columns.Add(new DataColumn("DateCreated", typeof(DateTime)));
        dtBidders.Columns.Add(new DataColumn("BidderID", typeof(long)));
        dtBidders.Columns.Add(new DataColumn("CompanyName", typeof(string)));
        dtBidders.Columns.Add(new DataColumn("ProposedByID", typeof(long)));
        dtBidders.Columns.Add(new DataColumn("ProposedBy", typeof(string)));
        dtBidders.Columns.Add(new DataColumn("ReasonID", typeof(int)));
        dtBidders.Columns.Add(new DataColumn("Reason", typeof(string)));
        dtBidders.Columns.Add(new DataColumn("OtherReason", typeof(string)));
        dtBidders.Rows.Clear();

        Session["dtBidders"] = dtBidders;
        dtUpdate = dtBidders;
    }

    protected void cboProcurementMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
        string procMethod = cboProcurementMethod.SelectedValue;
        string ReferenceNo = txtPRNumber2.Text;
        int procType = int.Parse(cboProcType.SelectedValue);
        try
        {
            if(procMethod=="4"|| procMethod == "5")
            {
                LoadProcCategoryBidders(procType);
                btnAddBidder.Visible = false;
                cboReason.Visible = false;
                ddlBidders.Visible = false;
                lblBidder.Visible = false;

            }
            else if (procMethod == "0")
            {
                ShowMessage("Select a procurement method");
            }
            else
            {
                LoadShortlistedBidders(ReferenceNo);
                btnAddBidder.Visible = true;
                cboReason.Visible = true;
                ddlBidders.Visible = true;
                lblBidder.Visible = true;
            }

        }catch(Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void DataGrid2_SelectedIndexChanged(object sender, EventArgs e)
    {
       // int newIdx = e.
    }

   

    private void LoadDocuments2()
    {
        //MultiView1.ActiveViewIndex = 7;
        string RefNo = txtPRNumber2.Text;
        datatable = bidd.GetBiddingDocuments2(RefNo, 0);
        if (datatable.Rows.Count > 0)
        {
            GridView2.DataSource = datatable;
            GridView2.DataBind();
            GridView2.Visible = true;
            Label2.Visible = false;
        }
        else
        {
            Label2.Visible = true;
            GridView2.Visible = false;
        }
    }

    protected void cboDocType_DataBound(object sender, EventArgs e)
    {
        cboDocType.Items.Insert(0, new ListItem("-- Select Document Type --", "0"));
    }

    protected void btnUpload_Click1(object sender, EventArgs e)
    {
        if (cboDocType.SelectedValue == "0")
        {
            ShowMessage("Select document type");
        }
        else
        {
            string ReferenceNo = txtPRNumber2.Text;
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
                    File2.PostedFile.SaveAs(Path + "" + c1);
                    bidd.SaveBiddingDocument(ReferenceNo, (Path + "" + c1), c, int.Parse(cboDocType.SelectedValue));
                    LoadDocuments2();
                }
            }
            ShowMessage(".");
        }
    }



    protected void checkbox1_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void advertised_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (advertised.SelectedValue.Equals("1"))
        {
            MultiView2.ActiveViewIndex = 1;
        }
        else
        {
            MultiView2.ActiveViewIndex = 0;
        }
    }
}
