using System;
using System.Xml.Linq;


namespace CRM.UITest.Helper.Implementations.QuoteList
{
    public class CreateLTLQuote
    {
        public XElement CreateQuoteXml(string quoteNumber, string pickupdate, string customerName)
        {
            XElement requestXml = new XElement("service-request",
                                    new XElement("service-id", "ImportWeb"),
                                    new XElement("request-id", "123456789"),
                                    new XElement("data",
                                        new XElement("WebImport",
                                            new XElement("WebImportHeader",
                                                new XElement("FileName", "QuoteImport"),
                                                new XElement("Type", "WebShXML4")
                                            ),
                                            new XElement("WebImportFile",
                                                new XElement("MercuryGate",
                                                    new XElement("Header",
                                                        new XElement("SenderID"),
                                                        new XElement("ReceiverID"),
                                                        new XElement("Action", "Add"),
                                                        new XElement("DocCount", "1"),
                                                        new XElement("DocTypeID", "Shipment"),
                                                        new XElement("Date", new XAttribute("type", "generation"), DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm"))
                                                    ),
                                                    new XElement("Shipment", new XAttribute("type", "LTL"), new XAttribute("action", "UpdateOrAdd"),
                                                        new XElement("Status", "Pending"),
                                                        new XElement("Enterprise", new XAttribute("name", customerName)),
                                                        new XElement("ReferenceNumbers",
                                                            new XElement("ReferenceNumber", new XAttribute("type", "SCAC"), new XAttribute("isPrimary", "false"), "FWDA"),
                                                            new XElement("ReferenceNumber", new XAttribute("type", "QuoteNumber"), new XAttribute("isPrimary", "true"), quoteNumber),
                                                            new XElement("ReferenceNumber", new XAttribute("type", "SubmittedBy"), new XAttribute("isPrimary", "false"), "ZZZ Test")
                                                        ),
                                                        new XElement("ServiceList"),
                                                        new XElement("EquipmentList"),
                                                        new XElement("Comments",
                                                            new XElement("Comment", new XAttribute("type", "SpecialInstructions"))
                                                        ),
                                                        new XElement("Dates",
                                                            new XElement("Pickup",
                                                                new XElement("Date", new XAttribute("type", "earliest"), pickupdate),
                                                                new XElement("Date", new XAttribute("type", "latest"), pickupdate)
                                                            ),
                                                            new XElement("Drop",
                                                                new XElement("Date", new XAttribute("type", "earliest"), DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm")),
                                                                new XElement("Date", new XAttribute("type", "latest"), DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm"))
                                                            )
                                                        ),
                                                        new XElement("PriceSheets",
                                                            new XElement("PriceSheet", new XAttribute("type", "Customer"), new XAttribute("chargeModel", "NORMALIZED_SMC"), new XAttribute("isSelected", "true"), new XAttribute("isAllocated", "false"), new XAttribute("currencyCode", "USD"), new XAttribute("createDate", DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm")), new XAttribute("internalId", ""),
                                                                new XElement("AccessorialTotal", "52.309181481481481481481481482"),
                                                                new XElement("SubTotal", "243.29851851851851851851851852"),
                                                                new XElement("Total", "295.60770000000000000000000000"),
                                                                new XElement("SCAC", "FWDA"),
                                                                new XElement("Mode", "LTL"),
                                                                new XElement("Service", "LTL"),
                                                                new XElement("ServiceDays", "1.0"),
                                                                new XElement("Distance", "0"),
                                                                new XElement("Id", "1211821"),
                                                                new XElement("InsuranceTypes",
                                                                    new XElement("Insurance", new XAttribute("type", "Cargo"), new XAttribute("amount", "0.00"), new XAttribute("company", ""), new XAttribute("expirationDate", ""), new XAttribute("contactName", ""), new XAttribute("contactPhone", "")),
                                                                    new XElement("Insurance", new XAttribute("type", "General"), new XAttribute("amount", "0.00"), new XAttribute("company", ""), new XAttribute("expirationDate", ""), new XAttribute("contactName", ""), new XAttribute("contactPhone", "")),
                                                                    new XElement("Insurance", new XAttribute("type", "Liability"), new XAttribute("amount", "0.00"), new XAttribute("company", ""), new XAttribute("expirationDate", ""), new XAttribute("contactName", ""), new XAttribute("contactPhone", ""))
                                                                ),
                                                                new XElement("ReasonCode"),
                                                                new XElement("Status"),
                                                                new XElement("LaneID"),
                                                                new XElement("Zone"),
                                                                new XElement("RouteGuidePriority"),
                                                                new XElement("CarrierLocationOid"),
                                                                new XElement("OriginService", "D"),
                                                                new XElement("DestinationService", "D"),
                                                                new XElement("Charges",
                                                                    new XElement("Charge", new XAttribute("sequenceNum", "1"), new XAttribute("type", "ITEM"), new XAttribute("itemGroupId", "1"),
                                                                        new XElement("Description"),
                                                                        new XElement("EdiCode"),
                                                                        new XElement("Amount", "243.29851851851851851851851852"),
                                                                        new XElement("Rate", "243.29851851851851851851851852"),
                                                                        new XElement("RateQualifier", "FR"),
                                                                        new XElement("Quantity", "0.01"),
                                                                        new XElement("Weight", "1.0"),
                                                                        new XElement("DimWeight", "0.0"),
                                                                        new XElement("FreightClass", "70.0"),
                                                                        new XElement("FakFreightClass", "0.0"),
                                                                        new XElement("IsMin", "false"),
                                                                        new XElement("IsMax", "false"),
                                                                        new XElement("IsNontaxable", "false")
                                                                    ),
                                                                    new XElement("Charge", new XAttribute("sequenceNum", "5"), new XAttribute("type", "ACCESSORIAL_FUEL"), new XAttribute("itemGroupId", ""),
                                                                        new XElement("Description", "Fuel Surcharge"),
                                                                        new XElement("EdiCode", "405"),
                                                                        new XElement("Amount", "52.309181481481481481481481482"),
                                                                        new XElement("Rate", "52.309181481481481481481481482"),
                                                                        new XElement("RateQualifier", "FR"),
                                                                        new XElement("Quantity", "100.0"),
                                                                        new XElement("Weight", "0.0"),
                                                                        new XElement("DimWeight", "0.0"),
                                                                        new XElement("FreightClass", "0.0"),
                                                                        new XElement("FakFreightClass", "0.0"),
                                                                        new XElement("IsMin", "false"),
                                                                        new XElement("IsMax", "false"),
                                                                        new XElement("IsNontaxable", "false")
                                                                    )
                                                                ),
                                                                new XElement("Comments")
                                                            ),
                                                              new XElement("PriceSheet", new XAttribute("type", "Carrier"), new XAttribute("chargeModel", "NORMALIZED_SMC"), new XAttribute("isSelected", "true"), new XAttribute("isAllocated", "false"), new XAttribute("currencyCode", "USD"), new XAttribute("createDate", DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm")), new XAttribute("internalId", ""),
                                                                new XElement("AccessorialTotal", "21.50"),
                                                                new XElement("SubTotal", "100.00"),
                                                                new XElement("Total", "121.50"),
                                                                new XElement("ContractId", "(193669957386,3023,0)"),
                                                                new XElement("ContractName", "1PSI Cost FWDA"),
                                                                new XElement("CarrierId", "(8210554331,3840,0)"),
                                                                new XElement("CarrierName", "Forward Air"),
                                                                new XElement("SCAC", "FWDA"),
                                                                new XElement("Mode", "LTL"),
                                                                new XElement("Service", "LTL"),
                                                                new XElement("ServiceDays", "1.0"),
                                                                new XElement("Distance", "0.0"),
                                                                new XElement("Id", "1211821"),
                                                                new XElement("InsuranceTypes",
                                                                    new XElement("Insurance", new XAttribute("type", "Cargo"), new XAttribute("amount", "0.00"), new XAttribute("company", ""), new XAttribute("expirationDate", ""), new XAttribute("contactName", ""), new XAttribute("contactPhone", "")),
                                                                    new XElement("Insurance", new XAttribute("type", "General"), new XAttribute("amount", "0.00"), new XAttribute("company", ""), new XAttribute("expirationDate", ""), new XAttribute("contactName", ""), new XAttribute("contactPhone", "")),
                                                                    new XElement("Insurance", new XAttribute("type", "Liability"), new XAttribute("amount", "0.00"), new XAttribute("company", ""), new XAttribute("expirationDate", ""), new XAttribute("contactName", ""), new XAttribute("contactPhone", ""))
                                                                ),
                                                                new XElement("ReasonCode"),
                                                                new XElement("Status"),
                                                                new XElement("LaneID"),
                                                                new XElement("Zone"),
                                                                new XElement("RouteGuidePriority"),
                                                                new XElement("CarrierLocationOid"),
                                                                new XElement("OriginService", "D"),
                                                                new XElement("DestinationService", "D"),
                                                                new XElement("Charges",
                                                                    new XElement("Charge", new XAttribute("sequenceNum", "1"), new XAttribute("type", "ITEM"), new XAttribute("itemGroupId", "1"),
                                                                        new XElement("Description"),
                                                                        new XElement("EdiCode"),
                                                                        new XElement("Amount", "0.84"),
                                                                        new XElement("Rate", "83.62"),
                                                                        new XElement("RateQualifier", "CW"),
                                                                        new XElement("Quantity", "0.01"),
                                                                        new XElement("Weight", "1.0"),
                                                                        new XElement("DimWeight", "0.0"),
                                                                        new XElement("FreightClass", "70.0"),
                                                                        new XElement("FakFreightClass", "0.0"),
                                                                        new XElement("IsMin", "false"),
                                                                        new XElement("IsMax", "false"),
                                                                        new XElement("IsNontaxable", "false")
                                                                    )
                                                                ),
                                                                new XElement("Comments")
                                                            )
                                                        ),
                                                        new XElement("Shipper",
                                                            new XElement("Address", new XAttribute("isResidential", "false"),
                                                                new XElement("LocationCode"),
                                                                new XElement("Name"),
                                                                new XElement("AddrLine1"),
                                                                new XElement("AddrLine2"),
                                                                new XElement("City"),
                                                                new XElement("StateProvince"),
                                                                new XElement("PostalCode", "33126"),
                                                                new XElement("CountryCode", "USA"),
                                                                new XElement("Comments", "DefaultShipcheck"),
                                                                new XElement("Contacts",
                                                                    new XElement("Contact", new XAttribute("type", ""),
                                                                    new XElement("Name", "Vashipcontactname"),
                                                                    new XElement("ContactMethods",
                                                                        new XElement("ContactMethod", new XAttribute("sequenceNum", "1"), new XAttribute("type", "phone"), "(809) 999-9999"),
                                                                        new XElement("ContactMethod", new XAttribute("sequenceNum", "1"), new XAttribute("type", "fax"), "(997) 986-8687"),
                                                                        new XElement("ContactMethod", new XAttribute("sequenceNum", "1"), new XAttribute("type", "email"), "vacontactemail123@test.com")
                                                                        )
                                                                    )
                                                               )
                                                            )
                                                        ),
                                                        new XElement("Consignee",
                                                            new XElement("Address", new XAttribute("isResidential", "false"),
                                                                new XElement("LocationCode"),
                                                                new XElement("Name"),
                                                                new XElement("AddrLine1"),
                                                                new XElement("AddrLine2"),
                                                                new XElement("City"),
                                                                new XElement("StateProvince"),
                                                                new XElement("PostalCode", "33126"),
                                                                new XElement("CountryCode", "USA"),
                                                                new XElement("Comments", ""),
                                                                new XElement("Contacts",
                                                                        new XElement("Contact", new XAttribute("type", ""),
                                                                            new XElement("ContactMethods")
                                                                        )
                                                                    )
                                                            )
                                                        ),
                                                        new XElement("ItemGroups",
                                                            new XElement("ItemGroup", new XAttribute("id", "CRM"), new XAttribute("isShipUnit", "false"), new XAttribute("isHandlingUnit", "false"), new XAttribute("sequence", "1"),
                                                            new XElement("Dimensions",
                                                                new XElement("Dimension", new XAttribute("type", "Length"), new XAttribute("uom", "IN")),
                                                                new XElement("Dimension", new XAttribute("type", "Width"), new XAttribute("uom", "IN")),
                                                                new XElement("Dimension", new XAttribute("type", "Height"), new XAttribute("uom", "IN"))
                                                            ),
                                                            new XElement("Description", "TO TEST CM FLOW AS DEFAULT ITEM"),
                                                            new XElement("FreightClasses",
                                                                new XElement("FreightClass", new XAttribute("type", ""), "70")
                                                            ),
                                                              new XElement("NmfcCode", "234"),
                                                              new XElement("HazardousMaterial", "false"),
                                                              new XElement("Weights",
                                                                new XElement("Weight", new XAttribute("type", "actual"), new XAttribute("uom", "lbs"), "1")
                                                            ),
                                                            new XElement("Quantities",
                                                                new XElement("Quantity", new XAttribute("type", "actual"), new XAttribute("uom", "SKD"), "4")
                                                            )
                                                           )
                                                        ),
                                                        new XElement("Payment",
                                                            new XElement("Method", "Forward Air"),
                                                            new XElement("BillTo", new XAttribute("thirdParty", "true"),
                                                                new XElement("Address", new XAttribute("type", ""), new XAttribute("isResidential", "false"),
                                                                    new XElement("LocationCode")
                                                                )
                                                            )
                                                        )
                                                    )
                                                )
                                            )
                                        )
                                    )
                                  );


            return requestXml;
        }

        public XElement CreateQuoteXmlWithAccessorial(string quoteNumber, string pickupdate, string customerName, string overlength)
        {            
            XElement requestXml = new XElement("service-request",
                                    new XElement("service-id", "ImportWeb"),
                                    new XElement("request-id", "123456789"),
                                    new XElement("data",
                                        new XElement("WebImport",
                                            new XElement("WebImportHeader",
                                                new XElement("FileName", "QuoteImport"),
                                                new XElement("Type", "WebShXML4")
                                            ),
                                            new XElement("WebImportFile",
                                                new XElement("MercuryGate",
                                                    new XElement("Header",
                                                        new XElement("SenderID"),
                                                        new XElement("ReceiverID"),
                                                        new XElement("Action", "Add"),
                                                        new XElement("DocCount", "1"),
                                                        new XElement("DocTypeID", "Shipment"),
                                                        new XElement("Date", new XAttribute("type", "generation"), DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm"))
                                                    ),
                                                    new XElement("Shipment", new XAttribute("type", "LTL"), new XAttribute("action", "UpdateOrAdd"),
                                                        new XElement("Status", "Pending"),
                                                        new XElement("Enterprise", new XAttribute("name", customerName)),
                                                        new XElement("ReferenceNumbers",
                                                            new XElement("ReferenceNumber", new XAttribute("type", "SCAC"), new XAttribute("isPrimary", "false"), "FWDA"),
                                                            new XElement("ReferenceNumber", new XAttribute("type", "QuoteNumber"), new XAttribute("isPrimary", "true"), quoteNumber),
                                                            new XElement("ReferenceNumber", new XAttribute("type", "SubmittedBy"), new XAttribute("isPrimary", "false"), "ZZZ Test")
                                                        ),
                                                        new XElement("ServiceList",
                                                                       new XElement("ServiceCode", overlength)                                                                       
                                                                       ),
                                                        new XElement("EquipmentList"),
                                                        new XElement("Comments",
                                                            new XElement("Comment", new XAttribute("type", "SpecialInstructions"))
                                                        ),
                                                        new XElement("Dates",
                                                            new XElement("Pickup",
                                                                new XElement("Date", new XAttribute("type", "earliest"), pickupdate),
                                                                new XElement("Date", new XAttribute("type", "latest"), pickupdate)
                                                            ),
                                                            new XElement("Drop",
                                                                new XElement("Date", new XAttribute("type", "earliest"), DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm")),
                                                                new XElement("Date", new XAttribute("type", "latest"), DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm"))
                                                            )
                                                        ),
                                                        new XElement("PriceSheets",
                                                            new XElement("PriceSheet", new XAttribute("type", "Customer"), new XAttribute("chargeModel", "NORMALIZED_SMC"), new XAttribute("isSelected", "true"), new XAttribute("isAllocated", "false"), new XAttribute("currencyCode", "USD"), new XAttribute("createDate", DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm")), new XAttribute("internalId", ""),
                                                                new XElement("AccessorialTotal", "52.309181481481481481481481482"),
                                                                new XElement("SubTotal", "243.29851851851851851851851852"),
                                                                new XElement("Total", "295.60770000000000000000000000"),
                                                                new XElement("SCAC", "FWDA"),
                                                                new XElement("Mode", "LTL"),
                                                                new XElement("Service", "LTL"),
                                                                new XElement("ServiceDays", "1.0"),
                                                                new XElement("Distance", "0"),
                                                                new XElement("Id", "1211821"),
                                                                new XElement("InsuranceTypes",
                                                                    new XElement("Insurance", new XAttribute("type", "Cargo"), new XAttribute("amount", "0.00"), new XAttribute("company", ""), new XAttribute("expirationDate", ""), new XAttribute("contactName", ""), new XAttribute("contactPhone", "")),
                                                                    new XElement("Insurance", new XAttribute("type", "General"), new XAttribute("amount", "0.00"), new XAttribute("company", ""), new XAttribute("expirationDate", ""), new XAttribute("contactName", ""), new XAttribute("contactPhone", "")),
                                                                    new XElement("Insurance", new XAttribute("type", "Liability"), new XAttribute("amount", "0.00"), new XAttribute("company", ""), new XAttribute("expirationDate", ""), new XAttribute("contactName", ""), new XAttribute("contactPhone", ""))
                                                                ),
                                                                new XElement("ReasonCode"),
                                                                new XElement("Status"),
                                                                new XElement("LaneID"),
                                                                new XElement("Zone"),
                                                                new XElement("RouteGuidePriority"),
                                                                new XElement("CarrierLocationOid"),
                                                                new XElement("OriginService", "D"),
                                                                new XElement("DestinationService", "D"),
                                                                new XElement("Charges",
                                                                    new XElement("Charge", new XAttribute("sequenceNum", "1"), new XAttribute("type", "ITEM"), new XAttribute("itemGroupId", "1"),
                                                                        new XElement("Description"),
                                                                        new XElement("EdiCode"),
                                                                        new XElement("Amount", "243.29851851851851851851851852"),
                                                                        new XElement("Rate", "243.29851851851851851851851852"),
                                                                        new XElement("RateQualifier", "FR"),
                                                                        new XElement("Quantity", "0.01"),
                                                                        new XElement("Weight", "1.0"),
                                                                        new XElement("DimWeight", "0.0"),
                                                                        new XElement("FreightClass", "70.0"),
                                                                        new XElement("FakFreightClass", "0.0"),
                                                                        new XElement("IsMin", "false"),
                                                                        new XElement("IsMax", "false"),
                                                                        new XElement("IsNontaxable", "false")
                                                                    ),
                                                                    new XElement("Charge", new XAttribute("sequenceNum", "5"), new XAttribute("type", "ACCESSORIAL_FUEL"), new XAttribute("itemGroupId", ""),
                                                                        new XElement("Description", "Fuel Surcharge"),
                                                                        new XElement("EdiCode", "405"),
                                                                        new XElement("Amount", "52.309181481481481481481481482"),
                                                                        new XElement("Rate", "52.309181481481481481481481482"),
                                                                        new XElement("RateQualifier", "FR"),
                                                                        new XElement("Quantity", "100.0"),
                                                                        new XElement("Weight", "0.0"),
                                                                        new XElement("DimWeight", "0.0"),
                                                                        new XElement("FreightClass", "0.0"),
                                                                        new XElement("FakFreightClass", "0.0"),
                                                                        new XElement("IsMin", "false"),
                                                                        new XElement("IsMax", "false"),
                                                                        new XElement("IsNontaxable", "false")
                                                                    )
                                                                ),
                                                                new XElement("Comments")
                                                            ),
                                                              new XElement("PriceSheet", new XAttribute("type", "Carrier"), new XAttribute("chargeModel", "NORMALIZED_SMC"), new XAttribute("isSelected", "true"), new XAttribute("isAllocated", "false"), new XAttribute("currencyCode", "USD"), new XAttribute("createDate", DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm")), new XAttribute("internalId", ""),
                                                                new XElement("AccessorialTotal", "21.50"),
                                                                new XElement("SubTotal", "100.00"),
                                                                new XElement("Total", "121.50"),
                                                                new XElement("ContractId", "(193669957386,3023,0)"),
                                                                new XElement("ContractName", "1PSI Cost FWDA"),
                                                                new XElement("CarrierId", "(8210554331,3840,0)"),
                                                                new XElement("CarrierName", "Forward Air"),
                                                                new XElement("SCAC", "FWDA"),
                                                                new XElement("Mode", "LTL"),
                                                                new XElement("Service", "LTL"),
                                                                new XElement("ServiceDays", "1.0"),
                                                                new XElement("Distance", "0.0"),
                                                                new XElement("Id", "1211821"),
                                                                new XElement("InsuranceTypes",
                                                                    new XElement("Insurance", new XAttribute("type", "Cargo"), new XAttribute("amount", "0.00"), new XAttribute("company", ""), new XAttribute("expirationDate", ""), new XAttribute("contactName", ""), new XAttribute("contactPhone", "")),
                                                                    new XElement("Insurance", new XAttribute("type", "General"), new XAttribute("amount", "0.00"), new XAttribute("company", ""), new XAttribute("expirationDate", ""), new XAttribute("contactName", ""), new XAttribute("contactPhone", "")),
                                                                    new XElement("Insurance", new XAttribute("type", "Liability"), new XAttribute("amount", "0.00"), new XAttribute("company", ""), new XAttribute("expirationDate", ""), new XAttribute("contactName", ""), new XAttribute("contactPhone", ""))
                                                                ),
                                                                new XElement("ReasonCode"),
                                                                new XElement("Status"),
                                                                new XElement("LaneID"),
                                                                new XElement("Zone"),
                                                                new XElement("RouteGuidePriority"),
                                                                new XElement("CarrierLocationOid"),
                                                                new XElement("OriginService", "D"),
                                                                new XElement("DestinationService", "D"),
                                                                new XElement("Charges",
                                                                    new XElement("Charge", new XAttribute("sequenceNum", "1"), new XAttribute("type", "ITEM"), new XAttribute("itemGroupId", "1"),
                                                                        new XElement("Description"),
                                                                        new XElement("EdiCode"),
                                                                        new XElement("Amount", "0.84"),
                                                                        new XElement("Rate", "83.62"),
                                                                        new XElement("RateQualifier", "CW"),
                                                                        new XElement("Quantity", "0.01"),
                                                                        new XElement("Weight", "1.0"),
                                                                        new XElement("DimWeight", "0.0"),
                                                                        new XElement("FreightClass", "70.0"),
                                                                        new XElement("FakFreightClass", "0.0"),
                                                                        new XElement("IsMin", "false"),
                                                                        new XElement("IsMax", "false"),
                                                                        new XElement("IsNontaxable", "false")
                                                                    )
                                                                ),
                                                                new XElement("Comments")
                                                            )
                                                        ),
                                                        new XElement("Shipper",
                                                            new XElement("Address", new XAttribute("isResidential", "false"),
                                                                new XElement("LocationCode"),
                                                                new XElement("Name"),
                                                                new XElement("AddrLine1"),
                                                                new XElement("AddrLine2"),
                                                                new XElement("City"),
                                                                new XElement("StateProvince"),
                                                                new XElement("PostalCode", "33126"),
                                                                new XElement("CountryCode", "USA"),
                                                                new XElement("Comments", "DefaultShipcheck"),
                                                                new XElement("Contacts",
                                                                    new XElement("Contact", new XAttribute("type", ""),
                                                                    new XElement("Name", "Vashipcontactname"),
                                                                    new XElement("ContactMethods",
                                                                        new XElement("ContactMethod", new XAttribute("sequenceNum", "1"), new XAttribute("type", "phone"), "(809) 999-9999"),
                                                                        new XElement("ContactMethod", new XAttribute("sequenceNum", "1"), new XAttribute("type", "fax"), "(997) 986-8687"),
                                                                        new XElement("ContactMethod", new XAttribute("sequenceNum", "1"), new XAttribute("type", "email"), "vacontactemail123@test.com")
                                                                        )
                                                                    )
                                                               )
                                                            )
                                                        ),
                                                        new XElement("Consignee",
                                                            new XElement("Address", new XAttribute("isResidential", "false"),
                                                                new XElement("LocationCode"),
                                                                new XElement("Name"),
                                                                new XElement("AddrLine1"),
                                                                new XElement("AddrLine2"),
                                                                new XElement("City"),
                                                                new XElement("StateProvince"),
                                                                new XElement("PostalCode", "33126"),
                                                                new XElement("CountryCode", "USA"),
                                                                new XElement("Comments", ""),
                                                                new XElement("Contacts",
                                                                        new XElement("Contact", new XAttribute("type", ""),
                                                                            new XElement("ContactMethods")
                                                                        )
                                                                    )
                                                            )
                                                        ),
                                                        new XElement("ItemGroups",
                                                            new XElement("ItemGroup", new XAttribute("id", "CRM"), new XAttribute("isShipUnit", "false"), new XAttribute("isHandlingUnit", "false"), new XAttribute("sequence", "1"),
                                                            new XElement("Dimensions",
                                                                new XElement("Dimension", new XAttribute("type", "Length"), new XAttribute("uom", "IN"),"96"),
                                                                new XElement("Dimension", new XAttribute("type", "Width"), new XAttribute("uom", "IN"),"12"),
                                                                new XElement("Dimension", new XAttribute("type", "Height"), new XAttribute("uom", "IN"),"12")
                                                            ),
                                                            new XElement("Description", "TO TEST CM FLOW AS DEFAULT ITEM"),
                                                            new XElement("FreightClasses",
                                                                new XElement("FreightClass", new XAttribute("type", ""), "70")
                                                            ),
                                                              new XElement("NmfcCode", "234"),
                                                              new XElement("HazardousMaterial", "false"),
                                                              new XElement("Weights",
                                                                new XElement("Weight", new XAttribute("type", "actual"), new XAttribute("uom", "lbs"), "1")
                                                            ),
                                                            new XElement("Quantities",
                                                                new XElement("Quantity", new XAttribute("type", "actual"), new XAttribute("uom", "SKD"), "4")
                                                            )
                                                           )
                                                        ),
                                                        new XElement("Payment",
                                                            new XElement("Method", "Forward Air"),
                                                            new XElement("BillTo", new XAttribute("thirdParty", "true"),
                                                                new XElement("Address", new XAttribute("type", ""), new XAttribute("isResidential", "false"),
                                                                    new XElement("LocationCode")
                                                                )
                                                            )
                                                        )
                                                    )
                                                )
                                            )
                                        )
                                    )
                                  );


            return requestXml;
        }
    }
}
