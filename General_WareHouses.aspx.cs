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
                LoadWareHouses();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }

    }


    private void LoadAreas()
    {
        dataTable = data.GetAreas();
        cboAreas.DataSource = dataTable;
        cboAreas.DataValueField = "AreaID";
        cboAreas.DataTextField = "Area";
        cboAreas.DataBind();
        cboCompany.DataSource = dataTable;
        cboCompany.DataValueField = "AreaID";
        cboCompany.DataTextField = "Area";
        cboCompany.DataBind();
    }

    private void LoadWareHouses()
    {

        dataTable = rprocess.GetWareHouses(Session["AreaCode"].ToString());
        GridCCenter.DataSource = dataTable;
        GridCCenter.DataBind();


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
            //   txtCCenter.Enabled = true;
            //  txtCCIntial.Enabled = true;
        }
        else
        {
            //  txtCCenter.Enabled = false;
            // txtCCIntial.Enabled = false;

        }

    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            string warehouseName = txtCcCode.Text.Trim();


            string Name = txtCcCode.Text.Trim();
            string AreaCode = cboCompany.SelectedValue.ToString();
            string warehouseID = lblCcCode.Text.Trim();

            Process.SaveWareHouseDetails(int.Parse(warehouseID), warehouseName, int.Parse(AreaCode));
            clearControls();
            ShowMessage("CostCenter(" + warehouseName + ") has been added successfull......");

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

            int ccid = Convert.ToInt32(lblcode.Text.Trim());
            dataTable = data.GetCostCenterDetails(ccid);

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
        lblcode.Text = "0";
        lblCcCode.Text = "0";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearControls();
        MultiView1.ActiveViewIndex = 0;
    }
    protected void GridCCenter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int newPageIndex = e.NewPageIndex;
            GridCCenter.PageIndex = newPageIndex;

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

    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            MultiView1.ActiveViewIndex = 2;

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
            string warehouseName = txtAName.Text.Trim();
            string warehouseID = lblCenterID.Text.Trim();
            string AreaCode = cboAreas.SelectedValue.ToString();
            Process.SaveWareHouseDetails(int.Parse(warehouseID), warehouseName, int.Parse(AreaCode));

            ShowMessage("CostCenter(" + warehouseName + ") has been added successfull......");
            clearControls();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
}
