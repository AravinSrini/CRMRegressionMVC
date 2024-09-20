using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.AvailableLoadsXML;
using System.Xml.Linq;
using System.Collections.Generic;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.CommonMethods;
using OpenQA.Selenium;
using CRM.UITest.Entities;

namespace CRM.UITest.Scripts.Availabe_Loads_Board
{
    [Binding]
    public class _95866_CreateFeatureFile_AvailableLoads_UpdateEmailModalSteps : LoadsBoard
    {
        string uri = null;
        string errormessage;
        List<AvailableLoadsViewModel> availableModel;
        IList<IWebElement> refValues;
        List<string> refValuesUI;
        string emailFromDB = null;
        string emailFromUI = string.Empty;
        string carrierSCAC = string.Empty;

        [When(@"I click on the email button of any displayed load from the grid (.*)")]
        public void WhenIClickOnTheEmailButtonOfAnyDisplayedLoadFromTheGrid(string reference)
        {
            ListScreenExtractResponseFromMGForAvailableLoads();
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, availableLoadsTitle_xpath, "Available Loads");
            Report.WriteLine("Available loads page loaded");
            SelectByVisibleText(attributeName_xpath, topViewOption_Xpath, "ALL");
            GlobalVariables.webDriver.WaitForPageLoad();
            refValues = GlobalVariables.webDriver.FindElements(By.XPath(refColumnValues_xpath));
            refValuesUI = new List<string>();
            foreach (var refValueList in refValues)
            {
                refValuesUI.Add(refValueList.Text);
            }
            for (int i = 0; i < refValues.Count; i++)
            {
                if (refValuesUI[i]==reference)
                {
                    scrollpagedown();
                    Click(attributeName_xpath, "//tr[" + (i + 1) + "]/td[12]");
                    Report.WriteLine("Email modal clicked");                
                }

                if (availableModel[i].PrimaryReference == reference)
                {
                    carrierSCAC = availableModel[i].CarrierSCAC;                   
                }
            }


        }
    
      
        [When(@"corresponding station is not available for load in CRM")]
        public void WhenCorrespondingStationIsNotAvailableForLoadInCRM()
        {
            Report.WriteLine("Verifying the email from DB");
            emailFromDB = DBHelper.GetToEmail(carrierSCAC);
        }
        
        [Then(@"the To will display the value from Available Load Email of the associated station details")]
        public void ThenTheToWillDisplayTheValueFromAvailableLoadEmailOfTheAssociatedStationDetails()
        {
           
            Report.WriteLine("Verifying the display of To email text box");
            VerifyElementVisible(attributeName_id, firstRowEmail_To_id, "To email textbox");
            VerifyElementNotEnabled(attributeName_id, firstRowEmail_To_id, "To email textbox");
            Report.WriteLine("To email text box is not editable");
            emailFromUI = GetValue(attributeName_id, firstRowEmail_To_id, "value");
            Report.WriteLine("Verifying the To email with UI");
            emailFromDB = DBHelper.GetToEmail(carrierSCAC);
            if (emailFromDB != null)
            {
                Assert.AreEqual(emailFromDB, emailFromUI);
                Report.WriteLine("Displaying To email in UI " + emailFromUI + " is matching with DB To email " + emailFromDB);
            }

        }

        [Then(@"the To field will be empty")]
        public void ThenTheToFieldWillBeEmpty()
        {
            Report.WriteLine("Verifying the To email with UI");
            if (emailFromDB == null)
            {
                emailFromUI = GetValue(attributeName_id, firstRowEmail_To_id, "value");
                if (emailFromUI == "")
                {
                    Report.WriteLine("corresponding station to a Load is not available in CRM " + carrierSCAC);
                }
            }
        }

        
        
        [Then(@"the Send button is inactive")]
        public void ThenTheSendButtonIsInactive()
        {
            Report.WriteLine("Verifying the send button");
            VerifyElementVisible(attributeName_id, firstRowEmail_SendButton_id, "Send Button");
            VerifyElementNotEnabled(attributeName_id, firstRowEmail_SendButton_id, "Send Button");
            Report.WriteLine("Send button is inactive");

        }

        public void ListScreenExtractResponseFromMGForAvailableLoads()
        {
            uri = $"MercuryGate/ListScreenExtract";

            //Building Request XML 
            AvailableLoadsRequestXml req = new AvailableLoadsRequestXml();
            XElement reqXML = req.GetAvailableLoadsRequestXml();

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("DLS Worldwide", "application/xml");

            AvailableLoadsResponseXML aXML = new AvailableLoadsResponseXML();
            availableModel = aXML.ResponseXml(uri, headers, reqXML, out errormessage);
            Report.WriteLine("Response from MG");
        }
    }
}
