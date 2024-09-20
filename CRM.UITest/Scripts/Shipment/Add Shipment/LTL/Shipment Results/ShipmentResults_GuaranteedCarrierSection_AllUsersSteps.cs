using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public  class ShipmentResults_GuaranteedCarrierSection_AllUsersSteps : AddShipments
    {
        public string NcarrierName;
        [Then(@"I will see the Guaranteed rates section bottom of the shipment result LTL page")]
        public void ThenIWillSeeTheGuaranteedRatesSectionBottomOfTheShipmentResultLTLPage()
        {           

            Report.WriteLine("I should see the Guranteed Rate Section");
            scrollElementIntoView(attributeName_xpath, ShipResults_GuaranteedColumnHeader_CARRIER_Xpath);
            VerifyElementPresent(attributeName_xpath, ShipResults_GuaranteedColumnHeader_CARRIER_Xpath, "CARRIER");

        }

      
        [Then(@"Verified that Guaranteed and non Guaranteed rate section will have the same columns and functionality for (.*)")]
        public void ThenVerifiedThatGuaranteedAndNonGuaranteedRateSectionWillHaveTheSameColumnsAndFunctionalityFor(string Usertype)
        {

            if (Usertype == "Internal")
            {
                Report.WriteLine("All column header are same for Non Guaranteed and Guaranteed section");
                string NonGuaranteed_Carrier = Gettext(attributeName_xpath, ShipResults_CarrierColumn_Xpath);
                string NonGuaranteed_ServiceDays = Gettext(attributeName_xpath, ShipResults_ServiceDaysColumn_Xpath);
                string NonGuaranteed_Distance = Gettext(attributeName_xpath, ShipResults_DistanceColumn_Xpath);
                string NonGuaranteed_EstCost = Gettext(attributeName_xpath, ShipResults_EstCostColumn_Xpath);
                string NonGuaranteed_Rate = Gettext(attributeName_xpath, ShipResults_RateColumn_Xpath);

                scrollElementIntoView(attributeName_xpath, ShipResults_GuaranteedColumnHeader_CARRIER_Xpath);

                string Guaranteed_Carrier = Gettext(attributeName_xpath, ShipResults_GuaranteedColumnHeader_CARRIER_Xpath);
                string Guaranteed_ServiceDays = Gettext(attributeName_xpath, ShipResults_GuaranteedColumnHeader_SERVICEDAYS_Xpath);
                string Guaranteed_Distance = Gettext(attributeName_xpath, ShipResults_GuaranteedColumnHeader_DISTANCE_Xpath);
                string Guaranteed_EstCost = Gettext(attributeName_xpath, ShipResults_GuaranteedColumnHeader_ESTCOST_Xpath);
                string Guaranteed_Rate = Gettext(attributeName_xpath, ShipResults_GuaranteedColumnHeader_RATE_Xpath);

                Assert.AreEqual(NonGuaranteed_Carrier, Guaranteed_Carrier);
                Assert.AreEqual(NonGuaranteed_ServiceDays, Guaranteed_ServiceDays);
                Assert.AreEqual(NonGuaranteed_Distance, Guaranteed_Distance);
                Assert.AreEqual(NonGuaranteed_EstCost, Guaranteed_EstCost);
                Assert.AreEqual(NonGuaranteed_Rate, Guaranteed_Rate);
            }
            else
            {
                Report.WriteLine("All column header are same for Non Guaranteed and Guaranteed section");
                string NonGuaranteed_Carrier = Gettext(attributeName_xpath, ShipResults_CarrierColumn_Xpath);
                string NonGuaranteed_ServiceDays = Gettext(attributeName_xpath, ShipResults_ServiceDaysColumn_Xpath);
                string NonGuaranteed_Distance = Gettext(attributeName_xpath, ShipResults_DistanceColumn_Xpath);
                string NonGuaranteed_Rate = Gettext(attributeName_xpath, ShipResults_External_RateColumn_Xpath);

                scrollElementIntoView(attributeName_xpath, ShipResults_GuaranteedColumnHeader_CARRIER_Xpath);

                string Guaranteed_Carrier = Gettext(attributeName_xpath, ShipResults_GuaranteedColumnHeader_CARRIER_Xpath);
                string Guaranteed_ServiceDays = Gettext(attributeName_xpath, ShipResults_GuaranteedColumnHeader_SERVICEDAYS_Xpath);
                string Guaranteed_Distance = Gettext(attributeName_xpath, ShipResults_GuaranteedColumnHeader_DISTANCE_Xpath);
                string Guaranteed_Rate = Gettext(attributeName_xpath, ShipResults_External_GuaranteedColumnHeader_RATE_Xpath);

                Assert.AreEqual(NonGuaranteed_Carrier, Guaranteed_Carrier);
                Assert.AreEqual(NonGuaranteed_ServiceDays, Guaranteed_ServiceDays);
                Assert.AreEqual(NonGuaranteed_Distance, Guaranteed_Distance);
                Assert.AreEqual(NonGuaranteed_Rate, Guaranteed_Rate);
            }

        }


        [Then(@"Verify the Guaranteed section have GUARANTEED RATE below the carrier name")]
        public void ThenVerifyTheGuaranteedSectionHaveGUARANTEEDRATEBelowTheCarrierName()
        {
            scrollElementIntoView(attributeName_xpath, ShipResults_GuaranteedColumnHeader_CARRIER_Xpath);
            int carrierrowcount = GetCount(attributeName_xpath, ShipResults_FC_GuaranteedCarrierName_Xpath);
            if (carrierrowcount > 1)
            {
                Report.WriteLine("I will see the Guaranteed Rate label in guranteed rate section");              
                VerifyElementPresent(attributeName_xpath, ShipResults_GuaranteedRate_Label_Xpath, "GUARANTEED RATE");
            }
            else
            {
                Report.WriteLine("No Carrier is Available in Guaranteed rate section");
            }
        

        }


        [Then(@"I will see a Guaranteed Rate Available button for any offered Guaranteed rate carrier in the Guaranteed carrier section")]
        public void ThenIWillSeeAGuaranteedRateAvailableButtonForAnyOfferedGuaranteedRateCarrierInTheGuaranteedCarrierSection()
        {
            Report.WriteLine("Any carrier displayed the Guaranteed rate");
            IList<IWebElement> GetAllCarrierName = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[1]"));
            int CarrierName = GetAllCarrierName.Count;
            String NcarrierName = CarrierName.ToString();

            String CarrierNametext = Gettext(attributeName_xpath, ShipResults_FC_GuaranteedCarrierName_Xpath);

            List<string> GetCarrierDB = DBHelper.GetGuranteedCarrierName();
            int GetCarrierName = GetCarrierDB.Count();

            for (int i = 0; i < CarrierName; i++)
            {


                string GCarrierName = GetCarrierDB[0];
                for (int j = 0; j < GetCarrierName; j++)
                {
                    if (GetAllCarrierName[i].Text == GetCarrierDB[j])
                    {

                        Report.WriteLine("I will see the Guaranteed Rate Available Button");
                        scrollElementIntoView(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[1]");

                         
                        VerifyElementPresent(attributeName_id, ShipResults_GuaranteedRateAvailableButton_Id, "GUARANTEED RATE AVAILABLE");

                        

                        scrollElementIntoView(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[1]");
                        VerifyElementPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]//*[text()='Guaranteed Rate Available']", "Guaranteed Rate Available");
                       


                    }
                    else
                    {
                        Report.WriteLine("Carrier don't have Guaranteed rates");

                    }
                }




            }
        }

        [When(@"I click on Guaranteed Rate Available button of any offered Guaranteed rate carrier")]
        public void WhenIClickOnGuaranteedRateAvailableButtonOfAnyOfferedGuaranteedRateCarrier()
        {
          
                Report.WriteLine("Any carrier displayed the Guaranteed rate");
                IList<IWebElement> GetAllCarrierName = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr/td[1]/div/div[1]"));
                int CarrierName = GetAllCarrierName.Count;
                String NcarrierName = CarrierName.ToString();

                String CarrierNametext = Gettext(attributeName_xpath, ShipResults_FC_GuaranteedCarrierName_Xpath);

                List<string> GetCarrierDB = DBHelper.GetGuranteedCarrierName();
                int GetCarrierName = GetCarrierDB.Count();

                for (int i = 0; i < CarrierName; i++)
                {


                    string GCarrierName = GetCarrierDB[0];
                    for (int j = 0; j < GetCarrierName; j++)
                    {
                        if (GetAllCarrierName[i].Text == GetCarrierDB[j])
                        {

                            Report.WriteLine("I will see the Guaranteed Rate Available Button");
                            VerifyElementPresent(attributeName_id, ShipResults_GuaranteedRateAvailableButton_Id, "GUARANTEED RATE AVAILABLE");

                            Report.WriteLine("I click on Guaranteed Rate Available button");
                           

                            scrollElementIntoView(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[1]");
                       
                            Click(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]//*[text()='Guaranteed Rate Available']");
                       

                    }
                        else
                        {
                            Report.WriteLine("Carrier don't have Guaranteed rates");

                        }
                    }




                }
                
            
        }
        [Then(@"The page will focus to the Guaranteed carrier section")]
        public void ThenThePageWillFocusToTheGuaranteedCarrierSection()
        {
            
            Report.WriteLine("Page will focus to the Guaranteed Rate Section");
            VerifyElementPresent(attributeName_xpath, ShipResults_GuaranteedColumnHeader_CARRIER_Xpath, "Guaranteed Rate Section");

            IList<IWebElement> GetAllCarrierName = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='GuaranteedResultTable']/tbody/tr/td[1]/div/div[1]"));
            int GCarrierName = GetAllCarrierName.Count;
            string some = GetAllCarrierName.ToString();
            bool GCarrier = some.Contains(NcarrierName);


        }

        [When(@"I scroll the page for Guaranteed rate section")]
        public void WhenIScrollThePageForGuaranteedRateSection()
        {
            Report.WriteLine("Scroll page for the Guaranteed Rate Section");
            scrollElementIntoView(attributeName_xpath, ShipResults_GuaranteedColumnHeader_CARRIER_Xpath);
        }

        [Then(@"I should be able to sort Carrier Column in ascending and descending order for Guaranteed section")]
        public void ThenIShouldBeAbleToSortCarrierColumnInAscendingAndDescendingOrderForGuaranteedSection()
        {
            List<string> ascSort = new List<string>();
            List<string> desSort = new List<string>();
            Report.WriteLine("Clicking on sorting icon");
            Click(attributeName_xpath, ShipResults_GuaranteedColumnHeader_CARRIER_Xpath);

            Report.WriteLine("Reading the values from the carrier name columns after ascdending sorting");
            IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_CarrierColumnValues_Xpath));
            foreach (IWebElement element in totalcarriers)
            {
                ascSort.Add(element.Text.ToString());
            }

            Click(attributeName_xpath, ShipResults_GuaranteedColumnHeader_CARRIER_Xpath);
            Report.WriteLine("Reading the values from the carrier name columns after descending sorting");
            IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_CarrierColumnValues_Xpath));
            foreach (IWebElement element in sortedvalues)
            {
                desSort.Add(element.Text.ToString());
            }
            desSort.Sort();
            Report.WriteLine("Comparing the values after sorting");
            for (int i = 0; i < sortedvalues.Count; i++)
            {
                if (ascSort[i] == desSort[i])
                {
                    Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                }
                else
                {
                    Report.WriteFailure("Sorting is not as expected");
                }
            }
        }

        [Then(@"I should be able to sort Service days Column in ascending and descending order for Guaranteed section")]
        public void ThenIShouldBeAbleToSortServiceDaysColumnInAscendingAndDescendingOrderForGuaranteedSection()
        {
            List<int> ascSort = new List<int>();
            List<int> desSort = new List<int>();
            Report.WriteLine("Clicking on sorting icon");
            Click(attributeName_xpath, ShipResults_GuaranteedColumnHeader_SERVICEDAYS_Xpath);

            Report.WriteLine("Reading the values from the service days columns after ascdending sorting");
            IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_ServicedaysColumnValues_Xpath));
            foreach (IWebElement element in totalcarriers)
            {
                int value = Convert.ToInt32(element.Text);
                ascSort.Add(value);
            }

            Click(attributeName_xpath, ShipResults_GuaranteedColumnHeader_SERVICEDAYS_Xpath);
            Report.WriteLine("Reading the values from the service days columns after descending sorting");
            IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_ServicedaysColumnValues_Xpath));
            foreach (IWebElement element in sortedvalues)
            {
                int value = Convert.ToInt32(element.Text);
                desSort.Add(value);
            }
            desSort.Sort();
            Report.WriteLine("Comparing the values after sorting");
            for (int i = 0; i < sortedvalues.Count; i++)
            {
                if (ascSort[i] == desSort[i])
                {
                    Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                }
                else
                {
                    Report.WriteFailure("Sorting is not as expected");
                }
            }
        }

        [Then(@"I should be able to sort Distance Column in ascending and descending order for Guaranteed section")]
        public void ThenIShouldBeAbleToSortDistanceColumnInAscendingAndDescendingOrderForGuaranteedSection()
        {
            List<decimal> ascSort = new List<decimal>();
            List<decimal> desSort = new List<decimal>();
            Report.WriteLine("Clicking on sorting icon");
            Click(attributeName_xpath, ShipResults_GuaranteedColumnHeader_DISTANCE_Xpath);

            Report.WriteLine("Reading the values from the distance columns after ascdending sorting");
            IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_DistanceColumnValues_Xpath));
            foreach (IWebElement element in totalcarriers)
            {
                string[] values = element.Text.Split(' ');
                decimal value = Convert.ToDecimal(values[0]);
                ascSort.Add(value);
            }
            Click(attributeName_xpath, ShipResults_GuaranteedColumnHeader_DISTANCE_Xpath);
            Report.WriteLine("Reading the values from the distance columns after descending sorting");
            IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_DistanceColumnValues_Xpath));
            foreach (IWebElement element in sortedvalues)
            {
                string[] values = element.Text.Split(' ');
                decimal value = Convert.ToDecimal(values[0]);
                desSort.Add(value);
            }
            desSort.Sort();
            Report.WriteLine("Comparing the values after sorting");
            for (int i = 0; i < sortedvalues.Count; i++)
            {
                if (ascSort[i] == desSort[i])
                {
                    Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                }
                else
                {
                    Report.WriteFailure("Sorting is not as expected");
                }
            }
        }

   


        [Then(@"I should be able to sort EST COST Column in ascending and descending order for Guaranteed section (.*)")]
        public void ThenIShouldBeAbleToSortESTCOSTColumnInAscendingAndDescendingOrderForGuaranteedSection(string Usertype)
        {
            if (Usertype == "Internal")
            {
                List<decimal> ascSort = new List<decimal>();
                List<decimal> desSort = new List<decimal>();
                Report.WriteLine("Clicking on sorting icon");
                Click(attributeName_xpath, ShipResults_GuaranteedColumnHeader_ESTCOST_Xpath);

                Report.WriteLine("Reading the values from the est cost columns after ascdending sorting");
                IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_Internal_EstColumnValues_Xpath));
                foreach (IWebElement element in totalcarriers)
                {
                    decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                    ascSort.Add(value);
                }
                Click(attributeName_xpath, ShipResults_GuaranteedColumnHeader_ESTCOST_Xpath);
                Report.WriteLine("Reading the values from the est cost columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_Internal_EstColumnValues_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                    desSort.Add(value);
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No column for External");
            }
        }


        [Then(@"I should be able to sort Rate Column in ascending and descending order for Guaranteed section (.*)")]
        public void ThenIShouldBeAbleToSortRateColumnInAscendingAndDescendingOrderForGuaranteedSection(string Usertype)
        {
            if(Usertype == "Internal")
            {
                List<decimal> ascSort = new List<decimal>();
                List<decimal> desSort = new List<decimal>();
                Report.WriteLine("Clicking on sorting icon");
                Click(attributeName_xpath, ShipResults_GuaranteedColumnHeader_RATE_Xpath);

                Report.WriteLine("Reading the values from the rate columns after ascdending sorting");
                IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_Internal_RateColumnValues_Xpath));
                foreach (IWebElement element in totalcarriers)
                {
                    decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                    ascSort.Add(value);
                }
                Click(attributeName_xpath, ShipResults_GuaranteedColumnHeader_RATE_Xpath);
                Report.WriteLine("Reading the values from the rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_Internal_RateColumnValues_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                    desSort.Add(value);
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                List<decimal> ascSort = new List<decimal>();
                List<decimal> desSort = new List<decimal>();
                Report.WriteLine("Clicking on sorting icon");
                Click(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/thead/tr/th[4]");

                Report.WriteLine("Reading the values from the rate columns after ascdending sorting");
                IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='GuaranteedResultTable']/tbody/tr/td[4]/div[1]"));
                foreach (IWebElement element in totalcarriers)
                {
                    decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                    ascSort.Add(value);
                }
                Click(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/thead/tr/th[4]");
                Report.WriteLine("Reading the values from the rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='GuaranteedResultTable']/tbody/tr/td[4]/div[1]"));
                foreach (IWebElement element in sortedvalues)
                {
                    decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                    desSort.Add(value);
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
        }



    }
}
