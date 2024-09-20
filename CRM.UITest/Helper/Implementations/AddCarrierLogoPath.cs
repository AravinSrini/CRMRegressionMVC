using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class AddCarrierLogoPath : IAddCarrierLogoPath
    {
        private ICreateLogoPathBasedOnScacCode _createLogoPathBasedOnScacCode;
        private IGetPhysicalPath _getPhysicalPath;
        private IConvertPhysicalPathToUrlForCarrierLogo _converPath;

        public AddCarrierLogoPath(ICreateLogoPathBasedOnScacCode createLogoPathBasedOnScacCode, IGetPhysicalPath getPhysicalPath,
            IConvertPhysicalPathToUrlForCarrierLogo converPath)
        {
            _getPhysicalPath = getPhysicalPath;
            _createLogoPathBasedOnScacCode = createLogoPathBasedOnScacCode;
            _converPath = converPath;
        }

        public IEnumerable<RateResultCarrierViewModel> AddLogoPathInModel(IEnumerable<RateResultCarrierViewModel> carrierList)
        {
            string logoPath = string.Empty;
            string physicalPath = string.Empty;

            if (carrierList != null)
            {
                physicalPath = _getPhysicalPath.GetPath(ConfigurationHelper.CarrierLogoImageUrl);

                foreach (RateResultCarrierViewModel carrier in carrierList)
                {
                    logoPath = _createLogoPathBasedOnScacCode.GetCarrierLogoPath(carrier.ScacCode, physicalPath);

                    carrier.CarrierLogoPath = string.IsNullOrWhiteSpace(logoPath) ? string.Empty : _converPath.ConvertPathToUrl(carrier.ScacCode);
                }
            }

            return carrierList;
        }
    }
}
