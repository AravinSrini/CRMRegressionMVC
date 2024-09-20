using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public sealed class Page_Elements___Customer_UsersSteps : AddShipments
    {

      

        [Then(@"I will be able to see Insured value Note(.*) and Insured rate and Insured Type field")]
        public void ThenIWillBeAbleToSeeInsuredValueNoteAndInsuredRateAndInsuredTypeField(string ExpText)
        {
            Report.WriteLine("Verifying Notificaiton to get insured rate on results page");
            Verifytext(attributeName_xpath, ShipResults_InsuredValueNote_Xpath, ExpText);
           // VerifyElementVisible(attributeName_id, ShipResults_InsuredRateTextbox_Id, "text box");
            VerifyElementVisible(attributeName_id, ShipResults_InsuredValueDropdown_Id, "drop down");
        }

        [Then(@"I will be able to see Filter Carriers By label(.*) Quickest Service and Least Cost Radio button")]
        public void ThenIWillBeAbleToSeeFilterCarriersByLabelQuickestServiceAndLeastCostRadioButton(string filterCarriersBy_Text)
        {
            Report.WriteLine("Verifying filter carrier section page");
            VerifyElementPresent(attributeName_xpath, ShipResults_QuickestService_Xpath, filterCarriersBy_Text);
            VerifyElementPresent(attributeName_xpath, ShipResults_QuickestService_Xpath, "Quickest Service");
            VerifyElementPresent(attributeName_xpath, ShipResults_LeastCost_Xpath, "least cost");
        }

        [Then(@"I will be able to see Carrier, Service Days, Distance, Rate columns and insured rate")]
        public void ThenIWillBeAbleToSeeCarrierServiceDaysDistanceRateColumnsAndInsuredRate()
        {
            Report.WriteLine("Verifying displaying columns");
            Verifytext(attributeName_xpath, ShipResults_CarrierColumn_Xpath, "CARRIER");
            Verifytext(attributeName_xpath, ShipResults_ServiceDaysColumn_Xpath, "SERVICE DAYS");
            Verifytext(attributeName_xpath, ShipResults_DistanceColumn_Xpath, "DISTANCE");
            Verifytext(attributeName_xpath, ShipResults_RateColumn_Xpath, "RATE");
            //Verifytext(attributeName_xpath, ShipResults_InsuredRateColumn_Xpath, "INSURED");
        }


        [When(@"I pass (.*) in shipment information page")]
        public void WhenIPassInShipmentInformationPage(string InsuredRate)
        {
            scrollpagedown();
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, InsuredRate);
        }


        [Then(@"I will see Insured Rate button Terms and Conditions link Create Shipment and Create Insured Shipment button Gauranteed Rates Available link")]
        public void ThenIWillSeeInsuredRateButtonTermsAndConditionsLinkCreateShipmentAndCreateInsuredShipmentButtonGauranteedRatesAvailableLink()
        {
            Report.WriteLine("Verifying displaying columns");
            Verifytext(attributeName_xpath, ShipResults_CarrierColumn_Xpath, "CARRIER");
            Verifytext(attributeName_xpath, ShipResults_ServiceDaysColumn_Xpath, "SERVICE DAYS");
            Verifytext(attributeName_xpath, ShipResults_DistanceColumn_Xpath, "DISTANCE");
            Verifytext(attributeName_xpath, ShipResults_EstCostColumn_Xpath, "EST COST");
            Verifytext(attributeName_xpath, ShipResults_RateColumn_Xpath, "RATE");
        }

       

        [Then(@"I will see Show Insured Rate, Terms and Conditions, Create Shipment,Create Insured Shipment, Export and Back to Shipment List buttons")]
        public void ThenIWillSeeShowInsuredRateTermsAndConditionsCreateShipmentCreateInsuredShipmentExportAndBackToShipmentListButtons()
        {
            Report.WriteLine("Verify the terms and conditions");
            VerifyElementPresent(attributeName_xpath, ShipResults_TermsandConditions_Xpath, "Terms and Conditions");
            VerifyElementVisible(attributeName_id, ShipResults_ShowInsuredRateButton_Id, "Show Insured Rate");
            VerifyElementVisible(attributeName_xpath, ShipResults_ExportButton_Xpath, "Export");
            VerifyElementVisible(attributeName_id, ShipResults_BackToShipmentListButton_Id, "Back to Shipment List");
            VerifyElementVisible(attributeName_xpath, ShipResults_FC_CreateShipment_Xpath, "Create Shipment");
            VerifyElementVisible(attributeName_xpath, ShipResults_FC_CreateInsuredShipment_Xpath, "Create Insured Shipment");
        }

    }
}
