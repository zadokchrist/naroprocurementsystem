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

public partial class General_ItemCategory : System.Web.UI.Page
{
    ProcessUsers Process = new ProcessUsers();
    ProcessPlanning PlanningProcess = new ProcessPlanning();
    DataLogin data = new DataLogin();
    BusinessLogin bll = new BusinessLogin();
    DataTable dataTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                MultiView1.ActiveViewIndex = 0;
                LoadProcurementTypes();
                LoadItems();
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
    private void LoadProcurementTypes()
    {
        dataTable = PlanningProcess.GetProcurementTypes();
        cboProcType.DataSource = dataTable;
        cboProcType.DataValueField = "Code";
        cboProcType.DataTextField = "Type";
        cboProcType.DataBind();
    }
    private void LoadProcurementTypes2()
    {
        dataTable = PlanningProcess.GetProcurementTypes();
        cboProcType2.DataSource = dataTable;
        cboProcType2.DataValueField = "Code";
        cboProcType2.DataTextField = "Type";
        cboProcType2.DataBind();
    }
    private void LoadItems()
    {
        string ProcType = cboProcType.SelectedValue.ToString();
        dataTable = PlanningProcess.GetItemCategoriesDatails(ProcType);
        GridData.DataSource = dataTable;
        GridData.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            MultiView1.ActiveViewIndex = 1;
            LoadProcurementTypes2();
            string TypeSelected = cboProcType.SelectedValue.ToString();
            Session["SelectedType"] = TypeSelected;
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboProcType_DataBound(object sender, EventArgs e)
    {
        cboProcType.Items.Insert(0, new ListItem("- - All Procurement Type - -", "0"));
    }
    protected void cboProcType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LoadItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void GridData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnEdit")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                Label1.Text = Convert.ToString(GridData.DataKeys[intIndex].Value);

                string TypeSelected = cboProcType.SelectedValue.ToString();
                Session["SelectedType"] = TypeSelected;
                loadForm();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void loadForm()
    {
        MultiView1.ActiveViewIndex = 1;
        int RecordID = Convert.ToInt32(Label1.Text.Trim());
        LoadProcurementTypes2();
        dataTable = PlanningProcess.GetItemCategoryDatails(RecordID);
        txtName.Text = dataTable.Rows[0]["Name"].ToString();
        txtRank.Text = dataTable.Rows[0]["Ranking"].ToString();
        string Type = dataTable.Rows[0]["ProcurementTypeID"].ToString();
        bool IsActive = Convert.ToBoolean(dataTable.Rows[0]["Active"].ToString());
        cboProcType2.SelectedIndex = cboProcType2.Items.IndexOf(cboProcType2.Items.FindByValue(Type));
        CheckBox2.Checked = IsActive;
    }
    protected void cboProcType2_DataBound(object sender, EventArgs e)
    {
        cboProcType2.Items.Insert(0, new ListItem("- - Select Procurement Type - -", "0"));
    }
    protected void GridData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int newPageIndex = e.NewPageIndex;
            GridData.PageIndex = newPageIndex;
            LoadItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            string ProcType = cboProcType2.SelectedValue.ToString();
            string Name = txtName.Text.Trim();
            string Rank = txtRank.Text.Trim();
            bool Active = CheckBox2.Checked;
            string Record = Label1.Text.Trim();
            string returned = PlanningProcess.SaveItemCategory(Record, ProcType, Name, Rank, Active);
            ShowMessage(returned);
            if (returned.Contains("Successfully"))
            {
                ClearControls();
            }

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void ClearControls()
    {
        txtName.Text = "";
        txtRank.Text = "";
        cboProcType2.SelectedIndex = cboProcType2.Items.IndexOf(cboProcType2.Items.FindByValue("0"));
        Label1.Text = "0";

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            MultiView1.ActiveViewIndex = 0;
            string former = Session["SelectedType"].ToString();
            cboProcType.SelectedIndex = cboProcType.Items.IndexOf(cboProcType.Items.FindByValue(former));
            LoadItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }

    }
    protected void GridData_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
