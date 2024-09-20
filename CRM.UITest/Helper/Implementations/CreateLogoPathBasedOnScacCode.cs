using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class CreateLogoPathBasedOnScacCode: ICreateLogoPathBasedOnScacCode
    {
        private const string png = ".png";

        public string GetCarrierLogoPath(string scacCode, string physicalPath)
        {
            string path = string.Empty;
            string logoPath = string.Empty;

            if (!string.IsNullOrWhiteSpace(physicalPath) && !string.IsNullOrWhiteSpace(scacCode))
            {
                // Create complete physical path including images/CarrierLogo/LogoName
                path = Path.Combine(physicalPath, scacCode);

                logoPath = File.Exists(path + png) ? string.Concat(path, png) : string.Empty;
            }

            return logoPath;
        }
    }
}
