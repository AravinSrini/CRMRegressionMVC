using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.ShipmentExtract;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_CopyLTLOption_AllUsers
{
    [Binding]
    public class ShipmentList_CopyLTLOption_ContactAndItemSectionsSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();

        ShipmentExtractViewModel shipmentViewModels = null;

        [Given(@"I am a shp\.entry,shp\.entrynorates, operations, sales, sales management or a station user- '(.*)','(.*)'")]
        public void GivenIAmAShp_EntryShp_EntrynoratesOperationsSalesSalesManagementOrAStationUser_(string Username, string Password)
        {
            string username = ConfigurationManager.AppSettings["username-Both"].ToString();
            string password = ConfigurationManager.AppSettings["password-Both"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);

        }

        [Given(@"I click on Copy Shipment button - (.*),(.*)")]
        public ShipmentExtractViewModel GivenIClickOnCopyShipmentButton_(string Usertype, string CustName)
        {
            int shipmentlist = 0;
            Report.WriteLine("Clicking on copy shipment icon for LTL shipment");
            if (Usertype == "Internal")
            {
                Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == CustName)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                Thread.Sleep(90000);
                SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");
                shipmentlist = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
                if (shipmentlist > 1)
                {
                    string refNumber = Gettext(attributeName_xpath, Shipmentlist_FirstRow_RefColumn_Xpath);
                    Click(attributeName_xpath, CopyIconFirst_AddShipmentList_Xpath);
                    Thread.Sleep(5000);
                    Verifytext(attributeName_xpath, CopyShipment_ConfirmMessage_Xpath, "Copy the selected shipment and create a new shipment entry?");

                    string uri = $"MercuryGate/OidLookup";

                    //Building Client
                    BuildHttpClient client = new BuildHttpClient();
                    HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

                    ShipmentExtract ext = new ShipmentExtract();
                    shipmentViewModels = ext.getShipmentData(uri, headers, refNumber, "Admin");
                }
                else
                {
                }
            }
            else
            {
                SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");
                shipmentlist = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
                if (shipmentlist > 1)
                {
                    string refNumber = Gettext(attributeName_xpath, Shipmentlist_FirstRow_RefColumn_Xpath);
                    Click(attributeName_xpath, CopyIconFirst_AddShipmentList_Xpath);
                    Thread.Sleep(50000);
                    Verifytext(attributeName_xpath, CopyShipment_ConfirmMessage_Xpath, "Copy the selected shipment and create a new shipment entry?");

                    string uri = $"MercuryGate/OidLookup";

                    //Building Client
                    BuildHttpClient client = new BuildHttpClient();
                    HttpClient headers = client.BuildHttpClientWithHeaders(CustName, "application/xml");

                    ShipmentExtract ext = new ShipmentExtract();
                    shipmentViewModels = ext.getShipmentData(uri, headers, refNumber, CustName);
                }
                else
                {

                }
            }
            return shipmentViewModels;
        }



        [Given(@"I click on Copy Shipment confirmation button")]
        public void GivenIClickOnCopyShipmentConfirmationButton()
        {
            Report.WriteLine("Click on Copy Shipment button");
            Click(attributeName_id, CopyShipmentConfirmButton_Id);
        }

        [Given(@"I clicked on the Copy Shipment button of an LTL shipment which contains ShipFrom contact information")]
        public void GivenIClickedOnTheCopyShipmentButtonOfAnLTLShipmentWhichContainsShipFromContactInformation()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I clicked on the Copy Shipment button of an LTL shipment which contains ShipTo contact information")]
        public void GivenIClickedOnTheCopyShipmentButtonOfAnLTLShipmentWhichContainsShipToContactInformation()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I clicked on the Copy Shipment button of an LTL shipment which contains Hazardous materials")]
        public ShipmentExtractViewModel GivenIClickedOnTheCopyShipmentButtonOfAnLTLShipmentWhichContainsHazardousMaterials()
        {
            return shipmentViewModels;
        }

        [Given(@"I clicked on the Copy Shipment button of an LTL shipment which contains Add Additional Items")]
        public ShipmentExtractViewModel GivenIClickedOnTheCopyShipmentButtonOfAnLTLShipmentWhichContainsAddAdditionalItems()
        {
            return shipmentViewModels;
        }

        [Given(@"I clicked on the Copy Shipment button of an LTL shipment which contains Add Additional Items and additional items contained hazardous materials")]
        public ShipmentExtractViewModel GivenIClickedOnTheCopyShipmentButtonOfAnLTLShipmentWhichContainsAddAdditionalItemsAndAdditionalItemsContainedHazardousMaterials()
        {
            return shipmentViewModels;
        }

        [Given(@"I clicked on the Copy Shipment button of an LTL shipment which contains Reference numbers")]
        public void GivenIClickedOnTheCopyShipmentButtonOfAnLTLShipmentWhichContainsReferenceNumbers()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I arrive on the Add Shipment \(LTL\) page")]
        public void WhenIArriveOnTheAddShipmentLTLPage()
        {
            Report.WriteLine("Add Shipment page");
            Verifytext(attributeName_xpath, CopyAddShipmentTitle_Xpath, "Add Shipment (LTL)");
        }

        [Then(@"The Shipping From Contact Info section will be collapsed with no original Contact information")]
        public void ThenTheShippingFromContactInfoSectionWillBeCollapsedWithNoOriginalContactInformation()
        {
            scrollpagedown();
            for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
            {
                if (shipmentViewModels.ContactViewModels[i].ContactType.ToLower() == "origin")
                {
                    if (shipmentViewModels.ContactViewModels[i].Name == null && shipmentViewModels.ContactViewModels[i].Phone == null && shipmentViewModels.ContactViewModels[i].Email == null && shipmentViewModels.ContactViewModels[i].Fax == null)
                    {
                        VerifyElementNotVisible(attributeName_id, ShippingFrom_ContactName_Id, "Contact Fields");
                    }
                    else
                    {
                        Report.WriteLine("Unable to verify the shipping from contact collapse functionality as shipment has contact info");
                    }
                }
            }
        }

        [Then(@"The Shipping To Contact Info section will be collapsed with no original Contact information")]
        public void ThenTheShippingToContactInfoSectionWillBeCollapsedWithNoOriginalContactInformation()
        {
            for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
            {
                if (shipmentViewModels.ContactViewModels[i].ContactType.ToLower() == "destination")
                {
                    if (shipmentViewModels.ContactViewModels[i].Name == null && shipmentViewModels.ContactViewModels[i].Phone == null && shipmentViewModels.ContactViewModels[i].Email == null && shipmentViewModels.ContactViewModels[i].Fax == null)
                    {
                        VerifyElementNotVisible(attributeName_id, ShippingTo_ContactName_Id, "Contact Fields");
                    }
                    else
                    {
                        Report.WriteLine("Unable to verify the shipping to contact collapse functionality as shipment has contact info");
                    }
                }
            }
        }

        [Then(@"The Shipping From Contact Info section will be collapsed")]
        public void ThenTheShippingFromContactInfoSectionWillBeCollapsed()
        {
            for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
            {
                if (shipmentViewModels.ContactViewModels[i].ContactType.ToLower() == "destination")
                {
                    if (shipmentViewModels.ContactViewModels[i].Name == null && shipmentViewModels.ContactViewModels[i].Phone == null && shipmentViewModels.ContactViewModels[i].Email == null && shipmentViewModels.ContactViewModels[i].Fax == null)
                    {
                        VerifyElementNotVisible(attributeName_id, ShippingFrom_ContactName_Id, "Contact Fields");
                    }
                    else
                    {
                        Report.WriteLine("Unable to verify the shipping from contact collapse functionality as shipment has contact info");
                    }
                }
            }
        }

        [Then(@"The Shipping To Contact Info section will be collapsed\.")]
        public void ThenTheShippingToContactInfoSectionWillBeCollapsed_()
        {
            Report.WriteLine("Shipping To Contact section without Data");
            if (shipmentViewModels.ContactViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
                {
                    string ShipToContactName = shipmentViewModels.ContactViewModels[i].Name;
                    if (ShipToContactName == null)
                    {
                        VerifyElementNotVisible(attributeName_id, ShippingTo_ContactName_Id, "ContactName");
                        Report.WriteLine("ShipTo Contact section does not contain information hence the section is collaped");
                    }
                    else
                    {
                        VerifyElementPresent(attributeName_id, ShippingTo_ContactName_Id, "ContactName");
                        Report.WriteLine("ShipTo Contact section contains information hence the section is expanded");
                    }

                }
            }
        }

        [Given(@"I clicked on the Copy Shipment button of an LTL shipment which contains ShipFrom contact information - (.*),(.*)")]
        public ShipmentExtractViewModel GivenIClickedOnTheCopyShipmentButtonOfAnLTLShipmentWhichContainsShipFromContactInformation_(string p0, string p1)
        {
            Report.WriteLine("ShipFrom Contact Section which contains Data");
            return shipmentViewModels;
        }


        [Then(@"The Shipping From Contact Info section will be expanded")]
        public void ThenTheShippingFromContactInfoSectionWillBeExpanded()
        {
            scrollpagedown();
            if (shipmentViewModels.ContactViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
                {
                    string ShipFromContactName = shipmentViewModels.ContactViewModels[i].Name;
                    if (ShipFromContactName == string.Empty)
                    {
                        VerifyElementNotVisible(attributeName_id, ShippingFrom_ContactName_Id, "ContactName");
                        Report.WriteLine("ShipFrom Contact section does not contain information hence the section is collaped");
                        break;
                    }
                    else
                    {
                        VerifyElementPresent(attributeName_id, ShippingFrom_ContactName_Id, "ContactName");
                        Report.WriteLine("ShipFrom Contact section contains information hence the section is expanded");

                    }

                }
            }
        }

        [Then(@"All fields are auto populated with values from original shipment in ShipFrom Contact section")]
        public void ThenAllFieldsAreAutoPopulatedWithValuesFromOriginalShipmentInShipFromContactSection()
        {
            Report.WriteLine("ShipFrom Contact Section Values");
            try
            {
                if (shipmentViewModels.ContactViewModels != null)
                {
                    for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
                    {
                        string ShipFromContactName = shipmentViewModels.ContactViewModels[i].Name;
                        VerifyElementPresent(attributeName_id, ShippingFrom_ContactName_Id, "ContactName");
                        string ShipFromNameUI = GetValue(attributeName_id, ShippingFrom_ContactName_Id, "value");
                        Assert.AreEqual(ShipFromContactName.ToUpper(), ShipFromNameUI.ToUpper());

                        string ShipFromContactPhone = shipmentViewModels.ContactViewModels[i].Phone;
                        string ShipFromPhoneUI = GetValue(attributeName_id, ShippingFrom_ContactPhone_Id, "value");
                        Assert.AreEqual(ShipFromContactPhone, ShipFromPhoneUI);

                        string ShipFromContactEmail = shipmentViewModels.ContactViewModels[i].Email;
                        string ShipFromEmailUI = GetValue(attributeName_id, ShippingFrom_ContactEmail_Id, "value");
                        Assert.AreEqual(ShipFromContactEmail, ShipFromEmailUI);

                        string ShipFromConatctFax = shipmentViewModels.ContactViewModels[i].Fax;
                        string ShipFromFax = GetValue(attributeName_id, ShippingFrom_ContactFax_Id, "value");
                        Assert.AreEqual(ShipFromConatctFax, ShipFromFax);
                    }
                }
                else
                {
                    Report.WriteFailure("No Response");
                }
            }
            catch (Exception)
            {
                Thread.Sleep(2000);
                Report.WriteLine("ShipFrom contact section deos not contain Information");
            }
        }

        [Then(@"All of the fields are editable - (.*),(.*),(.*),(.*)")]
        public void ThenAllOfTheFieldsAreEditable_(string FName, string FPhoneNum, string FEmail, string FFax)
        {
            try
            {
                VerifyElementPresent(attributeName_id, ShippingFrom_ContactName_Id, "ContactName");
                SendKeys(attributeName_id, ShippingFrom_ContactName_Id, FName);
                SendKeys(attributeName_id, ShippingFrom_ContactPhone_Id, FPhoneNum);
                SendKeys(attributeName_id, ShippingFrom_ContactEmail_Id, FEmail);
                SendKeys(attributeName_id, ShippingFrom_ContactFax_Id, FFax);
            }
            catch (Exception)
            {
                Thread.Sleep(2000);
                Report.WriteLine("ShipFrom contact section deos not contain Information");
            }
        }

        [Then(@"All of the ShipTo contact Information fields are editable - (.*),(.*),(.*),(.*)")]
        public void ThenAllOfTheShipToContactInformationFieldsAreEditable_(string TName, string TPhoneNum, string TEmail, string TFax)
        {
            try
            {
                VerifyElementPresent(attributeName_id, ShippingTo_ContactName_Id, "ContactName");
                SendKeys(attributeName_id, ShippingTo_ContactName_Id, TName);
                SendKeys(attributeName_id, ShippingTo_ContactPhone_Id, TPhoneNum);
                SendKeys(attributeName_id, ShippingTo_ContactEmail_Id, TEmail);
                SendKeys(attributeName_id, ShippingTo_ContactFax_Id, TFax);
            }
            catch (Exception)
            {
                Thread.Sleep(2000);
                Report.WriteLine("ShipTo contact section deos not contain Information");
            }
        }


        [Then(@"The Shipping To Contact Info section will be expanded")]
        public void ThenTheShippingToContactInfoSectionWillBeExpanded()
        {
            scrollpagedown();
            if (shipmentViewModels.ContactViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
                {
                    string ShipFromContactName = shipmentViewModels.ContactViewModels[i].Name;
                    if (ShipFromContactName == string.Empty)
                    {
                        VerifyElementNotVisible(attributeName_id, ShippingTo_ContactName_Id, "ContactName");
                        Report.WriteLine("ShipTo Contact section does not contain information hence the section is collaped");
                        break;
                    }
                    else
                    {
                        VerifyElementPresent(attributeName_id, ShippingTo_ContactName_Id, "ContactName");
                        Report.WriteLine("ShipTo Contact section contains information hence the section is expanded");

                    }

                }
            }
        }

        [Then(@"All fields are auto populated with values from original shipment in ShipTo contact section")]
        public void ThenAllFieldsAreAutoPopulatedWithValuesFromOriginalShipmentInShipToContactSection()
        {
            Report.WriteLine("ShipTo Contact Section Values");
            try
            {
                if (shipmentViewModels.ContactViewModels != null)
                {
                    for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
                    {
                        string ShipToContactName = shipmentViewModels.ContactViewModels[i].Name;
                        VerifyElementPresent(attributeName_id, ShippingTo_ContactName_Id, "ContactName");
                        string ShipToNameUI = GetValue(attributeName_id, ShippingTo_ContactName_Id, "value");
                        Assert.AreEqual(ShipToContactName.ToUpper(), ShipToNameUI.ToUpper());

                        string ShipToContactPhone = shipmentViewModels.ContactViewModels[i].Phone;
                        string ShipToPhoneUI = GetValue(attributeName_id, ShippingTo_ContactPhone_Id, "value");
                        Assert.AreEqual(ShipToContactPhone, ShipToPhoneUI);

                        string ShipToContactEmail = shipmentViewModels.ContactViewModels[i].Email;
                        string ShipToEmailUI = GetValue(attributeName_id, ShippingTo_ContactEmail_Id, "value");
                        Assert.AreEqual(ShipToContactEmail, ShipToEmailUI);

                        string ShipToConatctFax = shipmentViewModels.ContactViewModels[i].Fax;
                        string ShipToFax = GetValue(attributeName_id, ShippingTo_ContactFax_Id, "value");
                        Assert.AreEqual(ShipToConatctFax, ShipToFax);
                    }
                }
                else
                {
                    Report.WriteFailure("No Response");
                }
            }
            catch (Exception)
            {
                Thread.Sleep(2000);
                Report.WriteLine("ShipTo contact section deos not contain Information");
            }
        }

        [Then(@"The Hazardous Materials section will be expanded")]
        public void ThenTheHazardousMaterialsSectionWillBeExpanded()
        {
            Report.WriteLine("Hazardous Materials section");
            scrollpagedown();
            scrollpagedown();
            if (shipmentViewModels.ItemViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    bool Hazardous = shipmentViewModels.ItemViewModels[i].IsHazardous;
                    if (Hazardous == true)
                    {
                        VerifyElementChecked(attributeName_xpath, FreightDesp_FirstItem_Hazardous_Yes_RadioButton_xpath, "Hazardous");
                        VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "ID");
                    }

                    else if (Hazardous == false)
                    {
                        VerifyElementChecked(attributeName_xpath, FreightDesp_FirstItem_Hazardous_No_RadioButton_xpath, "Hazardous");
                        VerifyElementNotVisible(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "ID");

                    }
                    else
                    {
                        Report.WriteFailure("Invalid");
                    }

                }

            }
            else
            {
                Report.WriteFailure("No Response");
            }
        }

        [Then(@"All fields are auto populated with values from original shipment")]
        public void ThenAllFieldsAreAutoPopulatedWithValuesFromOriginalShipment()
        {
            Report.WriteLine("Hazardous material section values");
            scrollpagedown();
            try
            {
                if (shipmentViewModels.ItemViewModels != null)
                {
                    for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                    {
                        VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "UNNum");
                        string UNNumValue = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.HazMatId;
                        string UNNUMUI = GetValue(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "value");
                        Assert.AreEqual(UNNumValue, UNNUMUI);

                        string CCNNum = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.ContactPhone;
                        string CCNNumUI = GetValue(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "value");
                        if(CCNNum.Contains(CCNNumUI))
                        {
                            Report.WriteLine("CCN number is autopopulated");

                        }
                        else
                        {
                            Report.WriteFailure("Invaild");
                        }
                        

                        string HazGrp = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.PackageGroup;
                        string HazGrpUI = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
                        Assert.AreEqual(HazGrp, HazGrpUI);

                        string HazClass = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.HazMatClass;
                        string HazClassUI = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath);
                        Assert.AreEqual(HazClass, HazClassUI);

                        string EmergencyName = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.ContactName;
                        string EmergencyNameUI = GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "value");
                        Assert.AreEqual(EmergencyName.ToUpper(), EmergencyNameUI.ToUpper());

                        string EmergencyPhone = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.ContactPhone;
                        string EmergencyPhoneUI = GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "value");
                        if(EmergencyPhone.Contains(EmergencyPhoneUI))
                        {
                            Report.WriteLine("Phone number is auto populated");
                        }
                        else
                        {
                            Report.WriteFailure("Invalid");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Thread.Sleep(2000);
                Report.WriteLine("Shipment Does not contain Hazmat Values");
            }
        }

        [Then(@"The Hazardous Materials fields will be editable - (.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenTheHazardousMaterialsFieldsWillBeEditable_(string unNumb, string ccnNumb, string HGroup, string HClass, string EName, string EPhoneNum)
        {
            if (shipmentViewModels.ItemViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string itemDesc = shipmentViewModels.ItemViewModels[i].ItemDescription;
                    string ActualDesc = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");

                    if (ActualDesc == itemDesc)
                    {
                        bool hazMatValue = shipmentViewModels.ItemViewModels[i].IsHazardous;
                        if (hazMatValue == true)
                        {
                            SendKeys(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, unNumb);
                            SendKeys(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, ccnNumb);
                            SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, EName);
                            SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, EPhoneNum);
                            Click(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
                            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_Values_xpath, HGroup);
                            Click(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath);
                            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_Values_xpath, HClass);

                            string actUNNumb = GetValue(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "value");
                            Assert.AreEqual(actUNNumb, unNumb);
                            Report.WriteLine("Edited UN Number " + actUNNumb + "is displayin in UI" + unNumb);

                            string actCCNNumb = GetValue(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "value");
                            actCCNNumb.Contains(ccnNumb);

                            string actphone = GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "value");
                            Report.WriteLine("Edited phone " + actphone + "is displayin in UI" + EPhoneNum);
                           
                            string actName = GetValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "value");
                            Assert.AreEqual(actName, EName);
                            Report.WriteLine("Edited name " + actName + "is displayin in UI" + EName);

                            string actGroup = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
                            Assert.AreEqual(actGroup, HGroup);
                            Report.WriteLine("Edited hazmat group " + actGroup + "is displayin in UI" + HGroup);

                            string actClass = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath);
                            Assert.AreEqual(actClass, HClass);
                            Report.WriteLine("Edited hazmat class " + actClass + "is displayin in UI" + HClass);
                        }
                        else
                        {
                            Report.WriteLine("Unable to verify the hazmat edit funcitonality as selectedshipment does not contain hazmat details");
                        }
                    }
                }
            }
        }

        [Then(@"The Additional Item section will be expanded in the Freight Description section")]
        public void ThenTheAdditionalItemSectionWillBeExpandedInTheFreightDescriptionSection()
        {
            Report.WriteLine("Add Additional Item Section");
            scrollpagedown();
            if (shipmentViewModels.ItemViewModels != null)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string Class = shipmentViewModels.ItemViewModels[i].Classification;
                    if (Class == null)
                    {
                        VerifyElementNotVisible(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "Class");
                        Report.WriteLine("Shipment does not contain Add Additional section");
                    }
                    else
                    {
                        VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "Class");
                        Report.WriteLine("Shipment contains Add Additional section");

                    }

                }
            }
        }

        [Then(@"The Shipping From Contact Info section will be collapsed, if shipment did not contain any Shipping From Contact Info")]
        public void ThenTheShippingFromContactInfoSectionWillBeCollapsedIfShipmentDidNotContainAnyShippingFromContactInfo()
        {
            scrollpagedown();
            for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
            {
                if (shipmentViewModels.ContactViewModels[i].ContactType.ToLower() == "origin")
                {
                    if (shipmentViewModels.ContactViewModels[i].Name == string.Empty && shipmentViewModels.ContactViewModels[i].Phone == string.Empty && shipmentViewModels.ContactViewModels[i].Email == string.Empty && shipmentViewModels.ContactViewModels[i].Fax == string.Empty)
                    {
                        VerifyElementNotVisible(attributeName_id, ShippingFrom_ContactName_Id, "Contact Fields");
                    }
                    else
                    {
                        Report.WriteLine("Unable to verify the shipping from contact collapse functionality as shipment has contact info");
                    }
                }
            }
        }

        [Then(@"The Shipping To Contact Info section will be collapsed , if shipment did not contain any Shipping From Contact Info")]
        public void ThenTheShippingToContactInfoSectionWillBeCollapsedIfShipmentDidNotContainAnyShippingFromContactInfo()
        {
            scrollpagedown();
            for (var i = 0; i < shipmentViewModels.ContactViewModels.Count; i++)
            {
                if (shipmentViewModels.ContactViewModels[i].ContactType.ToLower() == "destination")
                {
                    if (shipmentViewModels.ContactViewModels[i].Name == string.Empty && shipmentViewModels.ContactViewModels[i].Phone == string.Empty && shipmentViewModels.ContactViewModels[i].Email == string.Empty && shipmentViewModels.ContactViewModels[i].Fax == string.Empty)
                    {
                        VerifyElementNotVisible(attributeName_id, ShippingTo_ContactName_Id, "Contact Fields");
                    }
                    else
                    {
                        Report.WriteLine("Unable to verify the shipping to contact collapse functionality as shipment has contact info");
                    }
                }
            }
        }


        [Then(@"I will see the Remove Item button")]
        public void ThenIWillSeeTheRemoveItemButton()
        {
            if (shipmentViewModels.ItemViewModels != null && shipmentViewModels.ItemViewModels.Count > 1)
            {
                VerifyElementVisible(attributeName_xpath, FreightDesp_First_Remove_Button_xpath, "Additional Item");
                Report.WriteLine("Remove button is displaing in UI");
            }
            else
            {
                Report.WriteLine("Unable to verify remove button functionality as additional item does not exists for the selected shipment");
                //Assert.IsTrue(false);
            }
        }

        [Then(@"I am able to edit any information in Additional Item section - (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenIAmAbleToEditAnyInformationInAdditionalItemSection_(string Class, string NMFC, string Quantity, string QuantityType, string ItemDescription, string Weight, string WeightType, string p7, string DLength, string DWidth, string DHeight, string DType)
        {
            Report.WriteLine("Edit Add Additional Information section");
            if (shipmentViewModels.ItemViewModels != null && shipmentViewModels.ItemViewModels.Count > 1)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string itemDesc = shipmentViewModels.ItemViewModels[i].ItemDescription;
                    string ActualDesc = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "value");

                    if (ActualDesc == itemDesc)
                    {
                        Click(attributeName_id, FreightDesp_First_AdditionalItem_ClearItem_Button_Id);
                        Report.WriteLine("Passing data in freight description section");
                        Click(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id);
                        IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));
                        for (int j = 0; j < dropdownValues.Count; j++)
                        {
                            int z = j + 1;
                            string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Text;
                            if (value == Class)
                            {
                                GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + z + "]/p")).Click();
                                break;
                            }
                        }
                        SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, NMFC);
                        SendKeys(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, Quantity);
                        SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, Weight);
                        SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, ItemDescription);
                        SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, DLength);
                        SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, DWidth);
                        SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, DHeight);
                        scrollpagedown();
                        Click(attributeName_xpath, FreightDesp_First_AdditionalItem_QuantityType_xpath);
                        SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_QuantityTypevalues_xpath, QuantityType);
                        Click(attributeName_xpath, FreightDesp_First_AdditionalItem_WeightType_xpath);
                        SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_WeightTypevalues_xpath, WeightType);
                        Click(attributeName_xpath, FreightDesp_First_AdditionalItem_DimensionType_xpath);
                        SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_DimensionTypevalues_xpath, DType);

                        string actualClass = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id, "value");
                        Assert.AreEqual(Class, actualClass);
                        Report.WriteLine("Displaying nmfc in UI " + actualClass + "is matching with API value" + Class);

                        string actualnmfc = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "value");
                        Assert.AreEqual(NMFC, actualnmfc);
                        Report.WriteLine("Displaying nmfc in UI " + actualnmfc + "is matching with API value" + NMFC);

                        string ActualQuantity = GetValue(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "value");
                        Assert.AreEqual(Quantity, ActualQuantity);
                        Report.WriteLine("Displaying quantity in UI " + ActualQuantity + "is matching with API value" + Quantity);

                        string ActualQuantityUnit = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_QuantityType_xpath);
                        Assert.AreEqual(QuantityType, ActualQuantityUnit);
                        Report.WriteLine("Displaying quantity unit in UI " + ActualQuantityUnit + "is matching with API value" + QuantityType);

                        string ActualWeight = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "value");
                        Assert.AreEqual(Weight, ActualWeight);
                        Report.WriteLine("Displaying weight in UI " + ActualWeight + "is matching with API value" + Weight);

                        string actualWeightUnit = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_WeightType_xpath);
                        Assert.AreEqual(WeightType, actualWeightUnit);
                        Report.WriteLine("Displaying weight unit in UI " + actualWeightUnit + "is matching with API value" + WeightType);

                        string actualLength = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "value");
                        Assert.AreEqual(DLength, actualLength);
                        Report.WriteLine("Displaying length in UI " + actualLength + "is matching with API value" + DLength);

                        string actualWidth = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "value");
                        Assert.AreEqual(DWidth, actualWidth);
                        Report.WriteLine("Displaying width in UI " + actualWidth + "is matching with API value" + DWidth);

                        string actualHeight = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "value");
                        Assert.AreEqual(DHeight, actualHeight);
                        Report.WriteLine("Displaying height in UI " + actualHeight + "is matching with API value" + DHeight);

                        string actualDimValue = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_DimensionType_Selected_xpath);
                        Assert.AreEqual(DType, actualDimValue);
                        Report.WriteLine("Displaying dimension value in UI " + actualDimValue + "is matching with API value" + DType);

                        break;
                    }
                    else
                    {
                    }
                }

            }
        }



        [Then(@"The Hazardous Materials section of the additional item will be expanded")]
        public void ThenTheHazardousMaterialsSectionOfTheAdditionalItemWillBeExpanded()
        {
            ScenarioContext.Current.Pending();
        }

      

        [Then(@"The Reference Numbers section will be expanded, if shipment contained reference numbers")]
        public void ThenTheReferenceNumbersSectionWillBeExpandedIfShipmentContainedReferenceNumbers()
        {
            scrollpagedown();
            scrollpagedown();
            List<String> extRefValue = new List<string>();
            string refValue = "PO Number, Order Number, GL_Code, Ship Ref, PRO, Pickup Number, Delivery Appt Nbr, Ship Ref, Cons Ref, CustInvRef, Delivery Appt Nbr, GL_Code, Job Name, Job Number, Manifest Nbr, Order Number, Pickup Appt Nbr, Pickup Number, PO Number, PRO, Product Code, Project Number, Release Nbr, Sales Order, Ship Ref, WorkOrderNbr";
            string[] values = refValue.Split(',');
            foreach (var v in values)
            {
                extRefValue.Add(v);
            }

            if (shipmentViewModels.ReferenceNumbers != null)
            {
                for (int i = 0; i < shipmentViewModels.ReferenceNumbers.Count; i++)
                {
                    if (extRefValue.Contains(shipmentViewModels.ReferenceNumbers[i].Type))
                    {
                        VerifyElementVisible(attributeName_id, ReferenceNumbers_PONumber_Id, "Reference number section");
                        break;
                    }
                }
            }
            else
            {
                Report.WriteLine("Unable to verify the reference number section as selected shipment does not contain reference numbers");
            }
        }

        [Then(@"The reference numbers from the previous shipment will be auto-populated in the corresponding reference number fields of the return shipment,")]
        public void ThenTheReferenceNumbersFromThePreviousShipmentWillBeAuto_PopulatedInTheCorrespondingReferenceNumberFieldsOfTheReturnShipment()
        {
            List<String> extRefValue = new List<string>();
            string refValue = "PO Number, Order Number, GL_Code, Ship Ref, PRO, Pickup Number, Delivery Appt Nbr, Ship Ref, Cons Ref, CustInvRef, Delivery Appt Nbr, GL_Code, Job Name, Job Number, Manifest Nbr, Order Number, Pickup Appt Nbr, Pickup Number, PO Number, PRO, Product Code, Project Number, Release Nbr, Sales Order, Ship Ref, WorkOrderNbr";
            string[] values = refValue.Split(',');
            foreach (var v in values)
            {
                extRefValue.Add(v);
            }

            if (shipmentViewModels.ReferenceNumbers != null)
            {
                for (int i = 0; i < shipmentViewModels.ReferenceNumbers.Count; i++)
                {
                    if (extRefValue.Contains(shipmentViewModels.ReferenceNumbers[i].Type) && shipmentViewModels.ReferenceNumbers[i].Type == "PO Number")
                    {
                        string actPONumber = GetValue(attributeName_id, ReferenceNumbers_PONumber_Id, "value");
                        Assert.AreEqual(shipmentViewModels.ReferenceNumbers[i].ReferenceNumber, actPONumber);
                        Report.WriteLine("Displaying PO number in UI " + actPONumber + "is matching with API " + shipmentViewModels.ReferenceNumbers[i].ReferenceNumber);
                        break;
                    }
                }
            }
            else
            {
                Report.WriteLine("Unable to verify the reference number section as selected shipment does not contain reference numbers");
            }
        }

        [Then(@"I must be able to Edit any of the Reference numbers- (.*), (.*)")]
        public void ThenIMustBeAbleToEditAnyOfTheReferenceNumbers_(string poNumb, string p1)
        {
            List<String> extRefValue = new List<String>();
            string refValue = "PO Number, Order Number, GL_Code, Ship Ref, PRO, Pickup Number, Delivery Appt Nbr, Ship Ref, Cons Ref, CustInvRef, Delivery Appt Nbr, GL_Code, Job Name, Job Number, Manifest Nbr, Order Number, Pickup Appt Nbr, Pickup Number, PO Number, PRO, Product Code, Project Number, Release Nbr, Sales Order, Ship Ref, WorkOrderNbr";
            string[] values = refValue.Split(',');
            foreach (var v in values)
            {
                extRefValue.Add(v);
            }

            if (shipmentViewModels.ReferenceNumbers != null)
            {
                for (int i = 0; i < shipmentViewModels.ReferenceNumbers.Count; i++)
                {
                    if (extRefValue.Contains(shipmentViewModels.ReferenceNumbers[i].Type) && shipmentViewModels.ReferenceNumbers[i].Type == "PO Number")
                    {
                        scrollElementIntoView(attributeName_id, ReferenceNumbers_PONumber_Id);
                        SendKeys(attributeName_id, ReferenceNumbers_PONumber_Id, poNumb);
                        string actPONumber = GetValue(attributeName_id, ReferenceNumbers_PONumber_Id, "value");
                        Assert.AreEqual(poNumb, actPONumber);
                        Report.WriteLine("Edited PO number in UI " + poNumb + "is matching with UI " + actPONumber);
                        break;
                    }
                }
            }
            else
            {
                Report.WriteLine("Unable to verify the reference number section as selected shipment does not contain reference numbers");
            }
        }




        [Then(@"I must be able to add additional reference numbers\.")]
        public void ThenIMustBeAbleToAddAdditionalReferenceNumbers_()
        {
            List<String> extRefValue = new List<string>();
            string refValue = "PO Number, Order Number, GL_Code, Ship Ref, PRO, Pickup Number, Delivery Appt Nbr, Ship Ref, Cons Ref, CustInvRef, Delivery Appt Nbr, GL_Code, Job Name, Job Number, Manifest Nbr, Order Number, Pickup Appt Nbr, Pickup Number, PO Number, PRO, Product Code, Project Number, Release Nbr, Sales Order, Ship Ref, WorkOrderNbr";
            string[] values = refValue.Split(',');
            foreach (var v in values)
            {
                extRefValue.Add(v.Trim());
            }

            if (shipmentViewModels.ReferenceNumbers != null)
            {
                for (int i = 0; i < shipmentViewModels.ReferenceNumbers.Count; i++)
                {
                    if (extRefValue.Contains(shipmentViewModels.ReferenceNumbers[i].Type))
                    {
                        VerifyElementVisible(attributeName_xpath, AddAdditionalReference_Button_xpath, "Reference number section");
                        Report.WriteLine("Add additional reference number button is displaying");
                        break;
                    }
                }
            }
            else
            {
                Report.WriteLine("Unable to verify the reference number section as selected shipment does not contain reference numbers");
            }
        }

        [Then(@"The Additional Item section will be expanded in the Freight Description section, if the shipment contained additional items")]
        public void ThenTheAdditionalItemSectionWillBeExpandedInTheFreightDescriptionSectionIfTheShipmentContainedAdditionalItems()
        {
            if (shipmentViewModels.ItemViewModels != null && shipmentViewModels.ItemViewModels.Count > 1)
            {
                VerifyElementVisible(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id, "Additional Item");
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string itemDesc = shipmentViewModels.ItemViewModels[i].ItemDescription;
                    string ActualDesc = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "value");

                    if (ActualDesc == itemDesc)
                    {
                        scrollpagedown();
                        scrollpagedown();
                        scrollpagedown();

                        string classification = shipmentViewModels.ItemViewModels[i].Classification;
                        string actualClass = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_SavedClassItem_DropDown_Id, "value");
                        Assert.AreEqual(classification, actualClass);
                        Report.WriteLine("Displaying classification in UI " + actualClass + "is matching with API value" + classification);

                        string nmfc = shipmentViewModels.ItemViewModels[i].NmfcCode;
                        string actualnmfc = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "value");
                        Assert.AreEqual(nmfc, actualnmfc);
                        Report.WriteLine("Displaying nmfc in UI " + actualnmfc + "is matching with API value" + nmfc);

                        string quantity = shipmentViewModels.ItemViewModels[i].Quantity;
                        string ActualQuantity = GetValue(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "value");
                        Assert.AreEqual(quantity, ActualQuantity + ".0");
                        Report.WriteLine("Displaying quantity in UI " + ActualQuantity + "is matching with API value" + quantity);

                        string QuanType = shipmentViewModels.ItemViewModels[i].QuantityUnit;
                        string ActualQuanType = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
                        GetQuantityType val = new GetQuantityType();
                        string ExpQuantityType = val.Getquantity(QuanType);
                        Assert.AreEqual(ExpQuantityType, ActualQuanType);

                        string weight = shipmentViewModels.ItemViewModels[i].Weight;
                        string ActualWeight = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "value");
                        Assert.AreEqual(weight, ActualWeight);
                        Report.WriteLine("Displaying weight in UI " + ActualWeight + "is matching with API value" + weight);

                        string WeightType = shipmentViewModels.ItemViewModels[i].WeightUnit;
                        string ActualWeightType = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
                        GetWeightType vals = new GetWeightType();
                        string ExpWeightType = vals.GetWeight(WeightType);
                        Assert.AreEqual(ExpWeightType, ActualWeightType);

                        string length = shipmentViewModels.ItemViewModels[i].Length;
                        string actualLength = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "value");
                        Assert.AreEqual(length, actualLength);
                        Report.WriteLine("Displaying length in UI " + actualLength + "is matching with API value" + length);

                        string width = shipmentViewModels.ItemViewModels[i].Width;
                        string actualWidth = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "value");
                        Assert.AreEqual(width, actualWidth);
                        Report.WriteLine("Displaying width in UI " + actualWidth + "is matching with API value" + width);

                        string height = shipmentViewModels.ItemViewModels[i].Height;
                        string actualHeight = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "value");
                        Assert.AreEqual(height, actualHeight);
                        Report.WriteLine("Displaying height in UI " + actualHeight + "is matching with API value" + height);

                        string dimValue = shipmentViewModels.ItemViewModels[i].DimensionUnit;
                        string actualDimValue = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_DimensionType_Selected_xpath);
                        Assert.AreEqual(dimValue.ToUpper(), actualDimValue);
                        Report.WriteLine("Displaying dimension value in UI " + actualDimValue + "is matching with API value" + dimValue);

                        bool hazMatValue = shipmentViewModels.ItemViewModels[i].IsHazardous;
                        if (hazMatValue == true)
                        {
                            VerifyElementChecked(attributeName_id, FreightDesp_AdditionalItem_Hazardous_Yes_Input_Id, "Hazmat Yes");
                        }
                        else
                        {
                            VerifyElementChecked(attributeName_id, FreightDesp_AdditionalItem_Hazardous_No_Input_Id, "Hazmat No");
                        }
                        break;
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                Report.WriteLine("Unable to verify additional item functionality as additional item does not exists for the selected shipment");

            }
        }

        [Then(@"The Hazardous Materials section will be expanded, when original shipment contains Hazardous materials")]
        public void ThenTheHazardousMaterialsSectionWillBeExpandedWhenOriginalShipmentContainsHazardousMaterials()
        {
            if (shipmentViewModels.ItemViewModels != null)
            {
                scrollpagedown();
                scrollpagedown();
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string itemDesc = shipmentViewModels.ItemViewModels[i].ItemDescription;
                    string ActualDesc = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");

                    if (ActualDesc == itemDesc)
                    {
                        bool hazMatValue = shipmentViewModels.ItemViewModels[i].IsHazardous;
                        if (hazMatValue == true)
                        {
                            VerifyElementVisible(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "UNNumber");
                        }
                        else
                        {
                            Report.WriteLine("Unable to verify the hazmat edit funcitonality as selectedshipment does not contain hazmat details");
                        }
                    }
                }
            }
        }

        [Then(@"The Hazardous Materials section of the additional item will be expanded, if the shipment contained additional hazmat")]
        public void ThenTheHazardousMaterialsSectionOfTheAdditionalItemWillBeExpandedIfTheShipmentContainedAdditionalHazmat()
        {
            scrollpagedown();
            scrollpagedown();
            if (shipmentViewModels.ItemViewModels != null && shipmentViewModels.ItemViewModels.Count > 1)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string itemDesc = shipmentViewModels.ItemViewModels[i].ItemDescription;
                    string ActualDesc = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "value");

                    if (ActualDesc == itemDesc && shipmentViewModels.ItemViewModels[i].IsHazardous == true)
                    {
                        VerifyElementVisible(attributeName_id, FreightDesp_First_AdditionalItem_UN_Number_Id, "Additional hazmat details");
                        Report.WriteLine("Additional item hazmat details expanded");

                        string unNumb = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.HazMatId;
                        string actUNNumber = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_UN_Number_Id, "value");
                        Assert.AreEqual(unNumb, actUNNumber);
                        Report.WriteLine("Displaying un number in UI " + actUNNumber + " is matching with API " + unNumb);

                        string ccNumber = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.ContactPhone;
                        string actccnNumber = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_CCN_Number_Id, "value");
                        ccNumber.Contains(actccnNumber);
                        Report.WriteLine("Displaying ccn number in UI " + actccnNumber + " is matching with API " + ccNumber);

                        string hazGroup = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.PackageGroup;
                        string actGroup = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatPackageGroup_SelectedValue_xpath);
                        Assert.AreEqual(hazGroup, actGroup);
                        Report.WriteLine("Displaying hazmat group in UI " + actGroup + " is matching with API " + hazGroup);

                        string hazClass = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.HazMatClass;
                        string actClass = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatClass_Selectedvalue_xpath);
                        Assert.AreEqual(hazClass, actClass);
                        Report.WriteLine("Displaying hazmat calss in UI " + actClass + " is matching with API " + hazClass);

                        string conPhone = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.ContactPhone;
                        string actConPhone = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_EmergencyReponsePhoneNumber_Id, "value");
                        conPhone.Contains(actConPhone);
                        Report.WriteLine("Displaying hazmat contact phone in UI " + actConPhone + " is matching with API " + conPhone);

                        string conName = shipmentViewModels.ItemViewModels[i].ShipmentImportHazMatDetailViewModels.ContactName;
                        string actConName = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_EmergencyReponseContactName_Id, "value");
                        Assert.AreEqual(conName, actConName);
                        Report.WriteLine("Displaying hazmat contact phone in UI " + actConName + " is matching with API " + conName);
                    }
                    else
                    {
                        Report.WriteLine("Unable to verify additional hazmat details section as selected shipment does not contain additional hazmat details");
                    }
                }
            }
            else
            {
                Report.WriteLine("Unable to verify additional hazmat details section as selected shipment does not contain additional items");
            }
        }

        [Then(@"The additional Hazardous Materials fields will be editable- (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void ThenTheAdditionalHazardousMaterialsFieldsWillBeEditable_And(string unNumb, string ccnNumb, string hazName, string hazPhone, string hazGroup, string hazClass)
        {
            if (shipmentViewModels.ItemViewModels != null && shipmentViewModels.ItemViewModels.Count > 1)
            {
                for (var i = 0; i < shipmentViewModels.ItemViewModels.Count; i++)
                {
                    string itemDesc = shipmentViewModels.ItemViewModels[i].ItemDescription;
                    string ActualDesc = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "value");

                    if (ActualDesc == itemDesc && shipmentViewModels.ItemViewModels[i].IsHazardous == true)
                    {
                        bool hazMatValue = shipmentViewModels.ItemViewModels[i].IsHazardous;
                        if (hazMatValue == true)
                        {
                            scrollpagedown();
                            scrollpagedown();
                            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_UN_Number_Id, unNumb);
                            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_CCN_Number_Id, ccnNumb);
                            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_EmergencyReponseContactName_Id, hazName);
                            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_EmergencyReponsePhoneNumber_Id, hazPhone);
                            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatPackageGroup_DownDown_xpath);
                            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatPackageGroup_DownDown_Values_xpath, hazGroup);
                            Click(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatClass_DropwDown_xpath);
                            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatClass_DropwDown_Values_xpath, hazClass);

                            string actUNNumb = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_UN_Number_Id, "value");
                            Assert.AreEqual(actUNNumb, unNumb);
                            Report.WriteLine("Edited UN Number " + actUNNumb + "is displayin in UI" + unNumb);

                            string actphone = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_EmergencyReponsePhoneNumber_Id, "value");
                            Assert.AreEqual(actphone, hazPhone);
                            Report.WriteLine("Edited contact phone " + actphone + "is displayin in UI" + hazPhone);

                            string actName = GetValue(attributeName_id, FreightDesp_First_AdditionalItem_EmergencyReponseContactName_Id, "value");
                            Assert.AreEqual(actName, hazName);
                            Report.WriteLine("Edited contact name " + actName + "is displayin in UI" + hazName);

                            string actGroup = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatPackageGroup_SelectedValue_xpath);
                            Assert.AreEqual(actGroup, hazGroup);
                            Report.WriteLine("Edited hazmat group " + actGroup + "is displayin in UI" + hazGroup);

                            string actClass = Gettext(attributeName_xpath, FreightDesp_First_AdditionalItem_SelectHazmatClass_Selectedvalue_xpath);
                            Assert.AreEqual(actClass, hazClass);
                            Report.WriteLine("Edited hazmat class " + actClass + "is displayin in UI" + hazClass);
                        }
                        else
                        {
                            Report.WriteLine("Unable to verify additional hazmat details section as selected shipment does not contain additional hazmat details");
                        }
                    }
                }
            }
            else
            {
                Report.WriteLine("Unable to verify additional hazmat details section as selected shipment does not contain additional items");
            }
        }



    }
}
