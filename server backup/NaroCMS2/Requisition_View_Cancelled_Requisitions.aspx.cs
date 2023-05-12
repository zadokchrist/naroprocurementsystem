using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Requisition_View_Cancelled_Requisitions : System.Web.UI.Page
{

    ProcessRequisition Process = new ProcessRequisition();
    DataTable datatable = new DataTable();
    DataLogin data = new DataLogin();
    ProcessPlanning ProcessOthers = new ProcessPlanning();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadProcurmentTypes();
        if (IsPostBack == false)
        {
            LoadAreas();
        }
    }

    private void LoadAreas()
    {
        datatable = data.GetAreas();
        cboAreas.DataSource = datatable;
        cboAreas.DataValueField = "AreaID";
        cboAreas.DataTextField = "Area";
        cboAreas.DataBind();

        // int AreaID = Convert.ToInt32(Session["AreaCode"].ToString());
        //  LoadCostCenters(AreaID);

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

    private void LoadProcurmentTypes()
    {
        datatable = Process.GetRequisitionProcurementTypes();
        cboProcType.DataSource = datatable;
        cboProcType.DataValueField = "Code";
        cboProcType.DataTextField = "Type";
        cboProcType.DataBind();
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            ShowMessage(".");
            string prnumber = txtPrNumber.Text.Trim();
            string startDate = txtStartDate.Text.Trim();
            string endDate = txtEndDate.Text.Trim();
            string proctypeID = cboProcType.SelectedValue.ToString();
            string costcenterid = cboCostCenters.SelectedValue.ToString();
            string areaid = cboAreas.SelectedValue.ToString();
            string Assignedto = Session["UserID"].ToString();
            int assigned = Convert.ToInt32(Assignedto);
            LoadItems(prnumber, startDate, endDate, proctypeID, costcenterid, areaid, assigned);
            //  LoadItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message + "" + ex);
        }
    }

    private void LoadItems(string prnumber, string StartDate, string EndDate, string ProcType, string costcenterid, string areaid,int assignedto)
    {

        if (costcenterid == "")
            costcenterid = "0";

        if (prnumber == "")
            prnumber = "0";

        //ShowMessage("ProctYpe" + ProcType);
        datatable = Process.getCancelledDeleteCCRequisitions(prnumber, StartDate, EndDate, ProcType, costcenterid, areaid,assignedto);
        DataGrid2.DataSource = datatable;
        DataGrid2.DataBind();

        if (datatable.Rows.Count > 0)
        {
            MultiViewForCancelRequisition.ActiveViewIndex = 0;

        }
        else
        {
            ShowMessage("NO REQUISITION(S) ASSIGNED TO YOU HAVE BEEN CANCELLED AND DELETED");
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
    protected void cboProcType_DataBound(object sender, EventArgs e)
    {
        cboProcType.Items.Insert(0, new ListItem("- - All Procurement Types - -", "0"));
    }
    protected void cboAreas_DataBound(object sender, EventArgs e)
    {
        cboAreas.Items.Insert(0, new ListItem("- - All Areas - -", "0"));
    }
    protected void cboCostCenters_DataBound(object sender, EventArgs e)
    {
        cboCostCenters.Items.Insert(0, new ListItem("- - All Cost Centers - -", "0"));
    }
    protected void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
    {

        int AreaID = Convert.ToInt32(cboAreas.SelectedValue.ToString());
        LoadCostCenters(AreaID);

    }
}