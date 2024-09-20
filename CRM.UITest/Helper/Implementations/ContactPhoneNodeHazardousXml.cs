using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class ContactPhoneNodeHazardousXml : IContactPhoneNodeHazardousXml
    {
        public string GetContactPhoneNode(ShipmentImportHazMatDetailModel hazardousMaterial)
        {
            hazardousMaterial.CcnNumber = string.IsNullOrWhiteSpace(hazardousMaterial.CcnNumber) ? string.Empty
                : string.Concat(" ", hazardousMaterial.CcnNumber);

            string contactPhone = string.IsNullOrWhiteSpace(hazardousMaterial.ContactPhone) ? string.Empty
                : hazardousMaterial.ContactPhone;

            contactPhone = string.IsNullOrWhiteSpace(hazardousMaterial.CcnNumber) ? contactPhone
                : string.Concat(contactPhone, hazardousMaterial.CcnNumber);

            return contactPhone;
        }
    }
}
