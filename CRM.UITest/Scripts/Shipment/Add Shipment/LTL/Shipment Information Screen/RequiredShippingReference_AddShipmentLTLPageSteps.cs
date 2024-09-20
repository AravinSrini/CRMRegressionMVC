using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen.OverLength_AddShipment__LTL_;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class RequiredShippingReference_AddShipmentLTLPageSteps : AddShipments
    {
        string userType = string.Empty;

        OverLength_AddShipmentLTL_TabOrderSteps directShipmentSteps = new OverLength_AddShipmentLTL_TabOrderSteps();
        ConfigureAccessorials_LTL_DisplayAccessorialShipmentSteps navigationSteps = new ConfigureAccessorials_LTL_DisplayAccessorialShipmentSteps();
        AddQuoteLTL getQuote = new AddQuoteLTL();
        RateToShipmentLTL rateToShipment = new RateToShipmentLTL();
        string customername = string.Empty;
        List<string> primaryReferencevalues = new List<string>();
        List<string> AdditionalReferencevalues = new List<string>();
        List<string> totalPrimaryAndAdditionalReference = new List<string>();
        List<string> AdditionalReferencesection = new List<string>();
        IList<IWebElement> TotalAdditionalReferncesection = null;
        AddShipmentLTL ltl = new AddShipmentLTL();
        string shpType = string.Empty;
        string reference = string.Empty;
        bool isPoNumberdesignatedAsReference;
        bool isOrderNumberdesignatedAsReference;
        bool isGLCOdedesignatedAsReference;
        bool isBOLNumberdesignatedAsReference;
        bool isPRoNumberdesignatedAsReference;
        bool isPickupNumberdesignatedAsReference;
        bool isDeliveryApptNumberdesignatedAsReference;
        bool isConsRefdesignatedAsReference;
        bool isCustInvRefdesignatedAsReference;
        bool isJobNamedesignatedAsReference;
        bool isJobNumberdesignatedAsReference;
        bool isManifestNbrdesignatedAsReference;
        bool isPickUpApptNbrdesignatedAsReference;
        bool isProductCodedesignatedAsReference;
        bool isProjectNumberdesignatedAsReference;
        bool isReleaseNbrdesignatedAsReference;
        bool isSalesOrderdesignatedAsReference;
        bool isShipRefdesignatedAsReference;
        bool isWorkOrderNbrdesignatedAsReference;


        [Given(@"that I am a shp\.entry or shp\.entrynorates user(.*)")]
        public void GivenThatIAmAShp_EntryOrShp_EntrynoratesUser(string loginUsertype)
        {
            userType = loginUsertype;
            string username = ConfigurationManager.AppSettings["username-ShipEntryShippingRef"].ToString();
            string password = ConfigurationManager.AppSettings["password-ShipEntryShippingRef"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am associated to a (.*) with one or more required references")]
        public void GivenIAmAssociatedToAWithOneOrMoreRequiredReferences(string customer)
        {
            //reference = "Primary Reference";
            customername = customer;
            primaryReferencevalues = DBHelper.GetCustomerShippingReferencedata(customer);
        }
        [Given(@"I am associated to a (.*) with one or more required additional references")]
        public void GivenIAmAssociatedToAWithOneOrMoreRequiredAdditionalReferences(string customer)
        {
            customername = customer;
            AdditionalReferencevalues = DBHelper.GetCustomerShippingReferencedata(customer);
            reference = "Additional Reference";
            isConsRefdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Cons Ref")).Any();
            isCustInvRefdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("CustInvRef")).Any();
            isJobNamedesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Job Name")).Any();
            isJobNumberdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Job Number")).Any();
            isManifestNbrdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Manifest Nbr")).Any();
            isPickUpApptNbrdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Pickup Appt Nbr")).Any();
            isProductCodedesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Product Code")).Any();
            isProjectNumberdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Project Number")).Any();
            isReleaseNbrdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Release Nbr")).Any();
            isSalesOrderdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Sales Order")).Any();
            isShipRefdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Ship Ref")).Any();
            isWorkOrderNbrdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("WorkOrderNbr")).Any();
        }


        [Given(@"the required reference\(s\) was one or more of the primary references")]
        public void GivenTheRequiredReferenceSWasOneOrMoreOfThePrimaryReferences()
        {

            isPoNumberdesignatedAsReference = primaryReferencevalues.Where(a => a.Contains("PO Number")).Any();
            isOrderNumberdesignatedAsReference = primaryReferencevalues.Where(a => a.Contains("Order Number")).Any();
            isGLCOdedesignatedAsReference = primaryReferencevalues.Where(a => a.Contains("GL Code")).Any();
            isBOLNumberdesignatedAsReference = primaryReferencevalues.Where(a => a.Contains("BOL Number")).Any();
            isPRoNumberdesignatedAsReference = primaryReferencevalues.Where(a => a.Contains("Pro Number")).Any();
            isPickupNumberdesignatedAsReference = primaryReferencevalues.Where(a => a.Contains("Pickup Number")).Any();
            isDeliveryApptNumberdesignatedAsReference = primaryReferencevalues.Where(a => a.Contains("Delivery Appt Number")).Any();

        }

        [Given(@"I am associated to a customer with one or more required additional references")]
        public void GivenIAmAssociatedToACustomerWithOneOrMoreRequiredAdditionalReferences()
        {
            List<string> tablevalues = DBHelper.GetCustomerShippingReferencedata(customername);
            bool isPoNumberdesignatedAsReference = tablevalues.Where(a => a.Contains("Cons Ref")).Any();
            bool isOrderNumberdesignatedAsReference = tablevalues.Where(a => a.Contains("Order Number")).Any();
            bool isGLCOdedesignatedAsReference = tablevalues.Where(a => a.Contains("GL Code")).Any();
            bool isBOLNumberdesignatedAsReference = tablevalues.Where(a => a.Contains("BOL Number")).Any();
            bool isPRoNumberdesignatedAsReference = tablevalues.Where(a => a.Contains("PRO Number")).Any();
            bool isPickupNumberdesignatedAsReference = tablevalues.Where(a => a.Contains("Pickup Number")).Any();
            bool isDeliveryApptNumberdesignatedAsReference = tablevalues.Where(a => a.Contains("Delivery APPT Number")).Any();


        }


        [Given(@"I selected a (.*) with one or more required references")]
        public void GivenISelectedAWithOneOrMoreRequiredReferences(string customer)
        {
            GivenIAmAssociatedToAWithOneOrMoreRequiredReferences(customer);
        }

        [Given(@"I selected a (.*) with one or more required references on the(.*) Shipment List page(.*)")]
        public void GivenISelectedAWithOneOrMoreRequiredReferencesOnTheShipmentListPage(string customer, string userType, string ShipmentType)
        {
            shpType = ShipmentType;
            customername = customer;
            GivenIAmAssociatedToAWithOneOrMoreRequiredReferences(customer);
            switch (ShipmentType)
            {
                case "Direct Shipment":
                    {
                        if (userType == "Internal" || userType == "Sales")
                        {
                            GlobalVariables.webDriver.WaitForPageLoad();
                            Click(attributeName_id, ShipmentIcon_Id);
                            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
                            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, customername);
                            Click(attributeName_id, AddShipmentButtionInternal_Id);
                            Click(attributeName_id, AddShipmentLTL_Button_Id);
                            Thread.Sleep(4000);
                        }
                        else
                        {
                            //quoteNavigation.GivenIAmOnTheGetQuoteLTLPage();
                            Click(attributeName_id, "shipment");
                            GlobalVariables.webDriver.WaitForPageLoad();
                            Click(attributeName_id, "add-shipment-btn");
                            GlobalVariables.webDriver.WaitForPageLoad();
                            Click(attributeName_id, "btn_ltl");
                            Thread.Sleep(4000);
                            GlobalVariables.webDriver.WaitForPageLoad();
                        }
                        break;
                    }
                case "Rate To Shipment":
                    {
                        if (userType == "Internal" || userType == "Sales")
                        {
                            getQuote.NaviagteToQuoteList();
                            getQuote.Add_QuoteLTL("Internal", customername);
                            getQuote.EnterOriginZip("33136");
                            getQuote.EnterDestinationZip("85282");
                            getQuote.selectShippingToServices("Inside Delivery");
                            getQuote.EnterItemdata("50", "50");
                            getQuote.ClickViewRates();
                            Report.WriteLine("I am on Rate Results page");
                            rateToShipment.ClickOnCreateShipmentbutton_Quote("Internal");
                            Report.WriteLine("I clicked on Create Shipment button on Rate Results page");
                            Thread.Sleep(2000);
                            Click(attributeName_id, "create-shipment-btn");
                            Thread.Sleep(4000);
                            GlobalVariables.webDriver.WaitForPageLoad();
                        }
                        else if (userType == "External")
                        {

                            Click(attributeName_xpath, ".//*[@id='raterequest']/i");
                            GlobalVariables.webDriver.WaitForPageLoad();
                            Click(attributeName_id, SubmitRateRequestButton_Id);

                            GlobalVariables.webDriver.WaitForPageLoad();
                            Report.WriteLine("Click on LTL tile");
                            Click(attributeName_id, LTL_TileLabel_Id);
                            GlobalVariables.webDriver.WaitForPageLoad();
                            getQuote.EnterOriginZip("33136");
                            getQuote.EnterDestinationZip("85282");
                            getQuote.selectShippingToServices("Inside Delivery");
                            getQuote.EnterItemdata("50", "50");
                            getQuote.ClickViewRates();
                            Report.WriteLine("I am on Rate Results page");
                            rateToShipment.ClickOnCreateShipmentbutton_Quote("External");
                            Report.WriteLine("I clicked on Create Shipment button on Rate Results page");
                            Thread.Sleep(2000);
                            Click(attributeName_id, "create-shipment-btn");
                            Thread.Sleep(4000);
                            GlobalVariables.webDriver.WaitForPageLoad();
                        }
                        break;
                    }
                case "Quote To Shipment":
                    {
                        ltl.QuoteToShipmentNavigation(userType, customername);
                        break;
                    }
                case "Edit Shipment":
                    {
                        SelectCustomerFromShipmentListPage();
                        SendKeys(attributeName_id, "searchbox", "ZZX002015245");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[10]/button");
                        Thread.Sleep(4000);
                        GlobalVariables.webDriver.WaitForPageLoad();

                        break;
                    }
                case "Copy Shipment":
                    {
                        SelectCustomerFromShipmentListPage();
                        SendKeys(attributeName_id, "searchbox", "ZZX002015245");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[11]/a[2]/span");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        WaitForElementVisible(attributeName_id, "copy-shipment-Ok", "Copy Confirmation Ok button");
                        Click(attributeName_id, "copy-shipment-Ok");
                        Thread.Sleep(4000);
                        GlobalVariables.webDriver.WaitForPageLoad();
                        break;
                    }
                case "Return Shipment":
                    {
                        SelectCustomerFromShipmentListPage();
                        SendKeys(attributeName_id, "searchbox", "ZZX002015245");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[11]/a[3]");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        WaitForElementVisible(attributeName_id, "Return-shipment-Ok", "Return Confirmation Ok button");
                        Click(attributeName_id, "Return-shipment-Ok");
                        Thread.Sleep(4000);
                        GlobalVariables.webDriver.WaitForPageLoad();
                        break;
                    }
            }
        }



        [Given(@"the required reference\(s\) was one or more of the primary references ""(.*)""")]
        public void GivenTheRequiredReferenceSWasOneOrMoreOfThePrimaryReferences(string primaryReferenceNumber)
        {
            Report.WriteLine("Verifying the presence" + primaryReferenceNumber + "From DB");
            GivenTheRequiredReferenceSWasOneOrMoreOfThePrimaryReferences();
            reference = "Primary Reference";
        }

        [Given(@"I'm a sales, sales management, operations, or station owner user(.*)")]
        public void GivenIMASalesSalesManagementOperationsOrStationOwnerUser(string loginUsertype)
        {
            userType = loginUsertype;
            string username = string.Empty;
            string password = string.Empty;
            if (userType == "Internal")
            {
                username = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
            }
            else if (userType == "Sales")
            {
                username = ConfigurationManager.AppSettings["username-SaleshippingRef"].ToString();
                password = ConfigurationManager.AppSettings["password-SalesShippingRef"].ToString();
            }
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I selected a (.*) with one or more Additional required references")]
        public void GivenISelectedAWithOneOrMoreAdditionalRequiredReferences(string customer)
        {
            customername = customer;
            AdditionalReferencevalues = DBHelper.GetCustomerShippingReferencedata(customer);
            reference = "Additional Reference";
        }

        [Given(@"the required reference\(s\) was one or more of the additional references")]
        public void GivenTheRequiredReferenceSWasOneOrMoreOfTheAdditionalReferences()
        {
            isConsRefdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Cons Ref")).Any();
            isCustInvRefdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("CustInvRef")).Any();
            isJobNamedesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Job Name")).Any();
            isJobNumberdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Job Number")).Any();
            isManifestNbrdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Manifest Nbr")).Any();
            isPickUpApptNbrdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Pickup Appt Nbr")).Any();
            isProductCodedesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Product Code")).Any();
            isProjectNumberdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Project Number")).Any();
            isReleaseNbrdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Release Nbr")).Any();
            isSalesOrderdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Sales Order")).Any();
            isShipRefdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("Ship Ref")).Any();
            isWorkOrderNbrdesignatedAsReference = AdditionalReferencevalues.Where(a => a.Contains("WorkOrderNbr")).Any();
            reference = "Additional Reference";
        }

        [Given(@"that I am a shp\.entry shp\.entrynorates, sales, sales management, operations, or station owner user(.*)")]
        public void GivenThatIAmAShp_EntryShp_EntrynoratesSalesSalesManagementOperationsOrStationOwnerUser(string loginUsertype)
        {
            userType = loginUsertype;
            string username = string.Empty;
            string password = string.Empty;
            if (userType == "Internal")
            {
                username = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
            }
            else if (userType == "Sales")
            {
                username = ConfigurationManager.AppSettings["username-SaleshippingRef"].ToString();
                password = ConfigurationManager.AppSettings["password-SalesShippingRef"].ToString();
            }
            else if (userType == "External")
            {
                username = ConfigurationManager.AppSettings["username-ShipEntryShippingRef"].ToString();
                password = ConfigurationManager.AppSettings["password-ShipEntryShippingRef"].ToString();
            }
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on the Add Shipment \(LTL\) page(.*),(.*)")]
        public void GivenIAmOnTheAddShipmentLTLPage(string customer, string shipmentType)
        {
            customername = customer;
            WhenIArriveOnTheAddShipmentLTLPageOf(shipmentType);
        }

        [Given(@"one or more references are required")]
        public void GivenOneOrMoreReferencesAreRequired()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have not completed one or more required reference fields")]
        public void GivenIHaveNotCompletedOneOrMoreRequiredReferenceFields()
        {
            switch (shpType)
            {
                case "Direct Shipment":
                    {
                        ltl.DirectShipmentEnterShipmentDatas();
                        break;
                    }
                case "Rate To Shipment":
                    {
                        SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "test");
                        SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "testadd1");
                        scrollPageup();
                        SendKeys(attributeName_id, ShippingTo_LocationName_Id, "test");
                        SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "testadd2");
                        scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
                        SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "check");
                        break;
                    }
                case "Quote To Shipment":
                    {
                        SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "test");
                        SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "testadd1");
                        scrollPageup();
                        SendKeys(attributeName_id, ShippingTo_LocationName_Id, "test");
                        SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "testadd2");
                        scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
                        SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "check");
                        break;
                    }

            }
        }

        [When(@"I arrive on the Add Shipment \(LTL\) page of (.*)")]
        public void WhenIArriveOnTheAddShipmentLTLPageOf(string shipmentType)
        {
            Report.WriteLine("User navigated to Add Shipment LTL page");
            WaitForElementVisible(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
        }


        [Then(@"the Reference Number section will be expanded")]
        public void ThenTheReferenceNumberSectionWillBeExpanded()
        {
            scrollElementIntoView(attributeName_xpath, ".//*[@id='referenceExpand']/h4");
            bool isReferencesectionExpanded = GlobalVariables.webDriver.FindElement(By.XPath(ReferenceNumberSection_Xpath)).Displayed;

            switch (reference)
            {
                case "Primary Reference":
                    {
                        if (isPoNumberdesignatedAsReference == true || isOrderNumberdesignatedAsReference == true || isGLCOdedesignatedAsReference == true || isBOLNumberdesignatedAsReference == true || isPRoNumberdesignatedAsReference == true || isPickupNumberdesignatedAsReference == true || isDeliveryApptNumberdesignatedAsReference == true)
                        {

                            Assert.IsTrue(isReferencesectionExpanded);
                        }
                        else
                        {
                            Assert.IsFalse(isReferencesectionExpanded);
                        }
                        break;
                    }
                case "Additional Reference":
                    {
                        if (isConsRefdesignatedAsReference || isCustInvRefdesignatedAsReference || isJobNamedesignatedAsReference || isJobNumberdesignatedAsReference || isManifestNbrdesignatedAsReference || isPickUpApptNbrdesignatedAsReference || isProductCodedesignatedAsReference || isProjectNumberdesignatedAsReference || isReleaseNbrdesignatedAsReference || isSalesOrderdesignatedAsReference || isShipRefdesignatedAsReference || isWorkOrderNbrdesignatedAsReference)
                        {
                            Assert.IsTrue(isReferencesectionExpanded);
                        }
                        else
                        {
                            Assert.IsFalse(isReferencesectionExpanded);
                        }
                        break;
                    }
            }
        }

        [Then(@"the reference\(s\) designated as required for this customer will be a required field\(s\)")]
        public void ThenTheReferenceSDesignatedAsRequiredForThisCustomerWillBeARequiredFieldS()
        {
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();
            VerifyPrimaryReferenceBorderWithRedHighlighted();
        }

        [Then(@"the required additional reference\(s\) for this customer will be displayed in the section")]
        public void ThenTheRequiredAdditionalReferenceSForThisCustomerWillBeDisplayedInTheSection()
        {
            TotalAdditionalReferncesection = GlobalVariables.webDriver.FindElements(By.XPath(TotalAdditionalReferencesection_Xpath));
            for (int i = 1; i <= TotalAdditionalReferncesection.Count; i++)
            {
                string additionalselectedReference = Gettext(attributeName_xpath, ".//*[@id='ltl_reference_type_select_" + i + "_chosen']/a");
                if (AdditionalReferencevalues.Contains(additionalselectedReference))
                {
                    Report.WriteLine("Additional Reference is Present in the Refernce section");
                }
                else
                {
                    Assert.Fail();
                }

            }
        }

        [Then(@"the additional reference\(s\) designated as required for this customer will be a required field\(s\)")]
        public void ThenTheAdditionalReferenceSDesignatedAsRequiredForThisCustomerWillBeARequiredFieldS()
        {
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();
            scrollElementIntoView(attributeName_xpath, ".//*[@id='referenceExpand']/h4");
            string expectedBorderColor = "rgb(255, 184, 69)";
            string expectedBackgroundColor = "url(\"http://dlsww-test.rrd.com/images/formicons.png\"), linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236))";
            for (int i = 1; i <= TotalAdditionalReferncesection.Count; i++)
            {
                string additionalselectedReferenceValuefieldBordercolor = GetCSSValue(attributeName_id, "ltl-reference-num-" + i + "", "border-color");

                string actualbackgroundcolor_Length = GetCSSValue(attributeName_id, "ltl-reference-num-" + i + "", "background-image");
                Assert.AreEqual(expectedBorderColor, additionalselectedReferenceValuefieldBordercolor);
                Assert.AreEqual(expectedBackgroundColor, actualbackgroundcolor_Length);
            }
        }

        [Then(@"I'm unable to change the displayed required reference")]
        public void ThenIMUnableToChangeTheDisplayedRequiredReference()
        {
            for (int i = 1; i <= TotalAdditionalReferncesection.Count; i++)
            {
                bool isAdditionalRefernceFieldDisabled = IsElementDisabled(attributeName_xpath, ".//*[@id='ltl_reference_type_select_" + i + "_chosen']/a", "Additional Ref dropdown");
                Assert.IsTrue(isAdditionalRefernceFieldDisabled);
            }
        }
        [Then(@"I will not See the Remove button")]
        public void ThenIWillNotSeeTheRemoveButton()
        {
            for (int i = 1; i <= TotalAdditionalReferncesection.Count; i++)
            {
                VerifyElementNotPresent(attributeName_xpath, ".//*[@id='" + i + "']//div[3]/button", "Additional Reference Remove button");
            }
        }

        [Then(@"the reference\(s\) designated as required for this customer will be displayed in the section")]
        public void ThenTheReferenceSDesignatedAsRequiredForThisCustomerWillBeDisplayedInTheSection()
        {
            VerifyElementPresent(attributeName_id, ReferenceNumbers_PONumber_Id, "PO Number Textbox");
            VerifyElementPresent(attributeName_id, ReferenceNumbers_OrderNumber_Id, "Order Number Textbox");
            VerifyElementPresent(attributeName_id, ReferenceNumbers_GLCode_Id, "GL Code Textbox");
            VerifyElementPresent(attributeName_id, ReferenceNumbers_BOLNumber_Id, "BOL Number Textbox");
            VerifyElementPresent(attributeName_id, ReferenceNumbers_PRONumber_Id, "Pro Number Textbox");
            VerifyElementPresent(attributeName_id, ReferenceNumbers_PickUpNumber_Id, "Pickup Number Textbox");
            VerifyElementPresent(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id, "Delivery Appt Number Textbox");
        }

        [Then(@"the required additional reference\(s\) for the customer will be displayed in the section")]
        public void ThenTheRequiredAdditionalReferenceSForTheCustomerWillBeDisplayedInTheSection()
        {
            ThenTheRequiredAdditionalReferenceSForThisCustomerWillBeDisplayedInTheSection();
        }

        [Then(@"the additional reference\(s\) designated as required for the customer will be a required field\(s\)")]
        public void ThenTheAdditionalReferenceSDesignatedAsRequiredForTheCustomerWillBeARequiredFieldS()
        {
            ThenTheAdditionalReferenceSDesignatedAsRequiredForThisCustomerWillBeARequiredFieldS();
        }

        [Then(@"I'm not able to see the (.*) button")]
        public void ThenIMNotAbleToSeeTheButton(string p0)
        {
            ThenIWillNotSeeTheRemoveButton();
        }

        [Then(@"the required reference field\(s\) will be highlighted")]
        public void ThenTheRequiredReferenceFieldSWillBeHighlighted()
        {
            VerifyPrimaryReferenceBorderWithRedHighlighted();
            string expectedBorderColor = "rgb(255, 184, 69)";
            string expectedBackgroundColor = "url(\"http://dlsww-test.rrd.com/images/formicons.png\"), linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236))";
            TotalAdditionalReferncesection = GlobalVariables.webDriver.FindElements(By.XPath(TotalAdditionalReferencesection_Xpath));
            for (int i = 1; i <= TotalAdditionalReferncesection.Count; i++)
            {
                string additionalselectedReferenceValuefieldBordercolor = GetCSSValue(attributeName_id, "ltl-reference-num-" + i + "", "border-color");

                string actualbackgroundcolor_Length = GetCSSValue(attributeName_id, "ltl-reference-num-" + i + "", "background-image");
                Assert.AreEqual(expectedBorderColor, additionalselectedReferenceValuefieldBordercolor);
                Assert.AreEqual(expectedBackgroundColor, actualbackgroundcolor_Length);
            }
        }

        [Then(@"I'am unable to continue to the next page")]
        public void ThenIAmUnableToContinueToTheNextPage()
        {
            ScrollToTopElement(attributeName_xpath, AddShipment_PageTitle_xpath);
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
        }

        [Given(@"one or more references are required(.*)")]
        public void GivenOneOrMoreReferencesAreRequired(string customer)
        {
            totalPrimaryAndAdditionalReference = DBHelper.GetCustomerShippingReferencedata(customer);
            isPoNumberdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("PO Number")).Any();
            isOrderNumberdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("Order Number")).Any();
            isGLCOdedesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("GL Code")).Any();
            isBOLNumberdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("BOL Number")).Any();
            isPRoNumberdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("Pro Number")).Any();
            isPickupNumberdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("Pickup Number")).Any();
            isDeliveryApptNumberdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("Delivery Appt Number")).Any();

            isConsRefdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("Cons Ref")).Any();
            isCustInvRefdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("CustInvRef")).Any();
            isJobNamedesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("Job Name")).Any();
            isJobNumberdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("Job Number")).Any();
            isManifestNbrdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("Manifest Nbr")).Any();
            isPickUpApptNbrdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("Pickup Appt Nbr")).Any();
            isProductCodedesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("Product Code")).Any();
            isProjectNumberdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("Project Number")).Any();
            isReleaseNbrdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("Release Nbr")).Any();
            isSalesOrderdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("Sales Order")).Any();
            isShipRefdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("Ship Ref")).Any();
            isWorkOrderNbrdesignatedAsReference = totalPrimaryAndAdditionalReference.Where(a => a.Contains("WorkOrderNbr")).Any();
        }

        [When(@"I click the View Rates button")]
        public void WhenIClickTheViewRatesButton()
        {
            Report.WriteLine("Clicking View Rates button");
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am associated to a (.*) with no Shipping Reference")]
        public void GivenIAmAssociatedToAWithNoShippingReference(string customer)
        {
            List<string> totalShippingReferenceCustomer = DBHelper.GetAllCustomerofShippingReference();
            bool isShippingRefernceCustomer = totalShippingReferenceCustomer.Where(a => !a.Contains(customer)).Any();
            Assert.IsTrue(isShippingRefernceCustomer);
        }

        //[Then(@"the Reference Number section will not be expanded")]
        //public void ThenTheReferenceNumberSectionWillNotBeExpanded()
        //{
        //    scrollElementIntoView(attributeName_xpath, ".//*[@id='referenceExpand']/h4");
        //    bool isReferencesectionExpanded = GlobalVariables.webDriver.FindElement(By.XPath(ReferenceNumberSection_Xpath)).Displayed;
        //    if(isReferencesectionExpanded)
        //    {
        //        string ponumber = GetValue(attributeName_id, ReferenceNumbers_PONumber_Id, "value");
        //        string ordernumber = GetValue(attributeName_id, ReferenceNumbers_OrderNumber_Id, "value");
        //        string GLCode = GetValue(attributeName_id, ReferenceNumbers_GLCode_Id, "value");
        //        string bolnumber = GetValue(attributeName_id, ReferenceNumbers_BOLNumber_Id, "value");
        //        string pronumber = GetValue(attributeName_id, ReferenceNumbers_PRONumber_Id, "value");
        //        string pickupnumber = GetValue(attributeName_id, ReferenceNumbers_PickUpNumber_Id, "value");
        //        string deliveryApptnumber = GetValue(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id, "value");

        //        if(string.IsNullOrEmpty(ponumber) || string.IsNullOrEmpty(ordernumber) || string.IsNullOrEmpty(GLCode) || string.IsNullOrEmpty(bolnumber) || string.IsNullOrEmpty(pronumber) || string.IsNullOrEmpty(pickupnumber) || string.IsNullOrEmpty(deliveryApptnumber))
        //        {
        //            Report.WriteLine("Reference section not expanded");
        //        }
        //        else
        //        {
        //            Report.WriteLine("Reference section will be expanded");
        //        }
        //    }
        //    else
        //    {
        //        Report.WriteLine("Reference section is not expanded");
        //    }
        //    //Assert.IsFalse(isReferencesectionExpanded);
        //}

        [Then(@"the Primary reference\(s\) for this customer will not be a required field\(s\)")]
        public void ThenThePrimaryReferenceSForThisCustomerWillNotBeARequiredFieldS()
        {
            string expectedBorderColorForNotRequired = "rgb(209, 211, 212)";

            scrollElementIntoView(attributeName_xpath, ".//*[@id='referenceExpand']/h4");
            bool isReferencesectionExpanded = GlobalVariables.webDriver.FindElement(By.XPath(ReferenceNumberSection_Xpath)).Displayed;
            if (isReferencesectionExpanded == false)
            {
                Click(attributeName_xpath, ReferenceNumbers_ExpandSection_xpath);
                Thread.Sleep(1500);
            }
            
                string poNumberValueFieldBorderColor = GetCSSValue(attributeName_id, ReferenceNumbers_PONumber_Id, "border-color");
                string actualpoNumberValueFieldBackgroundrColor = GetCSSValue(attributeName_id, ReferenceNumbers_PONumber_Id, "background-image");
                Assert.AreEqual(expectedBorderColorForNotRequired, poNumberValueFieldBorderColor);
                //Assert.AreEqual("", actualpoNumberValueFieldBackgroundrColor);

                string orderNumberValueFieldBorderColor = GetCSSValue(attributeName_id, ReferenceNumbers_OrderNumber_Id, "border-color");
                string actualOrderNumberValueFieldBackgroundrColor = GetCSSValue(attributeName_id, ReferenceNumbers_OrderNumber_Id, "background-image");
                Assert.AreEqual(expectedBorderColorForNotRequired, orderNumberValueFieldBorderColor);
                //Assert.AreEqual("", actualOrderNumberValueFieldBackgroundrColor);

                string GLCodeValueFieldBorderColor = GetCSSValue(attributeName_id, ReferenceNumbers_GLCode_Id, "border-color");
                string actualGLCodeValueFieldBackgroundrColor = GetCSSValue(attributeName_id, ReferenceNumbers_GLCode_Id, "background-image");
                Assert.AreEqual(expectedBorderColorForNotRequired, GLCodeValueFieldBorderColor);
                //Assert.AreEqual("", actualGLCodeValueFieldBackgroundrColor);

                string bolNumberValueFieldBorderColor = GetCSSValue(attributeName_id, ReferenceNumbers_BOLNumber_Id, "border-color");
                string actualBolNumberValueFieldBackgroundrColor = GetCSSValue(attributeName_id, ReferenceNumbers_BOLNumber_Id, "background-image");
                Assert.AreEqual(expectedBorderColorForNotRequired, bolNumberValueFieldBorderColor);
                //Assert.AreEqual("", actualBolNumberValueFieldBackgroundrColor);

                string PRONumberValueFieldBorderColor = GetCSSValue(attributeName_id, ReferenceNumbers_PRONumber_Id, "border-color");
                string actualproNumberValueFieldBackgroundrColor = GetCSSValue(attributeName_id, ReferenceNumbers_PRONumber_Id, "background-image");
                Assert.AreEqual(expectedBorderColorForNotRequired, PRONumberValueFieldBorderColor);
                //Assert.AreEqual("", actualproNumberValueFieldBackgroundrColor);

                string pickupNumberValueFieldBorderColor = GetCSSValue(attributeName_id, ReferenceNumbers_PickUpNumber_Id, "border-color");
                string actualPickupNumberValueFieldBackgroundrColor = GetCSSValue(attributeName_id, ReferenceNumbers_PickUpNumber_Id, "background-image");
                Assert.AreEqual(expectedBorderColorForNotRequired, pickupNumberValueFieldBorderColor);
                //Assert.AreEqual("", actualPickupNumberValueFieldBackgroundrColor);

                string deliveryAPPTNumberValueFieldBorderColor = GetCSSValue(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id, "border-color");
                string actualdeliveryAPPTNumberValueFieldBackgroundrColor = GetCSSValue(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id, "background-image");
                Assert.AreEqual(expectedBorderColorForNotRequired, deliveryAPPTNumberValueFieldBorderColor);
                //Assert.AreEqual("", actualdeliveryAPPTNumberValueFieldBackgroundrColor);

            
        }

        //[Then(@"I will not see Additional Reference field and Remove button")]
        //public void ThenIWillNotSeeAdditionalReferenceFieldAndRemoveButton()
        //{
        //    VerifyElementNotPresent(attributeName_xpath, ".//*[@id='ltl_reference_type_select_1_chosen']/a", "Additional Reference dropdown");
        //    VerifyElementNotPresent(attributeName_id, "ltl-reference-num-1", "Additional Reference Textbox");
        //    VerifyElementNotPresent(attributeName_xpath, ".//*[@id='1']//div[3]/button", "Additional Reference Remove button");

        //}

        [Then(@"I will able to navigate to next page upon click on View Rates button")]
        public void ThenIWillAbleToNavigateToNextPageUponClickOnViewRatesButton()
        {

            GivenIHaveNotCompletedOneOrMoreRequiredReferenceFields();
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, ShipResults_PageHeaderText_Relativexpath, "Shipment Results (LTL)");
        }


        public void VerifyPrimaryReferenceBorderWithRedHighlighted()
        {
            scrollElementIntoView(attributeName_xpath, ".//*[@id='referenceExpand']/h4");
            string expectedBorderColorForRequired = "rgb(255, 184, 69)";
            string expectedBackgroundColorForRequired = "url(\"http://dlsww-test.rrd.com/images/formicons.png\"), linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236))";

            string expectedBorderColorForNotRequired = "rgb(209, 211, 212)";
            //string expectedBackgroundColorForNotRequired = "url(\"http://dlsww-test.rrd.com/images/formicons.png\"), linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236))";

            string poNumberValueFieldBorderColor = GetCSSValue(attributeName_id, ReferenceNumbers_PONumber_Id, "border-color");
            string actualpoNumberValueFieldBackgroundrColor = GetCSSValue(attributeName_id, ReferenceNumbers_PONumber_Id, "background-image");

            if (isPoNumberdesignatedAsReference)
            {
                Assert.AreEqual(expectedBorderColorForRequired, poNumberValueFieldBorderColor);
                Assert.AreEqual(expectedBackgroundColorForRequired, actualpoNumberValueFieldBackgroundrColor);
            }
            else
            {
                Assert.AreEqual(expectedBorderColorForNotRequired, poNumberValueFieldBorderColor);
                //Assert.AreEqual(expectedBackgroundColorForNotRequired, actualpoNumberValueFieldBackgroundrColor);
            }

            string orderNumberValueFieldBorderColor = GetCSSValue(attributeName_id, ReferenceNumbers_OrderNumber_Id, "border-color");
            string actualOrderNumberValueFieldBackgroundrColor = GetCSSValue(attributeName_id, ReferenceNumbers_OrderNumber_Id, "background-image");
            if (isOrderNumberdesignatedAsReference)
            {
                Assert.AreEqual(expectedBorderColorForRequired, orderNumberValueFieldBorderColor);
                Assert.AreEqual(expectedBackgroundColorForRequired, actualOrderNumberValueFieldBackgroundrColor);
            }
            else
            {
                Assert.AreEqual(expectedBorderColorForNotRequired, orderNumberValueFieldBorderColor);
                //Assert.AreEqual("", actualOrderNumberValueFieldBackgroundrColor);
            }

            string GLCodeValueFieldBorderColor = GetCSSValue(attributeName_id, ReferenceNumbers_GLCode_Id, "border-color");
            string actualGLCodeValueFieldBackgroundrColor = GetCSSValue(attributeName_id, ReferenceNumbers_GLCode_Id, "background-image");
            if (isGLCOdedesignatedAsReference)
            {
                Assert.AreEqual(expectedBorderColorForRequired, GLCodeValueFieldBorderColor);
                Assert.AreEqual(expectedBackgroundColorForRequired, actualGLCodeValueFieldBackgroundrColor);
            }
            else
            {
                Assert.AreEqual(expectedBorderColorForNotRequired, GLCodeValueFieldBorderColor);
                //Assert.AreEqual("", actualGLCodeValueFieldBackgroundrColor);
            }

            string bolNumberValueFieldBorderColor = GetCSSValue(attributeName_id, ReferenceNumbers_BOLNumber_Id, "border-color");
            string actualBolNumberValueFieldBackgroundrColor = GetCSSValue(attributeName_id, ReferenceNumbers_BOLNumber_Id, "background-image");
            if (isBOLNumberdesignatedAsReference)
            {
                Assert.AreEqual(expectedBorderColorForRequired, bolNumberValueFieldBorderColor);
                Assert.AreEqual(expectedBackgroundColorForRequired, actualBolNumberValueFieldBackgroundrColor);
            }
            else
            {
                Assert.AreEqual(expectedBorderColorForNotRequired, bolNumberValueFieldBorderColor);
                //Assert.AreEqual("", actualBolNumberValueFieldBackgroundrColor);
            }

            string PRONumberValueFieldBorderColor = GetCSSValue(attributeName_id, ReferenceNumbers_PRONumber_Id, "border-color");
            string actualproNumberValueFieldBackgroundrColor = GetCSSValue(attributeName_id, ReferenceNumbers_PRONumber_Id, "background-image");
            if (isPRoNumberdesignatedAsReference)
            {
                Assert.AreEqual(expectedBorderColorForRequired, PRONumberValueFieldBorderColor);
                Assert.AreEqual(expectedBackgroundColorForRequired, actualproNumberValueFieldBackgroundrColor);
            }
            else
            {
                Assert.AreEqual(expectedBorderColorForNotRequired, PRONumberValueFieldBorderColor);
                //Assert.AreEqual("", actualproNumberValueFieldBackgroundrColor);
            }

            string pickupNumberValueFieldBorderColor = GetCSSValue(attributeName_id, ReferenceNumbers_PickUpNumber_Id, "border-color");
            string actualPickupNumberValueFieldBackgroundrColor = GetCSSValue(attributeName_id, ReferenceNumbers_PickUpNumber_Id, "background-image");
            if (isPickupNumberdesignatedAsReference)
            {
                Assert.AreEqual(expectedBorderColorForRequired, pickupNumberValueFieldBorderColor);
                Assert.AreEqual(expectedBackgroundColorForRequired, actualPickupNumberValueFieldBackgroundrColor);
            }
            else
            {
                Assert.AreEqual(expectedBorderColorForNotRequired, pickupNumberValueFieldBorderColor);
                //Assert.AreEqual("", actualPickupNumberValueFieldBackgroundrColor);
            }


            string deliveryAPPTNumberValueFieldBorderColor = GetCSSValue(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id, "border-color");
            string actualdeliveryAPPTNumberValueFieldBackgroundrColor = GetCSSValue(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id, "background-image");
            if (isDeliveryApptNumberdesignatedAsReference)
            {
                Assert.AreEqual(expectedBorderColorForRequired, deliveryAPPTNumberValueFieldBorderColor);
                Assert.AreEqual(expectedBackgroundColorForRequired, actualdeliveryAPPTNumberValueFieldBackgroundrColor);
            }
            else
            {
                Assert.AreEqual(expectedBorderColorForNotRequired, deliveryAPPTNumberValueFieldBorderColor);
                //Assert.AreEqual("", actualdeliveryAPPTNumberValueFieldBackgroundrColor);
            }
        }

        [Given(@"I'm shp\.entry shp\.entrynorates, sales, sales management, operations, or stationowner (.*) user")]
        public void GivenIMShp_EntryShp_EntrynoratesSalesSalesManagementOperationsOrStationownerUser(string loginUsertype)
        {
            userType = loginUsertype;
            string username = string.Empty;
            string password = string.Empty;
            if (userType == "Internal")
            {
                username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
                password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            }
            else if (userType == "Sales")
            {
                username = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
                password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
            }
            else if (userType == "External")
            {
                username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
                password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            }
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [When(@"I arrive on (.*)Add Shipment \(LTL\) page(.*) of Shipment (.*)")]
        public void WhenIArriveOnAddShipmentLTLPageOfShipment(string customer, string userType, string ShipmentType)
        {
            shpType = ShipmentType;
            customername = customer;
            GivenIAmAssociatedToAWithOneOrMoreRequiredReferences(customer);
            switch (ShipmentType)
            {
                case "Direct Shipment":
                    {
                        if (userType == "Internal" || userType == "Sales")
                        {
                            GlobalVariables.webDriver.WaitForPageLoad();
                            Click(attributeName_id, ShipmentIcon_Id);
                            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
                            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, customername);
                            Click(attributeName_id, AddShipmentButtionInternal_Id);
                            Click(attributeName_id, AddShipmentLTL_Button_Id);
                            Thread.Sleep(4000);
                        }
                        else
                        {
                            //quoteNavigation.GivenIAmOnTheGetQuoteLTLPage();
                            Click(attributeName_id, "shipment");
                            GlobalVariables.webDriver.WaitForPageLoad();
                            Click(attributeName_id, "add-shipment-btn");
                            GlobalVariables.webDriver.WaitForPageLoad();
                            Click(attributeName_id, "btn_ltl");
                            Thread.Sleep(4000);
                            GlobalVariables.webDriver.WaitForPageLoad();
                        }
                        break;
                    }
                case "Rate To Shipment":
                    {
                        if (userType == "Internal" || userType == "Sales")
                        {
                            getQuote.NaviagteToQuoteList();
                            getQuote.Add_QuoteLTL("Internal", customername);
                            getQuote.EnterOriginZip("33136");
                            getQuote.EnterDestinationZip("85282");
                            getQuote.selectShippingToServices("Inside Delivery");
                            getQuote.EnterItemdata("50", "50");
                            getQuote.ClickViewRates();
                            Report.WriteLine("I am on Rate Results page");
                            rateToShipment.ClickOnCreateShipmentbutton_Quote("Internal");
                            Report.WriteLine("I clicked on Create Shipment button on Rate Results page");
                            //Thread.Sleep(2000);
                            //Click(attributeName_id, "create-shipment-btn");
                            Thread.Sleep(4000);
                            GlobalVariables.webDriver.WaitForPageLoad();
                        }
                        else if (userType == "External")
                        {

                            Click(attributeName_xpath, ".//*[@id='raterequest']/i");
                            GlobalVariables.webDriver.WaitForPageLoad();
                            Click(attributeName_id, SubmitRateRequestButton_Id);

                            GlobalVariables.webDriver.WaitForPageLoad();
                            Report.WriteLine("Click on LTL tile");
                            Click(attributeName_id, LTL_TileLabel_Id);
                            GlobalVariables.webDriver.WaitForPageLoad();
                            getQuote.EnterOriginZip("33136");
                            getQuote.EnterDestinationZip("85282");
                            getQuote.selectShippingToServices("Inside Delivery");
                            getQuote.EnterItemdata("50", "50");
                            getQuote.ClickViewRates();
                            Report.WriteLine("I am on Rate Results page");
                            rateToShipment.ClickOnCreateShipmentbutton_Quote("External");
                            Report.WriteLine("I clicked on Create Shipment button on Rate Results page");
                            Thread.Sleep(2000);
                            Click(attributeName_id, "create-shipment-btn");
                            Thread.Sleep(4000);
                            GlobalVariables.webDriver.WaitForPageLoad();
                        }
                        break;
                    }
                case "Quote To Shipment":
                    {
                        ltl.QuoteToShipmentNavigation(userType, customername);
                        break;
                    }
                case "Edit Shipment":
                    {
                        SelectCustomerFromShipmentListPage();
                        SendKeys(attributeName_id, "searchbox", "ZZX002015276");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[10]/button");
                        Thread.Sleep(4000);
                        GlobalVariables.webDriver.WaitForPageLoad();

                        break;
                    }
                case "Copy Shipment":
                    {
                        SelectCustomerFromShipmentListPage();
                        SendKeys(attributeName_id, "searchbox", "ZZX002015276");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[11]/a[2]/span");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        WaitForElementVisible(attributeName_id, "copy-shipment-Ok", "Copy Confirmation Ok button");
                        Click(attributeName_id, "copy-shipment-Ok");
                        Thread.Sleep(4000);
                        GlobalVariables.webDriver.WaitForPageLoad();
                        break;
                    }
                case "Return Shipment":
                    {
                        SelectCustomerFromShipmentListPage();
                        SendKeys(attributeName_id, "searchbox", "ZZX002015276");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[11]/a[3]");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        WaitForElementVisible(attributeName_id, "Return-shipment-Ok", "Return Confirmation Ok button");
                        Click(attributeName_id, "Return-shipment-Ok");
                        Thread.Sleep(4000);
                        GlobalVariables.webDriver.WaitForPageLoad();
                        break;
                    }
            }
        }

        [When(@"I arrive (.*)to the Add Shipment \(LTL\) page(.*) of (.*)")]
        public void WhenIArriveToTheAddShipmentLTLPageOf(string customer, string userType, string ShipmentType)
        {
            GivenISelectedAWithOneOrMoreRequiredReferencesOnTheShipmentListPage(customer, userType, ShipmentType);
        }


        public void SelectCustomerFromShipmentListPage()
        {
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == customername)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }
            GlobalVariables.webDriver.WaitForPageLoad();
        }
    }
}
