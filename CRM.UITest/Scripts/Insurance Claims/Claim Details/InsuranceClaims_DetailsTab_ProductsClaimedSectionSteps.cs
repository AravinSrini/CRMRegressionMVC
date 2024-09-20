using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_DetailsTab_ProductsClaimedSectionSteps : InsuranceClaim
    {
        [Given(@"I clicked any dlswclaim reference hyper link on the Claims List page")]
        public void GivenIClickedAnyDlswclaimReferenceHyperLinkOnTheClaimsListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List Text");
            string gridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (gridData == "No Results Found")
            {
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {
                SendKeys(attributeName_xpath, ClaimsListSearchField_xpath, "1123478912");
                Report.WriteLine("Clicking on the Claim Number on Claim List page");
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr/td[4]/span");
            }
            WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            WaitForElementVisible(attributeName_xpath, ClaimDetailsTabText_Xpath, "Details");
            Report.WriteLine("I am on the Details Tab of Claim Details Page");
        }

        [Then(@"I will see the Clm Typ,Art Typ,Qty,Item,Desc")]
        public void ThenIWillSeeTheClmTypArtTypQtyItemDesc()
        {
            Report.WriteLine("I will be displayed with the claim type, Articles Type, Quantity, Item, Description");
            scrollElementIntoView(attributeName_xpath, ProductsClaimed_Xpath);
            VerifyElementVisible(attributeName_xpath, ClmType_Header_Xpath, "ClmType");
            VerifyElementVisible(attributeName_xpath, ArtType_Header_Xpath, "ArtTyp");
            VerifyElementVisible(attributeName_xpath, Qty_Header_Xpath, "Qty");
            VerifyElementVisible(attributeName_xpath, Item_Header_Xpath, "Item");
            VerifyElementVisible(attributeName_xpath, Desc_Header_Xpath, "Desc");
        }

        [Then(@"I will see Unit wt,Ext Wt with comma when greater than (.*) digits, always display (.*) decimal places")]
        public void ThenIWillSeeUnitWtExtWtWithCommaWhenGreaterThanDigitsAlwaysDisplayDecimalPlaces(int p0, int p1)
        {
            Report.WriteLine("I will be displayed with the Unit Weight, Ext Weight with comma when more than three digits and with 2 decimal places");

            IList<IWebElement> unitWeight = GlobalVariables.webDriver.FindElements(By.XPath(UnitWgtValuesList_Xpath));
            List<string> listOfUnitWeightValuesFromUI = new List<string>();
            for (int i = 0; i < unitWeight.Count; i++)
            {
                int j = i + 1;
                string unitWt = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + j + "]/td[6]//input", "value");
                listOfUnitWeightValuesFromUI.Add(unitWt);
            }

            for (int k = 0; k < listOfUnitWeightValuesFromUI.Count; k++)
            {
                bool unitWeightValueFromUI = listOfUnitWeightValuesFromUI[k].Contains(".");
                Assert.IsTrue(unitWeightValueFromUI);
                string unitWeightValueWithDecimal = listOfUnitWeightValuesFromUI[k].Substring(listOfUnitWeightValuesFromUI[k].LastIndexOf('.') + 1);
                Assert.AreEqual(unitWeightValueWithDecimal.Length, 2);
                if (listOfUnitWeightValuesFromUI[k].Contains(","))
                {
                    Report.WriteLine("Unit Wt: " + listOfUnitWeightValuesFromUI[k] + "separated with comma and displayed with 2 decimals in Claim Details Page");
                }
                else
                {
                    Report.WriteLine("Unit wt: " + listOfUnitWeightValuesFromUI[k] + "is less than 999 hence comma is not expected in Claim Details Page");
                }
            }

            IList<IWebElement> extWeight = GlobalVariables.webDriver.FindElements(By.XPath(ExtWgtValuesList_Xpath));
            List<string> listOfExtWeightValuesFromUI = new List<string>();
            for (int l = 0; l < extWeight.Count; l++)
            {
                int m = l + 1;
                string extWeightsingleValue = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + m + "]/td[7]//input", "value");
                listOfExtWeightValuesFromUI.Add(extWeightsingleValue);
            }

            for (int i = 0; i < listOfExtWeightValuesFromUI.Count; i++)
            {
                bool extWeightValueFromUI = listOfExtWeightValuesFromUI[i].Contains(".");
                Assert.IsTrue(extWeightValueFromUI);
                string extWeightValueWithDecimal = listOfExtWeightValuesFromUI[i].Substring(listOfExtWeightValuesFromUI[i].LastIndexOf('.') + 1);
                Assert.AreEqual(extWeightValueWithDecimal.Length, 2);
                if (listOfExtWeightValuesFromUI[i].Contains(","))
                {
                    Report.WriteLine("Ext Wt: " + listOfExtWeightValuesFromUI[i] + "separated with comma and displayed with 2 decimals in Claim Details Page");
                }
                else
                {
                    Report.WriteLine("Ext Wt:" + listOfExtWeightValuesFromUI[i] + "is less than 999 hence comma is not expected in Claim Details Page");
                }
            }
        }

        [Then(@"I will see Unit Val,Ext Val in format of (.*) decimal places, auto fill \$ ,comma when greater than (.*) digits")]
        public void ThenIWillSeeUnitValExtValInFormatOfDecimalPlacesAutoFillCommaWhenGreaterThanDigits(int p0, int p1)
        {
            Report.WriteLine("I will be displayed with Unit Val, Ext Val autofill with $ and 2 decimal places in currency format");

            IList<IWebElement> unitValue = GlobalVariables.webDriver.FindElements(By.XPath(UnitValList_Xpath));
            List<string> listOfUnitValuesFromUI = new List<string>();
            for (int i = 0; i < unitValue.Count; i++)
            {
                int j = i + 1;
                string singleUnitValue = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + j + "]/td[8]//input", "value");
                listOfUnitValuesFromUI.Add(singleUnitValue);
            }

            for (int k = 0; k < listOfUnitValuesFromUI.Count; k++)
            {
                bool unitValueFromUI = listOfUnitValuesFromUI[k].Contains(".");
                Assert.IsTrue(unitValueFromUI);
                bool dollar = listOfUnitValuesFromUI[k].Contains("$");
                Assert.IsTrue(dollar);
                string unitValueWithDecimal = listOfUnitValuesFromUI[k].Substring(listOfUnitValuesFromUI[k].LastIndexOf('.') + 1);
                Assert.AreEqual(unitValueWithDecimal.Length, 2);
                if (listOfUnitValuesFromUI[k].Contains(","))
                {
                    Report.WriteLine("Unit Val: " + listOfUnitValuesFromUI[k] + "separated with comma, auto fill with $ and displayed with 2 decimals in Claim Details Page");
                }
                else
                {
                    Report.WriteLine("Unit Val: " + listOfUnitValuesFromUI[k] + "is less than 999 hence comma is not expected in Claim Details Page");
                }
            }

            IList<IWebElement> extValue = GlobalVariables.webDriver.FindElements(By.XPath(ExtValList_Xpath));
            List<string> listOfExtValuesFromUI = new List<string>();
            for (int l = 0; l < extValue.Count; l++)
            {
                int j = l + 1;
                string singleExtValue = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + j + "]/td[9]//input", "value");
                listOfExtValuesFromUI.Add(singleExtValue);
            }

            for (int i = 0; i < listOfExtValuesFromUI.Count; i++)
            {
                bool extValueFromUI = listOfExtValuesFromUI[i].Contains(".");
                Assert.IsTrue(extValueFromUI);
                bool dollar = listOfExtValuesFromUI[i].Contains("$");
                Assert.IsTrue(dollar);
                string extValueWithDecimal = listOfExtValuesFromUI[i].Substring(listOfExtValuesFromUI[i].LastIndexOf('.') + 1);
                Assert.AreEqual(extValueWithDecimal.Length, 2);
                if (listOfExtValuesFromUI[i].Contains(","))
                {
                    Report.WriteLine("Ext Val: " + listOfExtValuesFromUI[i] + "separated with comma, autofill with $ and displayed with 2 decimals in Claim Details Page");
                }
                else
                {
                    Console.WriteLine("Ext Val: " + listOfExtValuesFromUI[i] + "is less than 999 hence comma is not expected in Claim Details Page");
                }
            }
        }

        [Then(@"I will see Ttl Pcs")]
        public void ThenIWillSeeTtlPcs()
        {
            VerifyElementVisible(attributeName_xpath, TotalPcsLabel_Xpath, "TTL PCS");
            VerifyElementVisible(attributeName_xpath, TotalPcs_Xpath, "Total Pcs Value");
            string totalPcs = Gettext(attributeName_xpath, TotalPcs_Xpath);
            Report.WriteLine("TTL Pcs: " + totalPcs + " displayed in Claim Details page");
        }

        [Then(@"I will see Ttl Wt,Total Shipment Weight in format of format with comma when greater than (.*) digits, always display (.*) decimal places")]
        public void ThenIWillSeeTtlWtTotalShipmentWeightInFormatOfFormatWithCommaWhenGreaterThanDigitsAlwaysDisplayDecimalPlaces(int p0, int p1)
        {
            Report.WriteLine("I will be displayed with Total Weight and Total Shipment Weight separate with comma when value is greater than 3 digits and 2 decimal places");

            string totalWeight = Gettext(attributeName_id, TotalWgt_id);
            bool totalWeightWithDecimal = totalWeight.Contains(".");
            Assert.IsTrue(totalWeightWithDecimal);
            string totalWeightDecimalPlaces = totalWeight.Substring(totalWeight.LastIndexOf('.') + 1);
            Assert.AreEqual(totalWeightDecimalPlaces.Length, 2);
            if (totalWeight.Contains(","))
            {
                Report.WriteLine("TTL WGT: " + totalWeight + "seperated with comma and displayed with 2 decimal values in Claim Details Page");
            }
            else
            {
                Report.WriteLine("TTL WGT: " + totalWeight + "is less than 999 hence comma is not expected in Claim Details Page");
            }

            string totalShipment = GetValue(attributeName_xpath, TotalShipmentWeightValue_xpath, "value");
            bool totalShipmentWithDecimal = totalShipment.Contains(".");
            Assert.IsTrue(totalShipmentWithDecimal);
            if (totalShipment.Contains(","))
            {
                Report.WriteLine("Total Shipment Weight: " + totalShipment + "separated with comma and displayed with 2 decimal values in Claim Details Page");
            }
            else
            {
                Report.WriteLine("Total Shipment Weight: " + totalShipment + "is less than 999 hence comma is not expected in Claim Details Page");
            }
        }

        [Then(@"I will display with Ttl Val in format of (.*) decimal places, auto fill \$,comma when greater than (.*) digits")]
        public void ThenIWillDisplayWithTtlValInFormatOfDecimalPlacesAutoFillCommaWhenGreaterThanDigits(int p0, int p1)
        {
            Report.WriteLine("I will be displayed Total Val with autofill $ and 2 decimal places in currency format");

            string totalValue = Gettext(attributeName_xpath, Totalval_Xpath);
            bool totalValueWithDecimal = totalValue.Contains(".");
            Assert.IsTrue(totalValueWithDecimal);
            bool dollar = totalValue.Contains("$");
            Assert.IsTrue(dollar);
            string totalValueWithDecimalPlaces = totalValue.Substring(totalValue.LastIndexOf('.') + 1);
            Assert.AreEqual(totalValueWithDecimalPlaces.Length, 2);
            if (totalValue.Contains(","))
            {
                Report.WriteLine("TTL Val: " + totalValue + "separated with comma, displayed with 2 decimals and auto filled with $ symbol in Claim Details Page");
            }
            else
            {
                Report.WriteLine("TTL Val: " + totalValue + "not separated with comma hence displayed value is less than 999 in Claim Details Page");
            }
        }

        [Then(@"Ttl Pcs field will display the sum of the Qty of all of the displayed products")]
        public void ThenTtlPcsFieldWillDisplayTheSumOfTheQtyOfAllOfTheDisplayedProducts()
        {
            Report.WriteLine("Total Pieces field will update to display the sum of the Quantity of all of the displayed products");
            scrollElementIntoView(attributeName_xpath, ProductsClaimed_Xpath);
            string totalPieces = Gettext(attributeName_xpath, TotalPcs_Xpath);
            IList<IWebElement> listOfQuantityValues = GlobalVariables.webDriver.FindElements(By.XPath(QtyValuesList_Xpath));
            List<string> actualListOfAllQuantityValues = new List<string>();
            int qtyTotalUI=0;
            for (int l = 0; l < listOfQuantityValues.Count; l++)
            {
                int j = l + 1;
                string singleQtyValue = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + j + "]/td[3]//input", "value");
                actualListOfAllQuantityValues.Add(singleQtyValue);
                qtyTotalUI = qtyTotalUI + Convert.ToInt32(singleQtyValue);
            }
            Assert.AreEqual(totalPieces, qtyTotalUI.ToString());
        }

        [Then(@"Ttl Wt field will display the sum of the EXT WGT of all of the displayed products")]
        public void ThenTtlWtFieldWillDisplayTheSumOfTheEXTWGTOfAllOfTheDisplayedProducts()
        {
            Report.WriteLine("Total Weight field will update to display the sum of the Ext Wt of all of the displayed products");
            string totalWeight = Gettext(attributeName_id, TotalWgt_id);
            
            IList<IWebElement> listOfExtWgtValues = GlobalVariables.webDriver.FindElements(By.XPath(ExtWgtValuesList_Xpath));
            List<string> actualListOfExtWgtValues = new List<string>();
            decimal extWgtValuesUItotal = 0;
            for (int l = 0; l < listOfExtWgtValues.Count; l++)
            {
                int j = l + 1;
                string singleExtWgt = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + j + "]/td[7]//input", "value");
                actualListOfExtWgtValues.Add(singleExtWgt);
                extWgtValuesUItotal = extWgtValuesUItotal + Convert.ToDecimal(singleExtWgt);
            }

            Assert.AreEqual(totalWeight.Replace(",", ""), extWgtValuesUItotal.ToString());
        }

        [Then(@"Ttl Val field will display the sum of the EXT VAL  of all of the displayed products")]
        public void ThenTtlValFieldWillDisplayTheSumOfTheEXTVALOfAllOfTheDisplayedProducts()
        {
            Report.WriteLine("Total Value field will update to display the sum of the Ext Val of all of the displayed products");
            string totalValue = Gettext(attributeName_xpath, Totalval_Xpath);
            IList<IWebElement> listOfExtValues = GlobalVariables.webDriver.FindElements(By.XPath(ExtValList_Xpath));
            List<string> actualListOfExtValues = new List<string>();
            decimal totalValuesUI = 0;
            for (int l = 0; l < listOfExtValues.Count; l++)
            {
                int j = l + 1;
                string singleExtVal = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + j + "]/td[9]//input", "value");
                actualListOfExtValues.Add(singleExtVal);
                totalValuesUI = totalValuesUI + Convert.ToDecimal(singleExtVal.Replace("$",""));
            }
            Assert.AreEqual(totalValue.Replace(",", ""), "$"+totalValuesUI.ToString());
        }


        [Then(@"the Total Shipment Weight field will be defaulted to blank")]
        public void ThenTheTotalShipmentWeightFieldWillBeDefaultedToBlank()
        {
            Report.WriteLine("Total Shipment Weight field will be defaulted to blank");
            scrollElementIntoView(attributeName_xpath, ProductsClaimed_Xpath);
            string totalShipmentWeight = GetValue(attributeName_xpath, TotalShipmentWeightValue_xpath, "value");
            Assert.AreEqual(totalShipmentWeight, "0.00");
        }

        [Then(@"the Ext Wt calculation will be made for each Products Claimed line item:Qty \* Unit Wt")]
        public void ThenTheExtWtCalculationWillBeMadeForEachProductsClaimedLineItemQtyUnitWt()
        {
            Report.WriteLine("Ext Wt calculation will be made for each Products Claimed line item: Qty*Unit Wt");
            scrollElementIntoView(attributeName_xpath, ProductsClaimed_Xpath);
            IList<IWebElement> listOfExtWtValues = GlobalVariables.webDriver.FindElements(By.XPath(ExtWgtValuesList_Xpath));
            List<string> actualListOfExtWgtValues = new List<string>();
            for (int l = 0; l < listOfExtWtValues.Count; l++)
            {
                int j = l + 1;
                string singleExtVal = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + j + "]/td[7]//input", "value");
                actualListOfExtWgtValues.Add(singleExtVal);
            }

            IList<IWebElement> listOfquantityValues = GlobalVariables.webDriver.FindElements(By.XPath(QtyValuesList_Xpath));
            List<string> actualListOfquantityValues = new List<string>();
            for (int a = 0; a < listOfquantityValues.Count; a++)
            {
                int b = a + 1;
                string singleQtyVal = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + b + "]/td[3]//input", "value");
                actualListOfquantityValues.Add(singleQtyVal);
            }
            IList<IWebElement> listOfUnitWtValues = GlobalVariables.webDriver.FindElements(By.XPath(UnitWgtValuesList_Xpath));
            List<string> actualListOfUnitWtValues = new List<string>();
            for (int c = 0; c < listOfUnitWtValues.Count; c++)
            {
                int d = c + 1;
                string singleUnitWtVal = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + d + "]/td[6]//input", "value");
                actualListOfUnitWtValues.Add(singleUnitWtVal);
            }

            for (int i = 0; i < listOfUnitWtValues.Count; i++)
            {
                double Quantity = double.Parse(actualListOfquantityValues[i]);
                double Unitwt = double.Parse(actualListOfUnitWtValues[i]);
                double expExtwt = Quantity * Unitwt;
                double ActualExtWt = double.Parse(actualListOfExtWgtValues[i]);
                Assert.AreEqual(expExtwt, ActualExtWt);
            }
        }

        [Then(@"the Ext Val calculation will be made for each Products Claimed line item:Qty \* Unit Val")]
        public void ThenTheExtValCalculationWillBeMadeForEachProductsClaimedLineItemQtyUnitVal()
        {
            Report.WriteLine("Ext Val calculation will be made for each Products Claimed line item: Qty*Unit Val");
            IList<IWebElement> listOfExtVal = GlobalVariables.webDriver.FindElements(By.XPath(ExtValList_Xpath));
            List<string> actualListOfExtValValues = new List<string>();
            for (int l = 0; l < listOfExtVal.Count; l++)
            {
                int j = l + 1;
                string singleExtVal = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + j + "]/td[9]//input", "value");
                actualListOfExtValValues.Add(singleExtVal);
            }
            IList<IWebElement> listOfquantityValues = GlobalVariables.webDriver.FindElements(By.XPath(QtyValuesList_Xpath));
            List<string> actualListOfquantityValues = new List<string>();
            for (int a = 0; a < listOfquantityValues.Count; a++)
            {
                int b = a + 1;
                string singleQtyVal = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + b + "]/td[3]//input", "value");
                actualListOfquantityValues.Add(singleQtyVal);
            }

            IList<IWebElement> listOfUnitVal = GlobalVariables.webDriver.FindElements(By.XPath(UnitValList_Xpath));
            List<string> actualListOfUnitVal = new List<string>();
            for (int j = 0; j < listOfUnitVal.Count; j++)
            {
                int k = j + 1;
                string singleUnitVal = GetValue(attributeName_xpath, ".//*[@class='productclaimtable']//tr[" + k + "]/td[8]//input", "value");
                actualListOfUnitVal.Add(singleUnitVal);
            }

            for (int i = 0; i < listOfUnitVal.Count; i++)
            {
                double Quantity = double.Parse(actualListOfquantityValues[i]);
                double Unitval = double.Parse(actualListOfUnitVal[i].Replace("$",""));
                double expExtval = Quantity * Unitval;
                double ActualExtVal = double.Parse(actualListOfExtValValues[i].Replace("$", ""));
                Assert.AreEqual(expExtval, ActualExtVal);
            }
        }
    }
}
