using System;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Confirmation_Screen__All_Users
{
    [Binding]
    public class ShipmentConfirmationLTLMVC5_PageElements_AllUsersSteps :AddShipments
    {
        [Then(@"I should be display with service,Bol number,Status,Upload Shipping Documents section fields and View Shipment Details,Print Shipping Labels,Add Another Shipment")]
        public void ThenIShouldBeDisplayWithServiceBolNumberStatusUploadShippingDocumentsSectionFieldsAndViewShipmentDetailsPrintShippingLabelsAddAnotherShipment()
        {
            Report.WriteLine("displaying with service,Bol number,Status,Upload Shipping Documents section fields and View Shipment Details,Print Shipping Labels,Add Another Shipment");
            VerifyElementVisible(attributeName_xpath, confirmation_pageheader, "Header");
            VerifyElementVisible(attributeName_xpath, confirmation_Serviceslabel, "services");
            VerifyElementVisible(attributeName_xpath, confirmation_BOLNumberlabel, "Bol");
            VerifyElementVisible(attributeName_xpath, confirmation_Statuslabel, "status");
            VerifyElementVisible(attributeName_xpath, confirmation_uploaddocumentsection, "uploadsection");
            VerifyElementVisible(attributeName_xpath, confirmation_pageheader, "Header");
            VerifyElementVisible(attributeName_xpath, confirmation_Serviceslabel, "services");
            VerifyElementVisible(attributeName_xpath, confirmation_BOLNumberlabel, "Bol");

        }

        [Then(@"I should displayed with document uploadarea and ''(.*)''and '(.*)'")]
        public void ThenIShouldDisplayedWithDocumentUploadareaAndAnd(string Usertype,string verbiage2)
        {
            if (Usertype == "Internal")
            {
                Report.WriteLine("displaying TheDisplayDocumentUploadArea and verbiages");
                VerifyElementVisible(attributeName_xpath, confirmation_Noteverbiage_internal, "varbiage");
                Verifytext(attributeName_xpath, confirmation_dropzoneheader_internal, verbiage2);

            }
            else
            {
                Report.WriteLine("displaying TheDisplayDocumentUploadArea and verbiages");
                VerifyElementVisible(attributeName_xpath, confirmation_Noteverbiage, "varbiage");
                Verifytext(attributeName_xpath, confirmation_dropzoneheader, verbiage2);
            }
        }


        [Then(@"I should'(.*)' be display the option to click on a link to browse my computer and networks to locate a document and drop it to the document upload area and option to drag and drop a document to the document upload area")]
        public void ThenIShouldBeDisplayTheOptionToClickOnALinkToBrowseMyComputerAndNetworksToLocateADocumentAndDropItToTheDocumentUploadAreaAndOptionToDragAndDropADocumentToTheDocumentUploadArea(string Usertype)
        {
            if (Usertype == "Internal")
            {
                Report.WriteLine("displaying TheDisplayDocumentUploadArea and verbiages");
                VerifyElementVisible(attributeName_xpath, confirmation_linktobrowse_internal, "link");

            }
            else
            {
                Report.WriteLine("displaying TheDisplayDocumentUploadArea and verbiages");
                VerifyElementVisible(attributeName_xpath, confirmation_linktobrowse, "link");
            }
        }

        [Then(@"I should be display the '(.*)','(.*)',display document upload area")]
        public void ThenIShouldBeDisplayTheDisplayDocumentUploadArea(string verbiage1, string verbiage2)
        {
            Report.WriteLine("displaying TheDisplayDocumentUploadArea and verbiages");
            VerifyElementVisible(attributeName_xpath, confirmation_Noteverbiage, "varbiage");
            Verifytext(attributeName_xpath, confirmation_dropzoneheader, verbiage2);
        }
        
        [Then(@"I should be display the option to click on a link to browse my computer and networks to locate a document and drop it to the document upload area and option to drag and drop a document to the document upload area")]
        public void ThenIShouldBeDisplayTheOptionToClickOnALinkToBrowseMyComputerAndNetworksToLocateADocumentAndDropItToTheDocumentUploadAreaAndOptionToDragAndDropADocumentToTheDocumentUploadArea()
        {
            Report.WriteLine("displaying TheDisplayDocumentUploadArea and verbiages");
            VerifyElementVisible(attributeName_xpath, confirmation_linktobrowse, "link");
        }

        [Then(@"I should '(.*)' be displayed with message for receiving BOL document '(.*)' and Bill of Lading button")]
        public void ThenIShouldBeDisplayedWithMessageForReceivingBOLDocumentAndBillOfLadingButton(string Usertype, string message)
        {
           if(Usertype== "Internal")
            {
                Report.WriteLine("displaying with message for receiving BOL document and Bill of Lading button");
                scrollpagedown();
                Thread.Sleep(500);
                Verifytext(attributeName_xpath, confirmation_confirmmessageemail_internal, message);
                Verifytext(attributeName_xpath, confirmation_confirmmessageinternal, "Your shipment has been submitted.");

            }
            else
            {
                Report.WriteLine("displaying with message for receiving BOL document and Bill of Lading button");
                scrollpagedown();
                Thread.Sleep(500);
                Verifytext(attributeName_xpath, confirmation_confirmmessageemail, message);
                Verifytext(attributeName_xpath, confirmation_confirmmessage, "Your shipment has been submitted.");

            }
        }

        [Then(@"I should '(.*)'be displayed with message for receiving summary document '(.*)' and Shipment Summary button")]
        public void ThenIShouldBeDisplayedWithMessageForReceivingSummaryDocumentAndShipmentSummaryButton(string Usertype, string message)
        {
            if (Usertype == "Internal")
            {
                Report.WriteLine("displaying with message for receiving BOL document and Bill of Lading button");
                scrollpagedown();
                Thread.Sleep(500);
                Verifytext(attributeName_xpath, confirmation_confirmmessageemail_internal, message);
                Verifytext(attributeName_xpath, confirmation_confirmmessageinternal, "Your shipment has been submitted.");

            }
            else
            {
                Report.WriteLine("displaying with message for receiving BOL document and Bill of Lading button");
                scrollpagedown();
                Thread.Sleep(500);
                Verifytext(attributeName_xpath, confirmation_confirmmessageemail, message);
                Verifytext(attributeName_xpath, confirmation_confirmmessage, "Your shipment has been submitted.");

            }
        }
              

    }
}
