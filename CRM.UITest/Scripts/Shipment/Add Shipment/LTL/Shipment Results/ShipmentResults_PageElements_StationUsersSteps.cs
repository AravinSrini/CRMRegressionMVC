using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class ShipmentResults_PageElements_StationUsersSteps : AddShipments
    {
        [When(@"I enter (.*) (.*) (.*) in shipping from location info section present in add shipment page")]
        public void WhenIEnterInShippingFromLocationInfoSectionPresentInAddShipmentPage(string oZip, string oName, string oAdd)
        {
            Report.WriteLine("Passing data in shipping from section");
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, oZip);
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, oName);
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, oAdd);
        }

        [When(@"I enter (.*) (.*) (.*) in shipping to location info section present in add shipment page")]
        public void WhenIEnterInShippingToLocationInfoSectionPresentInAddShipmentPage(string dZip, string dName, string dAdd)
        {
            Report.WriteLine("Passing data in shipping to section");
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, dZip);
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, dName);
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, dAdd);
        }

        [When(@"I enter data in (.*),  (.*) , (.*),  (.*) and (.*) freight description present in add shipment page")]
        public void WhenIEnterDataInAndFreightDescriptionPresentInAddShipmentPage(string classification, string nmfc, string quantity, string desc, string weight)
        {
            Report.WriteLine("Passing data in freight description section");
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            //scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
            for(int i = 0; i < dropdownValues.Count; i++)
            {
                int z = i + 1;
                string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div["+ z + "]/p")).Text;
                if(value == classification)
                {
                    GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Click();
                    break;
                }
            }
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, nmfc);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, quantity);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, weight);
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, desc);
        }

        [When(@"I enter (.*) (.*) (.*) (.*) (.*) in freight description present in add shipment page")]
        public void WhenIEnterInFreightDescriptionPresentInAddShipmentPage(string classification, string nmfc, string quantity, string weight, string desc)
        {
            Report.WriteLine("Passing data in freight description section");
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_SavedClassItem_DropDown_Values_xpath, classification);
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, nmfc);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, quantity);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, weight);
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, desc);
        }
        
        [When(@"I enter data in (.*) text box in add shipment page")]
        public void WhenIEnterDataInTextBoxInAddShipmentPage(int insRate)
        {
            Report.WriteLine("Passing data in insured rate text box");
            MoveToElement(attributeName_id, InsuredValue_TextBox_Id);
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, insRate.ToString());
        }


        [When(@"I pass (.*) in shipment results page")]
        public void WhenIPassInShipmentResultsPage(string insRate)
        {
            Report.WriteLine("Passing data in insured rate text box");
            SendKeys(attributeName_id, ShipResults_InsuredRateTextbox_Id, insRate);
        }
        
        [When(@"I click on show insured rate button")]
        public void WhenIClickOnShowInsuredRateButton()
        {
            Report.WriteLine("Clicking on show insured rate button");
            Click(attributeName_id, ShipResults_ShowInsuredRateButton_Id);
        }
        
        [Then(@"the station name- customer name will be displayed in the Customer field (.*)")]
        public void ThenTheStationName_CustomerNameWillBeDisplayedInTheCustomerField(string stationName)
        {
            Report.WriteLine("Verifying the station name in results page");
            string actAccountName = GlobalVariables.webDriver.FindElement(By.Id(ShipResults_StationName_Id)).Text;
            bool value = actAccountName.Contains(stationName);
            Assert.AreEqual(value, "True");
        }
        
        [Then(@"station name - customer is not editable in results page (.*)")]
        public void ThenStationName_CustomerIsNotEditableInResultsPage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should see (.*) insured note, rate and value Type field")]
        public void ThenIShouldSeeInsuredNoteRateAndValueTypeField(string ExpText)
        {
            Report.WriteLine("Verifying insured rate section in shipment results page");
            VerifyElementPresent(attributeName_xpath, ShipResults_InsuredValueNote_Xpath, "Insured Value Note");
            Verifytext(attributeName_xpath, ShipResults_InsuredValueNote_Xpath, ExpText);
            VerifyElementPresent(attributeName_id, ShipResults_InsuredRateTextbox_Id, "Insure Rate Text Box");
            VerifyElementPresent(attributeName_id, ShipResults_InsuredValueDropdown_Id, "Insure type dropdown");
        }
        
        [Then(@"I should see filter carriers by options - Quickest Service and Least cost")]
        public void ThenIShouldSeeFilterCarriersByOptions_QuickestServiceAndLeastCost()
        {
            Report.WriteLine("Verifying filter carrier section page");
            VerifyElementPresent(attributeName_xpath, ShipResults_QuickestService_Xpath, "Quickest Service");
            VerifyElementPresent(attributeName_xpath, ShipResults_LeastCost_Xpath, "least cost");
        }
        
        [Then(@"Carrier, Service Days, Distance,Est Cost and Rate columns")]
        public void ThenCarrierServiceDaysDistanceEstCostAndRateColumns()
        {
            Report.WriteLine("Verifying displaying columns");
            Verifytext(attributeName_xpath, ShipResults_CarrierColumn_Xpath, "CARRIER");
            Verifytext(attributeName_xpath, ShipResults_ServiceDaysColumn_Xpath, "SERVICE DAYS");
            Verifytext(attributeName_xpath, ShipResults_DistanceColumn_Xpath, "DISTANCE");
            Verifytext(attributeName_xpath, ShipResults_EstCostColumn_Xpath, "EST COST");
            Verifytext(attributeName_xpath, ShipResults_RateColumn_Xpath, "RATE");
        }
        
        [Then(@"I should see insured rate column in shipment results page")]
        public void ThenIShouldSeeInsuredRateColumnInShipmentResultsPage()
        {
            WaitForElementVisible(attributeName_xpath, ShipResults_InsuredRateColumn_Xpath, "Insured Column");
            Report.WriteLine("Verifying displaying columns");
            Verifytext(attributeName_xpath, ShipResults_InsuredRateColumn_Xpath, "INSURED");
        }
        
        [Then(@"I should see Total, Fuel, Line Haul and Accessorials fields under rate columns")]
        public void ThenIShouldSeeTotalFuelLineHaulAndAccessorialsFieldsUnderRateColumns()
        {
            Report.WriteLine("Verify the fields under rate column");
            VerifyElementPresent(attributeName_xpath, ShipResults_FC_Fuel_Xpath, "Fuel");
            VerifyElementPresent(attributeName_xpath, ShipResults_FC_Linehaul_Xpath, "Line Hual");
            VerifyElementPresent(attributeName_xpath, ShipResults_FC_Accessories_Xpath, "Accessories");
        }
        
        [Then(@"estimate margin field under rate columns")]
        public void ThenEstimateMarginFieldUnderRateColumns()
        {
            Report.WriteLine("Verify the fields under rate column");
            Verifytext(attributeName_xpath, ShipResults_FC_EstimateMargin_Xpath, "Est Margin %");
        }
        
        [Then(@"I should see Show Insured Rate, Terms and Conditions, Create Shipment,Create Insured Shipment, Export, Guaranteed Rate Available and Back to Shipment List buttons in shipment results page")]
        public void ThenIShouldSeeShowInsuredRateTermsAndConditionsCreateShipmentCreateInsuredShipmentExportGuaranteedRateAvailableAndBackToShipmentListButtonsInShipmentResultsPage()
        {
            Report.WriteLine("Verify the terms and conditions");
            VerifyElementPresent(attributeName_xpath, ShipResults_TermsandConditions_Xpath, "Terms and Conditions");
            VerifyElementPresent(attributeName_id, ShipResults_ShowInsuredRateButton_Id, "Show Insured Rate");
            VerifyElementPresent(attributeName_xpath, ShipResults_ExportButton_Xpath, "Export");
            VerifyElementPresent(attributeName_id, ShipResults_BackToShipmentListButton_Id, "Back to Shipment List");
            VerifyElementPresent(attributeName_xpath, ShipResults_InternalFC_CreateShipment_Xpath, "Create Shipment");
            VerifyElementPresent(attributeName_xpath, ShipResults_FC_CreateInsuredShipment_Xpath, "Create Insured Shipment");
            VerifyElementPresent(attributeName_xpath, ShipResults_FC_GuaranteedRateAvailable_Xpath, "Guaranteed rate");
        }


        [Then(@"I should be able to sort Carrier column in ascending and descending order")]
        public void ThenIShouldBeAbleToSortCarrierColumnInAscendingAndDescendingOrder()
        {
            List<string> ascSort = new List<string>(); 
            List<string> desSort = new List<string>(); 
            Report.WriteLine("Clicking on sorting icon");
            Click(attributeName_xpath, ShipResults_CarrierColumn_Xpath);

            Report.WriteLine("Reading the values from the carrier name columns after ascdending sorting");
            IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_CarrierColumnValues_Xpath));
            foreach (IWebElement element in totalcarriers)
                {
                    ascSort.Add(element.Text.ToString());
                }

            Click(attributeName_xpath, ShipResults_CarrierColumn_Xpath);
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
                if(ascSort[i] == desSort[i])
                {
                    Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                }
                else
                {
                    Report.WriteFailure("Sorting is not as expected");
                }
            }
        }

        [Then(@"I should be able to sort service days column in ascending and descending order")]
        public void ThenIShouldBeAbleToSortServiceDaysColumnInAscendingAndDescendingOrder()
        {
            List<int> ascSort = new List<int>();
            List<int> desSort = new List<int>();
            Report.WriteLine("Clicking on sorting icon");
            Click(attributeName_xpath, ShipResults_ServiceDaysColumn_Xpath);

            Report.WriteLine("Reading the values from the service days columns after ascdending sorting");
            IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_ServicedaysColumnValues_Xpath));
            foreach (IWebElement element in totalcarriers)
            {
                int value = Convert.ToInt32(element.Text);
                ascSort.Add(value);
            }

            Click(attributeName_xpath, ShipResults_ServiceDaysColumn_Xpath);
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

        [Then(@"I should be able to sort distance column in ascending and descending order")]
        public void ThenIShouldBeAbleToSortDistanceColumnInAscendingAndDescendingOrder()
        {
            List<decimal> ascSort = new List<decimal>();
            List<decimal> desSort = new List<decimal>();
            Report.WriteLine("Clicking on sorting icon");
            Click(attributeName_xpath, ShipResults_DistanceColumn_Xpath);

            Report.WriteLine("Reading the values from the distance columns after ascdending sorting");
            IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_DistanceColumnValues_Xpath));
            foreach (IWebElement element in totalcarriers)
            {
                string[] values = element.Text.Split(' ');
                decimal value = Convert.ToDecimal(values[0]);
                ascSort.Add(value);
            }
            Click(attributeName_xpath, ShipResults_DistanceColumn_Xpath);
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

        [Then(@"I should be able to sort Est Cost column in ascending and descending order")]
        public void ThenIShouldBeAbleToSortEstCostColumnInAscendingAndDescendingOrder()
        {
            List<decimal> ascSort = new List<decimal>();
            List<decimal> desSort = new List<decimal>();
            Report.WriteLine("Clicking on sorting icon");
            Click(attributeName_xpath, ShipResults_EstCostColumn_Xpath);

            Report.WriteLine("Reading the values from the est cost columns after ascdending sorting");
            IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_Internal_EstColumnValues_Xpath));
            foreach (IWebElement element in totalcarriers)
            {
                decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                ascSort.Add(value);
            }
            Click(attributeName_xpath, ShipResults_EstCostColumn_Xpath);
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

        [Then(@"I should be able to sort rate columns in ascending and descending order")]
        public void ThenIShouldBeAbleToSortRateColumnsInAscendingAndDescendingOrder()
        {
            List<decimal> ascSort = new List<decimal>();
            List<decimal> desSort = new List<decimal>();
            Report.WriteLine("Clicking on sorting icon");
            Click(attributeName_xpath, ShipResults_RateColumn_Xpath);

            Report.WriteLine("Reading the values from the rate columns after ascdending sorting");
            IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_Internal_RateColumnValues_Xpath));
            foreach (IWebElement element in totalcarriers)
            {
                decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                ascSort.Add(value);
            }
            Click(attributeName_xpath, ShipResults_RateColumn_Xpath);
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

    }
}
