using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Maintenance_Tools.Configure_Accessorials
{
    [Binding]
    public class _48169_MaintenanceTools_ConfigureAccessorials_DeleteSteps : ConfigureAccessorial
    {
        string accessorialNameToBeDeletedGrid = null;
        string accessorialNameToBeDeletedModel = null;
        ConfigureAccessorialViewModel deleteModal = null;

        [When(@"I Click on the Delete icon of any displayed accessorial")]
        public void WhenIClickOnTheDeleteIconOfAnyDisplayedAccessorial()
        {
            Report.WriteLine("I click on the Delete icon of any displayed accessorial");
            if (Gettext(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tbody//tr[1]//div/a[2]/span") == "No accessorials to display.")
            {
                Report.WriteLine("No Accessorial is available");
            }
            else
            {
                accessorialNameToBeDeletedGrid = Gettext(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tbody//tr[1]/td[1]");
                Click(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tbody//tr[1]//div/a[2]/span");
            }
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"the Delete Accessorial Modal will open")]
        public void ThenTheDeleteAccessorialModalWillOpen()
        {
            Thread.Sleep(2000);
            Report.WriteLine("Verify the Delete Accessorial modal will open");
            string deleteModal = Gettext(attributeName_xpath, deleteModalTitle_Xpath);
            Assert.AreEqual("Delete Accessorial", deleteModal);
        }

        [Then(@"the Delete Accessorial modal will display the accessorial name")]
        public void ThenTheDeleteAccessorialModalWillDisplayTheAccessorialName()
        {
            Report.WriteLine("the Delete Accessorial modal will display the accessorial name");
            accessorialNameToBeDeletedModel = Gettext(attributeName_xpath, deleteModalDisplayedAccessorialName_Xpath);
            Assert.AreEqual(accessorialNameToBeDeletedGrid, accessorialNameToBeDeletedModel);
        }

        [Then(@"I will see the accessorial name to be deleted in the modal")]
        public void ThenIWillSeeTheAccessorialNameToBeDeletedInTheModal()
        {
            Report.WriteLine("I will see the accessorial name to be deleted in the modal");
            Assert.AreEqual(accessorialNameToBeDeletedGrid, accessorialNameToBeDeletedModel);
        }


        [Then(@"I will see the verbiage (.*)")]
        public void ThenIWillSeeTheVerbiage(string deleteModalVerbiage)
        {
            Report.WriteLine("Verify delete modal verbiage ");
            string deleteModalPopUpVerbiage = "Deleting will remove this accessorial from CRM. Are you sure you want to delete this accessorial?";
            string actualDeleteModalVerbiage = Gettext(attributeName_xpath, deleteModalDisplayedVerbiageName_Xpath);
            Assert.AreEqual(deleteModalPopUpVerbiage, actualDeleteModalVerbiage);
        }


        [Then(@"I will see a Cancel Button")]
        public void ThenIWillSeeACancelButton()
        {
            Report.WriteLine("I will see a Cancel Button");
            VerifyElementPresent(attributeName_xpath, deleteModalCancelButton_Xpath, "Cancel button");
            Verifytext(attributeName_xpath, deleteModalCancelButton_Xpath, "Cancel");
        }

        [Then(@"I will see a Delete Button")]
        public void ThenIWillSeeADeleteButton()
        {
            Report.WriteLine("Verify will see a Delete Button");
            VerifyElementPresent(attributeName_id, deleteModalDeleteButton_Id, "Delete button");
            Verifytext(attributeName_id, deleteModalDeleteButton_Id, "Delete");
        }

        [Given(@"I clicked on the Delete icon of any Displayed accessorial")]
        public void GivenIClickedOnTheDeleteIconOfAnyDisplayedAccessorial()
        {
            Report.WriteLine("click on the Delete icon of any displayed accessorial");
            if (Gettext(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tbody//tr[1]//div/a[2]/span") == "No accessorials to display.")
            {
                Report.WriteLine("No Accessorial is available");
            }
            else
            {
                accessorialNameToBeDeletedGrid = Gettext(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tbody//tr[1]/td[1]");
                Click(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tbody//tr[1]//div/a[2]/span");
            }

            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"the Delete Accessorial Modal opened")]
        public void GivenTheDeleteAccessorialModalOpened()
        {
            Thread.Sleep(2000);
            string deleteModal = Gettext(attributeName_xpath, deleteModalTitle_Xpath);
            Assert.AreEqual("Delete Accessorial", deleteModal);
        }

        [When(@"I click on the Cancel Button")]
        public void WhenIClickOnTheCancelButton()
        {
            Click(attributeName_xpath, deleteModalCancelButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"the Modal will close")]
        public void ThenTheModalWillClose()
        {
            Report.WriteLine("Verify Delete modal will be closed");
            SendKeys(attributeName_xpath, configureAccessorialsSearchTexBox_Xpath, accessorialNameToBeDeletedGrid);
            string accessorialName= Gettext(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tbody//tr[1]/td[1]");
            Assert.AreEqual(accessorialName, accessorialNameToBeDeletedGrid);
        }


        [Then(@"the delete modal will close")]
        public void ThenTheDeleteModalWillClose()
        {
            Report.WriteLine("Verify Delete modal will be closed");
            VerifyElementNotVisible(attributeName_xpath, deleteModalTitle_Xpath, "Delete Accessorial");
        }


        [When(@"I click on the Delete Button")]
        public void WhenIClickOnTheDeleteButton()
        {
            Click(attributeName_id, deleteModalDeleteButton_Id);
            Thread.Sleep(3000);
        }

        [Then(@"the accessorial will be deleted")]
        public void ThenTheAccessorialWillBeDeleted()
        {
           deleteModal= DBHelper.GetAccessorialDetails(accessorialNameToBeDeletedGrid);
            if (deleteModal == null)
            {
                Report.WriteLine("Verified the accessorial is deleted from Proxy Database");
            }else
            {
                Report.WriteFailure("accessorial is not deleted from Proxy Database");
            }
        }


        [Then(@"the deleted accessorial will not be displayed on the Configure Accessorials page")]
        public void ThenTheDeletedAccessorialWillNotBeDisplayedOnTheConfigureAccessorialsPage()
        {
            Report.WriteLine("Verify the deleted accessorial will not be displayed on the Configure Accessorials page");
            scrollElementIntoView(attributeName_xpath, configureAccessorialsSearchTexBox_Xpath);
            SendKeys(attributeName_xpath, configureAccessorialsSearchTexBox_Xpath, accessorialNameToBeDeletedGrid);
            string accessorialName = Gettext(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tbody//tr[1]/td[1]");
            Assert.AreEqual("No accessorials to display.", accessorialName);
        }



    }
}
