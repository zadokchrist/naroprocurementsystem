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

public partial class Bidding_BidderCategories : System.Web.UI.Page
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
                LoadItems();
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
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
        //cboCategories.DataSource = Process.GetBidderCategoriesByProcType(TypeID);
        //cboCategories.DataTextField = "CategoryName";
        //cboCategories.DataValueField = "BidderCategoryID";
        //cboCategories.DataBind();
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
        int TypeID = Convert.ToInt32(cboProcType.SelectedValue);
        int view = Convert.ToInt32(ddlView.SelectedValue);
        if (view == 1)
        {
            dataTable = Process.GetBidderCategoriesByProcType(TypeID);


        }
        else if (view == 2)
        {
            dataTable = Process.GetBidderSubCategoriesByProcType(TypeID);

        }
        GridData.DataSource = dataTable;
        GridData.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            MultiView1.ActiveViewIndex = 1;
            LoadProcurementTypes2();
            ddlType.SelectedIndex = 0;
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
            LoadItems();
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

                string TypeSelected = cboProcType.SelectedValue.ToString();
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
        long BidderID = Convert.ToInt32(Label1.Text.Trim()); LoadProcurementTypes2(); 
        dataTable = Process.GetBidderDetails(BidderID); string Type = dataTable.Rows[0]["TypeID"].ToString();
        cboProcType2.SelectedIndex = cboProcType2.Items.IndexOf(cboProcType2.Items.FindByValue(Type));
        LoadCategories(); string Category = dataTable.Rows[0]["BiddercategoryID"].ToString();
      //  cboCategories.SelectedIndex = cboCategories.Items.IndexOf(cboCategories.Items.FindByValue(Category));
        //txtSupplierName.Text = dataTable.Rows[0]["CompanyName"].ToString();
        txtDirectorNames.Text = dataTable.Rows[0]["DirectorNames"].ToString();
        //txtPhysicalAddress.Text = dataTable.Rows[0]["PhysicalAddress"].ToString();
        //txtPhoneNumbers.Text = dataTable.Rows[0]["PhoneNumbers"].ToString();
        //txtEmailAddress.Text = dataTable.Rows[0]["EmailAddress"].ToString();
        //txtRemarks.Text = dataTable.Rows[0]["Remarks"].ToString();
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
            if (cboProcType2.SelectedValue == "0")
                ShowMessage("Please Select Supplier Category");
            //else if (cboCategories.SelectedValue == "0")
            //    ShowMessage("Please Select Supplier Sub Category");
            //else if (txtSupplierName.Text.Trim() == "")
              //  ShowMessage("Please Enter Supplier Name");
            //else if (txtDirectorNames.Text.Trim() == "")
            //    ShowMessage("Please Enter Names of Directors");
            //else if (txtPhysicalAddress.Text.Trim() == "")
            //    ShowMessage("Please Enter Physical Address of Supplier");
            //else if (txtPhoneNumbers.Text.Trim() == "")
            //    ShowMessage("Please Enter Phone Number(s) of Supplier");
            else
            {
              //  string ProcType = cboProcType2.SelectedValue; long Category = Convert.ToInt64(cboCategories.SelectedValue);
              //  string SupplierName = txtSupplierName.Text.Trim(); string DirectorNames = txtDirectorNames.Text.Trim();
               // string PhysicalAddress = txtPhysicalAddress.Text.Trim(); string PhoneNumbers = txtPhoneNumbers.Text.Trim();
              //  string EmailAddress = txtEmailAddress.Text.Trim(); string Remarks = txtRemarks.Text.Trim();
                bool Active = CheckBox2.Checked;
                long BidderID = Convert.ToInt64(Label1.Text.Trim());
                // Process.SaveEditBidders(BidderID, SupplierName, DirectorNames, PhysicalAddress, PhoneNumbers, EmailAddress, Category, Active); 
                String type = ddlType.SelectedItem.ToString();
                ShowMessage("BIDDER "+type+" HAS BEEN SAVED/EDITED");
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
       // txtRemarks.Text = ""; txtSupplierName.Text = ""; txtPhysicalAddress.Text = ""; txtPhoneNumbers.Text = "";
       // txtEmailAddress.Text = ""; txtDirectorNames.Text = "";
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
       // cboCategories.Items.Insert(0, new ListItem(" -- Select Sub Category -- ", "0"));
    }
    protected void cboProcType2_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCategories();
    }


    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadItems();
    }
    

    protected void ddlView_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadItems();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        try
        {
            MultiView1.ActiveViewIndex = 1;
            LoadProcurementTypes2();
            ddlType.SelectedIndex = 1;
            string TypeSelected = cboProcType.SelectedValue.ToString();
            Session["SelectedType"] = TypeSelected;
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }
}
