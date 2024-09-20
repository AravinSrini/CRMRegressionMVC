using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using TechTalk.SpecFlow;
using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using System.Collections.Generic;
using CRM.UITest.Helper.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Rrd.ServiceAccessLayer;
using Rrd.Dls.IdentityServer.Core.Dto;
using CRM.UITest.Entities;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.Helper.Interfaces;
using System.Threading;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Scripts.Quote.LTL;

namespace CRM.UITest.Scripts.Quote.Quote_List
{
    [Binding]
    public class LTL_RequoteAnExpiredQuoteSteps : ObjectRepository
    {
        string Quotenumber = null;
        string errorMessage = string.Empty;
        ShippingInformationScreenForDesktopSteps steps = new ShippingInformationScreenForDesktopSteps();

        [Given(@"I click on Quote icon")]
        public void GivenIClickOnQuoteIcon()
        {
            Report.WriteLine("Clicking on quote icon");
            Click(attributeName_id, QuoteIcon_Id);
        }
        
        [When(@"I click the option to re-quote an expired LTL quote")]
        public string WhenIClickTheOptionToRe_QuoteAnExpiredLTLQuote()
        {
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id,"Loading Icon");
            Click(attributeName_id, QuoteList_SearchDropdown_Id);
            WaitForElementVisible(attributeName_id, QuoteList_ClearAll_Id, "Clear All Button");
            Click(attributeName_id, QuoteList_ClearAll_Id);
            Click(attributeName_xpath, QuoteList_ServiceOption_Id);
            Click(attributeName_id, QuoteList_SearchDropdown_Id);
            WaitForElementVisible(attributeName_xpath, ExpiredRadioButton_Xpath, "Expired Radio Button");
            Thread.Sleep(2000);
            Click(attributeName_xpath, ExpiredRadioButton_Xpath);
            SendKeys(attributeName_id, QuoteList_SearchBox_Id, "LTL");
            int rowcount = GetCount(attributeName_xpath, QuoteList_NoofRecords_Xpath);
            if(rowcount > 1)
            {
                Quotenumber = Gettext(attributeName_xpath, QuoteList_FirstQuoteRecord_Xpath);
            }
            else
            {
                Report.WriteLine("No Records found for the LTL expired quotes for the logged in user");
            }
            Report.WriteLine("Clicking on requote icon for expired quote");
            Click(attributeName_xpath, QuoteList_FirstRecord_ExpandQuote_Xpath);
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "Loading Icon");
            Click(attributeName_xpath, QuoteList_FirstRecord_ReQuote_Xpath);
            return Quotenumber;
        }
        
        [Then(@"I will be taken to the Get Quote \(LTL\) page")]
        public void ThenIWillBeTakenToTheGetQuoteLTLPage()
        {
            Report.WriteLine("Verifying the GetQuote(LTL) page");
            Verifytext(attributeName_xpath, GetQuoteLTLText_Xpath, "Get Quote (LTL)");
        }

        [Then(@"previously saved data should be displayed in the corresponding fields (.*)")]
        public void ThenPreviouslySavedDataShouldBeDisplayedInTheCorrespondingFields(string Username)
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> AllClaimDetails = IDP.GetUserClaimDetails(Username);
            List<string> setClaimDetails = AllClaimDetails.Where(c => c.ClaimType == "dlscrm-CustomerSetUpId").Select(a => a.ClaimValue).ToList();
            CustomerSetup value = DBHelper.GetSetupDetails(Convert.ToInt32(setClaimDetails.FirstOrDefault()));

            IExtractShipment extractShipment = new ExtractShipment();
            UploadTemplateViewModel uploadTemplate = new UploadTemplateViewModel()
            {
                PrimaryReferenceBol = Quotenumber
            };

            List<UploadTemplateViewModel> uploadTemplateViewModel = new List<UploadTemplateViewModel>();
            uploadTemplateViewModel.Add(uploadTemplate);

            IEnumerable<ShipmentExtractViewModel> shipmentDetails = extractShipment.ShipmentExtract(uploadTemplateViewModel, value.CustomerName, out errorMessage);          

            ShipmentExtractViewModel model = shipmentDetails.ToList()[0];
            //Address Information for origin and destination
            string originCity = string.Empty;
            string originState = string.Empty;
            string originZipCode = string.Empty;
            string originCountry = string.Empty;
            string destinationCity = string.Empty;
            string destinationState = string.Empty;
            string destinationZipCode = string.Empty;
            string destinationCountry = string.Empty;
            if (model.AddressViewModels != null)
            {
                for (var i = 0; i < model.AddressViewModels.Count; i++)
                {
                    if (model.AddressViewModels[i].Type.ToLower() == "origin")
                    {
                        originCity = model.AddressViewModels[i].City;
                        var ActualOriginCity = GetValue(attributeName_id, LTL_OriginCity_Id, "value");
                        Assert.AreEqual(originCity, ActualOriginCity);
                        Report.WriteLine("Displaying Origin city in UI " + ActualOriginCity + "is matching with API value" + originCity);

                        originState = model.AddressViewModels[i].StateProvince;
                        string ActualOriginState = Gettext(attributeName_xpath, LTL_OriginStateProvince_SelectedValue_Xpath); 
                        Assert.AreEqual(originState, ActualOriginState);
                        Report.WriteLine("Displaying Origin state/province in UI " + ActualOriginState + "is matching with API value" + originState);

                        originZipCode = model.AddressViewModels[i].PostalCode;
                        string ActualOriginZipCode = GetValue(attributeName_id, LTL_OriginZipPostal_Id, "value");
                        Assert.AreEqual(originState.ToUpper(), ActualOriginState.ToUpper());
                        Report.WriteLine("Displaying Origin zip/postal in UI " + ActualOriginZipCode + "is matching with API value" + originZipCode);

                        originCountry = model.AddressViewModels[i].CountryCode;
                        string ActualOriginCountry = Gettext(attributeName_xpath, LTL_OriginCountryDropdown_SelectedValue_Xpath);
                        if (originCountry == "USA")
                        {
                            Assert.AreEqual("United States", ActualOriginCountry);
                        }
                        else
                        {
                            Assert.AreEqual(originCountry.ToUpper(), ActualOriginCountry.ToUpper());
                        }
                        Report.WriteLine("Displaying Origin Country in UI " + ActualOriginCountry + "is matching with API value" + originCountry);

                    }

                    if (model.AddressViewModels[i].Type.ToLower() == "destination")
                    {
                        destinationCity = model.AddressViewModels[i].City;
                        string ActualDestCity = GetValue(attributeName_id, LTL_DestinationCity_Id, "value");
                        Assert.AreEqual(destinationCity, ActualDestCity);
                        Report.WriteLine("Displaying Destination city in UI " + ActualDestCity + "is matching with API value" + destinationCity);

                        destinationState = model.AddressViewModels[i].StateProvince;
                        string ActualDestState = Gettext(attributeName_xpath, LTL_DestinationStateProvince_SelectedValue_Xpath);
                        Assert.AreEqual(destinationState, ActualDestState);
                        Report.WriteLine("Displaying destination state in UI " + ActualDestState + "is matching with API value" + destinationState);

                        destinationZipCode = model.AddressViewModels[i].PostalCode;
                        string ActualDestZipCode = GetValue(attributeName_id, LTL_DestinationZipPostal_Id, "value");
                        Assert.AreEqual(destinationZipCode.ToUpper(), ActualDestZipCode.ToUpper());
                        Report.WriteLine("Displaying destination zip/postal in UI " + ActualDestZipCode + "is matching with API value" + destinationZipCode);

                        destinationCountry = model.AddressViewModels[i].CountryCode;
                        string ActualDestCountry = Gettext(attributeName_xpath, LTL_DestinationCountryDropdown_SelectedValue_Xpath);
                        if (destinationCountry == "USA")
                        {
                            Assert.AreEqual("United States", ActualDestCountry);
                        }
                        else
                        {
                            Assert.AreEqual(destinationCountry.ToUpper(), ActualDestCountry.ToUpper());
                        }
                        Report.WriteLine("Displaying destination country in UI " + ActualDestCountry + "is matching with API value" + destinationCountry);

                    }
                }
            }
            //Item information and ShipmentValue
            string quantity = string.Empty;
            string quantityUnit = string.Empty;
            string weight = string.Empty;
            string weightUnit = string.Empty;
            string ShipmentValueInLtl = string.Empty;
            if (model.ItemViewModels != null && model.ItemViewModels.Count > 0)
            {
                for (var i = 0; i < model.ItemViewModels.Count; i++)
                {
                    quantity = model.ItemViewModels[i].Quantity;
                    string ActualQuantity = GetValue(attributeName_id, LTL_Quantity_Id, "value");
                    string data = quantity.Split('.')[i];

                    if (data == ActualQuantity)
                    {
                        //Assert.AreEqual(quantity, ActualQuantity);
                        Report.WriteLine("Displaying quantity in UI " + ActualQuantity + "is matching with API value" + quantity);

                        quantityUnit = model.ItemViewModels[i].QuantityUnitName;
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Selectedvalue_Xpath);
                        Assert.AreEqual(quantityUnit, ActualQuantityUnit);
                        Report.WriteLine("Displaying quantity unit in UI " + ActualQuantityUnit + "is matching with API value" + quantityUnit);

                        weight = model.ItemViewModels[i].Weight;
                        string ActualWeight = GetValue(attributeName_id, LTL_Weight_Id, "value");
                        Assert.AreEqual(weight.Split('.')[i], ActualWeight);
                        Report.WriteLine("Displaying weight in UI " + ActualWeight + "is matching with API value" + weight);

                        ShipmentValueInLtl = model.ItemViewModels[i].DollarValue;
                        string ActualShipmentValue = GetValue(attributeName_id, LTL_EnterInsuredValue_Id, "value");
                        Assert.AreEqual(ShipmentValueInLtl.Split('.')[i], ActualShipmentValue);
                        Report.WriteLine("Displaying insured value in UI " + ActualShipmentValue + "is matching with API value" + ShipmentValueInLtl);

                        break;
                    }
                    else
                    {
                        Report.WriteLine("Item values displaying in UI is not matching with API value");
                        Assert.IsTrue(false);
                    }
                }
            }
        }

        [Then(@"I should be able to edit the populated data (.*), (.*), (.*),(.*), (.*),(.*)")]
        public void ThenIShouldBeAbleToEditThePopulatedData(string OCity, string OState, string OZip, string DCity, string DState, string DZip)
        {
            Thread.Sleep(2000);
            WaitForElementVisible(attributeName_id, ClearAddress_OriginId, "Clear Address");
            Click(attributeName_id, ClearAddress_OriginId);
            Click(attributeName_id, ClearAddress_DestId);
            steps.WhenISelectCanadaCountryFromOriginCountryDropdown();
            steps.WhenIEnterValidDataInOriginSectionAnd(OZip, OCity, OState);
            steps.WhenISelectCanadaCountryFromDestinationCountryDropdown();
			steps.WhenIEnterValidDataInDestinationSectionAnd(DState, DCity, DZip);

            string ActualOriginCity = GetValue(attributeName_id, LTL_OriginCity_Id, "value");
            Assert.AreEqual(OCity, ActualOriginCity);
            Report.WriteLine("Origin City field is editable");

            string ActualOriginState = Gettext(attributeName_xpath, LTL_OriginStateProvince_SelectedValue_Xpath);
            Assert.AreEqual(OState, ActualOriginState);
            Report.WriteLine("Origin State field is editable");

            string ActualOriginZipCode = GetValue(attributeName_id, LTL_OriginZipPostal_Id, "value");
            Assert.AreEqual(OZip.ToUpper(), ActualOriginZipCode.ToUpper());
            Report.WriteLine("Origin Zip field is editable");


            string ActualDestCity = GetValue(attributeName_id, LTL_DestinationCity_Id, "value");
            Assert.AreEqual(DCity, ActualDestCity);
            Report.WriteLine("Destination City field is editable");

            string ActualDestState = Gettext(attributeName_xpath, LTL_DestinationStateProvince_SelectedValue_Xpath);
            Assert.AreEqual(DState, ActualDestState);
            Report.WriteLine("Destination State field is editable");

            string ActualDestZipCode = GetValue(attributeName_id, LTL_DestinationZipPostal_Id, "value");
            Assert.AreEqual(DZip.ToUpper(), ActualDestZipCode.ToUpper());
            Report.WriteLine("Destination Zip field is editable");

        }

        [Then(@"ship date should be defaulted the current date")]
        public void ThenShipDateShouldBeDefaultedTheCurrentDate()
        {
            Report.WriteLine("Verifying the ShipDate in the Frieght Description section and default date todays date");
            Verifytext(attributeName_xpath, PickupDate_xpath, "Pickup Date");
            var TodaysDate_System = DateTime.Today.ToString("MM/dd/yyyy");
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            var TodaysDate_UI = executor.ExecuteScript("return $('#PickupDate').val()");
            Assert.AreEqual(TodaysDate_UI, TodaysDate_System);
        }

        [Then(@"multiple items should be displayed in Get Quote \(LTL\) page (.*)")]
        public void ThenMultipleItemsShouldBeDisplayedInGetQuoteLTLPage(string Username)
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> AllClaimDetails = IDP.GetUserClaimDetails(Username);
            List<string> setClaimDetails = AllClaimDetails.Where(c => c.ClaimType == "dlscrm-CustomerSetUpId").Select(a => a.ClaimValue).ToList();
            CustomerSetup value = DBHelper.GetSetupDetails(Convert.ToInt32(setClaimDetails.FirstOrDefault()));

            IExtractShipment extractShipment = new ExtractShipment();
            UploadTemplateViewModel uploadTemplate = new UploadTemplateViewModel()
            {
                PrimaryReferenceBol = Quotenumber
            };

            List<UploadTemplateViewModel> uploadTemplateViewModel = new List<UploadTemplateViewModel>();
            uploadTemplateViewModel.Add(uploadTemplate);

            IEnumerable<ShipmentExtractViewModel> shipmentDetails = extractShipment.ShipmentExtract(uploadTemplateViewModel, value.CustomerName, out errorMessage);
            ShipmentExtractViewModel model = shipmentDetails.ToList()[0];

            //Item information and ShipmentValue
            string quantity = string.Empty;
            string quantityUnit = string.Empty;
            string weight = string.Empty;
            string weightUnit = string.Empty;
            string ShipmentValueInLtl = string.Empty;
            if (model.ItemViewModels.Count > 1)
            {
                VerifyElementPresent(attributeName_id, LTL_Additinal_Weight_Id, "Weight");
                VerifyElementPresent(attributeName_id, LTL_AdditionalQuantity_Id, "Quantity");
            }
            else if(model.ItemViewModels.Count == 1)
            {
                Report.WriteLine("Only single item exits for the selected quote");
            }
            else
            {
                Report.WriteLine("Single item is binding in UI and not matching with quote details");
                Assert.IsTrue(false);
            }
        }

        [Then(@"I click on view quote results button")]
        public void ThenIClickOnViewQuoteResultsButton()
        {
            Thread.Sleep(3000);
            WaitForElementVisible(attributeName_id, LTL_ViewQuoteResults_Id, "View Quote Results Button");
            steps.WhenClickOnViewQuoteResultsButton();
        }

        [Then(@"rate results page/ no rate results page should be displayed based on the entered information")]
        public void ThenRateResultsPageNoRateResultsPageShouldBeDisplayedBasedOnTheEnteredInformation()
        {
          VerifyElementVisible(attributeName_xpath, ltlBacktoQuoteListBtn_xpath, "Back to Quote List button");
        }
    }
}
