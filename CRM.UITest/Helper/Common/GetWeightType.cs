using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Common
{
    public class GetWeightType
    {
        string Weightval = null;
        public string GetWeight(string Weighval)
        {
            if(Weighval == "KG")
            {
                return Weightval = "KILOS";
            }
            else if(Weighval == "lb")
            {
                return Weightval = "LBS";
            }
            else
            {
                return null;
            }
        }
    }
}
