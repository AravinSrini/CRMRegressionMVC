using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;


namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen.OverLength_AddShipment__LTL_
{
    [Binding]
    public class Over_Length___Add_Shipment__LTL____FunctionalitySteps : AddShipments
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        public string CustomerName = "ZZZ - Czar Customer Test";
        public int numberOfAdditionalItems = 2;


        [Given(@"I am a shp\.entry, shp\.entrynorates, sales, sales management, operations, or station owner user")]
        public void GivenIAmAShp_EntryShp_EntrynoratesSalesSalesManagementOperationsOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-ExtuserCustDropdown"].ToString();
            string password = ConfigurationManager.AppSettings["password-ExtuserCustDropdown"].ToString();

            CrmLogin.LoginToCRMApplication(username, password);
        }


        [Given(@"I navigate to the Add Shipment \(LTL\) page")]
        public void GivenINavigateToTheAddShipmentLTLPage()
        {

            Report.WriteLine("Click on the Shipment icon from the left navigation bar");
            Click(attributeName_xpath, ShipmentIcon_Xpath);

            Report.WriteLine("I am on the shipment list page");
            Verifytext(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");

            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);

            Report.WriteLine("Selecting " + CustomerName + "from the Customer drop down list");

            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == CustomerName)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }

            Report.WriteLine("I click on the Add shipment Button");
            Click(attributeName_id, ShipmentList_AddShipmentButton_Id);

            Report.WriteLine("Click on LTL option on tiles page");
            Click(attributeName_id, ShipmentList_LTLtile_Id);
        }


        [When(@"I navigate to the Add Shipment \(LTL\) page")]
        public void WhenINavigateToTheAddShipmentLTLPage()
        {
            Report.WriteLine("Click on the Shipment icon from the left navigation bar");
            Click(attributeName_xpath, ShipmentIcon_Xpath);

            Report.WriteLine("I am on the shipment list page");
            Verifytext(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");

            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);

            Report.WriteLine("Selecting " + CustomerName + "from the Customer drop down list");

            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == CustomerName)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }

            Report.WriteLine("I click on the Add shipment Button");
            Click(attributeName_id, ShipmentList_AddShipmentButton_Id);

            Report.WriteLine("Click on LTL option on tiles page");
            Click(attributeName_id, ShipmentList_LTLtile_Id);
        }


        [When(@"I select the Dimension Type drop down")]
        public void WhenISelectTheDimensionTypeDropDown()
        {
            scrollElementIntoView(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            Click(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
        }

        [Then(@"dimension type selection drop down values should be IN and FT")]
        public void ThenDimensionTypeSelectionDropDownValuesShouldBeINAndFT()
        {
            string values = "IN,FT";
            string[] dimvalues = values.Split(',');
            IList<IWebElement> DimentionType_List = GlobalVariables.webDriver.FindElements(By.XPath(FreightDesp_FirstItem_DimensionType_Values_xpath));
            int DimentionTypeCount = DimentionType_List.Count;

            List<string> DimensionTypeValues = new List<string>();
            foreach (IWebElement element in DimentionType_List)
            {
                DimensionTypeValues.Add((element.Text).ToString());
            }


            Assert.AreEqual(DimentionType_List.Count, DimensionTypeValues.Count);
            for (int i = 0; i < DimentionTypeCount; i++)
            {
                if (DimensionTypeValues.Contains(DimentionType_List[i].Text))
                {
                    Report.WriteLine("Option" + DimentionType_List[i].Text + " is displaying under dimension type dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + DimentionType_List[i].Text + " is not displaying under dimension type dropdown");
                    Assert.IsTrue(false);
                }

            }


        }

        [Then(@"dimension type selection drop down values should be IN and FT for additional items")]
        public void ThenDimensionTypeSelectionDropDownValuesShouldBeINAndFTForAdditionalItems()
        {
            List<string> DimensionTypeValues = new List<string>();

            Report.WriteLine("Adding two additional items");
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_Length_Id);
            Click(attributeName_xpath, AddAdditionalItemButton_xpath);

            string values = "IN,FT";
            string[] dimvalues = values.Split(',');
            Click(attributeName_xpath, FreightDesp_SecondItem_DimensionType_xpath);
            IList<IWebElement> DimentionType_List = GlobalVariables.webDriver.FindElements(By.XPath(FreightDesp_SecondItem_DimensionType_Values_xpath));
            int DimentionTypeCount = DimentionType_List.Count;

            foreach (IWebElement element in DimentionType_List)
            {
                DimensionTypeValues.Add((element.Text).ToString());
            }


            Assert.AreEqual(DimentionType_List.Count, DimensionTypeValues.Count);
            for (int i = 0; i < DimentionTypeCount; i++)
            {
                if (DimensionTypeValues.Contains(DimentionType_List[i].Text))
                {
                    Report.WriteLine("Option" + DimentionType_List[i].Text + " is displaying under dimension type dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + DimentionType_List[i].Text + " is not displaying under dimension type dropdown");
                    Assert.IsTrue(false);
                }

            }

        }



        [When(@"I select Overlength as Services and accessorials from Shipping From Section")]
        public void WhenISelectOverlengthAsServicesAndAccessorialsFromShippingFromSection()
        {
            scrollpagedown();

            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
            IList<IWebElement> AccessorialDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_ServicesAccessorial_DropDown_Values_xpath));
            int AccessorialDropdownListCount = AccessorialDropdown_List.Count;
            for (int i = 0; i < AccessorialDropdownListCount; i++)
            {
                if (AccessorialDropdown_List[i].Text == "Overlength")
                {
                    AccessorialDropdown_List[i].Click();
                    break;
                }
            }
        }


        [Then(@"the Dimension fields Length, Width and Height should be the required fields")]
        public void ThenTheDimensionFieldsLengthWidthAndHeightShouldBeTheRequiredFields()
        {
           
            scrollpagedown();
            scrollElementIntoView(attributeName_xpath, AddAdditionalItemButton_xpath);
            Click(attributeName_xpath, AddAdditionalItemButton_xpath);
            scrollElementIntoView(attributeName_xpath, AddAdditionalItemButton_xpath);
            Click(attributeName_xpath, AddAdditionalItemButton_xpath);
            for (int i = 0; i< 3; i++)
            {

            string Length = GetCSSValue(attributeName_id, "freightlength-"+i+"", "border-color");
            string ExpLength = "rgb(255, 184, 69)";
            Assert.AreEqual(Length, ExpLength);

            string Width = GetCSSValue(attributeName_id, "freightwidth-"+i+"", "border-color");
            string ExpWidth = "rgb(255, 184, 69)";
            Assert.AreEqual(Width, ExpWidth);

            string Height = GetCSSValue(attributeName_id, "freightheight-"+i+"", "border-color");
            string ExpHeight = "rgb(255, 184, 69)";
            Assert.AreEqual(Height, ExpHeight);
            }
        }

        [Then(@"the Dimension fields Length, Width and Height should not be the required fields")]
        public void ThenTheDimensionFieldsLengthWidthAndHeightShouldNotBeTheRequiredFields()
        {
            string ExpLengthWidthHeightBorderColor = "rgb(209, 211, 212)";

            string Length = GetCSSValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "border-color");
            Assert.AreEqual(Length, ExpLengthWidthHeightBorderColor);

            string Width = GetCSSValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "border-color");
            Assert.AreEqual(Width, ExpLengthWidthHeightBorderColor);

            string Height = GetCSSValue(attributeName_id, FreightDesp_FirstItem_Length_Id, "border-color");
            Assert.AreEqual(Height, ExpLengthWidthHeightBorderColor);
        }





        [When(@"I select Overlength as Services and accessorials from Shipping To Section")]
        public void WhenISelectOverlengthAsServicesAndAccessorialsFromShippingToSection()
        {

            scrollpagedown();
            
            Click(attributeName_xpath, Overlength_ShippingTo_ServicesAccessorial_DropDown_xpath);
            IList<IWebElement> AccessorialDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(Overlength_ShippingTo_ServicesAccessorial_DropDown_Values_xpath));
            int AccessorialDropdownListCount = AccessorialDropdown_List.Count;
            for (int i = 0; i < AccessorialDropdownListCount; i++)
            {
                if (AccessorialDropdown_List[i].Text == "Overlength")
                {
                    AccessorialDropdown_List[i].Click();
                    break;
                }
            }
        }

        [When(@"the entered value of length field is equal to or greater than (.*) inches (.*)")]
        public void WhenTheEnteredValueOfLengthFieldIsEqualToOrGreaterThanInches(int p0, string Inches)
        {
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, Inches);
        }


        [Then(@"the Overlength should be auto populated in the services and accessorials of Shipping From section")]
        public void ThenTheOverlengthShouldBeAutoPopulatedInTheServicesAndAccessorialsOfShippingFromSection()
        {
            ScrollToTopElement(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
            Verifytext(attributeName_xpath, ServicesAccessorialsOverlengthSelected_xpath, "Overlength");
        }

        [Then(@"I have the option to remove the Overlength accessorial from Shipping From Section")]
        public void ThenIHaveTheOptionToRemoveTheOverlengthAccessorialFromShippingFromSection()
        {
            Click(attributeName_xpath, ServicesAccessorialsOverlengthRemoval_xpath);
        }

        [Then(@"I have the option to add any other accessorial in Shipping From Section")]
        public void ThenIHaveTheOptionToAddAnyOtherAccessorialInShippingFromSection()
        {
            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
            IList<IWebElement> AccessorialDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_ServicesAccessorial_DropDown_Values_xpath));
            int AccessorialDropdownListCount = AccessorialDropdown_List.Count;
            for (int i = 0; i < AccessorialDropdownListCount; i++)
            {
                if (AccessorialDropdown_List[i].Text == "Appointment")
                {
                    AccessorialDropdown_List[i].Click();
                    break;
                }
            }
        }

        [When(@"the entered value of length field is equal to or greater than (.*) feet (.*)")]
        public void WhenTheEnteredValueOfLengthFieldIsEqualToOrGreaterThanFeet(int p0, string Feet)
        {
            scrollElementIntoView(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            Click(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            IList<IWebElement> AccessorialDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(FreightDesp_FirstItem_DimensionType_Values_xpath));
            int AccessorialDropdownListCount = AccessorialDropdown_List.Count;
            for (int i = 0; i < AccessorialDropdownListCount; i++)
            {
                if (AccessorialDropdown_List[i].Text == "FT")
                {
                    AccessorialDropdown_List[i].Click();
                    break;
                }
            }

            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, Feet);

        }

        [When(@"the entered value of length field is less than (.*) inches (.*)")]
        public void WhenTheEnteredValueOfLengthFieldIsLessThanInches(int p0, string p1)
        {
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            //scrollElementIntoView(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            Click(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            IList<IWebElement> AccessorialDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(FreightDesp_FirstItem_DimensionType_Values_xpath));
            int AccessorialDropdownListCount = AccessorialDropdown_List.Count;
            for (int i = 0; i < AccessorialDropdownListCount; i++)
            {
                if (AccessorialDropdown_List[i].Text == "IN")
                {
                    AccessorialDropdown_List[i].Click();
                    break;
                }
            }
            string DimensionLength = Regex.Replace(p1, @"(\s+|&|'|\(|\)|<|>|#)", "");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, DimensionLength);
        }

        [When(@"the entered value of length field is less than (.*) feet (.*)")]
        public void WhenTheEnteredValueOfLengthFieldIsLessThanFeet(int p0, string p1)
        {
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            //scrollElementIntoView(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            Click(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            IList<IWebElement> AccessorialDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(FreightDesp_FirstItem_DimensionType_Values_xpath));
            int AccessorialDropdownListCount = AccessorialDropdown_List.Count;
            for (int i = 0; i < AccessorialDropdownListCount; i++)
            {
                if (AccessorialDropdown_List[i].Text == "FT")
                {
                    AccessorialDropdown_List[i].Click();
                    break;
                }
            }

            string DimensionLength = Regex.Replace(p1, @"(\s+|&|'|\(|\)|<|>|#)", "");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, DimensionLength);
        }



        [Then(@"the Overlength accessorial is not auto selected in the services and accessorial section of Shipping From Section")]
        public void ThenTheOverlengthAccessorialIsNotAutoSelectedInTheServicesAndAccessorialSectionOfShippingFromSection()
        {
            ScrollToTopElement(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
            string str = Gettext(attributeName_xpath,".//*[@id='shippingfromaccessorial_chosen']/ul/li");
            
            if (str == "")
            {
                Report.WriteLine("Overlength service and accessorial is not auto selected when I enter length less than 96 Inches");
            }
            else if(str == "Overlength")
            {
                Report.WriteLine("Overlength service and accessorial is auto selected when I enter length less than 96 Inches");
                Assert.Fail();
            }
            else
            {

                Report.WriteLine("Service and accessorial other than Overlength is auto selected when I enter length less than 96 Inches");
            }
        }


        [Then(@"I can see the warning popup with verbiage (.*)")]
        public void ThenICanSeeTheWarningPopupWithVerbiage(string p0)
        {

            string message = "The entered Length exceeds the standard LTL threshold of 8 feet. Additional carrier fees may apply.";
            VerifyElementPresent(attributeName_xpath, OverlengthWarningPopup_xpath, "Warning Popup");
            string warningmsg = Gettext(attributeName_xpath, OverLenghtWarningPopupMessage_xpath);
            Assert.AreEqual(message, warningmsg);
            
        }

        [Then(@"I can see the warning popup message with verbiage '(.*)'")]
        public void ThenICanSeeTheWarningPopupMessageWithVerbiage(string message)
        {
            message = "Additional carrier fees may apply due to the selection of the Overlength accessorial.";
            VerifyElementPresent(attributeName_xpath, OverlengthWarningPopup_xpath, "Warning Popup");
            Verifytext(attributeName_xpath, OverLenghtWarningPopupMessage_xpath, message);
        }


        [Then(@"I also have option to remove the warning popup")]
        public void ThenIAlsoHaveOptionToRemoveTheWarningPopup()
        {
            
            Click(attributeName_xpath, OverLengthWarningMessageRemovalButton_xpath);
           
        }

        [Given(@"I select Overlength as Services and accessorials from Shipping From Section")]
        public void GivenISelectOverlengthAsServicesAndAccessorialsFromShippingFromSection()
        {
            scrollpagedown();
            
            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
            IList<IWebElement> AccessorialDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_ServicesAccessorial_DropDown_Values_xpath));
            int AccessorialDropdownListCount = AccessorialDropdown_List.Count;
            for (int i = 0; i < AccessorialDropdownListCount; i++)
            {
                if (AccessorialDropdown_List[i].Text == "Overlength")
                {
                    AccessorialDropdown_List[i].Click();
                    break;
                }
            }
        }

        [When(@"I select any Services and accessorials other than Overlength from Shipping From Section")]
        public void WhenISelectAnyServicesAndAccessorialsOtherThanOverlengthFromShippingFromSection()
        {
            scrollpagedown();
            
            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
            IList<IWebElement> AccessorialDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_ServicesAccessorial_DropDown_Values_xpath));
            int AccessorialDropdownListCount = AccessorialDropdown_List.Count;
            for (int i = 0; i < AccessorialDropdownListCount; i++)
            {
                if (AccessorialDropdown_List[i].Text == "Appointment")
                {
                    AccessorialDropdown_List[i].Click();
                    break;
                }
            }
        }


        [When(@"I enter a value in the length field")]
        public void WhenIEnterAValueInTheLengthField()
        {
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_Length_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, "10");
        }

        [Given(@"I select Overlength as Services and accessorials from Shipping To Section")]
        public void GivenISelectOverlengthAsServicesAndAccessorialsFromShippingToSection()
        {
            scrollpagedown();
            scrollElementIntoView(attributeName_xpath, Overlength_ShippingTo_ServicesAccessorial_DropDown_xpath);
            Click(attributeName_xpath, Overlength_ShippingTo_ServicesAccessorial_DropDown_xpath);
            IList<IWebElement> AccessorialDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(Overlength_ShippingTo_ServicesAccessorial_DropDown_Values_xpath));
            int AccessorialDropdownListCount = AccessorialDropdown_List.Count;
            for (int i = 0; i < AccessorialDropdownListCount; i++)
            {
                if (AccessorialDropdown_List[i].Text == "Overlength")
                {
                    AccessorialDropdown_List[i].Click();
                    break;
                }
            }
        }


        [When(@"I select any Services and accessorials other than Overlength from Shipping To Section")]
        public void WhenISelectAnyServicesAndAccessorialsOtherThanOverlengthFromShippingToSection()
        {
            scrollpagedown();
            
            Click(attributeName_xpath, Overlength_ShippingTo_ServicesAccessorial_DropDown_xpath);
            IList<IWebElement> AccessorialDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(Overlength_ShippingTo_ServicesAccessorial_DropDown_Values_xpath));
            int AccessorialDropdownListCount = AccessorialDropdown_List.Count;
            for (int i = 0; i < AccessorialDropdownListCount; i++)
            {
                if (AccessorialDropdown_List[i].Text == "COD")
                {
                    AccessorialDropdown_List[i].Click();
                    break;
                }
            }
        }

        //Validation
        [Then(@"I am not allowed to enter negative value in Length, Width and Height fields (.*)")]
        public void ThenIAmNotAllowedToEnterNegativeValueInLengthWidthAndHeightFields(string negativeValue)
        {
            Report.WriteLine("I am not allowed to enter Negative value in Length, Width, Height field");
            string enteredValue = Regex.Replace(negativeValue, @"(\s+|&|'|\(|\)|<|>|#)", "");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, enteredValue);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, enteredValue);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, enteredValue);

            string length = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
            string width = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            string height = GetAttribute(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");

            if (Convert.ToInt32(length) > 0)
            {
                Report.WriteLine("Length field is not accepting negative values");
            }
            else
            {
                Report.WriteFailure("Length field is accepting negative values");
            }
            if (Convert.ToInt32(width) > 0)
            {
                Report.WriteLine("Width field is not accepting negative values");
            }
            else
            {
                Report.WriteFailure("width field is accepting negative values");
            }
            if (Convert.ToInt32(height) > 0)
            {
                Report.WriteLine("Height field is not accepting negative values");
            }
            else
            {
                Report.WriteFailure("Height field is accepting negative values");
            }
        }

        [Then(@"the Minimum value accepted in Length, Width and Height fields is (.*)")]
        public void ThenTheMinimumValueAcceptedInLengthWidthAndHeightFieldsIs(int p0)
        {
            Report.WriteLine("the Minimum value accepted in Length, Width, Height field is**");
            string length;
            string width;
            string height;

            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, "0");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, "0");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, "0");

            length = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
            width = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            height = GetAttribute(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");

            if (length == string.Empty && width == string.Empty && height == string.Empty)
            {
                Report.WriteLine("dimeansion fields are not accepting 0");
            }
            else
            {
                Report.WriteFailure("dimeansion fields are accepting 0");
            }


            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, "1");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, "1");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, "1");

            length = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
            width = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            height = GetAttribute(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");

            if (length == "1" && width == "1" && height == "1")
            {
                Report.WriteLine("dimeansion fields are accepting 1");
            }
            else
            {
                Report.WriteFailure("dimeansion fields are not accepting 1");
            }
        }


        [Then(@"I am not allowed to enter decimal values in Length, Width and Height fields (.*)")]
        public void ThenIAmNotAllowedToEnterDecimalValuesInLengthWidthAndHeightFields(string p0)
        {
            Report.WriteLine("I am not allowed to enter decimal values in Length, Width, Height field");

            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, "0.1");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, "1.50");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, "12.00");

            string length = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
            string width = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            string height = GetAttribute(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");

            if (Convert.ToDouble(length) != 0.1 && Convert.ToDouble(width) != 1.50 && Convert.ToDouble(height) != 12.00)
            {
                Report.WriteLine("Dimension fields are not not accepting decimal values");
            }
            else
            {
                Report.WriteLine("Dimension fields are not accepting decimal values");
            }
        }

        [Then(@"the maximum length of Length, Width and Height fields is restricted to three digit (.*)")]
        public void ThenTheMaximumLengthOfLengthWidthAndHeightFieldsIsRestrictedToThreeDigit(string p0)
        {
            Report.WriteLine("the maximum length of Length, Width, Height field is restricted to three digit");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, "9999");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, "9999");
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, "9999");

            string length = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
            string width = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            string height = GetAttribute(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");

            if (Convert.ToInt32(length) == 9999 && Convert.ToInt32(width) == 9999 && Convert.ToInt32(height) == 9999)
            {
                Report.WriteFailure("Dimension is accepting more than 3 interger");
            }
            else if (Convert.ToInt32(length) == 999 && Convert.ToInt32(width) == 999 && Convert.ToInt32(height) == 999)
            {
                Report.WriteLine("Dimension is accepting more than 3 interger");
            }
        }


        [When(@"I click on the add additional item button on the Add Shipment LTL page")]
        public void WhenIClickOnTheAddAdditionalItemButtonOnTheAddShipmentLTLPage()
        {
            
            int abtn = 0;
            while (abtn < numberOfAdditionalItems)
            {
                
                Click(attributeName_xpath, ".//*[@id='0']/div[7]/button");
                abtn++;
               

            }
        }

        [Then(@"I am not allowed to enter negative value in the added additional item fields for Length, Width and Height fields (.*)")]
        public void ThenIAmNotAllowedToEnterNegativeValueInTheAddedAdditionalItemFieldsForLengthWidthAndHeightFields(string negativeValue)
        {
            for (int i = 0; i <= numberOfAdditionalItems; i++)
            {
                Report.WriteLine("I am not allowed to enter Negative value in Length, Width, Height field");
                string enteredValue = Regex.Replace(negativeValue, @"(\s+|&|'|\(|\)|<|>|#)", "");
                SendKeys(attributeName_id, "freightlength-"+i+"", enteredValue);
                SendKeys(attributeName_id, "freightwidth-"+i+"", enteredValue);
                SendKeys(attributeName_id, "freightheight-"+i+"", enteredValue);

                string length = GetAttribute(attributeName_id, "freightlength-"+i+"", "value");
                string width = GetAttribute(attributeName_id, "freightwidth-"+i+"", "value");
                string height = GetAttribute(attributeName_id, "freightheight-"+i+"", "value");

                if (Convert.ToInt32(length) > 0)
                {
                    Report.WriteLine("Length field is not accepting negative values");
                }
                else
                {
                    Report.WriteFailure("Length field is accepting negative values");
                }
                if (Convert.ToInt32(width) > 0)
                {
                    Report.WriteLine("Width field is not accepting negative values");
                }
                else
                {
                    Report.WriteFailure("width field is accepting negative values");
                }
                if (Convert.ToInt32(height) > 0)
                {
                    Report.WriteLine("Height field is not accepting negative values");
                }
                else
                {
                    Report.WriteFailure("Height field is accepting negative values");
                }
            }
        }


        [Then(@"the Minimum value accepted in the added additional item fields for Length, Width and Height fields is (.*)")]
        public void ThenTheMinimumValueAcceptedInTheAddedAdditionalItemFieldsForLengthWidthAndHeightFieldsIs(int p0)
        {
            for (int i = 0; i <= numberOfAdditionalItems; i++)
            {
                Report.WriteLine("the Minimum value accepted in Length, Width, Height field is**");
                string length;
                string width;
                string height;

                SendKeys(attributeName_id, "freightlength-" + i + "", "0");
                SendKeys(attributeName_id, "freightwidth-" + i + "", "0");
                SendKeys(attributeName_id, "freightheight-" + i + "", "0");

                length = GetAttribute(attributeName_id, "freightlength-" + i + "", "value");
                width = GetAttribute(attributeName_id, "freightwidth-" + i + "", "value");
                height = GetAttribute(attributeName_id, "freightheight-" + i + "", "value");

                if (length == string.Empty && width == string.Empty && height == string.Empty)
                {
                    Report.WriteLine("dimeansion fields are not accepting 0");
                }
                else
                {
                    Report.WriteFailure("dimeansion fields are accepting 0");
                }


                SendKeys(attributeName_id, "freightlength-" + i + "", "1");
                SendKeys(attributeName_id, "freightwidth-" + i + "", "1");
                SendKeys(attributeName_id, "freightheight-" + i + "", "1");

                length = GetAttribute(attributeName_id, "freightlength-" + i + "", "value");
                width = GetAttribute(attributeName_id, "freightwidth-" + i + "", "value");
                height = GetAttribute(attributeName_id, "freightheight-" + i + "", "value");

                if (length == "1" && width == "1" && height == "1")
                {
                    Report.WriteLine("dimeansion fields are accepting 1");
                }
                else
                {
                    Report.WriteFailure("dimeansion fields are not accepting 1");
                }
            }
        }


        [Then(@"I am not allowed to enter decimal values in the added additional item fields for Length, Width and Height fields (.*)")]
        public void ThenIAmNotAllowedToEnterDecimalValuesInTheAddedAdditionalItemFieldsForLengthWidthAndHeightFields(string p0)
        {
            for (int i = 0; i <= numberOfAdditionalItems; i++)
            {
                Report.WriteLine("I am not allowed to enter decimal values in Length, Width, Height field");

                SendKeys(attributeName_id, "freightlength-" + i + "", "0.1");
                SendKeys(attributeName_id, "freightwidth-" + i + "", "1.50");
                SendKeys(attributeName_id, "freightheight-" + i + "", "12.00");

                string length = GetAttribute(attributeName_id, "freightlength-" + i + "", "value");
                string width = GetAttribute(attributeName_id, "freightwidth-" + i + "", "value");
                string height = GetAttribute(attributeName_id, "freightheight-" + i + "", "value");

                if (Convert.ToDouble(length) != 0.1 && Convert.ToDouble(width) != 1.50 && Convert.ToDouble(height) != 12.00)
                {
                    Report.WriteLine("Dimension fields are not not accepting decimal values");
                }
                else
                {
                    Report.WriteLine("Dimension fields are not accepting decimal values");
                }
            }
        }


        [Then(@"the maximum length of Length, Width and Height fields in the added additional item fields is restricted to three digit (.*)")]
        public void ThenTheMaximumLengthOfLengthWidthAndHeightFieldsInTheAddedAdditionalItemFieldsIsRestrictedToThreeDigit(string p0)
        {
            for (int i = 0; i <= numberOfAdditionalItems; i++)
            {
                Report.WriteLine("the maximum length of Length, Width, Height field is restricted to three digit");
                SendKeys(attributeName_id, "freightlength-" + i + "", "9999");
                SendKeys(attributeName_id, "freightwidth-" + i + "", "9999");
                SendKeys(attributeName_id, "freightheight-" + i + "", "9999");

                string length = GetAttribute(attributeName_id, "freightlength-" + i + "", "value");
                string width = GetAttribute(attributeName_id, "freightwidth-" + i + "", "value");
                string height = GetAttribute(attributeName_id, "freightheight-" + i + "", "value");

                if (Convert.ToInt32(length) == 9999 && Convert.ToInt32(width) == 9999 && Convert.ToInt32(height) == 9999)
                {
                    Report.WriteFailure("Dimension is accepting more than 3 interger");
                }
                else if (Convert.ToInt32(length) == 999 && Convert.ToInt32(width) == 999 && Convert.ToInt32(height) == 999)
                {
                    Report.WriteLine("Dimension is accepting more than 3 interger");
                }
            }
        }







    }
}
