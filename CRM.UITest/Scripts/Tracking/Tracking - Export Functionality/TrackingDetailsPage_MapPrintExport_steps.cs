using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using Excel = Microsoft.Office.Interop.Excel;

namespace CRM.UITest.Scripts.Tracking
{
	[Binding]
	public sealed class TrackingDetailsPage_MapPrintExport_steps : ObjectRepository
	{


		[Then(@"I will click on down arrow button")]
		public void ThenIWillClickOnDownArrowButton()
		{
			int count = GetCount(attributeName_xpath, Tracking_Datatable_Values_Xpath);
			if (count > 1)
			{
				Click(attributeName_xpath, DEtails_downArrow_Xpath);
			}
		}



		[Then(@"I will be able to see Print option")]
		public void ThenIWillBeAbleToSeePrintOption()
		{
			VerifyElementPresent(attributeName_xpath, TrackingPrintButton_Xpath, "Print");
		}

		[Then(@"I will be able to see Export button")]
		public void ThenIWillBeAbleToSeeExportButton()
		{
			Report.WriteLine("working");
			WaitForElementVisible(attributeName_xpath, TrackingExportLink_Xpath, "Export Button");
			VerifyElementPresent(attributeName_xpath, TrackingExportLink_Xpath, "Export");

			Click(attributeName_xpath, TrackingExportLink_Xpath);
			Thread.Sleep(3000);
			Click(attributeName_xpath, DEtails_downArrow_Xpath);
			Thread.Sleep(3000);

		}

		[Then(@"I have clicked on Export button")]
		public void ThenIHaveClickedOnExportButton()
		{
			Click(attributeName_xpath, TrackingExportLink_Xpath);
		}

		[Then(@"I will be able to see three columns (.*),(.*),(.*)")]
		public void ThenIWillBeAbleToSeeThreeColumns(string DateHeader, string DetailsHeader, string LocationHeader)
		{
			scrollpagedown();
			scrollpagedown();
			WaitForElementVisible(attributeName_xpath, TrackingDateHeader_Xpath, "Tracking Details");
			Verifytext(attributeName_xpath, TrackingDateHeader_Xpath, DateHeader);
			Verifytext(attributeName_xpath, TrackingDetailsHeader_Xpath, DetailsHeader);
			Verifytext(attributeName_xpath, TrackingLocationHeader_Xpath, LocationHeader);
		}

		[Then(@"shipment details should be expanded (.*)")]
		public void ThenShipmentDetailsShouldBeExpanded(string MApHeader)
		{
			WaitForElementVisible(attributeName_xpath, Tracking_MapHeader_Xpath, MApHeader);
			Verifytext(attributeName_xpath, Tracking_MapHeader_Xpath, MApHeader);
		}


		[Then(@"Shipment details should be expanded with tracking detail section (.*)")]
		public void ThenShipmentDetailsShouldBeExpandedWithTrackingDetailSection(string LocationHeader)
		{
			WaitForElementVisible(attributeName_xpath, Tracking_TrackingDetailsHeader_Xpath, LocationHeader);
			Verifytext(attributeName_xpath, Tracking_TrackingDetailsHeader_Xpath, LocationHeader);
		}



        [Then(@"it will download the tracking details in a \.xls file named TrackingDetails\.xls (.*)")]
        public void ThenItWillDownloadTheTrackingDetailsInA_XlsFileNamedTrackingDetails_Xls(string TrackingDetailsfilename)
        {
            List<string> UIvalue = IndividualColumnData(".//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div/div[2]/div/div/table/tbody/tr/td[1]"); //Gets Column Number
            string downloadpath = null;
            for (int i = 0; i < UIvalue.Count; i++)
            {
                 downloadpath = GetDownloadedFilePath(TrackingDetailsfilename);
                List<string> rowValue = new List<string> { };
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

				int rowCount = xlRange.Rows.Count;
				int colCount = xlRange.Columns.Count;

				for (int k = 6; k <= rowCount; k++)
				{

					string refValue = Convert.ToString((xlRange.Cells[k, 1] as Excel.Range).Value2);
					int count = i + 1;
					string UIDate = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div/div[2]/div/div/table/tbody/tr[" + count.ToString() + "]/td[1]")).Text;
					Assert.AreEqual(refValue, UIDate);

					string DeatilsExcel = Convert.ToString((xlRange.Cells[k, 2] as Excel.Range).Value2);
					string DetailsUI = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div/div[2]/div/div/table/tbody/tr[" + count.ToString() + "]/td[2]")).Text;
					Assert.AreEqual(DeatilsExcel.ToUpper(), DetailsUI);

                    string LocExcel = Convert.ToString((xlRange.Cells[k, 3] as Excel.Range).Value2);
                    string LocUI = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='TrackingDetailGrid']/tbody/tr[2]/td/div/div[2]/div/div[2]/div/div/table/tbody/tr[" + count.ToString() + "]/td[3]")).Text;
                    Assert.AreEqual(LocExcel.Trim(), LocUI.Trim());
                    i++;           
                }
                xlWorkbook.Close(0);
                xlApp.Quit();
            }
            DeleteFilesFromFolder(downloadpath);
        }
    }


}

