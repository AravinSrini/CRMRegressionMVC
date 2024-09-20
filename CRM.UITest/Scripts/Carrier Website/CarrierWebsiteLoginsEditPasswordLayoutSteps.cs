using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;


namespace CRM.UITest.Scripts.Carrier_Website
{
    [Binding]
    public class CarrierWebsiteLoginsEditPasswordLayoutSteps : MaintenaceTools
    {
        [When(@"I am on the Carrier Website Logins Edit Password page")]
        public void WhenIAmOnTheCarrierWebsiteLoginsEditPasswordPage()
        {
            Report.WriteLine("Clicking on Maintanence Tools icon");
            Click(attributeName_cssselector, MaintenanceToolIcon_css);
            Report.WriteLine("Clicking on Carrier website button");
            scrollElementIntoView(attributeName_id, CarrierWebsite_Button_Id);
            Click(attributeName_id, CarrierWebsite_Button_Id);
            WaitForElementVisible(attributeName_xpath, CarrierWebsite_Title_Xpath, "Carrier Website Page Header");
            Report.WriteLine("Verifying carrier website login page");
            Verifytext(attributeName_xpath, CarrierWebsite_Title_Xpath, "Admin Carrier Website Logins");
            Report.WriteLine("Clicking on edit icon for any page");
            Click(attributeName_xpath, CarrierWebsite_EditIcon_Xpath);

        }

        [Then(@"I will see the ""(.*)"" title")]
        public void ThenIWillSeeTheTitle(string p0)
        {
            Report.WriteLine("Verifying Edit Password popup text");
            WaitForElementVisible(attributeName_xpath, CarrierWebsite_EditModalTitle_Xpath,"Edit Password Popup");
            Verifytext(attributeName_xpath, CarrierWebsite_EditModalTitle_Xpath, "Edit Password");
        }

        [Then(@"I will see an input field with the current password value")]
        public void ThenIWillSeeAnInputFieldWithTheCurrentPasswordValue()
        {
            string FirstCarrierScac = Gettext(attributeName_xpath, CarrierWbsite_FirstCarrierScac_Xpath);
            string passwordValue = GetValue(attributeName_id, CarrierWebsite_EditPasswordTextBox_Id, "value");
            CRM.UITest.Entities.Proxy.CarrierWebsite carrierValue = new CRM.UITest.Entities.Proxy.CarrierWebsite();
            carrierValue = DBHelper.GetCarrierDetails(FirstCarrierScac);
            Assert.AreEqual(carrierValue.Password, passwordValue);
            Report.WriteLine("Displaying password value in UI " + passwordValue + "is matching with db value " + carrierValue.Password);
        }
        
        [Then(@"I will see an option to Cancel")]
        public void ThenIWillSeeAnOptionToCancel()
        {
            Report.WriteLine("Verifying display of Cancel button");
            VerifyElementVisible(attributeName_id, CarrierWbsite_EditModal_CancelButton_Id, "Cancel Button");
        }
        
        [Then(@"I will see an option to Save")]
        public void ThenIWillSeeAnOptionToSave()
        {
            Report.WriteLine("Verifying display of Save button");
            VerifyElementVisible(attributeName_id, CarrierWebsite_EditModal_SaveButton_Id, "Save Button");
        }
    }
}
