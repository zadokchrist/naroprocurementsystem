using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using CrystalDecisions.CrystalReports.Engine;
using System.IO;

public class ProcessBidding
{
    DataBidding data = new DataBidding();
    DataPlanning dataPlanning = new DataPlanning();
    DataLogin main = new DataLogin();
    BusinessRequisition bll = new BusinessRequisition();
    BusinessPlanning bllPlanning = new BusinessPlanning();
    ProcessPlanning Process = new ProcessPlanning();
    ProcessRequisition ProcessReq = new ProcessRequisition();
    SendMail mailer = new SendMail();
    DataSet dataSet = new DataSet();
    DataTable dTable = new DataTable();

    public ProcessBidding()
    {
    }
    #region Admin
    public DataTable GetBiddingProcurementTypes()
    {
        return data.GetBiddingProcurementTypes();
    }
    public DataTable GetSuppliersByProcurementTypes(int TypeID)
    {
        return data.GetSuppliersByProcurementTypes(TypeID);
    }
    public DataTable GetBidderCategoriesByProcType(int TypeID)
    {
        return data.GetBidderCategoriesByProcType(TypeID);
    }
    public DataTable GetBidderDetails(long BidderID)
    {
        return data.GetBidderDetails(BidderID);
    }

    public DataTable GetBidderByCategory(int BidderID)
    {
        return data.GetBidderByCategory(BidderID);
    }
    public DataTable GetCCMemberDetails(long CCUserID)
    {
        return data.GetCCMemberDetails(CCUserID);
    }
    public void SaveEditBidders(long BidderID, string CompanyName, string DirectorNames, string PhysicalAddress, string PhoneNumbers,
        string EmailAddress, long BidderCategoryID,String ppa, String designation, bool IsActive)
    {
        long CreatedBy = Convert.ToInt64(HttpContext.Current.Session["UserID"].ToString());
        data.SaveEditBidders(BidderID, CompanyName, DirectorNames, PhysicalAddress, PhoneNumbers, EmailAddress, BidderCategoryID, ppa, designation, IsActive, CreatedBy);
    }

    public DataTable GetOfficerDocTypes()
    {
        return data.GetOfficerDocTypes();
    }
    public DataTable GetEvaluationDocTypes()
    {
        return data.GetEvaluationDocTypes();
    }

    public void SaveEditCCMember(long CCMemberID, long CCID, long CCUserID, long PositionID, string ReasonForSelection, bool IsActive)
    {
        long CreatedBy = Convert.ToInt64(HttpContext.Current.Session["UserID"].ToString());
        data.SaveEditCCMember(CCMemberID, CCID, CCUserID, PositionID, ReasonForSelection, IsActive, CreatedBy);
    }
    #endregion Admin

    public string GetForm(int ProcurementMethod)
    {
        string PPForm = "";
        if (ProcurementMethod.Equals(1))
            PPForm = "PD02";
        else if (ProcurementMethod.Equals(2) || ProcurementMethod.Equals(3))
            PPForm = "Form4";
        else if (ProcurementMethod.Equals(5) || ProcurementMethod.Equals(6))
            PPForm = "Form1";
        else if (ProcurementMethod.Equals(4) || ProcurementMethod.Equals(7))
            PPForm = "Form2";
        else if (ProcurementMethod.Equals(10))
            PPForm = "Form3";

        return PPForm;
    }
    public void CheckPath(string Path)
    {
        if (!Directory.Exists(Path))
            Directory.CreateDirectory(Path);
    }
    public string GetBiddingFormDocPath()
    {
        string Path = "D:\\Reports\\PrcocurementAttachments\\BiddingForms\\";
        dTable = main.GetConfiguration(2);
        if (dTable.Rows.Count > 0)
        {
            Path = dTable.Rows[0]["Details"].ToString();
        }
        CheckPath(Path);
        return Path;
    }
    public DataTable GetCCMeetingMinutes(string CCRefNo, int DocumentTypeID)
    {
        dTable = data.GetCCMeetingMinutes(CCRefNo, DocumentTypeID);
        return dTable;
    }
    public DataTable GetBiddingDocuments(string ReferenceNo, int DocumentTypeID)
    {
        dTable = data.GetBiddingDocuments(ReferenceNo, DocumentTypeID);
        return dTable;
    }
    public DataTable GetBiddingDocuments2(string ReferenceNo, int DocumentTypeID)
    {
        dTable = data.GetBiddingDocuments2(ReferenceNo, DocumentTypeID);
        return dTable;
    }
    public DataTable GetBiddingEvaluationDocuments2(string ReferenceNo)
    {
        dTable = data.GetBiddingEvaluationDocuments2(ReferenceNo);
        return dTable;
    }
    public DataTable GetBiddingDocuments2bYCreator(string ReferenceNo, int DocumentTypeID, int createdby)
    {
        dTable = data.GetBiddingDocuments2bYCreator(ReferenceNo, DocumentTypeID, createdby);
        return dTable;
    }
    public DataTable GetBiddingDetailsForNotification(string ReferenceNo)
    {
        dTable = data.GetBiddingDetailsForNotification(ReferenceNo);
        return dTable;
    }
    public DataTable GetBidderSubCategoriesByProcType(int TypeID)
    {
        return data.GetBidderSubCategoriesByProcType(TypeID);
    }
    public DataTable GetRequisitionDetails(string ReferenceNo)
    {
        dTable = data.GetRequisitionDetails(ReferenceNo);
        return dTable;
    }
    public DataTable GetBEBRequisitionDetails(string ReferenceNo)
    {
        dTable = data.GetBEBRequisitionDetails(ReferenceNo);
        return dTable;
    }

    public DataTable GetAssignedProcurements(string RecordCode, string PrNumber, string ProcurementMethod, string ProcurementOfficer, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);

        int status = 0;
        if (Status != "")
            status = Convert.ToInt32(Status);

        dTable = data.GetAssignedProcurements(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, status, FinID, AreaID);
        return dTable;
    }
    public DataTable GetProcurementsForECSubmissionOnly(string RecordCode, string PrNumber, string ProcurementMethod, string ProcurementOfficer, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        dTable = data.GetProcurementsForECSubmissionOnly(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, FinID, AreaID);
        return dTable;
    }
    public DataTable GetBiddingProcurements(string RecordCode, string PrNumber, string ProcurementMethod, string ProcurementOfficer, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        dTable = data.GetBiddingProcurements(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
        return dTable;
    }

    public DataTable GetPreBidMeetingProcurements(string RecordCode, string PrNumber, string ProcurementMethod, string ProcurementOfficer, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        dTable = data.GetPreBidMeetingProcurements(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
        return dTable;
    }

    public DataTable GetBidSolicitationProcurements(string RecordCode, string PrNumber, string ProcurementMethod, string ProcurementOfficer, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        dTable = data.GetBidSolicitationProcurements(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
        return dTable;
    }

    public DataTable GetBidReceiptProcurements(string RecordCode, string PrNumber, string ProcurementMethod, string ProcurementOfficer, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        dTable = data.GetBidReceiptProcurements(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
        return dTable;
    }

    public DataTable GetBidOpeningProcurements(string RecordCode, string PrNumber, string ProcurementMethod, string ProcurementOfficer, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        dTable = data.GetBidOpeningProcurements(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
        return dTable;
    }

    public DataTable GetBidEvaluationProcurements(string RecordCode, string PrNumber, string ProcurementOfficer, string ProcurementMethod, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        dTable = data.GetBidEvaluationProcurements(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
        return dTable;
    }

    public DataTable GetBiddingProcurements2(string RecordCode, string PrNumber, string ProcurementMethod, string ProcurementOfficer, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        dTable = data.GetBiddingProcurements2(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
        return dTable;
    }


    public DataTable GetProcurementsForSolicitation(string RecordCode, string PrNumber, string ProcurementMethod, string ProcurementOfficer, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        dTable = data.GetProcurementsForSolicitation(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
        return dTable;
    }
    public DataTable GetBidderNewCategories(int type)
    {
        return data.GetBidderNewCategories(type);
    }

    public DataTable GetSuppliersByCategory(int procType, int cate, int subcat)
    {
        return data.GetSuppliersByCategory(procType, cate, subcat);
    }



    public DataTable getBidderClassifications(int bidder)
    {
        return data.getBidderClassifications(bidder);
    }






    public void updateDocumentStatus(int docId)
    {
        data.updateDocumentStatus(docId);
    }
    public DataTable GetLevelProcurements(string RecordCode, string PrNumber, string ProcurementMethod, string ProcurementOfficer, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        int StatusID = 0;
        if (Status != "")
            StatusID = Convert.ToInt32(Status);
        dTable = data.GetLevelProcurements(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, StatusID, FinID, AreaID);
        return dTable;
    }

    public DataTable GetLevelProcurements2(string RecordCode, string PrNumber, string ProcurementMethod, string ProcurementOfficer, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        int StatusID = 0;
        if (Status != "")
            StatusID = Convert.ToInt32(Status);
        dTable = data.GetLevelProcurements2(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, StatusID, FinID, AreaID);
        return dTable;
    }

    public DataTable SearchProcurements(string RecordCode, string PrNumber, string ProcurementOfficer, string ProcurementMethod, string AreaCode, string CostCenterCode, int status)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        dTable = data.SearchProcurements(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, FinID, AreaID, status);
        return dTable;
    }
    public DataTable ViewProcurements(string RecordCode, string PrNumber, string Status, string ProcurementMethod, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        int status = Convert.ToInt32(Status);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        dTable = data.ViewProcurements(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, FinID, AreaID, status);
        return dTable;
    }
    public DataTable GetOtherPPForms(string ReferenceNo)
    {
        dTable = data.GetOtherPPForms(ReferenceNo);
        return dTable;
    }
    public DataTable GetApprovedProcurements(string RecordCode, string PrNumber, string ProcurementMethod, string ProcurementOfficer, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        dTable = data.GetApprovedProcurements(RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, FinID, AreaID);
        return dTable;
    }
    public DataTable GetMicroProcurements(string RecordCode, string PrNumber, string ProcurementOfficer, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        int StatusID = 0;
        if (Status != "")
            StatusID = Convert.ToInt32(Status);
        dTable = data.GetMicroProcurements(RecordID, PrNumber, OfficerID, CostCenterID, StatusID, FinID, AreaID);
        if (dTable.Rows.Count == 0)
            dTable = data.GetRejectedMicroProcurements(RecordID, PrNumber, OfficerID, CostCenterID, FinID, AreaID, StatusID);
        return dTable;
    }
    public DataTable GetMicroProcurementApprovals(string RecordCode, string PrNumber, string ProcurementOfficer, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0; int StatusID = 0;
        if (Status != "")
            StatusID = Convert.ToInt32(Status);
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);

        dTable = data.GetMicroProcurementApprovals(RecordID, PrNumber, OfficerID, StatusID, CostCenterID, FinID, AreaID);
        return dTable;
    }
    public DataTable GetMicroProcurementHOSApprovals(string RecordCode, string PrNumber, string ProcurementOfficer, string HeadOfSection, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        long HOS = Convert.ToInt64(HeadOfSection);

        dTable = data.GetMicroProcurementHOSApprovals(RecordID, PrNumber, OfficerID, HOS, CostCenterID, FinID, AreaID);
        return dTable;
    }
    public DataTable GetMicroProcurementHODApprovals(string RecordCode, string PrNumber, string ProcurementOfficer, string HeadOfDepartment, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int OfficerID = Convert.ToInt32(ProcurementOfficer);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        long HOD = Convert.ToInt64(HeadOfDepartment);

        dTable = data.GetMicroProcurementHODApprovals(RecordID, PrNumber, OfficerID, HOD, CostCenterID, FinID, AreaID);
        return dTable;
    }
    public DataTable GetMicroProcurementCCChairmanApprovals(string RecordCode, string PrNumber, string ProcurementOfficer, string Chairman, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        long OfficerID = Convert.ToInt64(ProcurementOfficer);
        long ChairmanID = Convert.ToInt64(Chairman);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ChairmanAreaID = Convert.ToInt32(HttpContext.Current.Session["AreaCode"]);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);

        dTable = data.GetMicroProcurementCCChairmanApprovals(RecordID, PrNumber, OfficerID, ChairmanID, CostCenterID, FinID, AreaID, ChairmanAreaID);
        return dTable;
    }
    public DataTable GetCCProcurements(string RecordCode, string PrNumber, string ProcurementOfficer, string ProcurementMethod, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        long CCMemberID = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        long ProcOfficer = Convert.ToInt64(ProcurementOfficer);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        int StatusID = 0;
        if (Status != "")
            StatusID = Convert.ToInt32(Status);
        dTable = data.GetCCProcurements(RecordID, PrNumber, CCMemberID, ProcOfficer, ProcMethod, CostCenterID, StatusID, FinID, AreaID);
        return dTable;
    }

    public void generateIFB(string referenceNo, int supplierid)
    {
        data.generateIFB(referenceNo, supplierid);

    }
    public void updateIFB(string referenceNo, int supplierid)
    {
        data.updateIFB(referenceNo, supplierid);

    }
    public DataTable GetCCEvaluationProcurements(string RecordCode, string PrNumber, string ProcurementOfficer, string ProcurementMethod, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        long CCMemberID = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        long ProcOfficer = Convert.ToInt64(ProcurementOfficer);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        dTable = data.GetCCEvaluationProcurements(RecordID, PrNumber, CCMemberID, ProcOfficer, ProcMethod, CostCenterID, FinID, AreaID);
        return dTable;
    }
    public DataTable GetECProcurements(string RecordCode, string PrNumber, string ProcurementOfficer, string ProcurementMethod, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        long ProcOfficer = Convert.ToInt64(ProcurementOfficer);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        int StatusID = 0;
        if (Status != "")
            StatusID = Convert.ToInt32(Status);
        dTable = data.GetECProcurements(RecordID, PrNumber, ProcOfficer, ProcMethod, CostCenterID, StatusID, FinID, AreaID);
        return dTable;
    } // 
    public DataTable GetPDUProcurementsForEvaluation(string RecordCode, string PrNumber, string ProcurementOfficer, string ProcurementMethod, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        long ProcOfficer = Convert.ToInt64(ProcurementOfficer);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        int StatusID = 0;
        if (Status != "")
            StatusID = Convert.ToInt32(Status);
        dTable = data.GetPDUProcurementsForEvaluation(RecordID, PrNumber, ProcOfficer, ProcMethod, CostCenterID, StatusID, FinID, AreaID);
        return dTable;
    }
    public DataTable GetCCApprovalOptions(int StatusID)
    {
        return data.GetCCApprovalOptions(StatusID);
    }
    public DataTable GetProcurementsForSupervisorSubmission(string RecordCode, string PrNumber, string ProcurementOfficer, string ProcurementMethod, string Status, string AreaCode, string CostCenterCode, bool IsSupervisor)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int ProcOfficer = Convert.ToInt32(ProcurementOfficer);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        int StatusID = 0;
        if (Status != "")
            StatusID = Convert.ToInt32(Status);
        dTable = data.GetProcurementsForSupervisorSubmission(RecordID, PrNumber, ProcMethod, ProcOfficer, CostCenterID, StatusID, FinID, AreaID, IsSupervisor);
        return dTable;
    }

    public DataTable GetProcurementsForMD(string RecordCode, string PrNumber, string ProcurementOfficer, string ProcurementMethod, string Status, string AreaCode, string CostCenterCode, bool IsSupervisor)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int ProcOfficer = Convert.ToInt32(ProcurementOfficer);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        int StatusID = 0;
        if (Status != "")
            StatusID = Convert.ToInt32(Status);
        dTable = data.GetProcurementsForMD(RecordID, PrNumber, ProcMethod, ProcOfficer, CostCenterID, StatusID, FinID, AreaID, IsSupervisor);
        return dTable;
    }

    public void updateContractNumber(string refno, string contractnum)
    {
        data.updateContractNumber(refno, contractnum);
    }

    public DataTable GetCCScheduledProcurements(string RecordCode, string PrNumber, string ProcurementOfficer, string ProcurementMethod, string Status, string AreaCode, string CostCenterCode)
    {
        long RecordID = Convert.ToInt64(RecordCode);
        int FinID = Convert.ToInt32(HttpContext.Current.Session["BFinYearCode"]);
        int ProcMethod = Convert.ToInt32(ProcurementMethod);
        int ProcOfficer = Convert.ToInt32(ProcurementOfficer);
        int CostCenterID = 0;
        if (CostCenterCode != "")
            CostCenterID = Convert.ToInt32(CostCenterCode);
        int AreaID = 0;
        if (AreaCode != "")
            AreaID = Convert.ToInt32(AreaCode);
        int StatusID = 0;
        if (Status != "")
            StatusID = Convert.ToInt32(Status);
        dTable = data.GetCCScheduledProcurements(RecordID, PrNumber, ProcMethod, ProcOfficer, CostCenterID, StatusID, FinID, AreaID);
        return dTable;
    }
    public DataTable GetSections4Questions(int ProcMethod, int SubmissionType)
    {
        dTable = data.GetSections4Questions(ProcMethod, SubmissionType);
        return dTable;
    }

    public DataTable GetSections4Questions2(int ProcMethod, int SubmissionType, int proctype)
    {
        dTable = data.GetSections4Questions2(ProcMethod, SubmissionType, proctype);
        return dTable;
    }

    public DataTable GetSectionsForEvaluationReport(int ProcMethod)
    {
        dTable = data.GetSectionsForEvaluationReport(ProcMethod);
        return dTable;
    }
    public DataTable GetSectionsForEvaluationReport2(String section /*int ProcMethod*/)
    {
        dTable = data.GetSectionsForEvaluationReport2(section);
        return dTable;
    }
    public DataTable GetAnsweredFormDetails(string ReferenceNo)
    {
        dTable = data.GetAnsweredFormDetails(ReferenceNo);
        return dTable;
    }
    public DataTable GetSectionQuestions(int ProcMethod, string Section)
    {
        dTable = data.GetSectionQuestions(ProcMethod, Section);
        return dTable;
    }
    public DataTable GetQuestions(int ProcMethod, string Section)
    {
        dTable = data.GetQuestions(ProcMethod, Section);
        return dTable;
    }
    public DataTable GetGridAnswers(string ReferenceNo, string ProcMethod, string Section)
    {
        dTable = data.GetGridAnswers(ReferenceNo, ProcMethod, Section);
        return dTable;
    }
    public String GetQuestionAnswer(string ReferenceNo, int QuestionId)
    {
        string Answer = "";
        dTable = data.GetQuestionAnswer(ReferenceNo, QuestionId);
        if (dTable.Rows.Count > 0)
            Answer = dTable.Rows[0]["Answer"].ToString();

        return Answer;
    }
    public DataTable GetSectionAnswers(string Section, string ReferenceNo)
    {
        dTable = data.GetSectionAnswers(Section, ReferenceNo);
        return dTable;
    }
    public DataTable GetFormNumberByProcMethod(int ProcMethod, int SubmissionType)
    {
        dTable = data.GetFormNumberByProcMethod(ProcMethod, SubmissionType);
        return dTable;
    }
    public string GetReportName(int NewProcMethod, string PPForm, string Section, bool CCSubmission)
    {
        string ReportName = "";
        dTable = data.GetReportName(NewProcMethod, PPForm, Section, CCSubmission);
        if (dTable.Rows.Count > 0)
            ReportName = dTable.Rows[0]["ReportName"].ToString();

        return ReportName;
    }
    public DataTable GetShortlistedBidderDetails(string PRNumber)
    {
        dTable = data.GetShortlistedBidderDetails(PRNumber);
        return dTable;
    }

    public DataTable GetProcBiddersDocuments(string PRNumber)
    {
        dTable = data.GetProcBiddersDocuments(PRNumber);
        return dTable;
    }

    public DataTable GetECMemberDetails(string PRNumber)
    {
        dTable = data.GetECMemberDetails(PRNumber);
        return dTable;
    }
    public DataTable GetBidderReasons(int Type)
    {
        return data.GetBidderReasons(Type);
    }
    public DataTable GetBidderCategories()
    {
        return data.GetBidderCategories();
    }
    public DataTable GetUserByName(string Name)
    {
        return dataPlanning.GetUserByNames(Name);
    }
    public DataTable GetProfileByName(string Name)
    {
        return data.GetProfilesByNames(Name);
    }
    public DataTable GetBidderByName(string Name)
    {
        return dataPlanning.GetBidderByName(Name);
    }
    public DataTable GetPositions(string Committee)
    {
        return data.GetPositions(Committee);
    }
    public DataTable GetCCIDForReferenceNo(string ReferenceNo)
    {
        return data.GetCCIDForReferenceNo(ReferenceNo);
    }
    public DataTable GetRequisitionDetailsReferenceNo(string ReferenceNo)
    {
        return data.GetRequisitionDetailsReferenceNo(ReferenceNo);
    }
    public DataTable GetCCIDForEvaluationReport(string ReferenceNo, double Amount)
    {
        return data.GetCCIDForEvaluationReport(ReferenceNo, Amount);
    }
    public DataTable GetBEBDetails(string ReferenceNo)
    {
        return data.GetBEBDetails(ReferenceNo);
    }
    public DataTable GetMicroProcurementDetails(string ReferenceNo)
    {
        dTable = data.GetMicroProcurementDetails(ReferenceNo);
        return dTable;
    }
    public DataTable GetMicroProcurementItems(string ReferenceNo)
    {
        dTable = data.GetMicroProcurementItems(ReferenceNo);
        return dTable;
    }
    public DataTable GetSoliticationDocuments(string PRNumber)
    {
        dTable = data.GetSoliticationDocuments(PRNumber);
        return dTable;
    }

    public DataTable GetBidderDocuments(string PRNumber, int supplierId)
    {
        dTable = data.GetBidderDocuments(PRNumber, supplierId);
        return dTable;
    }

    public DataTable BidderIFBs(int supplierid, int status)
    {
        dTable = data.BidderIFBs(supplierid, status);
        return dTable;
    }




    public DataTable GetSoliticationDocumentDetails(string PRNumber)
    {
        dTable = data.GetSoliticationDocumentDetails(PRNumber);
        return dTable;
    }
    public DataTable GetPreBidMeetings(string PRNumber)
    {
        dTable = data.GetPreBidMeetings(PRNumber);
        return dTable;
    }
    public DataTable GetPreBidMeetingByID(long PreBidMeetingID)
    {
        dTable = data.GetPreBidMeetingByID(PreBidMeetingID);
        return dTable;
    }
    public DataTable GetPreBidMeetingQuestions(long PreBidMeetingID)
    {
        dTable = data.GetPreBidMeetingQuestions(PreBidMeetingID);
        return dTable;
    }
    public DataTable GetPreBidMeetingAttendance(long PreBidMeetingID)
    {
        dTable = data.GetPreBidMeetingAttendance(PreBidMeetingID);
        return dTable;
    }
    public DataTable GetBidReceipt(string PRNumber)
    {
        dTable = data.GetBidReceipt(PRNumber);
        return dTable;
    }
    public DataTable GetBidReceiptDetails(string PRNumber)
    {
        dTable = data.GetBidReceiptDetails(PRNumber);
        return dTable;
    }
    public DataTable GetBidReceiptMethods()
    {
        return data.GetBidReceiptMethods();
    }
    public DataTable GetBidOpeningTypes()
    {
        return data.GetBidOpeningTypes();
    }
    public DataTable GetCurrencies()
    {
        return data.GetCurrencies();
    }
    public DataTable GetCountries()
    {
        return data.GetCountries();
    }
    public DataTable GetUnits()
    {
        return data.GetUnits();
    }
    public DataTable GetBidOpening(string PRNumber)
    {
        dTable = data.GetBidOpening(PRNumber);
        return dTable;
    }
    public DataTable GetBidOpeningDetails(long BidOpeningID)
    {
        dTable = data.GetBidOpeningDetails(BidOpeningID);
        return dTable;
    }
    public DataTable GetBidOpeningAttendance(long BidOpeningID)
    {
        dTable = data.GetBidOpeningAttendance(BidOpeningID);
        return dTable;
    }
    public DataTable GetCCMembersByCCID(Int64 CCID)
    {
        return data.GetCCMembersByCCID(CCID);
    }
    public DataTable GetCCMembers(long CCID)
    {
        return data.GetCCMembers(CCID);
    }
    public DataTable GetSolicitedBiddersByReferenceNo(string RefNo)
    {
        return data.GetSolicitedBiddersByReferenceNo(RefNo);
    }
    public DataTable GetBiddersForBidSolicitByReferenceNo(string RefNo)
    {
        return data.GetBiddersForBidSolicitByReferenceNo(RefNo);
    }
    public DataTable GetBiddersForBidOpeningByReferenceNo(string RefNo)
    {
        return data.GetBiddersForBidOpeningByReferenceNo(RefNo);
    }
    public DataTable GetBiddersForReceivedBidsByReferenceNo(string RefNo)
    {
        return data.GetBiddersForReceivedBidsByReferenceNo(RefNo);
    }
    public DataTable GetMicroProcurementForBidAnalysis(string RefNo, string BidderID)
    {
        return data.GetMicroProcurementForBidAnalysis(RefNo, BidderID);
    }
    public DataTable GetNegotiationPlan(string PRNumber)
    {
        dTable = data.GetNegotiationPlan(PRNumber);
        return dTable;
    }
    public DataTable GetNegotiationPlanByID(long NegotiationPlanID)
    {
        dTable = data.GetNegotiationPlanByID(NegotiationPlanID);
        return dTable;
    }
    public DataTable GetNegotiationPlanDetails(long NegotiationPlanID)
    {
        dTable = data.GetNegotiationPlanDetails(NegotiationPlanID);
        return dTable;
    }
    public DataTable GetNegotiationPlanMembers(long NegotiationPlanID)
    {
        dTable = data.GetNegotiationPlanMembers(NegotiationPlanID);
        return dTable;
    }
    public DataTable GetBidderEvaluations(string ReferenceNo)
    {
        dTable = data.GetBidderEvaluations(ReferenceNo);
        return dTable;
    }
    public DataTable GetLottedBidderEvaluations(string ReferenceNo)
    {
        dTable = data.GetLottedBidderEvaluations(ReferenceNo);
        return dTable;
    }
    public DataTable GetLotts(string ReferenceNo)
    {
        dTable = data.GetLotts(ReferenceNo);
        return dTable;
    }
    public DataTable GetLottDetails(string ReferenceNo)
    {
        dTable = data.GetLottDetails(ReferenceNo);
        return dTable;
    }
    public DataTable GetLottByID(long LottID)
    {
        dTable = data.GetLottByID(LottID);
        return dTable;
    }

    public DataTable GetFormDetails(string refno, int AreaId)
    {
        dTable = data.GetFormDetails(refno, AreaId);

        return dTable;
    }
    public string SubmitBiddingDetailsForSourcing(string StrArry, int PDUSupervisorID, string PDUSupervisor, long OfficerID, int Status)
    {
        string output = "";
        if (StrArry != "")
        {
            string[] arr = StrArry.Split(',');
            int i = 0;
            string ReferenceNo = "";
            DataTable requisitiondetails;
            for (i = 0; i < arr.Length; i++)
            {
                ReferenceNo = arr[i].ToString();
                requisitiondetails = GetRequisitionDetailsReferenceNo(ReferenceNo);
                if (ReferenceNo != "")
                {
                    long CCID = 0;
                    dTable = GetCCIDForReferenceNo(ReferenceNo);
                    if (dTable.Rows.Count > 0)
                        CCID = Convert.ToInt64(dTable.Rows[0]["CCID"].ToString());
                    data.SaveUpdateBiddingDetailsForSupplier("0", ReferenceNo, PDUSupervisorID, CCID, OfficerID);
                    string proctype = requisitiondetails.Rows[0]["ProcurementType"].ToString();
                    string msg = "";
                    if (proctype.Equals("GOODS")|| proctype.Equals("WORKS"))
                    {
                        msg = "INVITATION FOR BIDS HAS BEEN SENT OUT AND WILL BE SUPERVISED BY ( " + PDUSupervisor + ")";
                    }
                    else if (proctype.Equals("CONSULTATIONAL SERVICES"))
                    {
                        msg = "INVITATION FOR EOI HAS BEEN SENT OUT AND WILL BE SUPERVISED BY ( " + PDUSupervisor + ")";
                    }
                    else
                    {
                        msg = "INVITATION FOR BIDS HAS BEEN SENT OUT AND WILL BE SUPERVISED BY ( " + PDUSupervisor + ")";
                    }

                    DataTable datatable = GetShortlistedBidderDetails(ReferenceNo);
                    if (datatable.Rows.Count>0)
                    {
                        string[] bidderemails= new string [datatable.Rows.Count];
                        int incre = 0;
                        foreach (DataRow dr in datatable.Rows)
                        {
                            bidderemails[incre] = dr["EmailAddress"].ToString();
                            incre++;
                        }

                        //mailer.SendBroadCastEmail("LAGOS WATER CORPORATION",);
                    }
                    
                    LogandCommitBiddingDetails(ReferenceNo, Status, msg);
                }
            }

            // Notify Procurement Supervisor
            string By = HttpContext.Current.Session["FullName"].ToString();
            string Subject = "Procurements and Bidding Doc(s) For Review and Approval";
            string MessageToSend = "<p>You have been sent " + i + " procurement(s) for review and your approval before Contracts Committee submission </p>";
            MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

            Process.NotifyManager(By, Subject, PDUSupervisorID, MessageToSend);

            output = i + " Invitation for Bid has been sent to Suppliers";
        }
        else
        {
            output = "Please Select Procurement(s) To Be Submitted For Procurement Supervisor Review and Approval";
        }
        return output;
    }
    public string SubmitBiddingDetails(string StrArry, int PDUSupervisorID, string PDUSupervisor, long OfficerID, int Status)
    {
        string output = "";
        if (StrArry != "")
        {
            string[] arr = StrArry.Split(',');
            int i = 0;
            string ReferenceNo = "";
            DataTable requisitiondetails;
            for (i = 0; i < arr.Length; i++)
            {
                ReferenceNo = arr[i].ToString();
                requisitiondetails = GetRequisitionDetailsReferenceNo(ReferenceNo);
                if (ReferenceNo != "")
                {
                    long CCID = 0;
                    dTable = GetCCIDForReferenceNo(ReferenceNo);
                    if (dTable.Rows.Count > 0)
                        CCID = Convert.ToInt64(dTable.Rows[0]["CCID"].ToString());
                    data.SaveUpdateBiddingDetails("0", ReferenceNo, PDUSupervisorID, CCID, OfficerID);

                    LogandCommitBiddingDetails(ReferenceNo, Status, "INVITATION FOR BIDS HAS BEEN SENT OUT AND WILL BE SUPERVISED BY ( " + PDUSupervisor + ")");
                }
            }

            // Notify Procurement Supervisor
            string By = HttpContext.Current.Session["FullName"].ToString();
            string Subject = "Procurements and Bidding Doc(s) For Review and Approval";
            string MessageToSend = "<p>You have been sent " + i + " procurement(s) for review and your approval before Contracts Committee submission </p>";
            MessageToSend += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

            Process.NotifyManager(By, Subject, PDUSupervisorID, MessageToSend);

            output = i + " Invitation for Bid has been sent to Suppliers";
        }
        else
        {
            output = "Please Select Procurement(s) To Be Submitted For Procurement Supervisor Review and Approval";
        }
        return output;
    }
    public string SubmitAreaBiddingDetails(string StrArry, long OfficerID, int Status)
    {
        string output = "";
        if (StrArry != "")
        {
            string[] arr = StrArry.Split(',');
            int i = 0;
            string ReferenceNo = "";
            for (i = 0; i < arr.Length; i++)
            {
                ReferenceNo = arr[i].ToString();
                if (ReferenceNo != "")
                {
                    long CCID = 0; string CCDescription = "";
                    dTable = GetCCIDForReferenceNo(ReferenceNo);
                    if (dTable.Rows.Count > 0)
                    {
                        CCID = Convert.ToInt64(dTable.Rows[0]["CCID"].ToString());
                        CCDescription = dTable.Rows[0]["CCDescription"].ToString();
                    }

                    data.SaveUpdateBiddingDetails("0", ReferenceNo, OfficerID, CCID, OfficerID);
                    LogandCommitBiddingDetails(ReferenceNo, Status, "Procurement Submitted To " + CCDescription);

                    // Notify Requisitioner and CC Members
                    string AreaOfficer = HttpContext.Current.Session["FullName"].ToString();
                    DataTable dtAlert = GetBiddingDetailsForNotification(ReferenceNo);
                    string Subject = "Procurement " + dtAlert.Rows[0]["Subject"].ToString() + " Submission To Area Contracts Committee";
                    string Requisitioner = dtAlert.Rows[0]["RequisitionerID"].ToString();
                    string CostCenterName = dtAlert.Rows[0]["CostCenterName"].ToString();
                    string ContractsCommittee = dtAlert.Rows[0]["CCDescription"].ToString();

                    string Message = "<p>Procurement ( " + ReferenceNo + " ) entitled <strong>" + dtAlert.Rows[0]["Subject"].ToString() + "</strong> from " + CostCenterName + " has been submitted to " + ContractsCommittee + " for Approval by " + AreaOfficer + " </p>";
                    Message += "<p>For more details, please access the link: <a href='http://192.168.8.110/Procurement/'>http://192.168.8.110/Procurement/</a> to login.</p>";

                    // Notify Contracts Committee
                    //NotifyContractsCommittee(AreaOfficer, Subject, Message, CCID);
                    // Notify Requisitioner
                    Process.NotifyPlanner(AreaOfficer, Subject, Requisitioner, Message);
                }
            }

            output = i + " Procurements Have Been Submitted To Area Contracts Committee For Approval";
        }
        else
        {
            output = "Please Select Procurement(s) To Be Submitted To Area Contracts Committee";
        }
        return output;
    }
    public void LogPreviousStatus(string ReferenceNo)
    {
        data.LogPreviousStatus(ReferenceNo);
    }
    public void LogandCommitBiddingDetails(string ReferenceNo, int Status, string remark)
    {
        int CreatedBy = Convert.ToInt32(HttpContext.Current.Session["UserID"]);
        data.LogandCommitTransaction(ReferenceNo, Status, CreatedBy, remark);
    }
    public void LogCCApprovalDetails(string CCReferenceNo, string ReferenceNo, long CCID, int CCDecisionID, string ApprovalOption, string Remark, int StageID)
    {
        int AppOption = -1;
        if (ApprovalOption != "")
            AppOption = Convert.ToInt32(ApprovalOption);
        long CreatedBy = Convert.ToInt64(HttpContext.Current.Session["UserID"].ToString());
        data.LogCCApprovalDetails(CCReferenceNo, ReferenceNo, CCID, CCDecisionID, AppOption, Remark, StageID, CreatedBy);
    }
    public void LogCCForEvaluation(string ReferenceNo, long CCID)
    {
        data.LogCCForEvaluation(ReferenceNo, CCID);
    }
    public void SubmitEvaluationReport(string ReferenceNo, long CCEvaluationID, long AwardedBidderID, long CurrencyCode, double FinalBidValue)
    {
        data.SubmitEvaluationReport(ReferenceNo, CCEvaluationID, AwardedBidderID, CurrencyCode, FinalBidValue);
    }
    public DataTable GetContractsCommittees()
    {
        dTable = data.GetContractsCommittees();
        return dTable;
    }
    public DataTable GetNegotiations(string PRNumber)
    {
        dTable = data.GetNegotiations(PRNumber);
        return dTable;
    }
    #region Notification Methods

    public string NotifyContractsCommittee(string SenderName, string Subject, string Message, long CCID)
    {
        string Name = "";
        string Email = "";
        dTable = data.GetCCMembersByCCID(CCID);
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow dr in dTable.Rows)
            {
                int NotifyeeID = Convert.ToInt32(dTable.Rows[0]["UserID"]);
                if (bllPlanning.IsDelegated(NotifyeeID))
                {
                    dTable = dataPlanning.GetActing(NotifyeeID);
                    Name = dTable.Rows[0]["FullName"].ToString();
                    Email = dTable.Rows[0]["Email"].ToString();
                }
                else
                {
                    Name = dr["CCMemberName"].ToString();
                    Email = dr["CCMemberEmail"].ToString();
                }
                string Msg = "<p>Hello " + Name.ToUpper() + " , </p>" + Message;
                mailer.SendEmail(SenderName, Email, Subject, Msg);
            }
        }
        return Name;
    }

    public string NotifyPDUSupervisors(string SenderName, string Subject, string Message)
    {
        string Name = "";
        string Email = "";
        dTable = ProcessReq.GetPDUSupervisors();
        if (dTable.Rows.Count > 0)
        {
            foreach (DataRow dr in dTable.Rows)
            {
                int NotifyeeID = Convert.ToInt32(dTable.Rows[0]["UserID"]);
                if (bllPlanning.IsDelegated(NotifyeeID))
                {
                    dTable = dataPlanning.GetActing(NotifyeeID);
                    Name = dTable.Rows[0]["FullName"].ToString();
                    Email = dTable.Rows[0]["Email"].ToString();
                }
                else
                {
                    Name = dr["Name"].ToString();
                    Email = dr["Email"].ToString();
                }
                string Msg = "<p>Hello " + Name.ToUpper() + " , </p>" + Message;
                mailer.SendEmail(SenderName, Email, Subject, Msg);
            }
        }
        return Name;
    }

    public void updateBEB(string refNo, int v, string comment)
    {
        data.updateBEB(refNo, v, comment);

    }

    #endregion Notification Methods

    #region Display Procurement Forms

    public DataTable GetForm1ForReport(string ReferenceNo, string FormNumber, string Section)
    {
        dTable = data.GetForm1ForReport(ReferenceNo, FormNumber, Section);
        return dTable;
    }
    public DataTable GetDetailsForForm16(string ReferenceNo)
    {
        dTable = data.GetDetailsForForm16(ReferenceNo);
        return dTable;
    }
    public DataTable GetReportForMicroProcurements(string ReferenceNo)
    {
        dTable = data.GetReportForMicroProcurements(ReferenceNo);
        return dTable;
    }
    public DataTable GetReportForShortlistedBidders(string ReferenceNo)
    {
        dTable = data.GetReportForShortlistedBidders(ReferenceNo);
        return dTable;
    }
    public DataTable GetReportForECMembers(string ReferenceNo)
    {
        dTable = data.GetReportForECMembers(ReferenceNo);
        return dTable;
    }
    public DataTable GetReportForSolicitationDocumentsIssue(string ReferenceNo)
    {
        dTable = data.GetReportForSolicitationDocumentsIssue(ReferenceNo);
        return dTable;
    }
    public DataTable GetReportForBidReceipt(string ReferenceNo)
    {
        dTable = data.GetReportForBidReceipt(ReferenceNo);
        return dTable;
    }
    public DataTable GetReportForPreBidMeetingQuestions(long PreBidMeetingID)
    {
        dTable = data.GetReportForPreBidMeetingQuestions(PreBidMeetingID);
        return dTable;
    }
    public DataTable GetReportForPreBidMeetingAttendence(long PreBidMeetingID)
    {
        dTable = data.GetReportForPreBidMeetingAttendence(PreBidMeetingID);
        return dTable;
    }
    public DataTable GetReportForBidOpening(long BidOpeningID)
    {
        dTable = data.GetReportForBidOpening(BidOpeningID);
        return dTable;
    }
    public DataTable GetReportForBidOpeningAttendence(long BidOpeningID)
    {
        dTable = data.GetReportForBidOpeningAttendence(BidOpeningID);
        return dTable;
    }
    public DataTable GetReportForNegotiationPlan(long NegotiationPlanID)
    {
        dTable = data.GetReportForNegotiationPlan(NegotiationPlanID);
        return dTable;
    }
    public DataTable GetReportForNegotiationTeam(long NegotiationPlanID)
    {
        dTable = data.GetReportForNegotiationTeam(NegotiationPlanID);
        return dTable;
    }
    public DataTable GetReportForBEB(string ReferenceNo)
    {
        dTable = data.GetReportForBEB(ReferenceNo);
        return dTable;
    }
    public DataTable GetReportForLottedBEB(string ReferenceNo, long LottID)
    {
        dTable = data.GetReportForLottedBEB(ReferenceNo, LottID);
        return dTable;
    }
    public DataTable GetReportForBidAnalysisSheet(string ReferenceNo)
    {
        dTable = data.GetReportForBidAnalysisSheet(ReferenceNo);
        return dTable;
    }
    public DataTable GetReportForProcurementMethodSchedule(long CCID, long CCMemberID, string CCRefNo, int Status, int YearID, int AreaID)
    {
        dTable = data.GetReportForProcurementMethodSchedule(CCID, CCMemberID, CCRefNo, Status, YearID, AreaID);
        return dTable;
    }
    public DataTable GetReportForAwardOfContractsSchedule(long CCID, long CCMemberID, string CCRefNo, int Status, int YearID, int AreaID)
    {
        dTable = data.GetReportForAwardOfContractsSchedule(CCID, CCMemberID, CCRefNo, Status, YearID, AreaID);
        return dTable;
    }
    public DataTable GetReportForRactification(long CCID, long CCMemberID, int YearID, int AreaID)
    {
        dTable = data.GetReportForRactification(CCID, CCMemberID, YearID, AreaID);
        return dTable;
    }
    public DataTable GetReportForMicroProcurementApproval(string ReferenceNo)
    {
        dTable = data.GetReportForMicroProcurementApproval(ReferenceNo);
        return dTable;
    }
    #endregion Display Procurement Forms

    #region UPDATE METHODS
    public void SaveEditQuestions(string ReferenceNo, int QuestionId, string Answer, int UserID)
    {
        data.SaveEditQuestions(ReferenceNo, QuestionId, Answer, UserID);
    }
    public void SaveEditMicroProcurementDetails(long MicroProcurementID, string ReferenceNo, DateTime ClosingDateTime, long CreatedBy)
    {
        data.SaveEditMicroProcurementDetails(MicroProcurementID, ReferenceNo, ClosingDateTime, CreatedBy);
    }
    public string SaveEditMicroProcurementItems(string ReferenceNo, DataTable dtPD02Items, long CreatedBy)
    {
        foreach (DataRow dr in dtPD02Items.Rows)
        {
            long ItemID = Convert.ToInt64(dr["ItemID"].ToString()); string ItemDesc = dr["ItemDescription"].ToString();
            int UnitID = Convert.ToInt32(dr["UnitID"].ToString()); string Quantity = dr["Quantity"].ToString();

            data.SaveEditMicroProcurementItems(ItemID, ReferenceNo, ItemDesc, UnitID, Quantity, CreatedBy);
        }
        return "Micro Procurement Items Have Been Successfully Added to Procurement ";
    }
    public string SavePotentialBidders(string PD_Code, string RefNo, DataTable dtBidders, string CreatedBy, int ProcMethod, int ProcType)
    {
        long UserID = Convert.ToInt64(CreatedBy);
        String bidders = "";
        foreach (DataRow dr in dtBidders.Rows)
        {
            long ShortlistID = Convert.ToInt64(dr["ShortlistID"].ToString());
            DateTime DateCreated = Convert.ToDateTime(dr["DateCreated"].ToString());
            long BidderID = Convert.ToInt64(dr["BidderID"].ToString());
            int ReasonID = Convert.ToInt32(dr["ReasonID"].ToString());
            string OtherReason = dr["OtherReason"].ToString();
            long ProposedByID = Convert.ToInt64(dr["ProposedByID"].ToString());
            int procmethod = Convert.ToInt32(ProcMethod);
            data.SaveUpdateShortlistedBidders(PD_Code, RefNo, ShortlistID, BidderID, ReasonID, OtherReason, DateCreated, ProposedByID, UserID);

            String biddername = dr["CompanyName"].ToString();
            String bidderreason = getBiddingReason(ReasonID);
            bidders += biddername + " ( " + bidderreason + " )  , ";

        }
        //data.SaveUpdateFormAnswerBidders(bidders, RefNo, ProcMethod, ProcType, UserID);

        return "Potential Bidders Have Been Successfully Shortlisted To Procurement " + RefNo;
    }

    public string getBidderName(long BidderID)
    {
        dTable = data.getBidderName(BidderID);
        String name = "";
        if (dTable.Rows.Count > 0)
        {
            name = dTable.Rows[0]["BidderName"].ToString();
        }
        return name;
    }

    public string getBiddingReason(int ReasonID)
    {
        dTable = data.getBiddingReason(ReasonID);
        String reason = "";
        if (dTable.Rows.Count > 0)
        {
            reason = dTable.Rows[0]["Reason"].ToString();
        }
        return reason;
    }

    public string getUserName(long userID)
    {
        dTable = data.getUserName(userID);
        String reason = "";
        if (dTable.Rows.Count > 0)
        {
            reason = dTable.Rows[0]["Name"].ToString();
        }
        return reason;
    }



    public string SaveEvaluationCommitteeMembers(string RefNo, DataTable dtMembers, string CreatedBy, int ProcMethod, int ProcType)
    {
        // UserID has changed to ProfileID
        String ec = "";
        long CreatedByID = Convert.ToInt64(CreatedBy);
        foreach (DataRow dr in dtMembers.Rows)
        {
            long ECMemberID = Convert.ToInt64(dr["ECMemberID"].ToString());
            long ProfileID = Convert.ToInt64(dr["UserID"].ToString());
            string Position = dr["Position"].ToString();
            string Department = dr["Department"].ToString();
            int ReasonID = Convert.ToInt32(dr["ReasonID"].ToString());
            string OtherReason = dr["OtherReason"].ToString();
            data.SaveUpdateEvaluationCommitteeMembers(ECMemberID, RefNo, ProfileID, Position, Department, ReasonID, OtherReason, CreatedByID);

            String membername = dr["ECMember"].ToString();
            String reason = getBiddingReason(ReasonID);
            ec += membername + " ( " + reason + " )  , ";
        }

        data.SaveUpdateFormAnswerEC(ec, RefNo, ProcMethod, ProcType, CreatedByID);

        return "Evaluation Committee Members Have Been Successfully Added to Procurement " + RefNo;
    }
    public void SaveEditSolicitationDocuments(long ID, string ReferenceNo, DateTime DateNoticePublished, DateTime DateDocumentAvailable, string AddendumNumber, bool IsFeePayable, double CostOfDocument, long IssuingOfficer, long CreatedBy)
    {
        data.SaveEditSolicitationDocuments(ID, ReferenceNo, DateNoticePublished, DateDocumentAvailable, AddendumNumber, IsFeePayable, CostOfDocument, IssuingOfficer, CreatedBy);
    }
    public string SaveEditSolicitationDocumentsDetails(string RefNo, DataTable dtSolDocDetails, long CreatedBy)
    {
        foreach (DataRow dr in dtSolDocDetails.Rows)
        {
            long ID = Convert.ToInt64(dr["ID"].ToString()); DateTime RequestReceivedDate = Convert.ToDateTime(dr["RequestReceivedDate"].ToString());
            DateTime FeePaidDate = Convert.ToDateTime(dr["FeePaidDate"].ToString()); DateTime DocumentsIssuedDate = Convert.ToDateTime(dr["DocumentsIssuedDate"].ToString());
            long BidderID = Convert.ToInt64(dr["BidderID"].ToString()); long IssuingOfficer = Convert.ToInt64(dr["IssuingOfficer"].ToString());
            //string bidder = dr["BidderName"].ToString();
            data.SaveEditSolicitationDocumentsDetails(ID, RefNo, RequestReceivedDate, FeePaidDate, DocumentsIssuedDate, BidderID, IssuingOfficer, CreatedBy);
        }
        return "Solicitation Documents Have Been Successfully Added to Procurement " + RefNo;
    }
    public void SaveEditPreBidMeeting(long PreBidMeetingID, string ReferenceNo, string MeetingLocation, DateTime MeetingDate, string ReasonForMeeting, long CreatedBy)
    {
        data.SaveEditPreBidMeeting(PreBidMeetingID, ReferenceNo, MeetingLocation, MeetingDate, ReasonForMeeting, CreatedBy);
    }
    public void SaveEditPrebidMeetingQuestions(long ID, long PreBidMeetingID, string Question, string Answer, long CreatedBy)
    {
        data.SaveEditPrebidMeetingQuestions(ID, PreBidMeetingID, Question, Answer, CreatedBy);
    }
    public void SaveEditPreBidMeetingAttendence(long AttendenceID, long PreBidMeetingID, string Name, string Position, string Company, long CreatedBy)
    {
        data.SaveEditPreBidMeetingAttendence(AttendenceID, PreBidMeetingID, Name, Position, Company, CreatedBy);
    }
    public void SaveEditBidReceipt(long BidReceiptID, string ReferenceNo, DateTime Deadline, int MethodID, string LocationOfSubmission, long PDUSignatory, long CCSignatory, DateTime PreparationDate, long CreatedBy)
    {
        data.SaveEditBidReceipt(BidReceiptID, ReferenceNo, Deadline, MethodID, LocationOfSubmission, PDUSignatory, CCSignatory, PreparationDate, CreatedBy);
    }
    public string SaveEditBidReceiptDetails(string RefNo, DataTable dtBidReceiptDetails, long CreatedBy)
    {
        foreach (DataRow dr in dtBidReceiptDetails.Rows)
        {
            long ID = Convert.ToInt64(dr["ID"].ToString()); DateTime BidReceiveDate = Convert.ToDateTime(dr["BidReceiveDate"].ToString());
            long BidderID = Convert.ToInt64(dr["BidderID"].ToString()); string Comment = dr["Comment"].ToString();
            int NoOfEnvelopes = Convert.ToInt32(dr["NoOfEnvelopes"].ToString());

            data.SaveEditBidReceiptDetails(ID, RefNo, BidderID, BidReceiveDate, Comment, NoOfEnvelopes, CreatedBy);
        }
        return "Bid Receipts Have Been Successfully Added to Procurement " + RefNo;
    }
    public string SaveEditBidOpening(string ReferenceNo, DataTable dtBidOpening, long CreatedBy)
    {
        foreach (DataRow dr in dtBidOpening.Rows)
        {
            long BidOpeningID = Convert.ToInt64(dr["BidOpeningID"].ToString()); string Location = dr["Location"].ToString();
            DateTime DateOfOpening = Convert.ToDateTime(dr["DateOfOpening"].ToString()); int OpeningTypeID = Convert.ToInt32(dr["OpeningTypeID"].ToString());
            long WitnessedByPDU = Convert.ToInt64(dr["PDUMemberID"].ToString()); long WitnessedByCC = Convert.ToInt64(dr["CCMemberID"].ToString());
            data.SaveEditBidOpening(BidOpeningID, ReferenceNo, Location, DateOfOpening, OpeningTypeID, WitnessedByPDU, WitnessedByCC, CreatedBy);
        }
        return "Bid Opening Has Been Successfully Saved to Procurement " + ReferenceNo;
    }
    public void SaveEditBidOpeningDetails(long BidOpeningDetailsID, long BidOpeningID, long BidderID, int Currency, double Price, bool BidSecurityReceived, int BidSecurityCurrencyID, double BidSecurityAmount, int NoOfCopies, string Remarks, long CreatedBy, string PowerOfAttorney)
    {
        data.SaveEditBidOpeningDetails(BidOpeningDetailsID, BidOpeningID, BidderID, Currency, Price, BidSecurityReceived, BidSecurityCurrencyID, BidSecurityAmount, NoOfCopies, Remarks, CreatedBy, PowerOfAttorney);
    }

    public void SaveEditBidOpeningDetail(string refno, string bidderid, string amount, string discount, string remark)

    {
        long CreatedBy = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
        data.SaveEditBidOpeningDetail(refno, bidderid, amount, discount, remark, CreatedBy);
    }

    public string SaveEditBidOpeningAttendence(long BidOpeningID, DataTable dtBidOpeningAttendence, long CreatedBy)
    {
        foreach (DataRow dr in dtBidOpeningAttendence.Rows)
        {
            long BidOpeningAttendenceID = Convert.ToInt64(dr["BidOpeningAttendenceID"].ToString());
            string Name = dr["Name"].ToString(); string Position = dr["Position"].ToString(); string Company = dr["Company"].ToString();

            data.SaveEditBidOpeningAttendence(BidOpeningAttendenceID, BidOpeningID, Name, Position, Company, CreatedBy);
        }
        return "Bid Opening Attendence Has Been Successfully Saved";
    }
    public string SaveEditNegotiationPlan(string ReferenceNo, DataTable dtNegotiationPlan, long CreatedBy)
    {
        foreach (DataRow dr in dtNegotiationPlan.Rows)
        {
            long NegotiationPlanID = Convert.ToInt64(dr["NegotiationPlanID"].ToString());
            long ProviderID = Convert.ToInt64(dr["ProviderID"].ToString());
            long ProposedByID = Convert.ToInt64(dr["ProposedByID"].ToString());
            data.SaveEditNegotiationPlan(NegotiationPlanID, ReferenceNo, ProviderID, ProposedByID, CreatedBy);
        }
        return "Negotiation Plan Has Been Successfully Saved to Procurement " + ReferenceNo;
    }
    public void SaveEditNegotiationPlanDetails(long NegotiationPlanDetailID, long NegotiationPlanID, string Issue, string Objective, string Parameter, long CreatedBy)
    {
        data.SaveEditNegotiationPlanDetails(NegotiationPlanDetailID, NegotiationPlanID, Issue, Objective, Parameter, CreatedBy);
    }
    public string SaveEditNegotiationPlanMembers(long NegotiationPlanID, DataTable dtMembers, string CreatedBy)
    {
        long CreatedByID = Convert.ToInt64(CreatedBy);
        foreach (DataRow dr in dtMembers.Rows)
        {
            long MemberID = Convert.ToInt64(dr["MemberID"].ToString());
            long UserID = Convert.ToInt64(dr["UserID"].ToString());
            string Position = dr["Position"].ToString();
            int ReasonID = Convert.ToInt32(dr["ReasonID"].ToString());
            string OtherReason = dr["OtherReason"].ToString();

            data.SaveUpdateNegotiationTeamMembers(MemberID, NegotiationPlanID, UserID, Position, ReasonID, OtherReason, CreatedByID);
        }
        return "Negotiation Team Members Have Been Successfully Added ...";
    }
    public void SaveEditBidAnalysis(long BidderID, long ItemID, double TotalPrice, long CreatedBy)
    {
        data.SaveEditBidAnalysis(BidderID, ItemID, TotalPrice, CreatedBy);
    }
    public string SaveEditBidderEvaluations(string RefNo, DataTable dtEvaluation, long CreatedBy)
    {
        foreach (DataRow dr in dtEvaluation.Rows)
        {
            long RecordID = Convert.ToInt64(dr["RecordID"].ToString()); string Reason = dr["Reason"].ToString();
            long BidderID = Convert.ToInt64(dr["BidderID"].ToString()); double BidValue = Convert.ToDouble(dr["BidValue"].ToString());
            long BidUnitID = Convert.ToInt64(dr["BidUnitID"].ToString()); bool IsBEB = Convert.ToBoolean(dr["IsBeB"].ToString());

            data.SaveEditBidderEvaluationDetails(RecordID, RefNo, BidderID, IsBEB, 0, BidUnitID, BidValue, Reason, CreatedBy);
        }
        return "Bidder Evaluations Have Been Successfully Added to Procurement " + RefNo;
    }
    public string SaveEditLottedBidderEvaluations(string RefNo, DataTable dtLottedEvaluation, long CreatedBy)
    {
        foreach (DataRow dr in dtLottedEvaluation.Rows)
        {
            long RecordID = Convert.ToInt64(dr["RecordID"].ToString()); string Reason = dr["Reason"].ToString();
            int LottID = Convert.ToInt32(dr["LottID"].ToString()); long BidderID = Convert.ToInt64(dr["BidderID"].ToString());
            double BidValue = Convert.ToDouble(dr["BidValue"].ToString()); long BidUnitID = Convert.ToInt64(dr["BidUnitID"].ToString());
            bool IsBEB = Convert.ToBoolean(dr["IsBeB"].ToString());

            data.SaveEditBidderEvaluationDetails(RecordID, RefNo, BidderID, IsBEB, LottID, BidUnitID, BidValue, Reason, CreatedBy);
        }
        return "Bidder Evaluations Have Been Successfully Added to Procurement " + RefNo;
    }
    public string SaveEditLotts(string ReferenceNo, DataTable dtLott, long CreatedBy)
    {
        foreach (DataRow dr in dtLott.Rows)
        {
            long LottID = Convert.ToInt64(dr["LottID"].ToString());
            int LottNumber = Convert.ToInt32(dr["LottNumber"].ToString());
            string LottDescription = dr["LottDescription"].ToString();

            data.SaveEditLotts(LottID, ReferenceNo, LottNumber, LottDescription, CreatedBy);
        }
        return "Lott Details Have Been Successfully Added to Procurement " + ReferenceNo;
    }

    public void SaveEditPrebidMeetingAttendance(long ID, long PreBidMeetingID, string nameAndAddress, string position, string company, long CreatedBy)
    {
        data.SaveEditPrebidMeetingAttendance(ID, PreBidMeetingID, nameAndAddress, position, company, CreatedBy);
    }



    public void SubmitMicroProcurement(string RefNo, long BidderID, int CurrencyID, double BidAmount, long HOD, string Comment, long CreatedBy)
    {
        data.SubmitMicroProcurement(RefNo, BidderID, CurrencyID, BidAmount, Comment, HOD, CreatedBy);
    }
    public void HOSMicroProcurementApproval(string ReferenceNo, long HOD, int StatusID, string Comment)
    {
        long CreatedBy = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
        data.HOSMicroProcurementApproval(ReferenceNo, HOD, StatusID, Comment, CreatedBy);
    }
    public void HODMicroProcurementApproval(string ReferenceNo, long HOD, int StatusID, string Comment)
    {
        long CreatedBy = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
        data.HODMicroProcurementApproval(ReferenceNo, HOD, StatusID, Comment, CreatedBy);
    }
    public void CCChairmanMicroProcurementApproval(string ReferenceNo, long CCChairmanID, int StatusID, string Comment)
    {
        long CreatedBy = Convert.ToInt64(HttpContext.Current.Session["UserID"]);
        data.CCChairmanMicroProcurementApproval(ReferenceNo, CCChairmanID, StatusID, Comment, CreatedBy);
    }
    public void FlagPotentialBidder(long ShortlistID, bool IsRemoved)
    {
        data.FlagPotentialBidder(ShortlistID, IsRemoved);
    }
    public void FlagPotentialECMember(long ECMemberID, bool IsRemoved)
    {
        data.FlagPotentialECMember(ECMemberID, IsRemoved);
    }
    public void FlagSolicitationDocumentDetail(long ID, bool IsRemoved)
    {
        data.FlagSolicitationDocumentDetail(ID, IsRemoved);
    }
    public void FlagPreBidMeeting(long ID, bool IsRemoved)
    {
        data.FlagPreBidMeeting(ID, IsRemoved);
    }
    public void FlagPreBidMeetingQuestion(long ID, bool IsRemoved)
    {
        data.FlagPreBidMeetingQuestion(ID, IsRemoved);
    }
    public void FlagBidReceiptDetail(long ID, bool IsRemoved)
    {
        data.FlagBidReceiptDetail(ID, IsRemoved);
    }
    public void FlagBidOpening(long BidOpeningID, bool IsRemoved)
    {
        data.FlagBidOpening(BidOpeningID, IsRemoved);
    }
    public void FlagBidOpeningDetails(long BidOpeningDetailsID, bool IsRemoved)
    {
        data.FlagBidOpeningDetails(BidOpeningDetailsID, IsRemoved);
    }
    public void FlagNegotiationPlan(long NegotiationPlanID, bool IsRemoved)
    {
        data.FlagNegotiationPlan(NegotiationPlanID, IsRemoved);
    }
    public void FlagNegPlanDetails(long NegPlanDetailsID, bool IsRemoved)
    {
        data.FlagNegPlanDetails(NegPlanDetailsID, IsRemoved);
    }
    public void FlagNegotiationTeamMember(long MemberID, bool IsRemoved)
    {
        data.FlagNegotiationTeamMember(MemberID, IsRemoved);
    }
    public void FlagBidderEvaluation(long RecordID, bool IsRemoved)
    {
        data.FlagBidderEvaluation(RecordID, IsRemoved);
    }
    public void FlagBidLott(long LottID, bool IsRemoved)
    {
        data.FlagBidLott(LottID, IsRemoved);
    }

    public void FlagPreBidMeetingAttendance(long AttendanceID, bool IsRemoved)
    {
        data.FlagPreBidMeetingAttendance(AttendanceID, IsRemoved);
    }
    #endregion UPDATE METHODS

    #region DOCUMENT METHODS
    public void RemoveDocument(string FileCode)
    {
        long FileID = Convert.ToInt64(FileCode);
        string Path = GetDocumentPath(FileCode);
        File.Delete(Path);
        data.RemoveDocument(FileID);
    }
    public string GetDocPath()
    {
        string Path = "D:\\Reports\\ProcurementAttachments\\";
        dTable = main.GetConfiguration(1);
        if (dTable.Rows.Count > 0)
        {
            Path = dTable.Rows[0]["Details"].ToString();
        }
        CheckPath(Path);
        return Path;
    }
    public string GetDocumentPath(string FileCode)
    {
        long FileID = Convert.ToInt64(FileCode);
        dTable = data.GetDocumentPath(FileID);
        string Path = dTable.Rows[0]["FilePath"].ToString();
        return Path;
    }
    public void SaveBiddingDocument(string ReferenceNo, string FilePath, string FileName, int DocumentTypeID)
    {
        data.SaveBiddingDocument(ReferenceNo, FilePath, FileName, DocumentTypeID);
    }
    public void DownloadFile(string path, bool forceDownload)
    {
        string name = Path.GetFileName(path);
        string ext = Path.GetExtension(path);
        string type = "";
        // set known types based on file extension  
        if (ext != null)
        {
            switch (ext.ToLower())
            {
                case ".htm":
                case ".html":
                    type = "text/HTML";
                    break;

                case ".txt":
                    type = "text/plain";
                    break;

                case ".doc":
                case ".docx":
                case ".rtf":
                    type = "Application/msword";
                    break;
                case ".xls":
                case ".xlsx":
                    type = "Application/vnd.ms-excel";
                    break;
                case ".pdf":
                    type = "Application/pdf";
                    break;
            }
        }
        if (forceDownload)
        {
            HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename=" + name);
        }
        if (type != "")
            HttpContext.Current.Response.ContentType = type;
        HttpContext.Current.Response.WriteFile(path);
        HttpContext.Current.Response.End();
    }
    #endregion DOCUMENT METHODS

    public void saveBidderClassification(int bidderId, int category, int subcategory)
    {
        data.saveBidderClassification(bidderId, category, subcategory);
    }


    public void removeBidderClassification(int recordId)
    {
        data.removeBidderClassification(recordId);
    }



}
public class BudgetReport
{
    public String budgetId;
    public String budgetCode;
    public String costCenterCode;
    public String costCenterName;
    public String amount;

}