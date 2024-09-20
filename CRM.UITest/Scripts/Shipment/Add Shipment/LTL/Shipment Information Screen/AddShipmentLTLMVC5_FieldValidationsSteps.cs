using System;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest
{
    [Binding]
    public class AddShipmentLTLMVC5_FieldValidationsSteps : AddShipments

    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();

        [Given(@"I am a shp\.entry, shp\.entrynorates, operations, sales, sales management, or station user (.*) (.*)")]
        public void GivenIAmAShp_EntryShp_EntrynoratesOperationsSalesSalesManagementOrstationUser(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [When(@"I am on  Add Shipment \(LTL\) page in shipment process '(.*)','(.*)'")]
        public void WhenIAmOnAddShipmentLTLPageInShipmentProcess(string UserType, string CustomerName)
        {

            Report.WriteLine("Click on shipment icon");
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            Thread.Sleep(2000);
            Report.WriteLine("Click on Add shipment button");
            if (UserType == "Internal")
            {
                Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == CustomerName)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                Thread.Sleep(500);


                WaitForElementNotVisible(attributeName_xpath, "(//span[@class='style-spin fa fa-spinner fa-spin fa-3x fa-fw'])", "MVC5 Loading Symbol");

                //Added for internal user
                Click(attributeName_id, AddShipmentButtionInternal_Id);
                Thread.Sleep(1000);

                //click on LTL tile
                Click(attributeName_id, ShipmentList_LTLtile_Id);
            }
            else
            {
                //Added for external users
                Thread.Sleep(500);
                Click(attributeName_id, AddShipmentButton_id);
                Thread.Sleep(1000);
                //click on LTL tile
                Click(attributeName_id, ShipmentList_LTLtile_Id);
            }
        }
        [Then(@"NMFC field will accept min character one character max characters twenty characters")]
        public void ThenNMFCFieldWillAcceptMinCharacterOneCharacterMaxCharactersTwentyCharacters()
        {
            Report.WriteLine("NMFCFieldWillAcceptMinCharacterOneCharacterMaxCharactersTwentyCharacters");
            //max length verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "testdatamax_length20");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value").Length;
            Assert.AreEqual(expmaxcharcount, 20);
            Console.WriteLine("NMFC field accepting maximum of 20 charcters");
            Clear(attributeName_id, FreightDesp_FirstItem_NMFC_Id);
            //min length verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "1");
            Thread.Sleep(200);
            int expmincharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value").Length;
            Assert.AreEqual(expmincharcount, 1);
            //more than  max length verification
            Clear(attributeName_id, FreightDesp_FirstItem_NMFC_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "testdatamax_lengthmorethan20");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value").Length;
            if (expmorethanmaxcharcount <= 20)
            {
                Console.WriteLine("NMFC field accepting maximum of 20 charcters");

            }

            else
            {
                throw new Exception("NMFC field accepting more than of 20 charcters");
            }
        }

        [Then(@"Quantity field should accept numeric_whole number_max length of_seven")]
        public void ThenQuantityFieldShouldAcceptNumeric_WholeNumber_MaxLengthOf_Seven()
        {

            Report.WriteLine("QuantityFieldWillAcceptAcceptNumeric_WholeNumber_MaxLengthOf_Seven");
            //max length verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "1234567");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value").Length;
            Assert.AreEqual(expmaxcharcount, 7);
            Console.WriteLine("Quantity field accepting maximum of 7 numerics");
            Clear(attributeName_id, FreightDesp_FirstItem_Quantity_Id);
            //min length verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "1");
            Thread.Sleep(200);
            int expmincharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value").Length;
            Assert.AreEqual(expmincharcount, 1);
            //more than  max length verification
            Clear(attributeName_id, FreightDesp_FirstItem_Quantity_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "12345678");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value").Length;
            if (expmorethanmaxcharcount <= 7)
            {
                Console.WriteLine("quantity field accepting maximum of 7 charcters");

            }

            else
            {
                throw new Exception("quantity field accepting more than of 7 charcters");
            }

            //wholenumber verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "1.5");
            Thread.Sleep(200);
            string expectedwholevalue = GetAttribute(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
            Assert.AreEqual(expectedwholevalue, "15");
            Console.WriteLine("quantity field accepting only whole numbers");


            //alphabetsandspecialcharacters verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "a&*>.wb");
            Thread.Sleep(200);
            string expectedvalue = GetAttribute(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
            Assert.AreEqual(expectedvalue, "");
            Console.WriteLine("quantity field accepting only numerics");
        }

        [Then(@"Weight field should accept numeric_max length of_ten")]
        public void ThenWeightFieldShouldAcceptNumeric_MaxLengthOf_Ten()
        {
            Report.WriteLine("Weight field should accept numeric_max length of_ten");
            //max length verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, "1234567890");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value").Length;
            Assert.AreEqual(expmaxcharcount, 10);
            Console.WriteLine("Weight field accepting maximum of 10 numerics");
            Clear(attributeName_id, FreightDesp_FirstItem_Weight_Id);
            //min length verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, "1");
            Thread.Sleep(200);
            int expmincharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value").Length;
            Assert.AreEqual(expmincharcount, 1);
            //more than  max length verification
            Clear(attributeName_id, FreightDesp_FirstItem_Weight_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, "012345678911");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value").Length;
            if (expmorethanmaxcharcount <= 10)
            {
                Console.WriteLine("Weight field accepting maximum of 10 numerics");

            }

            else
            {
                throw new Exception("weight field accepting more than of 10 numerics");
            }

            //wholenumber verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, "1.5");
            Thread.Sleep(200);
            string expectedwholevalue = GetAttribute(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");
            Assert.AreEqual(expectedwholevalue, "15");
            Console.WriteLine("weight field accepting only whole numbers");


            //alphabetsandspecialcharacters verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, "a&*>.wb");
            Thread.Sleep(200);
            string expectedvalue = GetAttribute(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");
            Assert.AreEqual(expectedvalue, "");
            Console.WriteLine("weight field accepting only numerics");
        }

        [Then(@"DimensionsL fields should accept  numeric_whole number_max length of_three")]
        public void ThenDimensionsLFieldsShouldAcceptNumeric_WholeNumber_MaxLengthOf_Three()
        {
            Report.WriteLine("DimensionsLFieldWillAcceptAcceptNumeric_WholeNumber_MaxLengthOf_three");
            //max length verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, "123");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value").Length;
            Assert.AreEqual(expmaxcharcount, 3);
            Console.WriteLine("Dimensions Length field accepting maximum of 3 numerics");
            Clear(attributeName_id, FreightDesp_FirstItem_Length_Id);
            //min length verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, "1");
            Thread.Sleep(200);
            int expmincharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value").Length;
            Assert.AreEqual(expmincharcount, 1);
            //more than  max length verification
            Clear(attributeName_id, FreightDesp_FirstItem_Length_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, "1234");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value").Length;
            if (expmorethanmaxcharcount <= 3)
            {
                Console.WriteLine("length field accepting maximum of 3 numerics");

            }

            else
            {
                throw new Exception("length field accepting more than of 3 charcters");
            }

            //wholenumber verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, "1.5");
            Thread.Sleep(200);
            string expectedwholevalue = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
            Assert.AreEqual(expectedwholevalue, "15");
            Console.WriteLine("length field accepting only whole numbers");


            //alphabetsandspecialcharacters verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, "a&*>.wb");
            Thread.Sleep(200);
            string expectedvalue = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
            Assert.AreEqual(expectedvalue, "");
            Console.WriteLine("length field accepting only numerics");
        }

        [Then(@"DimensionsW fields should accept  numeric_whole number_max length of_three")]
        public void ThenDimensionsWFieldsShouldAcceptNumeric_WholeNumber_MaxLengthOf_Three()
        {
            Report.WriteLine("DimensionsLFieldWillAcceptAcceptNumeric_WholeNumber_MaxLengthOf_three");
            //max length verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, "123");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value").Length;
            Assert.AreEqual(expmaxcharcount, 3);
            Console.WriteLine("Dimensions Length field accepting maximum of 3 numerics");
            Clear(attributeName_id, FreightDesp_FirstItem_Width_Id);
            //min length verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, "1");
            Thread.Sleep(200);
            int expmincharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value").Length;
            Assert.AreEqual(expmincharcount, 1);
            //more than  max length verification
            Clear(attributeName_id, FreightDesp_FirstItem_Width_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, "1234");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value").Length;
            if (expmorethanmaxcharcount <= 3)
            {
                Console.WriteLine("Width field accepting maximum of 3 numerics");

            }

            else
            {
                throw new Exception("Width field accepting more than of 3 charcters");
            }

            //wholenumber verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, "1.5");
            Thread.Sleep(200);
            string expectedwholevalue = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            Assert.AreEqual(expectedwholevalue, "15");
            Console.WriteLine("width field accepting only whole numbers");


            //alphabetsandspecialcharacters verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, "a&*>.wb");
            Thread.Sleep(200);
            string expectedvalue = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            Assert.AreEqual(expectedvalue, "");
            Console.WriteLine("width field accepting only numerics");
        }

        [Then(@"DimensionsH fields should accept  numeric_whole number_max length of_three")]
        public void ThenDimensionsHFieldsShouldAcceptNumeric_WholeNumber_MaxLengthOf_Three()
        {
            Report.WriteLine("DimensionsLFieldWillAcceptAcceptNumeric_WholeNumber_MaxLengthOf_three");
            //max length verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, "123");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_Height_Id, "value").Length;
            Assert.AreEqual(expmaxcharcount, 3);
            Console.WriteLine("Dimensions Length field accepting maximum of 3 numerics");
            Clear(attributeName_id, FreightDesp_FirstItem_Height_Id);
            //min length verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, "1");
            Thread.Sleep(200);
            int expmincharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_Height_Id, "value").Length;
            Assert.AreEqual(expmincharcount, 1);
            //more than  max length verification
            Clear(attributeName_id, FreightDesp_FirstItem_Height_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, "1234");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_Height_Id, "value").Length;
            if (expmorethanmaxcharcount <= 3)
            {
                Console.WriteLine("Height field accepting maximum of 3 numerics");

            }

            else
            {
                throw new Exception("Height field accepting more than of 3 charcters");
            }

            //wholenumber verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, "1.5");
            Thread.Sleep(200);
            string expectedwholevalue = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            Assert.AreEqual(expectedwholevalue, "15");
            Console.WriteLine("Height field accepting only whole numbers");


            //alphabetsandspecialcharacters verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, "a&*>.wb");
            Thread.Sleep(200);
            string expectedvalue = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            Assert.AreEqual(expectedvalue, "");
            Console.WriteLine("Height field accepting only numerics");
        }

        [Then(@"Item descriptionfield should accept max of_onehundredandfiftyfifty characters")]
        public void ThenItemDescriptionfieldShouldAcceptMaxOf_OnehundredandfiftyfiftyCharacters()
        {
            Report.WriteLine("Item descriptionfield should accept max of_onehundredandfiftyfifty characters");
            //max length verification 
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "testdatamaxilengthof150ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value").Length;
            Assert.AreEqual(expmaxcharcount, 150);
            Console.WriteLine("Item descriptionfield Length field accepting maximum of 150 characters");
            Clear(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id);
            //more than  max length verification
            Clear(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "testdatamaxilengthof150tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttmore150");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value").Length;
            if (expmorethanmaxcharcount <= 150)
            {
                Console.WriteLine("Itemdescription field accepting maximum of 150 chars");

            }

            else
            {
                throw new Exception("Itemdescription field accepting more than of 150 charcters");
            }

        }

        [Then(@"Default Special Instructions should accept max of_twohundredandfifty characters")]
        public void ThenDefaultSpecialInstructionsShouldAcceptMaxOf_TwohundredandfiftyCharacters()
        {
            Report.WriteLine("Item descriptionfield should accept max of_onehundredandfiftyfifty characters");
            //max length verification 
            SendKeys(attributeName_id, DefaultSpecialIntructions_Comments_Id, "SpecialInstructionmaxlegth250testttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_id, DefaultSpecialIntructions_Comments_Id, "value").Length;
            Assert.AreEqual(expmaxcharcount, 250);
            Console.WriteLine("Special Instructions field Length field accepting maximum of 250 characters");
            Clear(attributeName_id, DefaultSpecialIntructions_Comments_Id);
            //more than  max length verification
            Clear(attributeName_id, DefaultSpecialIntructions_Comments_Id);
            SendKeys(attributeName_id, DefaultSpecialIntructions_Comments_Id, "SpecialInstructionmaxlegth250testtttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttmore");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_id, DefaultSpecialIntructions_Comments_Id, "value").Length;
            if (expmorethanmaxcharcount <= 250)
            {
                Console.WriteLine("Special Instructions field accepting maximum of 250 characters");

            }

            else
            {
                throw new Exception("Special Instructions field accepting more than of 250 characters");
            }
        }

        [Then(@"Reference Numbers should accept max of twentyfive_characters")]
        public void ThenReferenceNumbersShouldAcceptMaxOfTwentyfive_Characters()
        {
            Report.WriteLine("ReferenceNumbers fields should accept max of_twentyfive characters");
            Click(attributeName_xpath, ReferenceNumbers_ExpandSection_xpath);
            //max length verification 
            SendKeys(attributeName_id, ReferenceNumbers_PONumber_Id, "testmaxof2512345678910111");
            SendKeys(attributeName_id, ReferenceNumbers_OrderNumber_Id, "testmaxof2512345678910111");
            SendKeys(attributeName_id, ReferenceNumbers_GLCode_Id, "testmaxof2512345678910111");
            SendKeys(attributeName_id, ReferenceNumbers_BOLNumber_Id, "testmaxof2512345678910111");
            SendKeys(attributeName_id, ReferenceNumbers_PRONumber_Id, "testmaxof2512345678910111");
            SendKeys(attributeName_id, ReferenceNumbers_PickUpNumber_Id, "testmaxof2512345678910111");
            SendKeys(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id, "testmaxof2512345678910111");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_id, ReferenceNumbers_PONumber_Id, "value").Length;
            int expmaxcharcount1 = GetAttribute(attributeName_id, ReferenceNumbers_OrderNumber_Id, "value").Length;
            int expmaxcharcount2 = GetAttribute(attributeName_id, ReferenceNumbers_GLCode_Id, "value").Length;
            int expmaxcharcount3 = GetAttribute(attributeName_id, ReferenceNumbers_BOLNumber_Id, "value").Length;
            int expmaxcharcount4 = GetAttribute(attributeName_id, ReferenceNumbers_PRONumber_Id, "value").Length;
            int expmaxcharcount5 = GetAttribute(attributeName_id, ReferenceNumbers_PickUpNumber_Id, "value").Length;
            int expmaxcharcount6 = GetAttribute(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id, "value").Length;
            Assert.AreEqual(expmaxcharcount, 25);
            Assert.AreEqual(expmaxcharcount1, 25);
            Assert.AreEqual(expmaxcharcount2, 25);
            Assert.AreEqual(expmaxcharcount3, 25);
            Assert.AreEqual(expmaxcharcount4, 25);
            Assert.AreEqual(expmaxcharcount5, 25);
            Assert.AreEqual(expmaxcharcount6, 25);

            Console.WriteLine("refernces field Length field accepting maximum of 25 characters");
            Clear(attributeName_id, ReferenceNumbers_PONumber_Id);
            Clear(attributeName_id, ReferenceNumbers_OrderNumber_Id);
            Clear(attributeName_id, ReferenceNumbers_GLCode_Id);
            Clear(attributeName_id, ReferenceNumbers_BOLNumber_Id);
            Clear(attributeName_id, ReferenceNumbers_PRONumber_Id);
            Clear(attributeName_id, ReferenceNumbers_PickUpNumber_Id);
            Clear(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id);
            //more than  max length verification

            SendKeys(attributeName_id, ReferenceNumbers_PONumber_Id, "testmaxof2512345678910111more25");
            SendKeys(attributeName_id, ReferenceNumbers_OrderNumber_Id, "testmaxof2512345678910111more25");
            SendKeys(attributeName_id, ReferenceNumbers_GLCode_Id, "testmaxof2512345678910111more25");
            SendKeys(attributeName_id, ReferenceNumbers_BOLNumber_Id, "testmaxof2512345678910111more25");
            SendKeys(attributeName_id, ReferenceNumbers_PRONumber_Id, "testmaxof2512345678910111more25");
            SendKeys(attributeName_id, ReferenceNumbers_PickUpNumber_Id, "testmaxof2512345678910111more25");
            SendKeys(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id, "testmaxof2512345678910111more25");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_id, ReferenceNumbers_PONumber_Id, "value").Length;
            int expmorethanmaxcharcount1 = GetAttribute(attributeName_id, ReferenceNumbers_OrderNumber_Id, "value").Length;
            int expmorethanmaxcharcount2 = GetAttribute(attributeName_id, ReferenceNumbers_GLCode_Id, "value").Length;
            int expmorethanmaxcharcount3 = GetAttribute(attributeName_id, ReferenceNumbers_BOLNumber_Id, "value").Length;
            int expmorethanmaxcharcount4 = GetAttribute(attributeName_id, ReferenceNumbers_PRONumber_Id, "value").Length;
            int expmorethanmaxcharcount5 = GetAttribute(attributeName_id, ReferenceNumbers_PickUpNumber_Id, "value").Length;
            int expmorethanmaxcharcount6 = GetAttribute(attributeName_id, ReferenceNumbers_DeliveryApptNumber_Id, "value").Length;
            if (expmorethanmaxcharcount <= 25 && expmorethanmaxcharcount1 <= 25 && expmorethanmaxcharcount2 <= 25 && expmorethanmaxcharcount3 <= 25 && expmorethanmaxcharcount4 <= 25 && expmorethanmaxcharcount5 <= 25 && expmorethanmaxcharcount6 <= 25)
            {
                Console.WriteLine("references field accepting maximum of 25 characters");

            }

            else
            {
                throw new Exception("references field accepting more than of 25 dcharacters");
            }
        }

        [Then(@"Reference Numbers should accept max of twentyfive_characters in additional reference number field")]
        public void ThenReferenceNumbersShouldAcceptMaxOfTwentyfive_CharactersInAdditionalReferenceNumberField()
        {

            Report.WriteLine("ReferenceNumbers fields should accept max of_twentyfive characters");
            //max length verification 
            Thread.Sleep(300);
            MoveToElement(attributeName_xpath, AddAdditionalReference_Button_xpath);
            Thread.Sleep(200);
            Click(attributeName_xpath, AddAdditionalReference_Button_xpath);
            Thread.Sleep(200);
            Click(attributeName_xpath, Additional_SelectReferenceType_DropDown_xpath);
            Thread.Sleep(200);
            scrollpagedown();
            SelectDropdownValueFromList(attributeName_xpath, Additional_SelectReferenceType_DropDown_Values_xpath, "Job Number");
            SendKeys(attributeName_xpath, AdditionalReferenceNumber_Value_xpath, "testmaxof2512345678910111");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_xpath, AdditionalReferenceNumber_Value_xpath, "value").Length;
            Assert.AreEqual(expmaxcharcount, 25);
            Console.WriteLine("ReferenceNumbers field accepting max of_twentyfive characters");
            Clear(attributeName_xpath, AdditionalReferenceNumber_Value_xpath);
            SendKeys(attributeName_xpath, AdditionalReferenceNumber_Value_xpath, "testmaxof2512345678910111more25");
            int expmorethanmaxcharcount = GetAttribute(attributeName_xpath, AdditionalReferenceNumber_Value_xpath, "value").Length;
            if (expmorethanmaxcharcount <= 25)
            {
                Console.WriteLine("additional references field accepting maximum of 25 characters");

            }

            else
            {
                throw new Exception("additional references field accepting more than of 25 dcharacters");
            }

        }
        [Then(@"I should display'(.*)' when insval morethanLakh '(.*)'")]
        public void ThenIShouldDisplayWhenInsvalMorethanLakh(string errormessage, int ins)
        {
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, ins.ToString());
            Thread.Sleep(200);
            Verifytext(attributeName_xpath, InsuredValue_ValueExceeds_xpath, errormessage);
        }
                     


        [Then(@"I should display with error message when insured value entered more than(.*) '(.*)'")]
        public void ThenIShouldDisplayWithErrorMessageWhenInsuredValueEnteredMoreThan(string insuredvalmax, string errormessage)
        {
            Report.WriteLine("DisplayWithErrorMessageWhenInsuredValue more than 100,000");
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, insuredvalmax);
            Thread.Sleep(200);
            Verifytext(attributeName_xpath, InsuredValue_ValueExceeds_xpath, errormessage);
            Clear(attributeName_id, InsuredValue_TextBox_Id);
            //test for min length
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, "100");
            VerifyElementNotPresent(attributeName_xpath, InsuredValue_ValueExceeds_xpath, "popup");

        }

        [Then(@"NMFC field will accept min character one character max characters twenty characters of additional item")]
        public void ThenNMFCFieldWillAcceptMinCharacterOneCharacterMaxCharactersTwentyCharactersOfAdditionalItem()
        {
            Report.WriteLine("NMFCFieldWillAcceptMinCharacterOneCharacterMaxCharactersTwentyCharacters");
            //max length verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "testdatamax_length20");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "value").Length;
            Assert.AreEqual(expmaxcharcount, 20);
            Console.WriteLine("NMFC field accepting maximum of 20 charcters");
            Clear(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id);
            //min length verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "1");
            Thread.Sleep(200);
            int expmincharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "value").Length;
            Assert.AreEqual(expmincharcount, 1);
            //more than  max length verification
            Clear(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "testdatamax_lengthmorethan20");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_NMFC_Id, "value").Length;
            if (expmorethanmaxcharcount <= 20)
            {
                Console.WriteLine("NMFC field accepting maximum of 20 charcters");

            }

            else
            {
                throw new Exception("NMFC field accepting more than of 20 charcters");
            }
        }

        [Then(@"Quantity field should accept numeric_whole number_max length of_seven of additional item")]
        public void ThenQuantityFieldShouldAcceptNumeric_WholeNumber_MaxLengthOf_SevenOfAdditionalItem()
        {
            Report.WriteLine("QuantityFieldWillAcceptAcceptNumeric_WholeNumber_MaxLengthOf_Seven");
            //max length verification 
            SendKeys(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "1234567");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "value").Length;
            Assert.AreEqual(expmaxcharcount, 7);
            Console.WriteLine("Quantity field accepting maximum of 7 numerics");
            Clear(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath);
            //min length verification 
            SendKeys(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "1");
            Thread.Sleep(200);
            int expmincharcount = GetAttribute(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "value").Length;
            Assert.AreEqual(expmincharcount, 1);
            //more than  max length verification
            Clear(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath);
            SendKeys(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "12345678");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "value").Length;
            if (expmorethanmaxcharcount <= 7)
            {
                Console.WriteLine("quantity field accepting maximum of 7 charcters");

            }

            else
            {
                throw new Exception("quantity field accepting more than of 7 charcters");
            }

            //wholenumber verification 
            SendKeys(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "1.5");
            Thread.Sleep(200);
            string expectedwholevalue = GetAttribute(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "value");
            Assert.AreEqual(expectedwholevalue, "15");
            Console.WriteLine("quantity field accepting only whole numbers");


            //alphabetsandspecialcharacters verification 
            SendKeys(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "a&*>.wb");
            Thread.Sleep(200);
            string expectedvalue = GetAttribute(attributeName_xpath, FreightDesp_First_AdditionalItem_Quantity_xpath, "value");
            Assert.AreEqual(expectedvalue, "");
            Console.WriteLine("quantity field accepting only numerics");
        }

        [Then(@"Weight field should accept numeric_max length of_ten of additional item")]
        public void ThenWeightFieldShouldAcceptNumeric_MaxLengthOf_TenOfAdditionalItem()
        {
            Report.WriteLine("Weight field should accept numeric_max length of_ten");
            //max length verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "1234567890");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "value").Length;
            Assert.AreEqual(expmaxcharcount, 10);
            Console.WriteLine("Weight field accepting maximum of 10 numerics");
            Clear(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id);
            //min length verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "1");
            Thread.Sleep(200);
            int expmincharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "value").Length;
            Assert.AreEqual(expmincharcount, 1);
            //more than  max length verification
            Clear(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "012345678911");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "value").Length;
            if (expmorethanmaxcharcount <= 10)
            {
                Console.WriteLine("Weight field accepting maximum of 10 numerics");

            }

            else
            {
                throw new Exception("weight field accepting more than of 10 numerics");
            }

            //wholenumber verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "1.5");
            Thread.Sleep(200);
            string expectedwholevalue = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "value");
            Assert.AreEqual(expectedwholevalue, "15");
            Console.WriteLine("weight field accepting only whole numbers");


            //alphabetsandspecialcharacters verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "a&*>.wb");
            Thread.Sleep(200);
            string expectedvalue = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Weight_Id, "value");
            Assert.AreEqual(expectedvalue, "");
            Console.WriteLine("weight field accepting only numerics");
        }

        [Then(@"DimensionsL fields should accept  numeric_whole number_max length of_three of additional item")]
        public void ThenDimensionsLFieldsShouldAcceptNumeric_WholeNumber_MaxLengthOf_TwoOfAdditionalItem()
        {
            Report.WriteLine("DimensionsLFieldWillAcceptAcceptNumeric_WholeNumber_MaxLengthOf_three");
            //max length verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "123");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "value").Length;
            Assert.AreEqual(expmaxcharcount, 3);
            Console.WriteLine("Dimensions Length field accepting maximum of 3 numerics");
            Clear(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id);
            //min length verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "1");
            Thread.Sleep(200);
            int expmincharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "value").Length;
            Assert.AreEqual(expmincharcount, 1);
            //more than  max length verification
            Clear(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "1234");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "value").Length;
            if (expmorethanmaxcharcount <= 3)
            {
                Console.WriteLine("length field accepting maximum of 3 numerics");

            }

            else
            {
                throw new Exception("length field accepting more than of 3 charcters");
            }

            //wholenumber verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "1.5");
            Thread.Sleep(200);
            string expectedwholevalue = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "value");
            Assert.AreEqual(expectedwholevalue, "15");
            Console.WriteLine("length field accepting only whole numbers");


            //alphabetsandspecialcharacters verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "a&*>.wb");
            Thread.Sleep(200);
            string expectedvalue = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Length_Id, "value");
            Assert.AreEqual(expectedvalue, "");
            Console.WriteLine("length field accepting only numerics");
        }

        [Then(@"DimensionsW fields should accept  numeric_whole number_max length of_three of additional item")]
        public void ThenDimensionsWFieldsShouldAcceptNumeric_WholeNumber_MaxLengthOf_ThreeOfAdditionalItem()
        {

            Report.WriteLine("DimensionsLFieldWillAcceptAcceptNumeric_WholeNumber_MaxLengthOf_three");
            //max length verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "123");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "value").Length;
            Assert.AreEqual(expmaxcharcount, 3);
            Console.WriteLine("Dimensions Length field accepting maximum of 3 numerics");
            Clear(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id);
            //min length verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "1");
            Thread.Sleep(200);
            int expmincharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "value").Length;
            Assert.AreEqual(expmincharcount, 1);
            //more than  max length verification
            Clear(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "1234");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "value").Length;
            if (expmorethanmaxcharcount <= 3)
            {
                Console.WriteLine("Width field accepting maximum of 3 numerics");

            }

            else
            {
                throw new Exception("Width field accepting more than of 3 charcters");
            }

            //wholenumber verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "1.5");
            Thread.Sleep(200);
            string expectedwholevalue = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "value");
            Assert.AreEqual(expectedwholevalue, "15");
            Console.WriteLine("width field accepting only whole numbers");


            //alphabetsandspecialcharacters verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "a&*>.wb");
            Thread.Sleep(200);
            string expectedvalue = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Width_Id, "value");
            Assert.AreEqual(expectedvalue, "");
            Console.WriteLine("width field accepting only numerics");
        }

        [Then(@"DimensionsH fields should accept  numeric_whole number_max length of_three of additional item")]
        public void ThenDimensionsHFieldsShouldAcceptNumeric_WholeNumber_MaxLengthOf_ThreeOfAdditionalItem()
        {
            Report.WriteLine("DimensionsLFieldWillAcceptAcceptNumeric_WholeNumber_MaxLengthOf_three");
            //max length verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "123");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "value").Length;
            Assert.AreEqual(expmaxcharcount, 3);
            Console.WriteLine("Dimensions Length field accepting maximum of 3 numerics");
            Clear(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id);
            //min length verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "1");
            Thread.Sleep(200);
            int expmincharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "value").Length;
            Assert.AreEqual(expmincharcount, 1);
            //more than  max length verification
            Clear(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "1234");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "value").Length;
            if (expmorethanmaxcharcount <= 3)
            {
                Console.WriteLine("Height field accepting maximum of 3 numerics");

            }

            else
            {
                throw new Exception("Height field accepting more than of 3 charcters");
            }

            //wholenumber verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "1.5");
            Thread.Sleep(200);
            string expectedwholevalue = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "value");
            Assert.AreEqual(expectedwholevalue, "15");
            Console.WriteLine("Height field accepting only whole numbers");


            //alphabetsandspecialcharacters verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "a&*>.wb");
            Thread.Sleep(200);
            string expectedvalue = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_Height_Id, "value");
            Assert.AreEqual(expectedvalue, "");
            Console.WriteLine("Height field accepting only numerics");
        }

        [Then(@"Item descriptionfield should accept max of_onehundredandfiftyfifty characters of additional item")]
        public void ThenItemDescriptionfieldShouldAcceptMaxOf_OnehundredandfiftyfiftyCharactersOfAdditionalItem()
        {
            Report.WriteLine("Item descriptionfield should accept max of_onehundredandfiftyfifty characters");
            //max length verification 
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "testdatamaxilengthof150ttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt");
            Thread.Sleep(200);
            int expmaxcharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "value").Length;
            Assert.AreEqual(expmaxcharcount, 150);
            Console.WriteLine("Item descriptionfield Length field accepting maximum of 150 characters");
            Clear(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id);
            //more than  max length verification
            Clear(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id);
            SendKeys(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "testdatamaxilengthof150tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttmore150");
            Thread.Sleep(200);
            int expmorethanmaxcharcount = GetAttribute(attributeName_id, FreightDesp_First_AdditionalItem_ItemDescription_Id, "value").Length;
            if (expmorethanmaxcharcount <= 150)
            {
                Console.WriteLine("Itemdescription field accepting maximum of 150 chars");

            }

            else
            {
                throw new Exception("Itemdescription field accepting more than of 150 charcters");
            }
        }

    }
}
