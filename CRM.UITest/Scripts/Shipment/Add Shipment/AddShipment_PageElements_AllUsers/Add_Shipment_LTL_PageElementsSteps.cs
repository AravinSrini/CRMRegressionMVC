using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.AddShipment_PageElements_AllUsers
{
    [Binding]
    public class Add_Shipment_LTL_PageElementsSteps : AddShipments
    {
        AddShipmentLTL ltl = new AddShipmentLTL();

        [When(@"I click on add shipment button depending on the UserType (.*) for the (.*)")]
        public void WhenIClickOnAddShipmentButtonDependingOnTheUserTypeForThe(string UserType, string CustomerAccName)
        {
            if (UserType.Equals("ShipEntry") || UserType.Equals("ShipEntryNoRates"))
            {
                Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
            }
            else if (UserType.Equals("Operation") || UserType.Equals("Sales") || UserType.Equals("SalesManagement") || UserType.Equals("StationOwner"))
            {
                Report.WriteLine("Select Customer Name from the dropdown list");
                Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == CustomerAccName)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                Click(attributeName_id, AddShipmentButtionInternal_Id);
            }
            
        }
        
        [When(@"I Select the LTL tile")]
        public void WhenISelectTheLTLTile()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
        }

        [When(@"I arrive on the Add Shipment Ltl page")]
        public void WhenIArriveOnTheAddShipmentLtlPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
        }

        [When(@"I Arrive on Add Shipment Ltl page")]
        public void WhenIArriveOnAddShipmentLtlPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
        }

        [When(@"I Arrived on Add Shipment Ltl page")]
        public void WhenIArrivedOnAddShipmentLtlPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            IList<IWebElement> RemoveItemButtons = GlobalVariables.webDriver.FindElements(By.ClassName(FreightDesp_RemoveItem_Button_Class));
            int RemoveItemButtonsCount = RemoveItemButtons.Count;
            for (int i = 0; i < RemoveItemButtonsCount; i++)
            {
                RemoveItemButtons[i].Click();
            }
            IList<IWebElement> ClearItemButtons = GlobalVariables.webDriver.FindElements(By.ClassName(FreightDesp_ClearItem_Button_Class));
            int ClearItemButtonsCount = ClearItemButtons.Count;
            for (int i = 0; i < ClearItemButtonsCount; i++)
            {
                ClearItemButtons[i].Click();
            }
            scrollPageup();
            Click(attributeName_id, ShippingFrom_LocationName_Id);
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
        }


        [Then(@"I can see the Message for the Required fields (.*)")]
        public void ThenICanSeeTheMessageForTheRequiredFields(string RequiredFieldsMsg)
        {
            Verifytext(attributeName_id, RequiredField_WarningMessage_Id, RequiredFieldsMsg);
        }


        [Then(@"I can see the Shipping From section (.*) with all fields below")]
        public void ThenICanSeeTheShippingFromSectionWithAllFieldsBelow(string ShipFrom_SectionText)
        {
            Verifytext(attributeName_xpath, ShippingFromSectionText_xpath, ShipFrom_SectionText);
        }

        [Then(@"I can see the Shipping From Select or search saved origin address drop down")]
        public void ThenICanSeeTheShippingFromSelectOrSearchSavedOriginAddressDropDown()
        {
            VerifyElementPresent(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "Select or Search Saved Origin Address");
        }

        [Then(@"I can see the Shipping From Clear Address option")]
        public void ThenICanSeeTheShippingFromClearAddressOption()
        {
            VerifyElementPresent(attributeName_id, ShippingFrom_ClearAddress_Id, "Clear Address");
        }

        [Then(@"I can see the Shipping From Location name,")]
        public void ThenICanSeeTheShippingFromLocationName()
        {
            VerifyElementPresent(attributeName_id, ShippingFrom_LocationName_Id, "Location Name");
        }

        [Then(@"I can see Shipping From Address Firstline")]
        public void ThenICanSeeShippingFromAddressFirstline()
        {
            VerifyElementPresent(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "AddressLine1");
        }

        [Then(@"I can see Shipping From Address Secondline")]
        public void ThenICanSeeShippingFromAddressSecondline()
        {
            VerifyElementPresent(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "AddressLine2");
        }

        [Then(@"I can see Shipping From Zipcode")]
        public void ThenICanSeeShippingFromZipcode()
        {
            VerifyElementPresent(attributeName_id, ShippingFrom_zipcode_Id, "Zipcode");
        }

        [Then(@"I can see Shipping From Country drop down and defaulted to United States")]
        public void ThenICanSeeShippingFromCountryDropDownAndDefaultedToUnitedStates()
        {
            VerifyElementPresent(attributeName_xpath, ShippingFrom_CountryDropDown_xpath, "United States");
            string expected = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
            string actual = "United States";
            Assert.AreEqual(expected, actual);
        }

        [Then(@"I can see the Shipping From City text box")]
        public void ThenICanSeeTheShippingFromCityTextBox()
        {
            VerifyElementPresent(attributeName_id, ShippingFrom_City_Id, "City");
            
        }


        [Then(@"I can see Shipping From State/Province drop down")]
        public void ThenICanSeeShippingFromStateProvinceDropDown()
        {

            Verifytext(attributeName_xpath, ShippingFrom_StateDropdwon_xpath, "Select state/province...");
        }

        [Then(@"I can see Shipping From Sevices and Accessorials drop down")]
        public void ThenICanSeeShippingFromSevicesAndAccessorialsDropDown()
        {
            
            VerifyElementPresent(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath, "ServicesAccessorials");
        }

        [Then(@"I can see Shipping From Comments text box")]
        public void ThenICanSeeShippingFromCommentsTextBox()
        {
            VerifyElementPresent(attributeName_id, ShippingFrom_Comments_Id, "Comments");
        }

        [Then(@"I can see the Shipping From Save Origin Information Checkbox")]
        public void ThenICanSeeTheShippingFromSaveOriginInformationCheckbox()
        {
            VerifyElementPresent(attributeName_xpath, ShippingFrom_SaveOriginInfo_Checkbox_xpath, "Save Origin Information");
        }

        [Then(@"I can see the Shipping From View Origin Location on Map link")]
        public void ThenICanSeeTheShippingFromViewOriginLocationOnMapLink()
        {
            VerifyElementPresent(attributeName_id, ShippingFrom_ViewOriginLocationMap_Id, "View Origin Location on Map");
        }


        [Then(@"I can see the Shipping To section (.*) with all fields below")]
        public void ThenICanSeeTheShippingToSectionWithAllFieldsBelow(string ShipTo_SectionText)
        {
            VerifyElementPresent(attributeName_xpath, ShippingToSectionText_xpath, ShipTo_SectionText);
        }


        [Then(@"I can see the Shipping To Select or search saved origin address drop down")]
        public void ThenICanSeeTheShippingToSelectOrSearchSavedOriginAddressDropDown()
        {
            VerifyElementPresent(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id, "Select or Search Saved Destination Address");
        }

        [Then(@"I can see the Shipping To Clear Address option")]
        public void ThenICanSeeTheShippingToClearAddressOption()
        {

            VerifyElementPresent(attributeName_id, ShippingTo_ClearAddress_Id, "Clear Address");
        }

        [Then(@"I can see the Shipping To Location name,")]
        public void ThenICanSeeTheShippingToLocationName()
        {

            VerifyElementPresent(attributeName_id, ShippingTo_LocationName_Id, "Enter destination name...");
        }

        [Then(@"I can see Shipping To Address Firstline")]
        public void ThenICanSeeShippingToAddressFirstline()
        {
            VerifyElementPresent(attributeName_id, ShippingTo_LocationAddressLine1_Id, "Enter destination address...");
        }

        [Then(@"I can see Shipping To Address Secondline")]
        public void ThenICanSeeShippingToAddressSecondline()
        {
            VerifyElementPresent(attributeName_id, ShippingTo_LocationAddressLine2_Id, "Enter destination address line 2...");
        }



        [Then(@"I can see Shipping To Zipcode")]
        public void ThenICanSeeShippingToZipcode()
        {
            VerifyElementPresent(attributeName_id, ShippingTo_zipcode_Id, "Enter zip/postal code...");
        }

        [Then(@"I can see Shipping To Country drop down and defaulted to United States")]
        public void ThenICanSeeShippingToCountryDropDownAndDefaultedToUnitedStates()
        {
            VerifyElementPresent(attributeName_xpath, ShippingTo_CountryDropDown_xpath, "United States");
        }

        [Then(@"I can see the Shipping To City text box")]
        public void ThenICanSeeTheShippingToCityTextBox()
        {
            VerifyElementPresent(attributeName_id, ShippingTo_City_Id, "Enter city...");
        }


        [Then(@"I can see Shipping To State/Province drop down")]
        public void ThenICanSeeShippingToStateProvinceDropDown()
        {
            VerifyElementPresent(attributeName_xpath, ShippingTo_StateDropdwon_xpath, "Select state/province");
        }

        [Then(@"I can see Shipping To Sevices and Accessorials drop down")]
        public void ThenICanSeeShippingToSevicesAndAccessorialsDropDown()
        {
            VerifyElementPresent(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath, "Services & accessorials");

        }

        [Then(@"I can see Shipping To Comments text box")]
        public void ThenICanSeeShippingToCommentsTextBox()
        {
            VerifyElementPresent(attributeName_id, ShippingTo_Comments_Id, "Enter comments...");
        }

        [Then(@"I can see the Shipping To Save Dest Information Checkbox")]
        public void ThenICanSeeTheShippingToSaveDestInformationCheckbox()
        {
            VerifyElementPresent(attributeName_xpath, ShippingTo_SaveDestInfo_Checkbox_xpath, "Save Destination Information");
        }

        [Then(@"I can see the Shipping To View Dest Location on Map link")]
        public void ThenICanSeeTheShippingToViewDestLocationOnMapLink()
        {
            VerifyElementPresent(attributeName_id, ShippingTo_ViewDestLocationMap_Id, "View Destination Location on Map");
        }

        [When(@"I Expand the Shiping From Contact Info section (.*)")]
        public void WhenIExpandTheShipingFromContactInfoSection(string ShippingFromContactInfo)
        {
            
            Verifytext(attributeName_xpath, ShippingFrom_ContactInfo_SectionText_xpath, ShippingFromContactInfo);
            Click(attributeName_xpath, ShippingFrom_ContactInfo_Expand_xpath);
        }


        [Then(@"I can see the Shipping From Contact name")]
        public void ThenICanSeeTheShippingFromContactName()
        {
           
           VerifyElementPresent(attributeName_id, ShippingFrom_ContactName_Id, "Contact Name");

        }

        [Then(@"I can see the Shipping From Contact Email")]
        public void ThenICanSeeTheShippingFromContactEmail()
        {
            VerifyElementPresent(attributeName_id, ShippingFrom_ContactEmail_Id, "Contact email");
        }

        [Then(@"I can see the Shipping From Contact Phone")]
        public void ThenICanSeeTheShippingFromContactPhone()
        {
            VerifyElementPresent(attributeName_id, ShippingFrom_ContactPhone_Id, "Contact phone");
        }

        [Then(@"I can see the Shipping From Contact Fax")]
        public void ThenICanSeeTheShippingFromContactFax()
        {
            VerifyElementPresent(attributeName_id, ShippingFrom_ContactFax_Id, "Contact FAX");
        }

        [Then(@"I Expand the Shiping To Contact Info section (.*)")]
        public void ThenIExpandTheShipingToContactInfoSection(string ShippingToContactInfo)
        {
            string bb = Gettext(attributeName_xpath, ShippingTo_ContactInfo_SectionText_xpath);
            Verifytext(attributeName_xpath, ShippingTo_ContactInfo_SectionText_xpath, ShippingToContactInfo);
            Click(attributeName_xpath, ShippingTo_ContactInfo_Expand_xpath);

        }

        [Then(@"I can see the Shipping To Contact name")]
        public void ThenICanSeeTheShippingToContactName()
        {
            VerifyElementPresent(attributeName_id, ShippingTo_ContactName_Id, "Contact name");
        }
        

        [Then(@"I can see the Shipping To Contact Email")]
        public void ThenICanSeeTheShippingToContactEmail()
        {
            VerifyElementPresent(attributeName_id, ShippingTo_ContactEmail_Id, "Contact email");
        }

        [Then(@"I can see the Shipping To Contact Phone")]
        public void ThenICanSeeTheShippingToContactPhone()
        {
            VerifyElementPresent(attributeName_id, ShippingTo_ContactPhone_Id, "Contact phone");
        }

        [Then(@"I can see the Shipping To Contact Fax")]
        public void ThenICanSeeTheShippingToContactFax()
        {
            VerifyElementPresent(attributeName_id, ShippingTo_ContactFax_Id, "Contact FAX");
        }

        [Then(@"I can see the Pick Up date with Caleder Icon")]
        public void ThenICanSeeThePickUpDateWithCalederIcon()
        {
            string CurrentDate = DateTime.Now.AddDays(0).ToString();            
            string[] Date = CurrentDate.Split(' ');
            string Day = Date[0];
            //int ConvertedDay = Convert.ToInt32(Day);
            VerifyElementPresent(attributeName_id, PickUpDateCalender_Id, "PickUpDate");
            string expected = GetValue(attributeName_id, PickUpDateCalender_Id, "value");
            Assert.AreEqual(expected, Day);
        }

        [Then(@"I can see the PickUp Date Ready Time default value")]
        public void ThenICanSeeThePickUpDateReadyTimeDefaultValue()
        {
            VerifyElementPresent(attributeName_xpath, PickUpDate_ReadyTime_xpath, "PickUpDateReadyTime");
            string expected = Gettext(attributeName_xpath, PickUpDate_ReadyTime_xpath);
            Assert.AreEqual(expected, "Ready 08:00 AM");
        }

        [Then(@"I can see the Pick Up Date Close Time default value")]
        public void ThenICanSeeThePickUpDateCloseTimeDefaultValue()
        {
            VerifyElementPresent(attributeName_xpath, PickUpDate_CloseTime_xpath, "PickUpDateCloseTime");
            string expected = Gettext(attributeName_xpath, PickUpDate_CloseTime_xpath);
            Assert.AreEqual(expected, "Close 05:00 PM");
        }


        [Then(@"I can see the Freight Description Section with header (.*)")]
        public void ThenICanSeeTheFreightDescriptionSectionWithHeader(string FreightDescriptionHeaderText)
        {
            
            Verifytext(attributeName_xpath, FreightDesp_SectionText_xpath, FreightDescriptionHeaderText);
        }


        [Then(@"I can see the Select or search saved items or class drop down")]
        public void ThenICanSeeTheSelectOrSearchSavedItemsOrClassDropDown()
        {
            
            VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "Select or search for a class or saved items...");
        }

        [Then(@"I can see the NMFC text box")]
        public void ThenICanSeeTheNMFCTextBox()
        {
            VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "Enter an NMFC...");
        }

        [Then(@"I can see the Item Description")]
        public void ThenICanSeeTheItemDescription()
        {
            VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "Enter item description...");
        }

        [Then(@"I can see the Quantity text box with Quantity type defaulted to (.*)")]
        public void ThenICanSeeTheQuantityTextBoxWithQuantityTypeDefaultedTo(string DefaultQtyType)
        {
            VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "Enter a quantity...");
            string expected = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
            Assert.AreEqual(expected, DefaultQtyType);

        }

        [Then(@"I can see the Weight text box with Weight type defaulted to (.*)")]
        public void ThenICanSeeTheWeightTextBoxWithWeightTypeDefaultedTo(string DefaultWeightType)
        {
            VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_Weight_Id, "Enter a weight...");
            string expected = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
            Assert.AreEqual(expected, DefaultWeightType);
        }


        [Then(@"I can see the Dimension values with Dimention type")]
        public void ThenICanSeeTheDimensionValuesWithDimentionType()
        {
            VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_Length_Id, "Length");
            VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_Width_Id, "Width");
            VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_Height_Id, "Height");
            string expected = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            Assert.AreEqual(expected, "IN");
        }

        [Then(@"I can see the Estimate Class button")]
        public void ThenICanSeeTheEstimateClassButton()
        {
            VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_EstimateClassButton_Id, "Estimate Class Button");
            OnMouseOver(attributeName_id, FreightDesp_FirstItem_EstimateClassButton_Id);
            string expected = GetValue(attributeName_id, FreightDesp_FirstItem_EstimateClassButton_Id, "data-title");
            Assert.AreEqual(expected, "Estimate Class");

        }

        [Then(@"I can see the Clear Item link")]
        public void ThenICanSeeTheClearItemLink()
        {
            VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id, "Clear Item");
        }

        [Then(@"I can see the Hazardous material section depending on Hazardous selection (.*)")]
        public void ThenICanSeeTheHazardousMaterialSectionDependingOnHazardousSelection(string Haz_Value)
        {

            if (Haz_Value == "Yes")
            {
                Click(attributeName_xpath, FreightDesp_FirstItem_Hazardous_Yes_RadioButton_xpath);
                VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "Enter UN number...");
                VerifyElementPresent(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath, "Select hazmat packing group...");
                VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "Enter emergency response name...");
                VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "Enter CNN number...");
                VerifyElementPresent(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath, "Select hazmat class...");
                VerifyElementPresent(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "Enter emergency response phone...");
            }
            else
            {

                VerifyElementChecked(attributeName_xpath, FreightDesp_FirstItem_Hazardous_No_RadioButton_xpath, "HazardousNoRadio Button");
            }
            
        }

        [Then(@"I can see the Add Additional Item button")]
        public void ThenICanSeeTheAddAdditionalItemButton()
        {
            VerifyElementPresent(attributeName_xpath, FreightDesp_First_AdditionalItem_Button_xpath, "Add Additional Item");
        }

        [Then(@"I can see the Reference Numbers Section with header (.*)")]
        public void ThenICanSeeTheReferenceNumbersSectionWithHeader(string ReferenceNumbers)
        {
            Verifytext(attributeName_xpath, ReferenceNumbers_HeaderText_xpath, ReferenceNumbers);
        }

        [Then(@"I expand the Reference Numbers Section")]
        public void ThenIExpandTheReferenceNumbersSection()
        {
            Thread.Sleep(2000);
            scrollpagedown();
            Thread.Sleep(500);
            scrollpagedown();
            Click(attributeName_xpath, ReferenceNumbers_ExpandSection_xpath);
        }

        [Then(@"I can see the PO_Number, OrderNumber, GL_Code, BOL_Number, PRO_Number, PickUpNumber, DeliveryApptNumber")]
        public void ThenICanSeeThePO_NumberOrderNumberGL_CodeBOL_NumberPRO_NumberPickUpNumberDeliveryApptNumber()
        {
            VerifyElementPresent(attributeName_id, ReferenceNumbers_PONumber_Id, "Enter PO number...");
            VerifyElementPresent(attributeName_id, ReferenceNumbers_OrderNumber_Id, "Enter order number...");
            VerifyElementPresent(attributeName_id, ReferenceNumbers_GLCode_Id, "Enter GL code...");
            VerifyElementPresent(attributeName_id, ReferenceNumbers_BOLNumber_Id, "Enter BOL number...");
            VerifyElementPresent(attributeName_id, ReferenceNumbers_PRONumber_Id, "Enter PRO number...");
            VerifyElementPresent(attributeName_id, ReferenceNumbers_PickUpNumber_Id, "Enter pickup number...");
            VerifyElementPresent(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id, "Enter Delivery appt number...");
        }

        [Then(@"I can see the AddAdditionalReferenceButton")]
        public void ThenICanSeeTheAddAdditionalReferenceButton()
        {
            VerifyElementPresent(attributeName_xpath, AddAdditionalReference_Button_xpath, "Add Additional Reference");
        }


        [Then(@"I can see the Default Special Instructions (.*)")]
        public void ThenICanSeeTheDefaultSpecialInstructions(string DefaultSpecilaIntsructionsText)
        {
            scrollpagedown();
            Thread.Sleep(500);
            scrollpagedown();
            Verifytext(attributeName_xpath, DefaultSpecialIntructions_HeaderText_xpath, DefaultSpecilaIntsructionsText);
        }

        [Then(@"I can see the Default Special Instruction Comments text box")]
        public void ThenICanSeeTheDefaultSpecialInstructionCommentsTextBox()
        {
            
            VerifyElementPresent(attributeName_id, DefaultSpecialIntructions_Comments_Id, "Default Comments");
        }

        [Then(@"I can Insured Value Text (.*), InsuredValue_TextBox , InsuredValue_Type default value, Insured Value ToolTip (.*)")]
        public void ThenICanInsuredValueTextInsuredValue_TextBoxInsuredValue_TypeDefaultValueInsuredValueToolTip(string InsuredValue_Text, string InsuredValue_ToolTip)
        {
            Verifytext(attributeName_xpath, InusredValue_Text_xpath, InsuredValue_Text);
            VerifyElementPresent(attributeName_id, InsuredValue_TextBox_Id, "Enter Insured Value");
            
            Verifytext(attributeName_xpath, InsuredValue_Type_xpath, "New");
            OnMouseOver(attributeName_xpath, InsuredValue_ToolTip_xpath);            
            string expected = GetValue(attributeName_xpath, InsuredValue_ToolTip_xpath, "data-title");          
            Assert.AreEqual(expected, InsuredValue_ToolTip);

        }

        [When(@"I expand the Reference Numbers Section")]
        public void WhenIExpandTheReferenceNumbersSection()
        {
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, ReferenceNumbers_ExpandSection_xpath);
        }

        [Then(@"I can see the Move Type and Inventory Location Type drop downs")]
        public void ThenICanSeeTheMoveTypeAndInventoryLocationTypeDropDowns()
        {
            VerifyElementPresent(attributeName_xpath, ReferenceNumbers_MoveType_DropDown_xpath, "Move Type");
            VerifyElementPresent(attributeName_xpath, ReferenceNumbers_InventoryLocationType_DropDown_xpath, "Inventory Location Type");
        }

        [Then(@"I can see View Rates Button in Add Shipment LTL page")]
        public void ThenICanSeeViewRatesButtonInAddShipmentLTLPage()
        {
            VerifyElementPresent(attributeName_xpath, ViewRatesButton_xpath, "View Rates Button");
        }

        [Then(@"I can see Back To Shipment List Button")]
        public void ThenICanSeeBackToShipmentListButton()
        {
            VerifyElementPresent(attributeName_id, BackToShipmentListButton_Id, "Back To Shipment List");
        }

        [When(@"I click on the View Rates Button")]
        public void WhenIClickOnTheViewRatesButton()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, ViewRatesButton_xpath);
        }

        [Then(@"all the Required fields should be highlighted in Orange Colour")]
        public void ThenAllTheRequiredFieldsShouldBeHighlightedInOrangeColour()
        {
           
            Report.WriteLine("Highlighted all required fields ");
            var colorofHighlighted_ShippingFrom_LocationName_value = GetCSSValue(attributeName_id, ShippingFrom_LocationName_Id, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_ShippingFrom_LocationName_value);
            
            var colorofHighlighted_ShippingFrom_AddrLine1_value = GetCSSValue(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_ShippingFrom_AddrLine1_value);
            
            var colorofHighlighted_ShippingFrom_ZipCode_value = GetCSSValue(attributeName_id, ShippingFrom_zipcode_Id, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_ShippingFrom_ZipCode_value);

            var colorofHighlighted_ShippingTo_LocationName_value = GetCSSValue(attributeName_id, ShippingTo_LocationName_Id, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_ShippingTo_LocationName_value);

            var colorofHighlighted_ShippingTo_AddrLine1_value = GetCSSValue(attributeName_id, ShippingTo_LocationAddressLine1_Id, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_ShippingTo_AddrLine1_value);

            var colorofHighlighted_ShippingTo_ZipCode_value = GetCSSValue(attributeName_id, ShippingTo_zipcode_Id, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_ShippingTo_ZipCode_value);

            var colorofHighlighted_Freight_SelectClass_value = GetCSSValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_Freight_SelectClass_value);

            //var colorofHighlighted_Freight_NMFC_value = GetCSSValue(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "border-color");
            //Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_Freight_NMFC_value);

            var colorofHighlighted_Freight_Quantity_value = GetCSSValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_Freight_Quantity_value);

            var colorofHighlighted_Freight_ItemDescp_value = GetCSSValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_Freight_ItemDescp_value);

            var colorofHighlighted_Freight_Weight_value = GetCSSValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_Freight_Weight_value);

           
            Click(attributeName_xpath, FreightDesp_FirstItem_Hazardous_Yes_RadioButton_xpath);

            var colorofHighlighted_Freight_UNNumber_value = GetCSSValue(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_Freight_UNNumber_value);

            var colorofHighlighted_Freight_CCNNumber_value = GetCSSValue(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_Freight_CCNNumber_value);

            var colorofHighlighted_Freight_HazmatPackageGroup_value = GetCSSValue(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDownOutline_xpath, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_Freight_HazmatPackageGroup_value);

            var colorofHighlighted_Freight_HazmatClass_value = GetCSSValue(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_xpath, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_Freight_HazmatClass_value);

            var colorofHighlighted_Freight_ResponceContactName_value = GetCSSValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_Freight_ResponceContactName_value);

            var colorofHighlighted_Freight_ResponcePhoneNumber_value = GetCSSValue(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "border-color");
            Assert.AreEqual("rgb(255, 184, 69)", colorofHighlighted_Freight_ResponcePhoneNumber_value);

            
        }

        [When(@"I click on Add Shipment button depending on the UserType (.*) for the selected (.*)")]
        public void WhenIClickOnAddShipmentButtonDependingOnTheUserTypeForTheSelected(string UserType, string CustomerName)
        {
            ltl.SelectCustomerFromShipmentList(UserType, CustomerName);
        }



        [Then(@"verify the tab Order for the mandatory fields for the Add Shipment LTL page")]
        public void ThenVerifyTheTabOrderForTheMandatoryFieldsForTheAddShipmentLTLPage()
        {
            Report.WriteLine("Verifying for Tab in Shipping From Location Name field");
            IWebElement _activeElementLocationName = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string LocNameElementId = _activeElementLocationName.GetAttribute("id");
            Assert.AreEqual(LocNameElementId, "txtOrginName");
            _activeElementLocationName.SendKeys(Keys.Tab);

            Report.WriteLine("Verifying for Tab in Shipping From Address Line 1 field");
            IWebElement _activeElementAddr1_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string FromAddrLine1ElementId = _activeElementAddr1_From.GetAttribute("id");
            Assert.AreEqual(FromAddrLine1ElementId, "txtOrginAddr1");
            _activeElementAddr1_From.SendKeys(Keys.Tab);

            Report.WriteLine("Verifying for Tab in Shipping From Zip Code field");
            IWebElement _activeElementZipCode_From = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string FromZipCodeElementId = _activeElementZipCode_From.GetAttribute("id");
            Assert.AreEqual(FromZipCodeElementId, "origin-zip");
            _activeElementZipCode_From.SendKeys(Keys.Tab);

            Report.WriteLine("Verifying for Tab in Shipping To Destination Name field");
            IWebElement _activeElementDestName = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string DestElementId = _activeElementDestName.GetAttribute("id");
            Assert.AreEqual(DestElementId, "txtDestName");
            _activeElementDestName.SendKeys(Keys.Tab);
            

            Report.WriteLine("Verifying for Tab in Shipping To Address Line 1 field");
            IWebElement _activeElementAddr1_To = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string ToAddrLine1ElementId = _activeElementAddr1_To.GetAttribute("id");
            Assert.AreEqual(ToAddrLine1ElementId, "txtDestAddr1");
            _activeElementAddr1_To.SendKeys(Keys.Tab);

            

            Report.WriteLine("Verifying for Tab in Shipping To Zip Code field");
            IWebElement _activeElementZipCode_To = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string ToZipCodeElementId = _activeElementZipCode_To.GetAttribute("id");
            Assert.AreEqual(ToZipCodeElementId, "destination-zip");
            _activeElementZipCode_To.SendKeys(Keys.Tab);

            //Report.WriteLine("Verifying for Tab in PickUp Date field");
            //IWebElement _activeElementPickUpdate = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            //string PickUpDateElementId = _activeElementPickUpdate.GetAttribute("id");
            //Assert.AreEqual(PickUpDateElementId, "PickupDate");
            //_activeElementPickUpdate.SendKeys(Keys.Tab);

            //Report.WriteLine("Verifying for Tab in PickUp Date Ready Time field");
            //IWebElement _activeElementPickUpdateReadyTime = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            ////string PickUpdateReadyTimeElementId = _activeElementPickUpdateReadyTime.GetAttribute("id");
            ////Assert.AreEqual(PickUpdateReadyTimeElementId, "pickupreadytime_chosen");
            //_activeElementPickUpdateReadyTime.SendKeys(Keys.Tab);

            //Report.WriteLine("Verifying for Tab in PickUp Date Close Time field");
            //IWebElement _activeElementPickUpdateCloseTime = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            ////string PickUpdateCloseTimeElementId = _activeElementPickUpdateCloseTime.GetAttribute("id");
            ////Assert.AreEqual(PickUpdateCloseTimeElementId, "pickupclosetime_chosen");
            //_activeElementPickUpdateCloseTime.SendKeys(Keys.Tab);


            Report.WriteLine("Verifying for Tab in Select Class or Saved Item field");
            IWebElement _activeElementSelectClass_Item = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string SelectClass_SavedItemElementId = _activeElementSelectClass_Item.GetAttribute("id");
            Assert.AreEqual(SelectClass_SavedItemElementId, "freightdescription-0");
            _activeElementSelectClass_Item.SendKeys(Keys.Tab);

            //Report.WriteLine("Verifying for Tab in NMFC field");
            //IWebElement _activeElementNMFC = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            //string NMFCElementId = _activeElementNMFC.GetAttribute("id");
            //Assert.AreEqual(NMFCElementId, "freightNMFC-0");
            //_activeElementNMFC.SendKeys(Keys.Tab);

            Report.WriteLine("Verifying for Tab in Quantity field");
            IWebElement _activeElementQuantity = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string QuantityElementId = _activeElementQuantity.GetAttribute("id");
            Assert.AreEqual(QuantityElementId, "freightquantity-0");
            _activeElementQuantity.SendKeys(Keys.Tab);

            Report.WriteLine("Verifying for Tab in Item Description field");
            IWebElement _activeElementItemDescription = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string ItemDescriptionElementId = _activeElementItemDescription.GetAttribute("id");
            Assert.AreEqual(ItemDescriptionElementId, "freightDesc-0");
            _activeElementItemDescription.SendKeys(Keys.Tab);

            Report.WriteLine("Verifying for Tab in Weight field");
            IWebElement _activeElementWeight = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string WeightElementId = _activeElementWeight.GetAttribute("id");
            Assert.AreEqual(WeightElementId, "freightweight-0");
            _activeElementWeight.SendKeys(Keys.Tab);

            Report.WriteLine("Verifying for Tab in View Rates field");
            IWebElement _activeElementViewRates = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string ViewRatesElementClasses = _activeElementViewRates.GetAttribute("class");
            Assert.AreEqual(ViewRatesElementClasses, "btn viewrates fontSize20 btn btn-block btn-warning btn-sm");
            

        }




    }
}


