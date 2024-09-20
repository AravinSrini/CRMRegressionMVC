using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Get_Quote__LTL__Screen
{
    [Binding]
    public class GetQuote_ClearItem_AllUsersSteps : ObjectRepository
    {
        [When(@"I click on Clear Item link")]
        public void WhenIClickOnClearItemLink()
        {
            Report.WriteLine("Clicking on clear item link");
            VerifyElementVisible(attributeName_id, LTL_ClearItem_Id, "Clear Item Link");
            Click(attributeName_id, LTL_ClearItem_Id);
        }

        [Then(@"item fields Classification ,Weight,Quantity and Quantity_unit should be cleared")]
        public void ThenItemFieldsClassificationWeightQuantityAndQuantity_UnitShouldBeCleared()
        {
            Report.WriteLine("Verify the item fields on clicking clear item link");
            string classValue = Gettext(attributeName_xpath, LTL_Classification_SelectedValue_Xpath);
            Assert.AreEqual(classValue, "Select or search for a class or saved item...");
            Report.WriteLine("Classification dropdown is set to select");

            string weightValue = Gettext(attributeName_id, LTL_Weight_Id);
            Assert.AreEqual(weightValue, string.Empty);
            Report.WriteLine("Weight Value is empty");

            string quanValue = Gettext(attributeName_id, LTL_Quantity_Id);
            Assert.AreEqual(quanValue, string.Empty);
            Report.WriteLine("Quantity Value is empty");

            string quanUnitValue = Gettext(attributeName_xpath, LTL_QuantityUnitField_Selectedvalue_Xpath);
            Assert.AreEqual(quanUnitValue, "Skids");
            Report.WriteLine("Skids value is selected to default value skids");
        }
    }
}
