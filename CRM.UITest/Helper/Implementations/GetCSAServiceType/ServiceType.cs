using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations.GetCSAServiceType
{
    public class ServiceType
    {
        string ServiceLevel = null;
        public string GetCSAServiceType(string service)
        {
            if (service == "5D")
            {
                return ServiceLevel = "Economy ";
            }
            else if (service == "WG")
            {
                return ServiceLevel = "White Glove ";
            }
            else if (service == "EU")
            {
                return ServiceLevel = "Hot Shot";
            }
            else if (service == "LC")
            {
                return ServiceLevel = "Local";
            }
            else if (service == "LT")
            {
                return ServiceLevel = "LTL";
            }
            else if (service == "FT")
            {
                return ServiceLevel = "FULL TRUCK LOAD";
            }
            else if (service == "CH")
            {
                return ServiceLevel = "CHARTER";
            }
            else if (service == "NF")
            {
                return ServiceLevel = "Next Flight Out";
            }
            else if (service == "SD")
            {
                return ServiceLevel = "Same Day";
            }
            else if (service == "1D")
            {
                return ServiceLevel = "Next Day";
            }
            else if (service == "1A")
            {
                return ServiceLevel = "Next Day AM";
            }
            else if (service == "2D")
            {
                return ServiceLevel = "2 Day";
            }
            else if (service == "2A")
            {
                return ServiceLevel = "2 Day AM";
            }
            else if (service == "3D")
            {
                return ServiceLevel = "3 Day";
            }
            else if (service == "3A")
            {
                return ServiceLevel = "3 Day AM";
            }
            else if (service == "CC")
            {
                return ServiceLevel = "Customs Clearance";
            }
            else if (service == "CO")
            {
                return ServiceLevel = "Air Consolidation";
            }
            else if (service == "DT")
            {
                return ServiceLevel = "Air Direct";
            }
            else if (service == "OL")
            {
                return ServiceLevel = "Ocean LCL";
            }
            else if(service == "OF")
            {
                return ServiceLevel = "Ocean FCL";
            }

            else
            {
                return null;
            }
        }
    }
}
