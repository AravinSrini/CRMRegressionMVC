using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    public class RateEventModel
    {
        public DateTime Date { get; set; }

        public string LocationCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

       // [Required(ErrorMessage = Constants.Country)]
        public string Country { get; set; }

        /// <summary>
        /// Constants
        /// </summary>
        private class Constants
        {
            internal const string Country = "Country is required";
        }
    }
}
