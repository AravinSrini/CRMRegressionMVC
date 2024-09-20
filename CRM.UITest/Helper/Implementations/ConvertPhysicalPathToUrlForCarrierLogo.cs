using CRM.UITest.Helper.Interfaces;

namespace CRM.UITest.Helper.Implementations
{
    public class ConvertPhysicalPathToUrlForCarrierLogo : IConvertPhysicalPathToUrlForCarrierLogo
    {
        public string ConvertPathToUrl(string scacCode)
        {
            string filePath = @"images/CarrierLogo/";
            string urlPath = string.Empty;

            urlPath = string.IsNullOrWhiteSpace(scacCode) ? string.Empty : string.Concat(ConfigurationHelper.CrmWebUrl, filePath, scacCode, ".png");

            return urlPath;
        }
    }
}
