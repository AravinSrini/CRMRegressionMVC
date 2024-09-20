using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    public class EquipmentModel
    {

        private const string equipmentCode = "Equipment Code is required";

       // [Required(ErrorMessage = equipmentCode)]
        public string EquipmentCode { get; set; }
    }
}
