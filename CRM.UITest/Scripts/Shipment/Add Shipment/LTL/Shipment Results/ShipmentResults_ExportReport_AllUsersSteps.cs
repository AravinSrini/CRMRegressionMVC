using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Excel = Microsoft.Office.Interop.Excel;
using CRM.UITest.CommonMethods;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class ShipmentResults_ExportReport_AllUsersSteps : AddShipments
    {
        [Given(@"I enter data in add shipment page  (.*), (.*), (.*),(.*), (.*), (.*),(.*),(.*), (.*),(.*), (.*), (.*), (.*)")]
        public void GivenIEnterDataInAddShipmentPage(string Usertype, 
            string CustomerName, string oZip, string oName, string oAdd, string dZip, string dName, string dAdd, 
            string classification, string nmfc, string quantity, string weight, string desc)
        {
            Report.WriteLine("Click on shipment icon");
            AddShipmentLTL data = new AddShipmentLTL();
            data.NaviagteToShipmentList();
            data.SelectCustomerFromShipmentList(Usertype, CustomerName);
           // Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            data.AddShipmentOriginData(oName,oAdd, oZip);
            //Click(attributeName_id, ShippingTo_ClearAddress_Id);
            data.AddShipmentDestinationData(dName, dAdd, dZip);
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
           // Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            data.AddShipmentFreightDescription(classification,nmfc,quantity,weight,desc);
           // data.ClickViewRates();
        }

        [Given(@"I enter (.*) and click on show insured rate button")]
        public void GivenIEnterAndClickOnShowInsuredRateButton(string insRate)
        {
            Report.WriteLine("Passing data in insured rate text box");
            SendKeys(attributeName_id, ShipResults_InsuredRateTextbox_Id, insRate);
            Report.WriteLine("Clicking on show insured rate button");
            Click(attributeName_id, ShipResults_ShowInsuredRateButton_Id);
        }

        [When(@"I click on export button in ltl shipment results page")]
        public void WhenIClickOnExportButtonInLtlShipmentResultsPage()
        {
            Report.WriteLine("Clicking on export button");
            WaitForElementVisible(attributeName_xpath, ShipResults_ExportButton_Xpath, "Export Button");
            Click(attributeName_xpath, ShipResults_ExportButton_Xpath);
        }

        [Then(@"displaying data in excel should match with UI data for customer users")]
        public void ThenDisplayingDataInExcelShouldMatchWithUIDataForCustomerUsers()
        {
            Report.WriteLine("Verifying the columns name of the downloaded excel document");
            string downloadpath = GetDownloadedFilePath("ShipResultExport.xls");
            List<string> columns = Excel_ReadColumnname(downloadpath);
            List<string> expectedColumnValues = new List<string>(new string[] { "Carrier", "Estimated Service Days", "Distance", "Fuel Charge", "Line Haul Charge", "Accessorial Charge", "Standard Rate", "Insured Fuel Charge", "Insured LineHaul Charge", "Insured Accessorial Charge", "Insured Rate" });

            foreach (var s in columns)
            {
                if (expectedColumnValues.Contains(s))
                {
                    Report.WriteLine("Column name " + s + "displaying in exported excel sheet matches with UI column name");
                }
                else
                {
                    Assert.Fail();
                }
            }

            Report.WriteLine("Comparing the displaying first carrier data with excel data");
            string firstCarrier = Gettext(attributeName_xpath, ShipResults_FC_CarrierName_Xpath);
            string serviceDays = Gettext(attributeName_xpath, ShipResults_FC_ServiceDays_Xpath);
            string distance = Gettext(attributeName_xpath, ShipResults_FC_Distance_Xpath);

            string ActfuelCharge = Gettext(attributeName_xpath, ShipResults_FC_Fuel_Xpath);
            string[] fuelvalue = ActfuelCharge.Split(':');
            string fuelCharge = fuelvalue[1];

            string ActlineHaulCharge = Gettext(attributeName_xpath, ShipResults_FC_Linehaul_Xpath);
            string[] lineHaulValue = ActlineHaulCharge.Split(':');
            string lineHaulCharge = lineHaulValue[1];

            string ActAccCharge = Gettext(attributeName_xpath, ShipResults_FC_Accessories_Xpath);
            string[] AccChargeValue = ActAccCharge.Split(':');
            string AccCharge = AccChargeValue[1];

            string total = Gettext(attributeName_xpath, ShipResults_FC_Total_Xpath);
            string ActInsFuelCharge = Gettext(attributeName_xpath, ShipResults_FC_Fuel_Xpath);
            string[] insFuelValue = ActInsFuelCharge.Split(':');
            string insFuelCharge = insFuelValue[1];

            string ActInslineHaulCharge = Gettext(attributeName_xpath, ShipResults_FC_InsLinehaul_Xpath);
            string[] inslineHaulValue = ActInslineHaulCharge.Split(':');
            string inslineHaulCharge = inslineHaulValue[1];

            string ActInsAccCharge = Gettext(attributeName_xpath, ShipResults_FC_InsAccessories_Xpath);
            string[] insAccValue = ActInsAccCharge.Split(':');
            string insAccCharge = insAccValue[1];

            string ActInsTotal = Gettext(attributeName_xpath, ShipResults_FC_InsTotal_Xpath);

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
            {
                string carrierValue = Convert.ToString((xlRange.Cells[i, 1] as Excel.Range).Value2);
                if (firstCarrier == carrierValue)
                {
                        string actServiceDays = Convert.ToString((xlRange.Cells[i, 2] as Excel.Range).Value2);
                        string actDistance = Convert.ToString((xlRange.Cells[i, 3] as Excel.Range).Value2);
                        string actFuel = Convert.ToString((xlRange.Cells[i, 4] as Excel.Range).Value2);
                        string actLineHual = Convert.ToString((xlRange.Cells[i, 5] as Excel.Range).Value2);
                        string actAccessories = Convert.ToString((xlRange.Cells[i, 6] as Excel.Range).Value2);
                        string actTotal = Convert.ToString((xlRange.Cells[i, 7] as Excel.Range).Value2);
                        string actInsFuel = Convert.ToString((xlRange.Cells[i, 8] as Excel.Range).Value2);
                        string actInsLineHaul = Convert.ToString((xlRange.Cells[i, 9] as Excel.Range).Value2);
                        string actInsAcc = Convert.ToString((xlRange.Cells[i, 10] as Excel.Range).Value2);
                        string actinsTotal = Convert.ToString((xlRange.Cells[i, 11] as Excel.Range).Value2);

                    Assert.AreEqual(serviceDays + " days", actServiceDays);
                    Assert.AreEqual(distance, actDistance);
                    Assert.AreEqual(Convert.ToDecimal(fuelCharge.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actFuel.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(lineHaulCharge.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actLineHual.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(AccCharge.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actAccessories.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(total.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actTotal.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(insFuelCharge.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actInsFuel.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(inslineHaulCharge.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actInsLineHaul.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(insAccCharge.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actInsAcc.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(ActInsTotal.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actinsTotal.Replace("$", string.Empty)));
            break;
                }
            }

            xlWorkbook.Close(0);
            xlApp.Quit();

            DeleteFilesFromFolder(downloadpath);
        }

        [Then(@"displaying data in excel should match with UI data for station users")]
        public void ThenDisplayingDataInExcelShouldMatchWithUIDataForStationUsers()
        {
            Report.WriteLine("Verifying the columns name of the downloaded excel document");
            string downloadpath = GetDownloadedFilePath("ShipResultExport.xls");
            List<string> columns = Excel_ReadColumnname(downloadpath);
            List<string> expectedColumnValues = new List<string>(new string[] { "Carrier", "Estimated Service Days", "Distance", "Est Cost Fuel Charge", "Est Cost Line Haul Charge", "Est Accessorial Charge", "Est Cost","Fuel Charge", "Line Haul Charge", "Accessorial Charge","Standard Rate", "Est Margin Standard", "Insured Fuel Charge", "Insured LineHaul Charge", "Insured Accessorial Charge", "Insured Rate", "Est Margin Insured" });

            foreach (var s in columns)
            {
                if (expectedColumnValues.Contains(s.Replace("\n"," ")))
                {
                    Report.WriteLine("Column name " + s + "displaying in exported excel sheet matches with UI column name");
                }
                else
                {
                    Assert.Fail();
                }
            }

            Report.WriteLine("Comparing the displaying first carrier data with excel data");
            string firstCarrier = Gettext(attributeName_xpath, ShipResults_FC_CarrierName_Xpath);
            string serviceDays = Gettext(attributeName_xpath, ShipResults_FC_ServiceDays_Xpath);
            string distance = Gettext(attributeName_xpath, ShipResults_FC_Distance_Xpath);
            string estFuelChargeUI = Gettext(attributeName_xpath, ShipResults_InternalFC_EstFuel_Xpath);
            string[] estFuelChargeValue = estFuelChargeUI.Split(':');
            string estFuelCharge = estFuelChargeValue[1];

            string estLineHaulChargeUI = Gettext(attributeName_xpath, ShipResults_InternalFC_EstLinehaul_Xpath);
            string[] estLineHaulChargeValue = estLineHaulChargeUI.Split(':');
            string estLineHaulCharge = estLineHaulChargeValue[1];

            string estAccChargeUI = Gettext(attributeName_xpath, ShipResults_InternalFC_EstAccessories_Xpath);
            string[] estAccChargeValue = estAccChargeUI.Split(':');
            string estAccCharge = estAccChargeValue[1];

            string estTotal = Gettext(attributeName_xpath, ShipResults_InternalFC_EstTotal_Xpath);
            string fuelChargeUI = Gettext(attributeName_xpath, ShipResults_FC_Fuel_Xpath);
            string[] fuelChargeValue = fuelChargeUI.Split(':');
            string fuelCharge = fuelChargeValue[1];

            string lineHaulChargeUI = Gettext(attributeName_xpath, ShipResults_InternalFC_InsLinehaul_Xpath);
            string[] lineHaulChargeValue = lineHaulChargeUI.Split(':');
            string lineHaulCharge = lineHaulChargeValue[1];

            string AccChargeUI = Gettext(attributeName_xpath, ShipResults_InternalFC_Accessories_Xpath);
            string[] AccChargeUIValue = AccChargeUI.Split(':');
            string AccCharge = AccChargeUIValue[1];

            string total = Gettext(attributeName_xpath, ShipResults_InternalFC_Total_Xpath);
            string insFuelChargeUI = Gettext(attributeName_xpath, ShipResults_FC_Fuel_Xpath);
            string[] insFuelChargeValue = insFuelChargeUI.Split(':');
            string insFuelCharge = insFuelChargeValue[1];

            string marginTotalUI = Gettext(attributeName_xpath, ShipResults_InternalFC_Margin_Xpath);
            string[] marginTotalValue = marginTotalUI.Split(':');
            string marginTotal = marginTotalValue[1];

            string inslineHaulChargeUI = Gettext(attributeName_xpath, ShipResults_InternalFC_InsLinehaul_Xpath);
            string[] inslineHaulChargeValue = inslineHaulChargeUI.Split(':');
            string inslineHaulCharge = inslineHaulChargeValue[1];

            string insAccChargeUI = Gettext(attributeName_xpath, ShipResults_InternalFC_InsAccessories_Xpath);
            string[] insAccChargeValue = insAccChargeUI.Split(':');
            string insAccCharge = insAccChargeValue[1];

            string insTotal = Gettext(attributeName_xpath, ShipResults_InternalFC_InsTotal_Xpath);

            string insMarginTotalUI = Gettext(attributeName_xpath, ShipResults_InternalFC_InsMargin_Xpath);
            string[] insMarginTotalValue = insMarginTotalUI.Split(':');
            string insMarginTotal = insMarginTotalValue[1];

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            for (int i = 2; i <= rowCount; i++)
            {
                string carrierValue = Convert.ToString((xlRange.Cells[i, 1] as Excel.Range).Value2);
                if (firstCarrier == carrierValue)
                {
                    string actServiceDays = Convert.ToString((xlRange.Cells[i, 2] as Excel.Range).Value2);
                    string actDistance = Convert.ToString((xlRange.Cells[i, 3] as Excel.Range).Value2);
                    string actEstFuel = Convert.ToString((xlRange.Cells[i, 4] as Excel.Range).Value2);
                    string actEstLineHual = Convert.ToString((xlRange.Cells[i, 5] as Excel.Range).Value2);
                    string actEstAccessories = Convert.ToString((xlRange.Cells[i, 6] as Excel.Range).Value2);
                    string actEstTotal = Convert.ToString((xlRange.Cells[i, 7] as Excel.Range).Value2);
                    string actFuel = Convert.ToString((xlRange.Cells[i, 8] as Excel.Range).Value2);
                    string actLineHual = Convert.ToString((xlRange.Cells[i, 9] as Excel.Range).Value2);
                    string actAccessories = Convert.ToString((xlRange.Cells[i, 10] as Excel.Range).Value2);
                    string actTotal = Convert.ToString((xlRange.Cells[i, 11] as Excel.Range).Value2);
                    string actEstMargin = Convert.ToString((xlRange.Cells[i, 12] as Excel.Range).Value2);
                    string actInsFuel = Convert.ToString((xlRange.Cells[i, 13] as Excel.Range).Value2);
                    string actInsLineHaul = Convert.ToString((xlRange.Cells[i, 14] as Excel.Range).Value2);
                    string actInsAcc = Convert.ToString((xlRange.Cells[i, 15] as Excel.Range).Value2);
                    string actInsTotal = Convert.ToString((xlRange.Cells[i, 16] as Excel.Range).Value2);
                    string actInsMarginTotal = Convert.ToString((xlRange.Cells[i, 17] as Excel.Range).Value2);

                    Assert.AreEqual(serviceDays + " days", actServiceDays);
                    Assert.AreEqual(distance, actDistance);
                    Assert.AreEqual(Convert.ToDecimal(estFuelCharge.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actEstFuel.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(estLineHaulCharge.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actEstLineHual.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(estTotal.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actEstTotal.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(fuelCharge.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actFuel.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(lineHaulCharge.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actLineHual.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(total.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actTotal.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(marginTotal.Trim().Replace("%", string.Empty)), Convert.ToDecimal(actEstMargin.Replace("%", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(insFuelCharge.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actInsFuel.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(inslineHaulCharge.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actInsLineHaul.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(insAccCharge.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actInsAcc.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(insTotal.Trim().Replace("$", string.Empty)), Convert.ToDecimal(actInsTotal.Replace("$", string.Empty)));
                    Assert.AreEqual(Convert.ToDecimal(insMarginTotal.Trim().Replace("%", string.Empty)), Convert.ToDecimal(actInsMarginTotal.Replace("%", string.Empty)));
                    break;
                }
            }


            xlWorkbook.Close(0);
            xlApp.Quit();

            DeleteFilesFromFolder(downloadpath);
        }
    }
}
