using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    public class RateConstraintsModel
    {
        public string Mode { get; set; }

        public string ContractType { get; set; }

        public string ContractName { get; set; }

        public string CarrierName { get; set; }

        public string CarrierScac { get; set; }

        public string PaymentTerms { get; set; }

        public List<ServiceFlagModel> ServiceFlags { get; set; }

        public List<EquipmentModel> Equipments { get; set; }

        public string AdditionalServicesValue { get; set; }

        public string AdditionServicesFrom { get; set; }

        public string AdditionServicesTo { get; set; }
    }
}
