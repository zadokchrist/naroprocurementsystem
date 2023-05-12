using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Requisition_Cancel_Requisition : System.Web.UI.Page
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
            ToggleCenter();
        }
    }

    
        private void LoadAreas()
    {
        datatable = data.GetAreas();
        cboAreas.DataSource = datatable;
        cboAreas.DataValueField = "AreaID";
        cboAreas.DataTextField = "Area";
        cboAreas.DataBind();

        int AreaID = Convert.ToInt32(Session["AreaCode"].ToString());
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
       private void ToggleCenter()
       {
           int AccessLevelID = Convert.ToInt32(Session["AccessLevelID"].ToString());
           string AreaID = Session["AreaCode"].ToString();
           cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue(AreaID));
           if (AccessLevelID != 3) {
               cboAreas.Enabled = false;
           }

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
                string prnumber = txtPrNumber.Text.Trim();
                string startDate = txtStartDate.Text.Trim();
                string endDate = txtEndDate.Text.Trim();
                string proctypeID = cboProcType.SelectedValue.ToString();
                string costcenterid = cboCostCenters.SelectedValue.ToString();
                string areaid = cboAreas.SelectedValue.ToString();
                LoadItems(prnumber, startDate, endDate, proctypeID, costcenterid, areaid);
              //  LoadItems();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message + "" + ex);
            }
            
        
       
    }

    private void LoadItems(string prnumber, string StartDate, string EndDate, string ProcType, string costcenterid, string areaid)
    {

        if (costcenterid == "")
            costcenterid = "0";

        if (prnumber == "")
            prnumber = "0";

       

        //ShowMessage("ProctYpe" + ProcType);
           datatable = Process.getCCRequisitions(prnumber, StartDate, EndDate, ProcType, costcenterid, areaid);
              DataGrid2.DataSource = datatable;
              DataGrid2.DataBind();

              if (datatable.Rows.Count > 0)
              {
                MultiViewForCancelRequisition.ActiveViewIndex = 0;
               
              }
              else
             {
                 ShowMessage("No items match your search");
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
   
    

    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        ShowMessage(".");
        try
        {
            // Get Item Name......
            string PD_Code = e.Item.Cells[0].Text;
            string prnumber = e.Item.Cells[1].Text;
            string Desc = e.Item.Cells[2].Text;
          
             if (e.CommandName == "btnDelete")
            {
                lblScalaPrNumber.Text = prnumber;
                lblpdcode.Text = PD_Code;
                lblDesc.Text = Desc;
               
              MultiViewForCancelRequisition.ActiveViewIndex = 1;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    
    protected void btnDeleteReq_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        try
        {
            if (txtDeleteComment.Text == "")
                ShowMessage("Please Enter Comment For Cancelling The Requistion");
            else
            {
                ShowMessage(".");
               // btnDeleteReq.Enabled = false;
                int ScalaPR;
                if (lblScalaPrNumber.Text == "&nbsp;")
                {
                    ScalaPR = 0;
                }
                else {
                   ScalaPR = Convert.ToInt32(lblScalaPrNumber.Text.Trim());
                
                }
                string message = txtDeleteComment.Text.Trim();
                string PD_Code =   lblpdcode.Text.Trim();

               Process.DeleteCCRequisition(ScalaPR, PD_Code, 75, message);
              
               ShowMessage("Requisition has been cancelled!!");
               ResetDeletionControls();
            }
        }
        catch (Exception ex)
        {
           

        }
    }

    private void ResetDeletionControls()
    {
        txtDeleteComment.Text = "";
        lblScalaPrNumber.Text = "";
        lblpdcode.Text = "";
        lblDesc.Text = "";

        string prnumber = txtPrNumber.Text.Trim();
        string startDate = txtStartDate.Text.Trim();
        string endDate = txtEndDate.Text.Trim();
        string proctypeID = cboProcType.SelectedValue.ToString();
        string costcenterid = cboCostCenters.SelectedValue.ToString();
        string areaid = cboAreas.SelectedValue.ToString();
        LoadItems(prnumber, startDate, endDate, proctypeID, costcenterid, areaid);
        
    }

    protected void btnCancelDelete_Click(object sender, EventArgs e)
    {
        ShowMessage("Cancellation Has Been stopped ...");
        MultiViewForCancelRequisition.ActiveViewIndex = 0;
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