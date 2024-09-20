using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations.CustomReportXML
{
    public class GetCustomReportXML
    {

        public XElement _GetCustReportXML(string Useremail, string ServiceType, string RefNumber, string StardDate, string Enddate, string OrgCity, string DestCity, string Status, string CustomerAccount, string MgCustomerAccountNumber, string APIReport)
        {
            CustomReportData CD = new CustomReportData();
            var p = CD.GetCustomReportList(Useremail, ServiceType, RefNumber, StardDate, Enddate, OrgCity, DestCity, Status, APIReport);

            var xmlfromLINQ = new XElement("service-request",
                                  new XElement("service-id", "ListScreen"),
                                  new XElement("request-id", 123456789),
                                  new XElement("data",
                                  new XElement("listScreenType", "Shipment"),
                                  new XElement("reportName", APIReport),
                                  new XElement("PromptFieldCount", 5),
                                  new XElement("PromptField1", p.PickUpDateStart.ToString()),
                                  new XElement("PromptField2", p.PickUpDateEnd.ToString()),
                                  new XElement("PromptField3", p.ShipmentServiceTypes),
                                  new XElement("PromptField4", p.Status),
                                  new XElement("PromptField5", p.OriginCity),
                                  //new XElement("Enterprise", new XAttribute("customerAcctNum", CustomerAccount))
                                  new XElement("Enterprise", !string.IsNullOrWhiteSpace(MgCustomerAccountNumber) ? new XAttribute("customerAcctNum", MgCustomerAccountNumber) : new XAttribute("name", CustomerAccount))

                                                 ));
            return xmlfromLINQ;
        }


        public XElement getListExtractRequestXML(string refNumber)
        {
            var ListExtractRequestXML = new XElement("service-request",
                                  new XElement("service-id", "ListScreen"),
                                  new XElement("request-id", 123456789),
                                  new XElement("data",
                                  new XElement("listScreenType", "Shipment"),
                                  new XElement("reportName", "CRM-ClaimsSubmitForm"),
                                  new XElement("PromptFieldCount", 1),
                                  new XElement("PromptField1", refNumber)
                                         ));
            return ListExtractRequestXML;
        }
    }
}
