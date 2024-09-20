using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CRM.UITest.Helper.Interfaces
{
    public interface IInvokeTerminalByPostalCodeApi
    {
        XmlDocument InvokeCarrierTerminalInformation(string terminalRequestXml, out string errorMessage);

        IDictionary<string, string> getTerminalinfomethod(XmlDocument xmlDoc);

        IDictionary<string, string> GetShipmentValues(string shipmentReferenceNumber);

    }


}
