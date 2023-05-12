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

public partial class General_EditUser : System.Web.UI.Page
{
    ProcessUsers Process = new ProcessUsers();
    DataLogin data = new DataLogin();
    BusinessLogin bll = new BusinessLogin();
    DataTable dataTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                if (Request.QueryString["transferid"] != null)
                {
                    LoadAccessLevels();
                    LoadAreas();
                    chkModule.Items.Clear();
                    string UserCode = Request.QueryString["transferid"].ToString();
                    LoadControls(UserCode);
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadControls(string Code)
    {
        dataTable = Process.GetUserDetails(Code);
        TxtFname.Text = dataTable.Rows[0]["FirstName"].ToString();
        txtMiddleName.Text = dataTable.Rows[0]["MiddleName"].ToString();
        txtLname.Text = dataTable.Rows[0]["LastName"].ToString();
        txtemail.Text = dataTable.Rows[0]["Email"].ToString();
        txtDesignation.Text = dataTable.Rows[0]["Designation"].ToString();
        txtphone.Text = dataTable.Rows[0]["PhoneNumber"].ToString();
        string AreaCode = dataTable.Rows[0]["AreaID"].ToString();
        txtUsername.Text = dataTable.Rows[0]["Username"].ToString();
        string CostCenterID = dataTable.Rows[0]["CostCenterID"].ToString();
        string AccessLevelID = dataTable.Rows[0]["AccessLevelID"].ToString();
        string UserID = dataTable.Rows[0]["UserID"].ToString();
        lblUsername.Text = dataTable.Rows[0]["Username"].ToString();
        chkIsPDUMember.Checked = Convert.ToBoolean(dataTable.Rows[0]["IsPDUMember"].ToString());
        chkIsInventoryStaff.Checked = Convert.ToBoolean(dataTable.Rows[0]["IsInventoryStaff"].ToString());
        chkIsPDUSupervisor.Checked = Convert.ToBoolean(dataTable.Rows[0]["IsPDUSupervisor"].ToString());
        if (chkIsPDUMember.Checked)
            chkIsPDUSupervisor.Visible = true;
        cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue(AreaCode));
        if (AreaCode != "")
        {
            int AreaID = Convert.ToInt32(AreaCode);
            LoadCostCenters(AreaID);
            cboCostCenter.SelectedIndex = cboCostCenter.Items.IndexOf(cboCostCenter.Items.FindByValue(CostCenterID));
            cboAccessLevel.SelectedIndex = cboAccessLevel.Items.IndexOf(cboAccessLevel.Items.FindByValue(AccessLevelID));
        }
        LoadUserModules(UserID);
    }

    private void LoadUserModules(string UserCode)
    {
        dataTable = Process.GetUserModules(UserCode);
        MultiView1.ActiveViewIndex = 0;
        GridData.DataSource = dataTable;
        GridData.DataBind();
        Label1.Text = UserCode;
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
    private void LoadAccessLevels()
    {
        dataTable = data.GetAccessLevels();
        cboAccessLevel.DataSource = dataTable;
        cboAccessLevel.DataValueField = "LevelID";
        cboAccessLevel.DataTextField = "LevelName";
        cboAccessLevel.DataBind();
    }
    private void LoadAreas()
    {
        dataTable = data.GetAreas();
        cboAreas.DataSource = dataTable;
        cboAreas.DataValueField = "AreaID";
        cboAreas.DataTextField = "Area";
        cboAreas.DataBind();
    }
    private void LoadCostCenters(int AreaID)
    {
        dataTable = data.GetCostCenters(AreaID);
        cboCostCenter.DataSource = dataTable;
        cboCostCenter.DataValueField = "CostCenterID";
        cboCostCenter.DataTextField = "CostCenterName";
        cboCostCenter.DataBind();
    }
    private void LoadModules()
    {
        string Access = cboAccessLevel.SelectedItem.ToString();
        dataTable = data.GetSystemModules(Access);
        chkModule.DataSource = dataTable;
        chkModule.DataTextField = "ModuleName";
        chkModule.DataValueField = "ModuleID";
        chkModule.DataBind();

    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            string UserCode = Label1.Text.Trim();
            string FName = TxtFname.Text.Trim();
            string MName = txtMiddleName.Text.Trim();
            string LName = txtLname.Text.Trim();
            string Phone = txtphone.Text.Trim();
            string Email = txtemail.Text.Trim();
            string Disgnation = txtDesignation.Text.Trim();
            int AreaID = Convert.ToInt32(cboAreas.SelectedValue);
            int AccessLevelID = Convert.ToInt32(cboAccessLevel.SelectedValue);
            int CostCenter = Convert.ToInt32(cboCostCenter.SelectedValue);
            int reset = IsReset(); string Username = txtUsername.Text;
            bool IsInventoryStaff = chkIsInventoryStaff.Checked;
            bool IsPDUMember = chkIsPDUMember.Checked; bool IsPDUSupervisor = chkIsPDUSupervisor.Checked;
            bool isRemoved = CheckBox2.Checked;
            FileUpload Sign = imgUpload;
            string returned = Process.UpdateSystemUser(UserCode, Username, FName, MName, LName, Disgnation, Email, Phone, AreaID, CostCenter, IsPDUMember, IsPDUSupervisor, IsInventoryStaff, AccessLevelID, reset, Sign, isRemoved);

            if (returned.Contains("successfully"))
            {
                ShowMessage(returned);
                ClearControls();
            }
            else
            {
                ShowMessage(returned);
            }
        }
        catch (Exception exc)
        {
            ShowMessage(exc.Message);
        }
    }

    private int IsReset()
    {
        int reset = 0;
        if (CheckBox1.Checked == true)
        {
            reset = 1;
        }
        return reset;
    }

    protected void cboAccessLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cboAccessLevel.SelectedValue != "0")
            {
                chkModule.Enabled = true;
                LoadModules();
            }
            else
            {
                chkModule.Enabled = false;
                chkModule.Items.Clear();
            }

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboAccessLevel_DataBound(object sender, EventArgs e)
    {
        cboAccessLevel.Items.Insert(0, new ListItem("- - Select Access Level - -", "0"));
    }
    protected void cboAreas_DataBound(object sender, EventArgs e)
    {
        cboAreas.Items.Insert(0, new ListItem("- - Select Area - -", "0"));
    }
    protected void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int AreaID = Convert.ToInt32(cboAreas.SelectedValue);
            LoadCostCenters(AreaID);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void ClearControls()
    {
        txtDesignation.Text = "";
        txtemail.Text = "";
        TxtFname.Text = "";
        txtLname.Text = "";
        txtMiddleName.Text = "";
        txtUsername.Text = "";
        txtphone.Text = "";
        chkModule.Items.Clear();
        cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue("0"));
        cboCostCenter.SelectedIndex = cboCostCenter.Items.IndexOf(cboCostCenter.Items.FindByValue("0"));
        cboAccessLevel.SelectedIndex = cboAccessLevel.Items.IndexOf(cboAccessLevel.Items.FindByValue("0"));

    }
    protected void cboCostCenter_DataBound(object sender, EventArgs e)
    {
        cboCostCenter.Items.Insert(0, new ListItem("- - Select Cost Center - -", "0"));
    }
    protected void GridData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnRemove")
            {
                string UserCode = Label1.Text.Trim();
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string Code = Convert.ToString(GridData.DataKeys[intIndex].Value);
                Process.WithdrawModule(UserCode, Code);
                LoadUserModules(UserCode);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private string GetSelectedModules()
    {
        string values = "";
        for (int i = 0; i < chkModule.Items.Count; i++)
        {
            if (chkModule.Items[i].Selected)
            {
                values += chkModule.Items[i].Value + ",";
            }
        }

        values = values.TrimEnd(',');
        return values;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            MultiView1.ActiveViewIndex = 1;
            LoadOtherModules();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadOtherModules()
    {
        string Access = cboAccessLevel.SelectedValue.ToString();
        string UserID = Label1.Text.Trim();
        dataTable = Process.GetOtherModules(UserID, Access);

        if (dataTable.Rows.Count > 0)
        {
            chkModule.Visible = true;
            chkModule.DataSource = dataTable;
            chkModule.DataTextField = "ModuleName";
            chkModule.DataValueField = "ModuleID";
            chkModule.DataBind();
            Label2.Visible = false;
            chkModule.Enabled = true;
        }
        else
        {
            chkModule.Visible = false;
            Label2.Visible = true;
        }
        chkModule.Visible = true;
        Label2.Visible = false;
        chkModule.Enabled = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string UserCode = Label1.Text.Trim();
            LoadUserModules(UserCode);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void chkModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string UserCode = Label1.Text.Trim();
            string Module = chkModule.SelectedValue.ToString();
            Process.AddModule(UserCode, Module);
            LoadOtherModules();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void chkIsPDUMember_CheckedChanged(object sender, EventArgs e)
    {
        if (chkIsPDUMember.Checked == true)
            chkIsPDUSupervisor.Visible = true;
        else
            chkIsPDUSupervisor.Visible = true;
    }
}
