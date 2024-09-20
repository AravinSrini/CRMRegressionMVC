using CRM.UITest.Objects;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Confirmation_Screen__All_Users
{
    [Binding]
    public class ShipmentConfirmationLTL_MVC5_BOLDocumentcreationSteps:AddShipments
    {    
        [When(@"I click on the drop down arrow of the Bill of Lading button")]
        public void WhenIClickOnTheDropDownArrowOfTheBillOfLadingButton()
        {
            Report.WriteLine("Click on BOL dropdown");
            Click(attributeName_xpath, confirmation_BOLbutton);            
        }
        
        [When(@"I click on View Bill of Lading option")]
        public void WhenIClickOnViewBillOfLadingOption()
        {
            Report.WriteLine("Click on View BOL option");
            scrollpagedown();
            Click(attributeName_xpath, confirmation_ViewBOL_xpath);
        }
        
        [Then(@"New tab will be opened which will display the BOL of shipment")]
        public void ThenNewTabWillBeOpenedWhichWillDisplayTheBOLOfShipment()
        {
            string configURL = launchUrl;
            WindowHandling(configURL + "Shipment/ShipmentConfirmation#");
            string variableref = Gettext(attributeName_xpath, confirmation_BOLValue_Xpath);
            
            string expectedPageURL = configURL + "Shipment/ViewBol?referenceNumber=" + variableref;
           
           WindowHandling(expectedPageURL);
            Report.WriteLine("User is navigated to the Bill of Lading Creation page");
            
        }
                 
    }
}
