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
                LoadAreas();
                LoadCostCenters();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
        
    }

    private void LoadCostCenters()
    {
        int AreaID = Convert.ToInt32(cboAreas.SelectedValue);
        dataTable = data.GetCostCenters(AreaID);
        GridCCenter.DataSource = dataTable;
        GridCCenter.DataBind();
    }
    private void LoadAreas()
    {
        dataTable = data.GetAreas();
        cboAreas.DataSource = dataTable;
        cboAreas.DataValueField = "AreaID";
        cboAreas.DataTextField = "Area";
        cboAreas.DataBind();
    }
    private void LoadCompany()
    {
        dataTable = data.GetAreas();
        cboCompany.DataSource = dataTable;
        cboCompany.DataValueField = "AreaID";
        cboCompany.DataTextField = "Area";
        cboCompany.DataBind();
        
    }
    protected void cboCCcategory_DataBound(object sender, EventArgs e)
    {
        
    }
    protected void cboCCcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cboCompany.SelectedValue != "0")
            {
                int ctypeCode = Convert.ToInt32(cboCompany.SelectedValue);
                loadGrid(ctypeCode);
                clearControls();
                
            }

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
            txtCCenter.Enabled = true;
            txtCCIntial.Enabled = true;
        }
        else
        {
            txtCCenter.Enabled = false;
            txtCCIntial.Enabled = false;

        }

    }
    
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            string CostCenterCode = txtCcCode.Text.Trim();

            if (cboCompany.SelectedValue == "0")
            {
                ShowMessage("Please Select the Cost Center Category");
            }
            else
            {
                string Name = txtCCenter.Text.Trim();
                string AreaCode = cboCompany.SelectedValue.ToString();
                string Initial = txtCCIntial.Text.Trim();
                string CostCenterID = lblCenterID.Text.Trim();
                bool IsMultiCostCenter = CheckBox4.Checked;
                bool Active = CheckBox1.Checked;
                Process.SaveCostCenter(CostCenterID, CostCenterCode, Name, AreaCode, Initial, IsMultiCostCenter, Active);
                clearControls();
                ShowMessage("CostCenter("+CostCenterCode+") has been added successfull......");
            }
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
            string CostCenter = txtCCenter.Text.Trim();
            string CcInitial = txtCCIntial.Text.Trim();
            string compareCode = lblCcCode.Text.Trim();
            string compareInitials = lblInitials.Text.Trim();
            string CCCategoryCode = cboCompany.SelectedValue;
                        
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
            int areaID = Convert.ToInt32(cboCompany.SelectedValue);
            dataTable = data.GetCostCenters(areaID);
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
            LoadCompany();
            int ccid = Convert.ToInt32(lblcode.Text.Trim());
            dataTable = data.GetCostCenterDetails(ccid);
            txtCcCode.Text = dataTable.Rows[0]["CostCenterCode"].ToString();
            txtCCenter.Text = dataTable.Rows[0]["CostCenterName"].ToString();
            txtCCIntial.Text = dataTable.Rows[0]["Intial"].ToString();
            lblCcCode.Text = dataTable.Rows[0]["CostCenterCode"].ToString();
            lblInitials.Text = dataTable.Rows[0]["Intial"].ToString();
            lblCenterID.Text = dataTable.Rows[0]["CostCenterID"].ToString();
            bool IsMultiCostCenter = Convert.ToBoolean(dataTable.Rows[0]["IsMultiCostCenter"].ToString());
            bool IsActive = Convert.ToBoolean(dataTable.Rows[0]["Active"].ToString());
            string Company = dataTable.Rows[0]["AreaID"].ToString();
            CheckBox1.Checked = IsActive;
            CheckBox4.Checked = IsMultiCostCenter;
            cboCompany.SelectedIndex = cboCompany.Items.IndexOf(cboCompany.Items.FindByValue(Company));
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
                string AreaSelected = cboAreas.SelectedValue.ToString();
                Session["SelectedArea"] = AreaSelected;
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
        txtCCenter.Text = "";
        txtCCIntial.Text = "";
        cboCompany.Enabled = true;
        lblcode.Text = "0";
        CheckBox4.Checked = false;
        CheckBox1.Checked = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearControls();
        MultiView1.ActiveViewIndex = 0;
        string Former = Session["SelectedArea"].ToString();
        cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue(Former));
        LoadCostCenters();
    }
    protected void GridCCenter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int newPageIndex = e.NewPageIndex;
            GridCCenter.PageIndex = newPageIndex;
            LoadCostCenters();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    
    protected void cboCompany_DataBound(object sender, EventArgs e)
    {        
        cboCompany.Items.Insert(0, new ListItem("--- Select Area ---", "0"));
    }
    protected void cboAreas_DataBound(object sender, EventArgs e)
    {
        cboAreas.Items.Insert(0, new ListItem("--- All Areas ---", "0"));
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
            LoadCategories();
            string AreaSelected = cboAreas.SelectedValue.ToString();
            Session["SelectedArea"] = AreaSelected;
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void LoadCategories()
    {
        dataTable = data.GetAreaCategories();
        cboCategory.DataSource = dataTable;
        cboCategory.DataValueField = "CategoryID";
        cboCategory.DataTextField = "Category";
        cboCategory.DataBind();
    }
    protected void cboCategory_DataBound(object sender, EventArgs e)
    {
        cboCategory.Items.Insert(0, new ListItem("--- Select Category ---", "0"));
    }
    
    protected void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int CategoryID = Convert.ToInt32(cboCategory.SelectedValue.ToString());
            LoadAreasByCategory(CategoryID);
           
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadAreasByCategory(int CategoryID)
    {
        dataTable = data.GetAreasByCategory(CategoryID);
        cboCompany2.DataSource = dataTable;
        cboCompany2.DataValueField = "AreaID";
        cboCompany2.DataTextField = "Area";
        cboCompany2.DataBind();

        if (dataTable.Rows.Count == 1)
        {
            string AreaID = dataTable.Rows[0]["AreaID"].ToString();
            cboCompany2.SelectedIndex = cboCompany2.Items.IndexOf(cboCompany2.Items.FindByValue(AreaID));
            cboCompany2.Enabled = false;
        }
        else
        {
            cboCompany2.Enabled = true;
        }
      //  LoadCostCenterfromScala(CategoryID);
    }
    private void LoadCostCenterfromScala( int CategoryCode)
    {
        //dataTable = data.GetCostCentersfromScala(CategoryCode, "0");
        //cboCostCenterNames.DataSource = dataTable;
        //cboCostCenterNames.DataValueField = "CostCenterCode";
        //cboCostCenterNames.DataTextField = "CostCenter";
        //cboCostCenterNames.DataBind();
    }
    protected void cboCompany2_DataBound(object sender, EventArgs e)
    {
        cboCompany2.Items.Insert(0, new ListItem("--- Select Area ---", "0"));
    }
    protected void cboCostCenterNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        int Category = Convert.ToInt32(cboCategory.SelectedValue.ToString());
        string Code = cboCostCenterNames.Text.Trim();
        dataTable = data.GetCostCentersfromScala(Category, Code);
        txtCode.Text = dataTable.Rows[0]["CostCenterCode"].ToString();
        txtInitial.Text = dataTable.Rows[0]["ProcurementInitials"].ToString();
        CheckBox2.Checked = true;
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        try
        {
            string CostCenterCode = txtCode.Text.Trim();

            if (cboCompany.SelectedValue == "0")
            {
                ShowMessage("Please Select the Cost Center Category");
            }
            //else if (txtCcCode.Text.Length < 6)
            //{
            //    ShowMessage("The Cost Center Code provided is Invalid (Make sure you include the Company Code)....");
            //}
            //else if (bll.CostCenterCodeExists(txtCcCode.Text.Trim()))
            //{
            //    ShowMessage("The Cost Center Code provided already exists....");
            //}
            else if (bll.IsCostCenter(CostCenterCode))
            {
                ShowMessage("The Cost Center With Code " + CostCenterCode + " exists already in the System");
            }
            else
            {
                string Name = cboCostCenterNames.Text.Trim();
                string AreaCode = cboCompany2.SelectedValue.ToString();
                string Initial = txtInitial.Text.Trim();
                string CostCenterID = lblCenterID.Text.Trim();
                bool Active = CheckBox2.Checked;
                bool IsMultiCostCenter = CheckBox3.Checked;
                Process.SaveCostCenter(CostCenterID, CostCenterCode, Name, AreaCode, Initial, IsMultiCostCenter, Active);
                clearControls();
                ShowMessage("CostCenter(" + CostCenterCode + ") has been added successfull......");
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
}
