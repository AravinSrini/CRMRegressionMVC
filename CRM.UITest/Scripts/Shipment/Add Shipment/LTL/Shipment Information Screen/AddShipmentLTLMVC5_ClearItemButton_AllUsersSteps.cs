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
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipmentLTLMVC5_ClearItemButton_AllUsersSteps : AddShipments

    {
        [Given(@"I am a DLS user and login into application (.*)")]
        public void GivenIAmADLSUserAndLoginIntoApplication(string usertype)
        {
            if (usertype == "internal")
            {
                string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
                string password = ConfigurationManager.AppSettings["password-AccessRRDUser"].ToString();
                CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
                CrmLogin.LoginToCRMApplication(userName, password);
                Report.WriteLine("I logged into CRM application with RRD access user");
            }
            else
            {
                string userName = ConfigurationManager.AppSettings["username-shpentry"].ToString();
                string password = ConfigurationManager.AppSettings["password-shpentry"].ToString();
                CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
                CrmLogin.LoginToCRMApplication(userName, password);
                Report.WriteLine("I logged into CRM application with RRD access user");
            }
        }
        [When(@"I choose any tms type MG/Both customer (.*) from the customer dropdown in shipment list")]
        public void WhenIChooseAnyTmsTypeMGBothCustomerFromTheCustomerDropdownInShipmentList(string Account)
        {
            Report.WriteLine("Clicking on customer dropdown");
            Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 1; i <= DropDownCount; i++)
            {
                int j = i - 1;
                if (DropDownList[j].Text == "ZZZ - Czar Customer Test")
                {
                    DropDownList[j].Click();
                    break;
                }
            }
        }


        [When(@"I navigate to Add Shipment \(LTL\) page")]
        public void WhenINavigateToAddShipmentLTLPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("NavigateToAddShipmentLandingPage");
            VerifyElementVisible(attributeName_xpath, Addshipment_pageheader_Xpath, "AddShipmentLandingPage");
        }


        [When(@"I have values in Freight Description section (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIHaveValuesInFreightDescriptionSection(string Classification, string Weight, string length, string width, string height, string NMFC, string itemdesc, string quantitytype, string weightype, string UNnumber, string CCN, string hazgroup, string hazclass, string contact, string phone)
        {
            Report.WriteLine("Enter details in item section");
            SendKeys(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "50");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, Weight);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, length);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, width);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, height);
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, NMFC);
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, itemdesc);
            Click(attributeName_xpath, FreightDesp_FirstItem_Hazardous_Yes_RadioButton_xpath);
            SendKeys(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, UNnumber);
            SendKeys(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, CCN);
            Click(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_Values_xpath, hazgroup);
            Click(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_Values_xpath, hazclass);
            SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, contact);
            SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, phone);

        }
        
        [When(@"I click on Clear All button in Freight Description section")]
        public void WhenIClickOnClearAllButtonInFreightDescriptionSection()
        {
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, "frieghtclearbtn-0");
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
           
        }

        [When(@"I Click add Additional item button")]
        public void WhenIClickAddAdditionalItemButton()
        {
            Report.WriteLine("clicked on additional item button");
            scrollElementIntoView(attributeName_xpath, FreightDesp_First_AdditionalItem_Button_xpath);
            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_Button_xpath);
        }

        [When(@"I myself click on add additional item button")]
        public void WhenIMyselfClickOnAddAdditionalItemButton()
        {
            Report.WriteLine("clicked on additional item button");
            scrollElementIntoView(attributeName_xpath, FreightDesp_First_AdditionalItem_Button_xpath);
            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_Button_xpath);
        }

        [When(@"I clicked on add additional item button")]
        public void WhenIClickedOnAddAdditionalItemButton()
        {
            Report.WriteLine("clicked on additional item button");
            scrollElementIntoView(attributeName_xpath, FreightDesp_First_AdditionalItem_Button_xpath);
            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_Button_xpath);
        }

        [When(@"I click on Clear All button in Freight Description section in addition section")]
        public void WhenIClickOnClearAllButtonInFreightDescriptionSectionInAdditionSection()
        {
            Report.WriteLine("clicked on clear button");
            MoveToElement(attributeName_xpath, FreightDesp_First_AdditionalItem_clearbutton_xpath);
            MoveToElementClick(attributeName_xpath, FreightDesp_First_AdditionalItem_clearbutton_xpath);
        }




        [When(@"I passed values in additional item fields (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIPassedValuesInAdditionalItemFields(string Classification, string Weight, string length, string width, string height, string NMFC, string itemdesc, string quantitytype, string weightype, string UNnumber, string CCN, string hazgroup, string hazclass, string contact, string phone)
        {
            Report.WriteLine("Enter details in item section");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id, "50");
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, Weight);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, length);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, width);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, height);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, NMFC);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, itemdesc);
            //scrollElementIntoView(attributeName_xpath, FreightDesp_First_AdditionalItem_Hazardous_Yes_RadioButton_xpath);
            //MoveToElementClick(attributeName_xpath, FreightDesp_First_AdditionalItem_Hazardous_Yes_RadioButton_xpath);
            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_Hazardous_Yes_RadioButton_xpath);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_UN_Number_Id, UNnumber);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_CCN_Number_Id, CCN);
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(4000);
            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatPackageGroup_DownDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatPackageGroup_DownDown_Values_xpath, hazgroup);
            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatClass_DropwDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatClass_DropwDown_Values_xpath, hazclass);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_EmergencyReponseContactName_Id, contact);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_EmergencyReponsePhoneNumber_Id, phone);
        }
        
        [Then(@"Select or search for a class or saved items,Enter an NMFC,Enter a description,Enter a quantity,Enter a weight,Dimension fields should be cleared")]
        public void ThenSelectOrSearchForAClassOrSavedItemsEnterAnNMFCEnterADescriptionEnterAQuantityEnterAWeightDimensionFieldsShouldBeCleared()
        {
            string saveditem_class=Gettext(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Assert.AreEqual(saveditem_class, "");
            string NMFC = Gettext(attributeName_id, FreightDesp_FirstItem_NMFC_Id);
             Assert.AreEqual(NMFC, "");
            string ItemDescription = Gettext(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id);
            Assert.AreEqual(ItemDescription, "");
            string Quantity = Gettext(attributeName_id, FreightDesp_FirstItem_Quantity_Id);
            Assert.AreEqual(Quantity, "");
            string Weight = Gettext(attributeName_id, FreightDesp_FirstItem_Weight_Id);
            Assert.AreEqual(Weight, "");
            string Length = Gettext(attributeName_id, FreightDesp_FirstItem_Length_Id);
            Assert.AreEqual(Length, "");
            string Width = Gettext(attributeName_id, FreightDesp_FirstItem_Width_Id);
            Assert.AreEqual(Width, "");
            string Height = Gettext(attributeName_id, FreightDesp_FirstItem_Height_Id);
            Assert.AreEqual(Height, "");

        }

        [Then(@"Weight type should be defaulted to LBS")]
        public void ThenWeightTypeShouldBeDefaultedToLBS()
        {
            Report.WriteLine("Weight type should be defaulted to LBS");
            string weightype = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
            Assert.AreEqual(weightype, "LBS");
            
        }

        [Then(@"Weight type should be defaulted to LBS in additional section")]
        public void ThenWeightTypeShouldBeDefaultedToLBSInAdditionalSection()
        {
            Report.WriteLine("Weight type should be defaulted to LBS");
            string weightype = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_WeightType_xpath);
            Assert.AreEqual(weightype, "LBS");
        }


        [Then(@"Hazardous Materials selection defaulted No in additional section")]
        public void ThenHazardousMaterialsSelectionDefaultedNoInAdditionalSection()
        {
            Report.WriteLine("Hazardous Materials selection defaulted No");
            MoveToElement(attributeName_xpath, FreightDesp_First_AdditionalItem_Hazardous_No_RadioButton_xpath);
            VerifyElementChecked(attributeName_xpath, ".//*[@id='1']/div/div[4]/div/div/div/div/div/div[1]/div[2]/input", "radiobuttoncheck");
        }

        [Then(@"Dimension type drop down defaulted to IN in additional section")]
        public void ThenDimensionTypeDropDownDefaultedToINInAdditionalSection()
        {
            Report.WriteLine("Dimension type drop down defaulted to IN");
            string weightype = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_DimensionType_xpath);
            Assert.AreEqual(weightype, "IN");
        }



        [Then(@"Hazardous Materials selection defaulted No")]
        public void ThenHazardousMaterialsSelectionDefaultedNo()
        {
            Report.WriteLine("Hazardous Materials selection defaulted No");
            MoveToElement(attributeName_xpath, FreightDesp_FirstItem_Hazardous_No_RadioButton_xpath);
            VerifyElementChecked(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[4]/div[4]/div/div[1]/div/div/div/div/div[2]/input", "radiobuttoncheck");
           
        }
        
        [Then(@"Dimension type drop down defaulted to IN")]
        public void ThenDimensionTypeDropDownDefaultedToIN()
        {
            Report.WriteLine("Dimension type drop down defaulted to IN");
            string weightype = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            Assert.AreEqual(weightype, "IN");
        }

        [Then(@"Select or search for a class or saved items,Enter an NMFC,Enter a description,Enter a quantity,Enter a weight,Dimension fields should be cleared in additional section")]
        public void ThenSelectOrSearchForAClassOrSavedItemsEnterAnNMFCEnterADescriptionEnterAQuantityEnterAWeightDimensionFieldsShouldBeClearedInAdditionalSection()
        {
            string saveditem_class=Gettext(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id);
            Assert.AreEqual(saveditem_class, "");
            string NMFC = Gettext(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id);
            Assert.AreEqual(NMFC, "");
            string ItemDescription = Gettext(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id);
            Assert.AreEqual(ItemDescription, "");
            string Quantity = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath);
            Assert.AreEqual(Quantity, "");
            string Weight = Gettext(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id);
            Assert.AreEqual(Weight, "");
            string Length = Gettext(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id);
            Assert.AreEqual(Length, "");
            string Width = Gettext(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id);
            Assert.AreEqual(Width, "");
            string Height = Gettext(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id);
            Assert.AreEqual(Height, "");

        }

    }
}
