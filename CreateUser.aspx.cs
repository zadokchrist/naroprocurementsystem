using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class CreateUser : System.Web.UI.Page
{
    //SystemUsers dac = new SystemUsers();
    ProcessUsers Process = new ProcessUsers();
    DataLogin data = new DataLogin();
    BusinessLogin bll = new BusinessLogin();
    DataTable dataTable = new DataTable();
    private HttpFileCollection uploads2 = HttpContext.Current.Request.Files;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack == false)
            {
                LoadAccessLevels();
                LoadAreas();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    protected void UploadFile(object sender, EventArgs e)
    {
        string folderPath = Server.MapPath("~/Files/");

        //Check whether Directory (Folder) exists.
        if (!Directory.Exists(folderPath))
        {
            //If Directory (Folder) does not exists Create it.
            Directory.CreateDirectory(folderPath);
        }

        //Save the File to the Directory (Folder).
        imgUpload.SaveAs(folderPath + Path.GetFileName(imgUpload.FileName));

        //Display the Picture in Image control.
        Image1.ImageUrl = "~/Files/" + Path.GetFileName(imgUpload.FileName);
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
        //cboAreas.DataSource = dataTable;
        //cboAreas.DataValueField = "AreaID";
        //cboAreas.DataTextField = "Area";
        //cboAreas.DataBind();
    }
    private void LoadCostCenters(int AreaID)
    {
        dataTable = data.GetCostCenters(AreaID);
        //cboCostCenter.DataSource = dataTable;
        //cboCostCenter.DataValueField = "CostCenterID";
        //cboCostCenter.DataTextField = "CostCenterName";
        //cboCostCenter.DataBind();
    }
    private void LoadModules()
    {
        string Access = cboAccessLevel.SelectedItem.ToString();
        dataTable = data.GetSystemModules(Access);
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {

    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            string ModArray = "";
            string FName = TxtFname.Text.Trim();
            string MName = txtMiddleName.Text.Trim();
            string LName = txtLname.Text.Trim();
            string Phone = txtphone.Text.Trim();
            string Email = txtemail.Text.Trim();
            string Disgnation = txtDesignation.Text.Trim();
            int AreaID = 1;//Convert.ToInt32(cboAreas.SelectedValue);
            int AccessLevelID = Convert.ToInt32(cboAccessLevel.SelectedValue);
            int CostCenter = 1;//Convert.ToInt32(cboCostCenter.SelectedValue);
            int Capturedby = Convert.ToInt32(Session["UserID"]);
            bool IsPDUMember = true; 
            bool IsPDUSupervisor = true;
            FileUpload Sign = imgUpload;
            try
            {
                string returned = Process.SaveSystemUser(FName, MName, LName, Disgnation, Email, Phone, AreaID, CostCenter,
                                  IsPDUMember, IsPDUSupervisor, AccessLevelID, ModArray, Capturedby, Sign);
                if (returned.Contains("successfully"))
                {
                    ShowMessage(returned);
                    ClearControls();
                }
                else
                    ShowMessage(returned);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("No such user"))
                    ShowMessage("User's Email Address wasn't found. Please rectify...");
            }

        }
        catch (Exception exc)
        {
            ShowMessage(exc.Message);
        }
    }
    protected void cboAccessLevel_DataBound(object sender, EventArgs e)
    {
        cboAccessLevel.Items.Insert(0, new ListItem("- - Select Access Level - -", "0"));
    }
    protected void cboAccessLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (cboAccessLevel.SelectedValue != "0")
            {
               
            }
            else
            {
            }

        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void cboAreas_DataBound(object sender, EventArgs e)
    {
        //cboAreas.Items.Insert(0, new ListItem("- - Select Area - -", "0"));
    }
    protected void cboCostCenter_DataBound(object sender, EventArgs e)
    {
        //cboCostCenter.Items.Insert(0, new ListItem("- - Select Cost Center - -", "0"));
    }
    protected void cboAreas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int AreaID = 1;//Convert.ToInt32(cboAreas.SelectedValue);
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
        txtphone.Text = "";
        //cboAreas.SelectedIndex = cboAreas.Items.IndexOf(cboAreas.Items.FindByValue("0"));
        //cboCostCenter.SelectedIndex = cboCostCenter.Items.IndexOf(cboCostCenter.Items.FindByValue("0"));
        cboAccessLevel.SelectedIndex = cboAccessLevel.Items.IndexOf(cboAccessLevel.Items.FindByValue("0"));

    }
}