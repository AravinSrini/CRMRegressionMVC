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
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class IntegrationComments_AddStatusComment_ModalSteps :Integration
   
    {
        
       
        string StatusVal = null;
        public WebElementOperations ObjWebElementOperations = new WebElementOperations();
        [When(@"I click on Add Comment Button")]
        public void WhenIClickOnAddCommentButton()
        {
            
            Click(attributeName_id, IntegrationIconLink_Dashboard_id);
          
            Click(attributeName_xpath, FirstrequestexpandIcon_xpath);
            
            MoveToElement(attributeName_id, AddCommentButton_Id);
            scrollpagedown();
            
            Click(attributeName_id, AddCommentButton_Id);
            Report.WriteLine("Clicked on Add Comments");
            
        }

        [When(@"I click on Add Comment Button of the selected request")]
        public void WhenIClickOnAddCommentButtonOfTheSelectedRequest()
        {

            Click(attributeName_id, IntegrationIconLink_Dashboard_id);
            
            Click(attributeName_xpath, FirstrequestexpandIcon_xpath);
            
            StatusVal = Gettext(attributeName_xpath, StatusbarValueInprogress_Xpath);
            MoveToElement(attributeName_id, AddCommentButton_Id);
           
            scrollpagedown();
            Click(attributeName_id, AddCommentButton_Id);
            Report.WriteLine("Clicked on Add Comments");
        }

        [Then(@"The Status on the comments modal should match with the Integration status")]
        public void ThenTheStatusOnTheCommentsModalShouldMatchWithTheIntegrationStatus()
        {
            Thread.Sleep(6000);
            string StatusModalVal = Gettext(attributeName_xpath, StatusModal_StatusValue_Xpath);
            if(StatusModalVal.Contains(StatusVal.Replace(":"," -")))
            {
                Report.WriteLine("Status displayed on comment status modal is Valid");
            }

            else
            {
                Assert.Fail();
            }
            
            
        }

        [When(@"I enter value to required field (.*)")]
        public void WhenIEnterValueToRequiredField(string Comment)
        {
           
            SendKeys(attributeName_id, StatusModal_CommentsTextBox_Id, Comment);
            Report.WriteLine("Entered value to comment field");
        }
        
        [When(@"I click on the Submit Button")]
        public void WhenIClickOnTheSubmitButton()
        {
            
            Click(attributeName_xpath, StatusModal_SubmitButton_Xpath);
            Report.WriteLine("Clicked on Submit button");
        }
        
        [When(@"I click on the cancel button")]
        public void WhenIClickOnTheCancelButton()
        {
            Click(attributeName_xpath, StatusModal_CancelButton_Xpath);
            Report.WriteLine("Clicked on Cancel Button");
        }
        
        [Then(@"I will be presented with the Status Comment Modal")]
        public void ThenIWillBePresentedWithTheStatusCommentModal()
        {
            VerifyElementPresent(attributeName_xpath, StatueModal_HeaderNameLabel_Xpath, "Status Comment");
            Report.WriteLine("Status Comment Modal is present");
        }
        
        [Then(@"The modal will contain the following - Header Name,Status,Comment field, Private and public radio buttons,Cancel button and Submit Button")]
        public void ThenTheModalWillContainTheFollowing_HeaderNameStatusCommentFieldPrivateAndPublicRadioButtonsCancelButtonAndSubmitButton()
        {
            VerifyElementPresent(attributeName_xpath, StatueModal_HeaderNameLabel_Xpath, "");
            VerifyElementPresent(attributeName_xpath, StatusModal_StatusLabel_Xpath, "Status");
            VerifyElementPresent(attributeName_xpath, StatusModal_CommentsLabel_Xpath, "Comments");
            VerifyElementPresent(attributeName_id, StatusModal_CommentsTextBox_Id, "Comments");
            VerifyElementPresent(attributeName_xpath, StatusModal_PublicRadioButton_Xpath, "Public");
            VerifyElementPresent(attributeName_xpath, StatusModal_PublicRadioButton_Xpath, "Private");
            VerifyElementPresent(attributeName_xpath, StatusModal_CancelButton_Xpath, "Cancel Button");
            VerifyElementPresent(attributeName_xpath, StatusModal_CancelButton_Xpath, "Submit Button");
            Report.WriteLine("Verified the existence of all the expected elements on Add Comments Modal");
        }
        
        [Then(@"I must be able to pass a maximun of (.*) characters to Comment field within Status Comment modal (.*)")]
        public void ThenIMustBeAbleToPassAMaximunOfCharactersToCommentFieldWithinStatusCommentModal(int p0, string Comment)
        {
            SendKeys(attributeName_id, StatusModal_CommentsTextBox_Id, Comment);
            string ValidCommentsUI = GetValue(attributeName_id, StatusModal_CommentsTextBox_Id, "value");
            Assert.AreEqual(Comment, ValidCommentsUI);
            Report.WriteLine("Able to pass 500 characters to Comments field");
        }
        
        [Then(@"I must not be able to pass more than (.*) characters to Comment field within Status Comment modal (.*)")]
        public void ThenIMustNotBeAbleToPassMoreThanCharactersToCommentFieldWithinStatusCommentModal(int p0, string Comment)
        {
            SendKeys(attributeName_id, StatusModal_CommentsTextBox_Id, Comment);
            string InValidCommentsUI = GetValue(attributeName_id, StatusModal_CommentsTextBox_Id, "value");
            Assert.AreNotEqual(Comment, InValidCommentsUI);
            Report.WriteLine("Validated Comments field by passing more than 500 characters");
        }
        
        [Then(@"I must be able to view Private radio button been selected by default")]
        public void ThenIMustBeAbleToViewPrivateRadioButtonBeenSelectedByDefault()
        {
            RadiobuttonChecked(attributeName_xpath, "//*[@id='Private']/input[1]");
            Report.WriteLine("Private Radio Button is checked by default");
        }

        [Then(@"The comment should be saved with a time stamp - (.*),(.*)")]
        public void ThenTheCommentShouldBeSavedWithATimeStamp_(string StationName, string Comments)
        {
            scrollPageup();
            scrollPageup();
          
            Click(attributeName_xpath, FirstrequestexpandIcon_xpath);
          
            MoveToElement(attributeName_id, AddCommentButton_Id);
            scrollpagedown();
            scrollpagedown();
           
            IList<IWebElement> CommentsUI = GlobalVariables.webDriver.FindElements(By.XPath(CommentView_Xpath));
            List<string> UICommentView = ObjWebElementOperations.GetListFromIWebElement(CommentsUI);

            IList<IWebElement> CommenterUI = GlobalVariables.webDriver.FindElements(By.XPath(CommenterView_Xpath));
            List<string> UICommenterView = ObjWebElementOperations.GetListFromIWebElement(CommenterUI);

            IList<IWebElement> DateTimeUI = GlobalVariables.webDriver.FindElements(By.XPath(DateTimeView_Xpath));
            List<string> UIDateTimeView = ObjWebElementOperations.GetListFromIWebElement(DateTimeUI);

            IList<IWebElement> PublicPrivateUI = GlobalVariables.webDriver.FindElements(By.XPath(PrivatePublicView_Xpath));
            List<string> UIPublicPrivateView = ObjWebElementOperations.GetListFromIWebElement(PublicPrivateUI);

            IntegrationRequestComment CommentCheck = DBHelper.GetPrivateCommentsValue(StationName, Comments);
            
            for (int i = 0; i < UICommentView.Count; i++)
            {
                if (CommentCheck.Comment == UICommentView[i])
                {
                  
                    Assert.AreEqual(CommentCheck.Commenter, UICommenterView[i]);
                    //Assert.AreEqual(CommentCheck.CreatedDate, UIDateTimeView[i]);
                    if(CommentCheck.IsPrivate == true)
                    {
                        Assert.AreEqual("Private", UIPublicPrivateView[i]);
                    }
                    else
                    {
                        Assert.Fail();
                    }
                    Report.WriteLine("Entered Status comment related values are inserted in db and displayed in UI");
                }
                else
                {
                    Report.WriteLine("Displayed Comment does not match with the expected value ");
                }
            }

        }

        [Then(@"I should return to the Integration Request List page\.")]
        public void ThenIShouldReturnToTheIntegrationRequestListPage_()
        {
            VerifyElementPresent(attributeName_id, AddCommentButton_Id, "Status Modal");
            Report.WriteLine("Status Modal is closed and retured to Integration Request list page");
        }
    }
}
