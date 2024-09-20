using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class LiabilityCoverage_RateRequest_DisplayLiabilityCostPerPoundSteps :ObjectRepository
    {
        [Then(@"I should displayed with Cost per PoundNew and Cost per PoundUsed fields above Max Liability field")]
        public void ThenIShouldDisplayedWithCostPerPoundNewAndCostPerPoundUsedFieldsAboveMaxLiabilityField()
        {
            Report.WriteLine("User displaying with Cost per pound New and Cost per pound Used fields above Max Liability field");
            VerifyElementPresent(attributeName_xpath, LiabilityCostperPound, "Liability Cost per Pound");
            VerifyElementPresent(attributeName_xpath, LiabilityCostperPoundnewused, "New and used");            
        }

        [Then(@"the verbiage Carrier’s Legal Liability per Pound without Insurance and Carrier’s Max Liability if Shipment is Not Insured fields should be displayed for carrier")]
        public void ThenTheVerbiageCarrierSLegalLiabilityPerPoundWithoutInsuranceAndCarrierSMaxLiabilityIfShipmentIsNotInsuredFieldsShouldBeDisplayedForCarrier()
        {
            IList<IWebElement> data = GlobalVariables.webDriver.FindElements(By.XPath(LiabilityCostperPound));
            for (int i = 0; i < data.Count; i++)
            {
                string expText = data[i].Text;
                {
                    if (expText == "Carrier’s Legal Liability per Pound without Insurance")
                    {
                        Report.WriteLine("Verbiage Carrier’s Legal Liability per Pound without Insurance is displaying");
                    }
                    else
                    {
                        Report.WriteFailure("Verbiage is not matching with expected value");
                        Assert.IsTrue(false);
                    }
                }
            }
            IList<IWebElement> datav = GlobalVariables.webDriver.FindElements(By.XPath(MaxLiabilityVerbiage));
            for (int i = 0; i < datav.Count; i++)
            {
                string expText = datav[i].Text;
                {
                    if (expText == "Carrier’s Max Liability if Shipment is Not Insured")
                    {
                        Report.WriteLine("Verbiage Carrier’s Max Liability if Shipment is Not Insured is displaying");
                    }
                    else
                    {
                        Report.WriteFailure("Verbiage is not matching with expected value");
                        Assert.IsTrue(false);
                    }
                }
            }
        }

        [Then(@"the verbiage Carrier’s Legal Liability per Pound without Insurance and Carrier’s Max Liability if Shipment is Not Insured fields should be displayed for guaranteed carrier")]
        public void ThenTheVerbiageCarrierSLegalLiabilityPerPoundWithoutInsuranceAndCarrierSMaxLiabilityIfShipmentIsNotInsuredFieldsShouldBeDisplayedForGuaranteedCarrier()
        {
            IList<IWebElement> data = GlobalVariables.webDriver.FindElements(By.XPath(LiabilityCostperPound_G));
            for (int i = 0; i < data.Count; i++)
            {
                string expText = data[i].Text;
                {
                    if (expText == "Carrier’s Legal Liability per Pound without Insurance")
                    {
                        Report.WriteLine("Verbiage Carrier’s Legal Liability per Pound without Insurance is displaying");
                    }
                    else
                    {
                        Report.WriteFailure("Verbiage is not matching with expected value");
                        Assert.IsTrue(false);
                    }
                }
            }
            IList<IWebElement> datav = GlobalVariables.webDriver.FindElements(By.XPath(MaxLiabilityVerbiage_G));
            for (int i = 0; i < datav.Count; i++)
            {
                string expText = datav[i].Text;
                {
                    if (expText == "Carrier’s Max Liability if Shipment is Not Insured")
                    {
                        Report.WriteLine("Verbiage Carrier’s Max Liability if Shipment is Not Insured is displaying");
                    }
                    else
                    {
                        Report.WriteFailure("Verbiage is not matching with expected value");
                        Assert.IsTrue(false);
                    }
                }
            }
        }

        [Then(@"I should displayed with Cost per PoundNew and Cost per PoundUsed fields with prefix of dollar")]
        public void ThenIShouldDisplayedWithCostPerPoundNewAndCostPerPoundUsedFieldsWithPrefixOfDollar()
        {
            Report.WriteLine("User displaying with Cost per Pound New and used fields with prefix dollar");
            IList<IWebElement> LiabilityNewlist = GlobalVariables.webDriver.FindElements(By.XPath(LiabilityCostperPoundnewused));
            if (LiabilityNewlist.Count > 0)
            {
                List<string> LiabilityNewlist1 = new List<string>();
                foreach (IWebElement element in LiabilityNewlist)
                {
                    LiabilityNewlist1.Add((element.Text).ToString());
                }
                int size1 = LiabilityNewlist1.Count;
                for (int i = 0; i < size1; i++)
                {
                    string[] a = LiabilityNewlist1[i].Split(new char[] { ' ' });
                    Report.WriteLine("User displaying with Cost per pound new field with prefix dollar");
                    string dollarnew = a[1];
                    string dollarexpnew = "$";
                    Assert.AreEqual(dollarnew, dollarexpnew);
                    Report.WriteLine("User displaying with Cost per pound Used field with prefix dollar");
                    string dollarused = a[5];
                    string dollarexpused = "$";
                    Assert.AreEqual(dollarused, dollarexpused);
                }
            }            
        }        
               
        [Then(@"I should displayed with Cost per PoundNew field with prefix of dollar")]
        public void ThenIShouldDisplayedWithCostPerPoundNewFieldWithPrefixOfDollar()
        {
            Report.WriteLine("User displaying with Cost per pound New with prefix dollar");
            IList<IWebElement> LiabilityNewlist = GlobalVariables.webDriver.FindElements(By.XPath(LiabilityCostperPoundnewused));
            if (LiabilityNewlist.Count > 0)
            {
                List<string> LiabilityNewlist1 = new List<string>();
                foreach (IWebElement element in LiabilityNewlist)
                {
                    LiabilityNewlist1.Add((element.Text).ToString());
                }
                int size1 = LiabilityNewlist1.Count;
                for (int i = 0; i < size1; i++)
                {
                    string[] a = LiabilityNewlist1[i].Split(new char[] { ' ' });
                    string dollar = a[1];
                    string dollarexp = "$";
                    Assert.AreEqual(dollar, dollarexp);
                }
            }
        }

        [Then(@"I should displayed with Cost per PoundUsed field with prefix of dollar")]
        public void ThenIShouldDisplayedWithCostPerPoundUsedFieldWithPrefixOfDollar()
        {
            Report.WriteLine("User displaying with Cost per pound Used with prefix dollar");
            IList<IWebElement> LiabilityUsedlist = GlobalVariables.webDriver.FindElements(By.XPath(LiabilityCostperPoundnewused));
            if (LiabilityUsedlist.Count > 0)
            {
                List<string> LiabilityUsedlist1 = new List<string>();
                foreach (IWebElement element in LiabilityUsedlist)
                {
                    LiabilityUsedlist1.Add((element.Text).ToString());
                }
                int size1 = LiabilityUsedlist1.Count;
                for (int i = 0; i < size1; i++)
                {
                    string[] a = LiabilityUsedlist1[i].Split(new char[] { ' ' });
                    string dollar = a[1];
                    string dollarexp = "$";
                    Assert.AreEqual(dollar, dollarexp);
                }
            }
        }

        [Then(@"I should displayed with Cost per PoundNew and Cost per PoundUsed field values should match with the DB for Nonguaranteed grid")]
        public void ThenIShouldDisplayedWithCostPerPoundNewAndCostPerPoundUsedFieldValuesShouldMatchWithTheDBForNonguaranteedGrid()
        {
            Report.WriteLine("Displaying Cost per pound New field values matching with DB for Nonguaranteed grid");
            IList<IWebElement> LiabilityCostNewused = GlobalVariables.webDriver.FindElements(By.XPath(LiabilityCostperPoundnewused));

            if (LiabilityCostNewused.Count > 0)
            {
                List<string> LiabilityCostNew = new List<string>();
                foreach (IWebElement element in LiabilityCostNewused)
                {
                    LiabilityCostNew.Add((element.Text).ToString());
                }
                IList<IWebElement> carrierslist = GlobalVariables.webDriver.FindElements(By.XPath(ltlcarriersall_xpath));

                for (int i = 1; i < carrierslist.Count; i++)
                {
                    InsuredRateCarrier value = DBHelper.GetnewCostperPound(carrierslist[i - 1].Text);

                    if (value != null)
                    {
                        string ActNewValue = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[" + i + "]/td[1]/ul/li[2]/div")).Text;
                        string[] a = ActNewValue.Split(new char[] { ' ' });
                        string actvalueNewValue = a[2];
                        string expectedNewValue = value.CostPerPoundNew;
                        Assert.AreEqual(expectedNewValue, actvalueNewValue);
                        string expectedUsedValue = value.CostPerPoundUsed_;
                        string[] a1 = ActNewValue.Split(new char[] { ' ' });
                        string actualUsedValue = a1[6];
                        Assert.AreEqual(expectedUsedValue, actualUsedValue);
                    }
                }
            }
        }
        [Then(@"I should displayed with Cost per PoundNew and Cost per PoundUsed field values should match with the DB for guaranteed grid")]
        public void ThenIShouldDisplayedWithCostPerPoundNewAndCostPerPoundUsedFieldValuesShouldMatchWithTheDBForGuaranteedGrid()
        {
            Report.WriteLine("Displaying Cost per pound New and Cost per pound Used field values matching with DB for guaranteed grid");

            IList<IWebElement> LiabilityCostNewused = GlobalVariables.webDriver.FindElements(By.XPath(LiabilityCostperPoundnewused_G));

            if (LiabilityCostNewused.Count > 0)
            {
                List<string> LiabilityCostNew = new List<string>();
                foreach (IWebElement element in LiabilityCostNewused)
                {
                    LiabilityCostNew.Add((element.Text).ToString());
                }
                IList<IWebElement> carrierslist = GlobalVariables.webDriver.FindElements(By.XPath(ltlcarriersall_G_xpath));

                for (int i = 1; i < carrierslist.Count; i++)
                {
                    InsuredRateCarrier value = DBHelper.GetnewCostperPound(carrierslist[i - 1].Text);

                    if (value != null)
                    {
                        string ActNewValue = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[" + i + "]/td[1]/ul/li[2]/div")).Text;
                        string[] a = ActNewValue.Split(new char[] { ' ' });
                        string actvalueNewValue = a[2];
                        string expectedNewValue = value.CostPerPoundNew;
                        Assert.AreEqual(expectedNewValue, actvalueNewValue);
                        string expectedUsedValue = value.CostPerPoundUsed_;
                        string[] a1 = ActNewValue.Split(new char[] { ' ' });
                        string actualUsedValue = a1[6];
                        Assert.AreEqual(expectedUsedValue, actualUsedValue);
                    }
                }
            }
        }
        
        [Then(@"I should displayed with Cost per PoundNew and Cost per PoundUsed fields above Max Liability field for guaranteed")]
        public void ThenIShouldDisplayedWithCostPerPoundNewAndCostPerPoundUsedFieldsAboveMaxLiabilityFieldForGuaranteed()
        {
            Report.WriteLine("User displaying with Cost per pound New and Cost per pound Used fields above Max Liability field");
            VerifyElementPresent(attributeName_xpath, LiabilityCostperPound_G, "Liability Cost Per Pound");
            VerifyElementPresent(attributeName_xpath, LiabilityCostperPoundnewused_G, "New and used");
        }

        [Then(@"I should displayed with Cost per PoundNew and Cost per PoundUsed fields with prefix of dollar for guaranteed")]
        public void ThenIShouldDisplayedWithCostPerPoundNewAndCostPerPoundUsedFieldsWithPrefixOfDollarForGuaranteed()
        {
            Report.WriteLine("User displaying with Cost per Pound New and used fields with prefix dollar for guaranteed");
            IList<IWebElement> LiabilityNewlist = GlobalVariables.webDriver.FindElements(By.XPath(LiabilityCostperPoundnewused_G));
            if (LiabilityNewlist.Count > 0)
            {
                List<string> LiabilityNewlist1 = new List<string>();
                foreach (IWebElement element in LiabilityNewlist)
                {
                    LiabilityNewlist1.Add((element.Text).ToString());
                }
                int size1 = LiabilityNewlist1.Count;
                for (int i = 0; i < size1; i++)
                {
                    string[] a = LiabilityNewlist1[i].Split(new char[] { ' ' });
                    Report.WriteLine("User displaying with Cost per pound new field with prefix dollar for guaranteed");
                    string dollarnew = a[1];
                    string dollarexpnew = "$";
                    Assert.AreEqual(dollarnew, dollarexpnew);
                    Report.WriteLine("User displaying with Cost per pound Used field with prefix dollar for guaranteed");
                    string dollarused = a[5];
                    string dollarexpused = "$";
                    Assert.AreEqual(dollarused, dollarexpused);
                }
            }
        }
    }
}
