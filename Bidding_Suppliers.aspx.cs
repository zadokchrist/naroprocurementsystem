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

public partial class Bidding_Suppliers : System.Web.UI.Page
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
                LoadProcurementTypes();
                LoadCategories(0);
                LoadSubCategories(0);
                LoadItems();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void LoadCategories(int v)
    {
        dataTable = Process.GetBidderNewCategories(v);
        ddlSubCategory.DataSource = dataTable;
        ddlSubCategory.DataTextField = "CategoryName";
        ddlSubCategory.DataValueField = "BidderCategoryID"; 
        ddlSubCategory.DataBind();
        ddlCategories2.DataSource = dataTable;
        ddlCategories2.DataTextField = "CategoryName";
        ddlCategories2.DataValueField = "BidderCategoryID";
        ddlCategories2.DataBind();
        ddlSubCategory.Items.Insert(0, new ListItem("-- Select Category --", "0"));
    }
    private void LoadSubCategories(int v)
    {
        dataTable = Process.GetBidderSubCategoriesByProcType(v);
        ddlcategory2.DataSource = dataTable;
        ddlcategory2.DataTextField = "subCategoryName";
        ddlcategory2.DataValueField = "bidderSubCategoryId";
        ddlcategory2.DataBind();
        ddlSubCategories2.DataSource = dataTable;
        ddlSubCategories2.DataTextField = "subCategoryName";
        ddlSubCategories2.DataValueField = "bidderSubCategoryId";
        ddlSubCategories2.DataBind();
        ddlcategory2.Items.Insert(0, new ListItem("-- Select Sub Category --", "0"));
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
        dataTable = Process.GetBiddingProcurementTypes();
        cboProcType.DataSource = dataTable;
        cboProcType.DataValueField = "TypeID";
        cboProcType.DataTextField = "ProcurementType";
        cboProcType.DataBind();
    }
    private void LoadCategories()
    {
        int TypeID = Convert.ToInt32(cboProcType2.SelectedValue);
        cboCategories.DataSource = Process.GetBidderCategoriesByProcType(TypeID);
        cboCategories.DataTextField = "CategoryName";
        cboCategories.DataValueField = "BidderCategoryID";
        cboCategories.DataBind();
    }
    private void LoadProcurementTypes2()
    {
        dataTable = Process.GetBiddingProcurementTypes();
        cboProcType2.DataSource = dataTable;
        cboProcType2.DataValueField = "TypeID";
        cboProcType2.DataTextField = "ProcurementType";
        cboProcType2.DataBind();

        LoadCategories();
    }
    private void LoadItems()
    {
        int ProcType = Convert.ToInt32(cboProcType.SelectedValue);
        int Category = Convert.ToInt32(ddlSubCategory.SelectedValue);
        int subCategory = int.Parse(ddlcategory2.SelectedValue);
        dataTable = Process.GetSuppliersByCategory(ProcType,Category, subCategory);
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
        cboProcType.Items.Insert(0, new ListItem("- - All Supplier Categories - -", "0"));
    }
    protected void cboProcType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int type = int.Parse(cboProcType.SelectedValue);
            LoadCategories(type);
            LoadSubCategories(type);
            LoadItems();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
    protected void GridData_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "btnEdit")
            {
                int intIndex = Convert.ToInt32(e.Item.Cells[0].Text);
                Label1.Text = Convert.ToString(e.Item.Cells[0].Text);

                string TypeSelected = cboProcType.SelectedValue.ToString();
                Session["SelectedType"] = TypeSelected;
                loadForm();
            }
            else if (e.CommandName == "btnClassifications")
            {
                int intIndex = Convert.ToInt32(e.Item.Cells[0].Text);
               string bidder = Convert.ToString(e.Item.Cells[0].Text);
                lblBidderId.Text = bidder;
                loadBidderSubcategories(int.Parse(bidder));
                MultiView1.ActiveViewIndex = 2;
                

            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void loadBidderSubcategories(int bidder)
    {
        dataTable = Process.getBidderClassifications (bidder);
        if (dataTable.Rows.Count > 0)
        {
            DataGrid5.DataSource = dataTable;
            DataGrid5.DataBind();
        }else
        {
            DataGrid5.DataSource = null;
            DataGrid5.DataBind();
            ShowMessage("No classifications found. Add new classifications");
        }
    }

    private void loadForm()
    {
        MultiView1.ActiveViewIndex = 1;
        long BidderID = Convert.ToInt32(Label1.Text.Trim()); LoadProcurementTypes2(); 
        dataTable = Process.GetBidderDetails(BidderID); string Type = dataTable.Rows[0]["TypeID"].ToString();
        cboProcType2.SelectedIndex = cboProcType2.Items.IndexOf(cboProcType2.Items.FindByValue(Type));
        LoadCategories(); string Category = dataTable.Rows[0]["BiddercategoryID"].ToString();
        cboCategories.SelectedIndex = cboCategories.Items.IndexOf(cboCategories.Items.FindByValue(Category));
        txtSupplierName.Text = dataTable.Rows[0]["CompanyName"].ToString();
        txtDirectorNames.Text = dataTable.Rows[0]["DirectorNames"].ToString();
        txtPhysicalAddress.Text = dataTable.Rows[0]["PhysicalAddress"].ToString();
        txtPhoneNumbers.Text = dataTable.Rows[0]["PhoneNumbers"].ToString();
        txtEmailAddress.Text = dataTable.Rows[0]["EmailAddress"].ToString();
        txtRemarks.Text = dataTable.Rows[0]["Remarks"].ToString();
        bool IsActive = Convert.ToBoolean(dataTable.Rows[0]["IsActive"].ToString());
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
            GridData.SelectedIndex = newPageIndex;
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
            if (cboProcType2.SelectedValue == "0")
                ShowMessage("Please Select Supplier Category");
            //else if (cboCategories.SelectedValue == "0")
            //    ShowMessage("Please Select Supplier Sub Category");
            else if (txtSupplierName.Text.Trim() == "")
                ShowMessage("Please Enter Supplier Name");
            //else if (txtDirectorNames.Text.Trim() == "")
            //    ShowMessage("Please Enter Names of Directors");
            //else if (txtPhysicalAddress.Text.Trim() == "")
            //    ShowMessage("Please Enter Physical Address of Supplier");
            //else if (txtPhoneNumbers.Text.Trim() == "")
            //    ShowMessage("Please Enter Phone Number(s) of Supplier");
            else
            {
                string ProcType = cboProcType2.SelectedValue; long Category = Convert.ToInt64(cboCategories.SelectedValue);
                string SupplierName = txtSupplierName.Text.Trim(); string DirectorNames = txtDirectorNames.Text.Trim();
                string PhysicalAddress = txtPhysicalAddress.Text.Trim(); string PhoneNumbers = txtPhoneNumbers.Text.Trim();
                string EmailAddress = txtEmailAddress.Text.Trim(); string Remarks = txtRemarks.Text.Trim();
                bool Active = CheckBox2.Checked;
                long BidderID = Convert.ToInt64(Label1.Text.Trim());
                String ppa = txtPPACode.Text;
                long bidcatid = int.Parse(cboCategories.SelectedValue);
                Process.SaveEditBidders(BidderID, SupplierName, DirectorNames, PhysicalAddress, PhoneNumbers, EmailAddress, Category,ppa,txtRemarks.Text, Active); 
                ShowMessage("Bidder Has Been Successfully Saved/Edited...");
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
        txtRemarks.Text = ""; txtSupplierName.Text = ""; txtPhysicalAddress.Text = ""; txtPhoneNumbers.Text = "";
        txtEmailAddress.Text = ""; txtDirectorNames.Text = "";
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
            ShowMessage(".");
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }

    }
    protected void GridData_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void cboCategories_DataBound(object sender, EventArgs e)
    {
        cboCategories.Items.Insert(0, new ListItem(" -- Select Sub Category -- ", "0"));
    }
    protected void cboProcType2_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCategories();
    }


    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadItems();
    }

    protected void ddlcategory2_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadItems();
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        ShowMessage(".");
    }

    protected void btnSaveFile_Click(object sender, EventArgs e)
    {

        int bidderId = int.Parse(lblBidderId.Text);
        int category = int.Parse(ddlCategories2.SelectedValue);
        int subcategory = int.Parse(ddlSubCategories2.SelectedValue);

        Process.saveBidderClassification(bidderId, category, subcategory);
        ShowMessage("Classification added!");
        loadBidderSubcategories(bidderId);
    }

    protected void DataGrid5_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "btnRemove")
        {
            int recordId = int.Parse( e.Item.Cells[0].Text);
            try
            {
                Process.removeBidderClassification(recordId);
                int bidder = int.Parse(lblBidderId.Text);
                loadBidderSubcategories(bidder);
                ShowMessage("Classification removed!");

            }
            catch(Exception ex)
            {

            }
        }
    }
}
