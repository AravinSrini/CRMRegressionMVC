using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class CarrierRateSettins_SetAccessorial_Steps :  MaintenaceTools
    {

        [When(@"I select the (.*) from the stations drop down list")]
        public void WhenISelectTheFromTheStationsDropDownList(string Station)
        {

            Report.WriteLine("Selecting " + Station + " from All stations dropdown");
            Click(attributeName_id, AllStations_Id);
            SendKeys(attributeName_xpath, AllStations_SelectedValue_Xpath, Station);
            Click(attributeName_xpath, AllStations_DropdownFirstValue_Xpath);
            Thread.Sleep(1000);


        }

        [When(@"I select the (.*) from the customer account drop down list")]
        public void WhenISelectTheFromTheCustomerAccountDropDownList(string Customer_Account)
        {
            Report.WriteLine("Selecting " + Customer_Account + " from All stations dropdown");
            Click(attributeName_id, IndividualCustomers_Id);
            SendKeys(attributeName_xpath, IndividualCustomers_SelectedValue_Xpath, Customer_Account);
            Click(attributeName_xpath, IndividualCustomers_DropdownFirstValue_Xpath);
        }



        [Then(@"I should be able to see the (.*) button")]
        public void ThenIShouldBeAbleToSeeTheButton(string Set_Accessorial)
        {
            Verifytext(attributeName_id, SetAccessorial_Button_Id, Set_Accessorial);
        }

        [When(@"I click on the Set Accessorial button")]
        public void WhenIClickOnTheSetAccessorialButton()
        {
            Click(attributeName_id, SetAccessorial_Button_Id);
        }

        [When(@"I select single (.*) from the list of the carriers")]
        public void WhenISelectSingleFromTheListOfTheCarriers(string Carrier)
        {
            Click(attributeName_xpath, ".//*[@id='2343']/td[1]/div/label");
        }

        [Then(@"Set Individual Accessorials modal should be opened with (.*)")]
        public void ThenSetIndividualAccessorialsModalShouldBeOpenedWith(string PopHeader)
        {
            Verifytext(attributeName_xpath, SetAccessorial_PopUp_Title_Xpath, PopHeader);
        }


        [Then(@"I should see the options to select the accessorials (.*) with label (.*), Gainshare with label (.*), (.*) link, (.*) and (.*) buttons")]
        public void ThenIShouldSeeTheOptionsToSelectTheAccessorialsWithLabelGainshareWithLabelLinkAndButtons(string SelectAccessorial, string SelectAccessorialType, string SetGainShare, string ADDAnotherAccessorial, string Cancel, string Save)
        {
            Report.WriteLine("Verifying the Select Accessorial Type DropDown field in the Set Accessorial Modal");
            VerifyElementPresent(attributeName_xpath, Select_Accessorial_Type_DropDown_Xpath, SelectAccessorial);
            var DefaultText_SetAccessorialDropDown = Gettext(attributeName_xpath, Select_Accessorial_Type_DropDown_Xpath);
            Assert.AreEqual(SelectAccessorial, DefaultText_SetAccessorialDropDown);

            Report.WriteLine("Verifying the Select Accessorial Type label in the Set Accessorial Modal");
            VerifyElementPresent(attributeName_xpath, Select_Accessorial_Type_DropDown_label_Xpath, SelectAccessorial);
            var DefaultText_SetAccessorialDropDownLabel = Gettext(attributeName_xpath, Select_Accessorial_Type_DropDown_label_Xpath);
            Assert.AreEqual(SelectAccessorialType, DefaultText_SetAccessorialDropDownLabel);

            Report.WriteLine("Verifying the Set Gainshare field in the Set Accessorial Modal");
            VerifyElementPresent(attributeName_id, SetGainshareFirst_TextBox_Id, "GainShareTextBox");

            Report.WriteLine("Verifying the Set Gainshare label in the Set Accessorial Modal");
            VerifyElementPresent(attributeName_xpath, SetGainshare_Label_Xpath, SetGainShare);
            var DefaultText_SetGainshareLabel = Gettext(attributeName_xpath, SetGainshare_Label_Xpath);
            Assert.AreEqual(SetGainShare, DefaultText_SetGainshareLabel);

            Report.WriteLine("Verifying the Add Another Accessorial Link in the Set Accessorial Modal");
            VerifyElementPresent(attributeName_xpath, AddAnotherAccessorial_Button_Xpath, ADDAnotherAccessorial);

            Report.WriteLine("Verifying the Cancel Button in the Set Accessorial Modal");
            VerifyElementPresent(attributeName_xpath, SetAccessorial_CancelButton_Xpath, Cancel);

            Report.WriteLine("Verifying the Save Button in the Set Accessorial Modal");
            VerifyElementPresent(attributeName_id, SetAccessorial_SaveButton_Id, Save);

        }

        [Then(@"I should be able to select the accessorial (.*) from the list")]
        public void ThenIShouldBeAbleToSelectTheAccessorialFromTheList(string SelectAccessorial)
        {
            Click(attributeName_xpath, Select_Accessorial_Type_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, SetAccessorialDropDownValues_Xpath, SelectAccessorial);
        }


        [When(@"I click on the Set Gainshare drop down list")]
        public void WhenIClickOnTheSetGainshareDropDownList()
        {
            Click(attributeName_id, SetGainshareDropDown_Id);
        }


        [Then(@"I should be able see the format as (.*) and (.*)")]
        public void ThenIShouldBeAbleSeeTheFormatAsAnd(string Percentage, string Currency)
        {
            
            var SetGainshare_Format1 = Gettext(attributeName_xpath, SetGainshareDropDownOption1_Xpath);
            Assert.AreEqual(Currency, SetGainshare_Format1);

            var SetGainshare_Format2 = Gettext(attributeName_xpath, SetGainshareDropDownOption2_Xpath);
            Assert.AreEqual(Percentage, SetGainshare_Format2);

        }


        [When(@"I click on the ADD Another Accessorial link")]
        public void WhenIClickOnTheADDAnotherAccessorialLink()
        {
            Click(attributeName_xpath, AddAnotherAccessorial_Button_Xpath);
        }


        [Then(@"another set of (.*) , (.*), (.*) link, and (.*) button")]
        public void ThenAnotherSetOfLinkAndButton(string SelectAccessorial, string SetGainShare, string ADDAnotherAccessorial, string Remove)
        {
           
            Report.WriteLine("Verifying the First Additional Accessorial Select Drop down in the Set Accessorial Modal");
            VerifyElementPresent(attributeName_xpath, FirstAdditional_Select_Accessorial_Type_DropDown_Xpath, SelectAccessorial);
            var DefaultText_Additional_SetAccessorialDropDown = Gettext(attributeName_xpath, FirstAdditional_Select_Accessorial_Type_DropDown_Xpath);
            Assert.AreEqual(SelectAccessorial, DefaultText_Additional_SetAccessorialDropDown);           

            Report.WriteLine("Verifying the First Additional Accessorial Set Gainshare Text Box in the Set Accessorial Modal");
            VerifyElementPresent(attributeName_id, FirstAdditional_SetGainshare_TextBox_Id, SetGainShare);            

            Report.WriteLine("Verifying the Add Another Accessorial Link in the Set Accessorial Modal");
            VerifyElementPresent(attributeName_xpath, Additional_AddAnotherAccessorial_Button_Xpath, ADDAnotherAccessorial);

            Report.WriteLine("Verifying the Remove Button in the Set Accessorial Modal");
            VerifyElementPresent(attributeName_id, SetAccessorial_RemoveButton_Id, Remove);
        }


        [Then(@"I should not be able to see the additional fields (.*) , (.*), and (.*) button")]
        public void ThenIShouldNotBeAbleToSeeTheAdditionalFieldsAndButton(string SelectAccessorial, string SetGainShare, string Remove)
        {
            Report.WriteLine("Verifying the FirstAdditional Select Accessorial Type DropDown field in the Set Accessorial Modal");
            VerifyElementNotPresent(attributeName_xpath, FirstAdditional_Select_Accessorial_Type_DropDown_Xpath, SelectAccessorial);

            Report.WriteLine("Verifying the FirstAdditional SetGainshare TextBox field in the Set Accessorial Modal");
            VerifyElementNotPresent(attributeName_id, FirstAdditional_SetGainshare_TextBox_Id, SetGainShare);

            Report.WriteLine("Verifying the FirstAdditional Set Accessorial RemoveButton in the Set Accessorial Modal");
            VerifyElementNotPresent(attributeName_id, SetAccessorial_RemoveButton_Id, Remove);
        }



        [Then(@"I click on the Remove button")]
        public void ThenIClickOnTheRemoveButton()
        {
            Click(attributeName_id, SetAccessorial_RemoveButton_Id);
        }


       
        [When(@"I click on the save button of the Set Accessorial Modal pop up")]
        public void WhenIClickOnTheSaveButtonOfTheSetAccessorialModalPopUp()
        {
            Click(attributeName_id, SetAccessorial_SaveButton_Id);
           
        }

        [Then(@"I should get the error message (.*)")]
        public void ThenIShouldGetTheErrorMessage(string ErrorMsg)
        {
            Report.WriteLine("Verifying the error Message on adding the same accessorial in the Set Accessorial Modal");
            VerifyElementPresent(attributeName_id, AddDuplicateAccessorial_errorMsg_Id, ErrorMsg);
            var DefaultText_Additional_SetAccessorialDropDown = Gettext(attributeName_id, AddDuplicateAccessorial_errorMsg_Id);
            Assert.AreEqual(ErrorMsg, DefaultText_Additional_SetAccessorialDropDown);

        }



        


        [When(@"I select the first accessorial (.*) from the list")]
        public void WhenISelectTheFirstAccessorialFromTheList(string SelectAccessorial1)
        {
            Click(attributeName_xpath, Select_Accessorial_Type_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, SetAccessorialDropDownValues_Xpath, SelectAccessorial1);

        }


        [When(@"I enter the first gainshare value (.*) with the gainshare type (.*)")]
        public void WhenIEnterTheFirstGainshareValueWithTheGainshareType(string SetGainsharevalue1, string GainshareType1)
        {
            SendKeys(attributeName_id, SetGainshareFirst_TextBox_Id, SetGainsharevalue1);
            //Click(attributeName_id, SetGainshareDropDown_Id);            
            //SelectDropdownValueFromList(attributeName_xpath, SetGainshareDropDownOption1_Xpath, GainshareType1);



        }

        [When(@"I select the second accessorial (.*) from the list")]
        public void WhenISelectTheSecondAccessorialFromTheList(string SelectAccessorial2)
        {
            Click(attributeName_xpath, FirstAdditional_Select_Accessorial_Type_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, FirtsAdditional_Select_Accessorial_Type_DropDownValues_Xpath, SelectAccessorial2);

        }

        [When(@"I enter the second gainshare value (.*) with the gainshare type (.*)")]
        public void WhenIEnterTheSecondGainshareValueWithTheGainshareType(string SetGainsharevalue2, string GainshareType2)
        {
            SendKeys(attributeName_id, FirstAdditional_SetGainshare_TextBox_Id, SetGainsharevalue2);
            //Click(attributeName_id, FirstAdditional_SetGainshareDropDown_Id);
            //SelectDropdownValueFromList(attributeName_xpath, FirstAdditional_SetGainshareDropDownOption1_Xpath, GainshareType2);

        }


        [When(@"I click on the cancel button of the Set Accessorial Modal pop up")]
        public void WhenIClickOnTheCancelButtonOfTheSetAccessorialModalPopUp()
        {
            Click(attributeName_xpath, SetAccessorial_CancelButton_Xpath);
        }


        [Then(@"the selected (.*) should not be added in the Master Carrier Rate Settings page")]
        public void ThenTheSelectedShouldNotBeAddedInTheMasterCarrierRateSettingsPage(string SelectAccessorial1)
        {
            
            List<string> GridColumnNames = IndividualColumnData(".//*[@id='CustomerTable']/thead/tr/th");
            for (int i = 1; i <= GridColumnNames.Count; i++)
            {
                string CustNameValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[" + i + "]");
                if (CustNameValue == SelectAccessorial1)
                {
                    Report.WriteLine("Cancelled Accessorial is added in the Grid");
                    Assert.IsTrue(false);

                }
                else
                {
                    Report.WriteLine("Cancelled Accessorial ["+ SelectAccessorial1 + "] is not added in the Grid for the  column["+i+"]");
                    Assert.IsTrue(true);
                }
            }

        }

        [Then(@"selected accessorial (.*) with (.*) value should be added to the Grid on the Master Carrier Rate Settings page")]
        public void ThenSelectedAccessorialWithValueShouldBeAddedToTheGridOnTheMasterCarrierRateSettingsPage(string SelectAccessorial1, string SetGainsharevalue1)
        {
            

        List<string> GridColumnNames = IndividualColumnData(".//*[@id='CustomerTable']/thead/tr/th");
            for (int i = 1; i <= GridColumnNames.Count; i++)
            {
                string ColumnNameValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th["+i+"]");
                if (ColumnNameValue == SelectAccessorial1.ToUpper())
                {
                    string CarrierColumn = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/thead/tr/th[2]");
                    if (CarrierColumn == "CARRIER")
                    {
                        List<string> CarrierCount = IndividualColumnData(".//*[@id='CustomerTable']/tbody/tr");
                        for (int j = 1; j <= CarrierCount.Count; j++)
                        {
                            string CarrierName = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" +j + "]/td[2]");
                            if (CarrierName == "Conway")
                            {
                                string SetGainshareValue = Gettext(attributeName_xpath, ".//*[@id='CustomerTable']/tbody/tr[" + j + "]/td[10]");
                                string RemoveFormat_Gainsharevalue = SetGainshareValue.Remove(0, 1);
                                Assert.AreEqual(RemoveFormat_Gainsharevalue, SetGainsharevalue1);
                                break;

                            }

                        }

                    }
                    

                }
                else
                {
                    Report.WriteLine("Added Accessorial name " + SelectAccessorial1 + " not matches with the column[" + i + "] in the Grid");
                    Assert.IsTrue(true);
                }
            }
        }
    }
}
