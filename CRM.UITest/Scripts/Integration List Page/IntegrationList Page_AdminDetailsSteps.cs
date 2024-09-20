using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class IntegrationList_Page_AdminDetailsSteps : Integration
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am a system admin user with valid (.*) and (.*)")]
        public void GivenIAmASystemAdminUserWithValidAnd(string Userame, string Password)
        {
            crm.LoginToCRMApplication(Userame, Password);
        }

        [When(@"I verify In Progress staus radio button is selected")]
        public void WhenIVerifyInProgressStausRadioButtonIsSelected()
        {
            IsElementEnabled(attributeName_xpath, IntegrationList_Filter_InProgress_RadioButton_xpath, "In Progress Radio button");
        }

        [Then(@"I should be displayed with Status Bar and current status highlighted for In Progress status")]
        public void ThenIShouldBeDisplayedWithStatusBarAndCurrentStatusHighlightedForInProgressStatus()
        {
            var colorofHighlighted_currentstatus = GetCSSValue(attributeName_xpath, ".//*[@id='gridIntegrationList']/tbody/tr[2]//ul/li[3]", "background-color");
            Assert.AreEqual("rgba(74, 134, 232, 1)", colorofHighlighted_currentstatus);
            Report.WriteLine("display with Status Bar with current status highlighted");
        }

        [Then(@"I can see In Progress includes the respective stages")]
        public void ThenICanSeeInProgressIncludesTheRespectiveStages()
        {
            Thread.Sleep(1000);
            string statusforinprogress = Gettext(attributeName_xpath, Inprogressstatusbar_label_xpath);
            Thread.Sleep(1000);
            string statusunderinprogress = statusforinprogress.Remove(0, 13);
            List<string> statusList = new List<string>(new string[] { "Waiting On Integration Team", "Pending management approval", "Documentation Sent to Customer", "Waiting on MG/CSA Configuration", "Waiting on Customer Configuration", "QA Testing" });

            if (statusList.Contains(statusunderinprogress))
            {
                Console.WriteLine("inprogress includes only Waiting on Integration Team, Pending management approval, Waiting on integration team, Documentation Sent to Customer, Waiting on MG / CSA Configuration, Waiting on Customer Configuration, QA Testing");
            }
            else
            {
                throw new System.Exception("status is mismatching");
            }
        }


        [When(@"I click on the filter by status Completed radio button")]
        public void WhenIClickOnTheFilterByStatusCompletedRadioButton()
        {
            Click(attributeName_xpath, IntegrationList_Filter_Completed_RadioButton_xpath);
        }

        [Then(@"I should be displayed with Status Bar and current status highlighted for Completed status")]
        public void ThenIShouldBeDisplayedWithStatusBarAndCurrentStatusHighlightedForCompletedStatus()
        {
            var colorofHighlighted_currentstatus = GetCSSValue(attributeName_xpath, ".//*[@id='gridIntegrationList']/tbody/tr[2]//ul/li[4]", "background-color");
            Assert.AreEqual("rgba(16, 124, 16, 1)", colorofHighlighted_currentstatus);
            Report.WriteLine("display with Status Bar with current status highlighted");
        }


        [Then(@"I can see Completed includes the respective stages")]
        public void ThenICanSeeCompletedIncludesTheRespectiveStages()
        {
            Thread.Sleep(1000);
            string statusforcompleted = Gettext(attributeName_xpath, Completedstatusbar_label_xpath);
            Thread.Sleep(1000);
            string statusundercompleted = statusforcompleted.Remove(0, 11);
            List<string> statusList = new List<string>(new string[] { "Denied", "On hold per customer", "Inactive", "In production" });

            if (statusList.Contains(statusundercompleted))
            {
                Console.WriteLine("Completed includes only Denied On hold per customer,Inactive,In production");
            }
            else
            {
                throw new System.Exception("status is mismatching");
            }
        }




        [When(@"I am on Integration Request List Page")]
        public void WhenIAmOnIntegrationRequestListPage()
        {

            Click(attributeName_xpath, IntegrationMenuIcon);
            Report.WriteLine("User see the Title Integration Request List Page ");

        }

        [Then(@"I can see the Potential Revenue, Additional Comments, MG/CSA Total Hours, Integration Team Total Hours and Status for admin users (.*)")]
        public void ThenICanSeeThePotentialRevenueAdditionalCommentsMGCSATotalHoursIntegrationTeamTotalHoursAndStatusForAdminUsers(string UserType)
        {

            Report.WriteLine("Potential Revenue, Additional Comments, MG/CSA Total Hours, Integration Team Total Hours and Status");
            VerifyElementVisible(attributeName_id, PotentialRevenuetextbox_id, "textbox");
            string potentialRevenue = Gettext(attributeName_xpath, PotentialRevenuelabel_xpath);
            Verifytext(attributeName_xpath, PotentialRevenuelabel_xpath, potentialRevenue);

            VerifyElementVisible(attributeName_id, AdditionalCommentstextbox_id, "textbox");
            string additionalComments = Gettext(attributeName_xpath, AdditionalCommentslabel_xpath);
            Verifytext(attributeName_xpath, AdditionalCommentslabel_xpath, additionalComments);

            if (UserType.Equals(UserType))
            {

                VerifyElementVisible(attributeName_id, MG_CSATotalHourstextbox_id, "textbox");
                string mgcsatotalHours = Gettext(attributeName_xpath, MG_CSATotalHourslabel_xpath);
                Verifytext(attributeName_xpath, MG_CSATotalHourslabel_xpath, mgcsatotalHours);

                VerifyElementVisible(attributeName_id, IntegrationTeamTotalHourstextbox_id, "textbox");
                string integrationtotalHours = Gettext(attributeName_xpath, IntegrationTeamTotalHourslabel_xpath);
                Verifytext(attributeName_xpath, IntegrationTeamTotalHourslabel_xpath, integrationtotalHours);

                VerifyElementVisible(attributeName_xpath, IntegrationTeamStatusdropdown_xpath, "dropdown");
                string integrationStatus = Gettext(attributeName_xpath, IntegrationTeamStatuslabel_xpath);
                Verifytext(attributeName_xpath, IntegrationTeamStatuslabel_xpath, integrationStatus);
            }
            else
            {
                VerifyElementNotVisible(attributeName_id, MG_CSATotalHourstextbox_id, "textbox");
                

                VerifyElementNotVisible(attributeName_id, IntegrationTeamTotalHourstextbox_id, "textbox");
               

                VerifyElementNotVisible(attributeName_xpath, IntegrationTeamStatusdropdown_xpath, "dropdown");
               
            }

        }


        [Then(@"I can see the Add Comment button")]
        public void ThenICanSeeTheAddCommentButton()
        {
            VerifyElementPresent(attributeName_id, IntegrationDetails_AddCommentBtn_Id, "Add Comment Button");
        }

        [Then(@"verify all the fields should be editable on Admin details page")]
        public void ThenVerifyAllTheFieldsShouldBeEditableOnAdminDetailsPage()
        {
            VerifyElementEnabled(attributeName_id, CompanyContactNameTextbox_id, "CompanyContactName");
            VerifyElementEnabled(attributeName_id, CompanyContactPhoneTextbox_id, "CompanyContactPhone");
            VerifyElementEnabled(attributeName_id, CompanyContactEmailTextbox_id, "CompanyContactEmail");

            VerifyElementEnabled(attributeName_id, IT_developercontactnametextbox_id, "IT_developerContactName");
            VerifyElementEnabled(attributeName_id, ITdeveloperContactphonetextbox_id, "IT_developerContactPhone");
            VerifyElementEnabled(attributeName_id, ITdeveloperemailtextbox_id, "IT_developerEmail");

            VerifyElementEnabled(attributeName_id, AdditionalCommentstextbox_id, "Additional Comments");
            VerifyElementEnabled(attributeName_id, YeartoDateshipmentstextbox_id, "Year to Date Shipments");
            VerifyElementEnabled(attributeName_id, YeartoDateRevenuetextbox_id, "Year to Date Revenue");
            VerifyElementEnabled(attributeName_id, PotentialRevenuetextbox_id, "Potential Revenue");

            VerifyElementEnabled(attributeName_id, MG_CSATotalHourstextbox_id, "MGCSATotalHours");
            VerifyElementEnabled(attributeName_id, IntegrationTeamTotalHourstextbox_id, "Integration team Total Hours");

           


        }


        [Then(@"I can see the integration notes of Comment, Commenter, Date/Time and Public/Private")]
        public void ThenICanSeeTheIntegrationNotesOfCommentCommenterDateTimeAndPublicPrivate()
        {
            Report.WriteLine("integration notes of Comment, Commenter, Date/Time and Public/Private");
            Verifytext(attributeName_xpath, Commentsheader_xpath, "Comment".ToUpper());
            Verifytext(attributeName_xpath, Commenterheader_xpath, "Commenter".ToUpper());
            Verifytext(attributeName_xpath, Date_timeheader_xpath, "Date/Time".ToUpper());
            Verifytext(attributeName_xpath, Public_privateheader_xpath, "Public/Private".ToUpper());
        }



        [Then(@"I can see the Submit button for the status other than Pending RM Approval")]
        public void ThenICanSeeTheSubmitButtonForTheStatusOtherThanPendingRMApproval()
        {
            VerifyElementPresent(attributeName_id, IntegrationDetails_SubmitButton_Id, "Submit Button");
        }

        [Then(@"I can see the modified (.*), (.*) and (.*) values on the admin details page once I click on the Submit button")]
        public void ThenICanSeeTheModifiedAndValuesOnTheAdminDetailsPageOnceIClickOnTheSubmitButton(string CompanyContactName, string CompanyContactPhone, string ITDevContactPhone)
        {
        
            string oldContactNamevalue = GetValue(attributeName_id, CompanyContactNameTextbox_id,"value");
            string oldItDevContactphone = GetValue(attributeName_id, CompanyContactPhoneTextbox_id,"Value");
            string oldCompanyContactphone = GetValue(attributeName_id, CompanyContactPhoneTextbox_id, "value");

            Clear(attributeName_id, CompanyContactNameTextbox_id);
            Clear(attributeName_id, ITdeveloperContactphonetextbox_id);
            Clear(attributeName_id, CompanyContactPhoneTextbox_id);

            SendKeys(attributeName_id, CompanyContactNameTextbox_id, CompanyContactName);
            SendKeys(attributeName_id, ITdeveloperContactphonetextbox_id, ITDevContactPhone);
            SendKeys(attributeName_id, CompanyContactPhoneTextbox_id, CompanyContactPhone);

            Click(attributeName_id, IntegrationDetails_SubmitButton_Id);
            
            //Again click on the same customer detials

            Click(attributeName_xpath, FirstrequestexpandIcon_xpath);
            
            string newContactNamevalue = GetValue(attributeName_id, CompanyContactNameTextbox_id, "value");
            string newItDevContactphone = GetValue(attributeName_id, ITdeveloperContactphonetextbox_id, "value");
            string newCompanyContactphone = GetValue(attributeName_id, CompanyContactPhoneTextbox_id, "value");

            Assert.AreEqual(newContactNamevalue, CompanyContactName);
            Report.WriteLine("Updated values are displayed");
            Assert.AreEqual(newItDevContactphone, ITDevContactPhone);
            Report.WriteLine("Updated values are displayed");
            Assert.AreEqual(newCompanyContactphone, CompanyContactPhone);
            Report.WriteLine("Updated values are displayed");



        }


        [Then(@"Verify the required fields in admin integration details page are highlighted")]
        public void ThenVerifyTheRequiredFieldsInAdminIntegrationDetailsPageAreHighlighted()
        {
         
            MoveToElement(attributeName_id, CompanyContactNameTextbox_id);
            Clear(attributeName_id, CompanyContactNameTextbox_id);
            MoveToElement(attributeName_id, CompanyContactPhoneTextbox_id);
            Clear(attributeName_id, CompanyContactPhoneTextbox_id);
            MoveToElement(attributeName_id, CompanyContactEmailTextbox_id);
            Clear(attributeName_id, CompanyContactEmailTextbox_id);

            MoveToElement(attributeName_id, IT_developercontactnametextbox_id);
            Clear(attributeName_id, IT_developercontactnametextbox_id);
            MoveToElement(attributeName_id, ITdeveloperContactphonetextbox_id);
            Clear(attributeName_id, ITdeveloperContactphonetextbox_id);
            MoveToElement(attributeName_id, ITdeveloperemailtextbox_id);
            Clear(attributeName_id, ITdeveloperemailtextbox_id);

            List<string> ascSort = new List<string>();
            IList<IWebElement> typeofIntegration = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='TypeofIntegration_chosen']/ul/li/span"));
            foreach (IWebElement element in typeofIntegration)
            {
                ascSort.Add((element.Text).ToString());
                
            }

            for(int i=1;i<=ascSort.Count;i++)
            {
                Click(attributeName_xpath, ".//*[@id='TypeofIntegration_chosen']/ul/li[" + i + "]/a");
            }

            Click(attributeName_id, IntegrationDetails_SubmitButton_Id);


            var colorofHighlighted_ComapnyName = GetCSSValue(attributeName_id, CompanyContactNameTextbox_id, "background-color");
            Assert.AreEqual("rgba(251, 236, 237, 1)", colorofHighlighted_ComapnyName);
            Report.WriteLine("Highlighted when data not entered");

            var colorofHighlighted_CompanyPhone = GetCSSValue(attributeName_id, CompanyContactPhoneTextbox_id, "background-color");
            Assert.AreEqual("rgba(251, 236, 237, 1)", colorofHighlighted_CompanyPhone);
            Report.WriteLine("Highlighted when data not entered");


            var colorofHighlighted_CompanyEmail = GetCSSValue(attributeName_id, CompanyContactEmailTextbox_id, "background-color");
            Assert.AreEqual("rgba(251, 236, 237, 1)", colorofHighlighted_CompanyEmail);
            Report.WriteLine("Highlighted when data not entered");


            var colorofHighlighted_ITDEVName = GetCSSValue(attributeName_id, IT_developercontactnametextbox_id, "background-color");
            Assert.AreEqual("rgba(251, 236, 237, 1)", colorofHighlighted_ITDEVName);
            Report.WriteLine("Highlighted when data not entered");

            var colorofHighlighted_ITDEVPhone = GetCSSValue(attributeName_id, ITdeveloperContactphonetextbox_id, "background-color");
            Assert.AreEqual("rgba(251, 236, 237, 1)", colorofHighlighted_ITDEVPhone);
            Report.WriteLine("Highlighted when data not entered");


            var colorofHighlighted_ITDEVEmail = GetCSSValue(attributeName_id, ITdeveloperemailtextbox_id, "background-color");
            Assert.AreEqual("rgba(251, 236, 237, 1)", colorofHighlighted_ITDEVEmail);
            Report.WriteLine("Highlighted when data not entered");

           


        }


        [Then(@"I should be able to pass fifty characters to Company Contact Name including alpha numeric, spaces, special characters (.*)")]
        public void ThenIShouldBeAbleToPassFiftyCharactersToCompanyContactNameIncludingAlphaNumericSpacesSpecialCharacters(string CompanyContactName)
        {
          
            Clear(attributeName_id, CompanyContactNameTextbox_id);
            //MoveToElement(attributeName_id,CompanyContactNameTextbox_id);
            SendKeys(attributeName_id, CompanyContactNameTextbox_id, CompanyContactName);
           
            string CompanyContactNameUI = GetValue(attributeName_id, CompanyContactNameTextbox_id, "value");
            Assert.AreEqual(CompanyContactName, CompanyContactNameUI);
            Report.WriteLine("Able to pass 50 characters to Company Contact Name field");
        }


        [Then(@"I should not be able to pass more than fifty characters in Company Name field including alpha numeric, spaces, special characters (.*)")]
        public void ThenIShouldNotBeAbleToPassMoreThanFiftyCharactersInCompanyNameFieldIncludingAlphaNumericSpacesSpecialCharacters(string CompanyContactName)
        {
           
            Clear(attributeName_id, CompanyContactNameTextbox_id);
            //MoveToElement(attributeName_id, CompanyContactNameTextbox_id);
            SendKeys(attributeName_id, CompanyContactNameTextbox_id, CompanyContactName);
            string CompanyContactNameUI = GetValue(attributeName_id, CompanyContactNameTextbox_id, "value");
            Assert.AreNotEqual(CompanyContactName, CompanyContactNameUI);
            Report.WriteLine("Not Able to pass 50 characters to Company Contact Name field");
        }


        [Then(@"I should be able to pass equal to twenty digits in Company Contact Phone (.*)")]
        public void ThenIShouldBeAbleToPassEqualToTwentyDigitsInCompanyContactPhone(string CompanyContactPhone)
        {
            
            Clear(attributeName_id, CompanyContactPhoneTextbox_id);
            MoveToElement(attributeName_id, CompanyContactPhoneTextbox_id);
            SendKeys(attributeName_id, CompanyContactPhoneTextbox_id, CompanyContactPhone);
            string CompanyContactPhoneUI = GetValue(attributeName_id, CompanyContactPhoneTextbox_id, "value");
            Assert.AreEqual(CompanyContactPhoneUI, CompanyContactPhone);
        }

        [Then(@"I should able to pass valid email address (.*)")]
        public void ThenIShouldAbleToPassValidEmailAddress(string CompanyContactEmail)
        {
            
            Clear(attributeName_id, CompanyContactEmailTextbox_id);
            MoveToElement(attributeName_id, CompanyContactEmailTextbox_id);
            SendKeys(attributeName_id, CompanyContactEmailTextbox_id, CompanyContactEmail);
            string CompanyContactPhoneUI = GetValue(attributeName_id, CompanyContactEmailTextbox_id, "value");
            Assert.AreEqual(CompanyContactPhoneUI, CompanyContactEmail);
        }


        [Then(@"I should be able to pass fifty characters in ITDEV Contact Name including alpha numeric , spaces and special characters (.*)")]
        public void ThenIShouldBeAbleToPassFiftyCharactersInITDEVContactNameIncludingAlphaNumericSpacesAndSpecialCharacters(string ITDEVContactName)
        {
            MoveToElement(attributeName_id, IT_developercontactnametextbox_id);
            SendKeys(attributeName_id, IT_developercontactnametextbox_id, ITDEVContactName);
            
            string CompanyContactPhoneUI = GetValue(attributeName_id, IT_developercontactnametextbox_id, "value");
            Assert.AreEqual(CompanyContactPhoneUI, ITDEVContactName);
        }


        [Then(@"I should able to accepts equal to twenty digits in (.*)")]
        public void ThenIShouldAbleToAcceptsEqualToTwentyDigitsIn(string ITDEVContactPhone)
        {
          
            Clear(attributeName_id, ITdeveloperContactphonetextbox_id);
            MoveToElement(attributeName_id, ITdeveloperContactphonetextbox_id);
            SendKeys(attributeName_id, ITdeveloperContactphonetextbox_id, ITDEVContactPhone);
            
            string CompanyContactPhoneUI = GetValue(attributeName_id, ITdeveloperContactphonetextbox_id, "value");
            Assert.AreEqual(CompanyContactPhoneUI, ITDEVContactPhone);
        }


        [Then(@"I can able to pass valid email address in ITDEV Conatct Email (.*)")]
        public void ThenICanAbleToPassValidEmailAddressInITDEVConatctEmail(string ITDEVContactEmail)
        {
           
            Clear(attributeName_id, ITdeveloperemailtextbox_id);
            MoveToElement(attributeName_id, ITdeveloperemailtextbox_id);
            SendKeys(attributeName_id, ITdeveloperemailtextbox_id, ITDEVContactEmail);
            
            string CompanyContactPhoneUI = GetValue(attributeName_id, ITdeveloperemailtextbox_id, "value");
            Assert.AreEqual(CompanyContactPhoneUI, ITDEVContactEmail);
        }


        [Then(@"Verify I should be able to enter five hundred characters in the Additional Comments field (.*)")]
        public void ThenVerifyIShouldBeAbleToEnterFiveHundredCharactersInTheAdditionalCommentsField(string AdditionalComments)
        {
           
            Clear(attributeName_id, AdditionalCommentstextbox_id);
            MoveToElement(attributeName_id, AdditionalCommentstextbox_id);
            SendKeys(attributeName_id, AdditionalCommentstextbox_id, AdditionalComments);
            string AdditionalCommentsUI = GetValue(attributeName_id, AdditionalCommentstextbox_id, "value");
            Assert.AreEqual(AdditionalCommentsUI, AdditionalComments);
        }


        [Then(@"Verify the Year to Date Shipments able to enter only six digits in the Year to Date Shipments field (.*)")]
        public void ThenVerifyTheYearToDateShipmentsAbleToEnterOnlySixDigitsInTheYearToDateShipmentsField(string YearToDateShipments)
        {
            
            MoveToElement(attributeName_id, YeartoDateshipmentstextbox_id);
            Clear(attributeName_id, YeartoDateshipmentstextbox_id);
            SendKeys(attributeName_id, YeartoDateshipmentstextbox_id, YearToDateShipments);
            string YearToDateShipmentsUI = GetValue(attributeName_id, YeartoDateshipmentstextbox_id, "value");
            Assert.AreEqual(YearToDateShipmentsUI, YearToDateShipments);
        }

        [Then(@"Verify I should be able to pass only eight digits including dollar sign with whole numbers (.*)")]
        public void ThenVerifyIShouldBeAbleToPassOnlyEightDigitsIncludingDollarSignWithWholeNumbers(string YeartoDateRevenue)
        {
            
            MoveToElement(attributeName_id, YeartoDateRevenuetextbox_id);
            Clear(attributeName_id, YeartoDateRevenuetextbox_id);
            SendKeys(attributeName_id, YeartoDateRevenuetextbox_id, YeartoDateRevenue);
            string YearToDateRevenueUI = GetValue(attributeName_id, YeartoDateRevenuetextbox_id, "value");
            Assert.AreEqual("$" + (YeartoDateRevenue), YearToDateRevenueUI.Replace(",", ""));
        }

        [Then(@"Verify Year to Date Revenue does not accepts more than eight digits including dollar sign with whole numbers (.*)")]
        public void ThenVerifyYearToDateRevenueDoesNotAcceptsMoreThanEightDigitsIncludingDollarSignWithWholeNumbers(string YeartoDateRevenue)
        {
            
            MoveToElement(attributeName_id, YeartoDateRevenuetextbox_id);
            Clear(attributeName_id, YeartoDateRevenuetextbox_id);
            SendKeys(attributeName_id, YeartoDateRevenuetextbox_id, YeartoDateRevenue);
            string YearToDateRevenueUI = GetValue(attributeName_id, YeartoDateRevenuetextbox_id, "value");
            Assert.AreNotEqual("$" + (YeartoDateRevenue), YearToDateRevenueUI.Replace(",", ""));
        }

        [Then(@"Year to Date Shipment field does not accepts more than six digits in (.*)")]
        public void ThenYearToDateShipmentFieldDoesNotAcceptsMoreThanSixDigitsIn(string YearToDateShipments)
        {
           
            MoveToElement(attributeName_id, YeartoDateshipmentstextbox_id);
            Clear(attributeName_id, YeartoDateshipmentstextbox_id);
            SendKeys(attributeName_id, YeartoDateshipmentstextbox_id, YearToDateShipments);
            string YearToDateShipmentsUI = GetValue(attributeName_id, YeartoDateshipmentstextbox_id,"value");
            Assert.AreNotEqual(YearToDateShipmentsUI, YearToDateShipments);
        }


        [Then(@"Verify Potential Revenue accepts max eight digits including currency with whole numbers (.*)")]
        public void ThenVerifyPotentialRevenueAcceptsMaxEightDigitsIncludingCurrencyWithWholeNumbers(string PotentialRevenue)
        {
            
            MoveToElement(attributeName_id, YeartoDateRevenuetextbox_id);
            Clear(attributeName_id, YeartoDateRevenuetextbox_id);
            SendKeys(attributeName_id, PotentialRevenuetextbox_id, PotentialRevenue);
            string PotentialRevenueUI = GetValue(attributeName_id, PotentialRevenuetextbox_id,"value");
            Assert.AreEqual("$" + (PotentialRevenue), PotentialRevenueUI.Replace(",", ""));
        }

        [Then(@"Potential Revenue does accepts more than eight digits including currency with whole numbers (.*)")]
        public void ThenPotentialRevenueDoesAcceptsMoreThanEightDigitsIncludingCurrencyWithWholeNumbers(string PotentialRevenue)
        {
            
            MoveToElement(attributeName_id, PotentialRevenuetextbox_id);
            Clear(attributeName_id, PotentialRevenuetextbox_id);
            SendKeys(attributeName_id, PotentialRevenuetextbox_id, PotentialRevenue);
            string PotentialRevenueUI = GetValue(attributeName_id, PotentialRevenuetextbox_id,"value");
            Assert.AreNotEqual("$" + (PotentialRevenue), PotentialRevenueUI.Replace(",", ""));
        }


        [Then(@"Verify the MGCSA Total Hours accepts max four digits of whole numbers (.*)")]
        public void ThenVerifyTheMGCSATotalHoursAcceptsMaxFourDigitsOfWholeNumbers(string MGCSATotalHours)
        {
            
            MoveToElement(attributeName_id, MG_CSATotalHourstextbox_id);
            Clear(attributeName_id, MG_CSATotalHourstextbox_id);
            SendKeys(attributeName_id, MG_CSATotalHourstextbox_id, MGCSATotalHours);
            string MGCSATotalHoursUI = GetValue(attributeName_id, MG_CSATotalHourstextbox_id,"value");
            Assert.AreEqual(MGCSATotalHoursUI, MGCSATotalHours);
        }

        [Then(@"Verify the MGCSA Total hours field does not accepts more than four digits of whole numbers (.*)")]
        public void ThenVerifyTheMGCSATotalHoursFieldDoesNotAcceptsMoreThanFourDigitsOfWholeNumbers(string MGCSATotalHours)
        {
            
            MoveToElement(attributeName_id, MG_CSATotalHourstextbox_id);
            Clear(attributeName_id, MG_CSATotalHourstextbox_id);
            SendKeys(attributeName_id, MG_CSATotalHourstextbox_id, MGCSATotalHours);
            string MGCSATotalHoursUI = GetValue(attributeName_id, MG_CSATotalHourstextbox_id,"value");
            Assert.AreNotEqual(MGCSATotalHoursUI, MGCSATotalHours);
        }


        [Then(@"Verify the Integration Total Hours field accepts max of four digits of whole numbers (.*)")]
        public void ThenVerifyTheIntegrationTotalHoursFieldAcceptsMaxOfFourDigitsOfWholeNumbers(string IntegrationTotalHours)
        {
            
            MoveToElement(attributeName_id, IntegrationTeamTotalHourstextbox_id);
            Clear(attributeName_id, IntegrationTeamTotalHourstextbox_id);
            SendKeys(attributeName_id, IntegrationTeamTotalHourstextbox_id, IntegrationTotalHours);
            string IntegrationTotalHoursUI = GetValue(attributeName_id, IntegrationTeamTotalHourstextbox_id,"value");
            Assert.AreEqual(IntegrationTotalHoursUI, IntegrationTotalHours);
        }


        [Then(@"Integration Team Total Hours field does not accepst more than four digits of whole numbers (.*)")]
        public void ThenIntegrationTeamTotalHoursFieldDoesNotAccepstMoreThanFourDigitsOfWholeNumbers(string IntegrationTotalHours)
        {
            
            MoveToElement(attributeName_id, IntegrationTeamTotalHourstextbox_id);
            Clear(attributeName_id, IntegrationTeamTotalHourstextbox_id);
            SendKeys(attributeName_id, IntegrationTeamTotalHourstextbox_id, IntegrationTotalHours);
            string IntegrationTotalHoursUI = GetValue(attributeName_id, IntegrationTeamTotalHourstextbox_id,"value");
            Assert.AreNotEqual(IntegrationTotalHoursUI, IntegrationTotalHours);
        }














    }
}
