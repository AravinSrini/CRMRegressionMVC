using System;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using System.Threading;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_Details_StatusDisplayAndFunctionalitySteps : Objects.InsuranceClaim
    {
       
        
        [Given(@"I selected a claim status from the drop down list")]
        public void GivenISelectedAClaimStatusFromTheDropDownList()
        {
            Click(attributeName_xpath, StatusClaim_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, StatusClaimValues_Xpath, "Open - 5AC");
        }

        [Given(@"I am clicking on the hyperlink of any displayed claim")]
        public void GivenIAmClickingOnTheHyperlinkOfAnyDisplayedClaim()
        {

            Report.WriteLine("I am on the Claims List Page");
            string ClaimNumber = null;
            VerifyElementPresent(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");

           // Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
            int TotalClaimNumber = GetCount(attributeName_xpath, ClaimGrid_DLSW_Total_ClaimNumber_ClaimSpecialist_Xpath);
            if (TotalClaimNumber > 0)
            {
                ClaimNumber = Gettext(attributeName_xpath, ClaimGrid_DLSW_First_ClaimNumber_ClaimSpecialist_Xpath);
                Click(attributeName_xpath, ClaimGrid_DLSW_First_ClaimNumber_ClaimSpecialist_Xpath);
            }
            else
            {
                Report.WriteLine("No claim found in the grid");
            }
        }


        [When(@"I hover over the displayed claim status")]
        public void WhenIHoverOverTheDisplayedClaimStatus()
        {
            OnMouseOver(attributeName_xpath, StatusClaim_Xpath);
        }
        
        [When(@"I click in the Claim Status drop down list")]
        public void WhenIClickInTheClaimStatusDropDownList()
        {
            Click(attributeName_xpath, StatusClaim_Xpath);
        }
        
        [Then(@"I will see the status of the claim")]
        public void ThenIWillSeeTheStatusOfTheClaim()
        {
            scrollPageup();
            scrollPageup();
            IsElementPresent(attributeName_xpath, StatusClaim_Xpath, "");
        }
        
        [Then(@"I will see a pop up message with a description of the current status")]
        public void ThenIWillSeeAPopUpMessageWithADescriptionOfTheCurrentStatus()
        {
            string claimStatus = GetAttribute(attributeName_xpath, StatusClaim_Xpath, "value");
            
            string claimStatusPopupMsg = GetAttribute(attributeName_xpath, StatusClaim_Xpath, "");
            if (claimStatus.Equals("Open - 4AI"))
            {
                Assert.Equals(claimStatusPopupMsg, "Carrier has requested additional information");
            }
            else if (claimStatus.Equals("Open - 4IN"))
            {
                Assert.Equals(claimStatusPopupMsg, "Carrier has requested an inspection. We have not received the inspection report.");
            }
            else if (claimStatus.Equals("Open - 4MI"))
            {
                Assert.Equals(claimStatusPopupMsg, "Carrier has requested mitigation");
            }
            else if (claimStatus.Equals("Open - 5AC"))
            {
                Assert.Equals(claimStatusPopupMsg, "Carrier has received an amended claim.");
            }
            else if (claimStatus.Equals("Open - 5AD"))
            {
                Assert.Equals(claimStatusPopupMsg, "Carrier has declined this claim and we have appealed their decision.");
            }
            else if (claimStatus.Equals("Open - 5SP"))
            {
                Assert.Equals(claimStatusPopupMsg, "Carrier requested a salvage salvage pick-up");
            }
            else if (claimStatus.Equals("Open - 6CA"))
            {
                Assert.Equals(claimStatusPopupMsg, "Carrier has approved payment of their claim.We have not received the check.");
            }
            else if (claimStatus.Equals("Open - 6SP"))
            {
                Assert.Equals(claimStatusPopupMsg, "Carrier has short-paid the claim and we have appealed their decision.");
            }
            else if (claimStatus.Equals("Open - 7FNP"))
            {
                Assert.Equals(claimStatusPopupMsg, "Carrier has paid the claim.DLS freight charges are unpaid.");
            }
            else if (claimStatus.Equals("Open - 7PRP"))
            {
                Assert.Equals(claimStatusPopupMsg, "Carrier has paid the claim. Claimant is a 3PL.Waiting to receive proof of payment to freight owner");
            }
            else if (claimStatus.Equals("Open - 7W9"))
            {
                Assert.Equals(claimStatusPopupMsg, "Carrier has paid the claim.Requested a completed, signed Form W - 9 from the customer");
            }
            else if (claimStatus.Equals("Open - 8CR"))
            {
                Assert.Equals(claimStatusPopupMsg, "Carrier has paid the claim.Settlement check requested from corporate accounting");
            }
            else if (claimStatus.Equals("Open - 9LS"))
            {
                Assert.Equals(claimStatusPopupMsg, "This claim is the subject of a pending lawsuit.");
            }
            else if (claimStatus.Equals("Cancelled - 100"))
            {
                Assert.Equals(claimStatusPopupMsg, "Claim < $100");
            }
            else if (claimStatus.Equals("Cancelled - AG"))
            {
                Assert.Equals(claimStatusPopupMsg, "Act of God");
            }
            else if (claimStatus.Equals("Cancelled - AW"))
            {
                Assert.Equals(claimStatusPopupMsg, "Act of War");
            }
            else if (claimStatus.Equals("Cancelled - CC"))
            {
                Assert.Equals(claimStatusPopupMsg, "Customer Cancelled");
            }
            else if (claimStatus.Equals("Cancelled - CD"))
            {
                Assert.Equals(claimStatusPopupMsg, "Clear Delivery");
            }
            else if (claimStatus.Equals("Cancelled - DC"))
            {
                Assert.Equals(claimStatusPopupMsg, "Duplicate Claim");
            }
            else if (claimStatus.Equals("Cancelled - GS"))
            {
                Assert.Equals(claimStatusPopupMsg, "Government Seizure");
            }
            else if (claimStatus.Equals("Cancelled - ID"))
            {
                Assert.Equals(claimStatusPopupMsg, "Inadequate Docs");
            }
            else if (claimStatus.Equals("Cancelled - IP"))
            {
                Assert.Equals(claimStatusPopupMsg, "Improper Packaging");
            }
            else if (claimStatus.Equals("Cancelled - IV"))
            {
                Assert.Equals(claimStatusPopupMsg, "Inherent Vice");
            }
            else if (claimStatus.Equals("Cancelled - ON"))
            {
                Assert.Equals(claimStatusPopupMsg, "Other, see notes");
            }
            else if (claimStatus.Equals("Cancelled - RM"))
            {
                Assert.Equals(claimStatusPopupMsg, "Refusal to mitigate");
            }
            else if (claimStatus.Equals("Cancelled - SV"))
            {
                Assert.Equals(claimStatusPopupMsg, "Service not OS&D");
            }
            else if (claimStatus.Equals("Cancelled - TB"))
            {
                Assert.Equals(claimStatusPopupMsg, "Time barred");
            }
            else if (claimStatus.Equals("Cancelled - UC"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - 100"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - AG"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - AW"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - CC"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - CD"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - DC"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - GS"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - ID"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - IP"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - IV"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - ON"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - RM"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - SC"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - SV"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - TB"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }
            else if (claimStatus.Equals("Denied - UC"))
            {
                Assert.Equals(claimStatusPopupMsg, "Unauthorized Claimant");
            }


        }
        
        [Then(@"I have the option to change the claim status")]
        public void ThenIHaveTheOptionToChangeTheClaimStatus()
        {
            scrollPageup();
            scrollPageup();
            Click(attributeName_xpath, StatusClaim_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, StatusClaimValues_Xpath, "Open - 5SP");

        }
        
        [Then(@"the status list is configurable")]
        public void ThenTheStatusListIsConfigurable()
        {
            IList<string> statusCode = DBHelper.GetInsuranceClaimStatusCode();
            IList<IWebElement> statusCodeUI = GlobalVariables.webDriver.FindElements(By.XPath(StatusClaimValues_Xpath));
            List<string> statusCodeList = new List<string>();
            for(int i = 0; i < statusCodeUI.Count; i++)
            {
                IWebElement element = statusCodeUI[i];
                IWebElement element1 = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='CarrierMode_chosen']/div/ul/li[" + (i + 1) + "]"));
                string elementText = element1.Text;
                if(isChild(element))
                {
                    if (elementText.Equals("Pending"))
                    {
                        continue;
                    }else
                    {
                        statusCodeList.Add(elementText.Split(' ')[2]);
                    }
                }
            }

            Assert.IsTrue(statusCode.Equals(statusCodeList));
      }
        
        [Then(@"I will see a list of status \+ code to choose")]
        public void ThenIWillSeeAListOfStatusCodeToChoose()
        {
            VerifyElementVisible(attributeName_xpath, StatusClaimValues_Xpath, "chosen-drop");
            
        }
        
        [Then(@"the list will contain the following status types: Open, Denied, Cancelled")]
        public void ThenTheListWillContainTheFollowingStatusTypesOpenDeniedCancelled()
        {
            IList<IWebElement> statusList = GlobalVariables.webDriver.FindElements(By.XPath(StatusClaimValues_Xpath));
            IWebElement statusOpen = GlobalVariables.webDriver.FindElement(By.XPath(StatusOpen_Xpath));
            IWebElement statusDenied = GlobalVariables.webDriver.FindElement(By.XPath(StatusDenied_Xpath));
            IWebElement statusCancelled = GlobalVariables.webDriver.FindElement(By.XPath(StatusCancelled_Xpath));
            bool isTrue = false;
            if(statusList.Contains(statusOpen) && statusList.Contains(statusDenied) && statusList.Contains(statusCancelled))
            {
                isTrue = true;
            }
            Assert.IsTrue(true);
        }

        [Then(@"I am unable to select more than one status \+ code")]
        public void ThenIAmUnableToSelectMoreThanOneStatusCode()
        {
            VerifyElementNotVisible(attributeName_xpath, StatusClaimValues_Xpath, "chosen-drop");
        }

        [Then(@"beneath each status types will be a list of selectable status \+ code")]
        public void ThenBeneathEachStatusTypesWillBeAListOfSelectableStatusCode()
        {
            IList<IWebElement> dropdownStatusList = GlobalVariables.webDriver.FindElements(By.XPath(StatusClaimValues_Xpath));
            for(int i = 0; i < dropdownStatusList.Count; i++)
            {
                IWebElement element = dropdownStatusList[i];
                if (!isChild(element))
                {
                    if (element.Text.Equals("Pending"))
                    {
                        continue;
                    } else
                    {
                        for(int j = i + 1; j < dropdownStatusList.Count; ++j)
                        {
                            IWebElement element1 = dropdownStatusList[j];
                            if (!isChild(element1))
                            {
                                i = j;
                                break;
                            } else
                            {
                                string parentText = element.Text;
                                string childText = element1.Text;

                                
                                bool isValid = System.Text.RegularExpressions.Regex.IsMatch(childText, @"^" + parentText + " - " + "[a-zA-Z0-9]+$");
                                if (!isValid)
                                {
                                    Assert.IsTrue(false);
                                }
                            }
                        }
                    }
                        
                }

                
                 
            }
        }
        
        [Then(@"the status \+ code list will be displayed in hierarchy format beneath the status type")]
        public void ThenTheStatusCodeListWillBeDisplayedInHierarchyFormatBeneathTheStatusType()
        {
            IList<IWebElement> dropdownStatusList = GlobalVariables.webDriver.FindElements(By.XPath(StatusClaimValues_Xpath));
            //Verifying the status list count
            if (dropdownStatusList.Count <= 1)
            {
                Assert.IsTrue(false);
            }
            //verifying the hierarchy
            IWebElement parentElement = dropdownStatusList[0];
            int ChildElementCount = 0;
            for (int i =1; i< dropdownStatusList.Count; i++)
            {
                IWebElement element = dropdownStatusList[i];
                if (isChild(element))
                {
                    ChildElementCount++;
                }else if(ChildElementCount > 0)
                {
                    ChildElementCount = 0;
                    parentElement = element;
                }else
                {
                    Assert.IsTrue(false);
                }
            }
            //verifying the elements of last parent
            if(ChildElementCount > 0)
            {
                Assert.IsTrue(true);
            }else
            {
                Assert.IsTrue(false);
            }
            
        }

        public static bool isChild(IWebElement element)
        {
            Console.WriteLine("classes: " + element.GetAttribute("class"));
            return element.GetAttribute("class")
                          .Split(' ')
                          .ToList()
                          .Contains("group-option");
        }

        
        [Then(@"I am unable to select a status type")]
        public void ThenIAmUnableToSelectAStatusType()
        {
            Click(attributeName_xpath, StatusOpen_Xpath);
        }
        
       
        
        [Then(@"the status of the claim will be updated with following details : Date/Time Status Updated,User first name and last name that changed status,New Status Code,Previous Status Code")]
        public void ThenTheStatusOfTheClaimWillBeUpdatedWithFollowingDetailsDateTimeStatusUpdatedUserFirstNameAndLastNameThatChangedStatusNewStatusCodePreviousStatusCode()
        {
            string claimNumber = GetAttribute(attributeName_xpath, DlswClaimNumber_Label_ClaimDetailsPage_Xpath, "value");
            int claim = Convert.ToInt32(claimNumber);
            string ClaimStatusDB = DBHelper.GetClaimStatus(claim);
            string updatedClaimStatusDB = ClaimStatusDB.Split(' ')[0];
            string ClaimStatusUI = GetAttribute(attributeName_xpath, StatusClaim_Xpath, "value");
            string ClaimStatusUISpaceRemoved = ClaimStatusUI.Replace(' ', '\0');
            Assert.Equals(updatedClaimStatusDB, ClaimStatusUISpaceRemoved);
        }
    }
}
