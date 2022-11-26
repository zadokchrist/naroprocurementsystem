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
                //LoadConfiguredContracts();
                LoadItems();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void LoadItems()
    {
        ProcessRequisition Process2 = new ProcessRequisition();
        string RecordID = "0";
        string contractype = "0";
        string StartDate = "";
        string EndDate = "";
        if (string.IsNullOrEmpty(StartDate))
        {
            StartDate = DateTime.Parse("01/11/2022").ToString();
        }

        if (string.IsNullOrEmpty(EndDate))
        {
            EndDate = DateTime.Parse("01/11/2025").ToString();
        }
        dataTable = Process2.GetUploadedContractsForApproval(contractype, StartDate, EndDate);
        GridWorkFLow.DataSource = dataTable;
        GridWorkFLow.DataBind();
    }

    private void LoadWorkFlows()
    {
        dataTable = data.GetAllWorkFlows("0");
        workflowname.DataSource = dataTable;
        workflowname.DataBind();

    }

    private void LoadConfiguredContracts()
    {
        dataTable = data.GetAllConfiguredContracts("0");
        GridWorkFLow.DataSource = dataTable;
        GridWorkFLow.DataBind();

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
            dataTable = data.GetAllConfiguredContracts(workflowid.Text.Trim());
            txtCcCode.Text = dataTable.Rows[0]["ContractName"].ToString();
            tracttype.Text = dataTable.Rows[0]["ContractType"].ToString();
            bool IsActive = Convert.ToBoolean(dataTable.Rows[0]["IsActive"].ToString());
            CheckBox1.Checked = IsActive;


            dataTable = data.GetAllWorkFlows("0");
            workflowedit.DataSource = dataTable;
            workflowedit.DataBind();
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
    protected void GridWorkFlow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnEdit")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                workflowid.Text = GridWorkFLow.DataKeys[intIndex].Value.ToString();
                loadForm();
            }
            else if (e.CommandName == "btnFiles")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                workflowid.Text = GridWorkFLow.DataKeys[intIndex].Value.ToString();
                LoadDocuments(workflowid.Text);
            }

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void LoadDocuments(string PDCode)
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
    protected void GridCCenter_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            int newPageIndex = e.NewPageIndex;
            GridWorkFLow.PageIndex = newPageIndex;
            LoadWorkFlows();
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
            string Contractname = txtAName.Text.Trim();
            string contracttpe = contracttype.Text.Trim();
            string workflow = workflowname.SelectedValue;
            bool Active = CheckBox2.Checked;
            Process.ConfigureContract(Contractname, contracttpe, workflow, Active);//SaveWorkFlowDetails(Name, Active);

            ShowMessage("Contract (" + Contractname + ") has been configured successfull......");
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

    protected void workflow_DataBound(object sender, EventArgs e)
    {
        workflowname.Items.Insert(0, new ListItem("- - Select Work flow - -", "0"));
    }

}
