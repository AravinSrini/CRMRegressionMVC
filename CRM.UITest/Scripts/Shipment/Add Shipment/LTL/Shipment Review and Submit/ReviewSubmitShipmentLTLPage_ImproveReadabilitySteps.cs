using CRM.UITest.CommonMethods;
using CRM.UITest.Helper;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Review_and_Submit
{
    [Binding]
    public class ReviewSubmitShipmentLTLPage_ImproveReadabilitySteps : AddShipments
    {
        [Then(@"I verify the labels and values will be black\.")]
        public void ThenIVerifyTheLabelsAndValuesWillBeBlack_()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            MoveToElement(attributeName_xpath, ShipResults_CreateShipButton_Xpath);
            Click(attributeName_xpath, ShipResults_CreateShipButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            string shippingInformation = GetCSSValue(attributeName_xpath, ReviewSubmitShippingToInformation, "color");
            Report.WriteLine("Verification that the text color of the shipping information is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, shippingInformation);

            string pickupDetails = GetCSSValue(attributeName_xpath, ReviewSubmitPickupDetails, "color");
            Report.WriteLine("Verification that the text color of the pickup details is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, pickupDetails);

            string frieghtDescriptionHeading = GetCSSValue(attributeName_xpath, ReviewSubmitFrieghtDescriptionHeading, "color");
            Report.WriteLine("Verification that the text color of the frieght description heading is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, frieghtDescriptionHeading);

            string frieghtDescription = GetCSSValue(attributeName_xpath, ReviewSubmitFrieghtDescription, "color");
            Report.WriteLine("Verification that the text color of the frieght description section is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, frieghtDescription);

            string frieghtDescriptionHazmat = GetCSSValue(attributeName_xpath, ReviewSubmitFrieghtDescriptionHazmat, "color");
            Report.WriteLine("Verification that the text color of the frieght description hazmat section is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, frieghtDescriptionHazmat);

            string referenceNumberSection = GetCSSValue(attributeName_xpath, ReviewSubmitReferenceNumberSection, "color");
            Report.WriteLine("Verification that the text color of the reference number section is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, referenceNumberSection);

            string instructionAndInsuredValueSection = GetCSSValue(attributeName_xpath, ReviewSubmitInstructionAndInsuredValueSection, "color");
            Report.WriteLine("Verification that the text color of the instruction and insuredValue section is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, instructionAndInsuredValueSection);

            string carrierInformationSection = GetCSSValue(attributeName_xpath, ReviewSubmitCarrierInformationSection, "color");
            Report.WriteLine("Verification that the text color of the carrier information section is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, carrierInformationSection);
        }

        [Then(@"I verify the labels and values will be black for Internal User\.")]
        public void ThenIVerifyTheLabelsAndValuesWillBeBlackForInternalUser_()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            MoveToElement(attributeName_xpath, ShipResults_CreateShipButton_Xpath);
            Click(attributeName_xpath, ShipResults_CreateShipButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            string shippingInformation = GetCSSValue(attributeName_xpath, ReviewSubmitShippingToInformation, "color");
            Report.WriteLine("Verification that the text color of the shipping information is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, shippingInformation);

            string pickupDetails = GetCSSValue(attributeName_xpath, ReviewSubmitPickupDetails, "color");
            Report.WriteLine("Verification that the text color of the pickup details is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, pickupDetails);

            string frieghtDescriptionHeading = GetCSSValue(attributeName_xpath, ReviewSubmitFrieghtDescriptionHeading, "color");
            Report.WriteLine("Verification that the text color of the frieght description heading is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, frieghtDescriptionHeading);

            string frieghtDescription = GetCSSValue(attributeName_xpath, ReviewSubmitFrieghtDescription, "color");
            Report.WriteLine("Verification that the text color of the frieght description section is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, frieghtDescription);

            string frieghtDescriptionHazmat = GetCSSValue(attributeName_xpath, ReviewSubmitFrieghtDescriptionHazmat, "color");
            Report.WriteLine("Verification that the text color of the frieght description hazmat section is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, frieghtDescriptionHazmat);

            string referenceNumberSection = GetCSSValue(attributeName_xpath, ReviewSubmitReferenceNumberSection, "color");
            Report.WriteLine("Verification that the text color of the reference number section is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, referenceNumberSection);

            string instructionAndInsuredValueSection = GetCSSValue(attributeName_xpath, ReviewSubmitInstructionAndInsuredValueSection, "color");
            Report.WriteLine("Verification that the text color of the instruction and insuredValue section is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, instructionAndInsuredValueSection);

            string carrierInformationSection = GetCSSValue(attributeName_xpath, ReviewSubmitCarrierInformationSection_InternalUser, "color");
            Report.WriteLine("Verification that the text color of the carrier information section is black");
            Assert.AreEqual(CommonConstants.BlackColorInRgba, carrierInformationSection);
        }

    }
}
