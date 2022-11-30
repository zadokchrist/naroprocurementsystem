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
    protected void cboCCcategory_DataBound(object sender, EventArgs e)
    {

    }



    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            string LevelName = txtEditLevelName.Text.Trim();
            string description = txtEditDescription.Text;
            bool Active = CheckEditActive.Checked;
            if (string.IsNullOrEmpty(LevelName))
            {
                ShowMessage("Please Enter Level Name");
            }
            else if (string.IsNullOrEmpty(description))
            {
                ShowMessage("Please Enter Description");
            }
            else
            {
                Process.UpdateAccessLevelDetails(lblLevelid.Text, LevelName, description, Active);
                ShowMessage("Access Level (" + LevelName + ") has been updated successfull......");
                clearControls();
            }
            
            
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void GridCCenter_RowCreated(object sender, GridViewRowEventArgs e)
    {

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
        txtdescript.Text = "";
        txtAName.Text = "";
        txtEditLevelName.Text = "";
        lblcode.Text = "0";
        txtEditDescription.Text = "";
        CheckBox2.Checked = false;
        CheckEditActive.Checked = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearControls();
        LoadAccessLevels();
        MultiView1.ActiveViewIndex = 0;

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }




    protected void Button2_Click1(object sender, EventArgs e)
    {
        try
        {

            string LevelName = txtAName.Text.Trim();
            string description = txtdescript.Text;
            bool Active = CheckBox2.Checked;
            if (string.IsNullOrEmpty(LevelName))
            {
                ShowMessage("Please Enter Level Name");
            }
            else if (string.IsNullOrEmpty(description))
            {
                ShowMessage("Please Enter Description");
            }
            else
            {
                Process.SaveAccessLevel(LevelName, description, Active);
                ShowMessage("Access Level (" + LevelName + ") has been added successfull......");
                clearControls();
            }
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
            string levelid = e.Item.Cells[0].Text;
            lblLevelid.Text = levelid;
            if (e.CommandName == "btnEdit")
            {
                DataTable table = data.GetAccessLevelsByID(levelid);
                txtEditLevelName.Text = table.Rows[0]["LevelName"].ToString();
                txtEditDescription.Text = table.Rows[0]["Description"].ToString();
                bool active = bool.Parse(table.Rows[0]["Active"].ToString());
                if (active)
                {
                    CheckEditActive.Checked = true;
                }
                else
                {
                    CheckEditActive.Checked = false;
                }
                MultiView1.ActiveViewIndex = 1;
            }
            else if (e.CommandName == "btnenable")
            {
                string code = e.Item.Cells[0].Text;
                string Status = e.Item.Cells[3].Text;
                string returned = Process.ChangeAccessLevelStatus(code, Status);
                ShowMessage(returned);
                LoadAccessLevels();
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
