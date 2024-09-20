using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.ViewRatesButton_AllUsers
{
    [Binding]
    public  class AddShipment_ViewRatesButton_ShpEntryNoRatesUsersSteps : AddShipments
    {      

        [Given(@"I am a Ship Entry No Rates user")]
        public void GivenIAmAShipEntryNoRatesUser()
        {
            string username = ConfigurationManager.AppSettings["username-prakashshpentynomg"].ToString();
            string password = ConfigurationManager.AppSettings["password-prakashshpentynomg"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);

        }

        [When(@"Verify that i will arrive on the (.*)")]
        public void WhenVerifyThatIWillArriveOnThe(string review_submit_page)
        {
            Report.WriteLine("I must be navigated to the Review and submit page LTL");

            string ReviewAndSubmit = Gettext(attributeName_xpath, ReviewAndSubmit_Title_Xpath);
            Assert.AreEqual(review_submit_page, ReviewAndSubmit);
            
        }
        [Then(@"Verify I must see the (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*) and fields on review and submit page")]
        public void ThenVerifyIMustSeeTheAndFieldsOnReviewAndSubmitPage(string shippingfrom, string shippingfromcontact_info, string shippingTo, string shippingTocontact_info, string pickupDate, string FreightDesc, string ReferenceNo, string DefaultSpecialInstruction, string InsuredValue)
        {
            Report.WriteLine("Verify the Shipping Info Section");
            string ExpectedSectionShipping = "Shipping Info";
            string ShippingINfo = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[1]/h4");
            Assert.AreEqual(ExpectedSectionShipping, ShippingINfo);

            Report.WriteLine("Verified the Shipping From Sections");
            string ShippingFromExpected = Gettext(attributeName_xpath, ReviewSubmit_Section_ShippingFrom_Xpath);
            Assert.AreEqual(shippingfrom, ShippingFromExpected);

            string ActualAccessorial = "Accessorials";
            string AccessorialExp = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[6]");
            string[] ExpectedAccessorials = AccessorialExp.Split(':');
            string AccessorialsLabel = ExpectedAccessorials[0];
            Assert.AreEqual(ActualAccessorial, AccessorialsLabel);

            string ActualComments = "Comments";
            string CommentsExp = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[7]");
            string[] ExpectedComments = CommentsExp.Split(':');
            string CommentsLabel = ExpectedComments[0];
            Assert.AreEqual(ActualComments, CommentsLabel);

            string ShippingFromContactsINfo = Gettext(attributeName_xpath, ReviewSubmit_Section_ShippingFromContactInfo_Xpath);
            Assert.AreEqual(shippingfromcontact_info, ShippingFromContactsINfo);

            string FromName = "Name";
            string FromNameText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[8]");
            string[] ExpectedFromName = FromNameText.Split(':');
            string FromNameLabel = ExpectedFromName[0];
            Assert.AreEqual(FromName, FromNameLabel);

            string FromPhone = "Phone";
            string FromPhoneText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[9]");
            string[] ExpectedFromPhone = FromPhoneText.Split(':');
            string FromPhoneLabel = ExpectedFromPhone[0];
            Assert.AreEqual(FromPhone, FromPhoneLabel);

            string FromEmail = "Email";
            string FromEmailText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[10]");
            string[] ExpectedFromEmail = FromEmailText.Split(':');
            string FromEmailLabel = ExpectedFromEmail[0];
            Assert.AreEqual(FromEmail, FromEmailLabel);

            string FromFax = "FAX";
            string FromFaxText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[11]");
            string[] ExpectedFromFax = FromFaxText.Split(':');
            string FromFaxLabel = ExpectedFromFax[0];
            Assert.AreEqual(FromFax, FromFaxLabel);





            Report.WriteLine("Verified the Shipping To Sections");
            string ShippingToExpected = Gettext(attributeName_xpath, ReviewSubmit_Section_ShippingTo_Xpath);
            Assert.AreEqual(shippingTo, ShippingToExpected);

            string ToActualAccessorial = "Accessorials";
            string ToAccessorialExp = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[6]");
            string[] ToExpectedAccessorials = ToAccessorialExp.Split(':');
            string ToAccessorialsLabel = ToExpectedAccessorials[0];
            Assert.AreEqual(ToActualAccessorial, ToAccessorialsLabel);

            string ToActualComments = "Comments";
            string ToCommentsExp = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[1]/span[7]");
            string[] ToExpectedComments = ToCommentsExp.Split(':');
            string ToCommentsLabel = ToExpectedComments[0];
            Assert.AreEqual(ToActualComments, ToCommentsLabel);

            string ShippingToContactsINfo = Gettext(attributeName_xpath, ReviewSubmit_Section_ShippingToContactInfo_Xpath);
            Assert.AreEqual(shippingTocontact_info, ShippingToContactsINfo);

            string ToName = "Name";
            string ToNameText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[8]");
            string[] ExpectedToName = FromNameText.Split(':');
            string ToNameLabel = ExpectedFromName[0];
            Assert.AreEqual(ToName, ToNameLabel);

            string ToPhone = "Phone";
            string ToPhoneText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[9]");
            string[] ExpectedToPhone = ToPhoneText.Split(':');
            string ToPhoneLabel = ExpectedToPhone[0];
            Assert.AreEqual(ToPhone, ToPhoneLabel);

            string ToEmail = "Email";
            string ToEmailText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[10]");
            string[] ExpectedToEmail = ToEmailText.Split(':');
            string ToEmailLabel = ExpectedToEmail[0];
            Assert.AreEqual(ToEmail, ToEmailLabel);

            string ToFax = "FAX";
            string ToFaxText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[1]/div[2]/span[11]");
            string[] ExpectedToFax = ToFaxText.Split(':');
            string ToFaxLabel = ExpectedToFax[0];
            Assert.AreEqual(ToFax, ToFaxLabel);

            Report.WriteLine("Verify the Pickup date section");
            string PickupdateActual = Gettext(attributeName_xpath, ReviewSubmit_Section_PickupDate_Xpath);
            Assert.AreEqual(pickupDate, PickupdateActual);

            Report.WriteLine("Verify the Freight Description section");
            string FreightDescActual = Gettext(attributeName_xpath, ReviewSubmit_Section_FreightDescription_Xpath);
            Assert.AreEqual(FreightDesc, FreightDescActual);

            string FreightClass = "Class";
            string FreightClassText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[1]/div/div/div[1]/span");
            string[] ExpectedFreightClass = FreightClassText.Split(':');
            string FreightClassLabel = ExpectedFreightClass[0];
            Assert.AreEqual(FreightClass, FreightClassLabel);

            string FreightNMFC = "NMFC";
            string FreightNMFCText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[1]/div/div/div[2]/span");
            string[] ExpectedFreightNMFC = FreightNMFCText.Split(':');
            string FreightNMFCLabel = ExpectedFreightNMFC[0];
            Assert.AreEqual(FreightNMFC, FreightNMFCLabel);

            string FreightQuantity = "Quantity";
            string FreightQuantityText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[1]/div/div/div[3]/span");
            string[] ExpectedFreightQuantity = FreightQuantityText.Split(':');
            string FreightQuantityLabel = ExpectedFreightQuantity[0];
            Assert.AreEqual(FreightQuantity, FreightQuantityLabel);

            string FreightWeight = "Weight";
            string FreightWeightText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[1]/div/div/div[4]/span");
            string[] ExpectedFreightWeight = FreightWeightText.Split(':');
            string FreightWeightLabel = ExpectedFreightWeight[0];
            Assert.AreEqual(FreightWeight, FreightWeightLabel);

            string FreightHazmat = "Hazardous Materials";
            string FreightHazmatText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[2]/div/div/div/div/div[1]/span");
            string[] ExpectedFreightHazmat = FreightHazmatText.Split(':');
            string FreightHazmatLabel = ExpectedFreightHazmat[0];
            Assert.AreEqual(FreightHazmat, FreightHazmatLabel);

            string FreightLength = "Length";
            string FreightLengthText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[2]/div/div/div/div/div[2]/span");
            string[] ExpectedFreightLength = FreightLengthText.Split(':');
            string FreightLengthLabel = ExpectedFreightLength[0];
            Assert.AreEqual(FreightLength, FreightLengthLabel);

            string FreightWidth = "Width";
            string FreightWidthText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[2]/div/div/div/div/div[3]/span");
            string[] ExpectedFreightWidthText = FreightWidthText.Split(':');
            string FreightWidthTextLabel = ExpectedFreightWidthText[0];
            Assert.AreEqual(FreightWidth, FreightWidthTextLabel);

            string FreightDescription = "Description";
            string FreightDescriptionText = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div/div[3]/div/div/div[2]/div/div/div[5]/div/div/div/div[3]/div/div/div/div/div/span");
            string[] ExpectedFreightDescriptionText = FreightDescriptionText.Split(':');
            string FreightDescriptionTextLabel = ExpectedFreightDescriptionText[0];
            Assert.AreEqual(FreightDescription, FreightDescriptionTextLabel);

            scrollElementIntoView(attributeName_xpath, ReviewSubmit_SubmitShipment_Button_Xpath);

            Report.WriteLine("Verify the Reference no section");
            string ReferenceNumberActual = Gettext(attributeName_xpath, ReviewSubmit_Section_ReferenceNumber_Xpath);
            Assert.AreEqual(ReferenceNo, ReferenceNumberActual);

            Report.WriteLine("Verify the Dafault special Instruction section");
            string DefaultSpecialInsActual = Gettext(attributeName_xpath, ReviewSubmit_Section_DefaultSpecialInstruction_Xpath);
            Assert.AreEqual(DefaultSpecialInstruction, DefaultSpecialInsActual);

            Report.WriteLine("Verify the Insured Value Section");
            string InsuredValueActual = Gettext(attributeName_xpath, ReviewSubmit_Section_InsuredValue_Xpath);
            Assert.AreEqual(InsuredValue, InsuredValueActual);
        }


    }
}
