﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM.UITest.Entities.Proxy
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WWProxyEntities : DbContext
    {
        public WWProxyEntities()
            : base("name=WWProxyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CarrierAddtionalServiceDay> CarrierAddtionalServiceDays { get; set; }
        public virtual DbSet<CodeTable> CodeTables { get; set; }
        public virtual DbSet<CommissionExtractUploadedFile> CommissionExtractUploadedFiles { get; set; }
        public virtual DbSet<DefaultInsSetting> DefaultInsSettings { get; set; }
        public virtual DbSet<GuaranteedCarrier> GuaranteedCarriers { get; set; }
        public virtual DbSet<InsuranceAllRiskUploadedFile> InsuranceAllRiskUploadedFiles { get; set; }
        public virtual DbSet<InsuredRateCarrier> InsuredRateCarriers { get; set; }
        public virtual DbSet<MetricsHistoryTable> MetricsHistoryTables { get; set; }
        public virtual DbSet<MetricsTransactionTable> MetricsTransactionTables { get; set; }
        public virtual DbSet<MgDocument> MgDocuments { get; set; }
        public virtual DbSet<ParcelServiceEnabledUser> ParcelServiceEnabledUsers { get; set; }
        public virtual DbSet<RatingApiExceptionUser> RatingApiExceptionUsers { get; set; }
        public virtual DbSet<ShipmentService> ShipmentServices { get; set; }
        public virtual DbSet<ShipmentStatu> ShipmentStatus { get; set; }
        public virtual DbSet<ActivityLog> ActivityLogs { get; set; }
        public virtual DbSet<ApprovalTeamDefaultEmail> ApprovalTeamDefaultEmails { get; set; }
        public virtual DbSet<CarrierDetail> CarrierDetails { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<CorporateBillingReferenceNumber> CorporateBillingReferenceNumbers { get; set; }
        public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public virtual DbSet<CustomerAccountMapping> CustomerAccountMappings { get; set; }
        public virtual DbSet<CustomerServiceSpecificEmail> CustomerServiceSpecificEmails { get; set; }
        public virtual DbSet<CustomerSpecificReference> CustomerSpecificReferences { get; set; }
        public virtual DbSet<CustomerSpecificReferenceValue> CustomerSpecificReferenceValues { get; set; }
        public virtual DbSet<Fak> Faks { get; set; }
        public virtual DbSet<GainsharePricingModel> GainsharePricingModels { get; set; }
        public virtual DbSet<GainShareScacCode> GainShareScacCodes { get; set; }
        public virtual DbSet<InvoicePreference> InvoicePreferences { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationAndContactType> LocationAndContactTypes { get; set; }
        public virtual DbSet<PoManagement> PoManagements { get; set; }
        public virtual DbSet<PricingModel> PricingModels { get; set; }
        public virtual DbSet<PricingType> PricingTypes { get; set; }
        public virtual DbSet<ReferenceType> ReferenceTypes { get; set; }
        public virtual DbSet<ReferenceTypeValue> ReferenceTypeValues { get; set; }
        public virtual DbSet<TariffPricingModel> TariffPricingModels { get; set; }
        public virtual DbSet<UserCustomerAccountMapping> UserCustomerAccountMappings { get; set; }
        public virtual DbSet<CsrActivityLog> CsrActivityLogs { get; set; }
        public virtual DbSet<CsrAddress> CsrAddresses { get; set; }
        public virtual DbSet<CsrContact> CsrContacts { get; set; }
        public virtual DbSet<CsrCorporateBillingReferenceNumber> CsrCorporateBillingReferenceNumbers { get; set; }
        public virtual DbSet<CsrCustomerAccountMapping> CsrCustomerAccountMappings { get; set; }
        public virtual DbSet<CsrCustomerServiceSpecificEmail> CsrCustomerServiceSpecificEmails { get; set; }
        public virtual DbSet<CsrFak> CsrFaks { get; set; }
        public virtual DbSet<CsrGainsharePricingModel> CsrGainsharePricingModels { get; set; }
        public virtual DbSet<CsrGainShareScacCode> CsrGainShareScacCodes { get; set; }
        public virtual DbSet<CsrInvoicePreference> CsrInvoicePreferences { get; set; }
        public virtual DbSet<CsrItem> CsrItems { get; set; }
        public virtual DbSet<CsrLocation> CsrLocations { get; set; }
        public virtual DbSet<CsrLocationAndContactType> CsrLocationAndContactTypes { get; set; }
        public virtual DbSet<CsrPricingModel> CsrPricingModels { get; set; }
        public virtual DbSet<CsrPricingType> CsrPricingTypes { get; set; }
        public virtual DbSet<CsrSetup> CsrSetups { get; set; }
        public virtual DbSet<CsrStationCustomerAccountMapping> CsrStationCustomerAccountMappings { get; set; }
        public virtual DbSet<CsrStatu> CsrStatus { get; set; }
        public virtual DbSet<CsrTariffPricingModel> CsrTariffPricingModels { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ApiEndPoint> ApiEndPoints { get; set; }
        public virtual DbSet<CustomerApiKey> CustomerApiKeys { get; set; }
        public virtual DbSet<CustomerEmail> CustomerEmails { get; set; }
        public virtual DbSet<CustomerEndPointMapping> CustomerEndPointMappings { get; set; }
        public virtual DbSet<CustomerRateOptionsMapping> CustomerRateOptionsMappings { get; set; }
        public virtual DbSet<CustomerSetup> CustomerSetups { get; set; }
        public virtual DbSet<RateOption> RateOptions { get; set; }
        public virtual DbSet<TrackingDetail> TrackingDetails { get; set; }
        public virtual DbSet<CustomReport> CustomReports { get; set; }
        public virtual DbSet<CustomReportServicesMapping> CustomReportServicesMappings { get; set; }
        public virtual DbSet<CustomReportStatusMapping> CustomReportStatusMappings { get; set; }
        public virtual DbSet<UserCustomReportsMapping> UserCustomReportsMappings { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<QuoteReferenceNumber> QuoteReferenceNumbers { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentRolesMapping> DocumentRolesMappings { get; set; }
        public virtual DbSet<Folder> Folders { get; set; }
        public virtual DbSet<ReferenceMapping> ReferenceMappings { get; set; }
        public virtual DbSet<Privilege> Privileges { get; set; }
        public virtual DbSet<SecurityGroup> SecurityGroups { get; set; }
        public virtual DbSet<SecurityGroupPrivilegeRelationship> SecurityGroupPrivilegeRelationships { get; set; }
        public virtual DbSet<CustomerSpecificBranding> CustomerSpecificBrandings { get; set; }
        public virtual DbSet<AccessorialSetUp> AccessorialSetUps { get; set; }
        public virtual DbSet<BumpSurgeCustomerSetUp> BumpSurgeCustomerSetUps { get; set; }
        public virtual DbSet<BumpSurgeStationSetUp> BumpSurgeStationSetUps { get; set; }
        public virtual DbSet<CarrierWebsite> CarrierWebsites { get; set; }
        public virtual DbSet<ExternalServiceErrorDetail> ExternalServiceErrorDetails { get; set; }
        public virtual DbSet<ExternalService> ExternalServices { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<StationSalesCode> StationSalesCodes { get; set; }
        public virtual DbSet<UserAutoLogin> UserAutoLogins { get; set; }
        public virtual DbSet<AccessorialCarrierSetUp> AccessorialCarrierSetUps { get; set; }
        public virtual DbSet<AccessorialCustomerSetUp> AccessorialCustomerSetUps { get; set; }
        public virtual DbSet<CsrAccessorialCarrierSetUp> CsrAccessorialCarrierSetUps { get; set; }
        public virtual DbSet<CsrAccessorialCustomerSetUp> CsrAccessorialCustomerSetUps { get; set; }
        public virtual DbSet<RmApprovalStatu> RmApprovalStatus { get; set; }
        public virtual DbSet<ImageNowSetUp> ImageNowSetUps { get; set; }
        public virtual DbSet<captured_columns> captured_columns { get; set; }
        public virtual DbSet<change_tables> change_tables { get; set; }
        public virtual DbSet<ddl_history> ddl_history { get; set; }
        public virtual DbSet<index_columns> index_columns { get; set; }
        public virtual DbSet<lsn_time_mapping> lsn_time_mapping { get; set; }
        public virtual DbSet<Common_BumpSurgeCustomerSetUp_CT> Common_BumpSurgeCustomerSetUp_CT { get; set; }
        public virtual DbSet<Common_BumpSurgeStationSetUp_CT> Common_BumpSurgeStationSetUp_CT { get; set; }
        public virtual DbSet<Csr_AccessorialCarrierSetUp_CT> Csr_AccessorialCarrierSetUp_CT { get; set; }
        public virtual DbSet<Csr_AccessorialCustomerSetUp_CT> Csr_AccessorialCustomerSetUp_CT { get; set; }
        public virtual DbSet<Csr_CarrierDetails_CT> Csr_CarrierDetails_CT { get; set; }
        public virtual DbSet<Csr_CustomerAccount_CT> Csr_CustomerAccount_CT { get; set; }
        public virtual DbSet<Csr_Fak_CT> Csr_Fak_CT { get; set; }
        public virtual DbSet<Csr_GainsharePricingModel_CT> Csr_GainsharePricingModel_CT { get; set; }
        public virtual DbSet<Csr_GainShareScacCode_CT> Csr_GainShareScacCode_CT { get; set; }
        public virtual DbSet<Csr_PricingModel_CT> Csr_PricingModel_CT { get; set; }
        public virtual DbSet<Csr_TariffPricingModel_CT> Csr_TariffPricingModel_CT { get; set; }
        public virtual DbSet<CsrStage_CsrCustomerAccount_CT> CsrStage_CsrCustomerAccount_CT { get; set; }
        public virtual DbSet<CsrStage_CsrFak_CT> CsrStage_CsrFak_CT { get; set; }
        public virtual DbSet<CsrStage_CsrGainsharePricingModel_CT> CsrStage_CsrGainsharePricingModel_CT { get; set; }
        public virtual DbSet<CsrStage_CsrPricingModel_CT> CsrStage_CsrPricingModel_CT { get; set; }
        public virtual DbSet<CsrStage_CsrTariffPricingModel_CT> CsrStage_CsrTariffPricingModel_CT { get; set; }
        public virtual DbSet<Proxy_CustomerSetUp_CT> Proxy_CustomerSetUp_CT { get; set; }
        public virtual DbSet<IntegrationRequestComment> IntegrationRequestComments { get; set; }
        public virtual DbSet<IntegrationRequestTypeMapping> IntegrationRequestTypeMappings { get; set; }
        public virtual DbSet<IntegrationStage> IntegrationStages { get; set; }
        public virtual DbSet<IntegrationStatu> IntegrationStatus { get; set; }
        public virtual DbSet<IntegrationType> IntegrationTypes { get; set; }
        public virtual DbSet<AllStationsBumpSurgeSetup> AllStationsBumpSurgeSetups { get; set; }
        public virtual DbSet<DefaultAccessorialSetup> DefaultAccessorialSetups { get; set; }
        public virtual DbSet<CustomerCredit> CustomerCredits { get; set; }
        public virtual DbSet<CustomerInvoice> CustomerInvoices { get; set; }
        public virtual DbSet<systranschema> systranschemas { get; set; }
        public virtual DbSet<InsuranceClaim> InsuranceClaims { get; set; }
        public virtual DbSet<InsuranceClaimArticleType> InsuranceClaimArticleTypes { get; set; }
        public virtual DbSet<InsuranceClaimCarrier> InsuranceClaimCarriers { get; set; }
        public virtual DbSet<InsuranceClaimFreight> InsuranceClaimFreights { get; set; }
        public virtual DbSet<InsuranceClaimItem> InsuranceClaimItems { get; set; }
        public virtual DbSet<InsuranceClaimStatu> InsuranceClaimStatus { get; set; }
        public virtual DbSet<InsuranceClaimType> InsuranceClaimTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<InsuranceClaimConsigneeAddress> InsuranceClaimConsigneeAddresses { get; set; }
        public virtual DbSet<InsuranceClaimPayableTo> InsuranceClaimPayableToes { get; set; }
        public virtual DbSet<InsuranceClaimShipperAddress> InsuranceClaimShipperAddresses { get; set; }
        public virtual DbSet<Batch> Batches { get; set; }
        public virtual DbSet<ApplicationConfiguration> ApplicationConfigurations { get; set; }
        public virtual DbSet<CustomReportCustomerMapping> CustomReportCustomerMappings { get; set; }
        public virtual DbSet<CustomReportStationMapping> CustomReportStationMappings { get; set; }
        public virtual DbSet<InvoiceCustomReport> InvoiceCustomReports { get; set; }
        public virtual DbSet<InvoiceRangeType> InvoiceRangeTypes { get; set; }
        public virtual DbSet<InvoiceType> InvoiceTypes { get; set; }
        public virtual DbSet<MonthlyScheduledReport> MonthlyScheduledReports { get; set; }
        public virtual DbSet<ReportFrequency> ReportFrequencies { get; set; }
        public virtual DbSet<ScheduledReport> ScheduledReports { get; set; }
        public virtual DbSet<WeeklyScheduledReport> WeeklyScheduledReports { get; set; }
        public virtual DbSet<InsuranceClaimReasonCode> InsuranceClaimReasonCodes { get; set; }
        public virtual DbSet<InsuranceClaimRep> InsuranceClaimReps { get; set; }
        public virtual DbSet<AccessType> AccessTypes { get; set; }
        public virtual DbSet<IntegrationUser> IntegrationUsers { get; set; }
        public virtual DbSet<IntegrationUserAccessMapping> IntegrationUserAccessMappings { get; set; }
        public virtual DbSet<InsuranceCarrierOsdAction> InsuranceCarrierOsdActions { get; set; }
        public virtual DbSet<InsuranceClaimCompany> InsuranceClaimCompanies { get; set; }
        public virtual DbSet<InsuranceClaimProgram> InsuranceClaimPrograms { get; set; }
        public virtual DbSet<InsuranceDlswOsdAction> InsuranceDlswOsdActions { get; set; }
        public virtual DbSet<InusranceFtlMode> InusranceFtlModes { get; set; }
        public virtual DbSet<InsuranceCarrierList> InsuranceCarrierLists { get; set; }
        public virtual DbSet<InsuranceForwardingMode> InsuranceForwardingModes { get; set; }
        public virtual DbSet<Cookie> Cookies { get; set; }
        public virtual DbSet<CookieCategory> CookieCategories { get; set; }
        public virtual DbSet<PartType> PartTypes { get; set; }
        public virtual DbSet<CsrCustomerAccount> CsrCustomerAccounts { get; set; }
        public virtual DbSet<IntegrationRequest> IntegrationRequests { get; set; }
        public virtual DbSet<CustomerDocumentDirectoryUrlMapping> CustomerDocumentDirectoryUrlMappings { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<InsuranceClaimCarrierCopy> InsuranceClaimCarrierCopies { get; set; }
        public virtual DbSet<InsuranceClaimConsigneeAddressCopy> InsuranceClaimConsigneeAddressCopies { get; set; }
        public virtual DbSet<InsuranceClaimCopy> InsuranceClaimCopies { get; set; }
        public virtual DbSet<InsuranceClaimFreightCopy> InsuranceClaimFreightCopies { get; set; }
        public virtual DbSet<InsuranceClaimHistory> InsuranceClaimHistories { get; set; }
        public virtual DbSet<InsuranceClaimItemsCopy> InsuranceClaimItemsCopies { get; set; }
        public virtual DbSet<InsuranceClaimPayableToCopy> InsuranceClaimPayableToCopies { get; set; }
        public virtual DbSet<InsuranceClaimPayment> InsuranceClaimPayments { get; set; }
        public virtual DbSet<InsuranceClaimPaymentType> InsuranceClaimPaymentTypes { get; set; }
        public virtual DbSet<InsuranceClaimShipperAddressCopy> InsuranceClaimShipperAddressCopies { get; set; }
        public virtual DbSet<InsuranceClaimStatusCode> InsuranceClaimStatusCodes { get; set; }
        public virtual DbSet<AccessorialDirection> AccessorialDirections { get; set; }
        public virtual DbSet<AccessorialMGDescription> AccessorialMGDescriptions { get; set; }
        public virtual DbSet<AccessorialServiceTypeMapping> AccessorialServiceTypeMappings { get; set; }
        public virtual DbSet<CarrierAndAccessorialThresholdMapping> CarrierAndAccessorialThresholdMappings { get; set; }
        public virtual DbSet<CustomerShippingReference> CustomerShippingReferences { get; set; }
        public virtual DbSet<DagrtNumberLookup> DagrtNumberLookups { get; set; }
        public virtual DbSet<GainshareCostingType> GainshareCostingTypes { get; set; }
        public virtual DbSet<CreditHoldHistory> CreditHoldHistories { get; set; }
        public virtual DbSet<CustomerRatingLogicAudit> CustomerRatingLogicAudits { get; set; }
    }
}
