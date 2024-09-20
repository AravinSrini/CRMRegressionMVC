using CRM.UITest.CommonMethods;
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

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public  class Insurance_Claims___Details_Tab___Comment_Section_Steps : InsuranceClaim
    {
        public string DetailsTab_Comment_Text = "Comments (5,000 chars max)";
        public string DetailsTab_CommentFields_Edit = "ALPHA NuMeRiC - 1234567890 -!@#$%^&*()_+={}[]|;:' <>,.?/_60";
        public string DetialsTab_Comment_MoreThan_FiveThousand = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount -1234567890 - !@#$%^&*()_+={}[]a|;:'n<>,.?/  __TotalCount_5020";
        

        [Given(@"I am a sales, sales management, operations or station owner use")]
        public void GivenIAmASalesSalesManagementOperationsOrStationOwnerUse()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"I will see a Comment Section")]
        public void ThenIWillSeeACommentSection()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Report.WriteLine("I will see the comment section");
            string ActualDetailsTab_Comment_Text = Gettext(attributeName_xpath, DetailsTab_CommentsSection_Text_Xpath);
            Assert.AreEqual(DetailsTab_Comment_Text, ActualDetailsTab_Comment_Text);
        }

        [Then(@"I am unable to edit the comments")]
        public void ThenIAmUnableToEditTheComments()
        {
            Report.WriteLine("I am unable to edit the Comment Section");
            IsElementDisabled(attributeName_id, DetailsTab_CommentsSection_Edit_id, "Comments");
        }

        [Then(@"I have the option to edit the Comments field")]
        public void ThenIHaveTheOptionToEditTheCommentsField()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Report.WriteLine("I have option to edit the Comments field");
            SendKeys(attributeName_id, DetailsTab_CommentsSection_Edit_id, DetailsTab_CommentFields_Edit);
            string Actual_TextAfterEnteringIn_CommentsField = GetValue(attributeName_id, DetailsTab_CommentsSection_Edit_id,"value");
            Assert.AreEqual(DetailsTab_CommentFields_Edit, Actual_TextAfterEnteringIn_CommentsField);
        }

        [Then(@"The Comments field will allow the following: alpha-numeric,text,special character,max length (.*)")]
        public void ThenTheCommentsFieldWillAllowTheFollowingAlpha_NumericTextSpecialCharacterMaxLength(int ExpectedLength_FiveThousand)
        {
            string DetailsTab_Comment_Filter_FiveThousant = DetialsTab_Comment_MoreThan_FiveThousand.Substring(0, 5000);

            Report.WriteLine("Comment Field will allow the Alpha Numeric, Text, Special Character and Maximum length is 5000");
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            executor.ExecuteScript("document.getElementById('DetailsTab_CommentsSection_Edit_id').sendkeys = DetailsTab_Comment_Filter_FiveThousant");
            //SendKeys(attributeName_id, DetailsTab_CommentsSection_Edit_id, DetailsTab_Comment_Filter_FiveThousant);
            //Thread.Sleep(120000);
            string Actual_TextAfterEnteringIn_CommentsField = Gettext(attributeName_id, DetialsTab_Comment_MoreThan_FiveThousand);
            int TotoalLengthCommets_Given = Actual_TextAfterEnteringIn_CommentsField.Length;
            Assert.AreEqual(ExpectedLength_FiveThousand, TotoalLengthCommets_Given);
            Assert.AreEqual(DetailsTab_Comment_Filter_FiveThousant, Actual_TextAfterEnteringIn_CommentsField);

        }

    }
}
