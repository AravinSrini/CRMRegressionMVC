using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using CRMTest.Common.PageObjects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using CRMTest.Common.CommonMethods.ApplicationCommon;
using CRMTest.Common.ComponentFunctions.QuoteFunctions;

namespace CRMRegressionTest.TestScripts.QuotePageTests
{
    [TestClass]
    public class CreateQuotewithExternalUsers :Quotelist
    {
       [TestMethod]
       public void CreateQuotewithExternalUser()
       {
            //LaunchURL();
            Navigation.QuoteList();
            QuoteListPage.ClickDateSort();

       }

       
    }
}
