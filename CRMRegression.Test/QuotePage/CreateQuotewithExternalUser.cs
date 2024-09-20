using CRMTest.Common.CommonMethods.ApplicationCommon;
using CRMTest.Common.ComponentFunctions.QuoteFunctions;
using CRMTest.Common.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRMRegression.Test.QuoteListTests
{
    [TestClass]
    public class CreateQuotewithExternalUser : Quotelist
    {
        CommonMethod CRMCommon = new CommonMethod();
        CreateQuote createQuote = new CreateQuote();
        Navigation Navigate = new Navigation();
        QuoteList quoteList = new QuoteList();

        [TestMethod]
        public void Quote_CreateQuoteWithExternalUsers()
        {
            CRMCommon.Login_CRMApplication("CurrentSprintOperations", "Te$t1234");
            Navigate.ToQuoteListPage();
            quoteList.ClickSubmitRateRequest();
            createQuote.EnterOriginZip("36024");
            createQuote.EnterDestinationZip("36024");

        }
    }
}
