using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.CommonMethods
{
    public class InactiveOrActiveCustomer : Shipmentlist
    {
        public WebElementOperations ObjWebElementOperations = new WebElementOperations();
        
        public void GetActiveInactiveCust(string stationData)
        {
            string[] values = stationData.Split(',');
            List<string> StatID = new List<string>();
            List<string> ExpAcc = new List<string>();
            foreach (var v in values)
            {
                StatID.Add(v);
            }
            for (int i = 0; i < StatID.Count; i++)
            {
                string setupId = StatID[i];
                List<CustomerSetup> value = DBHelper.GetRecordsMappedforStationID(setupId);

                for (int j = 0; j < value.Count; j++)
                {
                    string custname = value[j].CustomerName;
                    ExpAcc.Add(custname);
                }
            }

          
            IList<IWebElement> UIvalue = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerSelection_Dropdown_Values_Xpath));
            if (UIvalue.Count > 0)
            {
                
                for (int k = 2; k < UIvalue.Count; k++)
                {
                    if (ExpAcc.Contains(UIvalue[k].Text))
                    {
                        bool CustomerAccount = DBHelper.GetInactiveCustomer(UIvalue[k].Text);
                        if (CustomerAccount == false)
                        {
                            
                                Report.WriteLine("Inactive Customer");
                                string InactiveCustomerColour = GetCSSValue(attributeName_xpath, ".//*[@id='CustomerType_chosen']/div/ul/li[" + k + "]", "background-color");
                                string ActualCustomerColour = "rgba(0, 0, 0, 0)";
                                if (InactiveCustomerColour == ActualCustomerColour)
                                {
                                Report.WriteLine("Inactive Customer is grayed out");
                                }
                                else
                                {
                                    Report.WriteFailure("Database value and UI is not matching for inactive customer");
                                    Assert.Fail();
                                }
                            }
                            

                            else
                            {
                                Report.WriteLine("Active Customer");
                            }
                    }
                        else
                        {
                            Report.WriteLine("Displaying Customer account " + UIvalue[k].Text + " is not mapped to logged in user");
                            

                        }
                    }
            }
        }

        public bool GetCustomerStatus(string Username, string Password, string CustomerName)
        {
            bool CustomerStatus;
            Report.WriteLine("Launch URL");
            LaunchURL();
            Report.WriteLine("Land on Homepage");
            Click(attributeName_id, SignIn_Id);
            Report.WriteLine("Enter Inactive Username and Password belongs to Inactive customer and click on Log in");
            WaitForElementVisible(attributeName_id, IDP_Username_Id, "UserName");
            SendKeys(attributeName_id, IDP_Username_Id, Username);
            SendKeys(attributeName_id, IDP_Password_Id, Password);

            CustomerAccount accountDetails = DBHelper.GetAccountDetails_By_CustomerName(CustomerName);
            CustomerStatus = accountDetails.IsActive;
            return CustomerStatus;
        }
    }
}
