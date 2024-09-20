using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{

    [Binding]
    public class MasterCarrierRateSettings_RecordEditsForAuditSteps : MaintenaceTools
    {

        string SurgeUI = null;
        string BumpUI = null;
        string MinUI = null;
        string MinThreshold = null;
        string MinAmount = null;
        string MasterAccCharge = null;
        string Accessorial = null;
        DateTime UpdatedDate = DateTime.UtcNow;
        CommonMethodsCrm crm = new CommonMethodsCrm();
        [Given(@"I am a System Admin user (.*), (.*)")]
        public void GivenIAmASystemAdminUser(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [When(@"I have selected a Station (.*)")]
        public void WhenIHaveSelectedAStation(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I get surge value before editing")]
        public void WhenIGetSurgeValueBeforeEditing()
        {
            SurgeUI = Gettext(attributeName_xpath, FirstSurgeValue_Xpath);
            Report.WriteLine("Surge value before editing");
        }

        [When(@"I get Bump value before editing")]
        public void WhenIGetBumpValueBeforeEditing()
        {
            BumpUI = Gettext(attributeName_xpath, FirstBumpValue_Xpath);
            Report.WriteLine("Surge value before editing");
        }
        [When(@"I edit minimum value in Master Carrier Rate Settings page (.*)")]
        public void WhenIEditMinimumValueInMasterCarrierRateSettingsPage(string Min)
        {
            Report.WriteLine("Editing Minimum Value");
            SendKeys(attributeName_id, Mininum_Textbox_Id, Min);
            Click(attributeName_id, Mininum_Button_Id);
            Thread.Sleep(60000);
        }



        [When(@"I edit (.*) value on Master Carrier Rate Settings page")]
        public void WhenIEditValueOnMasterCarrierRateSettingsPage(string Surge)
        {
            Report.WriteLine("Editing surge values");
            SendKeys(attributeName_xpath, SurgeValue_Textbox_Xpath, Surge);
            Click(attributeName_id, Surgebutton_Id);
            Thread.Sleep(9000);
        }
        [When(@"I will edit (.*) value on Master Carrier Rate Settings page")]
        public void WhenIWillEditValueOnMasterCarrierRateSettingsPage(string Bump)
        {
            Report.WriteLine("Editing surge values");
            SendKeys(attributeName_xpath, BumpValue_Textbox_Xpath, Bump);
            Click(attributeName_id, Bumpbutton_Id);
            Thread.Sleep(80000);
        }

        [When(@"I edit Master Accessorial Charge on Master Carrier Rate Settings page (.*)")]
        public void WhenIEditMasterAccessorialChargeOnMasterCarrierRateSettingsPage(string MasterAccessorialCharge)
        {
            Report.WriteLine("Editing Master Accessorial Charge");
            SendKeys(attributeName_id, MasterAccesCharge_Text_Id, MasterAccessorialCharge);
            Click(attributeName_id, MasterAccesCharge_Button_Id);
            Thread.Sleep(50000);
        }


        [When(@"I edit minimum threshold value in Master Carrier Rate Settings page (.*)")]
        public void WhenIEditMinimumThresholdValueInMasterCarrierRateSettingsPage(string MinThreshold)
        {
            Report.WriteLine("Editing Minimum Threshold value");
            SendKeys(attributeName_id, MininumThreshold_Textbox_Id, MinThreshold);
            Click(attributeName_id, MininumThreshold_Button_Id);
            Thread.Sleep(50000);
        }

        [When(@"I edit Minimum Amount value on Master Carrier Rate Settings page (.*)")]
        public void WhenIEditMinimumAmountValueOnMasterCarrierRateSettingsPage(string MinAmount)
        {
            Report.WriteLine("Editing Minimum Amount value");
            SendKeys(attributeName_id, MininumAmount_Textbox_Id, MinAmount);
            Click(attributeName_id, MininumAmount_Button_Id);
            Thread.Sleep(50000);
        }

        [When(@"I edit set Accessorial value on Master Carrier Rate Settings page (.*)")]
        public void WhenIEditSetAccessorialValueOnMasterCarrierRateSettingsPage(string SetAccessorial)
        {
            Report.WriteLine("Editing Set Accessorial value");
            Click(attributeName_id, SetAccessorials_Button_Id);
            Thread.Sleep(7000);
            Click(attributeName_xpath, SetAccessorialType_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, SetAccessorailTypeValues_Xpath, "Appointment");
            SendKeys(attributeName_id, SetAccessorialTypeText_Id, SetAccessorial);
            Click(attributeName_id, SetAccessorials_SaveButton_Id);
            Thread.Sleep(50000);
        }



        [When(@"I get Minimum value before editing")]
        public void WhenIGetMinimumValueBeforeEditing()
        {
            MinUI = Gettext(attributeName_xpath, MinFirstCarrier_Xpath);
            Report.WriteLine("Minimum value before editing");
        }

        [When(@"I get Minimum Threshold value before editing")]
        public void WhenIGetMinimumThresholdValueBeforeEditing()
        {
            MinThreshold = Gettext(attributeName_xpath, MinThresholdFirstCarrier_Xpath);
            Report.WriteLine("Minimum Threshold value before editing");
        }

        [When(@"I get Minimum Amount value before editing")]
        public void WhenIGetMinimumAmountValueBeforeEditing()
        {
            MinAmount = Gettext(attributeName_xpath, MinAmountFirstCarrier_Xpath);
            Report.WriteLine("Minimum Amount value before editing");
        }

        [When(@"I get Master Accessorial Charge before editing")]
        public void WhenIGetMasterAccessorialChargeBeforeEditing()
        {
            MasterAccCharge = Gettext(attributeName_xpath, MasterAccesFirstCarrier_Xpath);
            Report.WriteLine("Master Accessorial Charge before editing");

        }

        [When(@"I get Accessorial charge before editing")]
        public void WhenIGetAccessorialChargeBeforeEditing()
        {
            Accessorial = Gettext(attributeName_xpath, FirstCarrier_SetAccessorial_Xpath);
            Report.WriteLine("Accessorial charge before editing");
        }


        [Then(@"The following values should get saved in Station setup new Record Edit DB -Station, Customer,Carrier, Field Name, Field Value - Old Surge, Field Value - new Surge, User ID, Date/Time of edit\.(.*),(.*)")]
        public void ThenTheFollowingValuesShouldGetSavedInStationSetupNewRecordEditDB_StationCustomerCarrierFieldNameFieldValue_OldSurgeFieldValue_NewSurgeUserIDDateTimeOfEdit_(string StationName, string Username)
        {
            string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            string SurgeEditUIVal = Gettext(attributeName_xpath, FirstSurgeValue_Xpath);
            Common_BumpSurgeStationSetUp_CT CT_ValOld = DBHelper.GetBumpSurgeCTOldDetailsStation(OneCarrierUI, StationName, UpdatedDate);
            string SurgeUIUp = SurgeUI.Substring(0, (SurgeUI.Length - 1));
            if (CT_ValOld.Surge == Convert.ToDecimal(SurgeUIUp))
            {
                Report.WriteLine("Old Surge value is inserted into CT table and value is matching with UI");
            }
            else
            {
                Report.WriteFailure("Old Surge value is not inserted into CT table and value is not matching with UI");
                Assert.Fail();
            }
            Common_BumpSurgeStationSetUp_CT CT_ValNew = DBHelper.GetBumpSurgeCTNewDetailsStation(OneCarrierUI, StationName, UpdatedDate);
            
                string SurgeEditValUp = SurgeEditUIVal.Substring(0, (SurgeEditUIVal.Length - 1));
                if (CT_ValNew.Surge == Convert.ToDecimal(SurgeEditValUp))
                {
                    Report.WriteLine("New Surge value is inserted into CT table and value is matching with UI");
                }
                else
                {
                    Report.WriteFailure("New Surge value is not inserted into CT table and value is not matching with UI");
                    Assert.Fail();
                }

                if (CT_ValNew.ModifiedBy == Username)
                {
                    Report.WriteLine("Modified Username is inserted into CT table");
                }
                else
                {
                    Report.WriteFailure("Modified Username is not inserted into CT table");
                    Assert.Fail();
                }

            
        }
        [Then(@"The following values should get saved in Station setup new Record Edit DB -Station, Customer,Carrier, Field Name, Field Value - Old Bump, Field Value -  new Bump, User ID, Date/Time of edit\.(.*),(.*)")]
        public void ThenTheFollowingValuesShouldGetSavedInStationSetupNewRecordEditDB_StationCustomerCarrierFieldNameFieldValue_OldBumpFieldValue_NewBumpUserIDDateTimeOfEdit_(string StationName, string Username)
        {
            string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            string BumpEditUIVal = Gettext(attributeName_xpath, FirstBumpValue_Xpath);
            Common_BumpSurgeCustomerSetUp_CT CT_ValOld = DBHelper.GetBumpSurgeCTOldDetails(OneCarrierUI, StationName);
            if (CT_ValOld.Bump == Convert.ToDecimal(BumpUI))
            {
                Report.WriteLine("Old Bump value is inserted into CT table and value is matching with UI");
            }
            else
            {
                Report.WriteFailure("Old Bump value is not inserted into CT table and value is not matching with UI");
                Assert.Fail();
            }
            Common_BumpSurgeCustomerSetUp_CT CT_ValNew = DBHelper.GetBumpSurgeCTNewDetails(OneCarrierUI, StationName, UpdatedDate);
            {
                if (CT_ValNew.Bump == Convert.ToDecimal(BumpEditUIVal))
                {
                    Report.WriteLine("New Bump value is inserted into CT table and value is matching with UI");
                }
                else
                {
                    Report.WriteFailure("New Bump value is not inserted into CT table and value is not matching with UI");
                    Assert.Fail();
                }

                if (CT_ValNew.ModifiedBy == Username)
                {
                    Report.WriteLine("Modified Username is inserted into CT table");
                }
                else
                {
                    Report.WriteFailure("Modified Username is not inserted into CT table");
                    Assert.Fail();
                }

            }
        }



        [Then(@"The following values should get recorded in the new Record Edit DB - Station, Customer,Carrier, Field Name, Field Value - Old Surge, Field Value - new Surge, User ID, Date/Time of edit\.(.*),(.*)")]
        public void ThenTheFollowingValuesShouldGetRecordedInTheNewRecordEditDB_StationCustomerCarrierFieldNameFieldValue_OldSurgeFieldValue_NewSurgeUserIDDateTimeOfEdit_(string CustomerName, string Username)
        {

            string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            string SurgeEditUIVal = Gettext(attributeName_xpath, FirstSurgeValue_Xpath);
            Common_BumpSurgeCustomerSetUp_CT CT_ValOld = DBHelper.GetBumpSurgeCTOldDetails(OneCarrierUI, CustomerName);
            string SurgeUIUp = SurgeUI.Substring(0, (SurgeUI.Length - 1));
            if ((CT_ValOld.Surge) == Convert.ToDecimal(SurgeUIUp))
            {
                Report.WriteLine("Old Surge value is inserted into CT table and value is matching with UI");
            }
            else
            {
                Report.WriteFailure("Old Surge value is not inserted into CT table and value is not matching with UI");
                Assert.Fail();
            }
            Common_BumpSurgeCustomerSetUp_CT CT_ValNew = DBHelper.GetBumpSurgeCTNewDetails(OneCarrierUI, CustomerName, UpdatedDate);
            
                string SurgeEditValUp = SurgeEditUIVal.Substring(0, (SurgeEditUIVal.Length - 1));
                if (CT_ValNew.Surge == Convert.ToDecimal(SurgeEditValUp))
                {
                    Report.WriteLine("New Surge value is inserted into CT table and value is matching with UI");
                }
                else
                {
                    Report.WriteFailure("New Surge value is not inserted into CT table and value is not matching with UI");
                    Assert.Fail();
                }

                if (CT_ValNew.ModifiedBy == Username)
                {
                    Report.WriteLine("Modified Username is inserted into CT table");
                }
                else
                {
                    Report.WriteFailure("Modified Username is not inserted into CT table");
                    Assert.Fail();
                }

            
        }

        [Then(@"The following values should get recorded in the new Record Edit DB - Station, Customer, Carrier, Field Name, Field Value - Old Min Threshold, Field Value - new Min Threshold, User ID, Date/Time of edit\.(.*),(.*)")]
        public void ThenTheFollowingValuesShouldGetRecordedInTheNewRecordEditDB_StationCustomerCarrierFieldNameFieldValue_OldMinThresholdFieldValue_NewMinThresholdUserIDDateTimeOfEdit_(string CustomerName, string Username)
        {
            string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            string MinThresholdEditUIVal = Gettext(attributeName_xpath, MinThresholdFirstCarrier_Xpath);
            Csr_GainShareScacCode_CT CT_ValOld = DBHelper.GetGainShareValues(OneCarrierUI, CustomerName);
            string MinThreshUIUp = MinThreshold.Substring(0, (MinThreshold.Length - 1));
            if (CT_ValOld.CarrierSpecificMinimumThreshold == MinThreshUIUp)
            {
                Report.WriteLine("Old Minimum Threshold value is inserted into CT table and value is matching with UI");
            }
            else
            {
                Report.WriteFailure("Old Minimum Threshold value is not inserted into CT table and value is not matching with UI");
                Assert.Fail();
            }
            Csr_GainShareScacCode_CT CT_ValNew = DBHelper.GetGainShareNewValues(OneCarrierUI, CustomerName);

            string MinThreshEditUIUp = MinThresholdEditUIVal.Substring(0, (MinThresholdEditUIVal.Length - 1));
            if (CT_ValNew.CarrierSpecificMinimumThreshold == MinThreshEditUIUp)
            {
                Report.WriteLine("New Minimum Threshold value is inserted into CT table and value is matching with UI");
            }
            else
            {
                Report.WriteFailure("New Minimum Threshold value is not inserted into CT table and value is not matching with UI");
                Assert.Fail();
            }

            if (CT_ValNew.ModifiedBy == Username)
            {
                Report.WriteLine("Modified Username is inserted into CT table");
            }
            else
            {
                Report.WriteFailure("Modified Username is not inserted into CT table");
                Assert.Fail();
            }


        }

        [Then(@"The following values should get recorded in the new Record Edit DB - Station, Customer,Carrier, Field Name, Field Value - Old Min Amount, Field Value - new Min Amount, User ID, Date/Time of edit\.(.*),(.*)")]
        public void ThenTheFollowingValuesShouldGetRecordedInTheNewRecordEditDB_StationCustomerCarrierFieldNameFieldValue_OldMinAmountFieldValue_NewMinAmountUserIDDateTimeOfEdit_(string CustomerName, string Username)
        {
            string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            string MinAmountEditUIVal = Gettext(attributeName_xpath, MinAmountFirstCarrier_Xpath);
            Csr_GainShareScacCode_CT CT_ValOld = DBHelper.GetGainShareValues(OneCarrierUI, CustomerName);
            string MinAmountUIUp = MinAmount.Substring(0, (MinAmount.Length - 1));
            if (CT_ValOld.CarrierSpecificMinimumAmount == MinAmountUIUp)
            {
                Report.WriteLine("Old Minimum Amount value is inserted into CT table and value is matching with UI");
            }
            else
            {
                Report.WriteFailure("Old Minimum Amount value is not inserted into CT table and value is not matching with UI");
                Assert.Fail();
            }
            Csr_GainShareScacCode_CT CT_ValNew = DBHelper.GetGainShareNewValues(OneCarrierUI, CustomerName);

            string MinAmountEditUIUp = MinAmountEditUIVal.Substring(0, (MinAmountEditUIVal.Length - 1));
            if (CT_ValNew.CarrierSpecificMinimumAmount == MinAmountEditUIUp)
            {
                Report.WriteLine("New Minimum Amount value is inserted into CT table and value is matching with UI");
            }
            else
            {
                Report.WriteFailure("New Minimum Amount value is not inserted into CT table and value is not matching with UI");
                Assert.Fail();
            }

            if (CT_ValNew.ModifiedBy == Username)
            {
                Report.WriteLine("Modified Username is inserted into CT table");
            }
            else
            {
                Report.WriteFailure("Modified Username is not inserted into CT table");
                Assert.Fail();
            }

        }

        [Then(@"The following values should get recorded in the new Record Edit DB - Station, Customer,Carrier, Field Name, Field Value - Old Master Accessorial Charge, Field Value - new Master Accessorial Charge, User ID, Date/Time of edit\.(.*),(.*)")]
        public void ThenTheFollowingValuesShouldGetRecordedInTheNewRecordEditDB_StationCustomerCarrierFieldNameFieldValue_OldMasterAccessorialChargeFieldValue_NewMasterAccessorialChargeUserIDDateTimeOfEdit_(string CustomerName, string Username)
        {
            string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            string MasterACCChargeEditUIVal = Gettext(attributeName_xpath, MasterAccesFirstCarrier_Xpath);
            Csr_GainShareScacCode_CT CT_ValOld = DBHelper.GetGainShareValues(OneCarrierUI, CustomerName);
            string MasterAccessUIUp = MasterAccCharge.Substring(0, (MasterAccCharge.Length - 1));
            if (CT_ValOld.MasterAccessorialCharge == Convert.ToDecimal(MasterAccessUIUp))
            {
                Report.WriteLine("Old Master Accessorial Charge value is inserted into CT table and value is matching with UI");
            }
            else
            {
                Report.WriteFailure("Old Master Accessorial Charge value is not inserted into CT table and value is not matching with UI");
                Assert.Fail();
            }
            Csr_GainShareScacCode_CT CT_ValNew = DBHelper.GetGainShareNewValues(OneCarrierUI, CustomerName);
            {
                string MasterAccessEditUIUp = MasterACCChargeEditUIVal.Substring(0, (MasterACCChargeEditUIVal.Length - 1));
                if (CT_ValNew.MasterAccessorialCharge == Convert.ToDecimal(MasterAccessEditUIUp))
                {
                    Report.WriteLine("New Master Accessorial Charge value is inserted into CT table and value is matching with UI");
                }
                else
                {
                    Report.WriteFailure("New Master Accessorial Charge value is not inserted into CT table and value is not matching with UI");
                    Assert.Fail();
                }

                if (CT_ValNew.ModifiedBy == Username)
                {
                    Report.WriteLine("Modified Username is inserted into CT table");
                }
                else
                {
                    Report.WriteFailure("Modified Username is not inserted into CT table");
                    Assert.Fail();
                }

            }
        }


        [Then(@"The following values should get recorded in the new Record Edit DB - Station, Customer, Carrier, Field Name, Field Value - Old Min, Field Value - new Min, User ID, Date/Time of edit\.(.*),(.*)")]
        public void ThenTheFollowingValuesShouldGetRecordedInTheNewRecordEditDB_StationCustomerCarrierFieldNameFieldValue_OldMinFieldValue_NewMinUserIDDateTimeOfEdit_(string CustomerName, string Username)
        {
            string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            string MinEditUIVal = Gettext(attributeName_xpath, MinFirstCarrier_Xpath);
            Csr_GainShareScacCode_CT CT_ValOld = DBHelper.GetGainShareValues(OneCarrierUI, CustomerName);
            string MinUIUp = MinUI.Substring(0, (MinUI.Length - 1));
            if (CT_ValOld.Minimum == Convert.ToDecimal(MinUIUp))
            {
                Report.WriteLine("Old Minimum value is inserted into CT table and value is matching with UI");
            }
            else
            {
                Report.WriteFailure("Old Minimum value is not inserted into CT table and value is not matching with UI");
                Assert.Fail();
            }
            Csr_GainShareScacCode_CT CT_ValNew = DBHelper.GetGainShareNewValues(OneCarrierUI, CustomerName);
            
                string MinUIEditUp = MinEditUIVal.Substring(0, (MinEditUIVal.Length - 1));
                if (CT_ValNew.Minimum == Convert.ToDecimal(MinUIEditUp))
                {
                    Report.WriteLine("New Minimum value is inserted into CT table and value is matching with UI");
                }
                else
                {
                    Report.WriteFailure("New Minimum value is not inserted into CT table and value is not matching with UI");
                    Assert.Fail();
                }

                if (CT_ValNew.ModifiedBy == Username)
                {
                    Report.WriteLine("Modified Username is inserted into CT table");
                }
                else
                {
                    Report.WriteFailure("Modified Username is not inserted into CT table");
                    Assert.Fail();
                }

            
        }

        [Then(@"The following values should get recorded in the new Record Edit DB - Station, Customer,Carrier, Field Name, Field Value - Old Set Accessorial, Field Value - new Set Accessorial, User ID, Date/Time of edit\.(.*),(.*)")]
        public void ThenTheFollowingValuesShouldGetRecordedInTheNewRecordEditDB_StationCustomerCarrierFieldNameFieldValue_OldSetAccessorialFieldValue_NewSetAccessorialUserIDDateTimeOfEdit_(string CustomerName, string Username)
        {
            string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            string SetAccessEditUIVal = Gettext(attributeName_xpath, FirstCarrier_SetAccessorial_Xpath);
            Csr_AccessorialCarrierSetUp_CT CT_ValOld = DBHelper.GetAccessorialVal(OneCarrierUI, CustomerName);
            string AccessUIUp = Accessorial.Substring(0, (Accessorial.Length - 1));
            if (CT_ValOld.AccessorialValue == Convert.ToDecimal(AccessUIUp))
            {
                Report.WriteLine("Old Accessorial value is inserted into CT table and value is matching with UI");
            }
            else
            {
                Report.WriteFailure("Old Accessorial value is not inserted into CT table and value is not matching with UI");
                Assert.Fail();
            }
            Csr_AccessorialCarrierSetUp_CT CT_ValNew = DBHelper.GetAccessorialNewVal(OneCarrierUI, CustomerName);

            string AccessUIEditUp = SetAccessEditUIVal.Substring(0, (SetAccessEditUIVal.Length - 1));
            if (CT_ValNew.AccessorialValue == Convert.ToDecimal(AccessUIEditUp))
            {
                Report.WriteLine("New Accessorial value is inserted into CT table and value is matching with UI");
            }
            else
            {
                Report.WriteFailure("New Accessorial value is not inserted into CT table and value is not matching with UI");
                Assert.Fail();
            }

            if (CT_ValNew.ModifiedBy == Username)
            {
                Report.WriteLine("Modified Username is inserted into CT table");
            }
            else
            {
                Report.WriteFailure("Modified Username is not inserted into CT table");
                Assert.Fail();
            }


        }


        [Then(@"The following values should get recorded in the new Record Edit DB - Station, Customer,Carrier, Field Name, Field Value - Old Bump, Field Value - new Bump, User ID, Date/Time of edit\.(.*),(.*)")]
        public void ThenTheFollowingValuesShouldGetRecordedInTheNewRecordEditDB_StationCustomerCarrierFieldNameFieldValue_OldBumpFieldValue_NewBumpUserIDDateTimeOfEdit_(string CustomerName, string Username)
        {
            string OneCarrierUI = Gettext(attributeName_xpath, CarrierOne_Xpath);
            string BumpEditUIVal = Gettext(attributeName_xpath, FirstBumpValue_Xpath);
            Common_BumpSurgeCustomerSetUp_CT CT_ValOld = DBHelper.GetBumpSurgeCTOldDetails(OneCarrierUI, CustomerName);
            string BumpUIUp = BumpUI.Substring(0, (BumpUI.Length - 1));
            if (CT_ValOld.Bump == Convert.ToDecimal(BumpUIUp))
            {
                Report.WriteLine("Old Bump value is inserted into CT table and value is matching with UI");
            }
            else
            {
                Report.WriteFailure("Old Bump value is not inserted into CT table and value is not matching with UI");
                Assert.Fail();
            }
            Common_BumpSurgeCustomerSetUp_CT CT_ValNew = DBHelper.GetBumpSurgeCTNewDetails(OneCarrierUI, CustomerName, UpdatedDate);
            {
                string BumpUIEditUp = BumpEditUIVal.Substring(0, (BumpEditUIVal.Length - 1));
                if (CT_ValNew.Bump == Convert.ToDecimal(BumpUIEditUp))
                {
                    Report.WriteLine("New Bump value is inserted into CT table and value is matching with UI");
                }
                else
                {
                    Report.WriteFailure("New Bump value is not inserted into CT table and value is not matching with UI");
                    Assert.Fail();
                }

                if (CT_ValNew.ModifiedBy == Username)
                {
                    Report.WriteLine("Modified Username is inserted into CT table");
                }
                else
                {
                    Report.WriteFailure("Modified Username is not inserted into CT table");
                    Assert.Fail();
                }

            }
        }


    }
}

