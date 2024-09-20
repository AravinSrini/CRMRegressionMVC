using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class _48500_Shipment_Details_Being_Carried_Forward_btwn_CustomersSteps : AddShipments
    {
        AddShipmentLTL ltl = new AddShipmentLTL();
        CommonMethodsCrm crm = new CommonMethodsCrm();
        public string username1;
        public string username2;
        public string password1;
        public string password2;
        
        public string oName = "JohnShipper";
        public string oAdd1 = "Lakeview Testing Address1";
        public string oZip = "33126";
        public string dName = "JohnConsignee";
        public string dAdd1 = "Honeywekk Testing Address1";
        public string dZip = "85282";
        public string classification = "50";
        public string nmfc = "Test123";
        public string quantity = "6";
        public string weight = "1000";
        public string Itemdesc = "TestItem1";
        public string fromAccessorials1 = "Appointment";
        public string FromComments = "Testing the Shipping From Comments";
        public string toAccessorials1 = "COD";
        public string toComments = "Testing the Shipping To Comments";
        public string fromContactName = "James";
        public string fromContactEmail = "James@test.com";
        public string fromContactFax = "1111111111";
        public string fromContactPhone = "2222222222";

        public string toContactName = "Jerry";
        public string toContactEmail = "Jerry@test.com";
        public string toContactPhone = "3333333333";
        public string toContactFax = "4444444444";
        public string Length = "66";
        public string Width = "67";
        public string Height = "68";
        public string SpecialInstructions = "This is test for Special Instructions";
        public string InsuredValue = "1234";
       
        [Given(@"I navigate to the Shipment List page")]
        public void GivenINavigateToTheShipmentListPage()
        {
            Thread.Sleep(1000);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on the Shipment icon from the left navigation bar");
            WebDriverHelpers.ClickElement(GlobalVariables.webDriver.FindElement(By.XPath(ShipmentIcon_Xpath)));
            Thread.Sleep(1000);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotVisible(attributeName_xpath, LoadingIcon_Xpath, "Loading icon");
            WaitForElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment list title");
            Report.WriteLine("I am on the shipment list page");
            Verifytext(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");          
        }

        [Given(@"I navigate to the Shipment List page for (.*) mapped to (.*)")]
        public void GivenINavigateToTheShipmentListPageForMappedTo(string User1, string Customer1)
        {
            Report.WriteLine("Click on the Shipment icon from the left navigation bar");
            Click(attributeName_xpath, ShipmentIcon_Xpath);

            Report.WriteLine("I am on the shipment list page");
            Verifytext(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
            if (User1.Equals("InternalUser"))
            {
                Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
                SendKeys(attributeName_xpath, ".//*[@id='CustomerType_chosen']/div/div/input", Customer1);
                Click(attributeName_xpath, ".//*[@id='CustomerType_chosen']//ul[@class='chosen-results']/li[2]");
                Report.WriteLine("Customer is chosen");

            }
        }

        [Given(@"I arrive on the Add Shipment LTL page")]
        public void GivenIArriveOnTheAddShipmentLTLPage()
        {
            if (username1.Equals("crmOperation"))
            {
                Click(attributeName_id, AddShipmentButtionInternal_Id);
            }
            else
            {
                Report.WriteLine("I click on the Add shipment Button");
                Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
            }

            Report.WriteLine("Click on LTL option on tiles page");
            Click(attributeName_id, ShipmentList_LTLtile_Id);

            ShipperFromDetails();
            ConsigneeDetails();
            ItemDetails();
            SendKeys(attributeName_id, DefaultSpecialIntructions_Comments_Id, SpecialInstructions);
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, InsuredValue);
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
  
        }

        [Given(@"I click on the (.*) button on Shipment Results page for (.*)")]
        public void GivenIClickOnTheButtonOnShipmentResultsPageFor(string CreateShipment, string User1)
        {
            if (User1.Equals("ExternalUser"))
            {
                string createShipment = Gettext(attributeName_xpath, ShipResults_External_CreateShipButton_xpath);
                if (createShipment != null || createShipment != string.Empty)
                {
                    if (CreateShipment.Equals("StandardRate"))
                    {
                        Click(attributeName_xpath, ShipResults_External_CreateShipButton_xpath);
                    }
                    else
                    {
                        Click(attributeName_xpath, ShipResults_External_CreateInsuredShipButton_xpath);
                    }

                }
                else
                {
                    Click(attributeName_xpath, ShipResults_CreateShipmentWithoutCarrierRate_Button_xpath);

                }
            }
            else
            {
                string createShipment = Gettext(attributeName_xpath, ShipResults_Internal_CreateShipButton_xpath);
                if (createShipment != null || createShipment != string.Empty)
                {
                    if (CreateShipment.Equals("StandardRate"))
                    {
                        Click(attributeName_xpath, ShipResults_Internal_CreateShipButton_xpath);
                    }
                    else
                    {
                        Click(attributeName_xpath, ShipResults_Internal_CreateInsuredShipButton_xpath);
                    }

                }
                else
                {
                    Click(attributeName_xpath, ShipResults_CreateShipmentWithoutCarrierRate_Button_xpath);

                }
            }
 
        }


        public void ShipperFromDetails()
        {
            string _selectedAddress = GetValue(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
               Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            }                        
                ltl.AddShipmentOriginData(oName, oAdd1, oZip);
                Report.WriteLine("Click on Services and Accessorials");
                Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
                SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_Values_xpath, fromAccessorials1);
                SendKeys(attributeName_id, ShippingFrom_Comments_Id, FromComments);

            Report.WriteLine("Passing data in shipping from contact info section");
            SendKeys(attributeName_id, ShippingFrom_ContactName_Id, fromContactName);
            SendKeys(attributeName_id, ShippingFrom_ContactEmail_Id, fromContactEmail);
            SendKeys(attributeName_id, ShippingFrom_ContactFax_Id, fromContactFax);
            SendKeys(attributeName_id, ShippingFrom_ContactPhone_Id, fromContactPhone);

        }

        public void ConsigneeDetails()
        {
            string _selectedAddress = GetValue(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                ScrollToTopElement(attributeName_id, ShippingTo_ClearAddress_Id);
                Click(attributeName_id, ShippingTo_ClearAddress_Id);
            }           
             
                ltl.AddShipmentDestinationData(dName, dAdd1, dZip);

            Report.WriteLine("Click on Services and Accessorials");
            Click(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_Values_xpath, toAccessorials1);
            SendKeys(attributeName_id, ShippingTo_Comments_Id, toComments);

            Report.WriteLine("Passing data in shipping to contact info section");
            SendKeys(attributeName_id, ShippingTo_ContactName_Id, toContactName);
            SendKeys(attributeName_id, ShippingTo_ContactEmail_Id, toContactEmail);
            SendKeys(attributeName_id, ShippingTo_ContactPhone_Id, toContactPhone);
            SendKeys(attributeName_id, ShippingTo_ContactFax_Id, toContactFax);
        }

        public void ItemDetails()
        {
            string _selectedItem = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");

            if (_selectedItem != "" || _selectedItem != string.Empty)
            {
                scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
                Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            }        
            
                Report.WriteLine("Passing data in freight description section");
               
                MoveToElement(attributeName_xpath, FreightDesp_SectionText_xpath);                              
                SendKeys(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, classification);
                SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, nmfc);
                SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, quantity);
                SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, weight);
                SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, Itemdesc);

                SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, Length);
                SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, Width);
                SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, Height);
            
        }

        [Given(@"I Complete the Shipment")]
        public void GivenICompleteTheShipment()
        {
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, ReviewPage_SubmitButton_id);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementPresent(attributeName_xpath, confirmation_pageheader, "Confirmation Page");
        }

        [Given(@"I logout of CRM")]
        public void GivenILogoutOfCRM()
        {
            Click(attributeName_xpath, ".//*[@id='loggedInUserName']/b");
           
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='dv-loginmenu']/ul/li/ul/li"));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "Sign Out")
                {
                    DropDownList[i].Click();
                    break;
                }
            }

        }

       
        [When(@"I selected LTL shipemnt service type from Dashboard to create Shipment")]
        public void WhenISelectedLTLShipemntServiceTypeFromDashboardToCreateShipment()
        {
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, Dashboard_LTLServiceType_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, Dashboard_CreateShipmentButton_Id);

        }

       
        [Given(@"I logged into CRM with (.*) mapped to (.*)")]
        public void GivenILoggedIntoCRMWithMappedTo(string User1, string Customer1)
        {
            if (User1.Equals("ExternalUser"))
            {
                username1 = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
                password1 = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
                crm.LoginToCRMApplication(username1, password1);
            }
            else
            {
                username1 = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
                password1 = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
                crm.LoginToCRMApplication(username1, password1);

            }

        }

        [Given(@"I login back into CRM with (.*) as different user mapped to (.*)")]
        public void GivenILoginBackIntoCRMWithAsDifferentUserMappedTo(string User2, string Customer2)
        {
            if (User2.Equals("ExternalUser"))
            {
                username2 = ConfigurationManager.AppSettings["username-shipentry"].ToString();
                password2 = ConfigurationManager.AppSettings["password-shipentry"].ToString();
                crm.Login_CRMApplication(username2, password2);
            }
            else
            {
                username2 = ConfigurationManager.AppSettings["username-OperationsCrm"].ToString();
                password2 = ConfigurationManager.AppSettings["password-OperationsCrm"].ToString();
                crm.Login_CRMApplication(username2, password2);

            }
        }

        [Then(@"the (.*) shipment details should not be prepopulated in the Add Shipment LTL page for (.*)")]
        public void ThenTheShipmentDetailsShouldNotBePrepopulatedInTheAddShipmentLTLPageFor(string Customer1, string Customer2)
        {
            //shipment Shipping From Details
            string user2FromName = GetAttribute(attributeName_id, ShippingFrom_LocationName_Id, "value");
            Assert.AreNotEqual(user2FromName, oName);

            string user2FromAddress1 = GetAttribute(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
            Assert.AreNotEqual(user2FromAddress1, oAdd1);

            string user2FromZip = GetAttribute(attributeName_id, ShippingFrom_zipcode_Id, "value");
            Assert.AreNotEqual(user2FromZip, oZip);

            string user2FromAccessorial = GetAttribute(attributeName_xpath, ".//*[@id='shippingfromaccessorial_chosen']/ul/li/input", "value");
            Assert.AreNotEqual(user2FromAccessorial, fromAccessorials1);

            string user2FromContactName = GetAttribute(attributeName_id, ShippingFrom_ContactName_Id, "value");
            Assert.AreNotEqual(user2FromContactName, fromContactName);

            string user2FromContactEmail = GetAttribute(attributeName_id, ShippingFrom_ContactEmail_Id, "value");
            Assert.AreNotEqual(user2FromContactEmail, fromContactName);

            string user2FromContactPhone = GetAttribute(attributeName_id, ShippingFrom_ContactName_Id, "value");
            Assert.AreNotEqual(user2FromContactPhone, fromContactPhone);

            string user2FromContactFax = GetAttribute(attributeName_id, ShippingFrom_ContactName_Id, "value");
            Assert.AreNotEqual(user2FromContactFax, fromContactFax);

            //shipment Shipping To Details
            string user2ToName = GetAttribute(attributeName_id, ShippingFrom_LocationName_Id, "value");
            Assert.AreNotEqual(user2ToName, dName);

            string user2ToAddress1 = GetAttribute(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
            Assert.AreNotEqual(user2ToAddress1, dAdd1);

            string user2ToZip = GetAttribute(attributeName_id, ShippingFrom_zipcode_Id, "value");
            Assert.AreNotEqual(user2ToZip, dZip);

            string user2ToAccessorial = GetAttribute(attributeName_xpath, ".//*[@id='shippingtoaccessorial_chosen']/ul/li/input", "value");
            Assert.AreNotEqual(user2ToAccessorial, toAccessorials1);

            string user2ToContactName = GetAttribute(attributeName_id, ShippingTo_ContactName_Id, "value");
            Assert.AreNotEqual(user2ToContactName, toContactName);

            string user2ToContactEmail = GetAttribute(attributeName_id, ShippingTo_ContactEmail_Id, "value");
            Assert.AreNotEqual(user2ToContactEmail, toContactEmail);

            string user2ToContactPhone = GetAttribute(attributeName_id, ShippingTo_ContactPhone_Id, "value");
            Assert.AreNotEqual(user2ToContactPhone, toContactPhone);

            string user2ToContactFax = GetAttribute(attributeName_id, ShippingTo_ContactFax_Id, "value");
            Assert.AreNotEqual(user2ToContactFax, toContactFax);

            //Item Details
            scrollpagedown();
            scrollpagedown();
            
            string itemclassification = GetAttribute(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id,"Value");
            Assert.AreNotEqual(itemclassification, classification);

            string itemnmfc = GetAttribute(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "Value");
            Assert.AreNotEqual(itemnmfc, nmfc);

            string itemquantity = GetAttribute(attributeName_id, FreightDesp_FirstItem_Quantity_Id,"value");
            Assert.AreNotEqual(itemquantity, quantity);

            string itemweight = GetAttribute(attributeName_id, FreightDesp_FirstItem_Weight_Id,"value");
            Assert.AreNotEqual(itemweight, weight);

            string itemDescription = GetAttribute(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");
            Assert.AreNotEqual(itemDescription, Itemdesc);

            string itemLength = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
            Assert.AreNotEqual(itemLength, Length);

            string itemWidth = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            Assert.AreNotEqual(itemWidth, Width);

            string itemHeight = GetAttribute(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
            Assert.AreNotEqual(itemHeight, Height);

            string Special_Instructions = GetAttribute(attributeName_id, DefaultSpecialIntructions_Comments_Id, "value");
            Assert.AreNotEqual(Special_Instructions, SpecialInstructions);

            string Insured_Value = GetAttribute(attributeName_id, InsuredValue_TextBox_Id, "value");
            Assert.AreNotEqual(Insured_Value, InsuredValue);

        }

    }
}
