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


public partial class Bidding_CCSchedule : System.Web.UI.Page
{
    ProcessBidding Process = new ProcessBidding();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    ProcessPlanning ProcessPlan = new ProcessPlanning();
    BusinessBidding bll = new BusinessBidding();
    DataTable dtable = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadContractsCommittee();
        }
        else
            LoadReport();
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
    private void LoadContractsCommittee()
    {
        cboCC.DataSource = Process.GetContractsCommittees();
        cboCC.DataValueField = "CCID"; cboCC.DataTextField = "CCDescription";
        cboCC.DataBind();

        string CC = bll.GetUserContractsCommittee(Session["UserID"].ToString());
        if (CC != "0")
        {
            cboCC.SelectedIndex = cboCC.Items.IndexOf(cboCC.Items.FindByValue(CC));
            cboCC.Enabled = false;
        }
        else
        {
            cboCC.SelectedIndex = cboCC.Items.IndexOf(cboCC.Items.FindByValue("0"));
            cboCC.Enabled = true;
        }
    }
    protected void cboCC_DataBound(object sender, EventArgs e)
    {
        cboCC.Items.Insert(0, new ListItem(" -- Select Contracts Committee -- ", "0"));
    }
    private void Hidetoolbar()
    {
        
    }
    private void Page_Unload(object sender, EventArgs e)
    {
        //if (doc != null)
        //{
        //    doc.Close();
        //    doc.Dispose();
        //    GC.Collect();
        //}
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        try
        {
            if (cboCC.SelectedValue == "0")
                ShowMessage("Please Select Contracts Committee");
            else if (cboSchedule.SelectedValue == "0")
                ShowMessage("Please Select Schedule");
            else if (cboStatus.SelectedValue == "0")
                ShowMessage("Please Select Status");
            else
                LoadReport();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadReport()
    {
        string appPath, physicalPath, rptName;
        appPath = HttpContext.Current.Request.ApplicationPath;
        physicalPath = HttpContext.Current.Request.MapPath(appPath);
        long CCID = Convert.ToInt64(cboCC.SelectedValue);
        string CCRefNo = txtMeetingRefNo.Text.Trim();
        int Status = Convert.ToInt32(cboStatus.SelectedValue);
        int YearID = Convert.ToInt32(Session["BFinYearCode"].ToString());
        int AreaID = 0; // Convert.ToInt32(Session["AreaCode"].ToString());
        long CCMemberID = 0;
        if (bll.IsContractCommitteeUser(Session["UserID"].ToString()))
            CCMemberID = Convert.ToInt64(Session["UserID"].ToString());
        rptName = physicalPath + "\\Bin\\Reports\\Bidding\\CCAwardOfContractsSchedule.rpt";

        if (cboSchedule.SelectedValue == "2" && Status == 2 && String.IsNullOrEmpty(txtMeetingRefNo.Text.Trim()))
        {
            ShowMessage("Please Enter C. C. Meeting Reference Number");
        }
        else if (cboSchedule.SelectedValue == "1")
        {
            dtable = Process.GetReportForProcurementMethodSchedule(CCID, CCMemberID, CCRefNo, Status, YearID, AreaID);
            rptName = physicalPath + "\\Bin\\Reports\\Bidding\\ApprovedCCProcMethodSchedule.rpt";
            DisplayReport(rptName);
        }
        else if (cboSchedule.SelectedValue == "2")
        {
            if (Status == 2)
                rptName = physicalPath + "\\Bin\\Reports\\Bidding\\ApprovedCCAwardOfContractsSchedule.rpt";
            dtable = Process.GetReportForAwardOfContractsSchedule(CCID, CCMemberID, CCRefNo, Status, YearID, AreaID);
            DisplayReport(rptName);
        } // Ractification Report
        else if (cboSchedule.SelectedValue == "3")
        {
            dtable = Process.GetReportForRactification(CCID, CCMemberID, YearID, 0);
            DisplayReport(rptName);
        }
    }

    private void DisplayReport(String rptName)
    {
        if (dtable.Rows.Count > 0)
        {
            //doc.Load(rptName);
            //doc.SetDataSource(dtable);
            //Hidetoolbar();
            //CrystalReportViewer1.ReportSource = doc;
            //CrystalReportViewer1.Visible = true;
            btnPrint.Enabled = true; btnExportToExcel.Enabled = true;
        }
        else
        {
            btnPrint.Enabled = false; btnExportToExcel.Enabled = false;
            ShowMessage("No Record(s) Found ...");
            //CrystalReportViewer1.Visible = false;
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        LoadReport();
        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
        //doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Proc. Method CC Schedule");
    }
    protected void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboStatus.SelectedValue == "2")
        {
            txtMeetingRefNo.Enabled = true; txtMeetingRefNo.Text = "";
        }
        else
        {
            txtMeetingRefNo.Enabled = false; txtMeetingRefNo.Text = "";
        }
    }
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        LoadReport();
        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();
        //doc.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, true, "Proc. Method CC Schedule");
    }
}
