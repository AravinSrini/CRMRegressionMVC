using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
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
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class LiabilityCoverage_VerbiageChange : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();
        
        [Given(@"I am a shp\.entry, operations, sales, sales management or station user")]
        public void GivenIAmAShp_EntryOperationsSalesSalesManagementOrStationUser()
        {

            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);

        }


        [Given(@"I enter data in add shipment ltl page (.*), (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnterDataInAddShipmentLtlPage(string Usertype,
            string CustomerName,
            string originName,
            string originAddr1,
            string originZipcode,
            string destinationName,
            string destinationAddr1,
            string destinationZipcode,
            string Classification,
            string nmfc,
            string quantity,
            string weight,
            string itemdesc)
        {
            
            ltl.NaviagteToShipmentList();
            ltl.SelectCustomerFromShipmentList(Usertype, CustomerName);
            ltl.AddShipmentOriginData(originName, originAddr1, originZipcode);
            ltl.AddShipmentDestinationData(destinationName, destinationAddr1, destinationZipcode);
            //scrollElementIntoView(attributeName_xpath, FreightDesp_SectionText_xpath);
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            ltl.AddShipmentFreightDescription(Classification, nmfc, quantity, weight, itemdesc);
        }


        [Then(@"the new verbiage Carrier’s Legal Liability per Pound without Insurance and Carrier’s Max Liability if Shipment is Not Insured fields should be displayed for carrier")]
        public void ThenTheNewVerbiageCarrierSLegalLiabilityPerPoundWithoutInsuranceAndCarrierSMaxLiabilityIfShipmentIsNotInsuredFieldsShouldBeDisplayedForCarrier()
        {
            IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
            for (int i = 1; i <= row.Count; i++)
            {
                string verCarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td");
                if (verCarrierName != "There are no rates available for this shipment.")
                {
                    string CarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");

                    InsuredRateCarrier value = DBHelper.insuredCarrier(CarrierName);

                    if (value != null)
                    {
                        bool d = IsElementPresent(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]/img", "CarrierImage");
                        if (d)
                        {
                            Verifytext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[3]/label", "Carrier’s Legal Liability per Pound without Insurance");
                            Verifytext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[4]/label", "Carrier’s Max Liability if Shipment is Not Insured");

                        }
                        else
                        {
                            Verifytext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[2]/label", "Carrier’s Legal Liability per Pound without Insurance");
                            Verifytext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div[3]/label", "Carrier’s Max Liability if Shipment is Not Insured");
                        }
                        break;
                    }
                    else
                    {
                        Report.WriteLine("Carrier is not associated with the Carrier Rate Setting");
                    }
                }
                else
                {
                    Report.WriteLine(" No Rates found on the Shipment Results page");
                }
            }
        }




        [Given(@"I enter value in Insured Value (.*)")]
        public void GivenIEnterValueInInsuredValue(string InsuredValue)
        {
            //scrollpagedown();
            //scrollpagedown();
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, InsuredValue);
        }

        [Given(@"I select the Insured Type from  (.*) drop down")]
        public void GivenISelectTheInsuredTypeFromDropDown(string InsuredType)
        {
            string typeSelection = Gettext(attributeName_xpath, InsuredValue_Type_xpath);
            if (typeSelection != InsuredType)
            {
                Click(attributeName_xpath, InsuredValue_Type_xpath);
                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(InsuredValue_Type_Values_xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == InsuredType)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }

            }
        }


        [Then(@"the new verbiage Carrier’s Legal Liability per Pound without Insurance and Carrier’s Max Liability if Shipment is Not Insured fields should be displayed for carrier for Guaranteed Rates")]
        public void ThenTheNewVerbiageCarrierSLegalLiabilityPerPoundWithoutInsuranceAndCarrierSMaxLiabilityIfShipmentIsNotInsuredFieldsShouldBeDisplayedForCarrierForGuaranteedRates()
        {
            IList<IWebElement> row = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr"));
            for (int i = 1; i <= row.Count; i++)
            {
                string verCarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td");
                if (verCarrierName != "There are no rates available for this shipment.")
                {
                    string CarrierName = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + i + "]/td[1]/div/div");
                    InsuredRateCarrier value = DBHelper.insuredCarrier(CarrierName);

                    if (value != null)
                    {
                        GuaranteedCarrier value1 = DBHelper.guaranteedCarrier(CarrierName);
                        string gCarrierName = value1.CarrierName;

                        if (value1 != null)
                        {

                            scrollElementIntoView(attributeName_xpath, ShipResults_GuaranteedColumnHeader_CARRIER_Xpath);
                            IList<IWebElement> guaranteedRatesRow = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='GuaranteedResultTable']/tbody/tr"));
                            for (int j = 1; j <= row.Count; j++)
                            {
                                string guaranteedCarrierName = Gettext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[1]/div/div[1]");
                                if (guaranteedCarrierName == gCarrierName)
                                {
                                    bool d = IsElementPresent(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[1]/div/div[2]/img", "CarrierImage");
                                    if (d)
                                    {

                                        Verifytext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[1]/div/div[3]/label", "Carrier’s Legal Liability per Pound without Insurance");
                                        Verifytext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[1]/div/div[4]/label", "Carrier’s Max Liability if Shipment is Not Insured");
                                    }
                                    else
                                    {

                                        Verifytext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[1]/div/div[2]/label", "Carrier’s Legal Liability per Pound without Insurance");
                                        Verifytext(attributeName_xpath, ".//*[@id='GuaranteedResultTable']/tbody/tr[" + j + "]/td[1]/div/div[3]/label", "Carrier’s Max Liability if Shipment is Not Insured");

                                    }
                                    break;

                                }
                            }
                            break;

                        }
                        else
                        {
                            Report.WriteLine("Carrier is not associated with the Guaranteed Rates Carrier Rate ");
                        }
                    }

                    else
                    {
                        Report.WriteLine("Carrier is not associated with the Carrier Rate Setting");
                    }
                }
                else
                {
                    Report.WriteLine(" No Rates found on the Shipment Results page");
                }
            }

        }
    }
}
