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


public partial class General_Areas : System.Web.UI.Page
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
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }

    }


    private void LoadAreas()
    {
        dataTable = data.GetAllAreas();
        GridCCenter.DataSource = dataTable;
        GridCCenter.DataBind();

    }
    private void LoadCompany()
    {
        dataTable = data.GetAllAreas();
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



    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            string areaName = txtAName.Text.Trim();

            //if (cboCompany.SelectedValue == "0")
            //{
            //    ShowMessage("Please Select the Cost Center Category");
            //}
            //else
            //{
            string Name = txtCcCode.Text.Trim();
            int category = int.Parse(cboCategory.SelectedValue.ToString());
            string CostCenterID = lblCcCode.Text.Trim();
            bool Active = CheckBox1.Checked;
            Process.SaveAreaDetails(int.Parse(CostCenterID), Name, category, Convert.ToInt32(Active));

            ShowMessage("Area (" + areaName + ") has been added successfull......");
            clearControls();
            //}
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
            int ccid = Convert.ToInt32(lblCcCode.Text.Trim());
            dataTable = data.GetAreaDetails(ccid);
            txtCcCode.Text = dataTable.Rows[0]["Area"].ToString();

            bool IsActive = Convert.ToBoolean(dataTable.Rows[0]["Active"].ToString());
            CheckBox1.Checked = IsActive;

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
                lblCcCode.Text = Convert.ToString(GridCCenter.DataKeys[intIndex].Value);
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
        txtCcCode.Text = "";
        lblcode.Text = "0";
        CheckBox2.Checked = false;
        CheckBox1.Checked = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearControls();
        LoadAreas();
        MultiView1.ActiveViewIndex = 0;



    }
    protected void GridCCenter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int newPageIndex = e.NewPageIndex;
            GridCCenter.PageIndex = newPageIndex;
            LoadAreas();
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

    protected void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LoadAreas();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

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
    protected void Button2_Click1(object sender, EventArgs e)
    {
        try
        {

            string Name = txtAName.Text.Trim();
            string CostCenterID = lblCenterID.Text.Trim();
            bool Active = CheckBox2.Checked;
            int category = int.Parse(cboCategory.SelectedValue.ToString());
            Process.SaveAreaDetails(int.Parse(CostCenterID), Name, category, Convert.ToInt32(Active));

            ShowMessage("Area (" + Name + ") has been added successfull......");
            clearControls();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 2;
        lblCenterID.Text = "0";
    }
}
