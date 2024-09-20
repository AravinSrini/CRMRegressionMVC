using CRM.UITest.CommonMethods;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest
{
    [Binding]
    public class AddShipmentLTLMVC5_AddAdditionalItem_AllUsersSteps : AddShipments
    {


        [When(@"I click on view rates button")]
        public void WhenIClickOnViewRatesButton()
        {
            Report.WriteLine("ClickOnViewRatesButton");
            scrollpagedown();
            Click(attributeName_xpath, Shipments_ViewRatesButton_xpath);

        }

        [Then(@"I should displayed with class or saved item field in additional item section")]
        public void ThenIShouldDisplayedWithClassOrSavedItemFieldInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWithClassOrSavedItemFieldInAdditionalItemSection");
            VerifyElementVisible(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id, "SavedClassItem");
        }

        [Then(@"I should be displayed with NMFC field in additional item section")]
        public void ThenIShouldBeDisplayedWithNMFCFieldInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWithNMFC field in additional item section");
            VerifyElementVisible(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "NMFC");
        }

        [Then(@"I should be displayed with Item Description field in additional item section")]
        public void ThenIShouldBeDisplayedWithItemDescriptionFieldInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWithItemDescriptionField in additional item section");
            VerifyElementVisible(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "ItemDescription");
        }

        [Then(@"I should be displayed with quantity field in additional item section")]
        public void ThenIShouldBeDisplayedWithQuantityFieldInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWithQuantityField in additional item section");
            VerifyElementVisible(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "QuantityField");
        }

        [Then(@"I should be Quantity type drop down selector in additional item section")]
        public void ThenIShouldBeQuantityTypeDropDownSelectorInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWithQuantitydropdownField in additional item section");
            VerifyElementVisible(attributeName_xpath, FreightDesp_First_AdditionalItem_QuantityType_xpath, "QuantitydropdownField");
        }

        [Then(@"I should displayed with Enter a weight field in additional item section")]
        public void ThenIShouldDisplayedWithEnterAWeightFieldInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWithweightField in additional item section");
            VerifyElementVisible(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "weight");
        }

        [Then(@"I should be displayed with Weight type drop down selector in additional item section")]
        public void ThenIShouldBeDisplayedWithWeightTypeDropDownSelectorInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWithweighttypeField in additional item section");
            VerifyElementVisible(attributeName_xpath, FreightDesp_First_AdditionalItem_WeightType_xpath, "weighttype");
        }

        [Then(@"I should be displayed with Estimate Class button in additional item section")]
        public void ThenIShouldBeDisplayedWithEstimateClassButtonInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWithweighttypeField in additional item section");
            VerifyElementVisible(attributeName_xpath, FreightDesp_First_AdditionalItem_WeightType_xpath, "weighttype");
        }

        [Then(@"I should be displayed with Hazardous Materials radio buttons in additional item section")]
        public void ThenIShouldBeDisplayedWithHazardousMaterialsRadioButtonsInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWith HazardousMaterialsRadioButtons in additional item section");
            VerifyElementVisible(attributeName_xpath, FreightDesp_First_AdditionalItem_Hazardous_Yes_RadioButton_xpath, "yes");
            VerifyElementVisible(attributeName_xpath, ".//*[@id='1']/div/div[4]/div/div/div/div/div/div[1]/div[2]/label", "no");
        }

        [Then(@"I should be displayed with Length field in additional item section")]
        public void ThenIShouldBeDisplayedWithLengthFieldInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWith length Field in additional item section");
            VerifyElementVisible(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "length");
        }

        [Then(@"I should be displayed with Width field in additional item section")]
        public void ThenIShouldBeDisplayedWithWidthFieldInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWith width Field in additional item section");
            VerifyElementVisible(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "Width");
        }

        [Then(@"I should be displayed with Height field in additional item section")]
        public void ThenIShouldBeDisplayedWithHeightFieldInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWith height Field in additional item section");
            VerifyElementVisible(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "height");
        }

        [Then(@"I should be displayed with Dimension type drop down selector in additional item section")]
        public void ThenIShouldBeDisplayedWithDimensionTypeDropDownSelectorInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWithDimensionTypeDropDown in additional item section");
            VerifyElementVisible(attributeName_xpath, FreightDesp_First_AdditionalItem_DimensionType_xpath, "demensiontype");
        }

        [Then(@"I should be displayed with Add Additional Item button in additional item section")]
        public void ThenIShouldBeDisplayedWithAddAdditionalItemButtonInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWithAddAdditionalItemButton in additional item section");
            VerifyElementVisible(attributeName_xpath, FreightDesp_First_AdditionalItem_Button_xpath, "AdditionalItemButton");
        }

        [Then(@"I should be displayed with Remove Item button in additional item section")]
        public void ThenIShouldBeDisplayedWithRemoveItemButtonInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWithremovebuttonField in additional item section");
            VerifyElementVisible(attributeName_xpath, FreightDesp_First_Remove_Button_xpath, "remove");
        }

        [Then(@"I should be displayed with Clear Item button in additional item section")]
        public void ThenIShouldBeDisplayedWithClearItemButtonInAdditionalItemSection()
        {
            Report.WriteLine("DisplayedWithClearItemButton in additional item section");
            VerifyElementVisible(attributeName_id, FreightDesp_First_AdditionalItem_ClearItem_Button_Id, "clearitem");
        }

        [Then(@"Quantity type defaulted to Skids")]
        public void ThenQuantityTypeDefaultedToSkids()
        {
            Report.WriteLine("Weight type should be defaulted to skids");
            string weightype = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_QuantityType_xpath);
            Assert.AreEqual(weightype, "Skids");
        }

        [Then(@"Weight type dropdown have '(.*)'")]
        public void ThenWeightTypeDropdownHave(string WTvalues)
        {

            string[] values = WTvalues.Split(',');
            Click(attributeName_xpath, ".//*[@id='freightweighttype_1_chosen']/a");
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='freightweighttype_1_chosen']/div/ul/li"));
            List <string> ExpectedVal = new List<string>();

            foreach (var v in values)
            {
                
                ExpectedVal.Add(v);
            }
            Assert.AreEqual(ExpectedVal.Count, UIValues.Count);
            for (int i = 0; i < UIValues.Count; i++)
            {
                if (ExpectedVal.Contains(UIValues[i].Text))
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under view dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under view dropdown is not expected");
                    Assert.IsTrue(false);
                }
            }

        }
        [Then(@"Dimension type dropdown '(.*)'")]
        public void ThenDimensionTypeDropdown(string dimvalues)
        {

            string[] values = dimvalues.Split(',');
            Click(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id);
            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_DimensionType_xpath);
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='freightdimensiontype_1_chosen']/div/ul/li"));
            List<string> ExpectedVal = new List<string>();

            foreach (var v in values)
            {
                ExpectedVal.Add(v);
            }
            Assert.AreEqual(ExpectedVal.Count, UIValues.Count);
            for (int i = 0; i < UIValues.Count; i++)
            {
                if (ExpectedVal.Contains(UIValues[i].Text))
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under view dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under view dropdown is not expected");
                    Assert.IsTrue(false);
                }
            }
           
        }

        [Then(@"saved item, Item Description, quantity field, Quantity type drop down selector, Enter a weight fields should highlight")]
        public void ThenSavedItemItemDescriptionQuantityFieldQuantityTypeDropDownSelectorEnterAWeightFieldsShouldHighlight()
        {
            Report.WriteLine("All the Required fields should be highlight in the pink color");
            var colorofthesaveditem = GetCSSValue(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id, "background");
            MoveToElement(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id);
            Thread.Sleep(1000);
            var coloroftheDescription = GetCSSValue(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "background");
            MoveToElement(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath);
            var colorofthequantity = GetCSSValue(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "background");
            var coloroftheweight = GetCSSValue(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "background");

            if (coloroftheDescription.Contains("linear-gradient(rgb(251, 236, 236)") && colorofthequantity.Contains("linear-gradient(rgb(251, 236, 236)") && coloroftheweight.Contains("linear-gradient(rgb(251, 236, 236)") && colorofthesaveditem.Contains("linear-gradient(rgb(251, 236, 236)"))
            {
                Report.WriteLine("SavedItemItemDescriptionQuantityFieldQuantityTypeDropDownSelectorEnterAWeightFieldsShouldHighlight");

            }
            else
            {
                throw new Exception("failed the validation");


            }
        }

        [When(@"I Clicked on view rates Button")]
        public void WhenIClickedOnViewRatesButton()
        {
            scrollpagedown();
            Click(attributeName_xpath, ViewRatesButton_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am a external user and login with (.*) and (.*)")]
        public void GivenIAmExternalUserAndLoginWith(string Username, string Password)
        {
            string username = Username;
            string password = Password;
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }
    }
}
