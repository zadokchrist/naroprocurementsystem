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


public partial class AddWorkFlow : System.Web.UI.Page
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
                LoadWorkFlows();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }


    private void LoadWorkFlows()
    {
        dataTable = data.GetAllWorkFlows("0");
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
            string Name = txtCcCode.Text.Trim();
            bool Active = CheckBox1.Checked;
            string flowid = workflowid.Text;
            Process.UpdateWorkFlowDetails(Name, Active, flowid);

            ShowMessage("Workflow (" + Name + ") has been updated successfull......");
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
            dataTable = data.GetAllWorkFlows(workflowid.Text.Trim());
            txtCcCode.Text = dataTable.Rows[0]["WorkFlowName"].ToString();

            bool IsActive = Convert.ToBoolean(dataTable.Rows[0]["IsActive"].ToString());
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
        LoadWorkFlows();
        MultiView1.ActiveViewIndex = 0;



    }

    protected void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LoadWorkFlows();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
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
            Process.SaveWorkFlowDetails(Name, Active);

            ShowMessage("Workflow (" + Name + ") has been added successfull......");
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

    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        DataGrid1.CurrentPageIndex = newPageIndex;
        LoadWorkFlows();
    }

    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            string code = e.Item.Cells[0].Text;
            if (e.CommandName == "btnEdit")
            {
                workflowid.Text = code;
                loadForm();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

}
