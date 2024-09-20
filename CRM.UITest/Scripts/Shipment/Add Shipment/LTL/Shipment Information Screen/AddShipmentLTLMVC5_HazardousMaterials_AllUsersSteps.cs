using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipmentLTLMVC5_HazardousMaterials_AllUsersSteps: AddShipments
    {
      
        
        [When(@"I click on yes button for Hazardous Materials in the Freight Description section")]
        public void WhenIClickOnYesButtonForHazardousMaterialsInTheFreightDescriptionSection()
        {
            Report.WriteLine("Click on Hazardous Materials");
            scrollElementIntoView(attributeName_xpath, FreightDesp_FirstItem_Hazardous_Yes_RadioButton_xpath);
            Click(attributeName_xpath, FreightDesp_FirstItem_Hazardous_Yes_RadioButton_xpath);
        }
        
        [Then(@"I should display with UN Number and CCN number")]
        public void ThenIShouldDisplayWithUNNumberAndCCNNumber()
        {
            Report.WriteLine("DisplayWithUNNumberAndCCNNumber");
            VerifyElementVisible(attributeName_id, FreightDesp_FirstItem_UN_Number_Id,"UN");
            VerifyElementVisible(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "CCN");
        }

        [Then(@"I should display with hazmat packing group with dropdown values '(.*)'")]
        public void ThenIShouldDisplayWithHazmatPackingGroupWithDropdownValues(string groups)
        {
            Report.WriteLine("Verifying the options present under view dropdown");
            string[] values = groups.Split(',');
            Click(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Hazmatpackagegroup_0_chosen']/div/ul/li"));
            List<string> ExpectedVal = new List<string>();

            foreach (var v in values)
            {
                ExpectedVal.Add(v);
            }

            Assert.AreEqual(ExpectedVal.Count, UIValues.Count);
            for (int i = 0; i < UIValues.Count; i++)
            {
                if (ExpectedVal.Contains(UIValues[i].Text))
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under view dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under view dropdown is not expected");
                    Assert.IsTrue(false);
                }
            }
        }

        [Then(@"I should be displayed with hazmat class dropdownvalues '(.*)'")]
        public void ThenIShouldBeDisplayedWithHazmatClassDropdownvalues(string classvalues)
        {
            Report.WriteLine("Verifying the options present under view dropdown");
            string[] values = classvalues.Split(',');
            Click(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath);
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='HazmatClass_0_chosen']/div/ul/li"));
            List<string> ExpectedVal = new List<string>();

            foreach (var v in values)
            {
                ExpectedVal.Add(v);
            }

            Assert.AreEqual(ExpectedVal.Count, UIValues.Count);
            for (int i = 0; i < UIValues.Count; i++)
            {
                if (ExpectedVal.Contains(UIValues[i].Text))
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under view dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under view dropdown is not expected");
                    Assert.IsTrue(false);
                }
            }
        }


        [Then(@"I should be display with hazmat class,emergency response name,emergency response phone")]
        public void ThenIShouldBeDisplayWithHazmatClassEmergencyResponseNameEmergencyResponsePhone()
        {
            Report.WriteLine("DisplayWithHazmatClassEmergencyResponseNameEmergencyResponsePhone");
            VerifyElementVisible(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath, "HazmatClass");
            VerifyElementVisible(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "EmergencyResponseName");
            VerifyElementVisible(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "EmergencyResponsePhone");
        }

        [Then(@"I can able to enter only numeric, min and max length four in  UN Number '(.*)'")]
        public void ThenICanAbleToEnterOnlyNumericMinAndMaxLengthFourInUNNumber(string UNNumber)
        {
            Report.WriteLine("ICanAbleToEnterOnlyNumericMinAndMaxLengthFourInUNNumber");
            //verification for max length
            SendKeys(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, UNNumber);
            Thread.Sleep(500);
            string uivalue = GetAttribute(attributeName_id, FreightDesp_FirstItem_UN_Number_Id,"value");
            string expected = UNNumber.Substring(0, 4);
            Assert.AreEqual(uivalue, expected);
            //verification for only numeric
            Clear(attributeName_id, FreightDesp_FirstItem_UN_Number_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "abcd@@");
            Thread.Sleep(500);
            string uivalue1 = GetAttribute(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "value");
            Assert.AreEqual(uivalue1, "");
            //verification for max length
            Clear(attributeName_id, FreightDesp_FirstItem_UN_Number_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "11");
            Thread.Sleep(500);
            Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);
            var coloroftheUN = GetCSSValue(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "background");
           // Assert.AreEqual("rgba(251, 236, 236, 1)", coloroftheUN);
           if(coloroftheUN.Contains("linear-gradient(rgb(251, 236, 236)"))
             {
                Report.WriteLine("UN number should be maximum four digits");

             }
           else
            {
                throw new Exception("failed_UN number is allowing less than four digits");


            }



        }


        [Then(@"I can able to enter only numerics in CCN number '(.*)'")]
        public void ThenICanAbleToEnterOnlyNumericsInCCNNumber(string CCNnumber)
        {
            Report.WriteLine("ICanAbleToEnterOnlynumerics in CCN number");
            SendKeys(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, CCNnumber);
            Thread.Sleep(500);
            string uivalue = GetAttribute(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id,"value");
            //bool containsInt = uivalue.Any(char.IsDigit);
            Assert.IsTrue(uivalue.Any(char.IsDigit));
            //Assert.AreEqual(containsInt.ToString(), "true");


        }
        
        [Then(@"I can able to enter only text in emergency response name '(.*)'")]
        public void ThenICanAbleToEnterOnlyTextInEmergencyResponseName(string emergencyresponsename)
        {
            Report.WriteLine("ICanAbleToEnterOnlynumerics in CCN number");
            SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "contact");
            Thread.Sleep(500);
            string uivalue = GetAttribute(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id,"value");
            Assert.IsTrue(uivalue.Any(char.IsLetter));
            Clear(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "111");
            Thread.Sleep(500);
            string uivalue1 = GetAttribute(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "value");
            Assert.AreEqual(uivalue1, "");

        }

        [Then(@"I can able to enter only phonenumberformat (.*)")]
        public void ThenICanAbleToEnterOnlyPhonenumberformat(string phonenumber)
        {
            Report.WriteLine("ICanAbleToEnterPhonenumberformat");
            SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, phonenumber);
            Thread.Sleep(500);
            string uivalue = GetAttribute(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id,"value");
            string expected = phonenumber.Substring(0, 10);
            //lengthcheck
            Assert.AreEqual(uivalue.Length-4, expected.Length);
            //phone number format check
            string expected1 = "(123) 456-7890";
            Assert.AreEqual(uivalue, expected1);
            //verification for only numeric
            Clear(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "abcd@@");
            Thread.Sleep(500);
            string uivalue1 = GetAttribute(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "value");
            Assert.AreEqual(uivalue1, "");


        }




        [Then(@"UN Number and CCN number,hazmat packing group,hazmat class,emergencyresponsename, emergencyresponsephone fields should highlight")]
        public void ThenUNNumberAndCCNNumberHazmatPackingGroupHazmatClassEmergencyresponsenameEmergencyresponsephoneFieldsShouldHighlight()
        {
            Report.WriteLine("All the Required fields should be highlight in the pink color");
            var coloroftheUN = GetCSSValue(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "background");
            var coloroftheCCN = GetCSSValue(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "background");
            var colorofthehazclass = GetCSSValue(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath, "background");
            var colorofthehazgroup = GetCSSValue(attributeName_xpath, ".//*[@id='Hazmatpackagegroup_0_chosen']/a", "background");
            var colorofthecontactfield = GetCSSValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "background");
            var colorofthephonenumfield = GetCSSValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "background");
            if (coloroftheUN.Contains("linear-gradient(rgb(251, 236, 236)") && coloroftheCCN.Contains("linear-gradient(rgb(251, 236, 236)") && colorofthehazclass.Contains("linear-gradient(rgb(251, 236, 236)") && colorofthehazgroup.Contains("linear-gradient(rgb(251, 236, 236)") && colorofthecontactfield.Contains("linear-gradient(rgb(251, 236, 236)") && colorofthephonenumfield.Contains("linear-gradient(rgb(251, 236, 236)"))
            {
                Report.WriteLine("UNNumberAndCCNNumberHazmatPackingGroupHazmatClassEmergencyresponsenameEmergencyresponsephoneFieldsShouldHighlight");

            }

            else
            {
                throw new Exception("failed the validation");


            }



        }
    }
}
