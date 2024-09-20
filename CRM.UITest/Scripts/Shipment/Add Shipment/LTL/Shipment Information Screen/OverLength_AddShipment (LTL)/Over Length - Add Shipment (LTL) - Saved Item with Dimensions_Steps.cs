using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen.OverLength_AddShipment__LTL_
{
    [Binding]
    public  class Over_Length___Add_Shipment__LTL____Saved_Item_with_Dimensions_Steps : AddShipments
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        public string Dimensions;
        public string DefaultCheck_CM_Meter;
        public string SelectCheck_CM_Meter;
        public string CustomerName = "ZZZ - Czar Customer Test";
        Item itemDB;


        [Given(@"I am a shp\.entry, shp\.entrynorates, sales, sales management, operations and station owner user")]
        public void GivenIAmAShp_EntryShp_EntrynoratesSalesSalesManagementOperationsAndStationOwnerUser()
        {
            string Username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string Password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CrmLogin.LoginToCRMApplication(Username, Password);
        }

        [Given(@"I am on the Add Shipment \(LTL\) page")]
        public void GivenIAmOnTheAddShipmentLTLPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, CustomerName);
            Click(attributeName_id, AddShipmentButtionInternal_Id);
            Click(attributeName_id, AddShipmentLTL_Button_Id);
        }

        

        [When(@"I have selected a saved item of dimension type with values of following (.*) : CM or Meter")]
        public void WhenIHaveSelectedASavedItemOfDimensionTypeWithValuesOfFollowingCMOrMeter(string dimension)
        {

            Dimensions = dimension;
            if (dimension == "CM")
            {  
                CrmLogin.SavedItemDimension_CM_Meter(CustomerName, "CM");
                SelectCheck_CM_Meter = CrmLogin.SelectionCheck_CMorMeter;

            }

            else if(dimension == "METER")
            {
               
                CrmLogin.SavedItemDimension_CM_Meter(CustomerName, "METER");
                SelectCheck_CM_Meter = CrmLogin.SelectionCheck_CMorMeter;

            }
        }

        [Then(@"The following dimension fields will be blank: Length, width, Height")]
        public void ThenTheFollowingDimensionFieldsWillBeBlankLengthWidthHeight()
        {
            
            if (Dimensions == "CM" || Dimensions == "METER")
            {
                if (SelectCheck_CM_Meter != null)
                {
                    Report.WriteLine("Dimension field will be blank : Length, width, Height");
                    string Length1 = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
                    Assert.AreEqual(Length1, string.Empty);
                    string Width1 = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
                    Assert.AreEqual(Width1, string.Empty);
                    string Height1 = GetAttribute(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
                    Assert.AreEqual(Height1, string.Empty);
                }
                else
                {
                    Report.WriteLine("No Record Found");

                }
            }        
            else 
            {
                if(DefaultCheck_CM_Meter != null)
                {
                    Report.WriteLine("Dimension field will be blank : Length, width, Height");
                    string Length = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
                    Assert.AreEqual(Length, string.Empty);
                    string Width = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
                    Assert.AreEqual(Width, string.Empty);
                    string Height = GetAttribute(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
                    Assert.AreEqual(Height, string.Empty);
                }
                else
                {
                    Report.WriteLine("No Record Found");
                }
                
            }
            

        }


        [Then(@"The dimension type will be defaulted to - IN")]
        public void ThenTheDimensionTypeWillBeDefaultedTo_IN()
        {

            if (Dimensions == "CM" || Dimensions  == "METER")
            {
                if (SelectCheck_CM_Meter != null)
                {
                    Report.WriteLine("Dimension Type will be Defaulted to IN");
                    string Actual_DimensionType = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
                    Assert.AreEqual("IN", Actual_DimensionType);
                }
                else
                {
                    Report.WriteLine("No record found");
                }
            }
            else
            {
                if (DefaultCheck_CM_Meter != null)
                {
                    Report.WriteLine("Dimension Type will be Defaulted to IN");
                    string Actual_DimensionType = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
                    Assert.AreEqual("IN", Actual_DimensionType);
                }
                else
                {
                    Report.WriteLine("No record found");
                }
            }
        }

        [When(@"The customer has a default item of dimensions type with values of following (.*) : CM or Meter")]
        public void WhenTheCustomerHasADefaultItemOfDimensionsTypeWithValuesOfFollowingCMOrMeter(string dimension)
        {
            if (dimension == "CM")
            {
               
                CrmLogin.DefaultItemDimension_CM_Meter(CustomerName, dimension);
                DefaultCheck_CM_Meter = CrmLogin.DefaultCheck_CMandMeter;

            }

            else if (dimension == "METER")
            {
                
                CrmLogin.DefaultItemDimension_CM_Meter(CustomerName, dimension);
                DefaultCheck_CM_Meter = CrmLogin.DefaultCheck_CMandMeter;
            }

        }

        [When(@"I have selected a saved item of dimension type of (.*) values")]
        public void WhenIHaveSelectedASavedItemOfDimensionTypeOfValues(string dimensionType)
        {
            Report.WriteLine("I have selected a saved item included dimension and dimension type(.*) values");
            string DimensionType = Regex.Replace(dimensionType, @"(\s+|&|'|\(|\)|<|>|#)", "");
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            itemDB = DBHelper.GetItemDetailsBasedDimension(CustomerName, DimensionType);
            if (itemDB == null)
            {
                Report.WriteFailure("No record is available for for demensionType " + dimensionType);
            }
            else
            {
                Report.WriteLine("Entering a search criteria in item dropdown");
                string itemDescription = itemDB.Classification + " " + itemDB.ItemDescription;
                Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
              
                //Thread.Sleep(5000);
                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(FreightDesp_FirstItem_SavedClassItem_DropDown_Values_xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text.ToLower() == itemDescription.ToLower())
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
            }



            

        }


        [Then(@"Length, Width, Height dimension fields will get bind and dimension type should be (.*) type")]
        public void ThenLengthWidthHeightDimensionFieldsWillGetBindAndDimensionTypeShouldBeType(string dimensionType)
        {
            if (itemDB == null)
            {
                Report.WriteFailure("No record is available for for demensionType " + dimensionType);
            }
            else
            {
                string DimensionType = Regex.Replace(dimensionType, @"(\s+|&|'|\(|\)|<|>|#)", "");
                if (itemDB.DimensionUnit == DimensionType)
                {
                    
                    string Actual_DimensionType = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
                    Assert.AreEqual(DimensionType, Actual_DimensionType);
                    double length = Convert.ToDouble(itemDB.Length);
                    double DBLength = Math.Floor(length);

                    double width = Convert.ToDouble(itemDB.Width);
                    double DBWidth = Math.Floor(width);

                    double height = Convert.ToDouble(itemDB.Height);
                    double DBHeight = Math.Floor(height);

                    Report.WriteLine("the Length,Width,Height,Dimension type dimension fields will get bind");

                    string itemLengthUI = GetValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");

                        if (itemDB.Length != null && itemDB.Length > 0)
                        {
                            Assert.AreEqual(DBLength.ToString(), itemLengthUI);
                        }
                        else
                        {
                            Assert.AreEqual(string.Empty, itemLengthUI);
                        }

                        string itemWidthUI = GetValue(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
                        if (itemDB.Width != null && itemDB.Width > 0)
                        {

                            Assert.AreEqual(DBWidth.ToString(), itemWidthUI);
                        }
                        else
                        {
                            Assert.AreEqual(string.Empty, itemWidthUI);
                        }

                        string itemHeightUI = GetValue(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
                        if (itemDB.Height != null && itemDB.Height > 0)
                        {

                            Assert.AreEqual(DBHeight.ToString(), itemHeightUI);
                        }
                        else
                        {
                            Assert.AreEqual(string.Empty, itemHeightUI);
                        }
                    }
                    else
                    {
                        Report.WriteLine("the dimension type of the saved item is not" + DimensionType);
                    }
                
            }
        }


        [When(@"the customer has a default item of dimensions type of (.*) values")]
        public void WhenTheCustomerHasADefaultItemOfDimensionsTypeOfValues(string dimensionType)
        {
            Report.WriteLine("the customer has a default item included dimensions and dimension type(.*) values");
            string DimensionType = Regex.Replace(dimensionType, @"(\s+|&|'|\(|\)|<|>|#)", "");
            itemDB = DBHelper.GetDefaultItemDetailsBasedDimension(CustomerName);
        }




    }
}
