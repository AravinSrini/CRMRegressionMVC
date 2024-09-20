using CRM.UITest.CommonMethods;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.CustomReportXML;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.Dls.IdentityServer.Core.Dto;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class Insurance_Claims___Claim_Form___Station_and_Customer_InfoSteps : Objects.InsuranceClaim
    {
        List<ShipmentListViewModel> Sdata;
        List<string> cust;
        List<string> custNamesUI = new List<string>();

        string actualPickup;
        string primaryReference;
        string carrierName;
        string pRONumber;
        string originName;
        string originAddress;
        string originAddress2;
        string originZip;
        string originCountry;
        string originCity;
        string originState;
        string destinationName;
        string destinationAddress;
        string destinationAddress2;
        string destinationZip;
        string destinationCountry;
        string destinationCity;
        string destinationState;
        string internalID;
        string owner;

        //data for saving the claim 
        string DLSBill = "BillLading123";
        string CarrierName = "Carrier123";
        string CarrierPRO = "123QA";
        string ShipperName = "Testing 1@3";
        string ShipperAddress = "AddressTest!123";
        string ShipperAdd2 = "Address223";
        string ShipperZip = "90001";
        string ShipperCity = "los@#$%";
        string ConsigneName = "Consigneename";
        string ConsigneAddress = "ConsigneAddress";
        string ConsigneAddress2 = "ConsigneAddress2";
        string ConsigneZip = "33126";
        string ConsigneCity = "ConsigneeCity#234";
        string ClaimCompanyName = "CompanyName";
        string ClaimAddress = "Address )**(434";
        string ClaimAddress2 = "Address2";
        string ClaimCity = "City";
        string ClaimProvince = "FL";
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
        string ReturnDLS = "45564321236789087654";
        string ReplaceFreightCharge = "20.00";
        string ReplaceDLS = "532756";
        string Remark = "jdhasu5535437hgd$#%^";
        string ShipperCountry = "United States";
        string ShipperState = "AL";
        string ConsigneCountry = "United States";
        string ConsigneProvince = "AL";
        string ClaimCountry = "United States";
        string DocumentType = "Repair Invoice";
        string ClaimZip = "32435";
        int ClaimNumber = 0;
        string UIDLSDate = null;
        string Fullpath = "../../Scripts/TestData/Testfiles_ClaimDocument/QuoteListCheck.txt";

        //common data

        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        WebElementOperations getListfromWebElement = new WebElementOperations();
        public string stationName = "ZZZ - Web Services Test";
        public string customerName = "ZZZ - GS Customer Test";
        public string stationID = "ZZZ";
        public string username;

        [Given(@"I am a Sales, Sales Management, Operations, Station Owner, or Claims Specialist user")]
        public void GivenIAmASalesSalesManagementOperationsStationOwnerOrClaimsSpecialistUser()
        {
            username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [Given(@"I am a crm Sales user")]
        public void GivenIAmACrmSalesUser()
        {
            username = ConfigurationManager.AppSettings["username-Sales"].ToString();
            string password = ConfigurationManager.AppSettings["password-Sales"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [When(@"I arrive on the Insurance Claim - Submit a Claim page")]
        public void WhenIArriveOnTheInsuranceClaim_SubmitAClaimPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, Submit_A_Claim_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");
            VerifyElementPresent(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");

        }

        [Then(@"I should see Station and Customer drop down fields beneath the Enter DLSW Ref\# to Start Process")]
        public void ThenIShouldSeeStationAndCustomerDropDownFieldsBeneathTheEnterDLSWRefToStartProcess()
        {
            VerifyElementPresent(attributeName_xpath, SubmitaClaim_StationDropDownLable_xpath, "STATION label");
            VerifyElementPresent(attributeName_xpath, SubmitaClaim_CustomerDropDownLable_xpath, "CUSTOMER Label");

            Verifytext(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath, "Select...");
            Verifytext(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath, "Select...");


        }


        [Then(@"Station and Customer drop down fields should be the required fields")]
        public void ThenStationAndCustomerDropDownFieldsShouldBeTheRequiredFields()
        {
           
            string stationlabel = Gettext(attributeName_xpath, SubmitaClaim_StationDropDownLable_xpath);
            if (stationlabel.Contains("*"))
            {
                Report.WriteLine("Station is the required field");
            }
            else
            {
                Report.WriteLine("Station is the not required field");
                Assert.Fail();
            }

            string customerlabel = Gettext(attributeName_xpath, SubmitaClaim_CustomerDropDownLable_xpath);
            if (customerlabel.Contains("*"))
            {
                Report.WriteLine("Station is the required field");
            }
            else
            {
                Report.WriteLine("Station is the not required field");
                Assert.Fail();
            }


            //Report.WriteLine("Clicked on Submit claim button");
            //scrollpagedown();
            //scrollElementIntoView(attributeName_id, SubmitClaimButton_Id);
            //(attributeName_id, SubmitClaimButton_Id);
            //GlobalVariables.webDriver.WaitForPageLoad();
            //IWebElement stationColor = GlobalVariables.webDriver.FindElement(By.XPath(SubmitaClaim_Stationdropdown_xpath));
            //string stnbgdColor = stationColor.GetCssValue("background-image");
            //string stnimg = "/images/formicons.png";
            //if (stnbgdColor.Contains("rgb(251, 236, 236)") && stnbgdColor.Contains(stnimg))
            //{
            //    Report.WriteLine("station background color matches");

            //}
            //else
            //{
            //    Assert.Fail();
            //}



            //IWebElement customerColor = GlobalVariables.webDriver.FindElement(By.XPath(SubmitaClaim_Customerdropdown_xpath));
            //string custbgdColor = stationColor.GetCssValue("background-image");
            //string custimg = "/images/formicons.png";
            //if (custbgdColor.Contains("rgb(251, 236, 236)") && custbgdColor.Contains(custimg))
            //{
            //    Report.WriteLine("station background color matches");

            //}
            //else
            //{
            //    Assert.Fail();
            //}
        }

        

        [Given(@"I entered valid DLSW Ref Number (.*)")]
        public void GivenIEnteredValidDLSWRefNumber(string DLSWBOLNumber)
        {
            SendKeys(attributeName_id, Enter_DLSW_BOLNumber_Textbox_Id, DLSWBOLNumber);
        }


        [Given(@"Click on the Populate Form button on the Submit a Claim page")]
        public void GivenClickOnThePopulateFormButtonOnTheSubmitAClaimPage()
        {
            Click(attributeName_id, PopulateForm_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [When(@"I receive the data for the submitted DLSW reference number from MG (.*)")]
        public void WhenIReceiveTheDataForTheSubmittedDLSWReferenceNumberFromMG(string DLSWBOLNumber)
        {
            BuildHttpClient objBuildHttpClient = new BuildHttpClient();
            HttpClient headers = objBuildHttpClient.BuildHttpClientWithHeaders("Admin", "application/xml");
            GetCustomReportXML _CustXml = new GetCustomReportXML();
            XElement resuestXML = _CustXml.getListExtractRequestXML(DLSWBOLNumber);

            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen Slist = new ShipmentListScreen();
            Sdata = Slist.CallListScreenAutopopulate(uri, headers, resuestXML);


            actualPickup = Sdata[1].ActualPickup;
            primaryReference = Sdata[1].PrimaryReference;
            carrierName = Sdata[1].CarrierName;
            pRONumber = Sdata[1].PRONumber;
            originName = Sdata[1].OriginName;
            originAddress = Sdata[1].OriginAddress;
            originAddress2 = Sdata[1].OriginAddress2;
            originZip = Sdata[1].OriginZip;
            originCountry = Sdata[1].OriginCountry;
            originCity = Sdata[1].OriginCity;
            originState = Sdata[1].OriginState;
            destinationName = Sdata[1].DestinationName;
            destinationAddress = Sdata[1].DestinationAddress;
            destinationAddress2 = Sdata[1].DestinationAddress2;
            destinationZip = Sdata[1].DestinationZip;
            destinationCountry = Sdata[1].DestinationCountry;
            destinationCity = Sdata[1].DestinationCity;
            destinationState = Sdata[1].DestinationState;
            internalID = Sdata[1].InternalID;
            owner = Sdata[1].Owner;
        }


        [Given(@"I am on the Insurance Claim - Submit a Claim page")]
        public void GivenIAmOnTheInsuranceClaim_SubmitAClaimPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, Submit_A_Claim_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");
            VerifyElementPresent(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");
            }


        [When(@"I Click on the Station drop down field")]
        public void WhenIClickOnTheStationDropDownField()
        {
            Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
        }


        [Then(@"I should see only list of Stations to which user is associated to")]
        public void ThenIShouldSeeOnlyListOfStationsToWhichUserIsAssociatedTo()
        {
            List<string> stationNamesUI = new List<string>();
            IList<IWebElement> stationValues = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_StatiodropdownValues_xpath));
            for (int i = 1; i < stationValues.Count; i++)
            {
                stationNamesUI.Add(stationValues[i].Text);
            }

            
            Report.WriteLine("User should see Dashboard icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);


            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails("crmOperation");
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-StationId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();

            List<string> stationId = claimValue.Select(x => x.ClaimValue).ToList();

            List<string> stationNames = DBHelper.GetStationNames(stationId);

            Assert.AreEqual(stationNamesUI.Count, stationNames.Count);

            for (int i = 0; i < stationNames.Count; i++)
            {
                stationNames.Sort();
                if (stationNames[i] == stationNamesUI[i])
                {
                    Report.WriteLine("Expected value :" + stationNames[i] + " is equal to the actual value: " + stationNamesUI[i]);
                }
                else
                {
                    Report.WriteFailure("Station Names not matching with mapped Station names for the user");
                }


            }


        }


        [Then(@"the stations should be listed first in numerical then in alphabetical order")]
        public void ThenTheStationsShouldBeListedFirstInNumericalThenInAlphabeticalOrder()
        {
            Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_StatiodropdownValues_xpath));
            List<string> actualDropdownlist = getListfromWebElement.GetListFromIWebElement(dropDownList);

            List<string> alphabeticalArray = new List<string>();
            for (int i = 0; i < actualDropdownlist.Count; i++)
            {
                alphabeticalArray.Add(actualDropdownlist[i]);
            }
            actualDropdownlist.Sort();
            CollectionAssert.AreEqual(actualDropdownlist, alphabeticalArray);
            Report.WriteLine("Displayed Stations are sorted in alphabetical order");
        }


        [Given(@"I Click on the Station drop down field")]
        public void GivenIClickOnTheStationDropDownField()
        {
            Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
            IList<IWebElement> stationValues = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_StatiodropdownValues_xpath));
            int stnDropDownCount = stationValues.Count;
            for (int i = 0; i < stnDropDownCount; i++)
            {
                if (stationValues[i].Text == stationName)
                {
                    stationValues[i].Click();
                    break;
                }
            }
        }


        [When(@"I Click on the Customer drop down field")]
        public void WhenIClickOnTheCustomerDropDownField()
        {

            Click(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);

        }


        [Then(@"the Station and Customer field should be auto populated with the Station and Customer associated with the DLSW Ref\#")]
        public void ThenTheStationAndCustomerFieldShouldBeAutoPopulatedWithTheStationAndCustomerAssociatedWithTheDLSWRef()
        {
            string stationAutopopulatedUI = Gettext(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
            Assert.AreEqual(stationAutopopulatedUI, "ZZZ - Web Services Test");

            string customerAutopopulateUI = Gettext(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);
            Assert.AreEqual(customerAutopopulateUI, "Superior Nut and Candy Company");

        }

        [Given(@"I select Station and Customer to which I am associated")]
        public void GivenISelectStationAndCustomerToWhichIAmAssociated()
        {
            Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
            IList<IWebElement> stationValues = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_StatiodropdownValues_xpath));
            int stnDropDownCount = stationValues.Count;
            for (int i = 0; i < stnDropDownCount; i++)
            {
                if (stationValues[i].Text == stationName)
                {
                    stationValues[i].Click();
                    break;
                }
            }

            Thread.Sleep(2000);


            Click(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);
            IList<IWebElement> customerValues = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_CustomerdropdownValues_xpath));
            int custDropDownCount = customerValues.Count;
            for (int i = 0; i < custDropDownCount; i++)
            {
                if (customerValues[i].Text == customerName)
                {
                    customerValues[i].Click();
                    break;
                }
            }

        }


        [Then(@"I should not be able to edit the Station and Customer fields")]
        public void ThenIShouldNotBeAbleToEditTheStationAndCustomerFields()
        {
            
            string station = GetValue(attributeName_xpath, "//div[@class='chosen-container chosen-container-single chosen-container-single-nosearch dropdownStation chosen-select chosen-disabled']", "class");
            if (station.Contains("disabled"))
            {
                Report.WriteLine("Station field is not editable");

            }else
            {
                Report.WriteLine("Station field is not editable");
            }

            string customer = GetValue(attributeName_xpath, "//div[@class='chosen-container chosen-container-single dropdownCUSTOMER chosen-select chosen-disabled']", "class");
            if (customer.Contains("disabled"))
            {
                Report.WriteLine("Station field is not editable");

            }
            else
            {
                Report.WriteLine("Station field is not editable");
            }


        }



        [When(@"I receive the data for the submitted DLSW reference number from CSA (.*)")]
        public void WhenIReceiveTheDataForTheSubmittedDLSWReferenceNumberFromCSA(string DLSWBOLNumber)
        {
            ShipmentInquiryOutputV3 result = null;

            using (ShipmentsSoapClient csaClient = new ShipmentsSoapClient())
            {

                result = csaClient.ShipmentInquiryV3("", DLSWBOLNumber);

                //Extracting Data and storing in variable
                actualPickup = result.ShipInqOutput[0].ShipmentDate;
                primaryReference = result.ShipInqOutput[0].Housebill;
                int costCount = result.ShipInqOutput[0].Costs.Length;
                if (costCount > 0)
                {
                    carrierName = result.ShipInqOutput[0].Costs[0].VendorName;
                }
                else
                {
                    carrierName = "";
                }

                int refCount = result.ShipInqOutput[0].References.Length;
                if (refCount > 0)
                {
                    pRONumber = result.ShipInqOutput[0].References[0].RefNo;
                }
                else
                {
                    pRONumber = "";
                }
                originName = result.ShipInqOutput[0].ShipperName;
                originAddress = result.ShipInqOutput[0].ShipperAddress1;
                originAddress2 = result.ShipInqOutput[0].ShipperAddress2;
                originZip = result.ShipInqOutput[0].ShipperZip;
                originCountry = result.ShipInqOutput[0].ShipperCountry;
                originCity = result.ShipInqOutput[0].ShipperCity;
                originState = result.ShipInqOutput[0].ShipperState;
                destinationName = result.ShipInqOutput[0].ConsigneeName;
                destinationAddress = result.ShipInqOutput[0].ConsigneeAddress1;
                destinationAddress2 = result.ShipInqOutput[0].ConsigneeAddress2;
                destinationZip = result.ShipInqOutput[0].ConsigneeZip;
                destinationCountry = result.ShipInqOutput[0].ConsigneeCountry;
                destinationCity = result.ShipInqOutput[0].ConsigneeCity;
                destinationState = result.ShipInqOutput[0].ConsigneeState;
            }
        }



        [Then(@"I should see only list of Customer to which user is associated to")]
        public void ThenIShouldSeeOnlyListOfCustomerToWhichUserIsAssociatedTo()
        {

            IList<IWebElement> custValues = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_CustomerdropdownValues_xpath));
            for (int i = 1; i < custValues.Count; i++)
            {
                custNamesUI.Add(custValues[i].Text);
            }

            List<CustomerSetup> customerNames = DBHelper.GetAllCustomersForTheStations(stationID);
            List<string> cust = customerNames.Select(x => x.CustomerName).ToList();
            Thread.Sleep(400);

            
            cust.Sort();
            custNamesUI.Sort();

            for (int i =0;i< cust.Count; i++)
            {
                if (i == 226)
                {
                    string DB = cust[i];
                    string[] lines = DB.Split();
                    string first = lines[0] +" "+ lines[1] +" "+ lines[2];
                    string second = lines[4] +" "+ lines[5];
                    string result = first + " " + second;
                    string UI = custNamesUI[i];
                    if (result == UI)
                    {

                        Report.WriteLine("Expected value is equal to the actual value");
                    }
                    else
                    {
                        Report.WriteFailure("Station Names of " + cust[i] + " is not matching with mapped Station names of " + custNamesUI[i] + " for the user");
                    }



                }else if (cust[i] == custNamesUI[i])
                {
                   
                    Report.WriteLine("Expected value :" + cust[i] + " is equal to the actual value: " + custNamesUI[i]);
                }
                else
                {
                    Report.WriteFailure("Station Names of " + cust[i] + " is not matching with mapped Station names of " + custNamesUI[i] +" for the user");
                }


            }

        }

        [Then(@"I should see only list of Customer to which user is associated to to Sales user")]
        public void ThenIShouldSeeOnlyListOfCustomerToWhichUserIsAssociatedToToSalesUser()
        {
            Report.WriteLine("User should see Dashboard icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);


            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails("MappingsalesUser");
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-CustomerSetUpId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();
            List<int> custSetupId = claimValue.Select(x => Convert.ToInt32(x.ClaimValue)).ToList();

            List<int> custAccId = DBHelper.GetCustomerAccountNumber(custSetupId);
            List<string> CustNames_p = DBHelper.CustomerNameOfPrimaryAccount(custSetupId);
            List<string> CustNames_S = DBHelper.CustomerNameOfSubAccountUnderPrimaryAccount(custAccId);
            CustNames_p.AddRange(CustNames_S);
            Click(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);

            IList<IWebElement> custValues = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_CustomerdropdownValues_xpath));
            for (int i = 1; i < custValues.Count; i++)
            {
                custNamesUI.Add(custValues[i].Text);
            }

            CustNames_p.Sort();
            custNamesUI.Sort();


            for (int i = 0; i < CustNames_p.Count; i++)
            {
                if (CustNames_p[i] == custNamesUI[i])
                {
                    Report.WriteLine("Expected value :" + CustNames_p[i] + " is equal to the actual value: " + custNamesUI[i]);
                }
                else
                {
                    Report.WriteFailure("Customer names not matching with mapped customer names for the user");
                }


            }

        }


        [Then(@"the Customer names should be listed in hierarchy format")]
        public void ThenTheCustomerNamesShouldBeListedInHierarchyFormat()
        {
            string customerNameActual = "ZZZ - Czar Customer Test";
            List<string> customerNamesList = DBHelper.GetCustomerNameOfSubAccountUnderPrimaryAccount(customerNameActual);

            
            IList<IWebElement> subAccounts = GlobalVariables.webDriver.FindElements(By.XPath(".//li[contains (@class,'level1')]"));
            List<string> SubAccountListValues = getListfromWebElement.GetListFromIWebElement(subAccounts);

            Assert.AreEqual(customerNamesList.Count, SubAccountListValues.Count);
            Report.WriteLine("Displayed sub accounts mapped to the chosen primary account");
                
                
            
        }


        [Then(@"the Customer names should be listed first in numerical then in alphabetical order")]
        public void ThenTheCustomerNamesShouldBeListedFirstInNumericalThenInAlphabeticalOrder()
        {
            Click(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(SubmitaClaim_CustomerdropdownValues_xpath));
            List<string> actualDropdownlist = getListfromWebElement.GetListFromIWebElement(dropDownList);

            List<string> alphabeticalArray = new List<string>();
            for (int i = 0; i < actualDropdownlist.Count; i++)
            {
                alphabeticalArray.Add(actualDropdownlist[i]);
            }
            actualDropdownlist.Sort();
            alphabeticalArray.Sort();
            CollectionAssert.AreEqual(actualDropdownlist, alphabeticalArray);
            Report.WriteLine("Displayed Stations are sorted in alphabetical order");
        }



        [Given(@"I pass data to all the fields on SUbmit a Claim page")]
        public void GivenIPassDataToAllTheFieldsOnSUbmitAClaimPage()
        {
            SendKeys(attributeName_id, DLSWBillOfLading_Textbox_Id, DLSBill);
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
            Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Shipper_Country_dropdownValue_Xpath, ShipperCountry);
            Click(attributeName_id, ShipperState_Id);
            SelectDropdownValueFromList(attributeName_xpath, Shipper_provinceDropdown_values_Xpath, ShipperState);
            SendKeys(attributeName_id, Shipper_City_Textbox_Id, ShipperCity);
            Report.WriteLine("Shipper information is passed");
            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, ConsigneName);
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, ConsigneAddress);
            SendKeys(attributeName_id, Consignee_Address2_Textbox_Id, ConsigneAddress2);
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, ConsigneZip);
            Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            Thread.Sleep(5000);
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
            Thread.Sleep(5000);
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
            Thread.Sleep(3000);
            string oldPath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/searcherCheck.txt");
            Thread.Sleep(3000);
            string newPath = Path.GetFullPath("../../Scripts/TestData/Temp/" + Guid.NewGuid().ToString() + "searcherCheck1.txt");
            Thread.Sleep(3000);
            File.Copy(oldPath, newPath, true);
            FileUpload(attributeName_xpath, DocumentUploadButton_Xpath, newPath);
            Thread.Sleep(3000);
            File.Delete(newPath);
            scrollElementIntoView(attributeName_id, AddAdditionalDocument_Button_Id);
            Click(attributeName_id, AddAdditionalDocument_Button_Id);
            WaitForElementVisible(attributeName_xpath, DocumentDropdown_Xpath, "Doctype");
            Click(attributeName_xpath, DocumentDropdown_Xpath);
            Thread.Sleep(3000);
            SelectDropdownValueFromList(attributeName_xpath, DocumentDropdownValues_Xpath, DocumentType);
            Thread.Sleep(5000);
            string oldAddPath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/hacker.txt");
            string newAddPath = Path.GetFullPath("../../Scripts/TestData/Temp/" + Guid.NewGuid().ToString() + "hacker1.txt");
            File.Copy(oldAddPath, newAddPath, true);
            FileUpload(attributeName_xpath, AdditionalUploadButton_Xpath, newAddPath);
            Thread.Sleep(3000);
            File.Delete(newAddPath);
            Report.WriteLine("Documents are uploaded");
            SendKeys(attributeName_id, RemarksField_Id, Remark);
            ClaimNumber = DBHelper.GetClaimNumber();
            ClaimNumber++;
        }




        [Then(@"All the passed data should get saved in DB along with the username of the user that submitted the claim, First name  and last name of the submitted user, date and time")]
        public void ThenAllThePassedDataShouldGetSavedInDBAlongWithTheUsernameOfTheUserThatSubmittedTheClaimFirstNameAndLastNameOfTheSubmittedUserDateAndTime()
        {
            List<InsuranceClaimViewModel> ClaimDetails = DBHelper.GetInsuranceClaimVal(ClaimNumber);
            Thread.Sleep(2000);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().DlswRefNumber, DLSBill);
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
            if (ClaimDetails.FirstOrDefault().CreatedBy == username)
            {
                Report.WriteLine("Username of the user who submitted the claim is inserted into DB");
            }
            else
            {
                Assert.Fail();
            }
            if (ClaimDetails.FirstOrDefault().FirstName == "Alphaoperation")
            {
                Report.WriteLine("Firstname of the user who submitted the claim is saved in DB");
            }
            else
            {
                Assert.Fail();
            }

            if (ClaimDetails.FirstOrDefault().LastName == "User")
            {
                Report.WriteLine("Lastname of the user who submitted the claim is saved in DB");
            }
            else
            {
                Assert.Fail();

            }
        }


        [Then(@"Submitted Claim will be placed in Pending Status\.")]
        public void ThenSubmittedClaimWillBePlacedInPendingStatus_()
        {
            int StatusId = DBHelper.GetInsuranceStatus(ClaimNumber);
            if (StatusId == 4)
            {
                Report.WriteLine("Submited Insurance claim is placed in pending status");
            }
            else
            {
                Report.WriteFailure("Submited Insurance claim is not placed in pending status");
            }
        }





    }

}

