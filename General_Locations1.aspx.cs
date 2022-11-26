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


public partial class CostCenter : System.Web.UI.Page
{
    ProcessUsers Process = new ProcessUsers();
    ProcessRequisition rprocess = new ProcessRequisition();
    DataLogin data = new DataLogin();
    BusinessLogin bll = new BusinessLogin();
    DataTable dataTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        Label msg = (Label)Master.FindControl("lblmsg");
        msg.Text = ".";

        try
        {
            if (IsPostBack == false)
            {
                MultiView1.ActiveViewIndex = 0;
                LoadLocations();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
        
    }

    private void LoadCostCenters()
    {
     
    }
   
    private void LoadCompany()
    {
        dataTable = data.GetAreas();
        
        
    }

    private void LoadLocations()
    {
        dataTable = rprocess.GetLocations();
        GridCCenter.DataSource = dataTable;
        GridCCenter.DataBind();

      
    }

    protected void cboCCcategory_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void cboCCcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ec)
        {
            Label msg = (Label)Master.FindControl("lblmsg");
            msg.Text = "MESSAGE:  " + ec.Message;
        }
    }
   
    private void toggle(bool enabled)
    {
        if (enabled == true)
        {
            //txtCCenter.Enabled = true;
            //txtCCIntial.Enabled = true;
        }
        else
        {
            //txtCCenter.Enabled = false;
            //txtCCIntial.Enabled = false;

        }

    }
    
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            string locationName = txtCcCode.Text.Trim();
            
                string locationID = lblCcCode.Text.Trim();
               

                Process.SaveLocationDetails(int.Parse(locationID), locationName);
                clearControls();
                ShowMessage("Delivery Location ("+ locationName + ") has been added successfull......");
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void saveDetails()
    {
        try
        {
            int ccid = Convert.ToInt32(lblcode.Text.Trim());
            string CostCenterCode = txtCcCode.Text.Trim();
            string compareCode = lblCcCode.Text.Trim();
            string compareInitials = lblInitials.Text.Trim();
                        
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void loadGrid(int cCCategory)
    {
        try
        {
            dataTable = rprocess.GetLocations();
            GridCCenter.DataSource = dataTable;
            GridCCenter.DataBind();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void loadForm()
    {
        try
        {
            MultiView1.ActiveViewIndex = 1;
            int ccid = Convert.ToInt32(lblcode.Text.Trim());
            dataTable = data.GetCostCenterDetails(ccid);
            txtCcCode.Text = dataTable.Rows[0]["CostCenterCode"].ToString();
            lblCcCode.Text = dataTable.Rows[0]["CostCenterCode"].ToString();

            bool IsActive = Convert.ToBoolean(dataTable.Rows[0]["Active"].ToString());
        
           
        }
        catch (Exception ex)
        {
            Label msg = (Label)Master.FindControl("lblmsg");
            msg.Text = "MESSAGE: " + ex.Message;
        }
    }
    protected void GridCCenter_RowCreated(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridCCenter_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnEdit")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                lblcode.Text = Convert.ToString(GridCCenter.DataKeys[intIndex].Value);
                loadForm();
            }
            
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
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
    private void clearControls()
    {
        txtCcCode.Text = "";
        txtAName.Text = "";
        lblcode.Text = "0";
        lblCenterID.Text = "0";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearControls();
        MultiView1.ActiveViewIndex = 0;
        LoadLocations();
    }
    protected void GridCCenter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int newPageIndex = e.NewPageIndex;
            GridCCenter.PageIndex = newPageIndex;
            LoadLocations();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    
  
    protected void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LoadCostCenters();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            MultiView1.ActiveViewIndex = 2;
            lblCenterID.Text = "0";
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

  
   
    protected void Button2_Click1(object sender, EventArgs e)
    {
        try
        {
                string locationName = txtAName.Text.Trim();

                string wareHouseID = lblCenterID.Text.Trim();
                
                Process.SaveLocationDetails(int.Parse(wareHouseID), locationName);
                clearControls();
                ShowMessage("Delivery Location (" + locationName + ") has been added successfull......");
            
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
}
