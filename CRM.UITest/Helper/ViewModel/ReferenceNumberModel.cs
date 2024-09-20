using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    public class ReferenceNumberModel
    {
        public bool IsPrimary { get; set; }

      //  [Required(ErrorMessage = Constants.ReferenceNumber)]
        public string ReferenceNumber { get; set; }

       // [Required(ErrorMessage = Constants.ReferenceType)]
        public string ReferenceType { get; set; }

        /// <summary>
        /// Constants
        /// </summary>
        private class Constants
        {
            internal const string ReferenceNumber = "ReferenceNumber is required";
            internal const string ReferenceType = "ReferenceType is required when a Reference Number is provided.";
        }
    }
}
