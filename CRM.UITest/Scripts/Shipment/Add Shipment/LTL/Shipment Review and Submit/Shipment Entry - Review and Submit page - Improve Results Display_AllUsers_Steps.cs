using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;


namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Review_and_Submit
{
    [Binding]
    public class Shipment_Entry___Review_and_Submit_page___Improve_Results_Display_AllUsers_Steps : AddShipments
    {
        string userType = "External";
        string username = "both";
        string originName = "test";
        string originAddress = "originAddr1";
        string originZip = "33126";
        string destinationName = "destinationName";
        string destinationAddress = "destinationAddr1";
        string destinationZip = "33126";
        string classification = "50";
        string nfsc = "123";
        string quantity = "1";
        string weight = "1";
        string description = "itemdesc";

        String carrierNameResultsPage = null;


        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();

       

        

        [Given(@"I am a  shp\.entry, operations, sales, sales management, or station owner user")]
        public void GivenIAmAShp_EntryOperationsSalesSalesManagementOrStationOwnerUser()
        {
            string Username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string Password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();

            CrmLogin.LoginToCRMApplication(Username, Password);
        }


        [Given(@"I am creating an LTL shipment,")]
        public void GivenIAmCreatingAnLTLShipment()
        {
            DefineTimeOut(60000);
            ltl.NaviagteToShipmentList();
            ltl.SelectCustomerFromShipmentList(userType, username);
            //scrollElementIntoView(attributeName_id, "shipment-1");
            //Click(attributeName_id, "shipment-1");
            //Click(attributeName_id, "createShipment");
            GlobalVariables.webDriver.WaitForPageLoad();
            ltl.AddShipmentOriginData(originName, originAddress, originZip);
            
            ltl.AddShipmentDestinationData(destinationName, destinationAddress, destinationZip);
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            ltl.AddShipmentFreightDescription(classification, nfsc, quantity, weight, description);
            //SendKeys(attributeName_id, InsuredValue_TextBox_Id, "1");

            //Click on ViewRates button
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();

            GlobalVariables.webDriver.WaitForPageLoad();

            bool NoShipmentsAvailable_text = IsElementPresent(attributeName_xpath, "//*[text()='There are no rates available for this shipment.']", "There are no rates  available for this shipment");
            if (NoShipmentsAvailable_text == false)
            {

                IList<IWebElement> carrierOnUI = GlobalVariables.webDriver.FindElements(By.XPath("//table[@id='ShipmentResultTable']/tbody/tr/td[1]"));
                for (int i = 1; i <= carrierOnUI.Count; i++)
                {
                    string carrierUI = GlobalVariables.webDriver.FindElement(By.XPath("//table[@id='ShipmentResultTable']/tbody/tr[" +  i  + "]/td[1]")).Text;
                    if (carrierUI.Contains("Carrier's legal liability per lb if uninsured"))
                        if (carrierUI.Contains("Carrier's max liability if uninsured"))
                        {
                           
                            carrierNameResultsPage= Gettext(attributeName_xpath, "//*//table[@id='ShipmentResultTable']/tbody/tr["+ i +"]//*[@class='col-md-12 carrier-name-col boldText']");
                            scrollElementIntoView(attributeName_xpath, "//*//table[@id='ShipmentResultTable']/tbody/tr[" + i + "]//*[@class='col-md-12 carrier-name-col boldText']");
                            Click(attributeName_xpath, "//*[@id='ShipmentResultTable']/tbody/tr["+i+"]/td[4]/div/button");
                            break;
                        }
                }

            }
            else
            {
                Report.WriteLine("No Carrier is avaiable");
                throw new Exception("No Carrier is avaiable");
            }
        }


        [When(@"I arrive on the Review and Submit \(LTL\) page")]
        public void WhenIArriveOnTheReviewAndSubmitLTLPage()
        {
            Report.WriteLine("Verifying reveiw and submit page");
            Verifytext(attributeName_xpath, AddShipmentReviewAndSubmitPage_Xpath, "Review and Submit Shipment (LTL)");
        }

        [Then(@"The carrier logos will be displayed in carrier info section on Review and Submit page")]
        public void ThenTheCarrierLogosWillBeDisplayedInCarrierInfoSectionOnReviewAndSubmitPage()
        {
            scrollElementIntoView(attributeName_xpath, ReviewAndSubmit_SubmitShipment_button_Xpath);
            Report.WriteLine("Verifying Carrier logo is presence in carrier info section on Review and Submit page");
            GlobalVariables.webDriver.WaitForPageLoad();
            IWebElement ImageFile = GlobalVariables.webDriver.FindElement(By.XPath("//img[@id='carrierlogo']"));
            IJavaScriptExecutor js = GlobalVariables.webDriver as IJavaScriptExecutor;

            Boolean ImagePresent = (Boolean)((js.ExecuteScript("return arguments[0].complete && typeof arguments[0].naturalWidth != \"undefined\" && arguments[0].naturalWidth > 0", ImageFile)));
            if (!ImagePresent)
            {
                Console.WriteLine("Image not displayed.");
            }
            else
            {
                Console.WriteLine("Image displayed.");
            }
        }


        [Then(@"The carrier name will be displayed in carrier info section on Review and Submit page")]
        public void ThenTheCarrierNameWillBeDisplayedInCarrierInfoSectionOnReviewAndSubmitPage()
        {
            Report.WriteLine("Verifying carrier name displayed in carrier info section on Review and Submit page");
            Verifytext(attributeName_xpath, "//span[@class='carriernametxt']", carrierNameResultsPage);
        }

        [Then(@"The carrier legal liability verbiage will read: Carrier's legal liability per lb if uninsured")]
        public void ThenTheCarrierLegalLiabilityVerbiageWillReadCarrierSLegalLiabilityPerLbIfUninsured()
        {
            Report.WriteLine("Verifying carrier legal liability verbiage will read: Carrier's legal liability per lb if uninsured");
            Verifytext(attributeName_xpath, "//span[@class='max_label_costperpound']", "Carrier's legal liability per lb if uninsured");
        }



        [Then(@"carrier max liability verbiage will read: Carrier's max liability if uninsured")]
        public void ThenCarrierMaxLiabilityVerbiageWillReadCarrierSMaxLiabilityIfUninsured()
        {
            Report.WriteLine("Verifying carrier max liability verbiage will read: Carrier's max liability if uninsured");
            Verifytext(attributeName_xpath, "//span[@class='max_label']", "Carrier's max liability if uninsured");
        }


        [Then(@"The text color of the carrier liability information will be black")]
        public void ThenTheTextColorOfTheCarrierLiabilityInformationWillBeBlack()
        {
            string color = GetCSSValue(attributeName_xpath, "", "carrier liability");
            Assert.Equals("", "FFFFFF");
        }

        [Then(@"The service days will display days text in service days column")]
        public void ThenTheServiceDaysWillDisplayDaysTextInServiceDaysColumn()
        {
           
            Report.WriteLine("Verifying The service days will display days text in service days column");
            string daysTexteUI = Gettext(attributeName_xpath, "//div[@class='lineadjustment estimatedservicedays margintopline']");
            if (daysTexteUI.Contains("days"))
            {
                Report.WriteLine("display days text in service days column");
            }
            else
            {
                Report.WriteLine("Not displaying days text in service days column");
                throw new Exception("Not displaying days text in service days column'");
            }
        }

        [Then(@"The verbiage (.*) will be displayed as (.*)")]
        public void ThenTheVerbiageWillBeDisplayedAs(string p0, string p1)
        {
            string verbiageDirectIndirect = Gettext(attributeName_xpath, "//span[@class='lineadjustment servicelane']");
            if (verbiageDirectIndirect == "Direct")
            {
                Report.WriteLine("Verifying Direct verbiage");
                Verifytext(attributeName_xpath, "//span[@class='lineadjustment servicelane']", "Direct");
            }
            else if(verbiageDirectIndirect == "Indirect")
            {
                Report.WriteLine("Verifying Indirect verbiage");
                Verifytext(attributeName_xpath, "//span[@class='lineadjustment servicelane']", "Indirect");
            }
            else
            {
                Report.WriteLine("The verbiage is wrong");
                throw new Exception("The verbiage is wrong");
            }
        }


      

        [Then(@"The Distance value will be displayed as a whole number (.*)")]
        public void ThenTheDistanceValueWillBeDisplayedAsAWholeNumber(string p0)
        {
            string distancevalueUI=Gettext(attributeName_xpath, "//div[@class='lineadjustment Distanceestimated margintopline']");
            if (distancevalueUI.Contains("miles"))
            {
                Report.WriteLine("Distance value will be displayed as a whole number");
            }
            else
            {
                Report.WriteLine("he Distance value does not contain 'miles");
                throw new Exception("The Distance value does not contain 'miles'");
            }
        }


        [Then(@"The currency values and formatting associated to New and Used will be consistent")]
        public void ThenTheCurrencyValuesAndFormattingAssociatedToNewAndUsedWillBeConsistent()
        {
            Report.WriteLine("verifying the currency values and formatting associated to New and Used will be consistent");
            string carrierLegalNewValueUI = Gettext(attributeName_xpath, "//span[@class='maximumNewCostPerPound']");
            matchCurrency(carrierLegalNewValueUI);

            string carrierLegalUsedValueUI = Gettext(attributeName_xpath, "//span[@class='maximumUsedCostPerPound usedmarginleft']");
            matchCurrency(carrierLegalUsedValueUI);

            string carrierMaxNewValueUI = Gettext(attributeName_xpath, "//span[@class='maximumliabilitynew']");
            matchCurrency(carrierMaxNewValueUI);

            string carrierMaxUsedValueUI = Gettext(attributeName_xpath, "//span[@class='maximumliabilityused usedmarginleft']");
            matchCurrency(carrierMaxUsedValueUI);

        }

        public static void matchCurrency(string currencyInUI)
        {
            Regex rgx = new Regex("[^0-9.$]");
            string currency = rgx.Replace(currencyInUI, "");
            string s = currency.Substring(0, 1);
            if (s.Equals("$"))
            {
                if (currency.Contains(".")){
                    string[] decimals = currency.Split('.');
                    int decimalvalue = decimals[1].Length;
                    if (decimalvalue == 2)
                    {
                        Report.WriteLine("Original Amount is have two decimal places");
                    }
                    else
                    {
                        Report.WriteLine("Currenly is not in correct format");
                        throw new Exception("Currenly is not in correct format");
                    }
                }

            }

            else
            {
                Report.WriteLine("Original Amount is not in Format");
                throw new Exception("Original Amount is not in Format");
            }
        }

        
    }
}
