using System;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class InsuranceClaims_ClaimsList_UpdateStatusColorCodesSteps : InsuranceClaim
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates, sales, sales management, operations, station owner, or claim specialist user")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesSalesSalesManagementOperationsStationOwnerOrClaimSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-CurrentSprintshpentry"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentSprintshpentry"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }
        
        [Then(@"the Open status color code will changed to a lighter blue")]
        public void ThenTheOpenStatusColorCodeWillChangedToALighterBlue()
        {
            
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Verifying the color code of the status Open");
            Click(attributeName_xpath,ClaimsList_OpenStatusCheckbox_xpath);
            Click(attributeName_xpath, ClaimListSearchTextBox_xpath);
            SendKeys(attributeName_xpath, ClaimListSearchTextBox_xpath,"Open");
            string open_Status_Color = GetElementPropertyValueFromGivenXPath.GetBackgroundColorFromGivenXPath(ClaimsList_OpenStatusColor_xpath);
            Assert.AreEqual(open_Status_Color, "rgb(0, 0, 255)");
            Report.WriteLine("Color code of Open status is verified");

           

        }

        
    }
}
