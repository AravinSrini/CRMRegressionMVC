using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Dashboard
{
    [Binding]
    public class BuildResponsiveHeaderSteps_Desktop : ObjectRepository
    {
        //[Then(@"Verify the application Header text '(.*)'")]
        //public void ThenVerifyTheApplicationHeaderText(string p0)
        //{
        //    ScenarioContext.Current.Pending();
        //}


        [Then(@"Verify the Users full name '(.*)' is displayed in the user profile drop down")]
        public void ThenVerifyTheUsersFullNameIsDisplayedInTheUserProfileDropDown(string UserFullName)
        {
            Verifytext(attributeName_id, userFullName_Id, UserFullName.ToUpper());
        }

        [When(@"I click on the User Profile drop down")]
        public void WhenIClickOnTheUserProfileDropDown()
        {
            Click(attributeName_xpath, userProfileDropdown_Xpath);
        }



        [Then(@"Verify the drop down Options lists '(.*)', '(.*)', '(.*)' in the User Profile drop down")]
        public void ThenVerifyTheDropDownOptionsListsInTheUserProfileDropDown(string OptionList1, string OptionList2, string OptionList3)
        {

            //string[] OptionList = new string[] { OptionList1, OptionList2, OptionList3 };
            //int count = OptionList.Count();

            //Click(attributeName_xpath, userProfileDropdown_Xpath);
            //IList<IWebElement> UserDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(UserDropDownLists_xpath));           
            //int UserDropDownCount = UserDropDownList.Count;
            //for (int i = 0; i < UserDropDownCount; i++)

            //    if (UserDropDownList.Count > 0)
            //{
            //    List<string> options = new List<string>();
            //    foreach (IWebElement element in UserDropDownList)
            //    {
            //        options.Add((element.Text).ToString());
            //    }
            //    List<Decimal> Rate = new List<Decimal>();
            //    for (int i = 0; i < InitialRate.Count; i++)
            //    {
            //        string[] RateListB = InitialRate[i].Split('*', ' ', '$');//After Click list
            //        Decimal RateB = Convert.ToDecimal(RateListB[3]);
            //        Rate.Add(RateB);
            //    }
            //}

         }

        [Given(@"I select the (.*) from the User profile drop down")]
        public void GivenISelectTheFromTheUserProfileDropDown(string p0)
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"User should be able too see the (.*) from the User profile drop down")]
        public void ThenUserShouldBeAbleTooSeeTheFromTheUserProfileDropDown(string OptionLists)
        {
            VerifyElementPresent(attributeName_xpath, POManagementOption_xpath, OptionLists);
        }


        [When(@"I select the '(.*)' from the User profile drop down")]
        public void WhenISelectTheFromTheUserProfileDropDown(string OptionLists)
        {
            
            IList<IWebElement> UserDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(UserDropDownLists_xpath));
            int UserDropDownCount = UserDropDownList.Count;
            for (int i = 0; i < UserDropDownCount; i++)
            {
               if (UserDropDownList[i].Text == OptionLists)
                {
                    UserDropDownList[i].Click();
                    break;
                }

            }
            
        }



        [Then(@"Terms of Use window pop up should be displayed")]
        public void ThenTermsOfUseWindowPopUpShouldBeDisplayed()
        {
            WaitForElementVisible(attributeName_xpath, TermsofUseText_xpath, "Terms of Use");
            Verifytext(attributeName_xpath, TermsofUseText_xpath, "Terms of Use");
        }


        [Then(@"Verify the Download PDF link is visible in the window pop up")]
        public void ThenVerifyTheDownloadPDFLinkIsVisibleInTheWindowPopUp()
        {
            IsElementPresent(attributeName_xpath, DownloadPDFLink_Id,"Download PDF");
        }


        [Then(@"Verify the Close button is visible")]
        public void ThenVerifyTheCloseButtonIsVisible()
        {
            IsElementPresent(attributeName_id, TermsofUseCloseButton_Id, "Close");
        }


        [Then(@"Verify user is navigated back to the Login page and able to see the sign In button")]
        public void ThenVerifyUserIsNavigatedBackToTheLoginPageAndAbleToSeeTheSignInButton()
        {
            IsElementPresent(attributeName_id, SignIn_Id, "Sign In");
        }


        [Then(@"Verify the PO Management option '(.*)' is not visible to the admin users")]
        public void ThenVerifyThePOManagementOptionIsNotVisibleToTheAdminUsers(string OptionLists)
        {
           VerifyElementNotPresent(attributeName_id, POManagementOption_Id, OptionLists);
           

        }



    }
}
