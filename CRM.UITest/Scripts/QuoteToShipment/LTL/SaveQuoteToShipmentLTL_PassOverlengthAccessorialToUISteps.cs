
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium;
using CRM.UITest.Helper.Common;
using System.Net.Http;
using CRM.UITest.Helper.Implementations.ShipmentExtract;
using CRM.UITest.Helper.ViewModel;
using System.Collections;

namespace CRM.UITest.Scripts.QuoteToShipment.LTL
{
    [Binding]
    public class SaveQuoteToShipmentLTL_PassOverlengthAccessorialToUISteps : Quotelist
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string quoteNumber = null;
        AddQuoteLTL createQuote = new AddQuoteLTL();
        string refNumber;
        string warning = "//div[@id='Length-Additional-Warning-0']/h4/i[2]";
        private ShipmentExtractViewModel shipmentViewModels;

        [Given(@"I am a shp\.entry, sales, sales management, operations, or station owner")]
        public void GivenIAmAShp_EntrySalesSalesManagementOperationsOrStationOwner()
        {
            string userName = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am in the Quote Details of an active LTL quote")]
        public void GivenIAmInTheQuoteDetailsOfAnActiveLTLQuote()
        {
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, Quote_LTLRadioButton_Id);
            Click(attributeName_xpath, GetQuoteButton_Xpath);
        }
        

        [Given(@"clicked on the Create Shipment button")]
        public void GivenClickedOnTheCreateShipmentButton()
        {
            
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, "searchbox", refNumber);

            Report.WriteLine("Expanding the saved quote");
            Click(attributeName_xpath, QuoteExpandIcon_Xpath);
            Thread.Sleep(9000);
            Report.WriteLine("Clicking on create shipment button");
            Click(attributeName_id, QuoteDetails_CreateShipButton_Id);
        }

        [Given(@"the saved quote had Overlength selected in the Shipping From section")]
        public void GivenTheSavedQuoteHadOverlengthSelectedInTheShippingFromSection()
        {
            SendKeys(attributeName_id, QuoteDetails_Origin_AddressZip_Id, "33126");
            SendKeys(attributeName_id, QuoteDetails_Destination_AddressZip_Id, "33126");
            Click(attributeName_xpath, GetQuote_ServiceAccessorialDrodown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, GetQuote_ServiceAccessorialDrodownValues_Xpath, "Overlength");
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id, "10");
            SendKeys(attributeName_id, SelectSavedItem_Id, "60");
            SendKeys(attributeName_id, QuoteDetails_FreightInfo_Weightfield_id, "777");
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id, "110");
            Click(attributeName_xpath, ".//*[@id='Length-Additional-Warning-0']/h4/i[2]");
            Thread.Sleep(3000);
            Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Save the quote");
            Click(attributeName_xpath, QuoteResult_LTL_SaveQuoteLink_Xpath);
            Report.WriteLine("Clicking Back to quote list button");
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteNumber = Gettext(attributeName_id, QC_RequestNumber_id);
            Click(attributeName_xpath, QuoteConfirmation_BackToQuoteListButton_Xpath);
           

        }
        [Given(@"I submit a LTL Quote (.*) with Overlength accessorial")]
        public void GivenISubmitALTLQuoteWithOverlengthAccessorial(string QuoteType)
        {

            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, Quote_LTLRadioButton_Id);
            Click(attributeName_xpath, GetQuoteButton_Xpath);
            Click(attributeName_id, ClearAddress_OriginId);
            createQuote.EnterOriginZip("33126");
            Click(attributeName_id, ClearAddress_DestId);
            createQuote.EnterDestinationZip("85282");
            Click(attributeName_id, LTL_ClearItem_Id);

            SendKeys(attributeName_id, SelectSavedItem_Id, "50");
            SendKeys(attributeName_id, QuoteDetails_FreightInfo_Weightfield_id, "777");
            SendKeys(attributeName_id, LTL_Quan_Id, "4");
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id, "96");
            SendKeys(attributeName_id, LTL_Width_Id, "97");
            SendKeys(attributeName_id, LTL_Height_Id, "98");
            
           

            //--- Adding first Additional Item------
            Click(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath);

            SendKeys(attributeName_id, LTL_Additional_SelectClass_Id, "60");
            SendKeys(attributeName_id, LTL_Additinal_Weight_Id, "1000");
            SendKeys(attributeName_id, LTL_Additional_Quantity_Id, "5");
           
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id_Additional, "12");
            SendKeys(attributeName_id, QuoteLTLPage_Width_Id_Additional, "96");
            SendKeys(attributeName_id, QuoteLTLPage_Height_Id_Additional, "96");
        

            //--- Adding second Additional Item------
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath);
            scrollpagedown();
            SendKeys(attributeName_xpath, QuoteLTLPage_SavedItem3_xpath, "70");
            SendKeys(attributeName_id, LTL_Additional_Weight_2_Id, "2345");
            SendKeys(attributeName_id, LTL_Additional_Quantity2_Id, "6");
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id_Second_Additional, "104");
            SendKeys(attributeName_id, QuoteLTLPage_Width_Id_Second_Additional, "96");
            SendKeys(attributeName_id, QuoteLTLPage_Height_Id_Second_Additional, "96");
           
           
            Click(attributeName_xpath, "//div[@id='Length-Additional-Warning-2']/h4/i[2]");
            Thread.Sleep(3000);
            Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

           
            bool elementCheck = IsElementPresent(attributeName_xpath, "//div[@class='col-md-12 no-results-content']/h5", "There are no rates available for this shipment.");
           
            if (elementCheck.Equals(true) )
            {
                Click(attributeName_xpath, "//a[@class='no-results-saveQtxt']");

            }
            else
            {
                if (QuoteType.Equals("Standard Quote"))
                {
                    Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[2]/li/a");
                }
                else if (QuoteType.Equals("Insured Quote"))
                {
                    SendKeys(attributeName_xpath, GetQuoteInsuredVal_Xpath, "100");
                    GlobalVariables.webDriver.WaitForPageLoad();
                    Click(attributeName_xpath, QuoteResultShowInsuredRateButton_Xpath);
                    GlobalVariables.webDriver.WaitForPageLoad();
                    Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[2]/li/a");
                }

            }

            refNumber = Gettext(attributeName_id, "referenceNumber-value");
            Click(attributeName_xpath, ltlBacktoQuoteListBtn_xpath);
        }

        [Given(@"I submit a LTL Quote with Overlength and other accessorial in shipping from accessorial and adding other accessorial in shipping To section")]
        public void GivenISubmitALTLQuoteWithOverlengthAndOtherAccessorialInShippingFromAccessorialAndAddingOtherAccessorialInShippingToSection()
        {
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, Quote_LTLRadioButton_Id);
            Click(attributeName_xpath, GetQuoteButton_Xpath);
            Click(attributeName_id, ClearAddress_OriginId);
            createQuote.EnterOriginZip("33126");
            Click(attributeName_id, ClearAddress_DestId);
            createQuote.EnterDestinationZip("85282");
            Click(attributeName_id, LTL_ClearItem_Id);
            Report.WriteLine("Adding Accessorial in shoping from section");
            Click(attributeName_xpath, GetQuote_ShippingFrom_ServicesAccessorial_DropDown_xpath);
            IList<IWebElement> AccessorialDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(GetQuote_ShippingFrom_ServicesAccessorial_DropDown_Value_xpath));
            int AccessorialDropdownListCount = AccessorialDropdown_List.Count;
            for (int i = 0; i < AccessorialDropdownListCount; i++)
            {
                if (AccessorialDropdown_List[i].Text == "Appointment")
                {
                    AccessorialDropdown_List[i].Click();
                    break;
                }
            }

            Report.WriteLine("Adding Accessorial in shoping To section");

            Click(attributeName_xpath, GetQuote_ShippingTo_ServicesAccessorial_DropDown_xpath);
            IList<IWebElement> AccessorialToDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(GetQuote_ShippingTo_ServicesAccessorial_DropDown_Value_xpath));
            int AccessorialTODropdownListCount = AccessorialToDropdown_List.Count;
            for (int i = 0; i < AccessorialTODropdownListCount; i++)
            {
                if (AccessorialToDropdown_List[i].Text == "COD")
                {
                    AccessorialToDropdown_List[i].Click();
                    break;
                }
            }



            SendKeys(attributeName_id, SelectSavedItem_Id, "50");
            SendKeys(attributeName_id, QuoteDetails_FreightInfo_Weightfield_id, "777");
            SendKeys(attributeName_id, LTL_Quan_Id, "4");
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id, "96");
            SendKeys(attributeName_id, LTL_Width_Id, "97");
            SendKeys(attributeName_id, LTL_Height_Id, "98");

            //--- Adding first Additional Item------
            Click(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath);

            SendKeys(attributeName_id, LTL_Additional_SelectClass_Id, "60");
            SendKeys(attributeName_id, LTL_Additinal_Weight_Id, "1000");
            SendKeys(attributeName_id, LTL_Additional_Quantity_Id, "5");

            SendKeys(attributeName_id, QuoteLTLPage_Length_Id_Additional, "12");
            SendKeys(attributeName_id, QuoteLTLPage_Width_Id_Additional, "96");
            SendKeys(attributeName_id, QuoteLTLPage_Height_Id_Additional, "96");


            //--- Adding second Additional Item------
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath);
            scrollpagedown();
            SendKeys(attributeName_xpath, QuoteLTLPage_SavedItem3_xpath, "70");
            SendKeys(attributeName_id, LTL_Additional_Weight_2_Id, "2345");
            SendKeys(attributeName_id, LTL_Additional_Quantity2_Id, "6");
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id_Second_Additional, "104");
            SendKeys(attributeName_id, QuoteLTLPage_Width_Id_Second_Additional, "96");
            SendKeys(attributeName_id, QuoteLTLPage_Height_Id_Second_Additional, "96");


            Click(attributeName_xpath, "//div[@id='Length-Additional-Warning-2']/h4/i[2]");
            Thread.Sleep(3000);
            Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();


            bool elementCheck = IsElementPresent(attributeName_xpath, "//div[@class='col-md-12 no-results-content']/h5", "There are no rates available for this shipment.");

            if (elementCheck.Equals(true))
            {
                Click(attributeName_xpath, "//a[@class='no-results-saveQtxt']");

            }
            else
            {
                           
                Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[2]/li/a");                     

            }

            refNumber = Gettext(attributeName_id, "referenceNumber-value");
            Click(attributeName_xpath, ltlBacktoQuoteListBtn_xpath);
        }    


        [Then(@"the accessorial Overlength should be selected in the Shipping From section not in the Shipping To Section")]
        public void ThenTheAccessorialOverlengthShouldBeSelectedInTheShippingFromSectionNotInTheShippingToSection()
        {
            string expectedSelectedAccessorial = "Overlength";
            string actualSelectedAccessorial = Gettext(attributeName_xpath, LTLAddShipment_SelectedAccessorial_ShippingFrom_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='shippingfromaccessorial_chosen']/ul/li"));
            for (int i = 1; i < DropDownList.Count; i++)
            {
                string Actaulaccessorial = Gettext(attributeName_xpath, ".//*[@id='shippingfromaccessorial_chosen']/ul/li[" + i + "]");
                if (Actaulaccessorial.Equals(expectedSelectedAccessorial))
                {
                    Report.WriteLine("Overlength accessorial is binding in Shipping From Section");
                    break;

                }
                if (i == DropDownList.Count && !Actaulaccessorial.Equals(expectedSelectedAccessorial))
                { Report.WriteFailure("Overlength accessorial is not Binded in shipping from section"); }
            }

            IList<IWebElement> DropDownList1 = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='shippingtoaccessorial_chosen']/ul/li"));
            for (int i = 1; i < DropDownList1.Count; i++)
            {
                string Actaulaccessorial = Gettext(attributeName_xpath, ".//*[@id='shippingtoaccessorial_chosen']/ul/li[" + i + "]");
                if (Actaulaccessorial.Equals(expectedSelectedAccessorial))
                {
                    Report.WriteFailure("Overlength accessorial is binding in Shipping To Section which is not expectable");
                    break;

                }
            }
        }

        [Then(@"Other accessorial should be selected  in shopping from and to section")]
        public void ThenOtherAccessorialShouldBeSelectedInShoppingFromAndToSection()
        {
            string expectedSelectedFromOtherAccessorial = "Appointment";
            string expectedSelectedToOtherAccessorial = "COD";
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='shippingfromaccessorial_chosen']/ul/li"));
            for (int i = 1; i < DropDownList.Count; i++)
            {
                string Actaulaccessorial = Gettext(attributeName_xpath, ".//*[@id='shippingfromaccessorial_chosen']/ul/li[" + i + "]");
                if (Actaulaccessorial.Equals(expectedSelectedFromOtherAccessorial))
                {
                    Report.WriteLine("Other accessorial is binding in Shipping From Section");
                    break;

                }
                if (i == DropDownList.Count && !Actaulaccessorial.Equals(expectedSelectedFromOtherAccessorial))
                { Report.WriteFailure("Other accessorial is not Binded in shipping from section"); }
            }

            IList<IWebElement> DropDownList1 = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='shippingtoaccessorial_chosen']/ul/li"));
            for (int i = 1; i < DropDownList1.Count; i++)
            {
                string Actaulaccessorial = Gettext(attributeName_xpath, ".//*[@id='shippingtoaccessorial_chosen']/ul/li[" + i + "]");
                if (Actaulaccessorial.Equals(expectedSelectedToOtherAccessorial))
                {
                    Report.WriteLine("Other accessorial is binding in Shipping To Section");
                    break;

                }
                if (i == DropDownList.Count && !Actaulaccessorial.Equals(expectedSelectedToOtherAccessorial))
                { Report.WriteFailure("Other accessorial is not Binded in shipping To section"); }
            }
        }


        [Then(@"the accessorial Overlength should be selected in the Shipping From section")]
        public void ThenTheAccessorialOverlengthShouldBeSelectedInTheShippingFromSection()
        {
            
            string expectedSelectedAccessorial = "Overlength";
            string actualSelectedAccessorial = Gettext(attributeName_xpath, LTLAddShipment_SelectedAccessorial_ShippingFrom_Xpath);
            Assert.AreEqual(expectedSelectedAccessorial, actualSelectedAccessorial);
        }
        [Then(@"MG Should contain All accessorial")]
        public void ThenMGShouldContainAllAccessorial()
        {
            List<string> ActualaccessorialList = new List<string>();
            ActualaccessorialList.Add("Appointment");
            ActualaccessorialList.Add("COD");
            ActualaccessorialList.Add("Overlength 8 feet");
            int addedaccessorialcount = ActualaccessorialList.Count;
            Report.WriteLine("MG get data started");
            string uri = $"MercuryGate/OidLookup";
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

            ShipmentExtract ext = new ShipmentExtract();
            shipmentViewModels = ext.getShipmentData(uri, headers, refNumber, "Admin");
            int AccessorialcountfromMG = shipmentViewModels.ShipmentDetailsViewModel.AdditionalServices.Count;
            IList accessorialMG = shipmentViewModels.ShipmentDetailsViewModel.AdditionalServices;
            Report.WriteLine("Comparing MG Accessorial with user given");
            if (AccessorialcountfromMG == addedaccessorialcount)
            {
                foreach(string acc in ActualaccessorialList)
                {
                    if(accessorialMG.Contains(acc))
                    { Report.WriteLine(acc + "Accessorial Presnt in MG"); }
                    else
                    { Report.WriteFailure(acc + "Accessorial Not Presnt in MG"); }
                }
            }
            else
            { Report.WriteFailure("Actual accessorials count are not amtching with MG accessorials");
            }
            Report.WriteLine("MG Accessorial validation Completed");
        }


    }
}
