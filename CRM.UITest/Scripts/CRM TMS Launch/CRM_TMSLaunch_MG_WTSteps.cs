using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using System.Threading;

namespace CRM.UITest.Scripts.CRM_TMS_Launch
{
	[Binding]
	public class CRM_TMSLaunch_MG_WTSteps : ObjectRepository
	{

		[Then(@"I must see the TMS Launch icon in left navigation bar")]
		public void ThenIMustSeeTheTMSLaunchIconInLeftNavigationBar()
		{
			VerifyElementPresent(attributeName_cssselector, TMS_Launch_Icon_css, "TMS Launch Icon");
		}

		[Then(@"I see the MG and World Track options when mouse hover on TMS icon")]
		public void ThenISeeTheMGAndWorldTrackOptionsWhenMouseHoverOnTMSIcon()
		{
			OnMouseOver(attributeName_cssselector, TMS_Launch_Icon_css);
			Verifytext(attributeName_xpath, TMS_Launch_MercuryGate_Option_xpath, "Mercury Gate");
			Verifytext(attributeName_xpath, TMS_Launch_WorldTrak_Option_xpath, "World-Trak");
		}

		[When(@"I mouser hover on TMS launch and click on MG option")]
		public void WhenIMouserHoverOnTMSLaunchAndClickOnMGOption()
		{
			OnMouseOver(attributeName_cssselector, TMS_Launch_Icon_css);
			Click(attributeName_xpath, TMS_Launch_MercuryGate_Option_xpath);
			Thread.Sleep(2000);
		}

		[Then(@"I must navigated to the Mercury Gate page")]
		public void ThenIMustNavigatedToTheMercuryGatePage()
		{
			Report.WriteLine("User is navigated to the Mercury Gate Login page");
			WindowHandling("https://qa-rrd.mercurygate.net/MercuryGate/login/mgLogin.jsp");
			string expectedURL = GetURL();
			Assert.AreEqual(expectedURL, "https://qa-rrd.mercurygate.net/MercuryGate/login/mgLogin.jsp");
		}

		[When(@"I mouser hover on TMS launch and click on World Track option")]
		public void WhenIMouserHoverOnTMSLaunchAndClickOnWorldTrackOption()
		{
			OnMouseOver(attributeName_cssselector, TMS_Launch_Icon_css);
			Click(attributeName_xpath, TMS_Launch_WorldTrak_Option_xpath);
		}

		[Then(@"I must navigated to the World Track page")]
		public void ThenIMustNavigatedToTheWorldTrackPage()
		{
			Report.WriteLine("User is navigated to the Mercury Gate Login page");
			Thread.Sleep(2000);
			WindowHandling("http://204.93.158.178/Worldtrak/");
			string expectedURL = GetURL();
			Assert.AreEqual("http://204.93.158.178/Worldtrak/", expectedURL);
		}
	}
}
