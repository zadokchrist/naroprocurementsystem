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


public partial class AddRoles : System.Web.UI.Page
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
            if (!Page.IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
                LoadAccessLevels();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadAccessLevels()
    {
        dataTable = data.getAllUserAccessLevel();
        DataGrid1.DataSource = dataTable;
        DataGrid1.DataBind();
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
                lblCcCode.Text = Convert.ToString(DataGrid1.DataKeys[intIndex].ToString());
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
        MultiView1.ActiveViewIndex = 0;
    }

    protected void cboCompany_DataBound(object sender, EventArgs e)
    {
        cboCompany.Items.Insert(0, new ListItem("--- Select Area ---", "0"));
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

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
    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            string code = e.Item.Cells[0].Text;
            if (e.CommandName == "btnEdit")
            {
                Response.Redirect("./General_EditUser.aspx?transferid=" + code, true);
            }
            else if (e.CommandName == "btnenable")
            {
                string Status = e.Item.Cells[5].Text;
                string returned = Process.ChangeUserStatus(code, Status);
                ShowMessage(returned);
                //LoadUsers();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        DataGrid1.CurrentPageIndex = newPageIndex;
    }
}
