using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.CommonMethods
{
    [Binding]
    public class ClaimDetailsPage : InsuranceClaim
    {
        public void ClaimHeader(string DLSW_ClaimRep, string stationname, string DLSW_Ref, string claimant, string claimReason, string carrierName, string carrierPRO, string insured)
        {
            //Claim Header - DLSW ClaimRep
            Click(attributeName_xpath, DlswClaimRep_dropdown_ClaimDetailsPage_Xpath);
            IList<IWebElement> dlswClaimRep_pDownList = GlobalVariables.webDriver.FindElements(By.XPath(DlswClaimRep_DropdownValues_ClaimDetailsPage_Xpath));
            for (int i = 0; i < dlswClaimRep_pDownList.Count; i++)
            {
                if (dlswClaimRep_pDownList[i].Text == DLSW_ClaimRep)
                {
                    dlswClaimRep_pDownList[i].Click();
                    break;
                }
                

            }

            //Claim Header - Station
            Click(attributeName_xpath, Station_Dropdown_ClaimDetailsPage_Xpath);
            IList<IWebElement> stationDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(Station_DropdownValues_ClaimDetailsPage_Xpath));
            for (int i = 0; i < stationDropDownList.Count; i++)
            {
                if (stationDropDownList[i].Text == stationname)
                {
                    stationDropDownList[i].Click();
                    break;
                }

            }

            //Claim Header - DLSW Ref #
            SendKeys(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, DLSW_Ref);

            //Claim Header -Claimant
            SendKeys(attributeName_id, Claimant_Textbox_ClaimDetailsPage_Id, claimant);

            //Claim Header - Claim Reason
            Click(attributeName_xpath, ClaimReason_Dropdown_ClaimDetailsPage_Xpath);
            IList<IWebElement> claimReasonDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ClaimReason_DropdownValues_ClaimDetailsPage_Xpath));
            for (int i = 0; i < claimReasonDropDownList.Count; i++)
            {
                if (claimReasonDropDownList[i].Text == claimReason)
                {
                    claimReasonDropDownList[i].Click();
                    break;
                }

            }

            //Claim Header - Carrier Name
            Click(attributeName_xpath, CarrierName_Dropdown_ClaimDetailsPage_Xpath);
            IList<IWebElement> carrierNameDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(CarrierName_DropdownValues_ClaimDetailsPage_Xpath));
            for (int i = 0; i < carrierNameDropDownList.Count; i++)
            {
                if (carrierNameDropDownList[i].Text == carrierName)
                {
                    carrierNameDropDownList[i].Click();
                    break;
                }

            }

            //Claim Header - Carrier PRO #
            SendKeys(attributeName_id, CarrierPro_Textbox_ClaimDetailsPage_Id, carrierPRO);

            //Claim Header - Insured
            Click(attributeName_xpath, Insured_Dropdown_ClaimDetailsPage_Xpath);
            IList<IWebElement> InsuredDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(Insured_DropdownValues_ClaimDetailsPage_Xpath));
            for (int i = 0; i < InsuredDropDownList.Count; i++)
            {
                if (InsuredDropDownList[i].Text == insured)
                {
                    InsuredDropDownList[i].Click();
                    break;
                }

            }

        }

        public void FTL_SpecificFields(string carrierMC, string sealIntact, string seal, string vehicle)
        {
            //FTL-Specific Fields - Carrier MC #
            SendKeys(attributeName_id, Carrier_MC_Id, carrierMC);

            //FTL-Specific Fields - Seal Intact
            Click(attributeName_xpath, SealIntact_Xpath);
            IList<IWebElement> SealIntactDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(SealIntactValues_Xpath));
            for (int i = 0; i < SealIntactDropDownList.Count; i++)
            {
                if (SealIntactDropDownList[i].Text == sealIntact)
                {
                    SealIntactDropDownList[i].Click();
                    break;
                }

            }

            //FTL-Specific Fields - Seal #
            SendKeys(attributeName_id, Seal_Number_Id, seal);

            //FTL-Specific Fields - Vehicle #
            SendKeys(attributeName_id, VehicleNumber_Id, vehicle);

        }

        public void ForwardingTab (string airline, string pickupCarrier, string deliveryCarrier, string steamshipLine, string freightForwarder, string whiteGloveAgent)
        {
            //Forwarding-Specific Fields - Airline
            Click(attributeName_xpath, airlineDropdown_Xpath);
            IList<IWebElement> airlineDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(airline_values_Xpath));
            for (int i = 0; i < airlineDropDownList.Count; i++)
            {
                if (airlineDropDownList[i].Text == airline)
                {
                    airlineDropDownList[i].Click();
                    break;
                }

            }

            //Forwarding - Specific Fields - Pickup Carrier
            Click(attributeName_id, pickupCarrier_Id);
            IList<IWebElement> pickupCarrierDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(pickupCarrier_values_Xpath));
            for (int i = 0; i < pickupCarrierDropDownList.Count; i++)
            {
                if (pickupCarrierDropDownList[i].Text == pickupCarrier)
                {
                    pickupCarrierDropDownList[i].Click();
                    break;
                }

            }

            //Forwarding - Specific Fields - Delivery Carrier
            Click(attributeName_xpath, deliveryCarrierDropdown_Xpath);
            IList<IWebElement> deliveryCarrierDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(deliveryCarrier_values_Xpath));
            for (int i = 0; i < deliveryCarrierDropDownList.Count; i++)
            {
                if (deliveryCarrierDropDownList[i].Text == deliveryCarrier)
                {
                    deliveryCarrierDropDownList[i].Click();
                    break;
                }

            }

            //Forwarding - Specific Fields - Steamship Line
            Click(attributeName_xpath, steamShipLineDropdown_Xpath);
            IList<IWebElement> steamShipLineDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(steamShipLine_values_Xpath));
            for (int i = 0; i < steamShipLineDropDownList.Count; i++)
            {
                if (steamShipLineDropDownList[i].Text == steamshipLine)
                {
                    steamShipLineDropDownList[i].Click();
                    break;
                }

            }


            //Forwarding - Specific Fields - Freight Forwarder
            Click(attributeName_xpath, freightForwarderDropdown_Xpath);
            IList<IWebElement> freightForwarderDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(freightForwarder_values_Xpath));
            for (int i = 0; i < freightForwarderDropDownList.Count; i++)
            {
                if (freightForwarderDropDownList[i].Text == freightForwarder)
                {
                    freightForwarderDropDownList[i].Click();
                    break;
                }

            }

            //Forwarding - Specific Fields - White Glove Agent
            Click(attributeName_xpath, whiteGloveAgentDropdown_Xpath);
            IList<IWebElement> whiteGloveAgentDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(whiteGloveAgent_values_Xpath));
            for (int i = 0; i < whiteGloveAgentDropDownList.Count; i++)
            {
                if (whiteGloveAgentDropDownList[i].Text == whiteGloveAgent)
                {
                    whiteGloveAgentDropDownList[i].Click();
                    break;
                }

            }
            
        }

        public void Shipper (string name, string address, string zip, string city, string country, string state, string dateAcktoClaimant, string dateFiledw_carrier, string program, string amount, string company)
        {

            GlobalVariables.webDriver.WaitForPageLoad();
            //Shipper - Name, Address, City, State, Zip,Country

            Click(attributeName_xpath, DetaislTab_Edit_Shipper_Country_Click_Xpath);
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Country_Value_Enter_Xpath, country);
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Country_EnterValue_Click_Xpath);

            Click(attributeName_xpath, DetailsTab_Edit_Shipper_State_Province_Click_Xpath);
            SendKeys(attributeName_xpath, ".//*[@id='State_chosen']/div/div/input", state);
            Click(attributeName_xpath, ".//*[@id='State_chosen']//ul/li[1]/em");

            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath, name);
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Address_Xpath, address);
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, zip);
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_City_Xpath, city);

            DefineTimeOut(5000);

            //DLSW OS & D Actions - Date Ack to Claimant
            Click(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, Keys.Backspace);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, dateAcktoClaimant);
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath);


            //DLSW OS & D Actions - Date Filed with Carrier
            Click(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id, Keys.Backspace);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id, dateFiledw_carrier);
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath);

            //Insurance Info - Program
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Program_Click_Xpath);
            IList<IWebElement> ProgramDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(DetailsTab_Edit_Shipper_Program_ListAll_Xpath));
            for (int i = 0; i < ProgramDropDownList.Count; i++)
            {
                if (ProgramDropDownList[i].Text == program)
                {
                    ProgramDropDownList[i].Click();
                    break;
                }

            }
           
            //Insurance Info -Amount
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_Amount_Id, amount);

            //Insurance Info -Company
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Company_Click_Xpath);
            IList<IWebElement> CompanyDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(DetailsTab_Edit_Shipper_Company_ListAll_Xpath));
            for (int i = 0; i < CompanyDropDownList.Count; i++)
            {
                if (CompanyDropDownList[i].Text == company)
                {
                    CompanyDropDownList[i].Click();
                    break;
                }

            }
        }

        public void Consignee(string name, string address, string zip, string city, string country, string state, string carrierAck, string carrierAckDate, string carrierClaim, string carrierPRODate, string bolShipDate, string deliveryDate, string remarks)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            //Consignee - Name, Address, City, State, Zip,Country
            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, name);
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, address);
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, zip);
            SendKeys(attributeName_id, Consignee_City_Textbox_Id, city);

            Click(attributeName_xpath, Consignee_Country_Xpath);
            SendKeys(attributeName_xpath, Consignee_Country_Textbox_Xpath, country);
            Click(attributeName_xpath, Consignee_Country_SelectingFirstHighlighted_Xpath);
            

            Click(attributeName_xpath, Consignee_StateDropdown_Xpath);
            SendKeys(attributeName_xpath, Consignee_State_Textbox_Xpath, state);
            Click(attributeName_xpath, Consingee_State_SelectingFirstHighlighted_Click_Xpath);
          

            //Carrier OS & D Actions - Carrier Ack
            Click(attributeName_xpath, CarrierOSDActions_CarrierAck_Xpath);
            IList<IWebElement> CarrierOSDActionsDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(CarrierOSDActions_CarrierAckValues_Xpath));
            for (int i = 0; i < CarrierOSDActionsDropDownList.Count; i++)
            {
                if (CarrierOSDActionsDropDownList[i].Text == carrierAck)
                {
                    CarrierOSDActionsDropDownList[i].Click();
                    break;
                }

            }

            //Carrier OS & D Actions - Carrier Ack Date
            Click(attributeName_id, CarrierOSDActions_CarrierAckDate_Id);
            SendKeys(attributeName_id, CarrierOSDActions_CarrierAckDate_Id, Keys.Backspace);
            SendKeys(attributeName_id, CarrierOSDActions_CarrierAckDate_Id, carrierAckDate);
            Click(attributeName_id, Consignee_Name_Textbox_Id);

            //Carrier OS&D Actions - Carrier Claim #
            SendKeys(attributeName_id, CarrierOSDActions_CarrierClaimNumber_Id, carrierClaim);

            //Key Dates - Carrier PRO Date
            Click(attributeName_id, KeyDates_CarrierProDate_Id);
            SendKeys(attributeName_id, KeyDates_CarrierProDate_Id, Keys.Backspace);
            SendKeys(attributeName_id, KeyDates_CarrierProDate_Id, carrierPRODate);
            Click(attributeName_id, Consignee_Name_Textbox_Id);

            //Key Dates -BOL / Ship Date
            Click(attributeName_id, KeyDates_BOLDate_Id);
            SendKeys(attributeName_id, KeyDates_BOLDate_Id, Keys.Backspace);
            SendKeys(attributeName_id, KeyDates_BOLDate_Id, bolShipDate);
            Click(attributeName_id, Consignee_Name_Textbox_Id);

            //Key Dates - Delivery Date
            Click(attributeName_id, KeyDates_DeliveryDate_Id);
            SendKeys(attributeName_id, KeyDates_DeliveryDate_Id, Keys.Backspace);
            SendKeys(attributeName_id, KeyDates_DeliveryDate_Id, deliveryDate);
            Click(attributeName_id, Consignee_Name_Textbox_Id);

            //Remarks
            SendKeys(attributeName_id, Remarks_Id, remarks);
        }

        public void ProductClaimed (string clmType, string artType, string qty, string item, string desc, string unitWT, string unitValue, string totalShipmentWeight)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            //Products Claimed -Clm Type
            Click(attributeName_xpath, FirstClaimType_xpath);
            IList<IWebElement> clmTypeDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(claimtypevalues_xpath));
            for (int i = 0; i < clmTypeDropDownList.Count; i++)
            {
                if (clmTypeDropDownList[i].Text == clmType)
                {
                    clmTypeDropDownList[i].Click();
                    break;
                }

            }

            //Products Claimed - Art Type
            Click(attributeName_xpath, FirstArticleType_xpath);
            IList<IWebElement> ArticleTypeDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ArticlesTypeValues_xpath));
            for (int i = 0; i < ArticleTypeDropDownList.Count; i++)
            {
                if (ArticleTypeDropDownList[i].Text == artType)
                {
                    ArticleTypeDropDownList[i].Click();
                    break;
                }

            }

            //Products Claimed - Qty
            SendKeys(attributeName_xpath, FirstQuantity_xpath, qty);

            //Products Claimed -Item #
            SendKeys(attributeName_xpath, Firstitem_xpath, item);

            //Products Claimed -Desc
            SendKeys(attributeName_xpath, firstDescription_claimedarticles_xpath, desc);

            //Products Claimed -Unit Wt
            SendKeys(attributeName_xpath, FirstUnitWgt_xpath, unitWT);

            //Products Claimed - Unit Val
            SendKeys(attributeName_xpath, firstUnitval_xpath, unitValue);

            //Products Claimed - Total Shipment Weight
            SendKeys(attributeName_xpath, TotalShipmentWeightValue_xpath, totalShipmentWeight);
            
        }

        public void FreightCalculations_Original (string o_ClaimedFreight, string o_CarrierChargestoDLSW, string o_DLSWChargestoCust, string o_DLSWRef)
        {
            //Freight Calculations -Original Row - Claimable ?, Claimed Freight, Carrier Charges to DLSW, DLSW Charges to Cust, DLSW Ref #
            SendKeys(attributeName_id, ClaimedFreight_Textbox_Original_Id, o_ClaimedFreight);
            SendKeys(attributeName_id, CarrierChargesToDLSW_Textbox_Original_Id, o_CarrierChargestoDLSW);
            SendKeys(attributeName_id, DLSWChargesToCust_Textbox_Original_Id, o_DLSWChargestoCust);
            SendKeys(attributeName_id, DLSWRefNumeber_Textbox_Original_Id, o_DLSWRef);
        }
        public void FreightCalculations_Return(string ret_ClaimedFreight, string ret_CarrierChargestoDLSW, string ret_DLSWChargestoCust, string ret_DLSWRef)
        {
            //Freight Calculations - Return Row - Claimable ?, Claimed Freight, Carrier Charges to DLSW, DLSW Charges to Cust, DLSW Ref #
            SendKeys(attributeName_id, ClaimedFreight_Textbox_Return_Id, ret_ClaimedFreight);
            SendKeys(attributeName_id, CarrierChargesToDLSW_Textbox_Return_Id, ret_CarrierChargestoDLSW);
            SendKeys(attributeName_id, DLSWChargesToCust_Textbox_Return_Id, ret_DLSWChargestoCust);
            SendKeys(attributeName_id, DLSWRefNumeber_Textbox_Return_Id, ret_DLSWRef);
        }
        public void FreightCalculations_Replacement(string rep_ClaimedFreight, string rep_CarrierChargestoDLSW, string rep_DLSWChargestoCust, string rep_DLSWRef)
        {
            //Freight Calculations - Replacement Row - Claimable ?, Claimed Freight, Carrier Charges to DLSW, DLSW Charges to Cust, DLSW Ref #
            SendKeys(attributeName_id, ClaimedFreight_Textbox_Replacement_Id, rep_ClaimedFreight);
            SendKeys(attributeName_id, CarrierChargesToDLSW_Textbox_Replacement_Id, rep_CarrierChargestoDLSW);
            SendKeys(attributeName_id, DLSWChargesToCust_Textbox_Replacement_Id, rep_DLSWChargestoCust);
            SendKeys(attributeName_id, DLSWRefNumeber_Textbox_Replacement_Id, rep_DLSWRef);
        }

        public void Comments (string comments)
        {
            //Comments
            SendKeys(attributeName_id, DetailsTab_CommentsSection_Edit_id, comments);
        }
    }
}
