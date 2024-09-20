using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Get_Quote__LTL__Screen
{
    [Binding]
    public class RateRequest_DefaultShipperSteps : ObjectRepository
    {
        [Then(@"the address information of default shipper address should auto-populate in the Shipping From section (.*)")]
        public void ThenTheAddressInformationOfDefaultShipperAddressShouldAuto_PopulateInTheShippingFromSection(string Username)
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            string setupID = IDP.GetClaimValue(Username, "dlscrm-CustomerSetUpId");
            int value = Convert.ToInt32(setupID);
            int AccNumb = DBHelper.GetAccountNumber(value);
            Address Addvalue = DBHelper.GetShipperAddressforAccount(AccNumb);

            if (Addvalue == null)
            {
                Report.WriteLine("Saved Address of the type shipper does not exists for the logged in user");
                Assert.IsTrue(false);
            }
            else
            {
                var ActualOriginCity = GetValue(attributeName_id, LTL_OriginCity_Id, "value");
                Assert.AreEqual(Addvalue.City, ActualOriginCity);
                Report.WriteLine("Displaying Origin city in UI " + ActualOriginCity + "is matching with DB value" + Addvalue.City);

                string ActualOriginState = Gettext(attributeName_xpath, LTL_OriginStateProvince_SelectedValue_Xpath);
                Assert.AreEqual(Addvalue.State, ActualOriginState);
                Report.WriteLine("Displaying Origin state/province in UI " + ActualOriginState + "is matching with DB value" + Addvalue.State);

                string ActualOriginZipCode = GetValue(attributeName_id, LTL_OriginZipPostal_Id, "value");
                Assert.AreEqual(Addvalue.Zip.ToUpper(), ActualOriginZipCode.ToUpper());
                Report.WriteLine("Displaying Origin zip/postal in UI " + ActualOriginZipCode + "is matching with DB value" + Addvalue.Zip);
            }
        }

        [Then(@"the address information section should be empty (.*)")]
        public void ThenTheAddressInformationSectionShouldBeEmpty(string Username)
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            string setupID = IDP.GetClaimValue(Username, "dlscrm-CustomerSetUpId");
            int value = Convert.ToInt32(setupID);
            int AccNumb = DBHelper.GetAccountNumber(value);
            Address Addvalue = DBHelper.GetShipperAddressforAccount(AccNumb);

            if (Addvalue == null)
            {
                var ActualOriginCity = GetValue(attributeName_id, LTL_OriginCity_Id, "value");
                Assert.AreEqual(string.Empty, ActualOriginCity);
                Report.WriteLine("City field is empty");

                string ActualOriginState = Gettext(attributeName_xpath, LTL_OriginStateProvince_SelectedValue_Xpath);
                Assert.AreEqual("Select state/province...", ActualOriginState);
                Report.WriteLine("State field is empty");

                string ActualOriginZipCode = GetValue(attributeName_id, LTL_OriginZipPostal_Id, "value");
                Assert.AreEqual(string.Empty, ActualOriginZipCode);
                Report.WriteLine("Zip Field is Empty");
            }
            else
            {
                Report.WriteLine("Saved Address of the type shipper exists for the logged in user");
                Assert.IsTrue(false);
            }

        }

        [Then(@"User should be able to edit address information (.*), (.*) and (.*)")]
        public void ThenUserShouldBeAbleToEditAddressInformationAnd(string OCity, string OState, string OZip)
        {
            ShippingInformationScreenForDesktopSteps steps = new ShippingInformationScreenForDesktopSteps();
            WaitForElementVisible(attributeName_id, ClearAddress_OriginId, "Clear Address");
            Click(attributeName_id, ClearAddress_OriginId);
            steps.WhenISelectCanadaCountryFromOriginCountryDropdown();
            steps.WhenIEnterValidDataInOriginSectionAnd(OZip, OCity, OState);

            string ActualOriginCity = GetValue(attributeName_id, LTL_OriginCity_Id, "value");
            Assert.AreEqual(OCity, ActualOriginCity);
            Report.WriteLine("Origin City field is editable");

            string ActualOriginState = Gettext(attributeName_xpath, LTL_OriginStateProvince_SelectedValue_Xpath);
            Assert.AreEqual(OState, ActualOriginState);
            Report.WriteLine("Origin State field is editable");

            string ActualOriginZipCode = GetValue(attributeName_id, LTL_OriginZipPostal_Id, "value");
            Assert.AreEqual(OZip.ToUpper(), ActualOriginZipCode.ToUpper());
            Report.WriteLine("Origin Zip field is editable");

        }

        [Then(@"shipping from saved address dropdown should be binded to default shipper address (.*)")]
        public void ThenShippingFromSavedAddressDropdownShouldBeBindedToDefaultShipperAddress(string username)
        {
            string text = GetAttribute(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "value");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            string setupID = IDP.GetClaimValue(username, "dlscrm-CustomerSetUpId");
            int value = Convert.ToInt32(setupID);
            int AccNumb = DBHelper.GetAccountNumber(value);
            Address Addvalue = DBHelper.GetShipperAddressforAccount(AccNumb);

            var addressFormat = Addvalue.Name + " " + Addvalue.Address1 + " " + Addvalue.Address2 + " " + Addvalue.City + " " + Addvalue.State + " " + " " + Addvalue.Country + " " + Addvalue.Zip + " " + Addvalue.ContactName + " " + Addvalue.PhoneNumber + " " + Addvalue.EmailId + " " + Addvalue.FaxNumber;

            Assert.AreEqual(addressFormat, text);
            Report.WriteLine("Address displaying in saved address dropdown is matching with saved address dropdown value");
        }

    }
}
