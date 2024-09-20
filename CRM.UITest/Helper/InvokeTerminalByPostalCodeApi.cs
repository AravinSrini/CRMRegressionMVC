using System;
using CRM.UITest.Helper.Interfaces;
using System.Xml;
using System.Net;
using System.Configuration;
using System.IO;
using System.Text;
using System.Collections.Generic;





using CRM.UITest.CommonMethods;
using CRM.UITest.Helper;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.ShipmentExtract;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml;
using TechTalk.SpecFlow;

namespace CRM.UITest.Helper
{
    class InvokeTerminalByPostalCodeApi : IInvokeTerminalByPostalCodeApi
    {
        ShipmentExtractViewModel shipmentViewModels = null;

        string SCAC = null;
        string Pickup_postalCode = string.Empty;
        string Pickup_countryCode = string.Empty;
        string Delivery_postalCode = string.Empty;
        string Delivery_countryCode = string.Empty;

        public XmlDocument InvokeCarrierTerminalInformation(string terminalRequestXml, out string errorMessage)
        {
            XmlDocument responseXml = new XmlDocument();
            errorMessage = string.Empty;
            string _response = string.Empty;

            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(terminalRequestXml);
               HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["CarrierInformationUrl"]);
                request.Method = "POST";
                request.ContentType = "text/xml;charset=UTF-8";
                request.ContentLength = byteArray.Length;



                using (Stream webStream = request.GetRequestStream())
                {
                    webStream.Write(byteArray, 0, byteArray.Length);
                }

                WebResponse webResponse = request.GetResponse();

                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            responseXml.LoadXml(responseReader.ReadToEnd());
                        }
                    }
                }
            }
            catch (Exception)
            {
                errorMessage = "Terminal information not available at this time.";
            }

            return responseXml;

        }


        public IDictionary<string, string> getTerminalinfomethod(XmlDocument xmlDoc)
        {

            IDictionary<string, string> Terminalinfo = new Dictionary<string, string>();

            XmlNodeList SCACTYPE = xmlDoc.GetElementsByTagName("ns2:SCAC");

            Terminalinfo.Add("PICKUP_SCACTYPE", SCACTYPE[0].InnerXml);
            Terminalinfo.Add("DELIVERY_SCACTYPE", SCACTYPE[1].InnerXml);

            XmlNodeList CarrierName = xmlDoc.GetElementsByTagName("ns2:carrierName");

            Terminalinfo.Add("PICKUP_CarrierName", CarrierName[0].InnerXml);
            Terminalinfo.Add("DELIVERY_CarrierName", CarrierName[1].InnerXml);


            XmlNodeList TerminalName = xmlDoc.GetElementsByTagName("ns2:terminalName");

            Terminalinfo.Add("PICKUP_TerminalName", TerminalName[0].InnerXml);
            Terminalinfo.Add("DELIVERY_TerminalName", TerminalName[1].InnerXml);


            XmlNodeList Address1 = xmlDoc.GetElementsByTagName("ns2:address1");

            Terminalinfo.Add("PICKUP_Address1", Address1[0].InnerXml);
            Terminalinfo.Add("DELIVERY_Address1", Address1[1].InnerXml);



            XmlNodeList Address2 = xmlDoc.GetElementsByTagName("ns2:address2");
            Terminalinfo.Add("PICKUP_Address2", Address2[0].InnerXml);
            Terminalinfo.Add("DELIVERY_Address2", Address2[1].InnerXml);



            XmlNodeList City = xmlDoc.GetElementsByTagName("ns2:city");
            Terminalinfo.Add("PICKUP_City", City[0].InnerXml);
            Terminalinfo.Add("DELIVERY_City", City[1].InnerXml);


            XmlNodeList StateProvince = xmlDoc.GetElementsByTagName("ns2:stateProvince");
            Terminalinfo.Add("PICKUP_StateProvince", StateProvince[0].InnerXml);
            Terminalinfo.Add("DELIVERY_StateProvince", StateProvince[1].InnerXml);



            XmlNodeList PostalCode = xmlDoc.GetElementsByTagName("ns2:postalCode");
            Terminalinfo.Add("PICKUP_PostalCode", PostalCode[0].InnerXml);
            Terminalinfo.Add("DELIVERY_PostalCode", PostalCode[1].InnerXml);



            XmlNodeList Country = xmlDoc.GetElementsByTagName("ns2:country");
            Terminalinfo.Add("PICKUP_Country", Country[0].InnerXml);
            Terminalinfo.Add("DELIVERY_Country", Country[1].InnerXml);


            
            XmlNodeList ContactName = xmlDoc.GetElementsByTagName("ns3:name");
            if (ContactName.Count == 2)
            {
                Terminalinfo.Add("PICKUP_ContactName", ContactName[0].InnerXml);
                Terminalinfo.Add("DELIVERY_ContactName", ContactName[1].InnerXml);
            }
            else if (ContactName.Count == 4)
            {
                Terminalinfo.Add("PICKUP_ContactName", ContactName[0].InnerXml);
                Terminalinfo.Add("DELIVERY_ContactName", ContactName[2].InnerXml);
            }

            XmlNodeList ContactPhone = xmlDoc.GetElementsByTagName("ns3:phone");
            string replacehypenphone = ContactPhone[0].InnerXml.Replace("-", "");
            string replacehypendelphone = ContactPhone[1].InnerXml.Replace("-", "");
            string pickup_contactPhone = String.Format("({0}) {1}-{2}", replacehypenphone.Substring(0, 3), replacehypenphone.Substring(3, 3), replacehypenphone.Substring(6, 4));
            string Delivery_contactPhone = String.Format("({0}) {1}-{2}", replacehypendelphone.Substring(0, 3), replacehypendelphone.Substring(3, 3), replacehypendelphone.Substring(6, 4));
            Terminalinfo.Add("PICKUP_ContactPhone", pickup_contactPhone);
            Terminalinfo.Add("DELIVERY_ContactPhone", Delivery_contactPhone);
            // Terminalinfo.Add("PICKUP_ContactPhone", ContactPhone[0].InnerXml);
            //Terminalinfo.Add("DELIVERY_ContactPhone", ContactPhone[1].InnerXml);


            XmlNodeList ContactEmail = xmlDoc.GetElementsByTagName("ns3:email");
            Terminalinfo.Add("PICKUP_ContactEmail", ContactEmail[0].InnerXml);
            Terminalinfo.Add("DELIVERY_ContactEmail", ContactEmail[1].InnerXml);

            return Terminalinfo;
        }


        public IDictionary<string, string> GetShipmentValues(string shipmentReferenceNumber)
        {
            IDictionary<string, string> TerminalRequestInfo = new Dictionary<string, string>();
            ShipmentExtractViewModel shipmentdata = null;
            string uri = $"MercuryGate/OidLookup";

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");
            ShipmentExtract ext = new ShipmentExtract();
            shipmentViewModels = ext.getShipmentData(uri, headers, shipmentReferenceNumber, "Admin");
            SCAC = shipmentViewModels.CarrierRatesViewModel.ScacCode;
            for (var i = 0; i < shipmentViewModels.AddressViewModels.Count; i++)
            {

                if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "origin")
                {
                    Pickup_postalCode = shipmentViewModels.AddressViewModels[i].PostalCode;
                    
                    Pickup_countryCode = shipmentViewModels.AddressViewModels[i].CountryCode;

                }
                if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "destination")
                {
                    Delivery_postalCode = shipmentViewModels.AddressViewModels[i].PostalCode;
                    
                    Delivery_countryCode = shipmentViewModels.AddressViewModels[i].CountryCode;
                                       
                }
            }

            TerminalRequestInfo.Add("SCAC", SCAC);
            TerminalRequestInfo.Add("Pickup_postalCode", Pickup_postalCode);
            TerminalRequestInfo.Add("Pickup_countryCode", Pickup_countryCode);
            TerminalRequestInfo.Add("Delivery_postalCode", Delivery_postalCode);
            TerminalRequestInfo.Add("Delivery_countryCode", Delivery_countryCode);


            return TerminalRequestInfo;
        }




    }
}
