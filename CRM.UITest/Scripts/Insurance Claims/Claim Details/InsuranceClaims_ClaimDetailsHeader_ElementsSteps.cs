using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_ClaimDetailsHeader_ElementsSteps : Objects.InsuranceClaim
    {
        string firstclaimNumber_ClaimsList_UI;
        decimal totalNumberOfDays;
        int convertedTotalDays;
        int compareDates;
        List<InsuredRateCarrier> crmCarrierAllDetails = null;
        string carrierNameValidCarrier;
        string carrierNameInvalidCarrier;
        string checkInvalidCarrier;
        string checkValidCarrier;
        string userType;
        string claimRepDb;
        string claimReasonDb;
        bool carrierValue;
        public string customerClaimReferenceNumberValue;

        [Given(@"I am Sales, Sales Management, Operations, Station Owner or Claims Specialist User")]
        public void GivenIAmSalesSalesManagementOperationsStationOwnerOrClaimsSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I clicked on the hyperlink of any Claim number from the Claim List page")]
        public void GivenIClickedOnTheHyperlinkOfAnyClaimNumberFromTheClaimListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");

            string gridFirstColumnHeader = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[1]");
            if (gridFirstColumnHeader == "CUSTOMER")
            {
                userType = "Internal User";
                Report.WriteLine("logged in User is Internal");
                firstclaimNumber_ClaimsList_UI = Gettext(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_InternalUser_Xpath);
                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_InternalUser_Xpath);
            }
            else if (gridFirstColumnHeader == "STA / CUST")
            {
                userType = "Claim Specialist User";
                Report.WriteLine("logged in User is Claim Specialist");
                firstclaimNumber_ClaimsList_UI = Gettext(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_ClaimSpecialistUser_Xpath);
                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_ClaimSpecialistUser_Xpath);
            }
        }

        [Given(@"I clicked on the hyperlink of any Claim number which has valid Carrier from the Claim List page")]
        public void GivenIClickedOnTheHyperlinkOfAnyClaimNumberWhichHasValidCarrierFromTheClaimListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string claimNumberValidCarrier;
            string gridFirstColumnHeader = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[1]");
            if (gridFirstColumnHeader == "CUSTOMER")
            {
                userType = "Internal User";
                Report.WriteLine("logged in User is Internal");
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");

                IList<IWebElement> GridCarrier = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[6]"));
                crmCarrierAllDetails = DBHelper.GetAllCarrierDetails();
                List<string> dbCarriers = crmCarrierAllDetails.Select(a => a.CarrierName).ToList();
                for (int i = 1; i <= GridCarrier.Count; i++)
                {
                    string gridCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[6]");
                    string[] carrierSplitted = gridCarrier.Split('\r');
                    string uiCarriername = carrierSplitted[0];

                    carrierValue = dbCarriers.Contains(uiCarriername);
                    if (carrierValue)
                    {
                        carrierNameValidCarrier = uiCarriername;
                        claimNumberValidCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span");
                        IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span/a"));
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                        executor.ExecuteScript("arguments[0].click();", element);
                        i = GridCarrier.Count + 1;
                        //checkValidCarrier = "Valid Carrier";
                    }
                }
            }
            else if (gridFirstColumnHeader == "STA / CUST")
            {
                userType = "Claim Specialist User";
                Report.WriteLine("logged in User is Claim Specialist User");
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");

                IList<IWebElement> GridCarrier = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[7]"));
                List<InsuredRateCarrier> crmCarrierAllDetails = DBHelper.GetAllCarrierDetails();
                List<string> dbCarriers = crmCarrierAllDetails.Select(a => a.CarrierName).ToList();
                for (int i = 1; i <= GridCarrier.Count; i++)
                {
                    string gridCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[7]");
                    string[] carrierSplitted = gridCarrier.Split('\r');
                    string uiCarriername = carrierSplitted[0];
                    carrierValue = dbCarriers.Contains(uiCarriername);
                    if (carrierValue)
                    {
                        carrierNameValidCarrier = uiCarriername;
                        claimNumberValidCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a");
                        IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a"));
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                        executor.ExecuteScript("arguments[0].click();", element);
                        i = GridCarrier.Count + 1;
                        //checkValidCarrier = "Valid Carrier";
                    }
                }
            }
        }

        [Given(@"I clicked on the hyperlink of any Claim number which has invalid Carrier from the Claim List page")]
        public void GivenIClickedOnTheHyperlinkOfAnyClaimNumberWhichHasInvalidCarrierFromTheClaimListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");

            string gridFirstColumnHeader = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[1]");
            string claimNumberInvalidCarrier;
            if (gridFirstColumnHeader == "CUSTOMER")
            {
                userType = "Internal User";
                Report.WriteLine("logged in User is Internal");
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");

                IList<IWebElement> GridCarrier = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[6]"));
                crmCarrierAllDetails = DBHelper.GetAllCarrierDetails();
                List<string> dbCarriers = crmCarrierAllDetails.Select(a => a.CarrierName).ToList();
                for (int i = 1; i <= GridCarrier.Count; i++)
                {
                    string gridCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[6]");
                    string[] carrierSplitted = gridCarrier.Split('\r');
                    string uiCarriername = carrierSplitted[0];

                    carrierValue = !(dbCarriers.Contains(uiCarriername));
                    if (carrierValue)
                    {
                        carrierNameInvalidCarrier = uiCarriername;
                        claimNumberInvalidCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span/a");
                        IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span/a"));
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                        executor.ExecuteScript("arguments[0].click();", element);
                        i = GridCarrier.Count + 1;
                        //checkInvalidCarrier = "Invalid Carrier";
                    }
                }
            }
            else if (gridFirstColumnHeader == "STA / CUST")
            {
                userType = "Claim Specialist User";
                Report.WriteLine("logged in User is Claim Specialist User");
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");

                IList<IWebElement> GridCarrier = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[7]"));
                List<InsuredRateCarrier> crmCarrierAllDetails = DBHelper.GetAllCarrierDetails();
                List<string> dbCarriers = crmCarrierAllDetails.Select(a => a.CarrierName).ToList();
                for (int i = 1; i <= GridCarrier.Count; i++)
                {
                    string gridCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[7]");
                    string[] carrierSplitted = gridCarrier.Split('\r');
                    string uiCarriername = carrierSplitted[0];
                    carrierValue = !(dbCarriers.Contains(uiCarriername));
                    if (carrierValue)
                    {
                        carrierNameInvalidCarrier = uiCarriername;
                        claimNumberInvalidCarrier = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a");

                        IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a"));
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
                        executor.ExecuteScript("arguments[0].click();", element);
                        i = GridCarrier.Count + 1;
                        //checkInvalidCarrier = "Invalid Carrier";
                    }
                }
            }
        }

        [When(@"I am on the Details tab of the Claim in Claim Details page")]
        public void WhenIAmOnTheDetailsTabOfTheClaimInClaimDetailsPage()
        {
            WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details Header");
            Verifytext(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
        }

        [When(@"I am on the Claim Details page")]
        public void WhenIAmOnTheClaimDetailsPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details Header");
            Verifytext(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
        }

        [Then(@"I will see Claim Header Informations")]
        public void ThenIWillSeeClaimHeaderInformations()
        {
            WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details Header");
            Verifytext(attributeName_xpath, DlswClaimNumber_Label_ClaimDetailsPage_Xpath, "DLSW Claim #");
            Verifytext(attributeName_xpath, Claimant_Label_ClaimDetailsPage_Xpath, "Claimant");
            Verifytext(attributeName_xpath, CarrierSCAC_Label_ClaimDetailsPage_Xpath, "Carrier SCAC");
            Verifytext(attributeName_xpath, DlswClaimRep_Label_ClaimDetailsPage_Xpath, "DLSW Claim Rep");
            Verifytext(attributeName_xpath, ClaimReason_Label_ClaimDetailsPage_Xpath, "Claim Reason");
            Verifytext(attributeName_xpath, CarrierName_Label_ClaimDetailsPage_Xpath, "Carrier Name");
            Verifytext(attributeName_xpath, Station_Label_ClaimDetailsPage_Xpath, "Station");
            Verifytext(attributeName_xpath, DateRequested_Label_ClaimDetailsPage_Xpath, "Date Requested");
            Verifytext(attributeName_xpath, CarrierPro_Label_ClaimDetailsPage_Xpath, "Carrier PRO #");
            Verifytext(attributeName_xpath, DlswRefNumber_Label_ClaimDetailsPage_Xpath, "DLSW Ref #");
            Verifytext(attributeName_xpath, ClaimAge_Label_ClaimDetailsPage_Xpath, "Claim Age");
            Verifytext(attributeName_xpath, Insured_Label_ClaimDetailsPage_Xpath, "Insured");
        }

        [Then(@"I will see Header Field values are Auto-populated from the Claim Form")]
        public void ThenIWillSeeHeaderFieldValuesAreAuto_PopulatedFromTheClaimForm()
        {
            int claimNumberUI = Convert.ToInt32(firstclaimNumber_ClaimsList_UI);

            InsuranceClaimDetailsHeaderViewModel insuranceClaimDetailsHeaderModel = DBHelper.GetInsuranceClaimDetailsHeader(claimNumberUI);
            Report.WriteLine("Verifying DLSW Claim Number binding");
            string uiDLSWClaimNumber = GetValue(attributeName_id, DlswClaimNumber_Textbox_ClaimDetailsPage_Id, "value");
            Assert.AreEqual(firstclaimNumber_ClaimsList_UI, uiDLSWClaimNumber);
            Report.WriteLine("Verifying Claimant binding");
            string uiClaimant = GetValue(attributeName_id, Claimant_Textbox_ClaimDetailsPage_Id, "value");

            if (!string.IsNullOrEmpty(insuranceClaimDetailsHeaderModel.Claimant))
            {
                Assert.AreEqual((insuranceClaimDetailsHeaderModel.Claimant).ToLower(), uiClaimant.ToLower());
            }
            else
            {
                Assert.AreEqual("N/A", uiClaimant);
            }

            string actualClaimRep = Gettext(attributeName_xpath, DlswClaimRep_dropdown_ClaimDetailsPage_Xpath);
            if (!string.IsNullOrEmpty(insuranceClaimDetailsHeaderModel.ClaimRep))
            {
                Assert.AreEqual(insuranceClaimDetailsHeaderModel.ClaimRep, actualClaimRep);
            }
            else
            {
                Assert.AreEqual("Select...", actualClaimRep);
            }

            string actualClaimReason = Gettext(attributeName_xpath, ClaimReason_Dropdown_ClaimDetailsPage_Xpath);

            if (!string.IsNullOrEmpty(insuranceClaimDetailsHeaderModel.ClaimReason))
            {
                Assert.AreEqual(insuranceClaimDetailsHeaderModel.ClaimReason, actualClaimReason);
            }
            else
            {
                Assert.AreEqual("Select...", actualClaimReason);
            }

            Report.WriteLine("Verifying Carrier Name binding");
            string uiCarrier = Gettext(attributeName_xpath, CarrierName_Dropdown_ClaimDetailsPage_Xpath);
            string actualClaimAssociatedCarrier = insuranceClaimDetailsHeaderModel.Carriername;
            List<InsuredRateCarrier> crmCarrierAllDetails = DBHelper.GetAllCarrierDetails();
            bool isValidCarrier = crmCarrierAllDetails.Any(a => a.CarrierName == actualClaimAssociatedCarrier);
            if (isValidCarrier)
            {
                Assert.AreEqual(uiCarrier, actualClaimAssociatedCarrier);
            }
            else
            {
                Assert.AreEqual(uiCarrier, "Select...");
            }

            Report.WriteLine("Verifying Carrier SCAC binding");
            string uiSCAC = GetValue(attributeName_id, CarrierSCAC_Textbox_ClaimDetailsPage_Id, "value");
            if (!string.IsNullOrWhiteSpace(uiSCAC))
            {
                string actualSCACCode = crmCarrierAllDetails.Where(x => x.CarrierName == insuranceClaimDetailsHeaderModel.Carriername).Select(x => x.CarrierCode).FirstOrDefault();
                Assert.AreEqual(uiSCAC, actualSCACCode);
            }
            else
            {
                Assert.AreEqual(string.Empty, uiSCAC);
            }

            Report.WriteLine("Verifying Date Requested binding");

            string uiDate = GetValue(attributeName_id, DateRequested_FieldValue_ClaimDetailsPage_Id, "value");
            Assert.AreEqual((insuranceClaimDetailsHeaderModel.ClaimCreatedDate.Date.ToString("MM/dd/yyyy")), uiDate);

            Report.WriteLine("Verifying Carrier Pro Number binding");
            string uiCarrierPro = GetValue(attributeName_id, CarrierPro_Textbox_ClaimDetailsPage_Id, "value");
            Assert.AreEqual(insuranceClaimDetailsHeaderModel.CarrierPro, uiCarrierPro);

            Report.WriteLine("Verifying DLSW Reference Number binding");
            string uiDLSWRefNumber = GetValue(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, "value");
            Assert.AreEqual(insuranceClaimDetailsHeaderModel.DLSWReferenceNumber, uiDLSWRefNumber);

            Report.WriteLine("Verifying Claim Age binding");
            compareDates = DateTime.Compare(insuranceClaimDetailsHeaderModel.ClaimCreatedDate.Date, DateTime.Now.Date);
            if (compareDates <= 0)
            {
                totalNumberOfDays = (decimal)(DateTime.Now.Date - insuranceClaimDetailsHeaderModel.ClaimCreatedDate.Date).TotalDays;
                convertedTotalDays = (int)Math.Floor(totalNumberOfDays);
            }
            else
            {
                totalNumberOfDays = (decimal)(insuranceClaimDetailsHeaderModel.ClaimCreatedDate.Date - DateTime.Now.Date).TotalDays;
                convertedTotalDays = (int)Math.Ceiling(totalNumberOfDays);
            }

            string claimAge_ClaimDetails_WithDaysVerbiage = GetValue(attributeName_id, ClaimAge_Textbox_ClaimDetailsPage_Id, "value");
            Assert.AreEqual(convertedTotalDays.ToString() +  " days", claimAge_ClaimDetails_WithDaysVerbiage);

            Report.WriteLine("Verifying Station Insured flag binding");
            string uiinsured = Gettext(attributeName_xpath, Insured_Dropdown_ClaimDetailsPage_Xpath);
            if (uiinsured == "Y")
            {
                Assert.IsTrue(insuranceClaimDetailsHeaderModel.IsClaimInsured);
            }
            else
            {
                Assert.IsFalse(insuranceClaimDetailsHeaderModel.IsClaimInsured);
            }

            Report.WriteLine("Verifying Station ID binding");
            Entities.Proxy.InsuranceClaim insuranceClaim = DBHelper.GetInsuranceClaimDetails(claimNumberUI);
            string uiStationId = Gettext(attributeName_xpath, Station_Dropdown_ClaimDetailsPage_Xpath);
            int custSetUpId = Convert.ToInt32(insuranceClaim.CustomerSetUpId);
            CustomerAccount customerAccount = DBHelper.GetCustAccountDetails(custSetUpId);
            Assert.AreEqual(customerAccount.StationId, uiStationId);
            //string stationId = insuranceClaim.CustomerSetup.CustomerAccounts.Where(a => a.CustomerSetUpId == insuranceClaim.CustomerSetUpId).Select(a => a.StationId).FirstOrDefault();
            //Assert.AreEqual(stationId, uiStationId);
        }

        [Then(@"I will see Claim Form button")]
        public void ThenIWillSeeClaimFormButton()
        {
            VerifyElementPresent(attributeName_id, ViewFormbutton_Id, "Claim Form button");
            string actualUIName = Gettext(attributeName_id, ViewFormbutton_Id);
            string[] stringSeparators = new string[] { "\r\n" };
            string[] actualUINameSplit = actualUIName.Split(stringSeparators, StringSplitOptions.None);
            string uiName = actualUINameSplit[0] + " " + actualUINameSplit[1];
            Assert.AreEqual("Claim Form", uiName);
        }

        [Then(@"the Claim Age will be difference in Current Date and Claim Date Submitted")]
        public void ThenTheClaimAgeWillBeDifferenceInCurrentDateAndClaimDateSubmitted()
        {
            int claimNumberUI = Convert.ToInt32(firstclaimNumber_ClaimsList_UI);
            Entities.Proxy.InsuranceClaim insuranceClaim = DBHelper.GetInsuranceClaimDetails(claimNumberUI);
            compareDates = DateTime.Compare(insuranceClaim.CreateDateTime.Date, DateTime.Now.Date);
            if (compareDates <= 0)
            {
                totalNumberOfDays = (decimal)(DateTime.Now.Date - insuranceClaim.CreateDateTime.Date).TotalDays;
                convertedTotalDays = (int)Math.Floor(totalNumberOfDays);
            }
            else
            {
                totalNumberOfDays = (decimal)(insuranceClaim.CreateDateTime.Date - DateTime.Now.Date).TotalDays;
                convertedTotalDays = (int)Math.Ceiling(totalNumberOfDays);
            }
            string claimAge_ClaimDetails_WithDaysVerbiage = GetValue(attributeName_id, ClaimAge_Textbox_ClaimDetailsPage_Id, "value");
            Assert.AreEqual(convertedTotalDays.ToString() + " days", claimAge_ClaimDetails_WithDaysVerbiage);
        }

        [Then(@"Carrier Name will be binded in the Claim Details Header section")]
        public void ThenCarrierNameWillBeBindedInTheClaimDetailsHeaderSection()
        {
            if (checkValidCarrier == "Valid Carrier")
            {
                string actualCarrier = Gettext(attributeName_xpath, CarrierName_Dropdown_ClaimDetailsPage_Xpath);
                Assert.AreEqual(carrierNameValidCarrier, actualCarrier);
            }
            else
            {
                Report.WriteLine("No Carrier is valid in Claim List page");
            }
        }

        [Then(@"Carrier Name field will display Select verbiage in the Claim Details Header section")]
        public void ThenCarrierNameFieldWillDisplaySelectVerbiageInTheClaimDetailsHeaderSection()
        {
            if (checkInvalidCarrier == "Invalid Carrier")
            {
                Verifytext(attributeName_xpath, CarrierName_Dropdown_ClaimDetailsPage_Xpath, "Select");
            }
            else
            {
                Report.WriteLine("Carrier of this selected Claim is Valid in Claim List page");
            }
        }

        [Then(@"associated SCAC code of that Carrier will be binded in SCAC field")]
        public void ThenAssociatedSCACCodeOfThatCarrierWillBeBindedInSCACField()
        {
            string uiSCAC = GetValue(attributeName_id, CarrierSCAC_Textbox_ClaimDetailsPage_Id, "value");

            if (carrierValue)
            {
                string actualSCACCode = crmCarrierAllDetails.Where(x => x.CarrierName == carrierNameValidCarrier).Select(x => x.CarrierCode).FirstOrDefault();
                Assert.AreEqual(uiSCAC, actualSCACCode);
            }
            else
            {
                Report.WriteLine("Carrier associated to Claim is InValid carrier and hence SCAC field is empty");
                Assert.AreEqual(string.Empty, uiSCAC);
            }
        }

        [Then(@"the SCAC field will be left blank")]
        public void ThenTheSCACFieldWillBeLeftBlank()
        {
            string uiSCAC = GetValue(attributeName_id, CarrierSCAC_Textbox_ClaimDetailsPage_Id, "value");
            if (carrierValue)
            {
                Assert.AreEqual(string.Empty, uiSCAC);
            }
            else
            {
                Report.WriteLine("Carrier associated to Claim is Valid carrier and hence SCAC field is not empty");
            }
        }

        [Given(@"I am a sales, sales management, operations, station owner user (.*),(.*),(.*)")]
        public void GivenIAmASalesSalesManagementOperationsStationOwnerUser(string userType, string userName, string password)
        {
            string UserName = ConfigurationManager.AppSettings[userName].ToString();
            string PassWord = ConfigurationManager.AppSettings[password].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(UserName, PassWord);
            Report.WriteLine("Logged into CRM Application");
        }

        [Given(@"I clicked on the link of any displayed claim (.*),(.*)")]
        public void GivenIClickedOnTheLinkOfAnyDisplayedClaim(string userType, string claimNumber)
        {
            Report.WriteLine("Searching for Test Data by Entering the Claim Number");
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, claimNumber);
            Report.WriteLine("Clicking on the Claim Number");
            if (userType == "Sales" || userType == "Internal")
            {
                Click(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_Xpath);

            }
            else if (userType == "ClaimSpecialist")
            {
                Click(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);

            }
        }

        [Then(@"I will see the field Customer Claim Ref \#")]
        public void ThenIWillSeeTheFieldCustomerClaimRef()
        {
            Report.WriteLine("Verifying Customer Claim Reference field label text");
            Verifytext(attributeName_id, ClaimDetailsPage_CustomerClaimReferenceNumber_Label_Id, "Customer Claim Ref #");
            Report.WriteLine("Verifying Customer Claim Reference field is Visible");
            VerifyElementVisible(attributeName_id, ClaimDetailsPage_CustomerClaimReferenceNumber_Value_Id, "Customer Claim Reference field");
        }

        [Then(@"the field is not editable")]
        public void ThenTheFieldIsNotEditable()
        {
            Report.WriteLine("Verifying Customer Claim Reference field is Not Editable");
            VerifyElementNotEnabled(attributeName_id, ClaimDetailsPage_CustomerClaimReferenceNumber_Value_Id, "Customer Claim Reference field");

            Report.WriteLine("Getting the Customer Claim Reference Number Field Value");
            customerClaimReferenceNumberValue = GetValue(attributeName_id, ClaimDetailsPage_CustomerClaimReferenceNumber_Value_Id, "value");
        }

        [Then(@"the value of the Customer Claim Ref \# field of the Submit A Claim page will be pushed to the Customer Claim Ref \# field of the Claim Details page (.*)")]
        public void ThenTheValueOfTheCustomerClaimRefFieldOfTheSubmitAClaimPageWillBePushedToTheCustomerClaimRefFieldOfTheClaimDetailsPage(int claimNumber)
        {
            Report.WriteLine("Fetching the saved Customer Claim Reference Number from DB");
            InsuranceClaimViewModel insuranceClaimViewModel = DBHelper.GetInsuranceClaimValues(claimNumber);
            string expectedCustomerClaimReferenceNumber = insuranceClaimViewModel.CustomerClaimReferenceNumber;

            Assert.AreEqual(expectedCustomerClaimReferenceNumber, customerClaimReferenceNumberValue);

        }

        [Given(@"I am a claim specialist user (.*),(.*),(.*)")]
        public void GivenIAmAClaimSpecialistUser(string userType, string userName, string password)
        {
            GivenIAmASalesSalesManagementOperationsStationOwnerUser(userType, userName, password);
        }

        [Then(@"I will see the optional field Customer Claim Ref \#")]
        public void ThenIWillSeeTheOptionalFieldCustomerClaimRef()
        {
            ThenIWillSeeTheFieldCustomerClaimRef();
        }

        [Then(@"the field is editable \(alpha-numeric, text, special characters, max length (.*)\)")]
        public void ThenTheFieldIsEditableAlpha_NumericTextSpecialCharactersMaxLength(int maxLength)
        {
            Report.WriteLine("Verifying Customer Claim Reference Number Field is Editable");
            VerifyElementEnabled(attributeName_id, ClaimDetailsPage_CustomerClaimReferenceNumber_Value_Id, "Customer Claim Reference field");

            Report.WriteLine("Getting the Customer Claim Reference Number Field Value");
            customerClaimReferenceNumberValue = GetValue(attributeName_id, ClaimDetailsPage_CustomerClaimReferenceNumber_Value_Id, "value");

            Report.WriteLine("Giving Alpha_NumericTextSpecialCharacters with More than 20 Characters From UI");
            SendKeys(attributeName_id, ClaimDetailsPage_CustomerClaimReferenceNumber_Value_Id, "@%# Some Text 1234 ^ More Than 20 Character");

            Report.WriteLine("Getting Customer Claim Reference Value from UI");
            string customerClaimReferenceField_UI = GetValue(attributeName_id, ClaimDetailsPage_CustomerClaimReferenceNumber_Value_Id, "value");

            Report.WriteLine("Verifying the Customer Claim Reference field length should be 20");
            Assert.AreEqual(maxLength, customerClaimReferenceField_UI.Length);

            Report.WriteLine("Verifying the Customer Claim Reference field should contain the first Twenty characters what we entered from UI");
            Assert.AreEqual("@%# Some Text 1234 ^", customerClaimReferenceField_UI);

        }

        [When(@"I edit Customer Claim Ref \# (.*),(.*),(.*)")]
        public void WhenIEditCustomerClaimRef(string claimNumber, string initialValueForCustomerClaimReferenceNumber, string editedValueForCustomerClaimReferenceNumber)
        {
            Report.WriteLine("Updating the Customer Claim Reference Number to Inital value");
            DBHelper.UpdateCustomerClaimReferenceValueByClaimNumber(Convert.ToInt32(claimNumber), initialValueForCustomerClaimReferenceNumber);

            Report.WriteLine("Editing the Customer Claim Reference Number");
            SendKeys(attributeName_id, ClaimDetailsPage_CustomerClaimReferenceNumber_Value_Id, editedValueForCustomerClaimReferenceNumber);
        }

        [When(@"I click on Save Claim Details")]
        public void WhenIClickOnSaveClaimDetails()
        {
            Report.WriteLine("Clicking on Save Claim Details Button");
            Click(attributeName_id, SaveClaimDetailsButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_id, ClaimDetailsPage_CustomerClaimReferenceNumber_Value_Id, "Customer Claim Reference Number");
        }

        [Then(@"Customer Claim Ref \# will be saved to Claim (.*),(.*)")]
        public void ThenCustomerClaimRefWillBeSavedToClaim(string claimNumber, string editedValueForCustomerClaimReferenceNumber)
        {
            Report.WriteLine("Fetching the saved Customer Claim Reference Number from DB");
            InsuranceClaimViewModel insuranceClaimViewModel = DBHelper.GetInsuranceClaimValues(Convert.ToInt32(claimNumber));
            string actualCustomerClaimReferenceNumber = insuranceClaimViewModel.CustomerClaimReferenceNumber;

            Report.WriteLine("Verifying the value we entered on edit matches with DB");
            Assert.AreEqual(editedValueForCustomerClaimReferenceNumber, actualCustomerClaimReferenceNumber);
        }
    }
}
