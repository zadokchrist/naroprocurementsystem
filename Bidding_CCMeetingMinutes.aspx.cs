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
using System.Text.RegularExpressions;

public partial class Bidding_CCMeetingMinutes : System.Web.UI.Page
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
    protected void btnOK_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        try
        {
            int CC = Convert.ToInt32(cboCC.SelectedValue);
            string CCRefNo = txtCCRefNo.Text.Trim();

            LoadDocuments(CCRefNo, 3);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    private void LoadDocuments(string CCRefNo, int DocumentTypeID)
    {
        dtable = Process.GetCCMeetingMinutes(CCRefNo, DocumentTypeID);
        if (dtable.Rows.Count > 0)
        {
            GridAttachments.DataSource = dtable;
            GridAttachments.DataBind();
            GridAttachments.Visible = true;
            lblNoAttachments.Visible = false;
        }
        else
        {
            lblNoAttachments.Visible = true;
            GridAttachments.Visible = false;
        }
    }
    protected void btnSaveFile_Click(object sender, EventArgs e)
    {
        ShowMessage(".");
        if (txtCCRefNo.Text.Trim() == "")
            ShowMessage("Please Enter CC Meeting Reference No.");
        else
        {
            string CCMeetingRefNo = Regex.Replace(txtCCRefNo.Text.Trim(), "[^A-Za-z0-9]", "");
            UploadFiles(CCMeetingRefNo);
            ShowMessage("File(s) Have Been Successfully Uploaded");
        }
    }
    private void UploadFiles(string CCMeetingRefNo)
    {
        HttpFileCollection uploads;
        uploads = HttpContext.Current.Request.Files;
        int countfiles = 0;
        for (int i = 0; i <= (uploads.Count - 1); i++)
        {
            if (uploads[i].ContentLength > 0)
            {
                string c = System.IO.Path.GetFileName(uploads[i].FileName);
                string cNoSpace = c.Replace(" ", "-");
                string c1 = CCMeetingRefNo + "_" + (countfiles + i + 1) + "_" + cNoSpace;
                string Path = Process.GetDocPath();
                FileField.PostedFile.SaveAs(Path + "" + c1);
                Process.SaveBiddingDocument(CCMeetingRefNo, (Path + "" + c1), c, 3);
            }
        }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void GridAttachments_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    public bool IsFileRemoveable(int IsRemoveable)
    {
        if (IsRemoveable == 1)
            return true;
        else
            return false;
    }
}
