using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.OverLength_GetQuote_LTL_;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Confirmation_Screen
{
    [Binding]
    public class Quote_Confirmation__LTL____New_Accessorial___NotificationSteps : ObjectRepository
    {
        AddQuoteLTL getQuoteLTL = new AddQuoteLTL();
        public string DimensionValue = "9";
        public string ShipFromAccessorial;
        public string ShipToAccessorial;
        public string Insuredvalue = "1234";
        public string QuoteConfirmationpageText = "Quote Confirmation";
        public string guaranteedLink;


        [Given(@"I passed all mandatory information on the Get Quote LTL page")]
        public void GivenIPassedAllMandatoryInformationOnTheGetQuoteLTLPage()
        {
            OverLength_GetQuote_LTL__NewFields getquote = new OverLength_GetQuote_LTL__NewFields();
            getquote.GivenIAmOnTheGetQuoteLTLPage();
            
            Click(attributeName_id, ClearAddress_FromId);
            getQuoteLTL.EnterOriginZip("33126");
            Click(attributeName_id, ClearAddress_DestId);
            getQuoteLTL.EnterDestinationZip("85282");

          
        }


        [Given(@"I selected (.*) in the Click to add services and accessorials field of the Shipping From Section")]
        public void GivenISelectedInTheClickToAddServicesAndAccessorialsFieldOfTheShippingFromSection(string p0)
        {
            DefineTimeOut(3000);
            ShipFromAccessorial = Regex.Replace(p0, @"(\s+|&|'|\(|\)|<|>|#)", "");
            getQuoteLTL.selectShippingfromServices(ShipFromAccessorial);

            
            Click(attributeName_id, LTL_OriginZipPostal_Id);
            getQuoteLTL.EnterItemdata("50", "1000");
            SendKeys(attributeName_id, LTL_Quantity_Id, "5");
            string enteredValue = Regex.Replace(DimensionValue, @"(\s+|&|'|\(|\)|<|>|#)", "");
            
            getQuoteLTL.EnterLWH(enteredValue, enteredValue, enteredValue, "");
            Report.WriteLine("Entering data in Enter Insured value text box");

            List<string> Accessorial_UI = new List<string>();
            IList<IWebElement> Accessorial_List_UI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='servicesaccessorialsfrom_chosen']/ul/li/span"));
            int AccessorialList_UICount = Accessorial_List_UI.Count;
            for (int a = 0; a < AccessorialList_UICount; a++)
            {
                string Staionname_UI = Accessorial_List_UI[a].Text.ToString();
                Accessorial_UI.Add(Staionname_UI);
            }

            for(int i=0; i< AccessorialList_UICount; i++)
            {
                if (Accessorial_List_UI[i].Text.Equals("Overlength"))
                {
                    Click(attributeName_xpath, LTL_Quote_EnteredLengthExceedsPopUp_RemoveOption_Item_Xpath);
                }

            }

            
            SendKeys(attributeName_id, LTL_EnterInsuredValue_Id, Insuredvalue);
            Thread.Sleep(2000);
            getQuoteLTL.ClickViewRates();


        }


        [Given(@"I selected (.*) in the Click to add services and accessorials field of the Shipping To Section")]
        public void GivenISelectedInTheClickToAddServicesAndAccessorialsFieldOfTheShippingToSection(string p0)
        {
            ShipToAccessorial = Regex.Replace(p0, @"(\s+|&|'|\(|\)|<|>|#)", "");
            getQuoteLTL.selectShippingToServices(ShipToAccessorial);

            Click(attributeName_id, LTL_OriginZipPostal_Id);
            getQuoteLTL.EnterItemdata("50", "1000");
            SendKeys(attributeName_id, LTL_Quantity_Id, "5");
            string enteredValue = Regex.Replace(DimensionValue, @"(\s+|&|'|\(|\)|<|>|#)", "");

            getQuoteLTL.EnterLWH(enteredValue, enteredValue, enteredValue, "");
            Report.WriteLine("Entering data in Enter Insured value text box");

            List<string> Accessorial_UI = new List<string>();
            IList<IWebElement> Accessorial_List_UI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='servicesaccessorialsto_chosen']/ul/li/span"));
            int AccessorialList_UICount = Accessorial_List_UI.Count;
            for (int a = 0; a < AccessorialList_UICount; a++)
            {
                string Staionname_UI = Accessorial_List_UI[a].Text.ToString();
                Accessorial_UI.Add(Staionname_UI);
            }

            for (int i = 0; i < AccessorialList_UICount; i++)
            {
                if (Accessorial_List_UI[i].Text.Equals("Overlength"))
                {
                    Click(attributeName_xpath, LTL_Quote_EnteredLengthExceedsPopUp_RemoveOption_Item_Xpath);
                }

            }
            SendKeys(attributeName_id, LTL_EnterInsuredValue_Id, Insuredvalue);

            getQuoteLTL.ClickViewRates();
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Given(@"I Clicked on the (.*) on the Quote Results LTL pag")]
        public void GivenIClickedOnTheOnTheQuoteResultsLTLPag(string Quote_Type)
        {
            string verifyQuotes = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']//h5");
            if (verifyQuotes.Equals("There are no rates available for this shipment."))
            {
                Report.WriteLine("There are no rates available for this shipment.");
                Click(attributeName_xpath, ".//*[@id='no-results-save-quote']");
                GlobalVariables.webDriver.WaitForPageLoad();

            }
            else
            {
                if (Quote_Type.Equals("Rate As Quote"))
                {

                    Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]//a");
                }
                else if (Quote_Type.Equals("Insured Rate As Quote"))
                {
                    Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]//a");
                }
                else if (Quote_Type.Equals("Guaranteed Rate As Quote"))
                {
                    guaranteedLink = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]//a");
                    if(guaranteedLink.Equals("Guaranteed Rate Available"))
                    {
                        Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[4]//a");

                    }else
                    {
                        Report.WriteLine("No Guaranteed Rates Available");

                        Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]//a");
                        Report.WriteLine("Clicking on the Insured Rate As Quote");
                    }

                }
                else if ((Quote_Type.Equals("Guaranteed Insured Rate As Quote")))
                {
                    guaranteedLink = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]//a");
                    if (guaranteedLink.Equals("Guaranteed Rate Available"))
                    {
                        Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[5]//a");

                    }
                    else
                    {
                        Report.WriteLine("No Guaranteed Rates Available");
                        Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]//a");
                        Report.WriteLine("Clicking on the Insured Rate As Quote");
                    }

                }
            }

        }


        [Given(@"I arrive on the Quote Confirmation LTL page")]
        public void GivenIArriveOnTheQuoteConfirmationLTLPage()
        {
            
            Report.WriteLine("Verify the LTL quote Confirmation header");
            Thread.Sleep(25000);
            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath, "confirmpage");
            string QuoteConfirmationPageHeader_UI = Gettext(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath);
            Assert.AreEqual(QuoteConfirmationpageText, QuoteConfirmationPageHeader_UI);
        }

        [When(@"I expand the Show Quote Details section")]
        public void WhenIExpandTheShowQuoteDetailsSection()
        {
            Click(attributeName_id, LTL_QC_ShowQuoteDetails_Id);
        }


        [Then(@"I will see Notification displayed in the Ship From field of the Services and Accessorials section")]
        public void ThenIWillSeeNotificationDisplayedInTheShipFromFieldOfTheServicesAndAccessorialsSection()
        {
            scrollpagedown();
            Report.WriteLine("ShouldBeDisplayedWithNAinshipfromfield");
            Thread.Sleep(2000);
            string actualAccessorials = Gettext(attributeName_xpath, LTL_QC_shipfromservicesvalues);
            string[] actual_Accessorials= actualAccessorials.Split(',');
           
            
           
            for (int i = 0; i < actual_Accessorials.Length; i++)
            {
                
                if (actual_Accessorials[i].Contains("Notification"))
                {
                    Report.WriteLine("Services and accessorials section contains the Notification in Ship From section" + actual_Accessorials[i]);
                    break;
                }
                else
                {
                    Report.WriteLine("Services and accessorials section does contains the Notification in Ship From section" + actual_Accessorials[i]);
                }


            }
        }


        [Then(@"I will see Notification displayed in the Ship To field of the Services and Accessorials section")]
        public void ThenIWillSeeNotificationDisplayedInTheShipToFieldOfTheServicesAndAccessorialsSection()
        {
            Report.WriteLine("ShouldBeDisplayedWithNAinshipfromfield");
            Thread.Sleep(2000);
            string actualAccessorials = Gettext(attributeName_xpath, LTL_QC_shiptoservicesvalues);
            string[] actual_Accessorials = actualAccessorials.Split(',');
            int count = actualAccessorials.Length;

            for (int i = 0; i < count; i++)
            {
                if (actual_Accessorials[i].Contains("Notification"))
                {
                    Report.WriteLine("Services and accessorials section contains the Notification in Ship To section" + actual_Accessorials[i]);
                    break;
                }
                else
                {
                    Report.WriteLine("Services and accessorials section does contains the Notification in Ship To section" + actual_Accessorials[i]);
                }


            }
        }










    }
}
