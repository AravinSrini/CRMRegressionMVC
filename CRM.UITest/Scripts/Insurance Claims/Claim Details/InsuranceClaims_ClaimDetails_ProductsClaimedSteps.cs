using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;
using System.Threading;

namespace CRM.UITest
{
    [Binding]
    public class InsuranceClaims_ClaimDetails_ProductsClaimedSteps : Objects.InsuranceClaim
    {
        string FirstClaimType_edited = "Shortage";
        string FirstArticleType_edited = "Used";
        string FirstItemType_edited = "abc123";
        string FirstUnitValue_edited = "11.00";
        string FirstUnitWt_edited = "123.00";
        string FirstQuantity_edited = "123";
        string Firstitem_edited = "12";
        string firstDescription_edited = "testdesc";
        string TotalShipmentWeight_edited = "100.00";
        string claimNumber = "2018000261";

        [Given(@"I have edited the fields Clm Type,Art Type,Qty, Item \#, Desc, Unit Wt,Unit Val of Products Claimed section in Details Tab")]
        public void GivenIHaveEditedTheFieldsClmTypeArtTypeQtyItemDescUnitWtUnitValOfProductsClaimedSectionInDetailsTab()
        {
            Report.WriteLine("I have edited the fields Clm Type,Art Type,Qty, Item, Desc, Unit Wt,Unit Val of Products Claimed section ");
            GlobalVariables.webDriver.WaitForPageLoad();
            MoveToElement(attributeName_xpath, FirstClaimType_xpath);
            scrollpagedown();
            Click(attributeName_xpath, FirstClaimType_xpath);
            SelectDropdownValueFromList(attributeName_xpath, claimtypevalues_xpath, FirstClaimType_edited);
            Thread.Sleep(1000);
            Click(attributeName_xpath, FirstArticleType_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ArticlesTypeValues_xpath, FirstArticleType_edited);
            SendKeys(attributeName_xpath, FirstItemType_xpath, FirstItemType_edited);
            SendKeys(attributeName_xpath, FirstUnitValue_xpath, FirstUnitValue_edited);
            SendKeys(attributeName_xpath, FirstUnitWgt_xpath, FirstUnitWt_edited);
            SendKeys(attributeName_xpath, TotalShipmentWeightValue_xpath, TotalShipmentWeight_edited);
            SendKeys(attributeName_xpath, FirstQuantity_xpath, FirstQuantity_edited);
            SendKeys(attributeName_xpath, Firstitem_xpath, Firstitem_edited);
            SendKeys(attributeName_xpath, firstDescription_claimedarticles_xpath, firstDescription_edited);


        }
        [Given(@"I am on Claim Detailspage with valid Products Claimed values")]
        public void GivenIAmOnClaimDetailspageWithValidProductsClaimedValues()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string claimListGridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (claimListGridData == "No Results Found")
            {
                Report.WriteLine("No Claims List found in the Grid");
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {
                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, ClaimListGrid_PendingCheckbox_Xpath);
                DefineTimeOut(1000);
                SendKeys(attributeName_xpath, ClaimsListSearchField_xpath, claimNumber);
                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, FirstClaimNumber_ClaimsListGid_ClaimSpecialistUser_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }

        [Then(@"Products Claimed values should be saved with the updated item values in DB")]
        public void ThenProductsClaimedValuesShouldBeSavedWithTheUpdatedItemValuesInDB()
        {
            Report.WriteLine("I have edited the fields Clm Type,Art Type,Qty, Item, Desc, Unit Wt,Unit Val of Products Claimed section ");
            InsuranceClaimItem ClaimItemdetails = DBHelper.GetInsuranceClaimItemdetails(claimNumber);
            Entities.Proxy.InsuranceClaim totalshipmentWeight_DB = DBHelper.GetInsuranceCliamDetails(claimNumber);
            var FirstClaimType_DB = ClaimItemdetails.InsuranceClaimTypeId;
            var FirstArticleType_DB = ClaimItemdetails.InsuranceClaimArticleTypeId;
            string FirstQuantity_DB = ClaimItemdetails.Quantity.ToString();
            string FirstItem_DB = ClaimItemdetails.ItemNumber.ToString();
            string firstDescription_DB = ClaimItemdetails.description.ToString();
            string FirstUnitWt_DB = ClaimItemdetails.Weight.ToString();
            string FirstUnitValue_DB = ClaimItemdetails.UnitValue.ToString();
            string TotalShipmentWeight_DB = totalshipmentWeight_DB.TotalShipmentWeight.ToString();
            Assert.AreEqual(1, FirstClaimType_DB);
            Assert.AreEqual(2, FirstArticleType_DB);
            Assert.AreEqual(FirstQuantity_edited, FirstQuantity_DB);
            Assert.AreEqual(Firstitem_edited, FirstItem_DB);
            Assert.AreEqual(firstDescription_edited, firstDescription_DB);
            Assert.AreEqual(FirstUnitWt_edited, FirstUnitWt_DB);
            Assert.AreEqual(FirstUnitValue_edited, FirstUnitValue_DB);
            Assert.AreEqual(TotalShipmentWeight_edited, TotalShipmentWeight_DB);
        }

        [Given(@"I have edited the any (.*) in Products Claimed section of Details page")]
        public void GivenIHaveEditedTheAnyInProductsClaimedSectionOfDetailsPage(string ProductsClaimedfield)
        {
            Report.WriteLine("I have edited the any field in Products Claimed section of Details page");
            GlobalVariables.webDriver.WaitForPageLoad();
            MoveToElement(attributeName_xpath, FirstClaimType_xpath);
            scrollpagedown();
            if (ProductsClaimedfield == "ClmType")
            {
                Click(attributeName_xpath, FirstClaimType_xpath);
                SelectDropdownValueFromList(attributeName_xpath, claimtypevalues_xpath, FirstClaimType_edited);
            }
            else if (ProductsClaimedfield == "ArtType")
            {
                Click(attributeName_xpath, FirstArticleType_xpath);
                SelectDropdownValueFromList(attributeName_xpath, ArticlesTypeValues_xpath, FirstArticleType_edited);
            }
            else if (ProductsClaimedfield == "Item")
            {
                SendKeys(attributeName_xpath, FirstItemType_xpath, FirstItemType_edited);
            }
            else if (ProductsClaimedfield == "Desc")
            {
                SendKeys(attributeName_xpath, firstDescription_claimedarticles_xpath, firstDescription_edited);

            }
            else if (ProductsClaimedfield == "UnitWt")
            {
                SendKeys(attributeName_xpath, FirstUnitWgt_xpath, FirstUnitWt_edited);
            }
            else if (ProductsClaimedfield == "UnitVal")
            {
                SendKeys(attributeName_xpath, FirstUnitValue_xpath, FirstUnitValue_edited);
            }

            else if (ProductsClaimedfield == "Quantity")
            {
                SendKeys(attributeName_xpath, FirstQuantity_xpath, FirstQuantity_edited);
            }

            else
            {
                SendKeys(attributeName_xpath, TotalShipmentWeightValue_xpath, TotalShipmentWeight_edited);
            }

        }

        [Then(@"(.*) should be saved with the updated values in DB")]
        public void ThenShouldBeSavedWithTheUpdatedValuesInDB(string ProductsClaimedfield)
        {
            InsuranceClaimItem ClaimItemdetails = DBHelper.GetInsuranceClaimItemdetails(claimNumber);
            Entities.Proxy.InsuranceClaim totalshipmentWeight_DB = DBHelper.GetInsuranceCliamDetails(claimNumber);
            var FirstClaimType_DB = ClaimItemdetails.InsuranceClaimTypeId;
            var FirstArticleType_DB = ClaimItemdetails.InsuranceClaimArticleTypeId;
            string FirstQuantity_DB = ClaimItemdetails.Quantity.ToString();
            string FirstItem_DB = ClaimItemdetails.ItemNumber.ToString();
            string firstDescription_DB = ClaimItemdetails?.description.ToString();
            string FirstUnitWt_DB = ClaimItemdetails.Weight.ToString();
            string FirstUnitValue_DB = ClaimItemdetails.UnitValue.ToString();
            string TotalShipmentWeight_DB = totalshipmentWeight_DB.TotalShipmentWeight.ToString();
            Report.WriteLine("I have edited the any field in Products Claimed section of Details page");
            if (ProductsClaimedfield == "ClmType")
            {
                Assert.AreEqual(1, FirstClaimType_DB);
            }
            else if (ProductsClaimedfield == "ArtType")
            {
                Assert.AreEqual(2, FirstArticleType_DB);
            }
            else if (ProductsClaimedfield == "Quantity")
            {
                Assert.AreEqual(FirstQuantity_edited, FirstQuantity_DB);
            }
            else if (ProductsClaimedfield == "Item")
            {
                Assert.AreEqual(Firstitem_edited, FirstItem_DB);
            }
            else if (ProductsClaimedfield == "Desc")
            {
                Assert.AreEqual(firstDescription_edited, firstDescription_DB);
            }
            else if (ProductsClaimedfield == "UnitWt")
            {
                Assert.AreEqual(FirstUnitWt_edited, FirstUnitWt_DB);
            }
            else if (ProductsClaimedfield == "UnitVal")
            {
                Assert.AreEqual(FirstUnitValue_edited, FirstUnitValue_DB);
            }
            else
            {
                Assert.AreEqual(TotalShipmentWeight_edited, TotalShipmentWeight_DB);
            }

        }

    }
}
