using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest
{
    [Binding]
    public class AddShipmentLTL_MVC5_DefaultItem_AllUsersSteps:AddShipments
    {
        [Then(@"Classification, NMFC, Quantity, Quantity Type, Weight, Weight Type, Dimensions, Dimensions Type, Hazardous materials should be autopopulated if the account has the default items in DB (.*)")]
        public void ThenClassificationNMFCQuantityQuantityTypeWeightWeightTypeDimensionsDimensionsTypeHazardousMaterialsShouldBeAutopopulatedIfTheAccountHasTheDefaultItemsInDB(string Customer_Name)
        {
            scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
            Report.WriteLine("Items should be auto populated if the customer has the default items");
            Thread.Sleep(5000);
            int setupid = DBHelper.GetAccountIdforAccountName(Customer_Name);
            int accountnumber = DBHelper.GetAccountNumber(setupid);
            Item values = DBHelper.GetDefaultItem(accountnumber);
            bool HazValue=values.IsHazardous;
            
            //Weight and Weight type
            string ActWeight = GetAttribute(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");
            Assert.AreEqual(values.Weight.ToString(), ActWeight);
            Report.WriteLine("Displaying Weight in UI" + ActWeight + "is matching with DB value" + values.Weight);

            string ActWeightType = Gettext(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
            if (ActWeightType == "LBS")
            {
                Assert.AreEqual(values.WeightUnit, "LBS");
            }
            else
            {
                Assert.AreEqual(values.WeightUnit, "KILOS");
            }
            Report.WriteLine("Displaying WeightType in UI" + ActWeightType + "is matching with DB value" + values.WeightUnit);
            Thread.Sleep(500);
            
            //Quantity and Quantity type
            string ActQuantity = GetAttribute(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
            Assert.AreEqual(values.Quantity.ToString(), ActQuantity);
            Report.WriteLine("Displaying Quanity in UI" + ActQuantity + "is matching with DB value" + values.Quantity);

            string ActQuantityUnit = Gettext(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
            if (ActQuantityUnit == "Skids")
            {
                Assert.AreEqual(values.QuantityUnit, "SKD");
            }
            else if (ActQuantityUnit == "Bags")
            {
                Assert.AreEqual(values.QuantityUnit, "BAG");
            }
            else if (ActQuantityUnit == "Bundles")
            {
                Assert.AreEqual(values.QuantityUnit, "BDL");
            }
            else if (ActQuantityUnit == "Boxes")
            {
                Assert.AreEqual(values.QuantityUnit, "BOX");
            }
            else if (ActQuantityUnit == "Cabinets")
            {
                Assert.AreEqual(values.QuantityUnit, "CAB");
            }
            else if (ActQuantityUnit == "Cans")
            {
                Assert.AreEqual(values.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Cases")
            {
                Assert.AreEqual(values.QuantityUnit, "CAS");
            }
            else if (ActQuantityUnit == "Crates")
            {
                Assert.AreEqual(values.QuantityUnit, "CRT");
            }
            else if (ActQuantityUnit == "Cartons")
            {
                Assert.AreEqual(values.QuantityUnit, "CTN");
            }
            else if (ActQuantityUnit == "Cylinders")
            {
                Assert.AreEqual(values.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Drums")
            {
                Assert.AreEqual(values.QuantityUnit, "DRM");
            }
            else if (ActQuantityUnit == "Pails")
            {
                Assert.AreEqual(values.QuantityUnit, "PAL");
            }
            else if (ActQuantityUnit == "Pieces")
            {
                Assert.AreEqual(values.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Pallets")
            {
                Assert.AreEqual(values.QuantityUnit, "PLT");
            }
            else if (ActQuantityUnit == "Flat Racks")
            {
                Assert.AreEqual(values.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Reels")
            {
                Assert.AreEqual(values.QuantityUnit, "REL");
            }
            else if (ActQuantityUnit == "Rolls")
            {
                Assert.AreEqual(values.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Slip Sheets")
            {
                Assert.AreEqual(values.QuantityUnit, "");
            }
            else if (ActQuantityUnit == "Stacks")
            {
                Assert.AreEqual(values.QuantityUnit, "");
            }
            else
            {
                Assert.AreEqual(values.QuantityUnit, "TBN");
            }
            Report.WriteLine("Displaying Quanity in UI" + ActQuantityUnit + "is matching with DB value" + values.QuantityUnit);
            Thread.Sleep(500);

            //class or saved item
            string Classification_UI = Gettext(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            string[] a = Classification_UI.Split(new char[] { ' ' });
            string ActClassification = a[0];
            Assert.AreEqual(values.Classification.ToString(), ActClassification);
            Report.WriteLine("Displaying Classification in UI" + ActClassification + "is matching with DB value" + values.Classification);

            //NMFC
            string ActNMFC = GetAttribute(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value");
            Assert.AreEqual(values.NmfcCode, ActNMFC);
            Report.WriteLine("Displaying NMFC code in UI" + ActNMFC + "is matching with DB value" + values.NmfcCode);

            //Item description            
            string ActItemdesc =GetAttribute(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");
            Assert.AreEqual(values.ItemDescription, ActItemdesc);
            Report.WriteLine("Displaying Item Description in UI" + ActItemdesc + "is matching with DB value" + values.ItemDescription);
            
            //Dimensions
            string ActLength = GetAttribute(attributeName_id, FreightDesp_FirstItem_Length_Id, "value");
            Assert.AreEqual(values.Length.ToString(), ActLength);
            Report.WriteLine("Displaying Length in UI" + ActLength + "is matching with DB value" + values.Length);

            var ActWidth = GetAttribute(attributeName_id, FreightDesp_FirstItem_Width_Id, "value");
            Assert.AreEqual(values.Width.ToString(), ActWidth);
            Report.WriteLine("Displaying Width in UI" + ActWidth + "is matching with DB value" + values.Width);

            var ActHeight = GetAttribute(attributeName_id, FreightDesp_FirstItem_Height_Id, "value");
            Assert.AreEqual(values.Height.ToString(), ActHeight);
            Report.WriteLine("Displaying Height in UI" + ActHeight + "is matching with DB value" + values.Height);
            
            //Dimension type
            string ActDimensionType = Gettext(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            if (ActDimensionType == "IN")
            {
                Assert.AreEqual(values.DimensionUnit, "IN");
            }
            else if (ActDimensionType == "CM")
            {
                Assert.AreEqual(values.DimensionUnit, "CM");
            }
            else if (ActDimensionType == "FT")
            {
                Assert.AreEqual(values.DimensionUnit, "FT");
            }
            else
            {
                Assert.AreEqual(values.DimensionUnit, "METER");
            }
            Report.WriteLine("Displaying Dimension Type in UI" + ActDimensionType + "is matching with DB value" + values.DimensionUnit);
            Thread.Sleep(500);

            //Hazardous materials
            
            if  (HazValue==true)
            {
                string ActUNnumber = GetAttribute(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "value");
                Assert.AreEqual(values.UnNumber, ActUNnumber);
                Report.WriteLine("Displaying UNnumber in UI" + ActUNnumber + "is matching with DB value" + values.UnNumber);

                string ActCCN = GetAttribute(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "value");
                Assert.AreEqual(values.CcnNumber, ActCCN);
                Report.WriteLine("Displaying CCN in UI" + ActCCN + "is matching with DB value" + values.CcnNumber);

                string ActHazPackingGrp = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
                if (ActHazPackingGrp == "I")
                {
                    Assert.AreEqual(values.HazMatPackagingGroup, "I");
                }
                else if(ActHazPackingGrp=="II")
                {
                    Assert.AreEqual(values.HazMatPackagingGroup, "II");
                }
                else if (ActHazPackingGrp == "III")
                {
                    Assert.AreEqual(values.HazMatPackagingGroup, "III");
                }
                else
                {
                    Assert.AreEqual(values.HazMatPackagingGroup, "N/A");
                }
                Report.WriteLine("Displaying Hazmat packing group in UI" + ActHazPackingGrp + "is matching with DB value" + values.HazMatPackagingGroup);

                string ActHazClass = Gettext(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_Values_xpath);
                if (ActHazClass == "1")
                {
                    Assert.AreEqual(values.HazMatClass, "1");
                }
                else if (ActHazClass == "1.1")
                {
                    Assert.AreEqual(values.HazMatClass, "1.1");
                }
                else if (ActHazClass == "1.2")
                {
                    Assert.AreEqual(values.HazMatClass, "1.2");
                }
                else if (ActHazClass == "1.3")
                {
                    Assert.AreEqual(values.HazMatClass, "1.3");
                }
                else if (ActHazClass == "1.4")
                {
                    Assert.AreEqual(values.HazMatClass, "1.4");
                }
                else if (ActHazClass == "1.4G")
                {
                    Assert.AreEqual(values.HazMatClass, "1.4G");
                }
                else if (ActHazClass == "1.4S")
                {
                    Assert.AreEqual(values.HazMatClass, "1.4S");
                }
                else if (ActHazClass == "1.5")
                {
                    Assert.AreEqual(values.HazMatClass, "1.5");
                }
                else if (ActHazClass == "1.6")
                {
                    Assert.AreEqual(values.HazMatClass, "1.6");
                }
                else if (ActHazClass == "2")
                {
                    Assert.AreEqual(values.HazMatClass, "2");
                }
                else if (ActHazClass == "2.1")
                {
                    Assert.AreEqual(values.HazMatClass, "2.1");
                }
                else if (ActHazClass == "2.2")
                {
                    Assert.AreEqual(values.HazMatClass, "2.2");
                }
                else if (ActHazClass == "2.3")
                {
                    Assert.AreEqual(values.HazMatClass, "2.3");
                }
                else if (ActHazClass == "3")
                {
                    Assert.AreEqual(values.HazMatClass, "3");
                }
                else if (ActHazClass == "3(6.1)")
                {
                    Assert.AreEqual(values.HazMatClass, "3(6.1)");
                }
                else if (ActHazClass == "3(6.1)(8)")
                {
                    Assert.AreEqual(values.HazMatClass, "3(6.1)(8)");
                }
                else if (ActHazClass == "3(8)")
                {
                    Assert.AreEqual(values.HazMatClass, "3(8)");
                }
                else if (ActHazClass == "4")
                {
                    Assert.AreEqual(values.HazMatClass, "4");
                }
                else if (ActHazClass == "4.1")
                {
                    Assert.AreEqual(values.HazMatClass, "4.1");
                }
                else if (ActHazClass == "4.2")
                {
                    Assert.AreEqual(values.HazMatClass, "4.2");
                }
                else if (ActHazClass == "4.3")
                {
                    Assert.AreEqual(values.HazMatClass, "4.3");
                }
                else if (ActHazClass == "5")
                {
                    Assert.AreEqual(values.HazMatClass, "5");
                }
                else if (ActHazClass == "5.1(8)")
                {
                    Assert.AreEqual(values.HazMatClass, "5.1(8)");
                }
                else if (ActHazClass == "5.1(8)(6.1)")
                {
                    Assert.AreEqual(values.HazMatClass, "5.1(8)(6.1)");
                }
                else if (ActHazClass == "5.2")
                {
                    Assert.AreEqual(values.HazMatClass, "5.2");
                }
                else if (ActHazClass == "5.2(8)")
                {
                    Assert.AreEqual(values.HazMatClass, "5.2(8)");
                }
                else if (ActHazClass == "6")
                {
                    Assert.AreEqual(values.HazMatClass, "6");
                }
                else if (ActHazClass == "6.1")
                {
                    Assert.AreEqual(values.HazMatClass, "6.1");
                }
                else if (ActHazClass == "6.1(3)(8)")
                {
                    Assert.AreEqual(values.HazMatClass, "6.1(3)(8)");
                }
                else if (ActHazClass == "6.1(8)")
                {
                    Assert.AreEqual(values.HazMatClass, "6.1(8)");
                }
                else if (ActHazClass == "6.2")
                {
                    Assert.AreEqual(values.HazMatClass, "6.2");
                }
                else if (ActHazClass == "7")
                {
                    Assert.AreEqual(values.HazMatClass, "7");
                }
                else if (ActHazClass == "8")
                {
                    Assert.AreEqual(values.HazMatClass, "8");
                }
                else if (ActHazClass == "8(3)")
                {
                    Assert.AreEqual(values.HazMatClass, "8(3)");
                }
                else if (ActHazClass == "8(5.1)")
                {
                    Assert.AreEqual(values.HazMatClass, "8(5.1)");
                }
                else if (ActHazClass == "8(6.1)")
                {
                    Assert.AreEqual(values.HazMatClass, "8(6.1)");
                }
                else
                {
                    Assert.AreEqual(values.HazMatClass, "9");
                }
                Report.WriteLine("Displaying Hazmat Class in UI" + ActHazClass + "is matching with DB value" + values.HazMatClass);

                string ActEcontactName = GetAttribute(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "value");
                Assert.AreEqual(values.EmergencyContactName, ActEcontactName);
                Report.WriteLine("Displaying Emergency Contact Name in UI" + ActEcontactName + "is matching with DB value" + values.EmergencyContactName);

                string ActEphoneNumber = GetAttribute(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "value");
                Assert.AreEqual(values.EmergencyPhoneNumber, ActEphoneNumber);
                Report.WriteLine("Displaying Emergency Phone number in UI" + ActEphoneNumber + "is matching with DB value" + values.EmergencyPhoneNumber);

                //editable functionality for Hazmat YES
                Report.WriteLine("Auto-filled UN Number field in the Freight Description section should remain editable");
                Clear(attributeName_id, FreightDesp_FirstItem_UN_Number_Id);
                SendKeys(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "123");

                Report.WriteLine("Auto-filled CCN Number field in the Freight Description section should remain editable");
                Clear(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id);
                SendKeys(attributeName_id, FreightDesp_FirstItem_CCN_Number_Id, "123");

                Report.WriteLine("Auto-filled Hazmat Package group field in the Freight Description section should remain editable");
                Click(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath);
                SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatPackageGroup_DownDown_xpath, "N/A");

                Report.WriteLine("Auto-filled Emergency Contact Name field in the Freight Description section should remain editable");
                Clear(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id);
                SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponseContactName_Id, "dfsfds");

                Report.WriteLine("Auto-filled Hazmat class field in the Freight Description section should remain editable");
                Click(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_Values_xpath);
                SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_SelectHazmatClass_DropwDown_Values_xpath, "1.5");

                Report.WriteLine("Auto-filled Emergency Contact Name field in the Freight Description section should remain editable");
                Clear(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id);
                SendKeys(attributeName_id, FreightDesp_FirstItem_EmergencyReponsePhoneNumber_Id, "1111111111");
            }
            else
            {
                VerifyElementNotVisible(attributeName_id, FreightDesp_FirstItem_UN_Number_Id, "UN number");
                Report.WriteLine("No Hazardous materials for this saved Item");
            }
        }
        
        [Then(@"all the autopopulated fields will remain editable in Freight description section")]
        public void ThenAllTheAutopopulatedFieldsWillRemainEditableInFreightDescriptionSection()
        {
            Report.WriteLine("Auto-filled Select Class field in the Freight Description section should remain editable");
            Click(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "7");

            Report.WriteLine("Auto-filled Weight field in the Freight Description section should remain editable");
            Clear(attributeName_id, FreightDesp_FirstItem_Weight_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Weight_Id, "123");

            Report.WriteLine("Auto-filled Weight Type field in the Freight Description section should remain editable");
            Click(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_WeightType_xpath, "KILOS");
                        
            Report.WriteLine("Auto-filled Quantity Type field in the Freight Description section should remain editable");
            Click(attributeName_xpath, FreightDesp_FirstItem_QuantityType_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_QuantityDropdownValues_Xpath, "Rolls");

            Report.WriteLine("Auto-filled Quantity field in the Freight Description section should remain editable");
            Clear(attributeName_id, FreightDesp_FirstItem_Quantity_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "123");

            Report.WriteLine("Auto-filled NMFC code in the Freight Description section should remain editable");
            Clear(attributeName_id, FreightDesp_FirstItem_NMFC_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "123");

            Report.WriteLine("Auto-filled Item Description in the Freight Description section should remain editable");
            Clear(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "xyz");

            Report.WriteLine("Auto-filled Dimension Lenghth in the Freight Description section should remain editable");
            Clear(attributeName_id, FreightDesp_FirstItem_Length_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Length_Id, "123");

            Report.WriteLine("Auto-filled Dimension Width in the Freight Description section should remain editable");
            Clear(attributeName_id, FreightDesp_FirstItem_Width_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Width_Id, "123");

            Report.WriteLine("Auto-filled Dimension Height in the Freight Description section should remain editable");
            Clear(attributeName_id, FreightDesp_FirstItem_Height_Id);
            SendKeys(attributeName_id, FreightDesp_FirstItem_Height_Id, "123");

            Report.WriteLine("Auto-filled Dimension Type in the Freight Description section should remain editable");
            Click(attributeName_xpath, FreightDesp_FirstItem_DimensionType_xpath);
            SelectDropdownValueFromList(attributeName_xpath, FreightDesp_FirstItem_DimensionType_Values_xpath, "METER");            
        }
    }
}
