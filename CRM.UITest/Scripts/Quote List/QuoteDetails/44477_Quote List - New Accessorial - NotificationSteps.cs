using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.Dls.IdentityServer.Core.Dto;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote_List.QuoteDetails
{
    [Binding]
    public class _44477_Quote_List___New_Accessorial___NotificationSteps : Quotelist
    {
        CommonQuoteNavigations CommonQuote = new CommonQuoteNavigations();
        public string Account = "ZZZ - GS Customer Test";
        public string ViewOption = "ALL";
        public string QuoteNum_Notification = "";
        public string errorMessage = string.Empty;
        public string QuoteNumber;
        public string Notification = "Notification";
        public string QuoteContainsNotification;

        [Given(@"I am navigated to the Quote List page")]
        public void GivenIAmNavigatedToTheQuoteListPage()
        {
            Report.WriteLine("Click on the Quote Module");
            Click(attributeName_xpath, QuoteIconModule_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, QuoteList_PageTitle_Xpath, "Quote List");        
        }


        [Given(@"I expand the Quote Details of any displayed LTL quote")]
        public void GivenIExpandTheQuoteDetailsOfAnyDisplayedLTLQuote()
        {
            IExtractShipment extractShipment = new ExtractShipment();
            CommonQuote.SelectCustomerFromDropdown(Account);
            GlobalVariables.webDriver.WaitForPageLoad();
            CommonQuote.SelectViewOptionsFromDropdown(ViewOption);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, QuoteList_Search_Box_Id, "LTL");
            GlobalVariables.webDriver.WaitForPageLoad();

            IList<IWebElement> QuoteNumbers = GlobalVariables.webDriver.FindElements(By.XPath(QuoteGridRefVlaues_Xpath));
            int QuoteNumbersCount = QuoteNumbers.Count;
            if (QuoteNumbersCount > 1)
            {
                for (int i = 0; i < QuoteNumbersCount; i++)
                {
                    QuoteNumber = QuoteNumbers[i].Text;
                    
                     UploadTemplateViewModel uploadTemplate = new UploadTemplateViewModel()
                    {
                        PrimaryReferenceBol = QuoteNumber
                    };

                    List<UploadTemplateViewModel> uploadTemplateViewModel = new List<UploadTemplateViewModel>();
                    uploadTemplateViewModel.Add(uploadTemplate);

                    IEnumerable<ShipmentExtractViewModel> QuoteDetails = extractShipment.ShipmentExtract(uploadTemplateViewModel, Account, out errorMessage);
                    ShipmentExtractViewModel quotemodel = QuoteDetails.ToList()[0];

                    if (quotemodel.AddressViewModels != null)
                    {
                        for (var j = 0; j < quotemodel.ShipmentDetailsViewModel.AdditionalServices.Count; j++)
                        {
                            if (quotemodel.ShipmentDetailsViewModel.AdditionalServices[j] == Notification)
                            {
                                QuoteContainsNotification = quotemodel.ShipmentDetailsViewModel.AdditionalServices[j];
                                SendKeys(attributeName_id, QuoteList_Search_Box_Id, QuoteNumber);
                                GlobalVariables.webDriver.WaitForPageLoad();
                                Click(attributeName_xpath, QuoteDetails_Expand_FirstRecord_Xpath);
                                GlobalVariables.webDriver.WaitForPageLoad();
                                break;
                            }
                            else
                            {
                                Report.WriteLine("Quote is not having accessorial type as Notification");
                            }
                        }

                    }

                    if(QuoteContainsNotification != null)
                    {
                        break;
                    }
                }
            }
            else
            {
                Report.WriteLine("No Quotes are available for this Customer Account");
            }

        }
        

        [When(@"The quote contained the accessorial (.*)")]
        public void WhenTheQuoteContainedTheAccessorial(string Notification)
        {
            string Notification1 = Notification.Replace(@"<", "");
            string Notificationacc = Notification1.Replace(@">", "");

            if (QuoteContainsNotification == Notificationacc)
            {
                Report.WriteLine("Quote are contaning the Notification accessorial");
            }
            else
            {
                Report.WriteLine("Quotes are not available with the Notification accessorial");
            }
            
        }

        [Then(@"I will see (.*) displayed in the Additional Services and Accessorials section")]
        public void ThenIWillSeeDisplayedInTheAdditionalServicesAndAccessorialsSection(string Notification)
        {
            string Notification1 = Notification.Replace(@"<", "");
            string Notificationacc = Notification1.Replace(@">", "");

            if (QuoteContainsNotification == Notificationacc)
            {
                Report.WriteLine("Verififying the Notification in Additional Services and Accessorials section of Quote details ");
                scrollpagedown();
                scrollpagedown();
                GlobalVariables.webDriver.WaitForPageLoad();
                Verifytext(attributeName_xpath, QuoteDetails_AdditionlaServicesAndAccessorials_Header_Xpath, "ADDITIONAL SERVICES AND ACCESSORIALS");       
                string allaccessorial = Gettext(attributeName_xpath, QuoteDetails_AdditionalServicesAndAccessorials_value_xpath);
                if(allaccessorial.Contains(Notificationacc))
                {
                    Report.WriteLine("Notification is available in the detail section");
                }

            }
            else
            {
                Report.WriteLine("Quotes are not available with the Notification accessorial");
            }

        }

    }
}

