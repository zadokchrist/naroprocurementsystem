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
public partial class AddWorkflowSteps : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOther = new ProcessPlanning();
    DataLogin data = new DataLogin();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable dtable = new DataTable();
    DataSet dataSet = new DataSet();
    private bool IsGroup = false;
    private bool IsEmergency = false;

    private DataTable dtUpdate;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DisableBtnsOnClick();
            if (IsPostBack == false)
            {
                CreateWorkflowStepsDataTable();
                
                if (Session["CostCenterID"].ToString().Equals("53") || Session["CostCenterID"].ToString().Equals("113"))
                {

                }
                else
                {

                }
                LoadControls();
                Toggle(false, ".");
            }
            //else if (Request.QueryString["transferid"] != null)
            //{
            //    MultiView1.ActiveViewIndex = 0;
            //    string PlanCode = lblPlanCode.Text.Trim();

            //    //MultiView2.ActiveViewIndex = 0;
            //    lblGroupRequisition.Text = "EDIT REQUISITION ITEM";
            //    //LoadProcurementTypes();
            //    //LoadControls();
            //    LoadDetails(PlanCode);
            //    //LoadPlanItem();
            //    Toggle(false, ".");
            //    //MultiView3.ActiveViewIndex = 0;
            //}
            dtUpdate = (DataTable)Session["dtWorkflowSteps"];
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
       
    }
    private void DisableBtnsOnClick()
    {
        string strProcessScript = "this.value='Processing...';this.disabled=true;";
        btnAddItem.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnAddItem, "").ToString());
        Button1.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(Button1, "").ToString());
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
    private void LoadControls()
    {
        //if (Request.QueryString["transferid"] != null)
        //{
            MultiView1.ActiveViewIndex = 0;
            //LoadDetails(PlanID);
            LoadWorkFlows();
            GetFromRoles();
        //}
        //else
        //{
        //    Response.Redirect("Requisition_Items.aspx", true);
        //}
    }

    public void LoadWorkFlows()
    {
        try
        {
            dtable = data.GetAllWorkFlows("0");
            workflowname.DataSource = dtable;
            workflowname.DataBind();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    public void GetFromRoles()
    {
        dtable = data.GetAccessLevels();
        fromrole.DataSource = dtable;
        fromrole.DataBind();

        torole.DataSource = dtable;
        torole.DataBind();
    }
    public bool DisplayStockName()
    {
        if (ProcessOther.IsUserInInventory() || Session["IsAreaProcess"].ToString() == "1")
            return true;
        else
            return false;
    }

    private void LoadDetails(string PlanCode)
    {
        LoadLocations();
        LoadWareHouses();
        dtable = Process.GetItemDetails(PlanCode);
        string PlanDesc = dtable.Rows[0]["Description"].ToString();
        //chkIsFramework.Checked = Convert.ToBoolean(dtable.Rows[0]["IsFramework"].ToString());
        lblGroupRequisition.Text = PlanDesc;
        lblInitail.Text = dtable.Rows[0]["Intial"].ToString();
        lblDesc.Text = dtable.Rows[0]["RequisitionInitial"].ToString();
        lblYear.Text = dtable.Rows[0]["FinancialYear"].ToString();
        lblTypeID.Text = dtable.Rows[0]["ProcurementTypeID"].ToString();
        IsGroup = Convert.ToBoolean(dtable.Rows[0]["IsGroupItem"]);
        // txtDateRequired.Text = DateTime.Today; // dtable.Rows[0]["DateNeeded"].ToString();
        LoadAreaManagers();
        if (ProcessOther.IsUserInInventory())
        {
        }
        else
        {
        }
        DataTable Manager = ProcessOther.GetDefaultCCManager();
        if (Manager.Rows.Count > 0)
        {
            string ManagerName = Manager.Rows[0]["FullName"].ToString();
        }
    }
    //sas
    private void LoadPlanItem()
    {
        Session["dtRequisition"] = dtUpdate;
        DataTable dtRequisition = (DataTable)Session["dtRequisition"];
        //string PlanDesc = dtable.Rows[0]["Description"].ToString();
        //lblPlanAmount.Text = Convert.ToDouble(dtable.Rows[0]["RemainingAmount"]).ToString("#,##0");

        string ItemDesc = dtRequisition.Rows[0]["ItemDesc"].ToString();
        //string StockCode = dtUpdate.Rows[0]["StockCode"].ToString();
        //string StockName = dtUpdate.Rows[0]["StockName"].ToString();
        //txtRequired.Text = Convert.ToInt32(dtRequisition.Rows[0]["Quantity"]).ToString();

        string Unit = dtRequisition.Rows[0]["UnitCode"].ToString();
        //double TotalCost = UnitCost * Quantity;
        //txtMarketprice.Text = Convert.ToDouble(dtRequisition.Rows[0]["MarketPrice"]).ToString("#,##0");

    }

    private void LoadWareHouses()
    {
        dtable = Process.GetWareHouses(Session["AreaCode"].ToString());
    }

    private void LoadAreaManagers()
    {
        if (Session["IsAreaProcess"].ToString() == "1")
        {
        }
        else
        {
        }
    }

    private void LoadLocations()
    {
        dtable = Process.GetLocations();
    }

    protected void btnYes_Click(object sender, EventArgs e)
    {
        // Clear Moniors
        string PlanCode = lblPlanCode.Text.Trim();
        if (bll.IsGroupItem(PlanCode))
        {
            MultiView1.ActiveViewIndex = 0;
            Button1.Enabled = true;
            LoadDetails(PlanCode);

            //string SelectedLocation = lblLoc.Text.Trim();
            //cboLocation.SelectedIndex = cboLocation.Items.IndexOf(cboLocation.Items.FindByValue(SelectedLocation));
            //btnReturn_Click();
        }
        else
        {
            MultiView1.ActiveViewIndex = 2;
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {

        //    try
        //    {
        //        MultiView1.ActiveViewIndex = 0;
        //        string Plancode = lblPlanCode.Text.Trim();
        //        ShowMessage("Requisition on Group Item " + Plancode + " has been Captured and Submitted to CostCenter Manager " + cboAreaManagers.SelectedItem.Text);
        //        //ClearMajorControls();
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowMessage(ex.Message);
        //    }
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        try
        {
            MultiView1.ActiveViewIndex = 0;
            string PlanCode = lblPlanCode.Text.Trim();
            string PD_Code = lblPDCode.Text.Trim();
            Process.LogandCommitRequisition(PD_Code, 11, "");
            AlertManager(PD_Code);
            ShowMessage("Requisition on Item " + PlanCode + " has been Captured and Submitted Successfully");
            ClearMajorControls();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }

    }
    protected void cboLocation_DataBound(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            ValidateRequisition();
            MultiView1.ActiveViewIndex = 0;
            lblGroupRequisition.Visible = false;
            lblTypeID.Visible = false;


        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private bool IsFrameWorkContract()
    {
        bool IsFrameWork = false;
        //if (chkIsFramework.Checked == true)
        //    IsFrameWork = true;

        return IsFrameWork;
    }
    private void ValidateRequisition()
    {
        DateTime StartDate = DateTime.Now;//Convert.ToDateTime(lblFinYearStartDate.Text.Trim());
        string marketprice = "";//txtMarketprice.Text.Trim();
        HttpFileCollection uploads;
        uploads = HttpContext.Current.Request.Files;
        if (dtUpdate.Rows.Count == 0)
        {
            ShowMessage("Please Add Steps To the workflow");
        }
        else
        {
            foreach (DataRow dr in dtUpdate.Rows)
            {
                string status = dr["Status"].ToString();
                string FromRoleid = dr["FromRoleid"].ToString();
                string ToRoleid = dr["ToRoleid"].ToString();
                bool canappr = bool.Parse(dr["CanApprove"].ToString());
                bool candown = bool.Parse(dr["CanDownload"].ToString());
                string description = dr["Description"].ToString();
                data.SaveWorkflowItems(workflowname.SelectedValue,status,FromRoleid,ToRoleid,candown,canappr, description);
            }
            
            //UploadFiles(PDReturn);
            ActionToTake();
            //if (!Process.IsRequisitionInAreaThreshold(TotalCost))
            //    ShowMessage("The Requisition Amount Is Above Your Cost Center Threshold. Please Contact Operations Department To Raise The Requisition");
            //else
            //{

            //    int CCManagerID = 0;//int.Parse(cboAreaManagers.SelectedValue.ToString());
            //                        //string PDReturn = Process.SaveRequisition(RecordCode, PD_Code, ItemCode, Plancode, EntityCode, Subject,
            //                        //                    LocationCode, WareHouseCode, ReqTypeCode, DateRequired, PlanBalance, ProcType, CCManagerID, dtRequisition, MarketPrice, IsFrameWork, IsProject);
            //                        //lblPDCode.Text = PDReturn;
            //Process.SaveWorkflowItems(workflowname.SelectedValue, dtUpdate);
            //    //UploadFiles(PDReturn);
            //    ActionToTake();

            //    //dtUpdate.Rows.RemoveAt();
            //}
        }
    }
    private void ActionToTake()
    {
        LoadControls();
        ClearMajorControls();
        ShowMessage("Workflow steps for ( " + workflowname.SelectedItem + " ) has been saved successfully ");
        dtUpdate.Clear();
        //Response.Redirect("AddWorkflowSteps.aspx", true);
    }
    private void AlertManager(string PD_Code)
    {
        DataTable dtAlert = Process.GetRequisitionerAndCCManager(PD_Code);
        string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
        string RequisitionerName = dtAlert.Rows[0]["Requisitioner"].ToString();
        string CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();
        string Subject = dtAlert.Rows[0]["Subject"].ToString();
        string Message = "";
        if (IsEmergency)
        {
            Message = "<p><strong>EMMERGENCY REQUISITION</strong></p>";
            Message += "<p>You have been sent an emmergency requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> for approval</p>";
        }
        else
        {
            Message = "<p>You have been sent a normal requisition entitled <strong>" + Subject + " by " + RequisitionerName + "</strong> for approval</p>";
        }

        Message += "<p>Please access the link: <a href='http://192.168.8.110:4070/procurement/'>http://192.168.8.110:4070/procurement/</a> to login. </p> ";
        int CCManagerID = 0;
        ProcessOther.NotifyManager(RequisitionerName, Subject, CCManagerID, Message);

    }
    private void Toggle(bool Check, string returned)
    {
        btnYes.Visible = Check;
        btnNo.Visible = Check;
        lblQn.Visible = Check;
        if (Check)
        {
            MultiView1.ActiveViewIndex = 1;
            lblQn.Text = returned;
        }
        else
        {
            MultiView1.ActiveViewIndex = 0;
            lblQn.Text = ".";
        }
    }
    private void ClearMajorControls()
    {
        txtStatus.Text = "";
        DataGrid2.DataSource = null;
        DataGrid2.DataBind();
    }

    private void ClearItemControls()
    {

    }


    private void UploadFiles(string PlanCode)
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
                string c1 = PlanCode + "_" + (countfiles + i + 1) + "_" + cNoSpace;
                string Path = Process.GetDocPath();
               
                ProcessOther.SavePlanDocuments(PlanCode, (Path + "" + c1), c, false);

            }
        }
    }
    protected void txtRequired_TextChanged(object sender, EventArgs e)
    {
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {

    }
    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            //string Plancode = e.Item.Cells[0].Text;
            //string RecordID = e.Item.Cells[0].Text;
            //string PD_Code = e.Item.Cells[1].Text;
            string Desc = e.Item.Cells[0].Text;

            if (e.CommandName == "btnRemove")
            {
                int ItemRowIndex = e.Item.DataSetIndex;
                //double ItemTotalCost = Convert.ToDouble(e.Item.Cells[4].Text.Replace(",", ""));
                //double RemAmount = 0;//Convert.ToDouble(lblAmount.Text.Trim().Replace(",", ""));
                //RemAmount = RemAmount + ItemTotalCost;

                dtUpdate.Rows.RemoveAt(ItemRowIndex);
                //lblAmount.Text = RemAmount.ToString("#,##0");

                DataGrid2.DataSource = dtUpdate.DefaultView;
                DataGrid2.DataBind();
            }
            //sas
            //else if (e.CommandName == "btnEdit")
            //{
            //    //MultiView1.ActiveViewIndex = 0;

            //    //lblPlanCode.Text = Plancode;
            //    //lblDesc.Text = ItemDesc;
            //    //LoadDetails(Plancode);
            //    //Session["Status"] = cboStatus.SelectedValue.ToString();
            //    Session["SelectedType"] = cboProcType.SelectedValue.ToString();


            //    Response.Redirect("Requisition_EditGroupRequisition.aspx?transferid=" + Desc, true);
            //    lblGroupRequisition.Text = "EDIT REQUISITION ITEM";
            //    int ItemRowIndex = e.Item.DataSetIndex;
            //    double ItemTotalCost = Convert.ToDouble(e.Item.Cells[4].Text.Replace(",", ""));
            //    double RemAmount = Convert.ToDouble(lblAmount.Text.Trim().Replace(",", ""));
            //    RemAmount = RemAmount + ItemTotalCost;
            //    string ItemDesc = e.Item.Cells[0].Text.Trim();

            //    string StockCode = dtUpdate.Rows[0]["StockCode"].ToString();
            //    string StockName = dtUpdate.Rows[0]["StockName"].ToString();
            //    int Quantity = Convert.ToInt32(e.Item.Cells[3].Text.ToString());
            //    int UnitCode = Convert.ToInt32(e.Item.Cells[4].Text.ToString());
            //    string Unit = e.Item.Cells[5].Text.ToString();
            //    double UnitCost = Convert.ToDouble(e.Item.Cells[6].Text.Trim().Replace(",", ""));
            //    //double TotalCost = UnitCost * Quantity;
            //    double Amount = Convert.ToDouble(e.Item.Cells[8].Text.Trim().Replace(",", ""));
            //    double MarketPrice = Convert.ToDouble(e.Item.Cells[7].Text.Trim().Replace(",", ""));



            //    DataGrid2.DataSource = dtUpdate.DefaultView;
            //    DataGrid2.DataBind();



            //}
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void ValidateMainControls()
    {

    }

    private void ValidateItemControls()
    {

    }

    private void ShowMessage2(string Message)
    {
        if (Message == ".")
            lblItemError.Text = ".";
        else
            lblItemError.Text = "MESSAGE: " + Message;
    }

    protected void btnAddItem_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage2(".");

            if (workflowname.SelectedIndex.Equals(0))
                ShowMessage2("Please select Workflow to proceed");
            else if (String.IsNullOrEmpty(txtStatus.Text))
                ShowMessage2("Please Enter Status Name");
            else if (fromrole.SelectedIndex.Equals(0))
                ShowMessage2("Please select from role");
            else if (torole.SelectedIndex.Equals(0))
                ShowMessage2("Please select to role");
            else
            {
                string status = txtStatus.Text;
                string fromrol = fromrole.SelectedItem.Text;
                string fromroleid = fromrole.SelectedValue;
                string torol = torole.SelectedItem.Text;
                string toroleid = torole.SelectedValue;
                bool canreject_or_approve = canapprove.Checked;
                bool canupload_download = canupload.Checked;
                string narration = description.Text.Trim();

                dtUpdate.Rows.Add(new object[] { status, fromrol, fromroleid, torol, toroleid, canreject_or_approve, canupload_download, narration });
                ClearItemControls();

                DataGrid2.DataSource = dtUpdate.DefaultView;
                DataGrid2.DataSource = dtUpdate;
                DataGrid2.DataBind();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void CreateWorkflowStepsDataTable()
    {
        DataTable dtWorkflowsteps = new DataTable("WorkflowSteps");
        dtWorkflowsteps.Columns.Add(new DataColumn("Status", typeof(string)));
        dtWorkflowsteps.Columns.Add(new DataColumn("FromRole", typeof(string)));
        dtWorkflowsteps.Columns.Add(new DataColumn("FromRoleid", typeof(int)));
        dtWorkflowsteps.Columns.Add(new DataColumn("ToRole", typeof(string)));
        dtWorkflowsteps.Columns.Add(new DataColumn("ToRoleid", typeof(int)));
        dtWorkflowsteps.Columns.Add(new DataColumn("CanApprove", typeof(Boolean)));
        dtWorkflowsteps.Columns.Add(new DataColumn("CanDownload", typeof(Boolean)));
        dtWorkflowsteps.Columns.Add(new DataColumn("Description", typeof(string)));
        dtWorkflowsteps.Rows.Clear();
        Session["dtWorkflowSteps"] = dtWorkflowsteps;
    }

    protected void txtUnitCost1_TextChanged(object sender, EventArgs e)
    {
        if (true )
        {
            string UnitCost = "";//txtUnitCost1.Text.Trim();
            double Cost = Convert.ToDouble(UnitCost.Replace(",", ""));
            int Qty = 0;
            double ReqAmount = Qty * Cost;
            double BalAmount = 0;//Convert.ToDouble(lblAmount.Text.Trim().Replace(",", ""));
            if (ReqAmount > BalAmount)
            {
                ShowMessage2(" Your Total Cost (" + ReqAmount + ") was greater than (" + BalAmount + ") balance on the Plan Item");
            }
            else
            {
                //txtTotalCost.Text = ReqAmount.ToString("#,##0");
            }
        }
    }

    protected void lblAmount_DataBinding(object sender, EventArgs e)
    {
        
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Requisition_Items.aspx?transferid=1", true);
    }
    protected void workflow_DataBound(object sender, EventArgs e)
    {
        workflowname.Items.Insert(0, new ListItem("- - Select Work flow - -", "0"));
    }

    protected void fromrole_DataBound(object sender, EventArgs e)
    {
        fromrole.Items.Insert(0, new ListItem("- - Select From Role - -", "0"));
    }

    protected void torole_DataBound(object sender, EventArgs e)
    {
        torole.Items.Insert(0, new ListItem("- - Select From Role - -", "0"));
    }
    protected void chkIsProject_CheckedChanged(object sender, EventArgs e)
    {
    }

}
