using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_ReturnShipment
{
    [Binding]
    public sealed class _45792_ShipmentList_ReturnShipment_DoesNotBringProNumber : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        string reference1ProNumber, reference2ProNumber, reference3ProNumber;


        //[BeforeScenario]
        //public static void CreateTestingShipment()
        //{
        //    CreateShipment1Pro();
        //    CreateShipment2Pro();
        //    CreateShipment3Pro();
        //}

        [Given(@"I am a ship entry, ship entry no rates, sales, sales management, operations, or station owner user with a valid ""(.*)"" ""(.*)""")]
        public void GivenIAmAShipEntryShipEntryNoRatesSalesSalesManagementOperationsOrStationOwnerUserWithAValidPassword_Currentsprintshpentry(string user, string pass)
        {
            string username = ConfigurationManager.AppSettings[user].ToString();
            string password = ConfigurationManager.AppSettings[pass].ToString();
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I click the Return Shipment button on a shipment")]
        public void GivenIClickTheReturnShipmentButtonOnAShipment()
        {
            int shipmentlist = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (shipmentlist > 1)
            {
                Click(attributeName_xpath, ShipmentListGrid_RetrunShipmentIcon_First_Xpath);
            }
            else
            {
                Report.WriteLine("No shipments found");
                Assert.Fail();
            }
        }

        [Given(@"I click the Return Shipment button on a shipment (.*)")]
        public void GivenIClickTheReturnShipmentButtonOnAShipment(string refNumber)
        {
            Report.WriteLine("Searching for reference number " + refNumber);
            SendKeys(attributeName_id, "txtReferenceNumer", refNumber);
            Report.WriteLine("Clicking on the search button");
            Click(attributeName_cssselector, ShipmentList_ReferenceSearchButton_Selector);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicking on the return shipment button");
            Click(attributeName_xpath , "//*[@id='ShipmentGrid']/tbody/tr/td[8]/a[3]");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I click on the edit shipment button (.*)")]
        public void WhenIClickOnTheEditShipmentButton(string proNumberCount)
        {
            string refNumber = string.Empty;

            if(proNumberCount.Equals("1"))
            {
                refNumber = reference1ProNumber;
            }
            if (proNumberCount.Equals("2"))
            {
                refNumber = reference2ProNumber;
            }
            if (proNumberCount.Equals("3"))
            {
                refNumber = reference3ProNumber;
            }

            Report.WriteLine("Searching for reference number " + refNumber);
            SendKeys(attributeName_id, "txtReferenceNumer", refNumber);
            Report.WriteLine("Clicking on the search button");
            Click(attributeName_cssselector, ShipmentList_ReferenceSearchButton_Selector);
            Report.WriteLine("Clicking on the edit shipment button");
            WaitForElementVisible(attributeName_cssselector, ShipmentList_EditShipmentButton_Selector, "Edit shipment button");
            Thread.Sleep(1000);
            Click(attributeName_cssselector, "#ShipmentGrid > tbody > tr > td.all.RatesColumn > button");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"the PRO NUMBER field will be blank")]
        public void ThenThePRONUMBERFieldWillBeBlank()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Verifying the ProNumber field is blank");
            string proNumberField = GetValue(attributeName_id, ReferenceNumbers_PRONumber_Id, "value");
            Assert.AreEqual("", proNumberField);
        }

        [Then(@"the PRO NUMBER field will be filled in with ""(.*)""")]
        public void ThenThePRONUMBERFieldWillBeFilledInWith(string PRONumber)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Verifying the ProNumber field is blank");
            string proNumberField = GetValue(attributeName_id, ReferenceNumbers_PRONumber_Id, "value");
            Assert.AreEqual(PRONumber, proNumberField);
        }

        [Then(@"the PRO NUMBER field and additional reference field will be filled in with (.*) (.*) (.*)")]
        public void ThenThePRONUMBERFieldAndAdditionalReferenceFieldsWillBeFilledInWith(string PRONumber1, string PRONumber2, string PRONumber3)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Verifying the ProNumber field is blank");
            string proNumberField = GetValue(attributeName_id, ReferenceNumbers_PRONumber_Id, "value");
            Assert.AreEqual(PRONumber1, proNumberField);

            var additionalItemRows = GlobalVariables.webDriver.FindElements(By.XPath("//div[contains(@class, 'additional-reference')]"));
            string additionalProNumber = string.Empty;
            foreach (var row in additionalItemRows)
            {
                if(row.Text.Contains("Pro Number"))
                {
                    int rowNumber = int.Parse(row.GetAttribute("id"));
                    additionalProNumber = GetValue(attributeName_id, "ltl-reference-num-" + rowNumber, "value");
                    if(additionalProNumber.Equals(PRONumber2))
                    {
                        Assert.AreEqual(PRONumber2, additionalProNumber);
                    }
                    else if( additionalProNumber.Equals(PRONumber3))
                    {
                        Assert.AreEqual(PRONumber3, additionalProNumber);
                    }
                }
            }
        }

        public void CreateShipment1Pro()
        {
            LogIn();
            NavigateToAddShipment();
            AddShipmentInfo();

            AddFirstReferenceNumber();
            
            CreateShipment();
            reference1ProNumber = GlobalVariables.webDriver.FindElement(By.Id("ref-num-label")).Text;
        }

        public void CreateShipment2Pro()
        {
            LogIn();
            NavigateToAddShipment();
            AddShipmentInfo();
            
            AddFirstReferenceNumber();
            AddSecondReferenceNumber();

            CreateShipment();

            reference2ProNumber = GlobalVariables.webDriver.FindElement(By.Id("ref-num-label")).Text;
        }

        public void CreateShipment3Pro()
        {
            LogIn();
            NavigateToAddShipment();
            AddShipmentInfo();

            AddFirstReferenceNumber();
            AddSecondReferenceNumber();
            AddThirdReferenceNumber();            

            CreateShipment();

            reference3ProNumber = GlobalVariables.webDriver.FindElement(By.Id("ref-num-label")).Text;
        }

        public void AddFirstReferenceNumber()
        {
            Report.WriteLine("Adding Reference number");
            Click(attributeName_xpath, ReferenceNum_section_Xpath);
            SendKeys(attributeName_xpath, ReferenceNumbers_PRONumber_Id, "4923716081");
        }
        public void AddSecondReferenceNumber()
        {
            Report.WriteLine("Adding second Reference number");
            Click(attributeName_xpath, AddAdditionalReference_Button_xpath);
            Click(attributeName_xpath, Additional_SelectReferenceType_DropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, Additional_SelectReferenceType_DropDown_xpath, "Pro Number");
            SendKeys(attributeName_xpath, AdditionalReferenceNumber_Value_xpath, "987654");
        }
        public void AddThirdReferenceNumber()
        {
            Report.WriteLine("Adding third reference number");
            Click(attributeName_xpath, AddAdditionalReference_Button_xpath);
            Click(attributeName_xpath, "//*[@id='ltl_reference_type_select_2_chosen']/a");
            SelectDropdownValueFromList(attributeName_xpath, "//*[@id='ltl_reference_type_select_2_chosen']/a", "Pro Number");
            SendKeys(attributeName_xpath, "//*[@id='ltl-reference-num-2']", "654321");
        }

        public void LogIn()
        {
            string username = ConfigurationManager.AppSettings["username-Currentsprintoperations"].ToString();
            string password = ConfigurationManager.AppSettings["password-Currentsprintoperations"].ToString();
            crm.LoginToCRMApplication(username, password);
        }
        public void NavigateToAddShipment()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicking on shipment icon");
            Click(attributeName_xpath, ShipmentModule_Xpath);

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on Shipments icon");
            Click(attributeName_id, ShipmentIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, "NinjaCustomer");
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Clicked on Add Shipment button");
            WaitForElementVisible(attributeName_id, AddShipment_Button_id, "Add shipment button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, AddShipment_Button_id);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Clicked on LTL tile");
            Click(attributeName_id, AddShipmentLTL_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        public void AddShipmentInfo()
        {
            Report.WriteLine("Shipment From section");
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "Chicago");
            Thread.Sleep(500);
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "Chicago");
            Thread.Sleep(500);
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, "60606");
            Thread.Sleep(500);

            Report.WriteLine("Shipment To section");
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, "Beverly Hills");
            Thread.Sleep(500);
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "Beverly Hills");
            Thread.Sleep(500);
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, "90210");
            Thread.Sleep(500);

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Writing information to freight description section");
            Thread.Sleep(500);
            SendKeys(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "50");
            Thread.Sleep(500);
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "1");
            Thread.Sleep(500);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "1");
            Thread.Sleep(500);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, "1");
            Thread.Sleep(500);
        }

        public void CreateShipment()
        {
            Report.WriteLine("Viewing rates");
            Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Creating Shipment");
            Click(attributeName_xpath, "//*[@id='createShipment']");
            Click(attributeName_xpath, ShipResultsModalWithoutInsuredRates_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ReviewAndSubmit_SubmitShipment_button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
    }

}
