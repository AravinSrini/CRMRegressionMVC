using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using System.Collections.Generic;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Rrd.ServiceAccessLayer;
using System;
using System.Threading;
using CRM.UITest.Entities.Proxy;


namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class RateRequestAddQuantityParametersInLTLQuoteProcessBindingQuantityFields_DesktopSteps : ObjectRepository
    {
        [Then(@"selected item data Quantity and Quantity Unit Field should be populated in the respective fields for the (.*),(.*)")]
        public void ThenSelectedItemDataQuantityAndQuantityUnitFieldShouldBePopulatedInTheRespectiveFieldsForThe(string Username, string ItemDescription)
        {
            string ActualQuantity = GetValue(attributeName_id, LTL_Quantity_Id, "value");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            string setupID = IDP.GetClaimValue(Username, "dlscrm-CustomerSetUpId");
            int value = Convert.ToInt32(setupID);
            int AccNumb = DBHelper.GetAccountNumber(value);
            Item ItemValue = DBHelper.GetItemDetails(AccNumb, ItemDescription);
            string quantity = null;
            Report.WriteLine("Verifying displaying Quantity and Quantity Unit details with db values");

            switch (ItemValue.QuantityUnit.ToString())
            {
                case "BAG":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Bags");
                        break;
                    }

                case "BDL":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Bundles");
                        break;
                    }
                case "BOX":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Boxes");
                        break;
                    }
                case "CAB":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Canbinets");
                        break;
                    }
                case "CAN":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Cans");
                        break;
                    }
                case "CAS":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Cases");
                        break;
                    }
                case "SKD":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Skids");
                        break;
                    }
                case "PLT":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Pallets");
                        break;
                    }
                case "ROL":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Rolls");
                        break;
                    }
                case "SLP":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Slip Sheets");
                        break;
                    }

                case "DRM":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Drums");
                        break;
                    }
            }
            quantity = ItemValue.Quantity == null ? string.Empty : ItemValue.Quantity.ToString();
            Assert.AreEqual(ActualQuantity, quantity);
        }

        [Then(@"No data populated to the Quantity field also the Quantity Unit Fields to be set to match with Database (.*),(.*)")]
        public void ThenNoDataPopulatedToTheQuantityFieldAlsoTheQuantityUnitFieldsToBeMatchWithDatabase(string Username, string ItemDescription)
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            string setupID = IDP.GetClaimValue(Username, "dlscrm-CustomerSetUpId");
            int value = Convert.ToInt32(setupID);
            int AccNumb = DBHelper.GetAccountNumber(value);
            Item ItemValue = DBHelper.GetItemDetails(AccNumb, ItemDescription);

            Report.WriteLine("Verifying displaying Quantity and Quantity Unit details with db values");
            string ActualQuantity = GetValue(attributeName_id, LTL_Quantity_Id, "value");
            Assert.AreEqual(ActualQuantity, ItemValue.Quantity.ToString());

            switch (ItemValue.QuantityUnit)
            {

                case "PLT":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Pallets");
                        break;
                    }

                case "BAG":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Bags");
                        break;
                    }

                case "BDL":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Bundles");
                        break;
                    }
                case "BOX":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Boxes");
                        break;
                    }
                case "CAB":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Canbinets");
                        break;
                    }
                case "CAN":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Cans");
                        break;
                    }
                case "CAS":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Cases");
                        break;
                    }
                case "SKD":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Skids");
                        break;
                    }

                case "ROL":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Rolls");
                        break;
                    }
                case "SLP":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Slip Sheets");
                        break;
                    }

                case "DRM":
                    {
                        string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
                        Assert.AreEqual(ActualQuantityUnit, "Drums");
                        break;
                    }
            }

        }


        [Then(@"another set of Quantity and Quantity Unit Fields should be populated")]
        public void ThenAnotherSetOfQuantityAndQuantityUnitFieldsShouldBePopulated()
        {
            scrollpagedown();
            WaitForElementVisible(attributeName_id, LTL_AdditionalQuantity_Id, "Additional Quantity field");
            WaitForElementVisible(attributeName_xpath, LTL_AdditionalQuantityunit_Xpath, "Additional Quantity Unit fields");
        }

        [When(@"click on remove item")]
        public void WhenClickOnRemoveItem()
        {
            scrollpagedown();
            scrollpagedown();
            MoveToElementClick(attributeName_xpath, LTL_RemoveItem_Xpath);
        }

        [Then(@"another set of Quantity and Quantity Unit Fields should disappear")]
        public void ThenAnotherSetOfQuantityAndQuantityUnitFieldsShouldDisappear()
        {
            //scrollpagedown();
            Thread.Sleep(1000);
            VerifyElementNotPresent(attributeName_id, LTL_AdditionalQuantity_Id, "Additional Quantity field");
            VerifyElementNotPresent(attributeName_xpath, LTL_AdditionalQuantityunit_Xpath, "Additional Quantity Unit fields");
        }


        [When(@"I pass (.*), (.*), (.*), (.*), (.*)")]
        public void WhenIPass(string Length, string Width, string Height, string Weight, string Quantity)
        {
            scrollpagedown();
            Report.WriteLine("Passing data in esitmated class lookup Modal");
            WaitForElementVisible(attributeName_id, LTL_EstimateClass_Length_Id, "Estimate Lookup");
            SendKeys(attributeName_id, LTL_EstimateClass_Length_Id, Length);
            SendKeys(attributeName_id, LTL_EstimateClass_Width_Id, Width);
            SendKeys(attributeName_id, LTL_EstimateClass_Height_Id, Height);
            SendKeys(attributeName_id, LTL_EstimateClass_Weight_Id, Weight);
            SendKeys(attributeName_id, LTL_EstimateClass_Quantity_Id, Quantity);
            Click(attributeName_id, LTL_EstimateClass_TableLink_Id);
        }

        [Then(@"pop-up model should be closed and passed data of Quantity and default content of UOM field should populate (.*), (.*)")]
        public void ThenPop_UpModelShouldBeClosedAndPassedDataOfQuantityAndDefaultContentOfUOMFieldShouldPopulate(string Quantity, string QuantityUnit)
        {
            scrollpagedown();
            scrollpagedown();
            //WaitForElementVisible(attributeName_id, LTL_AdditionalQuantity_Id, "Additional Quantity field");
            Report.WriteLine("Verifying displaying Quantity and Quantity Unit default value as Skids");
            string ActualQuantity = GetValue(attributeName_id, LTL_Quantity_Id, "value");
            Assert.AreEqual(ActualQuantity, Quantity);


            string ActualQuantityUnit = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
            Assert.AreEqual(ActualQuantityUnit, QuantityUnit);
        }

        [Then(@"Additional Quantity text appears above the Quantity textbox (.*)")]
        public void ThenAdditionalQuantityTextAppearsAboveTheQuantityTextbox(string QuantityLabel)
        {
            scrollpagedown();
            Report.WriteLine("Verify the Quantity Label above Quanityt Textbox");
            string QuantityLabel_UI = Gettext(attributeName_xpath, LTL_AdditionalQuantity_Label);
            Assert.AreEqual(QuantityLabel_UI, QuantityLabel);

        }

        [Then(@"I should be able to verify the maximum character limits Quantity textbox")]
        public void ThenIShouldBeAbleToVerifyTheMaximumCharacterLimitsQuantityTextbox()
        {
            string ActualQuantityChar = GetValue(attributeName_id, LTL_AdditionalQuantity_Id, "maxlength");
            Assert.AreEqual(ActualQuantityChar, "3");

        }

        [Then(@"I should be able to see default Quantity field (.*)")]
        public void ThenIShouldBeAbleToSeeDefaultQuantityField(string DefaultQuantityUnit)
        {
            string ActualQuantityUnitField_UI = Gettext(attributeName_xpath, LTL_AdditionalQuantityunit_Xpath);
            Assert.AreEqual(ActualQuantityUnitField_UI, DefaultQuantityUnit);
        }
    }
}
