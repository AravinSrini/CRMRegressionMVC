using System;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Threading;
using System.Configuration;

namespace CRM.UITest
{
    [Binding]
    public class PrintShippingLabelsSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();

        [Given(@"I am a shp\.entry, shp\.entrynorates, operations, sales, sales management, or station owner user")]
        public void GivenIAmAShp_EntryShp_EntrynoratesOperationsSalesSalesManagementOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [Given(@"I am on the Shipment Confirmation \(LTL\) page  (.*), (.*), (.*),(.*), (.*), (.*),(.*),(.*),(.*), (.*),(.*), (.*), (.*),(.*), (.*), (.*), (.*)")]
        public void GivenIAmOnTheShipmentConfirmationLTLPage(string Usertype,
            string oAdd2,
            string oZip,
            string oName,
            string oAdd1,
            string dAdd2,
            string dName,
            string dAdd1,
            string Customer_Name,
            string oComments,
            string dComments,
            string dZip,
            string classification,
            string nmfc,
            string quantity,
            string weight,
            string desc)
        {
            //Navigate
            //Click(attributeName_id, "btn_ltl");
            ltl.NaviagteToShipmentList();
            ltl.SelectCustomerFromShipmentList(Usertype, Customer_Name);

            //Enter shipment information
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            ltl.AddShipmentOriginData(oName, oAdd1, oZip);
            ltl.AddShipmentDestinationData(dName, dAdd1, dZip);
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            ltl.AddShipmentFreightDescription(classification, nmfc, quantity, weight, desc);
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, quantity); //Entering Insured value

            //added to click on view rate button
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            //Results page Create Shipment button Click
            ltl.ClickOnCreateShipmentButton(Usertype);
            GlobalVariables.webDriver.WaitForPageLoad();
            //Navigation to Review and Submit page and Click on Submit button
            ltl.ReviewAndSubmit_ClickOnSubmitShipmentButton();
        }

        [Given(@"I clicked on the drop down arrow of the Print Shipping Labels button")]
        public void GivenIClickedOnTheDropDownArrowOfThePrintShippingLabelsButton()
        {
            ScenarioContext.Current.Pending();
        }


        [When(@"I click on the drop down arrow of the Print Shipping Labels button (.*)")]
        public void WhenIClickOnTheDropDownArrowOfThePrintShippingLabelsButton(string UserType)
        {
            scrollElementIntoView(attributeName_xpath, confirmation_viewshipmentdetailsbutton);
            if (UserType == "External")
            {
                Click(attributeName_xpath, Confirmation_PrintShippingLabel_button);
            }else
            {
                Click(attributeName_xpath, Confirmation_PrintShippingLabelInternalUser_button);
            }
        }

        [When(@"I click on the drop down arrow of the Print Shipping Labels button")]
        public void WhenIClickOnTheDropDownArrowOfThePrintShippingLabelsButton()
        {
            
        }

        [When(@"I make any selection from the drop down list (.*)")]
        public void WhenIMakeAnySelectionFromTheDropDownList(string LableName)
        {

            if (LableName == "Full Page Label")
            {
                Click(attributeName_id, ReviewSubmit_Full_Page_Lable_Id);
            }
            else if (LableName == "2 Labels Per Page")
            {
                Click(attributeName_id, ReviewSubmit_2Label_Par_Page_Id);
            }
            else if (LableName == "4 Labels Per Page")
            {
                Click(attributeName_id, ReviewSubmit_4Label_Par_Page_Id);
            }
            else if (LableName == "6 Labels Per Page")
            {
                Click(attributeName_id, ReviewSubmit_6Label_Par_Page_Id);
            }
        }



        [Then(@"I will have four options Full Page Label,two Labels Per Page,four Labels Per Page,six Labels Per Page")]
        public void ThenIWillHaveFourOptionsFullPageLabelTwoLabelsPerPageFourLabelsPerPageSixLabelsPerPage()
        {
            VerifyElementVisible(attributeName_id, ReviewSubmit_Full_Page_Lable_Id, "Full Page Label");
            VerifyElementVisible(attributeName_id, ReviewSubmit_2Label_Par_Page_Id, "2 Labels Per Page");
            VerifyElementVisible(attributeName_id, ReviewSubmit_4Label_Par_Page_Id, "4 Labels Per Page");
            VerifyElementVisible(attributeName_id, ReviewSubmit_6Label_Par_Page_Id, "6 Labels Per Page");
        }

        [Then(@"a new tab will open in CRM")]
        public void ThenANewTabWillOpenInCRM()
        {
            Report.WriteLine("User is navigated to the Mercury Gate Login page");
          
            bool n=WindowHandling("http://dlsww-test.rrd.com//Shipment/ViewShipmentLabelsDocument?referenceNumber=");
            string expectedURL = GetURL();
            expectedURL.Contains("http://dlsww-test.rrd.com//Shipment/ViewShipmentLabelsDocument?referenceNumber=");
        }

        [Then(@"the shipping label\(s\) will be displayed\.")]
        public void ThenTheShippingLabelSWillBeDisplayed_()
        {
            //Need to debug code
            string downloadpath = GetDownloadedFilePath("PrintRRDonnelleyShipmentSummary-ZZX00206601.pdf");
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(downloadpath))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }

            }

            bool result = text.ToString().Contains("Pass value need to verify");
        }
    }
}
