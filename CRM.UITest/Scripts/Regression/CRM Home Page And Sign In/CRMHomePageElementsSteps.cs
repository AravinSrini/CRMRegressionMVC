using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest
{
    [Binding]
	public class CRMLandingPageSteps : ObjectRepository
    {
        string homepageURL = ConfigurationManager.AppSettings["BaseUrl"];

        [Given(@"I navigate to the homepage")]
        public void GivenINavigateToTheHomepage()
        {
            Report.WriteLine("Navigating to CRM home page - " + homepageURL);
            GlobalVariables.webDriver.Navigate().GoToUrl(homepageURL);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I enter login name as (.*) and password as (.*)")]
        public void GivenIEnterLoginNameAsCurrentsprintshipentry(string loginName, string password)
        {
            Report.WriteLine("Entering username and password");
            SendKeys(attributeName_id, "username", ConfigurationManager.AppSettings[loginName]);
            SendKeys(attributeName_id, "password", ConfigurationManager.AppSettings[password]);
        }

        [When(@"I click on log in")]
        public void WhenIClickOnLogIn()
        {
            Report.WriteLine("Clicking the login button");
            Click(attributeName_xpath, "//button[text()='SIGN IN']");

            if (GlobalVariables.webDriver is FirefoxDriver)
            {
                Thread.Sleep(1000);
                GlobalVariables.webDriver.SwitchTo().Alert().Accept();
            }

            GlobalVariables.webDriver.WaitForPageLoad();

            if (IsElementPresent(attributeName_id, Loading_Icon_Id, "Loading icon"))
            {
                WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "loading icon");
            }
        }

        [When(@"I am on the home page")]
        public void WhenIAmOnTheHomePage()
        {
            Report.WriteLine("Checking we are on the CRM home page");
            string currentURL = GlobalVariables.webDriver.Url;

            if (currentURL != homepageURL)
            {
                Report.WriteFailure("We are not on the homepage... current URL - " + currentURL);
            }
        }

        [When(@"I click the rrd dls worldwide logo")]
        public void WhenIClickTheRrdDlsWorldwideLogo()
        {
            Report.WriteLine("Click on RR Donnelley Logo");
            Click(attributeName_xpath, "//*[@class='footer-logo']/a");
        }

        [When(@"I click the privacy policy link")]
        public void WhenIClickThePrivacyPolicyLink()
        {
            Report.WriteLine("Click on privacy policy link");
            Click(attributeName_xpath, "//div[@class = 'row @*legal-links*@']//a[text() = 'Privacy Policy']");
        }

        [When(@"I click the terms of use link")]
        public void WhenIClickTheTermsOfUseLink()
        {
            Report.WriteLine("Click on privacy policy link");
            Click(attributeName_xpath, "//div[@class = 'row @*legal-links*@']//a[text() = 'Terms of Use']");
        }

        [Given(@"I click on the sign in button")]
        [When(@"I click on Sign In button")]
		public void WhenIClickOnSignInButton()
		{
			Report.WriteLine("Click on Sign In");
			Click(attributeName_id, SignIn_Id);
		}

        [When(@"I click on I Agree on the cookie script section")]
        public void WhenIClickOnIAgreeOnTheCookieScriptSection()
        {
            Report.WriteLine("Click on I agree for cookie script");
            IWebElement element;
            if (GlobalVariables.webDriver.FindElements(By.Id("cookiescript_accept")).Count < 1)
            {
                element = GlobalVariables.webDriver.FindElement(By.Id("cookiescript_badge"));
                WebDriverHelpers.ClickElement(element);
                WaitForElementVisible(attributeName_id, "cookiescript_accept", "cookie button");
                element = GlobalVariables.webDriver.FindElement(By.Id("cookiescript_accept"));
            }
            else
            {
                element = GlobalVariables.webDriver.FindElement(By.Id("cookiescript_accept"));
            }

            WebDriverHelpers.ClickElement(element);
        }

        [When(@"I click on I Disagree on the cookie script section")]
        public void WhenIClickOnIDisagreeOnTheCookieScriptSection()
        {
            Report.WriteLine("Click on I disagree for cookie script");
            IWebElement element;
            if (GlobalVariables.webDriver.FindElements(By.Id("cookiescript_reject")).Count < 1)
            {
                element = GlobalVariables.webDriver.FindElement(By.Id("cookiescript_badge"));
                WebDriverHelpers.ClickElement(element);
                WaitForElementVisible(attributeName_id, "cookiescript_reject", "cookie button");
                element = GlobalVariables.webDriver.FindElement(By.Id("cookiescript_reject"));
            }
            else
            {
                element = GlobalVariables.webDriver.FindElement(By.Id("cookiescript_reject"));
            }

            WebDriverHelpers.ClickElement(element);
        }

        [When(@"I click on read more on the cookie script section")]
        public void WhenIClickOnReadMoreOnTheCookieScriptSection()
        {
            Report.WriteLine("Click on Read More for cookie script");

            IWebElement element;
            if (GlobalVariables.webDriver.FindElements(By.Id("cookiescript_readmore")).Count < 1)
            {
                element = GlobalVariables.webDriver.FindElement(By.Id("cookiescript_badge"));
                WebDriverHelpers.ClickElement(element);
                WaitForElementVisible(attributeName_id, "cookiescript_readmore", "cookie button");
                element = GlobalVariables.webDriver.FindElement(By.Id("cookiescript_readmore"));
            }
            else
            {
                element = GlobalVariables.webDriver.FindElement(By.Id("cookiescript_readmore"));
            }

            WebDriverHelpers.ClickElement(element);
        }

        [Then(@"the Sign In button must appear on the top right corner with the text '(.*)'")]
		public void ThenTheSignInButtonMustAppearOnTheTopRightCornerWithTheText(string SignIn)
		{
			Report.WriteLine("Verify the presence of Sign In button");
            Verifytext(attributeName_id, SignIn_Id, SignIn);
		}

        [Then(@"I will see the rrd dls worldwide logo")]
        public void ThenIWillSeeTheRrdDlsWorldwideLogo()
        {
            Report.WriteLine("Verify the presence of website brand logo");
            VerifyElementVisible(attributeName_xpath, "//*[@class = 'navbar-brand']//img", "Website Brand Logo");
        }

        [Then(@"I will see the track up to 10 shipments by reference number area")]
        public void ThenIWillSeeTheTrackUpToShipmentsByReferenceNumberArea()
        {
            Report.WriteLine("Verify Heading for tracking up to 10 shipments");
            VerifyElementVisible(attributeName_xpath, "//*[@class = 'container tracking-container']//h5[text() = 'Track Up To 10 Shipments by Reference Number']", "Reference Number Heading");

            Report.WriteLine("Verify main text for tracking up to 10 shipments");
            string expectedText = "Enter up to 10 Reference Numbers into the field below. The following types are acceptable: Bill of Lading, Purchase Order or PRO Number. All references must be comma separated and are case sensitive.";
            Verifytext(attributeName_xpath, "//*[@class = 'container tracking-container']/div[1]/div[1]/p", expectedText);

            Report.WriteLine("Verify reference number inputs for tracking up to 10 shipments");
            VerifyElementVisible(attributeName_id, "txtReferenceNumer", "reference number input");

            Report.WriteLine("Verify submit button for tracking up to 10 shipments");
            VerifyElementVisible(attributeName_xpath, "//*[@class = 'container tracking-container']//button[contains(@class, 'btnReference ')]", "reference number submit button");
        }

        [Then(@"I will see the track multiple shipments by file upload area")]
        public void ThenIWillSeeTheTrackMultipleShipmentsByFileUploadArea()
        {
            Report.WriteLine("Verify Heading for tracking multiple shipments");
            VerifyElementVisible(attributeName_xpath, "//*[@class = 'container tracking-container']//h5[text() = 'Track Multiple Shipments by File Upload']", "Reference Number File Upload Heading");

            Report.WriteLine("Verify main text for tracking multiple shipments");
            string expectedText = "To track up to 25 shipments, click the Upload button below. Excel is the only acceptable file type. If you have never uploaded a file before, you must first download and use the template below.";
            Verifytext(attributeName_xpath, "//*[@class = 'container tracking-container']/div[1]/div[2]/p", expectedText);

            Report.WriteLine("Verify download template button is visible");
            VerifyElementVisible(attributeName_id, "btnDownloadTemplate", "download template button");

            Report.WriteLine("Verify upload template button is visible");
            VerifyElementVisible(attributeName_id, "btn-UploadDocument", "reference number input");
        }

        [Then(@"I will see the privacy policy link")]
        public void ThenIWillSeeThePrivacyPolicyLink()
        {
            Report.WriteLine("Verify privacy policy link is visible");
            VerifyElementVisible(attributeName_xpath, "//div[@class = 'row @*legal-links*@']//a[text() = 'Privacy Policy']", "Privacy Policy Link");
        }

        [Then(@"I will see the terms of use link")]
        public void ThenIWillSeeTheTermsOfUseLink()
        {
            Report.WriteLine("Verify terms of use link is visible");
            VerifyElementVisible(attributeName_xpath, "//div[@class = 'row @*legal-links*@']//a[text() = 'Terms of Use']", "Terms of Use Link");
        }

        [Then(@"I will see the cookies section")]
        public void ThenIWillSeeTheCookiesSection()
        {
            Report.WriteLine("Verify cookie section is visible");

            IWebElement element;
            if (GlobalVariables.webDriver.FindElements(By.Id("cookiescript_readmore")).Count < 1)
            {
                element = GlobalVariables.webDriver.FindElement(By.Id("cookiescript_badge"));
                WebDriverHelpers.ClickElement(element);
            }

            VerifyElementVisible(attributeName_id, "cookiescript_wrapper", "Cookie Section");
        }

        [Then(@"I will be redirected to the RR Donnelley home page")]
        public void ThenIWillBeRedirectedToTheRRDonnelleyHomePage()
        {
            Report.WriteLine("Checking we are on the RRD homepage");
            string currentURL = GlobalVariables.webDriver.Url;

            if (currentURL != "https://www.rrdonnelley.com/")
            {
                Report.WriteFailure("We are not on the rrd homepage... current URL - " + currentURL);
            }
        }

        [Then(@"I will be redirected to the privacy policy page for R R Donnelley")]
        public void ThenIWillBeRedirectedToThePrivacyPolicyPageForRRDonnelley()
        {
            Thread.Sleep(1500);
            Report.WriteLine("Checking we are on the privacy policy page");
            var tabs = GlobalVariables.webDriver.WindowHandles;
            GlobalVariables.webDriver.SwitchTo().Window(tabs[1]);
            GlobalVariables.webDriver.WaitForPageLoad();
            string currentURL = GlobalVariables.webDriver.Url;

            if (currentURL != "https://www.rrdonnelley.com/privacy-policy/")
            {
                Report.WriteFailure("We are not on the rrd privacy policy... current URL - " + currentURL);
            }
        }

        [Then(@"I will be redirected to the terms of use page for R R Donnelley")]
        public void ThenIWillBeRedirectedToTheTermsOfUsePageForRRDonnelley()
        {
            Thread.Sleep(1500);
            Report.WriteLine("Checking we are on the terms of use page");
            var tabs = GlobalVariables.webDriver.WindowHandles;
            GlobalVariables.webDriver.SwitchTo().Window(tabs[1]);
            GlobalVariables.webDriver.WaitForPageLoad();
            string currentURL = GlobalVariables.webDriver.Url;

            if (currentURL != "https://www.rrdonnelley.com/terms-of-use.aspx")
            {
                Report.WriteFailure("We are not on the terms of use... current URL - " + currentURL);
            }
        }

        [Then(@"I will get a new tab with the cookie policy page")]
        public void ThenIWillGetANewTabWithTheCookiePolicyPage()
        {
            Thread.Sleep(2000);
            Report.WriteLine("Checking we are on the terms of use page");
            var tabs = GlobalVariables.webDriver.WindowHandles;
            GlobalVariables.webDriver.SwitchTo().Window(tabs[1]);
            GlobalVariables.webDriver.WaitForPageLoad();
            string currentURL = GlobalVariables.webDriver.Url;

            if (currentURL != homepageURL + "CookiePolicy")
            {
                Report.WriteFailure("We are not on the cookie policy... current URL - " + currentURL);
            }
        }


        [Then(@"the cookie script section will dissappear from view")]
        public void ThenTheCookieScriptSectionWillDissappearFromView()
        {
            Thread.Sleep(1000);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Checking to make sure cookie script is not on the page anymore");
            VerifyElementNotPresent(attributeName_id, "cookiescript_injected", "Cookie script element");

            VerifyElementVisible(attributeName_id, "cookiescript_badge", "Cookie Script Badge");
        }

        [Then(@"I will be redirected to the dashboard")]
        public void ThenIWillBeRedirectedToTheDashboard()
        {
            Report.WriteLine("Checking to see if we have logged in successfully");
            string currentURL = GlobalVariables.webDriver.Url;
            if(!currentURL.Contains("Dashboard"))
                Report.WriteFailure("We are not on the crm dashboard... current URL - " + currentURL);
        }









        [Then(@"I must land on the IDP Login Screen '(.*)'")]
		public void ThenIMustLandOnTheIDPLoginScreen(string IDPLoginText)
		{
			Report.WriteLine("Verify the IDP Login screen");
			string IDPLoginText_UI = Gettext(attributeName_xpath, IDPLoginText_Xpath);
			Assert.AreEqual(IDPLoginText, IDPLoginText_UI);
		}


		[Then(@"on entering a valid username '(.*)' and password '(.*)' and clicking on Log In I land on the CRM dashboard '(.*)'")]
		public void ThenOnEnteringAValidUsernameAndPasswordAndClickingOnLogInILandOnTheCRMDashboard(string Username, string Password, string Dashboard)
		{
			Report.WriteLine("Enter valid Username and Password and click on Log in");
			SendKeys(attributeName_id, IDP_Username_Id, Username);
			SendKeys(attributeName_id, IDP_Password_Id, Password);
			Click(attributeName_xpath, IDP_Login_Xpath);

			Report.WriteLine("Verify the Presence of Dashboard text after successful login");

			string Dashboard_UI = Gettext(attributeName_xpath, StnOwnerDashboard_UI_Xpath);
			Assert.AreEqual(Dashboard, Dashboard_UI);
		}

	}
}
