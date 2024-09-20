using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Data;
using CRM.UITest.Entities;
namespace CRM.UITest
{
    [Binding]
    public class GetQuoteSelectClass_SavedItem_StationUsersSteps:ObjectRepository
    {

        [Then(@"number of items displaying for the (.*) in the saveditems dropdown should be equal to database")]
        public void ThenNumberOfItemsDisplayingForTheInTheSaveditemsDropdownShouldBeEqualToDatabase(string Account_Name)
        {

            int setupid = DBHelper.GetAccountIdforAccountName(Account_Name);
            int accountnumber = DBHelper.GetAccountNumber(setupid);
            int ExpectedCount = DBHelper.GetItemsforAccount(accountnumber).Count;
            List<string> ListofClassesandItems_UI = new List<string>();
            ListofClassesandItems_UI = GetDropdownValues(attributeName_id, ClassorSavedItemField_id, "li");
            ListofClassesandItems_UI.Remove("Select or search for a class or saved item...");
            int IndexOf500 = ListofClassesandItems_UI.FindIndex(x => x == "500");
            var ListofOptionsCount = ListofClassesandItems_UI.Count;
            List<string> ListofSavedItems_UI = new List<string>();
            for (int i = IndexOf500 + 1; i < ListofOptionsCount; i++)
            {
                ListofSavedItems_UI.Add(ListofClassesandItems_UI[i]);
            }
            int ActualCount = ListofSavedItems_UI.Count;
            Assert.AreEqual(ExpectedCount, ActualCount);
        }


        [Then(@"I must see the list of saved items is displayed in the Select Class field should be in numeric, then alphabetical order '(.*)'")]
        public void ThenIMustSeeTheListOfSavedItemsIsDisplayedInTheSelectClassFieldShouldBeInNumericThenAlphabeticalOrder(string Account_Name)
        {
            Report.WriteLine("I must see the  list of classes in the Select Class field should be in numeric, then alphabetical order");

            List<string> listofclassesinSavedItems = new List<string>();
            List<string> listofItemDescinSavedItems = new List<string>();
            List<string> ListofSavedItems_UI = new List<string>();
            ListofSavedItems_UI = GetDropdownValues(attributeName_id, ClassorSavedItemField_id, "li");
            var count = 0;

            foreach (string SavedItem in ListofSavedItems_UI)
            {
                List<string> secondRow = new List<string>(SavedItem.Split(' '));

                listofclassesinSavedItems.Add(secondRow[0]);
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
      
        
  
    }
}
