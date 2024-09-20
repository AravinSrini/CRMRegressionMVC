using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Entities;

namespace CRM.UITest.Helper.Implementations
{
    public class RatesAndCarriers : IRatesAndCarriers
    {
        private readonly IGetRateResultsandCarriers _getRateResultsandCarriers;
        private readonly IAddCarrierLogoPath _addCarrierLogoPath;
        private readonly ICaptureTotalRateRequests _captureTotalRateRequests;
        private readonly ICreateRateRequestXml _createRateRequestXml;
        private readonly IGetMaximumLiability _getMaximumLiability;
        private static ICheckDefaultInsAllFlag _checkDefaultInsAllFlag;//need to implementation class
        private static ICalculateInsAllForNonDefaultInsuredRates _calculateInsAllForNonDefaultInsuredRates;
        private static ICalculateInsAllForDefaultInsuredRates _calculateInsAllForDefaultInsuredRates;
        private static IAddServiceDays _addServiceDays;
        private static IRateCharges _rateCharges;
        private static ITransformRateCharge _transformRateCharge;
        private static IGetLiabilityCostPerPound _getLiabilityCostPerPound;
        private static IGetEstChargesEstMargin _getEstChargesEstMargin;

        public RatesAndCarriers(IGetRateResultsandCarriers getRateResultsandCarriers, IAddServiceDays addServiceDays, IRateCharges rateCharges,
           IGetMaximumLiability getMaximumLiability, ICaptureTotalRateRequests captureTotalRateRequests, ICheckDefaultInsAllFlag checkDefaultInsAllFlag,
           ICalculateInsAllForNonDefaultInsuredRates calculateInsAllForNonDefaultInsuredRates, IAddCarrierLogoPath addCarrierLogoPath, ICalculateInsAllForDefaultInsuredRates calculateInsAllForDefaultInsuredRates,
           ICreateRateRequestXml createRateRequestXml, IGetLiabilityCostPerPound getLiabilityCostPerPound, IGetEstChargesEstMargin getEstChargesEstMargin, ITransformRateCharge transformRateCharge)
        {
            _getRateResultsandCarriers = getRateResultsandCarriers;
            _addServiceDays = addServiceDays;
            _rateCharges = rateCharges;
            _getMaximumLiability = getMaximumLiability;
            _captureTotalRateRequests = captureTotalRateRequests;
            _checkDefaultInsAllFlag = checkDefaultInsAllFlag;
            _calculateInsAllForNonDefaultInsuredRates = calculateInsAllForNonDefaultInsuredRates;
            _addCarrierLogoPath = addCarrierLogoPath;
            _calculateInsAllForDefaultInsuredRates = calculateInsAllForDefaultInsuredRates;
            _createRateRequestXml = createRateRequestXml;
            _getLiabilityCostPerPound = getLiabilityCostPerPound;
            _getEstChargesEstMargin = getEstChargesEstMargin;
            _transformRateCharge = transformRateCharge;
        }

        List<XElement> listPriceSheets = null;

        public IEnumerable<RateResultCarrierViewModel> GetCustomerRateResultsandCarriers(
           RateRequestViewModel rateRequest, string userEmail, bool callProxyApiVersion2,
           out string errorMessage)
        {
            IEnumerable<RateResultCarrierViewModel> carrierRates = null;
            errorMessage = string.Empty;

            // *** Call to CreateRateRequestXml method to build the RequestXml
            XElement rateRequestXml = CreateRateRequestXml(rateRequest);

            // *** Call to GetRateResultsandCarrier method from GetRateResultsandCarriers class
            XElement responseXml = _getRateResultsandCarriers.GetRateResultsandCarrier(rateRequestXml,
                rateRequest.RatingLevel, callProxyApiVersion2, out errorMessage, false);

            // *** Read the response XML,return view model on success & set error message on failure.
            // *** Get back only Customer Rates (type = "Cost") and do not return Carrier cost for External Customer 
            if (responseXml != null && !responseXml.IsEmpty)
            {
                carrierRates = BuildRateResultCarrierViewModel(responseXml, rateRequest.ShipmentValue, rateRequest.Constraints, rateRequest.Items, _getMaximumLiability, rateRequest.RatingLevel);
            }

            return carrierRates;
        }

        public IEnumerable<IndividualAccessorialModel> GetIndivudualAccessorials(
          RateRequestViewModel rateRequest, string userEmail, bool callProxyApiVersion2,
            out string errorMessage)
        {
            bool IsAcc = false;
            IEnumerable<RateResultCarrierViewModel> carrierRates = null;
            errorMessage = string.Empty;

            // *** Call to CreateRateRequestXml method to build the RequestXml
            XElement rateRequestXml = CreateRateRequestXml(rateRequest);

            // *** Call to GetRateResultsandCarrier method from GetRateResultsandCarriers class
            XElement responseXml = _getRateResultsandCarriers.GetRateResultsandCarrier(
                rateRequestXml, rateRequest.RatingLevel, callProxyApiVersion2, out errorMessage, false);

            //extracting accessorials
            listPriceSheets = responseXml.Element("PriceSheets").Elements("PriceSheet").ToList();

            List<IndividualAccessorialModel> individualAccessorials = new List<IndividualAccessorialModel>();

            for (int i = 0; i < listPriceSheets.Count(); i++)
            {
                string carrierScac = listPriceSheets[i].Elements("AssociatedCarrierPricesheet").Elements("PriceSheet").Elements("SCAC").FirstOrDefault().Value;
                string carrierName = listPriceSheets[i].Elements("AssociatedCarrierPricesheet").Elements("PriceSheet").Elements("CarrierName").FirstOrDefault().Value;
                string accTotal = listPriceSheets[i].Elements("AssociatedCarrierPricesheet").Elements("PriceSheet").Elements("AccessorialTotal").FirstOrDefault().Value;
                string totalLineHaul = listPriceSheets[i].Elements("AssociatedCarrierPricesheet").Elements("PriceSheet").Elements("SubTotal").FirstOrDefault().Value;
                string totalCost = listPriceSheets[i].Elements("AssociatedCarrierPricesheet").Elements("PriceSheet").Elements("Total").FirstOrDefault().Value;
                string minType = null;
                string fuelAmountValue = string.Empty;

                foreach (XElement charge in listPriceSheets[i].Elements("AssociatedCarrierPricesheet").Elements("PriceSheet").Elements("Charges").Elements("Charge"))
                {
                    if (charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL")
                        && charge.Element("Description").Value.ToUpper().Contains("FUEL") || charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL_FUEL"))
                    {
                        fuelAmountValue = charge.Elements("Amount").FirstOrDefault().Value;
                    }
                }

                foreach (XElement charge in listPriceSheets[i].Elements("AssociatedCarrierPricesheet").Elements("PriceSheet").Elements("Charges").Elements("Charge"))
                {
                    if (charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL")
                        || !charge.Element("Description").Value.ToUpper().Contains("FUEL") || charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL_FUEL") || charge.Attribute("type").Value.ToUpper().Contains("MG_MINMAX_ADJ"))
                    {
                        // string accessorialDescription = (_readXelementWithNullCheck.ReadElement(charge, "Description")).NodeValue?.Trim();
                        string accType = charge.Elements("Description").FirstOrDefault().Value;
                        string accAmount = string.Empty;

                        if (charge.Attribute("type").Value.ToUpper().Contains("MG_MINMAX_ADJ"))
                        {
                            minType = charge.Attribute("type").Value;
                        }

                        if (charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL_FUEL"))
                        {
                            accAmount = charge.Elements("Rate").FirstOrDefault().Value;
                        }
                        else
                        {
                            accAmount = charge.Elements("Amount").FirstOrDefault().Value;
                        }

                        IsAcc = charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL");
                        string carrierChargeType = charge.Attribute("type").Value;

                        IndividualAccessorialModel individualAccessorial = new IndividualAccessorialModel
                        {
                            discription = accType,
                            amount = accAmount,
                            carrierName = carrierName,
                            CarrierScac = carrierScac,
                            accessorialsTotal = Convert.ToString(Convert.ToDecimal(accTotal) - Convert.ToDecimal(fuelAmountValue)),
                            chargeType = carrierChargeType,
                            IsAccessorial = IsAcc,
                            TotalLineHaul = totalLineHaul,
                            TotalCost = totalCost,
                            FuelSurcharge = fuelAmountValue
                        };

                        individualAccessorials.Add(individualAccessorial);
                    }
                }
            }

            return individualAccessorials;
        }

        public XElement CreateRateRequestXml(RateRequestViewModel rateRequest)
        {
            XElement requestXML = _createRateRequestXml.CreateRateRequestsXml(rateRequest);
            return requestXML;
        }

        private static IEnumerable<RateResultCarrierViewModel> BuildRateResultCarrierViewModel(XElement responseXml, double shipmentValue, RateConstraintsModel constraints, List<RateItemModel> items, IGetMaximumLiability getMaximumLiability, string customerName)
        {
            List<RateResultCarrierViewModel> carriersandRates = new List<RateResultCarrierViewModel>();
            RateResultCarrierViewModel rateResultCarrierViewModel = null;
            bool isDefaultInsAll = false;
            decimal shipmentCoverageValue = 0;
            int count = 1;

            // *** Check if the Shipment Coverage is true and shipment value > 0.0
            // *** calculate the shipment coverage value and update the view model.
            if (shipmentValue > 0.0)
            {
                isDefaultInsAll = _checkDefaultInsAllFlag.DefaultInsuredRates(customerName);

                shipmentCoverageValue = (!isDefaultInsAll)
                    ? _calculateInsAllForNonDefaultInsuredRates.NonDefaultInsAllCalculation(shipmentValue)
                    : _calculateInsAllForDefaultInsuredRates.DefaultInsAllCalculation(shipmentValue, customerName);
            }

            // *** Get the Guaranteed Carrier List
            List<CarrierRateViewModel> carriers = new List<CarrierRateViewModel>();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                carriers = (from carrier in context.GuaranteedCarriers
                            where carrier.IsActive == true
                            select new CarrierRateViewModel

                            {
                                CarrierCode = carrier.CarrierCode,
                                CarrierName = carrier.CarrierName,
                                MarkupPercentage = carrier.Percentage,
                                MinAmountCharge = carrier.MinimumCharge,
                                ServiceDays = carrier.AdditionalServiceDays
                            }).ToList();
            }

            // *** Build the RateResultCarrierViewModel parsing the price sheets node
            XDocument ratesResponseXml = XDocument.Parse(responseXml.ToString());

            //Checking Customer is gainshare or not
            bool iSCrmRatingLogic_GainshareCustomer = DBHelper.CheckNewCrmRatingLogic(customerName);

            foreach (XElement priceSheetElement in
                ratesResponseXml.Elements("RateResults").Elements("PriceSheets").Elements("PriceSheet"))
            {
                // *** Get only Customer\Cost Charges 
                if (iSCrmRatingLogic_GainshareCustomer)// Getting only chargers based on rating level
                {
                    //Pricesheet = Charge 
                    if ((priceSheetElement != null && priceSheetElement.Element("AssociatedCarrierPricesheet").Element("PriceSheet").Attribute("type").Value.ToUpper().Contains("CHARGE")))
                    {
                        if ((!string.IsNullOrWhiteSpace(constraints?.Mode) && constraints.Mode.ToUpper().Equals("LTL") && priceSheetElement.Element("Mode").Value.ToUpper().StartsWith("LTL")) || (!string.IsNullOrWhiteSpace(constraints?.Mode) && constraints.Mode.ToUpper().Equals("PARCEL")))
                        {
                            if (priceSheetElement.Element("Service") != null && priceSheetElement.Element("Service").Value.ToUpper().Equals(constraints.Mode.ToUpper()))
                            {
                                rateResultCarrierViewModel = AddRateResultCarrierViewModel(priceSheetElement, shipmentCoverageValue, carriers, items, getMaximumLiability, isDefaultInsAll);
                                carriersandRates.Add(rateResultCarrierViewModel);
                            }
                            else
                            {
                                rateResultCarrierViewModel = AddRateResultCarrierViewModel(priceSheetElement, shipmentCoverageValue, carriers, items, getMaximumLiability, isDefaultInsAll);
                                carriersandRates.Add(rateResultCarrierViewModel);
                            }
                        }
                        else
                        {
                            constraints.Mode = (constraints.Mode?.ToUpper() == "TRUCKLOAD" || constraints.Mode?.ToUpper() == "INTERMODAL") ? "TL" : constraints.Mode;

                            if (constraints.Mode?.ToUpper() == "PARTIAL TRUCKLOAD")
                            {
                                constraints.Mode = "LTL";
                            }
                            if (priceSheetElement.Element("Mode") != null && priceSheetElement.Element("Mode").Value.ToUpper().Equals(constraints.Mode.ToUpper()))
                            {
                                rateResultCarrierViewModel = AddRateResultCarrierViewModel(priceSheetElement, shipmentCoverageValue, carriers, items, getMaximumLiability, isDefaultInsAll);
                                carriersandRates.Add(rateResultCarrierViewModel);
                            }
                        }
                    }
                }
                else
                {
                    if ((priceSheetElement != null && priceSheetElement.Attribute("type").Value.ToUpper().Contains("COST")))
                    {
                        if ((!string.IsNullOrWhiteSpace(constraints?.Mode) && constraints.Mode.ToUpper().Equals("LTL") && priceSheetElement.Element("Mode").Value.ToUpper().StartsWith("LTL")) || (!string.IsNullOrWhiteSpace(constraints?.Mode) && constraints.Mode.ToUpper().Equals("PARCEL")))
                        {
                            if (priceSheetElement.Element("Service") != null && priceSheetElement.Element("Service").Value.ToUpper().Equals(constraints.Mode.ToUpper()))
                            {
                                rateResultCarrierViewModel = AddRateResultCarrierViewModel(priceSheetElement, shipmentCoverageValue, carriers, items, getMaximumLiability, isDefaultInsAll);
                                carriersandRates.Add(rateResultCarrierViewModel);
                            }
                            else
                            {
                                rateResultCarrierViewModel = AddRateResultCarrierViewModel(priceSheetElement, shipmentCoverageValue, carriers, items, getMaximumLiability, isDefaultInsAll);
                                carriersandRates.Add(rateResultCarrierViewModel);
                            }
                        }
                        else
                        {
                            constraints.Mode = (constraints.Mode?.ToUpper() == "TRUCKLOAD" || constraints.Mode?.ToUpper() == "INTERMODAL") ? "TL" : constraints.Mode;

                            if (constraints.Mode?.ToUpper() == "PARTIAL TRUCKLOAD")
                            {
                                constraints.Mode = "LTL";
                            }
                            if (priceSheetElement.Element("Mode") != null && priceSheetElement.Element("Mode").Value.ToUpper().Equals(constraints.Mode.ToUpper()))
                            {
                                rateResultCarrierViewModel = AddRateResultCarrierViewModel(priceSheetElement, shipmentCoverageValue, carriers, items, getMaximumLiability, isDefaultInsAll);
                                carriersandRates.Add(rateResultCarrierViewModel);
                            }
                        }
                    }
                }
            }

            // *** Check the Carrier supports GuaranteedRate and add to the CarrierRates 
            List<RateResultCarrierViewModel> guaranteedCarriers;
            guaranteedCarriers = AddGuaranteedCarriers(carriersandRates, carriers, shipmentCoverageValue);

            if (guaranteedCarriers != null)
            {
                carriersandRates = carriersandRates.Concat(guaranteedCarriers).ToList();
            }

            // *** Sort Rates by Service Dates ascending & Charges descending 
            carriersandRates =
                carriersandRates.OrderBy(r => r.ServiceDays)
                    .ThenBy(r => r.Charges.FirstOrDefault().TotalCost)
                    .ToList();

            foreach (var carrier in carriersandRates)
            {
                carrier.CarrierId = count++;
            }

            return carriersandRates;
        }

        private static RateResultCarrierViewModel AddRateResultCarrierViewModel(XElement priceSheetElement, decimal shipmentCoverageValue, List<CarrierRateViewModel> carriers, List<RateItemModel> items, IGetMaximumLiability getMaximumLiability, bool isDefaultInsAll)
        {
            RateResultCarrierViewModel rateResultCarrierViewModel = null;
            rateResultCarrierViewModel = new RateResultCarrierViewModel();
            string nodeValue = null;

            rateResultCarrierViewModel.CarrierName = ReadElementWithNullCheck(
                priceSheetElement,
                "CarrierName",
                out nodeValue)
                ? nodeValue
                : null;

            rateResultCarrierViewModel.ScacCode = ReadElementWithNullCheck(
                priceSheetElement,
                "SCAC",
                out nodeValue)
                ? nodeValue
                : null;

            if (!string.IsNullOrWhiteSpace(rateResultCarrierViewModel.ScacCode))
            {
                rateResultCarrierViewModel = _addServiceDays.AddtionalServiceDays(priceSheetElement, rateResultCarrierViewModel);
            }
            else
            {
                double serviceDays = 0.0;
                rateResultCarrierViewModel.ServiceDays = ReadElementWithNullCheck(
                    priceSheetElement,
                    "ServiceDays",
                    out nodeValue)
                    ? double.TryParse(nodeValue, out serviceDays) ? serviceDays : 0
                    : 0;
            }

            double distance = 0.0;
            rateResultCarrierViewModel.Distance = ReadElementWithNullCheck(
                priceSheetElement,
                "Distance",
                out nodeValue)
                ? double.TryParse(nodeValue, out distance) ? distance : 0
                : 0;

            rateResultCarrierViewModel.ServiceLane = ReadElementWithNullCheck(
                priceSheetElement,
                "DestinationService",
                out nodeValue)
                ? (!string.IsNullOrWhiteSpace(nodeValue))
                    ? ((nodeValue == "D") ? "Direct To" : "Indirect To")
                    : "N/A"
                : "N/A";

            // *** Build the Charges taking shipment coverage into account
            rateResultCarrierViewModel.Charges = _rateCharges.TransformRateCharges(priceSheetElement);

            //Get estimated charges
            rateResultCarrierViewModel = _getEstChargesEstMargin.GetEstFields(priceSheetElement, rateResultCarrierViewModel);

            if (shipmentCoverageValue > 0)
            {
                rateResultCarrierViewModel.IsInsuredRates = true;
                rateResultCarrierViewModel.InsuredRateCharges = _transformRateCharge.TransformRateCharges(priceSheetElement, shipmentCoverageValue);

                // *** Call the AddShipmentCoverageCharges method to build the new charge xElement.
                XElement shipmentCharge = AddShipmentCoverageCharges(priceSheetElement, shipmentCoverageValue, isDefaultInsAll);
                priceSheetElement.Elements("Charges").FirstOrDefault().Add(shipmentCharge);

                // *** Update the accessorial total and total values
                priceSheetElement.SetElementValue(
                    "AccessorialTotal",
                    decimal.Parse(priceSheetElement.Element("AccessorialTotal").Value) + shipmentCoverageValue);

                priceSheetElement.SetElementValue(
                    "Total",
                    decimal.Parse(priceSheetElement.Element("Total").Value) + shipmentCoverageValue);
            }
            rateResultCarrierViewModel.Pricesheets = EncodePricesheet(priceSheetElement.ToString());
            rateResultCarrierViewModel.IsGuaranteedCarrier = false;

            if (carriers.Any(c => c.CarrierName.Equals(rateResultCarrierViewModel.CarrierName)))
            {
                rateResultCarrierViewModel.IsGuaranteedCarrier = true;
            }

            //Get MaximumLiability 
            rateResultCarrierViewModel = getMaximumLiability.ComputeMaximumLiability(rateResultCarrierViewModel, items);

            //Get CostPerPound
            rateResultCarrierViewModel = _getLiabilityCostPerPound.GetCostPerPound(rateResultCarrierViewModel);
            return rateResultCarrierViewModel;
        }

        private static List<RateResultCarrierViewModel> AddGuaranteedCarriers(List<RateResultCarrierViewModel> rateResultCarrierViewModel, List<CarrierRateViewModel> carriers, decimal shipmentCoverageValue)
        {
            double percentage = 0.0;
            double minCharge = 0.0;
            double additionalDays = 0;

            List<RateResultCarrierViewModel> guaranteedCarriersRates = new List<RateResultCarrierViewModel>();
            List<RateResultCarrierViewModel> guaranteedRate = null;
            List<CostComponents> guaranteedCharges = null;
            List<CostComponents> guaranteedInsuredCharges = null;
            IDecodeToBase64 decodeToBase64 = new DecodeToBase64();

            foreach (RateResultCarrierViewModel rateResult in rateResultCarrierViewModel)
            {
                if (carriers.Any(c => c.CarrierName.Equals(rateResult.CarrierName)))
                {
                    if (rateResult.InsuredRateCharges != null)
                    {
                        guaranteedInsuredCharges = new List<CostComponents>
                        {
                            new CostComponents()
                            {
                                Assessorial = rateResult.InsuredRateCharges[0].Assessorial,
                                FuelCost = rateResult.InsuredRateCharges[0].FuelCost,
                                LineHaul = rateResult.InsuredRateCharges[0].LineHaul,
                                TotalCost = rateResult.InsuredRateCharges[0].TotalCost
                            }
                        };
                    }

                    guaranteedCharges = new List<CostComponents>
                    {
                        new CostComponents()
                        {
                            Assessorial = rateResult.Charges[0].Assessorial,
                            FuelCost = rateResult.Charges[0].FuelCost,
                            LineHaul = rateResult.Charges[0].LineHaul,
                            TotalCost = rateResult.Charges[0].TotalCost
                        }
                    };

                    guaranteedRate = new List<RateResultCarrierViewModel>
                    {
                        new RateResultCarrierViewModel()
                        {
                            CarrierName = rateResult.CarrierName,
                            ScacCode = rateResult.ScacCode,
                            Charges = guaranteedCharges,
                            InsuredRateCharges = guaranteedInsuredCharges,
                            Distance = rateResult.Distance,
                            IsGuaranteedCarrier = rateResult.IsGuaranteedCarrier,
                            IsGuaranteedCarrierPrice = rateResult.IsGuaranteedCarrierPrice,
                            Pricesheets = rateResult.Pricesheets,
                            ServiceDays = rateResult.ServiceDays,
                            ServiceLane = rateResult.ServiceLane,
                            IsInsuredRates  = rateResult.IsInsuredRates,
                            MaximumLiabilityNew = rateResult.MaximumLiabilityNew,
                            MaximumLiabilityUsed = rateResult.MaximumLiabilityUsed,
                            NewCostPerPound=rateResult.NewCostPerPound,
                            UsedCostPerPound=rateResult.UsedCostPerPound
                        }
                    };

                    foreach (RateResultCarrierViewModel rate in guaranteedRate)
                    {
                        rate.IsGuaranteedCarrierPrice = true;

                        foreach (var guaranteedCarrier in carriers)
                        {
                            if (rate.CarrierName == guaranteedCarrier.CarrierName)
                            {
                                percentage = Convert.ToDouble(guaranteedCarrier.MarkupPercentage);
                                minCharge = Convert.ToDouble(guaranteedCarrier.MinAmountCharge);
                                additionalDays = Convert.ToDouble(guaranteedCarrier.ServiceDays);
                            }
                        }

                        rate.MarkupPercentage = percentage.ToString();
                        rate.MinAmountCharge = minCharge.ToString();
                        string priceSheet = decodeToBase64.DecodeBase64String(rate.Pricesheets);
                        XElement priceSheetElement = XElement.Parse(priceSheet);

                        rate.ServiceDays = rateResult.ServiceDays + additionalDays;

                        // *** Calculate the Guaranteed price amount for the standard rates                       
                        GetGuranteedStandardRates(rate, percentage, minCharge, priceSheetElement);

                        if (rate.InsuredRateCharges != null)
                        {
                            // *** Calculate the Guaranteed price amount for the insured rates
                            GetGuranteedInsuredRates(rate, percentage, minCharge, priceSheetElement, shipmentCoverageValue);
                        }

                        rate.Pricesheets = EncodePricesheet(priceSheetElement.ToString());
                    }

                    guaranteedCarriersRates = guaranteedCarriersRates.Concat(guaranteedRate).ToList();
                }
            }

            return guaranteedCarriersRates;
        }

        private static bool ReadElementWithNullCheck(XElement element, string nodeName, out string value)
        {
            bool isNodeExist = true;
            value = null;

            try
            {
                // *** read the specified node value from XElement.if node is empty 
                // *** return's false or return's the node value.
                XElement eleNode = element.Element(nodeName);

                if (!string.IsNullOrEmpty(Convert.ToString(eleNode)))
                {
                    if (eleNode != null)
                    {
                        value = eleNode.Value;
                    }
                }
                else
                {
                    isNodeExist = false;
                }
            }
            catch (Exception)
            {
                isNodeExist = false;
                value = null;
            }

            return isNodeExist;
        }

        private static XElement AddShipmentCoverageCharges(XElement priceSheetElement, decimal shipmentCoverageValue, bool isDefaultInsAll)
        {
            // *** 
            // *** Read the Last Charge sequence number and increment 1.
            // ***
            int chargesCount = priceSheetElement.Elements("Charges").Elements("Charge").Count() + 1;

            // Build new charge XElement for shipment value.
            XElement charge = new XElement(
                "Charge",
                new XAttribute("sequenceNum", chargesCount),
                new XAttribute("type", "ACCESSORIAL"),
                new XAttribute("itemGroupId", string.Empty),
                isDefaultInsAll ? new XElement("Description", "All Risk") : new XElement("Description", "Product Protection"),
                isDefaultInsAll ? new XElement("EdiCode", "ARK") : new XElement("EdiCode", "PPP"),
            new XElement("Amount", shipmentCoverageValue),
                new XElement("Rate", shipmentCoverageValue),
                new XElement("RateQualifier", "FR"),
                new XElement("Quantity", string.Empty),
                new XElement("Weight", "0.0"),
                new XElement("DimWeight", "0.0"),
                new XElement("FreightClass", "0.0"),
                new XElement("FakFreightClass", "0.0"),
                new XElement("IsMin", false),
                new XElement("IsMax", false),
                new XElement("IsNontaxable", false));

            return charge;
        }

        private static string EncodePricesheet(string pricesheet)
        {
            string returnValue = string.Empty;

            if (!string.IsNullOrWhiteSpace(pricesheet))
            {
                // ***
                // *** Encoding for the UTF-8 format and converting to base 64 string format.
                // ***
                byte[] encodedPricesheet = Encoding.UTF8.GetBytes(pricesheet);

                returnValue = Convert.ToBase64String(encodedPricesheet);
            }

            return returnValue;
        }

        private static void GetGuranteedStandardRates(RateResultCarrierViewModel insuredRateCharges, double percentage, double minCharge, XElement priceSheetElement)
        {
            foreach (var rates in insuredRateCharges.Charges)
            {
                double guaranteeRate = (percentage / 100) * Convert.ToDouble(rates.TotalCost);
                guaranteeRate = guaranteeRate >= minCharge ? guaranteeRate : minCharge;
                decimal totalGuaranteeRate = Math.Round(Convert.ToDecimal(guaranteeRate), 2);
                rates.TotalCost = rates.TotalCost + totalGuaranteeRate;
                rates.Assessorial = Convert.ToDecimal(rates.Assessorial + totalGuaranteeRate);

                // ***
                // *** Update the accessorial total and total values
                // ***
                if (!insuredRateCharges.IsInsuredRates)
                {
                    priceSheetElement.SetElementValue(
                        "AccessorialTotal",
                        rates.Assessorial + rates.FuelCost);
                    priceSheetElement.SetElementValue(
                        "Total",
                        rates.TotalCost);

                    priceSheetElement.SetElementValue(
                        "ServiceDays",
                        insuredRateCharges.ServiceDays);

                    priceSheetElement.SetElementValue(
                       "Distance",
                       insuredRateCharges.Distance);

                    int sequenceNumber = 1;
                    foreach (XElement ele in priceSheetElement.Elements("Charges").Elements("Charge"))
                    {
                        sequenceNumber++;
                    }

                    priceSheetElement.Element("Charges").Add(CreateGuaranteedRateChargeNode(guaranteeRate, sequenceNumber));
                }
            }
        }

        private static void GetGuranteedInsuredRates(RateResultCarrierViewModel insuredRateCharges, double percentage, double minCharge, XElement priceSheetElement, decimal shipmentCoverageValue)
        {
            for (int i = 0; i < insuredRateCharges.Charges.Count(); i++)
            {
                double guaranteeRate = (percentage / 100) * Convert.ToDouble((insuredRateCharges.Charges[i].TotalCost - insuredRateCharges.Charges[i].Assessorial));
                //guaranteeRate = guaranteeRate + Convert.ToDouble(shipmentCoverageValue);
                guaranteeRate = guaranteeRate >= minCharge ? guaranteeRate : minCharge;
                decimal totalGuaranteeRate = Math.Round(Convert.ToDecimal(guaranteeRate), 2);
                insuredRateCharges.InsuredRateCharges[i].TotalCost = insuredRateCharges.Charges[i].TotalCost + shipmentCoverageValue;
                insuredRateCharges.InsuredRateCharges[i].Assessorial = Convert.ToDecimal(insuredRateCharges.Charges[i].Assessorial + shipmentCoverageValue);

                // ***
                // *** Update the accessorial total and total values
                // ***
                priceSheetElement.SetElementValue(
                    "AccessorialTotal",
                     insuredRateCharges.InsuredRateCharges[i].Assessorial + insuredRateCharges.InsuredRateCharges[i].FuelCost);
                priceSheetElement.SetElementValue(
                    "Total",
                     insuredRateCharges.InsuredRateCharges[i].TotalCost);

                priceSheetElement.SetElementValue(
                    "ServiceDays",
                    insuredRateCharges.ServiceDays);

                priceSheetElement.SetElementValue(
                   "Distance",
                   insuredRateCharges.Distance);

                int sequenceNumber = 1;
                foreach (XElement ele in priceSheetElement.Elements("Charges").Elements("Charge"))
                {
                    sequenceNumber++;
                }

                priceSheetElement.Element("Charges").Add(CreateGuaranteedRateChargeNode(guaranteeRate, sequenceNumber));
            }
        }

        private static XElement CreateGuaranteedRateChargeNode(double guaranteeRate, int sequenceNumber)
        {
            return new XElement("Charge", new XAttribute("sequenceNum", sequenceNumber), new XAttribute("type", "ACCESSORIAL"),
                                            new XAttribute("itemGroupId", ""), new XElement("Description", "Guaranteed Rate"), new XElement("EdiCode", "GDEL"),
                                            new XElement("Amount", Convert.ToDecimal(guaranteeRate)), new XElement("Rate", Convert.ToDecimal(guaranteeRate)),
                                            new XElement("RateQualifier", "FR"), new XElement("Quantity"), new XElement("Weight", "0.0"), new XElement("DimWeight", "0.0"),
                                            new XElement("FreightClass", "0.0"), new XElement("FakFreightClass", "0.0"), new XElement("IsMin", false),
                                            new XElement("IsMax", false), new XElement("IsNontaxable", false));
        }

        public IEnumerable<IndividualAccessorialModel> GetIndivudualAccessorialsCostPricesheet(
          RateRequestViewModel rateRequest, string userEmail, bool callProxyApiVersion2,
            out string errorMessage)
        {
            bool IsAcc = false;
            IEnumerable<RateResultCarrierViewModel> carrierRates = null;
            errorMessage = string.Empty;

            // *** Call to CreateRateRequestXml method to build the RequestXml
            XElement rateRequestXml = CreateRateRequestXml(rateRequest);

            // *** Call to GetRateResultsandCarrier method from GetRateResultsandCarriers class
            XElement responseXml = _getRateResultsandCarriers.GetRateResultsandCarrier(
                rateRequestXml, rateRequest.RatingLevel, callProxyApiVersion2, out errorMessage, false);

            //extracting accessorials
            listPriceSheets = responseXml.Element("PriceSheets").Elements("PriceSheet").ToList();

            List<IndividualAccessorialModel> individualAccessorials = new List<IndividualAccessorialModel>();

            for (int i = 0; i < listPriceSheets.Count(); i++)
            {
                string carrierScac = listPriceSheets[i].Elements("SCAC").First().Value;
                string carrierName = listPriceSheets[i].Elements("CarrierName").First().Value;
                string accTotal = listPriceSheets[i].Elements("AccessorialTotal").First().Value;
                string totalLineHaul = listPriceSheets[i].Elements("SubTotal").First().Value;
                string totalCost = listPriceSheets[i].Elements("Total").First().Value;
                string minType = null;
                string fuelAmountValue = string.Empty;

                foreach (XElement charge in listPriceSheets[i].Elements("Charges").Elements("Charge"))
                {
                    if (charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL")
                        && charge.Element("Description").Value.ToUpper().Contains("FUEL") || charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL_FUEL"))
                    {
                        fuelAmountValue = charge.Elements("Amount").FirstOrDefault().Value;
                    }
                }

                foreach (XElement charge in listPriceSheets[i].Elements("Charges").Elements("Charge"))
                {
                    if (charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL")
                        && !charge.Element("Description").Value.ToUpper().Contains("FUEL") || charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL_FUEL") || charge.Attribute("type").Value.ToUpper().Contains("MG_MINMAX_ADJ"))
                    {
                        string accType = charge.Elements("Description").FirstOrDefault().Value;
                        string accAmount = string.Empty;

                        if (charge.Attribute("type").Value.ToUpper().Contains("MG_MINMAX_ADJ"))
                        {
                            minType = charge.Attribute("type").Value;
                        }

                        if (charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL_FUEL"))
                        {
                            accAmount = charge.Elements("Rate").FirstOrDefault().Value;
                        }
                        else
                        {
                            accAmount = charge.Elements("Amount").FirstOrDefault().Value;
                        }

                        IsAcc = charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL");
                        string carrierChargeType = charge.Attribute("type").Value;
                        var accCode = DBHelper.AccessorialNameToCodeUsingMgDescription(accType);
                        IndividualAccessorialModel individualAccessorial = new IndividualAccessorialModel
                        {
                            discription = accType,
                            amount = accAmount,
                            carrierName = carrierName,
                            CarrierScac = carrierScac,
                            accessorialsTotal = Convert.ToString(Convert.ToDecimal(accTotal) - Convert.ToDecimal(fuelAmountValue)),
                            chargeType = carrierChargeType,
                            IsAccessorial = IsAcc,
                            TotalLineHaul = totalLineHaul,
                            TotalCost = totalCost,
                            AccessorialCode = accCode != null? accCode.AccessorialCode: null

                        };                   

                        individualAccessorials.Add(individualAccessorial);
                    }
                }
            }

            return individualAccessorials;
        }
    }
}
