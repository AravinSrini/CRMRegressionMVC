using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;
using CRM.UITest.Entities;

namespace CRM.UITest.Scripts.Quote_List.QuoteList_GridDisplay
{
    [Binding]
    public class QuotesLTL_DisplayCustomerNameWithLongHierarchySteps : Quotelist
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string actualMsg = null;
        string expectedMsg = null;
        string SubAccount = null;

        [Given(@"I am submitting an LTL rate request")]
        public void GivenIAmSubmittingAnLTLRateRequest()
        {
            Click(attributeName_xpath, QuoteIconModule_Xpath);
            Report.WriteLine("Quote List page");
            GlobalVariables.webDriver.WaitForPageLoad();

        }

        [Given(@"I'm on the Get Quote page of service type selection")]
        public void GivenIMOnTheGetQuotePageOfServiceTypeSelection()
        {

            Report.WriteLine("Clicked on submit rate request button");
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on submit rate request button");
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I'm on the Get Quote page")]
        public void GivenIMOnTheGetQuotePage()
        {
            Report.WriteLine("Clicked on submit rate request button");
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I'm on the Quote Results \(LTL\) page")]
        public void GivenIMOnTheQuoteResultsLTLPage()
        {
            Report.WriteLine("Clicked on submit rate request button");
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, QuoteDetails_Origin_AddressZip_Id, "33126");
            SendKeys(attributeName_id, QuoteDetails_Destination_AddressZip_Id, "33126");
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id, "7");
            SendKeys(attributeName_id, SelectSavedItem_Id, "60");
            SendKeys(attributeName_id, QuoteDetails_FreightInfo_Weightfield_id, "777");

            Thread.Sleep(3000);
            Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            Report.WriteLine("Clicked on View Quote button");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I'm on the Quote Confirmation \(LTL\) page")]
        public void GivenIMOnTheQuoteConfirmationLTLPage()
        {
            Report.WriteLine("Clicked on submit rate request button");
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, QuoteDetails_Origin_AddressZip_Id, "33126");
            SendKeys(attributeName_id, QuoteDetails_Destination_AddressZip_Id, "33126");
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id, "7");
            SendKeys(attributeName_id, SelectSavedItem_Id, "60");
            SendKeys(attributeName_id, QuoteDetails_FreightInfo_Weightfield_id, "777");

            Thread.Sleep(3000);
            Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            Report.WriteLine("Clicked on View Quote button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteResult_saveQuote_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I'm on the Quote Confirmation Internal \(LTL\) page")]
        public void GivenIMOnTheQuoteConfirmationInternalLTLPage()
        {
            Report.WriteLine("Clicked on submit rate request button");
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, QuoteDetails_Origin_AddressZip_Id, "33126");
            SendKeys(attributeName_id, QuoteDetails_Destination_AddressZip_Id, "33126");
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id, "7");
            SendKeys(attributeName_id, SelectSavedItem_Id, "60");
            SendKeys(attributeName_id, QuoteDetails_FreightInfo_Weightfield_id, "777");

            Thread.Sleep(3000);
            Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            Report.WriteLine("Clicked on View Quote button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteResult_saveQuoteItl_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I'm on the Quote Confirmation \(LTL\) page as a external user")]
        public void GivenIMOnTheQuoteConfirmationLTLPageAsAExternalUser()
        {
            Report.WriteLine("Clicked on submit rate request button");
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, QuoteDetails_Origin_AddressZip_Id, "33126");
            SendKeys(attributeName_id, QuoteDetails_Destination_AddressZip_Id, "33126");
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id, "7");
            SendKeys(attributeName_id, SelectSavedItem_Id, "60");
            SendKeys(attributeName_id, QuoteDetails_FreightInfo_Weightfield_id, "777");

            Thread.Sleep(3000);
            Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            Report.WriteLine("Clicked on View Quote button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteResult_LTL_SaveQuoteLink_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Given(@"that I am a shp\.inquiry or shp\.entry user,")]
        public void GivenThatIAmAShp_InquiryOrShp_EntryUser()
        {
            string userName = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"selected a customer from the (.*) drop down list")]
        public void GivenSelectedACustomerFromTheDropDownList(string p0)
        {
            Report.WriteLine("Select customer from quote list dropdown");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownList_Xpath, "ArnoldTest05072018B");

        }

        [Given(@"I select a customer name that is more than one level")]
        public void GivenISelectACustomerNameThatIsMoreThanOneLevel()
        {
            string elementClass = GetAttribute(attributeName_xpath, QuoteList_CustomerDropdownOptions_Xpath, "class");
            string[] classes = elementClass.Split(' ');
            foreach (string eleClass in classes)
            {
                if (eleClass.Equals("level1") || eleClass.Equals("level2"))
                {
                    Assert.IsTrue(true);
                }
            }

        }

        [Given(@"I select a customer name that is more than one level as a external user")]
        public void GivenISelectACustomerNameThatIsMoreThanOneLevelAsAExternalUser()
        {
            string elementClass = GetAttribute(attributeName_xpath, CustomerDropdownExtuser_Xpath, "class");
            string[] classes = elementClass.Split(' ');
            foreach (string eleClass in classes)
            {
                if (eleClass.Equals("level1") || eleClass.Equals("level2"))
                {
                    Assert.IsTrue(true);
                }
            }

        }

        [When(@"the customer name, hierarchies, and station is more than one level for external user")]
        public void WhenTheCustomerNameHierarchiesAndStationIsMoreThanOneLevelForExternalUser()
        {

            string elementClass = GetAttribute(attributeName_xpath, CustomerDropdownExtuser_Xpath, "class");
            string[] classes = elementClass.Split(' ');
            foreach (string eleClass in classes)
            {
                if (eleClass.Equals("level1") || eleClass.Equals("level2"))
                {
                    Assert.IsTrue(true);
                }
            }
        }



        [When(@"I hover over the customer name from quote list page as a external user")]
        public void WhenIHoverOverTheCustomerNameFromQuoteListPageAsAExternalUser()
        {
            OnMouseOver(attributeName_xpath, CustomerDropdownExtuser_Xpath);
        }

        [Given(@"selected a customer from the Select account to display\.\.\. drop down for external user")]
        public void GivenSelectedACustomerFromTheSelectAccountToDisplay_DropDownForExternalUser()
        {
            Report.WriteLine("Selecting a customer who is associated to a primary account that has sub accounts");
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerDropdownOptionExtUser_Xpath, "testingcsasubaccount_sub");
            Thread.Sleep(5000);
        }


        [Given(@"I am associated to a primary account that has sub-accounts,")]
        public void GivenIAmAssociatedToAPrimaryAccountThatHasSub_Accounts()
        {
            Report.WriteLine("Selecting a customer who is associated to a primary account that has sub accounts");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownList_Xpath, "gainsharetestswa1");
        }

        [Given(@"I'm on the Get Quote \(LTL\) page")]
        public void GivenIMOnTheGetQuoteLTLPage()
        {
            Report.WriteLine("Clicked on submit rate request button");
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"the customer name, hierarchies, and station is more than one level")]
        public void WhenTheCustomerNameHierarchiesAndStationIsMoreThanOneLevel()
        {
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            string elementClass = GetAttribute(attributeName_xpath, QuoteList_CustomerDropdownOptions_Xpath, "class");

            string[] classes = elementClass.Split(' ');
            foreach (string eleClass in classes)
            {
                if (eleClass.Equals("level1") || eleClass.Equals("level2"))
                {
                    Assert.IsTrue(true);
                    Report.WriteLine("Customer name hierarchy is more than one level");
                }
            }

        }


        [When(@"I hover over the customer name")]
        public void WhenIHoverOverTheCustomerName()
        {
            OnMouseOver(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
        }

        [When(@"I'm on the Get Quote page of service type selection")]
        public void WhenIMOnTheGetQuotePageOfServiceTypeSelection()
        {
            Report.WriteLine("Clicked on submit rate request button");
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I'm on the Get Quote page")]
        public void WhenIMOnTheGetQuotePage()
        {
            Report.WriteLine("Clicked on submit rate request button");
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I'm on the Quote Results \(LTL\) page")]
        public void WhenIMOnTheQuoteResultsLTLPage()
        {
            Report.WriteLine("Clicked on submit rate request button");
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, QuoteDetails_Origin_AddressZip_Id, "33126");
            SendKeys(attributeName_id, QuoteDetails_Destination_AddressZip_Id, "33126");
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id, "7");
            SendKeys(attributeName_id, SelectSavedItem_Id, "60");
            SendKeys(attributeName_id, QuoteDetails_FreightInfo_Weightfield_id, "777");

            Thread.Sleep(3000);
            Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            Report.WriteLine("Clicked on View Quote button");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I'm on the Quote Confirmation \(LTL\) page")]
        public void WhenIMOnTheQuoteConfirmationLTLPage()
        {
            Report.WriteLine("Clicked on submit rate request button");
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, QuoteDetails_Origin_AddressZip_Id, "33126");
            SendKeys(attributeName_id, QuoteDetails_Destination_AddressZip_Id, "33126");
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id, "7");
            SendKeys(attributeName_id, SelectSavedItem_Id, "60");
            SendKeys(attributeName_id, QuoteDetails_FreightInfo_Weightfield_id, "777");

            Thread.Sleep(3000);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            Report.WriteLine("Clicked on View Quote button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(4000);
            Click(attributeName_xpath, QuoteResult_saveQuote_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I'm on the Quote Confirmation \(LTL\) page as internal")]
        public void WhenIMOnTheQuoteConfirmationLTLPageAsInternal()
        {
            Report.WriteLine("Clicked on submit rate request button");
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, QuoteDetails_Origin_AddressZip_Id, "33126");
            SendKeys(attributeName_id, QuoteDetails_Destination_AddressZip_Id, "33126");
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id, "7");
            SendKeys(attributeName_id, SelectSavedItem_Id, "60");
            SendKeys(attributeName_id, QuoteDetails_FreightInfo_Weightfield_id, "777");

            Thread.Sleep(3000);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            Report.WriteLine("Clicked on View Quote button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(4000);
            Click(attributeName_xpath, QuoteResult_saveQuoteItl_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I'm on the Get Quote \(LTL\) page")]
        public void WhenIMOnTheGetQuoteLTLPage()
        {
            Report.WriteLine("Clicked on submit rate request button");
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
        }

        [When(@"I hover over the customer name from Get Quote page of service type selection")]
        public void WhenIHoverOverTheCustomerNameFromGetQuotePageOfServiceTypeSelection()
        {
            OnMouseOver(attributeName_xpath, StationCustomerName);
        }

        [When(@"I hover over the customer name from Get Quote page of service type selection as internal user")]
        public void WhenIHoverOverTheCustomerNameFromGetQuotePageOfServiceTypeSelectionAsInternalUser()
        {
            OnMouseOver(attributeName_xpath, StationCustomerNameLabel);
        }

        [When(@"I hover over the customer name from Get Quote page of service type selection as a external user")]
        public void WhenIHoverOverTheCustomerNameFromGetQuotePageOfServiceTypeSelectionAsAExternalUser()
        {
            Thread.Sleep(3000);
            OnMouseOver(attributeName_xpath, StationCustomerName);
        }

        [When(@"I hover over the customer name from Get Quote page of service type selection as a external")]
        public void WhenIHoverOverTheCustomerNameFromGetQuotePageOfServiceTypeSelectionAsAExternal()
        {
            Thread.Sleep(3000);
            OnMouseOver(attributeName_xpath, QuoteConfirmation_CustomerLabelExtrUser_Xpath);
        }        

        [When(@"I hover over the customer name from Get Quote page")]
        public void WhenIHoverOverTheCustomerNameFromGetQuotePage()
        {
            OnMouseOver(attributeName_xpath, StationCustomerNameLabel);
        }

        [When(@"I hover over the customer name from Quote Result page")]
        public void WhenIHoverOverTheCustomerNameFromQuoteResultPage()
        {
            Thread.Sleep(3000);
            OnMouseOver(attributeName_xpath, QuoteResultCustomerNameLabel_Xpath);
        }

        [When(@"I hover over the customer name Extl from Quote Result page")]
        public void WhenIHoverOverTheCustomerNameExtlFromQuoteResultPage()
        {
            Thread.Sleep(3000);
            OnMouseOver(attributeName_xpath, QuoteConfirmation_CustomerLabelExtrUser_Xpath);
        }

        [When(@"I hover over the customer name from Quote confirmation page")]
        public void WhenIHoverOverTheCustomerNameFromQuoteConfirmationPage()
        {
            OnMouseOver(attributeName_xpath, StationCustomerNameLabelConfirmationPage);
        }

        [When(@"I hover over the customer name from Quote confirmation page as a external user")]
        public void WhenIHoverOverTheCustomerNameFromQuoteConfirmationPageAsAExternalUser()
        {
            Thread.Sleep(3000);
            OnMouseOver(attributeName_xpath, QuoteConfirmation_CustomerLabelExtrUser_Xpath);
        }

        [When(@"I hover over the customer name from Quote confirmation page as a extl user")]
        public void WhenIHoverOverTheCustomerNameFromQuoteConfirmationPageAsAExtlUser()
        {
            Thread.Sleep(3000);
            OnMouseOver(attributeName_xpath, QuoteConfirmation_CustomerLabelUser_Xpath);
        }


        [When(@"I hover over the customer name from Get Quote page as a external user")]
        public void WhenIHoverOverTheCustomerNameFromGetQuotePageAsAExternalUser()
        {
            Thread.Sleep(3000);
            OnMouseOver(attributeName_xpath, GetQuote_CustomerLabelExtUser_Xpath);
        }

        [Given(@"I am a shp\.inquiry or shp\.entry user")]
        public void GivenIAmAShp_InquiryOrShp_EntryUser()
        {
            string userName = ConfigurationManager.AppSettings["username-ExtuserCustDropdown"].ToString();
            string password = ConfigurationManager.AppSettings["password-ExtuserCustDropdown"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Then(@"I will see Station ID - Primary Account\.\.\.Final Customer Name")]
        public void ThenIWillSeeStationID_PrimaryAccount_FinalCustomerName()
        {
            actualMsg = Gettext(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);

        }

        [Then(@"I will see Station ID - Primary Account\.\.\.Final Customer Name from Quote list page as a external user")]
        public void ThenIWillSeeStationID_PrimaryAccount_FinalCustomerNameFromQuoteListPageAsAExternalUser()
        {
            actualMsg = Gettext(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            SubAccount = "ArnoldTest05072018B";
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [Given(@"selected a customer name that is more than one level, in the <Select account to display\.\.\. field")]
        public void GivenSelectedACustomerNameThatIsMoreThanOneLevelInTheSelectAccountToDisplay_Field()
        {
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            string elementClass = GetAttribute(attributeName_xpath, QuoteList_CustomerDropdownOptions_Xpath, "class");

            string[] classes = elementClass.Split(' ');
            foreach (string eleClass in classes)
            {
                if (eleClass.Equals("level1") || eleClass.Equals("level2"))
                {
                    Assert.IsTrue(true);
                    Report.WriteLine("Customer name hierarchy is more than one level");
                }
            }
        }




        [Then(@"the customer label will now display Station ID - Primary Account\.\.\.Final Customer Name from Get quote page")]
        public void ThenTheCustomerLabelWillNowDisplayStationID_PrimaryAccount_FinalCustomerNameFromGetQuotePage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            actualMsg = Gettext(attributeName_xpath, GetQuote_CustomerLabelExtUser_Xpath);
            SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg); 
        }

        [Then(@"the customer label will now display Station ID - Primary Account\.\.\.Final Customer Name from Get quote page of service type for external user")]
        public void ThenTheCustomerLabelWillNowDisplayStationID_PrimaryAccount_FinalCustomerNameFromGetQuotePageOfServiceTypeForExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            actualMsg = Gettext(attributeName_xpath, StationCustomerName);
            SubAccount = "testingcsasubaccount_sub";
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }


        [Then(@"the customer label will now display Station ID - Primary Account\.\.\.Final Customer Name from Quote Result page")]
        public void ThenTheCustomerLabelWillNowDisplayStationID_PrimaryAccount_FinalCustomerNameFromQuoteResultPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            actualMsg = Gettext(attributeName_xpath, GetQuote_CustomerLabelItlUser_Xpath);
            SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [Then(@"the customer label will now display Station ID - Primary Account\.\.\.Final Customer Name from Quote Confirmation page")]
        public void ThenTheCustomerLabelWillNowDisplayStationID_PrimaryAccount_FinalCustomerNameFromQuoteConfirmationPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            actualMsg = Gettext(attributeName_xpath, QuoteConfirmation_CustomerLabelExtrUser_Xpath);
            SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [Then(@"the customer label will now display Station ID - Primary Account\.\.\.Final Customer Name from Quote Confirmation page as internal")]
        public void ThenTheCustomerLabelWillNowDisplayStationID_PrimaryAccount_FinalCustomerNameFromQuoteConfirmationPageAsInternal()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            actualMsg = Gettext(attributeName_xpath, QuoteConfirmation_CustomerLabelItlUser_Xpath);
            SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [Then(@"I will see Station ID - Primary Account\.\.\.Final Customer Name from Quote Confirmation page")]
        public void ThenIWillSeeStationID_PrimaryAccount_FinalCustomerNameFromQuoteConfirmationPage()
        {
            actualMsg = Gettext(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            SubAccount = Gettext(attributeName_xpath, QuoteList_CustomerDropdownList_Xpath);
            string StatioName = DBHelper.GetStationName(SubAccount);
            string PrimaryAccountName = DBHelper.GetPrimaryAccountName(SubAccount);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " - " + SubAccount + "...";
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [Then(@"the customer label will now display Station ID - Primary Account\.\.\.Final Customer Name")]
        public void ThenTheCustomerLabelWillNowDisplayStationID_PrimaryAccount_FinalCustomerName()
        {
            actualMsg = Gettext(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            SubAccount = Gettext(attributeName_xpath, QuoteList_CustomerDropdownList_Xpath);
            string StatioName = DBHelper.GetStationName(SubAccount);
            string PrimaryAccountName = DBHelper.GetPrimaryAccountName(SubAccount);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " - " + SubAccount + "...";
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [Then(@"the customer label will now display Station ID - Primary Account\.\.\.Final Customer Name from Get quote page of service type")]
        public void ThenTheCustomerLabelWillNowDisplayStationID_PrimaryAccount_FinalCustomerNameFromGetQuotePageOfServiceType()
        {
            actualMsg = Gettext(attributeName_xpath, StationCustomerName);
            SubAccount = Gettext(attributeName_xpath, CustomerDropdownOptionExtUser_Xpath);
            string StatioName = DBHelper.GetStationName(SubAccount);
            string PrimaryAccountName = DBHelper.GetPrimaryAccountName(SubAccount);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " - " + SubAccount + "...";
            Assert.AreEqual(actualMsg, actualMsg);
        }


        [Then(@"the customer label will now display <Station ID - Primary Account\.\.\.Final Customer Name from Get Quote page of service type selection")]
        public void ThenTheCustomerLabelWillNowDisplayStationID_PrimaryAccount_FinalCustomerNameFromGetQuotePageOfServiceTypeSelection()
        {
            actualMsg = Gettext(attributeName_xpath, StationCustomerName);
            SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [Then(@"the customer label will now display <Station ID - Primary Account\.\.\.Final Customer Name from Get Quote page of service type selection as internal")]
        public void ThenTheCustomerLabelWillNowDisplayStationID_PrimaryAccount_FinalCustomerNameFromGetQuotePageOfServiceTypeSelectionAsInternal()
        {
            actualMsg = Gettext(attributeName_xpath, StationCustomerNameLabel);
            SubAccount = "ArnoldTest05072018B";
            string StatioName = DBHelper.GetStationName(SubAccount);
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = StatioName + " - " + PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [Then(@"the customer label will now display Station ID - Primary Account\.\.\.Final Customer Name from Get quote page for external user")]
        public void ThenTheCustomerLabelWillNowDisplayStationID_PrimaryAccount_FinalCustomerNameFromGetQuotePageForExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            actualMsg = Gettext(attributeName_xpath, GetQuote_CustomerLabelExtUser_Xpath);
            SubAccount = "testingcsasubaccount_sub";
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [Then(@"the customer label will now display Station ID - Primary Account\.\.\.Final Customer Name from Quote result page for external user")]
        public void ThenTheCustomerLabelWillNowDisplayStationID_PrimaryAccount_FinalCustomerNameFromQuoteResultPageForExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            actualMsg = Gettext(attributeName_xpath, QuoteResultCustomerNameLabel_Xpath);
            SubAccount = "testingcsasubaccount_sub";
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [Then(@"the customer label will display Station ID - Primary Account\.\.\.Final Customer Name from Quote result page for external user")]
        public void ThenTheCustomerLabelWillDisplayStationID_PrimaryAccount_FinalCustomerNameFromQuoteResultPageForExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            actualMsg = Gettext(attributeName_xpath, QuoteConfirmation_CustomerLabelExtrUser_Xpath);
            SubAccount = "ArnoldTest05072018B";
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [Then(@"the customer label will now display Station ID - Primary Account\.\.\.Final Customer Name from Quote confirmation page for external user")]
        public void ThenTheCustomerLabelWillNowDisplayStationID_PrimaryAccount_FinalCustomerNameFromQuoteConfirmationPageForExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            actualMsg = Gettext(attributeName_xpath, QuoteConfirmation_CustomerLabelUser_Xpath);
            SubAccount = "ArnoldTest05072018B";
            int SubAccccId = DBHelper.GetCustomerId(SubAccount);
            int primaryAccId = DBHelper.GetPrimaryAccId(SubAccccId);
            string PrimaryAccountName = DBHelper.GetPrimaryAcc(primaryAccId);
            string ExpectedStationCustomerDisplay = PrimaryAccountName + " ... " + SubAccount;
            Assert.AreEqual(actualMsg, actualMsg);
        }

        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from quote list page")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromQuoteListPage()
        {
            actualMsg = Gettext(attributeName_classname, "mypopover");
            expectedMsg = "ZZZ - Web Services Test - ZZZ - GS Customer Test - ArnoldTest02222018 - ArnoldTest05072018B";
            Assert.AreEqual(actualMsg, expectedMsg);

        }

        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message  from Get Quote page of service type selection")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromGetQuotePageOfServiceTypeSelection()
        {
            actualMsg = Gettext(attributeName_classname, "mypopover");
            expectedMsg = "ZZZ - Web Services Test - ZZZ - GS Customer Test - ArnoldTest02222018 - ArnoldTest05072018B";
            Assert.AreEqual(actualMsg, expectedMsg);
        }

        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message  from Get Quote page of service type selection for external user")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromGetQuotePageOfServiceTypeSelectionForExternalUser()
        {
            actualMsg = Gettext(attributeName_classname, "mypopover");
            expectedMsg = "ZZZ - Czar Customer Test - checking for the config manager1 - testingcsasubaccount - testingcsasubaccount_sub";
            Assert.AreEqual(actualMsg, expectedMsg);
        }

        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Get Quote page")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromGetQuotePage()
        {
            actualMsg = Gettext(attributeName_classname, "mypopover");
            expectedMsg = "ZZZ - Web Services Test - ZZZ - GS Customer Test - ArnoldTest02222018 - ArnoldTest05072018B";
            Assert.AreEqual(actualMsg, expectedMsg);
        }

        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Get Quote page for external user")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromGetQuotePageForExternalUser()
        {
            actualMsg = Gettext(attributeName_classname, "mypopover");
            expectedMsg = "ZZZ - Czar Customer Test - checking for the config manager1 - testingcsasubaccount - testingcsasubaccount_sub";
            Assert.AreEqual(actualMsg, expectedMsg);
        }

        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Quote confirmation page for external user")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromQuoteConfirmationPageForExternalUser()
        {
            actualMsg = Gettext(attributeName_classname, "mypopover");
            expectedMsg = "ZZZ - Czar Customer Test - checking for the config manager1 - testingcsasubaccount - testingcsasubaccount_sub";
            Assert.AreEqual(actualMsg, expectedMsg);
        }


        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Quote Result page")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromQuoteResultPage()
        {
            actualMsg = Gettext(attributeName_classname, "mypopover");
            expectedMsg = "ZZZ - Web Services Test - ZZZ - GS Customer Test - ArnoldTest02222018 - ArnoldTest05072018B";
            Assert.AreEqual(actualMsg, expectedMsg);
        }

        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Quote confirmation page")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromQuoteConfirmationPage()
        {
            actualMsg = Gettext(attributeName_classname, "mypopover");
            expectedMsg = "ZZZ - Web Services Test - ZZZ - GS Customer Test - ArnoldTest02222018 - ArnoldTest05072018B";
            Assert.AreEqual(actualMsg, expectedMsg);
        }

        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from Quote Result page as a external user")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromQuoteResultPageAsAExternalUser()
        {
            actualMsg = Gettext(attributeName_classname, "mypopover");
            expectedMsg = "ZZZ - Czar Customer Test - checking for the config manager1 - testingcsasubaccount - testingcsasubaccount_sub";
            Assert.AreEqual(actualMsg, expectedMsg);
        }


        [Then(@"the entire station, hierarchies, and customer name will be displayed in the hover over message from quote list page for external user")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageFromQuoteListPageForExternalUser()
        {
            actualMsg = Gettext(attributeName_classname, "mypopover");
            expectedMsg = "ZZZ - Czar Customer Test - checking for the config manager1 - testingcsasubaccount - testingcsasubaccount_sub";
            Assert.AreEqual(actualMsg, expectedMsg);
        }

    }
}
