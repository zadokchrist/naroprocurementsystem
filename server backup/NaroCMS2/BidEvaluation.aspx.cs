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
    BusinessRequisition bll = new BusinessRequisition();
    DataLogin data = new DataLogin();
    ProcessBidding bidd = new ProcessBidding();
    DataTable datatable = new DataTable();
    DataSet dataSet = new DataSet();
    private string Status = "26";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadEvaluationDocumentTypes();
                LoadProcMethod();
                LoadAreas();
                LoadItems();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void LoadEvaluationDocumentTypes()
    {
        cboDocType.DataSource = bidd.GetEvaluationDocTypes();
        cboDocType.DataValueField = "DocumentTypeID";
        cboDocType.DataTextField = "DocumentType";
        cboDocType.DataBind();
    }
    private void LoadProcMethod()
    {
        datatable = Process.GetProcurementMethods();
        cboProcMethod.DataSource = datatable;
        cboProcMethod.DataValueField = "MethodCode";
        cboProcMethod.DataTextField = "Method";
        cboProcMethod.DataBind();
    }
    private void LoadItems()
    {
        string access = Session["AccessLevelID"].ToString();
        if (cbostatus.SelectedValue.Equals("0"))
        {
            ShowMessage("Please Select a Status...");
        }
        else
        {
            string RecordID = "0"; string PrNumber = txtPrNumber.Text.Trim();
            string ProcMethod = cboProcMethod.SelectedValue.ToString(); string ProcOfficer = Session["UserID"].ToString(); //cboProcurementOfficer.SelectedValue.ToString();
            string CostCenterCode = cboCostCenters.SelectedValue.ToString(); string AreaCode = cboAreas.SelectedValue.ToString();
            string Status = cbostatus.SelectedValue.ToString();
            if (access == "4")//procurement officer submitting evaluations to procurement manager
            {
                ShowMessage(".");
                datatable = Process.GetProcurementsSentToSuppliers(RecordID, PrNumber, ProcMethod, ProcOfficer, Status, AreaCode, CostCenterCode);
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
                    string EmptyMessage = "No New Activity Schedule(s) in the system assigned to you";
                    lblEmpty.Text = EmptyMessage;
                }
            }
            else if (access.Equals("3"))
            {
                ShowMessage(".");
                ProcOfficer = "0";
                datatable = Process.GetProcurementsSentToSuppliers(RecordID, PrNumber, ProcMethod, ProcOfficer, Status, AreaCode, CostCenterCode);
                if (datatable.Rows.Count > 0)
                {
                    MultiView1.ActiveViewIndex = 5;
                    DataGrid3.DataSource = datatable;
                    DataGrid3.DataBind();
                    lblEmpty.Text = ".";
                }
                else
                {
                    MultiView1.ActiveViewIndex = 0;
                    string EmptyMessage = "No New Activity Schedule(s) in the system assigned to you";
                    lblEmpty.Text = EmptyMessage;
                }
            }
            else if (access.Equals("17") && Status.Equals("40"))
            {
                ShowMessage(".");
                ProcOfficer = "0";
                datatable = Process.GetProcurementsSentToSuppliers(RecordID, PrNumber, ProcMethod, ProcOfficer, Status, AreaCode, CostCenterCode);
                if (datatable.Rows.Count > 0)
                {
                    MultiView1.ActiveViewIndex = 5;
                    DataGrid3.DataSource = datatable;
                    DataGrid3.DataBind();
                    lblEmpty.Text = ".";
                }
                else
                {
                    MultiView1.ActiveViewIndex = 0;
                    string EmptyMessage = "No New Activity Schedule(s) in the system assigned to you";
                    lblEmpty.Text = EmptyMessage;
                }
            }
            else
            {
                ShowMessage("You dont have rights to view this data");
            }
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
            string ReferenceNo = Label4.Text;
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
                    LoadEvaluationDocuments();
                }
            }
        }
    }

    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
           string PRNumber = e.Item.Cells[0].Text;
            Label2.Text = PRNumber;
           if (e.CommandName == "btnApprove")
            {
                Response.Redirect("Requisition_ApproveActivitySchedule.aspx?PR=" + PRNumber, true);
            }
            else if (e.CommandName == "btnViewBid")
            {
                MultiView1.ActiveViewIndex = 2;
                Label1.Text = PRNumber;
                
                LoadDocuments2();
            }
            else if (e.CommandName == "btnViewBidders")
            {
                datatable = Process.GetBidRemainingTime(PRNumber);
                string timeremaining = datatable.Rows[0]["Remaining"].ToString();
                double doubleremainingtime = double.Parse(timeremaining);
                if (doubleremainingtime>0)
                {
                    ShowMessage("You cannot view bidding documents when bidding period is still on ");
                }
                else
                {
                    MultiView1.ActiveViewIndex = 3;
                    LoadSuppliersWhoSubmittedBids(PRNumber);
                }
                
            }
            else if (e.CommandName == "evaluateBids")
            {
                datatable = Process.GetBidRemainingTime(PRNumber);
                string timeremaining = datatable.Rows[0]["Remaining"].ToString();
                double doubleremainingtime = double.Parse(timeremaining);
                if (doubleremainingtime > 0)
                {
                    ShowMessage("You cannot evaluate bids when bidding period is still on ");
                }
                else
                {
                    Label4.Text = PRNumber;
                    LoadEvaluationDocuments();
                    LoadBiddersToSelect(Label4.Text);
                    MultiView1.ActiveViewIndex = 4;
                }
                
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            //string PRNumber = e.Item.Cells[0].Text;
             if (e.CommandName == "btnViewBid")
            {
                MultiView1.ActiveViewIndex = 2;
                //Label1.Text = PRNumber;
                string bidid = e.Item.Cells[0].Text;
                LoadDocuments2ByCreator(int.Parse(bidid));
                //LoadDocuments2();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void DataGrid3_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
            
            string PRNumber = e.Item.Cells[0].Text;
            Label2.Text = PRNumber;
            if (e.CommandName == "btnApprove")
            {
                Response.Redirect("BidEvaluationApproval.aspx?PR=" + PRNumber, true);
            }
            else if (e.CommandName == "btnViewBid")
            {
                MultiView1.ActiveViewIndex = 2;
                Label1.Text = PRNumber;

                LoadDocuments2();
            }
            else if (e.CommandName == "btnViewBidders")
            {
                MultiView1.ActiveViewIndex = 3;
                LoadSuppliersWhoSubmittedBids(PRNumber);
            }
            else if (e.CommandName == "evaluateBids")
            {
                Label4.Text = PRNumber;
                LoadEvaluationDocuments();
                LoadBiddersToSelect(Label4.Text);
                MultiView1.ActiveViewIndex = 4;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void LoadSuppliersWhoSubmittedBids(string referenceNumber)
    {
        datatable = ProcessOthers.GetSuppliersWithBiddDocuments(referenceNumber);
        if (datatable.Rows.Count>0)
        {
            DataGrid2.DataSource = datatable;
            DataGrid2.DataBind();
        }
    }

    private void LoadBiddersToSelect(string referenceNumber)
    {
        datatable = ProcessOthers.GetSuppliersWithBiddDocuments(referenceNumber);
        if (datatable.Rows.Count > 0)
        {
            bidderstoselect.DataSource = datatable;
            bidderstoselect.DataValueField = "BidderID";
            bidderstoselect.DataTextField = "CompanyName";
            bidderstoselect.DataBind();
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

    protected void submitevaluation_Click(object sender, EventArgs e)
    {
        try
        {
            string Message = "";
            if (!GridView1.Rows.Count.Equals(2))
            {
                ShowMessage("Please Upload Required Documents For Evaluation");
            }
            else if (bidderstoselect.SelectedIndex.Equals(0))
            {
                ShowMessage("Please Select Bidder");
            }
            else
            {
                string referenceno = Label4.Text;
                string userid = Session["UserID"].ToString();
                string item = "Activity Plan";
                int status = 39;
                string SubjectOfProcurement = Process.GetRequisitionDetailsByReference(referenceno).Rows[0]["Subject"].ToString();
                string Pdcode = Process.GetRequisitionDetailsByReference(referenceno).Rows[0]["PD_Code"].ToString();
                Process.InsertBidAwards(bidderstoselect.SelectedValue, referenceno, userid);
                Process.LogandCommitRequisition(Pdcode, status, item + " Sent to Procurement Supervisor");
                Message = item + " saved And submitted for Approval ";
                ShowMessage(Message);
                int ManagerID = 6;

                string Msg = "<p>Hello " + "Lawrence Adebola" + ", </p> <p> You have been sent a " + item + " for Approval.</p> ";
                Msg += "<p>For more details, please access the link: http://192.168.8.110/Procurement/  to Login.</p>";
                string By = HttpContext.Current.Session["FullName"].ToString();
                ProcessPlanning plan = new ProcessPlanning();
                plan.NotifyManager(By, SubjectOfProcurement, ManagerID, Msg);

                LoadItems();
                MultiView1.ActiveViewIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        string access = Session["AccessLevelID"].ToString();
        if (access.Equals("3")|| access.Equals("17"))
        {
            LoadItems();
            MultiView1.ActiveViewIndex = 5;
        }
        else
        {
            MultiView1.ActiveViewIndex = 0;
        }
        
    }


    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            //if (e.CommandName == "btnRemove")
            //{
            //    int intIndex = Convert.ToInt32(e.CommandArgument);
            //    string FileCode = Convert.ToString(GridView2.DataKeys[intIndex].Value);
            //    bidd.RemoveDocument(FileCode);
            //    LoadDocuments2();
            //}
            //else
            //{
                // View 
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridView2.DataKeys[intIndex].Value);
                string Path = bidd.GetDocumentPath(FileCode);
                bidd.DownloadFile(Path, true);
            //}
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
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridView1.DataKeys[intIndex].Value);
                bidd.RemoveDocument(FileCode);
                LoadEvaluationDocuments(); 
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        int AreaID = Convert.ToInt32(cboAreas.SelectedValue);
        LoadCostCenters(AreaID);
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
    private void LoadDocuments2()
    {
        //MultiView1.ActiveViewIndex = 7;
        string RefNo = Label1.Text;//txtPRNumber2.Text;
        datatable = bidd.GetBiddingDocuments2(RefNo, 0);
        if (datatable.Rows.Count > 0)
        {
            GridView2.DataSource = datatable;
            GridView2.DataBind();
            GridView2.Visible = true;
            //Label2.Visible = false;
        }
        else
        {
            //Label2.Visible = true;
            GridView2.Visible = false;
        }
    }

    private void LoadEvaluationDocuments()
    {
        string RefNo = Label4.Text;
        datatable = bidd.GetBiddingEvaluationDocuments2(RefNo);
        if (datatable.Rows.Count > 0)
        {
            GridView1.DataSource = datatable;
            GridView1.DataBind();
            GridView1.Visible = true;
            //Label2.Visible = false;
        }
        else
        {
            //Label2.Visible = true;
            GridView1.Visible = false;
        }
    }
    private void LoadDocuments2ByCreator(int createdby)
    {
        //MultiView1.ActiveViewIndex = 7;
        string RefNo = Label2.Text;//txtPRNumber2.Text;
        datatable = bidd.GetBiddingDocuments2bYCreator(RefNo, 0, createdby);
        if (datatable.Rows.Count > 0)
        {
            GridView2.DataSource = datatable;
            GridView2.DataBind();
            GridView2.Visible = true;
            //Label2.Visible = false;
        }
        else
        {
            //Label2.Visible = true;
            GridView2.Visible = false;
        }
    }
    protected void cboAreas_DataBound1(object sender, EventArgs e)
    {
        cboAreas.Items.Insert(0, new ListItem(" -- All Areas -- ", "0"));
    }
    protected void cboCostCenter_DataBound(object sender, EventArgs e)
    {
        cboCostCenters.Items.Insert(0, new ListItem("- - All Cost Centers - -", "0"));
    }
    protected void bidderstoselect_DataBound(object sender, EventArgs e)
    {
        bidderstoselect.Items.Insert(0, new ListItem("- - Please Select Bidder To Award Contract - -", "0"));
    }
    protected void cboProcMethod_DataBound(object sender, EventArgs e)
    {
        cboProcMethod.Items.Insert(0, new ListItem(" -- All Proc. Methods --", "0"));
    }
}
