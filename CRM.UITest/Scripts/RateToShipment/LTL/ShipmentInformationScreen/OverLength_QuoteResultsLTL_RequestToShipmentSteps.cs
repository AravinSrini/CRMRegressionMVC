using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Scripts.QuoteToShipment.LTL;

namespace CRM.UITest.Scripts.RateToShipment.LTL.ShipmentInformationScreen
{
    [Binding]
    public class OverLength_QuoteResultsLTL_RequestToShipmentSteps:AddShipmentLTL
    {
        AddShipmentLTL addShipment = new AddShipmentLTL();
        AddQuoteLTL getQuote = new AddQuoteLTL();
        RateToShipmentLTL rateToShipment = new RateToShipmentLTL();
        AddShipmentLTL addShipmentObjects = new AddShipmentLTL();
        SavedQuoteToShipment_AutoPopulateSavedItemDetailsSteps saveQuoteHelpers = new SavedQuoteToShipment_AutoPopulateSavedItemDetailsSteps();

        [Given(@"that I am a shp\.entry, sales, sales management, operations, or station owner user")]
        public void GivenThatIAmAShp_EntrySalesSalesManagementOperationsOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }
        
        [Given(@"I am on Get Quote \(LTL\) page")]
        public void GivenIAmOnGetQuoteLTLPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            getQuote.NaviagteToQuoteList();
            getQuote.Add_QuoteLTL("External","zzz-czar customer");
        }
        
        [Given(@"I have passed all mandatory fields Length,Width,Height fields by selecting Overlength")]
        public void GivenIHavePassedAllMandatoryFieldsLengthWidthHeightFieldsBySelectingOverlength()
        {
            Report.WriteLine("I have passed all mandatory fields Length,Width,Height fields by selecting Overlength");
            getQuote.EnterOriginZip("60606");
            getQuote.EnterDestinationZip("33126");
            getQuote.EnterItemdata("50", "50");
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            DefineTimeOut(2000);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipFrom_Xpath,"Overlength");
            SendKeys(attributeName_id,LTL_Length_Id, "11");
            SendKeys(attributeName_id,LTL_Width_Id, "11");
            SendKeys(attributeName_id,LTL_Height_Id, "11");
            Click(attributeName_xpath, "//*[@id='Length-Additional-Warning-0']/h4/i[@class='icon-close right']");
            DefineTimeOut(1000);
        }
        
        [Given(@"I have passed all mandatory fields,Length,Width,Height fields without selecting Overlength")]
        public void GivenIHavePassedAllMandatoryFieldsLengthWidthHeightFieldsWithoutSelectingOverlength()
        {
            Report.WriteLine("I have passed all mandatory fields,Length,Width,Height fields without selecting Overlength");
            getQuote.EnterOriginZip("90001");
            getQuote.EnterDestinationZip("90007");
            getQuote.EnterItemdata("50", "50");
            SendKeys(attributeName_id, LTL_Length_Id, "11");
            SendKeys(attributeName_id, LTL_Width_Id, "11");
            SendKeys(attributeName_id, LTL_Height_Id, "11");
        }
        
        [Given(@"I have passed all mandatory fields without selecting Overlength")]
        public void GivenIHavePassedAllMandatoryFieldsWithoutSelectingOverlength()
        {
            Report.WriteLine("I have passed all mandatory fields without selecting Overlength");
            getQuote.EnterOriginZip("90001");
            getQuote.EnterDestinationZip("90007");
            getQuote.EnterItemdata("50", "50");
        }
        [Given(@"I have passed all mandatory fields by selecting  defualt item values")]
        public void GivenIHavePassedAllMandatoryFieldsBySelectingDefualtItemValues()
        {
            Report.WriteLine("I have passed all mandatory fields without selecting Overlength");
            getQuote.EnterOriginZip("90001");
            getQuote.EnterDestinationZip("90007");
           
        }

        [Given(@"I have passed all mandatory fields with the saved item")]
        public void GivenIHavePassedAllMandatoryFieldsWithTheSavedItem()
        {
            Report.WriteLine("I have passed all mandatory fields without selecting Overlength");
            getQuote.EnterOriginZip("90001");
            getQuote.EnterDestinationZip("90007");
            saveQuoteHelpers.EnterItemInformation("100 YESHAZ");
        }


        [When(@"I click on create shipment on Quote Results \(LTL\) page")]
        public void WhenIClickOnCreateShipmentOnQuoteResultsLTLPage()
        {
            getQuote.ClickViewRates();
            Report.WriteLine("I am on Rate Results page");
            rateToShipment.ClickOnCreateShipmentbutton_Quote("External");
            Report.WriteLine("I clicked on Create Shipment button on Rate Results page");
        }
        
        [When(@"I click on create Insured shipment on Quote Results \(LTL\) page")]
        public void WhenIClickOnCreateInsuredShipmentOnQuoteResultsLTLPage()
        {
            MoveToElement(attributeName_id,LTL_EnterInsuredValue_Id);
            SendKeys(attributeName_id,LTL_EnterInsuredValue_Id,"100");
            getQuote.ClickViewRates();
            Report.WriteLine("I am on Rate Results page");
            rateToShipment.ClickOnCreateInsuredShipmentbutton_Quote("External");
            Report.WriteLine("I clicked on Create Insured Shipment button on Rate Results page");
        }
        
        [Then(@"Length,Width,Height,Dimension Type fields should be autopoulated on Add Shipment \(LTL\) page")]
        public void ThenLengthWidthHeightDimensionTypeFieldsShouldBeAutopoulatedOnAddShipmentLTLPage()
        {
            Report.WriteLine("Length,Width,Height,Dimension Type fields should be autopoulated on Add Shipment LTL page");
            GlobalVariables.webDriver.WaitForPageLoad();
            MoveToElement(attributeName_id, addShipmentObjects.FreightDesp_FirstItem_Length_Id);
            Assert.AreEqual(GetValue(attributeName_id, addShipmentObjects.FreightDesp_FirstItem_Length_Id, "value"), "11");
            Assert.AreEqual(GetValue(attributeName_id, addShipmentObjects.FreightDesp_FirstItem_Width_Id, "value"), "11");
            Assert.AreEqual(GetValue(attributeName_id, addShipmentObjects.FreightDesp_FirstItem_Height_Id, "value"), "11");
        }
        
        [Then(@"Length,Width,Height,Dimension Type fields should be blank on Add Shipment \(LTL\) page")]
        public void ThenLengthWidthHeightDimensionTypeFieldsShouldBeBlankOnAddShipmentLTLPage()
        {
            Report.WriteLine("Length,Width,Height,Dimension Type fields should be autopopulated on Add Shipment LTL page");
            GlobalVariables.webDriver.WaitForPageLoad();
            Assert.AreEqual(GetValue(attributeName_id, addShipmentObjects.FreightDesp_FirstItem_Length_Id, "value"), "");
            Assert.AreEqual(GetValue(attributeName_id, addShipmentObjects.FreightDesp_FirstItem_Width_Id, "value"), "");
            Assert.AreEqual(GetValue(attributeName_id, addShipmentObjects.FreightDesp_FirstItem_Height_Id, "value"), "");
        }


        [Then(@"Length,Width,Height,Dimension Type fields should be autopopulated on Add Shipment \(LTL\) page which are default item values from quote")]
        public void ThenLengthWidthHeightDimensionTypeFieldsShouldBeAutopopulatedOnAddShipmentLTLPageWhichAreDefaultItemValuesFromQuote()
        {
            Report.WriteLine("Length,Width,Height,Dimension Type fields should be autopoulated on Add Shipment LTL page");
            GlobalVariables.webDriver.WaitForPageLoad();
            MoveToElement(attributeName_id, addShipmentObjects.FreightDesp_FirstItem_Length_Id);
            Assert.AreEqual(GetValue(attributeName_id, addShipmentObjects.FreightDesp_FirstItem_Length_Id, "value"),"");
            Assert.AreEqual(GetValue(attributeName_id, addShipmentObjects.FreightDesp_FirstItem_Width_Id, "value"), "");
            Assert.AreEqual(GetValue(attributeName_id, addShipmentObjects.FreightDesp_FirstItem_Height_Id, "value"), "");
        }

 

        [Then(@"Length,Width,Height,Dimension Type fields should be autopopulated on Add Shipment \(LTL\) page which are saved item values from quote")]
        public void ThenLengthWidthHeightDimensionTypeFieldsShouldBeAutopopulatedOnAddShipmentLTLPageWhichAreSavedItemValuesFromQuote()
        {
            Report.WriteLine("Length,Width,Height,Dimension Type fields should be autopoulated on Add Shipment LTL page");
            GlobalVariables.webDriver.WaitForPageLoad();
            MoveToElement(attributeName_id, addShipmentObjects.FreightDesp_FirstItem_Length_Id);
            Item itemDetails = DBHelper.GetItem("ZZZ - Czar Customer Test", "TEST-HAZARDOUS");
            Assert.AreEqual(Gettext(attributeName_id, addShipmentObjects.FreightDesp_FirstItem_Length_Id), itemDetails.Length);
            Assert.AreEqual(Gettext(attributeName_id, addShipmentObjects.FreightDesp_FirstItem_Width_Id), itemDetails.Width);
            Assert.AreEqual(Gettext(attributeName_id, addShipmentObjects.FreightDesp_FirstItem_Height_Id), itemDetails.Height);
        }

    }
}
