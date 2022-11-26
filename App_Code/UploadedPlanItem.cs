using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UploadedPlanItem
/// </summary>
public class UploadedPlanItem
{
    public UploadedPlanItem()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string ItemCategory { get; set; }
    public string GroupPlan { get; set; }
    public string IsFrameWork { get; set; }
    public string StockItemCategoryType { get; set; }
    public string NonStockItemCategory { get; set; }
    public string Currency { get; set; }
    public string Quatity { get; set; }
    public string UnitCost { get; set; }
    public string ProcurementMethod { get; set; }
    public string Description { get; set; }
    public string Units { get; set; }
    public string Justification { get; set; }
    public string Quarter { get; set; }
    public string DateNeeded { get; set; }
    public string FundingSource { get; set; }
}