using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

public class DataBidding
{
    private Database Proc_DB;
    private Database scala_DB;
    private DbCommand mycommand;
    private DataSet returnDataset;
    private DataTable returnDatatable;
    private BusinessRequisition bll = new BusinessRequisition();
    DataLogin con = new DataLogin();

	public DataBidding()
	{
        try
        {
            Proc_DB = con.ShareProc_Con();
            scala_DB = con.ShareScala_Con();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region DATA CALLING METHODS
    public DataTable CheckIfCCUser(long UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_CheckIfCCUser", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBiddingDetailsForNotification(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBiddingDetailsForNotification", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetRequisitionDetails(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetRequisitionDetailsByPRNo", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable GetBEBRequisitionDetails(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBEBRequisitionDetailsByPRNo", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal DataTable GetOfficerDocTypes()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetOfficerDocTypes");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal DataTable GetEvaluationDocTypes()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("GetBidevaluationDocs");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetBiddingProcurementTypes()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBiddingProcurementTypes");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetSuppliersByProcurementTypes(int TypeID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetSuppliersByProcurementTypes", TypeID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    } 
    public DataTable GetBidderCategoriesByProcType(int TypeID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidderCategoriesByProcType", TypeID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBidderDetails(long BidderID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidderDetails", BidderID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetBidderByCategory(int TypeID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidderByCategory", TypeID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCCMemberDetails(long CCUserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetCCMemberDetails", CCUserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetProfilesByNames(string Value)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetProfilesByName", Value);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBiddingDocuments(string ReferenceNo, int DocumentTypeID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetDocuments", ReferenceNo, DocumentTypeID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    
    public DataTable GetBiddingDocuments2(string ReferenceNo, int DocumentTypeID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetDocuments2", ReferenceNo, DocumentTypeID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetBiddingEvaluationDocuments2(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetEvaluationDocuments", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBiddingDocuments2bYCreator(string ReferenceNo, int DocumentTypeID,int createdby)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetDocuments2ByCreator", ReferenceNo, DocumentTypeID, createdby);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCCMeetingMinutes(string CCRefNo, int DocumentTypeID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetCCMeetingMinutes", CCRefNo, DocumentTypeID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetAssignedProcurements(long RecordID, string PrNumber, int Officer, int ProcMethod, int CostCenterID, int Status, int FinID, int AreaID)
    {

        

        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetAssignedProcurements", RecordID, PrNumber, Officer, ProcMethod, CostCenterID, Status, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetProcurementsForECSubmissionOnly(long RecordID, string PrNumber, int Officer, int ProcMethod, int CostCenterID, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetProcurementsForECSubmissionOnly", RecordID, PrNumber, Officer, ProcMethod, CostCenterID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCCProcurements(long RecordID, string PrNumber, long CCMemberID, long ProcOfficer, int ProcMethod, int CostCenterID, int StatusID, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetCCProcurements", RecordID, PrNumber, CCMemberID, ProcOfficer, ProcMethod, CostCenterID, StatusID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCCEvaluationProcurements(long RecordID, string PrNumber, long CCMemberID, long ProcOfficer, int ProcMethod, int CostCenterID, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetCCEvaluationProcurements", RecordID, PrNumber, CCMemberID, ProcOfficer, ProcMethod, CostCenterID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable ProcurementApprovedByAreaCC(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_ProcurementApprovedByAreaCC", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable IsProcurementFromArea(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_IsProcurementFromArea", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetECProcurements(long RecordID, string PrNumber, long ProcOfficer, int ProcMethod, int CostCenterID, int StatusID, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetECProcurements", RecordID, PrNumber, ProcOfficer, ProcMethod, CostCenterID, StatusID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPDUProcurementsForEvaluation(long RecordID, string PrNumber, long ProcOfficer, int ProcMethod, int CostCenterID, int StatusID, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetPDUProcurementsForEvaluation", RecordID, PrNumber, ProcOfficer, ProcMethod, CostCenterID, StatusID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBiddingProcurements(long RecordID, string PrNumber, long OfficerID, int ProcMethod, int CostCenterID, string Status, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBiddingProcurements", RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPreBidMeetingProcurements(long RecordID, string PrNumber, long OfficerID, int ProcMethod, int CostCenterID, string Status, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetPreBidMettingProcurements", RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetBidSolicitationProcurements(long RecordID, string PrNumber, long OfficerID, int ProcMethod, int CostCenterID, string Status, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidSolicitationProcurements", RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetBidReceiptProcurements(long RecordID, string PrNumber, long OfficerID, int ProcMethod, int CostCenterID, string Status, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidReceiptProcurements", RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetBidOpeningProcurements(long RecordID, string PrNumber, long OfficerID, int ProcMethod, int CostCenterID, string Status, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidOpeningProcurements", RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetBidEvaluationProcurements(long RecordID, string PrNumber, long OfficerID, int ProcMethod, int CostCenterID, string Status, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidEvaluationProcurements", RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable GetBiddingProcurements2(long RecordID, string PrNumber, long OfficerID, int ProcMethod, int CostCenterID, string Status, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBiddingProcurements2", RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetProcurementsForSolicitation(long RecordID, string PrNumber, long OfficerID, int ProcMethod, int CostCenterID, string Status, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetProcurementsForSolicitation", RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, Status, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetLevelProcurements(long RecordID, string PrNumber, long OfficerID, int ProcMethod, int CostCenterID, int StatusID, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetLevelProcurements", RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, StatusID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetLevelProcurements2(long RecordID, string PrNumber, long OfficerID, int ProcMethod, int CostCenterID, int StatusID, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetLevelProcurements2", RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, StatusID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetApprovedProcurements(long RecordID, string PrNumber, long OfficerID, int ProcMethod, int CostCenterID, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetApprovedProcurements", RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetMicroProcurements(long RecordID, string PrNumber, long OfficerID, int CostCenterID, int StatusID, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetMicroProcurements", RecordID, PrNumber, OfficerID, CostCenterID, StatusID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetRejectedMicroProcurements(long RecordID, string PrNumber, long OfficerID, int CostCenterID, int FinID, int AreaID,int StatusID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetRejectedMicroProcurements", RecordID, PrNumber, OfficerID, CostCenterID, FinID, AreaID, StatusID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetMicroProcurementApprovals(long RecordID, string PrNumber, long OfficerID, int StatusID, int CostCenterID, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetMicroProcurementApprovals", RecordID, PrNumber, OfficerID, CostCenterID, StatusID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetMicroProcurementHOSApprovals(long RecordID, string PrNumber, long OfficerID, long HOS, int CostCenterID, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetMicroProcurementHOSApprovals", RecordID, PrNumber, OfficerID, HOS, CostCenterID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetMicroProcurementHODApprovals(long RecordID, string PrNumber, long OfficerID, long HOD, int CostCenterID, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetMicroProcurementHODApprovals", RecordID, PrNumber, OfficerID, HOD, CostCenterID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetMicroProcurementCCChairmanApprovals(long RecordID, string PrNumber, long OfficerID, long ChairmanID, int CostCenterID, int FinID, int AreaID, int ChairmanAreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetMicroProcurementCCChairmanApprovals", RecordID, PrNumber, OfficerID, ChairmanID, CostCenterID, FinID, AreaID, ChairmanAreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetProcurementsForSupervisorSubmission(long RecordID, string PrNumber, int ProcMethod, int ProcOfficer, int CostCenterID, int StatusID, int FinID, int AreaID, bool IsSupervisor)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetProcurementsForSupervisorSubmission", RecordID, PrNumber, ProcMethod, ProcOfficer, CostCenterID, StatusID, FinID, AreaID, IsSupervisor);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetProcurementsForMD(long RecordID, string PrNumber, int ProcMethod, int ProcOfficer, int CostCenterID, int StatusID, int FinID, int AreaID, bool IsSupervisor)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetProcurementsForMD", RecordID, PrNumber, ProcMethod, ProcOfficer, CostCenterID, StatusID, FinID, AreaID, IsSupervisor);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCCScheduledProcurements(long RecordID, string PrNumber, int ProcMethod, int ProcOfficer, int CostCenterID, int StatusID, int FinID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetCCScheduledProcurements", RecordID, PrNumber, ProcMethod, ProcOfficer, CostCenterID, StatusID, FinID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetSections4Questions(int ProcMethod, int SubmissionType)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetSections4Questions", ProcMethod, SubmissionType);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetSections4Questions2(int ProcMethod, int SubmissionType, int proctype)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetSections4Questions2", ProcMethod, SubmissionType,proctype);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetSectionsForEvaluationReport2( String section /*int ProcMethod*/)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetSectionsForEvaluationReport", section);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal void generateIFB(string referenceNo, int supplierid)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_generateIFB", referenceNo, supplierid);
            Proc_DB.ExecuteNonQuery(mycommand);
           
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    internal void updateIFB(string referenceNo, int supplierid)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_updateIFB", referenceNo, supplierid);
            Proc_DB.ExecuteNonQuery(mycommand);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetSectionsForEvaluationReport(int ProcMethod)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetSectionsForEvaluationReport", ProcMethod);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetAnsweredFormDetails(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetAnsweredFormDetails", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetFormNumberByProcMethod(int ProcMethod, int SubmissionType)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetFormNumberByProcMethod", ProcMethod, SubmissionType);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportName(int NewProcMethod, string PPForm, string Section, bool CCSubmission)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportName", NewProcMethod, PPForm, Section, CCSubmission);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetQuestions(int ProcMethod, string Section)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetQuestions", ProcMethod, Section);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetGridAnswers(string ReferenceNo, string ProcMethod, string Section)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetGridAnswers", ReferenceNo, ProcMethod, Section);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetQuestionAnswer(string ReferenceNo, int QuestionId)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetQuestionAnswer", ReferenceNo, QuestionId);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetSectionQuestions(int ProcMethod, string Section)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetSectionQuestions", Section, ProcMethod);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal void updateContractNumber(string refno, string contractnum)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_updateContractNumber", refno, contractnum);
            Proc_DB.ExecuteNonQuery(mycommand);
          
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetSectionAnswers(string Section, string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetSectionAnswers", Section, ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetQuestionAnswers(string ReferenceNo, int questionid)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetQuestionAnswers", ReferenceNo, questionid);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetShortlistedBidderDetails(string PRNumber)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetShortlistedBidderDetails", PRNumber);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetProcBiddersDocuments(string PRNumber)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetProcBiddersDocuments", PRNumber);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable GetECMemberDetails(string PRNumber)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetEvaluationCommitteeMembers", PRNumber);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBidderReasons(int Type)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReasons", Type);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBidderCategories()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidderCategories");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPositions(string Committee)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetPositions", Committee);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCCIDForReferenceNo(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetCCIDForReferenceNo", ReferenceNo);
            mycommand.CommandTimeout = 140;
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetRequisitionDetailsReferenceNo(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("GetProcurementTypeForRequisition", ReferenceNo);
            mycommand.CommandTimeout = 140;
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetCCIDForEvaluationReport(string ReferenceNo, double Amount)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetCCIDForEvaluationReport", ReferenceNo, Amount);
            mycommand.CommandTimeout = 140;
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBEBDetails(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_BEBDetails", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetMicroProcurementDetails(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetMicroProcurementDetails", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetMicroProcurementItems(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetMicroProcurementItems", ReferenceNo);
            mycommand.CommandTimeout = 0;
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetSoliticationDocuments(string PRNumber)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetSolicitationDocuments", PRNumber);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable GetBidderDocuments(string PRNumber,int supplierid)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidderDocuments", PRNumber, supplierid);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable BidderIFBs(int supplierid, int status)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidderIFBs", supplierid, status);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetSoliticationDocumentDetails(string PRNumber)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetSoliticationDocumentDetails", PRNumber);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPreBidMeetings(string PRNumber)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetPreBidMeeting", PRNumber);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPreBidMeetingByID(long PreBidMeetingID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetPreBidMeetingByID", PreBidMeetingID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPreBidMeetingQuestions(long PreBidMeetingID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetPreBidMeetingQuestions", PreBidMeetingID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBidOpeningDetails(long BidopeningID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidOpeningDetails", BidopeningID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetPreBidMeetingAttendance(long PreBidMeetingID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetPreBidMeetingAttendance", PreBidMeetingID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBidOpeningAttendance(long BidOpeningID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidOpeningAttendance", BidOpeningID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBidReceipt(string PRNumber)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidReceipt", PRNumber);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBidReceiptDetails(string PRNumber)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidReceiptDetails", PRNumber);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBidOpening(string PRNumber)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidOpening", PRNumber);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBidReceiptMethods()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidReceiptMethods");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBidOpeningTypes()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidOpeningTypes");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCurrencies()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetCurrencies");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCountries()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetCountries");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetUnits()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Planning_GetUnits");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCCMembersByCCID(long CCID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetCCMembersByCCID", CCID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCCMembers(long CCID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetCCMembers", CCID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetSolicitedBiddersByReferenceNo(string RefNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetSolicitedBiddersByReferenceNo", RefNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBiddersForBidSolicitByReferenceNo(string RefNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBiddersForBidSolicitByReferenceNo", RefNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBiddersForBidOpeningByReferenceNo(string RefNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBiddersForBidOpeningByReferenceNo", RefNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBiddersForReceivedBidsByReferenceNo(string RefNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBiddersForReceivedBidsByReferenceNo", RefNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }  
    public DataTable GetMicroProcurementForBidAnalysis(string RefNo, string BidderID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetMicroProcurementForBidAnalysis", RefNo, BidderID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetNegotiationPlan(string PRNumber)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetNegotiationPlan", PRNumber);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetNegotiationPlanByID(long NegotiationPlanID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetNegotiationPlanByID", NegotiationPlanID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetNegotiationPlanDetails(long NegotiationPlanID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetNegotiationPlanDetails", NegotiationPlanID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetNegotiationPlanMembers(long NegotiationPlanID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetNegotiationPlanMembers", NegotiationPlanID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetNegotiations(string PRNumber)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetNegotiations", PRNumber);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetCCApprovalOptions(int StatusID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetCCApprovalOptions", StatusID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetContractsCommittees()
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetContractsCommittees");
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetBidderEvaluations(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidderEvaluations", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetLottedBidderEvaluations(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetLottedBidderEvaluations", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetLottDetails(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetLottDetails", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal void updateBEB(string refNo, int v, string comment)
    {

        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_updateBEB", refNo, v, comment);
            Proc_DB.ExecuteNonQuery(mycommand);
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetLottByID(long LottID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetLottByID", LottID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetLotts(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetLotts", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    } // 
    public DataTable GetProcurementLotts(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetProcurementLotts", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable SearchProcurements(long RecordID, string PrNumber, long OfficerID, int ProcMethod, int CostCenterID, int FinID, int AreaID, int status)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SearchProcurements", RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, FinID, AreaID, status);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable ViewProcurements(long RecordID, string PrNumber, long OfficerID, int ProcMethod, int CostCenterID, int FinID, int AreaID, int status)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_ViewProcurements", RecordID, PrNumber, OfficerID, ProcMethod, CostCenterID, FinID, AreaID, status);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetOtherPPForms(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetOtherPPForms", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetFormDetails(string refno, int AreaId)
    {

        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetFormDetails", refno, AreaId);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    #endregion DATA CALLING METHODS

    #region GET FORM DATA METHODS
    public DataTable GetForm1ForReport(string ReferenceNo, string FormNumber, string Section)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetForm1ForReport", ReferenceNo, FormNumber, Section);
            mycommand.CommandTimeout = 0;
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForMicroProcurements(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForMicroProcurements", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForShortlistedBidders(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForShortlistedBidders", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForECMembers(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForECMembers", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetDetailsForForm16(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetDetailsForForm16", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DataTable GetReportForSolicitationDocumentsIssue(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForSolicitationDocumentsIssue", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForBidReceipt(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForBidReceipt", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForPreBidMeetingAttendence(long PreBidMeetingID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForPreBidMeetingAttendence", PreBidMeetingID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForPreBidMeetingQuestions(long PreBidMeetingID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForPreBidMeetingQuestions", PreBidMeetingID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForBidOpening(long BidOpeningID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForBidOpening", BidOpeningID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForBidOpeningAttendence(long BidOpeningID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForBidOpeningAttendence", BidOpeningID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForNegotiationPlan(long NegotiationPlanID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForNegotiationPlan", NegotiationPlanID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForNegotiationTeam(long NegotiationPlanID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForNegotiationTeam", NegotiationPlanID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForBEB(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForBEB", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForLottedBEB(string ReferenceNo, long LottID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForLottedBEB", ReferenceNo, LottID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForBidAnalysisSheet(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForBidAnalysisSheet", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForProcurementMethodSchedule(long CCID, long CCMemberID, string CCRefNo, int Status, int YearID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForProcurementMethodSchedule", CCID, CCMemberID, CCRefNo, Status, YearID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForAwardOfContractsSchedule(long CCID, long CCMemberID, string CCRefNo, int Status, int YearID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForAwardOfContractsSchedule", CCID, CCMemberID, CCRefNo, Status, YearID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForRactification(long CCID, long CCMemberID, int YearID, int AreaID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForRactification", CCID, CCMemberID, YearID, AreaID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable GetReportForMicroProcurementApproval(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReportForMicroProcurementApproval", ReferenceNo);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion GET FORM DATA METHODS

    #region DATA INSERTION METHODS

    public void SaveEditQuestions(string ReferenceNo, int QuestionId, string Answer, int UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditQuestion", ReferenceNo, QuestionId, Answer, UserID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveEditMicroProcurementDetails(long MicroProcurementID, string ReferenceNo, DateTime ClosingDateTime, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditMicroProcurements", MicroProcurementID, ReferenceNo, ClosingDateTime, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveEditMicroProcurementItems(long ItemID, string ReferenceNo, string ItemDesc, int UnitID, string Quantity, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditMicroProcurementItems", ItemID, ReferenceNo, ItemDesc, UnitID, Quantity, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveUpdateShortlistedBidders(string PDCode, string ReferenceNo, long ShortlistID, long BidderID, int ReasonID, string OtherReason, DateTime ShortlistedDate, long ProposedByID, long UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveUpdateShortlistedBidders", PDCode, ReferenceNo, ShortlistID, BidderID, ReasonID, OtherReason, ShortlistedDate, ProposedByID, UserID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public void SaveUpdateFormAnswerBidders(string bidders, string ReferenceNo, int procmethod, int proctype, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveUpdateFormAnswerBidders", bidders, ReferenceNo, procmethod,proctype, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveUpdateFormAnswerEC(string ec, string ReferenceNo, int procmethod, int proctype, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveUpdateFormAnswerEC", ec, ReferenceNo, procmethod, proctype, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public DataTable getBidderName(long BidderID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidderNamebyID", BidderID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataTable getUserName(long UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_GetUserNamebyID", UserID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataTable getBiddingReason(int ReasonID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetReasons", ReasonID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    
    public void SaveEditSolicitationDocuments(long ID, string ReferenceNo, DateTime DateNoticePublished, DateTime DateDocumentAvailable, string AddendumNumber, bool IsFeePayable, double CostOfDocument, long IssuingOfficer, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditSolicitationDocuments", ID, ReferenceNo, DateNoticePublished, DateDocumentAvailable, AddendumNumber, IsFeePayable, CostOfDocument, IssuingOfficer, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveEditPreBidMeeting(long PreBidMeetingID, string ReferenceNo, string MeetingLocation, DateTime MeetingDate, string ReasonForMeeting, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditPreBidMeeting", PreBidMeetingID, ReferenceNo, MeetingLocation, MeetingDate, ReasonForMeeting, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveEditPrebidMeetingQuestions(long ID, long PreBidMeetingID, string Question, string Answer, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditPrebidMeetingQuestions", ID, PreBidMeetingID, Question, Answer, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveEditPreBidMeetingAttendence(long AttendenceID, long PreBidMeetingID, string Name, string Position, string Company, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditPreBidMeetingAttendence", AttendenceID, PreBidMeetingID, Name, Position, Company, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveEditBidReceipt(long BidReceiptID, string ReferenceNo, DateTime Deadline, int MethodID, string LocationOfSubmission, long PDUSignatory, long CCSignatory, DateTime PreparationDate, long CreatedBy)
    {
        try
        {
            if (CCSignatory == 0)
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditBidReceipt", BidReceiptID, ReferenceNo, Deadline, MethodID, LocationOfSubmission, PDUSignatory, DBNull.Value, PreparationDate, CreatedBy);
            else
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditBidReceipt", BidReceiptID, ReferenceNo, Deadline, MethodID, LocationOfSubmission, PDUSignatory, CCSignatory, PreparationDate, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveEditSolicitationDocumentsDetails(long ID, string ReferenceNo, DateTime RequestReceivedDate, DateTime FeePaidDate, DateTime DocumentsIssuedDate, long BidderID, long IssuingOfficer, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditSolicitationDocumentsDetails", ID, ReferenceNo, RequestReceivedDate, FeePaidDate, DocumentsIssuedDate, BidderID, IssuingOfficer, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveEditBidReceiptDetails(long ID, string RefNo, long BidderID, DateTime BidReceiveDate, string Comment, int NoOfEnvelopes, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditBidReceiptDetails", ID, RefNo, BidderID, BidReceiveDate, Comment, NoOfEnvelopes, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveUpdateEvaluationCommitteeMembers(long ECMemberID, string ReferenceNo, long ProfileID, string Position, string Department, int ReasonID, string OtherReason, long CreatedByID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveUpdateEvaluationCommitteeMembers", ECMemberID, ReferenceNo, ProfileID, Position, Department, ReasonID, OtherReason, CreatedByID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveUpdateBiddingDetails(string RecordID, string ReferenceNo, long PDUSupervisorID, long CCID, long OfficerID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveUpdateBiddingDetails", RecordID, ReferenceNo, PDUSupervisorID, CCID, OfficerID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Send Bids To Suppliers
    /// </summary>
    /// <param name="RecordID"></param>
    /// <param name="ReferenceNo"></param>
    /// <param name="PDUSupervisorID"></param>
    /// <param name="CCID"></param>
    /// <param name="OfficerID"></param>
    public void SaveUpdateBiddingDetailsForSupplier(string RecordID, string ReferenceNo, long PDUSupervisorID, long CCID, long OfficerID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveUpdateBiddingDetailsDaniel", RecordID, ReferenceNo, PDUSupervisorID, CCID, OfficerID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SaveEditBidOpening(long BidOpeningID, string ReferenceNo, string Location, DateTime DateOfOpening, int OpeningTypeID, long WitnessedByPDU, long WitnessedByCC, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditBidOpening", BidOpeningID, ReferenceNo, Location, DateOfOpening, OpeningTypeID, WitnessedByPDU, WitnessedByCC, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveEditBidOpeningDetails(long BidOpeningDetailsID, long BidOpeningID, long BidderID, int Currency, double Price, bool BidSecurityReceived, int BidSecurityCurrency, double BidSecurityAmount, int NoOfCopies, string Remarks, long CreatedBy, string PowerOfAttorney)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditBidOpeningDetails", BidOpeningDetailsID, BidOpeningID, BidderID, Currency, Price, BidSecurityReceived, BidSecurityCurrency, BidSecurityAmount, NoOfCopies, Remarks, CreatedBy, PowerOfAttorney);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SaveEditBidOpeningDetail(string refno, string bidderid, string amount, string discount, string remark, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditBidderEvaluation", refno, bidderid, amount, discount, remark, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SaveEditBidOpeningAttendence(long BidOpeningAttendenceID, long BidOpeningID, string Name, string Position, string Company, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditBidOpeningAttendence", BidOpeningAttendenceID, BidOpeningID, Name, Position, Company, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveEditNegotiationPlan(long NegotiationPlanID, string ReferenceNo, long ProviderID, long ProposedByID, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditNegotiationPlan", NegotiationPlanID, ReferenceNo, ProviderID, ProposedByID, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveEditNegotiationPlanDetails(long NegotiationPlanDetailID, long NegotiationPlanID, string Issue, string Objective, string Parameter, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditNegotiationPlanDetails", NegotiationPlanDetailID, NegotiationPlanID, Issue, Objective, Parameter, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveUpdateNegotiationTeamMembers(long MemberID, long NegotiationPlanID, long UserID, string Position, int ReasonID, string OtherReason, long CreatedByID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveUpdateNegotiationTeamMembers", MemberID, NegotiationPlanID, UserID, Position, ReasonID, OtherReason, CreatedByID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveEditBidAnalysis(long BidderID, long ItemID, double TotalPrice, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditBidAnalysis", BidderID, ItemID, TotalPrice, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveEditBidderEvaluationDetails(long RecordID, string RefNo, long BidderID, bool IsBEB, int LottNumber, long BidUnitID, double BidValue, string Reason, long CreatedBy)
    {
        try
        {
            if (LottNumber == 0)
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditBidderEvaluationDetails", RecordID, RefNo, BidderID, IsBEB, DBNull.Value, BidUnitID, BidValue, Reason, CreatedBy);
            else
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditBidderEvaluationDetails", RecordID, RefNo, BidderID, IsBEB, LottNumber, BidUnitID, BidValue, Reason, CreatedBy);
            
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveEditLotts(long LottID, string RefNo, int LottNumber, string LottDescription, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditLotts", LottID, RefNo, LottNumber, LottDescription, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    } 
    public void SaveEditBidders(long BidderID, string CompanyName, string DirectorNames, string PhysicalAddress, string PhoneNumbers,
        string EmailAddress, long BidderCategoryID,String ppa,String designation, bool IsActive, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditBidder", BidderID, CompanyName, DirectorNames, PhysicalAddress, PhoneNumbers, EmailAddress, BidderCategoryID, ppa, designation, IsActive, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveEditCCMember(long CCMemberID, long CCID, long UserID, long PositionID, string ReasonForSelection, bool IsActive, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditCCMember", CCMemberID, CCID, UserID, PositionID, ReasonForSelection, IsActive, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void LogPreviousStatus(string ReferenceNo)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_LogPreviousStatus", ReferenceNo);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void LogandCommitTransaction(string ReferenceNo, int Status, int CreatedBy, string Remark)
    {
        // Changes Status and Logs in Transactions Table
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_LogTransaction", ReferenceNo, Status, Remark, CreatedBy);
            mycommand.CommandTimeout = 140;
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void LogCCApprovalDetails(string CCReferenceNo, string ReferenceNo, long CCID, int CCDecisionID, int ApprovalOption, string Remark, int StageID, long CreatedBy)
    {
        try
        {
            if (ApprovalOption != -1)
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_LogCCApprovalDetails", CCReferenceNo, ReferenceNo, CCID, CCDecisionID, ApprovalOption, Remark, StageID, CreatedBy);
            else
                mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_LogCCApprovalDetails", CCReferenceNo, ReferenceNo, CCID, CCDecisionID, DBNull.Value, Remark, StageID, CreatedBy);  
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void LogCCForEvaluation(string ReferenceNo, long CCID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_LogCCForEvaluation", ReferenceNo, CCID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SubmitEvaluationReport(string ReferenceNo, long CCEvaluationID, long AwardedBidderID, long CurrencyCode, double FinalBidValue)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SubmitEvaluationReport", ReferenceNo, CCEvaluationID, AwardedBidderID, CurrencyCode, FinalBidValue);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SubmitMicroProcurement(string RefNo, long BidderID, int CurrencyID, double BidAmount, string Comment, long HOD, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SubmitMicroProcurement", RefNo, BidderID, CurrencyID, BidAmount, Comment, HOD, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void HOSMicroProcurementApproval(string ReferenceNo, long HOD, int StatusID, string Remark, long UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_HOSMicroProcurementApproval", ReferenceNo, HOD, StatusID, Remark, UserID); 
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void HODMicroProcurementApproval(string ReferenceNo, long HOD, int StatusID, string Remark, long UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_HODMicroProcurementApproval", ReferenceNo, HOD, StatusID, Remark, UserID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void CCChairmanMicroProcurementApproval(string ReferenceNo, long CCChairmanID, int StatusID, string Remark, long UserID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_CCChairmanMicroProcurementApproval", ReferenceNo, CCChairmanID, StatusID, Remark, UserID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void FlagPotentialBidder(long ShortlistID, bool IsRemoved)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_FlagPotentialBidder", ShortlistID, IsRemoved);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    } 
    public void FlagPotentialECMember(long ECMemberID, bool IsRemoved)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_FlagECMember", ECMemberID, IsRemoved);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    } 
    public void FlagSolicitationDocumentDetail(long ID, bool IsRemoved)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_FlagSolicitationDocumentDetail", ID, IsRemoved);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void FlagPreBidMeeting(long ID, bool IsRemoved)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_FlagPreBidMeeting", ID, IsRemoved);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void FlagPreBidMeetingQuestion(long ID, bool IsRemoved)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_FlagPreBidMeetingQuestion", ID, IsRemoved);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void FlagBidReceiptDetail(long ID, bool IsRemoved)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_FlagBidReceiptDetail", ID, IsRemoved);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void FlagBidOpening(long BidOpeningID, bool IsRemoved)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_FlagBidOpening", BidOpeningID, IsRemoved);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void FlagBidOpeningDetails(long BidOpeningDetailsID, bool IsRemoved)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_FlagBidOpeningDetails", BidOpeningDetailsID, IsRemoved);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    } 
    public void FlagNegotiationPlan(long NegotiationPlanID, bool IsRemoved)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_FlagNegotiationPlan", NegotiationPlanID, IsRemoved);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void FlagNegPlanDetails(long NegPlanDetailsID, bool IsRemoved)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_FlagNegPlanDetails", NegPlanDetailsID, IsRemoved);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void FlagNegotiationTeamMember(long MemberID, bool IsRemoved)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_FlagNegotiationTeamMember", MemberID, IsRemoved);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void FlagBidLott(long LottID, bool IsRemoved)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_FlagBidLott", LottID, IsRemoved);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void FlagBidderEvaluation(long RecordID, bool IsRemoved)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_FlagBidderEvaluation", RecordID, IsRemoved);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void FlagPreBidMeetingAttendance(long AttendanceID, bool IsRemoved)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_FlagPreBidMeetingAttndance", AttendanceID, IsRemoved);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion DATA INSERTION METHODS

    public DataTable GetConfiguration(int Config_Code)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_General_GetConfig", Config_Code);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    internal void updateDocumentStatus(int docId)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_updateDocumentStatus", docId);
            Proc_DB.ExecuteNonQuery(mycommand);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public void RemoveDocument(long FileID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_DeleteDocument", FileID);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal DataTable GetBidderNewCategories(int type)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidderNewCategories", type);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    internal DataTable getBidderClassifications(int bidder)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Biddin_getBidderClassification", bidder);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    internal void removeBidderClassification(int recordId)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Biddin_removeBidderClassification", recordId);
            Proc_DB.ExecuteNonQuery(mycommand);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    internal void saveBidderClassification(int bidderId, int category, int subcategory)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_saveBidderClassification", bidderId, category, subcategory);
            Proc_DB.ExecuteNonQuery(mycommand);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }




    internal DataTable GetSuppliersByCategory(int procType, int cate, int subcat)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetSuppliesbyCategory", procType, cate, subcat);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetDocumentPath(long FileID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetDocumentPath", FileID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void SaveBiddingDocument(string ReferenceNo, string FilePath, string FileName, int DocumentTypeID)
    {
        int creator;
        if (HttpContext.Current.Session["UserID"] != null)
        {
            creator = int.Parse(HttpContext.Current.Session["UserID"].ToString());
        }
        else
        {
            creator = 0;
        }
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveBiddingDocument", ReferenceNo, FilePath, FileName, DocumentTypeID, creator);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable GetBidderSubCategoriesByProcType(int TypeID)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_GetBidderSubCategories", TypeID);
            returnDatatable = Proc_DB.ExecuteDataSet(mycommand).Tables[0];
            return returnDatatable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SaveEditPrebidMeetingAttendance(long ID, long PreBidMeetingID, string nameAndAddress, string position, string company, long CreatedBy)
    {
        try
        {
            mycommand = Proc_DB.GetStoredProcCommand("Proc_Bidding_SaveEditPrebidMeetingAttendence", ID, PreBidMeetingID, nameAndAddress, position, company, CreatedBy);
            Proc_DB.ExecuteNonQuery(mycommand);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


}
