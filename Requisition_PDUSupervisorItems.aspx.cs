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
using System.IO;
public partial class Requisition_OfficerViewItems : System.Web.UI.Page
{
    ProcessRequisition Process = new ProcessRequisition();
    ProcessPlanning ProcessOthers = new ProcessPlanning();
    BusinessRequisition bll = new BusinessRequisition();
    ProcessBidding bidd = new ProcessBidding();
    DataTable datatable = new DataTable();
    DataSet dataSet = new DataSet();
    private string Status = "26";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadProcurementMethods();
                LoadItems();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void LoadProcurementMethods()
    {
        cboProcurementMethod.DataSource = ProcessOthers.GetProcurementMethods();
        cboProcurementMethod.DataValueField = "MethodCode";
        cboProcurementMethod.DataTextField = "Method";
        cboProcurementMethod.DataBind();
    }

    private void LoadItems()
    {
        string RecordID = "0";
        string StartDate = txtStartDate.Text.Trim();
        string EndDate = txtEndDate.Text.Trim();
        string PDUCategory = cboPDUCategory.SelectedValue.ToString();
        string ProcMethod = cboProcurementMethod.SelectedValue.ToString();
        string PrNumber = txtPrNumber.Text.Trim();
        string access = Session["AccessLevelID"].ToString();
        if (access == "3")//PM
        {
            cboPDUCategory.Enabled = true;
            datatable = Process.GetPDUSupervisorItems2(RecordID, PrNumber, StartDate, EndDate, PDUCategory, ProcMethod);
        }
        else if (access == "1025")//Large Proc
        {
            cboPDUCategory.Enabled = false;
            cboPDUCategory.SelectedIndex = 2;
            datatable = Process.GetPDUSupervisorItems(RecordID, PrNumber, StartDate, EndDate, PDUCategory, ProcMethod);
        }
        else if (access == "1027")//Small Proc
        {
            cboPDUCategory.Enabled = false;
            cboPDUCategory.SelectedIndex = 1;
            datatable = Process.GetPDUSupervisorItems(RecordID, PrNumber, StartDate, EndDate, PDUCategory, ProcMethod);
        }else if (access == "17")//MD
        {
            cboPDUCategory.Enabled = true;
            datatable = Process.GetPDUSupervisorItems3(RecordID, PrNumber, StartDate, EndDate, PDUCategory, ProcMethod);
        }

           
        if (datatable.Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 0;
            DataGrid1.DataSource = datatable;
            DataGrid1.DataBind();
            lblEmpty.Text = ".";
        }
        else
        {
            MultiView1.ActiveViewIndex = 1;
            string EmptyMessage = "No New Activity Schedule(s) in the system from PDU (" + cboPDUCategory.SelectedItem + ")" + Environment.NewLine;
            EmptyMessage += "from " + bll.ReturnDate(StartDate, 1).ToString("dd-MMM-yyyy") + " to " + bll.ReturnDate(EndDate, 2).ToString("dd-MMM-yyyy");
            lblEmpty.Text = EmptyMessage;
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
   
    protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            // Get Item Name......
           string PRNumber = e.Item.Cells[0].Text;
           if (e.CommandName == "btnApprove")
            {
                Response.Redirect("Requisition_ApproveActivitySchedule.aspx?PR=" + PRNumber, true);
            }
            else if (e.CommandName == "btnViewBid")
            {
                MultiView1.ActiveViewIndex = 2;
                Label1.Text = PRNumber;
                LoadDocuments2();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    
    protected void btnOK_Click(object sender, EventArgs e)
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
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void cboProcurementMethod_DataBound(object sender, EventArgs e)
    {
        cboProcurementMethod.Items.Insert(0, new ListItem(" -- Select Procurement Method -- ", "0"));
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnRemove")
            {
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridView2.DataKeys[intIndex].Value);
                bidd.RemoveDocument(FileCode);
                LoadDocuments2();
            }
            else
            {
                // View 
                int intIndex = Convert.ToInt32(e.CommandArgument);
                string FileCode = Convert.ToString(GridView2.DataKeys[intIndex].Value);
                string Path = bidd.GetDocumentPath(FileCode);
                bidd.DownloadFile(Path, true);
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void LoadDocuments2()
    {
        //MultiView1.ActiveViewIndex = 7;
        string RefNo = Label1.Text;//txtPRNumber2.Text;
        datatable = bidd.GetBiddingDocuments2(RefNo, 0);
        if (datatable.Rows.Count > 0)
        {
            GridView2.DataSource = datatable;
            GridView2.DataBind();
            GridView2.Visible = true;
            //Label2.Visible = false;
        }
        else
        {
            //Label2.Visible = true;
            GridView2.Visible = false;
        }
    }
}
