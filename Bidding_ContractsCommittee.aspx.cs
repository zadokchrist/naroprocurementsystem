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

public partial class Bidding_ContractsCommittee : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessPlanning PlanningProcess = new ProcessPlanning();
    DataTable dataTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                MultiView1.ActiveViewIndex = 0;
                LoadContractsCommittees(); LoadPositions();
                LoadItems();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadPositions()
    {
        dataTable = Process.GetPositions("CC");
        cboPositions.DataSource = dataTable;
        cboPositions.DataTextField = "Position"; cboPositions.DataValueField = "PositionID";
        cboPositions.DataBind();
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
    private void LoadContractsCommittees()
    {
        dataTable = Process.GetContractsCommittees();
        cboCC.DataSource = dataTable;
        cboCC.DataValueField = "CCID";
        cboCC.DataTextField = "CCDescription";
        cboCC.DataBind();
    }
    private void LoadContractsCommittees2()
    {
        dataTable = Process.GetContractsCommittees();
        cboCC2.DataSource = dataTable;
        cboCC2.DataValueField = "CCID";
        cboCC2.DataTextField = "CCDescription";
        cboCC2.DataBind();
    }
    private void LoadItems()
    {
        ShowMessage("."); int CC = Convert.ToInt32(cboCC.SelectedValue);
        dataTable = Process.GetCCMembers(CC); GridData.DataSource = dataTable;
        GridData.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            MultiView1.ActiveViewIndex = 1;
            LoadContractsCommittees2(); LoadPositions();
            string TypeSelected = cboCC.SelectedValue.ToString();
            Session["SelectedType"] = TypeSelected;
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

                string TypeSelected = cboCC.SelectedValue.ToString();
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
        long CCUserID = Convert.ToInt32(Label1.Text.Trim());
        LoadContractsCommittees2();
        dataTable = Process.GetCCMemberDetails(CCUserID);
        string CCID = dataTable.Rows[0]["CCID"].ToString();
        cboCC2.SelectedIndex = cboCC2.Items.IndexOf(cboCC2.Items.FindByValue(CCID));
        string Position = dataTable.Rows[0]["PositionID"].ToString();
        cboPositions.SelectedIndex = cboPositions.Items.IndexOf(cboPositions.Items.FindByValue(Position));
        txtName.Text = dataTable.Rows[0]["Name"].ToString();
        txtReason.Text = dataTable.Rows[0]["ReasonForSelection"].ToString();
        bool IsActive = Convert.ToBoolean(dataTable.Rows[0]["IsEnabled"].ToString());
        CheckBox2.Checked = IsActive;
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
            if (cboCC2.SelectedValue == "0")
                ShowMessage("Please Select Contracts Committee");
            else if (cboPositions.SelectedValue == "0")
                ShowMessage("Please Select Position");
            else if (txtName.Text.Trim() == "")
                ShowMessage("Please Enter Name");
            else if (txtReason.Text.Trim() == "")
                ShowMessage("Please Enter Reason of Selection");
            else
            {
                long CC = Convert.ToInt64(cboCC2.SelectedValue); int Position = Convert.ToInt32(cboPositions.SelectedValue);
                string Reason = txtReason.Text.Trim(); long CCUserID;
                dataTable = Process.GetUserByName(txtName.Text.Trim());
                if (dataTable.Rows.Count == 0)
                    throw new Exception("Please Enter Existing User OR Select from drop down returned after typing more than two letters");
                else
                    CCUserID = Convert.ToInt64(dataTable.Rows[0]["UserID"].ToString());

                bool Active = CheckBox2.Checked;
                long CCMemberID = Convert.ToInt64(Label1.Text.Trim());
                Process.SaveEditCCMember(CCMemberID, CC, CCUserID, Position, Reason, Active);
                ShowMessage("Contracts Committee Member Has Been Successfully Saved/Edited...");
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
        txtName.Text = ""; txtReason.Text = "";
        cboCC2.SelectedIndex = cboCC2.Items.IndexOf(cboCC2.Items.FindByValue("0"));
        cboPositions.SelectedIndex = cboPositions.Items.IndexOf(cboPositions.Items.FindByValue("0"));
        Label1.Text = "0";

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            ClearControls();
            MultiView1.ActiveViewIndex = 0;
            string former = Session["SelectedType"].ToString();
            cboCC.SelectedIndex = cboCC.Items.IndexOf(cboCC.Items.FindByValue(former));
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
    protected void cboCC_SelectedIndexChanged(object sender, EventArgs e)
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
    protected void cboCC_DataBound(object sender, EventArgs e)
    {
        cboCC.Items.Insert(0, new ListItem(" -- Select Contracts Committee -- ", "0"));
    }
    protected void cboPositions_DataBound(object sender, EventArgs e)
    {
        cboPositions.Items.Insert(0, new ListItem(" -- Select Position -- ", "0"));
    }
}
