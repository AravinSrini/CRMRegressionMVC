using System;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using System;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.Service.GenericService;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Threading;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Confirmation_Screen__All_Users
{
    [Binding]
    public class HideShipmentsReferenceNumber_URLChangeSteps : AddShipments
    {
        public string configUrl = null;
        public string refereneNo;
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();

        [Then(@"the BOL number will not be displayed in the URL details page")]
        public void ThenTheBOLNumberWillNotBeDisplayedInTheURLDetailsPage()
        {
            configUrl = launchUrl;
            string expectedURL = GetURL();
            expectedURL.Contains(configUrl + "L/Shipment/ShipmentDetails?tmsType=MG");
            if (expectedURL.Contains(refereneNo))
            {
                Assert.Fail();
                Report.WriteLine("Shipment details URL contains reference number");
            }
            else
            {
                Report.WriteLine("Shipment details URL does not contains reference number");
            }
        }

        [Then(@"BOL number will not be displayed in the URL of Print Shiipping Label")]
        public void ThenBOLNumberWillNotBeDisplayedInTheURLOfPrintShiippingLabel()
        {
            configUrl = launchUrl;
            Report.WriteLine("User is navigated to the Mercury Gate Login page");
            Thread.Sleep(2000);
            bool n = WindowHandling(configUrl + "Shipment/ViewShipmentLabelsDocument?labelType=FullPageLabel&tmsType=MG");
            string expectedURL = GetURL();
            if (expectedURL.Contains(refereneNo))
            {
                Assert.Fail();
                Report.WriteLine("Shipment details URL contains reference number");
            }
            else
            {
                Report.WriteLine("Shipment details URL does not contains reference number");
            }

        }


        [Then(@"verify the error warning when I enter the reference number in the URL")]
        public void ThenVerifyTheErrorWarningWhenIEnterTheReferenceNumberInTheURL()
        {
            configUrl = launchUrl;
            Report.WriteLine("User is navigated to the Mercury Gate Login page");
            Thread.Sleep(2000);
            bool n = WindowHandling(configUrl + "L/Shipment/ShipmentDetails?tmsType=MG");
            string expectedURL = GetURL();
            if (expectedURL.Contains(refereneNo))
            {
                Assert.Fail();
                Report.WriteLine("Shipment details URL contains reference number");
            }
            else
            {
                Report.WriteLine("Shipment details URL does not contains reference number");
            }

            //expectedURL.Contains(configUrl+"L/Shipment/ShipmentDetails?tmsType=MG");
        }




        //[When(@"I select View Bill of Landing option")]
        //public void WhenISelectViewBillOfLandingOption()
        //{
        //    Report.WriteLine("Clicking on Bill of Landing option");
        //    Thread.Sleep(2000);
        //    Click(attributeName_id, ViewBillOfLandining_Option_Id);

        //}

        [Then(@"the BOL number will not be displayed in the URL shipment summary page")]
        public void ThenTheBOLNumberWillNotBeDisplayedInTheURLShipmentSummaryPage()
        {
            configUrl = launchUrl;
            Report.WriteLine("User is navigated to the Mercury Gate Login page");
            Thread.Sleep(2000);
            bool n = WindowHandling(configUrl + "Shipment/ViewShipmentSummary?");
            string expectedURL = GetURL();
            //expectedURL.Contains(configUrl+"Shipment/ViewShipmentSummary?");
            if (expectedURL.Contains(refereneNo))
            {
                Assert.Fail();
                Report.WriteLine("Shipment details URL contains reference number");
            }
            else
            {
                Report.WriteLine("Shipment details URL does not contains reference number");
            }

        }

        [Then(@"the BOL number will not be displayed in the URL of View Bill Of Landing page")]
        public void ThenTheBOLNumberWillNotBeDisplayedInTheURLOfViewBillOfLandingPage()
        {
            configUrl = launchUrl;
            Report.WriteLine("User is navigated to the Mercury Gate Login page");
            Thread.Sleep(2000);
            bool n = WindowHandling(configUrl + "Shipment/ViewBol");
            string expectedURL = GetURL();
            if (expectedURL.Contains(refereneNo))
            {
                Assert.Fail();
                Report.WriteLine("Shipment details URL contains reference number");
            }
            else
            {
                Report.WriteLine("Shipment details URL does not contains reference number");
            }

        }


        [When(@"I click on the drop down arrow of the View shipment Summary button and select View Shipment Summary button")]
        public void WhenIClickOnTheDropDownArrowOfTheViewShipmentSummaryButtonAndSelectViewShipmentSummaryButton()
        {
            scrollpagedown();
            refereneNo = Gettext(attributeName_xpath, confirmation_BOLValue_Xpath);
            Click(attributeName_id, "shipSummaryBtnDiv");
            Click(attributeName_xpath, ".//*[@id='btn_ViewShipSummary']");
        }


        [When(@"I click on the View Shipment Coverage button on the Shipment Confirmation page")]
        public void WhenIClickOnTheViewShipmentCoverageButtonOnTheShipmentConfirmationPage()
        {
            refereneNo = Gettext(attributeName_xpath, confirmation_BOLValue_Xpath);
            Click(attributeName_id, confirmation_ViewShipmentCoverageButton_Id);
        }






        [Given(@"I click on the insured shipment and navigate to the Shipment Confirmation \(LTL\) page  (.*), (.*), (.*),(.*), (.*), (.*),(.*),(.*),(.*), (.*),(.*), (.*), (.*),(.*), (.*), (.*), (.*)")]
        public void GivenIClickOnTheInsuredShipmentAndNavigateToTheShipmentConfirmationLTLPage(string Usertype,
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
            try
            {
                Click(attributeName_xpath, ViewRatesButton_xpath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Thread.Sleep(50000);
            }

            //Results page Create Shipment button Click
            ltl.ClickOnCreateInsuredShipmentButton(Usertype);

            //Navigation to Review and Submit page and Click on Submit button
            ltl.ReviewAndSubmit_ClickOnSubmitShipmentButton();
        }

        [When(@"I click on the View Shipment Details button on the confirmation page")]
        public void WhenIClickOnTheViewShipmentDetailsButtonOnTheConfirmationPage()
        {
            refereneNo = Gettext(attributeName_xpath, confirmation_BOLValue_Xpath);

            scrollElementIntoView(attributeName_xpath, confirmation_viewshipmentdetailsbutton);
            try
            {
                Click(attributeName_xpath, confirmation_viewshipmentdetailsbutton);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Thread.Sleep(10000);
            }
        }

        [When(@"I click on the drop down arrow of the Bill of Lading button and select View Bill of Landing option")]
        public void WhenIClickOnTheDropDownArrowOfTheBillOfLadingButtonAndSelectViewBillOfLandingOption()
        {
            refereneNo = Gettext(attributeName_xpath, confirmation_BOLValue_Xpath);
            Report.WriteLine("Click on View BOL option");
            scrollpagedown();
            Click(attributeName_xpath, confirmation_BOLbutton);

            Report.WriteLine("Clicking on Bill of Landing option");
            Thread.Sleep(2000);
            Click(attributeName_xpath, confirmation_ViewBOL_xpath);
        }

        [Then(@"the BOL number will not be displayed in the URL Shipment Coverage page")]
        public void ThenTheBOLNumberWillNotBeDisplayedInTheURLShipmentCoveragePage()
        {
            configUrl = launchUrl;
            bool n = WindowHandling(configUrl + "Shipment/ViewShipmentCoverageDocument?referenceNumber=ZZX00207872");
            string expectedURL = GetURL();
            if (expectedURL.Contains(refereneNo))
            {
                Assert.Fail();
                Report.WriteLine("Shipment details URL contains reference number");
            }
            else
            {
                Report.WriteLine("Shipment details URL does not contains reference number");
            }
        }


        [When(@"I click on the drop down arrow of the Print Shipping Labels (.*) button  and make any selection from the drop down (.*)")]
        public void WhenIClickOnTheDropDownArrowOfThePrintShippingLabelsButtonAndMakeAnySelectionFromTheDropDown(string Usertype, string Label_Name)
        {
            refereneNo = Gettext(attributeName_xpath, confirmation_BOLValue_Xpath);

            scrollElementIntoView(attributeName_xpath, confirmation_viewshipmentdetailsbutton);
            if (Usertype == "External")
            {
                Click(attributeName_xpath, Confirmation_PrintShippingLabel_button);
            }
            else
            {
                Click(attributeName_xpath, Confirmation_PrintShippingLabelInternalUser_button);
            }

            if (Label_Name == "Full Page Label")
            {
                Click(attributeName_id, ReviewSubmit_Full_Page_Lable_Id);
            }
            else if (Label_Name == "2 Labels Per Page")
            {
                Click(attributeName_id, ReviewSubmit_2Label_Par_Page_Id);
            }
            else if (Label_Name == "4 Labels Per Page")
            {
                Click(attributeName_id, ReviewSubmit_4Label_Par_Page_Id);
            }
            else if (Label_Name == "6 Labels Per Page")
            {
                Click(attributeName_id, ReviewSubmit_6Label_Par_Page_Id);
            }
        }








    }
}
