using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.LTL_Freight_Description___Select_Class
{
    [Binding]
    public class RevampLTLRateRequest_FreightDescription_SelectClass_Desktop : ObjectRepository
    {
        List<string> ListofClassesandItems_UI = new List<string>();
        List<string> ListofClasses_UI = new List<string>();
        List<string> ListofSavedItems_UI = new List<string>();

        [When(@"I click on the Select Class field")]
        public void WhenIClickOnTheSelectClassField()
        {
            Report.WriteLine("I click on the Select Class field");
            Click(attributeName_id, ClassorSavedItemField_id);
        }

        [Then(@"I select '(.*)' from the Select Class field")]
        public void ThenISelectFromTheSelectClassField(string saveditem)
        {
            Report.WriteLine("when I select saved item then the saved item should auto-fill in the Select Class field");
            Click(attributeName_id, ClassorSavedItemField_id);
            SendKeys(attributeName_xpath, selectclasstextbox_xpath, saveditem);
            SelectDropdownValueFromList(attributeName_id, ClassorSavedItemField_id, saveditem);
        }

        [Then(@"I must see the list of classes in the Select Class field should be in numerical order")]
        public void ThenIMustSeeTheListOfClassesInTheSelectClassFieldShouldBeInNumericalOrder()
        {
            Report.WriteLine("I must see the list of classes in the Select Class field should be in numerical order");
            bool ExpectedClassPresent = false;
            bool EachClassPresentonlyOnce = false;
            double[] ExpectedClasses = { 50, 55, 60, 65, 70, 77.5, 85, 92.5, 100, 110, 125, 150, 175, 200, 250, 300, 400, 500 };

            //Click(attributeName_id, ClassorSavedItemField_id);
            ListofClassesandItems_UI = GetDropdownValues(attributeName_id, ClassorSavedItemField_id, "li");
            ListofClassesandItems_UI.Remove("Select or search for a class or saved item...");

            var ListofOptionsCount = ListofClassesandItems_UI.Count();

            int IndexOf50 = ListofClassesandItems_UI.FindIndex(x => x == "50");
            int IndexOf500 = ListofClassesandItems_UI.FindIndex(x => x == "500");

            for (int i = IndexOf50; i <= IndexOf500; i++)
            {
                ListofClasses_UI.Add(ListofClassesandItems_UI[i]);
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
            for(int i = 0; i <= 17; i++)
            {
                Assert.AreEqual(ListofClasses_UI[i].ToString(), ExpectedClasses[i].ToString());
            }
        }

        [Then(@"I must see the saved items should display after the list of classes in the Select Class field")]
        public void ThenIMustSeeTheSavedItemsShouldDisplayAfterTheListOfClassesInTheSelectClassField()
        {
            Report.WriteLine("I must see the List of saved items displayed after the list of classes");
            
            bool SavedItemsPresent = false;
            bool SavedItemsListDisplayafterClassesList = false;
            bool SavedItemsPresentonlyOnce = false;

            ListofClassesandItems_UI = GetDropdownValues(attributeName_id, ClassorSavedItemField_id, "li");
            ListofClassesandItems_UI.Remove("Select or search for a class or saved item...");

            int IndexOf50 = ListofClassesandItems_UI.FindIndex(x => x == "50");
            int IndexOf500 = ListofClassesandItems_UI.FindIndex(x => x == "500");
            
            var ListofOptionsCount = ListofClassesandItems_UI.Count();
            
            //Finding how many saved items in the list of drop down options

            var SavedItemsCount = ListofOptionsCount - (IndexOf500+1);

            if (IndexOf50 == 0 && IndexOf500 == 17 && SavedItemsCount >= 1)
            {
                SavedItemsPresent = true;
                Assert.IsTrue(SavedItemsPresent);
                SavedItemsListDisplayafterClassesList = true;
                Assert.IsTrue(SavedItemsListDisplayafterClassesList);

                Report.WriteLine(SavedItemsCount + "Saved Items Present in the list");
                for (int i = IndexOf500+1; i < ListofOptionsCount; i++)
                {
                    ListofSavedItems_UI.Add(ListofClassesandItems_UI[i]);
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
        }

        [Then(@"I must see the list of saved items should be display as Class and Item Description")]
        public void ThenIMustSeeTheListOfSavedItemsShouldBeDisplayAsClassAndItemDescription()
        {
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
        }

        [Then(@"I must see the list of saved items is displayed in the Select Class field should be in numeric, then alphabetical order")]
        public void ThenIMustSeeTheListOfSavedItemsIsDisplayedInTheSelectClassFieldShouldBeInNumericThenAlphabeticalOrder()
        {
            Report.WriteLine("I must see the  list of classes in the Select Class field should be in numeric, then alphabetical order");

            List<string> listofclassesinSavedItems = new List<string>();
            List<string> listofItemDescinSavedItems = new List<string>();
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

        [Then(@"number of items displaying for the (.*) in the saved items dropdown should be equal to database")]
        public void ThenNumberOfItemsDisplayingForTheInTheSavedItemsDropdownShouldBeEqualToDatabase(string Username)
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            string setupID = IDP.GetClaimValue(Username, "dlscrm-CustomerSetUpId");
            int value = Convert.ToInt32(setupID);
            int AccNumb = DBHelper.GetAccountNumber(value);
            int ExpectedCount = DBHelper.GetItemsforAccount(AccNumb).Count;
            ListofClassesandItems_UI = GetDropdownValues(attributeName_id, ClassorSavedItemField_id, "li");
            ListofClassesandItems_UI.Remove("Select or search for a class or saved item...");
            int IndexOf500 = ListofClassesandItems_UI.FindIndex(x => x == "500");
            var ListofOptionsCount = ListofClassesandItems_UI.Count();
            for (int i = IndexOf500 + 1; i < ListofOptionsCount; i++)
            {
                ListofSavedItems_UI.Add(ListofClassesandItems_UI[i]);
            }
            int ActualCount = ListofSavedItems_UI.Count;
            Assert.AreEqual(ExpectedCount, ActualCount);
        }
    }
}
