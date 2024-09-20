using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations.AvailableLoadsXML
{
    public class AvailableLoadsRequestXml
    {
        public XElement GetAvailableLoadsRequestXml()
        {
            XElement requestXml = new XElement(
              "service-request",
              new XElement("service-id", "ListScreen"),
              new XElement("request-id", "123456789"),
              new XElement(
                  "data",
                  new XElement("listScreenType", "Transport"),
                  new XElement("reportName", "CRM-AvailableLoads")
                      ));

            return requestXml;

        }
    }
}
