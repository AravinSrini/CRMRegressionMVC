using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.CommonMethods
{
    public class WebElementOperations
    {
        public List<string> GetListFromIWebElement(IList<IWebElement> webElementList)
        {
            List<string> result = new List<string>();
            foreach (IWebElement element in webElementList)
            {
                result.Add((element.Text));
            }
            return result;
        }
    }
}
