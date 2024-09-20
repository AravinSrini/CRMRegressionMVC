using CRM.UITest.Helper.Implementations;
using CRM.UITest.Helper.Interfaces;
using Unity;

namespace CRM.UITest.Dependency_resolution
{
    public class UnityConfiguration
    {
        public IUnityContainer Initialize()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType(typeof(IGetRateResultsandCarriers), typeof(GetRateResultsandCarriers));

            container.RegisterType(typeof(IGetEstChargesEstMargin), typeof(GetEstChargesEstMargin));
            container.RegisterType(typeof(IGetEstMargin), typeof(GetEstMargin));
            container.RegisterType(typeof(IConvertToTwoPlaceOfDecimal), typeof(ConvertToTwoPlaceOfDecimal));
            

            container.RegisterType(typeof(IAddCarrierLogoPath), typeof(AddCarrierLogoPath));
            container.RegisterType(typeof(ICreateLogoPathBasedOnScacCode), typeof(CreateLogoPathBasedOnScacCode));
            container.RegisterType(typeof(IGetPhysicalPath), typeof(GetPhysicalPath));//Need to check
            container.RegisterType(typeof(ICaptureTotalRateRequests), typeof(CaptureTotalRateRequests));
            container.RegisterType(typeof(IGetPhysicalPath), typeof(GetPhysicalPath));
            container.RegisterType(typeof(IGetPhysicalPath), typeof(GetPhysicalPath));
            container.RegisterType(typeof(IGetPhysicalPath), typeof(GetPhysicalPath));
            container.RegisterType(typeof(IGetPhysicalPath), typeof(GetPhysicalPath));
            container.RegisterType(typeof(IGetPhysicalPath), typeof(GetPhysicalPath));
            container.RegisterType(typeof(IGetPhysicalPath), typeof(GetPhysicalPath));
            container.RegisterType(typeof(IGetPhysicalPath), typeof(GetPhysicalPath));
            container.RegisterType(typeof(IGetPhysicalPath), typeof(GetPhysicalPath));
            container.RegisterType(typeof(IGetPhysicalPath), typeof(GetPhysicalPath));
            container.RegisterType(typeof(IGetPhysicalPath), typeof(GetPhysicalPath));
            container.RegisterType(typeof(IGetPhysicalPath), typeof(GetPhysicalPath));
            container.RegisterType(typeof(IGetPhysicalPath), typeof(GetPhysicalPath));
            container.RegisterType(typeof(IGetRateResultsandCarriers), typeof(GetRateResultsandCarriers));
            container.RegisterType(typeof(IAddCarrierLogoPath), typeof(AddCarrierLogoPath));
            container.RegisterType(typeof(ICreateLogoPathBasedOnScacCode), typeof(CreateLogoPathBasedOnScacCode));
            container.RegisterType(typeof(IGetPhysicalPath), typeof(GetPhysicalPath));//Need to check
            container.RegisterType(typeof(ICreateRateRequestXml), typeof(CreateRateRequestXml));
            container.RegisterType(typeof(IBuildConstrainsXElement), typeof(BuildConstrainsXelement));
            container.RegisterType(typeof(IServiceFlagsXelement), typeof(ServiceFlagsXelement));
            container.RegisterType(typeof(IServiceCodeNode), typeof(ServiceCodeNode));
            container.RegisterType(typeof(IBuildEquipmentsXelement), typeof(BuildEquipmentsXelement));
            container.RegisterType(typeof(IEquipmentsCodeNode), typeof(EquipmentsCodeNode));
            container.RegisterType(typeof(IBuildReferenceNumbersXElement), typeof(BuildReferenceNumbersXElement));
            container.RegisterType(typeof(IItemXElement), typeof(ItemXElement));
            container.RegisterType(typeof(IAddWeightinItemXElement), typeof(AddWeightinItemXElement));
            container.RegisterType(typeof(IAddQuantityinItemXElement), typeof(AddQuantityinItemXElement));
            container.RegisterType(typeof(IAddDimensioninItemXElement), typeof(AddDimensioninItemXElement));
            container.RegisterType(typeof(IHazardousMaterialXmlAgent), typeof(HazardousMaterialXmlAgent));
            container.RegisterType(typeof(IContactPhoneNodeHazardousXml), typeof(ContactPhoneNodeHazardousXml));
            container.RegisterType(typeof(IBuildHazardousMaterialXml), typeof(BuildHazardousMaterialXml));
            container.RegisterType(typeof(IBuildItemAttributes), typeof(BuildItemAttributes));
            container.RegisterType(typeof(IEventXElement), typeof(EventXElement));
            container.RegisterType(typeof(IDecrypt), typeof(Decrypt));
            container.RegisterType(typeof(IGetMaximumLiability), typeof(GetMaximumLiability));
            container.RegisterType(typeof(ICalculateMaximumLiabilityCoverage), typeof(CalculateMaximumLiabilityCoverage));
            container.RegisterType(typeof(IMaximumLiabilityRepository), typeof(MaximumLiabilityRepository));
            container.RegisterType(typeof(IGetTotalWeights), typeof(GetTotalWeights));
            container.RegisterType(typeof(IWeightUnitConvertor), typeof(WeightUnitConvertor));
            container.RegisterType(typeof(ICompareMaximumLiability), typeof(CompareMaximumLiability));
            container.RegisterType(typeof(ICheckDefaultInsAllFlag), typeof(CheckDefaultInsAllFlag));
            container.RegisterType(typeof(ICalculateInsAllForNonDefaultInsuredRates), typeof(CalculateInsAllForNonDefaultInsuredRates));
            container.RegisterType(typeof(ICalculateNumeratorForNonDefaultInsAllCal), typeof(CalculateNumeratorForNonDefaultInsAllCal));
            container.RegisterType(typeof(ICalculateInsAllCost), typeof(CalculateInsAllCost));
            container.RegisterType(typeof(ICalculateInsAllForDefaultInsuredRates), typeof(CalculateInsAllForDefaultInsuredRates));
            container.RegisterType(typeof(IGetCustomerInsuranceAllRiskByCustomerAccountId), typeof(GetCustomerInsuranceAllRiskByCustomerAccountId));
            container.RegisterType(typeof(IGetCustomerAccountId), typeof(GetCustomerAccountId));
            container.RegisterType(typeof(IGetInsAllRiskParameters), typeof(GetInsAllRiskParameters));
            container.RegisterType(typeof(ICheckDefaultInsAllFlag), typeof(CheckDefaultInsAllFlag));
            container.RegisterType(typeof(IGetShipementCoverageForDefaultInsAllRisk), typeof(GetShipementCoverageForDefaultInsAllRisk));
            container.RegisterType(typeof(IAddServiceDays), typeof(AddServiceDays));
            container.RegisterType(typeof(IAddAdditionalServiceDays), typeof(AddAdditionalServiceDays));
            container.RegisterType(typeof(IElementNullCheck), typeof(ElementNullCheck));
            container.RegisterType(typeof(IAssignAdditionalServiceDays), typeof(AssignAdditionalServiceDays));
            container.RegisterType(typeof(IRateCharges), typeof(RateCharges));
            container.RegisterType(typeof(IElementNullCheck), typeof(ElementNullCheck));
            container.RegisterType(typeof(IAccessorialCost), typeof(AccessorialCost));
            container.RegisterType(typeof(IFuelCost), typeof(FuelCost));
            container.RegisterType(typeof(ITransformRateCharge), typeof(TransformRateCharge));
            container.RegisterType(typeof(IReadElementWithNullCheck), typeof(ReadElementWithNullCheck));
            container.RegisterType(typeof(IAccessorialCosts), typeof(AccessorialCosts));
            container.RegisterType(typeof(IIncrementTotalRateRequestCount), typeof(IncrementTotalRateRequestCount));
            container.RegisterType(typeof(IFuelCosts), typeof(FuelCosts));
            container.RegisterType(typeof(IGetLiabilityCostPerPound), typeof(GetLiabilityCostPerPound));
            container.RegisterType(typeof(IInsertTotalRateRequestMetrics), typeof(InsertTotalRateRequestMetrics));
            container.RegisterType(typeof(IValidateSetupIdInQuoteMetrics), typeof(ValidateSetupIdInQuoteMetrics));
            container.RegisterType(typeof(IGetCustomerSetupId), typeof(GetCustomerSetupId));
            container.RegisterType(typeof(ILogErrorMessage), typeof(LogErrorMessage));
            container.RegisterType(typeof(IConvertPhysicalPathToUrlForCarrierLogo), typeof(ConvertPhysicalPathToUrlForCarrierLogo));
            container.RegisterType(typeof(IGetDefaultInsAllRiskDetails), typeof(GetDefaultInsAllRiskDetails));
            container.RegisterType(typeof(IBuildPickupDropEventXElement), typeof(BuildPickupDropEventXElement));
            container.RegisterType(typeof(IFuelPercentage), typeof(FuelPercentage));
            container.RegisterType(typeof(IAssignIsGuaranteedCarrierPriceToGuaranteedCarrierAgent), typeof(AssignIsGuaranteedCarrierPriceToGuaranteedCarrierAgent));
            container.RegisterType(typeof(IAssignIsGuaranteedCarrierPriceToGuaranteedCarrier), typeof(AssignIsGuaranteedCarrierPriceToGuaranteedCarrier));
            container.RegisterType(typeof(IDecodeToBase64), typeof(DecodeToBase64));
            container.RegisterType(typeof(ICheckForGuaranteedRateNodeInPriceSheet), typeof(CheckForGuaranteedRateNodeInPriceSheet));

            return container;
        }
    }
}
