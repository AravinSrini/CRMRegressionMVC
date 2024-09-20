using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Get_Quote__LTL__Screen
{
    [Binding]
    public class RateRequest_DefaultConsigneeSteps : ObjectRepository
    {
        [Then(@"the address information of default Consignee address should auto-populate in the Shipping To section (.*)")]
        public void ThenTheAddressInformationOfDefaultConsigneeAddressShouldAuto_PopulateInTheShippingToSection(string Username)
        {
          
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            string setupID = IDP.GetClaimValue(Username, "dlscrm-CustomerSetUpId");
            int value = Convert.ToInt32(setupID);
            int AccNumb = DBHelper.GetAccountNumber(value);
            Address Addvalue = DBHelper.GetConsigneeAddressforAccount(AccNumb);

            if (Addvalue == null)
            {
                Report.WriteLine("Saved Address of the type shipper does not exists for the logged in user");
                Assert.IsTrue(false);
            }
            else
            {
                var ActualDestinationCity = GetValue(attributeName_id, LTL_DestinationCity_Id, "value");
                Assert.AreEqual(Addvalue.City, ActualDestinationCity);
                Report.WriteLine("Displaying Destination city in UI " + ActualDestinationCity + "is matching with DB value" + Addvalue.City);

                string ActualDestinationState = Gettext(attributeName_xpath, LTL_DestinationStateProvince_SelectedValue_Xpath);
                Assert.AreEqual(Addvalue.State, ActualDestinationState);
                Report.WriteLine("Displaying Destination state/province in UI " + ActualDestinationState + "is matching with DB value" + Addvalue.State);
                
                string ActualDestinationZipCode = GetValue(attributeName_id, LTL_DestinationZipPostal_Id, "value");
                Assert.AreEqual(Addvalue.Zip.ToUpper(), ActualDestinationZipCode.ToUpper());
                Report.WriteLine("Displaying Destination zip/postal in UI " + ActualDestinationZipCode + "is matching with DB value" + Addvalue.Zip);
            }
        }


        [Then(@"the consignee address information section should be empty (.*)")]
        public void ThenTheConsigneeAddressInformationSectionShouldBeEmpty(string Username)
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            string setupID = IDP.GetClaimValue(Username, "dlscrm-CustomerSetUpId");
            int value = Convert.ToInt32(setupID);
            int AccNumb = DBHelper.GetAccountNumber(value);
            Address Addvalue = DBHelper.GetConsigneeAddressforAccount(AccNumb);

            if (Addvalue == null)
            {
                var ActualDestinationCity = GetValue(attributeName_id, LTL_DestinationCity_Id, "value");
                Assert.AreEqual(string.Empty, ActualDestinationCity);
                Report.WriteLine("City field is empty");

                string ActualDestinationState = Gettext(attributeName_xpath, LTL_DestinationStateProvince_SelectedValue_Xpath);
                Assert.AreEqual("Select state/province...", ActualDestinationState);
                Report.WriteLine("State field is empty");

                string ActualDestinationZipCode = GetValue(attributeName_id, LTL_DestinationZipPostal_Id, "value");
                Assert.AreEqual(string.Empty, ActualDestinationZipCode);
                Report.WriteLine("Zip Field is Empty");
            }
            else
            {
                Report.WriteLine("Saved Address of the type consignee exists for the logged in user");
                Assert.IsTrue(false);
            }

        }

        [Then(@"User should be able to edit consignee address information (.*), (.*) and (.*)")]
        public void ThenUserShouldBeAbleToEditConsigneeAddressInformationAnd(string DCity, string DState, string DZip)
        {
            ShippingInformationScreenForDesktopSteps steps = new ShippingInformationScreenForDesktopSteps();
            WaitForElementVisible(attributeName_id, ClearAddress_DestId, "Clear Address");            
            Click(attributeName_id, ClearAddress_DestId);
            steps.WhenISelectCanadaCountryFromDestinationCountryDropdown();
            steps.WhenIEnterValidDataInDestinationSectionAnd(DZip, DCity, DState);

            string ActualDestinationCity = GetValue(attributeName_id, LTL_DestinationCity_Id, "value");
            Assert.AreEqual(DCity, ActualDestinationCity);
            Report.WriteLine("Destination City field is editable");

            string ActualDestinationState = Gettext(attributeName_xpath, LTL_DestinationStateProvince_SelectedValue_Xpath);
            Assert.AreEqual(DState, ActualDestinationState);
            Report.WriteLine("Destination State field is editable");

            string ActualDestinationZipCode = GetValue(attributeName_id, LTL_OriginZipPostal_Id, "value");
            Assert.AreEqual(DZip.ToUpper(), ActualDestinationZipCode.ToUpper());
            Report.WriteLine("Destination Zip field is editable");
        }


        [Then(@"shipping to saved address dropdown should be binded to default Consignee address (.*)")]
        public void ThenShippingToSavedAddressDropdownShouldBeBindedToDefaultConsigneeAddress(string username)
        {
            string text = GetAttribute(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "value");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            string setupID = IDP.GetClaimValue(username, "dlscrm-CustomerSetUpId");
            int value = Convert.ToInt32(setupID);
            int AccNumb = DBHelper.GetAccountNumber(value);
            Address Addvalue = DBHelper.GetConsigneeAddressforAccount(AccNumb);

            var addressFormat = Addvalue.Name + " " + Addvalue.Address1 + " " + Addvalue.Address2 + " " + Addvalue.City + " " + Addvalue.State + " " + " " + Addvalue.Country + " " + Addvalue.Zip + " " + Addvalue.ContactName + " " + Addvalue.PhoneNumber + " " + Addvalue.EmailId + " " + Addvalue.FaxNumber;

            Assert.AreEqual(addressFormat, text);
            Report.WriteLine("Address displaying in saved address dropdown is matching with saved address dropdown value");
        }





    }
}



