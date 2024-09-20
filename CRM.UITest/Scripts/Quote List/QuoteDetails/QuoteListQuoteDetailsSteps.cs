using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.Dls.IdentityServer.Core.Dto;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote_List.QuoteDetails
{
    [Binding]
    public class QuoteListQuoteDetailsSteps : Quotelist
    {
        string Quotenumber = null;
        string errorMessage = string.Empty;

       
        [When(@"I filter the LTL services (.*) for New quotes")]
        public string WhenIFilterTheLTLServicesForNewQuotes(string Service)
        {
            
            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Quotenumber = Gettext(attributeName_xpath, QuoteList_FirstRecord_QuoteNumber_xpath);
                Thread.Sleep(1000);
                Click(attributeName_id, QuoteList_NewRadioButton_Id);
                Click(attributeName_xpath, QuoteList_SearchBox_DropdownArrow_Xpath);
                Thread.Sleep(1000);
                //WaitForElementVisible(attributeName_id, QuoteList_ClearAll_Id, "Clear All Button");
                Click(attributeName_id, QuoteList_Search_ClearButton_Id);
                Click(attributeName_xpath, QuoteList_Service_Option_Xpath);
                SendKeys(attributeName_id, QuoteList_Search_Box_Id, "LTL");
                Click(attributeName_xpath, QuoteList_SearchBox_DropdownArrow_Xpath);


            }
            else
            {
                Report.WriteLine("No Records found for the LTL Quoted status for the logged in user so unable to test the scenario");
            }
                      
            return Quotenumber;
        }


        [When(@"I filter the LTL services (.*)\tfor Expired status")]
        public string WhenIFilterTheLTLServicesForExpiredStatus(string Service)
        {
            
            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Quotenumber = Gettext(attributeName_xpath, QuoteList_FirstRecord_QuoteNumber_xpath);
                Thread.Sleep(1000);
                Click(attributeName_id, QuoteList_ExpiredButton_Id);
                Click(attributeName_xpath, QuoteList_SearchBox_DropdownArrow_Xpath);
                Thread.Sleep(1000);
                //WaitForElementVisible(attributeName_id, QuoteList_ClearAll_Id, "Clear All Button");
                Click(attributeName_id, QuoteList_Search_ClearButton_Id);
                Click(attributeName_xpath, QuoteList_Service_Option_Xpath);
                SendKeys(attributeName_id, QuoteList_Search_Box_Id, "LTL");
                Click(attributeName_xpath, QuoteList_SearchBox_DropdownArrow_Xpath);


            }
            else
            {
                Report.WriteLine("No Records found for the LTL Quoted status for the logged in user so unable to test the scenario");
            }

            return Quotenumber;
        }




        [When(@"I expand the quote details of any quote in the Quoted status (.*)")]
        public void WhenIExpandTheQuoteDetailsOfAnyQuoteInTheQuotedStatus(string UserType)
        {
            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Quotenumber = Gettext(attributeName_xpath, QuoteList_FirstRecord_QuoteNumber_xpath);
                Thread.Sleep(1000);

                if (UserType == ("ShipEntry") || (UserType == "ShipInquiry"))
                {
                    Click(attributeName_xpath, QuoteList_Expand_FirstRecord_Xpath);
                    Thread.Sleep(2000);

                }
                else if (UserType == ("Operation") || (UserType == "Sales") || UserType == ("SalesManagement") || (UserType == "StationOwner"))
                {
                    Click(attributeName_xpath, QuoteList_Internal_Expand_FirstRecord_Xpath);
                }

            }
            else
            {
                Report.WriteLine("No Records found for the LTL Quoted status for the logged in user so unable to test the scenario");
            }

            

        }

        [When(@"I filter the LTL services (.*) for Expired quotes")]
        public string WhenIFilterTheLTLServicesForExpiredQuotes(string Service)
        {
            Click(attributeName_id, QuoteList_ExpiredButton_Id);
            Click(attributeName_xpath, QuoteList_SearchBox_DropdownArrow_Xpath);
            //WaitForElementVisible(attributeName_id, QuoteList_ClearAll_Id, "Clear All Button");
            Click(attributeName_id, QuoteList_Search_ClearButton_Id);
            Click(attributeName_xpath, QuoteList_Service_Option_Xpath);
            SendKeys(attributeName_id, QuoteList_Search_Box_Id, "LTL");
            Click(attributeName_xpath, QuoteList_SearchBox_DropdownArrow_Xpath);

            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Quotenumber = Gettext(attributeName_xpath, QuoteList_FirstRecord_QuoteNumber_xpath);
                Thread.Sleep(2000);

            }
            else
            {
                Report.WriteLine("No Records found for the LTL Quoted status for the logged in user so unable to test the scenario");
            }

            return Quotenumber;
        }


        [When(@"I expand the quote details of any quote in the Expired status (.*)")]
        public void WhenIExpandTheQuoteDetailsOfAnyQuoteInTheExpiredStatus(string UserType)
        {
            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Quotenumber = Gettext(attributeName_xpath, QuoteList_FirstRecord_QuoteNumber_xpath);
                Thread.Sleep(1000);
                if (UserType == ("ShipEntry") || (UserType == "ShipInquiry"))
                {
                    Click(attributeName_xpath, QuoteList_Expand_FirstRecord_Xpath);
                    Thread.Sleep(2000);
                }
                else if (UserType == ("Operation") || (UserType == "Sales") || UserType == ("SalesManagement") || (UserType == "StationOwner"))
                {
                    Click(attributeName_xpath, QuoteList_Internal_Expand_FirstRecord_Xpath);
                }

            }
            else
            {
                Report.WriteLine("No Records found for the LTL Quoted status for the logged in user so unable to test the scenario");
            }

           

        }



        [Then(@"I must be able to see the Submitted By Field (.*)")]
        public void ThenIMustBeAbleToSeeTheSubmittedByField(string SubmittedBy)
        {
            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Quotenumber = Gettext(attributeName_xpath, QuoteList_FirstRecord_QuoteNumber_xpath);
                Thread.Sleep(2000);
                string ii = Gettext(attributeName_xpath, QuoteDetails_SubmittedBy_Xpath);
                Verifytext(attributeName_xpath, QuoteDetails_SubmittedBy_Xpath, SubmittedBy);
            }
            else
            {
                Report.WriteLine("No Records found for the LTL Quoted status for the logged in user so unable to test the scenario");
            }
           
        }


        [Then(@"I must be able to see the orgin (.*) with (.*) label")]
        public void ThenIMustBeAbleToSeeTheOrginWithLabel(string OriginLOcationSection, string AddressZip)
        {
            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Quotenumber = Gettext(attributeName_xpath, QuoteList_FirstRecord_QuoteNumber_xpath);
                Thread.Sleep(2000);
                string Originadd = Gettext(attributeName_xpath, QuoteDetails_OriginLocation_xpath);
                Verifytext(attributeName_xpath, QuoteDetails_OriginLocation_xpath, OriginLOcationSection);

            }
            else
            {
                Report.WriteLine("No Records found for the LTL Quoted status for the logged in user so unable to test the scenario");
            }

        }

        [Then(@"I must be able to see the destination  (.*) with (.*) label")]
        public void ThenIMustBeAbleToSeeTheDestinationWithLabel(string DestinationSection, string AddressZip)
        {
            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Quotenumber = Gettext(attributeName_xpath, QuoteList_FirstRecord_QuoteNumber_xpath);
                Thread.Sleep(2000);
                Verifytext(attributeName_xpath, QuoteDetails_DestinationLocation_xpath, DestinationSection);
            }
            else
            {
                Report.WriteLine("No Records found for the LTL Quoted status for the logged in user so unable to test the scenario");
            }
           
          

        }

        

        [Then(@"I must be able to see the Dates (.*) with (.*) and (.*) label")]
        public void ThenIMustBeAbleToSeeTheDatesWithAndLabel(string DatesSection, string PickupDate, string DropOffDate)
        {
            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Quotenumber = Gettext(attributeName_xpath, QuoteList_FirstRecord_QuoteNumber_xpath);
                Thread.Sleep(2000);
                Verifytext(attributeName_xpath, QuoteDetails_Dates_xpath, DatesSection);
                string pick = Gettext(attributeName_xpath, QuoteDetails_PickUpDate_Label_xpath);
                Verifytext(attributeName_xpath, QuoteDetails_PickUpDate_Label_xpath, PickupDate);
                Verifytext(attributeName_xpath, QuoteDetails_DropOffDate_Label_xpath, DropOffDate);

            }
            else
            {
                Report.WriteLine("No Records found for the LTL Quoted status for the logged in user so unable to test the scenario");
            }
       }



        [Then(@"I must be able to see the (.*) with (.*), (.*), (.*), (.*), (.*), (.*), (.*) label")]
        public void ThenIMustBeAbleToSeeTheWithLabel(string FreightInformation, string Quantity, string Package, string Weight, string ItemDescription, string Classification, string NMFC, string HazardousMaterials)
        {
            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Quotenumber = Gettext(attributeName_xpath, QuoteList_FirstRecord_QuoteNumber_xpath);
                Thread.Sleep(2000);

                string FreightInfo = Gettext(attributeName_xpath, QuoteDetails_FreightInfo_xpath);
                if (FreightInfo.Contains("FREIGHT INFORMATION"))
                {
                    Report.WriteLine("Freight Information text exists in the QuoteDetails");
                }
                else
                {
                    Report.WriteLine("Freight Information does not exists in the QuoteDetails");
                    Assert.Fail();
                }


                Verifytext(attributeName_xpath, QuoteDetails_FreightInfo_Quantity_xpath, "Quantity");
                Verifytext(attributeName_xpath, QuoteDetails_FreightInfo_Package_xpath, "Package");
                Verifytext(attributeName_xpath, QuoteDetails_FreightInfo_Weight_xpath, "Weight");
                Verifytext(attributeName_xpath, QuoteDetails_FreightInfo_ItemDesc_xpath, "Item Description");
                Verifytext(attributeName_xpath, QuoteDetails_FreightInfo_Classification_xpath, "Classification");
                Verifytext(attributeName_xpath, QuoteDetails_FreightInfo_NMFC_xpath, "NMFC");
                Verifytext(attributeName_xpath, QuoteDetails_FreightInfo_HazardousMaterial_xpath, "Hazardous Materials");

            }
            else
            {
                Report.WriteLine("No Records found for the LTL Quoted status for the logged in user so unable to test the scenario");
            }

      }

       
        [Then(@"I can see AdditionalSevicesAccessorials  '(.*)'")]
        public void ThenICanSeeAdditionalSevicesAccessorials(string AdditionalServicesandAccessorials)
        {

            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Quotenumber = Gettext(attributeName_xpath, QuoteList_FirstRecord_QuoteNumber_xpath);
                Thread.Sleep(2000);
                Verifytext(attributeName_xpath, QuoteDetails_AdditionalServicesAndAccessorials_xpath, "ADDITIONAL SERVICES AND ACCESSORIALS");
            }
            else
            {
                Report.WriteLine("No Records found for the LTL Quoted status for the logged in user so unable to test the scenario");
            }
            
        }



        [Then(@"previously saved data should be displayed and match with the corresponding fields (.*)")]
        public void ThenPreviouslySavedDataShouldBeDisplayedAndMatchWithTheCorrespondingFields(string Username)
        {
            //
            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Quotenumber = Gettext(attributeName_xpath, QuoteList_FirstRecord_QuoteNumber_xpath);
                Thread.Sleep(2000);
            


            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> AllClaimDetails = IDP.GetUserClaimDetails(Username);
            List<string> setClaimDetails = AllClaimDetails.Where(c => c.ClaimType == "dlscrm-CustomerSetUpId").Select(a => a.ClaimValue).ToList();
            CustomerSetup value = DBHelper.GetSetupDetails(Convert.ToInt32(setClaimDetails.FirstOrDefault()));

            IExtractShipment extractShipment = new ExtractShipment();
            UploadTemplateViewModel uploadTemplate = new UploadTemplateViewModel()
            {
                PrimaryReferenceBol = Quotenumber
            };

            List<UploadTemplateViewModel> uploadTemplateViewModel = new List<UploadTemplateViewModel>();
            uploadTemplateViewModel.Add(uploadTemplate);

            IEnumerable<ShipmentExtractViewModel> shipmentDetails = extractShipment.ShipmentExtract(uploadTemplateViewModel, value.CustomerName, out errorMessage);

            ShipmentExtractViewModel model = shipmentDetails.ToList()[0];
            //Address Information for origin and destination
            string originCity = string.Empty;
            string originState = string.Empty;
            string originZipCode = string.Empty;
            string originCountry = string.Empty;
            string destinationCity = string.Empty;
            string destinationState = string.Empty;
            string destinationZipCode = string.Empty;
            string destinationCountry = string.Empty;
            if (model.AddressViewModels != null)
            {
                for (var i = 0; i < model.AddressViewModels.Count; i++)
                {
                    if (model.AddressViewModels[i].Type.ToLower() == "origin")
                    {
                        originCity = model.AddressViewModels[i].City;
                        originState = model.AddressViewModels[i].StateProvince;
                        originZipCode = model.AddressViewModels[i].PostalCode;
                        string citystatezip = Gettext(attributeName_xpath, ".//*[@class='rateList-originCityState']");
                        string[] ActualCityStateZip = citystatezip.Split(',');
                       // string ActualCityStateZip =  Regex.Replace(citystatezip, @"[^ .,]+", "");

                        string City = ActualCityStateZip[0];
                        string State = ActualCityStateZip[1].Trim();
                        string Zip = ActualCityStateZip[2].Trim();
                        Assert.AreEqual(originCity, City);
                        Assert.AreEqual(originState, State);
                        Assert.AreEqual(originZipCode, Zip);


                        originCountry = model.AddressViewModels[i].CountryCode;
                        string ActualOriginCountry = Gettext(attributeName_xpath, ".//*[@class='rateList-originCountry']");
                        if (originCountry == "USA")
                        {
                            Assert.AreEqual("United States", ActualOriginCountry);
                        }
                        else
                        {
                            Assert.AreEqual(originCountry.ToUpper(), ActualOriginCountry.ToUpper());
                        }
                        Report.WriteLine("Displaying Origin Country in UI " + ActualOriginCountry + "is matching with API value" + originCountry);

                    }

                    if (model.AddressViewModels[i].Type.ToLower() == "destination")
                    {
                        destinationCity = model.AddressViewModels[i].City;
                        destinationState = model.AddressViewModels[i].StateProvince;
                        destinationZipCode = model.AddressViewModels[i].PostalCode;

                        string citystatezip = Gettext(attributeName_xpath, ".//*[@class='rateList-destinationCityState']");
                        string[] ActualCityStateZip = citystatezip.Split(',');
                        
                        string City = ActualCityStateZip[0];
                        string State = ActualCityStateZip[1].Trim();
                        string Zip = ActualCityStateZip[2].Trim();
                        Assert.AreEqual(destinationCity, City);
                        Assert.AreEqual(destinationState, State);
                        Assert.AreEqual(destinationZipCode, Zip);



                        destinationCountry = model.AddressViewModels[i].CountryCode;
                        string ActualDestCountry = Gettext(attributeName_xpath, ".//*[@class='rateList-destinationCountry']");
                        if (destinationCountry == "USA")
                        {
                            Assert.AreEqual("United States", ActualDestCountry);
                        }
                        else
                        {
                            Assert.AreEqual(destinationCountry.ToUpper(), ActualDestCountry.ToUpper());
                        }
                        Report.WriteLine("Displaying destination country in UI " + ActualDestCountry + "is matching with API value" + destinationCountry);

                    }
                }
            }
            //Item information and ShipmentValue
            string quantity = string.Empty;
            string quantityUnit = string.Empty;
            string weight = string.Empty;
            string weightUnit = string.Empty;
            string ItemDesc = string.Empty;
            string Classification = string.Empty;
            string NMFC = string.Empty;
            //bool HazMaterial ;
            
            if (model.ItemViewModels != null && model.ItemViewModels.Count > 0)
            {
                for (var i = 0; i < model.ItemViewModels.Count; i++)
                {
                    quantity = model.ItemViewModels[i].Quantity;
                    string ActualQuantity = Gettext(attributeName_xpath, QuoteDetails_FreightInfo_Quantity_Value_xpath);
                    string data = quantity.Split('.')[i];

                    if (data == ActualQuantity)
                    {
                        //Assert.AreEqual(quantity, ActualQuantity);
                        Report.WriteLine("Displaying quantity in UI " + ActualQuantity + "is matching with API value" + quantity);

                        quantityUnit = model.ItemViewModels[i].QuantityUnitName;
                        string ActualQuantityUnit = Gettext(attributeName_xpath, QuoteDetails_FreightInfo_Package_Value_xpath);
                        Assert.AreEqual(quantityUnit, ActualQuantityUnit);
                        Report.WriteLine("Displaying quantity unit in UI " + ActualQuantityUnit + "is matching with API value" + quantityUnit);

                        weight = model.ItemViewModels[i].Weight;
                        string ActualWeight = Gettext(attributeName_xpath, QuoteDetails_FreightInfo_Weight_value_xpath);
                        Assert.AreEqual(weight.Split('.')[i], ActualWeight);
                        Report.WriteLine("Displaying weight in UI " + ActualWeight + "is matching with API value" + weight);

                        ItemDesc = model.ItemViewModels[i].ItemDescription;
                        string ActualItemDesc = Gettext(attributeName_xpath, QuoteDetails_FreightInfo_ItemDesc_value_xpath);
                            if (ItemDesc == "")
                            {
                                ItemDesc = "N/A";
                                
                                Assert.AreEqual(ItemDesc, ActualItemDesc);
                                Report.WriteLine("Displaying weight in UI " + ActualItemDesc + "is matching with API value" + ItemDesc);

                            }
                            else
                            {
                                Assert.AreEqual(ItemDesc, ActualItemDesc);
                                Report.WriteLine("Displaying weight in UI " + ActualItemDesc + "is matching with API value" + ItemDesc);

                            }



                        Classification = model.ItemViewModels[i].Classification;
                        string ActualClassification = Gettext(attributeName_xpath, QuoteDetails_FreightInfo_Classification_value_xpath);
                        Assert.AreEqual(Classification, ActualClassification);
                        Report.WriteLine("Displaying insured value in UI " + ActualClassification + "is matching with API value" + Classification);

                        NMFC = model.ItemViewModels[i].NmfcCode;
                        string ActualNMFC = Gettext(attributeName_xpath, QuoteDetails_FreightInfo_NMFC_value_xpath);
                        if (NMFC == "")
                        {
                                NMFC = "N/A";
                                Assert.AreEqual(NMFC, ActualNMFC);
                                Report.WriteLine("Displaying insured value in UI " + ActualNMFC + "is matching with API value" + NMFC);
                          }
                         else
                            {
                                Assert.AreEqual(NMFC, ActualNMFC);
                                Report.WriteLine("Displaying insured value in UI " + ActualNMFC + "is matching with API value" + NMFC);
                            }
                        
                        

                        //HazMaterial = model.ItemViewModels[i].IsHazardous;
                        //string ActualHazMaterial = Gettext(attributeName_xpath, QuoteDetails_FreightInfo_HazardousMaterial_value_xpath);
                        //Assert.AreEqual(HazMaterial, ActualHazMaterial);
                        //Report.WriteLine("Displaying insured value in UI " + ActualHazMaterial + "is matching with API value" + HazMaterial);

                        break;
                    }
                    else
                    {
                        Report.WriteLine("Item values displaying in UI is not matching with API value");
                        Assert.IsTrue(false);
                    }
                }
            }


            } 
            else
            {
                Report.WriteLine("No Records found for the LTL Quoted status for the logged in user so unable to test the scenario");
            }


        }



        [Then(@"User should be able to see the Print and (.*) button")]
        public void ThenUserShouldBeAbleToSeeThePrintAndButton(string CreateShipment)
        {
            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Quotenumber = Gettext(attributeName_xpath, QuoteList_FirstRecord_QuoteNumber_xpath);
                Thread.Sleep(2000);
                VerifyElementPresent(attributeName_id, QuoteDetails_PrintButton_id, "PrintButton");
                VerifyElementPresent(attributeName_id, QuoteDetails_CreateShipmentButton_Id, "CreateShipment");

            }
            else
            {
                Report.WriteLine("No Records found for the LTL Quoted status for the logged in user so unable to test the scenario");
            }
         }

        [Then(@"User must be able to see the Print and (.*) button")]
        public void ThenUserMustBeAbleToSeeThePrintAndButton(string Requote)
        {
            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Quotenumber = Gettext(attributeName_xpath, QuoteList_FirstRecord_QuoteNumber_xpath);
                VerifyElementPresent(attributeName_id, QuoteDetails_PrintButton_id, "PrintButton");
                VerifyElementPresent(attributeName_id, QuoteDetails_RequoteButton_id, "Requote");
                Thread.Sleep(2000);
            }
            else
            {
                Report.WriteLine("No Records found for the LTL Quoted status for the logged in user so unable to test the scenario");
            }
         }



    }
}
