using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper
{
    public static class ConfigurationHelper
    {
        public static string CrmWebUrl => Convert.ToString(ConfigurationManager.AppSettings["CrmWebUrl"]);
        public static string CarrierLogoImageUrl = Convert.ToString(ConfigurationManager.AppSettings["CarrierLogoImageUrl"]);
        public static string InsuredBaseCost = ConfigurationManager.AppSettings["BaseInsuredCost"];
        public static string ProxyWebApiUrlVersion2 => Convert.ToString(ConfigurationManager.AppSettings["ProxyWebApiUrlVersion2"]);
    }
}
