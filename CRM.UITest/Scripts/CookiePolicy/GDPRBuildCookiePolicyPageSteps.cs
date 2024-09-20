using CRM.UITest.Helper.DataModels;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.Helper;
using CRM.UITest.Entities;

namespace CRM.UITest.Scripts.CookiePolicy
{
    [Binding]
    public class GDPRBuildCookiePolicyPageSteps : ObjectRepository
    {
        string crmWebUrl = ConfigurationManager.AppSettings["BaseUrl"].ToString();
        List<CookieModel> cookiesModelList = new List<CookieModel>();
        List<CookieCategoryModel> cookieCategories = new List<CookieCategoryModel>();

        [Given(@"I am any user on any CRM page")]
        public void GivenIAmAnyUserOnAnyCRMPage()
        {
            DefineTimeOut(600000);
            Report.WriteLine("Launch URL");
            LaunchURL();
            Report.WriteLine("Land on Homepage");
        }

        [When(@"I click Read More in the cookie description popup")]
        public void WhenIClickReadMoreInTheCookieDescriptionPopup()
        {
            Click(attributeName_id, CommonConstants.CookieReadMoreId);
        }

        [Then(@"I will navigate to the new cookie details page")]
        public void ThenIWillNavigateToTheNewCookieDetailsPage()
        {
            string cookiePageUrl = crmWebUrl + "CookiePolicy";
            Report.WriteLine("Cookie details page will be opened in new tab");
            Thread.Sleep(20000);
            bool val = WindowHandling(cookiePageUrl);
            if (val == true)
            {
                Report.WriteLine("URL is matching in New Tab");
            }
        }

        [Given(@"I click Read More in the cookie description popup")]
        public void GivenIClickReadMoreInTheCookieDescriptionPopup()
        {
            Click(attributeName_id, CommonConstants.CookieReadMoreId);
        }

        [When(@"I will navigate to the new cookie details page")]
        public void WhenIWillNavigateToTheNewCookieDetailsPage()
        {
            string cookiePageUrl = crmWebUrl + CommonConstants.CookiePolicy;
            Report.WriteLine("Cookie details page will be opened in new tab");
            Thread.Sleep(20000);
            WindowHandling(cookiePageUrl);
            Click(attributeName_id, CommonConstants.CookieIAccept);
        }

        [Then(@"I will see Cookie Policy label")]
        public void ThenIWillSeeCookiePolicyLabel()
        {
            VerifyElementVisible(attributeName_xpath, CommonConstants.CookiePolicyLabel, "cookiepolicylabel");
            Report.WriteLine("Verified Cookie Policy Label is present");
        }

        [Then(@"I will see To Review RRD's Cookie Policy label")]
        public void ThenIWillSeeToReviewRRDSCookiePolicyLabel()
        {
            VerifyElementVisible(attributeName_xpath, CommonConstants.Reviewcookiepolicylabel1, "reviewcookiepolicylabel");
            VerifyElementVisible(attributeName_xpath, CommonConstants.Reviewcookiepolicylabel2, "reviewcookiepolicylabel");
            Report.WriteLine("Verified Review Cookie Policy Labels are present");
        }

        [Then(@"I will see Last Update on label")]
        public void ThenIWillSeeLastUpdateOnLabel()
        {
            VerifyElementVisible(attributeName_xpath, CommonConstants.LastUpdateLabel, "cookiepolicylastupdatelabel");
            Report.WriteLine("Verified Last Update Label is present");
        }

        [Then(@"I will see all cookie types available in db")]
        public void ThenIWillSeeAllCookieTypesAvailableInDb()
        {
            int cookieCount = GetCount(attributeName_xpath, CommonConstants.CookieCategory);
            List<string> cookieCategoryTypes = new List<string>();
            for (int i = 0; i < cookieCount; i++)
            {
                string cookiePath = "/html/body/div/section/h2[" + (i + 1) + "]";
                string cookie = Gettext(attributeName_xpath, cookiePath);
                cookieCategoryTypes.Add(cookie.ToLower());
            }

            cookieCategoryTypes.Sort();
            GetCookieDetailsFromDb();
            List<string> cookiesCategoryFromDb = cookieCategories.Select(x => x.CookieCategoryName.ToLower()).ToList();
            cookiesCategoryFromDb.Sort();

            CollectionAssert.AreEqual(cookiesCategoryFromDb, cookieCategoryTypes);
            Report.WriteLine("Verified Cookie Categories from Database");
        }

        [Then(@"I will see last updated time from db")]
        public void ThenIWillSeeLastUpdatedTimeFromDb()
        {
            string DateFromUI = Gettext(attributeName_xpath, CommonConstants.LastUpdateTime);
            GetCookieDetailsFromDb();
            DateTime DateTimeExpected = GetLatestDateFromCookiesModifiedDates(cookiesModelList);
            string date = DateTimeExpected.Date.ToString();
            date = date.Substring(0, 8).Trim();
            Assert.IsTrue(DateFromUI.Contains(date));

            Report.WriteLine("Verified Last Updated date from Database");
        }

        [Then(@"I will see description for that cookie")]
        public void ThenIWillSeeDescriptionForThatCookie()
        {
            GetCookieDetailsFromDb();
            string FunctionalCookieDescription = Gettext(attributeName_xpath, CommonConstants.FunctionalCookieDescriptionPath);
            string functionCookieDescFromDb = cookieCategories.Where(x => x.CookieCategoryName.ToLower().Contains("functional")).Select(x => x.CookieCategoryDescription).FirstOrDefault().ToString();
            Assert.AreEqual(FunctionalCookieDescription.ToLower(), functionCookieDescFromDb.ToLower());

            string StrictlyNeccessaryCookieDescription = Gettext(attributeName_xpath, CommonConstants.StrictlyNeccessaryCookieDescriptionPath);
            string strictlyNecessaryCookieDescFromDb = cookieCategories.Where(x => x.CookieCategoryName.ToLower().Contains("strictly")).Select(x => x.CookieCategoryDescription).FirstOrDefault().ToString();
            Assert.AreEqual(StrictlyNeccessaryCookieDescription.ToLower(), strictlyNecessaryCookieDescFromDb.ToLower());

            string PerformanceCookieDescription = Gettext(attributeName_xpath, CommonConstants.PerformanceCookieDescriptionPath);
            string performaceCookieDescFromDb = cookieCategories.Where(x => x.CookieCategoryName.ToLower().Contains("performance")).Select(x => x.CookieCategoryDescription).FirstOrDefault().ToString();
            Assert.AreEqual(PerformanceCookieDescription.ToLower(), performaceCookieDescFromDb.ToLower());

            Report.WriteLine("Verified Cookie Description from Database");
        }

        [Then(@"I will see cookie part type name")]
        public void ThenIWillSeeCookiePartTypeName()
        {
            int cookieCount = GetCount(attributeName_xpath, CommonConstants.CookieCategory);
            string expectedValue = "FIRST PARTY/THIRD PARTY";
            for (int i = 0; i < cookieCount; i++)
            {
                string partType = Gettext(attributeName_xpath, "//div[@id='CookieTypeGrid" + (i + 1) + "_wrapper']//tr/th[2]");
                Assert.AreEqual(expectedValue, partType);
            }

            Report.WriteLine("Verified Cookie PartType as FIRST PARTY / THIRD PARTY");
        }

        [Then(@"I will see list of cookie name value")]
        public void ThenIWillSeeListOfCookieNameValue()
        {
            int count = GetCount(attributeName_xpath, CommonConstants.CookieNames);
            List<string> cookieTypes = new List<string>();
            for (int i = 0; i < count; i++)
            {
                string cookieName = Gettext(attributeName_xpath, "/html/body/div/section/div[3]/table/tbody/tr[" + (i + 1) + "]/td[1]");
                cookieTypes.Add(cookieName);
            }

            cookieTypes.Sort();
            GetCookieDetailsFromDb();
            List<string> cookiesFromDb = cookiesModelList.Select(x => x.CookieName).ToList();
            cookiesFromDb.Sort();

            CollectionAssert.AreEqual(cookiesFromDb, cookieTypes);
            Report.WriteLine("Verified Cookie Names from Database");
        }

        [Then(@"I will see cookie part type name value")]
        public void ThenIWillSeeCookiePartTypeNameValue()
        {
            int count = GetCount(attributeName_xpath, CommonConstants.CookieNames);
            GetCookieDetailsFromDb();
            for (int i = 0; i < count; i++)
            {
                string cookieName = Gettext(attributeName_xpath, "/html/body/div/section/div[3]/table/tbody/tr[" + (i + 1) + "]/td[1]");
                string partTypeOnUi = Gettext(attributeName_xpath, "/html/body/div/section/div[3]/table/tbody/tr[" + (i + 1) + "]/td[2]");
                string getPartType = cookiesModelList.Where(x => x.CookieName.Equals(cookieName, StringComparison.InvariantCultureIgnoreCase)).Select(x => x.PartType).FirstOrDefault().ToString();
                Assert.AreEqual(getPartType.ToLower(), partTypeOnUi.ToLower());
            }

            Report.WriteLine("Verified PartType value for each cookie from Database");
        }

        [Then(@"I will see cookie life span value")]
        public void ThenIWillSeeCookieLifeSpanValue()
        {
            int count = GetCount(attributeName_xpath, CommonConstants.CookieNames);
            GetCookieDetailsFromDb();
            for (int i = 0; i < count; i++)
            {
                string cookieName = Gettext(attributeName_xpath, "/html/body/div/section/div[3]/table/tbody/tr[" + (i + 1) + "]/td[1]");
                string lifeSpanOnUi = Gettext(attributeName_xpath, "/html/body/div/section/div[3]/table/tbody/tr[" + (i + 1) + "]/td[3]");
                string lifeSpanDb = cookiesModelList.Where(x => x.CookieName.Equals(cookieName, StringComparison.InvariantCultureIgnoreCase)).Select(x => x.LifeSpan).FirstOrDefault().ToString();
                Assert.AreEqual(lifeSpanDb, lifeSpanOnUi);
            }

            Report.WriteLine("Verified LifeSpan value for each cookie from Database");
        }

        [Then(@"I will see cookie purpose description")]
        public void ThenIWillSeeCookiePurposeDescription()
        {
            int count = GetCount(attributeName_xpath, CommonConstants.CookieNames);
            GetCookieDetailsFromDb();
            for (int i = 0; i < count; i++)
            {
                string cookieName = Gettext(attributeName_xpath, "/html/body/div/section/div[3]/table/tbody/tr[" + (i + 1) + "]/td[1]");
                string purposeOnUi = Gettext(attributeName_xpath, "/html/body/div/section/div[3]/table/tbody/tr[" + (i + 1) + "]/td[4]");
                string purposeInDb = cookiesModelList.Where(x => x.CookieName.Equals(cookieName, StringComparison.InvariantCultureIgnoreCase)).Select(x => x.Purpose).FirstOrDefault().ToString();
                Assert.AreEqual(purposeInDb, purposeOnUi);
            }

            Report.WriteLine("Verified Purpose for each cookie from Database");
        }

        [Then(@"I will see Sign in Button on Right Top Corner")]
        public void ThenIWillSeeSignInButtonOnRightTopCorner()
        {
            VerifyElementVisible(attributeName_id, CommonConstants.CookiePageSignInButtonId, "Sign In");
            Report.WriteLine("Verified Sign In button is available on top right corner");
        }

        public static DateTime GetLatestDateFromCookiesModifiedDates(List<CookieModel> cookies)
        {
            return cookies.Select(m => m.ModifiedDate).OrderByDescending(m => m).FirstOrDefault();
        }

        public static void GetCookieDetailsFromDb()
        {
            List<CookieModel> cookiesModelList = DBHelper.GetAllCookiesfromDb();
            List<CookieCategoryModel> cookieCategories = DBHelper.GetAllCookieCategories();
        }
    }
}
