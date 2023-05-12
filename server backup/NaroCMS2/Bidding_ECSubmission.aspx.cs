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

public partial class Bidding_ECSubmission : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    ProcessPlanning ProcessPlan = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    DataTable datatable = new DataTable();
    DataLogin data = new DataLogin();
    DataSet dataSet = new DataSet();
    private string Status = "26,27,30";
    DataTable dtUpdate = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadAreas(); LoadProcMethod();
                if (Request.QueryString["transferid"] != null)
                {
                    txtPrNumber.Text = Session["PRNumber"].ToString();
                    cboProcMethod.SelectedIndex = cboProcMethod.Items.IndexOf(cboProcMethod.Items.FindByValue(Session["ProcMethod"].ToString()));
                    cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue(Session["Area"].ToString()));
                    cboCostCenters.SelectedIndex = cboCostCenters.Items.IndexOf(cboCostCenters.Items.FindByValue(Session["CostCenter"].ToString()));
                    LoadItems();
                }
                LoadItems();
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
    private void LoadProcMethod()
    {
        datatable = ProcessPlan.GetProcurementMethods();
        cboProcMethod.DataSource = datatable;
        cboProcMethod.DataValueField = "MethodCode";
        cboProcMethod.DataTextField = "Method";
        cboProcMethod.DataBind();
    }
    private void LoadItems()
    {
        string RecordID = "0"; string PrNumber = txtPrNumber.Text.Trim();
        string ProcMethod = cboProcMethod.SelectedValue.ToString(); string ProcOfficer = Session["UserID"].ToString();
        string CostCenterCode = cboCostCenters.SelectedValue.ToString(); string AreaCode = cboAreas.SelectedValue.ToString();

        datatable = Process.GetProcurementsForECSubmissionOnly(RecordID, PrNumber, ProcMethod, ProcOfficer, AreaCode, CostCenterCode);
        if (datatable.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 0;
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind(); DataGrid1.Visible = true;
            lblEmpty.Text = ".";
        }
        else
        {
            MultiView1.ActiveViewIndex = 0; DataGrid1.Visible = false;
            string EmptyMessage = "No Procurement(s) Approved By Contracts Committee Without Evaluation Committee in the System from Area ( " + cboAreas.SelectedItem + " ) from Cost Center ( " + cboCostCenters.SelectedItem + " ) " + Environment.NewLine;
            lblEmpty.Text = EmptyMessage;
        }
    }
    public bool DisableLink(object dataItem)
    {
        if (DataBinder.Eval(dataItem, "IsSubmitEnabled").ToString() == "False")
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
    private void GetPreviousSelectedValues()
    {
        Session["PreviousPage"] = "Bidding_ECSubmission.aspx";
        Session["PRNumber"] = txtPrNumber.Text.Trim(); Session["ProcMethod"] = cboProcMethod.SelectedValue;
        Session["Area"] = cboAreas.SelectedValue; Session["CostCenter"] = cboCostCenters.SelectedValue;
    }
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        ShowMessage(".");
        try
        {
            // Get Item Name......
            string RecordID = e.Item.Cells[0].Text;
            string PRNumber = e.Item.Cells[2].Text;
            string Subject = e.Item.Cells[3].Text;

            GetPreviousSelectedValues();
            if (e.CommandName == "btnProposeEC")
                Response.Redirect("Bidding_NewEvaluationCommittee.aspx?PR=" + PRNumber, true);
            else if (e.CommandName == "btnSubmitToCC")
            {
                Process.LogPreviousStatus(PRNumber);
                Process.LogandCommitBiddingDetails(PRNumber, 44, "Submitted For Evaluation Committee Approval");
                ShowMessage("Evaluation Committee Has Been Successfully Submitted To Contracts Committee");
                LoadItems();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
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
    private void Page_Unload(object sender, EventArgs e)
    {
        //if (doc != null)
        //{
        //    doc.Close();
        //    doc.Dispose();
        //    GC.Collect();
        //}
    }
    protected void cboProcMethod_DataBound(object sender, EventArgs e)
    {
        cboProcMethod.Items.Insert(0, new ListItem(" -- All Proc. Methods --", "0"));
    }
}
