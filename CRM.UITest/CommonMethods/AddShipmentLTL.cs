using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.CommonMethods
{
    public class AddShipmentLTL : AddShipments
    {
        AddQuoteLTL getQuote = new AddQuoteLTL();
        RateToShipmentLTL rateToShipment = new RateToShipmentLTL();
        Quotelist quoteList = new Quotelist();
        string quoteNumber = string.Empty;
        #region ShipmentListModule
        public void NaviagteToShipmentList()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);

            //         bool d = IsElementPresent(attributeName_xpath, ".//*[@id='error']/h2", "Warning");
            //if (d)
            //{
            //	Click(attributeName_xpath, ".//*[@id='btn-error-Close']");
            //}

        }

        public void SelectCustomerFromShipmentList(string UserType, string CustomerName)
        {
            Report.WriteLine("Click on Add shipment button");
            if (UserType == "Internal")
            {
                try
                {
                    Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);
                }
                catch
                {
                    GlobalVariables.webDriver.WaitForPageLoad();
                }

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == CustomerName)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }

                try
                {
                    GlobalVariables.webDriver.WaitForPageLoad();
                    Click(attributeName_id, AddShipmentButtionInternal_Id);
                }
                catch
                {
                    GlobalVariables.webDriver.WaitForPageLoad();
                }
            }
            else
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, AddShipmentButton_id);
            }

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        public void SelectingCustomerFromShipmentList(string UserType, string CustomerName)
        {
            Report.WriteLine("Click on Add shipment button");
            if (UserType == "Internal")
            {

                Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);

                SendKeys(attributeName_xpath, ".//*[@id='CustomerType_chosen']/div/div/input", CustomerName);
                Click(attributeName_xpath, ".//*[@id='CustomerType_chosen']/div/ul/li[2]");

                Click(attributeName_id, AddShipmentButtionInternal_Id);
                //try
                //{
                //    Click(attributeName_id, AddShipmentButtionInternal_Id);
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e);
                //    Thread.Sleep(80000);
                //}
            }
            else
            {
                //Added for external users

                //Thread.Sleep(500);
                Click(attributeName_id, AddShipmentButton_id);
            }

            Click(attributeName_id, ShipmentServiceTypeLTL_id);
        }

        #endregion ShipmentListModule

        #region CreateShipment

        public void AddShipmentOriginData(string oName, string oAdd, string oZip)
        {
            Report.WriteLine("Passing data in shipping from section");
            scrollPageup();
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, oName);
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, oAdd);
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, oZip);

        }



        public void AddShipmentDestinationData(string dName, string dAdd, string dZip)
        {
            Report.WriteLine("Passing data in shipping to section");
            scrollPageup();
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            scrollElementIntoView(attributeName_id, ShippingTo_LocationName_Id);
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, dName);
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, dAdd);
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, dZip);


        }




        public void AddShipmentFreightDescription(string classification,
         string nmfc,
         string quantity,
         string weight,
         string desc)
        {

            Report.WriteLine("Passing data in freight description section");
            scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
            //Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            MoveToElement(attributeName_xpath, FreightDesp_SectionText_xpath);
            Thread.Sleep(6000);
            Clear(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, classification);

            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, nmfc);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, quantity);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, weight);
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, desc);
        }

        public void AddShippingFromContactSection(string cName, string cPhone, string cEmail, string cFax)
        {
            Report.WriteLine("Passing data in shipping from contact info section");
            SendKeys(attributeName_id, ShippingFrom_ContactName_Id, cName);
            SendKeys(attributeName_id, ShippingFrom_ContactEmail_Id, cEmail);
            SendKeys(attributeName_id, ShippingFrom_ContactFax_Id, cFax);
            SendKeys(attributeName_id, ShippingFrom_ContactPhone_Id, cPhone);
        }

        public void AddShippingToContactSection(string cName, string cPhone, string cEmail, string cFax)
        {
            Report.WriteLine("Passing data in shipping to contact info section");
            SendKeys(attributeName_id, ShippingTo_ContactName_Id, cName);
            SendKeys(attributeName_id, ShippingTo_ContactEmail_Id, cEmail);
            SendKeys(attributeName_id, ShippingTo_ContactFax_Id, cFax);
            SendKeys(attributeName_id, ShippingTo_ContactPhone_Id, cPhone);
        }

        public void PassHazmatDetailsforFirstItem(string unNumber, string ccnNumber, string hClass,
            string HGroup, string conName, string conPhone)
        {
            Report.WriteLine("Click yes on Hazardous Materials");
            scrollElementIntoView(attributeName_xpath, FreightDesp_FirstItem_Hazardous_Yes_RadioButton_xpath);
            Click(attributeName_xpath, FreightDesp_FirstItem_Hazardous_Yes_RadioButton_xpath);
            SendKeys(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, unNumber);
            SendKeys(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, ccnNumber);
            Click(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_Values_xpath, hClass);
            Click(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath, HGroup);
            SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, conName);
            SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, conPhone);

        }

        public void selectShippingfromServices(string services)
        {

            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_Values_xpath, services);
        }

        public void selectShippingToServices(string services)
        {
            Click(attributeName_xpath, ".//*[@id='shippingtoaccessorial_chosen']/ul/li");
            //SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='shippingtoaccessorial_chosen']/div/ul/li[2]", services);

            IList<IWebElement> accessorialsAndServices = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_ServicesAccessorial_DropDown_Values_xpath));
            int CustomerNameListCount = accessorialsAndServices.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (accessorialsAndServices[i].Text == services)
                {

                    accessorialsAndServices[i].Click();
                    break;
                }
            }
            // Click(attributeName_xpath, ".//*[@id='shippingtoaccessorial_chosen']/div/ul/li[2]");
            Thread.Sleep(1000);
            //Click(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_Values_xpath);
            //SelectDropdownValueFromList(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_Values_xpath, services);
        }

        public void ClickViewRates()
        {

            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            try
            {
                Click(attributeName_xpath, ViewRatesButton_xpath);
            }
            catch (Exception)
            {
                Thread.Sleep(40000);

            }

        }
        #endregion CreateShipment



        public void ClickOnCreateInsuredShipmentButton(string userType)
        {

            bool NoShipmentsAvailable_text = IsElementPresent(attributeName_xpath, "", "There are no rates  available for this shipment");
            if (NoShipmentsAvailable_text == false)
            {
                Report.WriteLine("Create shipment for selected carrier");
                switch (userType)
                {
                    case "External":
                        Click(attributeName_id, confirmation_CreateShipmentInsured_Id);
                        break;

                    case "Internal":
                        Click(attributeName_id, confirmation_CreateShipmentInsured_Id);
                        break;
                }
                GlobalVariables.webDriver.WaitForPageLoad();
            }

            else
            {
                Report.WriteLine("Rates are not available");
                Console.WriteLine("Rate Results are not available for the given information");
                Click(attributeName_xpath, "dummy xpath-Continue Shipment Without carriers");
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            WaitForElementVisible(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Page Header");

        }

        public void ClickOnCreateShipmentButton(string userType)
        {

            string resultspageText = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td");
            if (resultspageText != "There are no rates available for this shipment.")
            {
                Report.WriteLine("Create shipment for selected carrier");
                switch (userType)
                {
                    case "External":
                        Click(attributeName_xpath, ShipResults_FC_CreateShipment_Xpath);
                        break;

                    case "Internal":
                        Click(attributeName_xpath, ShipResults_InternalFC_CreateShipment_Xpath);
                        break;
                }
                GlobalVariables.webDriver.WaitForPageLoad();
            }

            else
            {
                Report.WriteLine("Rates are not available");
                Console.WriteLine("Rate Results are not available for the given information");
                Click(attributeName_xpath, ".//*[@id='gridLTLresult']/button");
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            WaitForElementVisible(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Page Header");

        }
        public void ReviewAndSubmit_ClickOnSubmitShipmentButton()
        {
            WaitForElementVisible(attributeName_xpath, ".//*[@id='SubmitShipment']", "Review and Submit Page Header");
            scrollElementIntoView(attributeName_xpath, ".//*[@id='SubmitShipment']");
            Click(attributeName_xpath, ".//*[@id='SubmitShipment']");
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        public void AddShipment_ShippingFromData(string oName, string oAdd, string oZip, string Country, string Postal, string city, string state)
        {
            if (Country != ("Canada"))
            {
                Report.WriteLine("Passing data in shipping from section");
                //Click(attributeName_id, ShippingFrom_ClearAddress_Id);
                SendKeys(attributeName_id, ShippingFrom_LocationName_Id, oName);
                SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, oAdd);
                SendKeys(attributeName_id, ShippingFrom_zipcode_Id, oZip);
                Thread.Sleep(500);
            }
            else
            {
                Report.WriteLine("Passing data in shipping from section");
                //Click(attributeName_id, ShippingFrom_ClearAddress_Id);
                SendKeys(attributeName_id, ShippingFrom_LocationName_Id, oName);
                SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, oAdd);
                Click(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_CountryDropDown_Values_xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == Country)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                SendKeys(attributeName_classname, ShippingFrom_PostalCode_Class, Postal);
                SendKeys(attributeName_id, ShippingFrom_City_Id, city);

            }
        }

        public void AddShipment_ShippingToData(string dName, string dAdd, string dZip, string Country, string Postal, string city, string state)
        {
            if (Country != ("Canada"))
            {
                Report.WriteLine("Passing data in shipping to section");
                //Click(attributeName_id, ShippingTo_ClearAddress_Id);
                SendKeys(attributeName_id, ShippingTo_LocationName_Id, dName);
                SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, dAdd);
                SendKeys(attributeName_id, ShippingTo_zipcode_Id, dZip);
                Thread.Sleep(500);
            }
            else
            {
                Report.WriteLine("Passing data in shipping To section");
                //Click(attributeName_id, ShippingTo_ClearAddress_Id);
                SendKeys(attributeName_id, ShippingTo_LocationName_Id, dName);
                SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, dAdd);

                Click(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_CountryDropDown_Values_xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == Country)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                SendKeys(attributeName_name, ShippingTo_PostalCode_Name, Postal);
                SendKeys(attributeName_id, ShippingTo_City_Id, city);

            }

        }

        public void DirectShipmentEnterShipmentDatas()
        {
            AddShipmentLTL ltl = new AddShipmentLTL();
            GlobalVariables.webDriver.WaitForPageLoad();
            ltl.AddShipmentOriginData("oName", "oAdd", "33126");
            ltl.AddShipmentDestinationData("dName", "dAdd", "85282");
            scrollPageup();

            Click(attributeName_xpath, Overlength_ShippingTo_ServicesAccessorial_DropDown_xpath);
            IList<IWebElement> AccessorialDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(Overlength_ShippingTo_ServicesAccessorial_DropDown_Values_xpath));
            int AccessorialDropdownListCount = AccessorialDropdown_List.Count;
            for (int i = 0; i < AccessorialDropdownListCount; i++)
            {
                if (AccessorialDropdown_List[i].Text == "Inside Delivery")
                {
                    AccessorialDropdown_List[i].Click();
                    break;
                }
            }
            //SelectDropdownValueFromList(attributeName_xpath,ShippingTo_ServicesAccessorial_DropDown_Values_xpath, "Inside Delivery");
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            string Classification = "70";
            double Quantity = 22;
            double Weight = 20;
            ltl.AddShipmentFreightDescription(Classification, "1234", Quantity.ToString(), Weight.ToString(), "testdescription");
        }

        public void RateToShipmentNavigation(string UserTypes, string CustomerName)
        {

            if (UserTypes == "Internal" || UserTypes == "Sales")
            {
                getQuote.NaviagteToQuoteList();
                getQuote.Add_QuoteLTL("Internal", CustomerName);
                getQuote.EnterOriginZip("33136");
                getQuote.EnterDestinationZip("85282");
                getQuote.selectShippingToServices("Inside Delivery");
                getQuote.EnterItemdata("50", "50");
                getQuote.ClickViewRates();
                Report.WriteLine("I am on Rate Results page");
                rateToShipment.ClickOnCreateShipmentbutton_Quote("Internal");
                Report.WriteLine("I clicked on Create Shipment button on Rate Results page");
                Thread.Sleep(2000);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else if (UserTypes == "External")
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
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            ScrollToTopElement(attributeName_id, ShippingFrom_LocationName_Id);
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "test");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "testadd1");
            scrollPageup();
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, "test");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "testadd2");
            scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "check");
        }

        public void QuoteToShipmentNavigation(string userType, string CustomerName)
        {
            if (userType != "External")
            {
                getQuote.NaviagteToQuoteList();
                getQuote.Add_QuoteLTL("Internal", CustomerName);
                getQuote.EnterOriginZip("33136");
                getQuote.EnterDestinationZip("85282");
                getQuote.EnterItemdata("50", "50");
                SendKeys(attributeName_id, "shipValueNumber", "80");
                getQuote.ClickViewRates();
                Report.WriteLine("I am on Rate Results page");
                GlobalVariables.webDriver.WaitForPageLoad();
                string configURL = launchUrl;
                string resultPagrURL = configURL + "Rate/LtlResultsView";
                if (GetURL() == resultPagrURL)
                {
                    Report.WriteLine("Rate Results available");
                    Click(attributeName_xpath, ltlsaverateasquotelnkint_xpath);
                }
                else
                {
                    Report.WriteLine("Rates are not available");
                    Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
                }
                Report.WriteLine("Clicking Back to quote list button");
                GlobalVariables.webDriver.WaitForPageLoad();
                quoteNumber = Gettext(attributeName_id, QC_RequestNumber_id);
                Click(attributeName_xpath, quoteList.QuoteConfirmation_BackToQuoteListButton_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                SendKeys(attributeName_id, "searchbox", quoteNumber);

                Report.WriteLine("Expanding the saved quote");
                Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]/td[10]/button");
                GlobalVariables.webDriver.WaitForPageLoad();
                Thread.Sleep(2000);
                Report.WriteLine("Clicking on create shipment button");
                Click(attributeName_id, quoteList.QuoteDetails_CreateShipButton_Id);
                Thread.Sleep(4000);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else
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
                getQuote.EnterItemdata("50", "50");
                SendKeys(attributeName_id, "shipValueNumber", "80");
                getQuote.ClickViewRates();
                Report.WriteLine("I am on Rate Results page");
                string configURL = launchUrl;
                string resultPagrURL = configURL + "Rate/LtlResultsView";
                if (GetURL() == resultPagrURL)
                {
                    Report.WriteLine("Rate Results available");
                    Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']//tr[1]//*[@class = 'save-rate-as-quote']");
                }
                else
                {
                    Report.WriteLine("Rates are not available");
                    Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
                }
                Report.WriteLine("Clicking Back to quote list button");
                GlobalVariables.webDriver.WaitForPageLoad();
                quoteNumber = Gettext(attributeName_id, QC_RequestNumber_id);
                Click(attributeName_xpath, quoteList.QuoteConfirmation_BackToQuoteListButton_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                SendKeys(attributeName_id, "searchbox", quoteNumber);

                Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]/td[9]/button");
                GlobalVariables.webDriver.WaitForPageLoad();
                Thread.Sleep(2000);
                Report.WriteLine("Clicking on create shipment button");
                Click(attributeName_id, quoteList.QuoteDetails_CreateShipButton_Id);
                Thread.Sleep(4000);
                GlobalVariables.webDriver.WaitForPageLoad();

            }
            ScrollToTopElement(attributeName_id, ShippingFrom_LocationName_Id);
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, "test");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "testadd1");
            scrollPageup();
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, "test");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, "testadd2");
            //scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
            scrollElementIntoView(attributeName_id, "freightDesc-0");
            SendKeys(attributeName_id, "freightDesc-0", "abcd");
        }

        public void SelectCustomerFromShipmentListPage(string customerName)
        {
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            Verifytext(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == customerName)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        public void DirectShipmentCreation(string userType, string CustomerName)
        {
            NaviagteToShipmentList();
            SelectCustomerFromShipmentList(userType, CustomerName);
            DirectShipmentEnterShipmentDatas();
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ClickViewRates();
            ClickOnCreateShipmentButton(userType);
            ReviewAndSubmit_ClickOnSubmitShipmentButton();
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
        }

        public void CopyShipment(string userType, string CustomerName)
        {
            NaviagteToShipmentList();
            GlobalVariables.webDriver.WaitForPageLoad();

            if (userType == "Internal" || userType == "Sales")
            {
                Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);
                SendKeys(attributeName_xpath, ".//*[@id='CustomerType_chosen']/div/div/input", CustomerName);
                Click(attributeName_xpath, ".//*[@id='CustomerType_chosen']/div/ul/li[2]");
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            int shipmentlistcount = GetCount(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[1]");
            if (shipmentlistcount <= 1)
            {
                DirectShipmentCreation(userType, CustomerName);
            }
            Click(attributeName_xpath, CopyiconFirstRecord_shipmentlist_Xpath);
            Thread.Sleep(2000);
            //GlobalVariables.webDriver.WaitForPageLoad();
            //WaitForElementVisible(attributeName_id, CopyShipmentOkModalPopup_Id, "Copy Confirmation Ok button");
            Click(attributeName_id, CopyShipmentOkModalPopup_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            //Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            //Click(attributeName_id, ShippingTo_ClearAddress_Id);
            scrollElementIntoView(attributeName_id, ShippingFrom_zipcode_Id);
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, "33136");
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, "85282");


        }

        public void ReturnShipment(string userType, string CustomerName)
        {
            NaviagteToShipmentList();
            GlobalVariables.webDriver.WaitForPageLoad();
            if (userType == "Internal" || userType == "Sales")
            {
                Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);
                SendKeys(attributeName_xpath, ".//*[@id='CustomerType_chosen']/div/div/input", CustomerName);
                Click(attributeName_xpath, ".//*[@id='CustomerType_chosen']/div/ul/li[2]");
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            int shipmentlistcount = GetCount(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[1]");
            if (shipmentlistcount <= 1)
            {
                DirectShipmentCreation(userType, CustomerName);
            }
            Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[1]//*[@class = 'btn btn-icon image-only-sm returnshipment']");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_id, ReturnShipmentYesModalPopup_Id, "Return Confirmation Yes button");
            Click(attributeName_id, ReturnShipmentYesModalPopup_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            //Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            //Click(attributeName_id, ShippingTo_ClearAddress_Id);
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, "33136");
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, "85282");

        }

        public void EditShipment(string userType, string CustomerName)
        {
            NaviagteToShipmentList();
            GlobalVariables.webDriver.WaitForPageLoad();

            if (userType == "Internal" || userType == "Sales")
            {
                Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);
                SendKeys(attributeName_xpath, ".//*[@id='CustomerType_chosen']/div/div/input", CustomerName);
                Click(attributeName_xpath, ".//*[@id='CustomerType_chosen']/div/ul/li[2]");
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            int count = GetCount(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr/td[1]");
            if (count <= 1)
            {
                DirectShipmentCreation(userType, CustomerName);
            }
            Click(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[1]//*[@class = 'btn btn-default colored btn-sm editShipmentBtn']");
            GlobalVariables.webDriver.WaitForPageLoad();
            //Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            //Click(attributeName_id, ShippingTo_ClearAddress_Id);
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, "33136");
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, "85282");
        }

    }
}
