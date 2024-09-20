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

namespace CRM.UITest.Scripts.QuoteToShipment.LTL
{
    [Binding]
    public class SavedQuotetoShipment_Buttons__Page_ElementsSteps : AddShipments
    {

        [Given(@"I am on the Quote Details Section of the non expired LTL quote (.*),(.*)")]
        public void GivenIAmOnTheQuoteDetailsSectionOfTheNonExpiredLTLQuote(string usertype, string Account)
        {

            Report.WriteLine("I am on the Quote Details Section");
            Click(attributeName_xpath, ".//*[@id='raterequest']/i");
            WaitForElementVisible(attributeName_xpath, "//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div[1]/h1", "Quotes");
            Thread.Sleep(3000);


            if (usertype == "Internal")
            {
                Click(attributeName_xpath, ".//*[@id='CategoryType_chosen']/a/span");

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CategoryType_chosen']/div/ul/li"));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == Account)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }

                Thread.Sleep(500);
                SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");
                Click(attributeName_xpath, ".//*[@id='QuotesGrid_wrapper']/div[1]/div[3]/label[2]/label");

                int row = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
                if (row > 1)
                {
                    Report.WriteLine("Expand the first new Quote in the Quote List ");
                    Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]//*[@class='btn exandableTrigger image-only-sm']");

                    WaitForElementVisible(attributeName_id, "btn-CreateShipment", "Create Shipment");
                    VerifyElementPresent(attributeName_id, "btn-CreateShipment", "Create Shipment");
                    Thread.Sleep(5000);
                }
                else
                {
                    Report.WriteLine("No New Quote found in the List");
                }
            }

            else

            {

                Thread.Sleep(500);
                SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");
                Click(attributeName_xpath, ".//*[@id='QuotesGrid_wrapper']/div[1]/div[3]/label[2]/label");

                int row = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
                if (row > 1)
                {
                    Report.WriteLine("Expand the first new Quote in the Quote List ");
                    Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]//*[@class='btn exandableTrigger image-only-sm']");

                    //Thread.Sleep(10000);
                    WaitForElementVisible(attributeName_id, "btn-CreateShipment", "Create Shipment");
                    VerifyElementPresent(attributeName_id, "btn-CreateShipment", "Create Shipment");


                    Thread.Sleep(500);
                }
                else
                {
                    Report.WriteLine("No New Quote found in the List");
                }
            }
        }

        [Then(@"Verify that in Shipping From Section Zipcode, Country ,City ,State and Service and Assessorials are auto populated and not editable")]
        public void ThenVerifyThatInShippingFromSectionZipcodeCountryCityStateAndServiceAndAssessorialsAreAutoPopulatedAndNotEditable()
        {
            Report.WriteLine("These field should be autpopulated and Not editable");

            Report.WriteLine("Zip Code Field is auto populated and It is not editable");
            string Zipcode = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
            Report.WriteLine("Value Present for ZipCode" + Zipcode);
            IsElementDisabled(attributeName_id, ShippingFrom_zipcode_Id, "Zip code");


            Report.WriteLine("City Field is auto populated and It is not editable");
            string FromCity = GetValue(attributeName_id, ShippingFrom_City_Id, "value");
            Report.WriteLine("Value Present for City" + FromCity);
            IsElementDisabled(attributeName_id, ShippingFrom_City_Id, "Origin City");


            Report.WriteLine("State Field is auto populated and It is not editable");
            string FromState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
            Report.WriteLine("Value Present for State" + FromState);
            IsElementDisabled(attributeName_xpath, ShippingFrom_StateDropdwon_xpath, "State Dropdown");

            Report.WriteLine("Country Field is auto populated and It is not editable");
            string FromCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
            Report.WriteLine("Value Present for Country is" + FromCountry);
            IsElementDisabled(attributeName_xpath, ShippingFrom_CountryDropDown_xpath, "Country");

            Report.WriteLine("Service and Accessorials for Shipping From Section ");
            string ShippingFromServicesAndAccess = Gettext(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
            if (ShippingFromServicesAndAccess != "null")
            {
                Report.WriteLine("Selected Service and Accessorials are" + ShippingFromServicesAndAccess);
                Report.WriteLine("Service and Accessorial is Disabled");
                IsElementDisabled(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath, "service and accessorials");
            }
            else
            {
                Report.WriteLine("Services and accessorials is not selected and not editable");
                IsElementDisabled(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath, "service and accessorials");

            }


        }

        [Then(@"Verify that in Shipping To Section Zipcode, Country ,City ,State and Service and Assessorials are auto populated and not editable")]
        public void ThenVerifyThatInShippingToSectionZipcodeCountryCityStateAndServiceAndAssessorialsAreAutoPopulatedAndNotEditable()
        {
            Report.WriteLine("These field should be autpopulated and Not editable");

            Report.WriteLine("Zip Code Field is auto populated and It is not editable");
            string Zipcode = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
            Report.WriteLine("Value Present for ZipCode" + Zipcode);
            IsElementDisabled(attributeName_id, ShippingTo_zipcode_Id, "Zip code");


            Report.WriteLine("City Field is auto populated and It is not editable");
            string ToCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
            Report.WriteLine("Value Present for City" + ToCity);
            IsElementDisabled(attributeName_id, ShippingTo_City_Id, "Origin City");


            Report.WriteLine("State Field is auto populated and It is not editable");
            string ToState = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
            Report.WriteLine("Value Present for State" + ToState);
            IsElementDisabled(attributeName_xpath, ShippingTo_StateDropdwon_xpath, "State Dropdown");

            Report.WriteLine("Country Field is auto populated and It is not editable");
            string ToCountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
            Report.WriteLine("Value Present for Country" + ToCountry);
            IsElementDisabled(attributeName_xpath, ShippingTo_CountryDropDown_xpath, "Country");

            Report.WriteLine("Service and Accessorials for Shipping To Section ");
            string ShippingToServicesAndAccess = Gettext(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath);
            if (ShippingToServicesAndAccess != "null")
            {
                Report.WriteLine("Selected Service and Accessorials are" + ShippingToServicesAndAccess);
                Report.WriteLine("Service and Accessorial is Disabled");
                IsElementDisabled(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath, "service and accessorials");
            }
            else
            {
                Report.WriteLine("Services and accessorials is not selected and not editable");
                IsElementDisabled(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath, "service and accessorials");

            }

        }

        [Then(@"I will not see the clear address button for Shipping from and Shipping To section")]
        public void ThenIWillNotSeeTheClearAddressButtonForShippingFromAndShippingToSection()
        {
            Report.WriteLine("I will not see the Clear Address button for Shipping From and Shipping To section");
            VerifyElementNotVisible(attributeName_id, ShippingFrom_ClearAddress_Id, "Clear Address");
            VerifyElementNotVisible(attributeName_id, ShippingTo_ClearAddress_Id, "Clear Address");
             
        }


        [Then(@"Verify that in Pick up Date section Date should be autopopulated and not editable")]
        public void ThenVerifyThatInPickUpDateSectionDateShouldBeAutopopulatedAndNotEditable()
        {
            scrollpagedown();

            Report.WriteLine("I should see the Pickup Date Section");
            VerifyElementPresent(attributeName_xpath, ".//*[@id='page-content-wrapper']//*[text()='Pickup Date']", "Pickup Date");
            Report.WriteLine("Pick up date is auto populated and not editable");
            string Pickupdate = GetValue(attributeName_id, PickUpDateCalender_Id, "value");
            Report.WriteLine("Date is autopopulated " + Pickupdate);
            IsElementDisabled(attributeName_id, PickUpDateCalender_Id, "PickupDateto");
        }


        [Then(@"Verify that in Freight Description Section Item ,Quantity ,Quantity type ,Weight and weight type are auto populated and not editable")]
        public void ThenVerifyThatInFreightDescriptionSectionItemQuantityQuantityTypeWeightAndWeightTypeAreAutoPopulatedAndNotEditable()
        {
            scrollpagedown();
            scrollpagedown();

            VerifyElementPresent(attributeName_xpath, ".//*[@id='page-content-wrapper']//*[text()='Freight Description']", "Freight Description");
            Report.WriteLine("Freight class is autopopulated and not editable");
            string Class = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
            Report.WriteLine("Value for Class" + Class);
            IsElementDisabled(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "Select or search for a class or saved items...");



            Report.WriteLine("Freight Quantity is autopopulated and not editable");
            string FrightQuantity = GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
            Report.WriteLine("Value for Freight Quantity" + FrightQuantity);
            IsElementDisabled(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "Enter a quantity...");



            Report.WriteLine("Quantity type is autopopulated and not editable");
            string Quantitytype = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
            Report.WriteLine("Value for Quantity type " + Quantitytype);
            IsElementDisabled(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath, "Quantity type");


            Report.WriteLine("Weight is autopopulated and not editable");
            string Weight = GetValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");
            Report.WriteLine("Value for Weight " + Weight);
            IsElementDisabled(attributeName_id, FreightDesp_FirstItem_Weight_Id, "Enter a weight...");


            Report.WriteLine("Weight type is autopopulated and not editable");
            string Weighttype = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
            Report.WriteLine("Value for Weight Type" + Weighttype);
            IsElementDisabled(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath, "Weight type");

        }

        [Then(@"Verify that Insured Value and Insured type is autopopulated and not editable")]
        public void ThenVerifyThatInsuredValueAndInsuredTypeIsAutopopulatedAndNotEditable()
        {
            scrollpagedown();
            scrollpagedown();


            Report.WriteLine("Value is Present for the Insured Value Field and insured type");
            string Insuredvalue = GetValue(attributeName_id, InsuredValue_TextBox_Id, "value");
            if (Insuredvalue != "null")
            {
                Report.WriteLine("Value is autopopulated for Insured value field" + Insuredvalue);
                Report.WriteLine("And Insured value is disabled");
                IsElementDisabled(attributeName_id, InsuredValue_TextBox_Id, "insvalue");

                string Insuredtype = Gettext(attributeName_xpath, ".//*[@id='instype_chosen']/a");
                Report.WriteLine("Insured type is auto populated" + Insuredtype);
                IsElementDisabled(attributeName_xpath, ".//*[@id='instype_chosen']/a", "value");

            }
            else
            {
                Report.WriteLine("No value is autopopulated for Insured value" + Insuredvalue);
                Report.WriteLine("Insured value and Insured Type both are disabled");
                IsElementDisabled(attributeName_id, InsuredValue_TextBox_Id, "insvalue");
                IsElementDisabled(attributeName_xpath, ".//*[@id='instype_chosen']/a", "value");

            }

        }
        [Then(@"Verfy the fields are editable (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenVerfyTheFieldsAreEditable(string LocationName, string LocationAddress, string LocationAddress2, string Destination, string DestinationAddress, string DestinationAddress2, string nmfc, string item, string length, string width, string height, string dimensions, string defaultspecialins)
        {

            Report.WriteLine("These fields are editable");
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, LocationName);
            string Locationname = GetValue(attributeName_id, ShippingFrom_LocationName_Id, "value");
            Report.WriteLine("Entered the value in field" + Locationname);

            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, LocationAddress);
            string ShippingFromAddress1 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
            Report.WriteLine("Entered the value in field" + ShippingFromAddress1);

            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine2_Id, LocationAddress2);
            string ShippingFromAddress2 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "value");
            Report.WriteLine("Entered the value in field" + ShippingFromAddress2);

            SendKeys(attributeName_id, ShippingTo_LocationName_Id, Destination);
            string DLocationname = GetValue(attributeName_id, ShippingTo_LocationName_Id, "value");
            Report.WriteLine("Entered the value in field" + DLocationname);

            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, DestinationAddress);
            string ShippingToAddress1 = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_Id, "value");
            Report.WriteLine("Enterd the value in field" + ShippingToAddress1);

            SendKeys(attributeName_id, ShippingTo_LocationAddressLine2_Id, DestinationAddress2);
            string ShippingToAddress2 = GetValue(attributeName_id, ShippingTo_LocationAddressLine2_Id, "value");
            Report.WriteLine("Enter the Value in field" + ShippingToAddress2);

            Report.WriteLine("Freight Description section ");
            VerifyElementPresent(attributeName_xpath, FreightDesp_SectionText_xpath, "Freight Description");

            scrollpagedown();
            scrollpagedown();
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, nmfc);
            string NMFCfield = GetValue(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value");
            Report.WriteLine("Enter the value in field" + NMFCfield);

            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, item);
            string Itemdesc = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");
            Report.WriteLine("Enter the value in field" + Itemdesc);

            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, length);
            string Length = GetValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
            Report.WriteLine("Enter the value in field" + Length);

            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, width);
            string Width = GetValue(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            Report.WriteLine("Enter the value in field" + Width);

            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, height);
            string Height = GetValue(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
            Report.WriteLine("Enter the value in field" + Height);

            Click(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='freightdimensiontype_0_chosen']/div/ul/li"));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == dimensions)
                {
                    DropDownList[i].Click();
                    break;
                }
            }

            string Dimensions = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            Report.WriteLine("Selected the Dimensions is" + Dimensions);

            scrollpagedown();
            scrollpagedown();

            VerifyElementPresent(attributeName_xpath, DefaultSpecialIntructions_HeaderText_xpath, "Default special Instruction");
            string DefaultSpecialIns = GetValue(attributeName_id, DefaultSpecialIntructions_Comments_Id, "value");
            if (DefaultSpecialIns == "")
            {
                SendKeys(attributeName_id, DefaultSpecialIntructions_Comments_Id, defaultspecialins);
                string Defaultsend = GetValue(attributeName_id, DefaultSpecialIntructions_Comments_Id, "value");
                Report.WriteLine("Entered Default Special Instruction is " + Defaultsend);
            }
            else
            {
                Clear(attributeName_id, DefaultSpecialIntructions_Comments_Id);
                SendKeys(attributeName_id, DefaultSpecialIntructions_Comments_Id, defaultspecialins);
                string Defaultsend = Gettext(attributeName_id, DefaultSpecialIntructions_Comments_Id);
                Report.WriteLine("Entered Default Special Instruction is " + Defaultsend);

            }

        }


        [Then(@"Verify the in Date section for (.*),(.*) is editable")]
        public void ThenVerifyTheInDateSectionForIsEditable(string ReadyDate, string CloseDate)
        {
            scrollPageup();


            string Ready = Gettext(attributeName_xpath, LTL_PickUpReadyTime_Xpath);
            string Close = Gettext(attributeName_xpath, LTL_PickUpCloseTime_Xpath);

            Report.WriteLine("By default Pick up Ready time is" + Ready + "By default Pickup Close time is" + Close);

            Report.WriteLine("Select the Pickup Reday time ");
            Click(attributeName_xpath, LTL_PickUpReadyTime_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='pickupreadytime_chosen']/div/ul/li"));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == ReadyDate)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            string PickupReadyTime = Gettext(attributeName_xpath, LTL_PickUpReadyTime_Xpath);

            Report.WriteLine("After changing the time is showing " + PickupReadyTime);

            Report.WriteLine("Select the Pickup Close time ");
            Click(attributeName_xpath, LTL_PickUpCloseTime_Xpath);
            IList<IWebElement> DropDownListClose = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='pickupclosetime_chosen']/div/ul/li"));
            int DropDownCountClose = DropDownListClose.Count;
            for (int i = 0; i < DropDownCountClose; i++)
            {
                if (DropDownListClose[i].Text == CloseDate)
                {
                    DropDownListClose[i].Click();
                    break;
                }
            }
            string PickupCloseTime = Gettext(attributeName_xpath, LTL_PickUpCloseTime_Xpath);
            Report.WriteLine("After changing the time is showing " + PickupCloseTime);

        }





    }



}




