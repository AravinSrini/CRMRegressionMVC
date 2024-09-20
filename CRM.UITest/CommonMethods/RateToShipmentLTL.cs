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
using System.Threading.Tasks;

namespace CRM.UITest.CommonMethods
{
    public class RateToShipmentLTL : AddShipments
    {
        public void NaviagteToQuoteList()
            
        {
            
            Click(attributeName_xpath, QuoteModule_Xpath);//try
            //{
            //    Click(attributeName_xpath, QuoteModule_Xpath);

            //}
            //catch (Exception)
            //{
            //    Thread.Sleep(50000);
            //    Console.WriteLine("error occurred");
            //}
        }

        public void SelectCustomerFrom_QuotetList(string UserType, string CustomerName)
        {
            Report.WriteLine("Click on Submit Rate request button");
            if (UserType == "Internal")
            {
                Report.WriteLine("Select Customer Name from the dropdown list");
                Click(attributeName_xpath, ".//*[@id='CategoryType_chosen']/a/span");

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CategoryType_chosen']/div/ul/li"));
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
                try
                {
                    Click(attributeName_id, SubmitRateRequestButton_Id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Thread.Sleep(80000);
                }
            }
            else
            {
                Thread.Sleep(500);
                Click(attributeName_id, SubmitRateRequestButton_Id);
            }
            WaitForElementVisible(attributeName_id, LTL_TileLabel_Id, "LTL Tile");
            Click(attributeName_id, LTL_TileLabel_Id);
        }

        public void _selectingCustomerNameonly_Quotelist(string UserType, string CustomerName)
        {
            Report.WriteLine("Click on Submit Rate request button");
            if (UserType == "Internal")
            {
                Report.WriteLine("Select Customer Name from the dropdown list");
                Click(attributeName_xpath, ".//*[@id='CategoryType_chosen']/a/span");

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CategoryType_chosen']/div/ul/li"));
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

            }
        }

        public void ClickOnOriginSavedAddressDropdown_Quote()
        {
            Report.WriteLine("Clicking on origin address dropdown");
            Thread.Sleep(2000);
            string _selectedAddress = GetValue(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                //Click(attributeName_id, ClearAddress_OriginId);
                Thread.Sleep(4000);
            }

            Click(attributeName_xpath, LTL_ShipinformationPage_ShippingFrom_Xpath);
            Click(attributeName_id, LTL_SavedOriginAddressDropdown_Id);
        }

        public void SearchByNameInTheOriginSavedAddressField_Quote(string oname)
        {
            Report.WriteLine("Entering a search criteria in origin address dropdown");
            Thread.Sleep(2000);
            SendKeys(attributeName_id, LTL_SavedOriginAddressDropdown_Id, oname);
        }


        public void SelectFirstAddressFromTheOriginSavedAddressDropdown_Quote()
        {
            Report.WriteLine("Selecting address from origin saved address dropdown");
            Thread.Sleep(3000);
            Click(attributeName_xpath, FirstSavedOriginAddress);
        }

        public void selectingOriginServiceAndAccessorial_Quote(string Accessorial)
        {
            Report.WriteLine("selecting Origin Service and Accessorial");
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath, Accessorial);
            Thread.Sleep(1000);
        }

        public void selectingDestinationServiceAndAccessorial_Quote(string Accessorial)
        {
            Report.WriteLine("selecting Origin Service and Accessorial");
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Xpath);
            Click(attributeName_xpath, ".//*[@id='servicesaccessorialsto_chosen']/div/ul/li[2]");
            Thread.Sleep(1000);
        }
        public void ClickOnDestinationSavedAddressDropdown_Quote()
        {
            Report.WriteLine("Clicking on destination address dropdown");
            Thread.Sleep(2000);
            string _selectedAddress = GetValue(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                //Click(attributeName_id, ClearAddress_DestId);
                Thread.Sleep(3000);
            }
            Click(attributeName_xpath, LTL_ShipinformationPage_ShippingTo_Xpath);
            Click(attributeName_id, LTL_SavedDestinationAddressDropdown_Id);

        }

        public void SearchByNameInTheDestinationSavedAddressField_Quote(string dname)
        {
            Report.WriteLine("Entering a search criteria in destination address dropdown");
            Thread.Sleep(2000);
            SendKeys(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, dname);
            Thread.Sleep(2000);
        }

        public void SelectFirstAddressFromTheDestinationSavedAddressDropdown_Quote()
        {
            Report.WriteLine("Selecting address from destination saved address dropdown");
            Click(attributeName_xpath, FirstSavedDestinationAddress);
            Thread.Sleep(2000);
        }

        public void addItem_Quote(string Item, string Quantity, string weight)
        {
            scrollElementIntoView(attributeName_id, LTL_Quantity_Id);

            Report.WriteLine("Selecting address from destination saved address dropdown");
            Click(attributeName_xpath, ClassorSavedItemField_xpath);
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Select_saveditem_0_chosen']/div/ul/li"));
            for (int i = 1; i <= dropdownValues.Count; i++)
            {

                string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='Select_saveditem_0_chosen']/div/ul/li[" + i + "]")).Text;



                if (value.ToUpper().Contains(Item.ToUpper()))
                {
                    var _value = value.Remove(0, value.IndexOf(' ') + 1).ToUpper();
                    if (_value == Item.ToUpper())
                    {
                        scrollElementIntoView(attributeName_xpath, ".//*[@id='Select_saveditem_0_chosen']/div/ul/li[" + i + "]");
                        GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='Select_saveditem_0_chosen']/div/ul/li[" + i + "]")).Click();
                        break;
                    }

                }
            }
            Thread.Sleep(2000);
        }

        public void addAdditionalItem1_Quote(string Item1, string Quantity, string weight)
        {
            scrollElementIntoView(attributeName_xpath, AddAdditionalItemBtm_xpath);
            Click(attributeName_xpath, AddAdditionalItemBtm_xpath);
            Thread.Sleep(1000);
            Click(attributeName_xpath, ".//*[@id='Select_saveditem_1_chosen']/a/span");
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Select_saveditem_0_chosen']/div/ul/li"));
            for (int i = 1; i <= dropdownValues.Count; i++)
            {

                string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='Select_saveditem_1_chosen']/div/ul/li[" + i + "]")).Text;



                if (value.ToUpper().Contains(Item1.ToUpper()))
                {
                    var _value = value.Remove(0, value.IndexOf(' ') + 1).ToUpper();
                    if (_value == Item1.ToUpper())
                    {
                        scrollElementIntoView(attributeName_xpath, ".//*[@id='Select_saveditem_1_chosen']/div/ul/li[" + i + "]");
                        GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='Select_saveditem_1_chosen']/div/ul/li[" + i + "]")).Click();
                        break;
                    }

                }
            }
        }

        public void EnterDataInInsuredField_Quote(string Insuredvalue)
        {
            Report.WriteLine("Entering data in Enter Insured value text box");
            MoveToElement(attributeName_id, LTL_EnterInsuredValue_Id);
            SendKeys(attributeName_id, LTL_EnterInsuredValue_Id, Insuredvalue);
            Thread.Sleep(1000);
        }

        public void EnterInsuredValueAndType_Quote(string Insuredvalue, string Type)
        {
            Report.WriteLine("Entering data in Enter Insured value text box");
            SendKeys(attributeName_id, LTL_EnterInsuredValue_Id, Insuredvalue);
            Thread.Sleep(1000);
            Click(attributeName_xpath, ".//*[@id='Insvalue_chosen']/a/span");
            SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='Insvalue_chosen']/div/ul/li", Type);
            Thread.Sleep(1000);
        }

        public void SelectingDate_Quote(string Date)
        {
            Click(attributeName_id, Pickupdate_id);
            int ConvertedDay = Convert.ToInt32(Date);
            DatePickerFromCalander(attributeName_xpath, "html/body/div[8]/div[1]/table/tbody/tr/td", ConvertedDay, "html/body/div[8]/div[1]/table/thead/tr[1]/th[3]/i");
            Thread.Sleep(1000);
        }

        public void ClickOnViewQuoteResultsButton_Quote()
        {
            Report.WriteLine("Click on Quote Results");
            
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
            //try
            //{
            //    Click(attributeName_id, LTL_ViewQuoteResults_Id);
            //    Thread.Sleep(185000);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}
            //Thread.Sleep(2500);
            WaitForElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "waitforheader");

        }

        public void ClickOnCreateShipmentbutton_Quote(string Usertype)
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");
                Report.WriteLine("Create shipment for selected carrier");
                switch (Usertype)
                {
                    case "External":
                        WaitForElementVisible(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/button", "Create Shipment");
                        Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/button");
                        break;

                    case "Internal":
                        WaitForElementVisible(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/button", "Create Shipment");
                        Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/button");
                        break;
                }
                Thread.Sleep(23000);
                
            }
            else
            {
                Report.WriteLine("No Rates Available and hence unable to navigate to Add Shipment(LTL) page");
            }

        }

        public void ClickOnCreateInsuredShipmentbutton_Quote(string Usertype)
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");
                Report.WriteLine("Create shipment for selected carrier");
                switch (Usertype)
                {
                    case "External":
                        Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/button");
                        break;

                    case "Internal":
                        Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[6]/button");
                        break;
                }
                Thread.Sleep(22000);
                
            }
            else
            {
                Report.WriteLine("No Rates Available and hence unable to navigate to Add Shipment(LTL) page");
            }
        }
        public void ShpFromAddressFields_Quote(string ocity, string ostate, string ozip)
        {
            string _selectedAddress = GetValue(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_OriginId);
                Thread.Sleep(4000);
            }
            SendKeys(attributeName_id, LTL_OriginCity_Id, ocity);
            Thread.Sleep(500);
            Report.WriteLine("Selecting Origin State from Origin State dropdown");
            Click(attributeName_id, LTL_OriginStateProvince_Id);
            SelectDropdownValueFromList(attributeName_xpath, LTL_OriginStateProvinceValues_Xpath, ostate);
            Thread.Sleep(500);
            SendKeys(attributeName_id, LTL_OriginZipPostal_Id, ozip);
            Thread.Sleep(2000);
            Click(attributeName_xpath, LTL_ShipinformationPage_ShippingFrom_Xpath);
        }

        public void ShpToAddressFields_Quote(string dcity, string dstate, string dzip)
        {
            string _selectedAddress = GetValue(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_DestId);
                Thread.Sleep(3000);
            }
            SendKeys(attributeName_id, LTL_DestinationCity_Id, dcity);
            Thread.Sleep(500);
            Report.WriteLine("Selecting Destination State from Destination State dropdown");
            Click(attributeName_id, LTL_DestinationStateProvince_Id);
            SelectDropdownValueFromList(attributeName_xpath, LTL_DestinationStateProvinceValues_Xpath, dstate);
            Thread.Sleep(500);
            SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, dzip);
            Thread.Sleep(2000);
            Click(attributeName_xpath, LTL_ShipinformationPage_ShippingTo_Xpath);
        }

        public void Enter_Name_Address1_ShpFromSection_Shipment(string oname, string oadd1)
        {
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, oname);
            Thread.Sleep(100);
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, oadd1);
            Thread.Sleep(100);
        }

        public void Enter_Name_Address1_ShpToSection_Shipment(string dname, string dadd1)
        {
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, dname);
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, dadd1);
        }

        public void Enter_NMFC_Shipment(string nmfc)
        {
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Thread.Sleep(500);
            SendKeys(attributeName_id, FreightDesp_FirstItem_NMFC_Id, nmfc);
        }
        
        public void Get_CreateShipmentAndInsShipmentButton_Count_For_StandardRates(string UserType)
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                switch(UserType)
                {
                    case "External":
                        {
                            List<string> btn = new List<string>();
                            IList<IWebElement> StndCarrier = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]"));
                            IList<IWebElement> StndCreateShpbtn = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[4]/button"));
                            IList<IWebElement> StndInsuredShpbtn = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[5]/button"));
                            Report.WriteLine("Verifying Create Shipment button for Standard Rates");
                            Assert.AreEqual(StndCarrier.Count, StndCreateShpbtn.Count);
                            Assert.AreEqual(StndCarrier.Count, StndInsuredShpbtn.Count);
                            break;
                        }

                    case "Internal":
                        {
                            List<string> btn = new List<string>();
                            IList<IWebElement> StndCarrier = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[1]"));
                            IList<IWebElement> StndCreateShpbtn = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[5]/button"));
                            IList<IWebElement> StndInsuredShpbtn = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr/td[6]/button"));
                            Report.WriteLine("Verifying Create Shipment button for Standard Rates");
                            Assert.AreEqual(StndCarrier.Count, StndCreateShpbtn.Count);
                            Assert.AreEqual(StndCarrier.Count, StndInsuredShpbtn.Count);
                            break;
                        }
                }
                

            }
        }


        public void Get_CreateShipmentAndInsShipmentButton_Count_GauranteedRates(string UserType)
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                bool GauranteedCarrierSection = IsElementVisible(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[1]", "Gauranteed Carriers section");
                scrollElementIntoView(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[1]");
                if (GauranteedCarrierSection)
                {

                    switch (UserType)
                    {
                        case "External":
                            {
                                bool Gauranteed_FirstStandardRate = IsElementVisible(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[4]/ul[1]/li[1]", "Gauranteed Standard rate ");
                                if (Gauranteed_FirstStandardRate)
                                {
                                    IList<IWebElement> Gauranteed_Carrier = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[1]"));
                                    IList<IWebElement> Gauranteed_Stnd_ShipmentButton = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[4]/button"));
                                    IList<IWebElement> Gauranteed_Ins_ShipmentButton = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[5]/button"));
                                    Assert.AreEqual(Gauranteed_Carrier.Count, Gauranteed_Stnd_ShipmentButton.Count);
                                    Assert.AreEqual(Gauranteed_Carrier.Count, Gauranteed_Ins_ShipmentButton.Count);
                                }
                                else
                                {
                                    Report.WriteLine("No Gauranteed Carriers Available");
                                }
                                break;
                            }

                        case "Internal":
                            {
                                bool Gauranteed_FirstInsRate = IsElementVisible(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr[1]/td[5]/ul[1]/li[1]", "Gauranteed Ins Rate ");
                                if (Gauranteed_FirstInsRate)
                                {   
                                    IList<IWebElement> GauranteedCarrier = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[1]"));
                                    IList<IWebElement> GauranteedStndCreateShpbtn = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[5]/button"));
                                    IList<IWebElement> GauranteedInsCreateShpbtn = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Grid-Rate-List-Large-Guranteed']/tbody/tr/td[6]/button"));
                                    Report.WriteLine("Verifying Create Shipment button for Standard Rates");
                                    Assert.AreEqual(GauranteedCarrier.Count, GauranteedStndCreateShpbtn.Count);
                                    Assert.AreEqual(GauranteedCarrier.Count, GauranteedInsCreateShpbtn.Count);
                                }
                                break;
                            }
                    }

                }
                else
                {
                    Report.WriteLine("No Gauranteed Carriers Available");
                }
            }
        }

    }
}
