using OpenQA.Selenium;
using System.Collections.Generic;

namespace CRM.UITest.CommonMethods
{
    public interface IGetChosenAccessorials
    {
        IList<IWebElement> GetShippingFromChosenAccessorials();
    }
}
