using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace CRM.UITest.CommonMethods
{
    public class ClickAndWaitMethods : ObjectRepository
    {
        public  void ClickAndWait(string param1, string param2)
        {
            Click(param1, param2);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
    }
}
