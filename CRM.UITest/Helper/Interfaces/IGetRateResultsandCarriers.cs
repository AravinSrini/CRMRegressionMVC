using System.Xml.Linq;

namespace CRM.UITest.Helper.Interfaces
{
    public interface IGetRateResultsandCarriers
    {
        XElement GetRateResultsandCarrier(XElement requestXml, string customerAccount, bool callProxyVersion2, out string errorMessage, bool applyGainShareGuaranteedCalculation);
    }
}
