using CRM.UITest.Helper.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations.StandardReport
{
    public class ListScreenExtractRequestXML
    {


        public XElement GetListScreenExtractRequestXMLL(string customerName, string reportName)
        {
            var xmlfromLINQ = new XElement(

                                  new XElement("service-request",
                                  new XElement("service-id", "ListScreen"),
                                  new XElement("request-id", "123456789"),
                                  new XElement("data",
                                  new XElement("listScreenType", "Shipment"),
                                  new XElement("reportName", reportName),
                                  new XElement("PromptFieldCount", "1"),
                                  new XElement("PromptField1", new XAttribute("name", customerName))
                                                 )));
            return xmlfromLINQ;
        }

        public XElement GetRequestXMLForShipmentListCustomerUser(string customerName, string reportName)
        {
            var xmlfromLINQ = new XElement(

                                  new XElement("service-request",
                                  new XElement("service-id", "ListScreen"),
                                  new XElement("request-id", "123456789"),
                                  new XElement("data",
                                  new XElement("listScreenType", "Shipment"),
                                  new XElement("reportName", reportName),
                                  new XElement("PromptFieldCount", "1"),
                                  new XElement("PromptField1", customerName)
                                  )));
            return xmlfromLINQ;
        }
        public XElement GetRequestXMLForShipmentListStationUser(string mgAccountNumber, string reportName)
        {
            var xmlfromLINQ = new XElement(

                                  new XElement("service-request",
                                  new XElement("service-id", "ListScreen"),
                                  new XElement("request-id", "123456789"),
                                  new XElement("data",
                                  new XElement("listScreenType", "Shipment"),
                                  new XElement("reportName", reportName),
                                  new XElement("Enterprise", new XAttribute("customerAcctNum", mgAccountNumber))
                                                 )));
            return xmlfromLINQ;
        }

        public XElement GetRequestXMLForShipmentListExternalUser(string mgAccountNumber, string reportName, string customerName)
        {
            var xmlfromLINQ = new XElement(

                                  new XElement("service-request",
                                  new XElement("service-id", "ListScreen"),
                                  new XElement("request-id", "123456789"),
                                  new XElement("data",
                                  new XElement("listScreenType", "Shipment"),
                                  new XElement("reportName", reportName),
                                  new XElement("Enterprise", !string.IsNullOrWhiteSpace(mgAccountNumber) ? new XAttribute("customerAcctNum", mgAccountNumber) : new XAttribute("name", customerName))
                                                 )));
            return xmlfromLINQ;
        }

        public XElement GetOidNumberFromReferenceNumber(string referenceNumber)
        {
            var xmlfromLINQ = new XElement(
                                  new XElement("service-request",
                                  new XElement("service-id", "OidLookup"),
                                  new XElement("request-id", "123456789"),
                                  new XElement("timing", "true"),
                                  new XElement("data",
                                  new XElement("objectType", "shipment"),
                                  new XElement("searchBy", "reference"),
                                  new XElement("searchValue", referenceNumber)
                                                 )));
            return xmlfromLINQ;
        }

        public XElement GetShipmentFromOID(string oid)
        {
            var xmlfromLINQ = new XElement(
                                  new XElement("service-request",
                                  new XElement("service-id", "ExtractShipment"),
                                  new XElement("request-id", "123456789"),
                                  new XElement("timing", "true"),
                                  new XElement("data",
                                  new XElement("oid", oid)
                                                 )));
            return xmlfromLINQ;
        }
    }
}
