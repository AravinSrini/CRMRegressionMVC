using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Helper;
using CRM.UITest.Helper.Implementations;
using CRM.UITest.Helper.Implementations.Csrs;
using CRM.UITest.Helper.Interfaces.Csrs;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Csr.Gainshare___New_Logic
{
    [Binding]
    public sealed class _96966___Inherit_Default_Accessorial___Apply_Logic : Submit_CSR
    {
        ClickAndWaitMethods clickMethods = new ClickAndWaitMethods();
        DeleteCustomerFromDb deleteCustomerFromDb = new DeleteCustomerFromDb();
        IDeleteAllCsrStageInfoForUser deleteAllCsrStageInfo = new DeleteAllCsrStageInfoForUser();
        IChangeCRMRatingLogicFlagToFalse changeCRMRatingLogicFlagToFalse = new ChangeCRMRatingLogicFlagToFalse();
        IChangeCRMRatingLogicFlagToTrue changeCRMRatingLogicFlagToTrue = new ChangeCRMRatingLogicFlagToTrue();

        [Then(@"the value of New CRM Rating Logic in the database will be true for customer ""(.*)""")]
        public void ThenTheValueOfNewCRMRatingLogicInTheDatabaseWillBeTrueForCustomer(string customerName)
        {
            Report.WriteLine("Checking database for New CRM Rating Logic value");
            bool newCRMRatingLogic = DBHelper.CheckNewCrmRatingLogic(customerName);

            Assert.IsTrue(newCRMRatingLogic);
        }

        [Then(@"the value of New CRM Rating Logic in the database will be false for customer ""(.*)""")]
        public void ThenTheValueOfNewCRMRatingLogicInTheDatabaseWillBeFalseForCustomer(string customerName)
        {
            Report.WriteLine("Checking database for New CRM Rating Logic value");
            bool newCRMRatingLogic = DBHelper.CheckNewCrmRatingLogic(customerName);

            Assert.IsFalse(newCRMRatingLogic);
        }

        [BeforeScenario("96966NewGainshareLogicYesDeleteCustomer")]
        private void DeleteCustomerFromDb96966NewCustomerWithGainshareNewLogic()
        {
            string username = "96966 New Gainshare Logic is Yes MG";
            deleteCustomerFromDb.DeleteCustomerDetails(username);
            deleteAllCsrStageInfo.DeleteAllCsrStageInformation(username);
        }

        [BeforeScenario("96966NewGainshareLogicNoDeleteCustomer")]
        private void DeleteCustomerFromDb96966NewCustomerWithoutGainshareNewLogic()
        {
            string username = "96966 New Gainshare Logic is No MG";
            deleteCustomerFromDb.DeleteCustomerDetails(username);
            deleteAllCsrStageInfo.DeleteAllCsrStageInformation(username);
        }

        [BeforeScenario("96966TurnOffGainshareLogicForCustomer")]
        public void NewGainshareLogicNoRevisedTurnOffGainshareNewLogic()
        {
            string customerName = "96966 New Gainshare Logic No Revised";
            changeCRMRatingLogicFlagToFalse.ChangeCRMRatingLogicFlagFromTrueToFalse(customerName);
            deleteAllCsrStageInfo.DeleteAllCsrStageInformation(customerName);
            customerName = "96966 New Gainshare Logic No Revised CSA";
            changeCRMRatingLogicFlagToFalse.ChangeCRMRatingLogicFlagFromTrueToFalse(customerName);
            deleteAllCsrStageInfo.DeleteAllCsrStageInformation(customerName);
        }

        [BeforeScenario("96966TurnOnGainshareLogicForCustomer")]
        public void NewGainshareLogicYesRevisedTurnOnGainshareNewLogic()
        {
            string customerName = "96966 New Gainshare Logic Yes Revised";
            changeCRMRatingLogicFlagToTrue.ChangeCRMRatingLogicToTrue(customerName);
            deleteAllCsrStageInfo.DeleteAllCsrStageInformation(customerName);
            customerName = "96966 New Gainshare Logic Yes Revised CSA";
            changeCRMRatingLogicFlagToTrue.ChangeCRMRatingLogicToTrue(customerName);
            deleteAllCsrStageInfo.DeleteAllCsrStageInformation(customerName);
        }
    }
}
