using CRM.UITest.Helper.ViewModel;
using System.Collections.Generic;

namespace CRM.UITest.Entities
{
    public class InsuranceClaimViewModel
    {
        public string DlswRefNumber { get; set; }

        public string CarrierName { get; set; }

        public string CarrierProNumber { get; set; }

        public string ShipperName { get; set; }

        public string ShipperAddress { get; set; }

        public string ShipperAdd2 { get; set; }

        public string ShipperZip { get; set; }

        public string ShipperCountry { get; set; }

        public string ShipperCity { get; set; }

        public string ShipperState { get; set; }

        public string ConsigneName { get; set; }

        public string ConsigneAddress { get; set; }

        public string ConsigneAdd2 { get; set; }

        public string ConsigneZip { get; set; }

        public string ConsigneCountry { get; set; }

        public string ConsigneCity { get; set; }

        public string ConsigneState { get; set; }

        public string ClaimCompanyName { get; set; }

        public string ClaimAddress { get; set; }

        public string ClaimAdd2 { get; set; }

        public string ClaimZip { get; set; }

        public string ClaimCity { get; set; }

        public string ClaimCountry { get; set; }

        public string ClaimState { get; set; }
        public string ClaimContactName { get; set; }

        public string ClaimContactPhone { get; set; }

        public string ClaimContactEmail { get; set; }

        public string ClaimWebsite { get; set; }

        public bool IsArticlesIns { get; set; }

        public decimal? InsuredValAmount { get; set; }

        public int ClaimTypeId { get; set; }

        public int AritcleTypeId { get; set; }

        public string ItemNum { get; set; }

        public decimal? UnitVal { get; set; }

        public int Quantity { get; set; }

        public decimal? Weight { get; set; }

        public string Description { get; set; }

        public bool? IsOriginalFreightCharge { get; set; }

        public decimal? OriginalFreightCharge { get; set; }

        public bool? IsReturnFreightCharge { get; set; }

        public decimal? ReturnFreightCharge { get; set; }

        public bool? IsReplacementFreightCharge { get; set; }

        public decimal? ReplacementFreightCharge { get; set; }

        public decimal? SubTotalClaimVal { get; set; }
        public string ReturnDLSRefNum { get; set; }

        public string ReplaceDLSWRefNum { get; set; }

        public string Remarks { get; set; }

        public string CreatedBy { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ShipmentMode { get; set; }

        public string ActualDeliveryDate { get; set; }

        public string CarrierAck { get; set; }

        public string CarrierAckDate { get; set; }

        public string CarrierClaimNumber { get; set; }

        public string CarriePRODate { get; set; }

        public string ShipDate { get; set; }

        public string DeliveryDate { get; set; }

        public string DateAckToClaimant { get; set; }

        public string DateFiledWCarrier { get; set; }

        public string InsuranceClaimProgramId { get; set; }

        public string InsuranceClaimCompanyId { get; set; }

        public decimal? OriginalCarrierChargesToDLSWValue { get; set; }

        public decimal? OriginalDLSWChargesToCustomerValue { get; set; }

        public decimal? ReturnCarrierChargesToDLSWValue { get; set; }

        public decimal? ReturnDLSWChargesToCustomerValue { get; set; }


        public decimal? ReplacementCarrierChargesToDLSWValue { get; set; }

        public decimal? ReplacementDLSWChargesToCustomerValue { get; set; }

        public string Comments { get; set; }

        public List<InsuranceClaimItems> InsuranceclaimItem { get; set; }

        public string CustomerClaimReferenceNumber { get; set; }

    }
}