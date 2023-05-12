using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddNewPlanFileUpload : System.Web.UI.Page
{
    ProcessPlanning Process = new ProcessPlanning();
    DataLogin dll = new DataLogin();
    bool Planned;
    DataTable dtable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultiView1.ActiveViewIndex = 0;
            LoadProcurementTypes();
        }
        
    }

    private void LoadProcurementTypes()
    {
        dtable = Process.GetProcurementTypes();
        cboProcType.DataSource = dtable;
        cboProcType.DataValueField = "Code";
        cboProcType.DataTextField = "Type";
        cboProcType.DataBind();
    }

    protected void cboProcType_DataBound(object sender, EventArgs e)
    {
        cboProcType.Items.Insert(0, new ListItem("- - Select Procurement Type - -", "0"));
    }
    protected void cboProcType_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GetTotalCost();
        //LoadItems();
        ToggleProcurementType();
    }

    private void ToggleProcurementType()
    {
        //try
        //{
        //    if (cboProcType.SelectedValue == "0")
        //        btnOK.Enabled = false;
        //    else
        //        btnOK.Enabled = true;
        //}
        //catch (Exception ex)
        //{
        //    ShowMessage(ex.Message);
        //}
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        try
        {
            ValidateDetails();
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void ValidateDetails()
    {
        HttpFileCollection uploads;
        uploads = HttpContext.Current.Request.Files;
        string protype = cboProcType.SelectedValue;
        if (uploads.Count<1)
        {
            ShowMessage("Please Upload Plan items");
        }
        else if (!IsCorrectFileForamat())
        {
            ShowMessage("Wrong file formats have been uploaded. Please upload CSV files only");
        }
        else
        {
            UploadFiles();
        }
        
    }

    private void UploadFiles()
    {
        HttpFileCollection uploads;
        uploads = HttpContext.Current.Request.Files;
        int countfiles = 0;
        DataTable errorTable = new DataTable();
        DataTable passedTable = new DataTable();
        for (int i = 0; i <= (uploads.Count - 1); i++)
        {
            errorTable = GetErrorTable();
            passedTable = GetPassedTable();
            if (uploads[i].ContentLength > 0)
            {
                string filename = HttpUtility.HtmlEncode(Path.GetFileName(uploads[i].FileName));
                string extension = HttpUtility.HtmlEncode(Path.GetExtension(filename));
                string user = Session["Username"].ToString().Replace(" ", "-").Replace(".", "");
                filename = "C:\\PlanItemsFiles\\"+user + filename;
                string filepath = filename;
                uploads[0].SaveAs(filepath);
                DataFile df = new DataFile();
                ArrayList filecontents = df.readFile(filepath);
                Session["ProcType"] = cboProcType.SelectedValue;
                for (int record = 0; record < filecontents.Count; record++)
                {
                    string error = "";
                    string line = filecontents[record].ToString();
                    string[] sLine = line.Split(',');
                    string[] StrArray = line.Split(Convert.ToChar(","));
                    if (sLine.Length.Equals(15))
                    {
                        int categorytype = 0;
                        int qty = 0;
                        string ItemCategory = StrArray[0].ToString().Trim();
                        string GroupPlan = StrArray[1].ToString().Trim();
                        string IsFrameWork = StrArray[2].ToString().Trim();
                        string StockItemCategoryType = StrArray[3].ToString().Trim();
                        string NonStockItemCategory = StrArray[4].ToString().Trim();
                        string Currency = StrArray[5].ToString().Trim();
                        string Quatity = StrArray[6].ToString().Trim();
                        string UnitCost = StrArray[7].ToString().Trim();
                        string ProcurementMethod = StrArray[8].ToString().Trim();
                        string Description = StrArray[9].ToString().Trim();
                        string Units = StrArray[10].ToString().Trim();
                        string Justification = StrArray[11].ToString().Trim();
                        string Quarter = StrArray[12].ToString().Trim();
                        string DateNeeded = StrArray[13].ToString().Trim();
                        string FundingSource = StrArray[14].ToString().Trim();
                        
                        //check group plan whether its okay
                        if (!string.IsNullOrEmpty(GroupPlan))
                        {
                            try
                            {
                                bool groupplan;
                                bool.TryParse(GroupPlan, out groupplan);
                            }
                            catch (Exception ex)
                            {
                                error = error + "Group Plan should be supplied as 0 or 1";
                            }
                        }

                        if (!string.IsNullOrEmpty(IsFrameWork))
                        {
                            try
                            {
                                bool IsFrameWorkbool;
                                bool.TryParse(IsFrameWork, out IsFrameWorkbool);
                            }
                            catch (Exception ex)
                            {
                                error = error + "IsFrameWork should be supplied as 0 or 1";
                            }
                        }
                        if (string.IsNullOrEmpty(ItemCategory))
                        {
                            error = error + "Item Category Required";
                        }
                        else if (!CorrectItemCategory(cboProcType.SelectedValue.ToString().Trim(), ItemCategory.Trim()))
                        {
                            error = error + "Wrong Item Category supplied";
                        }
                        else if (string.IsNullOrEmpty(GroupPlan))
                        {
                            error = error + "Group Plan Required";
                        }
                        else if (string.IsNullOrWhiteSpace(IsFrameWork))
                        {
                            error = error + "Is Frame Work Required";
                        }
                        else if (string.IsNullOrWhiteSpace(StockItemCategoryType))
                        {
                            error = error + "Stock ItemCategory Type Required";
                        }
                        else if (!int.TryParse(StockItemCategoryType,out categorytype))
                        {
                            error = error + "Invalid Stock Item Category Type";
                        }
                        else if (string.IsNullOrWhiteSpace(NonStockItemCategory))
                        {
                            error = error + "Non Stock Item Category Required";
                        }
                        else if (IsRightNonCategoryId(StockItemCategoryType, NonStockItemCategory))
                        {
                            error = error + "Non Stock Item Category ";
                        }
                        else if (string.IsNullOrWhiteSpace(Currency))
                        {
                            error = error + "Currency Required";
                        }
                        else if (!GetCurrencyCode(Currency))
                        {
                            error = error + "Invalid Currency Code";
                        }
                        else if (string.IsNullOrWhiteSpace(Quatity))
                        {
                            error = error + "Quatity Required";
                        }
                        else if (!int.TryParse(Quatity,out qty) || Quatity.Equals("0"))
                        {
                            error = error + "Invalid Qty supplied";
                        }
                        else if (string.IsNullOrWhiteSpace(UnitCost))
                        {
                            error = error + "UnitCost Required";
                        }
                        else if (!int.TryParse(UnitCost, out qty) || int.Parse(UnitCost)<1)
                        {
                            error = error + "Invalid Qty supplied";
                        }
                        else if (string.IsNullOrWhiteSpace(ProcurementMethod))
                        {
                            error = error + "Procurement Method Required";
                        }
                        else if (!IsValidProcurementType(Quatity, UnitCost, cboProcType.SelectedValue, ProcurementMethod))
                        {
                            error = error + "Wrong Procurement Method Required";
                        }
                        else if (string.IsNullOrWhiteSpace(Description))
                        {
                            error = error + "Description Required";
                        }
                        else if (string.IsNullOrWhiteSpace(Units))
                        {
                            error = error + "Units Required";
                        }
                        else if (string.IsNullOrWhiteSpace(Justification))
                        {
                            error = error + "Justification Required";
                        }
                        else if (string.IsNullOrWhiteSpace(DateNeeded))
                        {
                            error = error + "DateNeeded Required";
                        }
                        else if (string.IsNullOrWhiteSpace(Quarter))
                        {
                            error = error + "Quarter Required";
                        }
                        else if (string.IsNullOrWhiteSpace(FundingSource))
                        {
                            error = error + "FundingSource Required";
                        }
                        else
                        {
                            error = error + "";
                        }

                        if (!error.Equals(""))
                        {
                            DateTime now = DateTime.Now;
                            DataRow drerror = errorTable.NewRow();
                            drerror["ItemCategory"] = HttpUtility.HtmlEncode(ItemCategory);
                            drerror["GroupPlan"] = HttpUtility.HtmlEncode(GroupPlan);
                            drerror["IsFrameWork"] = HttpUtility.HtmlEncode(IsFrameWork);
                            drerror["StockItemCategoryType"] = HttpUtility.HtmlEncode(StockItemCategoryType);
                            drerror["NonStockItemCategory"] = HttpUtility.HtmlEncode(NonStockItemCategory);
                            drerror["Currency"] = HttpUtility.HtmlEncode(Currency);
                            drerror["Quatity"] = HttpUtility.HtmlEncode(Quatity);
                            drerror["UnitCost"] = HttpUtility.HtmlEncode(UnitCost);
                            drerror["ProcurementMethod"] = HttpUtility.HtmlEncode(ProcurementMethod);
                            drerror["Description"] = HttpUtility.HtmlEncode(Description);
                            drerror["Units"] = HttpUtility.HtmlEncode( Units);
                            drerror["Justification"] = HttpUtility.HtmlEncode(Justification);
                            drerror["DateNeeded"] = HttpUtility.HtmlEncode(DateNeeded);
                            drerror["Quarter"] = HttpUtility.HtmlEncode(Quarter);
                            drerror["FundingSource"] = HttpUtility.HtmlEncode(FundingSource);
                            drerror["Reason"] = error;
                            errorTable.Rows.Add(drerror.ItemArray);
                        }
                        else
                        {
                            DataRow drpassed = passedTable.NewRow();
                            drpassed["ItemCategory"] = HttpUtility.HtmlEncode(ItemCategory);
                            drpassed["GroupPlan"] = HttpUtility.HtmlEncode(GroupPlan);
                            drpassed["IsFrameWork"] = HttpUtility.HtmlEncode(IsFrameWork);
                            drpassed["StockItemCategoryType"] = HttpUtility.HtmlEncode(StockItemCategoryType);
                            drpassed["NonStockItemCategory"] = HttpUtility.HtmlEncode(NonStockItemCategory);
                            drpassed["Currency"] = HttpUtility.HtmlEncode(Currency);
                            drpassed["Quatity"] = HttpUtility.HtmlEncode(Quatity);
                            drpassed["UnitCost"] = HttpUtility.HtmlEncode(UnitCost);
                            drpassed["ProcurementMethod"] = HttpUtility.HtmlEncode(ProcurementMethod);
                            drpassed["Description"] = HttpUtility.HtmlEncode(Description);
                            drpassed["Units"] = HttpUtility.HtmlEncode(Units);
                            drpassed["Justification"] = HttpUtility.HtmlEncode(Justification);
                            drpassed["DateNeeded"] = HttpUtility.HtmlEncode(DateNeeded);
                            drpassed["Quarter"] = HttpUtility.HtmlEncode(Quarter);
                            drpassed["FundingSource"] = HttpUtility.HtmlEncode(FundingSource);
                            passedTable.Rows.Add(drpassed.ItemArray);
                        }
                    }
                    else
                    {
                        throw new Exception("File Format is not OK for file "+ filename + ", Columns must be 15.");
                    }
                }
                ProcessUploadedData(errorTable, passedTable);
                
            }
        }
    }

    private void ProcessUploadedData(DataTable errorTable, DataTable correctdata)
    {
        try
        {
            if (errorTable.Rows.Count > 0)
            {
                ShowMessage("Please Note the Uploaded file has some errors");
                DataGrid1.DataSource = errorTable;
                DataGrid1.DataBind();
                MultiView1.ActiveViewIndex = 1;
            }
            else if (correctdata.Rows.Count>0)
            {
                Session["uploadeddata"] = correctdata;
                ShowMessage("Please confirm below data for confirmation");
                DataGrid2.DataSource = correctdata;
                DataGrid2.DataBind();
                MultiView1.ActiveViewIndex = 2;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private bool IsValidProcurementType(string qty,string unitcost,string proctype,string procmethod)
    {
        bool IsTrue = false;
        try
        {
            int qty1 = int.Parse(qty);
            double unitcost1 = double.Parse(unitcost);
            double amt = qty1 * unitcost1;
            BusinessPlanning bll = new BusinessPlanning();
            int proctype1 = int.Parse(proctype);
            if (bll.isSpecificMethod(proctype1, amt))
            {
                IsTrue = true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return IsTrue;
    }

    private bool GetCurrencyCode(string currencycode)
    {
        bool IsTrue = false;
        try
        {
            DataTable currency = Process.GetCurrenciesByCode(currencycode);
            if (currency.Rows.Count>0)
            {
                IsTrue = true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return IsTrue;
    }
    private bool IsRightNonCategoryId(string catetypecode,string catid)
    {
        bool IsTrue = false;
        try
        {
            int CategoryTypeCode = int.Parse(catetypecode);
            int categoryid = int.Parse(catid);
            DataTable items = Process.GetNonStockItemCategoriesByCategoryTypeCodeBy(CategoryTypeCode, categoryid);
            if (items.Rows.Count>0)
            {
                IsTrue = true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return IsTrue;
    }
    /// <summary>
    /// Check Item Category
    /// </summary>
    /// <param name="proctype"></param>
    /// <param name="itemcategory"></param>
    /// <returns></returns>
    private bool CorrectItemCategory(string proctype,string itemcategory)
    {
        bool Istrue = false;
        try
        {
            DataTable itemcategories = Process.GetItemsByProcTypeAndId(proctype, itemcategory);
            if (itemcategories.Rows.Count>0)
            {
                Istrue = true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return Istrue;
    }
    private DataTable GetErrorTable()
    {
        DataTable dterror = new DataTable("ErrorTable");
        dterror.Columns.Add("ItemCategory");
        dterror.Columns.Add("GroupPlan");
        dterror.Columns.Add("IsFrameWork");
        dterror.Columns.Add("StockItemCategoryType");
        dterror.Columns.Add("NonStockItemCategory");
        dterror.Columns.Add("Currency");
        dterror.Columns.Add("Quatity");
        dterror.Columns.Add("UnitCost");
        dterror.Columns.Add("ProcurementMethod");
        dterror.Columns.Add("Description");
        dterror.Columns.Add("Units");
        dterror.Columns.Add("Justification");
        dterror.Columns.Add("DateNeeded");
        dterror.Columns.Add("Quarter");
        dterror.Columns.Add("FundingSource");
        dterror.Columns.Add("Reason");
        return dterror;
    }
    private DataTable GetPassedTable()
    {
        DataTable dterror = new DataTable("PassedTable");
        dterror.Columns.Add("ItemCategory");
        dterror.Columns.Add("GroupPlan");
        dterror.Columns.Add("IsFrameWork");
        dterror.Columns.Add("StockItemCategoryType");
        dterror.Columns.Add("NonStockItemCategory");
        dterror.Columns.Add("Currency");
        dterror.Columns.Add("Quatity");
        dterror.Columns.Add("UnitCost");
        dterror.Columns.Add("ProcurementMethod");
        dterror.Columns.Add("Description");
        dterror.Columns.Add("Units");
        dterror.Columns.Add("Justification");
        dterror.Columns.Add("DateNeeded");
        dterror.Columns.Add("Quarter");
        dterror.Columns.Add("FundingSource");
        return dterror;
    }
    /// <summary>
    /// Validates the formats of the files uploaded
    /// </summary>
    /// <returns></returns>
    protected bool IsCorrectFileForamat()
    {
        HttpFileCollection uploads;
        uploads = HttpContext.Current.Request.Files;
        int countfiles = 0;
        for (int i = 0; i <= (uploads.Count - 1); i++)
        {
            string c = System.IO.Path.GetFileName(uploads[i].FileName);
            string extension = System.IO.Path.GetExtension(c);
            if (!extension.Equals(".csv"))
            {
                return false;
            }
        }
        return true;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnNo_Click(this, e);
    }

    protected void btnNo_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["transfertype"] != null)
            Planned = false;
        else
            Planned = true;

        if (Planned)
            Response.Redirect("Planning_PendingItems.aspx", true);
        else
            Response.Redirect("Requisition_Items.aspx?transferid=1", true);
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

    private void DisableBtnsOnClick()
    {
        string strProcessScript = "this.value='Processing...';this.disabled=true;";
        btnOK.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnOK, "").ToString());
        //btnYes.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnYes, "").ToString());
        //btnNo.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnNo, "").ToString());
    }


    protected void cancel_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    protected void proceed_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable uploadeddata = (DataTable)Session["uploadeddata"];
            foreach (DataRow dr in uploadeddata.Rows)
            {
                string PlanCode = "0";
                string ProcType1 = Session["ProcType"].ToString();
                string FinCode = Session["PFinYearCode"].ToString();
                bool IsOperational = false;
                bool IsStock = false;
                string StockCode = "";
                string StockItemName = "";
                string BudgetCostCenterCode = Session["CostCenterID"].ToString();
                dtable = dll.GetUserDetails(Session["UserCode"].ToString());
                string CostCenterCode = "";
                if (dtable.Rows.Count > 0)
                    CostCenterCode = Session["CostCenterID"].ToString();//dtable.Rows[0]["CostCenterID"].ToString();
                string ItemCategory = dr["ItemCategory"].ToString();
                bool GroupPlan = false;
                if (dr["GroupPlan"].ToString().Equals("1"))
                {
                    GroupPlan = true;
                }
                bool IsFrameWork = false;
                if (dr["IsFrameWork"].ToString().Equals("1"))
                {
                    IsFrameWork = true;
                }
                string StockItemCategoryType = dr["StockItemCategoryType"].ToString();
                string NonStockItemCategory = dr["NonStockItemCategory"].ToString();
                string Currency = dr["Currency"].ToString();
                string Quatity = dr["Quatity"].ToString();
                string UnitCost = dr["UnitCost"].ToString();
                string ProcurementMethod = dr["ProcurementMethod"].ToString();
                string Description = dr["Description"].ToString();
                string Units = dr["Units"].ToString();
                string Justification = dr["Justification"].ToString();
                string DateNeeded = dr["DateNeeded"].ToString();
                string Quarter = dr["Quarter"].ToString();
                string FundingSource = dr["FundingSource"].ToString();
                DateTime DateForPP20 = Convert.ToDateTime(DateNeeded).AddMonths((-1 * 3));
                string txtDate4PP20 = DateForPP20.ToString("MMMM d, yyyy");
                string Planner = Session["UserID"].ToString();
                double MarketPrice = 0;
                string returned = Process.SavePlan(PlanCode, ProcType1, ProcurementMethod, FinCode, IsOperational, IsStock, StockCode, StockItemName, "",
                    "", ItemCategory, Description, Justification, GroupPlan, CostCenterCode, BudgetCostCenterCode, NonStockItemCategory, FundingSource, Units,
                    double.Parse(UnitCost), Quatity, Quarter, txtDate4PP20, DateNeeded, "3", "1", "3", Planner, Planned, MarketPrice, IsFrameWork);
                //string returned = Process.SubmitPlanItems(ItemArr, CCManagerID, CCManager, Status);
                ShowMessage(returned);
                MultiView1.ActiveViewIndex = 0;
            }
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
        
    }
}