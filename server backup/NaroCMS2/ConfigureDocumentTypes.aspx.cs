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


public partial class ConfigureDocumentTypes : System.Web.UI.Page
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
                LoadDocumentTypes();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message,true);
        }
    }
    private void LoadDocumentTypes()
    {
        dataTable = data.GetDocumentTypes();
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
            string doctype = txtEditDocType.Text.Trim();
            bool Active = CheckEditActive.Checked;
            if (string.IsNullOrEmpty(doctype))
            {
                ShowMessage("Please Enter Document Type", true);
            }
            else
            {
                data.UpdateDocType(lbldoctype.Text, doctype, Active);
                ShowMessage("Document Type (" + doctype + ") has been updated successfull......",false);
                clearControls();
            }
            
            
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, true);
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
        txtDocType.Text = "";
        txtEditDocType.Text = "";
        lblcode.Text = "0";
        CheckBox2.Checked = false;
        CheckEditActive.Checked = false;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clearControls();
        LoadDocumentTypes();
        MultiView1.ActiveViewIndex = 0;

    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }




    protected void Button2_Click1(object sender, EventArgs e)
    {
        try
        {

            string DocTypeName = txtDocType.Text.Trim();
            bool Active = CheckBox2.Checked;
            if (string.IsNullOrEmpty(DocTypeName))
            {
                ShowMessage("Please Type Name", true);
            }
            else
            {
                data.SaveDocType(DocTypeName, Active);
                ShowMessage("Document Type (" + DocTypeName + ") has been added successfull......",false);
                clearControls();
            }
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
    protected void DataGrid2_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            string docid = e.Item.Cells[0].Text;
            lbldoctype.Text = docid;
            if (e.CommandName == "btnEdit")
            {
                DataTable table = data.GetDocumentTypesById(docid);//data.GetAccessLevelsByID(levelid);
                txtEditDocType.Text = table.Rows[0]["DocumentType"].ToString();
                bool active = bool.Parse(table.Rows[0]["Active"].ToString());
                if (active)
                {
                    CheckEditActive.Checked = true;
                }
                else
                {
                    CheckEditActive.Checked = false;
                }
                MultiView1.ActiveViewIndex = 1;
            }
            else if (e.CommandName == "btnenable")
            {
                string code = e.Item.Cells[0].Text;
                bool Status = bool.Parse(e.Item.Cells[2].Text);
                string doctypename = e.Item.Cells[1].Text;
                string returned = Process.ChangeDocTypeStatus(code, Status, doctypename);
                ShowMessage(returned,false);
                LoadDocumentTypes();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, true);
        }
    }
    protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        DataGrid1.CurrentPageIndex = newPageIndex;
    }
}
