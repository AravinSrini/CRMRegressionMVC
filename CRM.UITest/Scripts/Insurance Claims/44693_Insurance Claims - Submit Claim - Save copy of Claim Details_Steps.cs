using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claims_List
{
    [Binding]
    public class _44693_Insurance_Claims___Submit_Claim___Save_copy_of_Claim_Details_Steps : InsuranceClaim
    {
        CommonMethodsCrm crmLogin = new CommonMethodsCrm();

        //All information need to pass here while submitting the claim
        string Stationname = "TestStation013";
        string Customername = "013_mg_hc";

        string DLSWRef = "Ref999888777";
        string CarrierName = "Carrier123";
        string CarrierPRO = "123QA";
        string ShipperName = "Testing 1@3";
        string ShipperAddress = "AddressTest!123";
        string ShipperAdd2 = "Address223";
        string ShipperZip = "33126";
        string ShipperCity = "Miami";
        string ShipperCountry = "United States";
        string ShipperState = "FL";

        string ConsigneName = "Consigneename";
        string ConsigneAddress = "ConsigneAddress";
        string ConsigneAddress2 = "ConsigneAddress2";
        string ConsigneZip = "85282";
        string ConsigneCity = "Tempe";
        string ConsigneCountry = "United States";
        string ConsigneProvince = "AZ";


        string ClaimCompanyName = "CompanyName";
        string ClaimAddress = "Address )**(434";
        string ClaimAddress2 = "Address2";
        string ClaimZip = "85282";
        string ClaimCountry = "United States";
        string ClaimCity = "Tempe";
        string ClaimProvince = "AZ";
        string ClaimContactName = "ContactName";
        string ClaimPhone = "84324249324";
        string ClaimEmail = "dyafdyu@gmail.com";
        string ClaimWebsite = "www.shua.com";

        string InsuredAmount = "23.00";

        string ItemMode = "Itemcheck@123";
        string UnitVal = "23.00";
        string Quantity = "45";
        string Weight = "23.00";
        string ClaimDescription = "Description Test 123";

        string OriginFreightCharge = "23.00";
        string ReturnFreight = "23.00";
        string ReturnDLS = "45.00";
        string ReplaceFreightCharge = "20.00";
        string ReplaceDLS = "532756";
        string Remark = "jdhasu5535437hgd$#%^";

        
        string DocumentType = "Repair Invoice";
        int ClaimNumber = 0;

        string UIDLSDate = null;
        string Fullpath = "../../Scripts/TestData/Testfiles_ClaimDocument/QuoteListCheck.txt";


        //* Information update on claim details page of any existing claim
        string U_DLSWRef = "Ref999888666";

        string U_CarrierName = "Carrier123";
        string U_CarrierPRO = "123QA";

        string U_ShipperName = "Testing update";

        string U_ShipperAddress = "Update Test!123";
        string U_ShipperAdd2 = "Address223";

        string U_ShipperZip = "90001";
        string U_ShipperCity = "Los Angeles";
        string U_ShipperCountry = "United States";
        string U_ShipperState = "CA";

        string U_ConsigneName = "Update Consigneename";
        string U_ConsigneAddress = "ConsigneAddress";
        string U_ConsigneAddress2 = "ConsigneAddress2";
        string U_ConsigneZip = "60606";
        string U_ConsigneCity = "Chicago";
        string U_ConsigneCountry = "United States";
        string U_ConsigneProvince = "IL";

        string U_ClaimCompanyName = "update CompanyName";
        string U_ClaimAddress = "update Address )**(434";
        string U_ClaimAddress2 = "update Address2";
        string U_ClaimCity = "City";
        string U_ClaimProvince = "FL";
        string U_ClaimContactName = "ContactName";
        string U_ClaimPhone = "84324249324";
        string U_ClaimEmail = "dyafdyu@gmail.com";
        string U_ClaimWebsite = "www.shua.com";
        string U_InsuredAmount = "23.00";
        string U_ItemMode = "Itemcheck@123";
        string U_UnitVal = "23.00";
        string U_Quantity = "45";
        string U_Weight = "23.00";
        string U_ClaimDescription = "Description Test 123";
        string U_OriginFreightCharge = "23.00";
        string U_ReturnFreight = "23.00";
        string U_ReturnDLS = "45564321236789087654";
        string U_ReplaceFreightCharge = "20.00";
        string U_ReplaceDLS = "532756";
        string U_Remark = "update check";
        
        
        string U_ClaimCountry = "United States";
        string U_DocumentType = "Repair Invoice";
        string U_ClaimZip = "32435";

        public int ClaimAvailable = 2018;
        public int LatestClaim_Number;
        public string newsubmitted_claimnumber;
        public string Claimnumber_in_list;

        [Given(@"I am a CRM user")]
        public void GivenIAmACRMUser()
        {
            string username = ConfigurationManager.AppSettings["username-claimspecialistClaim"].ToString();
            string password = ConfigurationManager.AppSettings["password-claimspecialistClaim"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [When(@"I submit a claim")]
        public void WhenISubmitAClaim()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            //Click(attributeName_xpath, ClaimListGrid_PendingCheckbox_Xpath);
            SendKeys(attributeName_xpath, ClaimListSearchTextBox_xpath, ClaimAvailable.ToString());
            Claimnumber_in_list = Gettext(attributeName_xpath, ClaimListClaimNumberHyperLink_AfterSearch_Xpath);
            if (Claimnumber_in_list != null)
            {
                Report.WriteLine("Claim is already submitted");
            }
            else
            {
                newsubmitted_claimnumber = "New Claim Submitting";
                Click(attributeName_id, Submit_A_Claim_button_Id);
                WaitForElementVisible(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");

                //All information passed - while submitting the claim
                Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
                IList<IWebElement> stationValues = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_StatiodropdownValues_xpath));
                int stnDropDownCount = stationValues.Count;
                for (int i = 0; i < stnDropDownCount; i++)
                {
                    if (stationValues[i].Text == Stationname)
                    {
                        stationValues[i].Click();
                        break;
                    }
                }


                // Thread.Sleep(2000);


                Click(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);
                IList<IWebElement> customerValues = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_CustomerdropdownValues_xpath));
                int custDropDownCount = customerValues.Count;
                for (int i = 0; i < custDropDownCount; i++)
                {
                    if (customerValues[i].Text == Customername)
                    {
                        customerValues[i].Click();
                        break;
                    }
                }


                SendKeys(attributeName_id, DLSWBillOfLading_Textbox_Id, DLSWRef);

                SendKeys(attributeName_id, CarrierName_Textbox_Id, CarrierName);

                Click(attributeName_id, DLSW_BOLDate_Field_Id);
                AnyNextDatePickerFromDoubleGridCalander(attributeName_xpath, DLSDate_Xpath, -1, DLSDateMonth_Xpath);
                UIDLSDate = Gettext(attributeName_id, DLSW_BOLDate_Field_Id);

                SendKeys(attributeName_id, CarrierPro_Textbox_Id, CarrierPRO);

                Click(attributeName_id, CarrierProDate_Field_Id);
                AnyNextDatePickerFromDoubleGridCalander(attributeName_xpath, CarrierProDate_Field_Values_Xpath, -1, CarrierProDate_Field_LeftArrow_Xpath);
                Report.WriteLine("Carrier information is passed");

                scrollpagedown();
                SendKeys(attributeName_id, Shipper_Name_Textbox_Id, ShipperName);
                SendKeys(attributeName_id, Shipper_Address_Textbox_Id, ShipperAddress);
                SendKeys(attributeName_id, Shipper_Address2_Textbox_Id, ShipperAdd2);
                SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, ShipperZip);
                   // Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
                   //Thread.Sleep(5000);
                   //SelectDropdownValueFromList(attributeName_xpath, Shipper_Country_dropdownValue_Xpath, ShipperCountry);
                   //Click(attributeName_id, ShipperState_Id);
                   // SelectDropdownValueFromList(attributeName_xpath, Shipper_provinceDropdown_values_Xpath, ShipperState);
                   // SendKeys(attributeName_id, Shipper_City_Textbox_Id, ShipperCity);
                Report.WriteLine("Shipper information is passed");

                SendKeys(attributeName_id, Consignee_Name_Textbox_Id, ConsigneName);
                SendKeys(attributeName_id, Consignee_Address_Textbox_Id, ConsigneAddress);
                SendKeys(attributeName_id, Consignee_Address2_Textbox_Id, ConsigneAddress2);
                SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, ConsigneZip);
                Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
                // Thread.Sleep(5000);
                SelectDropdownValueFromList(attributeName_xpath, Consignee_Country_dropdownValue_Xpath, ConsigneCountry);
                Click(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, Consignee_provinceDropdown_values_Xpath, ConsigneProvince);
                SendKeys(attributeName_id, Consignee_City_Textbox_Id, ConsigneCity);
                Report.WriteLine("Consignee information is passed");

                scrollpagedown();
                SendKeys(attributeName_id, ClaimPayableTo_CompanyName_Id, ClaimCompanyName);
                SendKeys(attributeName_id, ClaimPayableTo_Address_Id, ClaimAddress);
                SendKeys(attributeName_id, ClaimPayableTo_Address2_Id, ClaimAddress2);
                SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, ClaimZip);
                SendKeys(attributeName_id, ClaimPayableTo_City_Id, ClaimCity);
                Click(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath);
                //Thread.Sleep(5000);
                SelectDropdownValueFromList(attributeName_xpath, ClaimPayableTo_Country_dropdownValue_Xpath, ClaimCountry);
                SendKeys(attributeName_id, ClaimPayableTo_ContactName_Id, ClaimContactName);
                SendKeys(attributeName_id, ClaimPayableTo_ContactPhone_Id, ClaimPhone);
                SendKeys(attributeName_id, ClaimPayableTo_ContactEmail_Id, ClaimEmail);
                SendKeys(attributeName_id, ClaimPayableTo_CompanyWebsite_Id, ClaimWebsite);
                Report.WriteLine("Claim payable to information is passed");


                scrollpagedown();
                Click(attributeName_xpath, ArticlesInsuredYes_Xpath);
                SendKeys(attributeName_id, InsuredAmount_Id, InsuredAmount);

                Click(attributeName_xpath, ShortageOption_Xpath);
                Click(attributeName_xpath, ArticlesTypeUsed_Xpath);
                SendKeys(attributeName_id, UnitValue_Id, UnitVal);
                SendKeys(attributeName_id, Quantity_Id, Quantity);
                SendKeys(attributeName_id, Weight_LBS_Id, Weight);
                SendKeys(attributeName_id, ClaimedArticle_Description_Id, ClaimDescription);

                Click(attributeName_xpath, FreightChargeYes_Xpath);
                scrollpagedown();
                scrollpagedown();
                scrollElementIntoView(attributeName_classname, OriginFreightChargeOptionField_Class);
                SendKeys(attributeName_classname, OriginFreightChargeOptionField_Class, OriginFreightCharge);
                SendKeys(attributeName_classname, ReturnFreightVal_Class, ReturnFreight);
                SendKeys(attributeName_id, ReturnDLS_Id, ReturnDLS);
                SendKeys(attributeName_classname, ReplaceFreightVal_Class, ReplaceFreightCharge);
                SendKeys(attributeName_id, ReplaceDLS_Id, ReplaceDLS);
                Report.WriteLine("Claim details are been passed");


                scrollpagedown();
                scrollpagedown();
                // Thread.Sleep(3000);
                string oldPath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/searcherCheck.txt");
                //Thread.Sleep(3000);
                string newPath = Path.GetFullPath("../../Scripts/TestData/Temp/" + Guid.NewGuid().ToString() + "searcherCheck1.txt");
                //Thread.Sleep(3000);
                File.Copy(oldPath, newPath, true);
                FileUpload(attributeName_xpath, DocumentUploadButton_Xpath, newPath);
                //Thread.Sleep(3000);
                File.Delete(newPath);

                scrollElementIntoView(attributeName_id, AddAdditionalDocument_Button_Id);
                Click(attributeName_id, AddAdditionalDocument_Button_Id);
                WaitForElementVisible(attributeName_xpath, DocumentDropdown_Xpath, "Doctype");
                Click(attributeName_xpath, DocumentDropdown_Xpath);
                //Thread.Sleep(3000);
                SelectDropdownValueFromList(attributeName_xpath, DocumentDropdownValues_Xpath, DocumentType);
                //Thread.Sleep(5000);
                string oldAddPath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/hacker.txt");
                string newAddPath = Path.GetFullPath("../../Scripts/TestData/Temp/" + Guid.NewGuid().ToString() + "hacker1.txt");
                File.Copy(oldAddPath, newAddPath, true);
                FileUpload(attributeName_xpath, AdditionalUploadButton_Xpath, newAddPath);
                //Thread.Sleep(3000);
                File.Delete(newAddPath);
                Report.WriteLine("Documents are uploaded");


                SendKeys(attributeName_id, RemarksField_Id, Remark);

                ClaimNumber = DBHelper.GetClaimNumber();
                ClaimNumber++;


                Click(attributeName_id, SubmitClaimButton_Id);
                Report.WriteLine("Submitted the claim");

                GlobalVariables.webDriver.WaitForPageLoad();

                LatestClaim_Number = DBHelper.GetClaimNumber();
                ClaimNumber = LatestClaim_Number++;
            }

        }

        [Then(@"Save the copy of claim details separately in database")]
        public void ThenSaveTheCopyOfClaimDetailsSeparatelyInDatabase()
        {
            if (Claimnumber_in_list != null)
            {
                List<InsuranceClaimViewModel> ClaimDetails = DBHelper.GetInsuranceClaimSavedCopy_val(ClaimAvailable);
                //The Copy of Claim Details Separately in Database  
                Assert.AreEqual(ClaimDetails.FirstOrDefault().DlswRefNumber, DLSWRef);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().CarrierName, CarrierName);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().CarrierProNumber, CarrierPRO);

                Report.WriteLine("Passed carrier information is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperName, ShipperName);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperAddress, ShipperAddress);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperAdd2, ShipperAdd2);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperZip, ShipperZip);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperCountry, ShipperCountry);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperCity, ShipperCity);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperState, ShipperState);

                Report.WriteLine("Passed shipper information is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneName, ConsigneName);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneAddress, ConsigneAddress);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneAdd2, ConsigneAddress2);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneZip, ConsigneZip);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneCountry, ConsigneCountry);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneCity, ConsigneCity);
                //Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneState, ConsigneProvince);

                Report.WriteLine("Passed consigne information is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimCompanyName, ClaimCompanyName);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimAddress, ClaimAddress);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimAdd2, ClaimAddress2);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimZip, ClaimZip);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimCountry, ClaimCountry);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimCity, ClaimCity);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimContactName, ClaimContactName);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimContactPhone, ClaimPhone);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimContactEmail, ClaimEmail);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimWebsite, ClaimWebsite);

                Report.WriteLine("Passed Claim payable to information is saved in DB");
                if (ClaimDetails.FirstOrDefault().IsArticlesIns == true)
                {
                    Assert.AreEqual(ClaimDetails.FirstOrDefault().InsuredValAmount.ToString(), InsuredAmount);
                }
                else
                {
                    Report.WriteFailure("Articles insured flag was not set even after selecting 'YES'");

                }

                if (ClaimDetails.FirstOrDefault().ClaimTypeId == 1)
                {
                    Report.WriteLine("Claim type Shortage is inserted into DB");
                }
                else
                {
                    Report.WriteFailure("Claim type shortage is nor inserted into DB");
                }

                if (ClaimDetails.FirstOrDefault().AritcleTypeId == 2)
                {
                    Report.WriteLine("Articles type Used is inserted into DB");
                }
                else
                {
                    Report.WriteFailure("Articles type Used is not inserted into DB");
                }
                //Assert.AreEqual(ClaimDetails.FirstOrDefault().ItemNum, ItemMode);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().UnitVal.ToString(), UnitVal);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().Quantity.ToString(), Quantity);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().Weight.ToString(), Weight);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().Description, ClaimDescription);
                Report.WriteLine("Passed claim details are saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().OriginalFreightCharge.ToString(), OriginFreightCharge);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReturnFreightCharge.ToString(), ReturnFreight);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReplacementFreightCharge.ToString(), ReplaceFreightCharge);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReturnDLSRefNum, ReturnDLS);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReplaceDLSWRefNum, ReplaceDLS);
                Report.WriteLine("Passed Freight information is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().Remarks, Remark);

                if (ClaimDetails.FirstOrDefault().CreatedBy == "zzzext")
                {
                    Report.WriteLine("Username of the user who submitted the claim is inserted into DB");
                }
                else
                {
                    Assert.Fail();
                }
                if (ClaimDetails.FirstOrDefault().FirstName == "Zzz")
                {
                    Report.WriteLine("Firstname of the user who submitted the claim is saved in DB");
                }
                else
                {
                    Assert.Fail();
                }

                if (ClaimDetails.FirstOrDefault().LastName == "Ext")
                {
                    Report.WriteLine("Lastname of the user who submitted the claim is saved in DB");
                }
                else
                {
                    Assert.Fail();

                }
            }
            else
            {
                List<InsuranceClaimViewModel> ClaimDetails = DBHelper.GetInsuranceClaimSavedCopy_val(LatestClaim_Number);
                //The Copy of Claim Details Separately in Database  
                Assert.AreEqual(ClaimDetails.FirstOrDefault().DlswRefNumber, DLSWRef);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().CarrierName, CarrierName);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().CarrierProNumber, CarrierPRO);

                Report.WriteLine("Passed carrier information is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperName, ShipperName);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperAddress, ShipperAddress);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperAdd2, ShipperAdd2);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperZip, ShipperZip);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperCountry, ShipperCountry);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperCity, ShipperCity);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperState, ShipperState);

                Report.WriteLine("Passed shipper information is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneName, ConsigneName);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneAddress, ConsigneAddress);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneAdd2, ConsigneAddress2);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneZip, ConsigneZip);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneCountry, ConsigneCountry);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneCity, ConsigneCity);
                //Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneState, ConsigneProvince);

                Report.WriteLine("Passed consigne information is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimCompanyName, ClaimCompanyName);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimAddress, ClaimAddress);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimAdd2, ClaimAddress2);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimZip, ClaimZip);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimCountry, ClaimCountry);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimCity, ClaimCity);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimContactName, ClaimContactName);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimContactPhone, ClaimPhone);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimContactEmail, ClaimEmail);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimWebsite, ClaimWebsite);

                Report.WriteLine("Passed Claim payable to information is saved in DB");
                if (ClaimDetails.FirstOrDefault().IsArticlesIns == true)
                {
                    Assert.AreEqual(ClaimDetails.FirstOrDefault().InsuredValAmount.ToString(), InsuredAmount);
                }
                else
                {
                    Report.WriteFailure("Articles insured flag was not set even after selecting 'YES'");

                }

                if (ClaimDetails.FirstOrDefault().ClaimTypeId == 1)
                {
                    Report.WriteLine("Claim type Shortage is inserted into DB");
                }
                else
                {
                    Report.WriteFailure("Claim type shortage is nor inserted into DB");
                }

                if (ClaimDetails.FirstOrDefault().AritcleTypeId == 2)
                {
                    Report.WriteLine("Articles type Used is inserted into DB");
                }
                else
                {
                    Report.WriteFailure("Articles type Used is not inserted into DB");
                }
                //Assert.AreEqual(ClaimDetails.FirstOrDefault().ItemNum, ItemMode);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().UnitVal.ToString(), UnitVal);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().Quantity.ToString(), Quantity);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().Weight.ToString(), Weight);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().Description, ClaimDescription);
                Report.WriteLine("Passed claim details are saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().OriginalFreightCharge.ToString(), OriginFreightCharge);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReturnFreightCharge.ToString(), ReturnFreight);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReplacementFreightCharge.ToString(), ReplaceFreightCharge);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReturnDLSRefNum, ReturnDLS);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ReplaceDLSWRefNum, ReplaceDLS);
                Report.WriteLine("Passed Freight information is saved in DB");
                Assert.AreEqual(ClaimDetails.FirstOrDefault().Remarks, Remark);

                if (ClaimDetails.FirstOrDefault().CreatedBy == "zzzext")
                {
                    Report.WriteLine("Username of the user who submitted the claim is inserted into DB");
                }
                else
                {
                    Assert.Fail();
                }
                if (ClaimDetails.FirstOrDefault().FirstName == "Zzz")
                {
                    Report.WriteLine("Firstname of the user who submitted the claim is saved in DB");
                }
                else
                {
                    Assert.Fail();
                }

                if (ClaimDetails.FirstOrDefault().LastName == "Ext")
                {
                    Report.WriteLine("Lastname of the user who submitted the claim is saved in DB");
                }
                else
                {
                    Assert.Fail();

                }
            }

        }

        [Given(@"I am on the Claim Details page of existing claim")]
        public void GivenIAmOnTheClaimDetailsPageOfExistingClaim()
        {
            SendKeys(attributeName_xpath, ClaimListSearchTextBox_xpath, ClaimAvailable.ToString());
            Claimnumber_in_list = Gettext(attributeName_xpath, ClaimListClaimNumberHyperLink_AfterSearch_Xpath);
            if (Claimnumber_in_list != null)
            {
                Click(attributeName_xpath, ClaimListClaimNumberHyperLink_AfterSearch_Xpath);
                scrollPageup();
                scrollPageup();
                Verifytext(attributeName_xpath, ClaimDetails_PageLebel_Xpath, "Claim Details");
            }
            else
            {
                SendKeys(attributeName_xpath, ClaimListSearchTextBox_xpath, LatestClaim_Number.ToString());
                Click(attributeName_xpath, ClaimListClaimNumberHyperLink_AfterSearch_Xpath);
                scrollPageup();
                scrollPageup();
                Verifytext(attributeName_xpath, ClaimDetails_PageLebel_Xpath, "Claim Details");
            }
        }


        [Given(@"I updated the fields on claim Details page")]
        public void GivenIUpdatedTheFieldsOnClaimDetailsPage()
        {

            SendKeys(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, U_DLSWRef);
            scrollpagedown();
            scrollpagedown();
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath, U_ShipperName);
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, U_ShipperZip);
            scrollpagedown();
            scrollpagedown();
            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, U_ConsigneName);
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, U_ConsigneZip);
            SendKeys(attributeName_id, Remarks_Id, U_Remark);

            SendKeys(attributeName_id, ClaimedFreight_Textbox_Original_Id, U_OriginFreightCharge);

        }

        [Then(@"The saved copy of Claim details will not be updated in database")]
        public void ThenTheSavedCopyOfClaimDetailsWillNotBeUpdatedInDatabase()
        {
            if (Claimnumber_in_list != null)
            {
                List<InsuranceClaimViewModel> ClaimDetails = DBHelper.GetInsuranceClaimSavedCopy_val(ClaimAvailable);  
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().DlswRefNumber, U_DLSWRef);
                Report.WriteLine("Passed carrier information is saved in DB");

                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ShipperName, U_ShipperName);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ShipperZip, U_ShipperZip);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ShipperCountry, ShipperCountry);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ShipperCity, U_ShipperCity);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ShipperState, U_ShipperState);
                Report.WriteLine("Passed shipper information is saved in DB");

                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ConsigneName, U_ConsigneName);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ConsigneZip, U_ConsigneZip);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ConsigneCountry, U_ConsigneCountry);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ConsigneCity, U_ConsigneCity);
                Report.WriteLine("Passed consignee information is saved in DB");

                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().Remarks, U_Remark);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().OriginalFreightCharge.ToString(), U_OriginFreightCharge);
                Report.WriteLine("Passed Freight information is saved in DB");

            }
            else
            {
                List<InsuranceClaimViewModel> ClaimDetails = DBHelper.GetInsuranceClaimSavedCopy_val(LatestClaim_Number);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().DlswRefNumber, U_DLSWRef);
                Report.WriteLine("Passed carrier information is saved in DB");

                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ShipperName, U_ShipperName);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ShipperZip, U_ShipperZip);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ShipperCountry, ShipperCountry);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ShipperCity, U_ShipperCity);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ShipperState, U_ShipperState);
                Report.WriteLine("Passed shipper information is saved in DB");

                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ConsigneName, U_ConsigneName);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ConsigneZip, U_ConsigneZip);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ConsigneCountry, U_ConsigneCountry);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().ConsigneCity, U_ConsigneCity);
                Report.WriteLine("Passed consignee information is saved in DB");

                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().Remarks, U_Remark);
                Assert.AreNotEqual(ClaimDetails.FirstOrDefault().OriginalFreightCharge.ToString(), U_OriginFreightCharge);
                Report.WriteLine("Passed Freight information is saved in DB");
            }
        }

        [Then(@"The existing saved claim details will be updated in database")]
        public void ThenTheExistingSavedClaimDetailsWillBeUpdatedInDatabase()
        {
            if (Claimnumber_in_list != null)
            {
                List<InsuranceClaimViewModel> ClaimDetails = DBHelper.GetInsuranceClaimVal(ClaimAvailable); 
                Assert.AreEqual(ClaimDetails.FirstOrDefault().DlswRefNumber, U_DLSWRef);
                Report.WriteLine("Passed carrier information is saved in DB");

                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperName, U_ShipperName);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperZip, U_ShipperZip);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperCountry, ShipperCountry);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperCity, U_ShipperCity);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperState, U_ShipperState);
                Report.WriteLine("Passed shipper information is saved in DB");

                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneName, U_ConsigneName);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneZip, U_ConsigneZip);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneCountry, U_ConsigneCountry);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneCity, U_ConsigneCity);
                Report.WriteLine("Passed consignee information is saved in DB");

                Assert.AreEqual(ClaimDetails.FirstOrDefault().Remarks, U_Remark);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().OriginalFreightCharge.ToString(), U_OriginFreightCharge);
                Report.WriteLine("Passed Freight information is saved in DB");

            }
            else
            {
                List<InsuranceClaimViewModel> ClaimDetails = DBHelper.GetInsuranceClaimVal(LatestClaim_Number); 
                Assert.AreEqual(ClaimDetails.FirstOrDefault().DlswRefNumber, U_DLSWRef);
                Report.WriteLine("Passed carrier information is saved in DB");

                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperName, U_ShipperName);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperZip, U_ShipperZip);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperCountry, ShipperCountry);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperCity, U_ShipperCity);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperState, U_ShipperState);
                Report.WriteLine("Passed shipper information is saved in DB");

                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneName, U_ConsigneName);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneZip, U_ConsigneZip);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneCountry, U_ConsigneCountry);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneCity, U_ConsigneCity);
                Report.WriteLine("Passed consignee information is saved in DB");

                Assert.AreEqual(ClaimDetails.FirstOrDefault().Remarks, U_Remark);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().OriginalFreightCharge.ToString(), U_OriginFreightCharge);
                Report.WriteLine("Passed Freight information is saved in DB");
            }
        }

    }
}
