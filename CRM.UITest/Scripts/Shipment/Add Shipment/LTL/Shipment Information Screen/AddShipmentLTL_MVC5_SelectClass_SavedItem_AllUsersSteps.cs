using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.UITest.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using OpenQA.Selenium;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipmentLTL_MVC5_SelectClass_SavedItem_AllUsersSteps:AddShipments
    {        
        List<string> ListofClassesandItems_UI = new List<string>();
        List<string> ListofClasses_UI = new List<string>();
        List<string> ListofSavedItems_UI = new List<string>();
        List<string> listofclassesinSavedItems = new List<string>();
        List<string> listofItemDescinSavedItems = new List<string>();

        [When(@"I click on the Select Class field under Freight Description")]
        public void WhenIClickOnTheSelectClassFieldUnderFreightDescription()
        {
            Report.WriteLine("I click on the Select Class field");
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Thread.Sleep(1000);
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
        }

        [When(@"I select value (.*) from the Select class dropdown")]
        public void WhenISelectValueFromTheSelectClassDropdown(string SaveItem)
        {
            Report.WriteLine("I select saved item then the saved item should auto-fill in the Select Class field");
            scrollpagedown();
            scrollpagedown();
            Thread.Sleep(1000);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
            for (int i = 0; i < dropdownValues.Count; i++)
            {
                int z = i + 1;
                string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Text;
                if (value == SaveItem)
                {
                    GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Click();
                    break;
                }
            }
        }

        [Then(@"number of items displaying for the (.*) in the saveditem dropdown should be matching with database")]
        public void ThenNumberOfItemsDisplayingForTheInTheSaveditemDropdownShouldBeMatchingWithDatabase(string Customer_Name)
        {
            int setupid = DBHelper.GetAccountIdforAccountName(Customer_Name);
            int accountnumber = DBHelper.GetAccountNumber(setupid);
            int ExpectedCount = DBHelper.GetItemsforAccount(accountnumber).Count;
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "");
            IList<IWebElement> ListofClassesandItems1_UI = GlobalVariables.webDriver.FindElements(By.XPath(FreightDesp_FirstItem_SavedClassItem_DropDown_Values_xpath));
            List<string> validat = new List<string>();
            foreach (IWebElement element in ListofClassesandItems1_UI)
            {
                validat.Add(element.Text.ToString());
            }

            int IndexOf500 = validat.FindIndex(x => x == "500");
            var ListofOptionsCount = ListofClassesandItems1_UI.Count;
            List<string> ListofSavedItems_UI = new List<string>();
            for (int i = IndexOf500 + 1; i < ListofOptionsCount; i++)
            {
                ListofSavedItems_UI.Add(ListofClassesandItems1_UI[i].Text);
            }
            int ActualCount = ListofSavedItems_UI.Count;
            Assert.AreEqual(ExpectedCount, ActualCount-18);
        }

        [Then(@"The saved items must be listed after the classes in numeric followed by alphabetical order with Class and Item Description")]
        public void ThenTheSavedItemsMustBeListedAfterTheClassesInNumericFollowedByAlphabeticalOrderWithClassAndItemDescription()
        {
            Report.WriteLine("I must see the list of classes in the Select Class field should be in numerical order");
            bool ExpectedClassPresent = false;
            bool EachClassPresentonlyOnce = false;
            double[] ExpectedClasses = { 50, 55, 60, 65, 70, 77.5, 85, 92.5, 100, 110, 125, 150, 175, 200, 250, 300, 400, 500 };
            bool SavedItemsPresent = false;
            bool SavedItemsListDisplayafterClassesList = false;
            bool SavedItemsPresentonlyOnce = false;
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            Thread.Sleep(1000);
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "");
            IList<IWebElement> ListofClassesandItems_UI = GlobalVariables.webDriver.FindElements(By.XPath(FreightDesp_FirstItem_SavedClassItem_DropDown_Values_xpath));
                        
            List<string> validat = new List<string>();
            foreach (IWebElement element in ListofClassesandItems_UI)
            {
                validat.Add(element.Text.ToString());
            }

            var ListofOptionsCount = ListofClassesandItems_UI.Count();
            
            int IndexOf50 = validat.FindIndex(x => x == "50");
            int IndexOf500 = validat.FindIndex(x => x == "500");

            for (int i = IndexOf50; i <= IndexOf500; i++)
            {
                ListofClasses_UI.Add(ListofClassesandItems_UI[i].Text);
            }

            //Compare the List of classes displayed in UI with expected list

            foreach (double Class in ExpectedClasses)
            {
                if (ListofClasses_UI.Contains(Class.ToString()))
                {
                    Report.WriteLine(Class + " Class is present in UI");
                    ExpectedClassPresent = true;
                    Assert.IsTrue(ExpectedClassPresent);
                    if (ListofClasses_UI.Where(x => x == Class.ToString()).Count() <= 1)
                    {
                        Report.WriteLine(Class + " Class is present in UI for one time");
                        EachClassPresentonlyOnce = true;
                    }
                    Assert.IsTrue(EachClassPresentonlyOnce);
                }
                else
                {
                    throw new Exception("Matching not found for " + Class);
                }
            }

            //Verifying list of classes in numerical order
            Report.WriteLine("List of Classes is in numerical order");
            for (int i = 0; i <= 17; i++)
            {
                Assert.AreEqual(ListofClasses_UI[i].ToString(), ExpectedClasses[i].ToString());
            }
            Report.WriteLine("I must see the List of saved items displayed after the list of classes");
            //Finding how many saved items in the list of drop down options

            var SavedItemsCount = ListofOptionsCount - (IndexOf500 + 1);

            if (IndexOf50 == 0 && IndexOf500 == 17 && SavedItemsCount >= 1)
            {
                SavedItemsPresent = true;
                Assert.IsTrue(SavedItemsPresent);
                SavedItemsListDisplayafterClassesList = true;
                Assert.IsTrue(SavedItemsListDisplayafterClassesList);

                Report.WriteLine(SavedItemsCount + "Saved Items Present in the list");
                for (int i = IndexOf500 + 1; i < ListofOptionsCount; i++)
                {
                    ListofSavedItems_UI.Add(ListofClassesandItems_UI[i].Text);
                }

                //Verifying Saved Items present in the List of drop down values

                foreach (string SavedItem in ListofSavedItems_UI)
                {
                    Report.WriteLine(SavedItem + " SavedItem is present in UI");
                    if (ListofSavedItems_UI.Where(x => x == SavedItem.ToString()).Count() <= 1)
                    {
                        Report.WriteLine(SavedItem + " SavedItem is present in UI for one time");
                        SavedItemsPresentonlyOnce = true;
                    }
                    Assert.IsTrue(SavedItemsPresentonlyOnce);
                }
            }
            else
            {
                Report.WriteLine("There is no saved Items in the list");
            }

            Report.WriteLine("I must see the list of saved items should be display as Class and Item Description");
            foreach (string SavedItem in ListofSavedItems_UI)
            {
                List<string> secondRow = new List<string>(SavedItem.Split(' '));
                if (ListofClasses_UI.Contains(secondRow[0].ToString()))
                {
                    Report.WriteLine("Saved Item display as: Class " + secondRow[0] + "+ Item Description");
                }
                else
                {
                    throw new Exception("Saved Item not display as Class + Item Description ");
                }
            }

            Report.WriteLine("I must see the  list of classes in the Select Class field should be in numeric, then alphabetical order");

            
            var count = 0;
            foreach (string SavedItem in ListofSavedItems_UI)
            {
                List<string> secondRow = new List<string>(SavedItem.Split(' '));

                listofclassesinSavedItems.Add(secondRow[0]);
                count = listofclassesinSavedItems.Count();
                listofItemDescinSavedItems.Add(secondRow[1]);
            }

            //Sorting the Classes in the Saved Items List
            List<String> SortedClassesList = new List<String>();
            foreach (string classes in listofclassesinSavedItems)
            {
                SortedClassesList.Add(classes);
            }

            //Verifying list of classes in numerical order
            Report.WriteLine("List of Classes is in numerical order");
            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(SortedClassesList[i].ToString(), listofclassesinSavedItems[i].ToString());
                Report.WriteLine(SortedClassesList[i] + " equals " + listofclassesinSavedItems[i]);
            }

            //Sorting the Classes in the Saved Items List
            List<String> SortedItemDescriptionList = new List<String>();
            foreach (string Items in listofItemDescinSavedItems)
            {
                SortedItemDescriptionList.Add(Items);
            }

            //Verifying list of classes in numerical order
            Report.WriteLine("List of Classes is in numerical order");
            for (int i = 0; i < count; i++)
            {
                Assert.AreEqual(SortedItemDescriptionList[i].ToString(), listofItemDescinSavedItems[i].ToString());
                Report.WriteLine(SortedItemDescriptionList[i] + " equals " + listofItemDescinSavedItems[i]);
            }            
        }        

        [Then(@"Saved item of '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)' and '(.*)' should be autopopulated in Freight Description section")]
        public void ThenSavedItemOfAndShouldBeAutopopulatedInFreightDescriptionSection(string Class, string NMFC, string Quantity, string QuantityType, string Weight, string WeightType, string Length, string Width, string Height, string DimensionType, string ItemDescription, string UNNumber, string CCN, string HazPackagegrp, string HazClass, string EContactName, string EPhoneNumber)
        {          

            Report.WriteLine("Verifying the Select Class field is auto filled with saved item information");            
            string DefaultText_ClassSavedItem = GetAttribute(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
            Assert.AreEqual(Class, DefaultText_ClassSavedItem);

            Report.WriteLine("Verifying the NMFC field is auto filled with saved item information");            
            string DefaultText_NMFC = GetAttribute(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value");
            Assert.AreEqual(NMFC, DefaultText_NMFC);
            
            Report.WriteLine("Verifying the Quantity field is auto filled with saved item information");
            string Defaulttext_QuantitySavedItem = GetAttribute(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
            Assert.AreEqual(Quantity, Defaulttext_QuantitySavedItem);

            Report.WriteLine("Verifying the Quantity Type field is auto filled with saved item information");            
            string Defaulttext_QuantityTypeSavedItem = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
            Assert.AreEqual(QuantityType, Defaulttext_QuantityTypeSavedItem);
            
            Report.WriteLine("Verifying the weight field is auto filled with saved item information");            
            string Defaulttext_weightSavedItem = GetAttribute(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");
            Assert.AreEqual(Weight, Defaulttext_weightSavedItem);
            
            Report.WriteLine("Verifying the Weight Type field is auto filled with saved item information");            
            string Defaulttext_weightType = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
            Assert.AreEqual(WeightType, Defaulttext_weightType);

            Report.WriteLine("Verifying the Length field is auto filled with saved item information");            
            string Defaulttext_Length = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
            Assert.AreEqual(Length, Defaulttext_Length);

            Report.WriteLine("Verifying the Width field is auto filled with saved item information");            
            string Defaulttext_Width = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            Assert.AreEqual(Width, Defaulttext_Width);

            Report.WriteLine("Verifying the Width field is auto filled with saved item information");           
            string Defaulttext_Height = GetAttribute(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
            Assert.AreEqual(Height, Defaulttext_Height);

            Report.WriteLine("Verifying the Dimension Type field is auto filled with saved item information");            
            string Defaulttext_DimensionType = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            Assert.AreEqual(DimensionType, Defaulttext_DimensionType);

            Report.WriteLine("Verifying the Item Description field is auto filled with saved item information");            
            string Defaulttext_IemDesc = GetAttribute(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");
            Assert.AreEqual(ItemDescription, Defaulttext_IemDesc);

            Report.WriteLine("Verifying the UNNumber field is auto filled with saved item information");
            string Defaulttext_UnNumber = GetAttribute(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "value");
            Assert.AreEqual(UNNumber, Defaulttext_UnNumber);

            Report.WriteLine("Verifying the CcN field is auto filled with saved item information");
            string Defaulttext_CcN = GetAttribute(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "value");
            Assert.AreEqual(CCN, Defaulttext_CcN);

            Report.WriteLine("Verifying the Hazmat Packaging group field is auto filled with saved item information");
            string Defaulttext_HazPackagegrp = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
            Assert.AreEqual(HazPackagegrp, Defaulttext_HazPackagegrp);

            Report.WriteLine("Verifying the Hazmat Class field is auto filled with saved item information");
            string Defaulttext_HazmatClass = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath);
            Assert.AreEqual(HazClass, Defaulttext_HazmatClass);

            Report.WriteLine("Verifying the Emergency contact name field is auto filled with saved item information");
            var Defaulttext_EContactName = GetAttribute(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "value");
            Assert.AreEqual(EContactName, Defaulttext_EContactName);

            Report.WriteLine("Verifying the Emergency phone number field is auto filled with saved item information");
            string Defaulttext_EPhoneNumber = GetAttribute(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "value");
            Assert.AreEqual(EPhoneNumber, Defaulttext_EPhoneNumber);
        }
        
        [Then(@"I can able to search value from the class or saved item from dropdown")]
        public void ThenICanAbleToSearchValueFromTheClassOrSavedItemFromDropdown()
        {
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "92.5");
            //SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_SavedClassItem_DropDown_Values_xpath, "92.5");
            Click(attributeName_xpath, FreightDesp_FirstItem_SavedClassItem_DropDown_Values_xpath);
        }
    }
}
