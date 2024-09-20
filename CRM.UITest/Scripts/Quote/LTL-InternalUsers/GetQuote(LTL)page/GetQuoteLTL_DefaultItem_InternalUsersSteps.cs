using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;

namespace CRM.UITest
{
    [Binding]
    public class GetQuoteLTL_DefaultItem_InternalUsersSteps:ObjectRepository
    {
        
        [Then(@"Class, Weight, Quantity and QuantityUnit should be autopopulated if the customer has the default items in DB (.*)")]
        public void ThenClassWeightQuantityAndQuantityUnitShouldBeAutopopulatedIfTheCustomerHasTheDefaultItemsInDB(string Customer_Name)
        {
            Report.WriteLine("Items should be auto populated if the customer has the default items");
            GlobalVariables.webDriver.WaitForPageLoad();
            int setupid = DBHelper.GetAccountIdforAccountName(Customer_Name);
            int accountnumber = DBHelper.GetAccountNumber(setupid);
            Item values = DBHelper.GetDefaultItem(accountnumber);
            string ActWeight = GetAttribute(attributeName_id, LTL_Weight_Id, "value");
            Assert.AreEqual(values.Weight.ToString(), ActWeight);
            Report.WriteLine("Displaying Weight in UI" + ActWeight + "is matching with DB value" + values.Weight);
            string ActQuantity = GetAttribute(attributeName_id, LTL_Quantity_Id, "value");
            Assert.AreEqual(values.Quantity.ToString(), ActQuantity);
            Report.WriteLine("Displaying Quanity in UI" + ActQuantity + "is matching with DB value" + values.Quantity);
            string ActQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);

            if (ActQuantityUnit == "Skids")
            {
                Assert.AreEqual(values.QuantityUnit, "SKD");
            }
            else if (ActQuantityUnit == "Bags")
            {
                Assert.AreEqual(values.QuantityUnit, "BAG");
            }
            else if (ActQuantityUnit == "Bundles")
            {
                Assert.AreEqual(values.QuantityUnit, "BDL");
            }
            else if (ActQuantityUnit == "Boxes")
            {
                Assert.AreEqual(values.QuantityUnit, "BOX");
            }
            else if (ActQuantityUnit == "Cabinets")
            {
                Assert.AreEqual(values.QuantityUnit, "CAB");
            }
            else if (ActQuantityUnit == "Cans")
            {
                Assert.AreEqual(values.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Cases")
            {
                Assert.AreEqual(values.QuantityUnit, "CAS");
            }
            else if (ActQuantityUnit == "Crates")
            {
                Assert.AreEqual(values.QuantityUnit, "CRT");
            }
            else if (ActQuantityUnit == "Cartons")
            {
                Assert.AreEqual(values.QuantityUnit, "CTN");
            }
            else if (ActQuantityUnit == "Cylinders")
            {
                Assert.AreEqual(values.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Drums")
            {
                Assert.AreEqual(values.QuantityUnit, "DRM");
            }
            else if (ActQuantityUnit == "Pails")
            {
                Assert.AreEqual(values.QuantityUnit, "PAL");
            }
            else if (ActQuantityUnit == "Pieces")
            {
                Assert.AreEqual(values.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Pallets")
            {
                Assert.AreEqual(values.QuantityUnit, "PLT");
            }
            else if (ActQuantityUnit == "Flat Racks")
            {
                Assert.AreEqual(values.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Reels")
            {
                Assert.AreEqual(values.QuantityUnit, "REL");
            }
            else if (ActQuantityUnit == "Rolls")
            {
                Assert.AreEqual(values.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Slip Sheets")
            {
                Assert.AreEqual(values.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Stacks")
            {
                Assert.AreEqual(values.QuantityUnit, "");
            }
            else
            {
                Assert.AreEqual(values.QuantityUnit, "TBN");
            }   
            Report.WriteLine("Displaying Quanity in UI" + ActQuantityUnit + "is matching with DB value" + values.QuantityUnit);
            GlobalVariables.webDriver.WaitForPageLoad();        
            string Classification_UI = Gettext(attributeName_id, ClassorSavedItemField_id);
            string[] a = Classification_UI.Split(new char[] { ' ' });
            string ActClassification = a[0];
            Assert.AreEqual(values.Classification.ToString(), ActClassification);
            Report.WriteLine("Displaying Classification in UI" + ActClassification + "is matching with DB value" + values.Classification);                       
        }        
        
        [Then(@"All of the fields which are auto populated should remain editable in Freight description section")]
        public void ThenAllOfTheFieldsWhichAreAutoPopulatedShouldRemainEditableInFreightDescriptionSection()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, LTL_ClearItem_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Auto-filled Select Class field in the Freight Description section should remain editable");
            Click(attributeName_id, ClassorSavedItemField_id);            
            SendKeys(attributeName_id, ClassorSavedItemField_id, "7");

            Report.WriteLine("Auto-filled Weight field in the Freight Description section should remain editable");            
            SendKeys(attributeName_id, weight_id, "123");

            Report.WriteLine("Auto-filled Quantity field in the Freight Description section should remain editable");            
            SendKeys(attributeName_id, Quantity_id, "123");

            Report.WriteLine("Auto-filled Quantity Type field in the Freight Description section should remain editable");
            Click(attributeName_id, QuantityType_id);
            SendKeys(attributeName_xpath, QuantityTypetextbox_xpath, "B");
        }
    }
}
