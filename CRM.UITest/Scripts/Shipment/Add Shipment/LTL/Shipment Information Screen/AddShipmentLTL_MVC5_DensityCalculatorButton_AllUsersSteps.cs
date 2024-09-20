using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipmentLTL_MVC5_DensityCalculatorButton_AllUsersSteps:AddShipments
    {
        [When(@"I clicked on the Density calculator Icon")]
        public void WhenIClickedOnTheDensityCalculatorIcon()
        {
            Report.WriteLine("Click on Density Calculator icon");
            scrollpagedown();
            Thread.Sleep(1000);
            scrollpagedown();
            Thread.Sleep(1000);
            Click(attributeName_id, LTL_EstimateClassButton_Id);
            WaitForElementVisible(attributeName_xpath, LTL_EstimateClass_HeaderText_Xpath, "Estimate Class Lookup");
        }

        [When(@"I enter values in (.*), (.*), (.*), (.*) and (.*)")]
        public void WhenIEnterValuesInAnd(string Length, string Width, string Height, string Weight, string Quantity)
        {
            Report.WriteLine("Passing data in esitmated class lookup");
            WaitForElementVisible(attributeName_id, LTL_EstimateClass_Length_Id, "Estimate Lookup");
            SendKeys(attributeName_id, LTL_EstimateClass_Length_Id, Length);
            SendKeys(attributeName_id, LTL_EstimateClass_Width_Id, Width);
            SendKeys(attributeName_id, LTL_EstimateClass_Height_Id, Height);
            SendKeys(attributeName_id, LTL_EstimateClass_Weight_Id, Weight);
            SendKeys(attributeName_id, LTL_EstimateClass_Quantity_Id, Quantity);
            Click(attributeName_id, LTL_EstimateClass_TableLink_Id);
            Thread.Sleep(2000);            
        }

        [Then(@"Estimated Class Lookup modal will be displayed")]
        public void ThenEstimatedClassLookupModalWillBeDisplayed()
        {
            Report.WriteLine("Estimated Class lookup modal displayed");
            string ExpectedText = "Estimated Class Lookup";
            string ActualText = Gettext(attributeName_xpath, LTL_EstimateClass_HeaderText_Xpath);
            Assert.AreEqual(ExpectedText, ActualText);
        }
        
        [Then(@"I will see the fields (.*), (.*), (.*), (.*) and (.*) with in the Estimated class lookup modal")]
        public void ThenIWillSeeTheFieldsAndWithInTheEstimatedClassLookupModal(string Length, string Width, string Height, string Weight, string Quantity)
        {
            Report.WriteLine("Verify all the fields with in estimated class lookup");
            Verifytext(attributeName_xpath, LTL_EstimateClass_Length_Verbiage_Xpath, Length);
            Verifytext(attributeName_xpath, LTL_EstimateClass_Width_Verbiage_Xpath, Width);
            Verifytext(attributeName_xpath, LTL_EstimateClass_Height_Verbiage_Xpath, Height);
            Verifytext(attributeName_xpath, LTL_EstimateClass_Weight_Verbiage_Xpath, Weight);
            Verifytext(attributeName_xpath, LTL_EstimateClass_Quantity_Verbiage_Xpath, Quantity);
        }
                
        [Then(@"Modal popup should be closed and passed data should be populated into respective fields (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void ThenModalPopupShouldBeClosedAndPassedDataShouldBePopulatedIntoRespectiveFieldsAnd(double Length, double Width, double Height, string Weight, string Quantity, string Class)
        {
            scrollpagedown();
            Thread.Sleep(500);
            scrollpagedown();

            string ActualClassification = Gettext(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Assert.AreEqual(Class, ActualClassification);

            string ActualWeight = GetValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");
            Assert.AreEqual(Weight, ActualWeight);

            string ActualQuantity = GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
            Assert.AreEqual(Quantity, ActualQuantity);
                        
            string Length_UI = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
            double ActualLength = double.Parse(Length_UI);
            Assert.AreEqual(Height, ActualLength);

            string Width_UI = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            double ActualWidth = double.Parse(Width_UI);
            Assert.AreEqual(Height, ActualWidth);

            string Height_UI = GetAttribute(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
            double ActualHeight = double.Parse(Height_UI);
            Assert.AreEqual(Height, ActualHeight);                        
        }

        [When(@"I clicked on close button in esitmate class popup")]
        public void WhenIClickedOnCloseButtonInEsitmateClassPopup()
        {
            Report.WriteLine("Clicking close button");            
            Click(attributeName_xpath, CloseBtnPopUpEstimateclass_xpath);
        }


    }
}
