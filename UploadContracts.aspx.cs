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
                LoadConfiguredContracts();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, true);
        }
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
            string contract_id = contractid.Text;
            string subject = comment.Text;
            string contractname = contname.Text;
            string contracttype = conttype.Text;
            
            if (string.IsNullOrEmpty(subject))   
            {
                ShowMessage("Please Enter Contract subject", true);
            }
            else
            {
                string uploadedcontid = data.InsertUploadedContract(contract_id, subject).Rows[0]["Contractid"].ToString();
                string workflowid = data.GetAllConfiguredContracts(contract_id).Rows[0]["WorkflowId"].ToString();
                string userid = Session["UserID"].ToString();
                string code = uploadedcontid;
                dataTable = data.GetStatusesByWorkflowid(workflowid);
                string status = dataTable.Rows[0]["StatusID"].ToString();
                string remark = dataTable.Rows[0]["Description"].ToString();
                data.NextContractStatus(uploadedcontid, workflowid, remark, userid, status);
                UploadFiles(code);
                ShowMessage("Contract Uploaded and forwarded to the next step for processing......",false);
            }
            
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, true);
        }
    }
    private void saveDetails()
    {
        try
        {
            int ccid = Convert.ToInt32(lblcode.Text.Trim());
            //string CostCenterCode = txtCcCode.Text.Trim();
            string compareCode = lblCcCode.Text.Trim();
            string compareInitials = lblInitials.Text.Trim();
           

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, true);
        }
    }

    private void loadForm()
    {
        try
        {
            MultiView1.ActiveViewIndex = 1;
            dataTable = data.GetAllConfiguredContracts(contractid.Text.Trim());
            contname.Text = dataTable.Rows[0]["ContractName"].ToString();
            conttype.Text = dataTable.Rows[0]["ContractType"].ToString();
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
    private void ShowMessage(string Message, bool Color)
    {
        Label msg = (Label)Master.FindControl("lblmsg");
        if (Color)
        {
            msg.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            msg.ForeColor = System.Drawing.Color.Green;
        }
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
        //txtCcCode.Text = "";
        //txtAName.Text = "";
        //txtCcCode.Text = "";
        //lblcode.Text = "0";
        //CheckBox2.Checked = false;
        //CheckBox1.Checked = false;
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
            ShowMessage(ex.Message, true);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }





    private void UploadFiles(string PlanCode)
    {
        try
        {
            string uploadedby = Session["FullName"].ToString();
            ProcessRequisition processdoc = new ProcessRequisition();
            ProcessPlanning ProcessOther = new ProcessPlanning();
            HttpFileCollection uploads;
            uploads = HttpContext.Current.Request.Files;
            int countfiles = 0;
            for (int i = 0; i <= (uploads.Count - 1); i++)
            {
                if (uploads[i].ContentLength > 0)
                {
                    string c = System.IO.Path.GetFileName(uploads[i].FileName);
                    string cNoSpace = c.Replace(" ", "-");
                    string c1 = PlanCode + "_" + (countfiles + i + 1) + "_" + cNoSpace;
                    string Path = processdoc.GetDocPath();
                    FileField.PostedFile.SaveAs(Path + "" + c1);
                    ProcessOther.SavePlanDocuments(PlanCode, (Path + "" + c1), c, false, uploadedby);

                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, true);
        } 
        
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

            ShowMessage("Contract (" + Contractname + ") has been configured successfull......",false);
            clearControls();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, true);
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

    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            string code = e.Item.Cells[0].Text;
            if (e.CommandName == "btnEdit")
            {
                contractid.Text = code;
                loadForm();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message,true);
        }
    }

    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        DataGrid1.CurrentPageIndex = newPageIndex;
        LoadConfiguredContracts();
    }

}
