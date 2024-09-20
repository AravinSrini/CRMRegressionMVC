using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Shipment.Add_Shipment.Shipment_Service_Tiles_Screen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.UAT_Regression.Domestic_Forwarding.Shipment
{
    [Binding]
    public class AddShipment_Confirmation_UploadDocumentSteps : Mvc4Objects
    {
        string shipRef = null;

        [Given(@"I am on the Confirmation page of the Add Shipment process (.*), (.*), (.*), (.*), (.*),(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public string GivenIAmOnTheConfirmationPageOfTheAddShipmentProcessAnd(string userName, string password, string type, 
            string oLocName, string oLocAdd, string oZip, string dLocName, string dLocAdd, string dZip, string pickReady, 
            string pickClose, string delReady, string delClose, string quantity, string weight, string length, 
            string width, string height, string itemDesc)
        {
            Report.WriteLine("Logging into the appliaction");
            CommonMethodsCrm methods = new CommonMethodsCrm();
            methods.LoginToCRMApplication(userName, password);

            Report.WriteLine("Clicking on shipment icon");
            AddShipmentLTL ship = new AddShipmentLTL();
            ship.NaviagteToShipmentList();
            Click(attributeName_id, "add-shipment-btn");

            Report.WriteLine("Selecting domestic forwarding type");
            AddShipmen_ServiceSelection_DomFor_CustomerUsersSteps steps = new AddShipmen_ServiceSelection_DomFor_CustomerUsersSteps();
            steps.WhenIClickOnTheDomesticForwardingTileInAddShipmentPage();
            steps.WhenISelectAnyFromTheDropdown(type);
            steps.WhenIClickOnContinueButtonInServiceTypePopup();
            steps.ThenIShouldBeNavigatedToTheDomesticForwardingLocationsAndDatesPage();

            Report.WriteLine("Passing data in location and dates page");
            SendKeys(attributeName_id, ShipDF_OriginLocationName_Id, oLocName);
            SendKeys(attributeName_id, ShipDF_OriginAddress_Id, oLocAdd);
            SendKeys(attributeName_id, ShipDF_OriginZip_Id, oZip);
            SendKeys(attributeName_id, ShipDF_DestLocationName_Id, dLocName);
            SendKeys(attributeName_id, ShipDF_DestAddress_Id, dLocAdd);
            SendKeys(attributeName_id, ShipDF_DestZip_Id, dZip);

            scrollElementIntoView(attributeName_xpath, ShipDF_PickReady_Dropdown_Xpath);
            Click(attributeName_xpath, ShipDF_PickReady_Dropdown_Xpath);
            WaitForElementVisible(attributeName_xpath, ShipDF_PickReady_DropdownValues_Xpath, "Pickup ready");
            SelectDropdownValueFromList(attributeName_xpath, ShipDF_PickReady_DropdownValues_Xpath, pickReady);

            Click(attributeName_xpath, ShipDF_PickClose_Dropdown_Xpath);
            WaitForElementVisible(attributeName_xpath, ShipDF_PickClose_DropdownValues_Xpath, "Pickup close");
            SelectDropdownValueFromList(attributeName_xpath, ShipDF_PickClose_DropdownValues_Xpath, pickClose);

            Click(attributeName_xpath, ShipDF_DelReady_Dropdown_Xpath);
            WaitForElementVisible(attributeName_xpath, ShipDF_DelReady_DropdownValues_Xpath, "Delivery ready");
            SelectDropdownValueFromList(attributeName_xpath, ShipDF_DelReady_DropdownValues_Xpath, delReady);

            Click(attributeName_xpath, ShipDF_DelClose_Dropdown_Xpath);
            WaitForElementVisible(attributeName_xpath, ShipDF_DelClose_DropdownValues_Xpath, "Delivery close");
            SelectDropdownValueFromList(attributeName_xpath, ShipDF_DelClose_DropdownValues_Xpath, delClose);

            scrollElementIntoView(attributeName_id, ShipDF_Quantity_Id);
            SendKeys(attributeName_id, ShipDF_Quantity_Id, quantity);
            SendKeys(attributeName_id, ShipDF_Weight_Id, weight);
            SendKeys(attributeName_id, ShipDF_Length_Id, length);
            SendKeys(attributeName_id, ShipDF_Width_Id, width);
            SendKeys(attributeName_id, ShipDF_Height_Id, height);
            SendKeys(attributeName_id, ShipDF_Desc_Id, itemDesc);

            scrollpagedown();
            Click(attributeName_id, ShipDF_SaveContinueButton_Id);

            WaitForElementVisible(attributeName_id, ShipDF_SubmitButton_Id, "Submit Button");
            scrollElementIntoView(attributeName_id, ShipDF_SubmitButton_Id);
            Click(attributeName_id, ShipDF_SubmitButton_Id);

            WaitForElementVisible(attributeName_xpath, ShipDF_ConfirmationTitle_Xpath, "Confirmation page");

            shipRef = Gettext(attributeName_id, ShipDF_RefNum_Text);
            return shipRef;
        }

        [Given(@"I have uploaded a document (.*)")]
        public void GivenIHaveUploadedADocument(string path)
        {
            Report.WriteLine("Uploading document");
            scrollElementIntoView(attributeName_xpath, ShipDF_BrowseFile_Xpath);
            Thread.Sleep(2000);
            string filepath = Path.GetFullPath(path);
            FileUpload(attributeName_xpath, ShipDF_BrowseFile_Xpath, filepath);
            WaitForElementPresent(attributeName_xpath, ShipDF_FileSavedText_Xpath, "SAVED");
        }

        [When(@"I arrive on the Document repository page")]
        public void WhenIArriveOnTheDocumentRepositoryPage()
        {
            Report.WriteLine("Clicking to Doc Rep Module");
            Click(attributeName_xpath, DocumentRepositoryIcon_xpath);

            Report.WriteLine("User should navigate to the Document Repository module");
            Verifytext(attributeName_cssselector, DocumentRepositorypageTitle_css, "Document Repository");
        }
        
        [When(@"I open the BOL folder")]
        public void WhenIOpenTheBOLFolder()
        {
            Report.WriteLine("Clicking on BOL folder");
            WaitForElementVisible(attributeName_xpath, DocRepo_BOLTab_Xpath,"BOL");
            Click(attributeName_xpath, DocRepo_BOLTab_Xpath);
        }

        [Then(@"the recently uploaded document must be listed in the grid (.*)")]
        public void ThenTheRecentlyUploadedDocumentMustBeListedInTheGrid(string fileName)
        {
            Report.WriteLine("Verifying the recently added page for the uploaded document");
            Verifytext(attributeName_id, DocRepo_RecentlyAddedtitlt_Id, "Recently Added");
            WaitForElementVisible(attributeName_id, DocRepo_SearchBox_Id, "Doc Repo");
            SendKeys(attributeName_id, DocRepo_SearchBox_Id, shipRef);
            string actFilename = Gettext(attributeName_xpath, DocRepo_Firstrow_FileName_Xpath);
            Assert.AreEqual(actFilename.Trim(), fileName);
            Report.WriteLine("Uploaded document in shipment " + fileName + " is displaying doc repe recently added " + actFilename);
        }

        [Then(@"the reference number must be the primary reference number of the shipment (.*)")]
        public void ThenTheReferenceNumberMustBeThePrimaryReferenceNumberOfTheShipment(string filename)
        {
            string actRefvalue = Gettext(attributeName_xpath, DocRepo_Firstrow_Ref_Xpath);
            Assert.AreEqual(actRefvalue.Trim(), shipRef);
            DBHelper.removefile(filename);
        }

        [Then(@"the document is displayed (.*)")]
        public void ThenTheDocumentIsDisplayed(string fileName)
        {
            Report.WriteLine("Verifying the BOL page for the uploaded document");
            Verifytext(attributeName_id, DocRepo_RecentlyAddedtitlt_Id, "BOLs");
            SendKeys(attributeName_id, DocRepo_SearchBox_Id, shipRef);
            string actFilename = Gettext(attributeName_xpath, DocRepo_Firstrow_FileName_Xpath);
            Assert.AreEqual(actFilename.Trim(), fileName);
            Report.WriteLine("Uploaded document in shipment " + fileName + " is displaying doc repe BOL folder " + actFilename);
        }

    }
}
