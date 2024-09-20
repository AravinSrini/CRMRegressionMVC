using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Add_Quantity_Parameters
{
    [Binding]
    public class RateRequest_DefaultItem_Desktop : ObjectRepository
    {
        [Then(@"The saved item information of '(.*)', '(.*)', '(.*)', '(.*)' should be auto-filled in the Freight Description section")]
        public void ThenTheSavedItemInformationOfShouldBeAuto_FilledInTheFreightDescriptionSection(string Class, string Weight, string Quantity, string QuantityType)
        {
            Report.WriteLine("Verifying the Select Class field is auto filled with saved item information");
            VerifyElementPresent(attributeName_id, ClassorSavedItemField_id, "SavedItemField");
            var DefaultText_ClassSavedItem = Gettext(attributeName_xpath, ClassorSavedItemField_xpath);
            Assert.AreEqual(Class, DefaultText_ClassSavedItem);

            Report.WriteLine("Verifying the weight field is auto filled with saved item information");
            VerifyElementPresent(attributeName_id, weight_id, "weight");
            var Defaulttext_weightSavedItem = GetAttribute(attributeName_id, weight_id, "value");
            Assert.AreEqual(Weight, Defaulttext_weightSavedItem);

            Report.WriteLine("Verifying the Quantity field is auto filled with saved item information");
            VerifyElementPresent(attributeName_id, Quantity_id, "Quantity");
            var Defaulttext_QuantitySavedItem = GetAttribute(attributeName_id, Quantity_id, "value");
            Assert.AreEqual(Quantity, Defaulttext_QuantitySavedItem);

            Report.WriteLine("Verifying the Quantity Type field is auto filled with saved item information");
            VerifyElementPresent(attributeName_id, QuantityType_id, "QuantityType");
            var Defaulttext_QuantityTypeSavedItem = Gettext(attributeName_xpath, QuantityType_xpath);
            Assert.AreEqual(QuantityType, Defaulttext_QuantityTypeSavedItem);
        }

        [Then(@"All of the auto-filled fields in the Freight Description section should remain editable")]
        public void ThenAllOfTheAuto_FilledFieldsInTheFreightDescriptionSectionShouldRemainEditable()
        {
            Report.WriteLine("Auto-filled Select Class field in the Freight Description section should remain editable");
            Click(attributeName_id, ClassorSavedItemField_id);
            SendKeys(attributeName_xpath, selectclasstextbox_xpath, "7");

            Report.WriteLine("Auto-filled Weight field in the Freight Description section should remain editable");
            Clear(attributeName_id, weight_id);
            SendKeys(attributeName_id, weight_id, "123");

            Report.WriteLine("Auto-filled Quantity field in the Freight Description section should remain editable");
            Clear(attributeName_id, Quantity_id);
            SendKeys(attributeName_id, Quantity_id, "123"); 

            Report.WriteLine("Auto-filled Quantity Type field in the Freight Description section should remain editable");
            Click(attributeName_id, QuantityType_id);
            SendKeys(attributeName_xpath, QuantityTypetextbox_xpath, "B");
        }

    }
}
