using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using MoreLinq;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claims_List
{
    [Binding]
    public  class InsuranceClaims_ClaimAgeCounterSteps : InsuranceClaim
    {

        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates, Sales, Sales Management, Operations or Station Owner user")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesSalesSalesManagementOperationsOrStationOwnerUser()
        {
            string Username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string Password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();

            CrmLogin.LoginToCRMApplication(Username, Password);
        }

        [Then(@"The Claim Age value will be calculated as Current Date - Claim Date Submitted = Number of days")]
        public void ThenTheClaimAgeValueWillBeCalculatedAsCurrentDate_ClaimDateSubmittedNumberOfDays()
        {
            
            Click(attributeName_xpath, ".//*[text()='Pending']");
            DefineTimeOut(2000);
            Click(attributeName_xpath, ".//*[text()='Open']");
            DefineTimeOut(2000);
            Click(attributeName_xpath, ".//*[text()='Paid']");
            DefineTimeOut(2000);
            Click(attributeName_xpath, ".//*[text()='Denied']");
            DefineTimeOut(2000);
            Click(attributeName_xpath, ".//*[text()='Cancelled']");
            DefineTimeOut(2000);

            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td");
            int Shipmentrowcount = GetCount(attributeName_xpath, ClaimsList_TotalRecords_Xpath);

            if (Shipmentrowcount >= 1 && noReocrdsCheck != "No Results Found")
            {
                Report.WriteLine("Selected grid view as all");
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select");
                IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_TopGrid_ViewDropdownValues_Xpath));
                int CustomerNameListCount = UIValues.Count;
                for (int i = 0; i < CustomerNameListCount; i++)
                {
                    if (UIValues[i].Text == "ALL")
                    {
                        UIValues[i].Click();
                        break;
                    }
                }

                DefineTimeOut(2000);
                Report.WriteLine("Claim Age value should be calculated as Current Date - Claim Date submitted = No of days");

                IList<IWebElement> DlsClaimNumber_UI = GlobalVariables.webDriver.FindElements(By.XPath("//tr//*[@class='DlswClaimNumber']"));
                int DlsClaimNumber_UICount = DlsClaimNumber_UI.Count;
                for (int i = 0; i < DlsClaimNumber_UICount; i++)
                {
                    string DlsClaimNumber = DlsClaimNumber_UI[i].Text;
                    int TogetDate = int.Parse(DlsClaimNumber);

                    Entities.Proxy.InsuranceClaim togetDatefromDb = DBHelper.ListOfDatesBasedonClaimNo(TogetDate);
                    string tocheckdate = togetDatefromDb.CreateDateTime.Date.ToString();

                    string[] DatefromDbSplit = tocheckdate.Split(' ');
                    string DatefromDb = DatefromDbSplit[0].ToString();


                    int k = i + 1;
                    string fromuiNoofDays = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[" + k + "]/td[10]");
                    int tocheckd = int.Parse(fromuiNoofDays);

                    //Current date - no of days = submitted date 
                    DateTime TogetActualDate = DateTime.Now.AddDays(-tocheckd);

                    string getfromsystem = TogetActualDate.Date.ToString();
                    string[] TogetActualDateSplit = getfromsystem.Split(' ');
                    string CorrectDateAfter_Minus = TogetActualDateSplit[0].ToString();

                    if (DatefromDb == CorrectDateAfter_Minus)
                    {
                        Report.WriteLine("No of" + fromuiNoofDays + "is correct");
                    }
                    else
                    {
                        Report.WriteFailure("No of days not matched");
                    }
                }
             }
            else
            {
                Report.WriteLine("No records found");
            }


            
        }

     
    }
}
